using System;
using System.Collections.Generic;
using System.Linq;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaExpedicao
{
    public class ItemConferencia
    {

        public ItemConferenciaKey Key { get; private set; }
        public ConferenciaDefaultClass Parent { get; private set; }
        public Double QtdOriginal
        {
            get
            {
                return this._subItens.Sum(sub => sub.QtdOriginal);

            }
        }
        public Double QtdConferida
        {
            get
            {
                return this.QtdOriginal - this.Saldo;
            }
        }
        public Double QtdConferidaNessaOperacao
        {
            get
            {
                return this._subItens.Sum(sub => sub.QtdConferidaNessaOperacao);

            }
        }
        public Double Saldo
        {
            get
            {
                return this._subItens.Sum(sub => sub.Saldo);

            }
        }
        public Double SaldoNessaOperacao
        {
            get
            {
                return this._subItens.Sum(sub => sub.SaldoNessaOperacao);

            }
        }


        public int Situacao
        {
            get
            {
                bool existe0 = false;
                bool existe1 = false;
                bool existe2 = false;
                
                foreach (SubItemConferencia sub in this._subItens)
                {
                    switch (sub.Situacao)
                    {
                        case 0:
                            existe0 = true;
                            break;
                        case 1:
                            existe1 = true;
                            break;
                        case 2:
                            existe2 = true;
                            break;
                    }
                }

                if (existe1)
                {
                    return 1;
                }

                if (existe0 && existe2)
                {
                    return 1;
                }

                if (existe2)
                {
                    return 2;
                }
                return 0;
            }
        }

        private readonly List<string> _itensSequenciaUtilizados;
        private readonly List<SubItemConferencia> _subItens;

        public ItemConferencia(ItemConferenciaKey key, ConferenciaDefaultClass parent)
        {

            this.Key = key;
                                                                                                                                                                                                                    
            this.Parent = parent;

            this._itensSequenciaUtilizados = new List<string>();
            this._subItens = new List<SubItemConferencia>();

        }

        public void AddItemFilho(int idOrderItemEtiqueta, Double qtdOriginal, Double saldo, int situacao, Double qtdAConferirNessaOperacao, AcsUsuarioClass Usuario)
        {
            this._subItens.Add(new SubItemConferencia(idOrderItemEtiqueta, qtdOriginal, saldo, situacao, qtdAConferirNessaOperacao, this,Usuario));
        }

        internal bool IsSequencialLivre(string numeroSequencial)
        {
            if (this.Key.Tipo == TipoItem.Customizado)
            {
                return !this._itensSequenciaUtilizados.Contains(numeroSequencial);
            }

            return true;
        }

        internal void Baixa(string numeroSequencial, double? qtdEtiqueta)
        {
            double qtdBaixar = qtdEtiqueta != null ? qtdEtiqueta.Value : 1;

            //Testa Sequencial da etiqueta só para customizados
            if (this.Key.Tipo == TipoItem.Customizado)
            {
                if (this._itensSequenciaUtilizados.Contains(numeroSequencial))
                {
                    throw new Exception("Etiqueta já conferida.");
                }

                this._itensSequenciaUtilizados.Add(numeroSequencial);
            }

            if (Saldo >= qtdBaixar)
            {
                double tmpQtd = qtdBaixar;

                foreach (SubItemConferencia sub in this._subItens.Where(sub => sub.Situacao != 2))
                {
                    if (sub.SaldoNessaOperacao >= tmpQtd)
                    {
                        sub.Baixa(tmpQtd);
                        break;
                    }

                    tmpQtd -= sub.SaldoNessaOperacao;
                    sub.Baixa(sub.SaldoNessaOperacao);
                }
            }
            else
            {
                throw new Exception("Item já foi totalmente Conferido ou sem Quantidade disponível para essa etiqueta");
            }

        }

        internal void Save(IWTPostgreNpgsqlConnection conn, long idOrderItemEtiquetaConferenciaPai)
        {
            foreach (SubItemConferencia sub in this._subItens)
            {
                sub.Save(conn, sub.IdOrderItemEtiqueta == this.Parent.IdOrderItemEtiqueta,idOrderItemEtiquetaConferenciaPai);
            }
        }



    }
}