using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I05_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.prod.NCM != "00" && item.prod.NCM.Length!=8)
                {
                    error += "NCM inválido para o produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
