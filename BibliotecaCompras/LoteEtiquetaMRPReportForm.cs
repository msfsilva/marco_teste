#region Referencias

using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaProdutos;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaCompras
{
    public partial class LoteEtiquetaMRPReportForm : IWTBaseForm
    {
        readonly List<LoteClass> Lotes;
        readonly string internalLabelPrinter;
        readonly string internalLabelPaper;
        private readonly IWTPostgreNpgsqlConnection conn;

        public LoteEtiquetaMRPReportForm(List<LoteClass> Lotes, IWTPostgreNpgsqlConnection conn, string internalLabelPrinter, string internalLabelPaper)
        {
            InitializeComponent();

            this.Lotes = Lotes;
            this.internalLabelPaper = internalLabelPaper;
            this.internalLabelPrinter = internalLabelPrinter;
            this.conn = conn;
        }

        public void printReport()
        {
            try
            {
                List<LoteEtiquetaMRPReportClass> toPrint = new List<LoteEtiquetaMRPReportClass>();
                foreach (LoteClass lote in Lotes.Where(a =>
                     (a.Produto != null && a.Produto.PoliticaEstoque == PoliticaEstoque.MRP) ||
                     (a.Material != null && a.Material.PoliticaEstoque == PoliticaEstoque.MRP)))
                {
                    if (lote.Produto != null)
                    {
                        toPrint.AddRange(from solicitacao in lote.solicitacoesCompraAtuais
                                         from pedido in solicitacao.Solicitacao.Pedidos
                                         select
                                             new LoteEtiquetaMRPReportClass(pedido.IdPedidoItem, pedido.Quantidade,
                                                                            lote.Numero, lote.IDClean));
                    }
                    else
                    {

                        toPrint.AddRange(from solicitacao in lote.solicitacoesCompraAtuais
                                         from pedido in solicitacao.Solicitacao.Pedidos
                                         select
                                             new LoteEtiquetaMRPReportClass(pedido.IdPedidoItem, pedido.Quantidade,
                                                                            lote.Numero, lote.IDClean));


                    }
                }
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                foreach (LoteEtiquetaMRPReportClass etiquetaMrpReport in toPrint)
                {
                    etiquetaMrpReport.Load(ref command);
                }
                
                LoteEtiquetaMRPReport rep = new LoteEtiquetaMRPReport();
                rep.SetDataSource(toPrint);

                rep.Refresh();
                
                try
                {
                    int j;
                    Boolean found1 = false;
                    string PaperList = "";
                    int rawKind1 = 0;
                    PrintDocument doctoprint = new PrintDocument();
                    doctoprint.PrinterSettings.PrinterName = internalLabelPrinter;

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
                        rep.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;
                        rep.PrintOptions.PaperSize = (PaperSize)rawKind1;
                    }
                }
                catch (Exception r)
                {
                    MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.crystalReportViewer1.ReportSource = rep;

            }
            catch (Exception a)
            {
                this.Close();
                throw new Exception("Erro ao gerar as etiquetas.\r\n" + a.Message, a);
            }

        }

        private void LoteEtiquetaMRPReportForm_Shown(object sender, EventArgs e)
        {
            this.printReport();
        }


    }
}
