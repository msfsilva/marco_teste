using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12a_40:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);



                    if ((icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102) ||
                        (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                        )
                    {
                        if (
                            item.prod.CFOP != "5101" && 
                            item.prod.CFOP != "5102" && 
                            item.prod.CFOP != "5103" && 
                            item.prod.CFOP != "5104" && 
                            item.prod.CFOP != "5115" 

                            )
                        {
                            error += "CSOSN não permitido para o CFOP informado no produto " + item.prod.cProd + " / ";
                        }    
                    }
                    
             
                }

                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
