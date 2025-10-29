#region Referencias

using System;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using dbProvider;
using Image = System.Drawing.Image;

#endregion

namespace BibliotecaExpedicao
{
    public partial class ReimprimirReletorioPalletForm : IWTBaseForm
    {
        private byte[] logoEmpresa;

        public ReimprimirReletorioPalletForm()
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

        private void gerarReport()
        {
            try
            {
                PalletReportDataSet ds = new PalletReportDataSet();
                PalletReportDataSet.palletRow row;

                PalletConferencia pallet = new PalletConferencia(Convert.ToInt32(this.nudNumeroPallet.Value), DbConnection.Connection);

                if (IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET) && !pallet.Conferido)
                {
                    throw new Exception("O pallet deve estar conferido.");
                }

                if (!pallet.Fechado )
                {
                    throw new Exception("O pallet deve estar fechado.");
                }

                                    string tempDir = Environment.GetEnvironmentVariable("temp");

                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";


                    process.StartInfo.Arguments = "IP2|" + pallet.Numero.ToString() + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta_conferencia.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos, " +
                    "  public.order_item_etiqueta_conferencia.oic_volumes, " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia, " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario, " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario, "+
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_data " +
                    "FROM " +
                    "  public.order_item_etiqueta_conferencia " +
                    "WHERE " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet = :oic_pallet AND " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet_sequencia = :oic_pallet_sequencia AND " +
                     "  public.order_item_etiqueta_conferencia.oic_conferencia_pai =1  " +
                    "ORDER BY " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number, " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = pallet.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet_sequencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = pallet.Sequencia;

               
                string usuarioConferenciaPallet = LoginClass.UsuarioLogado.loggedUser.ToString();
                DateTime dataConferenciaPallet = Configurations.DataIndependenteClass.GetData();
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    usuarioConferenciaPallet = read["oic_conferencia_pallet_usuario"].ToString();
                    dataConferenciaPallet = Convert.ToDateTime(read["oic_conferencia_pallet_data"]);



                    int volumes = 1;
                    if (read["oic_volumes"] != DBNull.Value)
                    {
                        volumes = Convert.ToInt32(read["oic_volumes"]);
                    }

                    for (int i = 1; i <= volumes; i++)
                    {
                        row = ds.pallet.NewpalletRow();
                        row.codItem = read["oic_codigo_item"].ToString();
                        row.codigBarrasPallet = array;
                        row.conferidor = read["oic_identificacao_usuario"].ToString();
                        if (read["oic_data_conferencia"] == DBNull.Value)
                        {
                            row.dataConferencia = Convert.ToDateTime(read["oic_data_conferencia"]);
                        }

                        row.logoEmpresa = logoEmpresa;
                        row.numPallet = pallet.Numero;
                        row.oc = read["oic_order_number"].ToString();
                        row.pos = Convert.ToInt32(read["oic_order_pos"]);
                        row.totalVolumes = volumes;
                        row.volume = i;

                        ds.pallet.AddpalletRow(row);
                    }

                }
                read.Close();

                PalletReport rep = new PalletReport();
                rep.SetDataSource(ds);
                rep.Subreports[0].SetDataSource(ds);
                rep.Refresh();

                rep.SetParameterValue("ImpressoEm", "Impresso por " + LoginClass.UsuarioLogado.loggedUser.Login + " em " + DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss"));
                rep.SetParameterValue("conf", usuarioConferenciaPallet + " em " + dataConferenciaPallet.ToString("dd/MM/yyyy HH:mm:ss"));

                this.crystalReportViewer1.ReportSource = rep;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + e.Message, e);
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.gerarReport();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
