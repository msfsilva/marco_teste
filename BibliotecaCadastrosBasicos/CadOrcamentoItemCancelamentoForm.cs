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
    public partial class CadOrcamentoItemCancelamentoForm : IWTBaseForm
    {

        readonly OrcamentoItemClass Orcamento;

        public CadOrcamentoItemCancelamentoForm(OrcamentoItemClass orcamento)
        {
            InitializeComponent();

            this.Orcamento = orcamento;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                this.Orcamento.Cancelar(this.txtJustificativa.Text);
                MessageBox.Show(this, "Orçamento cancelado com sucesso!", "Cancelamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAbortar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
