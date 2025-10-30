using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;
using TNFeInfNFeTranspModFrete = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete;

namespace BibliotecaValidacoes.X.Transporte
{
    public class X25b_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                if (nfe.infNFe.transp.ItemsElementName != null)
                {
                    if (nfe.infNFe.transp.ItemsElementName.Any(a => a == TNFeInfNFeTransp.ItemsChoiceType5.balsa))
                    {
                        error = "NFCe com dados da balsa de Transporte";
                        return false;
                    }
                }

            }
            error = "";
            return true;
        }
    }
}
