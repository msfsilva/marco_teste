using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12a_44:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    if (
                        (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                        )
                    {
                        if (
                            item.prod.CFOP != "5405" && 
                            item.prod.CFOP != "5656" && 
                            item.prod.CFOP != "5667"
                            

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
