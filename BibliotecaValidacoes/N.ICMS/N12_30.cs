using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12_30:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20) continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40 && (((TNFeInfNFeDetImpostoICMSICMS40)icms.Item).CST == TNFeInfNFeDetImpostoICMSICMS40CST.Item40 || ((TNFeInfNFeDetImpostoICMSICMS40)icms.Item).CST==TNFeInfNFeDetImpostoICMSICMS40CST.Item41)) continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60) continue;
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90) continue;


                    if(icms.Item.GetType().ToString().Contains("TNFeInfNFeDetImpostoICMSICMSSN"))continue;
                    

                    error += "NFCe contendo item com CST inválido" + item.prod.cProd + " / ";
             
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
