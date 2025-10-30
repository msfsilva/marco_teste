using System;
using System.Globalization;
using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;
using TMod = IWTNFCompleto.BibliotecaDatasets.v4_0.TMod;
using TNFe = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFe;
using TNFeInfNFeDet = IWTNFCompleto.BibliotecaDatasets.v4_0.TNFeInfNFeDet;

namespace BibliotecaValidacoes.W.Total
{
    public class W12_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            double valorTotalIPI = double.Parse(nfe.infNFe.total.ICMSTot.vIPI, NumberStyles.Any, CultureInfo.InvariantCulture);
            double totalCalculado = 0;

            foreach (TNFeInfNFeDet item in nfe.infNFe.det)
            {
                TIpi ipi = (TIpi)item.imposto.Items.FirstOrDefault(a => a is TIpi);

                if (ipi != null)
                {
                    if (ipi.Item is TIpiIPINT)
                    {
                        continue;
                    }


                    if (ipi.Item is TIpiIPITrib)
                    {
                        totalCalculado = Math.Round(totalCalculado + double.Parse(((TIpiIPITrib) ipi.Item).vIPI, NumberStyles.Any, CultureInfo.InvariantCulture), 2);
                    }
                    else
                    {
                        throw new Exception("Tipo de objeto de IPI inválido");
                    }
                }
            }

            if (Math.Abs(Math.Abs(totalCalculado - valorTotalIPI)) > 0)
            {
                error = "Total do IPI difere do somatório dos itens";
                return false;
            }


            error = "";
            return true;


        
        }
    }
}
