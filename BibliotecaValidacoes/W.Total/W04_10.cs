using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W04_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalICMS = double.Parse(nfe.infNFe.total.ICMSTot.vICMS, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {

                TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);
                string vICMString = "";

                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)
                {
                    vICMString = ((TNFeInfNFeDetImpostoICMSICMS00) icms.Item).vICMS;
                }
                else
                {


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        vICMString = ((TNFeInfNFeDetImpostoICMSICMS10)icms.Item).vICMS;
                    }
                    else
                    {

                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20)
                        {
                            vICMString = ((TNFeInfNFeDetImpostoICMSICMS20)icms.Item).vICMS;
                        }
                        else
                        {

                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS30)
                            {
                                 vICMString = "0.00";
                            }
                            else
                            {

                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40)
                                {
                                    vICMString = "0.00";
                                }
                                else
                                {

                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS51)
                                    {
                                        vICMString = ((TNFeInfNFeDetImpostoICMSICMS51)icms.Item).vICMS;
                                    }
                                    else
                                    {

                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60)
                                        {
                                             vICMString = "0.00";
                                        }
                                        else
                                        {

                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS70)
                                            {
                                                vICMString = ((TNFeInfNFeDetImpostoICMSICMS70)icms.Item).vICMS;
                                            }
                                            else
                                            {

                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                                                {
                                                    vICMString = ((TNFeInfNFeDetImpostoICMSICMS90)icms.Item).vICMS;
                                                }
                                                else
                                                {

                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN101)
                                                    {
                                                         vICMString = "0.00";
                                                    }
                                                    else
                                                    {

                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)
                                                        {
                                                             vICMString = "0.00";
                                                        }
                                                        else
                                                        {

                                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN201)
                                                            {
                                                                 vICMString = "0.00";
                                                            }
                                                            else
                                                            {

                                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN202)
                                                                {
                                                                     vICMString = "0.00";
                                                                }
                                                                else
                                                                {

                                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                                                                    {
                                                                        vICMString = "0.00";
                                                                    }
                                                                    else
                                                                    {

                                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                                                                        {
                                                                            vICMString = ((TNFeInfNFeDetImpostoICMSICMSSN900)icms.Item).vICMS;
                                                                        }
                                                                        else
                                                                        {
                                                                            throw new Exception("Tipo do objeto de icms inválido");
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                totalCalculado = Math.Round(totalCalculado + double.Parse(vICMString, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalICMS)) > 0)
            {
                error = "Total do ICMS difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
