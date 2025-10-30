using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W05_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalBCICMSST = double.Parse(nfe.infNFe.total.ICMSTot.vBCST, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {

                TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);
                string vBCSTstring = "";

                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)
                {
                    vBCSTstring = "0.00";
                }
                else
                {


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMS10)icms.Item).vBCST;
                    }
                    else
                    {

                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20)
                        {
                            vBCSTstring = "0.00";
                        }
                        else
                        {

                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS30)
                            {
                                vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMS30)icms.Item).vBCST;
                            }
                            else
                            {

                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40)
                                {
                                    vBCSTstring = "0.00";
                                }
                                else
                                {

                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS51)
                                    {
                                        vBCSTstring = "0.00";
                                    }
                                    else
                                    {

                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60)
                                        {
                                            vBCSTstring = "0.00";
                                        }
                                        else
                                        {

                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS70)
                                            {
                                                vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMS70)icms.Item).vBCST;
                                            }
                                            else
                                            {

                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                                                {
                                                    vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMS90)icms.Item).vBCST;
                                                }
                                                else
                                                {

                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN101)
                                                    {
                                                        vBCSTstring = "0.00";
                                                    }
                                                    else
                                                    {

                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)
                                                        {
                                                            vBCSTstring = "0.00";
                                                        }
                                                        else
                                                        {

                                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN201)
                                                            {
                                                                vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN201)icms.Item).vBCST;
                                                            }
                                                            else
                                                            {

                                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN202)
                                                                {
                                                                    vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN202)icms.Item).vBCST;
                                                                }
                                                                else
                                                                {

                                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                                                                    {
                                                                        vBCSTstring = "0.00";
                                                                    }
                                                                    else
                                                                    {

                                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                                                                        {
                                                                            vBCSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN900)icms.Item).vBCST;
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

                totalCalculado = Math.Round(totalCalculado + double.Parse(vBCSTstring, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalBCICMSST)) > 0)
            {
                error = "Total da BC ICMS-ST difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
