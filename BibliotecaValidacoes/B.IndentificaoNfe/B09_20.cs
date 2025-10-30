using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.B.IndentificaoNfe
{
    public class B09_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item55)
            {
                if (nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.EmissaoNormal || nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaDPEC || nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCAN || nfe.infNFe.ide.TpEmisLegado == TNFeInfNFeIdeTpEmisLegado.ContingenciaSVCRS)
                {

                    DateTime dataEmissao;
                    if (DateTime.TryParse(nfe.infNFe.ide.dhEmi, out dataEmissao))
                    {
                        if (dataEmissao.AddDays(30) < Configurations.DataIndependenteClass.GetData())
                        {
                            error = "A data de emissão da NFe/NFCe está muito atrasada";
                            return false;
                        }
                    }
                    else
                    {
                        error = "A data de emissão da NFe/NFCe deve uma data válida: " + nfe.infNFe.ide.dhEmi;
                        return false;
                    }
                }
            }
            error = "";
            return true;
        }
    }
}
