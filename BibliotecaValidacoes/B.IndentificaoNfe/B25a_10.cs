using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B25a_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.indFinal  ==  TNFeInfNFeIdeIndFinal.Item0)
                {
                    error = "NFCe em operação não destinada a consumidor final";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
