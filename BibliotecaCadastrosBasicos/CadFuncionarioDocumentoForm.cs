using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Base;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos
{
    public partial class CadFuncionarioDocumentoForm : IWTForm
    {

        FuncionarioDocumentoClass Documento
        {
            get { return (FuncionarioDocumentoClass) this.Entity; }
        }
        public CadFuncionarioDocumentoForm(FuncionarioDocumentoClass entidade)
            : base(entidade, typeof(FuncionarioDocumentoClass), LoginClass.UsuarioLogado.loggedUser, null)
        {
            InitializeComponent();
        }

        #region Evento

        protected override void btnSalvar_Click(object sender, EventArgs e)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
              
                fs = new FileStream(txtArquivo.Text, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                FileInfo fileInfo = new FileInfo(txtArquivo.Text);
                string nome = fileInfo.Name;

                Documento.NomeArquivo = nome;
                Documento.Arquivo = br.ReadBytes((int) fs.Length);

                
                fs.Close();
                br.Close();

            }
            catch (Exception a)
            {
                throw new Exception("Falha ao adicionar o arquivo\r\n" + a.Message.ToString());
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

            base.btnSalvar_Click(sender, e);
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Selecione o arquivo para incluir";
                openFileDialog1.Filter = "Arquivo|*.*";
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtArquivo.Text = openFileDialog1.FileName;
                }
            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
