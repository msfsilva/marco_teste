using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B09_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {



            DateTime dataEmissao;
            if (DateTime.TryParse(nfe.infNFe.ide.dhEmi, out dataEmissao))
            {
                double minutosDif = dataEmissao.Subtract(Configurations.DataIndependenteClass.GetData()).TotalMinutes;
                if (minutosDif>5)
                {
                    error = "A data de emissão da NFe/NFCe é posterior a data de transmissão";
                    return false;
                }
            }
            else
            {
                error = "A data de emissão da NFe/NFCe deve uma data válida: " + nfe.infNFe.ide.dhEmi;
                return false;
            }


            error = "";
            return true;
        }
    }
}
