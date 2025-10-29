#region Referencias

using System;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using Configurations;
using IWTDotNetLib;
using IWTPostgreNpgsql;
using Npgsql;
using dbProvider;

#endregion

namespace ModuloAcompanhamentoPedidos
{
    public partial class ReceitaForm : IWTBaseForm
    {
        private readonly IWTPostgreNpgsqlConnection connection;
        public ReceitaForm(IWTPostgreNpgsqlConnection connection)
        {
            InitializeComponent();
            this.connection = connection;

            this.dtpDeDataNF.Value = Configurations.DataIndependenteClass.GetData().AddDays((Configurations.DataIndependenteClass.GetData().Day - 1) * -1).Date;
            this.dtpAteDataNF.Value = Configurations.DataIndependenteClass.GetData().Date;

            this.initializeGrid();
        }

        private void initializeGrid()
        {
            string searchClause = "";
            //Montagem Where
            if (this.txtBusca.Text.Trim().Length > 0)
            {
                searchClause += " AND ( "+
                    " UPPER(pedido ||'\'||pos) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' "+
                    " OR UPPER(produto_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(produto_classificacao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(produto_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToUpper() + "%' " +
                    " OR UPPER(cli_nome) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(pedido ||'\'||pos) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(produto_codigo) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(produto_classificacao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(produto_descricao) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR LOWER(cli_nome) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " OR CAST(nf_numero AS TEXT) LIKE '%" + this.txtBusca.Text.Trim().ToLower() + "%' " +
                    " ) ";
            }

            
            //Inicio Data NF
            if (this.chkDeDataNF.Checked)
            {
                searchClause += " AND dt_emissao >= '" + this.dtpDeDataNF.Value.Date.ToString("yyyy-MM-dd") + "'";
            }

            if (this.chkAteDataNF.Checked)
            {
                searchClause += " AND dt_emissao < '" + this.dtpAteDataNF.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "'";
            }
            //Fim data

            //Inicio Data Entrega
            if (this.chkDeDataEntrega.Checked)
            {
                searchClause += " AND dataEntrega >= '" + this.dtpDeDataEntrega.Value.Date.ToString("yyyy-MM-dd") + "'";
            }

            if (this.chkAteDataEntrega.Checked)
            {
                searchClause += " AND dataEntrega < '" + this.dtpAteDataEntrega.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "'";
            }
            //Fim data


            //Inicio Data Entrada
            if (this.chkDeDataEntrada.Checked)
            {
                searchClause += " AND pei_data_entrada >= '" + this.dtpDeDataEntrada.Value.Date.ToString("yyyy-MM-dd") + "'";
            }

            if (this.chkAteDataEntrada.Checked)
            {
                searchClause += " AND pei_data_entrada < '" + this.dtpAteDataEntrada.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "'";
            }
            //Fim data

            string sqlFaturados =
                ////"-- Antigos e Novos Faturados   
                //   "SELECT                                                                                                                                                                     " +
                //   "  public.order_item_etiqueta.oie_order_number as pedido,                                                                                                                             " +
                //   "  public.order_item_etiqueta.oie_order_pos as pos,                                                                                                                                " +
                //   "  CASE WHEN cliente.id_cliente IS NULL THEN public.order_item_etiqueta.id_externo_cliente_access ELSE public.cliente.cli_nome_resumido END as cli_nome,                            " +
                //   "  public.nf_principal.nfp_numero as nf_numero,                                                                                                                                          " +
                //   "  public.nf_item.nfi_numero_item as nf_item,  "+
                //   "  public.nf_principal.nfp_data_emissao as dt_emissao,                                                                                                                                    " +
                //   "  CAST (public.nf_principal.nfp_data_emissao + interval '28 days' AS DATE) as data_fatura,                                                                                 " +
                //   "  CASE WHEN pei_data_entrega IS NOT NULL THEN pei_data_entrega WHEN oie_data_entrega IS NOT NULL THEN oie_data_entrega ELSE CAST (public.nf_principal.nfp_data_emissao AS DATE) END as dataEntrega, " +
                //   "  public.nf_item_tributo_ipi.nti_valor_ipi + public.nf_item_tributo_icms.ntc_valor_icms_st +  public.nf_produto.nfp_valor_total_tributavel AS valor_total,                 " +
                //   "  public.nf_produto.nfp_valor_total_tributavel AS valor_produto,                                                                                                            " +
                //   "  CASE WHEN public.pedido_item.pei_preco_total_original IS NOT NULL THEN public.pedido_item.pei_preco_total_original ELSE public.nf_produto.nfp_valor_total_tributavel END as precoOriginal " +
                //   "FROM                                                                                                                                                                       " +
                //   "  public.atendimento                                                                                                                                                       " +
                //   "  INNER JOIN public.order_item_etiqueta ON (public.atendimento.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta)                                 " +
                //   "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal)                                                             " +
                //   "  INNER JOIN public.nf_item ON (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal)                                                                      " +
                //   "  AND (public.atendimento.ate_linha_nf = public.nf_item.nfi_numero_item)                                                                                                   " +
                //   "  INNER JOIN public.nf_produto ON (public.nf_item.id_nf_item = public.nf_produto.id_nf_item)                                                                               " +
                //   "  LEFT OUTER JOIN public.nf_item_tributo_ipi ON (public.nf_item.id_nf_item = public.nf_item_tributo_ipi.id_nf_item)                                                        " +
                //   "  LEFT OUTER JOIN public.nf_item_tributo_icms ON (public.nf_item.id_nf_item = public.nf_item_tributo_icms.id_nf_item)                                                      " +
                //   "  LEFT OUTER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente)                                                                   " +
                //   "  LEFT OUTER JOIN public.pedido_item ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) "+
                //   "WHERE                                                                                                                                                                      " +
                //   "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND                                                                                                                       " +
                //   "  public.order_item_etiqueta.oie_status_pedido <> 'C'                                                                                                                      ";

                 //"  public.order_item_etiqueta.oie_order_number as pedido,                                                                                                                             " +
                 //   "  public.order_item_etiqueta.oie_order_pos as pos,                                                                                                                                " +
                 //   "  public.order_item_etiqueta.id_externo_cliente_access as cli_nome,                                                                                                                            " +
                 //   "  CAST (NULL AS INTEGER) as nf_numero,                                                                                                                                                                    " +
                 //   "  CAST (NULL AS INTEGER) as nf_item, " +
                 //   "  CAST (NULL AS DATE) as dt_emissao,                                                                                                                                                                    " +
                 //   "  CAST (NULL AS DATE) as data_fatura,                                                                                                                                                                     " +
                 //   "  public.order_item_etiqueta.oie_data_entrega as dataEntrega, " +
                 //   "  public.order_item_etiqueta.oie_saldo * public.order_item_etiqueta.oie_preco_unitario AS valor_total,                                                                                    " +
                 //   "  public.order_item_etiqueta.oie_saldo * public.order_item_etiqueta.oie_preco_unitario AS valor_produto,                                                                                      " +
                 //   "  public.order_item_etiqueta.oie_quantidade * public.order_item_etiqueta.oie_preco_unitario AS precoOriginal     

                    "SELECT  "+                                                                                                                                            
                    "   pedido,  "+
                    "   posicao as pos,  "+
                    "   cliente as cli_nome,  "+
                    "   nfp_numero as nf_numero,  "+
                    "   nfi_numero_item as nf_item,  " +
                    "   nfp_data_emissao as dt_emissao, " +
                    "   faturas, "+
                    "   data_fatura, "+
                    "   CASE WHEN data_entrega IS NULL THEN CAST( nfp_data_emissao AS DATE) ELSE data_entrega END AS dataEntrega, " +
                    "   COALESCE(nti_valor_ipi,0) + COALESCE(ntc_valor_icms_st,0) +  nfp_valor_total_tributavel as valor_total, " +
                    "   nfp_valor_total_tributavel as valor_produto, " +
                    "   CASE " +
                    "     WHEN valor_original IS NOT NULL THEN " +
                    "       valor_original " +
                    "     ELSE " +
                    "       quantidade * valor_unit " +
                    "   END AS  precoOriginal, " +
                    "   lof_identificacao,                                                                                                                                       " +
                    "   pei_data_entrada, "+
                    "   produto_codigo, "+
                    "   produto_descricao, "+
                    "   produto_classificacao, "+
                    "   pei_quantidade, " +
                    "   qtd_faturada " +
                    " FROM (                                                                                                                                   " +
                    "                                                                                                                                          " +
                    "SELECT                     																																																																												"+
"    tab.pedido ,                                                                                                                                                                   "+
"    tab.posicao,                                                                                                                                                                   "+
"    tab.cliente,                                                                                                                                                                   "+
"    tab.nfp_numero,                                                                                                                                                                "+
"    tab.nfi_numero_item,                                                                                                                                                           "+
"    tab.nfp_data_emissao,                                                                                                                                                          "+
"    tab.data_entrega,                                                                                                                                                              "+
"    tab.saldo,                                                                                                                                                                     "+
"    tab.valor_unit,                                                                                                                                                                "+
"    tab.nfp_valor_total_tributavel,                                                                                                                                                "+
"    tab.valor_original,                                                                                                                                                            "+
"    tab.nti_valor_ipi,                                                                                                                                                             "+
"    tab.ntc_valor_icms_st,                                                                                                                                                         "+
"    tab.id_nf_principal,                                                                                                                                                           "+
"    tab.quantidade,                                                                                                                                                                "+
"    tab.lof_identificacao,                                                                                                                                                         "+
"    tab.pei_data_entrada,                                                                                                                                                          "+
"    tab.produto_codigo,                                                                                                                                                            "+
"    tab.produto_descricao,                                                                                                                                                         "+
"    tab.produto_classificacao,                                                                                                                                                     "+
"	iwt_agregate_pedidos_op(to_char(nf_duplicata.nfd_vencimento,'DD/MM/YYYY')) as faturas,                                                                                            "+
"    CAST(MIN(nf_duplicata.nfd_vencimento) AS DATE) as data_fatura  ,                                                                                                               "+
"    tab.pei_quantidade,                                                                                                                                                            "+
"    tab.qtd_faturada                                                                                                                                                               "+
"FROM (                                                                                                                                                                             "+
"                                                                                                                                                                                   "+
"SELECT                                                                                                                                                                             "+
"                      public.pedido_item.pei_numero as pedido,                                                                                                                     "+
"                      public.pedido_item.pei_posicao as posicao,                                                                                                                   "+
"                      public.cliente.cli_nome_resumido as cliente,                                                                                                                 "+
"                      public.nf_principal.nfp_numero,                                                                                                                              "+
"                      public.nf_item.nfi_numero_item,                                                                                                                              "+
"                      public.nf_principal.nfp_data_emissao,                                                                                                                        "+
"                      public.pedido_item.pei_data_entrega as data_entrega,                                                                                                         "+
"                      public.pedido_item.pei_saldo as saldo,                                                                                                                       "+
"                      public.pedido_item.pei_preco_unitario as valor_unit,                                                                                                         "+
"                      public.nf_produto.nfp_valor_total_tributavel,                                                                                                                "+
"                      public.pedido_item.pei_preco_total_original as valor_original,                                                                                               "+
"                      public.nf_item_tributo_ipi.nti_valor_ipi,                                                                                                                    "+
"                      public.nf_item_tributo_icms.ntc_valor_icms_st,                                                                                                               "+
"                      public.nf_principal.id_nf_principal,                                                                                                                         "+
"                      public.pedido_item.pei_quantidade as quantidade,                                                                                                             "+
"                      public.local_fabricacao.lof_identificacao,                                                                                                                   "+
"                      pei_data_entrada,                                                                                                                                            "+
"                      produto.pro_codigo as produto_codigo,                                                                                                                        "+
"                      produto.pro_descricao as produto_descricao,                                                                                                                  "+
"                      classificacao_produto.clp_identificacao as produto_classificacao,                                                                                            "+
"                     SUM(ate_quantidade) as pei_quantidade ,                                                                                                                                             " +
"                     SUM(ate_quantidade) as qtd_faturada                                                                                                                          "+
"                    FROM                                                                                                                                                           "+
"                      public.pedido_item                                                                                                                                           "+
"                      LEFT JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item)                                      "+
"                      INNER JOIN public.atendimento ON (public.pedido_item.id_pedido_item = public.atendimento.id_pedido_item)                                                     "+
"                      INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal)                                                 "+
"                      INNER JOIN public.nf_item ON (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal)                                                          "+
"                      AND (public.atendimento.ate_linha_nf = public.nf_item.nfi_numero_item)                                                                                       "+
"                      INNER JOIN public.nf_produto ON (public.nf_item.id_nf_item = public.nf_produto.id_nf_item)                                                                   "+
"                      LEFT OUTER JOIN public.nf_item_tributo_ipi ON (public.nf_item.id_nf_item = public.nf_item_tributo_ipi.id_nf_item)                                            "+
"                      LEFT OUTER JOIN public.nf_item_tributo_icms ON (public.nf_item.id_nf_item = public.nf_item_tributo_icms.id_nf_item)                                          "+
"                      INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)                                                                     "+
"                      LEFT JOIN public.produto ON (pedido_item.id_produto = produto.id_produto)                                                                                    "+
"                      LEFT JOIN public.local_fabricacao ON (produto.id_local_fabricacao = local_fabricacao.id_local_fabricacao)                                                    "+
"                      LEFT JOIN public.classificacao_produto ON (classificacao_produto.id_classificacao_produto = produto.id_classificacao_produto )                               "+
"                    WHERE                                                                                                                                                          "+
"                      public.pedido_item.pei_sub_linha = 0 AND                                                                                                                     "+
"                      nf_principal.nfp_situacao <> 'C' AND                                                                                                                         "+
"                     ((pei_configurado = 1 AND order_item_etiqueta.id_pedido_item IS NOT NULL) OR (pei_configurado = 0 AND order_item_etiqueta.id_pedido_item IS NULL))            "+
"                     GROUP BY                                                                                                                                                      "+
"                      public.pedido_item.pei_numero ,                                                                                                                              "+
"                      public.pedido_item.pei_posicao  ,                                                                                                                            "+
"                      public.cliente.cli_nome_resumido ,                                                                                                                           "+
"                      public.nf_principal.nfp_numero,                                                                                                                              "+
"                      public.nf_item.nfi_numero_item,                                                                                                                              "+
"                      public.nf_principal.nfp_data_emissao,                                                                                                                        "+
"                      public.pedido_item.pei_data_entrega,                                                                                                                         "+
"                      public.pedido_item.pei_saldo ,                                                                                                                               "+
"                      public.pedido_item.pei_preco_unitario ,                                                                                                                      "+
"                      public.nf_produto.nfp_valor_total_tributavel,                                                                                                                "+
"                      public.pedido_item.pei_preco_total_original ,                                                                                                                "+
"                      public.nf_item_tributo_ipi.nti_valor_ipi,                                                                                                                    "+
"                      public.nf_item_tributo_icms.ntc_valor_icms_st,                                                                                                               "+
"                      public.nf_principal.id_nf_principal,                                                                                                                         "+
"                      public.pedido_item.pei_quantidade,                                                                                                                           "+
"                      public.local_fabricacao.lof_identificacao,                                                                                                                   "+
"                      pei_data_entrada,                                                                                                                                            "+
"                      produto.pro_codigo ,                                                                                                                                         "+
"                      produto.pro_descricao,                                                                                                                                       "+
"                      classificacao_produto.clp_identificacao                                                                                                                    "+                
"                                                                                                                                                                     "+
") AS tab                                                                                                                                                                           "+
"LEFT JOIN public.nf_duplicata ON tab.id_nf_principal = public.nf_duplicata.id_nf_principal                                                                                         "+
"GROUP BY                                                                                                                                                                           "+
"tab.pedido ,                                                                                                                                                                       "+
"tab.posicao,                                                                                                                                                                       "+
"tab.cliente,                                                                                                                                                                       "+
"tab.nfp_numero,                                                                                                                                                                    "+
"tab.nfi_numero_item,                                                                                                                                                               "+
"tab.nfp_data_emissao,                                                                                                                                                              "+
"tab.data_entrega,                                                                                                                                                                  "+
"tab.saldo,                                                                                                                                                                         "+
"tab.valor_unit,                                                                                                                                                                    "+
"tab.nfp_valor_total_tributavel,                                                                                                                                                    "+
"tab.valor_original,                                                                                                                                                                "+
"tab.nti_valor_ipi,                                                                                                                                                                 "+
"tab.ntc_valor_icms_st,                                                                                                                                                             "+
"tab.id_nf_principal,                                                                                                                                                               "+
"tab.quantidade,                                                                                                                                                                    "+
"tab.lof_identificacao,                                                                                                                                                             "+
"tab.pei_data_entrada,                                                                                                                                                              "+
"tab.produto_codigo,                                                                                                                                                                "+
"tab.produto_descricao,                                                                                                                                                             "+
"tab.produto_classificacao,                                                                                                                                                         "+
"tab.pei_quantidade,                                                                                                                                                                "+
"tab.qtd_faturada                                                                                                                                                                   " +

                    "UNION ALL                                                                                                                                     " +
                    "                                                                                                                                          " +
                    "SELECT                                                                                                                                    " +
                    "  public.order_item_etiqueta.oie_order_number as pedido,                                                                                  " +
                    "  public.order_item_etiqueta.oie_order_pos as posicao,                                                                                    " +
                    "  public.order_item_etiqueta.id_externo_cliente_access as cliente,                                                                                " +
                    "  public.nf_principal.nfp_numero,                                                                                                         " +
                    "  public.nf_item.nfi_numero_item,                                                                                                         " +
                    "  public.nf_principal.nfp_data_emissao,                                                                                                   " +
                    "  public.order_item_etiqueta.oie_data_entrega as data_entrega,                                                                            " +
                    "  public.order_item_etiqueta.oie_saldo as saldo,                                                                                          " +
                    "  public.order_item_etiqueta.oie_preco_unitario as valor_unit,                                                                            " +
                    "  public.nf_produto.nfp_valor_total_tributavel,                                                                                           " +
                    "  public.order_item_etiqueta.oie_preco_unitario * public.order_item_etiqueta.oie_quantidade as valor_original,                            " +
                    "  public.nf_item_tributo_ipi.nti_valor_ipi,                                                                                               " +
                    "  public.nf_item_tributo_icms.ntc_valor_icms_st,                                                                                          " +
                    "  public.nf_principal.id_nf_principal,                                                                                                    " +
                    "  public.order_item_etiqueta.oie_quantidade as quantidade,                                                                                 " +
                    //"  public.local_fabricacao.lof_identificacao, " +
                    "  '' as lof_identificacao, "+
                    "  order_date as pei_data_entrada, "+
                    "  order_item_etiqueta.oie_codigo_item as produto_codigo, " +
                    "  order_item_etiqueta.oie_descricao as produto_descricao, " +
                    "  order_item_etiqueta.oie_kit_fantasia as produto_classificacao, " +
                    "  to_char(CAST (nfp_data_emissao + interval '28 days' AS DATE),'DD/MM/YYYY') as faturas, " +
                    "  CAST (nfp_data_emissao + interval '28 days' AS DATE) as data_fatura, "+
                    "  0 as pei_quantidade , " +
                    "  0 as qtd_faturada  " +
                    "FROM                                                                                                                                      " +
                    "  public.order_item_etiqueta                                                                                                              " +
                    "  INNER JOIN public.atendimento ON (public.atendimento.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta)        " +
                    "  INNER JOIN public.nf_principal ON (public.nf_principal.id_nf_principal = public.atendimento.id_nf_principal)                            " +
                    "  INNER JOIN public.nf_item ON   (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal)                                   " +
                    "  AND (public.atendimento.ate_linha_nf = public.nf_item.nfi_numero_item)                                                                  " +
                    "  INNER JOIN public.nf_produto ON (public.nf_item.id_nf_item = public.nf_produto.id_nf_item)                                              " +
                    "  LEFT OUTER JOIN public.nf_item_tributo_ipi ON (public.nf_item.id_nf_item = public.nf_item_tributo_ipi.id_nf_item)                       " +
                    "  LEFT OUTER JOIN public.nf_item_tributo_icms ON (public.nf_item.id_nf_item = public.nf_item_tributo_icms.id_nf_item)                     " +
                    "  LEFT JOIN order_item ON order_number = oie_order_number AND order_pos = oie_order_pos "+
                    //"  LEFT JOIN produto ON produto.pro_codigo LIKE order_item_etiqueta.oie_codigo_cliente "+
                    //"  LEFT JOIN public.local_fabricacao ON (produto.id_local_fabricacao = local_fabricacao.id_local_fabricacao) " +
                    "WHERE                                                                                                                                     " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND                                                                                      " +
                    "  public.order_item_etiqueta.id_pedido_item IS NULL AND                                                                                   " +
                    "  nf_principal.nfp_situacao <> 'C'                                                                                                        " +
                    "                                                                                                                                          " +
                    "                                                                                                                                          " +
                    "  ) as tab                                                                                                                                ";


            string sqlPendentes =
                //"-- Antigos com saldo Pendentes                                                                                                                                             " +
                    "SELECT                                                                                                                                                                     " +
                    "  public.order_item_etiqueta.oie_order_number as pedido,                                                                                                                             " +
                    "  public.order_item_etiqueta.oie_order_pos as pos,                                                                                                                                " +
                    "  public.order_item_etiqueta.id_externo_cliente_access as cli_nome,                                                                                                                            " +
                    "  CAST (NULL AS INTEGER) as nf_numero,                                                                                                                                                                    " +
                    "  CAST (NULL AS INTEGER) as nf_item, " +
                    "  CAST (NULL AS DATE) as dt_emissao,                                                                                                                                                                    " +
                    "  CAST (NULL AS VARCHAR) as faturas,                                                                                                                                                                     " +
                    "  CAST (NULL AS DATE) as data_fatura,                                                                                                                                                                     " +
                    "  public.order_item_etiqueta.oie_data_entrega as dataEntrega, " +
                    "  public.order_item_etiqueta.oie_saldo * public.order_item_etiqueta.oie_preco_unitario AS valor_total,                                                                                    " +
                    "  public.order_item_etiqueta.oie_saldo * public.order_item_etiqueta.oie_preco_unitario AS valor_produto,                                                                                      " +
                    "  public.order_item_etiqueta.oie_quantidade * public.order_item_etiqueta.oie_preco_unitario AS precoOriginal,                                                                                      " +
                    //"  public.local_fabricacao.lof_identificacao, " +
                    "  '' as lof_identificacao, " +
                    "  order_date as pei_data_entrada, " +
                    "  order_item_etiqueta.oie_codigo_item as produto_codigo, " +
                    "  order_item_etiqueta.oie_descricao as produto_descricao, " +
                    "  order_item_etiqueta.oie_kit_fantasia as produto_classificacao, " +
                    " 0 as pei_quantidade , 0 as qtd_faturada  " +
                    "FROM                                                                                                                                                                       " +
                    "  public.order_item_etiqueta                                                                                                                                               " +
                    "  LEFT JOIN order_item ON order_number = oie_order_number AND order_pos = oie_order_pos " +
                    //"  LEFT JOIN produto ON produto.pro_codigo LIKE order_item_etiqueta.oie_codigo_cliente " +
                    //"  LEFT JOIN public.local_fabricacao ON (produto.id_local_fabricacao = local_fabricacao.id_local_fabricacao) " +
                    "WHERE                                                                                                                                                                      " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 1 AND                                                                                                                       " +
                    "  public.order_item_etiqueta.oie_status_pedido <> 'E' AND                                                                                                                  " +
                    "  public.order_item_etiqueta.oie_status_pedido <> 'C' AND                                                                                                                   " +
                    "  public.order_item_etiqueta.oie_saldo > 0 AND                                                                                                                                " +
                    "  public.order_item_etiqueta.id_pedido_item IS NULL AND " +
                    "  public.order_item_etiqueta.id_produto IS NULL " +
                    "UNION ALL                                                                                                                                                                      " +
                //"-- Novos Pendentes
                    "SELECT                                                                                                                                                                     " +
                    "  public.pedido_item.pei_numero as pedido,                                                                                                                                           " +
                    "  public.pedido_item.pei_posicao as pos,                                                                                                                                          " +
                    "  public.cliente.cli_nome_resumido as cli_nome,                                                                                                                                        " +
                    "  CAST (NULL AS INTEGER) as nf_numero,                                                                                                                                                                    " +
                    "  CAST (NULL AS INTEGER) as nf_item, " +
                    "  CAST (NULL AS DATE) as dt_emissao,                                                                                                                                                                    " +
                    "  CAST (NULL AS VARCHAR) as faturas,                                                                                                                                                                     " +
                    "  CAST (NULL AS DATE) as data_fatura,                                                                                                                                                                     " +
                    "  public.pedido_item.pei_data_entrega as dataEntrega, " +
                    "  public.pedido_item.pei_saldo * public.pedido_item.pei_preco_unitario AS valor_total,                                                                                                    " +
                    "  public.pedido_item.pei_saldo * public.pedido_item.pei_preco_unitario AS valor_produto,                                                                                                     " +
                    "  (public.pedido_item.pei_preco_total_original) as precoOriginal, " +
                    "  public.local_fabricacao.lof_identificacao, " +
                    "  pei_data_entrada, "+
                    "  produto.pro_codigo as produto_codigo, " +
                    "  produto.pro_descricao as produto_descricao, " +
                    "  classificacao_produto.clp_identificacao as produto_classificacao, " +
                    "  pei_saldo as pei_quantidade , " +
                    "  0 as qtd_faturada " +
                    "FROM " +
                    "  public.pedido_item " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  LEFT JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                    "  LEFT JOIN public.produto ON (pedido_item.id_produto = produto.id_produto) " +
                    "  LEFT JOIN public.local_fabricacao ON (produto.id_local_fabricacao = local_fabricacao.id_local_fabricacao) " +
                    "  LEFT JOIN public.classificacao_produto ON (classificacao_produto.id_classificacao_produto = produto.id_classificacao_produto ) " +
                    "WHERE " +
                    "  ((public.pedido_item.pei_configurado = 1 AND id_order_item_etiqueta IS NOT NULL) OR (public.pedido_item.pei_configurado = 0 AND id_order_item_etiqueta IS NULL)) AND                                                                                                                                                                    " +
                    "  public.pedido_item.pei_sub_linha = 0 AND                                                                                                                                 " +
                    "  public.pedido_item.pei_saldo > 0 AND                                                                                                                                     " +
                    "  (public.pedido_item.pei_status = 0 OR                                                                                                                                    " +
                    "  public.pedido_item.pei_status = 3)                                                                                                                                       ";


            IWTPostgreNpgsqlAdapter adapter;
            DataSet dataSet;
            try
            {
               
                    /*
                    "SELECT  " +
                    "  public.order_item_etiqueta.oie_order_number, " +
                    "  public.order_item_etiqueta.oie_order_pos, " +
                    "  public.nf_principal.nfp_numero, " +
                    "  public.nf_principal.nfp_data_emissao, " +
                    "  public.nf_produto.nfp_valor_total_tributavel + " +
                    "  public.nf_item_tributo_ipi.nti_valor_ipi + " +
                    "  public.nf_item_tributo_icms.ntc_valor_icms_st as valor_item, " +
                    "  public.nf_produto.nfp_valor_total_tributavel " +
                    "FROM " +
                    "  public.atendimento " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.atendimento.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal) " +
                    "  INNER JOIN public.nf_item ON (public.nf_principal.id_nf_principal = public.nf_item.id_nf_principal) " +
                    "  AND (public.atendimento.ate_linha_nf = public.nf_item.nfi_numero_item) " +
                    "  INNER JOIN public.nf_produto ON (public.nf_item.id_nf_item = public.nf_produto.id_nf_item) " +
                    "  LEFT OUTER JOIN public.nf_item_tributo_ipi ON (public.nf_item.id_nf_item = public.nf_item_tributo_ipi.id_nf_item) " +
                    "  LEFT OUTER JOIN public.nf_item_tributo_icms ON (public.nf_item.id_nf_item = public.nf_item_tributo_icms.id_nf_item) " +
                    "WHERE " +
                    "  public.order_item_etiqueta.oie_nota_fiscal = 1  AND   " +
                    "  public.order_item_etiqueta.oie_status_pedido <> 'C'   " +
                    searchClause +
                    "ORDER BY                                                " +
                    "  public.nf_principal.nfp_data_emissao,          " +
                    "  public.order_item_etiqueta.oie_order_number,          " +
                    "  public.order_item_etiqueta.oie_order_pos              ";
                    */

                string sql = "SELECT pedido||'/'|| pos, cli_nome,produto_classificacao, produto_codigo, produto_descricao, nf_numero,nf_item,dt_emissao,faturas, dataEntrega,pei_data_entrada,ROUND(valor_total,2) as valor_total, ROUND(valor_produto,2) as valor_produto ,ROUND(precoOriginal,2) as precoOriginal,lof_identificacao, CASE WHEN nf_numero IS NULL THEN  CAST(EXTRACT( DAYS FROM (CURRENT_DATE - pei_data_entrada)) as INTEGER) ELSE CAST(EXTRACT( DAYS FROM (data_fatura - pei_data_entrada)) as INTEGER )END as LT ,pei_quantidade, qtd_faturada FROM ( ";
                    
                if (rdbTodos.Checked)
                {
                    sql += sqlFaturados + " UNION ALL " + sqlPendentes;

                }

                if (rdbPendentes.Checked)
                {
                    sql += sqlPendentes;
                }

                if (rdbEncerrados.Checked)
                {
                    sql += sqlFaturados;
                }

                if (rdbAtrasados.Checked)
                {
                    sql += sqlPendentes;
                    searchClause += " AND dataEntrega < CURRENT_DATE ";
                }

                sql += " ) as res ";
                
                if (searchClause.Length > 0)
                {
                    sql += " WHERE " + searchClause.Substring(4) + " ";

                }

                sql +=
                    "ORDER BY     " +
                    "  dt_emissao," +
                    "  nf_numero, " +
                    "  nf_item,   " +
                    "  pedido,    " +
                    "  pos        ";


                adapter = new IWTPostgreNpgsqlAdapter(sql, connection);
                if (adapter != null)
                {
                    dataSet = new DataSet();
                    adapter.Fill(dataSet);

                    BindingSource binding = new BindingSource();
                    binding.DataSource = dataSet.Tables[0];

                    dataGridView1.AutoGenerateColumns = true;
                    dataGridView1.DataSource = binding;

                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[0], "Pedido", 90, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[1], "Cliente", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[2], "Classificação", 120, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[3], "Produto", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[4], "Descrição", 80, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[5], "Nº NFe", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[6], "Item NFe", 35, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[7], "Data NFe", 100, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[8], "Faturas", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[9], "Previão Entrega", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[10], "Data de Entrada", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[11], "Valor Total", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[12], "Valor Produtos", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[13], "Valor Original Pedido", 75, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[14], "Planta", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[15], "LT", 50, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[16], "Qtd Pedido (na linha do relatório)", 70, DataGridViewAutoSizeColumnMode.None, true);
                    IWTFunctions.IWTFunctions.setGridColumn(this.dataGridView1.Columns[17], "Qtd Faturada", 50, DataGridViewAutoSizeColumnMode.None, true);



                }


                string sql2 =
                    "SELECT " +
                    "SUM(valor_total) as valor , " +
                    "SUM(valor_produto) as valor_sem_ipi, " +
                    "COUNT (*) as qtdLinhas, "+
                    "AVG(LT) as leadTime "+
                    "FROM ( " + sql + " ) as tab";
                

                IWTPostgreNpgsqlCommand command = DbConnection.Connection.CreateCommand();
                command.CommandText = sql2;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                read.Read();
                if (read["valor"] != DBNull.Value)
                {
                    this.lblValorRecebido.Text = Convert.ToDouble(read["valor"]).ToString("C2", CultureInfo.CurrentCulture);
                }
                else
                {
                    this.lblValorRecebido.Text = "R$ 0,00";
                }

                if (read["valor_sem_ipi"] != DBNull.Value)
                {
                    this.lblValorSemIPI.Text = Convert.ToDouble(read["valor_sem_ipi"]).ToString("C2", CultureInfo.CurrentCulture);
                }
                else
                {
                    this.lblValorSemIPI.Text = "R$ 0,00";
                }

                if (read["qtdLinhas"] != DBNull.Value)
                {
                    this.lblQtdLinhas.Text = read["qtdLinhas"].ToString() ;
                }
                else
                {
                    this.lblQtdLinhas.Text = "0";
                }

                if (read["leadTime"] != DBNull.Value)
                {
                    this.lblLeadTime.Text = Convert.ToDouble(read["leadTime"]).ToString("F2", CultureInfo.CurrentCulture);
                }
                else
                {
                    this.lblLeadTime.Text = "0,00";
                }
                read.Close();


               
                
            }
            catch (Exception z)
            {
                MessageBox.Show("Erro em carregar o Grid. \n" + z.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        #region Eventos
        private void txtOC_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void txtPos_TextChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Start();
        }

        private void chkDeDataNF_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDeDataNF.Enabled = this.chkDeDataNF.Checked;
            this.initializeGrid();
        }

