using System.Linq;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.ZB.Compra
{
    public class ZB01_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                if (nfe.infNFe.compra != null)
                {
                    error = "NFCe com dados de compra (Empenho, Pedido, Contrato)";
                    return false;
                }
            }
            error = "";
            return true;
        }
    }
}
