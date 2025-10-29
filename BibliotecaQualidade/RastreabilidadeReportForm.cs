#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaQualidade
{
    public partial class RastreabilidadeReportForm : IWTBaseForm
    {
        private readonly RastreabilidadeReportClass generator;
        private RastreabilidadeReport conferenciaReport;
        private RastreabilidadeOPReport opReport;

        public RastreabilidadeReportForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            generator = new RastreabilidadeReportClass(conn);
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtOc.Text.Trim().Length > 0 && this.txtPos.Text.Trim().Length > 0 && this.cmbCliente.SelectedItem != null)
                {
                    long idCliente = ((ClienteClass) (this.cmbCliente.SelectedItem)).ID;

                    this.conferenciaReport = this.generator.generateReport(this.txtOc.Text.Trim(), this.txtPos.Text.Trim(), idCliente);
                    this.opReport = this.generator.generateReportOps(this.txtOc.Text.Trim(), this.txtPos.Text.Trim(), idCliente);
                }
                else
                {
                    throw new Exception("Preencha os campos do pedido corretamente.");
                }

                this.toolStripButton1_Click(null, null);

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void carregaClientes()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(this.txtOc.Text) || string.IsNullOrWhiteSpace(this.txtPos.Text))
                {
                    return;
                }

                PedidoItemClass searchPed = new PedidoItemClass(LoginClass.UsuarioLogado.loggedUser,this.SingleConnection);
                List<PedidoItemClass> pedidos = searchPed.Search(new List<SearchParameterClass>()
                                                                     {
                                                                         new SearchParameterClass("Numero", this.txtOc.Text.Trim()),
                                                                         new SearchParameterClass("Posicao", int.Parse(this.txtPos.Text.Trim()))
                                                                     }).ConvertAll(a => (PedidoItemClass) a);
                if (pedidos.Count == 0)
                {
                    this.cmbCliente.Enabled = false;
                    throw new Exception("Não foi encontrado nenhum pedido para os parâmetros selecionados");

                }

                if (pedidos.Count == 1)
                {
                    this.cmbCliente.Enabled = false;


                    this.cmbCliente.DataSource = new List<ClienteClass>() { pedidos[0].Cliente }; 
                    this.cmbCliente.ValueMember = "ID";
                    this.cmbCliente.DisplayMember = "NomeResumido";
                    this.cmbCliente.autoSize = true;
                    this.cmbCliente.Table = new List<ClienteClass>() { pedidos[0].Cliente }; 
                    this.cmbCliente.ColumnsToDisplay = new string[] { "FamiliaCliente","NomeResumido"};
                    this.cmbCliente.HeadersToDisplay = new string[] { "Agrupador", "Nome Resumido" };

                    this.cmbCliente.SelectedIndex = 0;
                }

                if (pedidos.Count>1)
                {
                    this.cmbCliente.Enabled = true;

                    List<ClienteClass> clientes = new List<ClienteClass>();
                    foreach (PedidoItemClass pedido in pedidos)
                    {
                        if (!clientes.Contains(pedido.Cliente))
                        {
                            clientes.Add(pedido.Cliente);
                        }
                    }

                    this.cmbCliente.DataSource = clientes;
                    this.cmbCliente.ValueMember = "ID";
                    this.cmbCliente.DisplayMember = "NomeResumido";
                    this.cmbCliente.autoSize = true;
                    this.cmbCliente.Table = clientes;
                    this.cmbCliente.ColumnsToDisplay = new string[] { "FamiliaCliente", "NomeResumido" };
                    this.cmbCliente.HeadersToDisplay = new string[] { "Agrupador", "Nome Resumido" };

                    this.cmbCliente.SelectedIndex = 0;

                }


            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar os Clientes do Pedido\r\n" + e.Message, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ReportSource = this.conferenciaReport;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.crystalReportViewer1.ReportSource = this.opReport;
        }

        private void txtOc_Leave(object sender, EventArgs e)
        {
            try
            {

                this.carregaClientes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

   

        private void txtPos_Leave(object sender, EventArgs e)
        {
            try
            {

                this.carregaClientes();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
