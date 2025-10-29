#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoCopiaAtivaDesativaForm : IWTBaseForm
    {
        readonly DocumentoCopiaClass CopiaSelecionada;
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        readonly bool Ativar = false;

        public CadDocumentoCopiaAtivaDesativaForm(ref DocumentoCopiaClass CopiaSelecionada,bool Ativar,  AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.CopiaSelecionada = CopiaSelecionada;
            this.Usuario = Usuario;
            this.conn = conn;
            this.Ativar = Ativar;

            if (this.Ativar)
            {
                this.Text = "Ativar Cópia";
            }
            else
            {
                this.Text = "Desativar Cópia";
            }

            this.lblCopiaSelecionada.Text =  this.CopiaSelecionada.Identificacao;
        }

        private void verificarCodigoBarras()
        {
            try
            {
                if (this.txtBarcode.Text.Trim().Length == 0)
                {
                    return;
                }


                DocumentoCopiaClass tmp = DocumentoCopiaClass.loadFromBarcode(this.txtBarcode.Text.Trim(), this.Usuario, this.conn);
                if (tmp.ID != this.CopiaSelecionada.ID)
                {
                    throw new Exception("O código de barras lido não é da cópia selecionada.");
                }

                if (!this.Ativar)
                {
                    this.lblAtivarDesativar.Text = "Essa cópia será desativada!";
                }
                else
                {
                    this.lblAtivarDesativar.Text = "Essa cópia será ativada!";
                }
              
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a cópia.\r\n" + e.Message, e);
            }
        }

        private void Confirmar()
        {
            try
            {
                this.CopiaSelecionada.Ativa = this.Ativar;
                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao confirmar a operação.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();
                timer1.Start();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.verificarCodigoBarras();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtBarcode.Clear();
                this.lblAtivarDesativar.Text = "";
                this.txtBarcode.Focus();
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Confirmar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
