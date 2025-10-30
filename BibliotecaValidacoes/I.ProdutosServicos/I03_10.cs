using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I03_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (!IWTFunctions.IWTFunctions.validaCodigoGTIN(item.prod.cEAN))
                {
                    error += "Código GTIN (Antigo EAN) inválido para o produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
