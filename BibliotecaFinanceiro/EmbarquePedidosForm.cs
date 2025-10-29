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
    public partial class EmbarquePedidosForm : IWTBaseForm
    {
        public bool confirmado = false;
        private readonly string idEmbarque;

        public EmbarquePedidosForm(string idEmbarque)
        {
            InitializeComponent();
            this.idEmbarque = idEmbarque;
            this.initializeGrid();
        }

        private void initializeGrid()
        {
            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
                string sql =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos, " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.id_embarque = " + idEmbarque + " " +
                    "ORDER BY oic_order_number,oic_order_pos ";

                adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "OC";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Pos";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Item";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Qty";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    

                }

            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region eventos
        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.confirmado = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.confirmado = false;
            this.Close();
        }
        #endregion
    }
}
