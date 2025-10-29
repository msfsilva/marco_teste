using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.ClassesAuxiliares;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using dbProvider;

namespace BibliotecaPedidos
{
    public partial class PedidoEspelhoReportForm : IWTBaseForm
    {
        private List<PedidoEspelhoParametrosBuscaClass> parametros = null;
        private PedidoOrcamento tipoRelatorio;

        public PedidoEspelhoReportForm(List<PedidoEspelhoParametrosBuscaClass> parametros, PedidoOrcamento tipo)
        {
            this.parametros = parametros;
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
            tipoRelatorio = tipo;
            if(tipoRelatorio == PedidoOrcamento.Orcamento)
            {
                this.Text = "Orçamento";
            }else
            {
                this.Text = "Pedido";
            }
        }


        private void gerarRelatorio()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();

                List<PedidoEspelhoClass> dados = PedidoEspelhoClass.gerar(parametros, this.tipoRelatorio,chkExibirValores.Checked, ref command);
                PedidoEspelhoReport report = new PedidoEspelhoReport();
                report.SetDataSource(dados);
                this.crystalReportViewer1.ShowLogo = false;
                this.crystalReportViewer1.ReportSource = report;
            }
            catch(Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PedidoEspelhoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                gerarRelatorio();
            }
            catch(Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkExibirValores_CheckedChanged(object sender, EventArgs e)
        {
             try
            {
               gerarRelatorio();
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
