#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTLineComponent;
using ProjectConstants;

#endregion

namespace BibliotecaCadastrosBasicos.NovaEstruturaProduto
{
    public partial class CadProdutoMaterialFormNew : IWTBaseForm
    {
        private readonly IWTLine _roteiro;
        public double? Quantidade { get; set; }
        public bool PlanoCorte{ get; set; }
        public double PlanoCorteQuantidade { get; private set; }

        public string Dimensao1Valor { get; private set; }
        public DimensaoClass Dimensao1 { get; private set; }
        public UnidadeMedidaClass Unidade1 { get; private set; }

        public string Dimensao2Valor { get; private set; }
        public DimensaoClass Dimensao2 { get; private set; }
        public UnidadeMedidaClass Unidade2 { get; private set; }

        public string Dimensao3Valor { get; private set; }
        public DimensaoClass Dimensao3 { get; private set; }
        public UnidadeMedidaClass Unidade3 { get; private set; }

        public PostoTrabalhoClass PostoTrabalhoCorte { get; private set; }
        public string PlanoCorteInformacoesAdicionais { get; private set; }

        public bool Condicional { get; private set; }
        public string CondicionalRegra { get; private set; }


        public bool QuantidadeCondicional { get; private set; }
        public string QuantidadeCondicionalRegra { get; private set; }


        public CadProdutoMaterialFormNew(IWTLine roteiro, string tituloTela, string unidadeMaterial)
        {
            InitializeComponent();
            
            _roteiro = roteiro;
            configuraTela();
            this.LoadCombosDimensoes();
            this.LoadCombosUnidades();
            this.LoadComboPostos();

            this.Text = "Quantidade - " + tituloTela;
            this.lblUnidadeMaterial.Text = unidadeMaterial;
        }

