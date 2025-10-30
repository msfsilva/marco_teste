using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B11_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.tpNF==TNFeInfNFeIdeTpNF.Item0)
                {
                    error = "NFCe para operação de entrada";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
