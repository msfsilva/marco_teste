#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaExpedicao
{
    public partial class PalletForm : IWTBaseForm
    {
        public PalletConferencia palletToRet { get; private set; }
        public bool sairSistema { get; private set; }
        public bool sairTela { get; private set; }

        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;

        public PalletForm(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();

            this.conn = conn;
            this.Usuario = Usuario;

            this.palletToRet = null;
            this.sairSistema = false;
            this.sairTela = false;

            this.buscaPalletAberto();
        }

        private void buscaPalletAberto()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText = "SELECT pal_numero FROM pallet WHERE id_usuario=" + this.Usuario.ID;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    read.Read();
                    this.setPallet("IP|" + read["pal_numero"]);
                    read.Close();
                }
                else
                {
                    read.Close();
                    return;
                }
            }
            catch (Exception a)
            {
                if (a.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                else
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (this.sairSistema && this.sairTela)
                    {
                        this.Close();
                    }
                }
            }

        }

        private void setPallet(string barcode)
        {
            try
            {
                string[] barcodeSplit = barcode.Replace("\r", "").Replace("\n", "").Replace('}', '|').Trim().Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                if (barcodeSplit.Length == 2 && barcodeSplit[0] == "IP")
                {

                    this.palletToRet = new PalletConferencia(int.Parse(barcodeSplit[1]),this.conn);

                    if (palletToRet.UtilizadoMomento)
                    {
                        if (palletToRet.Usuario == this.Usuario)
                        {
                            this.sairSistema = true;
                            this.sairTela = true;
                            throw new Exception("Você já está com o pallet " + palletToRet.Numero + " aberto em outro terminal. Feche-o antes de continuar.");
                        }
                        else
                        {
                            throw new Exception("O Pallet selecionado já está sendo utilizado em outro terminal no momento.");
                        }
                    }

                    if (this.palletToRet.Ocupado)
                    {
                        

                        if (!this.palletToRet.Fechado && this.palletToRet.Usuario == this.Usuario)
                        {
                            this.sairTela = true;
                            this.Close();
                        }
                        else
                        {
                            throw new Exception("O pallet selecionado está ocupado!");
                        }
                       
                    }
                    else
                    {
                        if (this.palletToRet.Bloqueado)
                        {
                            throw new Exception("O pallet selecionado está bloqueado pelo administrador do sistema!");
                        }
                        else
                        {
                            this.sairTela = true;
                            this.Close();
                        }
                    }


                }
                else
                {
                    throw new Exception("Código do pallet inválido");
                }
            }
            catch (Exception e)
            {
                if (e.Message.ToUpper().Contains("BROKEN"))
                {
                    MessageBox.Show(this, "O sistema perdeu a conexão com o servidor e será encerrado agora.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                    return;
                }
                else
                {
                    throw new Exception("Erro ao selecionar o pallet.\r\n" + e.Message);
                }
            }
        }

        private void resetForm()
        {
            this.txtPallet.Text = "";
            this.txtPallet.Focus();
        }


        #region Eventos
        private void rdbBarCode_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbManual_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.timer1.Enabled = false;
            if (this.rdbBarCode.Checked)
            {
                try
                {
                    if (this.txtPallet.Text.Trim().Length > 0)
                    {
                        this.setPallet(this.txtPallet.Text);
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.resetForm();
                }
            }

        }



        private void txtPallet_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.rdbManual.Checked && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter))
            {
                try
                {
                    if (this.txtPallet.Text.Trim().Length > 0)
                    {
                        this.setPallet(this.txtPallet.Text);
                    }
                }
                catch (Exception a)
                {
                    MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.resetForm();
                }
            }
        }
        
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.sairSistema = true;
            this.Close();
        }
    

        private void PalletForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.sairSistema && !this.sairTela)
            {
                e.Cancel = true;
            }
        }

        #endregion
    }
}
