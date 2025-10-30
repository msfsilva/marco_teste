using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;

namespace BibliotecaValidacoes.YA.FormasPagamento
{
    /// <summary>
    /// Validação YA04-10: Rejeição 391 - Não informados os dados do cartão
    /// de crédito / débito / PIX.
    /// </summary>
    public class YA04_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = string.Empty;

            if (nfe.infNFe.pag?.detPag == null)
            {
                return true;
            }

            int nOcor = 0;
            foreach (var pagamento in nfe.infNFe.pag.detPag)
            {
                nOcor++;
                // Verifica se o pagamento é com Cartão de Crédito(03), Débito(04) ou PIX(17)
                bool isCartaoOuPix = pagamento.tPagLegado == TNFeInfNFePagDetPagTPagLegado.CartaoCredito|| pagamento.tPagLegado == TNFeInfNFePagDetPagTPagLegado.CartaoDebito || pagamento.tPagLegado == TNFeInfNFePagDetPagTPagLegado.Pix;

                if (isCartaoOuPix && pagamento.card == null)
                {
                    error = $"Rejeição 391: Não informados os dados da operação (cartão/pix) para a forma de pagamento [nOcor:{nOcor}].";
                    return false;
                }
            }

            return true;
        }
    }
}
