using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B07_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN || nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS)
            {
                int serieInt;
                if (int.TryParse(nfe.infNFe.ide.serie, out serieInt))
                {
                    if (serieInt < 900 || serieInt > 999)
                    {
                        error = "A série da NFe/NFCe deve ser de 900 a 999 para emissões em contingência";
                        return false;
                    }
                }
                else
                {
                    error = "A série da NFe/NFCe deve um número válido: " + nfe.infNFe.ide.serie;
                    return false;
                }
            }
            error = "";
            return true;
        }
    }
}
