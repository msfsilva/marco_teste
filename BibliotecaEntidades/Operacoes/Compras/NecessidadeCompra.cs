#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.Operacoes.GerenciamentoKb;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.Compras
{
    public class NecessidadeCompra
    {
        readonly IWTPostgreNpgsqlConnection conn;
        private readonly AcsUsuarioClass _usuarioAtual;
        public Dictionary<itemNecessidadeCompraKey, itemNecessidadeCompra> itensComprar { get; private set; }
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        readonly int leadtimePCP;
        readonly int leadtimeCompras;

        readonly int diasVerde;
        readonly int diasAmarelo;
        readonly int diasVermelho;
        readonly int mesesMedia;
        readonly double categoriaAAcimaDe;
        readonly double categoriaBAcimaDe;
        readonly double margemAvisoKB;

        readonly double sugestaoCompraAcimaConfigurado;

        private Dictionary<long, int> _ultimaUtilizacaoProdutos;
        private Dictionary<long, int> _ultimaUtilizacaoMateriais;


        public NecessidadeCompra(string tipoCalculoSemana, string diaCalculoSemana, int leadtimePCP, int leadtimeCompras,
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double categoriaAAcimaDe, double categoriaBAcimaDe,
            double margemAvisoKB,
            double sugestaoCompraAcimaConfigurado,
            IWTPostgreNpgsqlConnection conn,
            AcsUsuarioClass usuarioAtual)
        {
            this.conn = conn;
            _usuarioAtual = usuarioAtual;
            this.itensComprar = new Dictionary<itemNecessidadeCompraKey, itemNecessidadeCompra>();
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.diasVerde = diasVerde;
            this.diasAmarelo = diasAmarelo;
            this.diasVermelho = diasVermelho;
            this.mesesMedia = mesesMedia;
            this.categoriaAAcimaDe = categoriaAAcimaDe;
            this.categoriaBAcimaDe = categoriaBAcimaDe;
            this.margemAvisoKB = margemAvisoKB;

            this.leadtimeCompras = leadtimeCompras;
            this.leadtimePCP = leadtimePCP;

            this.sugestaoCompraAcimaConfigurado = sugestaoCompraAcimaConfigurado;

            this._ultimaUtilizacaoProdutos = new Dictionary<long, int>();
            this._ultimaUtilizacaoMateriais = new Dictionary<long, int>();


        }


        private int getUltimaUtilizacao(long? idProduto, long? idMaterial)
        {
            if (idProduto.HasValue)
            {
                if (!_ultimaUtilizacaoProdutos.ContainsKey(idProduto.Value))
                {
                    IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                    command.CommandText =
                        "       SELECT " +
                        "        public.order_item_etiqueta.id_produto, " +
                        "        MAX(public.order_item_etiqueta.oie_pps) as pps " +
                        "            FROM " +
                        "        public.order_item_etiqueta " +
                        "            WHERE id_produto = :id_produto " +
                        "        GROUP BY " +
                        "        public.order_item_etiqueta.id_produto";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Bigint, idProduto.Value));
                    object tmp = command.ExecuteScalar();
                    if (tmp != null && tmp != DBNull.Value)
                    {
                        _ultimaUtilizacaoProdutos.Add(idProduto.Value, Convert.ToInt32(tmp));
                    }
                    else
                    {
                        _ultimaUtilizacaoProdutos.Add(idProduto.Value, 0);
                    }
                }

                return _ultimaUtilizacaoProdutos[idProduto.Value];
            }

            if (idMaterial.HasValue)
            {
                if (!_ultimaUtilizacaoMateriais.ContainsKey(idMaterial.Value))
                {
                    IWTPostgreNpgsqlCommand command = conn.CreateCommand();
                    command.CommandText =
                        "SELECT " +
                        "        public.pedido_item_configurado_material.id_material, " +
                        "        MAX(public.order_item_etiqueta.oie_pps) as pps " +
                        "            FROM " +
                        "        pedido_item_configurado_material JOIN order_item_etiqueta ON " +
                        "        order_item_etiqueta.id_order_item_etiqueta = " +
                        "        pedido_item_configurado_material.id_order_item_etiqueta " +
                        "            WHERE pedido_item_configurado_material.id_material = :id_material " +
                        "        GROUP BY " +
                        "        public.pedido_item_configurado_material.id_material";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Bigint, idMaterial.Value));
                    object tmp = command.ExecuteScalar();
                    if (tmp != null && tmp != DBNull.Value)
                    {
                        _ultimaUtilizacaoMateriais.Add(idMaterial.Value, Convert.ToInt32(tmp));
                    }
                    else
                    {
                        _ultimaUtilizacaoMateriais.Add(idMaterial.Value, 0);
                    }
                }

                return _ultimaUtilizacaoMateriais[idMaterial.Value];
            }

            throw new Exception("Deve ser informado o produto ou o material para identificação do ultimo uso");
        }

        public void gerarRelatorio(long? idProduto, long? idMaterial, long? idEpi, List<SolicitacaoCompraClass> solicitacoesDescontar )
        {
            try
            {
                solicitacoesDescontar = solicitacoesDescontar.Where(a => a != null).ToList();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                IWTPostgreNpgsqlDataReader read;
                bool buscaMateriais = true;
                List<long> idsProduto = new List<long>();

                if (idEpi.HasValue)
                {
                    EpiClass epi = EpiClass.GetEntidade(idEpi.Value, _usuarioAtual, conn);

                    itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Epi, epi);

                    this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                        TipoItemCompra.Epi,
                        epi,
                        epi.Identificacao,
                        epi.Descricao,
                        true,
                        epi.LoteMinimo,
                        epi.LotePadrao,
                        epi.Verde,
                        epi.UnidadeMedidaUso != null ? epi.UnidadeMedidaUso.ToString() : null,
                        epi.ImpedirSolicitacaoAutomatica,
                        Configurations.DataIndependenteClass.GetData(),
                        this.tipoCalculoSemana,
                        this.diaCalculoSemana,
                        epi.UnidadeMedidaCompra != null ? epi.UnidadeMedidaCompra.ToString() : null,
                        epi.UnidadesPorUnidadeCompra,
                        this.leadtimePCP,
                        this.leadtimeCompras,
                        epi.LeadTimeCompra,
                        this.diasVerde,
                        this.diasAmarelo,
                        this.diasVermelho,
                        this.mesesMedia,
                        this.categoriaAAcimaDe,
                        this.categoriaBAcimaDe,
                        this.margemAvisoKB,
                        this.sugestaoCompraAcimaConfigurado,
                        this.conn));


                    return;
                }
                else
                {
                    if (!idMaterial.HasValue && !idProduto.HasValue)
                    {

                        //carrega EPI (todos)
                        List<EpiClass> epis = new EpiClass(_usuarioAtual, conn).Search(new List<SearchParameterClass>()).ToList().ConvertAll(a => (EpiClass) a);


                        foreach (EpiClass epi in epis)
                        {
                            itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Epi, epi);

                            this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                                TipoItemCompra.Epi,
                                epi,
                                epi.Identificacao,
                                epi.Descricao,
                                true,
                                epi.LoteMinimo,
                                epi.LotePadrao,
                                epi.Verde,
                                epi.UnidadeMedidaUso != null ? epi.UnidadeMedidaUso.ToString() : null,
                                epi.ImpedirSolicitacaoAutomatica,
                                Configurations.DataIndependenteClass.GetData(),
                                this.tipoCalculoSemana,
                                this.diaCalculoSemana,
                                epi.UnidadeMedidaCompra != null ? epi.UnidadeMedidaCompra.ToString() : null,
                                epi.UnidadesPorUnidadeCompra,
                                this.leadtimePCP,
                                this.leadtimeCompras,
                                epi.LeadTimeCompra,
                                this.diasVerde,
                                this.diasAmarelo,
                                this.diasVermelho,
                                this.mesesMedia,
                                this.categoriaAAcimaDe,
                                this.categoriaBAcimaDe,
                                this.margemAvisoKB,
                                this.sugestaoCompraAcimaConfigurado,
                                this.conn));


                        }
                    }
                }




                if (idMaterial != null)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.produto_material.id_produto " +
                        "FROM " +
                        "  public.produto_material " +
                        "WHERE " +
                        "  public.produto_material.id_material = " + idMaterial.Value.ToString() + "";
                    read = command.ExecuteReader();
                    while (read.Read())
                    {
                        idsProduto.Add(Convert.ToInt32(read["id_produto"]));
                    }
                    read.Close();

                    if (idsProduto.Count == 0)
                    {
                        return;
                    }
                }
                
                if (idProduto != null)
                {
                    idsProduto.Add(idProduto.Value);
                    buscaMateriais = false;
                }

                command.CommandText =
                    "SELECT  " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.order_item_etiqueta.oie_saldo, " +
                    "  public.order_item_etiqueta.id_produto, " +
                    "  public.order_item_etiqueta.oie_item_original_pedido, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.produto.pro_emite_op, " +
                    "  public.produto.pro_politica_estoque, " +
                    "  public.produto.pro_tipo_aquisicao, " +
                    "  public.produto_k.prk_codigo, " +
                    "  public.produto_k.prk_emite_op, " +
                    "  public.produto_k.prk_verde, " +
                    "  public.produto_k.prk_amarelo, " +
                    "  public.produto_k.prk_vermelho, " +
                    "  public.produto_k.prk_lote_producao, " +
                    "  public.produto.pro_vermelho, " +
                    "  public.produto.pro_verde, " +
                    "  public.produto.pro_amarelo, " +
                    "  public.produto.pro_lote_padrao_compra, " +
                    "  public.produto.pro_lead_time_compra, " +
                    "  public.produto.pro_impedir_solicitacao_auto, " +
                    "  public.order_item_etiqueta.oie_situacao_conferencia, " +
                    "  public.order_item_etiqueta.oie_saldo_conferencia, " +
                    "  MIN(public.ordem_producao.orp_situacao) as orpSituacao, " +
                    "  pedidos_pai.pei_data_entrega, " +
                    "  public.unidade_medida.unm_abreviada, " +
                    "  u2.unm_abreviada as unidade_compra, " +
                    "  produto.pro_unidades_por_un_compra, " +
                    "  pedidos_pai.id_pedido_item, " +
                    "  produto_k.prk_utiliza_dimensao_quantidade_baixa, " +
                    "  public.order_item_etiqueta.oie_dimensao, " +
                    "  public.order_item_etiqueta.oie_codigo_item, " +
                    "  public.order_item_etiqueta.oie_etiqueta_interna " +
                    "FROM " +
                    "  public.order_item_etiqueta " +
                    "  LEFT OUTER JOIN public.produto_k ON (public.order_item_etiqueta.id_produto_k = public.produto_k.id_produto_k) " +
                    "  LEFT OUTER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                    "  LEFT OUTER JOIN public.unidade_medida ON produto.id_unidade_medida = unidade_medida.id_unidade_medida " +
                    "  LEFT OUTER JOIN public.unidade_medida u2 ON produto.id_unidade_medida_compra = u2.id_unidade_medida " +
                    "  LEFT OUTER JOIN public.ordem_producao_pedido ON (public.order_item_etiqueta.id_order_item_etiqueta = public.ordem_producao_pedido.id_order_item_etiqueta) " +
                    "  LEFT OUTER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  JOIN ( " +
                    "  	SELECT pei_numero, pei_posicao,pei_data_entrega, id_pedido_item, id_cliente  FROM pedido_item WHERE pei_sub_linha = 0 AND (pei_status = 0 OR pei_status = 3) " +
                    "  ) as pedidos_pai ON pei_numero = oie_order_number AND pei_posicao = oie_order_pos AND pedidos_pai.id_cliente = order_item_etiqueta.id_cliente ";

                if (idsProduto.Count > 0)
                {
                    string tmp = "";
                    foreach (int id in idsProduto)
                    {
                        tmp += " OR order_item_etiqueta.id_produto = " + id.ToString() + " ";
                    }
                    command.CommandText += " WHERE " + tmp.Substring(3) + " ";
                }
                command.CommandText +=
                    "GROUP BY " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta, " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.order_item_etiqueta.oie_saldo, " +
                    "  public.order_item_etiqueta.id_produto, " +
                    "  public.order_item_etiqueta.oie_item_original_pedido, " +
                    "  public.order_item_etiqueta.oie_etiqueta_interna, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.produto.pro_emite_op, " +
                    "  public.produto.pro_politica_estoque, " +
                    "  public.produto.pro_tipo_aquisicao, " +
                    "  public.produto_k.prk_codigo, " +
                    "  public.produto_k.prk_emite_op, " +
                    "  public.produto_k.prk_verde, " +
                    "  public.produto_k.prk_amarelo, " +
                    "  public.produto_k.prk_vermelho, " +
                    "  public.produto_k.prk_lote_producao, " +
                    "  public.produto.pro_vermelho, " +
                    "  public.produto.pro_verde, " +
                    "  public.produto.pro_amarelo, " +
                    "  public.produto.pro_lote_padrao_compra, " +
                    "  public.produto.pro_lead_time_compra, " +
                    "  public.produto.pro_impedir_solicitacao_auto, " +
                    "  public.order_item_etiqueta.oie_situacao_conferencia, " +
                    "  public.order_item_etiqueta.oie_saldo_conferencia, " +
                    "  pedidos_pai.pei_data_entrega, " +
                    "  public.unidade_medida.unm_abreviada, " +
                    "  u2.unm_abreviada, " +
                    "  produto.pro_unidades_por_un_compra, " +
                    "  pedidos_pai.id_pedido_item, " +
                    "  produto_k.prk_utiliza_dimensao_quantidade_baixa, " +
                    "  public.order_item_etiqueta.oie_dimensao, " +
                    "  public.order_item_etiqueta.oie_codigo_item ";


                read = command.ExecuteReader();


               IWTPostgreNpgsqlCommand command2 = this.conn.CreateCommand();

                double qtd = 0;

                while (read.Read())
                {
                    qtd = 0;
                    //Verifica se o Item é comprado
                    if (read["pro_tipo_aquisicao"].ToString() == "1")
                    {
                        //Item Comprado

                        //Verifica se é Item original
                        if (read["oie_item_original_pedido"].ToString() == "1")
                        {
                            //É Item original, a baixa ocorre somente na nf, então deve 
                            //Somar a qtd sempre
                            qtd = Convert.ToDouble(read["oie_saldo"]);

                        }
                        else
                        {
                            //Verificar a situação de conferencia
                            //Se ainda não foi conferido somar, caso contrário já foi baixado do estoque na conferencia

                            if (read["oie_situacao_conferencia"].ToString() != "2")
                            {
                                qtd = Convert.ToDouble(read["oie_saldo_conferencia"]);
                            }
                            else
                            {
                                continue;
                            }
                        }

                    }
                    else
                    {
                        //Item Fabricado
                        //Verificar se emite OP e a situação da OP
                        if ((read["prk_emite_op"] != DBNull.Value && read["prk_emite_op"].ToString() == "1") ||
                            (read["prk_emite_op"] == DBNull.Value && read["pro_emite_op"].ToString() == "1"))
                        {
                            //Item Emite OP
                            //Se a op não existir ainda ou exitir e não estiver encerrada deve dar baixa nos materiais desse Item
                            if (read["orpSituacao"] == DBNull.Value || read["orpSituacao"].ToString() == "0" ||
                                read["orpSituacao"].ToString() == "1")
                            {
                                if (buscaMateriais)
                                {
                                    this.IncluirMateriaisNecessarios(read["id_order_item_etiqueta"].ToString(),
                                        read["oie_order_number"] + "/" + read["oie_order_pos"],
                                        Convert.ToInt32(read["id_pedido_item"]),
                                        Convert.ToDateTime(read["pei_data_entrega"]),
                                        false,
                                        command2);
                                }
                            }
                            else
                            {
                                //Item emite OP mas a op já foi encerrada ou cancelada
                                continue;
                            }

                        }
                        else
                        {
                            //Item não emite OP 
                            if (read["oie_item_original_pedido"].ToString() == "1" || read["oie_etiqueta_interna"].ToString() == "0")
                            {
                                //É Item original, a baixa dos materirias ocorre somente na nf, então deve 
                                //Somar a qtd sempre
                                //Ou não é Item original mas não faz conferencia a qtd deve somar sempre
                                if (buscaMateriais)
                                {
                                    this.IncluirMateriaisNecessarios(read["id_order_item_etiqueta"].ToString(),
                                        read["oie_order_number"] + "/" + read["oie_order_pos"],
                                        Convert.ToInt32(read["id_pedido_item"]),
                                        Convert.ToDateTime(read["pei_data_entrega"]),
                                        false,
                                        command2);
                                }

                            }
                            else
                            {
                                //Verificar a situação de conferencia
                                //Se ainda não foi conferido somar os materiais, caso contrário já foi baixado do estoque na conferencia
                                if (read["oie_situacao_conferencia"].ToString() != "2")
                                {
                                    if (buscaMateriais)
                                    {
                                        this.IncluirMateriaisNecessarios(
                                            read["id_order_item_etiqueta"].ToString(),
                                            read["oie_order_number"] + "/" + read["oie_order_pos"],
                                            Convert.ToInt32(read["id_pedido_item"]),
                                            Convert.ToDateTime(read["pei_data_entrega"]),
                                            true, command2);
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        }
                        continue;
                    }

                    string unidade = read["unm_abreviada"].ToString();
                    string unidadeCompra = null;
                    double qtdUnidadesUsoPorUnidadeCompra = 1;
                    if (read["unidade_compra"] != DBNull.Value)
                    {
                        qtdUnidadesUsoPorUnidadeCompra = Convert.ToDouble(read["pro_unidades_por_un_compra"]);
                        unidadeCompra = read["unidade_compra"].ToString();
                    }


                    ProdutoClass produto = ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]), _usuarioAtual, conn);
                    itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Produto, produto);

                    if (!this.itensComprar.ContainsKey(tmpKey))
                    {
                        bool kb = false;
                        double loteProducao = 0.000001;
                        double estoqueMinimo = 0;
                        if (read["pro_politica_estoque"].ToString() == "1")
                        {
                            kb = true;

                            if (read["prk_emite_op"] != DBNull.Value)
                            {
                                if (read["prk_lote_producao"] != DBNull.Value)
                                {
                                    loteProducao = Convert.ToDouble(read["prk_lote_producao"]);
                                }

                                if (read["prk_verde"] != DBNull.Value)
                                {
                                    estoqueMinimo = Convert.ToDouble(read["prk_verde"]);
                                }
                            }
                            else
                            {
                                if (read["pro_lote_padrao_compra"] != DBNull.Value)
                                {
                                    loteProducao = Convert.ToDouble(read["pro_lote_padrao_compra"]);
                                }

                                if (read["pro_verde"] != DBNull.Value)
                                {
                                    estoqueMinimo = Convert.ToDouble(read["pro_verde"]);
                                }
                            }
                        }
                        else
                        {
                            if (read["pro_lote_padrao_compra"] != DBNull.Value)
                            {
                                loteProducao = Convert.ToDouble(read["pro_lote_padrao_compra"]);
                            }
                        }

                        this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                            TipoItemCompra.Produto,
                            tmpKey.Item,
                            read["pro_codigo"].ToString(),
                            read["pro_descricao"].ToString(),
                            kb,
                            produto.LoteMinimo.HasValue ? produto.LoteMinimo.Value : 0,
                            loteProducao,
                            estoqueMinimo,
                            unidade,
                            Convert.ToBoolean(Convert.ToInt16(read["pro_impedir_solicitacao_auto"])), Convert.ToDateTime(read["pei_data_entrega"]),
                            this.tipoCalculoSemana,
                            this.diaCalculoSemana,
                            unidadeCompra,
                            qtdUnidadesUsoPorUnidadeCompra,
                            this.leadtimePCP,
                            this.leadtimeCompras,
                            Convert.ToInt32(read["pro_lead_time_compra"]),
                            this.diasVerde,
                            this.diasAmarelo,
                            this.diasVermelho,
                            this.mesesMedia,
                            this.categoriaAAcimaDe,
                            this.categoriaBAcimaDe,
                            this.margemAvisoKB,
                            this.sugestaoCompraAcimaConfigurado,
                            this.conn));
                    }


                    double multiplicadorQtdKb = 1;
                    if (read["prk_utiliza_dimensao_quantidade_baixa"].ToString() == "1")
                    {
                        double tmp;
                        if (double.TryParse(read["oie_dimensao"].ToString(), out tmp))
                        {
                            multiplicadorQtdKb = tmp;
                        }
                        else
                        {
                            throw new Exception("O Item " + read["oie_codigo_item"] + " possui um Item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                        }
                    }


                    qtd = qtd*multiplicadorQtdKb;



                    this.itensComprar[tmpKey].setDataUtilizacao(Convert.ToDateTime(read["pei_data_entrega"]));
                    //this.itensComprar[tmpKey].qtdNecessaria += qtd;
                    this.itensComprar[tmpKey].adicionarPedido(
                        Convert.ToInt32(read["id_pedido_item"]), read["oie_order_number"] + "/" + read["oie_order_pos"], qtd, Convert.ToDateTime(read["pei_data_entrega"]));

                }

                read.Close();


                //Gerar Necessidade para os itens com estoque abaixo do verde e que não tenham gerado, gerar seguindo regra padrão
                //Só deve gerar caso não tenha sido selecionado nenhum Item
                if (!idProduto.HasValue && !idMaterial.HasValue)
                {
                    this.IncluirMateriaisSemPedido(ref command);
                }

                incluirDefaults(idMaterial, idProduto);

                #region Descontar do Cálculo a SC atual


                foreach (SolicitacaoCompraClass sc in solicitacoesDescontar)
                {
                    TipoItemCompra tipoItem = TipoItemCompra.Material;
                    if (sc.Produto != null)
                    {
                        tipoItem = TipoItemCompra.Produto;

                    }
                    if (sc.Material != null)
                    {
                        tipoItem = TipoItemCompra.Material;

                    }
                    if (sc.Epi != null)
                    {
                        tipoItem = TipoItemCompra.Epi;

                    }
                    AbstractEntity itemSc = null;
                    if (sc.Produto != null)
                    {
                        itemSc = sc.Produto;
                    }

                    if (sc.Material != null)
                    {
                        itemSc = sc.Material;
                    }

                    if (sc.Epi != null)
                    {
                        itemSc = sc.Epi;
                    }
                    itemNecessidadeCompraKey chaveTmp = new itemNecessidadeCompraKey(tipoItem, itemSc);
                    if (itensComprar.ContainsKey(chaveTmp))
                    {
                        itensComprar[chaveTmp].qtdSolicitacoesCompraAguardandoCompra = Math.Round(itensComprar[chaveTmp].qtdSolicitacoesCompraAguardandoCompra - sc.QtdUnidadeUso, 5);
                    }
                }
                #endregion

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de necessidade.\r\n" + e.Message, e);
            }
        }

        private void incluirDefaults(long? idMaterial,long? idProduto)
        {
            if (idMaterial.HasValue)
            {
                MaterialClass material = MaterialClass.GetEntidade(idMaterial.Value, _usuarioAtual, conn);
                itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Material, material);

                if (!this.itensComprar.ContainsKey(tmpKey))
                {
                    string unidade = material.UnidadeMedida.ToString();
                    string unidadeCompra = null;
                    double qtdUnidadesUsoPorUnidadeCompra = 1;

                    if (material.UnidadeMedidaCompra != null)
                    {
                        qtdUnidadesUsoPorUnidadeCompra = material.UnidadesPorUnCompra;
                        unidadeCompra = material.UnidadeMedidaCompra.ToString();
                    }


                    bool kb = false;
                    double estoqueMinimo = 0;
                    var loteProducao = material.LotePadrao;
                    if (material.PoliticaEstoque == PoliticaEstoque.Kanban)
                    {
                        kb = true;
                        estoqueMinimo = material.Verde;
                    }

                    string descricao = material.Descricao;
                    if (Math.Abs(material.Medida) > 0.00001)
                    {
                        descricao = material.MedidaCompleta + " - " + descricao;
                    }

                    this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                        TipoItemCompra.Material,
                        tmpKey.Item,
                        material.IdentificacaoCompleta,
                        descricao, kb,
                        material.LoteMinimo,
                        loteProducao,
                        estoqueMinimo,
                        unidade,
                        material.ImpedirSolicitacaoAuto,
                        Configurations.DataIndependenteClass.GetData(),
                        this.tipoCalculoSemana,
                        this.diaCalculoSemana,
                        unidadeCompra,
                        qtdUnidadesUsoPorUnidadeCompra,
                        this.leadtimePCP,
                        this.leadtimeCompras,
                        material.LeadTimeCompra,
                        this.diasVerde,
                        this.diasAmarelo,
                        this.diasVermelho,
                        this.mesesMedia,
                        this.categoriaAAcimaDe,
                        this.categoriaBAcimaDe,
                        this.margemAvisoKB,
                        this.sugestaoCompraAcimaConfigurado,
                        this.conn)
                        );
                }
            }

            if (idProduto.HasValue)
            {
                ProdutoClass produto = ProdutoClass.GetEntidade(idProduto.Value, _usuarioAtual, conn);
                itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Produto, produto);
                if (!this.itensComprar.ContainsKey(tmpKey))
                {
                    string unidade = produto.UnidadeMedida?.ToString();
                    string unidadeCompra = null;
                    double qtdUnidadesUsoPorUnidadeCompra = 1;
                    if (produto.UnidadeMedidaCompra != null)
                    {
                        qtdUnidadesUsoPorUnidadeCompra = produto.UnidadesPorUnCompra;
                        unidadeCompra = produto.UnidadeMedidaCompra.ToString();
                    }


                    bool kb = false;
                    double loteProducao = 0.000001;
                    double estoqueMinimo = 0;
                    if (produto.PoliticaEstoque == PoliticaEstoque.Kanban)
                    {
                        kb = true;

                        ProdutoKProdutoClass produtoK = produto.CollectionProdutoKProdutoClassProduto.FirstOrDefault();

                        if (produtoK != null)
                        {
                            loteProducao = produtoK.ProdutoK.LoteProducao;
                            estoqueMinimo = produtoK.ProdutoK.Verde;
                        }
                        else
                        {
                            if (produto.LotePadraoCompra.HasValue)
                            {
                                loteProducao = produto.LotePadraoCompra.Value;
                            }
                            estoqueMinimo = produto.Verde;
                        }
                    }
                    else
                    {
                        if (produto.LotePadraoCompra.HasValue)
                        {
                            loteProducao = produto.LotePadraoCompra.Value;
                        }
                    }

                    this.itensComprar.Add(tmpKey,
                        new itemNecessidadeCompra(
                        TipoItemCompra.Produto,
                        tmpKey.Item,
                        produto.Codigo,
                        produto.Descricao,
                        kb,
                        produto.LoteMinimo.HasValue ? produto.LoteMinimo.Value : 0,
                        loteProducao,
                        estoqueMinimo,
                        unidade,
                        produto.ImpedirSolicitacaoAuto,
                        Configurations.DataIndependenteClass.GetData(),
                        this.tipoCalculoSemana,
                        this.diaCalculoSemana,
                        unidadeCompra,
                        qtdUnidadesUsoPorUnidadeCompra,
                        this.leadtimePCP,
                        this.leadtimeCompras,
                        produto.LeadTimeCompra,
                        this.diasVerde,
                        this.diasAmarelo,
                        this.diasVermelho,
                        this.mesesMedia,
                        this.categoriaAAcimaDe,
                        this.categoriaBAcimaDe,
                        this.margemAvisoKB,
                        this.sugestaoCompraAcimaConfigurado,
                        this.conn));
                }
            }
        }

        private void IncluirMateriaisSemPedido(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                List<MaterialClass> materiais = new MaterialClass(_usuarioAtual, conn).Search(new List<SearchParameterClass>()).ConvertAll(a => (MaterialClass) a);

                foreach (MaterialClass material in materiais)
                {

                    itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Material, material);

                    if (!this.itensComprar.ContainsKey(tmpKey))
                    {
                        string unidade = material.UnidadeMedida.ToString();
                        string unidadeCompra = null;
                        double qtdUnidadesUsoPorUnidadeCompra = 1;

                        if (material.UnidadeMedidaCompra != null)
                        {
                            qtdUnidadesUsoPorUnidadeCompra = material.UnidadesPorUnCompra;
                            unidadeCompra = material.UnidadeMedidaCompra.ToString();
                        }


                        bool kb = false;
                        double estoqueMinimo = 0;
                        var loteProducao = material.LotePadrao;
                        if (material.PoliticaEstoque == PoliticaEstoque.Kanban)
                        {
                            kb = true;
                            estoqueMinimo = material.Verde;
                        }

                        string descricao = material.Descricao;
                        if (Math.Abs(material.Medida) > 0.00001)
                        {
                            descricao = material.MedidaCompleta + " - " + descricao;
                        }

                        this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                            TipoItemCompra.Material,
                            tmpKey.Item,
                            material.IdentificacaoCompleta,
                            descricao, kb,
                            material.LoteMinimo,
                            loteProducao,
                            estoqueMinimo,
                            unidade,
                            material.ImpedirSolicitacaoAuto,
                            Configurations.DataIndependenteClass.GetData(),
                            this.tipoCalculoSemana,
                            this.diaCalculoSemana,
                            unidadeCompra,
                            qtdUnidadesUsoPorUnidadeCompra,
                            this.leadtimePCP,
                            this.leadtimeCompras,
                            material.LeadTimeCompra,
                            this.diasVerde,
                            this.diasAmarelo,
                            this.diasVermelho,
                            this.mesesMedia,
                            this.categoriaAAcimaDe,
                            this.categoriaBAcimaDe,
                            this.margemAvisoKB,
                            this.sugestaoCompraAcimaConfigurado,
                            this.conn)
                            );
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao incluir os materiais sem pedidos.\r\n" + e.Message, e);
            }

        }

        private void IncluirMateriaisNecessarios(string idOrderItemEtiqueta,string pedido, int idPedidoItem, DateTime dataUtilizacao, bool utilizarSaldoConferencia,IWTPostgreNpgsqlCommand command)
        {
            try
            {
                command.CommandText =
                    "SELECT    " +
                    "  public.pedido_item_configurado_material.id_material,   " +
                    "  public.familia_material.fam_codigo,   " +
                    "  public.material.mat_lote_padrao,   " +
                    "  public.material.mat_verde,   " +
                    "  public.material.mat_amarelo,   " +
                    "  public.material.mat_vermelho,   " +
                    "  public.pedido_item_configurado_material.pcm_codigo,   " +
                    "  public.pedido_item_configurado_material.pcm_descricao,   " +
                    "  public.pedido_item_configurado_material.pcm_medida,   " +
                    "  public.pedido_item_configurado_material.pcm_medida_largura,   " +
                    "  public.pedido_item_configurado_material.pcm_medida_comprimento,   " +
                    "  public.material.mat_politica_estoque,   " +
                    "  public.pedido_item_configurado_material.pcm_quantidade_total,   " +
                    "  public.order_item_etiqueta.oie_saldo,   " +
                    "  public.order_item_etiqueta.oie_quantidade,   " +
                    "  public.order_item_etiqueta.oie_saldo_conferencia,     " +
                    "  public.unidade_medida.unm_abreviada,   " +
                    "  u2.unm_abreviada as unidade_compra,   " +
                    "  public.material.mat_lead_time_compra,   " +
                    "  public.material.mat_unidades_por_un_compra,   " +
                    "  public.material.mat_impedir_solicitacao_auto,   " +
                    "  produto_k.prk_utiliza_dimensao_quantidade_baixa,   " +
                    "  public.order_item_etiqueta.oie_dimensao,   " +
                    "  public.order_item_etiqueta.oie_codigo_item ,  " +
                    "  pedido_pai.pei_data_entrega   " +
                    "FROM   " +
                    "  public.pedido_item_configurado_material " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.pedido_item_configurado_material.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta)   " +
                    "  INNER JOIN public.material ON (public.pedido_item_configurado_material.id_material = public.material.id_material)  " +
                    "  INNER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material)  " +
                    "  INNER JOIN public.unidade_medida ON unidade_medida.id_unidade_medida = pedido_item_configurado_material.id_unidade_medida   " +
                    "  LEFT JOIN public.unidade_medida u2 ON u2.id_unidade_medida = material.id_unidade_medida_compra   " +
                    "  LEFT OUTER JOIN public.produto_k ON ( public.order_item_etiqueta.id_produto_k = public.produto_k.id_produto_k)   " +
                    "  LEFT OUTER JOIN (   " +
                    "    SELECT pedido_item_pai.pei_numero, pedido_item_pai.pei_posicao, pedido_item_pai.pei_data_entrega     " +
                    "    FROM public.pedido_item pedido_item_pai    " +
                    "    WHERE pedido_item_pai.pei_sub_linha = 0)   " +
                    "  as pedido_pai ON (order_item_etiqueta.oie_order_number = pedido_pai.pei_numero AND order_item_etiqueta.oie_order_pos = pedido_pai.pei_posicao)  " +
                    "WHERE " +
                    "  public.order_item_etiqueta.id_order_item_etiqueta = " + idOrderItemEtiqueta + "";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {

                    MaterialClass material = MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]), _usuarioAtual, conn);
                    itemNecessidadeCompraKey tmpKey = new itemNecessidadeCompraKey(TipoItemCompra.Material, material);


                    double qtd = 0;

                    double qtdTotalMaterial = Convert.ToDouble(read["pcm_quantidade_total"]);
                    double qtdTotalPedido = Convert.ToDouble(read["oie_quantidade"]);
                   


                    if (utilizarSaldoConferencia)
                    {
                        double razaoSaldoConferencia = Convert.ToDouble(read["oie_saldo_conferencia"]) / qtdTotalPedido;
                        qtd = Math.Round(qtdTotalMaterial * razaoSaldoConferencia, 5);
                    }
                    else
                    {
                        double razaoSaldoPedido = Convert.ToDouble(read["oie_saldo"]) / qtdTotalPedido;
                        qtd = Math.Round(qtdTotalMaterial*razaoSaldoPedido, 5);
                         
                    }

                    if (qtd == 0 || Double.IsNaN(qtd))
                    {
                        continue;
                    }


                    string unidade = material.UnidadeMedida.ToString();
                    string unidadeCompra = null;
                    double qtdUnidadesUsoPorUnidadeCompra = 1;

                    if (material.UnidadeMedidaCompra!=null)
                    {
                        qtdUnidadesUsoPorUnidadeCompra = material.UnidadesPorUnCompra;
                        unidadeCompra = material.UnidadeMedidaCompra.ToString();
                    }

                    DateTime? dataEntrega = read["pei_data_entrega"] as DateTime?;

                    if (!this.itensComprar.ContainsKey(tmpKey))
                    {
                        bool kb = false;
                        double loteProducao = material.LotePadrao;
                        double estoqueMinimo = 0;
                        if (material.PoliticaEstoque == PoliticaEstoque.Kanban)
                        {
                            kb = true;
                            estoqueMinimo = material.Verde;
                        }

                        string descricao =  read["pcm_descricao"].ToString();
                        if (read["pcm_medida"] != DBNull.Value && Convert.ToDouble(read["pcm_medida"]) != 0)
                        {
                            descricao = 
                                read["pcm_medida"] +
                                " X " + read["pcm_medida_largura"] +
                                " X " + read["pcm_medida_comprimento"] +
                                " - " + descricao;
                        }

                        


                        this.itensComprar.Add(tmpKey, new itemNecessidadeCompra(
                            TipoItemCompra.Material,
                            tmpKey.Item,
                            read["fam_codigo"] + " " + read["pcm_codigo"],
                            descricao, kb,
                            material.LoteMinimo,
                            loteProducao,
                            estoqueMinimo,
                            unidade,
                            material.ImpedirSolicitacaoAuto,
                            dataUtilizacao,
                            this.tipoCalculoSemana,
                            this.diaCalculoSemana,
                            unidadeCompra,
                            qtdUnidadesUsoPorUnidadeCompra,
                            this.leadtimePCP,
                            this.leadtimeCompras,
                            material.LeadTimeCompra,
                            this.diasVerde,
                            this.diasAmarelo,
                            this.diasVermelho,
                            this.mesesMedia,
                            this.categoriaAAcimaDe,
                            this.categoriaBAcimaDe,
                            this.margemAvisoKB,
                            this.sugestaoCompraAcimaConfigurado,
                            this.conn));
                    }

                    double multiplicadorQtdKb = 1;
                    if (read["prk_utiliza_dimensao_quantidade_baixa"].ToString()=="1")
                    {
                        double tmp;
                        if (double.TryParse(read["oie_dimensao"].ToString(), out  tmp))
                        {
                            multiplicadorQtdKb = tmp;
                        }
                        else
                        {
                            throw new Exception("O Item " + read["oie_codigo_item"] + " possui um Item agrupador e esta configurado pra utilizar a dimensão como a quantidade, no entanto a dimensão não é um número válido.");
                        }
                    }


                    qtd = qtd*multiplicadorQtdKb;


                    this.itensComprar[tmpKey].adicionarPedido(idPedidoItem, pedido, qtd, dataEntrega);
                    this.itensComprar[tmpKey].setDataUtilizacao(dataUtilizacao);
                }
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar os materiais para necessidade.\r\n" + e.Message, e);
            }
        }
    }

    public class itemNecessidadeCompraKey:IEquatable<itemNecessidadeCompraKey>
    {
        public TipoItemCompra tipoItem { private set; get; }
        public AbstractEntity Item { get; set; }

        public itemNecessidadeCompraKey(TipoItemCompra tipoItem, AbstractEntity item)
        {
            this.tipoItem = tipoItem;
            Item = item;
        }

        public bool Equals(itemNecessidadeCompraKey other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return tipoItem == other.tipoItem && Equals(Item, other.Item);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((itemNecessidadeCompraKey) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) tipoItem*397) ^ (Item != null ? Item.GetHashCode() : 0);
            }
        }

        public static bool operator ==(itemNecessidadeCompraKey left, itemNecessidadeCompraKey right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(itemNecessidadeCompraKey left, itemNecessidadeCompraKey right)
        {
            return !Equals(left, right);
        }
    }

    public class itemNecessidadeCompra
    {
        public AbstractEntity Item { private set; get; }
        public string codigo { private set; get; }
        public string descricao { private set; get; }
        
        public bool Kanban { private set; get; }
        public double lotePadrao { private set; get; }

        public double LoteMinimo { private set; get; }

        public double estoqueMinimo { private set; get; }

        public int leadtimePCP { private set; get; }
        public int leadtimeCompras { private set; get; }
        public int leadtimeItem { private set; get; }
        
        public TipoItemCompra tipoItem { private set; get; }  


        readonly int diasVerde;
        readonly int diasAmarelo;
        readonly int diasVermelho;
        readonly int mesesMedia;
        readonly double categoriaAAcimaDe;
        readonly double categoriaBAcimaDe;
        readonly double margemAvisoKB;

        internal readonly double sugestaoCompraAcimaConfigurado;

        
        public double qtdNecessaria {
            get
            {
                double toRet = 0;
                if (this.Pedidos!=null)
                {
                    toRet = 0;
                    foreach (var pedido in Pedidos)
                        toRet += pedido.Quantidade;
                }
                return toRet ;
            }
        }
        public double qtdEstoque { private set; get; }
        public double qtdComprada
        {
            get
            {
                return this.qtdSolicitacoesCompraAguardandoCompra + this.qtdSolicitacoesCompraCompradas;
            }
        }

        public double qtdSolicitacoesCompraAguardandoCompra { internal set; get; }
        public double qtdSolicitacoesCompraCompradas { private set; get; }
        
        public double qtdUnidadesDeUsoPorUnidadeCompra { private set; get; }

        public string unidadeMedida
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(this._unidadeMedidaCompra))
                {
                    return this._unidadeMedidaCompra;
                }
                else
                {
                    return this._unidadeMedidaUso;
                }
            }
        }

        private readonly string _unidadeMedidaCompra;
        private readonly string _unidadeMedidaUso;

        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        public DateTime menorDataUtilizacao { private set; get; }
        public String menorSemanaUtilizacao
        {
            get
            {
                int weekNum = IWTFunctions.IWTFunctions.getNumeroSemana(this.menorDataUtilizacao, this.tipoCalculoSemana, this.diaCalculoSemana);
                return this.menorDataUtilizacao.ToString("yy") + weekNum.ToString().PadLeft(2, '0');

            }
        }

        //public int semanaUltimaUtilizacao { private set; get; }

        readonly IWTPostgreNpgsqlConnection conn;
        


        public double qtdComprarOriginalUnidadeUso 
        {
            get
            {
                if (Kanban)
                {
                    return (this.estoqueMinimo - this.EVP) + ((this.sugestaoCompraAcimaConfigurado / 100) * this.estoqueMinimo);
                }
                else
                {
                    //MRP
                    return this.qtdNecessaria - this.qtdEstoque - this.qtdComprada;

                }
            }
        }

        public double qtdAComprar
        {
            get
            {

                double saldoComprar = qtdComprarOriginalUnidadeUso;
                
                saldoComprar = saldoComprar / this.qtdUnidadesDeUsoPorUnidadeCompra;

                if (saldoComprar > 0)
                {

                    if (lotePadrao <= 0)
                    {
                        lotePadrao = 0.0001;
                        //throw new ExcecaoTratada("Não é possível fazer o cálculo para compra pois o lote padrão definido é menor ou igual a zero (" + this.tipoItem + " " + this.codigo + "(" + this.Item.ID + ").");
                    }


                    if (saldoComprar < LoteMinimo)
                    {
                        saldoComprar = LoteMinimo;
                    }
                    else
                    {
                        
                        saldoComprar = Math.Round(saldoComprar - LoteMinimo, 5);
                        
                        int qtdLotesPadrao = (int) Math.Truncate(saldoComprar / lotePadrao);
                        double tmp = Math.Round(qtdLotesPadrao * lotePadrao, 4);
                        if (tmp < saldoComprar)
                        {
                            tmp += lotePadrao;
                        }

                        saldoComprar = Math.Round(tmp + LoteMinimo, 4);


                    }

                }

                return saldoComprar;

               
            }
        }

        public double qtdAComprarUnidadeUso
        {
            get { return this.qtdAComprar * this.qtdUnidadesDeUsoPorUnidadeCompra; }
        }

        internal double ConsumoMedioDiario { private set; get; }

        
        public double EVP
        {
            get
            {


                //if (Kanban)
                //{
                CalculaSugestaoKBClass sugKB = new CalculaSugestaoKBClass(conn);
                SugestaoKBClass sugestao = null;
                switch (tipoItem)
                {
                    case TipoItemCompra.Material:
                        sugestao = sugKB.Calcular((MaterialClass) this.Item, 0, 0, 0, "", 1);
                        break;
                    case TipoItemCompra.Produto:
                        sugestao = sugKB.CalcularProduto((ProdutoClass) this.Item, 0, 0, 0, "");
                        break;
                    case TipoItemCompra.Epi:
                        sugestao = sugKB.CalcularEpi((EpiClass) this.Item, 0, 0, 0, "", 1);
                        break;
                    default:
                        throw new Exception("Tipo de Item de Compra inválido para o cálculo do EVP.");

                }

                ConsumoMedioDiario = sugestao.consumoMedioDiario;
                return this.qtdEstoque + this.qtdComprada - this.qtdNecessaria - (sugestao.consumoMedioDiario*(this.leadtimeCompras + this.leadtimeItem + this.leadtimePCP));
                //}
                //else
                //{
                //    this._EVP = 0;
                //}

            }
        }

        public string tipoItemStr
        {
            get
            {
                switch (tipoItem)
                {
                    case TipoItemCompra.Material:
                        return "MATERIAL";
                    case TipoItemCompra.Produto:
                        return "PRODUTO";
                    case TipoItemCompra.Epi:
                        return "EPI";
                    default:
                        return "";
                }
                
            }
        }


        public string HistoricoCalculo
        {
            get
            {
                string historicoCalculoNecessidade = "";
                historicoCalculoNecessidade += "Quantidade em Estoque: " + qtdEstoque.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Quantidade Comprada: " + qtdSolicitacoesCompraCompradas.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Quantidade Em Solicitações Aguardando Compra: " + qtdSolicitacoesCompraAguardandoCompra.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Quantidade Necessária Pedidos: " + qtdNecessaria.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Consumo Médio Diário: " + ConsumoMedioDiario.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Leadtime de PCP: " + leadtimePCP + "Dias" + Environment.NewLine;
                historicoCalculoNecessidade += "Leadtime de Compras: " + leadtimeCompras +"Dias"+ Environment.NewLine;
                historicoCalculoNecessidade += "Leadtime do Item: " + leadtimeItem + "Dias" + Environment.NewLine;
                historicoCalculoNecessidade += "Sugestão de Compra Acima (configurado no sistema): " + sugestaoCompraAcimaConfigurado.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) +"%"+ Environment.NewLine;
                historicoCalculoNecessidade += "Demanda Sugerida Verde: " + estoqueMinimo.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Item KB: " + (Kanban ? "SIM" : "Não") + Environment.NewLine;
                historicoCalculoNecessidade += "Qtd Unidades de uso por Unidade de Compra: " + qtdUnidadesDeUsoPorUnidadeCompra.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Lote Mínimo: " + LoteMinimo.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                historicoCalculoNecessidade += "Lote de Compra: " + lotePadrao.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;

                historicoCalculoNecessidade += "EVP = QtdEstoque + QtdComprada + QtdAguardandoCompra - QtdNecessaria - (ConsumoMedioDiario * (LeadtimeCompras + LeadtimeItem + LeadtimePCP)): EVP=" + EVP.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + Environment.NewLine;

                if (Kanban)
                {

                    historicoCalculoNecessidade += "Quantidade a Comprar Original = (DemandaSugeridaVerde - EVP) + ((SugestaoCompraAcimaConfigurado / 100) * DemandaSugeridaVerde): Quantidade a Comprar = " + qtdComprarOriginalUnidadeUso.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " "+_unidadeMedidaUso + Environment.NewLine;
                }
                else
                {
                    historicoCalculoNecessidade += "Quantidade a Comprar Original = this.QtdNecessaria - QtdEstoque - QtdComprada - QtdAguardandoCompra: Quantidade a Comprar = " + qtdComprarOriginalUnidadeUso.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;
                }

                historicoCalculoNecessidade += "Quantidade a Comprar Final (Unidade Compra): " + qtdAComprar.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + unidadeMedida + Environment.NewLine;
                historicoCalculoNecessidade += "Quantidade a Comprar Final (Unidade Uso): " + qtdAComprarUnidadeUso.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + Environment.NewLine;



                historicoCalculoNecessidade += "Pedidos: " + Environment.NewLine;
                foreach (itemNecessidadeCompraPedidoClass pedido in Pedidos.OrderBy(a=>a.DataEntrega).ThenBy(a=>a.Quantidade))
                {
                    historicoCalculoNecessidade += pedido.Pedido + " - " + pedido.Quantidade.ToString("F5", CultureInfo.GetCultureInfo("pt-BR")) + " " + _unidadeMedidaUso + " - Entrega: " + (pedido.DataEntrega.HasValue ? pedido.DataEntrega.Value.ToString("dd/MM/yyyy") : "") + Environment.NewLine;
                }

                return historicoCalculoNecessidade;

            }
        }


        public List<itemNecessidadeCompraPedidoClass> Pedidos { get; private set; }

        public bool impedirSolicitacaoAutomatica { private set; get; }

        public itemNecessidadeCompra(
            TipoItemCompra tipoItem, AbstractEntity Item, string codigo, string descricao, bool Kanban,
            double loteMinimo, 
            double lotePadrao, double estoqueMinimo, string unidadeMedida,
            bool impedirSolicitacaoAutomatica, 
            DateTime dataUtilizacao, string tipoCalculoSemana, string diaCalculoSemana, 
            string unidadeMedidaCompra,double qtdUnidadesDeUsoPorUnidadeCompra,
            int leadtimePCP, int leadtimeCompras, int leadtimeItem, 
            int diasVerde,
            int diasAmarelo, int diasVermelho, int mesesMedia,
            double categoriaAAcimaDe, double categoriaBAcimaDe,
            double margemAvisoKB,
            double sugestaoCompraAcimaConfigurado,
            IWTPostgreNpgsqlConnection conn)
        {
            this.Item = Item;
            this.codigo = codigo;
            this.descricao = descricao;
            this.Kanban = Kanban;
            LoteMinimo = loteMinimo;
            this.lotePadrao = lotePadrao;
            this.estoqueMinimo = estoqueMinimo;
            this._unidadeMedidaUso = unidadeMedida;
            this.impedirSolicitacaoAutomatica = impedirSolicitacaoAutomatica;

            this.conn = conn;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.menorDataUtilizacao = dataUtilizacao;

            this._unidadeMedidaCompra = unidadeMedidaCompra;
            this.qtdUnidadesDeUsoPorUnidadeCompra = qtdUnidadesDeUsoPorUnidadeCompra;

            this.leadtimePCP = leadtimePCP;
            this.leadtimeCompras = leadtimeCompras;
            this.leadtimeItem = leadtimeItem;

            this.diasVerde = diasVerde;
            this.diasAmarelo = diasAmarelo;
            this.diasVermelho = diasVermelho;
            this.mesesMedia = mesesMedia;
            this.categoriaAAcimaDe = categoriaAAcimaDe;
            this.categoriaBAcimaDe = categoriaBAcimaDe;
            this.margemAvisoKB = margemAvisoKB;

            this.sugestaoCompraAcimaConfigurado = sugestaoCompraAcimaConfigurado;

            this.tipoItem = tipoItem;



            qtdEstoque = CarregarEstoqueAtual(tipoItem, Item, conn);


            double qtdAguardandoCompra;
            double qtdAguardandoRecebimento;
            CarregarQtdComprada(tipoItem,Item,qtdUnidadesDeUsoPorUnidadeCompra,conn,out qtdAguardandoCompra, out qtdAguardandoRecebimento);

            qtdSolicitacoesCompraAguardandoCompra = qtdAguardandoCompra;
            qtdSolicitacoesCompraCompradas = qtdAguardandoRecebimento;

            this.Pedidos = new List<itemNecessidadeCompraPedidoClass>();
            
        }

        public static void CarregarQtdComprada(TipoItemCompra tipo, AbstractEntity entidade, double qtdUnidadesDeUsoPorUnidadeCompra, IWTPostgreNpgsqlConnection connection, out double qtdAguardandoCompra, out double qtdAguardandoRecebimento)
        {
            try
            {
                #region Aguardando Compra
                IWTPostgreNpgsqlCommand command = connection.CreateCommand();
                switch (tipo)
                {
                    case TipoItemCompra.Material:
                        command.CommandText =
                            "SELECT  " +
                            "  SUM(public.solicitacao_compra.soc_saldo_recebimento) AS soma " +
                            "FROM " +
                            "  public.solicitacao_compra " +
                            "WHERE " +
                            "  public.solicitacao_compra.id_material = " + entidade.ID + " AND  " +
                            "  (public.solicitacao_compra.soc_status = 0 OR " +
                            "  public.solicitacao_compra.soc_status = 1 OR " +
                            "  public.solicitacao_compra.soc_status = 2 " +
                            "  ) ";
                        break;
                    case TipoItemCompra.Produto:
                        command.CommandText =
                            "SELECT  " +
                            "  SUM(public.solicitacao_compra.soc_saldo_recebimento) AS soma " +
                            "FROM " +
                            "  public.solicitacao_compra " +
                            "WHERE " +
                            "  public.solicitacao_compra.id_produto = " + entidade.ID + " AND  " +
                            "  (public.solicitacao_compra.soc_status = 0 OR " +
                            "  public.solicitacao_compra.soc_status = 1 OR " +
                            "  public.solicitacao_compra.soc_status = 2 " +
                            "  ) ";

                        break;
                    case TipoItemCompra.Epi:
                        command.CommandText =
                           "SELECT  " +
                           "  SUM(public.solicitacao_compra.soc_saldo_recebimento) AS soma " +
                           "FROM " +
                           "  public.solicitacao_compra " +
                           "WHERE " +
                           "  public.solicitacao_compra.id_epi = " + entidade.ID + " AND  " +
                           "  (public.solicitacao_compra.soc_status = 0 OR " +
                           "  public.solicitacao_compra.soc_status = 1 OR " +
                           "  public.solicitacao_compra.soc_status = 2 " +
                           "  ) ";
                        break;
                    default:
                        break;
                }


                object tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    qtdAguardandoCompra = 0;
                }
                else
                {
                    qtdAguardandoCompra = Convert.ToDouble(tmp) * qtdUnidadesDeUsoPorUnidadeCompra;
                }
                #endregion

                #region Aguardando Recebimento
                switch (tipo)
                {
                    case TipoItemCompra.Material:
                        command.CommandText =
                             command.CommandText =
                            "SELECT  " +
                            "  SUM(ROUND(public.solicitacao_compra.soc_saldo_recebimento* (public.solicitacao_compra.soc_qtd_unidade_uso/public.solicitacao_compra.soc_qtd),5)) AS soma "+
                            "FROM " +
                            "  public.solicitacao_compra " +
                            "WHERE " +
                            "  public.solicitacao_compra.id_material = " + entidade.ID + " AND  " +
                            "  (public.solicitacao_compra.soc_status = 3 OR " +
                            "  public.solicitacao_compra.soc_status = 4 " +
                            "  ) ";
                        break;
                    case TipoItemCompra.Produto:
                        command.CommandText =
                            command.CommandText =
                            "SELECT  " +
                            "  SUM(ROUND(public.solicitacao_compra.soc_saldo_recebimento* (public.solicitacao_compra.soc_qtd_unidade_uso/public.solicitacao_compra.soc_qtd),5)) AS soma " +
                            "FROM " +
                            "  public.solicitacao_compra " +
                            "WHERE " +
                            "  public.solicitacao_compra.id_produto = " + entidade.ID + " AND  " +
                            "  (public.solicitacao_compra.soc_status = 3 OR " +
                            "  public.solicitacao_compra.soc_status = 4 " +
                            "  ) ";
                        break;
                    case TipoItemCompra.Epi:
                        command.CommandText =
                           command.CommandText =
                           "SELECT  " +
                           "  SUM(ROUND(public.solicitacao_compra.soc_saldo_recebimento* (public.solicitacao_compra.soc_qtd_unidade_uso/public.solicitacao_compra.soc_qtd),5)) AS soma " +
                           "FROM " +
                           "  public.solicitacao_compra " +
                           "WHERE " +
                           "  public.solicitacao_compra.id_epi = " + entidade.ID + " AND  " +
                           "  (public.solicitacao_compra.soc_status = 3 OR " +
                           "  public.solicitacao_compra.soc_status = 4 " +
                           "  ) ";
                        break;
                    default:
                        break;
                }
                
                tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    qtdAguardandoRecebimento = 0;
                }
                else
                {
                    //Marco 2019-05-16: Retirada a multiplicação pois a consulta já faz a conversão levando em consideração os valores utilizados originalmente.
                    //this.qtdSolicitacoesCompraCompradas = Convert.ToDouble(tmp) * this.qtdUnidadesDeUsoPorUnidadeCompra;
                    qtdAguardandoRecebimento = Convert.ToDouble(tmp);
                }
                #endregion

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a quantidade comprada\r\n." + e.Message, e);
            }
        }

        public static double CarregarEstoqueAtual(TipoItemCompra tipo, AbstractEntity entidade, IWTPostgreNpgsqlConnection connection)
        {
            try
            {
                IWTPostgreNpgsqlCommand command = connection.CreateCommand();

                switch (tipo)
                {
                    case TipoItemCompra.Material:
                        return EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueMaterial((MaterialClass) entidade, ref command);

                    case TipoItemCompra.Produto:
                        return EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueProduto((ProdutoClass) entidade, ref command);

                    case TipoItemCompra.Epi:
                        return EstoqueMovimentacao.BuscaQuantidadeAtualEstoqueEpi((EpiClass) entidade, ref command);
                    default:
                        throw new Exception("Tipo de item inválido para buscar estoque atual");
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o estoque atual do Item.\r\n" + e.Message, e);
            }
        }

        internal void setDataUtilizacao(DateTime data)
        {
            if (data.CompareTo(this.menorDataUtilizacao) > 0)
            {
                this.menorDataUtilizacao = data;
            }
        }


        internal void adicionarPedido(int IdPedidoItem, string pedido, double Quantidade, DateTime? dataEntrega)
        {
            
            this.Pedidos.Add(new itemNecessidadeCompraPedidoClass(IdPedidoItem,pedido, Quantidade, dataEntrega));
        }


    }

    public class itemNecessidadeCompraPedidoClass
    {
        public int IdPedidoItem { get; private set; }
        public double Quantidade { get; private set; }
        public string Pedido { get; private set; }
        public DateTime? DataEntrega { get; private set; }


        public itemNecessidadeCompraPedidoClass(int idPedidoItem, string pedido, double quantidade, DateTime? dataEntrega)
        {
            IdPedidoItem = idPedidoItem;
            Quantidade = quantidade;
            Pedido = pedido;
            DataEntrega = dataEntrega;
        }
    }

    public enum TipoItemCompra { Material, Produto, Epi }

}
