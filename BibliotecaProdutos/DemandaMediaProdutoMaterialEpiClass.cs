using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;
using dbProvider;

namespace BibliotecaProdutos
{
    public class DemandaMediaProdutoMaterialEpiClass
    {
        public byte[] logoCli { get; private set; }
        public string CodigoUnico { get; set; }
        public string CodigoItem { get; set; }
        public string DescricaoItem { get; set; }
        public string DimensaoItem { get; set; }
        public double Vermelho { get; set; }
        public double VermelhoPrevisto { get; set; }
        public double Amarelo { get; set; }
        public double AmareloPrevisto { get; set; }
        public double Verde { get; set; }
        public double VerdePrevisto { get; set; }


        public DemandaMediaProdutoMaterialEpiClass(byte[] logoCli, string codigoItem, string descricaoItem, string dimensaoItem, double vermelho, int vermelhoPrevisto, double amarelo, int amareloPrevisto, double verde, int verdePrevisto, string codigoUnico)
        {
            CodigoUnico = codigoUnico;
            CodigoItem = codigoItem;
            DescricaoItem = descricaoItem;
            DimensaoItem = dimensaoItem;
            Vermelho = vermelho;
            VermelhoPrevisto = vermelhoPrevisto;
            Amarelo = amarelo;
            AmareloPrevisto = amareloPrevisto;
            Verde = verde;
            VerdePrevisto = verdePrevisto;

            this.logoCli = logoCli;
        }

        public DemandaMediaProdutoMaterialEpiClass(string codigoUnico)
        {
            CodigoUnico = codigoUnico;
        }

        public static List<DemandaMediaProdutoMaterialEpiClass> gerarRelatorio(int tipoItem, AbstractEntity itemSelecionado, IWTPostgreNpgsqlConnection conn)
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

                }

            #endregion
            
            List<DemandaMediaProdutoMaterialEpiClass> ds = new List<DemandaMediaProdutoMaterialEpiClass>();
            IWTPostgreNpgsqlCommand command =conn.CreateCommand();
            IWTPostgreNpgsqlDataReader read;
            DemandaMediaProdutoMaterialEpiClass demandaMediaProdutoMaterialEpi;
            switch (tipoItem)
            {
                case 0:
                    command.CommandText = "SELECT id_material FROM material";
                    if (itemSelecionado != null)
                    {
                        command.CommandText += " WHERE id_material = " + itemSelecionado.ID;
                    }
                    read = command.ExecuteReader();
                    while(read.Read())
                    {
                        
                        MaterialClass Material =
                            MaterialBaseClass.GetEntidade(Convert.ToInt32(read["id_material"]),
                                              LoginClass.UsuarioLogado.loggedUser,
                                              DbConnection.Connection
                                );


                        demandaMediaProdutoMaterialEpi =
                            new DemandaMediaProdutoMaterialEpiClass(tmp,
                                                                    Material.ToString(),
                                                                    Material.Descricao,
                                                                    "",
                                                                    Material.Vermelho,
                                                                    Convert.ToInt32(Material.sugestaoKB.Vermelho),
                                                                    Material.Amarelo,
                                                                    Convert.ToInt32(Material.sugestaoKB.Amarelo),
                                                                    Material.Verde,
                                                                    Convert.ToInt32(Material.sugestaoKB.Verde),
                                                                    Material.CodigoInterno);
                        ds.Add(demandaMediaProdutoMaterialEpi);

                    }
                    ds = ds.OrderByDescending(a => a, new SpecialComparer()).ToList();
                    read.Close();
                    break;
                case 1:
                    ds.AddRange(loadProdutoDimensaoKb(tmp, (ProdutoClass) itemSelecionado));
                    ds = ds.OrderByDescending(a => a, new SpecialComparer()).ToList();
                    break;
                case 2:
                    EpiClass search = new EpiClass(LoginClass.UsuarioLogado.loggedUser, conn);
                    List<EpiClass> epis = null;
                    if (itemSelecionado != null)
                    {
                        epis = new List<EpiClass>(){(EpiClass) itemSelecionado}; 
                    }
                    else
                    {
                        epis = search.Search(new List<SearchParameterClass>() {new SearchParameterClass("epi_identificacao", null, SearchOperacao.SomenteOrdenacao, SearchOrdenacao.Asc, TipoOrdenacao.String)}).ConvertAll(a => (EpiClass) a);
                    }
                    
                    
                    foreach (EpiClass epi in epis)
                    {
                        demandaMediaProdutoMaterialEpi =
                            new DemandaMediaProdutoMaterialEpiClass(tmp, epi.Identificacao,
                                                                    epi.Descricao,
                                                                    "",
                                                                    epi.Vermelho,
                                                                    Convert.ToInt32(epi.sugestaoKB.Vermelho),
                                                                    epi.Amarelo,
                                                                    Convert.ToInt32(epi.sugestaoKB.Amarelo),
                                                                    epi.Verde,
                                                                    Convert.ToInt32(epi.sugestaoKB.Verde),
                                                                    epi.ID.ToString());
                        ds.Add(demandaMediaProdutoMaterialEpi);
                    }
                    ds = ds.OrderByDescending(a => a, new SpecialComparer()).ToList();
                    break;
                case 3:
                    ds.AddRange(loadProdutoK(tmp, (ProdutoKClass)itemSelecionado));
                    ds = ds.OrderByDescending(a => a, new SpecialComparer()).ToList();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("");
            }

