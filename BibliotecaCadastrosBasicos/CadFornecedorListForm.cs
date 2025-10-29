using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFornecedorListForm : IWTListForm
    {
        private TipoForm Tipo;
        private readonly bool _somenteExtrangeiro;


        public CadFornecedorListForm(TipoForm tipo, bool somenteExtrangeiro = false)
        {
            InitializeComponent();
            this.Tipo = tipo;
            _somenteExtrangeiro = somenteExtrangeiro;

        }


        public override Type getTipoEntidade()
        {
            return typeof (FornecedorClass);
        }

        protected override void chamadaForm(AbstractEntity entidade)
        {
            try
            {
                CadFornecedorForm form = new CadFornecedorForm((FornecedorClass) entidade, this);
                form.SomenteLeitura = SomenteLeitura;
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
            List<SearchParameterClass> toRet = new List<SearchParameterClass>() {new SearchParameterClass("for_nome_fantasia", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)};
            if (_somenteExtrangeiro)
            {
                toRet.Add(new SearchParameterClass("Estrangeiro", true, SearchOperacao.FiltroObrigatorio, SearchOrdenacao.Asc, TipoOrdenacao.Automatica));
            }
            return toRet;
        }



        private void ImprimirListagemFornecedores()
        {
            try
            {
                List<ClienteFornecedorReportClass> ds = ClienteFornecedorReportClass.getFornecedores(LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                FornecedoresReport rep = new FornecedoresReport();
                rep.SetDataSource(ds);
                ViewReportPadraoForm form = new ViewReportPadraoForm("Listagem de Fornecedores", rep);
                form.Show(this);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception("Erro inesperado ao gerar a listagem de fornecedores para impressão.\r\n" + e.Message, e);
            }
        }

        #region Eventos

        private void btnImprirmirRelatorioFornecedores_Click(object sender, EventArgs e)
        {
            try
            {
                ImprimirListagemFornecedores();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion
    }
}
