using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Compras;
using BibliotecaEntidades.Operacoes.Estoque;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTNFCompleto.BibliotecaDatasets.v3_10;
using IWTPostgreNpgsql;
using ProjectConstants;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

namespace BibliotecaEntidades.Relatorios
{
    public class RelatorioCompletoEstoqueReportClass
    {
        public string Tipo { get; private set; }
        public string Codigo { get; private set; }
        public string Descricao { get; private set; }
        public double EstoqueAtual { get; private set; }
        public double EstoqueReservado { get; private set; }
        public double Comprado { get; private set; }

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

        public double EstoqueProjetado => Math.Round(EstoqueAtual - EstoqueReservado + Comprado, 5);


        public static List<RelatorioCompletoEstoqueReportClass> GerarRelatorio(bool incluirMateriais, bool incluirProdutos, bool incluirEpis, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario)
        {
            List<RelatorioCompletoEstoqueReportClass> toRet = new List<RelatorioCompletoEstoqueReportClass>();

            IWTPostgreNpgsqlCommand command = conn.CreateCommand();

            NecessidadeCompra calc = new NecessidadeCompra(
                IWTConfiguration.Conf.getConf(Constants.SEMANA_TIPO_DEFINICAO),
                IWTConfiguration.Conf.getConf(Constants.SEMANA_DIA),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_PCP)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.DIAS_PROGRAMACAO_COMPRAS)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA)),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A)),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B)),
                Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB)),
                Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.SUGESTAO_ACIMA_CONFIGURADO)),
                conn,
                usuario);


            //carrega cálculos
            calc.gerarRelatorio(null, null, null, new List<SolicitacaoCompraClass>());

            if (incluirMateriais)
            {

                //Materiais
                List<MaterialClass> materiais = new MaterialClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Ativo", true)
                }).ConvertAll(a => (MaterialClass) a);

                foreach (MaterialClass material in materiais)
                {

                    itemNecessidadeCompraKey key = new itemNecessidadeCompraKey(TipoItemCompra.Material, material);

                    double qtdComprada = 0;
                    double estoqueAtual = 0;
                    double qtdNecessaria = 0;
                    if (calc.itensComprar.ContainsKey(key))
                    {
                        itemNecessidadeCompra itemCalculado = calc.itensComprar[key];
                        qtdComprada = itemCalculado.qtdComprada;
                        estoqueAtual = itemCalculado.qtdEstoque;
                        qtdNecessaria = itemCalculado.qtdNecessaria;
                    }

                    else
                    {

                        estoqueAtual = itemNecessidadeCompra.CarregarEstoqueAtual(key.tipoItem, key.Item, conn);
                        double qtdAguardandoCompra;
                        double qtdAguardandoRecebimento;
                        itemNecessidadeCompra.CarregarQtdComprada(key.tipoItem, key.Item, material.UnidadesPorUnCompra, conn, out qtdAguardandoCompra, out qtdAguardandoRecebimento);
                        qtdComprada = qtdAguardandoCompra + qtdAguardandoRecebimento;
                    }


                    RelatorioCompletoEstoqueReportClass item = new RelatorioCompletoEstoqueReportClass()
                    {
                        Codigo = material.IdentificacaoCompleta,
                        Comprado = qtdComprada,
                        Descricao = material.Descricao,
                        EstoqueAtual = estoqueAtual,
                        EstoqueReservado = qtdNecessaria,
                        Tipo = key.tipoItem.ToString()
                    };

                    toRet.Add(item);

                }
            }


            if (incluirProdutos)
            {

                //Produtos
                List<ProdutoClass> produtos = new ProdutoClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("Ativo", true)
                }).ConvertAll(a => (ProdutoClass) a);

                foreach (ProdutoClass produto in produtos)
                {
                    itemNecessidadeCompraKey key = new itemNecessidadeCompraKey(TipoItemCompra.Produto, produto);

                    double qtdComprada = 0;
                    double estoqueAtual = 0;
                    double qtdNecessaria = 0;
                    if (calc.itensComprar.ContainsKey(key))
                    {
                        itemNecessidadeCompra itemCalculado = calc.itensComprar[key];
                        qtdComprada = itemCalculado.qtdComprada;
                        estoqueAtual = itemCalculado.qtdEstoque;
                        qtdNecessaria = itemCalculado.qtdNecessaria;
                    }

                    else
                    {

                        estoqueAtual = itemNecessidadeCompra.CarregarEstoqueAtual(key.tipoItem, key.Item, conn);
                        double qtdAguardandoCompra;
                        double qtdAguardandoRecebimento;
                        itemNecessidadeCompra.CarregarQtdComprada(key.tipoItem, key.Item, produto.UnidadesPorUnCompra, conn, out qtdAguardandoCompra, out qtdAguardandoRecebimento);
                        qtdComprada = qtdAguardandoCompra + qtdAguardandoRecebimento;
                    }

                    RelatorioCompletoEstoqueReportClass item = new RelatorioCompletoEstoqueReportClass()
                    {
                        Codigo = produto.ToString(),
                        Comprado = qtdComprada,
                        Descricao = produto.Descricao,
                        EstoqueAtual = estoqueAtual,
                        EstoqueReservado = qtdNecessaria,
                        Tipo = key.tipoItem.ToString()
                    };

                    toRet.Add(item);

                }
            }

            if (incluirEpis)
            {

                //EPIs
                List<EpiClass> epis = new EpiClass(usuario, conn).Search(new List<SearchParameterClass>()
                {
                }).ConvertAll(a => (EpiClass) a);

                foreach (EpiClass epi in epis)
                {
                    itemNecessidadeCompraKey key = new itemNecessidadeCompraKey(TipoItemCompra.Epi, epi);

                    double qtdComprada = 0;
                    double estoqueAtual = 0;
                    double qtdNecessaria = 0;
                    if (calc.itensComprar.ContainsKey(key))
                    {
                        itemNecessidadeCompra itemCalculado = calc.itensComprar[key];
                        qtdComprada = itemCalculado.qtdComprada;
                        estoqueAtual = itemCalculado.qtdEstoque;
                        qtdNecessaria = itemCalculado.qtdNecessaria;
                    }

                    else
                    {

                        estoqueAtual = itemNecessidadeCompra.CarregarEstoqueAtual(key.tipoItem, key.Item, conn);
                        double qtdAguardandoCompra;
                        double qtdAguardandoRecebimento;
                        itemNecessidadeCompra.CarregarQtdComprada(key.tipoItem, key.Item, epi.UnidadesPorUnidadeCompra, conn, out qtdAguardandoCompra, out qtdAguardandoRecebimento);
                        qtdComprada = qtdAguardandoCompra + qtdAguardandoRecebimento;
                    }


                    RelatorioCompletoEstoqueReportClass item = new RelatorioCompletoEstoqueReportClass()
                    {
                        Codigo = epi.ToString(),
                        Comprado = qtdComprada,
                        Descricao = epi.Descricao,
                        EstoqueAtual = estoqueAtual,
                        EstoqueReservado = qtdNecessaria,
                        Tipo = key.tipoItem.ToString()
                    };

                    toRet.Add(item);

                }

            }

            toRet = toRet.OrderBy(a => a.Tipo).ThenBy(a => a.Codigo).ToList();

            return toRet;
        }

    }
}