        private void chkAteDataNF_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpAteDataNF.Enabled = this.chkAteDataNF.Checked;
            this.initializeGrid();
        }

        private void dtpDeDataNF_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void dtpAteDataNF_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void lnkAtualizar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbTodos_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbPendentes_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void rdbEncerrados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void chkDeDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDeDataEntrega.Enabled = this.chkDeDataEntrega.Checked;
            this.initializeGrid();
        }

        private void chkAteDataEntrega_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpAteDataEntrega.Enabled = this.chkAteDataEntrega.Checked;
            this.initializeGrid();
        }
        private void dtpDeDataEntrega_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void dtpAteDataEntrega_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }
     
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            this.initializeGrid();
        }

      

        private void ReceitaForm_Shown(object sender, EventArgs e)
        {
            /*int larguraColunas = 80;
            foreach (DataGridViewColumn coluna in this.dataGridView1.Columns)
            {
                larguraColunas += coluna.Width;
            }

            if (this.Width < larguraColunas)
            {
                this.Width = larguraColunas;
            }*/

            this.WindowState = FormWindowState.Maximized;
        }

       

        private void rdbAtrasados_CheckedChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }
       
        private void chkDeDataEntrada_CheckedChanged(object sender, EventArgs e)
        {

            this.dtpDeDataEntrada.Enabled = this.chkDeDataEntrada.Checked;
            this.initializeGrid();
        }

        private void chkAteDataEntrada_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpAteDataEntrada.Enabled = this.chkAteDataEntrada.Checked;
            this.initializeGrid();
        }


        private void dtpDeDataEntrada_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        private void dtpAteDataEntrada_ValueChanged(object sender, EventArgs e)
        {
            this.initializeGrid();
        }

        #endregion

    }
}
