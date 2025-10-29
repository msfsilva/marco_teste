#region Referencias

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Operacoes.Configurador;
using IWTDotNetLib;
using IWTPostgreNpgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioPedidosSemVariaveisReportForm : IWTBaseForm
    {
        readonly IWTPostgreNpgsqlConnection conn;
        private IConfiguradorEASIFactory configuradorEasiFactory;
        private bool toClose = false;

        public RelatorioPedidosSemVariaveisReportForm(IWTPostgreNpgsqlConnection conn, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            InitializeComponent();
            this.conn = conn;
            this.configuradorEasiFactory = configuradorEasiFactory;


            try
            {
                GerarRelatorio();
            }
            catch (ExcecaoTratada a)
            {
                toClose = true;
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                toClose = true;
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerarRelatorio()
        {

            RelatorioPedidosSemVariaveisClass ger = new RelatorioPedidosSemVariaveisClass(this.conn, this.configuradorEasiFactory);
            List<PedidosSemVariaveisClass> dados = ger.gerarRelatorio();

            if (dados.Count == 0)
            {
                throw new ExcecaoTratada("Não existem dados para serem exibidos no relatório");   
            }

            RelatorioPedidosSemVariaveisReport rep = new RelatorioPedidosSemVariaveisReport();
            rep.SetDataSource(dados);
            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.RefreshReport();

        }

        private void RelatorioPedidosSemVariaveisReportForm_Shown(object sender, EventArgs e)
        {
            if (toClose)
            {
                Close();
            }
        }
    }
}
