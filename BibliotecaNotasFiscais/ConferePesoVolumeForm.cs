using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaNotasFiscais
{
    public partial class ConferePesoVolumeForm : IWTBaseForm
    {
        public double PesoBruto { get; set; }
        public double PesoLiquido { get; set; }
        public int Volumes { get; set; }

        public ConferePesoVolumeForm(double pesoBruto, double pesoLiquido, int volumes)
        {
            PesoBruto = pesoBruto;
            PesoLiquido = pesoLiquido;
            Volumes = volumes;

            InitializeComponent();

            nudPesoBruto.Value = (decimal) pesoBruto;
            nudPesoLiquido.Value = (decimal) pesoLiquido;
            nudVolumes.Value = volumes;


        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ConferePesoVolumeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            PesoBruto = (double) nudPesoBruto.Value;
            PesoLiquido = (double) nudPesoLiquido.Value;
            Volumes = (int) nudVolumes.Value;
            
            
        }
    }
}