            if (ds.Count == 0)
            {
                throw new Exception("Não há dados para a geração do relatório.");
            }

            return ds;
        }

        static List<DemandaMediaProdutoMaterialEpiClass> loadProdutoDimensaoKb(byte[] logo, ProdutoClass itemSelecionado)
        {
            try
            {

                int diasVerde = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
                int diasAmarelo = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
                int diasVermelho = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
                int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
                DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * mesesMedia);

                List<DemandaMediaProdutoMaterialEpiClass> toRet = new List<DemandaMediaProdutoMaterialEpiClass>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT    " +
                    "  SUM(public.order_item_etiqueta.oie_quantidade* CASE prk_utiliza_dimensao_quantidade_baixa WHEN 1 THEN CAST(oie_dimensao as DOUBLE PRECISION) ELSE 1 END) AS qtdUsoTotal,   " +
                    "  hcp_preco_unitario,   " +
                    "  lot_qtd_compra,  " +
                    "  lot_qtd,  " +
                    "  order_item_etiqueta.oie_dimensao,  " +
                    "  produto.pro_codigo,  " +
                    "  produto.pro_descricao,  " +
                    "  produto.pro_vermelho,  " +
                    "  produto.pro_amarelo,  " +
                    "  produto.pro_verde,  " +
                    "  produto.id_produto "+
                    "FROM   " +
                    "  public.order_item_etiqueta   " +
                    "  INNER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto)   " +
                    "  JOIN (   " +
                    "    SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0   " +
                    "     AND (pei_data_entrada BETWEEN '" + dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + dataFim.Date.ToString("yyyy-MM-dd") + "' )   " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos   " +
                    "  LEFT JOIN produto_k ON order_item_etiqueta.id_produto_k = produto_k.id_produto_k " +
                    "  LEFT OUTER JOIN    " +
                    "  (   " +
                    "  SELECT    " +
                    "    historico_compra_produto.id_produto,   " +
                    "    public.historico_compra_produto.hcp_preco_unitario,   " +
                    "    lote.lot_qtd_compra, " +
                    "    lote.lot_qtd " +
                    "    FROM   " +
                    "   public.historico_compra_produto   " +
                    "   LEFT JOIN lote ON lote.id_lote = historico_compra_produto.id_lote " +
                    "    WHERE id_historico_compra_produto IN (   " +
                    "      SELECT    " +
                    "        MAX(id_historico_compra_produto) FROM   " +
                    "       historico_compra_produto   " +
                    "        )   " +
                    "  ) as ultimaCompra ON produto.id_produto = ultimaCompra.id_produto  ";

                if (itemSelecionado != null)
                {
                    command.CommandText += " WHERE produto.id_produto = " + itemSelecionado.ID + " ";
                }

                    command.CommandText +=
                    "GROUP BY   " +
                    "  oie_dimensao,   " +
                    "  produto.id_produto,   " +
                    "  produto.pro_codigo,  " +
                    "  produto.pro_descricao,  " +
                    "  produto.pro_vermelho,  " +
                    "  produto.pro_amarelo,  " +
                    "  produto.pro_verde,  " +
                    "  hcp_preco_unitario," +
                    "  lot_qtd_compra,  " +
                    "  lot_qtd " +
                    ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                }

                while (read.Read())
                {
                    DemandaMediaProdutoMaterialEpiClass demandaMediaProduto = new DemandaMediaProdutoMaterialEpiClass(read["id_produto"].ToString());

                    demandaMediaProduto.logoCli = logo;
                    demandaMediaProduto.CodigoItem = read["pro_codigo"].ToString();
                    demandaMediaProduto.DescricaoItem = read["pro_descricao"].ToString();
                    demandaMediaProduto.Vermelho = Convert.ToDouble(read["pro_vermelho"]);
                    demandaMediaProduto.Amarelo = Convert.ToDouble(read["pro_amarelo"]);
                    demandaMediaProduto.Verde = Convert.ToDouble(read["pro_verde"]);
                    demandaMediaProduto.DimensaoItem = read["oie_dimensao"].ToString();

                    #region Calculo dos KBs Sugeridos
                        double qtdUtilizacaoTotal = Convert.ToDouble(read["qtdUsoTotal"]);
                        double qtdUtilizacaoMensal = qtdUtilizacaoTotal / mesesMedia;
                        demandaMediaProduto.VerdePrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasVerde, 0, MidpointRounding.AwayFromZero);
                        demandaMediaProduto.AmareloPrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasAmarelo, 0, MidpointRounding.AwayFromZero);
                        demandaMediaProduto.VermelhoPrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasVermelho, 0, MidpointRounding.AwayFromZero);
                    #endregion

                    toRet.Add(demandaMediaProduto);
                }
                
                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a sugestão de reposição da Kanban.\r\n" + e.Message, e);
            }
        }


        static List<DemandaMediaProdutoMaterialEpiClass> loadProdutoK(byte[] logo, ProdutoKClass itemSelecionado)
        {
            try
            {

                int diasVerde = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
                int diasAmarelo = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO));
                int diasVermelho = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO));
                int mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA));
                DateTime dataFim = Configurations.DataIndependenteClass.GetData().Date;
                DateTime dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * mesesMedia);

                List<DemandaMediaProdutoMaterialEpiClass> toRet = new List<DemandaMediaProdutoMaterialEpiClass>();

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText =
                    "SELECT    " +
                    "  SUM(public.order_item_etiqueta.oie_quantidade* CASE prk_utiliza_dimensao_quantidade_baixa WHEN 1 THEN CAST(oie_dimensao as DOUBLE PRECISION) ELSE 1 END) AS qtdUsoTotal,   " +
                    "  hcp_preco_unitario,   " +
                    "  lot_qtd_compra,  " +
                    "  lot_qtd,  " +
                    "  produto_k.prk_dimensao,  " +
                    "  produto_k.prk_codigo,  " +
                    "  produto_k.prk_vermelho,  " +
                    "  produto_k.prk_amarelo,  " +
                    "  produto_k.prk_verde,  " +
                    "  produto_k.id_produto_k " +
                    "FROM   " +
                    "  public.order_item_etiqueta   " +
                    "  INNER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto)   " +
                    "  JOIN (   " +
                    "    SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0   " +
                    "     AND (pei_data_entrada BETWEEN '" + dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + dataFim.Date.ToString("yyyy-MM-dd") + "' )   " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos   " +
                    "  JOIN produto_k ON order_item_etiqueta.id_produto_k = produto_k.id_produto_k " +
                    "  LEFT OUTER JOIN    " +
                    "  (   " +
                    "  SELECT    " +
                    "    historico_compra_produto.id_produto,   " +
                    "    public.historico_compra_produto.hcp_preco_unitario,   " +
                    "    lote.lot_qtd_compra, " +
                    "    lote.lot_qtd " +
                    "    FROM   " +
                    "   public.historico_compra_produto   " +
                    "   LEFT JOIN lote ON lote.id_lote = historico_compra_produto.id_lote " +
                    "    WHERE id_historico_compra_produto IN (   " +
                    "      SELECT    " +
                    "        MAX(id_historico_compra_produto) FROM   " +
                    "       historico_compra_produto   " +
                    "        )   " +
                    "  ) as ultimaCompra ON produto.id_produto = ultimaCompra.id_produto  ";

                if (itemSelecionado != null)
                {
                    command.CommandText += " WHERE produto_k.id_produto_k = " + itemSelecionado.ID + " ";
                }

                command.CommandText +=
                "GROUP BY   " +
                "  prk_dimensao,   " +
                "  produto_k.id_produto_k,   " +
                "  produto_k.prk_codigo,  " +
                "  produto_k.prk_vermelho,  " +
                "  produto_k.prk_amarelo,  " +
                "  produto_k.prk_verde,  " +
                "  hcp_preco_unitario," +
                "  lot_qtd_compra,  " +
                "  lot_qtd " +
                ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                }

                while (read.Read())
                {
                    DemandaMediaProdutoMaterialEpiClass demandaMediaProduto = new DemandaMediaProdutoMaterialEpiClass(read["id_produto_k"].ToString());

                    demandaMediaProduto.logoCli = logo;
                    demandaMediaProduto.CodigoItem = read["prk_codigo"].ToString();
                    demandaMediaProduto.DescricaoItem = "";
                    demandaMediaProduto.Vermelho = Convert.ToDouble(read["prk_vermelho"]);
                    demandaMediaProduto.Amarelo = Convert.ToDouble(read["prk_amarelo"]);
                    demandaMediaProduto.Verde = Convert.ToDouble(read["prk_verde"]);
                    demandaMediaProduto.DimensaoItem = read["prk_dimensao"].ToString();

                    #region Calculo dos KBs Sugeridos
                    double qtdUtilizacaoTotal = Convert.ToDouble(read["qtdUsoTotal"]);
                    double qtdUtilizacaoMensal = qtdUtilizacaoTotal / mesesMedia;
                    demandaMediaProduto.VerdePrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasVerde, 0, MidpointRounding.AwayFromZero);
                    demandaMediaProduto.AmareloPrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasAmarelo, 0, MidpointRounding.AwayFromZero);
                    demandaMediaProduto.VermelhoPrevisto = Math.Round((qtdUtilizacaoMensal / 30) * diasVermelho, 0, MidpointRounding.AwayFromZero);
                    #endregion

                    toRet.Add(demandaMediaProduto);
                }

                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a sugestão de reposição da Kanban de manuf.\r\n" + e.Message, e);
            }
        }
    }

    public class SpecialComparer : IComparer<DemandaMediaProdutoMaterialEpiClass>
    {
        public int Compare(DemandaMediaProdutoMaterialEpiClass x, DemandaMediaProdutoMaterialEpiClass y)
        {
            if (x == null)
            {
                return -1;
            }

            if (y == null)
            {
                return 1;
            }

            if (x.VermelhoPrevisto > y.VermelhoPrevisto)
            {
                return 1;
            }
            if (x.VermelhoPrevisto < y.VermelhoPrevisto)
            {
                return -1;
            }
            if (x.VermelhoPrevisto.Equals(y.VermelhoPrevisto))
            {
                if (x.AmareloPrevisto > y.AmareloPrevisto)
                {
                    return 1;
                }
                if (x.AmareloPrevisto < y.AmareloPrevisto)
                {
                    return -1;
                }
                if (x.AmareloPrevisto.Equals(y.AmareloPrevisto))
                {
                    if (x.VerdePrevisto > y.VerdePrevisto)
                    {
                        return 1;
                    }
                    if (x.VerdePrevisto < y.VerdePrevisto)
                    {
                        return -1;
                    }
                    return 0;
                }
            }
            return 0;
        }
    }
    
}
