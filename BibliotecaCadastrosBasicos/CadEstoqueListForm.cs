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
    public partial class CadEstoqueListForm : IWTListForm
    {

        public CadEstoqueListForm(bool desabilitarOperacaoes = false)
        {
            InitializeComponent();

            if (desabilitarOperacaoes)
            {

                this.iwtDefaultListButtons1.iwtEditarButton1.Visible = false;
                this.iwtDefaultListButtons1.iwtExcluirButton1.Visible = false;
                this.iwtDefaultListButtons1.iwtNovoButton1.Visible = false;
            }
        }

        public override Type getTipoEntidade()
        {
            return typeof(EstoqueClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadEstoqueForm form = new CadEstoqueForm((EstoqueClass)entidade, this);
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
            return new List<SearchParameterClass>() { new SearchParameterClass("Identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica) };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.rdbAtivos.Checked = true;
        }
    }
}
