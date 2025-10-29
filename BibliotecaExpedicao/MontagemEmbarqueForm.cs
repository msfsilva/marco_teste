#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using ProjectConstants;

#endregion

namespace BibliotecaExpedicao
{
    public partial class MontagemEmbarqueForm : IWTBaseForm
    {
        EmbarqueClass embarque = null;
        const string AREA_NAME = "MONTAGEM_EMBARQUE";
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        private readonly string _impressoraRelatorioEmbarque;
        private readonly byte[] logoEmpresa;

        public MontagemEmbarqueForm(byte[] logo, string impressoraRelatorioEmbarque, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.Usuario = Usuario;
            this.conn = conn;
            this._impressoraRelatorioEmbarque = impressoraRelatorioEmbarque;

            #region Logo

            logoEmpresa = logo;

            if (logoEmpresa != null)
            {
                MemoryStream ms = new MemoryStream(logoEmpresa);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                logoEmpresa = ms.ToArray();
            }


            #endregion

            AjusteSituacaoPalletsMarretada();

            this.ResetForm();
            this.loadComboTransporte();
        }

        private void AjusteSituacaoPalletsMarretada()
        {
            IWTPostgreNpgsqlCommand command = null;

            try
            {
                command = SingleConnection.CreateCommand();
                command.Transaction = command.Connection.BeginTransaction();

                command.CommandText =
                    "SELECT " +
                    "   public.pallet.id_pallet, " +
                    "   public.pallet.pal_numero, " +
                    "   public.pallet.pal_sequencia, " +
                    "   public.pallet.pal_ocupado, " +
                    "   public.pallet.pal_fechado, " +
                    "   public.pallet.pal_conferido, " +
                    "   sit_conf_pallet " +
                    "       FROM " +
                    "   public.pallet " +
                    "       JOIN  " +
                    "      ( " +
                    "       SELECT  " +
                    "   public.order_item_etiqueta_conferencia.oic_pallet, " +
                    "   public.order_item_etiqueta_conferencia.oic_pallet_sequencia, " +
                    "   MIN(public.order_item_etiqueta_conferencia.oic_conferencia_pallet) as sit_conf_pallet " +
                    "       FROM " +
                    "   public.order_item_etiqueta_conferencia " +
                    "       WHERE " +
                    "   public.order_item_etiqueta_conferencia.oic_nf_emitida = 0 AND  " +
                    "   public.order_item_etiqueta_conferencia.id_embarque IS NULL " +
                    "       GROUP BY " +
                    "   public.order_item_etiqueta_conferencia.oic_pallet, " +
                    "   public.order_item_etiqueta_conferencia.oic_pallet_sequencia " +
                    "       HAVING  " +
                    "   MIN(public.order_item_etiqueta_conferencia.oic_conferencia_pallet) = 1 " +
                    "   ) as peds_problema ON peds_problema.oic_pallet =  public.pallet.pal_numero AND  public.pallet.pal_sequencia = peds_problema.oic_pallet_sequencia " +
                    "       WHERE " +
                    "   public.pallet.pal_especial = 0 AND  " +
                    "   public.pallet.pal_conferido = 0 AND  " +
                    "   public.pallet.pal_ocupado = 1 AND  " +
                    "   public.pallet.pal_fechado = 1";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    PalletClass pallet = PalletClass.GetEntidade(Convert.ToInt64(read["id_pallet"]), LoginClass.UsuarioLogado.loggedUser, SingleConnection);
                    pallet.Conferido = true;
                    pallet.Save(ref command);
                }

                command.Transaction.Commit();
            }
            catch
            {
                command?.Transaction?.Rollback();
            }


        }

        private void ResetForm()
        {
            this.timerItem.Enabled = false;
            this.grbItem.Enabled = true;
            this.grbModoOperacao.Enabled = true;
            this.btnSalvar.Enabled = true;
            this.txtBarcodeOc.Text = "";
            this.lstInseridos.Items.Clear();
            this.cmbTransporte.SelectedValue = -1;
            this.chkTransporte.Checked = false;

            this.embarque = new EmbarqueClass(this.Usuario ,this.conn);
            this.txtBarcodeOc.Focus();
        }

        private void loadComboTransporte()
        {
            try
            {
                string sql =
                    "SELECT  " +
                    "  public.transporte.id_transporte, "+
                    "  public.transporte.trp_identificacao || ' - ' || "+
                    "  public.transporte.trp_descricao as ident  "+
                    "FROM "+
                    "  public.transporte "+
                    "ORDER BY "+
                    "  public.transporte.trp_identificacao ";


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = ds.Tables[0];
                    this.cmbTransporte.DataSource = binding;
                    this.cmbTransporte.ValueMember = "id_transporte";
                    this.cmbTransporte.DisplayMember = "ident";


                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados de transporte\r\n" + e.Message, e);
            }
        }

