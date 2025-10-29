using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BibliotecaCadastrosBasicos.TelasAuxiliares;
using BibliotecaEntidades.Relatorios;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class RelatorioCompletoEstoqueReportForm : IWTBaseForm
    {
        public RelatorioCompletoEstoqueReportForm()
        {
            InitializeComponent();
        }


        private void btnGerar_Click(object sender, EventArgs e)
        {
            
            try
            {
                crystalReportViewer1.ReportSource = null;


                List<RelatorioCompletoEstoqueReportClass> dados = RelatorioCompletoEstoqueReportClass.GerarRelatorio(
                    chkMateriais.Checked,chkProdutos.Checked,chkEPIs.Checked,
                    SingleConnection, LoginClass.UsuarioLogado.loggedUser);

                if (dados == null || dados.Count == 0)
                {
                    throw new ExcecaoTratada("Não foram encontrados registros no banco de dados para o relatório");
                }

                RelatorioCompletoEstoqueReport report = new RelatorioCompletoEstoqueReport();
                report.SetDataSource(dados);


                crystalReportViewer1.ReportSource = report;

            }
            catch (ExcecaoTratada a)
            {
                MessageBox.Show(this, a.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
