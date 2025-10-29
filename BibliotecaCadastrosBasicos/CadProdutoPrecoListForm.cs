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
    public partial class CadProdutoPrecoListForm : IWTListForm
    {

       public CadProdutoPrecoListForm()
        {
            InitializeComponent();
        }

        #region ListForm
        public override Type getTipoEntidade()
        {
            return typeof(ProdutoPrecoClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                if (entidade != null)
                {
                    ProdutoPrecoClass preco = (ProdutoPrecoClass) entidade;
                    if (!preco.Vigente)
                    {
                        throw new ExcecaoTratada("Selecione um preço vigente para revisar");
                    }
                }

                CadProdutoPrecoForm form = new CadProdutoPrecoForm((ProdutoPrecoClass) entidade, this);
                form.VerificaUtilizacao = TipoModulo.Tipo != TipoForm.Gerencial;
                form.ShowDialog();

                if (entidade != null)
                {
                    this.ForceInitializeDataGrid();
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
            return new List<SearchParameterClass>() { new SearchParameterClass("Produto", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        }

        #endregion





        #region Eventos

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.rdbVigentes.Checked = true;
        }



        

        #endregion

    }
}
