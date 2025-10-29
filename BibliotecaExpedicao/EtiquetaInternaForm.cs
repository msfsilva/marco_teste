#region Referencias

using System;
using System.Data;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using PaperSize = CrystalDecisions.Shared.PaperSize;

#endregion

namespace BibliotecaExpedicao
{
    public partial class EtiquetaInternaForm : IWTBaseForm
    {
        private string idProduto;
        private string descProd;

        private readonly IWTPostgreNpgsqlConnection conn;
        readonly string internalLabelPrinter;
        readonly string internalLaberPaper;

        public EtiquetaInternaForm(string internalLabelPrinter, string internalLaberPaper, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.internalLabelPrinter = internalLabelPrinter;
            this.internalLaberPaper = internalLaberPaper;
            this.loadCombo();       
            
        }

        private void loadCombo()
        {
            IWTPostgreNpgsqlAdapter a1;
            DataSet ds1;
            BindingSource binding1;

            a1 = new IWTPostgreNpgsqlAdapter("SELECT codigo FROM produto ORDER BY codigo", conn);

            if (a1 != null)
            {
                ds1 = new DataSet();

                a1.Fill(ds1);

                binding1 = new BindingSource();
                binding1.DataSource = ds1.Tables[0];
                binding1.Sort = "codigo";

                cmbProduto.DataSource = binding1;
                this.cmbProduto.DisplayMember = "codigo";
                this.cmbProduto.ValueMember = "codigo";
            }
        }        

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT descricao FROM produto";
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                read.Read();
                this.descProd = read["descricao"].ToString();

                this.idProduto = cmbProduto.SelectedValue.ToString();
            }
            catch (Exception x)
            {
                MessageBox.Show("Erro ao buscar descricao do produto. \r\n" + x, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }  

            string qtdEtiquetas = txtQtdEtiquetas.Value.ToString();
            EtiquetaInternaReport etiqueta = new EtiquetaInternaReport();
            string tempDir = Environment.GetEnvironmentVariable("temp");

            //criar barCode
            Process process = new Process();
            process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

            process.StartInfo.Arguments = idProduto.Replace(" ", "-") + " " + tempDir + "\\code.bmp"; ;
            process.Start();
            process.WaitForExit();

            FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
            BinaryReader br = new BinaryReader(fs);
            Byte[] array = br.ReadBytes((int)fs.Length);
            br.Close();
            fs.Close();
            //            
            EtiquetaInternaDataSet dataset = new EtiquetaInternaDataSet();           
            EtiquetaInternaDataSet.etiqueta_internaRow row;

            for (int i = 0; i < int.Parse(qtdEtiquetas); i++)
            {
                row = dataset.etiqueta_interna.Newetiqueta_internaRow();
                row["pro_descricao"] = descProd;
                row["bar_code"] = array;
                dataset.etiqueta_interna.Addetiqueta_internaRow(row);
            }
                       
            //Definindo papel correto
            try
            {
                int j;
                Boolean found1 = false;
                string PaperList = "";
                int rawKind1 = 0;
                PrintDocument doctoprint = new PrintDocument();
                doctoprint.PrinterSettings.PrinterName = this.internalLabelPrinter;

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
                        if (paperSizeCollection[j].PaperName == this.internalLaberPaper)
                        {
                            rawKind1 = (int)(paperSizeCollection[j].GetType().GetField("kind", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(paperSizeCollection[j]));
                            found1 = true;
                        }
                    }

                    if (!found1)
                    {
                        MessageBox.Show("Papel da Etiqueta não encontrado!\r\n Você deve selecionar entre os papeis abaixo, coloca-lo na configuração e gerar o relatório novamente.\r\n" + PaperList, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    etiqueta.PrintOptions.PaperSize = (PaperSize)rawKind1;
                }
            }
            catch (Exception r)
            {
                MessageBox.Show("Erro ao definir o tipo de papel correto! \r\n" + r, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            etiqueta.SetDataSource(dataset);
            EtiquetaInternaViewForm etiquetaView = new EtiquetaInternaViewForm(etiqueta);
            etiquetaView.Show();            

            


            

        }


    }
}
