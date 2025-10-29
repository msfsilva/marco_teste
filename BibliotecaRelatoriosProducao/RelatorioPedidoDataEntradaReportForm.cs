#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioPedidoDataEntradaReportForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly DateTime? Inicio;
        readonly DateTime? Fim;
        private readonly bool _incluirCancelados;
        private readonly bool _ordernarDataEntrega;
        public bool abort { get; private set; }
        public RelatorioPedidoDataEntradaReportForm(DateTime? Inicio, DateTime? Fim, bool incluirCancelados,bool ordernarDataEntrega, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.Inicio = Inicio;
            this.Fim = Fim;
            _incluirCancelados = incluirCancelados;
            _ordernarDataEntrega = ordernarDataEntrega;
        }

        private void RelatorioPedidoDataEntradaReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                RelatorioPedidoDataEntradaClass relat = new RelatorioPedidoDataEntradaClass(this.conn);
                RelatorioPedidoDataEntradaReport rep = new RelatorioPedidoDataEntradaReport();

                rep.SetDataSource(relat.gerarRelatorio(this.Inicio, this.Fim, _incluirCancelados, _ordernarDataEntrega));

                this.crystalReportViewer1.ReportSource = rep;
                this.crystalReportViewer1.Refresh();
            }
            catch (Exception a)
            {
                this.abort = true;
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
