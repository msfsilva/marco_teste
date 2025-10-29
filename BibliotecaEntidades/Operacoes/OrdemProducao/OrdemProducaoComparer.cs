using System.Collections.Generic;
using System.Linq;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoComparer : IComparer<OrdemProducaoClass>
    {
        #region IComparer<OrdemProducaoClass> Members

        public int Compare(OrdemProducaoClass x, OrdemProducaoClass y)
        {
            int resCompareAgrupador = 0;


            if (x.agrupadorOP != null && y.agrupadorOP != null)
            {
                resCompareAgrupador = System.String.CompareOrdinal(x.agrupadorOP, y.agrupadorOP);
            }

            if (resCompareAgrupador == 0)
            {
                string posto1 = "";
                string posto2 = "";

                if (x.postosTrabalho.Count > 1)
                {
                    x.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());
                    posto1 = x.postosTrabalho[1].Codigo;
                }

                if (y.postosTrabalho.Count > 1)
                {
                    y.postosTrabalho.Sort(new OrdemProducaoPostoTrabalhoComparer());
                    posto2 = y.postosTrabalho[1].Codigo;
                }


                int resCompare = System.String.CompareOrdinal(posto1, posto2);
                if (resCompare == 0)
                {
                    double dimMaterial1 = 0;
                    double dimMaterial2 = 0;

                    if (x.Materiais.Count > 0)
                    {
                        dimMaterial1 = x.Materiais.OrderBy(a => a.Espessura).First().Espessura;
                    }

                    if (y.Materiais.Count > 0)
                    {
                        dimMaterial2 = y.Materiais.OrderBy(a => a.Espessura).First().Espessura;

                    }

                    int resCompare2 = dimMaterial1.CompareTo(dimMaterial2);
                    if (resCompare2 == 0)
                    {
                        return System.String.CompareOrdinal(x.produtoCodigo, y.produtoCodigo);
                    }
                    else
                    {
                        return resCompare2;
                    }

                }
                else
                {
                    return resCompare;
                }
            }

            else
            {
                return resCompareAgrupador;
            }
        }

        #endregion
    }
}