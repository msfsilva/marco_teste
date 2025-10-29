using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadAliquotaICMSListForm : IWTListForm
    {
        private TipoForm Tipo;
        private readonly ModeloFiscalIcmsClass _modeloFiscalIcms;

        public CadAliquotaICMSListForm(TipoForm tipo, ModeloFiscalIcmsClass modeloFiscalIcms)
        {
            InitializeComponent();
            this.Tipo = tipo;
            _modeloFiscalIcms = modeloFiscalIcms;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        public override Type getTipoEntidade()
        {
            return typeof(ModeloFiscalIcmsEstadoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadAliquotaICMSForm form = new CadAliquotaICMSForm((ModeloFiscalIcmsEstadoClass)entidade, this);
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

            return new List<SearchParameterClass>()
                       {
                           new SearchParameterClass("ModeloFiscalIcms", _modeloFiscalIcms, SearchOperacao.FiltroObrigatorio, SearchOrdenacao.Asc, TipoOrdenacao.String),
                           new SearchParameterClass("IDDiferente", -10),
                           new SearchParameterClass("Estado", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)
                       };
        }



        
    }
}
