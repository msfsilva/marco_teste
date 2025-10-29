#region Referencias

using IWTDotNetLib;

#endregion

namespace BibliotecaCNC
{
    public partial class CNCReportForm : IWTBaseForm
    {
        public CNCReportForm(CNCReport rep)
        {
            InitializeComponent();

            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.Refresh();
        }
    }
}
