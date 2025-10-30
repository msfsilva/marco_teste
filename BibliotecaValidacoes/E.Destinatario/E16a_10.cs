using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.E.Destinatario
{
    public class E16a_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.emit.IEST != null)
            {


                if (nfe.infNFe.dest.indIEDest !=TNFeInfNFeDestIndIEDest.Item9)
                {
                    error = "NFCe para destinatário contribuinte de ICMS";
                    return false;
                }


            }
            error = "";
            return true;
        }
    }
}
