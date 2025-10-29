using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFomularioRetiradaManualEstoqueListForm : IWTListForm
    {

        public CadFomularioRetiradaManualEstoqueListForm()
        {
            InitializeComponent();
        }


        #region Funções List

        public override Type getTipoEntidade()
        {
            return typeof (FomularioRetiradaManualEstoqueClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadFomularioRetiradaManualEstoqueForm form = new CadFomularioRetiradaManualEstoqueForm((FomularioRetiradaManualEstoqueClass) entidade, this);
                form.VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial;
                form.SomenteLeitura = entidade!=null && ((FomularioRetiradaManualEstoqueClass) entidade).Retirado;
                form.ShowDialog();

                if (entidade == null)
                {
                    if (MessageBox.Show(this, "Você deseja inserir outro formulário de movimentação manual de estoque?", "Novo Formulário", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.chamadaForm(null);
                    }
                }

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
            return new List<SearchParameterClass>() {new SearchParameterClass("ID", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)};
        }

        #endregion


        private void Imprimir(bool etiqueta)
        {
            try
            {
                if (this.getDataGrid().SelectedRows.Count <= 0) return;
                List<FomularioRetiradaManualEstoqueClass> formsImprimir = new List<FomularioRetiradaManualEstoqueClass>();

                foreach (IWTDataGridViewRow row in this.getDataGrid().SelectedRows)
                {
                    FomularioRetiradaManualEstoqueClass formulario = (FomularioRetiradaManualEstoqueClass) row.DataBoundItem;
                    if (formulario.Retirado)
                    {
                        throw new ExcecaoTratada("Não é possível imprimir o formulário "+formulario+" pois ele já foi retirado do estoque");
                    }

                    formsImprimir.Add(formulario);
                }

                CadFomularioRetiradaManualEstoqueReportForm form = new CadFomularioRetiradaManualEstoqueReportForm(formsImprimir, etiqueta, false);
                form.ShowDialog();


            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao Imprimir\r\n" + e.Message, e);
            }
        }

        #region Eventos

        private void btnImprimirEtiqueta_Click(object sender, EventArgs e)
        {
            try
            {
                this.Imprimir(etiqueta: true);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnImprimirFormulario_Click(object sender, EventArgs e)
        {
            try
            {
                this.Imprimir(etiqueta: false);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        #endregion
    }
}
