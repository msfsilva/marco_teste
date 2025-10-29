using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class OrdemProducaoMateriaisReportForm : IWTBaseForm
    {
        public OrdemProducaoMateriaisReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
        }

        private void btnGerar_Click(object sender, EventArgs e)
        {
            try
            {
                this.crystalReportViewer1.ReportSource = null;
                List<OrdemProducaoMateriaisReportClass> ds = OrdemProducaoMateriaisReportClass.Gerar(this.dtpInicio.Value, this.dtpFim.Value, LoginClass.UsuarioLogado.loggedUser, SingleConnection);

                if (ds.Count == 0)
                {
                    throw new ExcecaoTratada("Nenhum dado encontrado para as opções selecionadas");
                }

                 OrdemProducaoMateriaisReport rep = new OrdemProducaoMateriaisReport();
                 
                rep.SetDataSource(ds);
                rep.SetParameterValue("Periodo", this.dtpInicio.Value.ToString("dd/MM/yyyy") + " - " + this.dtpFim.Value.ToString("dd/MM/yyyy"));
                this.crystalReportViewer1.ReportSource = rep;

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
