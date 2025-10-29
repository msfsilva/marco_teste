#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class SelecionaDataForm : IWTBaseForm
    {
        public DateTime dataSelecionada;
        public SelecionaDataForm()
        {
            InitializeComponent();
            this.dateTimePicker1.Value = Configurations.DataIndependenteClass.GetData();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SelecionaDataForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.dataSelecionada = this.dateTimePicker1.Value;
        }
    }
}
