using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W03_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalBCICMS = double.Parse(nfe.infNFe.total.ICMSTot.vBC, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {

                TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);
                string vBCString = "";

                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)
                {
                    vBCString = ((TNFeInfNFeDetImpostoICMSICMS00) icms.Item).vBC;
                }
                else
                {


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        vBCString = ((TNFeInfNFeDetImpostoICMSICMS10) icms.Item).vBC;
                    }
                    else
                    {

                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20)
                        {
                            vBCString = ((TNFeInfNFeDetImpostoICMSICMS20) icms.Item).vBC;
                        }
                        else
                        {

                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS30)
                            {
                                vBCString = "0.00";
                            }
                            else
                            {

                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40)
                                {
                                    vBCString = "0.00";
                                }
                                else
                                {

                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS51)
                                    {
                                        vBCString = ((TNFeInfNFeDetImpostoICMSICMS51) icms.Item).vBC;
                                    }
                                    else
                                    {

                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60)
                                        {
                                            vBCString = "0.00";
                                        }
                                        else
                                        {

                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMS70)
                                            {
                                                vBCString = ((TNFeInfNFeDetImpostoICMSICMS70) icms.Item).vBC;
                                            }
                                            else
                                            {

                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                                                {
                                                    vBCString = ((TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vBC;
                                                }
                                                else
                                                {

                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN101)
                                                    {
                                                        vBCString = "0.00";
                                                    }
                                                    else
                                                    {

                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)
                                                        {
                                                            vBCString = "0.00";
                                                        }
                                                        else
                                                        {

                                                            if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN201)
                                                            {
                                                                vBCString = "0.00";
                                                            }
                                                            else
                                                            {

                                                                if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN202)
                                                                {
                                                                    vBCString = "0.00";
                                                                }
                                                                else
                                                                {

                                                                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                                                                    {
                                                                        vBCString = "0.00";
                                                                    }
                                                                    else
                                                                    {

                                                                        if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                                                                        {
                                                                            vBCString = ((TNFeInfNFeDetImpostoICMSICMSSN900) icms.Item).vBC;
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

                totalCalculado = Math.Round(totalCalculado + double.Parse(vBCString, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalBCICMS)) > 0)
            {
                error = "Total da BC do ICMS difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
