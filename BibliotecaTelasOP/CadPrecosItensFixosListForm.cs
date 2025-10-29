#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaTelasOP
{
    public partial class CadPrecosItensFixosListForm : IWTBaseForm
    {
        BindingSource binding;
        readonly IWTPostgreNpgsqlConnection conn;

        public CadPrecosItensFixosListForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
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


            string sql = "SELECT id_tabela_preco_item_fixo, tpf_codigo, tpf_lote_ativo,tpf_data_inicio, tpf_preco, tpf_qtd_lote_orcado, tpf_origem_preco FROM tabela_preco_item_fixo;";

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
                dataGridView1.MultiSelect = false;

                this.dataGridView1.Columns[0].Visible = false;
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Item", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Lote Ativo", 50, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Data Inicio", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Preço", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Lote", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Origem Preço", 160, DataGridViewAutoSizeColumnMode.None, true);             

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

        /*private void initializeGridOLD()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {

                /*DBProvider DBTemp = new DBProvider("MS-Access");
                DBTemp.DBFile = IWTConfiguration.Conf.getConf(Program.NF_PPS_PATH);
                OleDbConnection AccessConnection = (OleDbConnection)DBTemp.CreateConn();
                AccessConnection.Open();
                //*

                string sql = "SELECT tpf_codigo, tpf_lote_ativo,tpf_data_inicio, tpf_preco, tpf_qtd_lote_orcado, tpf_origem_preco FROM tabela_preco_item_fixo;";
                adapter = Program.DBConn.CreateAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "Item";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Lote Ativo";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Data Inicio";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Preço";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].HeaderText = "Lote";
                    dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[5].HeaderText = "Origem Preço";
                    dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    this.updateSearch();
                }

            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
        }*/

        private void updateSearch()
        {
            try
            {
                string search = "";
                if (this.txtItem.Text.Trim().Length > 0)
                {
                    search += " AND tpf_codigo LIKE '%" + this.txtItem.Text.Trim() + "%' ";
                }                

                if (search.Length > 0)
                {
                    this.binding.Filter = search.Substring(4);
                }
                else
                {
                    this.binding.Filter = "";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao realizar a busca.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Novo()
        {
            try
            {
                CadPrecosItensFixosForm form = new CadPrecosItensFixosForm(this.conn, null);
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
                    int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_tabela_preco_item_fixo"].Value);

                    CadPrecosItensFixosForm form = new CadPrecosItensFixosForm(this.conn, id);
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

                    if (MessageBox.Show(this, "Você deseja excluir o item selecionado?", "Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_tabela_preco_item_fixo"].Value);
                        IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.tabela_preco_item_fixo  " +
                            "WHERE  " +
                            "  id_tabela_preco_item_fixo = :id_tabela_preco_item_fixo " +
                            "; ";
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tabela_preco_item_fixo", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = id;

                        command.ExecuteNonQuery();

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
        
        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            this.updateSearch();
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

        

    }
}