        public CadProdutoMaterialFormNew(IWTLine roteiro, double quantidade, bool planoCorte, double? planoCorteQuantidade, DimensaoClass dimensao1, string dimensao1Valor, DimensaoClass dimensao2, string dimensao2Valor, DimensaoClass dimensao3, string dimensao3Valor, PostoTrabalhoClass postoTrabalhoCorte, string planoCorteInformacoesAdicionais, UnidadeMedidaClass unidade1, UnidadeMedidaClass unidade2, UnidadeMedidaClass unidade3, string tituloTela, string unidadeMaterial, bool condicional, string condicionalRegra, bool qtdCondicional, string qtdCondicionalRegra)
        {
            InitializeComponent();

            _roteiro = roteiro;
            Quantidade = quantidade;
            PlanoCorte = planoCorte;
            PlanoCorteQuantidade = planoCorteQuantidade.HasValue ? planoCorteQuantidade.Value : 1;
            Dimensao1 = dimensao1;
            Dimensao1Valor = dimensao1Valor;
            Dimensao2 = dimensao2;
            Dimensao2Valor = dimensao2Valor;
            Dimensao3 = dimensao3;
            Dimensao3Valor = dimensao3Valor;
            PostoTrabalhoCorte = postoTrabalhoCorte;
            PlanoCorteInformacoesAdicionais = planoCorteInformacoesAdicionais;
            Unidade1 = unidade1;
            Unidade2 = unidade2;
            Unidade3 = unidade3;

            Condicional = condicional;
            CondicionalRegra = condicionalRegra;

            QuantidadeCondicional= qtdCondicional;
            QuantidadeCondicionalRegra = qtdCondicionalRegra;

            configuraTela();
            this.LoadCombosDimensoes();
            this.LoadCombosUnidades();
            this.LoadComboPostos();

            this.Text = "Quantidade - " + tituloTela;
            this.lblUnidadeMaterial.Text = unidadeMaterial;

           
            this.chkPlanoCorte.Checked = this.PlanoCorte;
            if (this.chkPlanoCorte.Checked)
            {
                this.nudPlanoCorteQuantidade.Value = (decimal) this.PlanoCorteQuantidade;
            }

            this.txtPlanoCorteInfoAdd.Text = this.PlanoCorteInformacoesAdicionais;

            bool found = false;
            foreach (PostoTrabalhoClass postoTrabalho in cmbPostoTrabalhoCorte.Items)
            {
                PostoTrabalhoClass postoTeste = this.PostoTrabalhoCorte;
                if (postoTeste != null && postoTrabalho.ID == postoTeste.ID)
                {
                    found = true;
                    this.cmbPostoTrabalhoCorte.SelectedItem = postoTrabalho;
                    break;
                }
            }

            if (!found)
            {
                this.cmbPostoTrabalhoCorte.SelectedIndex = -1;
                this.cmbPostoTrabalhoCorte.SelectedValue = null;
                this.cmbPostoTrabalhoCorte.SelectedItem = null;
            }
           
            
            if (this.Dimensao1!=null)
            {
                this.chkDimensao1.Checked = true;
                this.cmbDimensao1.SelectedItem = this.Dimensao1;
                if (this.Dimensao1Valor == "-1")
                {
                    this.rdbDimensao1Pai.Checked = true;
                    this.rdbDimensao1.Checked = false;
                }
                else
                {
                    this.rdbDimensao1Pai.Checked = false;
                    this.rdbDimensao1.Checked = true;
                    this.txtDimensao1.Text = this.Dimensao1Valor;
                }
                this.cmbUnidade1.SelectedItem = this.Unidade1;
            }
            else
            {
                this.chkDimensao1.Checked = false;
            }

            if (this.Dimensao2 != null)
            {
                this.chkDimensao2.Checked = true;
                this.cmbDimensao2.SelectedItem = this.Dimensao2;
                if (this.Dimensao2Valor == "-1")
                {
                    this.rdbDimensao2Pai.Checked = true;
                    this.rdbDimensao2.Checked = false;
                }
                else
                {
                    this.rdbDimensao2.Checked = true;
                    this.rdbDimensao2Pai.Checked = false;
                    this.txtDimensao2.Text = this.Dimensao2Valor;
                }
                this.cmbUnidade2.SelectedItem = this.Unidade2;
            }
            else
            {
                this.chkDimensao2.Checked = false;
            }

            if (this.Dimensao3 != null)
            {
                this.chkDimensao3.Checked = true;
                this.cmbDimensao3.SelectedItem = this.Dimensao3;
                if (this.Dimensao3Valor == "-1")
                {
                    this.rdbDimensao3.Checked = false;
                    this.rdbDimensao3Pai.Checked = true;
                }
                else
                {
                    this.rdbDimensao3.Checked = true;
                    this.rdbDimensao3Pai.Checked = false;
                    this.txtDimensao3.Text = this.Dimensao3Valor;
                }
                this.cmbUnidade3.SelectedItem = this.Unidade3;
            }
            else
            {
                this.chkDimensao3.Checked = false;
            }


            if (condicional)
            {
                this.chkCondicional.Checked = true;
                this.txtRegraCondicional.Text = condicionalRegra;
            }
            else
            {
                this.chkCondicional.Checked = false;
                this.txtRegraCondicional.Text = "";
            }

            if (qtdCondicional)
            {
                this.rdbQtdCondicional.Checked = true;
                this.rdbQtdFixa.Checked = false;
                this.txtQtdCondicionalRegra.Text = qtdCondicionalRegra;
                this.nudQuantidade.Value = 0;
            }
            else
            {
                this.rdbQtdCondicional.Checked = false;
                this.rdbQtdFixa.Checked = true;
                this.txtQtdCondicionalRegra.Text = "";
                this.nudQuantidade.Value = (decimal) quantidade;
            }
        }

        private void LoadComboPostos()
        {
            this.cmbPostoTrabalhoCorte.DisableAutoSelectOnEmpty = true;
            IWTLineNode noAtual = this._roteiro.Inicio;

            List<PostoTrabalhoClass> postos = new List<PostoTrabalhoClass>();
            while (noAtual != null)
            {
                if (noAtual.Conteudo != null && noAtual.Conteudo is NewPostoTrabalhoTreeClass)
                {
                    PostoTrabalhoClass posto = ((ProdutoPostoTrabalhoClass) noAtual.Conteudo.getEntidadeOrigem()).PostoTrabalho;
                    if (!postos.Contains(posto))
                    {
                        postos.Add(posto);
                    }

                }

                noAtual = noAtual.Proximo;
            }

            postos = postos.OrderBy(a => a.Nome).ToList();

            this.cmbPostoTrabalhoCorte.DataSource = postos;
            this.cmbPostoTrabalhoCorte.DisplayMember = "Codigo";
            this.cmbPostoTrabalhoCorte.ValueMember = "ID";
            this.cmbPostoTrabalhoCorte.autoSize = true;
            this.cmbPostoTrabalhoCorte.Table = postos;
            this.cmbPostoTrabalhoCorte.ColumnsToDisplay = new[] {"Codigo", "Nome", "Operacao"};
            this.cmbPostoTrabalhoCorte.HeadersToDisplay = new[] {"Código", "Nome", "Operação"};
        }

