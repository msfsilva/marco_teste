#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using BibliotecaProdutos;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioPedidoItemConsumoMedioReportForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        private long? idProdutoSelecionado = null;
        private long? idClienteSelecionado = null;
        private TipoForm Tipo;

        public RelatorioPedidoItemConsumoMedioReportForm(IWTPostgreNpgsqlConnection conn, TipoForm tipo)
        {
            InitializeComponent();
            this.conn = conn;
            this.Tipo = tipo;
            loadComboCliente();
        }

        private void gerarRelatorio()
        {
            try
            {
                RelatorioPedidoItemConsumoMedioClass gerador = new RelatorioPedidoItemConsumoMedioClass(this.conn);

                TipoRelatorioPedidoItemConsumoMedio tipo = TipoRelatorioPedidoItemConsumoMedio.ordernarTrimestral;
                if (this.rdbMensal.Checked)
                {
                    tipo = TipoRelatorioPedidoItemConsumoMedio.ordernarMensal;
                }

                if (this.rdbTrimestral.Checked)
                {
                    tipo = TipoRelatorioPedidoItemConsumoMedio.ordernarTrimestral;
                }


                if (this.rdbSemestral.Checked)
                {
                    tipo = TipoRelatorioPedidoItemConsumoMedio.ordernarSemestral;
                }

                if (this.rdbAnual.Checked)
                {
                    tipo = TipoRelatorioPedidoItemConsumoMedio.ordernarAnual;
                }

                long? idProduto = null;
                long? idCliente = null;
                string dimensao = null;

               if (this.grbProduto.Enabled)
                {
                    if (this.idProdutoSelecionado == null)
                    {
                        throw new Exception("Selecione um produto ou desabilite o campo");
                    }
                    idProduto = (long?)this.idProdutoSelecionado;
                    dimensao = this.txtDimensao.Text;

                }

                if(cmbCliente.Enabled)
                {
                    if(this.idClienteSelecionado == null)
                    {
                        throw new Exception("Selecione um cliente ou desabilite o campo");
                    }
                    idCliente = idClienteSelecionado;
                }
                

                List<itemRelatorioPedidoItemConsumoMedioClass> dados = gerador.gerarRelatorio(tipo, false, idProduto, idCliente, dimensao);


                RelatorioPedidoItemConsumoMedioReport rep = new RelatorioPedidoItemConsumoMedioReport();
                rep.SetDataSource(dados);

                this.crystalReportViewer1.ReportSource = rep;
                //this.crystalReportViewer1.RefreshReport();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }

        private void BuscaProduto()
        {
            try
            {

                CadProdutoListForm form = new CadProdutoListForm(this.Tipo, true, this.txtBuscaProduto.Text, somenteAtivos: true);
                form.ShowDialog();
                if (form.ItemSelecionado != null)
                {
                    this.idProdutoSelecionado = ((ProdutoClass)form.ItemSelecionado).ID;
                    txtBuscaProduto.Text = ((ProdutoClass)form.ItemSelecionado).Codigo;
                    lblDescricao.Text = form.ItemSelecionado.ToString();
                }else
                {
                    this.idProdutoSelecionado = null;
                    txtBuscaProduto.Text = String.Empty;
                    lblDescricao.Text = String.Empty;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar o produto\r\n" + e.Message, e);
            }
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
                "  JOIN public.cliente ON (public.familia_cliente.id_familia_cliente = public.cliente.id_familia_cliente) " +
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

      /*  private void InitializeComboProduto()
        {
            try
            {
                const string sql =
                "SELECT  " +
                "  public.produto.id_produto, "+
                "  public.produto.pro_codigo, "+
                "  public.produto.pro_codigo_cliente, "+
                "  public.produto.pro_descricao "+
                "FROM "+
                "  public.produto "+
                "ORDER BY "+
                "  public.produto.pro_codigo ";

                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                BindingSource binding = new BindingSource { DataSource = ds.Tables[0] };
                this.cmbProduto.DataSource = binding;
                this.cmbProduto.ValueMember = "id_produto";
                this.cmbProduto.DisplayMember = "pro_codigo";
                this.cmbProduto.autoSize = true;
                this.cmbProduto.Table = ds.Tables[0];
                this.cmbProduto.ColumnsToDisplay = new[] { "pro_codigo", "pro_codigo_cliente", "pro_descricao" };
                this.cmbProduto.HeadersToDisplay = new[] { "Código", "Código do Cliente", "Descrição" };

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do produto.\r\n" + e.Message);
            }
        }

        */

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.gerarRelatorio();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkProduto_CheckedChanged(object sender, EventArgs e)
        {
            this.grbProduto.Enabled = this.chkProduto.Checked;
        }

        private void btnBuscaProduto_Click(object sender, EventArgs e)
        {
            try
            {
                this.BuscaProduto();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            cmbCliente.Enabled = chkCliente.Checked;
        }

        private void cmbCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCliente.SelectedValue != null)
                {
                    idClienteSelecionado = Convert.ToInt32(cmbCliente.SelectedValue);
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Falha ao selecionar o cliente " + e.ToString());
            }
        }

    }
}
