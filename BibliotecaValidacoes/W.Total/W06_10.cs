using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.W.Total
{
    /// <summary>
    /// Validação W06-10: Total do ICMS ST difere do somatório nos itens.
    /// Versão final compatível com .NET 4.5.2, usando if-else if.
    /// </summary>
    public class W06_10 : IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalICMSST;
            if (!double.TryParse(nfe.infNFe.total.ICMSTot.vST, NumberStyles.Any, CultureInfo.InvariantCulture, out valorTotalICMSST))
            {
                valorTotalICMSST = 0;
            }

            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                var icmsGroup = item.imposto.Items.FirstOrDefault(a => a is TNFeInfNFeDetImpostoICMS);

                if (icmsGroup != null)
                {
                    var icms = (TNFeInfNFeDetImpostoICMS)icmsGroup;
                    string vSTstring = "0.00";
                    var icmsItem = icms.Item;

                    // Estrutura if-else if compatível com C# 5 (.NET 4.5.2)
                    if (icmsItem is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMS10)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMS30)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMS30)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMS70)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMS70)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMS90)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMS90)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMSSN201)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN201)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMSSN202)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN202)icmsItem).vICMSST;
                    }
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMSSN900)
                    {
                        vSTstring = ((TNFeInfNFeDetImpostoICMSICMSSN900)icmsItem).vICMSST;
                    }
                    // Agrupando todos os casos que SABIDAMENTE não possuem vICMSST
                    else if (icmsItem is TNFeInfNFeDetImpostoICMSICMS00 ||
                             icmsItem is TNFeInfNFeDetImpostoICMSICMS20 ||
                             icmsItem is TNFeInfNFeDetImpostoICMSICMS40 || // Abrange 40, 41, 50
                             icmsItem is TNFeInfNFeDetImpostoICMSICMS51 ||
                             icmsItem is TNFeInfNFeDetImpostoICMSICMS60 ||
                             icmsItem is TNFeInfNFeDetImpostoICMSICMSSN101 ||
                             icmsItem is TNFeInfNFeDetImpostoICMSICMSSN102 || // Abrange 102, 103, 300, 400
                             icmsItem is TNFeInfNFeDetImpostoICMSICMSSN500)
                    {
                        vSTstring = "0.00";
                    }
                    // Mantendo a rigidez: se o tipo não for nenhum dos acima, lança o erro.
                    else
                    {
                        // Adicionado para cobrir todos os tipos da sua definição de `Item`
                        if (icmsItem is TNFeInfNFeDetImpostoICMSICMS02 ||
                            icmsItem is TNFeInfNFeDetImpostoICMSICMS15 ||
                            icmsItem is TNFeInfNFeDetImpostoICMSICMS53 ||
                            icmsItem is TNFeInfNFeDetImpostoICMSICMS61 ||
                            icmsItem is TNFeInfNFeDetImpostoICMSICMSPart ||
                            icmsItem is TNFeInfNFeDetImpostoICMSICMSST)
                        {
                            vSTstring = "0.00"; // Esses tipos também não possuem vICMSST
                        }
                        else
                        {
                            throw new Exception("Tipo do objeto de icms não tratado na validação W06-10: " + icmsItem.GetType().Name);
                        }
                    }

                    double valorItemST;
                    if (!string.IsNullOrEmpty(vSTstring) && double.TryParse(vSTstring, NumberStyles.Any, CultureInfo.InvariantCulture, out valorItemST))
                    {
                        totalCalculado += valorItemST;
                    }
                }
            }

            totalCalculado = Math.Round(totalCalculado, 2);

            if (Math.Abs(totalCalculado - valorTotalICMSST) > 0.01)
            {
                error = $"Total do ICMS-ST difere do somatório dos itens. Total nos itens: {totalCalculado:F2}, Total na nota: {valorTotalICMSST:F2}.";
                return false;
            }

            error = "";
            return true;
        }
    }
}
