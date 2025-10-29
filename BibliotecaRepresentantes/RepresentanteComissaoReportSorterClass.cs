using System.Collections.Generic;
using BibliotecaEntidades.Entidades;

namespace BibliotecaRepresentantes
{
    internal class ComissaoReportSorterClass:IComparer<ComissaoReportDataSource>
    {
        public int Compare(ComissaoReportDataSource x, ComissaoReportDataSource y)
        {
            if (x == null)
            {
                return y == null ? 0 : 1;
            }

            if (y == null)
            {
                return -1;
            }

            if (!x.Tipo.Equals(y.Tipo)) return string.CompareOrdinal(x.Tipo, y.Tipo);
            if (!x.RepresentanteVendedor.Equals(y.RepresentanteVendedor)) return string.CompareOrdinal(x.RepresentanteVendedor, y.RepresentanteVendedor);
            if (!x.Data.Date.Equals(y.Data.Date)) return x.Data.Date.CompareTo(y.Data.Date);
            return x.Valor.CompareTo(y.Valor);

        }
    }
}
