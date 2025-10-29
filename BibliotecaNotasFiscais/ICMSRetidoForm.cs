#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaNotasFiscais
{
    public partial class IcmsRetidoForm : IWTBaseForm
    {
        public double remetenteBC { private set; get; }
        public double remetenteValor { private set; get; }

        public double destBC { private set; get; }
        public double destValor { private set; get; }

        public IcmsRetidoForm(string item)
        {
            InitializeComponent();
            this.lblItem.Text = item;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ICMSRetidoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.remetenteBC = (double)this.nudRemetenteBC.Value;
            this.remetenteValor = (double)this.nudRemetenteValor.Value;


            this.destBC = (double)this.nudDestBC.Value;
            this.destValor = (double)this.nudDestValor.Value;

        }

    }
}
