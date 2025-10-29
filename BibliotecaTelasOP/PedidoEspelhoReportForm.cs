using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BibliotecaTelasOP
{
    public partial class PedidoEspelhoReportForm : Form
    {
        private List<PedidoEspelhoParametrosBuscaClass> parametros = null;

        public PedidoEspelhoReportForm(List<PedidoEspelhoParametrosBuscaClass> parametros)
        {
            this.parametros = parametros;
            InitializeComponent();
        }


        private void gerarRelatorio()
        {
            try
            {
                List<PedidoEspelhoClass> dados = PedidoEspelhoClass.gerar(parametros);
                PedidoEspelhoReport report = new PedidoEspelhoReport();
                report.SetDataSource(dados);
                this.crystalReportViewer1.ReportSource = report;
            }
            catch(Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void PedidoEspelhoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                gerarRelatorio();
            }
            catch(Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
    }
}
