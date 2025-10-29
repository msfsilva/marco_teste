using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadClassificacaoProdutoForm : IWTForm
    {
    
        public CadClassificacaoProdutoForm(ClassificacaoProdutoClass classificacaoProduto, CadClassificacaoProdutoListForm listForm)
            : base(classificacaoProduto, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.loadComboComprador();
        }


        public CadClassificacaoProdutoForm(ClassificacaoProdutoClass classificacaoProduto)
            : base(classificacaoProduto, typeof(ClassificacaoProdutoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }



        private void loadComboComprador()
        {
            try
            {
                CompradorClass classificacao = new CompradorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<CompradorClass> classificacoes =
                    classificacao.Search(new List<SearchParameterClass>() { new SearchParameterClass("com_apelido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (CompradorClass)a);


                this.cmbComprador.DataSource = classificacoes;
                this.cmbComprador.DisplayMember = "Apelido";
                this.cmbComprador.ValueMember = "ID";
                this.cmbComprador.autoSize = true;
                this.cmbComprador.Table = classificacoes;
                this.cmbComprador.ColumnsToDisplay = new[] { "Apelido", "Nome" };
                this.cmbComprador.HeadersToDisplay = new[] { "Apelido", "Nome" };
                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da classificação.\r\n" + e.Message);
            }
        }

        private void cbxComprador_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbComprador.Enabled = this.cbxComprador.Checked;
        }

        private void ConfiguracaoAutomatica_CheckedChanged(object sender, EventArgs e)
        {
            grbConfiguracaoAutomatica.Enabled = ConfiguracaoAutomatica.Checked;

            if (grbConfiguracaoAutomatica.Enabled)
            {
                ConfiguracaoAutomaticaIntervalo.removeForceDisable();
                ConfiguracaoAutomaticaReferencia_DataCadastro.removeForceDisable();
                ConfiguracaoAutomaticaReferencia_DataEntrega.removeForceDisable();
            }
            else
            {
                ConfiguracaoAutomaticaIntervalo.forceDisable();
                ConfiguracaoAutomaticaReferencia_DataCadastro.forceDisable();
                ConfiguracaoAutomaticaReferencia_DataEntrega.forceDisable();
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            try
            {
                ConfiguracaoAutomatica_CheckedChanged(null, null);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
