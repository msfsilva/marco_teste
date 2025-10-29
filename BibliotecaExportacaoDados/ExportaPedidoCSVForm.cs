#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using BibliotecaTelasOP;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaExportacaoDados
{
    public partial class ExportaPedidoCSVForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public ExportaPedidoCSVForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
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
                    this.cmbCliente.ColumnsToDisplay = new string[] {"cli_nome_resumido", "fac_nome" };
                    this.cmbCliente.HeadersToDisplay = new string[] {"Nome Resumido", "Agrupador"  };


                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados para seleção do Cliente.\r\n" + e.Message);
            }
        }

        private void Exportar()
        {
            try
            {

                if (this.textBox1.Text.Trim().Length == 0)
                {
                    throw new Exception("Selecione o diretório de saída para o arquivo gerado.");
                }

                ExportaPedidosCSV exp = new ExportaPedidosCSV(this.conn);

                DateTime? dataEntradaInicio = null;
                if (this.dtpEntradaInicio.Enabled)
                {
                    dataEntradaInicio = this.dtpEntradaInicio.Value;
                }

                DateTime? dataEntradaFim = null;
                if (this.dtpEntradaFim.Enabled)
                {
                    dataEntradaFim = this.dtpEntradaFim.Value;
                }

                DateTime? dataEntregaInicio = null;
                if (this.dtpEntregaInicio.Enabled)
                {
                    dataEntregaInicio = this.dtpEntregaInicio.Value;
                }

                DateTime? dataEntregaFim = null;
                if (this.dtpEntregaFim.Enabled)
                {
                    dataEntregaFim = this.dtpEntregaFim.Value;
                }

                List<PedidoStatus> statusGerar = new List<PedidoStatus>();

                if (this.chkCancelado.Checked)
                {
                    statusGerar.Add(PedidoStatus.Cancelado);
                }
                if (this.chkEncerrado.Checked)
                {
                    statusGerar.Add(PedidoStatus.Encerrado);
                }
                if (this.chkPendente.Checked)
                {
                    statusGerar.Add(PedidoStatus.Pendente);
                }
                if (this.chkReaberto.Checked)
                {
                    statusGerar.Add(PedidoStatus.Reaberto);
                }
                if (this.chkSuspenso.Checked)
                {
                    statusGerar.Add(PedidoStatus.Suspenso);
                }

                List<PedidoUrgente> urgenteGerar = new List<PedidoUrgente>();
                if (this.chkNormal.Checked)
                {
                    urgenteGerar.Add(PedidoUrgente.Normal);
                }
                if (this.chkAntecipacao.Checked)
                {
                    urgenteGerar.Add(PedidoUrgente.Antecipacao);
                }
                if (this.chkCritico.Checked)
                {
                    urgenteGerar.Add(PedidoUrgente.Critico);
                }
                if (this.chkUrgente.Checked)
                {
                    urgenteGerar.Add(PedidoUrgente.Urgente);
                }


                List<ExportaPedidoPedidoClass> Pedidos = new List<ExportaPedidoPedidoClass>();
                if (this.txtNumeroPedido.Text.Trim().Length > 0)
                {
                    if (this.txtPosPedido.Text.Trim().Length > 0)
                    {
                        Pedidos.Add(new ExportaPedidoPedidoClass(this.txtNumeroPedido.Text.Trim(), this.txtPosPedido.Text.Trim()));
                    }
                    else
                    {
                        Pedidos.Add(new ExportaPedidoPedidoClass(this.txtNumeroPedido.Text.Trim(), null));
                    }
                }

                List<int> idClientes = new List<int>();
                if (cmbCliente.Enabled && cmbCliente.SelectedValue != null)
                {
                    idClientes.Add(Convert.ToInt32(cmbCliente.SelectedValue));
                }

                string arquivo = exp.gerarCSV(
                    dataEntradaInicio, dataEntradaFim, dataEntregaInicio,
                    dataEntregaFim, statusGerar,
                    urgenteGerar, Pedidos, idClientes, this.textBox1.Text);

                if (MessageBox.Show(this, "O arquivo foi gerado com sucesso, deseja visualiza-lo agora?", "Abrir arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Process pr = new Process();
                    pr.StartInfo.FileName = arquivo;
                    pr.Start();
                }
                
            }
            catch (Exception e)
            {

                throw new Exception("Erro ao gerar o arquivo de exportação.\r\n" + e.Message);
            }
        }

        #region Eventos

        private void chkEntradaInicio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEntradaInicio.Enabled = chkEntradaInicio.Checked;
        }

        private void chkEntradaFim_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEntradaFim.Enabled = chkEntradaFim.Checked;
        }

        private void chkEntregaInicio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEntregaInicio.Enabled = chkEntregaInicio.Checked;
        }

        private void chkEntregaFim_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpEntregaFim.Enabled = chkEntregaFim.Checked;
        }

        private void chkCliente_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbCliente.Enabled = chkCliente.Checked;
        }

        private void btnDiretorioSaida_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Exportar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    
        #endregion
    }
}
