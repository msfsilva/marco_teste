using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12a_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500) continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900) continue;
                    
                    if (icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMS00")) continue;
                    if (icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMS20")) continue;
                    if (icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMS40")) continue;
                    if (icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMS60")) continue;
                    if (icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMS90")) continue;

                    error += "NFCe contendo item com CSOSN inválido" + item.prod.cProd + " / ";
             
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
