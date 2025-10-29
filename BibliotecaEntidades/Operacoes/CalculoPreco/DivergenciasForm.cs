#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    public partial class DivergenciasForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly AcsUsuarioClass Usuario;

        public DivergenciasForm(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
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
            
            string sql =
                "SELECT                       " +
                "  id_divergencia_preco,            " +
                "  div_oc,                    " +
                "  div_pos,                   " +
                "  div_codigo_item,           " +
                "  div_mensagem,              " +
                "  div_preco_tabela,          " +
                "  div_preco_pedido,          " +
                "  div_preco_cliente,         " +
                "  div_usuario,               " +
                "  div_datahora,              " +
                "  div_status                 " +
                "FROM                         " +
                "  public.divergencia_preco ; ";

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

                DataGridViewCheckBoxColumn tmp = null;
                DataGridViewColumn column;

                column = dataGridView1.Columns["div_status"];
                if (column.DataPropertyName == "div_status")
                {
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
                    dataGridView1.Columns.Remove(tmp.Name);
                    dataGridView1.Columns.Add(tmp);
                }

                this.dataGridView1.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "OC", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Pos", 40, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Produto", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Mensagem", 255, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Preço Tabela", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Preço Pedido", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Preço Cliente", 70, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Usuário", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "DataHora", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "OK", 50, DataGridViewAutoSizeColumnMode.None, true);

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

            this.updateSearch();

        }

        private void updateSearch()
        {
            try
            {
                string filter = "";
                if (this.txtOc.Text.Trim().Length > 0)
                {
                    filter += " AND div_oc LIKE '%" + this.txtOc.Text.Trim() + "%' ";
                }

                if (this.txtPos.Text.Trim().Length > 0)
                {
                    filter += " AND div_pos LIKE '%" + this.txtPos.Text.Trim() + "%' ";
                }

                if (this.cbxPend.Checked)
                {
                    filter += " AND div_status = 0";
                }
                else
                {
                    filter += " AND div_status = 1";
                }
                
                if (filter.Length > 0)
                {
                    this.binding.Filter = filter.Substring(4);
                }
                else
                {
                    this.binding.Filter = "";
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar a busca.\r\n" + e.Message);
            }

        }       

        private void Baixar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show(this, "Essa operação não poderá ser desfeita, deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                        foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                        {
                            if (row.Cells["div_status"].Value.ToString() == "0")
                            {
                                int id = Convert.ToInt32(row.Cells["id_divergencia_preco"].Value);
                                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                                command.CommandText = "UPDATE divergencia_preco SET div_status = 1, div_usuario = :div_usuario, div_datahora = NOW() WHERE id_divergencia_preco = :id_divergencia_preco";
                                command.Parameters.Clear();
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_divergencia_preco", NpgsqlDbType.Integer));
                                command.Parameters[command.Parameters.Count - 1].Value = id;
                                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("div_usuario", NpgsqlDbType.Varchar));
                                command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.Login;

                                command.ExecuteNonQuery();

                            }
                            else
                            {
                                MessageBox.Show(this, "A  divergência " + row.Cells["div_oc"].Value + "/" + row.Cells["div_pos"].Value + "(" + row.Cells["div_codigo_item"].Value + ") ja foi baixada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                continue;
                            }
                        }
                       
                        this.initializeGrid();
                    }
                    else
                    {
                        return;
                    }
                   
                }
                else
                {
                    throw new Exception("Selecione uma linha.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao baixar o item selecionado.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void btnAjusteRealiz_Click(object sender, EventArgs e)
        {
            try
            {
                this.Baixar();
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Baixar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtOc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Stop();
                this.timer1.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Stop();
                this.timer1.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxPend_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Stop();
                this.timer1.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 


        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.P && e.Modifiers == Keys.Control)
            {

                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string toClipboard = "";


                    foreach (DataGridViewRow row in this.dataGridView1.SelectedRows)
                    {
                        toClipboard += row.Cells["div_oc"].Value + "/" + row.Cells["div_pos"].Value + "\r\n";
                    }


                    Clipboard.SetDataObject(toClipboard);
                }
            }
        }

        #endregion

    }
}
