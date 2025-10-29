#region Referencias

using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEntidades.Operacoes.CalculoPreco
{
    public partial class SimuladorCalculoPrecoForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public SimuladorCalculoPrecoForm(IWTPostgreNpgsqlConnection conn, PedidoOrcamento tipoTela)
        {
         

            InitializeComponent();
            this.conn = conn;
            if (tipoTela == PedidoOrcamento.Pedido)
            {
                this.rdbPedido.Checked = true;
            }
            else
            {
                this.rdbOrcamento.Checked = true;
            }
            this.loadComboCliente();
        }



        private void loadComboCliente()
        {
            try
            {
                string sql =

                "SELECT  " +
                "  public.cliente.id_cliente, " +
                "  public.cliente.id_familia_cliente, " +
                "  public.familia_cliente.fac_nome, " +
                "  public.cliente.cli_nome_resumido " +
                "FROM " +
                "  public.familia_cliente " +
                "  RIGHT JOIN public.cliente ON (public.familia_cliente.id_familia_cliente = public.cliente.id_familia_cliente) " +
                "ORDER BY " +
                "  public.familia_cliente.fac_nome, " +
                "  public.cliente.cli_nome_resumido ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
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
                    this.cmbCliente.ColumnsToDisplay = new string[] { "fac_nome", "cli_nome_resumido" };
                    this.cmbCliente.HeadersToDisplay = new string[] { "Agrupador", "Nome Resumido" };


                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Cliente.\r\n" + e.Message);
            }
        }

        private void Calcular()
        {
            try
            {
                this.textBox1.Clear();
                if (txtOc.Text.Trim().Length == 0)
                {
                    throw new Exception("Preencha o campo de pedido corretamente.");
                }

                if (this.cmbCliente.SelectedValue == null)
                {
                    throw new Exception("Selecione o cliente ao qual pertence o pedido indicado.");
                }

                CalculoPrecoClass calcula = new CalculoPrecoClass(this.conn, LoginClass.UsuarioLogado.loggedUser);
                string avisos;
                PedidoOrcamento tipoEntidade;

                if (this.rdbOrcamento.Checked)
                {
                    tipoEntidade = PedidoOrcamento.Orcamento;
                }
                else
                {
                    tipoEntidade = PedidoOrcamento.Pedido;
                }

                string logCalculo;
                double precoCalculado = calcula.calulaPrecoPedido(this.txtOc.Text, this.txtPos.Text, this.cmbCliente.SelectedValue.ToString(), out avisos, tipoEntidade, out logCalculo);
                
                this.lblValorCalculado.Text = "R$ " + precoCalculado.ToString("F2", CultureInfo.CurrentCulture);

                this.textBox1.Text = "";
                if (!string.IsNullOrWhiteSpace(avisos))
                {
                    this.textBox1.Text = avisos + Environment.NewLine +"-----------------"+ Environment.NewLine;
                }

                this.textBox1.Text += logCalculo;
                MessageBox.Show(this, "Cálculo realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception e)
            {
                this.textBox1.Text = e.Message;
            }

        }

        #region Eventos
        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                this.Calcular();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
