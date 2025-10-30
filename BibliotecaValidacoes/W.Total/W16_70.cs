using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W16_70:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            /*
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                double valorTotalNf = 0;
                if (nfe.infNFe.total.ICMSTot.vNF != null)
                {
                    valorTotalNf = double.Parse(nfe.infNFe.total.ICMSTot.vNF, NumberStyles.Any, CultureInfo.InvariantCulture);
                }
                double totalCalculado = 0;

                foreach (TNFeInfNFePag pagto in nfe.infNFe.pag)
                {
                    if (pagto.vPag != null)
                    {
                        totalCalculado = Math.Round(totalCalculado + double.Parse(pagto.vPag, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                    }
                }

                if (Math.Abs(Math.Abs(totalCalculado - valorTotalNf)) > 1.00)
                {
                    error = "NFC-e com somatório dos pagamentos diferente do total da Nota Fiscal";
                    return false;
                }
            }

            */
            error = "";
            return true;


        
        }
    }
}
