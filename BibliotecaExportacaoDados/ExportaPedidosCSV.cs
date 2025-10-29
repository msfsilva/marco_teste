#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using BibliotecaTelasOP;
using Configurations;
using IWTPostgreNpgsql;
using Npgsql;
using ProjectConstants;

#endregion

namespace BibliotecaExportacaoDados
{
    public class ExportaPedidosCSV
    {
        readonly IWTPostgreNpgsqlConnection conn;
        private readonly int _limiteRegistrosAntesFlush = 50000;

        public ExportaPedidosCSV(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public string gerarCSV(DateTime? dataEntradaInicio, DateTime? dataEntradaFim, DateTime? dataEntregaInicio, DateTime? dataEntregaFim,
            List<PedidoStatus> statusGerar, List<PedidoUrgente> urgenteGerar, List<ExportaPedidoPedidoClass> Pedidos ,List<int> idClientes,
            string outputDir)
        {
            StreamWriter writer = null;
            try
            {
                #region Testa Dir e cria arquivo saida

                if (!Directory.Exists(outputDir))
                {
                    throw new Exception("Diretório de saída inválido.");
                }

                string fileName = outputDir + "/exportPedidoEasi.csv";

                if (File.Exists(@fileName))
                {
                    File.Delete(@fileName);
                }




                #endregion

                #region Buscas

                string searchClause = "";

                if (dataEntradaInicio != null)
                {
                    searchClause += " AND pei_data_entrada >= '" + dataEntradaInicio.Value.ToString("yyyy-MM-dd") + "' ";
                }

                if (dataEntradaFim != null)
                {
                    searchClause += " AND pei_data_entrada < '" + dataEntradaFim.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                }

                if (dataEntregaInicio != null)
                {
                    searchClause += " AND pei_data_entrega >= '" + dataEntregaInicio.Value.ToString("yyyy-MM-dd") + "' ";
                }

                if (dataEntregaFim != null)
                {
                    searchClause += " AND pei_data_entrega < '" + dataEntregaFim.Value.Date.AddDays(1).ToString("yyyy-MM-dd") + "' ";
                }

                if (statusGerar != null)
                {
                    string statusClause = "";
                    foreach (PedidoStatus stat in statusGerar)
                    {
                        statusClause += " OR status = " + Convert.ToInt16(stat) + " ";
                    }

                    if (statusClause.Length > 0)
                    {
                        searchClause += " AND (" + statusClause.Substring(3) + ") ";
                    }
                }

                if (urgenteGerar != null)
                {
                    string urgenteClause = "";
                    foreach (PedidoUrgente urg in urgenteGerar)
                    {
                        urgenteClause += " OR pei_urgente = " + Convert.ToInt16(urg) + " ";
                    }

                    if (urgenteClause.Length > 0)
                    {
                        searchClause += " AND (" + urgenteClause.Substring(3) + ") ";
                    }
                }

                if (Pedidos != null)
                {
                    string pedidosClause = "";
                    foreach (ExportaPedidoPedidoClass ped in Pedidos)
                    {
                        pedidosClause += " OR (pei_numero LIKE '" + ped.Numero + "'";
                        if (ped.Pos != null)
                        {
                            pedidosClause += "AND pei_posicao = " + ped.Pos + " ";
                        }
                        pedidosClause += " ) ";
                    }

                    if (pedidosClause.Length > 0)
                    {
                        searchClause += " AND (" + pedidosClause.Substring(3) + ") ";
                    }
                }

                if (idClientes != null)
                {
                    string clientesClause = "";
                    foreach (int idCliente in idClientes)
                    {
                        clientesClause += " OR pedido_item.id_cliente = " + idCliente + " ";
                    }

                    if (clientesClause.Length > 0)
                    {
                        searchClause += " AND (" + clientesClause.Substring(3) + ") ";
                    }
                }

                if (searchClause.Length > 0)
                {
                    searchClause = " WHERE " + searchClause.Substring(4) + " ";
                }

                #endregion

                #region Cabeçalho do arquivo

                
                double maxVariaveis = 300;
                


                string linhaCabecalho =
                    "Pedido;Posição;Sublinha;Cliente;Data Entrada;Data Entrega;Data Entrega Original;Código Interno Produto;" +
                    "Descrição Interna;Código Produto Cliente;Descrição Produto Cliente;Quantidade;Saldo;Preço Unitário;Preço Total;Preço Original;" +
                    "Frete;Projeto;" +
                    "CNPJ Cliente;Armazenagem;NBM;Status;Entrega Parcial;Volume Único;Configurado;Data Configuração;Exportação;Urgente;" +
                    "Urgente Solicitante;Urgente Data Prometida;Urgente Informações Complementares;Informação Especial Pedido;CFOP;" +
                    "Natureza da Operação;Incide ICMS;" +
                    "Incide IPI;Incide Cofins;Incide PIS;Incide ISS;Valida Preços;Usuário Cancelamento;DataCancelamento;Justificativa Cancelamento;" +
                    "Emite OP;Medida Calculada;Agrupador Item Semelhantes;" +
                    "Notas Fiscais;Data Notas Fiscais;Forma de Pagamento; Endereço Principal; Endereço Secundário; Telefone/Ramal 1; Telefone/Ramal2; Fax/Ramal;" +
                    "Contato ;Inscrição Estadual; Acabamento; Data Encerramento;" +
                    "Representante Razão;Representante CNPJ;Representante Email;Representante Banco;Representante Agencia;Representante Conta;(%)Comissão Pedido; (%)Comissão Representante;Classificação;";


                for (int i = 1; i <= maxVariaveis; i++)
                {
                    linhaCabecalho += "Var " + i + ";Valor Var " + i + ";";
                }

                using (writer = new StreamWriter(fileName, true, Encoding.GetEncoding(1252)))
                {
                    writer.AutoFlush = true;
                    writer.WriteLine(linhaCabecalho);
                    writer.Close();
                }

                #endregion


                bool operacaoCompleta = IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO);




                string queryBase =
                    "SELECT  " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_sub_linha, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.cliente.id_cliente, " +
                    "  public.pedido_item.pei_data_entrada, " +
                    "  pedido_pai.data_entrega, " +
                    "  pedido_pai.data_entrega_original, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.pedido_item.pei_produto_codigo_cliente, " +
                    "  public.pedido_item.pei_produto_descricao_cliente, " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.pedido_item.pei_saldo, " +
                    "  public.pedido_item.pei_preco_unitario, " +
                    "  public.pedido_item.pei_preco_total, " +
                    "  public.pedido_item.pei_preco_total_original,  " +
                    "  public.pedido_item.pei_frete, " +
                    "  public.pedido_item.pei_projeto_cliente, " +
                    "  public.pedido_item.pei_cnpj_cliente, " +
                    "  public.pedido_item.pei_armazenagem_cliente, " +
                    "  public.ncm.ncm_codigo, " +
                    "  pedido_pai.status, " +
                    "  public.pedido_item.pei_permite_entrega_parcial, " +
                    "  public.pedido_item.pei_volume_unico, " +
                    "  public.pedido_item.pei_configurado, " +
                    "  public.pedido_item.pei_data_configuracao, " +
                    "  public.pedido_item.pei_exportacao, " +
                    "  public.pedido_item.pei_urgente, " +
                    "  public.pedido_item.pei_urgente_solicitante, " +
                    "  public.pedido_item.pei_urgente_data_prometida, " +
                    "  public.pedido_item.pei_urgente_informacoes_complementares, " +
                    "  public.pedido_item.pei_informacao_especial, " ;

                if (operacaoCompleta)
                {
                    queryBase +=
                        "  public.operacao_completa.opc_cfop as ope_cfop, " +
                        "  public.operacao_completa.opc_natureza_operacao as ope_natureza_operacao, " +
                        "  public.operacao_completa.opc_icms_incide as ope_incide_icms, " +
                        "  public.operacao_completa.opc_ipi_incide as ope_incide_ipi, " +
                        "  public.operacao_completa.opc_cofins_incide as ope_incide_cofins, " +
                        "  public.operacao_completa.opc_pis_incide as ope_incide_pis, " +
                        "  0 as ope_incide_iss, " +
                        "  public.operacao_completa.opc_valida_precos as ope_valida_precos, ";
                }
                else
                {
                    queryBase +=
                        "  public.operacao.ope_cfop, " +
                        "  public.operacao.ope_natureza_operacao, " +
                        "  public.operacao.ope_incide_icms, " +
                        "  public.operacao.ope_incide_ipi, " +
                        "  public.operacao.ope_incide_cofins, " +
                        "  public.operacao.ope_incide_pis, " +
                        "  public.operacao.ope_incide_iss, " +
                        "  public.operacao.ope_valida_precos, ";
                }

                queryBase +=
                    "  public.acs_usuario.aus_login as usuario_cancelamento, " +
                    "  public.pedido_item.pei_data_cancelamento, " +
                    "  public.pedido_item.pei_justificativa_cancelamento, " +
                    "  public.produto.pro_emite_op, " +
                    "  public.order_item_etiqueta.oie_dimensao, " +
                    "  CASE WHEN order_item_etiqueta.id_produto_k IS NOT NULL THEN public.order_item_etiqueta.oie_codigo_item ELSE '' END AS codigoKB, " +
                    "  iwt_agregate_pedidos_op(CAST (nf_principal.nfp_numero AS VARCHAR)) as notas ,   " +
                    "  iwt_agregate_pedidos_op(to_char(nf_principal.nfp_data_emissao,'DD/MM/YYYY')) as data_notas, " +
                    "  COALESCE(fop_pedido.fop_descricao, fop_cliente.fop_descricao) as forma_pgto, " +
                    "  (public.cliente.cli_endereco||', '||public.cliente.cli_endereco_numero||' - '|| public.cliente.cli_bairro||' - '|| cidade_1.cid_nome ||'/'||estado_1.est_sigla ||' - '|| public.cliente.cli_cep) as endereco_principal, " +
                    "  (public.cliente.cli_endereco_cob ||', '|| public.cliente.cli_endereco_numero_cob ||' - '|| public.cliente.cli_bairro_cob ||' - '|| cidade_2.cid_nome ||'/'|| estado_2.est_sigla ||' - '|| public.cliente.cli_cep_cob) as endereco_cobranca, " +
                    "  public.cliente.cli_fone1 || '  ' || public.cliente.cli_ramal1 as fone1,  " +
                    "  public.cliente.cli_fone2 || '  ' || public.cliente.cli_ramal2 as fone2,  " +
                    "  public.cliente.cli_fax || '  ' || public.cliente.cli_fax_ramal as fax,  " +
                    "  public.cliente.cli_comprador_cliente as contato, " +
                    "  public.cliente.cli_ie as ie,  " +
                    "  public.order_item_etiqueta.oie_acab_item_pai as acabamento, " +
                    "  pedido_pai.data_encerramento, " +
                    "  public.representante.rep_razao_social as rep_razao_social, " +
                    "  public.representante.rep_cnpj as rep_cnpj, " +
                    "  public.representante.rep_email as rep_email, " +
                    "  public.representante.rep_banco as rep_banco, " +
                    "  public.representante.rep_agencia as rep_agencia, " +
                    "  public.representante.rep_conta as rep_conta, " +
                    "  public.pedido_item.pei_perc_comissao_representante as pedido_percentual_comissao, " +
                    "  public.representante.rep_comissao, " +
                    "  pedido_pai.classificacao " +
                    "FROM " +
                    "  public.pedido_item " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) ";

                if (operacaoCompleta)
                {
                    queryBase += "  INNER JOIN public.operacao_completa ON (public.pedido_item.id_operacao_completa = public.operacao_completa.id_operacao_completa) ";
                }
                else
                {
                    queryBase += "  INNER JOIN public.operacao ON (public.pedido_item.id_operacao = public.operacao.id_operacao) ";
                }

                queryBase +=
                    "  LEFT OUTER JOIN public.acs_usuario ON (public.pedido_item.id_acs_usuario_cancelamento = public.acs_usuario.id_acs_usuario) " +
                    "  LEFT OUTER JOIN public.order_item_etiqueta ON (public.pedido_item.id_pedido_item = public.order_item_etiqueta.id_pedido_item) " +
                    "  INNER JOIN ( " +
                    "       SELECT pei_numero as numero, pei_posicao as posicao, pei_status as status, id_pedido_item as id_pedido_item_pai, pei_data_encerramento as data_encerramento, pedido_item.id_cliente as IdCliente, public.classificacao_produto.clp_identificacao as classificacao, pedido_item.pei_data_entrega as data_entrega, pei_data_entrega_original as data_entrega_original FROM pedido_item" +
                    "           LEFT OUTER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                    "           LEFT OUTER JOIN public.classificacao_produto ON (public.produto.id_classificacao_produto = public.classificacao_produto.id_classificacao_produto)" +
                    "        " +
                    "        WHERE pei_sub_linha = 0 " +
                    ") as pedido_pai ON pei_numero = numero AND pei_posicao = posicao AND pedido_item.id_cliente = IdCliente " +
                    " LEFT JOIN atendimento ON atendimento.id_pedido_item = pedido_pai.id_pedido_item_pai " +
                    " LEFT JOIN nf_principal ON atendimento.id_nf_principal = nf_principal.id_nf_principal " +
                    " LEFT JOIN forma_pagamento as fop_pedido ON fop_pedido.id_forma_pagamento = pedido_item.id_forma_pagamento " +
                    " LEFT JOIN forma_pagamento as fop_cliente ON fop_cliente.id_forma_pagamento = cliente.id_forma_pagamento " +
                    " LEFT OUTER JOIN public.cidade cidade_1 ON (public.cliente.id_cidade_cob = cidade_1.id_cidade) " +
                    " LEFT OUTER JOIN public.cidade cidade_2 ON (public.cliente.id_cidade = cidade_2.id_cidade) " +
                    " LEFT OUTER JOIN public.estado estado_1 ON (cidade_1.id_estado = estado_1.id_estado) " +
                    " LEFT OUTER JOIN public.estado estado_2 ON (cidade_2.id_estado = estado_2.id_estado) " +
                    " LEFT OUTER JOIN public.representante ON (public.pedido_item.id_representante = public.representante.id_representante) " +
                    "  LEFT OUTER JOIN public.ncm ON(public.pedido_item.id_ncm = public.ncm.id_ncm) " +
                    searchClause + " " +
                    "GROUP BY " +
                    "  public.pedido_item.pei_numero,   " +
                    "  public.pedido_item.pei_posicao,   " +
                    "  public.pedido_item.pei_sub_linha,   " +
                    "  public.cliente.cli_nome_resumido,   " +
                    "  public.cliente.id_cliente,   " +
                    "  public.pedido_item.pei_data_entrada,   " +
                    "  pedido_pai.data_entrega,   " +
                    "  pedido_pai.data_entrega_original,   " +
                    "  public.produto.pro_codigo,   " +
                    "  public.produto.pro_descricao,   " +
                    "  public.pedido_item.pei_produto_codigo_cliente,   " +
                    "  public.pedido_item.pei_produto_descricao_cliente,   " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.pedido_item.pei_saldo,   " +
                    "  public.pedido_item.pei_preco_unitario,   " +
                    "  public.pedido_item.pei_preco_total,   " +
                    "  public.pedido_item.pei_preco_total_original,    " +
                    "  public.pedido_item.pei_frete,   " +
                    "  public.pedido_item.pei_projeto_cliente,   " +
                    "  public.pedido_item.pei_cnpj_cliente,   " +
                    "  public.pedido_item.pei_armazenagem_cliente,   " +
                    "  public.ncm.ncm_codigo,   " +
                    "  pedido_pai.status,   " +
                    "  public.pedido_item.pei_permite_entrega_parcial,   " +
                    "  public.pedido_item.pei_volume_unico,   " +
                    "  public.pedido_item.pei_configurado,   " +
                    "  public.pedido_item.pei_data_configuracao,   " +
                    "  public.pedido_item.pei_exportacao,   " +
                    "  public.pedido_item.pei_urgente,   " +
                    "  public.pedido_item.pei_urgente_solicitante,   " +
                    "  public.pedido_item.pei_urgente_data_prometida,   " +
                    "  public.pedido_item.pei_urgente_informacoes_complementares,   " +
                    "  public.pedido_item.pei_informacao_especial,   " ;

                if (operacaoCompleta)
                {
                    queryBase +=
                        "  public.operacao_completa.opc_cfop, " +
                        "  public.operacao_completa.opc_natureza_operacao, " +
                        "  public.operacao_completa.opc_icms_incide, " +
                        "  public.operacao_completa.opc_ipi_incide, " +
                        "  public.operacao_completa.opc_cofins_incide, " +
                        "  public.operacao_completa.opc_pis_incide, " +
                        "  public.operacao_completa.opc_valida_precos, ";
                }
                else
                {

                    queryBase +=

                        "  public.operacao.ope_cfop,   " +
                        "  public.operacao.ope_natureza_operacao,   " +
                        "  public.operacao.ope_incide_icms,   " +
                        "  public.operacao.ope_incide_ipi,   " +
                        "  public.operacao.ope_incide_cofins,   " +
                        "  public.operacao.ope_incide_pis,   " +
                        "  public.operacao.ope_incide_iss,   " +
                        "  public.operacao.ope_valida_precos, ";
                }

                queryBase +=
                "  public.acs_usuario.aus_login,   " +
                    "  public.pedido_item.pei_data_cancelamento,   " +
                    "  public.pedido_item.pei_justificativa_cancelamento,   " +
                    "  public.produto.pro_emite_op,   " +
                    "  public.order_item_etiqueta.oie_dimensao,  " +
                    "  order_item_etiqueta.id_produto_k, " +
                    "  public.order_item_etiqueta.oie_codigo_item, " +
                    "  fop_pedido.fop_descricao, " +
                    "  fop_cliente.fop_descricao, " +
                    "  public.cliente.cli_endereco, " +
                    "  public.cliente.cli_endereco_numero, " +
                    "  public.cliente.cli_bairro, " +
                    "  cidade_1.cid_nome, " +
                    "  estado_1.est_sigla, " +
                    "  public.cliente.cli_endereco_cob, " +
                    "  public.cliente.cli_endereco_numero_cob, " +
                    "  public.cliente.cli_bairro_cob, " +
                    "  public.cliente.cli_cep_cob, " +
                    "  public.cliente.cli_cep, " +
                    "  cidade_2.cid_nome, " +
                    "  estado_2.est_sigla, " +
                    "  public.cliente.cli_fone1, " +
                    "  public.cliente.cli_ramal1,  " +
                    "  public.cliente.cli_fone2, " +
                    "  public.cliente.cli_ramal2,  " +
                    "  public.cliente.cli_fax, " +
                    "  public.cliente.cli_fax_ramal,  " +
                    "  public.cliente.cli_comprador_cliente, " +
                    "  public.cliente.cli_ie,  " +
                    "  public.order_item_etiqueta.oie_acab_item_pai, " +
                    "  pedido_pai.data_encerramento, " +
                    "  representante.rep_razao_social, " +
                    "  representante.rep_cnpj, " +
                    "  representante.id_representante, " +
                    "  representante.rep_email, " +
                    "  representante.rep_banco, " +
                    "  representante.rep_agencia, " +
                    "  representante.rep_conta, " +
                    "  public.pedido_item.pei_perc_comissao_representante, " +
                    "  public.representante.rep_comissao, " +
                    "  pedido_pai.classificacao " +
                    "ORDER BY " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.cliente.cli_nome_resumido,   " +
                    "  public.pedido_item.pei_sub_linha "; 

                ;

               
                bool encerrado = false;
                int registroAtualFlush = 0;
                while (!encerrado)
                {
                    using (writer = new StreamWriter(fileName, true, Encoding.GetEncoding(1252)))
                    {
                        writer.AutoFlush = true;
                        var command = this.conn.CreateCommand();
                        command.CommandText = queryBase + " LIMIT " + _limiteRegistrosAntesFlush + " OFFSET " + registroAtualFlush;
                        using (IWTPostgreNpgsqlDataReader read = command.ExecuteReader())
                        {
                            bool hasRows = false;

                            while (read.Read())
                            {
                                hasRows = true;
                                writer.Write("\"" + read["pei_numero"].ToString().Replace("\r\n", "") + "\";");
                                writer.Write(read["pei_posicao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_sub_linha"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["cli_nome_resumido"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDateTime(read["pei_data_entrada"]).ToString("dd-MM-yyyy") + ";");
                                writer.Write(Convert.ToDateTime(read["data_entrega"]).ToString("dd-MM-yyyy") + ";");
                                if (read["data_entrega_original"] != DBNull.Value)
                                {
                                    writer.Write(Convert.ToDateTime(read["data_entrega_original"]).ToString("dd-MM-yyyy") + ";");
                                }
                                else
                                {
                                    writer.Write(";");
                                }
                                writer.Write(read["pro_codigo"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pro_descricao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_produto_codigo_cliente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_produto_descricao_cliente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_quantidade"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_saldo"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_preco_unitario"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_preco_total"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_preco_total_original"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(Convert.ToDouble(read["pei_frete"]).ToString("F5", CultureInfo.GetCultureInfo("pt-BR")).Replace("\r\n", "") + ";");
                                writer.Write(read["pei_projeto_cliente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_cnpj_cliente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_armazenagem_cliente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ncm_codigo"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["status"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_permite_entrega_parcial"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_volume_unico"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_configurado"].ToString().Replace("\r\n", "") + ";");
                                if (read["pei_data_configuracao"] != DBNull.Value)
                                {
                                    writer.Write(Convert.ToDateTime(read["pei_data_configuracao"]).ToString("dd-MM-yyyy") + ";");
                                }
                                else
                                {
                                    writer.Write(";");
                                }
                                writer.Write(read["pei_exportacao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_urgente"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_urgente_solicitante"].ToString().Replace("\r\n", "") + ";");
                                if (read["pei_urgente_data_prometida"] != DBNull.Value)
                                {
                                    writer.Write(Convert.ToDateTime(read["pei_urgente_data_prometida"]).ToString("dd-MM-yyyy") + ";");
                                }
                                else
                                {
                                    writer.Write(";");
                                }
                                writer.Write(read["pei_urgente_informacoes_complementares"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pei_informacao_especial"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_cfop"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_natureza_operacao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_incide_icms"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_incide_ipi"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_incide_cofins"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_incide_pis"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_incide_iss"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ope_valida_precos"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["usuario_cancelamento"].ToString().Replace("\r\n", "") + ";");
                                if (read["pei_data_cancelamento"] != DBNull.Value)
                                {
                                    writer.Write(Convert.ToDateTime(read["pei_data_cancelamento"]).ToString("dd-MM-yyyy") + ";");
                                }
                                else
                                {
                                    writer.Write(";");
                                }
                                writer.Write(read["pei_justificativa_cancelamento"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["pro_emite_op"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["oie_dimensao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["codigoKB"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["notas"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["data_notas"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["forma_pgto"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["endereco_principal"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["endereco_cobranca"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["fone1"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["fone2"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["fax"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["contato"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["ie"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["acabamento"].ToString().Replace("\r\n", "") + ";");
                                if (read["data_encerramento"] != DBNull.Value)
                                {
                                    writer.Write(Convert.ToDateTime(read["data_encerramento"]).ToString("dd-MM-yyyy") + ";");
                                }
                                else
                                {
                                    writer.Write(";");
                                }

                                writer.Write(read["rep_razao_social"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_cnpj"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_email"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_banco"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_agencia"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_conta"].ToString().Replace("\r\n", "") + ";");

                                writer.Write(read["pedido_percentual_comissao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["rep_comissao"].ToString().Replace("\r\n", "") + ";");
                                writer.Write(read["classificacao"].ToString().Replace("\r\n", "") + ";");

                                IWTPostgreNpgsqlCommand command2 = this.conn.CreateCommand();
                                IWTPostgreNpgsqlDataReader read2;
                                command2.CommandText =
                                    "SELECT * FROM ( " +
                                    "SELECT  " +
                                    "  public.pedido_item_variavel.piv_codigo as codigo, " +
                                    "  public.pedido_item_variavel.piv_valor as valor " +
                                    "FROM " +
                                    "  public.pedido_item_variavel " +
                                    "WHERE " +
                                    "  public.pedido_item_variavel.piv_pedido_numero LIKE '" + read["pei_numero"] + "' AND  " +
                                    "  public.pedido_item_variavel.piv_pedido_posicao =" + read["pei_posicao"] + " AND  " +
                                    "  public.pedido_item_variavel.id_cliente = " + read["id_cliente"] + " AND  " +
                                    "  public.pedido_item_variavel.piv_sub_linha = " + read["pei_sub_linha"] + " " +
                                    "UNION ALL " +
                                    "SELECT  " +
                                    "  public.pedido_variavel.pev_codigo as codigo, " +
                                    "  public.pedido_variavel.pev_valor as valor " +
                                    "FROM " +
                                    "  public.pedido_variavel " +
                                    "WHERE " +
                                    "  public.pedido_variavel.pev_pedido_numero LIKE '" + read["pei_numero"] + "' AND  " +
                                    "  public.pedido_variavel.pev_pedido_posicao = " + read["pei_posicao"] + " AND " +
                                    "  public.pedido_variavel.id_cliente = " + read["id_cliente"] + " " +
                                    "  ) as tab " +
                                    "ORDER BY codigo ";

                                read2 = command2.ExecuteReader();
                                while (read2.Read())
                                {
                                    writer.Write(read2["codigo"].ToString().Replace("\r\n", "") + ";" + read2["valor"].ToString().Replace("\r\n", "") + ";");
                                }
                                read2.Close();

                                writer.WriteLine();
                                registroAtualFlush++;
                            }
                            read.Close();
                            writer.Close();

                            if (!hasRows)
                            {
                                encerrado = true;
                            }
                        }
                    }
                }



                return fileName;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao exportar os pedidos em CSV.\r\n" + e.Message, e);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }


        }

    }

    public class ExportaPedidoPedidoClass
    {
        public string Numero { get; set; }
        public string Pos { get; set; }

        public ExportaPedidoPedidoClass(string Numero, string Pos)
        {
            this.Numero = Numero;
            this.Pos = Pos;
        }

    }


 
}
