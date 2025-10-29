using System;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaFinanceiro
{
    public partial class JustificativaCancelamentoNFeForm : IWTBaseForm
    {
        
        public bool cancelamentoSalvo { get; private set; }
        public string justificativa { get; private set; }

        public JustificativaCancelamentoNFeForm()
        {
            InitializeComponent();
        }


        private void Salvar()
        {
            try
            {
                if(validaJustificativa())
                {
                    justificativa = txtJustificativa.Text;
                    cancelamentoSalvo = true;
                    this.Close();
                }else
                {
                    MessageBox.Show(this, "Justificativa deve conter pelo menos 10 caracteres.", "Atenção",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a Justificativa de Cancelamento da NFe.\r\n" + e.Message, e);
            }  
        }


        private bool validaJustificativa()
        {
            if (txtJustificativa.Text.Trim().Length < 10)
            {
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Salvar();
            }catch(Exception ex)
            {
                MessageBox.Show("Falha ao salvar a justificativa \n" + ex.Message);
            }
        }

    }
}
