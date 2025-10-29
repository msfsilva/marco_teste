using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.Relatórios;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using ProjectConstants;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAgrupadorItemSemelhanteListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadAgrupadorItemSemelhanteListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        #region IWTListForm

        public override Type getTipoEntidade()
        {
            return typeof (ProdutoKClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            CadAgrupadorItemSemelhanteForm form = new CadAgrupadorItemSemelhanteForm((ProdutoKClass) entidade, this);
            form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
            form.ShowDialog();
        }

        public override IWTDataGridView getDataGrid()
        {
            return this.iwtDataGridView1;
        }

        public override AcsUsuarioClass getUsuarioAtual()
        {
            return LoginClass.UsuarioLogado.loggedUser;
        }
        #endregion

        private void AtivarDesativar()
        {
            try
            {
                string operacao;
                if (this.rdbAtivos.Checked)
                {
                    operacao = "Desativar";
                }
                else
                {
                    operacao = "Reativar";
                }


                if (MessageBox.Show(this, "Essa operação irá " + operacao + " os kanbans selecionados, deseja continuar?", operacao + " Kanbans", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    return;
                }

                JustificativaForm form = new JustificativaForm("Entre com a justificativa para a operação:");
                form.ShowDialog(this);

                if (form.Abortar)
                {
                    return;
                }

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {

                    ProdutoKClass kb = (ProdutoKClass)row.DataBoundItem;

                    bool controleRevisaoAnterior = kb.ControleRevisaoHabilitado;
                    try
                    {
                        kb.ControleRevisaoHabilitado = false;
                        kb.Ativo = !kb.Ativo;
                        kb.UltimaRevisao = form.Justificativa;
                        kb.UltimaRevisaoData = DataIndependenteClass.GetData();
                        kb.UltimaRevisaoUsuario = getUsuarioAtual();
                        kb.Save();

                    }
                    finally
                    {
                        kb.ControleRevisaoHabilitado = controleRevisaoAnterior;
                    }
                }

                this.ForceInitializeDataGrid();
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao desativar ou reativar o Kb de Itens Manufaturados.\r\n" + e.Message, e);
            }
        }

        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            this.iwtTextBox1.Focus();
            if (this.ModoSelecao)
            {
                this.rdbAtivos.Checked = true;
                this.rdbAtivos.Visible = false;
                this.rdbInativos.Visible = false;
            }
        }


        private void btnEtiquetaKb_Click(object sender, EventArgs e)
        {
            if (this.getDataGrid().SelectedRows.Count > 0)
            {
                try
                {
                    List<ProdutoKClass> produtosK = new List<ProdutoKClass>();
                    foreach (IWTDataGridViewRow item in this.getDataGrid().SelectedRows)
                    {
                        produtosK.Add((ProdutoKClass)item.DataBoundItem);
                    }
                    EtiquetaCompraRepetitivaReportForm form = new EtiquetaCompraRepetitivaReportForm(produtosK, null, null,null);
                    form.ShowDialog();
                }
                catch (Exception a)
                {
                    MessageBox.Show(a.Message, "Etiqueta de Kb", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }  
            }

            
        }

        private void btnAtivarDesativar_Click(object sender, EventArgs e)
        {
            try
            {
                AtivarDesativar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

        private void rdbAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAtivos.Checked)
            {
                this.btnAtivarDesativar.Text = "Desativar";
            }
            else
            {
                this.btnAtivarDesativar.Text = "Reativar";
            }
        }

        private void rdbInativos_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdbAtivos.Checked)
            {
                this.btnAtivarDesativar.Text = "Desativar";
            }
            else
            {
                this.btnAtivarDesativar.Text = "Reativar";
            }
        }
    }
}
