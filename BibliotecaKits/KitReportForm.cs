#region Referencias

using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;

#endregion

namespace ModuloKits
{
    public partial class KitReportForm : IWTBaseForm
    {
        public KitReportForm(ReportClass rep)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.Refresh();
        }

        public KitReportForm(SemKitReport rep)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.Refresh();
        } 

    }
}
