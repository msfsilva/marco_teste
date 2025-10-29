#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos.Estoque
{
    public partial class InventarioSelectForm : IWTBaseForm
    {
        enum PassoAtualTelaInventario { SelecaoEstoque, SelecaoCorredor, SelecaoPrateleira, SelecaoGaveta };

        private PassoAtualTelaInventario passoAtual;
        private EstoqueGavetaClass gavetaSelecionada = null;
        private EstoquePrateleiraClass prateleiraSelecionada = null;
        private EstoqueCorredorClass corredorSelecionado = null;
        private EstoqueClass estoqueSelecionado = null;


        readonly IWTPostgreNpgsqlConnection conn;
        AcsUsuarioClass Usuario;
       

        public InventarioSelectForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            
            this.Usuario = Usuario;
            this.ConfiguraTela(PassoAtualTelaInventario.SelecaoEstoque);

            
        }

        private void ConfiguraTela(PassoAtualTelaInventario passoAtual)
        {
            PassoAtualTelaInventario passoAnterior = this.passoAtual;
            try
            {
                this.passoAtual = passoAtual;
                switch (passoAtual)
                {
                    case PassoAtualTelaInventario.SelecaoEstoque:
                        this.lblLocalEstoque.Text = "";
                        this.lblLocalAtual.Text = "Selecione o estoque";
                        this.dgvEstoque.Visible = true;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = false;

                        this.btnAvancar.Enabled = true;
                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Cancelar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.initializeGridEstoque("");
                        break;

                    case PassoAtualTelaInventario.SelecaoCorredor:
                        this.lblLocalEstoque.Text = estoqueSelecionado.ToString();
                        this.lblLocalAtual.Text = "Selecione o corredor";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = true;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = false;

                        this.btnAvancar.Enabled = true;
                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridCorredor("");
                        break;

                    case PassoAtualTelaInventario.SelecaoPrateleira:
                        this.lblLocalEstoque.Text = corredorSelecionado.ToString();
                        this.lblLocalAtual.Text = "Selecione a prateleira";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = true;
                        this.dgvGaveta.Visible = false;

                        this.btnAvancar.Enabled = true;
                        this.btnAvancar.Text = "Avançar";
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridPrateleira("");
                        break;

                    case PassoAtualTelaInventario.SelecaoGaveta:
                        this.lblLocalEstoque.Text = prateleiraSelecionada.ToString();
                        this.lblLocalAtual.Text = "Selecione a gaveta";
                        this.dgvEstoque.Visible = false;
                        this.dgvCorredor.Visible = false;
                        this.dgvPrateleira.Visible = false;
                        this.dgvGaveta.Visible = true;

                        this.btnAvancar.Text = "Avançar";
                        this.btnAvancar.Enabled = false;
                        this.btnVoltar.Text = "Voltar";

                        this.txtBusca.Visible = true;
                        this.txtBusca.Text = "";
                        this.lblBusca.Visible = true;
                        this.initializeGridGaveta("");
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


                
                switch (passoAtual)
                {
                    case PassoAtualTelaInventario.SelecaoEstoque:
                        this.initializeGridEstoque(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTelaInventario.SelecaoCorredor:
                        this.initializeGridCorredor(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTelaInventario.SelecaoPrateleira:
                        this.initializeGridPrateleira(this.txtBusca.Text.Trim());
                        break;
                    case PassoAtualTelaInventario.SelecaoGaveta:
                        this.initializeGridGaveta(this.txtBusca.Text.Trim());
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
                if (passoAtual != PassoAtualTelaInventario.SelecaoGaveta)
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


                string sql =
                    "SELECT  " +
                    "  id_estoque_gaveta, " +
                    "  esg_identificacao, " +
                    "  esg_descricao " +
                    "FROM  " +
                    "  public.estoque_gaveta " +
                    "WHERE " +
                    "  id_estoque_prateleira = " + this.prateleiraSelecionada.ID + " " +
                    "  AND esg_ativo = 1 " +
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
                if (passoAtual != PassoAtualTelaInventario.SelecaoPrateleira)
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

                string sql =
                    "SELECT  " +
                    "  id_estoque_prateleira, " +
                    "  esp_identificacao, " +
                    "  esp_descricao " +
                    "FROM  " +
                    "  public.estoque_prateleira " +
                    "WHERE " +
                    "  id_estoque_corredor = " + this.corredorSelecionado.ID + " " +
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

                if (passoAtual != PassoAtualTelaInventario.SelecaoCorredor)
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

                string sql =
                    "SELECT  " +
                    "  id_estoque_corredor, " +
                    "  esc_identificacao, " +
                    "  esc_descricao " +
                    "FROM  " +
                    "  public.estoque_corredor " +
                    "WHERE " +
                    "  id_estoque = " + this.estoqueSelecionado.ID + " " +
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
                if (passoAtual != PassoAtualTelaInventario.SelecaoEstoque)
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
                    case PassoAtualTelaInventario.SelecaoEstoque:
                        this.Close();
                        break;
                    case PassoAtualTelaInventario.SelecaoCorredor:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Estoque já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                            this.gavetaSelecionada = null;
                        this.prateleiraSelecionada = null;
                        corredorSelecionado = null;
                        estoqueSelecionado = null;
                            this.ConfiguraTela(PassoAtualTelaInventario.SelecaoEstoque);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    case PassoAtualTelaInventario.SelecaoPrateleira:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Corredor já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.gavetaSelecionada = null;
                        this.prateleiraSelecionada = null;
                        corredorSelecionado = null;
                        this.ConfiguraTela(PassoAtualTelaInventario.SelecaoCorredor);
                        //}
                        //else
                        //{
                        //    return;
                        //}
                        break;

                    case PassoAtualTelaInventario.SelecaoGaveta:
                        //if (MessageBox.Show(this, "Você deseja voltar? Ao voltar a seleção de Prateleira já realizada será perdida.",
                        //    "Voltar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //{
                        this.gavetaSelecionada = null;
                        this.prateleiraSelecionada = null;
                        this.ConfiguraTela(PassoAtualTelaInventario.SelecaoPrateleira);
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
                    case PassoAtualTelaInventario.SelecaoEstoque:
                        if (dgvEstoque.SelectedRows.Count == 1)
                        {

                            this.estoqueSelecionado = EstoqueClass.GetEntidade(Convert.ToInt32(dgvEstoque.SelectedRows[0].Cells["id_estoque"].Value), Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTelaInventario.SelecaoCorredor);
                        }
                        else
                        {
                            throw new Exception("Selecione o estoque antes de continuar.");
                        }
                        break;

                    case PassoAtualTelaInventario.SelecaoCorredor:
                        if (dgvCorredor.SelectedRows.Count == 1)
                        {
                            corredorSelecionado = EstoqueCorredorClass.GetEntidade(Convert.ToInt32(dgvCorredor.SelectedRows[0].Cells["id_estoque_corredor"].Value),Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTelaInventario.SelecaoPrateleira);
                        }
                        else
                        {
                            throw new Exception("Selecione o corredor antes de continuar.");
                        }
                        break;


                    case PassoAtualTelaInventario.SelecaoPrateleira:
                        if (dgvPrateleira.SelectedRows.Count == 1)
                        {
                            prateleiraSelecionada = EstoquePrateleiraClass.GetEntidade(Convert.ToInt32(dgvPrateleira.SelectedRows[0].Cells["id_estoque_prateleira"].Value),Usuario, this.conn);
                            this.ConfiguraTela(PassoAtualTelaInventario.SelecaoGaveta);
                        }
                        else
                        {
                            throw new Exception("Selecione a prateleira antes de continuar.");
                        }
                        break;

                    case PassoAtualTelaInventario.SelecaoGaveta:
                        if (dgvGaveta.SelectedRows.Count == 1)
                        {
                            gavetaSelecionada = EstoqueGavetaClass.GetEntidade(Convert.ToInt32(dgvGaveta.SelectedRows[0].Cells["id_estoque_gaveta"].Value),Usuario,conn);
                            this.gerarInventario();
                        }
                        else
                        {
                            throw new Exception("Selecione o estoque antes de continuar.");
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

        private void gerarInventario()
        {
            try
            {
                InventarioReportForm form;
                switch (this.passoAtual)
                {
                    case PassoAtualTelaInventario.SelecaoEstoque:
                        if (dgvEstoque.SelectedRows.Count == 1)
                        {
                            form = new InventarioReportForm(EstoqueClass.GetEntidade(Convert.ToInt32(dgvEstoque.SelectedRows[0].Cells["id_estoque"].Value), Usuario, conn), null, null, null, conn);
                        }
                        else
                        {
                            throw new Exception("Selecione o estoque antes de continuar.");
                        }
                        break;
                    case PassoAtualTelaInventario.SelecaoCorredor:
                        if (dgvCorredor.SelectedRows.Count == 1)
                        {
                            form = new InventarioReportForm(null, EstoqueCorredorClass.GetEntidade(Convert.ToInt32(dgvCorredor.SelectedRows[0].Cells["id_estoque_corredor"].Value),Usuario,conn), null, null,conn);
                        }
                        else
                        {
                            throw new Exception("Selecione o corredor antes de continuar.");
                        }
                        break;
                    case PassoAtualTelaInventario.SelecaoPrateleira:
                        if (dgvPrateleira.SelectedRows.Count == 1)
                        {
                            form = new InventarioReportForm(null, null, EstoquePrateleiraClass.GetEntidade(Convert.ToInt32(dgvPrateleira.SelectedRows[0].Cells["id_estoque_prateleira"].Value), Usuario, conn), null, conn);
                        }
                        else
                        {
                            throw new Exception("Selecione a prateleira antes de continuar.");
                        }
                        break;
                    case PassoAtualTelaInventario.SelecaoGaveta:
                        if (dgvGaveta.SelectedRows.Count == 1)
                        {
                            form = new InventarioReportForm(null, null, null, EstoqueGavetaClass.GetEntidade(Convert.ToInt32(dgvGaveta.SelectedRows[0].Cells["id_estoque_gaveta"].Value), Usuario, conn), conn);
                        }
                        else
                        {
                            throw new Exception("Selecione a gaveta antes de continuar.");
                        }
                        break;
                    default:
                        throw new Exception("Passo Inválido.");
                        break;
                }

                form.Show();
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            try
            {
                this.gerarInventario();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

    }
}
