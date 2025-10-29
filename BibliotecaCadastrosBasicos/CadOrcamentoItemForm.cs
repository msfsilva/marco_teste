#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using BibliotecaCentroCusto;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Entidades;
using BibliotecaPedidos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;


#endregion

namespace BibliotecaCadastrosBasicos
{


    public partial class CadOrcamentoItemForm : IWTForm
    {

        private bool loading = true;

        private bool codigoAutomatico = false;
        private bool descricaoAutomatica = false;

        private bool salvarComo = false;
        private CentroCustoLucroClass centroCustoSelecionado;

        private ProdutoClass ProdutoSelecionado;
        private ProdutoClass ProdutoSelecionadoItem;
        private TipoForm Tipo;


        protected OrcamentoItemClass Orcamento
        {
            get { return (OrcamentoItemClass)this.Entity; }
        }

        public CadOrcamentoItemForm(OrcamentoItemClass orcamentoItem, CadOrcamentoItemListForm listForm, TipoForm tipoForm)
            : base(orcamentoItem, listForm, listForm.SingleConnection)
        {
            InitializeComponent();

            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(BibliotecaControleRevisao.TipoModulo.Tipo);

            this.Tipo = tipoForm;

            Init();
        }

        public CadOrcamentoItemForm(OrcamentoItemClass orcamentoItem, TipoForm tipoForm)
            : base(orcamentoItem, typeof (OrcamentoItemClass), LoginClass.UsuarioLogado.loggedUser,null)
        {
            InitializeComponent();
            ensFormaPagamento.FormSelecao = new CadFormaPagamentoListForm(BibliotecaControleRevisao.TipoModulo.Tipo);
            this.Tipo = tipoForm;

            Init();
        }

        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        private void Init()
        {

            
          this.loadComboOperação();
            this.loadClientes();
            this.loadComboRepresentante();
            this.loadKits();
            this.loadComboContaBancaria();

            if (Entity != null)
            {
                loading = true;
                this.editFieldsMode();
                this.updateGrid();
                this.btnVariaveis.Enabled = true;
                loading = false;
            }
            else
            {

                this.txtOc.Text = this.Orcamento.Numero;
                this.txtPos.Text = this.Orcamento.Posicao.ToString();
            }

            this.updateTotalMainItem();
        }


        private void updateGrid()
        {
            try
            {

                dataGridView1.Columns.Clear();

                dataGridView1.AutoGenerateColumns = false;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Produto";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Código";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;

                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName =
                    "ProdutoCodigoCliente";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Código Cliente";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName =
                    "ProdutoDescricaoCliente";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Descrição";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;


                this.dataGridView1.Columns.Add(new DataGridViewTextBoxColumn());
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].DataPropertyName = "Quantidade";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].HeaderText = "Qtd.";
                this.dataGridView1.Columns[this.dataGridView1.Columns.Count - 1].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.AllCells;






