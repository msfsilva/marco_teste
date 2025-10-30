using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W16_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalNfe = double.Parse(nfe.infNFe.total.ICMSTot.vNF, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;
            totalCalculado = Math.Round(
                +double.Parse(nfe.infNFe.total.ICMSTot.vProd, NumberStyles.Any, CultureInfo.InvariantCulture)
                - double.Parse(nfe.infNFe.total.ICMSTot.vDesc, NumberStyles.Any, CultureInfo.InvariantCulture)
                - double.Parse(nfe.infNFe.total.ICMSTot.vICMSDeson, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vST, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vFrete, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vSeg, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vOutro, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vII, NumberStyles.Any, CultureInfo.InvariantCulture)
                + double.Parse(nfe.infNFe.total.ICMSTot.vIPI, NumberStyles.Any, CultureInfo.InvariantCulture)
                , 5);






            if (Math.Abs(Math.Abs(totalCalculado - valorTotalNfe)) > 0)
            {
                error = "Total da NF difere do somatório dos valores que compõe o total da NF";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
