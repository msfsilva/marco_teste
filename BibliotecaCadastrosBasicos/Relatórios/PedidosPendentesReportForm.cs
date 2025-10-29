using System;
using System.Windows.Forms;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class PedidosPendentesReportForm : IWTBaseForm
    {
        public PedidosPendentesReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                PedidosPendentesReport rep = new PedidosPendentesReport();
                rep.SetDataSource(PedidosPendentesReportClass.generateReport(dtpIni.Value, dtpFim.Value,this.SingleConnection));
                AcsUsuarioClass user = LoginClass.UsuarioLogado.loggedUser;
                rep.SetParameterValue(0, "Impresso por " + user + " em " + Configurations.DataIndependenteClass.GetData().ToString("dd/MM/yyyy"));
                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception a)
            {
                MessageBox.Show("Erro ao gerar relatório.\r\n" + a.Message, "Relatório de Pedidos Pendentes",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
