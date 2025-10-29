#region Referencias

using System;
using System.IO;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;

#endregion

namespace BibliotecaAdministracaoSistema
{
    public partial class ReimprimirNfCanceladaForm : IWTBaseForm
    {
        public ReimprimirNfCanceladaForm()
        {
            InitializeComponent();
        }

        private void gerarArquivo(int numeroNf, string arquivo)
        {
            try
            {
                if (arquivo.Length == 0)
                {
                    throw new Exception("Campo arquivo é obrigatório.");
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  public.nf_extras.nfx_texto, " +
                "  public.nf_principal.nfp_situacao " +
                "FROM " +
                "  public.nf_extras " +
                "  RIGHT JOIN public.nf_principal ON (public.nf_extras.id_nf_principal = public.nf_principal.id_nf_principal) " +
                "WHERE " +
                "  nfp_numero = " + numeroNf.ToString() + "; ";
                
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    if (read["nfp_situacao"].ToString() == "C")
                    {
                        if (read["nfx_texto"] != DBNull.Value)
                        {
                            StreamWriter writer = null;
                            try
                            {
                                writer = new StreamWriter(arquivo);
                                writer.AutoFlush = true;
                                writer.Write(read["nfx_texto"].ToString());
                                writer.Close();
                            }
                            catch (Exception e)
                            {
                                throw new Exception("Erro ao escrever o arquivo de NFe.\r\n" + e.Message);
                            }
                            finally
                            {
                                if (writer != null)
                                {
                                    writer.Close();
                                }
                            }
                        }
                        else
                        {
                            throw new Exception("Essa nota fiscal não possui o arquivo salvo no banco de dados para ser restaurado.");
                        }

                    }
                    else
                    {
                        throw new Exception("Essa nota fiscal não está cancelada.");
                    }

                }
                else
                {
                    throw new Exception("Número de nota fiscal inválido.");
                }

                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o arquivo da nfe.\r\n" + e.Message);
            }
              
        }

        #region eventos
        private void btnArquivo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtLocalArquivo.Text = saveFileDialog1.FileName;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                this.gerarArquivo((int)this.nudNumeroNF.Value, this.txtLocalArquivo.Text);
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
