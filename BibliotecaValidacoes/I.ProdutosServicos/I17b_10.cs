using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I17b_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (!string.IsNullOrWhiteSpace(item.prod.cEANTrib))
                {
                    if (!IWTFunctions.IWTFunctions.validaCodigoGTIN(item.prod.cEANTrib))
                    {
                        error += "Código GTIN (Antigo EAN) de tributação inválido para o produto " + item.prod.cProd + " / ";
                    }
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
