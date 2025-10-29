#region Referencias

using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaTelasOP
{
    public partial class CadPrecosItensVariaveisListForm : IWTBaseForm
    {
        BindingSource binding;
        readonly IWTPostgreNpgsqlConnection conn;

        public CadPrecosItensVariaveisListForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.initializeGrid();
        }

        private void initializeGrid()
        {        
            try
            {                
                #region Salvando Posição do Grid
                int scrollIndex = 0;
                if (this.dataGridView1.FirstDisplayedScrollingRowIndex > 0)
                {
                    scrollIndex = this.dataGridView1.FirstDisplayedScrollingRowIndex;
                }

                int selectRowIndex = 0;
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    selectRowIndex = this.dataGridView1.SelectedRows[0].Index;
                }
                #endregion

                #region Salvando FiltroAtual

                string atualFilter;
                if (this.binding != null)
                {
                    atualFilter = this.binding.Filter;
                }
                else
                {
                    atualFilter = "";
                }

                #endregion

                #region Salvando o Sort Atual do Grid

                string sortedColumName = null;
                SortOrder? sortedMode = null;
                if (this.dataGridView1.SortedColumn != null)
                {
                    sortedColumName = this.dataGridView1.SortedColumn.Name;
                    sortedMode = this.dataGridView1.SortOrder;
                }

                #endregion


                string searchClause = "";

                if (this.txtPedido.Text.Trim().Length > 0)
                {
                    searchClause += " AND pei_numero LIKE '%" + this.txtPedido.Text.Trim() + "%' ";
                }

                if (this.txtProdutoClassificacao.Text.Trim().Length > 0)
                {
                    searchClause += " AND (upper(pedido.pei_produto_codigo_cliente) LIKE '%" + this.txtProdutoClassificacao.Text.Trim().ToUpper() + "%' ";
                    searchClause += " OR upper(public.classificacao_produto.clp_identificacao) LIKE '%" + this.txtProdutoClassificacao.Text.Trim().ToUpper() + "%') ";
                }

                if (this.txtPos.Text.Trim().Length > 0)
                {
                    searchClause += " AND pei_posicao = " + this.txtPos.Text.Trim() + " ";
                }

                if (rdbAntigos.Checked)
                {
                    searchClause += " AND tpv_antigo = 1 ";
                }

                if (rdbNormais.Checked)
                {
                    searchClause += " AND tpv_antigo = 0 ";
                }

                if (rdbSemPreco.Checked)
                {
                    searchClause += " AND id_tabela_preco_item_variavel IS NULL ";
                }

                if (chkNaoEncerrados.Checked)
                {
                    searchClause += " AND (pei_status = 0 OR pei_status = 3 OR pei_status = 4)  ";
                }

                if (searchClause.Length > 0)
                {
                    searchClause = " WHERE " + searchClause.Substring(4);
                }

                string sql =
                    "SELECT   " +
                    "  public.tabela_preco_item_variavel.id_tabela_preco_item_variavel, " +
                    "  pedido.pei_numero, " +
                    "  pedido.pei_posicao, " +
                    "  cliente.cli_nome_resumido, "+
                    "  pedido.pei_produto_codigo_cliente, " +
                    "  public.classificacao_produto.clp_identificacao, "+
                    "  public.tabela_preco_item_variavel.tpv_preco, " +
                    "  pedido.pei_preco_total_original, "+
                    "  CASE public.tabela_preco_item_variavel.tpv_antigo WHEN 1 THEN 'Antigo' WHEN 0 THEN 'Normal' ELSE '' END, " +
                    "  pedido.id_cliente " +
                    "FROM " +
                    "  (SELECT * FROM public.pedido_item WHERE pei_sub_linha = 0) as pedido " +
                    "  LEFT OUTER JOIN public.tabela_preco_item_variavel ON (pedido.pei_numero = public.tabela_preco_item_variavel.tpv_order_number) " +
                    "  AND (pedido.pei_posicao = public.tabela_preco_item_variavel.tpv_pos) AND (pedido.id_cliente = public.tabela_preco_item_variavel.id_cliente) " +
                    "  LEFT OUTER JOIN public.produto ON (pedido.id_produto = public.produto.id_produto) " +
                    "  LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto) "+
                    "  LEFT OUTER JOIN cliente ON pedido.id_cliente = cliente.id_cliente " +
                    searchClause +
                    "ORDER BY " +
                    "  pedido.pei_numero, " +
                    "  pedido.pei_posicao ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    binding.Filter = atualFilter;
                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = true;

                    this.dataGridView1.Columns[0].Visible = false;
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Pedido", 200, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Pos", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Cliente", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Produto", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Classificação", 100, DataGridViewAutoSizeColumnMode.None, true);                    
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Preço Total", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Preço Total Orig.", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Tipo", 50, DataGridViewAutoSizeColumnMode.None, true);
                    this.dataGridView1.Columns[9].Visible = false;


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

                        this.binding.Sort = sortString;
                    }
                    #endregion

                    #region Restaurando Posição do Grid
                    for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                    {
                        this.dataGridView1.SelectedRows[i].Selected = false;
                    }
                    if (this.dataGridView1.Rows.Count > 0)
                    {
                        while (selectRowIndex > 0 && selectRowIndex >= this.dataGridView1.Rows.Count)
                        {
                            selectRowIndex--;
                        }


                        this.dataGridView1.Rows[selectRowIndex].Selected = true;

                        while (scrollIndex > 0 && scrollIndex >= this.dataGridView1.Rows.Count)
                        {
                            scrollIndex--;
                        }

                        this.dataGridView1.FirstDisplayedScrollingRowIndex = scrollIndex;
                    }
                    #endregion


                 }

            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }

   
        private void Novo()
        {
            try
            {
                CadPrecosItensVariaveisForm form = new CadPrecosItensVariaveisForm(this.conn, null);
                form.ShowDialog();
                this.initializeGrid();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cadastrar um novo item.\r\n" + e.Message);
            }
        }

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    CadPrecosItensVariaveisForm form;
                    if (this.dataGridView1.SelectedRows[0].Cells["id_tabela_preco_item_variavel"].Value != DBNull.Value)
                    {
                        int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_tabela_preco_item_variavel"].Value);
                        
                        form = new CadPrecosItensVariaveisForm(this.conn, id);
                    }
                    else
                    {
                        string oc = this.dataGridView1.SelectedRows[0].Cells["pei_numero"].Value.ToString();
                        int pos = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["pei_posicao"].Value);
                        ClienteClass cli = ClienteBaseClass.GetEntidade(Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_cliente"].Value), LoginClass.UsuarioLogado.loggedUser, this.SingleConnection);

                        form = new CadPrecosItensVariaveisForm(this.conn, oc, pos,cli);
                    }
                    form.ShowDialog();

                    this.initializeGrid();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao editar o item.\r\n" + e.Message);
            }
        }

        private void Excluir()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (
                        MessageBox.Show(this, "Você deseja excluir o(s) item(ns) selecionado(s)?", "Exclusão",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        command = this.conn.CreateCommand();
                        command.Transaction = this.conn.BeginTransaction();

                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {
                            if (row.Cells["id_tabela_preco_item_variavel"].Value != DBNull.Value)
                            {
                                int id = Convert.ToInt32(row.Cells["id_tabela_preco_item_variavel"].Value);

                                command.CommandText =
                                    "DELETE FROM  " +
                                    "  public.tabela_preco_item_variavel  " +
                                    "WHERE  " +
                                    "  id_tabela_preco_item_variavel = :id_tabela_preco_item_variavel " +
                                    "; ";
                                command.Parameters.Clear();
                                command.Parameters.Add(
                                    new IWTPostgreNpgsqlCommandParameter("id_tabela_preco_item_variavel",
                                                                         NpgsqlDbType.Integer));
                                command.Parameters[command.Parameters.Count - 1].Value = id;

                                command.ExecuteNonQuery();
                            }
                        }

                        command.Transaction.Commit();


                        this.initializeGrid();
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    throw new Exception("Selecione a linha que você deseja excluir.");
                }
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw new Exception("Erro ao excluir o item selecionado.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void txtPedido_TextChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void txtPos_TextChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                this.Novo();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.Excluir();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells["id_tabela_preco_item_variavel"].Value.ToString() == "")
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.Yellow;
                }
            }
            else
            {
                foreach (DataGridViewCell cell in dataGridView1.Rows[e.RowIndex].Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }

        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbAntigos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbNormais_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbSemPreco_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }



        private void txtProdutoClassificacao_TextChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }
    
        private void chkNaoEncerrados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        #endregion



    }
}
