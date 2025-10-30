using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B09_40:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                DateTime dataEmissao;
                if (DateTime.TryParse(nfe.infNFe.ide.dhEmi, out dataEmissao))
                {
                    double minutosDif = Math.Abs(dataEmissao.Subtract(Configurations.DataIndependenteClass.GetData()).TotalMinutes);
                    if (minutosDif > 5)
                    {
                        error = "A data de emissão da NFCe está muito atrasada";
                        return false;
                    }
                }
                else
                {
                    error = "A data de emissão da NFCe deve uma data válida: " + nfe.infNFe.ide.dhEmi;
                    return false;
                }
            }
            error = "";
            return true;
        }
    }
}
