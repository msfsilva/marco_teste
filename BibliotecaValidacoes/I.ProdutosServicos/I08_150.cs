using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I08_150:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";

            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    if (
                        item.prod.CFOP != "5101" &&
                        item.prod.CFOP != "5102" &&
                        item.prod.CFOP != "5103" &&
                        item.prod.CFOP != "5104" &&
                        item.prod.CFOP != "5115" &&
                        item.prod.CFOP != "5405" &&
                        item.prod.CFOP != "5656" &&
                        item.prod.CFOP != "5667" &&
                        item.prod.CFOP != "5933"
                        )
                    {
                        error += "CFOP inválido para emissão de NFCe no produto " + item.prod.cProd + " / ";
                    }
                }


                return string.IsNullOrWhiteSpace(error);
            }

            return true;
        }
    }
}
