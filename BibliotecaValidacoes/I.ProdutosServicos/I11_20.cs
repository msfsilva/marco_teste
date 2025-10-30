using System;
using System.Globalization;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I11_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    if (item.prod.indTot == TNFeInfNFeDetProdIndTot.Item0)
                    {

                        error += "NFCe com item não participante do total (" + item.prod.cProd + ") / ";
                    }
                }


                return string.IsNullOrWhiteSpace(error);
            }
            return true;

        }
    }
}
