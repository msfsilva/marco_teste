using System.Linq;
using IWTNFCompleto.BibliotecaDatasets.v4_0;

namespace BibliotecaValidacoes.N.ICMS
{
    public class N12_20:IValidacao
    {
        public bool Validar(TNFe nfe, out string error)
        {
            error = "";
            if (nfe.infNFe.emit.CRT == TNFeInfNFeEmitCRT.Item1)
            {
                foreach (TNFeInfNFeDet item in nfe.infNFe.det)
                {
                    TNFeInfNFeDetImpostoICMS icms = (TNFeInfNFeDetImpostoICMS) item.imposto.Items.First(a => a is TNFeInfNFeDetImpostoICMS);


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS00)
                    {
                        error += "Informado CST 00 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS10)
                    {
                        error += "Informado CST 10 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS20)
                    {
                        error += "Informado CST 20 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS30)
                    {
                        error += "Informado CST 30 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS40)
                    {
                        string cst = ((TNFeInfNFeDetImpostoICMSICMS40) icms.Item).CST.ToString().Replace("Item", "");
                        error += "Informado CST " + cst + " para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS51)
                    {
                        error += "Informado CST 51 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS60)
                    {
                        error += "Informado CST 60 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }


                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS70)
                    {
                        error += "Informado CST 70 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

                    if (icms.Item is TNFeInfNFeDetImpostoICMSICMS90)
                    {
                        error += "Informado CST 90 para nota fiscal emitida pelo Simples no produto " + item.prod.cProd + " / ";
                    }

             
                }



                return string.IsNullOrWhiteSpace(error);
            }
            return true;
        }
    }
}
