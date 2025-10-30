using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.E.Destinatario
{
    public class E17_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.emit.IEST != null)
            {


                if (nfe.infNFe.dest.IE !=null)
                {
                    error = "NFCe com informação da IE do destinatário";
                    return false;
                }


            }
            error = "";
            return true;
        }
    }
}
