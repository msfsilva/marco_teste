#region Referencias

using IWTDotNetLib;

#endregion

namespace BibliotecaExpedicao
{
    public partial class EtiquetaInternaViewForm : IWTBaseForm
    {
        public EtiquetaInternaViewForm(EtiquetaInternaReport etiqueta)
        {
            InitializeComponent();
            crystalReportViewer1.ReportSource = etiqueta;
            crystalReportViewer1.Refresh();
        }
    }
}
