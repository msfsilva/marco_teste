using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.YA.FormasPagamento
{
    public class YA05_10:IValidacao
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
                            if (pag.card.tpIntegra == TNFeInfNFePagDetPagCardTpIntegra.Item1 && (pag.card.CNPJ == null || pag.card.cAut == null))
                            {
                                error = "Não informado os dados da operação de pagamento por cartão de crédito/débito";
                                return false;
                            }
                        }
                    }
                }

                

            }
            error = "";
            return true;
        }
    }
}
