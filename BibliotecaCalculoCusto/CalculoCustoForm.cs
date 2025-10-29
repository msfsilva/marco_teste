#region Referencias

using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using BibliotecaTributos;
using IWTDotNetLib;
using IWTNF;
using IWTNF.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCalculoCusto
{
    public partial class CalculoCustoForm : IWTBaseForm
    {
        readonly long idProduto;
        readonly string Produto;
        readonly string descricaoProduto;
        readonly int versaoEstruturaProduto;
        
        readonly ArredondamentoNF arrendodamentoNF;
        readonly IWTPostgreNpgsqlConnection conn;
        SimulacaoPrecoClass simulacao;


        private readonly bool loading = false;

        public CalculoCustoForm(
            long idProduto,
            int versaoEstruturaProduto,
            string Produto,
            string descricaoProduto,
            
            ArredondamentoNF arrendodamentoNF,
            IWTPostgreNpgsqlConnection conn
            )
        {
            InitializeComponent();
            this.conn = conn;
            this.idProduto = idProduto;
            this.versaoEstruturaProduto = versaoEstruturaProduto;
            this.Produto = Produto;
            this.arrendodamentoNF = arrendodamentoNF;
            this.descricaoProduto = descricaoProduto;
            this.loading = true;
            this.initializeComboCliente();
            this.loading = false;
            try
            {
                this.rodarSimulacao();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.atualizarDadosTela();
        }

        private void rodarSimulacao()
        {
            try
            {
                if (this.loading) return;

                if (this.cmbCliente.SelectedValue != null)
                {
                    CalculoCustoClass calcula = new CalculoCustoClass(this.conn);

                    
                    string Avisos;
                    this.simulacao = calcula.simularPreco(
                        this.idProduto,
                        this.versaoEstruturaProduto,
                        this.Produto,
                        this.descricaoProduto,
                        out Avisos,
                        Convert.ToInt32(this.cmbCliente.SelectedValue),
                        Convert.ToDouble(this.nudMargemBruta.Value),
                        this.arrendodamentoNF);


                    this.txtAvisos.Text = Avisos;

                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do produto.\r\n" + e.Message, e);
            }
        }

        private void initializeComboCliente()
        {
            try
            {
                string sql =
                         "SELECT                              " +
                         "  id_cliente,                       " +
                         "  cli_nome_resumido                 " +
                         "FROM                                " +
                         "  public.cliente                    " +
                         "ORDER BY cli_nome_resumido";


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

                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os clientes.\r\n" + e.Message, e);
            }
        }

        private void atualizarDadosTela()
        {
            try
            {
                if (this.loading) return;

                this.lblProduto.Text = this.Produto;
                if (this.simulacao != null)
                {

                    this.lblCofins.Text = "R$ " + this.simulacao.valorCofins.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblICMS.Text = "R$ " + this.simulacao.valorICMS.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblIPI.Text = "R$ " + this.simulacao.valorIPI.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblPis.Text = "R$ " + this.simulacao.valorPIS.ToString("F2", CultureInfo.CurrentCulture);

                    this.lblPrecoBrutoCalculado.Text = "R$ " + this.simulacao.custoInicial.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblCustoMaoObraCalculado.Text = "R$ " + this.simulacao.custoMaoObra.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblCustoTotalCalculado.Text = "R$ " + this.simulacao.custoTotal.ToString("F2", CultureInfo.CurrentCulture);
                    this.lblMargemCalculada.Text = (this.simulacao.pMargem * 100).ToString("F2", CultureInfo.CurrentCulture) + " %";

                    this.lblValorFinal.Text = "R$ " + this.simulacao.valorFinal.ToString("F2", CultureInfo.CurrentCulture);

                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao atualizar os dados da tela.\r\n" + e.Message, e);
            }
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.rodarSimulacao();
                this.atualizarDadosTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudMargemBruta_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.rodarSimulacao();
                this.atualizarDadosTela();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCustoBruto_Click(object sender, EventArgs e)
        {
            try
            {
                ComposicaoCustoReportForm form = new ComposicaoCustoReportForm(this.simulacao.Componentes, this.Produto);
                form.Show();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
