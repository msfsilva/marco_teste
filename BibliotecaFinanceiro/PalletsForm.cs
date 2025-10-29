#region Referencias

using System;
using System.Data;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class PalletsForm : IWTBaseForm
    {
        private BindingSource binding;
        public PalletsForm()
        {
            InitializeComponent();
            this.initializeGrid();
        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql = "SELECT  " +
                        "  pal_numero, " +
                        "  CASE pal_ocupado WHEN 0 THEN 'Não' ELSE 'Sim' END as ocupado, " +
                        "  CASE pal_fechado WHEN 0 THEN 'Não' ELSE 'Sim' END as fechado, " +
                        "  CASE pal_conferido WHEN 0 THEN 'Não' ELSE 'Sim' END as conferido, " +
                        "  pal_ocupado, " +
                        "  pal_fechado, " +
                        "  pal_conferido, " +
                        "  pal_especial, " +
                        "  CASE pal_especial WHEN 0 THEN 'Não' ELSE 'Sim' END as especial, " +
                        "  pal_sequencia, " +
                        "  pal_bloqueado, " +
                        "  CASE pal_bloqueado WHEN 0 THEN 'Não' ELSE 'Sim' END as bloqueado " +
                        "FROM " +
                        "  public.pallet " +
                        "ORDER BY pal_numero";

                adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "Número";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Ocupado";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Fechado";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Conferido";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Columns[7].Visible = false;
                    dataGridView1.Columns[8].HeaderText = "Especial";
                    dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[9].Visible = false;
                    dataGridView1.Columns[10].Visible = false;
                    dataGridView1.Columns[11].HeaderText = "Bloqueado";
                    dataGridView1.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
                this.updateSearch();
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void updateSearch()
        {
            string sql = "";
            if (this.txtNumero.Text.Trim().Length > 0)
            {
                sql += " AND pal_numero = " + this.txtNumero.Text;
            }

            if (!rdbOcupadoTodos.Checked)
            {
                sql += " AND pal_ocupado=" + Convert.ToInt16(rdbOcupadoSim.Checked).ToString() + " ";
            }
            if (!rdbFechadoTodos.Checked)
            {
                sql += " AND pal_fechado=" + Convert.ToInt16(rdbFechadoSim.Checked).ToString() + " ";
            }
            if (!rdbConferidoTodos.Checked)
            {
                sql += " AND pal_conferido=" + Convert.ToInt16(rdbConferidoSim.Checked).ToString() + " ";
            }

            if (sql.Length > 0)
            {
                this.binding.Filter = sql.Substring(4);
            }
            else
            {
                this.binding.Filter = "";
            }
        }



        #region Eventos

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.updateSearch();

        }

        private void rdbOcupadoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbOcupadoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }
     
        private void rdbOcupadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbFechadoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }
      
        private void rdbConferidoSim_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbConferidoNao_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }

        private void rdbConferidoTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.updateSearch();
        }
        #endregion

        private void btnEmitirNF_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dataGridView1.SelectedRows.Count > 0)
                {
                    string numPallet = this.dataGridView1.SelectedRows[0].Cells["pal_numero"].Value.ToString();
                    bool especial = Convert.ToBoolean(Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["pal_especial"].Value));
                    bool conferido = Convert.ToBoolean(Convert.ToInt16(this.dataGridView1.SelectedRows[0].Cells["pal_conferido"].Value));
                    if (especial)

                    if (MessageBox.Show(this, "Deseja emitir a nota fiscal para os itens do pallet número: " + numPallet, "Emissão NF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {

                    }
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.initializeGrid();
        }

    }
}
