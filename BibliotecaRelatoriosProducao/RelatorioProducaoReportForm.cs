#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioProducaoReportForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public RelatorioProducaoReportForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void RelatorioProducaoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                RelatorioPedidosProdutosTempClass relat = new RelatorioPedidosProdutosTempClass(this.conn);
                RelatoriosPedidosProdutosTempReport rep = new RelatoriosPedidosProdutosTempReport();

                rep.SetDataSource(relat.gerarRelatorio());

                this.crystalReportViewer1.ReportSource = rep;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
