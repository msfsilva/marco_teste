#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaExpedicao
{
    public partial class LiberarPalletForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public LiberarPalletForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void liberarPallet(string barcode)
        {
            try
            {
                PalletConferencia pallet = new PalletConferencia(barcode,this.conn);
                pallet.setUtilizadoMomento(false);
                pallet.Save();

                MessageBox.Show(this, "Pallet liberado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao liberar o pallet.\r\n" + e.Message);
            }
        }


        #region Eventos
        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPallet_TextChanged(object sender, EventArgs e)
        {
            this.timer1.Stop();
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.timer1.Enabled = false;
                this.liberarPallet(this.txtPallet.Text);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
