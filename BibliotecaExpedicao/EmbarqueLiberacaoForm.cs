#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaExpedicao
{
    public partial class EmbarqueLiberacaoForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;

        public EmbarqueLiberacaoForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;
            this.Usuario = Usuario;
        }


        private void liberaEmbarque(string barcode)
        {
            try
            {
                if (barcode.Trim().Length == 0) return;

                string[] barcodeExploded = barcode.Replace('}', '|').Replace("\r", "").Replace("\n", "").Split('|');

                EmbarqueClass embarque = null;
                if (barcodeExploded.Length == 2 && barcodeExploded[0] == "IE")
                {
                    embarque = EmbarqueClass.getEmbarqueClean(barcodeExploded[1], this.Usuario, this.conn);

                    if (embarque.LiberadoNF)
                    {
                        throw new Exception("Esse embarque já foi liberado anteriormente pelo usuário " + embarque.usuarioLiberacao);
                    }
                    else
                    {
                        if (MessageBox.Show(this, "Você deseja liberar o embarque número " + embarque.idEmbarque + " para a emissão de nota fiscal?", "Liberação de Embarque", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            embarque.liberarEmbarque(this.Usuario);
                            embarque.Save();
                            this.Close();
                        }
                        else
                        {
                            this.resetForm();
                        }
                    }                   

                }
                else
                {
                    throw new Exception("Código de barras inválido.");
                }

            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                else
                {
                    MessageBox.Show(this, "Erro ao liberar o pallet.\r\n" + e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.resetForm();
                }
            }
        }

        private void resetForm()
        {
            this.txtBarcodeEmbarque.Text = "";
            this.txtBarcodeEmbarque.Focus();
        }

        #region Eventos
        private void txtBarcodePallet_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                this.liberaEmbarque(this.txtBarcodeEmbarque.Text.Trim());
            }
        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {
            this.btnEmbarque.Enabled = rdbManual.Checked;
        }

        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {
            this.btnEmbarque.Enabled = rdbManual.Checked;
        }

        private void btnPallet_Click(object sender, EventArgs e)
        {
            this.liberaEmbarque(this.txtBarcodeEmbarque.Text.Trim());
        }
        #endregion


    }
}
