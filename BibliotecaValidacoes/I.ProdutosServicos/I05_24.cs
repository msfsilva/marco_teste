using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I05_24:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                if (item.prod.NCM == "00" && nfe.infNFe.ide.finNFe != TFinNFe.Item3)
                {
                    error += "Informado o NCM 00 indevidamente para o produto " + item.prod.cProd + " / ";
                }
            }

          
            return string.IsNullOrWhiteSpace(error);
        }
    }
}
