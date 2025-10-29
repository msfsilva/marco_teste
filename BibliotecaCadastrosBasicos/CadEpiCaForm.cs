using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadEpiCaForm : IWTForm
    {

        public EpiCaClass EpiCa
        {
            get { return (EpiCaClass) this.Entity; }
        }

        public CadEpiCaForm(EpiCaClass entidade, CadEpiCaListForm listForm)
            : base(entidade, listForm, listForm.SingleConnection)
        {
            InitializeComponent();
        }

        public CadEpiCaForm(EpiCaClass entidade)
            : base(entidade, typeof(EpiCaClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }


        private void SelecioneDocumento()
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                if (this.ofdDocumento.ShowDialog() == DialogResult.OK)
                {
                    fs = new FileStream(this.ofdDocumento.FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    if (fs.Length > 10485760)
                    {
                        throw new Exception("O arquivo deve possuir menos de 10Mb");
                    }


                    this.EpiCa.Documento = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    this.EpiCa.NomeDocumento = new FileInfo(this.ofdDocumento.FileName).Name;


                    this.lnkDocumento.Text = "Baixar: " + this.EpiCa.NomeDocumento;
                    this.lnkDocumento.Visible = true;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o documento escaneado.\r\n" + e.Message, e);
            }
            finally
            {
                if (br != null)
                {

                    br.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }


        }

        private void DownloadDocumento()
        {
            FileStream fs = null;
            BinaryWriter bw = null;
            try
            {
                string tempDir = Environment.GetEnvironmentVariable("temp");
                if (tempDir != null)
                {




                    string nome = EpiCa.NomeDocumento;
                    byte[] documento = EpiCa.Documento;


                    fs = new FileStream(tempDir + "\\" + nome, FileMode.Create);
                    bw = new BinaryWriter(fs);
                    bw.Write(documento);
                    Process.Start(tempDir + "\\" + nome);


                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o documento escaneado\r\n" + e.Message, e);
            }
            finally
            {
                if (bw != null)
                {
                    bw.Close();
                }

                if (fs != null)
                {
                    fs.Close();
                }

            }
        }


        #region Eventos
        private void btnDocumentoEscaneado_Click(object sender, EventArgs e)
        {
            try
            {
                this.SelecioneDocumento();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkDocumento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                this.DownloadDocumento();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.Vencido.forceDisable();

            if (this.EpiCa.Documento != null)
            {
                this.lnkDocumento.Text = "Baixar: " + EpiCa.NomeDocumento;
                this.lnkDocumento.Visible = true;
            }
            else
            {
                this.lnkDocumento.Visible = false;
            }
        }

        private void Validade_ValueChanged(object sender, EventArgs e)
        {
            this.EpiCa.AtualizaVencido();
            this.Vencido.Checked = this.EpiCa.Vencido;
        }
    
        private void Validade_Validated(object sender, EventArgs e)
        {
            this.EpiCa.AtualizaVencido();
            this.Vencido.Checked = this.EpiCa.Vencido;
        }

        private void Validade_CloseUp(object sender, EventArgs e)
        {
            this.EpiCa.AtualizaVencido();
            this.Vencido.Checked = this.EpiCa.Vencido;
        }
        #endregion

    }
}
