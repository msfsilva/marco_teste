using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;

namespace BibliotecaCadastrosBasicos.TelasAuxiliares
{
    public partial class ViewReportPadraoForm : IWTDotNetLib.IWTReportForm
    {
        private readonly ReportDocument _relatorio;
        

        public ViewReportPadraoForm(string nomeTela, ReportDocument relatorio) : base(nomeTela)
        {
            _relatorio = relatorio;
        InitializeComponent();
        }

        protected override ReportDocument InitReportCustom()
        {
            return this._relatorio;
        }
    }
}
