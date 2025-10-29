using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaExpedicao
{
    public partial class ConferenciaPedidoPesoForm : IWTDotNetLib.IWTBaseForm
    {
        public double Peso { get; private set; }
        public ConferenciaPedidoPesoForm(string codigoItem, double peso)
        {
            InitializeComponent();
            this.Peso = peso;

            this.lblItem.Text = codigoItem;
            this.nudPeso.Value = (decimal) peso;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConferenciaPedidoPesoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                this.Peso = (double)this.nudPeso.Value;

                if (this.Peso <= 0)
                {
                    e.Cancel = true;
                    throw new Exception("O peso deve ser preenchido com um valor maior do que zero");
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
