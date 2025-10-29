#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using iTextSharp.text.pdf;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaIdentificacaoProdutosReportForm : IWTBaseForm
    {
        readonly List<ItemQtdEtiquetaIdentificacao> listParam;
        readonly string internalLaberPrinter;
        readonly string internalLabelPaper;
        IWTPostgreNpgsqlConnection conn;
        private byte[] logoEmpresa;

        public EtiquetaIdentificacaoProdutosReportForm(List<ItemQtdEtiquetaIdentificacao> listParam, string internalLaberPrinter, string internalLabelPaper, byte[] logoEmpresa,  IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;

            this.listParam = listParam;
            this.internalLaberPrinter = internalLaberPrinter;
            this.internalLabelPaper = internalLabelPaper;

            #region Logo

            byte[] tmp = logoEmpresa;

            if (logoEmpresa != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                //imagem.Save("C:\\teste.bmp");
                this.logoEmpresa = tmp = ms.ToArray();
            }


            #endregion
            
        }

        private void PrintEtiquetas()
        {
            string tempDir = Environment.GetEnvironmentVariable("temp");



            List<ItemQtdEtiquetaIdentificacao> toReport = new List<ItemQtdEtiquetaIdentificacao>();
            foreach (ItemQtdEtiquetaIdentificacao item in this.listParam)
            {


                for (int i = item.qtdEtiquetas; i > 0; i--)
                {

                    ItemQtdEtiquetaIdentificacao tmp = new ItemQtdEtiquetaIdentificacao();
                    tmp.Codigo = item.Codigo;
                    tmp.Descricao = item.Descricao;
                    tmp.codigoCliente = item.codigoCliente;
                    tmp.qtdPorEtiquetas = item.qtdPorEtiquetas;
                    tmp.nEtiqueta = i;
                    tmp.Usuario = item.Usuario;
                    tmp.qtdEtiquetas = item.qtdEtiquetas;
                    tmp.observacao = item.observacao;
                    tmp.logoEmpresa = logoEmpresa;
                    tmp.Gtin = item.Gtin;

                    Barcode128 code128 = new Barcode128();
                    code128.CodeType = Barcode.CODE128;
                    code128.ChecksumText = true;
                    code128.GenerateChecksum = true;
                    code128.StartStopText = true;
                    code128.BarHeight = 85;
                    if (string.IsNullOrWhiteSpace(tmp.Gtin))
                    {


                        code128.Code = "EI" + item.idProduto;
                    }
                    else
                    {


                        code128.Code = tmp.Gtin;
                    }

                    tmp.barcodeTexto = code128.Code;
                    Bitmap codeBar = new Bitmap(code128.CreateDrawingImage(Color.Black, Color.White));
                    ImageConverter converter = new ImageConverter();
                    byte[] array = (byte[]) converter.ConvertTo(codeBar, typeof (byte[]));


                    tmp.barcode = array;
                    toReport.Add(tmp);
                }


            }




            EtiquetaIdentificacaoProdutosReport report = new EtiquetaIdentificacaoProdutosReport();
            report.SetDataSource(toReport);
            report.Refresh();

            try
            {
                int j;
                Boolean found1 = false;
                string PaperList = "";
                int rawKind1 = 0;
                PrintDocument doctoprint = new PrintDocument();
                doctoprint.PrinterSettings.PrinterName = internalLaberPrinter;

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
                        if (paperSizeCollection[j].PaperName == internalLabelPaper)
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

        private void EtiquetaIdentificacaoProdutosReportForm_Shown(object sender, EventArgs e)
        {
            this.PrintEtiquetas();
        }
    }
}
