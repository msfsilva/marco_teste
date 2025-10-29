#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadPedidoItemCancelamentoForm : IWTBaseForm
    {
        public string Justificativa { get; private set; }
        public bool Confirmado { get; private set; }

        public CadPedidoItemCancelamentoForm()
        {
            InitializeComponent();

            
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtJustificativa.Text.Trim().Length < 10)
                {
                    throw new Exception("O campo de justicativa deve conter pelo menos 10 caracteres válidos.");
                }

                Justificativa = this.txtJustificativa.Text.Trim();
                Confirmado = true;



                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            Confirmado = false;
            this.Close();
        }
    }
}
