using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.ZC.Cana
{
    public class ZC01_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                if (nfe.infNFe.cana != null)
                {
                    error = "NFCe com dados de aquisição de Cana";
                    return false;
                }
            }
            error = "";
            return true;
        }
    }
}
