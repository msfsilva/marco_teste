using System;
using System.Collections.Generic;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFamiliaMateriaisForm : IWTForm
    {
        public CadFamiliaMateriaisForm(FamiliaMaterialClass familia, CadFamiliaMateriaisListForm listForm)
            : base(familia, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
            this.loadComboComprador();
            this.loadComboAgrupadorMaterial();
        }

        public CadFamiliaMateriaisForm(FamiliaMaterialClass familia):base(familia, typeof(FamiliaMaterialClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();

        }

        private void loadComboComprador()
        {
            try
            {
                CompradorClass classificacao = new CompradorClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<CompradorClass> classificacoes =
                    classificacao.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("com_apelido", null,
                                                                          SearchOperacao.SomenteOrdenacao,
                                                                          SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).ConvertAll(
                                                 a => (CompradorClass) a);


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


        private void loadComboAgrupadorMaterial()
        {
            try
            {
                AgrupadorMaterialClass agrupador = new AgrupadorMaterialClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<AgrupadorMaterialClass> agrupadores =
                    agrupador.Search(new List<SearchParameterClass>() { new SearchParameterClass("agm_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (AgrupadorMaterialClass)a);


                this.cmbAgrupador.DataSource = agrupadores;
                this.cmbAgrupador.DisplayMember = "Identificacao";
                this.cmbAgrupador.ValueMember = "ID";
                this.cmbAgrupador.autoSize = true;
                this.cmbAgrupador.Table = agrupadores;
                this.cmbAgrupador.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbAgrupador.HeadersToDisplay = new[] { "Identificação", "Descrição" };
                


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção dos Agrupadores.\r\n" + e.Message);
            }

        }

        private void chkComprador_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbComprador.Enabled = chkComprador.Checked;

        }
        
    }
}