                dataGridView1.DataSource = this.Orcamento.CollectionOrcamentoItemClassOrcamentoItemPai;

                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridView1.MultiSelect = false;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados dos Itens do orcamento no grid.\r\n" + e.Message);
            }
        }

        private void editFieldsMode()
        {
            if (this.Orcamento != null && this.Orcamento.Status != StatusOrcamento.Pendente )
            {

                this.tabPage1.Enabled = false;
                this.tabPage2.Enabled = false;

                this.btnCancelar.Enabled = false;
                this.btnCopiar.Enabled = true;
            }
            else
            {
                this.nudValorUnit.Enabled = true;
                if (this.Orcamento.Configurado)
                {
                    this.txtBuscaProduto.Enabled = false;
                    this.btnBuscaProduto.Enabled = false;
                    this.cmbCliente.Enabled = false;
                    this.txtOc.Enabled = false;
                    this.txtPos.Enabled = false;
                    this.txtNCM.Enabled = false;
                    this.chkNCM.Enabled = false;
                    this.txtProjeto.Enabled = false;
                    this.txtArmazenagem.Enabled = false;
                    this.txtCodigo.Enabled = false;
                    this.txtDescricao.Enabled = false;
                    this.cbxEntregaParc.Enabled = false;
                    this.cbxVolumeUnico.Enabled = false;
                    this.nudQtd.Enabled = true;
                    this.nudQtdItem.Enabled = false;
                    this.txtCodigoItem.Enabled = false;
                    this.txtDescricaoItem.Enabled = false;

                    this.txtBuscaProdItem.Enabled = false;
                    this.txtBuscaProdItem.Enabled = false;

                    this.chkExportacao.Enabled = false;
                    this.btnConfirmarEdicao.Enabled = false;
                    this.btnEditarItem.Enabled = false;
                    this.btnAdicionar.Enabled = false;
                    this.btnRemover.Enabled = false;

                    this.txtInfoEspeciais.Enabled = false;

                    this.chkTipoKit.Enabled = false;
                    this.gbxItem.Enabled = false;
                    this.cmbTipoKit.Enabled = false;

                }

            }
        }

        private void loadComboOperação()
        {
            try
            {

                OperacaoClass search = new OperacaoClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<OperacaoClass> operacoes =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("ope_descricao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      }).
                        ConvertAll(a => (OperacaoClass) a);


                this.cmbOperacao.DataSource = operacoes;
                this.cmbOperacao.DisplayMember = "Descricao";
                this.cmbOperacao.ValueMember = "ID";

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados das operações.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadClientes()
        {
            try
            {


                ClienteClass search = new ClienteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ClienteClass> clientes =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("cli_nome_resumido", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                                          new SearchParameterClass("cli_nome", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      }).
                        ConvertAll(a => (ClienteClass) a);


                this.cmbCliente.DataSource = clientes;
                this.cmbCliente.DisplayMember = "NomeResumido";
                this.cmbCliente.ValueMember = "ID";
                this.cmbCliente.autoSize = true;
                this.cmbCliente.Table = clientes;
                this.cmbCliente.ColumnsToDisplay = new string[] {"NomeResumido", "Nome"};
                this.cmbCliente.HeadersToDisplay = new string[] {"Nome Resumido", "Razão"};




                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados do cliente.\r\n" + a.Message, "Dados do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void loadKits()
        {
            try
            {
                string sql =
                    "SELECT  " +
                    "  public.kit_tipo_kit.pek_tipo_kit " +
                    "FROM " +
                    "  public.kit_tipo_kit " +
                    "ORDER BY " +
                    "  public.kit_tipo_kit.pek_tipo_kit ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.SingleConnection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbTipoKit.DataSource = binding;
                    this.cmbTipoKit.ValueMember = "pek_tipo_kit";
                    this.cmbTipoKit.DisplayMember = "pek_tipo_kit";

                }

            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados dos kits.\r\n" + a.Message, "Dados do Cliente",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void validateRequiredFieldsToSave()
        {
            try
            {
                if (this.txtOc.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Numero do orcamento é obrigatório.");
                }

                if (this.txtPos.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Posição é obrigatório.");
                }

                if (this.txtDescricao.Enabled && this.txtDescricao.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição é obrigatório.");
                }

                if (this.txtCodigo.Enabled && this.txtCodigo.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Código é obrigatório.");
                }

                if (this.txtNCM.Enabled && this.txtNCM.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo NCM é obrigatório.");
                }

                if (this.cmbCliente.SelectedValue == null)
                {
                    throw new Exception("Campo Cliente é obrigatório. Selecione um item da lista de seleção.");
                }

                if (this.ProdutoSelecionado == null)
                {
                    throw new Exception("Campo Produto é obrigatório.");
                }

                if (this.cmbOperacao.SelectedValue == null)
                {
                    throw new Exception("Campo Operação é obrigatório. Selecione um item da lista de seleção.");
                }

               

                if (this.cmbTipoKit.Enabled && this.cmbTipoKit.SelectedValue == null)
                {
                    throw new Exception("Selecione o tipo do kit ou desabilite a opção de kit.");
                }

                if (cmbContaBancaria.Enabled &&
                    (cmbContaBancaria.SelectedValue == null || cmbContaBancaria.SelectedValue.ToString().Length == 0))
                {
                    throw new Exception("Selecione uma conta bancária ou desabilite o campo");
                }

                if (btnCentroCusto.Enabled && this.centroCustoSelecionado == null)
                {
                    throw new Exception("Selecione um centro de custo ou desabilite o campo");
                }


                if (chkRepresentante.Checked)
                {
                    if (cmbRepresentante.SelectedValue == null)
                    {
                        throw new Exception("Informe o Representante a receber comissão ou inabilite os campos de Comissão");
                    }
                    if (nudComissaoRepresentante.Value == 0)
                    {
                        throw new Exception("Informe um percentual de Comissão para o Representante ou inabilite os campos de Comissão");
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        protected override void Salvar(IWTPostgreNpgsqlCommand command = null)
        {
            this.validateRequiredFieldsToSave();



            //if (this.centroCustoSelecionado != null)
            //{
            //    this.Orcamento.CentroLucro = centroCustoSelecionado;
            //}
            //else
            //{
            //    this.Orcamento.CentroLucro = null;
            //}

            if (!this.salvarComo)
            {
                base.Salvar(command);
            }
            else
            {
                this.SalvarComo();
            }

            EnviarEmail();
        }

        private void SalvarComo()
        {
            this.validateRequiredFieldsToSave();

            this.Orcamento.SalvarComo();

            this.ListForm.ForceInitializeDataGrid();

            EnviarEmail();

        }

        private void EnviarEmail()
        {
            try
            {

                PedidoAgrupador agrupador = new PedidoAgrupador(
                    PedidoOrcamento.Orcamento,
                    this.txtOc.Text.Trim(),
                    this.Orcamento.Cliente,
                    this.Orcamento.Representante,
                    this.Orcamento.Vendedor,
                    LoginClass.UsuarioLogado.loggedUser,
                    this.SingleConnection
                    );


                agrupador.AdicionarOrcamento(this.Orcamento);

                agrupador.EnviarEmail();
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Ocorreu um erro ao enviar os emails do orcamento/orçamento.\r\n" + e.Message, "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void validateRequiredFields()
        {
            try
            {
                if (this.ProdutoSelecionadoItem == null)
                {
                    throw new Exception("Campo Produto é obrigatório.");
                }

                if (this.txtDescricaoItem.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Descrição do item é obrigatório.");
                }

                if (this.txtCodigoItem.Text.Trim().Length == 0)
                {
                    throw new Exception("Campo Código do item é obrigatório.");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao validar os campos obrigatórios.\r\n" + e.Message);
            }
        }

        private void cleanItemFields()
        {
            this.txtBuscaProdItem.Clear();
            this.txtCodigoItem.Clear();
            this.txtDescricaoItem.Clear();
            this.txtBuscaProdItem.Enabled = true;
            this.ProdutoSelecionadoItem = null;
            this.btnBuscaProdItem.Text = "Selecionar";
            this.btnBuscaProdItem.Focus();
            this.btnBuscaProdItem.Enabled = true;
            this.nudQtdItem.Value = 0;
        }

        private void updateTotalMainItem()
        {
            lblTotal.Text = "Total: R$ " + (nudQtd.Value*nudValorUnit.Value).ToString("F2", CultureInfo.CurrentCulture);
        }

        private void updateNCMPrincipal()
        {
            if (!loading)
            {
                if (this.ProdutoSelecionado.CollectionProdutoFiscalClassProduto.Any() && this.ProdutoSelecionado.CollectionProdutoFiscalClassProduto.First().Ncm != null)
                {
                    txtNCM.Text = this.ProdutoSelecionado.CollectionProdutoFiscalClassProduto.First().Ncm.Codigo;
                }
                else
                {
                    txtNCM.Text = "";
                }

            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count == 0)
                {
                    throw new Exception("Selecione o subitem a ser editado");
                }

                OrcamentoItemClass sublinha = (OrcamentoItemClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;


                this.txtCodigoItem.Text = sublinha.ProdutoCodigoCliente;
                this.txtDescricaoItem.Text = sublinha.ProdutoDescricaoCliente;

                this.txtBuscaProdItem.Enabled = false;
                this.btnBuscaProdItem.Text = "Limpar";
                this.btnBuscaProdItem.Enabled = false;
                this.ProdutoSelecionadoItem = sublinha.Produto;
                this.txtBuscaProdItem.Text = this.ProdutoSelecionadoItem.Codigo;
                this.nudQtdItem.Value = (decimal) sublinha.Quantidade;

                this.btnEditarItem.Visible = false;
                this.btnConfirmarEdicao.Visible = true;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o subitem.\r\n" + e.Message, e);
            }
        }

        private void ConfirmarEdicao()
        {
            try
            {
                OrcamentoItemClass sublinha = (OrcamentoItemClass) ((IWTDataGridViewRow) this.dataGridView1.SelectedRows[0]).DataBoundItem;

                sublinha.SetQuantidade((double) this.nudQtdItem.Value);

                sublinha.ProdutoCodigoCliente = this.txtCodigoItem.Text;
                sublinha.ProdutoDescricaoCliente = this.txtDescricaoItem.Text;


                this.btnEditarItem.Visible = true;
                this.btnConfirmarEdicao.Visible = false;

                this.updateGrid();
                this.cleanItemFields();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao confirmar a edição do subitem.\r\n" + e.Message, e);
            }
        }

 

        private void habilitarCopiar()
        {

            this.tabPage1.Enabled = true;
            this.tabPage2.Enabled = true;
            this.tabPage4.Enabled = true;


            foreach (Control c in this.Controls)
            {

                c.Enabled = true;

            }
            this.btnSalvar.Enabled = true;
            this.btnCancelar.Enabled = true;


            this.nudValorUnit.Enabled = true;

            this.txtBuscaProduto.Enabled = true;
            this.btnBuscaProduto.Enabled = true;
            this.cmbOperacao.Enabled = true;
            this.cmbCliente.Enabled = true;
            this.dtpDataEntrega.Enabled = true;
            this.txtOc.Enabled = true;
            this.txtPos.Enabled = true;
            this.chkNCM.Enabled = true;
            this.txtProjeto.Enabled = true;
            this.txtArmazenagem.Enabled = true;
            this.txtCodigo.Enabled = true;
            this.txtDescricao.Enabled = true;
            this.nudFrete.Enabled = true;
            this.cbxEntregaParc.Enabled = true;
            this.cbxVolumeUnico.Enabled = true;
            this.nudQtd.Enabled = true;
            //this.dtpDataOrcamento.Enabled = true;

            this.nudQtdItem.Enabled = true;
            this.txtCodigoItem.Enabled = true;
            this.txtDescricaoItem.Enabled = true;
            //this.cmbProdItem.Enabled = true;
            this.txtBuscaProdItem.Enabled = true;
            this.txtBuscaProdItem.Enabled = true;

            this.chkExportacao.Enabled = true;
            this.btnConfirmarEdicao.Enabled = true;
            this.btnEditarItem.Enabled = true;
            this.btnAdicionar.Enabled = true;
            this.btnRemover.Enabled = true;

            this.txtInfoEspeciais.Enabled = true;

            this.chkTipoKit.Enabled = true;
            this.gbxItem.Enabled = true;
            this.cmbTipoKit.Enabled = true;


            this.salvarComo = true;

            this.grbCancelamento.Visible = false;

            this.Text = "COPIANDO " + this.Text;
            this.btnCopiar.Visible = false;

            this.btnSalvar.Text = "Salvar Cópia";

            if (this.chkNCM.Checked)
            {
                this.txtNCM.Enabled = true;
            }
            else
            {
                this.txtNCM.Enabled = false;
            }

            this.chkTipoKit_CheckedChanged(null, null);

        }

        private void selcionarCentroCusto()
        {
            try
            {
                SelecaoCentroCustoLucroForm form = new SelecaoCentroCustoLucroForm(CentroCustoLucroNatureza.Lucro);
                form.ShowDialog();

                if (form.CentroSelecionado == null)
                {
                    this.chkCentroCusto.Checked = false;
                }
                else
                {
                    this.txtCentroCusto.Text = form.CentroSelecionado.ToString();
                    this.centroCustoSelecionado = form.CentroSelecionado;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o centro de custo padrão\r\n" + e.Message, e);
            }
        }

        private void loadComboContaBancaria()
        {
            try
            {


                ContaBancariaClass search = new ContaBancariaClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<ContaBancariaClass> contas =
                    search.Search(new List<SearchParameterClass>()
                                      {
                                          new SearchParameterClass("cba_nome_banco", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                                          new SearchParameterClass("cba_agencia", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String),
                                          new SearchParameterClass("cba_numero_conta", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                      }).
                        ConvertAll(a => (ContaBancariaClass) a);


                this.cmbContaBancaria.DataSource = contas;
                this.cmbContaBancaria.DisplayMember = "NomeBanco";
                this.cmbContaBancaria.ValueMember = "ID";
                this.cmbContaBancaria.autoSize = true;
                this.cmbContaBancaria.Table = contas;
                this.cmbContaBancaria.ColumnsToDisplay = new string[] {"NomeBanco", "Agencia", "NumeroConta"};
                this.cmbContaBancaria.HeadersToDisplay = new string[] {"Banco", "Agência", "Conta"};





            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção da conta bancária.\r\n" + e.Message);
            }
        }

        private void detalhesPrincipal()
        {
            try
            {
                if (this.ProdutoSelecionado != null)
                {
                    CadProdutoForm form = new CadProdutoForm(this.ProdutoSelecionado, this.Tipo)
                                              {
                                                  SomenteLeitura = true
                                              };
                    form.Show();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir os detalhes do produto.\r\n" + e.Message, e);
            }
        }

        private void detalhesSub()
        {
            try
            {
                if (this.ProdutoSelecionadoItem != null)
                {
                    CadProdutoForm form = new CadProdutoForm(this.ProdutoSelecionadoItem, this.Tipo)
                                              {
                                                  SomenteLeitura = true
                                              };
                    form.Show();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir os detalhes do produto.\r\n" + e.Message, e);
            }

        }

        private void BuscaProduto()
        {
            try
            {
                if (this.ProdutoSelecionado == null)
                {

                    CadProdutoListForm form = new CadProdutoListForm(Tipo, true, this.txtBuscaProduto.Text,
                                                                     true, somenteAtivos: true);

                    if (form.ItemSelecionado == null)
                    {
                        form.ShowDialog();

                    }

                    if (form.ItemSelecionado != null)
                    {
                        this.ProdutoSelecionado = (BibliotecaEntidades.Entidades.ProdutoClass) form.ItemSelecionado;
                        this.txtBuscaProduto.Text = this.ProdutoSelecionado.Codigo;
                        this.txtBuscaProduto.Enabled = false;
                        this.btnBuscaProduto.Text = "Limpar";

                        this.updateNCMPrincipal();

                        if (codigoAutomatico || this.txtCodigo.Text.Trim().Length == 0)
                        {
                            codigoAutomatico = true;
                            this.txtCodigo.Text = this.ProdutoSelecionado.CodigoCliente;
                        }

                        if (descricaoAutomatica || this.txtDescricao.Text.Trim().Length == 0)
                        {
                            descricaoAutomatica = true;
                            this.txtDescricao.Text = this.ProdutoSelecionado.Descricao;
                        }

                        MessageBox.Show(this, "Produto selecionado com sucesso.", "Produto Selecionado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        this.ProdutoSelecionado = null;
                    }
                }
                else
                {
                    this.txtBuscaProduto.Clear();
                    this.txtCodigo.Clear();
                    this.txtDescricao.Clear();
                    this.txtBuscaProduto.Enabled = true;
                    this.ProdutoSelecionado = null;
                    this.btnBuscaProduto.Text = "Selecionar";
                    this.txtBuscaProduto.Focus();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o produto\r\n" + e.Message, e);
            }
        }

        private void BuscaProdutoItem()
        {
            try
            {
                if (this.ProdutoSelecionadoItem == null)
                {

                    CadProdutoListForm form = new CadProdutoListForm(this.Tipo, true, this.txtBuscaProdItem.Text, true, somenteAtivos: true);
                    if (form.ItemSelecionado == null)
                    {
                        form.ShowDialog();

                    }

                    if (form.ItemSelecionado != null)
                    {
                        this.ProdutoSelecionadoItem = (BibliotecaEntidades.Entidades.ProdutoClass) form.ItemSelecionado;
                        this.txtBuscaProdItem.Text = this.ProdutoSelecionadoItem.Codigo;
                        this.txtBuscaProdItem.Enabled = false;
                        this.btnBuscaProdItem.Text = "Limpar";

                        this.updateNCMPrincipal();

                        if (codigoAutomatico || this.txtCodigoItem.Text.Trim().Length == 0)
                        {
                            codigoAutomatico = true;
                            this.txtCodigoItem.Text = this.ProdutoSelecionadoItem.CodigoCliente;
                        }

                        if (descricaoAutomatica || this.txtDescricaoItem.Text.Trim().Length == 0)
                        {
                            descricaoAutomatica = true;
                            this.txtDescricaoItem.Text = this.ProdutoSelecionadoItem.Descricao;
                        }

                        MessageBox.Show(this, "Produto selecionado com sucesso.", "Produto Selecionado",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        this.ProdutoSelecionadoItem = null;
                    }
                }
                else
                {
                    this.txtBuscaProdItem.Clear();
                    this.txtCodigoItem.Clear();
                    this.txtDescricaoItem.Clear();
                    this.txtBuscaProdItem.Enabled = true;
                    this.ProdutoSelecionadoItem = null;
                    this.btnBuscaProdItem.Text = "Selecionar";
                    this.btnBuscaProdItem.Focus();
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o produto\r\n" + e.Message, e);
            }
        }

        private void selecionarCliente()
        {
            try
            {
                if (this.cmbCliente.SelectedItem != null)
                {
                    ClienteClass cliente = (ClienteClass) this.cmbCliente.SelectedItem;

                    if (!chkCentroCusto.Checked)
                    {
                        if (cliente.PossuiCentroCustoLucro)
                        {
                            this.txtCentroCusto.Text = cliente.CentroCustoLucro.ToString();
                            this.centroCustoSelecionado = cliente.CentroCustoLucro;
                        }
                        else
                        {
                            this.centroCustoSelecionado = null;
                            this.txtCentroCusto.Text = "";
                        }
                    }

                    if (!chkContaBancaria.Checked)
                    {
                        if (cliente.PossuiContaBancaria)
                        {
                            this.cmbContaBancaria.SelectedItem = cliente.ContaBancaria;
                        }
                        else
                        {
                            this.cmbContaBancaria.SelectedValue = -1;
                            this.cmbContaBancaria.Text = "";
                        }
                    }

                    if (!ensFormaPagamento.Enabled)
                    {
                        if (cliente.PossuiFormaPagamento)
                        {
                            this.ensFormaPagamento.EntidadeSelecionada = cliente.FormaPagamento;
                        }
                        else
                        {
                            this.ensFormaPagamento.Clear();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar o cliente.\r\n" + e.Message, e);
            }
        }

        private void loadComboRepresentante()
        {
            try
            {

                RepresentanteClass representante = new RepresentanteClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                List<RepresentanteClass> representantes =
                    representante.Search(new List<SearchParameterClass>()
                                             {
                                                 new SearchParameterClass("rep_razao_social", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)
                                             }).
                        ConvertAll(a => (RepresentanteClass) a);


                this.cmbRepresentante.DataSource = representantes;
                this.cmbRepresentante.DisplayMember = "RazaoSocial";
                this.cmbRepresentante.ValueMember = "ID";
                this.cmbRepresentante.autoSize = true;
                this.cmbRepresentante.Table = representantes;
                this.cmbRepresentante.ColumnsToDisplay = new[] {"RazaoSocial", "Cnpj", "Fone1", "Email"};
                this.cmbRepresentante.HeadersToDisplay = new[] {"Razão Social", "Cnpj", "Fone", "E-mail"};


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção de Representantes.\r\n" + e.Message);
            }
        }






        #region Eventos

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.validateRequiredFields();

                this.Orcamento.adicionarSubitem(this.ProdutoSelecionadoItem, txtCodigoItem.Text, txtDescricaoItem.Text, Convert.ToDouble(nudQtdItem.Value), 0, null);


                this.updateGrid();
                this.cleanItemFields();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    OrcamentoItemClass subLinha = (OrcamentoItemClass)((IWTDataGridViewRow)dataGridView1.SelectedRows[0]).DataBoundItem;
                    this.Orcamento.excluirSubItem(subLinha);
                    this.updateGrid();
                }
                else
                {
                    throw new Exception("Selecione o subitem que você deseja remover.");
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudQtd_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalMainItem();
        }

        private void nudValorUnit_ValueChanged(object sender, EventArgs e)
        {
            this.updateTotalMainItem();
        }

        private void btnVariaveis_Click(object sender, EventArgs e)
        {
            if (this.Orcamento.Numero != null)
            {
                CadOrcamentoItemVariavelListForm form = new CadOrcamentoItemVariavelListForm(this.Orcamento);
                form.ShowDialog();
            }

        }

     

        private void btnEditarItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Editar();
            }

            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarEdicao_Click(object sender, EventArgs e)
        {
            try
            {
                this.ConfirmarEdicao();
            }

            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkTipoKit_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbTipoKit.Enabled = this.chkTipoKit.Checked;
            this.gbxItem.Enabled = this.chkTipoKit.Checked;
        }

      

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            codigoAutomatico = false;
        }

        private void txtDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            descricaoAutomatica = false;
        }

     

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                this.habilitarCopiar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkNCM_CheckedChanged(object sender, EventArgs e)
        {
            this.txtNCM.Enabled = this.chkNCM.Checked;
        }

        private void chkContaBancaria_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbContaBancaria.Enabled = this.chkContaBancaria.Checked;
        }

        private void chkCentroCusto_CheckedChanged(object sender, EventArgs e)
        {
            this.btnCentroCusto.Enabled = this.chkCentroCusto.Checked;
            if (!this.chkCentroCusto.Checked)
            {
                this.centroCustoSelecionado = null;
                this.txtCentroCusto.Clear();
            }
        }

        private void btnCentroCusto_Click(object sender, EventArgs e)
        {
            try
            {
                this.selcionarCentroCusto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadOrcamentoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Orcamento.Alterado)
            {
                string mensagem = "";

                mensagem = "O orcamento foi alterado e não foi salvo, deseja salvar antes de sair?";


                DialogResult res = MessageBox.Show(this, mensagem, "Salvar", MessageBoxButtons.YesNoCancel,
                                                   MessageBoxIcon.Question);

                switch (res)
                {

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                    case DialogResult.Yes:
                        this.btnSalvar_Click(null, null);
                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void lnkDetalhesPrincipal_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.detalhesPrincipal();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDetalhesSub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.detalhesSub();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscaProduto_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscaProduto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscaProduto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.btnBuscaProduto_Click(sender, null);
            }
        }

        private void btnBuscaProdItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscaProdutoItem();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscaProdItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.btnBuscaProdItem_Click(sender, null);
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CadOrcamentoForm_Shown(object sender, EventArgs e)
        {

            try
            {
                this.selecionarCliente();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void txtBuscaProduto_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkRepresentante_CheckedChanged(object sender, EventArgs e)
        {
            cmbRepresentante.Enabled = chkRepresentante.Checked;
            nudComissaoRepresentante.Enabled = chkRepresentante.Checked;
        }

        private void cmbRepresentante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbRepresentante.SelectedValue != null)
                {
                    RepresentanteClass rep = RepresentanteBaseClass.GetEntidade(int.Parse(cmbRepresentante.SelectedValue.ToString()), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    nudComissaoRepresentante.Value = (Decimal) rep.Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Representante selecionado\r\n" + a.Message);
            }
        }

        private void chkVendedor_CheckedChanged(object sender, EventArgs e)
        {
            cmbVendedor.Enabled = chkVendedor.Checked;
            nudComissaoVendedor.Enabled = chkVendedor.Checked;
        }

        private void cmbVendedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbVendedor.SelectedValue != null)
                {
                    VendedorClass rep = VendedorBaseClass.GetEntidade(int.Parse(cmbVendedor.SelectedValue.ToString()), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);
                    nudComissaoVendedor.Value = (Decimal)rep.Comissao;
                }
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar a comissão do Vendedor selecionado\r\n" + a.Message);
            }

        }

  

        #endregion

       

    }
}
