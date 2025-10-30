using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I08_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if ((item.prod.CFOP.ToString().StartsWith("1") || item.prod.CFOP.ToString().StartsWith("2") || item.prod.CFOP.ToString().StartsWith("3")) && nfe.infNFe.ide.tpNF ==TNFeInfNFeIdeTpNF.Item1)
                {
                    error += "CFOP de entrada para nota fiscal de Saída no produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
