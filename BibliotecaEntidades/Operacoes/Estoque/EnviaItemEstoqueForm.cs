#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.Estoque
{
    public partial class EnviaItemEstoqueForm : IWTBaseForm
    {
        enum PassoAtualTela { SelecaoEstoque, SelecaoCorredor, SelecaoPrateleira, SelecaoGaveta, Observacao };
        public enum tipoUtilizacao { Material, Produto, Recurso, CópiaDocumento, ProdutoK, Epi }
        
        private PassoAtualTela passoAtual;
        public EstoqueGavetaClass GavetaSelecionada { get; private set; }
        public EstoquePrateleiraClass PrateleiraSelecionada { get; private set; }
        public EstoqueCorredorClass CorredorSelecionado { get; private set; }
        public EstoqueClass EstoqueSelecionado { get; private set; }


        readonly IWTPostgreNpgsqlConnection conn;
        readonly tipoUtilizacao tipo;
        readonly double Quantidade;
        string textoDescricao;
        readonly int idItemEstoque;
        readonly AcsUsuarioClass Usuario;
        IWTPostgreNpgsqlCommand command;
        readonly bool quantidadeManual;
        readonly bool obsManual;
        readonly string Obs;
        readonly bool movimentacaoTotal;
        readonly string Unidade;
        readonly EstoqueGavetaItemClass gavetaOrigem;
        public AbstractEntity ItemEstoque { get; set; }
        public string EntidadeGeradora { get; private set; }

        public bool Salvo { get; private set; }

        public bool Cancelar { private set; get; }


        List<EstoqueGavetaClass> gavetasPermitidas = new List<EstoqueGavetaClass>();
        private bool _somenteGavetasPermitidas = false;

        public EnviaItemEstoqueForm(tipoUtilizacao tipo, string textoDescricao, bool quantidadeManual, double Quantidade, string Unidade, bool obsManual, string Obs, AbstractEntity itemEstoque, bool movimentacaoTotal, EstoqueGavetaItemClass gavetaOrigem, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, ref IWTPostgreNpgsqlCommand command, string entidadeGeradora, bool verificaPermissaoUso = true)
        {
            InitializeComponent();
            this.conn = conn;
            ItemEstoque = itemEstoque;
            this.EntidadeGeradora = entidadeGeradora;
            this.tipo = tipo;
            this.textoDescricao = textoDescricao;
            this.Quantidade = Quantidade;
            this.quantidadeManual = quantidadeManual;
            
            this.movimentacaoTotal = movimentacaoTotal;
            this.gavetaOrigem = gavetaOrigem;
            this.Unidade = Unidade;
            this.Usuario = Usuario;
            this.command = command;

            this.Cancelar = false;

            this.obsManual = obsManual;
            this.Obs = Obs;
            if (quantidadeManual || this.Quantidade == 0)
            {
                this.lblItemEstoque.Text = tipo.ToString() + " " + textoDescricao;
            }
            else
            {
                this.lblItemEstoque.Text = tipo.ToString() + " " + textoDescricao + " - " + Quantidade.ToString();
                
            }





            if (verificaPermissaoUso && !IWTConfiguration.Conf.getBoolConf(ProjectConstants.Constants.ESTOQUE_PERMITIR_CRIAR_LOCAL_ESTOQUE))
            {
                _somenteGavetasPermitidas = true;

                switch (tipo)
                {
                    case tipoUtilizacao.Material:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasMaterial((MaterialClass) itemEstoque, null, command);
                        break;
                    case tipoUtilizacao.Produto:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasProduto((ProdutoClass)itemEstoque, null, command);
                        break;
                    case tipoUtilizacao.Recurso:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasRecursos((RecursoClass)itemEstoque, command);
                        break;
                    case tipoUtilizacao.CópiaDocumento:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasDocumentoCopia((DocumentoCopiaClass)itemEstoque,  command);
                        break;
                    case tipoUtilizacao.ProdutoK:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasProdutoK((ProdutoKClass)itemEstoque,  command);
                        break;
                    case tipoUtilizacao.Epi:
                        gavetasPermitidas = EstoqueMovimentacao.BuscaTodasGavetasEpi((EpiClass)itemEstoque,  command);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(tipo), tipo, null);
                }

                if (gavetasPermitidas.Count == 0)
                {
                    throw new ExcecaoTratada("O item não pode ser colocado no estoque pois a restrição de criação está ativa e o item não possui nenhuma gaveta definida");
                }

            }


            this.ConfiguraTela(PassoAtualTela.SelecaoEstoque);

            
        }

        private void ConfiguraTela(PassoAtualTela passoAtual)
        {
            PassoAtualTela passoAnterior = this.passoAtual;
            try
            {
                this.passoAtual = passoAtual;
                switch (passoAtual)
                {
                    case PassoAtualTela.SelecaoEstoque:
                        this.lblLocalEstoque.Text = "";
                        this.lblLocalAtual.Text = "Selecione o estoque";
                        this.dgvEstoque.Visible = true;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = false;
                        this.txtObservacao.Visible = false;
                        this.lblObservacoes.Visible = false;
                        this.nudQuantidade.Visible = false;
                        this.lblQuantidade.Visible = false;
                        this.lblUnidade.Visible = false;
                        

                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Cancelar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.initializeGridEstoque("");
                        break;

                    case PassoAtualTela.SelecaoCorredor:
                        this.lblLocalEstoque.Text = EstoqueSelecionado.ToString();
                        this.lblLocalAtual.Text = "Selecione o corredor";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = true;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = false;
                        this.txtObservacao.Visible = false;
                        this.lblObservacoes.Visible = false;
                        this.nudQuantidade.Visible = false;
                        this.lblQuantidade.Visible = false;
                        this.lblUnidade.Visible = false;

                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridCorredor("");
                        break;

                    case PassoAtualTela.SelecaoPrateleira:
                        this.lblLocalEstoque.Text = CorredorSelecionado.ToString();
                        this.lblLocalAtual.Text = "Selecione a prateleira";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = true;
                        this.dgvGaveta.Visible = false;
                        this.txtObservacao.Visible = false;
                        this.lblObservacoes.Visible = false;
                        this.nudQuantidade.Visible = false;
                        this.lblQuantidade.Visible = false;
                        this.lblUnidade.Visible = false;


                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridPrateleira("");
                        break;

                    case PassoAtualTela.SelecaoGaveta:
                        this.lblLocalEstoque.Text = PrateleiraSelecionada.ToString();
                        this.lblLocalAtual.Text = "Selecione a gaveta";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = true;
                        this.txtObservacao.Visible = false;
                        this.lblObservacoes.Visible = false;
                        this.nudQuantidade.Visible = false;
                        this.lblQuantidade.Visible = false;
                        this.lblUnidade.Visible = false;

                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridGaveta("");
                        break;
                    case PassoAtualTela.Observacao:
                        this.lblLocalEstoque.Text = GavetaSelecionada.ToString();

                        if (!this.obsManual && !this.quantidadeManual)
                        {
                            this.Save();
                        }
                        
                        
                        this.lblLocalAtual.Text = "";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = false;


                        this.txtObservacao.Visible = true;
                        this.lblObservacoes.Visible = true;
                        this.txtObservacao.Text = this.Obs;
                        this.txtObservacao.Enabled = this.obsManual;




                        this.nudQuantidade.Visible = true;
                        this.lblQuantidade.Visible = true;
                        this.lblUnidade.Visible = true;
                        this.lblUnidade.Text = this.Unidade;
                        this.nudQuantidade.Value = Convert.ToDecimal(this.Quantidade);
                        if (this.quantidadeManual)
                        {
                            this.nudQuantidade.Enabled = true;
                            this.nudQuantidade.ReadOnly = false;
                            if (this.tipo == tipoUtilizacao.CópiaDocumento)
                            {
                                this.nudQuantidade.Maximum = 1;
                            }
                            else
                            {
                                this.nudQuantidade.Maximum = 999999999;
                            }
                        }
                        else
                        {
                            this.nudQuantidade.Enabled = false;
                            this.nudQuantidade.ReadOnly = true;
                        }
                        this.btnAvancar.Text = "Salvar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = false;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = false;
                        break;
                    default :
                        throw new Exception("Passo inválido");
                }

                
            }
            catch (Exception e)
            {
                this.passoAtual = passoAnterior;
                throw new Exception("Erro ao configurar a tela.\r\n" + e.Message);
            }
        }

        private void realizaBusca()
        {
            try
            {
                if (this.txtBusca.Text.Trim().Length == 0)
                {
                    return;
                }

                
                switch (passoAtual)
                {
                    case PassoAtualTela.SelecaoEstoque:
                        this.initializeGridEstoque(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTela.SelecaoCorredor:
                        this.initializeGridCorredor(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTela.SelecaoPrateleira:
                        this.initializeGridPrateleira(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTela.SelecaoGaveta:
                        this.initializeGridGaveta(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTela.Observacao:
                        throw new Exception("Não é possível realizar a busca no passo de observação.");
                        break;
                    default:
                        throw new Exception("Passo inválido");
                }

                

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }
        }

        private void initializeGridGaveta(string busca)
        {
            try
            {
                if (passoAtual != PassoAtualTela.SelecaoGaveta)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvGaveta.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvGaveta.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvGaveta.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvGaveta.SelectedRows[0].Index;
                }
                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (binding != null)
                {
                    atualFilter = binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dgvGaveta.SortedColumn != null)
                {
                    sortedColumName = this.dgvGaveta.SortedColumn.Name;
                    sortedMode = this.dgvGaveta.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND (esg_identificacao LIKE '%" + busca + "%' OR esg_descricao LIKE '%" + busca + "%' ) ";
                }


                if (_somenteGavetasPermitidas)
                {
                    string gav = "";

                    foreach (EstoqueGavetaClass gaveta in gavetasPermitidas)
                    {
                        gav += " OR id_estoque_gaveta = " + gaveta.ID + " ";


                    }

                    whereClause += " AND ( " + gav.Substring(3) + " ) ";
                }

                string sql =
                    "SELECT  " +
                    "  id_estoque_gaveta, " +
                    "  esg_identificacao, " +
                    "  esg_descricao " +
                    "FROM  " +
                    "  public.estoque_gaveta " +
                    "WHERE " +
                    "  id_estoque_prateleira = " + this.PrateleiraSelecionada.ID + " " +
                    "  AND esg_ativo = 1 "+
                    whereClause +
                    "ORDER BY " +
                    "  esg_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvGaveta.AutoGenerateColumns = true;
                    dgvGaveta.DataSource = binding;

                    dgvGaveta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvGaveta.MultiSelect = false;

                    this.dgvGaveta.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvGaveta.Columns[1], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvGaveta.Columns[2], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);

                }

                #region Restaurando Sort Atual do Grid

                if (sortedColumName != null)
                {
                    string sortString = sortedColumName;
                    switch (sortedMode)
                    {
                        case SortOrder.Ascending:
                            sortString += " ASC";
                            break;
                        case SortOrder.Descending:
                            sortString += " DESC";
                            break;
                    }

                    binding.Sort = sortString;
                }
                #endregion

                #region Restaurando Posição do Grid
                for (int i = 0; i < this.dgvGaveta.SelectedRows.Count; i++)
                {
                    this.dgvGaveta.SelectedRows[i].Selected = false;
                }
                if (this.dgvGaveta.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvGaveta.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvGaveta.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvGaveta.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvGaveta.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de gavetas.\r\n" + e.Message);
            }
        }

        private void initializeGridPrateleira(string busca)
        {
            try
            {
                if (passoAtual != PassoAtualTela.SelecaoPrateleira)
                {
                    return;
                }

                BindingSource binding = null;

                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvPrateleira.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvPrateleira.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvPrateleira.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvPrateleira.SelectedRows[0].Index;
                }
                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (binding != null)
                {
                    atualFilter = binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dgvPrateleira.SortedColumn != null)
                {
                    sortedColumName = this.dgvPrateleira.SortedColumn.Name;
                    sortedMode = this.dgvPrateleira.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND (esp_identificacao LIKE '%" + busca + "%' OR esp_descricao LIKE '%" + busca + "%' ) ";
                }

                if (_somenteGavetasPermitidas)
                {
                    string gav = "";

                    foreach (EstoqueGavetaClass gaveta in gavetasPermitidas)
                    {
                        gav += " OR id_estoque_prateleira = " + gaveta.EstoquePrateleira.ID + " ";


                    }

                    whereClause += " AND ( " + gav.Substring(3) + " ) ";
                }

                string sql =
                    "SELECT  " +
                    "  id_estoque_prateleira, " +
                    "  esp_identificacao, " +
                    "  esp_descricao " +
                    "FROM  " +
                    "  public.estoque_prateleira " +
                    "WHERE " +
                    "  id_estoque_corredor = " + this.CorredorSelecionado.ID + " " +
                    "  AND esp_ativo = 1 " +
                    whereClause +
                    "ORDER BY " +
                    "  esp_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvPrateleira.AutoGenerateColumns = true;
                    dgvPrateleira.DataSource = binding;

                    dgvPrateleira.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvPrateleira.MultiSelect = false;

                    this.dgvPrateleira.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvPrateleira.Columns[1], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvPrateleira.Columns[2], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);

                }

                #region Restaurando Sort Atual do Grid

                if (sortedColumName != null)
                {
                    string sortString = sortedColumName;
                    switch (sortedMode)
                    {
                        case SortOrder.Ascending:
                            sortString += " ASC";
                            break;
                        case SortOrder.Descending:
                            sortString += " DESC";
                            break;
                    }

                    binding.Sort = sortString;
                }
                #endregion

                #region Restaurando Posição do Grid
                for (int i = 0; i < this.dgvPrateleira.SelectedRows.Count; i++)
                {
                    this.dgvPrateleira.SelectedRows[i].Selected = false;
                }
                if (this.dgvPrateleira.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvPrateleira.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvPrateleira.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvPrateleira.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvPrateleira.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de prateleiras.\r\n" + e.Message);
            }
        }

        private void initializeGridCorredor(string busca)
        {
            try
            {

                if (passoAtual != PassoAtualTela.SelecaoCorredor)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvCorredor.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvCorredor.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvCorredor.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvCorredor.SelectedRows[0].Index;
                }
                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (binding != null)
                {
                    atualFilter = binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dgvCorredor.SortedColumn != null)
                {
                    sortedColumName = this.dgvCorredor.SortedColumn.Name;
                    sortedMode = this.dgvCorredor.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND (esc_identificacao LIKE '%" + busca + "%' OR esc_descricao LIKE '%" + busca + "%' ) ";
                }

                if (_somenteGavetasPermitidas)
                {
                    string gav = "";

                    foreach (EstoqueGavetaClass gaveta in gavetasPermitidas)
                    {
                        gav += " OR id_estoque_corredor = " + gaveta.EstoquePrateleira.EstoqueCorredor.ID + " ";


                    }

                    whereClause += " AND ( " + gav.Substring(3) + " ) ";
                }

                string sql =
                    "SELECT  " +
                    "  id_estoque_corredor, " +
                    "  esc_identificacao, " +
                    "  esc_descricao " +
                    "FROM  " +
                    "  public.estoque_corredor " +
                    "WHERE " +
                    "  id_estoque = " + this.EstoqueSelecionado.ID + " " +
                    "  AND esc_ativo = 1 " +
                    whereClause +
                    "ORDER BY " +
                    "  esc_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvCorredor.AutoGenerateColumns = true;
                    dgvCorredor.DataSource = binding;

                    dgvCorredor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvCorredor.MultiSelect = false;

                    this.dgvCorredor.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvCorredor.Columns[1], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvCorredor.Columns[2], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);

                }

                #region Restaurando Sort Atual do Grid

                if (sortedColumName != null)
                {
                    string sortString = sortedColumName;
                    switch (sortedMode)
                    {
                        case SortOrder.Ascending:
                            sortString += " ASC";
                            break;
                        case SortOrder.Descending:
                            sortString += " DESC";
                            break;
                    }

                    binding.Sort = sortString;
                }
                #endregion

                #region Restaurando Posição do Grid
                for (int i = 0; i < this.dgvCorredor.SelectedRows.Count; i++)
                {
                    this.dgvCorredor.SelectedRows[i].Selected = false;
                }
                if (this.dgvCorredor.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvCorredor.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvCorredor.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvCorredor.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvCorredor.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de corredores.\r\n" + e.Message);
            }
        }

        private void initializeGridEstoque(string busca)
        {
            try
            {
                if (passoAtual != PassoAtualTela.SelecaoEstoque)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvEstoque.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvEstoque.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvEstoque.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvEstoque.SelectedRows[0].Index;
                }
                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (binding != null)
                {
                    atualFilter = binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dgvEstoque.SortedColumn != null)
                {
                    sortedColumName = this.dgvEstoque.SortedColumn.Name;
                    sortedMode = this.dgvEstoque.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND (est_identificacao LIKE '%" + busca + "%' OR est_descricao LIKE '%" + busca + "%' ) ";
                }

                if (_somenteGavetasPermitidas)
                {
                    string gav = "";
                    
                    foreach (EstoqueGavetaClass gaveta in gavetasPermitidas)
                    {
                        gav += " OR id_estoque = " + gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.ID + " ";

                        
                    }

                    whereClause+= " AND ( " + gav.Substring(3) + " ) ";
                }

                string sql =
                    "SELECT  " +
                    "  id_estoque, " +
                    "  est_identificacao, " +
                    "  est_descricao " +
                    "FROM  " +
                    "  public.estoque " +
                    "WHERE "+
                    "  est_ativo = 1 " +
                    whereClause +
                    "ORDER BY " +
                    "  est_identificacao";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvEstoque.AutoGenerateColumns = true;
                    dgvEstoque.DataSource = binding;

                    dgvEstoque.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEstoque.MultiSelect = false;

                    this.dgvEstoque.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoque.Columns[1], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoque.Columns[2], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);

                }

                #region Restaurando Sort Atual do Grid

                if (sortedColumName != null)
                {
                    string sortString = sortedColumName;
                    switch (sortedMode)
                    {
                        case SortOrder.Ascending:
                            sortString += " ASC";
                            break;
                        case SortOrder.Descending:
                            sortString += " DESC";
                            break;
                    }

                    binding.Sort = sortString;
                }
                #endregion

                #region Restaurando Posição do Grid
                for (int i = 0; i < this.dgvEstoque.SelectedRows.Count; i++)
                {
                    this.dgvEstoque.SelectedRows[i].Selected = false;
                }
                if (this.dgvEstoque.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvEstoque.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvEstoque.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvEstoque.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvEstoque.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de estoques.\r\n" + e.Message);
            }
        }
        
        private void Voltar()
        {
            try
            {
                switch (passoAtual)
                {
                    case PassoAtualTela.SelecaoEstoque:
                        this.Cancelar = true;
                        this.Close();
                        break;
                    case PassoAtualTela.SelecaoCorredor:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Estoque já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.GavetaSelecionada = null;
                        this.EstoqueSelecionado = null;
                        this.PrateleiraSelecionada = null;
                        CorredorSelecionado = null;
                        this.ConfiguraTela(PassoAtualTela.SelecaoEstoque);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    case PassoAtualTela.SelecaoPrateleira:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Corredor já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.CorredorSelecionado = null;
                        this.PrateleiraSelecionada = null;
                        this.GavetaSelecionada = null;
                        this.ConfiguraTela(PassoAtualTela.SelecaoCorredor);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    case PassoAtualTela.SelecaoGaveta:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Prateleira já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.PrateleiraSelecionada = null;
                        this.GavetaSelecionada = null;
                        this.ConfiguraTela(PassoAtualTela.SelecaoPrateleira);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    case PassoAtualTela.Observacao:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Gaveta já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.GavetaSelecionada = null;
                        this.GavetaSelecionada = null;
                        this.ConfiguraTela(PassoAtualTela.SelecaoGaveta);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    default:
                        throw new Exception("Passo inválido");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao voltar.\r\n" + e.Message);
            }
        }

        private void Avancar()
        {
            try
            {
                switch (passoAtual)
                {
                    case PassoAtualTela.SelecaoEstoque:
                        if (dgvEstoque.SelectedRows.Count == 1)
                        {
                            this.EstoqueSelecionado = EstoqueClass.GetEntidade(Convert.ToInt32(dgvEstoque.SelectedRows[0].Cells["id_estoque"].Value), Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTela.SelecaoCorredor);
                        }
                        else
                        {
                            throw new Exception("Selecione o estoque antes de continuar.");
                        }
                        break;

                    case PassoAtualTela.SelecaoCorredor:
                        if (dgvCorredor.SelectedRows.Count == 1)
                        {
                            this.CorredorSelecionado = EstoqueCorredorClass.GetEntidade(Convert.ToInt32(dgvCorredor.SelectedRows[0].Cells["id_estoque_corredor"].Value), Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTela.SelecaoPrateleira);
                        }
                        else
                        {
                            throw new Exception("Selecione o corredor antes de continuar.");
                        }
                        break;


                    case PassoAtualTela.SelecaoPrateleira:
                        if (dgvPrateleira.SelectedRows.Count == 1)
                        {
                            this.PrateleiraSelecionada = EstoquePrateleiraClass.GetEntidade(Convert.ToInt32(dgvPrateleira.SelectedRows[0].Cells["id_estoque_prateleira"].Value),Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTela.SelecaoGaveta);
                        }
                        else
                        {
                            throw new Exception("Selecione a prateleira antes de continuar.");
                        }
                        break;

                    case PassoAtualTela.SelecaoGaveta:
                        if (dgvGaveta.SelectedRows.Count == 1)
                        {
                            this.GavetaSelecionada = EstoqueGavetaClass.GetEntidade(Convert.ToInt32(dgvGaveta.SelectedRows[0].Cells["id_estoque_gaveta"].Value), Usuario, conn);
                            
                            this.ConfiguraTela(PassoAtualTela.Observacao);
                        }
                        else
                        {
                            throw new Exception("Selecione o estoque antes de continuar.");
                        }
                        break;
                    case PassoAtualTela.Observacao:
                        if (!this.obsManual || this.txtObservacao.Text.Trim().Length > 5)
                        {
                            this.Save();
                        }
                        else
                        {
                            throw new Exception("O campo de observação é obrigatório e deve ter ao menos 5 caracteres.");
                        }
                        break;
                    default:
                        throw new Exception("Passo inválido");
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }
        }

        private void Save()
        {
            try
            {
                bool exibirPergunta = true;
                string msgSucesso = "Item salvo com sucesso!";

                if (!this.obsManual && !this.quantidadeManual)
                {
                    exibirPergunta = false;
                    msgSucesso = "Localização criada com sucesso!";
                }

                DialogResult resp = DialogResult.Yes;

                if (exibirPergunta)
                {
                    resp = MessageBox.Show(this, "Essa operação irá salvar os itens no local estoque selecionado. Deseja continuar?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }

                if (resp == DialogResult.Yes)
                {

                    switch (this.tipo)
                    {
                        case tipoUtilizacao.CópiaDocumento:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueDocumentoCopia(
                                    this.GavetaSelecionada, (DocumentoCopiaClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text,this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalDocumentoCopia(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (DocumentoCopiaClass)this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;
                        case tipoUtilizacao.Material:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueMaterial(
                                    this.GavetaSelecionada, (MaterialClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text, this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalMaterial(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (MaterialClass) this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;
                        case tipoUtilizacao.Produto:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueProduto(
                                    this.GavetaSelecionada, (ProdutoClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text, this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalProduto(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (ProdutoClass) this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;
                        case tipoUtilizacao.Recurso:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueRecurso(
                                    this.GavetaSelecionada, (RecursoClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text, this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalRecurso(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (RecursoClass) this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;

                        case tipoUtilizacao.ProdutoK:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueProdutoK(
                                    this.GavetaSelecionada, (ProdutoKClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text, this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalProdutoK(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (ProdutoKClass) this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;
                        case tipoUtilizacao.Epi:
                            if (!this.movimentacaoTotal)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueEpi(
                                    this.GavetaSelecionada, (EpiClass) this.ItemEstoque, Convert.ToDouble(this.nudQuantidade.Value), this.txtObservacao.Text, this.EntidadeGeradora,
                                    this.Usuario, this.quantidadeManual, ref command);
                            }
                            else
                            {
                                EstoqueMovimentacao.TrocaItemGavetaTotalEpi(
                                    this.gavetaOrigem,
                                    this.GavetaSelecionada,
                                    (EpiClass) this.ItemEstoque,
                                    this.Usuario,
                                    ref command);
                            }
                            break;
                    }
                }
                else
                {
                    return;
                }

                MessageBox.Show(this, msgSucesso , "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Salvo = true;
                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            try
            {
                this.realizaBusca();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Voltar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAvancar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
 
        private void dgvCorredor_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEstoque_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvGaveta_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPrateleira_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Avancar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion
    }
}
