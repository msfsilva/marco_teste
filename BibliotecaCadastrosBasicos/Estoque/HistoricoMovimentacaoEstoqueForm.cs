#region Referencias

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos.Estoque
{
    public partial class HistoricoMovimentacaoEstoqueForm : IWTBaseForm
    {
        private readonly DocumentoCopiaClass _documento;
        private readonly RecursoClass _recurso;
        private readonly ProdutoKClass _produtoK;
        private readonly EpiClass _epi;
        private readonly ProdutoClass _produto;
        private readonly MaterialClass _material;
        readonly EstoqueGavetaItemClass _itemEstoque;
        

        public HistoricoMovimentacaoEstoqueForm(EstoqueGavetaItemClass itemEstoque)
        {
            InitializeComponent();
            _itemEstoque = itemEstoque;
        }

        public HistoricoMovimentacaoEstoqueForm(MaterialClass material)
        {
            _material = material;
            InitializeComponent();
            }

        public HistoricoMovimentacaoEstoqueForm(ProdutoClass produto)
        {
            _produto = produto;
            InitializeComponent();
        }

        public HistoricoMovimentacaoEstoqueForm(EpiClass epi)
        {
            _epi = epi;
            InitializeComponent();
        }

        public HistoricoMovimentacaoEstoqueForm(ProdutoKClass produtoK)
        {
            _produtoK = produtoK;
            InitializeComponent();
        }

        public HistoricoMovimentacaoEstoqueForm(RecursoClass recurso)
        {
            _recurso = recurso;
            InitializeComponent();
        }
        public HistoricoMovimentacaoEstoqueForm(DocumentoCopiaClass documento)
        {
            _documento = documento;
            InitializeComponent();
        }

        private void LoadGrid()
        {
            try
            {
                if (_itemEstoque != null)
                {
                    this.lblGaveta.Text = this._itemEstoque.EstoqueGaveta.GetLocalizacaoCompleta();
                }

                this.iwtDataGridView1.AutoGenerateColumns = false;

                List<SearchParameterClass> parametros = new List<SearchParameterClass>();

                if (_itemEstoque!=null)
                {
                    parametros.Add(new SearchParameterClass("EstoqueGavetaItem", _itemEstoque));
                    iwtDataGridView1.Columns.Remove(LocalizacaoColumn);
                    LocalizacaoColumn.Visible = false;
                }


                if (_documento != null)
                {
                    parametros.Add(new SearchParameterClass("DocumentoCopia", _documento));
                }

                if (_recurso != null)
                {
                    parametros.Add(new SearchParameterClass("Recurso", _recurso));
                }

                if (_produtoK != null)
                {
                    parametros.Add(new SearchParameterClass("ProdutoK", _produtoK));
                }

                if (_epi != null)
                {
                    parametros.Add(new SearchParameterClass("Epi", _epi));
                }

                if (_produto != null)
                {
                    parametros.Add(new SearchParameterClass("Produto", _produto));
                }

                if (_material != null)
                {
                    parametros.Add(new SearchParameterClass("Material", _material));
                }

                parametros.Add(new SearchParameterClass("Data",null, SearchOperacao.SomenteOrdenacao,SearchOrdenacao.Desc,TipoOrdenacao.Data));

                this.iwtDataGridView1.DataSource = new BindingList<EstoqueMovimentacaoClass>(new EstoqueMovimentacaoClass(LoginClass.UsuarioLogado.loggedUser, SingleConnection).Search(parametros).ConvertAll(a => (EstoqueMovimentacaoClass) a).ToList());

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o histórico.\r\n" + e.Message, e);
            }
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistoricoMovimentacaoEstoqueForm_Shown(object sender, EventArgs e)
        {
            try
            {

                this.LoadGrid();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
