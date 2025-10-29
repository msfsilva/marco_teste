using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTDotNetLib;
using dbProvider;

namespace BibliotecaQualidade
{
    public partial class AcompanhamentoTemposReportForm : IWTBaseForm
    {
        public AcompanhamentoTemposReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
        }
        
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
              
                int tolerancia = Convert.ToInt32(this.nudTolerancia.Value);
                DateTime data = this.dtpDataParam.Value;
               
                List<AcompanhamentoTemposReportClass> ds = AcompanhamentoTemposReportClass.generateReport(tolerancia, data, DbConnection.Connection);

                if (ds.Count == 0)
                {
                    MessageBox.Show(this, "Não existem tempos fora dos limites determinados para o período selecionado.", "Tempos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    AcompanhamentoTemposReport rep = new AcompanhamentoTemposReport();
                    rep.SetDataSource(ds);
                    rep.SetParameterValue("data", "OPs Encerradas após: " + data.ToString("dd/MM/yyyy"));
                    rep.SetParameterValue("percTolerancia", "Tolerância(%): " + tolerancia);
                    this.crystalReportViewer1.ReportSource = rep;
                }

            }
            catch (Exception a)
            {
                throw new Exception("Erro ao gerar o relatório.\r\n" + a.Message, a);
            }
        }
    }
}
