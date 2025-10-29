#region Referencias

using System;
using System.Collections.Generic;
using IWTDotNetLib;
using IWTNF.Entidades.Entidades;

#endregion

namespace BibliotecaEntidades.Operacoes.VisualizacaoNf
{
    public enum VisualNFeFormUtilizacao { Aceite, Visualizacao }
    public partial class VisualNFeForm : IWTBaseForm
    {
        public bool NFeRecusada = true;

        public VisualNFeForm(NfPrincipalClass nf, string Embarque, VisualNFeFormUtilizacao tipoUtilizacao)
        {
            InitializeComponent();

            if (tipoUtilizacao == VisualNFeFormUtilizacao.Visualizacao)
            {
                this.btnAceitar.Visible = false;
                this.btnRecusar.Visible = false;
            }
            else
            {
                this.btnAceitar.Visible = true;
                this.btnRecusar.Visible = true;
            }

            


            NfeReportClass repClass = new NfeReportClass(nf, int.Parse(Embarque));

            NFeVisualizacaoReport report = new NFeVisualizacaoReport();
            report.SetDataSource(new List<NfeReportClass>() {repClass});
            report.Subreports[0].SetDataSource(repClass.Itens);
            crystalReportViewer1.ReportSource = report;
            //crystalReportViewer1.Refresh();

            NFeVisualizacaoImpostosReport report2 = new NFeVisualizacaoImpostosReport();
            

            report2.SetDataSource(repClass.Itens);
            report2.SetParameterValue("numeroNFe", nf.Numero);
            report2.SetParameterValue("idEmbarque", int.Parse(Embarque));
            crystalReportViewer2.ReportSource = report2;
            //crystalReportViewer2.Refresh();
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            NFeRecusada = false;
            this.Close();
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {
            NFeRecusada = true;
            this.Close();
        }

        
    }
}
