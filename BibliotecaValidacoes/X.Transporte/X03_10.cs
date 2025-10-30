using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;
using TNFeInfNFeTranspModFrete = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete;

namespace BibliotecaValidacoes.X.Transporte
{
    public class X03_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                if (nfe.infNFe.transp.transporta!=null && nfe.infNFe.ide.indPres != TNFeInfNFeIdeIndPres.Item4)
                {
                    error = "NFCe com transportador e não é de entrega a domicílio";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
