#region Referencias

using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.OrdemProducao;
using IWTDotNetLib;

#endregion

namespace BibliotecaCompras
{
    public partial class AvisoRecebimentoReportForm : IWTBaseForm
    {
        public AvisoRecebimentoReportForm(NFEntradaClass NF)
        {
            InitializeComponent();


            List<AvisoRecebimentoReportClass> dados = new List<AvisoRecebimentoReportClass>();

            foreach (NFEntradaItemClass item in NF.linhasAtuais.Values)
            {
                foreach (LoteEstoque estoque in item.Lote.gavetasEstoque.Where(a => a.Quantidade > 0))
                {
                    dados.Add(new AvisoRecebimentoReportClass(item, NF, estoque));
                }
            }

            dados.Sort();

            AvisoRecebimentoReport rep = new AvisoRecebimentoReport();
            rep.SetDataSource(dados);

            this.crystalReportViewer1.ReportSource = rep;
            this.crystalReportViewer1.RefreshReport();

        }
    }
}
