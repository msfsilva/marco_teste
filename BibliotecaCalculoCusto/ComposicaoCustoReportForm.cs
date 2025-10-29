using System;
using System.Collections.Generic;
using System.Windows.Forms;
using IWTDotNetLib;

namespace BibliotecaCalculoCusto
{
    public partial class ComposicaoCustoReportForm : IWTBaseForm
    {
        private readonly List<CalculoCustoComponentesClass> _componentes;
        private readonly string _codigoProduto;

        public ComposicaoCustoReportForm(List<CalculoCustoComponentesClass> componentes, string codigoProduto )
        {
            _componentes = componentes;
            _codigoProduto = codigoProduto;
            InitializeComponent();
            this.crystalReportViewer1.ShowLogo = false;

        }

        private void ComposicaoCustoReportForm_Shown(object sender, EventArgs e)
        {
            try
            {
                ComposicaoCustoReport rep = new ComposicaoCustoReport();
                rep.SetDataSource(this._componentes);
                rep.SetParameterValue("codigoProduto", this._codigoProduto);
                this.crystalReportViewer1.ReportSource = rep;
            }
            catch (Exception a)
            {
                MessageBox.Show(this, a.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
