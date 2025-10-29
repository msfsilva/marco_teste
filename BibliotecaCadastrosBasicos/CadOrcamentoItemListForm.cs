using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.ClassesAuxiliares;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaPedidos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadOrcamentoItemListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadOrcamentoItemListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }


        #region Funcoes ListForm
        public override Type getTipoEntidade()
        {
            return typeof (OrcamentoItemClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadOrcamentoItemForm form = new CadOrcamentoItemForm((OrcamentoItemClass)entidade, this, this.Tipo);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }

        public override List<SearchParameterClass> getParametrosBuscaIniciais()
        {
            return new List<SearchParameterClass>()
                       {
                           new SearchParameterClass("SubLinha", 0),
                           new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica),
                           new SearchParameterClass("Posicao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                       };
        }
        #endregion

        private void Cancelar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count != 1)
                {
                    throw new Exception("Selecione um orçamento para ser cancelado.");
                }



                if (MessageBox.Show(this, "Você deseja Cancelar o item selecionado?", "Cancelamento", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OrcamentoItemClass orcamento = (OrcamentoItemClass) ((IWTDataGridViewRow) this.getDataGrid().SelectedRows[0]).DataBoundItem;


                    if (orcamento.Status != StatusOrcamento.Pendente)
                    {
                        throw new Exception("Só é possível cancelar orçamentos pendentes");
                    }
                    else
                    {
                        CadOrcamentoItemCancelamentoForm form = new CadOrcamentoItemCancelamentoForm(orcamento);
                        form.ShowDialog();
                        this.getDataGrid().InvalidateRow(this.getDataGrid().SelectedRows[0].Index);
                    }


                }

                else
                {
                    return;
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao cancelar o item selecionado.\r\n" + e.Message);
            }
        }

        private void Imprimir()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count > 0)
                {
                    int i = 0;
                    List<PedidoEspelhoParametrosBuscaClass> parametrosBusca = new List<PedidoEspelhoParametrosBuscaClass>();
                    while (i < this.getDataGrid().SelectedRows.Count)
                    {

                        OrcamentoItemClass orcamento = (OrcamentoItemClass)((IWTDataGridViewRow)this.getDataGrid().SelectedRows[0]).DataBoundItem;

                        PedidoEspelhoParametrosBuscaClass parametros = new PedidoEspelhoParametrosBuscaClass
                        {
                            idCliente = orcamento.Cliente.ID,
                            numero = orcamento.Numero,
                            posicao = orcamento.Posicao
                        };
                        parametrosBusca.Add(parametros);
                        i++;
                    }

                    PedidoEspelhoReportForm form = new PedidoEspelhoReportForm(parametrosBusca, PedidoOrcamento.Orcamento);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show(this, "Selecione um orçamento para imprimir.", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Aprovar()
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count != 1)
                {
                    throw new Exception("Selecione um orçamento para ser aprovado.");
                }



                if (MessageBox.Show(this, "Você deseja Aprovar o item selecionado?", "Aprovação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OrcamentoItemClass orcamento = (OrcamentoItemClass)((IWTDataGridViewRow)this.getDataGrid().SelectedRows[0]).DataBoundItem;


                    if (orcamento.Status != StatusOrcamento.Pendente)
                    {
                        throw new Exception("Só é possível aprovar orçamentos pendentes");
                    }
                    else
                    {
                        orcamento.Aprovar();
                        this.getDataGrid().InvalidateRow(this.getDataGrid().SelectedRows[0].Index);

                        MessageBox.Show(this, "Pedido criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                else
                {
                    return;
                }

            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new ExcecaoTratada("Erro ao cancelar o item selecionado.\r\n" + e.Message);
            }
        }

        #region Eventos

    
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cancelar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnImprimirPedido_Click(object sender, EventArgs e)
        {
            try
            {
                Imprimir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAprovar_Click(object sender, EventArgs e)
        {
            try
            {
                Aprovar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

       

      
    }
}
