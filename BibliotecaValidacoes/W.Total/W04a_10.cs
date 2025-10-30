using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W04a_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalICMSDesonerado = double.Parse(nfe.infNFe.total.ICMSTot.vICMSDeson, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {

                TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);
                string vICMSDesontring = "";

                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)
                {
                    vICMSDesontring = "0.00";
                }
                else
                {


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        vICMSDesontring = "0.00";
                    }
                    else
                    {

                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20)
                        {
                            vICMSDesontring = ((TNFeInfNFeDetImpostoICMSICMS20)icms.Item).vICMSDeson;
                        }
                        else
                        {

                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS30)
                            {
                                vICMSDesontring = ((TNFeInfNFeDetImpostoICMSICMS30)icms.Item).vICMSDeson;
                            }
                            else
                            {

                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40)
                                {
                                    vICMSDesontring = ((TNFeInfNFeDetImpostoICMSICMS40)icms.Item).vICMSDeson;
                                }
                                else
                                {

                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS51)
                                    {
                                        vICMSDesontring = "0.00";
                                    }
                                    else
                                    {

                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60)
                                        {
                                            vICMSDesontring = "0.00";
                                        }
                                        else
                                        {

                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS70)
                                            {
                                                vICMSDesontring = ((TNFeInfNFeDetImpostoICMSICMS70)icms.Item).vICMSDeson;
                                            }
                                            else
                                            {

                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                                                {
                                                    vICMSDesontring = ((TNFeInfNFeDetImpostoICMSICMS90)icms.Item).vICMSDeson;
                                                }
                                                else
                                                {

                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN101)
                                                    {
                                                        vICMSDesontring = "0.00";
                                                    }
                                                    else
                                                    {

                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)
                                                        {
                                                            vICMSDesontring = "0.00";
                                                        }
                                                        else
                                                        {

                                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN201)
                                                            {
                                                                vICMSDesontring = "0.00";
                                                            }
                                                            else
                                                            {

                                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN202)
                                                                {
                                                                    vICMSDesontring = "0.00";
                                                                }
                                                                else
                                                                {

                                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                                                                    {
                                                                        vICMSDesontring = "0.00";
                                                                    }
                                                                    else
                                                                    {

                                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                                                                        {
                                                                            vICMSDesontring = "0.00";
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

                totalCalculado = Math.Round(totalCalculado + double.Parse(vICMSDesontring, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalICMSDesonerado)) > 0)
            {
                error = "Total do ICMS desonerado difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
