using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Relatorios;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTCustomControls;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using OrdemProducaoGrupoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoGrupoClass;
using OrdemProducaoPedidoClass = BibliotecaEntidades.Operacoes.OrdemProducao.OrdemProducaoPedidoClass;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoGeradorClass
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly AcsUsuarioClass Usuario;
        readonly string tipoCalculoSemana;
        readonly string diaCalculoSemana;
        private readonly OrdemProducaoGrupoClass Grupo;
        private readonly bool UtilizarEstoqueOP;

        public OrdemProducaoGeradorClass(AcsUsuarioClass Usuario, IWTPostgreNpgsqlConnection conn, string tipoCalculoSemana, string diaCalculoSemana, bool utilizarEstoqueOP, IOrdemProducaoFactory iOrdemProducaoFactory)
        {
            this.Usuario = Usuario;
            this.conn = conn;
            this.tipoCalculoSemana = tipoCalculoSemana;
            this.diaCalculoSemana = diaCalculoSemana;
            this.UtilizarEstoqueOP = utilizarEstoqueOP;
            this.Grupo = iOrdemProducaoFactory.getInstanceOPGrupo(this.conn, this.Usuario);
        }

        public List<OrdemProducaoOc> listarOcsParaGeracao(DateTime? data, TipoItemSelecao tipoItem, string order, int? pos, int? idCliente, ProdutoClass produto, out  List<int> idsOrderItemEtiquetaPlanoCorteAvulsos)
        {
            try
            {

                List<OrdemProducaoOc> ocs = new List<OrdemProducaoOc>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT " +
                    "  produto.id_produto, " +
                    "  order_item_etiqueta.id_order_item_etiqueta, " +
                    "  order_item_etiqueta.oie_order_number, " +
                    "  order_item_etiqueta.oie_order_pos, " +
                    "  public.order_item_etiqueta.oie_dimensao, " +
                    "  public.order_item_etiqueta.id_externo_cliente_access, " +
                    "  public.order_item_etiqueta.oie_numero_documento, " +
                    "  public.order_item_etiqueta.oie_tipo_documento, " +
                    "  public.order_item_etiqueta.oie_revisao_desenho, " +
                    "  public.produto.pro_codigo as codigo_produto, "+
                    "  public.produto.pro_descricao as descricao_produto, "+
                    "  public.order_item_etiqueta.oie_ordem_producao_impressa, " +
                    "  public.order_item_etiqueta.oie_ordem_producao_impressa_data, " +
                    "  CASE WHEN order_number IS NULL THEN public.order_item_etiqueta.oie_data_entrega ELSE public.order_item.delivery_date END as data_entrega, " +
                    "  CASE WHEN id_pedido_kit IS NULL THEN 0 ELSE 1 END as kit, " +
                    "  produto_k.prk_codigo, "+
                    "  public.order_item_etiqueta.oie_dimensao," +
                    "  pais.pif_texto " +
                    "FROM " +
                    "  order_item_etiqueta " +
                    "  LEFT OUTER JOIN public.produto ON (public.order_item_etiqueta.id_produto = public.produto.id_produto) " +
                    "  LEFT OUTER JOIN public.order_item ON (public.order_item_etiqueta.oie_order_number = public.order_item.order_number) " +
                    "  AND (public.order_item_etiqueta.oie_order_pos = public.order_item.order_pos) " +
                    "  JOIN ( "+
                        "SELECT  " +
                        "   pedido_item.pei_numero AS oie_order_number, " +
                        " pedido_item.pei_posicao AS oie_order_pos, " +
                        " pedido_item.id_cliente, " +
                        " public.pedido_item_feedback.pif_texto " +
                        " FROM " +
                        " pedido_item " +
                        " LEFT OUTER JOIN public.pedido_item_feedback ON(public.pedido_item_feedback.id_pedido_item = pedido_item.id_pedido_item) " +
                        " WHERE " +
                        " pei_sub_linha = 0 AND " +
                        " (pei_status = 0 OR " +
                        " pei_status = 3 OR " +
                        " pei_status = 4) " +
                        " AND (public.pedido_item_feedback.pif_atual = 1 OR public.pedido_item_feedback.pif_atual IS NULL) " +
                    " ) as pais ON pais.oie_order_number=order_item_etiqueta.oie_order_number AND pais.oie_order_pos=order_item_etiqueta.oie_order_pos AND pais.id_cliente = order_item_etiqueta.id_cliente " +
                    "  LEFT OUTER JOIN pedido_kit ON order_item_etiqueta.oie_order_number = pek_oc AND order_item_etiqueta.oie_order_pos = pek_pos " +
                    "  LEFT JOIN produto_k ON produto_k.id_produto_k = order_item_etiqueta.id_produto_k "+
                    "WHERE " ;
                //"  (public.order_item_etiqueta.oie_status_pedido = 'P' OR public.order_item_etiqueta.oie_status_pedido = 'R') AND " +
                //"  public.order_item_etiqueta.oie_tipo_item = 1 AND " +
                if (data != null)
                {
                    command.CommandText += "  CASE WHEN order_number IS NULL THEN public.order_item_etiqueta.oie_data_entrega ELSE public.order_item.delivery_date END <= '" + data.Value.ToString("yyyy-MM-dd") + "' AND ";
                }

                string filtro = "";
                if (!string.IsNullOrEmpty(order))
                {
                    filtro += " AND  order_item_etiqueta.oie_order_number LIKE '" + order + "' ";
                }

                if (pos.HasValue)
                {
                    filtro += " AND  order_item_etiqueta.oie_order_pos = " + pos.Value + " ";
                }

                if (idCliente.HasValue)
                {
                    filtro += " AND order_item_etiqueta.id_cliente = " + idCliente + " ";
                }

                if (produto!=null)
                {
                    filtro += " AND order_item_etiqueta.id_produto = " + produto.ID + " ";
                }


             if (filtro.Length>0)
             {
                 command.CommandText += " ( " + filtro.Substring(4) + " ) AND ";
             }


                string sqlPlanoCorte = command.CommandText + " (((produto_k.prk_emite_op IS NULL AND produto.pro_emite_op = 0) OR (produto_k.prk_emite_op = 0)) AND produto.pro_emite_plano_corte = 1) ";
                
                command.CommandText += " ((produto_k.prk_emite_op IS NULL AND produto.pro_emite_op = 1) OR (produto_k.prk_emite_op = 1))";

                switch (tipoItem)
                {
                    case TipoItemSelecao.SomenteKit:
                        command.CommandText += " AND id_pedido_kit IS NOT NULL ";
                        break;
                    case TipoItemSelecao.SomenteNaoKit:
                        command.CommandText += " AND id_pedido_kit IS NULL ";
                        break;
                    default:
                        break;
                }



                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    bool semProduto;
                    if (read["id_produto"] != DBNull.Value)
                    {
                        semProduto = false;
                    }
                    else
                    {

                        semProduto = true;

                    }

                    OrdemProducaoOc oc = new OrdemProducaoOc
                        (read["id_externo_cliente_access"].ToString(),
                         read["codigo_produto"].ToString(),
                         Convert.ToDateTime(read["data_entrega"]),
                         read["oie_ordem_producao_impressa_data"] as DateTime?,
                         read["descricao_produto"].ToString(),
                         read["oie_dimensao"].ToString(),
                         Convert.ToInt32(read["id_order_item_etiqueta"]),
                         Convert.ToBoolean(Convert.ToInt16(read["kit"])),
                         read["oie_numero_documento"].ToString(),
                         read["oie_order_number"].ToString(),
                         Convert.ToBoolean(Convert.ToInt16(read["oie_ordem_producao_impressa"])),
                         read["oie_order_pos"].ToString(),
                         read["prk_codigo"].ToString(),
                         read["oie_revisao_desenho"].ToString(),
                         semProduto,
                         read["oie_tipo_documento"].ToString(),
                         read["id_produto"] as int?,
                         read["pif_texto"].ToString()
                         ,Usuario, conn);


                    


                    ocs.Add(oc);
                }
                read.Close();

                command.CommandText = sqlPlanoCorte;
                read = command.ExecuteReader();
                idsOrderItemEtiquetaPlanoCorteAvulsos = new List<int>(); 
                while (read.Read())
                {
                    int id = Convert.ToInt32(read["id_order_item_etiqueta"]);
                    if (!idsOrderItemEtiquetaPlanoCorteAvulsos.Contains(id))
                    {
                        idsOrderItemEtiquetaPlanoCorteAvulsos.Add(id);
                    }
                }

                read.Close();

                return ocs;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao listar os pedidos para seleção.\r\n" + e.Message);
            }
        }

        public List<OrdemProducaoOc> listarOcsParaGeracao(string Semana, TipoItemSelecao tipoItem, out  List<int> idsOrderItemEtiquetaPlanoCorteAvulsos)
        {
            //identifica a data final da semana
            if (Semana.Length != 3 && Semana.Length != 4)
            {
                throw new Exception("Semana inválida. A semana deve ter 3 ou 4 caracteres");
            }
            try
            {
                int ano = int.Parse(Semana.Substring(0, 2)) + 2000;
                int semana = int.Parse(Semana.Substring(2));

                DateTime date = new DateTime(ano, 1, 1);
                int semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(date, this.tipoCalculoSemana, this.diaCalculoSemana);
                while (semana != semanaTmp)
                {
                    date = date.AddDays(1);
                    semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(date, this.tipoCalculoSemana, this.diaCalculoSemana);
                }

                //Corre para o último dia da semana
                date = date.AddDays(6);
                return this.listarOcsParaGeracao(date, tipoItem, null, null, null,null, out idsOrderItemEtiquetaPlanoCorteAvulsos);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao identificar o término da semana.\r\n" + e.Message);
            }
        }

        private List<OrdemProducaoClass> gerarOps(List<OrdemProducaoOc> ocs, List<int> idsOrderItemEtiquetaPlanoCorteAvulsos, out List<OrdemProducaoOc> ocsSemProduto, out string erroGeral, bool somenteVerificar, out bool existeOpGerar)
        {
            IWTPostgreNpgsqlCommand command = null;
            Dictionary<OrdemProducaoKeyClass,OrdemProducaoClass> OPs = new Dictionary<OrdemProducaoKeyClass,OrdemProducaoClass>();
            ocsSemProduto = new List<OrdemProducaoOc>();
            erroGeral = "";
            existeOpGerar = false;

            try
            {
                command = this.conn.CreateCommand();

                command.Transaction = this.conn.BeginTransaction();

                if (ocs.Count==0)
                {
                    throw new Exception("Nenhum item atende aos critérios selecionados.");
                }

                command.CommandText =
                    "CREATE LOCAL TEMPORARY TABLE \"ordem_producao_select_temp\" ( " +
                    "  \"onu\" VARCHAR(255),  " +
                    "  \"op\" INTEGER, " +
                    "  \"id\" INTEGER "+
                    ") ON COMMIT DROP;";

                //command.CommandText =
                //   "CREATE TABLE \"ordem_producao_select_temp\" ( " +
                //   "  \"onu\" VARCHAR(255),  " +
                //   "  \"op\" INTEGER " +
                //   ") WITH OIDS;";
                
                command.ExecuteNonQuery();

                command.CommandText = "INSERT INTO ordem_producao_select_temp(onu,op,id) VALUES ";

                List<int> jaInseridos = new List<int>();


                foreach (OrdemProducaoOc oc in ocs)
                {
                    if (!jaInseridos.Contains(oc.idOrderItemEtiqueta))
                    {
                        command.CommandText += "('" + oc.oc + "'," + oc.pos + "," + oc.idOrderItemEtiqueta + "),";
                        jaInseridos.Add(oc.idOrderItemEtiqueta);
                    }

                }
                command.CommandText = command.CommandText.Remove(command.CommandText.Length - 1);
                command.ExecuteNonQuery();

               
                command.CommandText =
                    "SELECT * FROM (                                                  																																																																			" +
                    "    SELECT                                                                                                                                                                                             " +
                    "    *,                                                                                                                                                                                                 " +
                    "    CASE WHEN order_number IS NULL THEN oie_data_entrega ELSE order_item.delivery_date END as data                                                                                                     " +
                    "     FROM (                                                                                                                                                                                            " +
                    "        SELECT id_order_item_etiqueta,                                                                                                                                                                 " +
                    "               oie_order_number,                                                                                                                                                                       " +
                    "               oie_order_pos,                                                                                                                                                                          " +
                    "               oie_tipo_item,                                                                                                                                                                          " +
                    "               oie_dimensao,                                                                                                                                                                           " +
                    "               CASE WHEN cli_nome_resumido IS NULL THEN id_externo_cliente_access ELSE cli_nome_resumido END as cliente_res,                                                                                                                                                                      " +
                    "               oie_cnc,                                                                                                                                                                                " +
                    "               oie_saf,                                                                                                                                                                                " +
                    "               oie_var_1_nome,                                                                                                                                                                         " +
                    "               oie_var_1_valor,                                                                                                                                                                        " +
                    "               oie_var_2_nome,                                                                                                                                                                         " +
                    "               oie_var_2_valor,                                                                                                                                                                        " +
                    "               oie_var_3_nome,                                                                                                                                                                         " +
                    "               oie_var_4_nome,                                                                                                                                                                         " +
                    "               oie_var_3_valor,                                                                                                                                                                        " +
                    "               oie_var_4_valor,                                                                                                                                                                        " +
                    "               oie_data_entrega,                                                                                                                                                                       " +
                    "               oie_quantidade,                                                                                                                                                                         " +
                    "               oie_numero_documento,                                                                                                                                                                   " +
                    "               oie_tipo_documento,                                                                                                                                                                     " +
                    "               oie_revisao_desenho,                                                                                                                                                                    " +
                    "               oie_codigo_item,                                                                                                                                                                        " +
                    "               oie_tipo_ligacao,                                                                                                                                                                       " +
                    "               oie_codigo_item_pai,                                                                                                                                                                    " +
                    "               oie_desc_item_pai,                                                                                                                                                                      " +
                    "               oie_acab_item_pai,                                                                                                                                                                      " +
                    "               id_produto, "+
                    "               id_produto_k, "+
                    "               oie_versao_estrutura_item, " +
                    "               oie_rastreamento_material, "+
                    "               order_item_etiqueta.id_cliente "+
                    "        FROM order_item_etiqueta LEFT JOIN                                                                                                                                                                       " +
                    "             cliente ON order_item_etiqueta.id_cliente = cliente.id_cliente "+
                    "        WHERE oie_ordem_producao_impressa = 0                                                                       "+
                    //"             (oie_status_pedido = 'P' OR                                                                                                                                          " +
                    //"              oie_status_pedido = 'R')                                                                                                                                 " +
                    "                                                                                                                                                    " +
                    "        ) as order_item_etiqueta                                                                                                                                                                       " +
                    "         LEFT OUTER JOIN order_item ON (                                                                                                                                                               " +
                    "               order_item_etiqueta.oie_order_number =                                                                                                                                                  " +
                    "                order_item.order_number) AND (                                                                                                                                                         " +
                    "                order_item_etiqueta.oie_order_pos = order_item.order_pos)                                                                                                                              " +
                    "        JOIN (                                                                                                                                                                                         " +
                    "            SELECT pei_numero as oie_order_number, "+
                    "               pei_posicao as oie_order_pos, " +
                    "               id_cliente, "+
                    "               pei_status "+
                    "            FROM pedido_item  "+
                    "            WHERE pei_sub_linha = 0 AND( "+
                    "               pei_status = 0 OR "+
                    "               pei_status = 3 OR "+
                    "               pei_status = 4 "+
                    "               )                                                                                                                                                              " +
                    "             ) as pais  ON pais.oie_order_number = order_item_etiqueta.oie_order_number AND pais.oie_order_pos = order_item_etiqueta.oie_order_pos AND order_item_etiqueta.id_cliente = pais.id_cliente                                                     " +
                    //"        JOIN ordem_producao_select_temp ON ordem_producao_select_temp.onu = order_item_etiqueta.oie_order_number AND ordem_producao_select_temp.op = order_item_etiqueta.oie_order_pos                 " +
                    "        JOIN ordem_producao_select_temp ON ordem_producao_select_temp.id = order_item_etiqueta.id_order_item_etiqueta                 " +
                    "   ) as tab                                                                                                                                                                                            " +
                    "   	LEFT OUTER JOIN produto ON (                                                                                                                                                                      " +
                    "     tab.id_produto = produto.id_produto                                                                                                                                                          " +
                    "    )                                                                                                                                                                                                  "+
                    "    LEFT JOIN produto_k ON tab.id_produto_k = produto_k.id_produto_k "+
                    "WHERE produto.id_produto IS NULL OR (produto_k.prk_emite_op IS NULL AND produto.pro_emite_op = 1) OR (produto_k.prk_emite_op = 1)                                                                                                                                                                     " +
                    "                                                                                                                                                                            " +
                    "ORDER BY                                                                                                                                                                                               " +
                    "	oie_codigo_item,                                                                                                                                                                                   " +
                    "	oie_tipo_documento,                                                                                                                                                                                   " +
                    "	oie_numero_documento,                                                                                                                                                                                 " +
                    "	oie_revisao_desenho,                                                                                                                                                                                  " +
                    "	cliente_res,                                                                                                                                                                                    " +
                    "	oie_dimensao,                                                                                                                                                                                         "+
                    "   oie_rastreamento_material ";


                Dictionary<OrdemProducaoKeyClass, IdsUpdate> idsToUpdate = new Dictionary<OrdemProducaoKeyClass, IdsUpdate>();
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                while (read.Read())
                {
                    
                    if (read["pro_estrutura_em_revisao"].ToString() == "1")
                    {
                        ocsSemProduto.Add(new OrdemProducaoOc(
                                              read["oie_order_number"].ToString(),
                                              read["oie_order_pos"].ToString(),
                                              read["oie_codigo_item"].ToString()));
                        continue;
                    }

                    if (read["pei_status"].ToString() == "4")
                    {
                        erroGeral += "Não é possível gerar ops para o pedido " + read["oie_order_number"] + "/" + read["oie_order_pos"] + " pois ele está suspenso.\r\n";
                        continue;
                        
                    }

                    existeOpGerar = true;
                    


                    if (read["id_produto"] != DBNull.Value)
                    {

                        string descricao = read["pro_descricao"].ToString();
                        if (read["prk_descricao"]!=DBNull.Value)
                        {
                            descricao = read["prk_descricao"].ToString();
                        }
                        OrdemProducaoKeyClass key = new OrdemProducaoKeyClass(
                            read["oie_codigo_item"].ToString(),
                            descricao,
                            read["oie_dimensao"].ToString(),
                            read["id_produto_k"] as int?,
                            Convert.ToBoolean(Convert.ToInt16(read["pro_imprime_ops_relacionadas"])),
                            read["oie_numero_documento"].ToString(),
                            Convert.ToBoolean(Convert.ToInt16(read["oie_rastreamento_material"])),
                            read["oie_revisao_desenho"].ToString(),
                            Convert.ToInt32(read["oie_versao_estrutura_item"]),
                            read["oie_tipo_documento"].ToString()
                            );

                        if (!OPs.ContainsKey(key))
                        {

                            OrdemProducaoClass opTmp = this.Grupo.addOrdemProducao(
                                Convert.ToInt32(read["id_produto"]),
                                key.revisaoEstruturaItem,
                                key.codItem,
                                key.descItem,
                                key.tipoDocumento,
                                key.numeroDocumento,
                                key.revDocumento,
                                key.Dimensao,
                                key.rastrearMP,
                                key.imprimeOpsRelacionadas,
                                key.idProdutoK);
                            
                            if (read["id_produto_k"]!=DBNull.Value)
                            {
                                double percentualExtra = Convert.ToDouble(decimal.Parse(IWTConfiguration.Conf.getConf(Constants.PERCENTUAL_GERACAO_OP_KB_ACIMA_ESTOQUE_VERDE)))/100;
                                percentualExtra++;

                                opTmp.qtdExtra = Math.Round(Convert.ToDouble(read["prk_verde"])*percentualExtra, 5, MidpointRounding.ToEven);
                            }

                            //Cria uma nova OP
                            OPs.Add(key, opTmp);
                            idsToUpdate.Add(key, new IdsUpdate());
                        }
                        else
                        {

                        }

                        //Adiciona o Pedido


                        DateTime dataEntrega = Convert.ToDateTime(read["data"]);
                        string semanaTmp = IWTFunctions.IWTFunctions.getNumeroSemana(dataEntrega, this.tipoCalculoSemana, this.diaCalculoSemana).ToString();
                        semanaTmp = dataEntrega.ToString("yy") + semanaTmp.PadLeft(2,'0');

                        int semanaEntrega = Convert.ToInt32(semanaTmp);

                        OPs[key].addPedido(read["oie_order_number"].ToString(), Convert.ToInt32(read["oie_order_pos"]), key.codItem, key.descItem,
                                           read["oie_var_1_nome"].ToString(), read["oie_var_1_valor"].ToString(), read["oie_var_2_nome"].ToString(), read["oie_var_2_valor"].ToString(),
                                           read["oie_var_3_nome"].ToString(), read["oie_var_3_valor"].ToString(), read["oie_var_4_nome"].ToString(), read["oie_var_4_valor"].ToString(),
                                           Convert.ToDouble(read["oie_quantidade"]), key.tipoDocumento, key.numeroDocumento, key.revDocumento, read["oie_saf"].ToString(),
                                           read["oie_cnc"].ToString(), read["oie_tipo_ligacao"].ToString(), read["oie_codigo_item_pai"].ToString(),
                                           read["oie_desc_item_pai"].ToString(), read["oie_acab_item_pai"].ToString(),
                                           semanaEntrega,
                                           read["cliente_res"].ToString(), key.Dimensao, Convert.ToInt32(read["id_order_item_etiqueta"]));

                        idsToUpdate[key].idsOrderItemEtiqueta.Add(read["id_order_item_etiqueta"].ToString());
                        //idsToUpdate.Add(read["id_order_item_etiqueta"].ToString());
                    }
                    else
                    {
                        ocsSemProduto.Add(new OrdemProducaoOc(
                                              read["oie_order_number"].ToString(),
                                              read["oie_order_pos"].ToString(),
                                              read["oie_codigo_item"].ToString()));
                        continue;
                    }

                }

                read.Close();

                //Busca os itens que deixaram de ser produzidos em outras ops e devem ser produzidos
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao_pedido.id_ordem_producao_pedido, " +
                    "  public.ordem_producao_pedido.id_ordem_producao, " +
                    "  public.ordem_producao_pedido.opp_produto_codigo, " +
                    "  public.ordem_producao_pedido.opp_produto_descricao, " +
                    "  public.ordem_producao_pedido.opp_order_number, " +
                    "  public.ordem_producao_pedido.opp_order_pos, " +
                    "  public.ordem_producao_pedido.opp_variavel_1, " +
                    "  public.ordem_producao_pedido.opp_valor_variavel_1, " +
                    "  public.ordem_producao_pedido.opp_variavel_2, " +
                    "  public.ordem_producao_pedido.opp_valor_variavel_2, " +
                    "  public.ordem_producao_pedido.opp_variavel_3, " +
                    "  public.ordem_producao_pedido.opp_valor_variavel_3, " +
                    "  public.ordem_producao_pedido.opp_variavel_4, " +
                    "  public.ordem_producao_pedido.opp_valor_variavel_4, " +
                    "  public.ordem_producao_pedido.opp_quantidade, " +
                    "  public.ordem_producao_pedido.opp_tipo_documento, " +
                    "  public.ordem_producao_pedido.opp_numero_documento, " +
                    "  public.ordem_producao_pedido.opp_saf, " +
                    "  public.ordem_producao_pedido.opp_cnc, " +
                    "  public.ordem_producao_pedido.opp_tipo_ligacao, " +
                    "  public.ordem_producao_pedido.opp_produto_codigo_pai, " +
                    "  public.ordem_producao_pedido.opp_cliente, " +
                    "  public.ordem_producao_pedido.opp_semana_entrega, " +
                    "  public.ordem_producao_pedido.opp_revisao_documento, " +
                    "  public.ordem_producao_pedido.opp_dimensao, " +
                    "  public.ordem_producao_pedido.id_order_item_etiqueta, " +
                    "  public.ordem_producao_pedido.opp_produto_acabamento_pai, " +
                    "  public.ordem_producao_pedido.opp_produto_descricao_pai, " +
                    "  public.ordem_producao.orp_produto_descricao, " +
                    "  public.ordem_producao.orp_produto_codigo, " +
                    "  public.ordem_producao.orp_tipo_documento, " +
                    "  public.ordem_producao.orp_numero_documento, " +
                    "  public.ordem_producao.orp_revisao_documento, " +
                    "  public.ordem_producao.orp_dimensao, " +
                    "  public.ordem_producao.id_produto, " +
                    "  public.ordem_producao.id_produto_k, " +
                    "  public.ordem_producao_diferenca.opd_quantidade, " +
                    "  public.ordem_producao_diferenca.id_ordem_producao_diferenca, " +
                    "  public.ordem_producao.orp_versao_estrutura_produto, "+
                    "  public.ordem_producao.orp_rastreamento_material, " +                    
                    "  public.ordem_producao.orp_imprime_relacionadas "+                    
                    "FROM " +
                    "  public.ordem_producao_diferenca " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_diferenca.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                    "WHERE " +
                    "  public.ordem_producao_diferenca.opd_repor = 1 AND " +
                    "  public.ordem_producao_diferenca.opd_reposto = 0 ";

                read = command.ExecuteReader();
                List<string> idsOrdemProducaoDiferencaToUpdate = new List<string>();
                while (read.Read())
                {
                    OrdemProducaoKeyClass key = new OrdemProducaoKeyClass(
                        read["orp_produto_codigo"].ToString(),
                        read["orp_produto_descricao"].ToString(),
                        read["orp_dimensao"].ToString(),
                        read["id_produto_k"] as int?,
                        Convert.ToBoolean(Convert.ToInt16(read["orp_imprime_relacionadas"])),
                        read["orp_numero_documento"].ToString(),
                        Convert.ToBoolean(Convert.ToInt16(read["orp_rastreamento_material"])),
                        read["orp_revisao_documento"].ToString(),
                        Convert.ToInt32(read["orp_versao_estrutura_produto"]),
                        read["orp_tipo_documento"].ToString()
                        );

                    if (!OPs.ContainsKey(key))
                    {
                        //Cria uma nova OP
                        OrdemProducaoClass opTmp = this.Grupo.addOrdemProducao(
                            Convert.ToInt32(read["id_produto"]),
                            key.revisaoEstruturaItem,
                            key.codItem,
                            key.descItem,
                            key.tipoDocumento,
                            key.numeroDocumento,
                            key.revDocumento,
                            key.Dimensao,
                            key.rastrearMP,
                            key.imprimeOpsRelacionadas,
                            key.idProdutoK);
                        OPs.Add(key, opTmp);

                        idsToUpdate.Add(key, new IdsUpdate());
                    }

                    //Adiciona o Pedido


                    OPs[key].addPedido(read["opp_order_number"].ToString(), Convert.ToInt32(read["opp_order_pos"]), key.codItem, key.descItem,
                                       read["opp_variavel_1"].ToString(), read["opp_valor_variavel_1"].ToString(), read["opp_variavel_2"].ToString(), read["opp_valor_variavel_2"].ToString(),
                                       read["opp_variavel_3"].ToString(), read["opp_valor_variavel_3"].ToString(), read["opp_variavel_4"].ToString(), read["opp_valor_variavel_4"].ToString(),
                                       Convert.ToDouble(read["opd_quantidade"])*-1, key.tipoDocumento, key.numeroDocumento, key.revDocumento, read["opp_saf"].ToString(),
                                       read["opp_cnc"].ToString(), read["opp_tipo_ligacao"].ToString(),
                                       read["opp_produto_codigo_pai"].ToString(), read["opp_produto_descricao_pai"].ToString(),
                                       read["opp_produto_acabamento_pai"].ToString(),
                                       Convert.ToInt32(read["opp_semana_entrega"]),
                                       read["opp_cliente"].ToString(), key.Dimensao, Convert.ToInt32(read["id_order_item_etiqueta"]));

                    idsOrdemProducaoDiferencaToUpdate.Add(read["id_ordem_producao_diferenca"].ToString());
                    idsToUpdate[key].idsOrdemProducaoDiferencaToUpdate.Add(read["id_ordem_producao_diferenca"].ToString());
                }

                read.Close();




                if (this.UtilizarEstoqueOP)
                {
                    //Busca se algum dos itens existe em estoque, não está utilizado em alguma outra OP já gerada e insere os estoques na OP
                    Dictionary<EstoqueDisponivelClassKey, EstoqueDisponivelClass> estoquesCalculados = new Dictionary<EstoqueDisponivelClassKey, EstoqueDisponivelClass>();

                    string idsIgnorarSoma = "";
                    foreach (OrdemProducaoClass OP in OPs.Values)
                    {
                        foreach (OrdemProducaoPedidoClass pedido in OP.Pedidos)
                        {
                            idsIgnorarSoma += " AND public.order_item_etiqueta.id_order_item_etiqueta <> " + pedido.idOrderItemEtiqueta + " ";
                        }
                    }

                    if (idsIgnorarSoma.Length > 0)
                    {
                        idsIgnorarSoma = idsIgnorarSoma.Substring(4);
                    }



                    foreach (OrdemProducaoClass OP in OPs.Values)
                    {
                        EstoqueDisponivelClassKey tmpKey = new EstoqueDisponivelClassKey(OP.Produto,
                                                                                         OP.versaoEstruturaProduto,
                                                                                         OP.Dimensao,
                                                                                         OP.ProdutoK);

                        double qtdOP = OP.Quantidade;
                        if (!estoquesCalculados.ContainsKey(tmpKey))
                        {
                            estoquesCalculados.Add(tmpKey,
                                                   new EstoqueDisponivelClass(tmpKey.Produto, tmpKey.RevisaoProduto,
                                                                              tmpKey.Dimensao,
                                                                              idsIgnorarSoma,
                                                                              tmpKey.ProdutoK,
                                                                              ref command));
                        }

                        if (estoquesCalculados[tmpKey].EstoqueDisponivel >= qtdOP)
                        {
                            estoquesCalculados[tmpKey].QtdUtilizadaNesseProcesso += qtdOP;
                            OP.quantidadeEstoque = qtdOP;


                        }
                        else
                        {
                            OP.quantidadeEstoque = estoquesCalculados[tmpKey].EstoqueDisponivel;
                            estoquesCalculados[tmpKey].QtdUtilizadaNesseProcesso +=
                                estoquesCalculados[tmpKey].EstoqueDisponivel;

                        }
                    }
                }


                if (somenteVerificar)
                {
                    command.Transaction.Rollback();
                    return new List<OrdemProducaoClass>();
                }

                List<OrdemProducaoErroDocumentoClass> Erros = new List<OrdemProducaoErroDocumentoClass>();
                PlanoCorteClass planoCorte = new PlanoCorteClass(LoginClass.UsuarioLogado.loggedUser, this.conn);


                //Carrega a estrutura do produto para cada um das ocs montadas
                for (int i=0;i<OPs.Count;i++)
                    //foreach (KeyValuePair<OrdemProducaoKeyClass, OrdemProducaoClass> pair in OPs)
                    //OrdemProducaoClass OP in OPs.Values)
                {
                    //OrdemProducaoKeyClass Key= new List<OrdemProducaoKeyClass>(OPs.Keys)[i];
                    OrdemProducaoKeyClass Key =OPs.Keys.ElementAt(i);
                    OrdemProducaoClass Value = OPs[Key];


                    string error = "";


                    List<PedidoItemConfiguradoMaterialClass> itensIncluirPlanoCorte;
                    if (Value.preencherOP(ref command, out error, ref Erros, out itensIncluirPlanoCorte))
                    {
                        //Value.Save(ref command);

                        //Atualiza os status
                        command.CommandText = "UPDATE order_item_etiqueta SET oie_ordem_producao_impressa=1,oie_ordem_producao_impressa_data=NOW() WHERE id_order_item_etiqueta=:id_order_item_etiqueta ";
                        foreach (string id in idsToUpdate[Key].idsOrderItemEtiqueta)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt32(id);
                            command.ExecuteNonQuery();
                        }

                        command.CommandText = "UPDATE ordem_producao_diferenca SET opd_reposto=1 WHERE id_ordem_producao_diferenca = :id_ordem_producao_diferenca; ";
                        foreach (string idOrdemProducaoDiferenca in idsToUpdate[Key].idsOrdemProducaoDiferencaToUpdate)
                        {
                            command.Parameters.Clear();
                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_diferenca", NpgsqlDbType.Integer));
                            command.Parameters[command.Parameters.Count - 1].Value = idOrdemProducaoDiferenca;
                            command.ExecuteNonQuery();
                        }

                        foreach (PedidoItemConfiguradoMaterialClass pedidoMaterial in itensIncluirPlanoCorte)
                        {
                            Value.ItensPlanoCorte.Add(planoCorte.AdicionarItemOP(pedidoMaterial, Value));
                        }
                    }
                    else
                    {
                        erroGeral += error + "\r\n";
                        OPs.Remove(Key);
                        this.Grupo.OPs.Remove(Value);
                        i--;
                        
                    }
                }

                if (erroGeral.Length > 0)
                {

                    DialogResult res = DialogResult.No;

                    if (erroGeral.Length > 1000)
                    {
                        ScrollableMessageBox message = new ScrollableMessageBox(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral + "\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        res = message.ShowDialog();
                    }
                    else
                    {
                        res = MessageBox.Show(null, "Algumas ops não foram geradas pelos seguintes motivos.\r\n" + erroGeral+"\r\nVocê deseja continuar com a geração das ops das ordens que não apresentaram erros?", "Erro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    }

                    if (res == DialogResult.No)
                    {
                        command.Transaction.Rollback();
                        return new List<OrdemProducaoClass>();


                    }

                }

                if (Erros.Count > 0)
                {
                    OpErrosReportFormForm form = new OpErrosReportFormForm(Erros);
                    form.ShowDialog();
                }

                if (this.Grupo.OPs.Count != 0)
                {
                    this.Grupo.Save(ref command);

                    this.Grupo.ordernaOPs();
                }


                this.gerarPlanoCorteSemOps(idsOrderItemEtiquetaPlanoCorteAvulsos, ref planoCorte, ref command);

             

                if (!somenteVerificar)
                {

                    command.Transaction.Commit();
                }
                else
                {
                    command.Transaction.Rollback();
                }


                foreach (OrdemProducaoClass op in OPs.Values)
                {
                    op.AtualizarItensPlanoCorte();
                }

                if (planoCorte.CollectionPlanoCorteItemClassPlanoCorte.Count > 0)
                {
                    planoCorte.Save();
                    PlanoCorteReportForm form = new PlanoCorteReportForm(planoCorte);
                    form.ShowDialog(null);
                }

                if (this.Grupo.OPs.Count > 0)
                {
                    existeOpGerar = true;
                }
                else
                {
                    existeOpGerar = false;
                }
              
                //return new List<OrdemProducaoClass>(OPs.Values);
                return this.Grupo.OPs;
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction!=null)
                {
                    command.Transaction.Rollback();

                }
                throw new Exception("Erro ao emitir as Ordens de Produção.\r\n" + e.Message);
            }
        }

        public List<OrdemProducaoClass> gerarOps(List<OrdemProducaoOc> ocs, List<int> idsOrderItemEtiquetaPlanoCorteAvulsos, out List<OrdemProducaoOc> ocsSemProduto, out string erroGeral)
        {
            bool existe;
            return this.gerarOps(ocs,idsOrderItemEtiquetaPlanoCorteAvulsos, out ocsSemProduto, out erroGeral, false, out existe);
        }

        public bool existeOpsGerar(List<OrdemProducaoOc> ocs, List<int> idsOrderItemEtiquetaPlanoCorteAvulsos)
        {
            string erroTmp;
            List<OrdemProducaoOc> ocsSemProdutoTmp;
            bool existeOpGerar;

            this.gerarOps(ocs, idsOrderItemEtiquetaPlanoCorteAvulsos, out ocsSemProdutoTmp, out erroTmp, true, out existeOpGerar);

            return existeOpGerar || idsOrderItemEtiquetaPlanoCorteAvulsos.Count > 0;
        }

        private void gerarPlanoCorteSemOps(List<int> idsOrderItemEtiquetaPlanoCorteAvulsos, ref PlanoCorteClass planoCorte, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (idsOrderItemEtiquetaPlanoCorteAvulsos == null) return;
                
                foreach (int idOrderItemEtiqueta in idsOrderItemEtiquetaPlanoCorteAvulsos)
                {
                    OrderItemEtiquetaClass itemEtiqueta = OrderItemEtiquetaBaseClass.GetEntidade(idOrderItemEtiqueta, this.Usuario, this.conn);
                    if (!itemEtiqueta.Produto.EmiteOp)
                    {
                        foreach (PedidoItemConfiguradoMaterialClass pedidoMaterial in itemEtiqueta.CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Where(a => !a.PlanoCorteGerado))
                        {
                            planoCorte.AdicionarItemSemOP(pedidoMaterial, itemEtiqueta);
                            pedidoMaterial.PlanoCorteGerado = true;
                            pedidoMaterial.Save(ref command);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar os planos de cortes avulsos\r\n" + e.Message, e);
            }
        }

    }
}