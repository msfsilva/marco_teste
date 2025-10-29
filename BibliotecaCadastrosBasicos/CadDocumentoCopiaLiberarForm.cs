#region Referencias

using System;
using System.Windows.Forms;
using BibliotecaControleRevisao;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCadastrosBasicos
{
    public partial class CadDocumentoCopiaLiberarForm : IWTBaseForm
    {
        TipoForm Tipo;
        readonly AcsUsuarioClass Usuario;
        readonly IWTPostgreNpgsqlConnection conn;
        DocumentoCopiaClass Copia;

        public CadDocumentoCopiaLiberarForm(TipoForm Tipo, AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.Tipo = Tipo;
            this.Usuario = Usuario;
            this.conn = conn;
        }

        private void SelecionarCopia()
        {
            try
            {
                if (this.txtBarcode.Text.Trim().Length == 0)
                {
                    return;
                }


                this.Copia = DocumentoCopiaClass.loadFromBarcode(this.txtBarcode.Text.Trim(), this.Usuario, this.conn);
                if (!Copia.Ocupada)
                {
                    throw new Exception("Essa cópia não está ocupada.");
                }
                this.lblCopia.Text = Copia.Identificacao;
                this.lblDocumento.Text = Copia.DocumentoTipoFamilia.DocumentoTipo.ToString();
                this.lblUltimaUtilizacao.Text = Copia.getUltimaUtilizacao();
                this.txtJustificativa.Focus();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao selecionar a cópia.\r\n" + e.Message, e);
            }
        }

        private void Liberar()
        {
            try
            {
                if (this.txtJustificativa.Text.Trim().Length < 10)
                {
                    throw new Exception("Entre com uma justificativa de ao menos 10 caracteres.");
                }
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                Copia.Liberar(ref command, this.txtJustificativa.Text.Trim());

                command.Transaction.Commit();
                MessageBox.Show(this, "Cópia liberada com sucesso", "Liberação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao liberar.\r\n" + e.Message, e);
            }
        }


        #region Eventos
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                timer1.Enabled = false;
                this.SelecionarCopia();
                
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtBarcode.Clear();
                this.lblCopia.Text = "";
                this.lblDocumento.Text = "";
                this.txtBarcode.Focus();
            }

        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Liberar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion


    }
}
