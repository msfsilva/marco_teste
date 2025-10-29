#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaCadastrosBasicos.Estoque
{
    public partial class MovimentacaoManualEstoqueForm : IWTBaseForm
    {
        enum passoTela { SelecaoItem, VisualizacaoEstoque, AlteracaoEstoque }
        passoTela passoAtual;
        EnviaItemEstoqueForm.tipoUtilizacao tipoUtilizacaoSelecionado;
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;

        List<int> produtosComGaveta;
        private List<int> materiaisComGaveta;
        private List<int> recursosComGaveta;
        private List<int> documentosComGaveta;
        private List<int> produtosKComGaveta;
        private List<int> epiComGaveta;

        public MovimentacaoManualEstoqueForm(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            try
            {
                this.conn = conn;
                this.Usuario = Usuario;
                InitializeComponent();
                this.loadListsItensComGaveta();
                this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.Material);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void ConfiguraTela(passoTela novoPasso, EnviaItemEstoqueForm.tipoUtilizacao tipoSelecionado)
        {
            passoTela passoAnterior = this.passoAtual;
            EnviaItemEstoqueForm.tipoUtilizacao tipoAnterior = this.tipoUtilizacaoSelecionado;

            this.passoAtual = novoPasso;
            this.tipoUtilizacaoSelecionado = tipoSelecionado;

            try
            {
                switch (novoPasso)
                {
                    case passoTela.SelecaoItem:

                        this.spcBuscas.Visible = true;
                        this.spcEstoque.Visible = false;
                        this.btnAlterar.Visible = true;
                        this.btnAlterar.Text = "Selecionar";
                        this.btnSair.Text = "Fechar";
                        //this.txtBusca.Text = "";
                        this.lblSelecionado.Visible = false;
                        this.lblSelecionadoTitulo.Visible = false;

                        switch (tipoSelecionado)
                        {
                            case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                                this.dgvMaterial.Visible = true;
                                this.dgvProduto.Visible = false;
                                this.dgvRecurso.Visible = false;
                                this.dgvDocumento.Visible = false;
                                this.dgvProdutoK.Visible = false;
                                this.dgvEpi.Visible = false;
                                this.initializeGridMaterial(this.txtBusca.Text.Trim());
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                                this.dgvMaterial.Visible = false;
                                this.dgvProduto.Visible = true;
                                this.dgvRecurso.Visible = false;
                                this.dgvDocumento.Visible = false;
                                this.dgvProdutoK.Visible = false;
                                this.dgvEpi.Visible = false;
                                this.initializeGridProduto(this.txtBusca.Text.Trim());
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                                this.dgvMaterial.Visible = false;
                                this.dgvProduto.Visible = false;
                                this.dgvRecurso.Visible = true;
                                this.dgvDocumento.Visible = false;
                                this.dgvProdutoK.Visible = false;
                                this.dgvEpi.Visible = false;
                                this.initializeGridRecurso(this.txtBusca.Text.Trim());

                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                                this.dgvMaterial.Visible = false;
                                this.dgvProduto.Visible = false;
                                this.dgvRecurso.Visible = false;
                                this.dgvDocumento.Visible = true;
                                this.dgvProdutoK.Visible = false;
                                this.dgvEpi.Visible = false;
                                this.initializeGridDocumento(this.txtBusca.Text.Trim());
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                                this.dgvMaterial.Visible = false;
                                this.dgvProduto.Visible = false;
                                this.dgvRecurso.Visible = false;
                                this.dgvDocumento.Visible = false;
                                this.dgvProdutoK.Visible = true;
                                this.dgvEpi.Visible = false;
                                this.initializeGridProdutoK(this.txtBusca.Text.Trim());
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                                this.dgvMaterial.Visible = false;
                                this.dgvProduto.Visible = false;
                                this.dgvRecurso.Visible = false;
                                this.dgvDocumento.Visible = false;
                                this.dgvProdutoK.Visible = false;
                                this.dgvEpi.Visible = true;
                                this.initializeGridEpi(this.txtBusca.Text.Trim());
                                break;
                        }

                        break;
                    case passoTela.VisualizacaoEstoque:
                        this.lblSelecionado.Visible = true;
                        this.lblSelecionadoTitulo.Visible = true;
                        this.carregaSelecionado();

                        this.btnAlterar.Visible = true;
                        this.btnAlterar.Text = "Alterar";
                        this.btnSair.Text = "Voltar";
                        this.spcBuscas.Visible = false;
                        this.spcEstoque.Visible = true;
                        this.dgvEstoquesLocalizados.Visible = true;
                        this.dgvEstoquesLocalizados.Enabled = true;
                        this.nudQuantidade.Enabled = false;
                        this.nudQuantidade.Value = 0;
                        this.txtJustificativa.Enabled = false;
                        this.txtJustificativa.Text = "";
                        //this.txtBusca.Text = "";
                        this.initializeGridEstoque();
                        break;

                    case passoTela.AlteracaoEstoque:
                        this.lblSelecionado.Visible = true;
                        this.lblSelecionadoTitulo.Visible = true;
                        this.carregaSelecionado();

                        this.btnAlterar.Visible = true;
                        this.btnAlterar.Text = "Salvar";
                        this.btnSair.Text = "Voltar";
                        this.spcBuscas.Visible = false;
                        this.spcEstoque.Visible = true;
                        this.dgvEstoquesLocalizados.Visible = true;
                        this.dgvEstoquesLocalizados.Enabled = false;
                        this.nudQuantidade.Enabled = true;
                        this.nudQuantidade.Value = Convert.ToDecimal(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["egi_quantidade"].Value);

                        if (tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento)
                        {
                            this.nudQuantidade.Maximum = 999999999;
                        }
                        else
                        {
                            this.nudQuantidade.Maximum = 1;
                            
                        }
                        this.txtJustificativa.Enabled = true;
                        this.txtJustificativa.Text = "";
                        break;
                    default:
                        throw new Exception("Passo Inválido");
                }

            }
            catch (Exception e)
            {
                this.passoAtual = passoAnterior;
                this.tipoUtilizacaoSelecionado = tipoAnterior;
                throw new Exception("Erro ao configurar a tela.\r\n" + e.Message);
            }

        }

        private void carregaSelecionado()
        {
            try
            {
                DataGridViewRow row;
                switch (tipoUtilizacaoSelecionado)
                {
                    case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                        row = this.dgvDocumento.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["fad_codigo"].Value + " " + row.Cells["dot_identificacao"].Value + " " + row.Cells["dot_revisao_atual"].Value + " - " + row.Cells["doc_identificacao"].Value;
                        this.lblUnidadeMedida.Text = "";
                        break;

                    case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                        row = this.dgvMaterial.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["agm_identificacao"].Value + " " + row.Cells["fam_codigo"].Value + " " + row.Cells["mat_codigo"].Value;
                        this.lblUnidadeMedida.Text = row.Cells["unm_abreviada"].Value.ToString();
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                        row = this.dgvProduto.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["pro_codigo"].Value.ToString();
                        this.lblUnidadeMedida.Text = row.Cells["unm_abreviada"].Value.ToString();
                        break;

                    case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                        row = this.dgvProdutoK.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["prk_codigo"].Value.ToString() + " " + row.Cells["prk_dimensao"].Value.ToString();
                        this.lblUnidadeMedida.Text = "";
                        break;

                    case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                        row = this.dgvRecurso.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["far_identificacao"].Value + " " + row.Cells["rec_codigo"].Value + " " + row.Cells["rec_nome"].Value;
                        this.lblUnidadeMedida.Text = "";
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                        row = this.dgvEpi.SelectedRows[0];
                        this.lblSelecionado.Text = row.Cells["epi_identificacao"].Value.ToString();
                        this.lblUnidadeMedida.Text = row.Cells["unm_abreviada"].Value.ToString();
                        break;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o item selecionado.\r\n" + e.Message);
            }
        }

        private void loadListsItensComGaveta()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                #region Produtos
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_produto " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_produto IS NOT NULL ";

                
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

               produtosComGaveta = new List<int>();

                while (read.Read())
                {
                    produtosComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion

                #region Produtos K
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_produto_k " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_produto_k IS NOT NULL ";


                read = command.ExecuteReader();

                produtosKComGaveta = new List<int>();

                while (read.Read())
                {
                    produtosKComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion

                #region Material
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_material " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_material IS NOT NULL ";


                read = command.ExecuteReader();

                materiaisComGaveta = new List<int>();

                while (read.Read())
                {
                    materiaisComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion

                #region Recursos
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_recurso " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_recurso IS NOT NULL ";


                read = command.ExecuteReader();

                recursosComGaveta = new List<int>();

                while (read.Read())
                {
                    recursosComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion

                #region Documentos
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_documento_copia " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_documento_copia IS NOT NULL ";


                read = command.ExecuteReader();

                documentosComGaveta = new List<int>();

                while (read.Read())
                {
                    documentosComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion

                #region Epi
                command.CommandText =
                             "SELECT DISTINCT  " +
                             "  public.estoque_gaveta_item.id_epi " +
                             "FROM " +
                             "  public.estoque_gaveta_item " +
                             "WHERE " +
                             "  public.estoque_gaveta_item.egi_ativo = 1 AND " +
                             "  public.estoque_gaveta_item.id_epi IS NOT NULL ";


                read = command.ExecuteReader();

                epiComGaveta = new List<int>();

                while (read.Read())
                {
                    epiComGaveta.Add(Convert.ToInt32(read[0]));
                }

                read.Close();
                #endregion
            
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar os itens com gaveta\r\n" + e.Message, e);
            }
        }

        private void initializeGridDocumento(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvDocumento.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvDocumento.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvDocumento.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvDocumento.SelectedRows[0].Index;
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
                if (this.dgvDocumento.SortedColumn != null)
                {
                    sortedColumName = this.dgvDocumento.SortedColumn.Name;
                    sortedMode = this.dgvDocumento.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( "+
                         " UPPER(fad_codigo) LIKE '%" + busca.ToUpper() + "%' "+
                         " OR UPPER(dot_identificacao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(dot_revisao_atual) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(doc_identificacao) LIKE '%" + busca.ToUpper() + "%' " +

                         " OR LOWER(fad_codigo) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(dot_identificacao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(dot_revisao_atual) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(doc_identificacao) LIKE '%" + busca.ToLower() + "%' " +

                         //" OR CAST(documento_copia.id_documento_copia AS VARCHAR) LIKE '%" + busca + "%' " +
                    " ) ";
                }


                string sql =
                    "SELECT  " +
                    "  public.documento_copia.id_documento_copia, " +
                    "  public.familia_documento.fad_codigo, " +
                    "  public.documento_tipo.dot_identificacao, " +
                    "  public.documento_tipo.dot_revisao_atual, " +
                    "  public.documento_copia.doc_identificacao, " +
                    "  public.documento_copia.doc_ativa, " +
                    "  public.documento_copia.doc_ocupada, " +
                    "  iwt_agregate_gavetas_estoque( "+
                    "	  public.estoque.est_identificacao||' > '|| "+
                    "	  public.estoque_corredor.esc_identificacao||' > '|| "+
                    "	  public.estoque_prateleira.esp_identificacao||' > '|| " +
                    "	  public.estoque_gaveta.esg_identificacao "+
                    "  ) AS localestoque "+
                    "FROM " +
                    "  public.documento_tipo " +
                    "  INNER JOIN public.documento_tipo_familia ON (public.documento_tipo.id_documento_tipo = public.documento_tipo_familia.id_documento_tipo) " +
                    "  INNER JOIN public.familia_documento ON (public.documento_tipo_familia.id_familia_documento = public.familia_documento.id_familia_documento) " +
                    "  INNER JOIN public.documento_copia ON (public.documento_tipo_familia.id_documento_tipo_familia = public.documento_copia.id_documento_tipo_familia) " +
                    "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.documento_copia.id_documento_copia = estoque_item.id_documento_copia) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) "+
                    "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) "+
                    "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) "+
                    "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) "+
                    "WHERE "+
                    "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) "+
                    " "+whereClause+" "+
                    "GROUP BY "+
                    "  public.documento_copia.id_documento_copia, " +
                    "  public.familia_documento.fad_codigo, " +
                    "  public.documento_tipo.dot_identificacao, " +
                    "  public.documento_tipo.dot_revisao_atual, " +
                    "  public.documento_copia.doc_identificacao, " +
                    "  public.documento_copia.doc_ativa, " +
                    "  public.documento_copia.doc_ocupada " +
                    "ORDER BY " +
                    "  public.familia_documento.fad_codigo, " +
                    "  public.documento_tipo.dot_identificacao, " +
                    "  public.documento_tipo.dot_revisao_atual, " +
                    "  public.documento_copia.doc_identificacao ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvDocumento.AutoGenerateColumns = true;
                    dgvDocumento.DataSource = binding;

                    dgvDocumento.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvDocumento.MultiSelect = true;

                    this.dgvDocumento.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[1], "Familia", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[2], "Documento", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[3], "Revisão", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[4], "Cópia", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[5], "Ativa", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[6], "Ocupada", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvDocumento.Columns[7], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);


                    DataGridViewColumn column = dgvDocumento.Columns["doc_ativa"];
                    DataGridViewCheckBoxColumn tmp = null;

                    tmp = new DataGridViewCheckBoxColumn();
                    tmp.FalseValue = "0";
                    tmp.TrueValue = "1";
                    tmp.DataPropertyName = column.DataPropertyName;
                    tmp.DisplayIndex = column.DisplayIndex;
                    tmp.ReadOnly = column.ReadOnly;
                    tmp.AutoSizeMode = column.AutoSizeMode;
                    tmp.Width = column.Width;
                    tmp.Name = column.Name;
                    tmp.HeaderText = column.HeaderText;
                    dgvDocumento.Columns.Remove(tmp.Name);
                    dgvDocumento.Columns.Add(tmp);

                    column = dgvDocumento.Columns["doc_ocupada"];
                    tmp = null;

                    tmp = new DataGridViewCheckBoxColumn();
                    tmp.FalseValue = "0";
                    tmp.TrueValue = "1";
                    tmp.DataPropertyName = column.DataPropertyName;
                    tmp.DisplayIndex = column.DisplayIndex;
                    tmp.ReadOnly = column.ReadOnly;
                    tmp.AutoSizeMode = column.AutoSizeMode;
                    tmp.Width = column.Width;
                    tmp.Name = column.Name;
                    tmp.HeaderText = column.HeaderText;
                    dgvDocumento.Columns.Remove(tmp.Name);
                    dgvDocumento.Columns.Add(tmp);
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
                for (int i = 0; i < this.dgvDocumento.SelectedRows.Count; i++)
                {
                    this.dgvDocumento.SelectedRows[i].Selected = false;
                }
                if (this.dgvDocumento.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvDocumento.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvDocumento.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvDocumento.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvDocumento.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de documentos.\r\n" + e.Message);
            }
        }

        private void initializeGridRecurso(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.Recurso)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvRecurso.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvRecurso.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvRecurso.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvRecurso.SelectedRows[0].Index;
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
                if (this.dgvRecurso.SortedColumn != null)
                {
                    sortedColumName = this.dgvRecurso.SortedColumn.Name;
                    sortedMode = this.dgvRecurso.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( " +
                        " UPPER(far_identificacao) LIKE '%" + busca.ToUpper() + "%' " +
                        " OR UPPER(pos_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                        " OR UPPER(rec_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                        " OR UPPER(rec_nome) LIKE '%" + busca.ToUpper() + "%' " +

                        " OR LOWER(far_identificacao) LIKE '%" + busca.ToLower() + "%' " +
                        " OR LOWER(pos_codigo) LIKE '%" + busca.ToLower() + "%' " +
                        " OR LOWER(rec_codigo) LIKE '%" + busca.ToLower() + "%' " +
                        " OR LOWER(rec_nome) LIKE '%" + busca.ToLower() + "%' " +

                        //" OR CAST(recurso.id_recurso AS VARCHAR) LIKE '%" + busca + "%' " +
                   " ) ";
                }


                string sql =
                    "SELECT  " +
                    "  public.recurso.id_recurso, "+
                    "  public.familia_recurso.far_identificacao, "+
                    "  public.posto_trabalho.pos_codigo, "+
                    "  public.recurso.rec_codigo, "+
                    "  public.recurso.rec_nome, "+
                    "  SUM(egi_quantidade) as qtdEstoque, "+
                    "  iwt_agregate_gavetas_estoque( "+
                    "	  public.estoque.est_identificacao||' > '|| "+
                    "	  public.estoque_corredor.esc_identificacao||' > '|| "+
                    "	  public.estoque_prateleira.esp_identificacao||' > '|| " +
                    "	  public.estoque_gaveta.esg_identificacao "+
                    "  ) AS localestoque "+
                    "FROM "+
                    "  public.familia_recurso "+
                    "  INNER JOIN public.recurso ON (public.familia_recurso.id_familia_recurso = public.recurso.id_familia_recurso) "+
                    "  INNER JOIN public.posto_trabalho ON (public.recurso.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) "+
                    "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.recurso.id_recurso = estoque_item.id_recurso) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) "+
                    "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) "+
                    "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) "+
                    "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) "+
                    "WHERE "+
                    "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) "+
                    " "+whereClause+" "+
                    "GROUP BY "+
                    "  public.recurso.id_recurso, "+
                    "  public.familia_recurso.far_identificacao, "+
                    "  public.posto_trabalho.pos_codigo, "+
                    "  public.recurso.rec_codigo, "+
                    "  public.recurso.rec_nome "+
                    "ORDER BY "+
                    "  public.familia_recurso.far_identificacao, "+
                    "  public.posto_trabalho.pos_codigo, "+
                    "  public.recurso.rec_codigo ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvRecurso.AutoGenerateColumns = true;
                    dgvRecurso.DataSource = binding;

                    dgvRecurso.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvRecurso.MultiSelect = true;

                    this.dgvRecurso.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[1], "Família", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[2], "Posto", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[3], "Identificação", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[4], "Descrição", 200, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[5], "Estoque Total", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvRecurso.Columns[6], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);


                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();




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
                for (int i = 0; i < this.dgvRecurso.SelectedRows.Count; i++)
                {
                    this.dgvRecurso.SelectedRows[i].Selected = false;
                }
                if (this.dgvRecurso.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvRecurso.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvRecurso.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvRecurso.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvRecurso.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de recursos.\r\n" + e.Message);
            }
        }

        private void initializeGridProduto(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.Produto)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvProduto.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvProduto.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvProduto.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvProduto.SelectedRows[0].Index;
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
                if (this.dgvProduto.SortedColumn != null)
                {
                    sortedColumName = this.dgvProduto.SortedColumn.Name;
                    sortedMode = this.dgvProduto.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( " +
                         " UPPER(pro_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(pro_descricao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(clp_descricao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(pro_codigo_cliente) LIKE '%" + busca.ToUpper() + "%' " +

                         " OR LOWER(pro_codigo) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(pro_descricao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(clp_descricao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(pro_codigo_cliente) LIKE '%" + busca.ToLower() + "%' " +

                         //" OR CAST(produto.id_produto AS VARCHAR) LIKE '%" + busca + "%' " +
                    " ) ";
                }


                string sql =
                "SELECT  " +
                "  public.produto.id_produto, " +
                "  public.produto.pro_codigo, " +
                "  public.produto.pro_codigo_cliente, " +
                "  public.produto.pro_descricao, " +
                "  public.classificacao_produto.clp_descricao, " +
                "  public.unidade_medida.unm_abreviada, " +
                "  SUM(egi_quantidade) as qtdEstoque, "+
                "  iwt_agregate_gavetas_estoque( "+
                "	  public.estoque.est_identificacao||' > '|| "+
                "	  public.estoque_corredor.esc_identificacao||' > '|| "+
                "	  public.estoque_prateleira.esp_identificacao||' > '|| " +
                "	  public.estoque_gaveta.esg_identificacao "+
                "  ) AS localestoque "+
                "FROM " +
                "  public.produto " +
                "  LEFT JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                "  LEFT JOIN public.unidade_medida ON public.unidade_medida.id_unidade_medida = public.produto.id_unidade_medida " +
                "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.produto.id_produto = estoque_item.id_produto) " +
                "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) "+
                "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) "+
                "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) "+
                "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) "+
                "WHERE "+
                "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) "+
                " "+whereClause+" "+
                "GROUP BY "+
                "  public.produto.id_produto, " +
                "  public.produto.pro_codigo, " +
                "  public.produto.pro_codigo_cliente, " +
                "  public.produto.pro_descricao, " +
                "  public.classificacao_produto.clp_descricao, " +
                "  public.unidade_medida.unm_abreviada " +
                "ORDER BY " +
                "  public.produto.pro_codigo, " +
                "  public.produto.pro_descricao, " +
                "  public.classificacao_produto.clp_descricao ";


             

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                binding = new BindingSource {DataSource = ds.Tables[0], Filter = atualFilter};
                dgvProduto.AutoGenerateColumns = true;
                dgvProduto.DataSource = binding;

                dgvProduto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProduto.MultiSelect = true;

                this.dgvProduto.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[1], "Código Interno", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[2], "Código Cliente", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[3], "Descrição", 250, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[4], "Classificação", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[5], "Unidade", 60, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[6], "Estoque Total", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProduto.Columns[7], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);






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
                for (int i = 0; i < this.dgvProduto.SelectedRows.Count; i++)
                {
                    this.dgvProduto.SelectedRows[i].Selected = false;
                }
                if (this.dgvProduto.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvProduto.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvProduto.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvProduto.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvProduto.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de itens.\r\n" + e.Message);
            }
        }

        private void initializeGridMaterial(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.Material)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvMaterial.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvMaterial.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvMaterial.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvMaterial.SelectedRows[0].Index;
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
                if (this.dgvMaterial.SortedColumn != null)
                {
                    sortedColumName = this.dgvMaterial.SortedColumn.Name;
                    sortedMode = this.dgvMaterial.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( " +
                         " UPPER(agm_identificacao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(fam_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(mat_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(mat_descricao) LIKE '%" + busca.ToUpper() + "%' " +

                         " OR LOWER(agm_identificacao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(fam_codigo) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(mat_codigo) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(mat_descricao) LIKE '%" + busca.ToLower() + "%' " +

                         " OR CAST(material.id_material AS VARCHAR) LIKE '%" + busca + "%' " +
                    " ) ";
                }


                string sql =
                "SELECT  "+
                "  public.material.id_material, "+
                "  public.agrupador_material.agm_identificacao, "+
                "  public.familia_material.fam_codigo, "+
                "  public.material.mat_codigo, "+
                "  public.material.mat_descricao, "+
                "  public.material.mat_medida, "+
                "  public.material.mat_medida_largura, "+
                "  public.material.mat_medida_comprimento, "+
                "  public.unidade_medida.unm_abreviada, "+
                "  SUM(egi_quantidade) as qtdEstoque, "+
                "  iwt_agregate_gavetas_estoque( "+
                "	  public.estoque.est_identificacao||' > '|| "+
                "	  public.estoque_corredor.esc_identificacao||' > '|| "+
                "	  public.estoque_prateleira.esp_identificacao||' > '|| " +
                "	  public.estoque_gaveta.esg_identificacao "+
                "  ) AS localestoque "+
                "FROM "+
                "  public.agrupador_material "+
                "  INNER JOIN public.familia_material ON (public.agrupador_material.id_agrupador_material = public.familia_material.id_agrupador_material) "+
                "  INNER JOIN public.material ON (public.familia_material.id_familia_material = public.material.id_familia_material) "+
                "  LEFT OUTER JOIN public.unidade_medida ON (public.unidade_medida.id_unidade_medida = public.material.id_unidade_medida) "+
                "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.material.id_material = estoque_item.id_material)  " +
                "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) "+
                "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) "+
                "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) "+
                "WHERE "+
                "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) " +
                " "+whereClause+" "+
                "GROUP BY "+
                "  public.material.id_material, "+
                "  public.agrupador_material.agm_identificacao, "+
                "  public.familia_material.fam_codigo, "+
                "  public.material.mat_codigo, "+
                "  public.material.mat_descricao, "+
                "  public.material.mat_medida, "+
                "  public.material.mat_medida_largura, "+
                "  public.material.mat_medida_comprimento, "+
                "  public.unidade_medida.unm_abreviada "+
                "ORDER BY "+
                "  public.agrupador_material.agm_identificacao, "+
                "  public.familia_material.fam_codigo, "+
                "  public.material.mat_codigo, "+
                "  public.material.mat_medida, "+
                "  public.material.mat_descricao ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvMaterial.AutoGenerateColumns = true;
                    dgvMaterial.DataSource = binding;

                    dgvMaterial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvMaterial.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[0], "ID", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[1], "Agrupador", 150, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[2], "Família", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[3], "Identificação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[4], "Descrição", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[5], "Medida 1", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[6], "Medida 2", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[7], "Medida 3", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[8], "Unidade", 60, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[9], "Estoque Total", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvMaterial.Columns[10], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);






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
                for (int i = 0; i < this.dgvMaterial.SelectedRows.Count; i++)
                {
                    this.dgvMaterial.SelectedRows[i].Selected = false;
                }
                if (this.dgvMaterial.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvMaterial.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvMaterial.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvMaterial.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvMaterial.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de materiais.\r\n" + e.Message);
            }
        }

        private void initializeGridProdutoK(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvProduto.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvProduto.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvProduto.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvProduto.SelectedRows[0].Index;
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
                if (this.dgvProduto.SortedColumn != null)
                {
                    sortedColumName = this.dgvProduto.SortedColumn.Name;
                    sortedMode = this.dgvProduto.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( " +
                         " UPPER(prk_codigo) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(prk_dimensao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(clp_descricao) LIKE '%" + busca.ToUpper() + "%' " +
                         " OR UPPER(clp_identificacao) LIKE '%" + busca.ToUpper() + "%' " +

                         " OR LOWER(prk_codigo) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(prk_dimensao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(clp_descricao) LIKE '%" + busca.ToLower() + "%' " +
                         " OR LOWER(clp_identificacao) LIKE '%" + busca.ToLower() + "%' " +

                        // " OR CAST(produto_k.id_produto_k AS VARCHAR) LIKE '%" + busca + "%' " +
                    " ) ";
                }


                string sql =
                    "SELECT  " +
                    "  public.produto_k.id_produto_k, " +
                    "  public.produto_k.prk_codigo, " +
                    "  public.produto_k.prk_dimensao, " +
                    "  public.classificacao_produto.clp_identificacao, " +
                    "  public.classificacao_produto.clp_descricao, " +
                    "  SUM(egi_quantidade) AS qtdestoque, " +
                    "  iwt_agregate_gavetas_estoque(public.estoque.est_identificacao||' > ' || public.estoque_corredor.esc_identificacao||' > ' || public.estoque_prateleira.esp_identificacao||' > ' || public.estoque_gaveta.esg_identificacao) AS localestoque " +
                    "FROM " +
                    "  public.produto_k " +
                    "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto_k.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) " +
                    "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.produto_k.id_produto_k = estoque_item.id_produto_k) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                    "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                    "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                    "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                    "WHERE " +
                    "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) " +
                    " " + whereClause + " " +
                    "GROUP BY " +
                    "  public.produto_k.id_produto_k, " +
                    "  public.produto_k.prk_codigo, " +
                    "  public.produto_k.prk_dimensao, " +
                    "  public.classificacao_produto.clp_identificacao, " +
                    "  public.classificacao_produto.clp_descricao " +
                    "ORDER BY " +
                    "  public.produto_k.prk_codigo, " +
                    "  public.produto_k.prk_dimensao";




                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);

                DataSet ds = new DataSet();
                adapter.Fill(ds);

                binding = new BindingSource { DataSource = ds.Tables[0], Filter = atualFilter };
                dgvProdutoK.AutoGenerateColumns = true;
                dgvProdutoK.DataSource = binding;

                dgvProdutoK.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvProdutoK.MultiSelect = true;

                this.dgvProdutoK.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[1], "Código", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[2], "Dimensão", 150, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[3], "Classificação", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[4], "Classificação - Descrição", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[5], "Estoque Total", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dgvProdutoK.Columns[6], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);






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
                for (int i = 0; i < this.dgvProduto.SelectedRows.Count; i++)
                {
                    this.dgvProduto.SelectedRows[i].Selected = false;
                }
                if (this.dgvProduto.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvProduto.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvProduto.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvProduto.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvProduto.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de itens.\r\n" + e.Message);
            }
        }

        private void initializeGridEpi(string busca)
        {
            try
            {
                if (passoAtual != passoTela.SelecaoItem && tipoUtilizacaoSelecionado != EnviaItemEstoqueForm.tipoUtilizacao.Epi)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvEpi.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvEpi.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvEpi.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvEpi.SelectedRows[0].Index;
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
                if (this.dgvEpi.SortedColumn != null)
                {
                    sortedColumName = this.dgvEpi.SortedColumn.Name;
                    sortedMode = this.dgvEpi.SortOrder;
                }

                #endregion

                string whereClause = "";
                if (busca.Length > 0)
                {
                    whereClause = " AND ( " +
                          " UPPER(epi_identificacao) LIKE '%" + busca.ToUpper() + "%' " +
                            " OR UPPER(epi_descricao) LIKE '%" + busca.ToUpper() + "%' " +
                            " OR UPPER(epi_descricao_adicional) LIKE '%" + busca.ToUpper() + "%' " +
                            " OR LOWER(epi_identificacao) LIKE '%" + busca.ToLower() + "%' " +
                            " OR LOWER(epi_descricao) LIKE '%" + busca.ToLower() + "%' " +
                            " OR LOWER(epi_descricao_adicional) LIKE '%" + busca.ToLower() + "%' " +

                            " OR CAST(epi.id_epi AS VARCHAR) LIKE '%" + busca + "%' " +
                            " ) ";
                }


                string sql =
                    "SELECT  " +
                    "  public.epi.id_epi, " +
                    "  public.epi.epi_identificacao, " +
                    "  public.epi.epi_descricao, " +
                    "  public.unidade_medida.unm_abreviada, " +
                    "  SUM(egi_quantidade) as qtdEstoque, " +
                    "  iwt_agregate_gavetas_estoque( " +
                    "	  public.estoque.est_identificacao||' > '|| " +
                    "	  public.estoque_corredor.esc_identificacao||' > '|| " +
                    "	  public.estoque_prateleira.esp_identificacao||' > '|| " +
                    "	  public.estoque_gaveta.esg_identificacao " +
                    "  ) AS localestoque " +
                    "FROM " +
                    "  public.epi " +
                    "  JOIN public.unidade_medida ON (public.epi.id_unidade_medida_uso = public.unidade_medida.id_unidade_medida) " +
                    "  LEFT OUTER JOIN (SELECT * FROM public.estoque_gaveta_item WHERE egi_ativo = 1) as estoque_item ON (public.epi.id_epi = estoque_item.id_epi) " +
                    "  LEFT OUTER JOIN public.estoque_gaveta ON (estoque_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                    "  LEFT OUTER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                    "  LEFT OUTER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                    "  LEFT OUTER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                    "WHERE " +
                    "  (estoque_item.egi_ativo = 1 OR estoque_item.id_estoque_gaveta_item IS NULL) " +
                    " " + whereClause + " " +
                    "GROUP BY " +
                    "  public.epi.id_epi, " +
                    "  public.epi.epi_identificacao, " +
                    "  public.epi.epi_descricao, " +
                    "  public.unidade_medida.unm_abreviada " +
                    "ORDER BY " +
                    "  public.epi.id_epi, " +
                    "  public.epi.epi_identificacao, " +
                    "  public.epi.epi_descricao ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvEpi.AutoGenerateColumns = true;
                    dgvEpi.DataSource = binding;

                    dgvEpi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEpi.MultiSelect = true;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[0], "ID", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[1], "Identificação", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[2], "Descrição", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[3], "Unidade", 60, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[4], "Estoque Total", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEpi.Columns[5], "Localizações", 200, DataGridViewAutoSizeColumnMode.None, true);

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
                for (int i = 0; i < this.dgvEpi.SelectedRows.Count; i++)
                {
                    this.dgvEpi.SelectedRows[i].Selected = false;
                }
                if (this.dgvEpi.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvEpi.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvEpi.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvEpi.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvEpi.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a listagem de Epis.\r\n" + e.Message);
            }
        }

        private void carregaQuantidadeTotalEstoque()
        {
            try
            {
                double qtd = 0;
                foreach (DataGridViewRow row in dgvEstoquesLocalizados.Rows)
                {
                    qtd += Convert.ToDouble(row.Cells["egi_quantidade"].Value);
                }

                this.lblQtdTotal.Text = qtd.ToString("F4", CultureInfo.CurrentCulture);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular o total do estoque.\r\n" + e.Message);
            }
        }

        private void initializeGridEstoque()
        {
            try
            {
                if (passoAtual != passoTela.VisualizacaoEstoque)
                {
                    return;
                }

                BindingSource binding = null;
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dgvEstoquesLocalizados.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dgvEstoquesLocalizados.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dgvEstoquesLocalizados.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dgvEstoquesLocalizados.SelectedRows[0].Index;
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
                if (this.dgvEstoquesLocalizados.SortedColumn != null)
                {
                    sortedColumName = this.dgvEstoquesLocalizados.SortedColumn.Name;
                    sortedMode = this.dgvEstoquesLocalizados.SortOrder;
                }

                #endregion

                string sql =
                "SELECT  " +
                "  public.estoque_gaveta_item.id_estoque_gaveta_item, " +
                "  public.estoque.est_identificacao, " +
                "  public.estoque_corredor.esc_identificacao, " +
                "  public.estoque_prateleira.esp_identificacao, " +
                "  public.estoque_gaveta.esg_identificacao, " +
                "  public.estoque_gaveta_item.egi_quantidade " +
                "FROM " +
                "  public.estoque_gaveta_item " +
                "  INNER JOIN public.estoque_gaveta ON (public.estoque_gaveta_item.id_estoque_gaveta = public.estoque_gaveta.id_estoque_gaveta) " +
                "  INNER JOIN public.estoque_prateleira ON (public.estoque_gaveta.id_estoque_prateleira = public.estoque_prateleira.id_estoque_prateleira) " +
                "  INNER JOIN public.estoque_corredor ON (public.estoque_prateleira.id_estoque_corredor = public.estoque_corredor.id_estoque_corredor) " +
                "  INNER JOIN public.estoque ON (public.estoque_corredor.id_estoque = public.estoque.id_estoque) " +
                "WHERE " +
                "  egi_ativo = 1 AND ";

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.Produto)
                {
                    sql += "  public.estoque_gaveta_item.id_produto = " + dgvProduto.SelectedRows[0].Cells["id_produto"].Value + " ";
                }

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.Material)
                {
                    sql += "  public.estoque_gaveta_item.id_material = " + dgvMaterial.SelectedRows[0].Cells["id_material"].Value + " ";
                }

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento)
                {
                    sql += "  public.estoque_gaveta_item.id_documento_copia = " + dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value + " ";
                }

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.Recurso)
                {
                    sql += "  public.estoque_gaveta_item.id_recurso = " + dgvRecurso.SelectedRows[0].Cells["id_recurso"].Value + " ";
                }

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK)
                {
                    sql += "  public.estoque_gaveta_item.id_produto_k = " + dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value + " ";
                }

                if (this.tipoUtilizacaoSelecionado == EnviaItemEstoqueForm.tipoUtilizacao.Epi)
                {
                    sql += "  public.estoque_gaveta_item.id_epi = " + dgvEpi.SelectedRows[0].Cells["id_epi"].Value + " ";
                }

                sql +=
                    "ORDER BY " +
                    "  public.estoque.est_identificacao, " +
                    "  public.estoque_corredor.esc_identificacao, " +
                    "  public.estoque_prateleira.esp_identificacao, " +
                    "  public.estoque_gaveta.esg_identificacao, " +
                    "  public.estoque_gaveta_item.egi_quantidade ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dgvEstoquesLocalizados.AutoGenerateColumns = true;
                    dgvEstoquesLocalizados.DataSource = binding;

                    dgvEstoquesLocalizados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvEstoquesLocalizados.MultiSelect = false;

                    this.dgvEstoquesLocalizados.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoquesLocalizados.Columns[1], "Estoque", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoquesLocalizados.Columns[2], "Corredor", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoquesLocalizados.Columns[3], "Prateleira", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoquesLocalizados.Columns[4], "Gaveta", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dgvEstoquesLocalizados.Columns[5], "Quantidade", 80, DataGridViewAutoSizeColumnMode.None, true);


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
                for (int i = 0; i < this.dgvEstoquesLocalizados.SelectedRows.Count; i++)
                {
                    this.dgvEstoquesLocalizados.SelectedRows[i].Selected = false;
                }
                if (this.dgvEstoquesLocalizados.Rows.Count > 0)
                {
                    while (selectRowIndex > 0 && selectRowIndex >= this.dgvEstoquesLocalizados.Rows.Count)
                    {
                        selectRowIndex--;
                    }


                    this.dgvEstoquesLocalizados.Rows[selectRowIndex].Selected = true;

                    while (scrollIndex > 0 && scrollIndex >= this.dgvEstoquesLocalizados.Rows.Count)
                    {
                        scrollIndex--;
                    }

                    this.dgvEstoquesLocalizados.FirstDisplayedScrollingRowIndex = scrollIndex;
                }
                #endregion

                this.carregaQuantidadeTotalEstoque();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar a listagem de estoque.\r\n" + e.Message);
            }
        }

        private void realizaBusca()
        {
            try
            {
                //if (this.txtBusca.Text.Trim().Length == 0)
                //{
                //    return;
                //}

                if (passoAtual != passoTela.SelecaoItem)
                {
                    return;
                }

                switch (tipoUtilizacaoSelecionado)
                {
                    case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                        this.initializeGridDocumento(this.txtBusca.Text.Trim());
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                        this.initializeGridMaterial(this.txtBusca.Text.Trim());
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                        this.initializeGridProduto(this.txtBusca.Text.Trim());
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                        this.initializeGridRecurso(this.txtBusca.Text.Trim());
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                        this.initializeGridProdutoK(this.txtBusca.Text.Trim());
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                        this.initializeGridEpi(this.txtBusca.Text.Trim());
                        break;
                    default:
                        throw new Exception("Tipo inválido");
                }



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }
        }

        private void Operacao()
        {
            try
            {
                switch (this.passoAtual)
                {
                    case passoTela.SelecaoItem:
                        switch (tipoUtilizacaoSelecionado)
                        {
                            case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                                if (this.dgvMaterial.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.Material);
                                }
                                else
                                {
                                    throw new Exception("Selecione um material antes de continuar");
                                }
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                                if (this.dgvProduto.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.Produto);
                                }
                                else
                                {
                                    throw new Exception("Selecione um produto antes de continuar");
                                }
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                                if (this.dgvRecurso.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.Recurso);
                                }
                                else
                                {
                                    throw new Exception("Selecione um recurso antes de continuar");
                                }
                                break;

                            case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                                if (this.dgvDocumento.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento);
                                }
                                else
                                {
                                    throw new Exception("Selecione uma cópia de documento antes de continuar");
                                }
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                                if (this.dgvProdutoK.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK);
                                }
                                else
                                {
                                    throw new Exception("Selecione um Agrupador antes de continuar");
                                }
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                                if (this.dgvEpi.SelectedRows.Count > 0)
                                {
                                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, EnviaItemEstoqueForm.tipoUtilizacao.Epi);
                                }
                                else
                                {
                                    throw new Exception("Selecione um Epi antes de continuar");
                                }
                                break;
                        }
                        break;
                    case passoTela.VisualizacaoEstoque:
                        if (this.dgvEstoquesLocalizados.SelectedRows.Count > 0)
                        {
                            this.ConfiguraTela(passoTela.AlteracaoEstoque, this.tipoUtilizacaoSelecionado);
                        }
                        else
                        {
                            throw new Exception("Selecione uma gaveta antes de continuar");
                        }
                        break;
                    case passoTela.AlteracaoEstoque:
                        if (this.txtJustificativa.Text.Trim().Length < 5)
                        {
                            throw new Exception("O campo de justificativa é obrigatório e deve conter ao menos 5 caracteres.");
                        }

                        if (Convert.ToDouble(this.nudQuantidade.Value) < 0)
                        {
                            throw new Exception("A nova quantidade deve ser maior ou igual a zero.");
                        }

                        int idGavetaItem = Convert.ToInt32(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["id_estoque_gaveta_item"].Value);
                        EstoqueGavetaItemClass gaveta = EstoqueGavetaItemClass.GetEntidade(idGavetaItem, Usuario, conn);



                        double novaQtd = Convert.ToDouble(this.nudQuantidade.Value);

                        if (novaQtd == gaveta.Quantidade)
                        {
                            throw new Exception("A quantidade nova é igual a quantidade anterior.");
                        }

                        double qtdMovimento = novaQtd - gaveta.Quantidade;
                        IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                        switch (tipoUtilizacaoSelecionado)
                        {
                            case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                                EstoqueMovimentacao.LancaMovimentoEstoqueDocumentoCopia(
                                    gaveta.EstoqueGaveta,
                                    DocumentoCopiaClass.GetEntidade(Convert.ToInt32(this.dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                                EstoqueMovimentacao.LancaMovimentoEstoqueMaterial(
                                    gaveta.EstoqueGaveta,
                                    MaterialClass.GetEntidade(Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["id_material"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                                EstoqueMovimentacao.LancaMovimentoEstoqueProduto(
                                    gaveta.EstoqueGaveta,
                                    ProdutoClass.GetEntidade(Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["id_produto"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                                EstoqueMovimentacao.LancaMovimentoEstoqueRecurso(
                                    gaveta.EstoqueGaveta,
                                    RecursoClass.GetEntidade(Convert.ToInt32(this.dgvRecurso.SelectedRows[0].Cells["id_recurso"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                                EstoqueMovimentacao.LancaMovimentoEstoqueProdutoK(
                                    gaveta.EstoqueGaveta,
                                    ProdutoKClass.GetEntidade(Convert.ToInt32(this.dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                            case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                                EstoqueMovimentacao.LancaMovimentoEstoqueEpi(
                                    gaveta.EstoqueGaveta,
                                    EpiClass.GetEntidade(Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["id_epi"].Value), Usuario, conn),
                                    qtdMovimento, this.txtJustificativa.Text.Trim(), "Manual",
                                    this.Usuario, true, ref command);
                                break;
                        }
                        MessageBox.Show(this, "Alteração realizada com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.ConfiguraTela(passoTela.VisualizacaoEstoque, this.tipoUtilizacaoSelecionado);

                        break;

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a operação.\r\n" + e.Message);
            }
        }

        private void Cancelar()
        {

            switch (this.passoAtual)
            {
                case passoTela.SelecaoItem:
                    this.Close();
                    break;
                case passoTela.VisualizacaoEstoque:
                    this.ConfiguraTela(passoTela.SelecaoItem, this.tipoUtilizacaoSelecionado);
                    break;
                case passoTela.AlteracaoEstoque:
                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, this.tipoUtilizacaoSelecionado);
                    break;
            }

        }

        private void novaGaveta()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {

                command = this.conn.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();


                AbstractEntity itemEstoque = null;
                string unidade;
                switch (tipoUtilizacaoSelecionado)
                {
                    case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                        itemEstoque =DocumentoCopiaClass.GetEntidade(Convert.ToInt32(this.dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value),Usuario,conn);
                        unidade = "";
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                        itemEstoque = MaterialClass.GetEntidade(Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["id_material"].Value),Usuario,conn);
                        unidade = this.dgvMaterial.SelectedRows[0].Cells["unm_abreviada"].Value.ToString(); 
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                        itemEstoque = ProdutoClass.GetEntidade(Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["id_produto"].Value),Usuario,conn);
                        unidade = this.dgvProduto.SelectedRows[0].Cells["unm_abreviada"].Value.ToString(); 
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                        itemEstoque = RecursoClass.GetEntidade(Convert.ToInt32(this.dgvRecurso.SelectedRows[0].Cells["id_recurso"].Value),Usuario,conn);
                        unidade = "";
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                        itemEstoque = ProdutoKClass.GetEntidade(Convert.ToInt32(this.dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value),Usuario,conn);
                        unidade = "";
                        break;
                    case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                        itemEstoque = EpiClass.GetEntidade(Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["id_epi"].Value),Usuario,conn);
                        unidade = "";
                        break;
                    default:
                        throw new Exception("Tipo Inválido");
                }


               


                EnviaItemEstoqueForm form = new EnviaItemEstoqueForm(this.tipoUtilizacaoSelecionado, this.lblSelecionado.Text, true, 1,unidade, true, "", itemEstoque, false, null, this.Usuario, this.conn, ref command, "Manual", false);
                form.ShowDialog();

                this.ConfiguraTela(passoTela.VisualizacaoEstoque, this.tipoUtilizacaoSelecionado);
                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                  if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao inserir o item em uma nova gaveta.\r\n" + e.Message);
            }
        }

        private void trocarGaveta()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Essa operação irá mover a quantidade total do item para a nova gaveta que será selecionada. Deseja continuar?", "Mover item", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = this.conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();


                    int id;
                    string unidade;

                    AbstractEntity itemEstoque;
                    switch (tipoUtilizacaoSelecionado)
                    {
                        case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                            itemEstoque = DocumentoCopiaClass.GetEntidade(Convert.ToInt32(this.dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value), Usuario, conn);
                            unidade = "";
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                            itemEstoque = MaterialClass.GetEntidade(Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["id_material"].Value), Usuario, conn);
                            unidade = this.dgvMaterial.SelectedRows[0].Cells["unm_abreviada"].Value.ToString();
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                            itemEstoque = ProdutoClass.GetEntidade(Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["id_produto"].Value), Usuario, conn);
                            unidade = this.dgvProduto.SelectedRows[0].Cells["unm_abreviada"].Value.ToString();
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                            itemEstoque = RecursoClass.GetEntidade(Convert.ToInt32(this.dgvRecurso.SelectedRows[0].Cells["id_recurso"].Value), Usuario, conn);
                            unidade = "";
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                            itemEstoque = ProdutoKClass.GetEntidade(Convert.ToInt32(this.dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value), Usuario, conn);
                            unidade = "";
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                            itemEstoque = EpiClass.GetEntidade(Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["id_epi"].Value), Usuario, conn);
                            unidade = "";
                            break;
                        default:
                            throw new Exception("Tipo Inválido");
                    }

                    if (this.dgvEstoquesLocalizados.SelectedRows.Count == 0)
                    {
                        throw new Exception("Selecione a gaveta de origem antes de continuar");
                    }

                    double qtd = Convert.ToDouble(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["egi_quantidade"].Value);
                    EstoqueGavetaItemClass gavetaOrigem = EstoqueGavetaItemClass.GetEntidade(Convert.ToInt32(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["id_estoque_gaveta_item"].Value), Usuario, conn);



                    EnviaItemEstoqueForm form = new EnviaItemEstoqueForm(this.tipoUtilizacaoSelecionado, this.lblSelecionado.Text, false, qtd, unidade, false, "Movimentação total de estoque - Troca de Gaveta", itemEstoque, true, gavetaOrigem, this.Usuario, this.conn, ref command, "Manual", false);
                    form.ShowDialog();



                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, this.tipoUtilizacaoSelecionado);

                    command.Transaction.Commit();
                }

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao mover o item de gaveta.\r\n" + e.Message, e);
            }
        }

        private void historicoGaveta()
        {
            try
            {
                if (this.dgvEstoquesLocalizados.SelectedRows.Count == 0)
                {
                    throw new Exception("Selecione a gaveta de origem antes de continuar");
                }

                EstoqueGavetaItemClass Gaveta = EstoqueGavetaItemClass.GetEntidade(Convert.ToInt32(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["id_estoque_gaveta_item"].Value), Usuario, conn);
        

                HistoricoMovimentacaoEstoqueForm form = new HistoricoMovimentacaoEstoqueForm(Gaveta);
                form.ShowDialog();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao abrir o histórico de movimentação.\r\n" + e.Message, e);
            }
        }

        private void excluirGaveta()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (MessageBox.Show(this, "Essa operação irá excluir a quantidade total do item da gaveta selecionada. Deseja continuar?", "Excluir item da Gaveta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    command = this.conn.CreateCommand();
                    command.Transaction = command.Connection.BeginTransaction();


                    if (this.dgvEstoquesLocalizados.SelectedRows.Count == 0)
                    {
                        throw new Exception("Selecione a gaveta de origem antes de continuar");
                    }


                    EstoqueGavetaItemClass gavetaOrigem = EstoqueGavetaItemClass.GetEntidade(Convert.ToInt32(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["id_estoque_gaveta_item"].Value), Usuario, conn);




                    switch (tipoUtilizacaoSelecionado)
                    {
                        case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                            DocumentoCopiaClass doc = DocumentoCopiaClass.GetEntidade(Convert.ToInt32(this.dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaDocumentoCopia(gavetaOrigem, doc, this.Usuario, ref command);
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                            MaterialClass material = MaterialClass.GetEntidade(Convert.ToInt32(this.dgvMaterial.SelectedRows[0].Cells["id_material"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaMaterial(gavetaOrigem, material, this.Usuario, ref command);
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                            ProdutoClass produto = ProdutoClass.GetEntidade(Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["id_produto"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaProduto(gavetaOrigem, produto, this.Usuario, ref command);
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                            RecursoClass recurso = RecursoClass.GetEntidade(Convert.ToInt32(this.dgvProduto.SelectedRows[0].Cells["id_recurso"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaRecurso(gavetaOrigem, recurso, this.Usuario, ref command);
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                            ProdutoKClass produtok = ProdutoKClass.GetEntidade(Convert.ToInt32(this.dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaProdutoK(gavetaOrigem, produtok, this.Usuario, ref command);
                            break;
                        case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                            EpiClass epi = EpiClass.GetEntidade(Convert.ToInt32(this.dgvEpi.SelectedRows[0].Cells["id_epi"].Value), Usuario, conn);
                            EstoqueMovimentacao.ExcluiItemGavetaEpi(gavetaOrigem, epi, this.Usuario, ref command);
                            break;
                        default:
                            throw new Exception("Tipo Inválido");
                    }




                    this.ConfiguraTela(passoTela.VisualizacaoEstoque, this.tipoUtilizacaoSelecionado);
                    command.Transaction.Commit();

                }

            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao excluir o item de gaveta.\r\n" + e.Message, e);
            }
        }

        private void HistoricoMovimentacaoCompleto()
        {
            HistoricoMovimentacaoEstoqueForm form;
            switch (tipoUtilizacaoSelecionado)
            {
                case EnviaItemEstoqueForm.tipoUtilizacao.Material:
                    if (dgvMaterial.SelectedRows.Count > 0)
                    {
                        MaterialClass material = MaterialClass.GetEntidade(Convert.ToInt64(dgvMaterial.SelectedRows[0].Cells["id_material"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(material);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o material que deseja para verificar o histórico");
                    }

                    break;
                case EnviaItemEstoqueForm.tipoUtilizacao.Produto:
                    if (dgvProduto.SelectedRows.Count > 0)
                    {
                        ProdutoClass produto = ProdutoClass.GetEntidade(Convert.ToInt64(dgvProduto.SelectedRows[0].Cells["id_produto"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(produto);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o produto que deseja para verificar o histórico");
                    }
                    break;
                case EnviaItemEstoqueForm.tipoUtilizacao.Recurso:
                    if (dgvRecurso.SelectedRows.Count > 0)
                    {
                        RecursoClass recurso = RecursoClass.GetEntidade(Convert.ToInt64(dgvRecurso.SelectedRows[0].Cells["id_recurso"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(recurso);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o recurso que deseja para verificar o histórico");
                    }
                    break;
                case EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento:
                    if (dgvDocumento.SelectedRows.Count > 0)
                    {
                        DocumentoCopiaClass documento = DocumentoCopiaClass.GetEntidade(Convert.ToInt64(dgvDocumento.SelectedRows[0].Cells["id_documento_copia"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(documento);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o documento que deseja para verificar o histórico");
                    }
                    break;
                case EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK:
                    if (dgvProdutoK.SelectedRows.Count > 0)
                    {
                        ProdutoKClass produtoK = ProdutoKClass.GetEntidade(Convert.ToInt64(dgvProdutoK.SelectedRows[0].Cells["id_produto_k"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(produtoK);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o Agrupador que deseja para verificar o histórico");
                    }
                    break;
                case EnviaItemEstoqueForm.tipoUtilizacao.Epi:
                    if (dgvEpi.SelectedRows.Count > 0)
                    {
                        EpiClass epi = EpiClass.GetEntidade(Convert.ToInt64(dgvEpi.SelectedRows[0].Cells["id_epi"].Value), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                        form = new HistoricoMovimentacaoEstoqueForm(epi);
                    }
                    else
                    {
                        throw new ExcecaoTratada("Selecione o epi que deseja para verificar o histórico");
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

           
            form.ShowDialog();
        }

        #region Eventos

        private void rdbMaterial_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbMaterial.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.Material);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void rdbProduto_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbProduto.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.Produto);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbRecurso_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbRecurso.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.Recurso);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbDocumento_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbDocumento.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.CópiaDocumento);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                timerBusca.Enabled = false;
                this.realizaBusca();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cancelar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        private void dgvEstoquesLocalizados_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgvEstoquesLocalizados.SelectedRows != null && this.dgvEstoquesLocalizados.SelectedRows.Count > 0)
            {
                this.lblQtdEstoqueSelecionado.Text = Convert.ToDouble(this.dgvEstoquesLocalizados.SelectedRows[0].Cells["egi_quantidade"].Value).ToString("F4", CultureInfo.CurrentCulture);
            }
        }

        private void btnNovaGaveta_Click(object sender, EventArgs e)
        {
            try
            {
                this.novaGaveta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
    
        private void dgvEstoquesLocalizados_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMaterial_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProduto_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvRecurso_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvDocumento_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProdutoK_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                this.Operacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTrocarGaveta_Click(object sender, EventArgs e)
        {
            try
            {
                this.trocarGaveta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                this.historicoGaveta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirGaveta_Click(object sender, EventArgs e)
        {
            try
            {
                this.excluirGaveta();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbProdutoK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbProdutoK.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.ProdutoK);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbEpi_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.rdbEpi.Checked)
                {
                    this.ConfiguraTela(passoTela.SelecaoItem, EnviaItemEstoqueForm.tipoUtilizacao.Epi);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnHistoricoMovimentacaoCompleto_Click(object sender, EventArgs e)
        {
            try
            {
                HistoricoMovimentacaoCompleto();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        #endregion


    }
}
