#region Referencias

using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    public partial class LogCalculoPrecoListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;

        public LogCalculoPrecoListForm(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
            this.dtpInicio.Value = Configurations.DataIndependenteClass.GetData().AddDays(-3);
            this.dtpFim.Value = Configurations.DataIndependenteClass.GetData();
            
            this.initializeGrid();
        }

        private void initializeGrid()
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

            if (txtOc.Text.Trim().Length > 0)
            {
                searchClause += " AND lcp_oc ||'/'||lcp_pos LIKE '%" + txtOc.Text.Trim() + "%' ";
            }

            if (txtItem.Text.Trim().Length > 0)
            {
                searchClause += " AND lcp_codigo_item LIKE '%" + txtItem.Text.Trim() + "%' ";
            }

            if (groupBox1.Enabled)
            {
                searchClause += " AND (lcp_data_hora >= '" + dtpInicio.Value.ToString("yyyy-MM-dd") + "' AND lcp_data_hora < '" + dtpFim.Value.AddDays(1).ToString("yyyy-MM-dd") + "') ";
            }

            if (rdbAvisos.Checked)
            {
                searchClause += " AND lcp_tipo = 1 ";
            }

            if (rdbErros.Checked)
            {
                searchClause += " AND lcp_tipo = 0 ";
            }


            if (searchClause.Length > 0)
            {
                searchClause = " WHERE " + searchClause.Substring(4);
            }

            string sql =
                "SELECT  " +
                "  id_log_conferencia_preco, "+
                "  lcp_oc, "+
                "  lcp_pos, "+
                "  lcp_codigo_item, "+
                "  lcp_preco_original, " +
                "  lcp_preco_calculado, " +
                "  CASE lcp_tipo WHEN 0 THEN 'Erro' WHEN 1 THEN 'Aviso' ELSE '' END as tipo, "+
                "  lcp_mensagem, "+
                "  lcp_data_hora "+
                "FROM  "+
                "  public.log_conferencia_preco "+
                searchClause +
                "ORDER BY " +
                "  lcp_data_hora";

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

                this.dataGridView1.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Pedido", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Pos", 30, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Item", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Preço Orig.", 60, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Preço Calc.", 60, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Tipo", 60, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Mensagem", 300, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Data", 105, DataGridViewAutoSizeColumnMode.None, true);
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

        private void excluirSelecionados()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    if (MessageBox.Show(this, "Deseja excluir as linhas selecionadas?", "Excluir Log", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //
                        StringBuilder sql = new StringBuilder();
                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {
                            sql.Append(" OR id_log_conferencia_preco = " + row.Cells["id_log_conferencia_preco"].Value + " ");
                        }

                        IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                        command.CommandText = "DELETE FROM log_conferencia_preco WHERE " + sql.ToString().Substring(3);
                        command.ExecuteNonQuery();

                        this.initializeGrid();
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir as entradas do log.\r\n" + e.Message);
            }
        }

        #region
        private void txtOc_TextChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            this.groupBox1.Enabled = this.chkData.Checked;
            this.initializeGrid();
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void dtpFim_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }
       
        private void rdbErros_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbAvisos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }


        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                this.excluirSelecionados();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
        

    }
}
