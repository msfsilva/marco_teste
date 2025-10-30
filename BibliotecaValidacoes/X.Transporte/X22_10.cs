using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;
using TNFeInfNFeTranspModFrete = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeTranspModFrete;

namespace BibliotecaValidacoes.X.Transporte
{
    public class X22_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                if (nfe.infNFe.transp.ItemsElementName != null)
                {
                    if (nfe.infNFe.transp.ItemsElementName.Any(a => a == TNFeInfNFeTransp.ItemsChoiceType5.reboque))
                    {
                        error = "NFCe com dados de reboque do veículo de Transporte";
                        return false;
                    }
                }

            }
            error = "";
            return true;
        }
    }
}
