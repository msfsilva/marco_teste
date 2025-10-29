#region Referencias

using System;
using System.Data.Common;
using BibiliotecaGerenciamentoKB;
using BibliotecaEntidades.Entidades;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

#endregion

namespace BibliotecaEntidades.Operacoes.GerenciamentoKb
{
    public class CalculaSugestaoKBClass
    {
        private readonly IWTPostgreNpgsqlConnection _conn;
        readonly int diasVerde;
        readonly int diasAmarelo;
        readonly int diasVermelho;
        readonly int mesesMedia;
        readonly double categoriaAAcimaDe;
        readonly double categoriaBAcimaDe;
        readonly double margemAvisoKB;

        DateTime dataFim;
        DateTime dataInicio;

        public CalculaSugestaoKBClass(IWTPostgreNpgsqlConnection conn)
        {
            _conn = conn;
            this.diasVerde = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERDE));
            this.diasAmarelo = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_AMARELO)); ;
            this.diasVermelho = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_DIAS_VERMELHO)); ;
            this.mesesMedia = Int32.Parse(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_N_MESES_MEDIA)); ;
            this.categoriaAAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_A));
            this.categoriaBAcimaDe = Convert.ToDouble(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_CLASSIFICACAO_B)); 
            this.margemAvisoKB = Convert.ToInt32(IWTConfiguration.Conf.getConf(Constants.ESTOQUE_MARGEM_REVISAO_KB));

            dataFim = Configurations.DataIndependenteClass.GetData().Date;
            dataInicio = Configurations.DataIndependenteClass.GetData().Date.AddMonths(-1 * this.mesesMedia);

        }

        public SugestaoKBClass Calcular(MaterialClass material, double verdeTeorico, double amareloTeorico, double vermelhoTeorico,
             string unidadeUso, double lotePadrao)
        {
            try
            {
                SugestaoKBClass toRet = new SugestaoKBClass();

                IWTPostgreNpgsqlCommand command = _conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  SUM((pedido_item_configurado_material.pcm_quantidade_total)* CASE prk_utiliza_dimensao_quantidade_baixa WHEN 1 THEN CAST(oie_dimensao as DOUBLE PRECISION) ELSE 1 END ) AS qtdUsoTotal, " +
                    "  hcm_preco_unitario, " +
                    "  lot_qtd_compra,  " +
                    "  lot_qtd  " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  INNER JOIN pedido_item_configurado_material ON order_item_etiqueta.id_order_item_etiqueta = pedido_item_configurado_material.id_order_item_etiqueta "+
                    "  JOIN ( " +
                    "  	SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0 AND pei_status <> 2 " +
                    "     AND (pei_data_entrada BETWEEN '" + this.dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + this.dataFim.Date.ToString("yyyy-MM-dd") + "' ) " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos " +
                    "  LEFT JOIN produto_k ON order_item_etiqueta.id_produto_k = produto_k.id_produto_k " +
                    "  LEFT OUTER JOIN  " +
                    "  ( " +
                    "  SELECT  " +
                    "  historico_compra_material.id_material,   " +
                    "  public.historico_compra_material.hcm_preco_unitario, " +
                    "  lote.lot_qtd_compra, " +
                    "  lote.lot_qtd " +
                    "  FROM   " +
                    "   public.historico_compra_material   " +
                    "   LEFT JOIN lote ON lote.id_lote = historico_compra_material.id_lote " +
                    "    WHERE id_historico_compra_material IN ( " +
                    "      SELECT  " +
                    "  	    MAX(id_historico_compra_material) FROM " +
                    "       historico_compra_material " +
                    "       WHERE id_material = " + material.ID + " " +
                    "  	    ) " +
                    "  ) as ultimaCompra ON pedido_item_configurado_material.id_material = ultimaCompra.id_material " +
                    "WHERE " +
                    "  public.pedido_item_configurado_material.id_material = " + material.ID + " AND " +
                    "  public.order_item_etiqueta.oie_tipo_aquisicao_produto = 0 "+
                    "GROUP BY " +
                    "  public.pedido_item_configurado_material.id_material, " +
                    "  hcm_preco_unitario, " +
                    "  lot_qtd_compra,  " +
                    "  lot_qtd  ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                    return new SugestaoKBClass()
                    {
                        Verde = 0,
                        Amarelo = 0,
                        Vermelho = 0,
                        Unidade = "",
                        ClassificacaoABC = "C",
                        obsRevisarKBVerde = "",
                        obsRevisarKBAmarelo = "",
                        obsRevisarKBVermelho = ""
                    };
                }

                read.Read();

                #region Calculo dos KBs Sugeridos
                double qtdUtilizacaoTotal = Convert.ToDouble(read["qtdUsoTotal"]);
                double qtdUtilizacaoMensal = qtdUtilizacaoTotal / this.mesesMedia;


                toRet.Unidade = unidadeUso;

                toRet.consumoMedioDiario = (qtdUtilizacaoMensal / 30);

                toRet.Verde = Math.Round((qtdUtilizacaoMensal / 30) * this.diasVerde, 0, MidpointRounding.AwayFromZero);
                toRet.Amarelo = Math.Round((qtdUtilizacaoMensal / 30) * this.diasAmarelo, 0, MidpointRounding.AwayFromZero);
                toRet.Vermelho = Math.Round((qtdUtilizacaoMensal / 30) * this.diasVermelho, 0, MidpointRounding.AwayFromZero);

                #endregion

                #region Calculo ABC
                double ulimoPreco = 0;
                if (read["hcm_preco_unitario"] != DBNull.Value)
                {
                    ulimoPreco = Convert.ToDouble(read["hcm_preco_unitario"]);
                    if (read["lot_qtd_compra"]!=DBNull.Value)
                    {
                        ulimoPreco = ulimoPreco*Convert.ToDouble(read["lot_qtd_compra"])/Convert.ToDouble(read["lot_qtd"]);
                    }

                }

                double valorAbc = ulimoPreco * qtdUtilizacaoMensal;

                if (valorAbc > this.categoriaAAcimaDe)
                {
                    toRet.ClassificacaoABC = "A";
                }
                else
                {
                    if (valorAbc > this.categoriaBAcimaDe)
                    {
                        toRet.ClassificacaoABC = "B";
                    }
                    else
                    {
                        toRet.ClassificacaoABC = "C";
                    }
                }
                #endregion

                #region Observação Alteração KB

                if (verdeTeorico < (toRet.Verde * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque baixo";
                }

                if (verdeTeorico > (toRet.Verde * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque alto";
                }


                if (amareloTeorico < (toRet.Amarelo * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque baixo";
                }

                if (amareloTeorico > (toRet.Amarelo * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque alto";
                }

                if (vermelhoTeorico < (toRet.Vermelho * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque baixo";
                }

                if (vermelhoTeorico > (toRet.Vermelho * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque alto";
                }


                #endregion

                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a sugestão de reposição da Kanban.\r\n" + e.Message, e);
            }
        }

        public SugestaoKBClass CalcularProduto(ProdutoClass produto, double verdeTeorico, double amareloTeorico, double vermelhoTeorico, string unidadeUso)
        {
            try
            {
                SugestaoKBClass toRet = new SugestaoKBClass();

                IWTPostgreNpgsqlCommand command = _conn.CreateCommand();
                command.CommandText =
                    "SELECT    " +
                    "  SUM(public.order_item_etiqueta.oie_quantidade* CASE prk_utiliza_dimensao_quantidade_baixa WHEN 1 THEN CAST(oie_dimensao as DOUBLE PRECISION) ELSE 1 END) AS qtdUsoTotal,   " +
                    "  hcp_preco_unitario,   " +
                    "  lot_qtd_compra,  "+
                    "  lot_qtd  "+
                    "FROM   " +
                    "  public.order_item_etiqueta   " +
                    "  INNER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto)   " +
                    "  JOIN (   " +
                    "    SELECT pei_numero, pei_posicao,pei_data_entrega FROM pedido_item WHERE pei_sub_linha = 0   " +
                    "     AND (pei_data_entrada BETWEEN '" + this.dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + this.dataFim.Date.ToString("yyyy-MM-dd") + "' )   " +
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
                    "       WHERE id_produto = " + produto.ID + "     " +
                    "        )   " +
                    "  ) as ultimaCompra ON produto.id_produto = ultimaCompra.id_produto  " +
                    "WHERE   " +
                    "    public.produto.id_produto = " + produto.ID + " " +
                    "GROUP BY   " +
                    "  public.produto.id_produto,   " +
                    "  hcp_preco_unitario," +
                    "  lot_qtd_compra,  "+
                    "  lot_qtd ;"; 

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                    return new SugestaoKBClass()
                    {
                        Verde = 0,
                        Amarelo = 0,
                        Vermelho = 0,
                        Unidade = "",
                        ClassificacaoABC = "C",
                        obsRevisarKBVerde = "",
                        obsRevisarKBAmarelo = "",
                        obsRevisarKBVermelho = ""
                    };
                }

                read.Read();

                #region Calculo dos KBs Sugeridos
                double qtdUtilizacaoTotal = Convert.ToDouble(read["qtdUsoTotal"]);
                double qtdUtilizacaoMensal = qtdUtilizacaoTotal / this.mesesMedia;


                toRet.Unidade = unidadeUso;

                toRet.consumoMedioDiario = (qtdUtilizacaoMensal / 30);

                toRet.Verde = Math.Round((qtdUtilizacaoMensal / 30) * this.diasVerde, 0, MidpointRounding.AwayFromZero);
                toRet.Amarelo = Math.Round((qtdUtilizacaoMensal / 30) * this.diasAmarelo, 0, MidpointRounding.AwayFromZero);
                toRet.Vermelho = Math.Round((qtdUtilizacaoMensal / 30) * this.diasVermelho, 0, MidpointRounding.AwayFromZero);

                #endregion

                #region Calculo ABC
                double ulimoPreco = 0;
                if (read["hcp_preco_unitario"] != DBNull.Value)
                {
                    ulimoPreco = Convert.ToDouble(read["hcp_preco_unitario"]);
                    if (read["lot_qtd_compra"] != DBNull.Value)
                    {
                        ulimoPreco = ulimoPreco * Convert.ToDouble(read["lot_qtd_compra"]) / Convert.ToDouble(read["lot_qtd"]);
                    }
                }

                double valorAbc = ulimoPreco * qtdUtilizacaoMensal;

                if (valorAbc > this.categoriaAAcimaDe)
                {
                    toRet.ClassificacaoABC = "A";
                }
                else
                {
                    if (valorAbc > this.categoriaBAcimaDe)
                    {
                        toRet.ClassificacaoABC = "B";
                    }
                    else
                    {
                        toRet.ClassificacaoABC = "C";
                    }
                }
                #endregion

                #region Observação Alteração KB

                if (verdeTeorico < (toRet.Verde * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque baixo";
                }

                if (verdeTeorico > (toRet.Verde * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque alto";
                }


                if (amareloTeorico < (toRet.Amarelo * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque baixo";
                }

                if (amareloTeorico > (toRet.Amarelo * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque alto";
                }

                if (vermelhoTeorico < (toRet.Vermelho * (1 - (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque baixo";
                }

                if (vermelhoTeorico > (toRet.Vermelho * (1 + (margemAvisoKB / 100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque alto";
                }


                #endregion

                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a sugestão de reposição da Kanban.\r\n" + e.Message, e);
            }
        }

        public SugestaoKBClass CalcularEpi(EpiClass epi, double verdeTeorico, double amareloTeorico, double vermelhoTeorico,
           string unidadeUso, double lotePadrao)
        {
            try
            {
                SugestaoKBClass toRet = new SugestaoKBClass();

                IWTPostgreNpgsqlCommand command = _conn.CreateCommand();
                command.CommandText =
                    " SELECT count(*) AS qtdUtilizada, " +
                    "  ultimo_preco_unidade_uso " +
                    " FROM " +
                    "   public.funcionario_epi " +
                    "   LEFT JOIN epi_ultima_compra ON epi_ultima_compra.id_epi = funcionario_epi.id_epi " +
                    " WHERE " +
                    "   public.funcionario_epi.id_epi = " + epi.ID + " AND public.funcionario_epi.fue_data_retirada BETWEEN '" + this.dataInicio.Date.ToString("yyyy-MM-dd") + "' AND '" + this.dataFim.Date.ToString("yyyy-MM-dd") + "'" +

                    " GROUP BY " +
                    "   public.funcionario_epi.id_epi, " +
                    "   ultimo_preco_unidade_uso; ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (!read.HasRows)
                {
                    read.Close();
                    return new SugestaoKBClass()
                               {
                                   Verde = 0,
                                   Amarelo = 0,
                                   Vermelho = 0,
                                   Unidade = "",
                                   ClassificacaoABC = "C",
                                   obsRevisarKBVerde = "",
                                   obsRevisarKBAmarelo = "",
                                   obsRevisarKBVermelho = ""
                               };
                }

                read.Read();

                #region Calculo dos KBs Sugeridos

                double qtdUtilizacaoTotal = Convert.ToDouble(read["qtdUtilizada"]);
                double qtdUtilizacaoMensal = qtdUtilizacaoTotal/this.mesesMedia;


                toRet.Unidade = unidadeUso;

                toRet.consumoMedioDiario = (qtdUtilizacaoMensal/30);

                toRet.Verde = Math.Round((qtdUtilizacaoMensal/30)*this.diasVerde, 0, MidpointRounding.AwayFromZero);
                toRet.Amarelo = Math.Round((qtdUtilizacaoMensal/30)*this.diasAmarelo, 0, MidpointRounding.AwayFromZero);
                toRet.Vermelho = Math.Round((qtdUtilizacaoMensal/30)*this.diasVermelho, 0, MidpointRounding.AwayFromZero);

                #endregion

                #region Observação Alteração KB

                if (verdeTeorico < (toRet.Verde*(1 - (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque baixo";
                }

                if (verdeTeorico > (toRet.Verde*(1 + (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBVerde = "Estoque alto";
                }


                if (amareloTeorico < (toRet.Amarelo*(1 - (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque baixo";
                }

                if (amareloTeorico > (toRet.Amarelo*(1 + (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBAmarelo = "Estoque alto";
                }

                if (vermelhoTeorico < (toRet.Vermelho*(1 - (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque baixo";
                }

                if (vermelhoTeorico > (toRet.Vermelho*(1 + (margemAvisoKB/100))))
                {
                    toRet.obsRevisarKBVermelho = "Estoque alto";
                }


                #endregion


                #region Calculo ABC

                double ulimoPreco = 0;
                if (read["ultimo_preco_unidade_uso"] != DBNull.Value)
                {
                    ulimoPreco = Convert.ToDouble(read["ultimo_preco_unidade_uso"]);
                }

                double valorAbc = ulimoPreco*qtdUtilizacaoMensal;

                if (valorAbc > this.categoriaAAcimaDe)
                {
                    toRet.ClassificacaoABC = "A";
                }
                else
                {
                    if (valorAbc > this.categoriaBAcimaDe)
                    {
                        toRet.ClassificacaoABC = "B";
                    }
                    else
                    {
                        toRet.ClassificacaoABC = "C";
                    }
                }

                #endregion

                read.Close();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao calcular a sugestão de reposição da Kanban.\r\n" + e.Message, e);
            }
        }

    }
}
