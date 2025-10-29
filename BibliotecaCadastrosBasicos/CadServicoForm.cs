using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadServicoForm : IWTForm
    {

        public CadServicoForm(ServicoClass classificacaoServico, CadServicoListForm listForm)
            : base(classificacaoServico, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }


        public CadServicoForm(ServicoClass classificacaoServico)
            : base(classificacaoServico, typeof(ServicoClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
        }


   

        private void loadComboClassificacao()
        {
            try
            {
                ClassificacaoServicoClass classificacaoServico = new ClassificacaoServicoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ClassificacaoServicoClass> classificacaoServicoList =
                    classificacaoServico.Search(new List<SearchParameterClass>() { new SearchParameterClass("cls_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String) }).ConvertAll(a => (ClassificacaoServicoClass)a);


                this.cmbClassificacao.DataSource = classificacaoServicoList;
                this.cmbClassificacao.DisplayMember = "Identificacao";
                this.cmbClassificacao.ValueMember = "ID";
                this.cmbClassificacao.autoSize = true;
                this.cmbClassificacao.Table = classificacaoServicoList;
                this.cmbClassificacao.ColumnsToDisplay = new[] { "Identificacao", "Descricao" };
                this.cmbClassificacao.HeadersToDisplay = new[] { "Identificação", "Descrição" };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da classificação do serviço.\r\n" + e.Message);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            ensFornecedor.FormSelecao = new CadFornecedorListForm(TipoModulo.Tipo);
            this.loadComboClassificacao();
            base.OnShown(e);
        }


    }
}
