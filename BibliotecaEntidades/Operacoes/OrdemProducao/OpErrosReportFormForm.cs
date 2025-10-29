using System.Collections.Generic;
using IWTDotNetLib;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public partial class OpErrosReportFormForm : IWTBaseForm
    {
        public OpErrosReportFormForm(List<OrdemProducaoErroDocumentoClass> Erros )
        {
            InitializeComponent();

            OpErrosReport rep = new OpErrosReport();
            rep.SetDataSource(Erros);

            List<OrdemProducaoErroDocumentoCopiaClass> copias = new List<OrdemProducaoErroDocumentoCopiaClass>();
            foreach (OrdemProducaoErroDocumentoClass erro in Erros)
            {
                copias.AddRange(erro.Copias);
            }

            rep.Subreports[0].SetDataSource(copias);
            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.Refresh(); 

        }
    }
}
