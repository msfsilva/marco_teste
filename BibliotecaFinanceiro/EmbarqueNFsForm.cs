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
    public partial class EmbarqueNFsForm : IWTBaseForm
    {
        readonly string idEmbarque;
        public EmbarqueNFsForm(string idEmbarque)
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
                    "  public.nf_principal.nfp_numero, " +
                    "  public.nf_principal.nfp_data_emissao, " +
                    "  public.nf_cliente.nfc_nome_fantasia, " +
                    "  public.nf_totais.nfo_valor_total_nf " +
                    "FROM " +
                    "  public.atendimento " +
                    "  INNER JOIN public.order_item_etiqueta_conferencia ON (public.atendimento.id_order_item_etiqueta_conferencia = public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " +
                    "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                    "  INNER JOIN public.nf_cliente ON (public.nf_principal.id_nf_principal = public.nf_cliente.id_nf_principal) " +
                    "  INNER JOIN public.nf_totais ON (public.nf_principal.id_nf_principal = public.nf_totais.id_nf_principal) " +
                    "WHERE id_embarque = " + this.idEmbarque + " " +
                    "GROUP BY  nfp_numero, nfp_data_emissao, nfc_nome_fantasia, nfo_valor_total_nf";

                adapter = new IWTPostgreNpgsqlAdapter(sql, DbConnection.Connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    dataGridView1.Columns[0].HeaderText = "Número da NF";
                    dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns[0].MinimumWidth = 100;
                    dataGridView1.Columns[1].HeaderText = "Data de Emissão";
                    dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[2].HeaderText = "Cliente";
                    dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns[3].HeaderText = "Valor";
                    dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                }

            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
    }
}
