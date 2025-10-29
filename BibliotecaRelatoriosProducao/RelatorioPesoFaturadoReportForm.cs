using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaRelatoriosProducao
{
    public partial class RelatorioPesoFaturadoReportForm : IWTDotNetLib.IWTBaseForm
    {
        public RelatorioPesoFaturadoReportForm()
        {
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;

            this.txtInicio.Text = "01/" + Configurations.DataIndependenteClass.GetData().Year.ToString(CultureInfo.InvariantCulture);
            this.txtFim.Text = Configurations.DataIndependenteClass.GetData().Month.ToString(CultureInfo.InvariantCulture).PadLeft(2, '0') + "/" + Configurations.DataIndependenteClass.GetData().Year.ToString(CultureInfo.InvariantCulture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime inicio;
                if (!DateTime.TryParse("01/"+this.txtInicio.Text, CultureInfo.GetCultureInfo("pt-Br"), DateTimeStyles.AllowWhiteSpaces, out inicio))
                {
                    throw new ExcecaoTratada("Mês de Inicio Inválido");
                }

                DateTime fim;
                if (!DateTime.TryParse("01/" + this.txtFim.Text, CultureInfo.GetCultureInfo("pt-Br"), DateTimeStyles.AllowWhiteSpaces, out fim))
                {
                    throw new ExcecaoTratada("Mês de Fim Inválido");
                }
                fim = fim.AddMonths(1).AddDays(-1);
            




                RelatorioPesoFaturadoReport rep = new RelatorioPesoFaturadoReport();
                string intervaloDados;


                rep.SetDataSource(RelatorioPesoFaturadoReportClass.Gerar(inicio, fim, out intervaloDados));
                rep.SetParameterValue("intervaloDadosString", intervaloDados);
                this.crystalReportViewer1.ReportSource = rep;
                
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
