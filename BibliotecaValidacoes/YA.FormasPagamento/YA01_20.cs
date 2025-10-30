using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.YA.FormasPagamento
{
    public class YA01_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.pag == null)
                {
                    error = "NFCe deve possuir o grupo de Formas de Pagamento";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
