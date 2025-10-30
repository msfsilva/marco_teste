using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B25_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.finNFe  !=  TFinNFe.Item1)
                {
                    error = "NFCe com finalidade inválida";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
