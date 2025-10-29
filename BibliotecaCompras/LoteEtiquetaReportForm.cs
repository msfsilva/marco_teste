#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.Compras;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaCompras
{
    public partial class LoteEtiquetaReportForm : IWTBaseForm
    {
        readonly List<LoteClass> Lotes;
        //readonly string internalLabelPrinter;
        //readonly string internalLabelPaper;
        public LoteEtiquetaReportForm(List<LoteClass> Lotes, string internalLabelPrinter, string internalLabelPaper)
        {
            InitializeComponent();
            this.Lotes = Lotes;
            //this.internalLabelPaper = internalLabelPaper;
            //this.internalLabelPrinter = internalLabelPrinter;

           
        }

        public void printReport()
        {
            try
            {
                List<LoteClass> toPrint = new List<LoteClass>();
                foreach (LoteClass lote in Lotes)
                {
                    for (int i = 0; i < lote.qtdEtiquetas; i++)
                    {
                        toPrint.Add(lote);
                    }
                }

                LoteEtiquetaReport repM = null;
                LoteEtiquetaPequenaReport repP = null;

                

                string printer = "";
                string label_paper = "";
                if (IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_RECEBIMENTO) == "0")
                {
                    printer = IWTConfiguration.Conf.getConf(Constants.MEDIUM_LABEL_PRINTER);
                    label_paper = IWTConfiguration.Conf.getConf(Constants.MEDIUM_LABEL_PAPER);

                    repM = new LoteEtiquetaReport();
                    repM.SetDataSource(toPrint);

                    repM.Refresh();
                }
                else
                {
                    printer = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PRINTER);
                    label_paper = IWTConfiguration.Conf.getConf(Constants.INTERNAL_LABEL_PAPER);

                    repP = new LoteEtiquetaPequenaReport();
                    repP.SetDataSource(toPrint);

                    repP.Refresh();
                }
                
                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = printer;

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
                            if (paperSizeCollection[j].PaperName == label_paper)
                            {
                                rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                                found1 = true;
                            }
                        }

                        if (!found1)
                        {
                            MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_RECEBIMENTO) == "0")
                        {
                            repM.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                            repM.PrintOptions.PaperSize = (PaperSize) rawKind1;
                        }else
                        {
                            repP.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                            repP.PrintOptions.PaperSize = (PaperSize)rawKind1;
                        }
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (IWTConfiguration.Conf.getConf(Constants.TIPO_ETIQUETA_RECEBIMENTO) == "0")
                {
                    this.crystalReportViewer1.ReportSource = repM;
                }
                else
                {
                    this.crystalReportViewer1.ReportSource = repP;
                }
                
                
            }
            catch (Exception a)
            {
                this.Close();
                throw new Exception("Erro ao gerar as etiquetas.\r\n" + a.Message,a);
            }

        }

        private void LoteEtiquetaReportForm_Shown(object sender, EventArgs e)
        {
            this.printReport();
        }
    }
}
