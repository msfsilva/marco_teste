using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.BA.DocumentoFiscalReferenciado
{
    public class BA01_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.NFref != null && nfe.infNFe.ide.NFref.Count>0)
                {
                    error = "NFCe não pode referenciar documento fiscal";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
