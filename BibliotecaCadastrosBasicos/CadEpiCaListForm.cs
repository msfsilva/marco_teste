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
    public partial class CadEpiCaListForm : IWTListForm
    {

       public CadEpiCaListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(EpiCaClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadEpiCaForm form = new CadEpiCaForm((EpiCaClass)entidade, this);
                form.VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial;
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
            return new List<SearchParameterClass>() { new SearchParameterClass("Numero", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        } 
    }
}
