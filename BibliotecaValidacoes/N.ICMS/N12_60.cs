using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12_60:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    string vICMSST = "";
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                    {
                        if (((TNFeInfNFeDetImpostoICMSICMS90) icms.Item).vICMSST != null)
                        {
                            error += "Item com repasse de ICMS retido por Substituto Tributário no produto " + item.prod.cProd + "/ ";
                        }
                        
                    }

             
                }

                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
