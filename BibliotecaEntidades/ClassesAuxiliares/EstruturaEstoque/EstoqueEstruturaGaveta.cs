#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    public class EstoqueEstruturaGaveta : SubEstoque
    {
        EstoqueGavetaClass Gaveta
        {
            get { return (EstoqueGavetaClass)this.EntidadeBase; }

        }

        public EstoqueEstruturaGaveta(EstoqueGavetaClass gaveta, SubEstoque pai)
            : base(gaveta,gaveta.Identificacao,gaveta.Descricao,gaveta.Ativo,pai)
        {

        }


        public override string ToString()
        {
            return "Gaveta: " + this.Identificacao;
        }

        public override void LoadSubNiveis()
        {
            try
            {
              
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da estrutura Gaveta.\r\n" + e.Message);
            }
        }

        public override SubEstoque AddSubNivel(string identificacao, string descricao, bool ativo)
        {
            throw new ExcecaoTratada("Não é possível adicionar um subnivel em uma gaveta");
        }

        public override SubEstoque AddSubNivel(AbstractEntity entidadeBase)
        {
            throw new ExcecaoTratada("Não é possível adicionar um subnivel em uma gaveta");
            
        }

        public override void SetAtivo(bool ativo)
        {
            if (ativo != this.Gaveta.Ativo)
            {
                if (!ativo)
                {
                    IWTPostgreNpgsqlCommand command = null;
                    command = Gaveta.SingleConnection.CreateCommand();
                
                    List<InventarioReportClass> itens = EstoqueMovimentacao.Inventario(null, null, null, this.Gaveta, false, null, null, ref command,LoginClass.UsuarioLogado.loggedUser);
                    if (itens.Any(a => a.Ativo && Math.Abs(a.Quantidade) > 0.00001))
                    {
                        throw new ExcecaoTratada("Não é possível desativar a gaveta pois ela possui itens com quantidades diferentes de zero");
                    }
                }

                this.Gaveta.Ativo = ativo;
            }
        }

        public override bool GetAtivo()
        {
            return this.Gaveta.Ativo;
        }

        public override void ExcluirSubNivel(SubEstoque noExcluir)
        {
            throw new ExcecaoTratada("Não é possível excluir um subnivel de uma gaveta");
        }

        public override void AtualizarEntidade()
        {
            Gaveta.Identificacao = Identificacao;
            Gaveta.Descricao = Descricao;

        }

        public override List<EstoqueGavetaReportClass> GerarEtiqueta()
        {
            return EstoqueGavetaReportClass.Gerar(
                new List<EstoqueGavetaClass>() {this.Gaveta}
                );
        }
    }
}
