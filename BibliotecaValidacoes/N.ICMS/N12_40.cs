using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12_40:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    if ((icms.Item is TNFeInfNFeDetImpostoICMSICMS00) ||
                        (icms.Item is TNFeInfNFeDetImpostoICMSICMS20) ||
                        (icms.Item is TNFeInfNFeDetImpostoICMSICMS40 && (((TNFeInfNFeDetImpostoICMSICMS40) icms.Item).CST == TNFeInfNFeDetImpostoICMSICMS40CST.Item40 || ((TNFeInfNFeDetImpostoICMSICMS40) icms.Item).CST == TNFeInfNFeDetImpostoICMSICMS40CST.Item41)) ||
                        (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
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
                            error += "CST não permitido para o CFOP informado no produto " + item.prod.cProd + " / ";
                        }    
                    }
                    
             
                }

                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