        private void LoadCombosDimensoes()
        {
            try
            {
                DimensaoClass search = new DimensaoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<DimensaoClass> tmp = search.Search(new List<SearchParameterClass>()
                                                            {
                                                                new SearchParameterClass("dim_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                                            }).ConvertAll(a => (DimensaoClass) a);

                this.cmbDimensao1.DataSource = tmp;
                this.cmbDimensao1.DisplayMember = "Identificacao";
                this.cmbDimensao1.ValueMember = "ID";
                this.cmbDimensao1.autoSize = true;
                this.cmbDimensao1.Table = tmp;
                this.cmbDimensao1.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbDimensao1.HeadersToDisplay = new[] {"Identificação", "Descrição"};

                List<DimensaoClass> tmp2 = new List<DimensaoClass>(tmp.ToArray());
                List<DimensaoClass> tmp3 = new List<DimensaoClass>(tmp.ToArray());

                this.cmbDimensao2.DataSource = tmp2;
                this.cmbDimensao2.DisplayMember = "Identificacao";
                this.cmbDimensao2.ValueMember = "ID";
                this.cmbDimensao2.autoSize = true;
                this.cmbDimensao2.Table = tmp2;
                this.cmbDimensao2.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbDimensao2.HeadersToDisplay = new[] {"Identificação", "Descrição"};

                this.cmbDimensao3.DataSource = tmp3;
                this.cmbDimensao3.DisplayMember = "Identificacao";
                this.cmbDimensao3.ValueMember = "ID";
                this.cmbDimensao3.autoSize = true;
                this.cmbDimensao3.Table = tmp3;
                this.cmbDimensao3.ColumnsToDisplay = new[] {"Identificacao", "Descricao"};
                this.cmbDimensao3.HeadersToDisplay = new[] {"Identificação", "Descrição"};
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção das dimensões.\r\n" + e.Message);
            }

        }

        private void LoadCombosUnidades()
        {
            try
            {
                UnidadeMedidaClass search = new UnidadeMedidaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<UnidadeMedidaClass> tmp = search.Search(new List<SearchParameterClass>()
                                                            {
                                                                new SearchParameterClass("unm_abreviada", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                                            }).ConvertAll(a => (UnidadeMedidaClass)a);

                this.cmbUnidade1.DataSource = tmp;
                this.cmbUnidade1.DisplayMember = "Abreviada";
                this.cmbUnidade1.ValueMember = "ID";
                this.cmbUnidade1.autoSize = true;
                this.cmbUnidade1.Table = tmp;
                this.cmbUnidade1.ColumnsToDisplay = new[] { "Abreviada", "NomeUnidade" };
                this.cmbUnidade1.HeadersToDisplay = new[] { "Identificação", "Descrição" };

                List<UnidadeMedidaClass> tmp2 = new List<UnidadeMedidaClass>(tmp.ToArray());
                List<UnidadeMedidaClass> tmp3 = new List<UnidadeMedidaClass>(tmp.ToArray());

                this.cmbUnidade2.DataSource = tmp2;
                this.cmbUnidade2.DisplayMember = "Abreviada";
                this.cmbUnidade2.ValueMember = "ID";
                this.cmbUnidade2.autoSize = true;
                this.cmbUnidade2.Table = tmp2;
                this.cmbUnidade2.ColumnsToDisplay = new[] { "Abreviada", "NomeUnidade" };
                this.cmbUnidade2.HeadersToDisplay = new[] { "Identificação", "Descrição" };

                this.cmbUnidade3.DataSource = tmp3;
                this.cmbUnidade3.DisplayMember = "Abreviada";
                this.cmbUnidade3.ValueMember = "ID";
                this.cmbUnidade3.autoSize = true;
                this.cmbUnidade3.Table = tmp3;
                this.cmbUnidade3.ColumnsToDisplay = new[] { "Abreviada", "NomeUnidade" };
                this.cmbUnidade3.HeadersToDisplay = new[] { "Identificação", "Descrição" };
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção das unidades.\r\n" + e.Message);
            }

        }

        private void configuraTela()
        {
            try
            {


                this.grbPlanoCorte.Enabled = IWTConfiguration.Conf.getBoolConf(Constants.PLANO_CORTE_HABILITADO);
             

                nudPlanoCorteQuantidade.Enabled = this.chkPlanoCorte.Checked;
                cmbPostoTrabalhoCorte.Enabled = this.chkPlanoCorte.Checked;
                this.chkDimensao1.Enabled = this.chkPlanoCorte.Checked;
                this.chkDimensao2.Enabled = this.chkPlanoCorte.Checked;
                this.chkDimensao3.Enabled = this.chkPlanoCorte.Checked;


                grbDimensao1.Enabled = this.chkDimensao1.Checked;
                cmbDimensao1.Enabled = this.chkPlanoCorte.Checked;
                cmbUnidade1.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao1.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao1Pai.Enabled = this.chkPlanoCorte.Checked;

                grbDimensao2.Enabled = this.chkDimensao2.Checked;
                cmbDimensao2.Enabled = this.chkPlanoCorte.Checked;
                cmbUnidade2.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao2.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao2Pai.Enabled = this.chkPlanoCorte.Checked;

                grbDimensao3.Enabled = this.chkDimensao3.Checked;
                cmbDimensao3.Enabled = this.chkPlanoCorte.Checked;
                cmbUnidade3.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao3.Enabled = this.chkPlanoCorte.Checked;
                rdbDimensao3Pai.Enabled = this.chkPlanoCorte.Checked;

                txtPlanoCorteInfoAdd.Enabled = this.chkPlanoCorte.Checked;

                txtDimensao1.Enabled = this.rdbDimensao1.Checked && this.rdbDimensao1.Enabled;
                txtDimensao2.Enabled = this.rdbDimensao2.Checked && this.rdbDimensao2.Enabled;
                txtDimensao3.Enabled = this.rdbDimensao3.Checked && this.rdbDimensao3.Enabled;

                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao configurar a tela.\r\n" + e.Message, e);
            }
        }

        private void OkPressed()
        {
            try
            {
              
                if (this.grbPlanoCorte.Enabled)
                {
                    this.PlanoCorte = this.chkPlanoCorte.Checked;
                    if (this.PlanoCorte)
                    {
                        this.PlanoCorteQuantidade = Convert.ToDouble(this.nudPlanoCorteQuantidade.Value);
                        this.PlanoCorteInformacoesAdicionais = this.txtPlanoCorteInfoAdd.Text;
                        if (this.cmbPostoTrabalhoCorte.SelectedItem == null)
                        {
                            throw new Exception("Selecione o posto de trabalho de corte");
                        }

                        this.PostoTrabalhoCorte = (PostoTrabalhoClass)this.cmbPostoTrabalhoCorte.SelectedItem;

                        if (this.grbDimensao1.Enabled)
                        {
                            if (this.cmbDimensao1.SelectedItem == null)
                            {
                                throw new Exception("Selecione a dimensão 1 ou desabilite os campos");
                            }

                            if (this.cmbUnidade1.SelectedItem == null)
                            {
                                throw new Exception("Selecione a unidade da dimensão 1 ou desabilite os campos");
                            }

                            this.Dimensao1Valor = this.rdbDimensao1Pai.Checked ? "-1" : this.txtDimensao1.Text;
                            this.Dimensao1 = (DimensaoClass)this.cmbDimensao1.SelectedItem;
                            this.Unidade1 = (UnidadeMedidaClass)this.cmbUnidade1.SelectedItem;
                        }
                        else
                        {
                            this.Dimensao1Valor = null;
                            this.Dimensao1 = null;
                            this.Unidade1 = null;
                        }

                        if (this.grbDimensao2.Enabled)
                        {
                            if (this.cmbDimensao2.SelectedItem == null)
                            {
                                throw new Exception("Selecione a dimensão 1 ou desabilite os campos");
                            }

                            if (this.cmbUnidade2.SelectedItem == null)
                            {
                                throw new Exception("Selecione a unidade da dimensão 2 ou desabilite os campos");
                            }

                            this.Dimensao2Valor = this.rdbDimensao2Pai.Checked ? "-1" : this.txtDimensao2.Text;
                            this.Dimensao2 = (DimensaoClass)this.cmbDimensao2.SelectedItem;
                            this.Unidade2 = (UnidadeMedidaClass)this.cmbUnidade2.SelectedItem;

                        }
                        else
                        {
                            this.Dimensao2Valor = null;
                            this.Dimensao2 = null;
                            this.Unidade2 = null;
                        }

                        if (this.grbDimensao3.Enabled)
                        {
                            if (this.cmbDimensao3.SelectedItem == null)
                            {
                                throw new Exception("Selecione a dimensão 1 ou desabilite os campos");
                            }

                            if (this.cmbUnidade3.SelectedItem == null)
                            {
                                throw new Exception("Selecione a unidade da dimensão 3 ou desabilite os campos");
                            }

                            this.Dimensao3Valor = this.rdbDimensao3Pai.Checked ? "-1" : this.txtDimensao3.Text;
                            this.Dimensao3 = (DimensaoClass)this.cmbDimensao3.SelectedItem;
                            this.Unidade3 = (UnidadeMedidaClass)this.cmbUnidade3.SelectedItem;
                        }
                        else
                        {
                            this.Dimensao3Valor = null;
                            this.Dimensao3 = null;
                            this.Unidade3 = null;
                        }
                    }

                    else
                    {
                        this.PlanoCorteQuantidade = 0;
                        this.PlanoCorteInformacoesAdicionais = "";
                        this.PostoTrabalhoCorte = null;

                        this.Dimensao1Valor = null;
                        this.Dimensao1 = null;
                        this.Unidade1 = null;

                        this.Dimensao2Valor = null;
                        this.Dimensao2 = null;
                        this.Unidade2 = null;

                        this.Dimensao3Valor = null;
                        this.Dimensao3 = null;
                        this.Unidade3 = null;
                    }


                  


                }

                if (nudQuantidade.Enabled && Math.Round(this.nudQuantidade.Value, 5) <= 0)
                {
                    throw new Exception("A quantidade do material deve ser maior do que zero.");
                }

                this.Condicional = this.chkCondicional.Checked;
                this.CondicionalRegra = this.Condicional ? txtRegraCondicional.Text : null;

                this.QuantidadeCondicional = this.rdbQtdCondicional.Checked;
                this.QuantidadeCondicionalRegra = this.QuantidadeCondicional ? txtQtdCondicionalRegra.Text : null;
                this.Quantidade = !this.QuantidadeCondicional ? (double)this.nudQuantidade.Value : 0;

                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os dados selecionados.\r\n" + e.Message, e);
            }
        }


        #region Eventos

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.OkPressed();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPlanoCorte_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void rdbDimensao1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDimensao1Pai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDimensao2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDimensao2Pai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDimensao3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDimensao3Pai_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDimensao1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDimensao2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkDimensao3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.configuraTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void chkCondicional_CheckedChanged(object sender, EventArgs e)
        {
            this.txtRegraCondicional.Enabled = this.chkCondicional.Checked;
        }

        private void rdbQtdFixa_CheckedChanged(object sender, EventArgs e)
        {
            this.nudQuantidade.Enabled = this.rdbQtdFixa.Checked;
            this.txtQtdCondicionalRegra.Enabled = this.rdbQtdCondicional.Checked;
        }

        private void rdbQtdCondicional_CheckedChanged(object sender, EventArgs e)
        {
            this.nudQuantidade.Enabled = this.rdbQtdFixa.Checked;
            this.txtQtdCondicionalRegra.Enabled = this.rdbQtdCondicional.Checked;

        }

    }
}
