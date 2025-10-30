using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W09_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalSeguro = double.Parse(nfe.infNFe.total.ICMSTot.vSeg, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.prod.vSeg == null) continue;

                totalCalculado = Math.Round(totalCalculado + double.Parse(item.prod.vSeg, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalSeguro)) > 0)
            {
                error = "Total do Seguro difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
