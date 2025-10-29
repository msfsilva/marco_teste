using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPalletListForm : IWTListForm
    {

       public CadPalletListForm()
        {
            InitializeComponent();
        }

        #region ListForm
        public override Type getTipoEntidade()
        {
            return typeof(PalletClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
    
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
        #endregion

        #region Eventos
        private void btnAdicionarNovosPallets_Click(object sender, EventArgs e)
        {
            try
            {
                CadPalletForm form = new CadPalletForm();
                form.ShowDialog(this);
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.ForceInitializeDataGrid();
            }
        }
        #endregion
    }
}
