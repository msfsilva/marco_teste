using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using dbProvider;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule;

namespace BibliotecaProdutos
{
    public class CargaFabricaReportClass
    {
        
        public string IdentificacaoPt { get; set; }
        public string DescricaoPt { get; set; }
        public double TempoSetup { get; set; }

        public string TempoSetupString
        {
            get { return ConverteHorasDouble(TempoSetup); }
        }

        public double TempoOperacao { get; set; }

        public string TempoOperacaoString
        {
            get { return ConverteHorasDouble(TempoOperacao); }
        }

        public double CustoHoraPosto { get; set; }

        public double CustoHoraTotal
        {
            get { return Math.Round((TempoSetup + TempoOperacao) * CustoHoraPosto, 2, MidpointRounding.AwayFromZero); }
        }


        private static byte[] _logoCliente;

        public byte[] LogoCliente
        {
            get
            {
                if (_logoCliente == null)
                {
                    LoadLogoCliente();
                }

                return _logoCliente;
            }
        }

        private static void LoadLogoCliente()
        {
            #region Logo

            byte[] tmp = IWTConfiguration.Conf.getBinaryConf(Constants.LOGO_EMPRESA);

            if (tmp != null)
            {
                MemoryStream ms = new MemoryStream(tmp);
                Image imagem = Image.FromStream(ms);

                imagem = IWTFunctions.IWTFunctions.ResizeImage(imagem, 100, 100, false);

                ms = new MemoryStream();
                imagem.Save(ms, ImageFormat.Bmp);
                tmp = ms.ToArray();
                _logoCliente = tmp;
            }

            #endregion
        }

        private string ConverteHorasDouble(double horasTotal)
        {
            //15.26

            int horas = (int) horasTotal;//15
            horasTotal = (horasTotal - horas)*60; //15.6
            int minutos = (int) (horasTotal); //15

            int segundos = (int) ((horasTotal - minutos) * 60);//36;

            return horas.ToString().PadLeft(2, '0') + ":" + minutos.ToString().PadLeft(2, '0') + ":" + segundos.ToString().PadLeft(2, '0');


        }






        public static List<CargaFabricaReportClass> GerarReport(DateTime? dataEntregaIni, DateTime? dataEntregaFim, DateTime? dataEntradaIni, DateTime? dataEntradaFim, ClassificacaoProdutoClass classificacao, IWTPostgreNpgsqlConnection conn )
        {
            try
            {
                Dictionary<PostoTrabalhoClass, CargaFabricaReportClass> ds = new Dictionary<PostoTrabalhoClass, CargaFabricaReportClass>();
                
                //busca todas as ops abertas
                List<OrdemProducaoClass> opsAbertas = new OrdemProducaoClass(LoginClass.UsuarioLogado.loggedUser, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Abertas",true)

                }).ConvertAll(a => (OrdemProducaoClass) a);


                //Como o relatório é gerado por ordem de produção e o filtro é de pedido então o sistema considera sempre os extremos, por exemplo, para o filtro de data de entrada se existir ao menos um pedido 
                //cuja data de entrada satisfaça a condição estabelecida toda a OP será considerada
                List<OrdemProducaoClass> opsFiltradas = new List<OrdemProducaoClass>();



                foreach (OrdemProducaoClass opAberta in opsAbertas)
                {
                    if (dataEntradaIni.HasValue)
                    {
                        if (opAberta.CollectionOrdemProducaoPedidoClassOrdemProducao.All(a => a.OrderItemEtiqueta.PedidoItemLinhaPrincipalPedido.DataEntrada.Date < dataEntradaIni.Value.Date))
                        {
                            continue;
                        }
                    }

                    if (dataEntradaFim.HasValue)
                    {
                        if (opAberta.CollectionOrdemProducaoPedidoClassOrdemProducao.All(a => a.OrderItemEtiqueta.PedidoItemLinhaPrincipalPedido.DataEntrada.Date > dataEntradaFim.Value.Date))
                        {
                            continue;
                        }
                    }


                    if (dataEntregaIni.HasValue)
                    {
                        if (opAberta.CollectionOrdemProducaoPedidoClassOrdemProducao.All(a => a.OrderItemEtiqueta.PedidoItemLinhaPrincipalPedido.DataEntrega.Date < dataEntregaIni.Value.Date))
                        {
                            continue;
                        }
                    }

                    if (dataEntregaFim.HasValue)
                    {
                        if (opAberta.CollectionOrdemProducaoPedidoClassOrdemProducao.All(a => a.OrderItemEtiqueta.PedidoItemLinhaPrincipalPedido.DataEntrega.Date > dataEntregaFim.Value.Date))
                        {
                            continue;
                        }
                    }

                    if (classificacao != null)
                    {
                        if (opAberta.Produto.ClassificacaoProduto != classificacao)
                        {
                            continue;
                        }

                    }

                    opsFiltradas.Add(opAberta);

                }
                


                List<PostoTrabalhoClass> postos = new PostoTrabalhoClass(LoginClass.UsuarioLogado.loggedUser, conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (PostoTrabalhoClass) a);

                foreach (PostoTrabalhoClass posto in postos)
                {
                    if (!ds.ContainsKey(posto))
                    {
                        CargaFabricaReportClass tmp = new CargaFabricaReportClass()
                        {
                            DescricaoPt = posto.Nome,
                            IdentificacaoPt = posto.Codigo,
                            CustoHoraPosto = posto.TaxaHora
                        };

                        ds.Add(posto, tmp);
                    }

                    CargaFabricaReportClass toRet = ds[posto];

                    foreach (OrdemProducaoClass op in opsFiltradas)
                    {

                        OrdemProducaoPostoTrabalhoClass postoOp = op.CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.FirstOrDefault(a => a.PostoTrabalho == posto);
                        if (postoOp == null)
                        {
                            continue;
                        }

                        if (op.CollectionOrdemProducaoPostoTrabalhoClassOrdemProducao.Any(a => a.Sequencia >= postoOp.Sequencia && a.Tempo1.HasValue))
                        {
                            //Já possui tempo apontado nesse posto ou em algum depois dele, então pode desconsiderar o tempo da OP pois ela já passou do posto ou está em produçõa nele
                            continue;
                        }

                        double qtd = op.Quantidade;

                        //TempoSetup em Horas
                        //TempoProdução em Segundos

                        double tempoSetup = postoOp.TempoSetup??0;
                        double tempoProducao = postoOp.TempoProducao ?? 0;
                        
                        toRet.TempoSetup = Math.Round(toRet.TempoSetup + tempoSetup, 8);
                        toRet.TempoOperacao = Math.Round(toRet.TempoOperacao + ((tempoProducao * qtd)/3600), 8);

                    }


                }

                return ds.Values.Where(a => a.TempoSetup > 0 || a.TempoOperacao > 0).ToList();
            }
            catch (Exception a)
            {
                throw new Exception("Erro ao carregar relatório.\r\n" + a.Message);
            }
        }
    }
}
