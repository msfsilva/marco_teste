using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W13_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalPis = double.Parse(nfe.infNFe.total.ICMSTot.vPIS, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.imposto.PIS == null)
                {
                    continue;
                }

                if (!item.imposto.Items.Any(a => a is TNFeInfNFeDetImpostoICMS))
                {
                    continue;
                }

                if (item.imposto.PIS.Item is TNFeInfNFeDetImpostoPISPISAliq)
                {
                    totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoPISPISAliq)item.imposto.PIS.Item).vPIS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                }
                else
                {
                    if (item.imposto.PIS.Item is TNFeInfNFeDetImpostoPISPISNT)
                    {
                        continue;

                    }

                    if (item.imposto.PIS.Item is TNFeInfNFeDetImpostoPISPISOutr)
                    {
                        totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoPISPISOutr)item.imposto.PIS.Item).vPIS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                    }
                    else
                    {

                        if (item.imposto.PIS.Item is TNFeInfNFeDetImpostoPISPISQtde)
                        {
                            totalCalculado = Math.Round(totalCalculado + double.Parse(((TNFeInfNFeDetImpostoPISPISQtde)item.imposto.PIS.Item).vPIS, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                        }
                        else
                        {
                            throw new Exception("Tipo de objeto do PIS inválido");
                        }
                    }
                }
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalPis)) > 0)
            {
                error = "Total do PIS difere do somatório dos itens sujeitos ao ICMS";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
