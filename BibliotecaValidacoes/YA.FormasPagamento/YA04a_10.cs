using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.YA.FormasPagamento
{
    public class YA04a_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            if (nfe.infNFe.ide.mod == TMod.Item65)
            {
                foreach (TNFeInfNFePagDetPag pag in nfe.infNFe.pag.detPag)
                {
                    if (pag.card!=null)
                    {
                        if (pag.card.tpIntegraSpecified)
                        {
                            error = "Não informado o tipo de integração no pagamento com cartão de crédito/débito";
                            return false;
                        }
                    }
                }

                

            }
            error = "";
            return true;
        }
    }
}
