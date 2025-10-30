using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N17_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.finNFe == TFinNFe.Item1)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);


                    TNFeInfNFeDetImpostoICMSICMS00 icmsicms00 = icms.Item as TNFeInfNFeDetImpostoICMSICMS00;
                    if (icmsicms00 != null)
                    {
                        double valorICMS = double.Parse(icmsicms00.vICMS, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double bcICMS = double.Parse(icmsicms00.vBC, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double aliquotaICMS = double.Parse(icmsicms00.pICMS, NumberStyles.Any, CultureInfo.InvariantCulture);

                        double valorCalulado = Math.Round(bcICMS*aliquotaICMS/100, 2);
                        if (Math.Abs(Math.Round(valorCalulado - valorICMS, 2)) > 0.01)
                        {
                            error += "Valor do ICMS difere do produto BC e Alíquota no produto " + item.prod.cProd + " / ";
                        }
                    }

                    TNFeInfNFeDetImpostoICMSICMS10 icmsicms10 = icms.Item as TNFeInfNFeDetImpostoICMSICMS10;
                    if (icmsicms10 != null)
                    {
                        double valorICMS = double.Parse(icmsicms10.vICMS, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double bcICMS = double.Parse(icmsicms10.vBC, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double aliquotaICMS = double.Parse(icmsicms10.pICMS, NumberStyles.Any, CultureInfo.InvariantCulture);

                        double valorCalulado = Math.Round(bcICMS * aliquotaICMS / 100, 2);
                        if (Math.Abs(Math.Round(valorCalulado - valorICMS, 2)) > 0.01)
                        {
                            error += "Valor do ICMS difere do produto BC e Alíquota no produto " + item.prod.cProd + " / ";
                        }
                    }

                    TNFeInfNFeDetImpostoICMSICMS20 icmsicms20 = icms.Item as TNFeInfNFeDetImpostoICMSICMS20;
                    if (icmsicms20 != null)
                    {
                        double valorICMS = double.Parse(icmsicms20.vICMS, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double bcICMS = double.Parse(icmsicms20.vBC, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double aliquotaICMS = double.Parse(icmsicms20.pICMS, NumberStyles.Any, CultureInfo.InvariantCulture);

                        double valorCalulado = Math.Round(bcICMS * aliquotaICMS / 100, 2);
                        if (Math.Abs(Math.Round(valorCalulado - valorICMS, 2)) > 0.01)
                        {
                            error += "Valor do ICMS difere do produto BC e Alíquota no produto " + item.prod.cProd + " / ";
                        }
                    }

                    TNFeInfNFeDetImpostoICMSICMS70 icmsicms70 = icms.Item as TNFeInfNFeDetImpostoICMSICMS70;
                    if (icmsicms70 != null)
                    {
                        double valorICMS = double.Parse(icmsicms70.vICMS, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double bcICMS = double.Parse(icmsicms70.vBC, NumberStyles.Any, CultureInfo.InvariantCulture);
                        double aliquotaICMS = double.Parse(icmsicms70.pICMS, NumberStyles.Any, CultureInfo.InvariantCulture);

                        double valorCalulado = Math.Round(bcICMS * aliquotaICMS / 100, 2);
                        if (Math.Abs(Math.Round(valorCalulado - valorICMS, 2)) > 0.01)
                        {
                            error += "Valor do ICMS difere do produto BC e Alíquota no produto " + item.prod.cProd + " / ";
                        }
                    }
                    
             
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
