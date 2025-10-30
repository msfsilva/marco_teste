using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.UA.DevolucaoTributos
{
    public class UA01_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                error = "";
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    if (item.impostoDevol != null)
                    {
                        error += "NFC-e com grupo de devolução de tributos no produto " + item.prod.cProd + "/ ";
                    }
                }

                return string.IsNullOrEmpty(error);
            }
            error = "";
            return true;
        }
    }
}
