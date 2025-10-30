using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.Y.Cobranca
{
    /// <summary>
    /// Validação Y09-50: Rejeição 797 - Data de vencimento da parcela
    /// superior a 10 anos da data atual.
    /// </summary>
    public class Y09_50 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = string.Empty;

            if (nfe.infNFe.cobr?.dup == null)
            {
                return true;
            }

            DateTime dataLimite = DateTime.Now.AddYears(10);
            int nOcor = 0;

            foreach (var parcela in nfe.infNFe.cobr.dup)
            {
                nOcor++;
                if (string.IsNullOrEmpty(parcela.dVenc)) continue;

                DateTime dataVencimento;
                if (DateTime.TryParse(parcela.dVenc, out dataVencimento))
                {
                    if (dataVencimento > dataLimite)
                    {
                        error = $"Rejeição 797: Data de vencimento da parcela superior a 10 anos da data atual [nOcor: {nOcor}]";
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
