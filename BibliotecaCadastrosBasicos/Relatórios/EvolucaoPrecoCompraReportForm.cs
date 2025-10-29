using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BibliotecaEntidades.Entidades;
using CrystalDecisions.CrystalReports.Engine;
using IWTDotNetLib;

namespace BibliotecaCadastrosBasicos.Relatórios
{
    public partial class EvolucaoPrecoCompraReportForm : IWTBaseForm
    {
        private readonly List<AbstractEntity> _itens;
        private readonly EvolucaoPrecoCompraReportClass.SelecaoEntidadeRelatorio _tipoEntidade;

        public EvolucaoPrecoCompraReportForm(List<AbstractEntity> itens, EvolucaoPrecoCompraReportClass.SelecaoEntidadeRelatorio tipoEntidade) 
        {
            _itens = itens;
            _tipoEntidade = tipoEntidade;
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;
        }




        protected void Gerar()
        {
            EvolucaoPrecoCompraReport rep = new EvolucaoPrecoCompraReport();



            EvolucaoPrecoCompraReportClass.SelecaoRelatorio tipoRelatorio = EvolucaoPrecoCompraReportClass.SelecaoRelatorio.Todos; ;
            if (rdbA.Checked)
            {
                tipoRelatorio = EvolucaoPrecoCompraReportClass.SelecaoRelatorio.SomenteA; 
            }

            if (rdbB.Checked)
            {
                tipoRelatorio = EvolucaoPrecoCompraReportClass.SelecaoRelatorio.SomenteB;
            }

            if (rdbC.Checked)
            {
                tipoRelatorio = EvolucaoPrecoCompraReportClass.SelecaoRelatorio.SomenteC;
            }

            List<EvolucaoPrecoCompraReportClass> datasource = EvolucaoPrecoCompraReportClass.Gerar(_itens, this.dtpInicio.Value.Date, this.dtpFim.Value.Date, tipoRelatorio, _tipoEntidade, SingleConnection);

            if (datasource.Count == 0)
            {
                this.crystalReportViewer1.ReportSource = null;
                throw new ExcecaoTratada("A seleção realizada não resultou em nenhum registro para o relatório");
            }

            rep.SetDataSource(datasource);


            this.crystalReportViewer1.ReportSource = rep;
        }

        private void iwtButton1_Click(object sender, System.EventArgs e)
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

        private void EvolucaoPrecoCompraReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                this.dtpInicio.Value = new DateTime(Configurations.DataIndependenteClass.GetData().Year, 1, 1);
                this.Gerar();

            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
