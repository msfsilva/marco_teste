#region Referencias

using System;
using IWTDotNetLib;

#endregion

namespace BibliotecaCadastrosBasicos.EstruturaProduto
{
    public partial class CadProdutoPostoTrabalhoForm : IWTBaseForm
    {
        public bool Abortar { get; private set; }
        public double TempoSetup { get; private set; }
        public double TempoProducao { get; private set; }

        public CadProdutoPostoTrabalhoForm(double tempoSetup, double tempoProducao)
        {

            InitializeComponent();
            TempoSetup = tempoSetup;
            TempoProducao = tempoProducao;

            this.nudTempoProducao.Value = (decimal) tempoProducao;
            this.nudTempoSetup.Value = (decimal) tempoSetup;
            this.Abortar = false;
        }

        public CadProdutoPostoTrabalhoForm()
        {

            InitializeComponent();
            TempoSetup = 0;
            TempoProducao = 0;
            this.Abortar = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Abortar = false;
            this.TempoProducao = (double)nudTempoProducao.Value;
            this.TempoSetup = (double)nudTempoSetup.Value;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Abortar = true;
            this.Close();
        }

    }
}
