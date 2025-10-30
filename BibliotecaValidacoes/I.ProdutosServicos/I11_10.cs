using System;
using System.Globalization;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.I.ProdutosServicos
{
    public class I11_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";

            if (nfe.infNFe.ide.finNFe == TFinNFe.Item1)
            {

                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    double vProd = double.Parse(item.prod.vProd, NumberStyles.Any, CultureInfo.InvariantCulture);
                    double vUnCom = double.Parse(item.prod.vUnCom, NumberStyles.Any, CultureInfo.InvariantCulture);
                    double qCom = double.Parse(item.prod.qCom, NumberStyles.Any, CultureInfo.InvariantCulture);
                    double valorCalculado = Math.Round(vUnCom*qCom, 2);
                    double dif = Math.Abs(Math.Round(vProd - valorCalculado, 3));


                    if (dif > 0.01)
                    {
                        error += "Valor do produto difere do produto Valor Unitário e Quantidade no item " + item.prod.cProd + " / ";
                    }
                }


                return string.IsNullOrWhiteSpace(error);
            }
            return true;

        }
    }
}
