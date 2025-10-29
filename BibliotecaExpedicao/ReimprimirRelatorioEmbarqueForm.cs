using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using ProjectConstants;
using dbProvider;

namespace BibliotecaExpedicao
{
    public partial class ReimprimirRelatorioEmbarqueForm : IWTBaseForm
    {
        private byte[] logoEmpresa;
        public ReimprimirRelatorioEmbarqueForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;

            #region Logo

            this.logoEmpresa = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

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


        private void GenerateReport()
        {
            try
            {
                int idEmbarque;

                if (this.rdbUltimoEmbarque.Checked)
                {
                   idEmbarque = EmbarqueClass.getNumeroUltimoEmbarque();
                }
                else
                {
                    idEmbarque = Convert.ToInt32(this.nudNumeroEmbarque.Value);
                }

                EmbarqueClass embarque = EmbarqueClass.getEmbarque(idEmbarque.ToString(), LoginClass.UsuarioLogado.loggedUser, DbConnection.Connection);

                List<EmbarqueReportClass> ds = new List<EmbarqueReportClass>();
                EmbarqueReportClass tmp;
                Dictionary<string, EmbarqueReportClass> palletsInseridos = new Dictionary<string, EmbarqueReportClass>();

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                process.StartInfo.Arguments = "IE|" + embarque.idEmbarque + " " + tempDir + "\\code.bmp";
                process.Start();
                process.WaitForExit();

                FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                Byte[] array = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();


                foreach (EmbarqueItemClass item in embarque.itens)
                {

                    if (item.palletEspecial)
                    {
                        tmp = new EmbarqueReportClass();
                        tmp.Item = item.OC + "/" + item.pos + " - " + item.codItem;
                        tmp.NumeroBc = array;
                        tmp.Numero = int.Parse(embarque.idEmbarque);
                        tmp.Conferidor = item.Conferidor;
                        tmp.LogoEmpresa = this.logoEmpresa;
                        tmp.Quantidade = item.Quantidade;
                        tmp.DataConferencia = item.DataConferencia != null ? ((DateTime)item.DataConferencia).ToString("dd/MM/yyyy HH:mm:ss") : "";
                        ds.Add(tmp);
                    }
                    else
                    {
                        if (item.ConferenciaPai)
                        {
                            if (!palletsInseridos.ContainsKey(item.numPallet))
                            {
                                tmp = new EmbarqueReportClass();
                                tmp.Item = "Pallet: " + item.numPallet;
                                tmp.NumeroBc = array;
                                tmp.Numero = int.Parse(embarque.idEmbarque);
                                tmp.Conferidor = item.Conferidor;
                                tmp.LogoEmpresa = this.logoEmpresa;
                                tmp.Quantidade = item.Quantidade;

                                tmp.DataConferencia = item.DataConferencia != null ? ((DateTime)item.DataConferencia).ToString("dd/MM/yyyy HH:mm:ss") : "";
                                ds.Add(tmp);

                                palletsInseridos.Add(item.numPallet, tmp);
                            }
                            else
                            {
                                tmp = palletsInseridos[item.numPallet];
                                if (string.IsNullOrWhiteSpace(tmp.Conferidor))
                                {
                                    if (item.DataConferencia != null)
                                    {
                                        tmp.DataConferencia = item.DataConferencia != null ? ((DateTime)item.DataConferencia).ToString("dd/MM/yyyy HH:mm:ss") : "";
                                        tmp.Conferidor = item.Conferidor;
                                    }
                                }

                                tmp.Quantidade += item.Quantidade;

                            }
                        }
                    }
                }

                EmbarqueReport report = new EmbarqueReport();
                report.SetDataSource(ds);
                report.SetParameterValue("ImpressoEm", "Impresso por " + LoginClass.UsuarioLogado.loggedUser.Login + " em " + DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss"));

                this.crystalReportViewer1.ReportSource = report;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, "Erro ao gerar o relatório.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbUltimoEmbarque_CheckedChanged(object sender, EventArgs e)
        {
            this.nudNumeroEmbarque.Enabled = this.rdbEmbarqueNumero.Checked;
            this.GenerateReport();
        }

        private void rdbEmbarqueNumero_CheckedChanged(object sender, EventArgs e)
        {
            this.nudNumeroEmbarque.Enabled = this.rdbEmbarqueNumero.Checked;
            this.GenerateReport();
        }

        private void ReimprimirRelatorioEmbarqueForm_Shown(object sender, EventArgs e)
        {
            this.GenerateReport();

        }

        private void nudNumeroEmbarque_ValueChanged(object sender, EventArgs e)
        {
            this.GenerateReport();
        }

    }
}
