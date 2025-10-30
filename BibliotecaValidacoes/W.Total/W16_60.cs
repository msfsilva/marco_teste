using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W16_50:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                double valorTotalNfe = double.Parse(nfe.infNFe.total.ICMSTot.vNF, NumberStyles.Any, CultureInfo.InvariantCulture);

                if (valorTotalNfe > 100000 && (nfe.infNFe.dest == null || nfe.infNFe.dest.xNome == null))
                {
                    error = "Total da NFC-e superior ao limite permitido para destinatário não identificado (Nome)";
                    return false;
                }
            }

            error = "";
            return true;


        
        }
    }
}
