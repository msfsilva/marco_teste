using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W16a_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalAproximadoTributos = 0;
            if (nfe.infNFe.total.ICMSTot.vTotTrib != null)
            {
                valorTotalAproximadoTributos = double.Parse(nfe.infNFe.total.ICMSTot.vTotTrib, NumberStyles.Any, CultureInfo.InvariantCulture);
            }
            
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.imposto.vTotTrib != null)
                {
                    totalCalculado = Math.Round(totalCalculado + double.Parse(item.imposto.vTotTrib, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                }
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalAproximadoTributos)) > 0)
            {
                error = "Total do Valor Aproximado dos Tributos diferente do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
