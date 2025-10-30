using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I08_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if ((item.prod.CFOP.ToString().StartsWith("5") || item.prod.CFOP.ToString().StartsWith("6") || item.prod.CFOP.ToString().StartsWith("7")) && nfe.infNFe.ide.tpNF ==TNFeInfNFeIdeTpNF.Item0)
                {
                    error += "CFOP de saída para nota fiscal de entrada no produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
