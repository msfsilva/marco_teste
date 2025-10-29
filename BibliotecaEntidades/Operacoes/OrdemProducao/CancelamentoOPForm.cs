#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;

#endregion

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class CancelamentoOPForm : IWTBaseForm
    {
        readonly OrdemProducaoClass OP;
        public bool Abortar { get; private set; }
        public CancelamentoOPForm(OrdemProducaoClass OP, string tipo)
        {
            InitializeComponent();
            this.OP = OP;

            if (tipo == "ENCERRAMENTO")
            {
                this.Text = "Encerramento de Ordem de Produção";
                this.label1.Text = "Leia o código de barras para encerrar a Ordem de Produção Nº.";
            }
            else
            {
                this.Text = "Cancelamento de Ordem de Produção";
                this.label1.Text = "Leia o código de barras para cancelar a Ordem de Produção Nº.";
            }

            this.lblNumeroOP.Text = this.OP.idOrdemProducao.Value.ToString();
            this.Abortar = true;


#if DEBUG
            this.txtCodigoBarras.DebugMode = true;
#endif
        }

        private void validarCodigoBarras(string valor)
        {
            try
            {
                if (valor.Length > 0)
                {
                    if (this.OP.validarCodigoBarras(valor))
                    {
                        this.Abortar = false;
                        this.Close();
                    }
                    else
                    {
                        throw new Exception("Código de barras inválida para a Ordem de produção selecionada.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao tentar cancelar através do código de barras.\r\n" + e.Message, e);
            }
        }

        #region Eventos
        


        private void btnAbortar_Click(object sender, EventArgs e)
        {
            this.Abortar = true;
            this.Close();
        }
        #endregion

        private void txtCodigoBarras_OperacaoBarcodeEncerrada(object sender, string valor)
        {
            try
            {
                this.validarCodigoBarras(valor);
            }
            catch (Exception a)
            {
                this.txtCodigoBarras.Text = "";
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.txtCodigoBarras.Focus();
            }
        }
    }
}
