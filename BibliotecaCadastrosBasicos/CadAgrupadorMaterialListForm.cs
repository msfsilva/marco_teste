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
    public partial class CadAgrupadorMaterialListForm : IWTListForm
    {
         private TipoForm Tipo;

        public CadAgrupadorMaterialListForm(TipoForm tipo)
        {
            InitializeComponent();
            this.Tipo = tipo;
        }

        public override Type getTipoEntidade()
        {
            return typeof(AgrupadorMaterialClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadAgrupadorMaterialForm form = new CadAgrupadorMaterialForm((AgrupadorMaterialClass)entidade, this);
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
            return new List<SearchParameterClass>() { new SearchParameterClass("agm_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) };
        }
    }
}
