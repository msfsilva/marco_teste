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
    public partial class CadModeloFiscalICMSListForm : IWTListForm
    {
        private TipoForm Tipo;

        public CadModeloFiscalICMSListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        public override Type getTipoEntidade()
        {
            return typeof(ModeloFiscalIcmsClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadModeloFiscalICMSForm form = new CadModeloFiscalICMSForm((ModeloFiscalIcmsClass)entidade, this);
                form.VerificaUtilizacao = this.Tipo != TipoForm.Gerencial;
                form.ShowDialog();
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
            return new List<SearchParameterClass>() { new SearchParameterClass("mfi_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
        }

        private void btnAliquota_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.iwtDataGridView1.SelectedRows.Count==0)
                {
                    throw new Exception("Selecione o Modelo do ICMS para visualizar as alíquotas dos estados.");
                }

                ModeloFiscalIcmsClass modeloFiscalIcms = (ModeloFiscalIcmsClass) ((IWTDataGridViewRow)this.iwtDataGridView1.SelectedRows[0]).DataBoundItem;

                CadAliquotaICMSListForm form = new CadAliquotaICMSListForm(TipoForm.Gerencial, modeloFiscalIcms);
                form.ShowDialog(this);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
