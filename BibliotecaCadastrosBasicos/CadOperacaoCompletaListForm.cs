using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadOperacaoCompletaListForm : IWTListForm
    {

       public CadOperacaoCompletaListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(OperacaoCompletaClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
               
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
            return new List<SearchParameterClass>() { new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        } 
    }
}
