using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W11_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalII = double.Parse(nfe.infNFe.total.ICMSTot.vII, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                TNFeInfNFeDetImpostoII ii = (TNFeInfNFeDetImpostoII)item.imposto.Items.FirstOrDefault(a => a is TNFeInfNFeDetImpostoII);

                if (ii != null)
                {

                    totalCalculado = Math.Round(totalCalculado + double.Parse(ii.vII, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                }

            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalII)) > 0)
            {
                error = "Total do II difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
