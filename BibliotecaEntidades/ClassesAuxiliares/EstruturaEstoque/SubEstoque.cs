using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares.EstruturaEstoque
{
    public abstract class SubEstoque : TreeNode
    {
        public AbstractEntity EntidadeBase { get; set; }

        public string Identificacao { get; protected set; }
        public string Descricao { get; protected set; }
        public SubEstoque Pai { get; protected set; }


        protected List<SubEstoque> SubNiveis;

        #region FuncoesAbstratas

        public abstract override string ToString();
        public abstract void LoadSubNiveis();
        public abstract SubEstoque AddSubNivel(string identificacao, string descricao, bool ativo);
        public abstract SubEstoque AddSubNivel(AbstractEntity entidadeBase);

        public abstract void SetAtivo(bool ativo);
        public abstract bool GetAtivo();

        public abstract void ExcluirSubNivel(SubEstoque noExcluir);

        public abstract void AtualizarEntidade();
        public abstract List<EstoqueGavetaReportClass> GerarEtiqueta();

        #endregion

        public SubEstoque(AbstractEntity entidadeBase, string identificacao, string descricao,bool ativo, SubEstoque pai)
        {
            EntidadeBase = entidadeBase;
            Identificacao = identificacao;
            Descricao = descricao;
            Pai = pai;

            
            this.SubNiveis = new List<SubEstoque>();

            if (EntidadeBase != null)
            {
                this.LoadSubNiveis();
            }

            base.Text = this.ToString();
            this.SetAtivo(ativo);
        }
        
        public void AtualizarDados(string identificacao, string descricao, bool ativo)
        {
            if (this.Pai != null)
            {
                Identificacao = identificacao;
                Descricao = descricao;
                if (GetAtivo() != ativo)
                {
                    this.SetAtivo(ativo);
                }

                base.Text = this.ToString();
                AtualizarEntidade();
            }
            else
            {
                throw new Exception("Não é possível atualizar os dados do nível principal do estoque.");
            }

        }
        public string IdentificacaoCompleta()
        {
            if (Pai != null)
            {
                return this.Pai.IdentificacaoCompleta() + ">" + this.Identificacao;
            }
            else
            {
                return this.Identificacao;
            }
        }

        
    }
}