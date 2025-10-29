#region Referencias

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.Compras;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaCompras
{
    public partial class NecessidadeCompraReportForm : IWTBaseForm
    {
        IWTPostgreNpgsqlConnection conn;
        readonly NecessidadeCompra neC;
        public NecessidadeCompraReportForm(string tipoCalculoSemana,string diaCalculoSemana,
            int leadtimePCP, int leadtimeCompras,
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double categoriaAAcimaDe, double categoriaBAcimaDe,
            double margemAvisoKB, 
             double sugestaoCompraAcimaConfigurado,
            IWTPostgreNpgsqlConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
            this.neC = new NecessidadeCompra(tipoCalculoSemana, diaCalculoSemana,
                leadtimePCP,leadtimeCompras,diasVerde,diasAmarelo,diasVermelho,
                mesesMedia,categoriaAAcimaDe,categoriaBAcimaDe,margemAvisoKB,
                sugestaoCompraAcimaConfigurado,
                conn, 
                LoginClass.UsuarioLogado.loggedUser);
        }

        private void NecessidadeCompraReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.neC.gerarRelatorio(null, null, null, new List<SolicitacaoCompraClass>());

                List<itemNecessidadeCompra> tmp = new List<itemNecessidadeCompra>(this.neC.itensComprar.Values.Where(a => a.qtdAComprar > 0));

                if (tmp.Count > 0)
                {
                    NecessidadeCompraReport rep = new NecessidadeCompraReport();
                    rep.SetDataSource(tmp);

                    this.crystalReportViewer1.ReportSource = rep;
                    this.crystalReportViewer1.Refresh();
                }
                else
                {
                    MessageBox.Show(this, "Erro ao gerar o relatório, não existem itens para serem comprados.", "Não existem itens", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                }
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
