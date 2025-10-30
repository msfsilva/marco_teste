using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.E.Destinatario
{
    public class E02_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.dest != null && nfe.infNFe.emit.Item == nfe.infNFe.dest.Item)
                {


                    error = "NFCe com destinatário e remetentes iguais";
                    return false;


                }
            }
            error = "";
            return true;
        }
    }
}
