#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public partial class CadPedidoRejeitadoListForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;

        public CadPedidoRejeitadoListForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.initializeGrid();
            this.WindowState = FormWindowState.Maximized;
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

            string filter = "";
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                filter +=
                    "WHERE " +
                    "  public.pedido_rejeitado.per_nome_arquivo LIKE '%" + this.txtBusca.Text.Trim() + "%' OR  " +
                    "  public.pedido_rejeitado.per_motivo_rejeicao LIKE '%" + this.txtBusca.Text.Trim() + "%' OR  " +
                    "  public.pedido_rejeitado.per_observacao LIKE '%" + this.txtBusca.Text.Trim() + "%' OR " +
                    "  public.pedido_rejeitado.per_modulo_importador LIKE '%" + this.txtBusca.Text.Trim() + "%' ";

            }

            string sql =
                "SELECT  " +
                "  public.pedido_rejeitado.id_pedido_rejeitado, "+
                "  public.pedido_rejeitado.per_modulo_importador, " +
                "  public.pedido_rejeitado.per_nome_arquivo, "+                
                "  public.pedido_rejeitado.per_motivo_rejeicao, "+
                "  public.pedido_rejeitado.per_observacao, "+                
                "  public.pedido_rejeitado.per_data_entrada, "+
                "  public.pedido_rejeitado.per_data_ultimo_processamento "+
                "FROM "+
                "  public.pedido_rejeitado "+
                filter+
                "ORDER BY " +
                "  per_modulo_importador, id_pedido_rejeitado";

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
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Módulo Importador", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Nome", 200, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Motivo Rejeição", 400, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Observações", 400, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Data Entrada", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Data Último Processamento", 100, DataGridViewAutoSizeColumnMode.None, true);

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

        private void Editar()
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_pedido_rejeitado"].Value);

                    CadPedidoRejeitadoForm form = new CadPedidoRejeitadoForm(this.conn, id);
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
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {

                    if (MessageBox.Show(this, "Você deseja excluir o(s) item(ns) selecionado(s)?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.pedido_rejeitado  " +
                            "WHERE  " +
                            "  id_pedido_rejeitado = :id_pedido_rejeitado " +
                            "; ";

                        for (int i = 0; i < this.dataGridView1.SelectedRows.Count; i++)
                        {
                            int id = Convert.ToInt32(this.dataGridView1.SelectedRows[i].Cells["id_pedido_rejeitado"].Value);
                           
                            command.Parameters.Clear();
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_rejeitado", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = id;

                            command.ExecuteNonQuery();
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
                    throw new Exception("Selecione a linha que você deseja excluir.");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir o item selecionado.\r\n" + e.Message);
            }
        }

        #region Eventos
        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.initializeGrid();
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
       

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            timerBusca.Stop();
            timerBusca.Start();
        }

        #endregion

    }
}
