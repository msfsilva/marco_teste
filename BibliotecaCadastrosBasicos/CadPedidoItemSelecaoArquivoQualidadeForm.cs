using System;
using System.IO;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;


namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemSelecaoArquivoQualidadeForm : IWTBaseForm
    {
        public PedidoItemQualidadeClass  PedidoItemQualidade = null;

        public CadPedidoItemSelecaoArquivoQualidadeForm()
        {
            InitializeComponent();
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Title = "Selecione o arquivo para incluir no pedido";
                openFileDialog1.Filter = "Imagens (*.JPG;*.PNG; *.BMP; *.GIF)|*.JPG;*.PNG; *.BMP; *.GIF|PDF(*.PDF)|*.PDF";
                openFileDialog1.FileName = "";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    txtArquivo.Text = openFileDialog1.FileName;
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao selecionar a imagem.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                AdicionarArquivo();
            }
            catch(Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarArquivo()
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                if (txtArquivo.Text == "")
                {
                    throw new Exception("Selecione o arquivo para adicionar");
                }
                if (txtDescricaoArquivo.Text == "")
                {
                    throw new Exception("Informe a descrição do arquivo");
                }
                fs = new FileStream(txtArquivo.Text, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);

                FileInfo fileInfo = new FileInfo(txtArquivo.Text);
                string nome = fileInfo.Name;
                PedidoItemQualidade = new PedidoItemQualidadeClass(LoginClass.UsuarioLogado.loggedUser, this.SingleConnection)
                {
                    Arquivo =  br.ReadBytes((int) fs.Length),
                    NomeArquivo = nome,
                    DescricaoArquivo = txtDescricaoArquivo.Text,
                    PedidoItem = null,
                    
                };

                fs.Close();
                br.Close();
                this.Close();

            }catch(Exception a)
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
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
