using System;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCompras
{
    public partial class OCCancelamentoForm : IWTBaseForm
    {
        public bool Confirmar { get; private set; }
        public string Justificativa { get; private set; }

        public OCCancelamentoForm(string numeroOC)
        {
            InitializeComponent();
            this.lblOC.Text = numeroOC;
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtJustificativa.Text.Trim().Length < 10)
                {
                    throw new Exception("A justificativa deve ter ao menos 10 caracteres.");
                }
                this.Confirmar = true;
                this.Justificativa = this.txtJustificativa.Text.Trim();

                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, "Erro ao justificar o cancelamento.\r\n" + a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
