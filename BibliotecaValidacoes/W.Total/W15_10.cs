using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W15_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalOutros = double.Parse(nfe.infNFe.total.ICMSTot.vOutro, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.prod.vOutro == null)continue;

                totalCalculado = Math.Round(totalCalculado + double.Parse(item.prod.vOutro, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalOutros)) > 0)
            {
                error = "Total do vOutro difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
