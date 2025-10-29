#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using IWTPostgreNpgsql;
using Npgsql;
using ComplexLoginModule;
using NpgsqlTypes;

#endregion

namespace BibliotecaProdutos
{
    public partial class CadAcabamentoListForm : Form
    {
        readonly IWTPostgreNpgsqlConnection conn;
        BindingSource binding;
        readonly TipoForm Tipo;
        readonly AcsUsuario Usuario;

        public CadAcabamentoListForm(TipoForm Tipo, AcsUsuario Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Usuario = Usuario;
            this.Tipo = Tipo;
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
                "SELECT  " +
                "  id_acabamento, " +
                "  acb_identificacao, " +
                "  acb_descricao_tecnica, " +
                "  acb_norma_cliente, " +
                "  acb_obs, " +
                "  public.acs_usuario.aus_login, " +
                "  acb_ultima_revisao, " +
                "  acb_ultima_revisao_data " +
                "FROM  " +
                "  public.acabamento " +
                "  LEFT JOIN public.acs_usuario ON (public.acabamento.id_acs_usuario_ultima_revisao = public.acs_usuario.id_acs_usuario) " +
                "ORDER BY " +
                "  acb_identificacao";

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
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Identificação", 120, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Descrição Técnica", 250, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Norma Cliente", 200, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Observações", 250, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Revisor", 80, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Revisão", 100, DataGridViewAutoSizeColumnMode.None, true);
                IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Data Revisão ", 100, DataGridViewAutoSizeColumnMode.None, true);

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
                if (this.txtBusca.Text.Trim().Length > 0)
                {
                    filter += " AND (acb_identificacao LIKE '%" + this.txtBusca.Text.Trim() + "%' OR acb_descricao_tecnica LIKE '%" + this.txtBusca.Text.Trim() + "%' OR acb_norma_cliente LIKE '%" + this.txtBusca.Text.Trim() + "%') ";
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

        private void Novo()
        {
            try
            {
                CadAcabamentoForm form = new CadAcabamentoForm(this.Tipo, this.Usuario, this.conn, null);
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
                    int? id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_acabamento"].Value);

                    CadAcabamentoForm form = new CadAcabamentoForm(this.Tipo, this.Usuario, this.conn, id);
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
                        int id = Convert.ToInt32(this.dataGridView1.SelectedRows[0].Cells["id_acabamento"].Value);
                        IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.acabamento  " +
                            "WHERE  " +
                            "  id_acabamento = :id_acabamento " +
                            "; ";
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acabamento", NpgsqlDbType.Integer));
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

        #region Eventos
        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Stop();
                this.timerBusca.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timerBusca_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timerBusca.Enabled = false;
                this.updateSearch();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        #endregion
    }
}
