using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadLogConfiguracaoAutomaticaPedidosListForm : IWTListForm
    {

        public CadLogConfiguracaoAutomaticaPedidosListForm()
        {
            InitializeComponent();
        }

        public override Type getTipoEntidade()
        {
            return typeof(LogConfiguracaoAutomaticaPedidosClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadLogConfiguracaoAutomaticaPedidosForm form = new CadLogConfiguracaoAutomaticaPedidosForm((LogConfiguracaoAutomaticaPedidosClass) entidade, this);
                form.VerificaUtilizacao = false;
                form.SomenteLeitura = true;
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
            return new List<SearchParameterClass>() {new SearchParameterClass("Data", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.Automatica)};
        }
    }
}
