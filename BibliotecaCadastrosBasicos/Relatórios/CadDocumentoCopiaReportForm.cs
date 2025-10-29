#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class CadDocumentoCopiaReportForm : IWTBaseForm
    {
        readonly DocumentoCopiaClass Copia;
        readonly string Printer;
        readonly string Paper;
        public CadDocumentoCopiaReportForm(DocumentoCopiaClass Copia)
        {
            InitializeComponent();
            this.Copia = Copia;
            this.Printer = Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.INTERNAL_LABEL_PRINTER);
            this.Paper = Configurations.IWTConfiguration.Conf.getConf(ProjectConstants.Constants.INTERNAL_LABEL_PAPER); 

            this.generateReport();
        }

        private void generateReport()
        {

            try
            {
                DocumentoCopiaReport rep = new DocumentoCopiaReport();
                rep.SetDataSource(new List<DocumentoCopiaReportClass> { new DocumentoCopiaReportClass(this.Copia) });

                rep.Refresh();

                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = this.Printer;

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
                            if (paperSizeCollection[j].PaperName == this.Paper)
                            {
                                rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                                found1 = true;
                            }
                        }

                        if (!found1)
                        {
                            MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        rep.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                        rep.PrintOptions.PaperSize = (PaperSize)rawKind1;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.crystalReportViewer1.ReportSource = rep;


                rep.PrintToPrinter(1, false, 0, 99999);
                
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }

        }
    }
}
