using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12a_10:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.emit.CRT != TNFeInfNFeEmitCRT.Item1)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN101)
                    {
                        error += "Informado CSON 101 para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN102)
                    {
                        string cst = ((TNFeInfNFeDetImpostoICMSICMSSN102)icms.Item).CSOSN.ToString().Replace("Item", "");
                        error += "Informado CSON " + cst + " para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN201)
                    {
                        error += "Informado CSON 201 para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN202)
                    {
                        string cst = ((TNFeInfNFeDetImpostoICMSICMSSN202)icms.Item).CSOSN.ToString().Replace("Item", "");
                        error += "Informado CSON " + cst + " para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }

    
                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN500)
                    {
                        error += "Informado CSON 51 para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMSSN900)
                    {
                        error += "Informado CSON 60 para nota fiscal emitida fora do Simples no produto " + item.prod.cProd + " / ";
                    }



             
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
