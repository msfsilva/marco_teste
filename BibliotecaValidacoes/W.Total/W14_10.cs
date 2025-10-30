using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W14_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalCofins = double.Parse(nfe.infNFe.total.ICMSTot.vCOFINS, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.imposto.COFINS == null)
                {
                    continue;
                }

                if (!item.imposto.Items.Any(a => a is TNFeInfNFeDetImpostoICMS))
                {
                    continue;
                }

                if (item.imposto.COFINS.Item is TNFeInfNFeDetImpostoCOFINSCOFINSAliq)
                {
                    totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoCOFINSCOFINSAliq)item.imposto.COFINS.Item).vCOFINS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                }
                else
                {
                    if (item.imposto.COFINS.Item is TNFeInfNFeDetImpostoCOFINSCOFINSNT)
                    {
                        continue;

                    }

                    if (item.imposto.COFINS.Item is TNFeInfNFeDetImpostoCOFINSCOFINSOutr)
                    {
                        totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoCOFINSCOFINSOutr)item.imposto.COFINS.Item).vCOFINS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                    }
                    else
                    {

                        if (item.imposto.COFINS.Item is TNFeInfNFeDetImpostoCOFINSCOFINSQtde)
                        {
                            totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoCOFINSCOFINSQtde)item.imposto.COFINS.Item).vCOFINS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                        }
                        else
                        {
                            throw new Exception("Tipo de objeto do COFINS inválido");
                        }
                    }
                }
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalCofins)) > 0)
            {
                error = "Total do COFINS difere do somatório dos itens sujeitos ao ICMS";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
