using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12_34:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                    {
                        if (((TNFeInfNFeDetImpostoICMSICMS90) icms.Item).modBCSTSpecified )
                        {
                            error += "NFCe contendo item com CST 90 e informando os dados do ICMS ST" + item.prod.cProd + " / ";
                        }
                    }
                    
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
