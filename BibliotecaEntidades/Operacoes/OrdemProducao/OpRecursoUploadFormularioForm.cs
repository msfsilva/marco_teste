using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class OpRecursoUploadFormularioForm : IWTBaseForm
    {
        public byte[] NovoDocumentoScaneado { get; private set; }
        public string NovoDocumentoScaneadoNome { get; private set; }

        public OpRecursoUploadFormularioForm(string nomeFormulario)
        {
            InitializeComponent();
            this.lblFormulario.Text = nomeFormulario;
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

                    this.NovoDocumentoScaneado = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    
                    this.NovoDocumentoScaneadoNome = new FileInfo(this.ofdDocumento.FileName).Name;


                    this.lnkDocumento.Text = "Baixar: " + NovoDocumentoScaneadoNome;
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
                if (this.NovoDocumentoScaneado != null)
                {
                    string tempDir = Environment.GetEnvironmentVariable("temp");
                    if (tempDir != null)
                    {
                        string nome = this.NovoDocumentoScaneadoNome;
                        byte[] documento = this.NovoDocumentoScaneado;


                        fs = new FileStream(tempDir + "\\" + nome, FileMode.Create);
                        bw = new BinaryWriter(fs);
                        bw.Write(documento);
                        Process.Start(tempDir + "\\" + nome);

                    }
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

        private bool Sair()
        {
            if (this.NovoDocumentoScaneado == null)
            {
                throw new Exception("Você deve carregar o formulário preenchido antes de continuar.");
            }

            return true;
        }

        #region Eventos
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




        private void btnOK_Click(object sender, EventArgs e)
        {

            try
            {
               this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }

        private void OpRecursoUploadFormularioForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!this.Sair())
                {
                    e.Cancel = true;
                }

                e.Cancel = false;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        #endregion

      
    }
}
