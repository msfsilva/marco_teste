#region Referencias

using System;
using System.Media;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaExpedicao
{
    public partial class ConferenciaPalletForm : IWTBaseForm
    {
        ConferenciaPalletClass nfEmConferencia = null;
        const string AREA_NAME = "MODULO_CONFERENCIA_NF";
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        readonly string impressoraRelatorioPallet;

        private readonly byte[] logoEmpresa;

        public ConferenciaPalletForm(byte[] logo, string impressoraRelatorioPallet, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.logoEmpresa = logo;
            this.Usuario = Usuario;
            this.conn = conn;
            this.impressoraRelatorioPallet = impressoraRelatorioPallet;
        }

        private void ResetForm()
        {
            this.timerOC.Enabled = false;
            this.timerPallet.Enabled = false;
            this.grbCaixa.Enabled = true;
            this.grbItem.Enabled = false;
            this.grbModoOperacao.Enabled = true;
            this.btnSalvar.Enabled = false;
            this.nfEmConferencia = null;
            this.txtBarcodeOc.Text = "";
            this.txtBarcodePallet.Text = "";
            this.lstConferidos.Items.Clear();
            this.lstDisponiveis.Items.Clear();

            this.txtBarcodePallet.Focus();


        }

        private void loadCaixaInfo(string barcode)
        {
            barcode = barcode.Trim().Replace("\r\n", "");
            if (barcode != "")
            {
                try
                {
                    nfEmConferencia = new ConferenciaPalletClass(barcode, Environment.MachineName, this.impressoraRelatorioPallet, this.logoEmpresa, this.Usuario, this.conn);

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
                        MessageBox.Show(this, "Erro ao carregar as informações do Pallet.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.ResetForm();
                        return;
                    }
                }

                
                this.grbModoOperacao.Enabled = false;
                this.grbCaixa.Enabled = false;
                this.grbItem.Enabled = true;

                this.btnSalvar.Enabled = true;
                this.loadLists();

                this.txtBarcodeOc.Focus();
                

            }



        }

        private void loadLists()
        {
            this.lstConferidos.Items.Clear();
            this.lstDisponiveis.Items.Clear();

            foreach (ocConferenciaClass item in this.nfEmConferencia.Itens)
            {
                foreach (OcConferenciaVolumeClass volume in item.Volumes)
                {
                    if (volume.Conferido)
                    {
                        this.lstConferidos.Items.Add(item.Oc + "/" + item.Pos + " - " + item.codItem + " - volume: " + volume.NumeroVolume + "/" + item.qtdVolumes);
                    }
                    else
                    {
                        this.lstDisponiveis.Items.Add(item.Oc + "/" + item.Pos + " - " + item.codItem + " - volume: " + volume.NumeroVolume + "/" + item.qtdVolumes);
                    }

                }

                /*if (item.saldoVolumes > 0)
                {
                    
                }
                if (item.qtdVolumesConferidos > 0)
                {
                    
                }
                */
 

            }

            if (this.lstDisponiveis.Items.Count == 0)
            {
              
                this.SalvarConferencia();

            }
        }

        private void confereItem(string texto)
        {

            string[] linhas = texto.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string linha in linhas)
            {



                string barcode = linha.Trim().Replace("\r\n", "");

                if (barcode != "")
                {
                    try
                    {

                        nfEmConferencia.ConfereItem(barcode);
                        SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\certo.wav");
                        simpleSound.Play();

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
                            DialogResult res = DialogResult.No;

                            while (res != DialogResult.Yes)
                            {
                                SoundPlayer simpleSound = new SoundPlayer(@AppDomain.CurrentDomain.BaseDirectory + "\\errado.wav");
                                simpleSound.Play();


                                res = MessageBox.Show(this, "Erro ao conferir o item.\r\n" + a.Message + "\r\nMensagem Lida?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
                            }
                        }
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
                nfEmConferencia.Save();
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
                    MessageBox.Show(this, "Erro ao salvar as informações da conferência.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.ResetForm();
                    return;
                }
            }

            this.ResetForm();

        }

        #region Eventos
        private void txtBarcodePallet_TextChanged(object sender, EventArgs e)
        {
            timerPallet.Stop();
            timerPallet.Start();
        }

        private void btnPallet_Click(object sender, EventArgs e)
        {
            this.loadCaixaInfo(this.txtBarcodePallet.Text);
        }

        private void txtBarcodeOc_TextChanged(object sender, EventArgs e)
        {
            timerOC.Stop();
            timerOC.Start();
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            this.confereItem(this.txtBarcodeOc.Text);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.SalvarConferencia();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.ResetForm();
        }

        private void timerPallet_Tick(object sender, EventArgs e)
        {
            timerPallet.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                this.loadCaixaInfo(this.txtBarcodePallet.Text);
            }
        }

        private void timerOC_Tick(object sender, EventArgs e)
        {
            timerOC.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                this.confereItem(this.txtBarcodeOc.Text);
            }
        }
     

        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            this.btnPallet.Enabled = rdbManual.Checked;
            this.btnItem.Enabled = rdbManual.Checked;
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            this.btnPallet.Enabled = rdbManual.Checked;
            this.btnItem.Enabled = rdbManual.Checked;
        }
  
        private void txtBarcodePallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
            {
                this.btnPallet_Click(null, null);
            }
        }

        private void txtBarcodeOc_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
            {
                this.btnItem_Click(null, null);
            }
        }
        #endregion
    }
}
