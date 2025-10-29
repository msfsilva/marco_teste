#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemJustificativaForm : IWTBaseForm
    {
        public override sealed string Text
        {
            get { return base.Text; }
            set { base.Text = value; }
        }

        public bool Abortar { get; private set; }
        public string Justificativa { get; private set; }

        public CadPedidoItemJustificativaForm(PedidoItemClass pedido)
        {
            InitializeComponent();
            this.Text = "Suspensão/Retirada de Suspensão Pedido: " + pedido;
            this.Abortar = true;
        }

        
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                
                this.Justificativa = this.txtJustificativa.Text.Trim();
                this.Abortar = false;
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            this.Abortar = true;
            this.Close();
        }

        private void CadPedidoJustificativaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (!Abortar)
                {
                    if (this.Justificativa.Trim().Length < 5)
                    {
                        e.Cancel = true;
                        throw new Exception("A Observação deve ter ao menos 5 caracteres");
                    }
                }

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
