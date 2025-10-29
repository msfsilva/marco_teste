#region Referencias

using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IWTDotNetLib;
using ModuloEtiquetasInternas;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaPalletReportForm : IWTBaseForm
    {

        public EtiquetaInternaPalletReportForm(decimal ini, decimal fim, string expeditionPrinter, string expeditionPaper)
        {
            InitializeComponent();
            this.FillReport(ini, fim, expeditionPrinter, expeditionPaper);
        }

        private void FillReport(decimal ini, decimal fim, string expeditionPrinter, string expeditionPaper)
        {
            string tempDir = Environment.GetEnvironmentVariable("temp");

            EtiquetaPalletDataSet ds = new EtiquetaPalletDataSet();

            Process process = new Process();
            process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";




            for (int i = (int)ini; i <= (int)fim; i++)
            {


                //IP|NUMERO_PALLET
                process.StartInfo.Arguments = "IP|" + i.ToString("D2") + " " + tempDir + "\\code.bmp";
                process.Start();
                process.WaitForExit();

                Bitmap codeBar = new Bitmap(@tempDir + "\\code.bmp");
                codeBar.RotateFlip(RotateFlipType.Rotate90FlipNone);
                codeBar.Save(@tempDir + "\\code.bmp");

                FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] array = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

                EtiquetaPalletDataSet.PalletRow row;


                row = ds.Pallet.NewPalletRow();

                row.barcode = array;
                row.numero = i.ToString("D2");


                ds.Pallet.AddPalletRow(row);

            }


            EtiquetaPalletReport report = new EtiquetaPalletReport();
            report.SetDataSource(ds);
            report.Refresh();


            try
            {
                int j;
                Boolean found1 = false;
                string PaperList = "";
                int rawKind1 = 0;
                PrintDocument doctoprint = new PrintDocument();
                doctoprint.PrinterSettings.PrinterName = expeditionPrinter;

                if (!doctoprint.PrinterSettings.IsValid)
                {
                    string PrinterList = "Você deve selecionar entre uma das impressoras abaixo, coloca-la na configuração e gerar o relatório novamente.\r\n";
                    foreach (string strPrinter in PrinterSettings.InstalledPrinters)
                    {
                        PrinterList += "\r\n" + strPrinter;
                    }
                    MessageBox.Show("Impressora de Etiquetas não encontrada!\r\n\r\n" + PrinterList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    PrinterSettings.PaperSizeCollection paperSizeCollection = doctoprint.PrinterSettings.PaperSizes;

                    for (j = 0; j < paperSizeCollection.Count; j++)
                    {

                        PaperList += "\r\n" + paperSizeCollection[j].PaperName;
                        if (paperSizeCollection[j].PaperName == expeditionPaper)
                        {
                            rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                            found1 = true;
                        }
                    }

                    if (!found1)
                    {
                        MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    report.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                    report.PrintOptions.PaperSize = (PaperSize)rawKind1;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            this.crystalReportViewer1.ReportSource = report;
        }
    }
}
