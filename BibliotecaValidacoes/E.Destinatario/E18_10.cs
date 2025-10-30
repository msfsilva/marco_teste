using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.E.Destinatario
{
    public class E18_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.emit.IEST != null)
            {


                if (nfe.infNFe.dest.ISUF !=null)
                {
                    error = "NFCe com informação da Inscrição Suframa do destinatário";
                    return false;
                }


            }
            error = "";
            return true;
        }
    }
}
