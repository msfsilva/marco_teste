using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.C.Emitente
{
    public class C18_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.emit.IEST!=null)
            {

                if (nfe.infNFe.ide.NFref != null && nfe.infNFe.ide.NFref.Count>0)
                {
                    error = "NFCe não deve informar IE de substituto tributário";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
