using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.E.Destinatario
{
    public class E01_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.emit.IEST!=null)
            {

                if (nfe.infNFe.ide.indPres==TNFeInfNFeIdeIndPres.Item4)
                {
                    if (nfe.infNFe.dest == null)
                    {
                        error = "NFCe de entrega a domicílio sem a identificação do destinatário";
                        return false;
                    }
                }

            }
            error = "";
            return true;
        }
    }
}
