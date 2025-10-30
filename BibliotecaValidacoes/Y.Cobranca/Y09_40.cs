using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaValidacoes;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

// Este arquivo contém as novas classes de validação introduzidas ou tornadas
// obrigatórias pela Nota Técnica 2025.001.
// Adicione este arquivo ao seu projeto 'BibliotecaValidacoes' e inclua-o no
// arquivo .csproj para que o sistema de carregamento dinâmico o encontre.

namespace BibliotecaValidacoes.Y.Cobranca
{
    /// <summary>
    /// Validação Y09-40: Rejeição 853 - Dados de cobrança não devem ser
    /// informados para pagamento à vista.
    /// </summary>
    public class Y09_40 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = string.Empty;

            // Se não houver grupo de pagamento, a regra não se aplica.
            if (nfe.infNFe.pag == null || nfe.infNFe.pag.detPag == null || !nfe.infNFe.pag.detPag.Any())
            {
                return true;
            }

            // Verifica se alguma forma de pagamento é "à vista" (indPag = 0)
            bool isPagamentoAVista = nfe.infNFe.pag.detPag.Any(p => p.indPag == TNFeInfNFePagDetPagIndPag.Item0);

            // Verifica se o grupo de cobrança (duplicatas) foi informado
            bool temCobranca = nfe.infNFe.cobr != null && nfe.infNFe.cobr.dup != null && nfe.infNFe.cobr.dup.Any();

            if (isPagamentoAVista && temCobranca)
            {
                error = "Rejeição 853: Dados de cobrança (duplicatas) não devem ser informados para pagamento à vista.";
                return false;
            }

            return true;
        }
    }

   
}
