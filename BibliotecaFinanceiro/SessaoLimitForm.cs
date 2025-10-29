#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaFinanceiro
{
    public partial class SessaoLimitForm : IWTBaseForm
    {
        private bool okPressed;
        public SessaoLimitForm()
        {
            InitializeComponent();
            //okPressed = false;
            //lblUsuario.Text += " " + Program.Login.loggedUser.useName.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            /*if (txtSenha.Text.Equals(Program.Login.loggedUser.usePassword.ToString()))
            {
                this.okPressed = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Senha Inválida", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        private void SessaoLimitForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*if (!this.okPressed)
            {
                e.Cancel = true;
            }*/
        }
    }
}
