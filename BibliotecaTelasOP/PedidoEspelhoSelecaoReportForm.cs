using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWTPostgreNpgsql;

namespace BibliotecaTelasOP
{
    public partial class PedidoEspelhoSelecaoReportForm : Form
    {
        public PedidoEspelhoSelecaoReportForm()
        {
            InitializeComponent();
            loadClientes();
        }

        private void loadClientes()
        {
            try
            {
                string sql =
                   "SELECT " +
                   "  public.cliente.id_cliente, " +
                   "  public.cliente.cli_nome_resumido, " +
                   "  public.cliente.cli_nome " +
                   "FROM " +
                   "  public.cliente " +
                   "ORDER BY " +
                   "  cli_nome_resumido, " +
                   "  public.cliente.cli_nome ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, dbProvider.DbConnection.Connection);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbCliente.DataSource = binding;
                    this.cmbCliente.ValueMember = "id_cliente";
                    this.cmbCliente.DisplayMember = "cli_nome_resumido";
                    this.cmbCliente.autoSize = true;
                    this.cmbCliente.Table = ds.Tables[0];
                    this.cmbCliente.ColumnsToDisplay = new string[] { "cli_nome_resumido", "cli_nome" };
                    this.cmbCliente.HeadersToDisplay = new string[] { "Nome Resumido", "Razão" };
                }
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao carregar dados do cliente.\r\n" + a.Message, "Dados do Cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void imprimirPedidos()
        {
            try
            {
                if (cmbCliente.SelectedRow != null)
                {
                    List<PedidoEspelhoParametrosBuscaClass> parametrosBusca = new List<PedidoEspelhoParametrosBuscaClass>();
                    PedidoEspelhoParametrosBuscaClass parametros = new PedidoEspelhoParametrosBuscaClass
                    {
                        idCliente = int.Parse(cmbCliente.SelectedValue.ToString()),
                        numero = txtNumeroPedido.Text != "" ? txtNumeroPedido.Text : null,
                        posicao = null
                    };
                    parametrosBusca.Add(parametros);

                    PedidoEspelhoReportForm form = new PedidoEspelhoReportForm(parametrosBusca);
                    form.ShowDialog();
                

                }
                else
                {
                    MessageBox.Show(this, "Selecione um cliente para imprimir os pedidos", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #region Eventos


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                imprimirPedidos();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
