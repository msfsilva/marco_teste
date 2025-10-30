using System.Globalization;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I17_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.prod.vDesc == null) continue;

                double vProd = double.Parse(item.prod.vProd, NumberStyles.Any, CultureInfo.InvariantCulture);
                double vDesc = double.Parse(item.prod.vDesc, NumberStyles.Any, CultureInfo.InvariantCulture);
                if (vDesc>vProd)
                {
                    error += "Item com valor de desconto maior do que o valor do produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
