using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B25b_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {

                if (nfe.infNFe.ide.indPres != TNFeInfNFeIdeIndPres.Item1 && nfe.infNFe.ide.indPres != TNFeInfNFeIdeIndPres.Item4)
                {
                    error = "NFCe em operação não presencial";
                    return false;
                }

            }
            error = "";
            return true;
        }
    }
}
