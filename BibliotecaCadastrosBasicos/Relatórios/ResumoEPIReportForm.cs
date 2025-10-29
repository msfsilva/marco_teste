using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class ResumoEPIReportForm : IWTBaseForm
    {
        private readonly FuncionarioClass _funcionario;

        public ResumoEPIReportForm(FuncionarioClass funcionario)
        {
            _funcionario = funcionario;
            InitializeComponent();

            this.crystalReportViewer1.ShowLogo = false;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.crystalReportViewer1.ReportSource = null;
                List<ResumoEPIReportClass> ds = ResumoEPIReportClass.GerarReport(_funcionario, this.dtpInicio.Value, this.dtpTermino.Value, SingleConnection);

                if (ds.Count == 0)
                {
                    throw new ExcecaoTratada("Nenhum registro foi encontrado para o período");
                }
                ResumoEPIReport rep = new ResumoEPIReport();
                rep.SetDataSource(ds);
                rep.SetParameterValue("periodo", "De " + this.dtpInicio.Value.ToString("dd/MM/yyyy") + " a " + this.dtpTermino.Value.ToString("dd/MM/yyyy"));

                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
