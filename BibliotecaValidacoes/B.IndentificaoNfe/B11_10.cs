using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B10_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.dhSaiEnt != null)
                {
                    error = "NFCe com data de entrada e saída";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
