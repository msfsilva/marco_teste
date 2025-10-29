#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaExpedicao
{
    public partial class QuantidadeParcialForm : IWTBaseForm
    {
        public double? QtdSelecionada { get; set; }
        public int? QtdVolumes { get; set; }

        public QuantidadeParcialForm(double qtdMaxima, int qtdMaximaVolumes)
        {
            InitializeComponent();
            this.nudQuantidade.Minimum = 1;
            this.nudQuantidade.Maximum = (decimal)qtdMaxima;
            this.nudQuantidade.Value = (decimal)qtdMaxima;

            this.nudQtdVolumes.Minimum = 1;
            //this.nudQtdVolumes.Maximum = qtdMaximaVolumes;
            this.nudQtdVolumes.Value = qtdMaximaVolumes;
        }

        private void btnContinuar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QuantidadeParcialForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.QtdSelecionada = (double)this.nudQuantidade.Value;
            this.QtdVolumes = (int)this.nudQtdVolumes.Value;
        }
    }
}
