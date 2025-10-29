using System;
using BibliotecaEntidades.Base;
using IWTDotNetLib;

namespace BibliotecaCompras
{
    public partial class OCEditLinhaForm : IWTBaseForm
    {
        internal double ValorUnitario { get; private set; }
        internal double AliquotaIcms { get; private set; }
        internal double AliquotaIpi { get; private set; }
        internal DateTime EntregaPrevista { get; private set; }
        internal bool ScChanged { get; private set; }
        internal bool NaoAtualizaPrecoRecebimento { get; private set; }

        double Quantidade;

        public OCEditLinhaForm(string produtoMaterial, double valorUnitario, double aliquotaICMS, double aliquotaIPI, double quantidade, StatusOrdemCompra status, DateTime entregaPrevista, bool naoAtualizaPrecoRecebimento)
        {
            InitializeComponent();

            this.lblProdutoMaterial.Text = produtoMaterial;
            this.nudICMS.Value = (decimal) aliquotaICMS;
            this.nudIPI.Value = (decimal)aliquotaIPI;
            this.nudValorUnitario.Value = (decimal)valorUnitario;
            this.nudDataPrevista.Value = (DateTime)entregaPrevista;
            this.nudNaoAtualizaPrecoRecebimento.Checked = (Boolean)naoAtualizaPrecoRecebimento;

            this.ValorUnitario = valorUnitario;
            this.AliquotaIcms = aliquotaICMS;
            this.AliquotaIpi = aliquotaIPI;
            this.EntregaPrevista = entregaPrevista;
            this.ScChanged = false;

            this.Quantidade = quantidade;

            if (status == StatusOrdemCompra.Enviada || status == StatusOrdemCompra.RecebidaParcial)
            {
                this.nudICMS.Enabled = false;
                this.nudIPI.Enabled = false;
                this.nudValorUnitario.Enabled = false;
                this.nudValorTotal.Enabled = false;
            }

            if (status == StatusOrdemCompra.Recebida || status == StatusOrdemCompra.Cancelada)
            {
                this.nudICMS.Enabled = false;
                this.nudIPI.Enabled = false;
                this.nudValorUnitario.Enabled = false;
                this.nudValorTotal.Enabled = false;
                this.nudDataPrevista.Enabled = false;
            }

            this.atualizaValorTotal();
        }

        private void atualizaValorTotal()
        {
            this.nudValorTotal.Value = (decimal)this.Quantidade * this.nudValorUnitario.Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.AliquotaIcms.CompareTo((double)this.nudICMS.Value) != 0 ||
                this.AliquotaIpi.CompareTo((double)this.nudIPI.Value) != 0 ||
                this.ValorUnitario.CompareTo((double)this.nudValorUnitario.Value) != 0)
            {
                this.ScChanged = true;
            }

            this.AliquotaIcms = (double) this.nudICMS.Value;
            this.AliquotaIpi = (double) this.nudIPI.Value;
            this.ValorUnitario = (double) this.nudValorUnitario.Value;
            this.EntregaPrevista = (DateTime)this.nudDataPrevista.Value;
            this.NaoAtualizaPrecoRecebimento = (Boolean)this.nudNaoAtualizaPrecoRecebimento.Checked;

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void nudValorUnitario_ValueChanged(object sender, EventArgs e)
        {
            this.atualizaValorTotal();
        }

        private void naoAtualizaPrecoRecebimento_CheckedChanged(object sender, EventArgs e)
        {
            this.NaoAtualizaPrecoRecebimento = this.nudNaoAtualizaPrecoRecebimento.Checked;
        }
    }
}
