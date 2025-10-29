#region Referencias

using System;
using System.Windows.Forms;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioPedidoDataEntradaForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public RelatorioPedidoDataEntradaForm(IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.dtpInicio.Value = Configurations.DataIndependenteClass.GetData();
            this.dtpFim.Value = Configurations.DataIndependenteClass.GetData();
        }

        private void Gerar()
        {
            DateTime? Inicio = null;
            DateTime? Fim = null;

            if (this.dtpInicio.Enabled)
            {
                Inicio = this.dtpInicio.Value;
            }

            if (this.dtpFim.Enabled)
            {
                Fim = this.dtpFim.Value;
            }

            RelatorioPedidoDataEntradaReportForm form = new RelatorioPedidoDataEntradaReportForm(Inicio, Fim, this.chkIncluirCancelados.Checked,this.rdbOrdernaEntrega.Checked,this.conn);
            form.ShowDialog();
            if (!form.abort)
            {
                this.Close();
            }
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Gerar();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkInicio_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpInicio.Enabled = this.chkInicio.Checked;
            
        }

        private void chkFim_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpFim.Enabled = this.chkFim.Checked;
        }

       
    }
}