        private void loadLists()
        {
            this.lstInseridos.Items.Clear();
          

            foreach (EmbarqueItemClass item in this.embarque.itens.Where(a=>a.ConferenciaPai))
            {
                this.lstInseridos.Items.Add(item.ToString());
            }
        }

        private void insereItem(string barcode)
        {
            barcode = barcode.Trim().Replace("\r\n", "");

            if (barcode != "")
            {
                try
                {
                    string aviso = this.embarque.inserirItem(barcode);
                    SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                    simpleSound.Play();

                    if (aviso.Length > 0)
                    {
                        MessageBox.Show(this, aviso, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception a)
                {
                    if (a.Message.ToUpper().Contains("BROKEN"))
                    {
                        MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit();
                        return;
                    }
                    else
                    {
                        SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                        simpleSound.Play();
                        MessageBox.Show(this, "Erro ao inserir o item.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                this.loadLists();
                this.txtBarcodeOc.Text = "";
                this.txtBarcodeOc.Focus();
            }

        }

        private void SalvarConferencia()
        {
            try
            {
                if (this.cmbTransporte.Enabled)
                {
                    if (this.cmbTransporte.SelectedValue == null)
                    {
                        throw new Exception("Selecione um transporte ou desative o campo de seleção.");
                    }

                    this.embarque.idTransporte = Convert.ToInt32(this.cmbTransporte.SelectedValue);
                }
                else
                {
                    this.embarque.idTransporte = null;
                }



                bool conferenciaSimplificada = !IWTConfiguration.Conf.getBoolConf(Constants.EXIGIR_CONFERENCIA_PALLET);

                if (conferenciaSimplificada)
                {
                    this.embarque.liberarEmbarque(LoginClass.UsuarioLogado.loggedUser);
                }


                this.embarque.Save();

                if (!conferenciaSimplificada)
                {
                    EmbarqueReportClass tmp;
                    List<EmbarqueReportClass> ds = new List<EmbarqueReportClass>();
                    Dictionary<string, EmbarqueReportClass> palletsInseridos = new Dictionary<string, EmbarqueReportClass>();

                    string tempDir = Environment.GetEnvironmentVariable("temp");

                    Process process = new Process();
                    process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                    process.StartInfo.Arguments = "IE|" + this.embarque.idEmbarque + " " + tempDir + "\\code.bmp";
                    process.Start();
                    process.WaitForExit();

                    FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                    BinaryReader br = new BinaryReader(fs);
                    Byte[] array = br.ReadBytes((int) fs.Length);
                    br.Close();
                    fs.Close();


                    foreach (EmbarqueItemClass item in this.embarque.itens)
                    {
                       
                        if (item.palletEspecial)
                        {
                            tmp = new EmbarqueReportClass();
                            tmp.Item = item.OC + "/" + item.pos + " - " + item.codItem;
                            tmp.NumeroBc = array;
                            tmp.Numero = int.Parse(this.embarque.idEmbarque);
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
                                    tmp.Numero = int.Parse(this.embarque.idEmbarque);
                                    tmp.Conferidor = item.Conferidor;
                                    tmp.Quantidade = item.Quantidade;

                                    tmp.LogoEmpresa = this.logoEmpresa;

                                    tmp.DataConferencia = item.DataConferencia != null ? ((DateTime) item.DataConferencia).ToString("dd/MM/yyyy HH:mm:ss") : "";
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

                    ReportDocument report = new EmbarqueReport();
                    report.SetDataSource(ds);
                    report.Refresh();

                    report.SetParameterValue("ImpressoEm", "Impresso por " + Usuario.Login + " em " + DataIndependenteClass.GetData().ToString("dd/MM/yyyy HH:mm:ss"));
                    IWTFunctions.IWTFunctions.DefineImpressoraReport(ref report, _impressoraRelatorioEmbarque, "A4");
                    report.PrintToPrinter(1, false, 0, 99999);

                }

            }
            catch (Exception a)
            {
                if (a.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Erro ao salvar as informações do embarque.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            this.ResetForm();
            this.Close();

        }

        #region Eventos

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.insereItem(this.txtBarcodeOc.Text);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Você deseja encerrar e salvar o embarque?", "Encerramento de Embarque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.SalvarConferencia();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }

        private void timerItem_Tick(object sender, EventArgs e)
        {
            if (this.rdbBarCode.Checked)
            {
                this.timerItem.Enabled = false;
                this.insereItem(this.txtBarcodeOc.Text);
            }
        }

        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            this.btnItem.Enabled = rdbManual.Checked;
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            this.btnItem.Enabled = rdbManual.Checked;
        }
  

        private void txtBarcodeOc_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
            {
                this.btnItem_Click(null, null);
            }
        }
       

        private void txtBarcodeOc_TextChanged_1(object sender, EventArgs e)
        {
            timerItem.Stop();
            timerItem.Start();
        }

        private void chkTransporte_CheckedChanged(object sender, EventArgs e)
        {
            this.cmbTransporte.Enabled = this.chkTransporte.Checked;
        }
        #endregion
    }
}
