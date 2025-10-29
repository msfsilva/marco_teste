#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ModuloEtiquetasInternas;
using Npgsql;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaEmissaoEtiquetas
{
    public partial class EtiquetaInternaKanbanReportForm : IWTBaseForm
    {
        //private string cod;
        //private string descr;
        //private string med;
        //private string desenho;
        //private int quant;
        private readonly List<ItemQtd> list =  new List<ItemQtd>();
        readonly IWTPostgreNpgsqlConnection conn;
        readonly Ref<string> seqInterna;
        readonly AcsUsuarioClass Usuario;



        public EtiquetaInternaKanbanReportForm(List<ItemQtd> listParam, ref Ref<string> seqInterna, string internalLaberPrinter, string internalLabelPaper, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            InitializeComponent();
            this.conn = conn;
            this.seqInterna = seqInterna;
            this.Usuario = Usuario;

            list = listParam;
            PrintEtiquetas(internalLaberPrinter, internalLabelPaper);
            //seqInterna = this.seqInterna;

        }
        private void PrintEtiquetas(string internalLaberPrinter, string internalLabelPaper)
        {
            string tempDir = Environment.GetEnvironmentVariable("temp");

            Process process = new Process();
            process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

            EtiquetaInternaDataSet ds = new EtiquetaInternaDataSet();

            byte[] logoEmpresa = EtiquetaInternaCustomizadoReportForm.BuscarLogoEmpresa(false);

            foreach (ItemQtd item in list)
            {              
                //Dicionario de codigos de barras
                string idCodigoBarras = "";
                try
                {
                    //busca se tem
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText = "SELECT id_codigo_barra FROM codigo_barra WHERE cob_codigo_item='" + item.codigo + "' AND cob_dimensao='" + item.dimensao + "' AND cob_qtd_por_etiqueta = " + item.qtdPorEtiqueta.ToString("F2", CultureInfo.InvariantCulture) + " ;";
                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                    read.Read();
                    if (read.HasRows)
                    {
                        idCodigoBarras = read["id_codigo_barra"].ToString();
                    }
                    else 
                    { 
                        read.Close();
                        command.CommandText = "INSERT INTO codigo_barra (cob_codigo_item, cob_dimensao,cob_qtd_por_etiqueta) VALUES ('" + item.codigo + "','" + item.dimensao + "'," + item.qtdPorEtiqueta.ToString("F2", CultureInfo.InvariantCulture) + ") RETURNING id_codigo_barra";
                        idCodigoBarras = command.ExecuteScalar().ToString();

                        //command.CommandText = "SELECT id_codigo_barra FROM codigo_barra WHERE cob_codigo_item='" + item.codigo + "' AND cob_dimensao='" + item.dimensao + "'";
                        //read = command.ExecuteReader();
                        //read.Read();

                        //idCodigoBarras = read["id_codigo_barra"].ToString();
                    }
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Erro na geração do código de barras.\r\n" + ee.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Anterior
                //process.StartInfo.Arguments = "IK|" + idCodigoBarras + " " + tempDir + "\\code.bmp";

                //Busca o sequencial
                int sequencial;
                if (int.TryParse(this.seqInterna.Value, out sequencial))
                {
                    //sequencial++;
                }
                else
                {
                    sequencial = 0;
                }

               
                EtiquetaInternaDataSet.EtiquetaInternaKRow row;

                for (int i = item.qtd; i > 0 ; i--)
                {
                    sequencial++;
                    if (sequencial > 9999)
                    {
                        sequencial = 0;
                    }

                    row = ds.EtiquetaInternaK.NewEtiquetaInternaKRow();
                    row["codigo_item"] = item.codigo;
                    if (item.dimensao == "0")
                    {
                        row["medida_item"] = "FIXO";
                    }
                    else
                    {
                        row["medida_item"] = item.dimensao;
                    }
                    
                    row.desenho = item.desenho;
                    row.qtd_por_etiqueta = item.qtdPorEtiqueta;
                    row.usuario = this.Usuario.Login;
                    row.nEtiqueta = i;
                    row.nTotalEtiquetas = item.qtd;
                    row.logoEmpresa = logoEmpresa;

                    process.StartInfo.Arguments = "IK|" + idCodigoBarras + "|" + sequencial.ToString() + " " + tempDir + "\\code.bmp";

                    //------------------ anterior
                    //process.StartInfo.Arguments = "IK|" + item.codigo + "|" + item.dimensao + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    row["barcode"] = array;
                    ds.EtiquetaInternaK.AddEtiquetaInternaKRow(row);
                }
                this.seqInterna.Value = sequencial.ToString();
                
            }

          


            EtiquetaInternaKReport report = new EtiquetaInternaKReport();
            report.SetDataSource(ds);
            report.Refresh();

            try
            {
                int j;
                Boolean found1 = false;
                string PaperList = "";
                int rawKind1 = 0;
                PrintDocument doctoprint = new PrintDocument();
                doctoprint.PrinterSettings.PrinterName = internalLaberPrinter;
                report.PrintOptions.PrinterName = doctoprint.PrinterSettings.PrinterName;

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
    }
}
