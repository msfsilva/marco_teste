using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaComunicacaoGAD.api;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;

namespace BibliotecaEntidades.ClassesAuxiliares
{
    public static class ConfiguraConexaoGad
    {
        public static bool GadAtivo { get; private set; }

        public static void Configura()
        {
            ConexaoGad.IdFornecedor = 0;
            string tmp = IWTConfiguration.Conf.getConf(ProjectConstants.Constants.ID_FORNECEDOR_GAD);
            if (!string.IsNullOrWhiteSpace(tmp))
            {
                int id;
                if (int.TryParse(tmp, out id))
                {
                    ConexaoGad.IdFornecedor = id;
                }
            }

            GadAtivo = ConexaoGad.IdFornecedor > 0;
            ConexaoGad.BaseAddress = "http://insightwt.no-ip.org:57411/";
            //ConexaoGad.BaseAddress = "http://192.168.125.120:8081/";
        }


        public static string ConverteCodigoBarrasGadCustomizado(string barcode, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            
            //PadraoGad: GAD OC(15) POS(3) ITEM(20) SEQUENCIAL(3)- pad left com espaços

            //Padrao EASI: ICN -> Item Interno Customizado: ICN|ID_ORDER_NUMBER_ETIQUETA_PAI|ID Código de Barras|numero do item sequencial
            barcode = barcode.Trim();
            if (!barcode.StartsWith("GAD"))
            {
                return barcode;
            }


            if (barcode.StartsWith("GAD2"))
            {
                throw new ExcecaoTratada("Leia primeiro o código de barras superior da Etiqueta");
            }

            ComplementoEtiquetaGadForm form = new ComplementoEtiquetaGadForm();
            form.ShowDialog();

            if (string.IsNullOrWhiteSpace(form.CodigoBarrasLido))
            {
                return barcode;
            }

            string barcode1 = barcode;
            string barcode2 = form.CodigoBarrasLido;


            string oc = barcode1.Substring(4, barcode1.Length - 6 - 4).Trim();

            string tmp = barcode1.Substring(barcode1.Length - 6 , 3).Trim();
            int pos;
            if (!int.TryParse(tmp,out pos))
            {
                throw new ExcecaoTratada("Código de barras da etiqueta GAD Inválido (2), consulte a equipe IWT");
            }
            string item = barcode2.Substring(4).Trim();

            tmp = barcode1.Substring(barcode1.Length - 3, 3).Trim();
            int sequencial;
            if (!int.TryParse(tmp, out sequencial))
            {
                throw new ExcecaoTratada("Código de barras da etiqueta GAD Inválido (3), consulte a equipe IWT");
            }

            //IdentificaPai
            List<OrderItemEtiquetaClass> possiveisPais = new OrderItemEtiquetaClass(usuario, conn).Search(
                new List<SearchParameterClass>()
                {
                    new SearchParameterClass("OrderNumberExato", oc), 
                    new SearchParameterClass("OrderPos", pos), 
                    new SearchParameterClass("NivelItem", (short)0),
                    new SearchParameterClass("NotaFiscal", true)
                })
                .ConvertAll(a => (OrderItemEtiquetaClass) a).ToList();

            if (possiveisPais.Count == 0)
            {
                throw new ExcecaoTratada("Não foi possível encontrar o item pai do pedido " + oc + "/" + pos + " no EASI, certifique-se que o pedido foi importado e configurado no EASI");
            }

            if (possiveisPais.Count > 1)
            {
                throw new ExcecaoTratada("Foram encontrados diversos itens pai do pedido " + oc + "/" + pos + " no EASI, utlize a etiqueta do EASI para essa operação");
            }

            OrderItemEtiquetaClass pai = possiveisPais.First();

            //Identifica o Código de Barras
            List<CodigoBarraClass> possiveisCodigoBarras = new CodigoBarraClass(usuario, conn).Search(
                    new List<SearchParameterClass>()
                    {
                        new SearchParameterClass("CodigoItemExato", item),
                    })
                .ConvertAll(a => (CodigoBarraClass)a).ToList();

            if (possiveisCodigoBarras.Count == 0)
            {
                CodigoBarraClass tmpBarra = new CodigoBarraClass(usuario, conn)
                {
                    CodigoItem = item,
                    Dimensao = "0",
                };
                possiveisCodigoBarras.Add(tmpBarra);
                tmpBarra.Save();
            }

            if (possiveisCodigoBarras.Count > 1)
            {
                throw new ExcecaoTratada("O produto " + item + " diversas dimensões no EASI, utlize a etiqueta do EASI para essa operação");
            }

            CodigoBarraClass codigoBarra = possiveisCodigoBarras.First();

            barcode = "ICN|" + pai.ID + "|" + codigoBarra.ID + "|" + sequencial;
            return barcode;
        }

    }

}
