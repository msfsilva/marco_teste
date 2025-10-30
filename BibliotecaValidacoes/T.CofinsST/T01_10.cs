using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.T.CofinsST
{
    public class T01_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                error = "";
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    if (item.imposto.COFINSST != null)
                    {

                        error += "NFCe com grupo de Cofins ST no produto " + item.prod.cProd + " / ";
                    }


                }
                return string.IsNullOrWhiteSpace(error);
            }
            error = "";
            return true;
        }
    }
}
