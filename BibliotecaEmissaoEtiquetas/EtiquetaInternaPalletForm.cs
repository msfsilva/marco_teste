#region Referencias

using System;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaPalletForm : IWTBaseForm
    {
        readonly string expeditionPrinter;
        readonly string expeditionPaper;
        public EtiquetaInternaPalletForm(string expeditionPrinter, string expeditionPaper, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.expeditionPaper = expeditionPaper;
            this.expeditionPrinter = expeditionPrinter;

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT MAX(p.pal_numero) FROM pallet p ";
            this.nudFim.Maximum = Convert.ToDecimal(command.ExecuteScalar());
            this.nudInicio.Maximum = this.nudFim.Maximum;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EtiquetaInternaPalletReportForm form = new EtiquetaInternaPalletReportForm(this.nudInicio.Value, this.nudFim.Value, this.expeditionPrinter, this.expeditionPaper);
            form.ShowDialog();
            this.Close();
        }
    }
}
