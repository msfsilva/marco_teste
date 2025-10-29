#region Referencias

using System;
using IWTDotNetLib;

#endregion

namespace BibliotecaExpedicao
{
    public partial class FechamentoPalletForm : IWTBaseForm
    {
        public bool fecharPallet { get; private set; }
        public FechamentoPalletForm()
        {
            InitializeComponent();
        }

        private void setResp(string barcode)
        {
            barcode = barcode.Replace("\r", "").Replace("\r", "").Replace('}', '|').Trim();
            if (barcode == "SIM")
            {
                this.fecharPallet = true;
            }
            else
            {
                this.fecharPallet = false;
            }
            this.Close();
        }

        #region Eventos
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void btnSim_Click(object sender, EventArgs e)
        {
            this.setResp("SIM");
        }

        private void btnNao_Click(object sender, EventArgs e)
        {
            this.setResp("NAO");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (this.txtResp.Text.Trim().Length > 0)
            {
                this.setResp(this.txtResp.Text);
            }
            
        }
        #endregion
    }
}
