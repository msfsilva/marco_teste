using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using System.Globalization;

namespace BibliotecaValidacoes.YA.FormasPagamento
{
    /// <summary>
    /// Validação YA03-10 e YA03-20: Rejeição 865 e 866 - Trata a consistência
    /// entre o total da nota e o total dos pagamentos.
    /// </summary>
    public class YA03_10_20 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {

            
            error = string.Empty;

            // Regra não se aplica para nota fiscal de Ajuste (finNFe=3) ou Devolução (finNFe=4)
            if (nfe.infNFe.ide.finNFe == TFinNFe.Item3 || nfe.infNFe.ide.finNFe == TFinNFe.Item4)
            {
                return true;
            }

            // Se não houver pagamentos, não valida
            if (nfe.infNFe.pag?.detPag == null || !nfe.infNFe.pag.detPag.Any())
            {
                return true;
            }

            // Regra não se aplica se o meio de pagamento for "90 - Sem Pagamento"
            if (nfe.infNFe.pag.detPag.Any(p => p.tPagLegado == TNFeInfNFePagDetPagTPagLegado.SemPagamento))
            {
                return true;
            }

            
            decimal valorTotalNota = decimal.Parse(nfe.infNFe.total.ICMSTot.vNF, CultureInfo.InvariantCulture);
            decimal valorTotalPagamentos = nfe.infNFe.pag.detPag.Sum(p => decimal.Parse(p.vPag, CultureInfo.InvariantCulture));
            decimal valorTroco = 0;
            if (!string.IsNullOrEmpty(nfe.infNFe.pag.vTroco))
            {
                valorTroco = decimal.Parse(nfe.infNFe.pag.vTroco, CultureInfo.InvariantCulture);
            }

            // Rejeição 865: Total dos pagamentos menor que o total da nota
            if (valorTotalPagamentos < valorTotalNota)
            {
                error = "Rejeição 865: Total dos pagamentos menor que o total da nota.";
                return false;
            }

            // Rejeição 866: Ausência de troco quando o valor dos pagamentos for maior que o total da nota
            if (valorTotalPagamentos > valorTotalNota && valorTroco == 0)
            {
                error = "Rejeição 866: Ausência de troco quando o valor dos pagamentos informados for maior que o total da nota.";
                return false;
            }

            // Validação complementar para o troco
            if (valorTotalPagamentos > valorTotalNota)
            {
                if (valorTotalPagamentos - valorTotalNota != valorTroco)
                {
                    error = "O valor do troco informado não corresponde à diferença entre o total pago e o total da nota.";
                    return false;
                }
            }


            return true;
        }
    }
}
