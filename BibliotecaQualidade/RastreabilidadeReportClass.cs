#region Referencias

using System;
using System.Collections.Generic;
using System.Globalization;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaQualidade
{
    public class RastreabilidadeReportClass
    {
        private readonly IWTPostgreNpgsqlConnection conn;
        public RastreabilidadeReportClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

        public RastreabilidadeReport generateReport(string oc, string pos, long idCliente)
        {

            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                RastreabilidadeReportDataSet ds = new RastreabilidadeReportDataSet();
                RastreabilidadeReportDataSet.dadosRow row;
                RastreabilidadeReportDataSet.opsRow opsRow;


                command.CommandText =
                    "SELECT                                                                                                                                                                                   " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number,                                                                                                                               " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos,                                                                                                                                  " +
                    "  public.order_item_etiqueta_conferencia.oic_codigo_item,                                                                                                                                " +
                    "  public.order_item_etiqueta_conferencia.oic_quantidade_conferida,                                                                                                                       " +
                    "  public.order_item_etiqueta_conferencia.oic_data_conferencia,                                                                                                                           " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_estacao,                                                                                                                      " +
                    "  public.order_item_etiqueta_conferencia.oic_identificacao_usuario,                                                                                                                      " +
                    "  public.order_item_etiqueta_conferencia.oic_volumes,                                                                                                                                    " +
                    "  public.order_item_etiqueta_conferencia.oic_pallet,                                                                                                                                     " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario,                                                                                                                 " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pallet_data,                                                                                                                    " +
                    "  public.order_item_etiqueta_conferencia.id_embarque,                                                                                                                                    " +
                    "  public.embarque.emb_usuario,                                                                                                                                                           " +
                    "  public.embarque.emb_data_hora,                                                                                                                                                         " +
                    "  public.embarque.emb_liberacao_hora,                                                                                                                                                    " +
                    "  public.embarque.emb_liberacao_usuario,                                                                                                                                                 " +
                    "  public.nf_principal.nfp_numero,                                                                                                                                                        " +
                    "  public.atendimento.ate_usuario,                                                                                                                                                        " +
                    "  public.atendimento.ate_data_hora,                                                                                                                                                      " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai,                                                                                                                            " +
                    "  public.cliente.cli_nome_resumido,                                                                                                                                                       " +
                    "  public.order_item_etiqueta.oie_codigo_cliente, "+
                    "  public.order_item_etiqueta.oie_dimensao " +
                    "FROM                                                                                                                                                                                     " +
                    "  public.order_item_etiqueta_conferencia                                                                                                                                                 " +
                    "  JOIN order_item_etiqueta ON order_item_etiqueta_conferencia.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta                                                        " +
                    "  LEFT OUTER JOIN public.embarque ON (public.order_item_etiqueta_conferencia.id_embarque = public.embarque.id_embarque)                                                                  " +
                    "  LEFT OUTER JOIN public.atendimento ON (public.order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = public.atendimento.id_order_item_etiqueta_conferencia)              " +
                    "  LEFT OUTER JOIN public.nf_principal ON (public.atendimento.id_nf_principal = public.nf_principal.id_nf_principal)                                                                      " +
                    "  LEFT OUTER JOIN public.cliente ON order_item_etiqueta.id_cliente = cliente.id_cliente                                                                                                  " +
                    "WHERE                                                                                                                                                                                    " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number LIKE '" + oc + "' AND                                                                                                         " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos = " + pos + " AND                                                                                                                 " +
                    "  public.order_item_etiqueta.id_cliente = "+idCliente+" "+
                    "ORDER BY " +
                    "  public.order_item_etiqueta_conferencia.oic_order_number,                                                                                                          " +
                    "  public.order_item_etiqueta_conferencia.oic_order_pos,                                                                                                                  " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.order_item_etiqueta_conferencia.oic_conferencia_pai DESC";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                 //   throw new Exception("O pedido selecionado ainda não iniciou o processo de expedição");
                }

                RastreabilidadeReportDataSet.dadosRow ultimaRowPai= null;

           
                while (read.Read())
                {
                    row = ds.dados.NewdadosRow();

                    row.oc = oc;
                    row.pos = pos;
                    row.cliente = read["cli_nome_resumido"].ToString();
                    row.oc_pos = read["cli_nome_resumido"] + " - " + oc + "/" + pos;
                    row.id_cliente = idCliente;

                    #region Dados relativos a conferencia
                    if (read["oic_conferencia_pai"] != DBNull.Value)
                    {
                        row.item_pai = Convert.ToInt16(read["oic_conferencia_pai"]);

                      
                        row.conf_pedido_item = read["oic_codigo_item"].ToString();
                        row.conf_pedido_item_codigo_cliente = read["oie_codigo_cliente"].ToString();
                        row.conf_pedido_item_dimensao = read["oie_dimensao"].ToString();

                        if (row.conf_pedido_item_dimensao == "0" || row.conf_pedido_item_dimensao == "FIXO")
                        {
                            row.conf_pedido_item_dimensao = "";
                        }

                        if (read["oic_quantidade_conferida"] != DBNull.Value)
                        {
                            row.conf_pedido_qtd = Convert.ToDouble(read["oic_quantidade_conferida"]);
                        }


                        if (row.item_pai == 1)
                        {


                            if (read["oic_conferencia_pallet_data"] != DBNull.Value)
                            {
                                row.conf_pallet_data = Convert.ToDateTime(read["oic_conferencia_pallet_data"]);
                            }

                            if (read["oic_pallet"] != DBNull.Value)
                            {
                                row.conf_pallet_numero = Convert.ToInt32(read["oic_pallet"]);
                            }

                            row.conf_pallet_usuario = read["oic_conferencia_pallet_usuario"].ToString();

                            if (read["oic_data_conferencia"] != DBNull.Value)
                            {
                                row.conf_pedido_data = Convert.ToDateTime(read["oic_data_conferencia"]);
                            }

                            row.conf_pedido_estacao = read["oic_identificacao_estacao"].ToString();




                            row.conf_pedido_usuario = read["oic_identificacao_usuario"].ToString();

                            if (read["oic_volumes"] != DBNull.Value)
                            {
                                row.conf_pedido_volumes = Convert.ToInt32(read["oic_volumes"]);
                            }

                            if (read["emb_liberacao_hora"] != DBNull.Value)
                            {
                                row.libe_embarque_data = Convert.ToDateTime(read["emb_liberacao_hora"]);
                            }

                            row.libe_embarque_usuario = read["emb_liberacao_usuario"].ToString();

                            if (read["emb_data_hora"] != DBNull.Value)
                            {
                                row.mont_embarque_data = Convert.ToDateTime(read["emb_data_hora"]);
                            }

                            if (read["id_embarque"] != DBNull.Value)
                            {
                                row.mont_embarque_numero = Convert.ToInt32(read["id_embarque"]);
                            }

                            row.mont_embarque_usuario = read["emb_usuario"].ToString();

                            if (read["ate_data_hora"] != DBNull.Value)
                            {
                                row.nf_data = Convert.ToDateTime(read["ate_data_hora"]);
                            }

                            if (read["nfp_numero"] != DBNull.Value)
                            {
                                row.nf_numero = Convert.ToInt32(read["nfp_numero"]);
                            }

                            row.nf_usuario = read["ate_usuario"].ToString();
                        }
                        else
                        {
                            
                            row.nf_numero = ultimaRowPai.nf_numero;
                            row.mont_embarque_numero = ultimaRowPai.mont_embarque_numero;
                            row.conf_pallet_numero = ultimaRowPai.conf_pallet_numero;
                        }


                        if (row.item_pai == 1)
                        {
                            ultimaRowPai = row;
                        }
                    }
                #endregion

                    ds.dados.AdddadosRow(row);
                }

                read.Close();

                if (ds.dados.Rows.Count == 0)
                {
                    command.CommandText =
                        "SELECT  " +
                        "  public.cliente.cli_nome_resumido " +
                        "FROM " +
                        "  public.order_item_etiqueta " +
                        "  INNER JOIN public.cliente ON (public.order_item_etiqueta.id_cliente = public.cliente.id_cliente) " +
                        "WHERE " +
                        "  public.order_item_etiqueta.oie_order_number LIKE '" + oc + "' AND " +
                        "  public.order_item_etiqueta.oie_order_pos = " + pos + " AND " +
                        "  public.order_item_etiqueta.id_cliente = " + idCliente + " ";

                    object tmp = command.ExecuteScalar();
                    string cliente = "";
                    if (tmp != null)
                    {
                        cliente = tmp.ToString();
                    }
                    else
                    {
                        cliente = "";
                    }
                    

                    row = ds.dados.NewdadosRow();

                    row.oc = oc;
                    row.pos = pos;
                    row.cliente = cliente;
                    row.id_cliente = idCliente;
                    row.oc_pos = cliente + " - " + oc + "/" + pos;

                    ds.dados.AdddadosRow(row);
                }

                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao.id_ordem_producao, " +
                    "  public.ordem_producao.orp_situacao, " +
                    "  tab_rastreavel.rastreavel, " +
                    "  orp_produto_codigo, " +
                    "  orp_produto_descricao, " +
                    "  pro_lead_time_fabrica " +
                    "FROM " +
                    "  public.ordem_producao_pedido " +
                    "  INNER JOIN public.order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN produto ON ordem_producao.id_produto = produto.id_produto " +
                    "  JOIN ( " +
                    "  	SELECT  " +
                    "	  public.ordem_producao_posto_trabalho.id_ordem_producao, " +
                    "	  MAX(public.posto_trabalho.pos_rastreamento) AS rastreavel " +
                    "	FROM " +
                    "	  public.ordem_producao_posto_trabalho " +
                    "	  INNER JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                    "	GROUP BY " +
                    "	  public.ordem_producao_posto_trabalho.id_ordem_producao " +
                    " ) as tab_rastreavel ON tab_rastreavel.id_ordem_producao = ordem_producao.id_ordem_producao " +
                    "WHERE " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + pos + "  AND " +
                    "  order_item_etiqueta.id_cliente =   " + idCliente + " " +
                    "ORDER BY " +
                    "  pro_lead_time_fabrica DESC, " +
                    "  public.ordem_producao.id_ordem_producao";


                read = command.ExecuteReader();

                
                while (read.Read())
                {
                    opsRow = ds.ops.NewopsRow();
                    opsRow.oc = oc;
                    opsRow.pos = pos;
                    opsRow.num_op = read["id_ordem_producao"].ToString();
                    opsRow.codigo_item = read["orp_produto_codigo"].ToString();
                    opsRow.descricao_item = read["orp_produto_descricao"].ToString();
                    opsRow.lead_time = Convert.ToInt32(read["pro_lead_time_fabrica"]);
                    opsRow.id_cliente = idCliente;
                    if (Convert.ToBoolean(Convert.ToInt16(read["rastreavel"])))
                    {
                        opsRow.rastreavel = "Sim";
                    }
                    else
                    {
                        opsRow.rastreavel = "Não";
                    }

                    switch (Convert.ToInt16(read["orp_situacao"]))
                    {
                        case 0:
                            opsRow.status = "Ordem Aguardando inicio da Produção";
                            break;
                        case 1:
                            opsRow.status = "Ordem em Produção";
                            break;
                        case 2:
                            opsRow.status = "Ordem Encerrada";
                            break;
                        case 3:
                            opsRow.status = "Ordem Cancelada";
                            break;
                    }

                    ds.ops.AddopsRow(opsRow);
                }

                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_producao_pedido.opp_order_number, " +
                    "  public.ordem_producao_pedido.opp_order_pos, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.plano_corte_item.pci_material_agrupador ||  ' ' || " +
                    "  public.plano_corte_item.pci_material_familia ||  ' ' || " +
                    "  public.plano_corte_item.pci_material_codigo as cod_material, " +
                    "  public.plano_corte_item.pci_posto_nome, " +
                    "  public.material.mat_descricao, " +
                    "  SUM(public.plano_corte_item_op.pco_quantidade) AS qtd, " +
                    "  public.plano_corte.id_plano_corte, " +
                    "  public.plano_corte.plc_data " +
                    "FROM " +
                    "  public.plano_corte " +
                    "  INNER JOIN public.plano_corte_item ON (public.plano_corte.id_plano_corte = public.plano_corte_item.id_plano_corte) " +
                    "  INNER JOIN public.plano_corte_item_op ON (public.plano_corte_item.id_plano_corte_item = public.plano_corte_item_op.id_plano_corte_item) " +
                    "  INNER JOIN public.ordem_producao ON (public.plano_corte_item_op.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN public.material ON (public.plano_corte_item.id_material = public.material.id_material) " +
                    "WHERE " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE :numero_pedido AND  " +
                    "  public.ordem_producao_pedido.opp_order_pos = :pos_pedido AND " +
                    "  public.order_item_etiqueta.id_cliente = :id_cliente " +
                    "GROUP BY " +
                    "  public.plano_corte.id_plano_corte, " +
                    "  public.plano_corte.plc_data, " +
                    "  public.plano_corte_item.pci_material_agrupador, " +
                    "  public.plano_corte_item.pci_material_familia, " +
                    "  public.plano_corte_item.pci_material_codigo, " +
                    "  public.plano_corte_item.pci_posto_nome, " +
                    "  public.ordem_producao_pedido.opp_order_number, " +
                    "  public.ordem_producao_pedido.opp_order_pos, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.material.mat_descricao " +
                    "UNION   " +
                    "SELECT  " +
                    "  public.plano_corte_item_pedido.pcp_pedido_numero, " +
                    "  public.plano_corte_item_pedido.pcp_pedido_posicao, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.plano_corte_item.pci_material_agrupador || ' ' || " +
                    "  public.plano_corte_item.pci_material_familia || ' ' ||  " +
                    "  public.plano_corte_item.pci_material_codigo as cod_material, " +
                    "  public.plano_corte_item.pci_posto_nome, " +
                    "  public.material.mat_descricao, " +
                    "  SUM(public.plano_corte_item_pedido.pcp_quantidade) as qtd, " +
                    "  public.plano_corte.id_plano_corte, " +
                    "  public.plano_corte.plc_data " +
                    "FROM " +
                    "  public.plano_corte " +
                    "  INNER JOIN public.plano_corte_item ON (public.plano_corte.id_plano_corte = public.plano_corte_item.id_plano_corte) " +
                    "  INNER JOIN public.plano_corte_item_pedido ON (public.plano_corte_item.id_plano_corte_item = public.plano_corte_item_pedido.id_plano_corte_item) " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.plano_corte_item_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN public.material ON (public.plano_corte_item.id_material = public.material.id_material) " +
                    "WHERE " +
                    "  public.plano_corte_item_pedido.pcp_pedido_numero LIKE :numero_pedido AND  " +
                    "  public.plano_corte_item_pedido.pcp_pedido_posicao = :pos_pedido AND  " +
                    "  public.order_item_etiqueta.id_cliente = :id_cliente " +
                    "GROUP BY " +
                    "  public.plano_corte_item_pedido.pcp_pedido_numero, " +
                    "  public.plano_corte_item_pedido.pcp_pedido_posicao, " +
                    "  public.order_item_etiqueta.id_cliente, " +
                    "  public.plano_corte_item.pci_material_agrupador, " +
                    "  public.plano_corte_item.pci_material_familia, " +
                    "  public.plano_corte_item.pci_material_codigo, " +
                    "  public.plano_corte_item.pci_posto_nome, " +
                    "  public.material.mat_descricao, " +
                    "  public.plano_corte.id_plano_corte, " +
                    "  public.plano_corte.plc_data ";
                                                    command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("numero_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = oc ;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pos_pedido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = pos;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idCliente;

                read = command.ExecuteReader();

                RastreabilidadeReportDataSet.pcsRow pcRow;
                while (read.Read())
                {
                    pcRow = ds.pcs.NewpcsRow();
                    pcRow.codigo_material = read["cod_material"].ToString();
                    pcRow.data_pc = Convert.ToDateTime(read["plc_data"]);
                    pcRow.descricao_material = read["mat_descricao"].ToString();
                    pcRow.id_cliente = idCliente;
                    pcRow.oc = oc;
                    pcRow.pos = pos;
                    pcRow.posto_trabalho = read["pci_posto_nome"].ToString();
                    pcRow.quantidade = Convert.ToDouble(read["qtd"]);
                    pcRow.numero_pc = Convert.ToInt32(read["id_plano_corte"]);

                    ds.pcs.AddpcsRow(pcRow);
                }

                RastreabilidadeReport toRet = new RastreabilidadeReport();
                toRet.SetDataSource(ds);
                toRet.Refresh();

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o relatório de rastreabilidade.\r\n" + e.Message);
            }
        }

        public RastreabilidadeOPReport generateReportOps(string oc, string pos, long idCliente)
        {
            try
            {
                Dictionary<int, leadTimeOpClass> leadTimes = new Dictionary<int, leadTimeOpClass>();

                RastreabilidadeOPReportDataSet ds = new RastreabilidadeOPReportDataSet();
                RastreabilidadeOPReportDataSet.rastreabilidadeRow row;

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  DISTINCT " +
                    "  public.ordem_producao_pedido.opp_order_number, " +
                    "  public.ordem_producao_pedido.opp_order_pos, " +
                    "  public.ordem_producao.id_ordem_producao, " +
                    "  SUM(public.ordem_producao_pedido.opp_quantidade) as opp_quantidade, " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_codigo, " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_nome, " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_operacao, " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_1, " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo1, " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_2, " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo2, " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_3, " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo3, " +
                    "  CASE public.posto_trabalho.pos_rastreamento WHEN 1 THEN 'Sim' ELSE 'Não' END as rastreamento, " +
                    "  CASE public.posto_trabalho.pos_acompanhamento WHEN 1 THEN 'Passagem' WHEN 2 THEN '2 Tempos' WHEN 3 THEN '3 Tempos' WHEN 4 THEN 'Passagem' ELSE '' END as acompanhamento, " +
                    "  public.ordem_producao_posto_trabalho.opt_quantidade_entrada, " +
                    "  public.ordem_producao_posto_trabalho.opt_quantidade_saida, " +
                    "  public.ordem_producao.orp_data, " +
                    "  CASE public.ordem_producao.orp_situacao WHEN 0 THEN 'Nova' WHEN 1 THEN 'Em Produção' WHEN 2 THEN 'Encerrada' ELSE 'Cancelada' END as situacao, " +
                    "  public.ordem_producao_posto_trabalho.opt_sequencia, " +
                    "  public.posto_trabalho.pos_rastreamento, " +
                    "  public.posto_trabalho.pos_acompanhamento, " +
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.ordem_producao_pedido.opp_cliente, " +
                    "  public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho " +
                    "FROM " +
                    "  public.ordem_producao_pedido " +
                    "  INNER JOIN public.order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_pedido.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN public.ordem_producao_posto_trabalho ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_posto_trabalho.id_ordem_producao) " +
                    "  INNER JOIN public.posto_trabalho ON (public.ordem_producao_posto_trabalho.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                    "  INNER JOIN public.produto ON public.ordem_producao.id_produto = public.produto.id_produto " +
                    "WHERE                                                                                                                                                                                    " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND                                                                                                         " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + pos + " AND                                                                                                                " +
                    "  public.posto_trabalho.pos_rastreamento = 1 AND " +
                    "  order_item_etiqueta.id_cliente =   " + idCliente + " " +
                    "GROUP BY " +
                    "  public.ordem_producao_pedido.opp_order_number,   " +
                    "  public.ordem_producao_pedido.opp_order_pos,   " +
                    "  public.ordem_producao.id_ordem_producao,   " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_codigo,   " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_nome,   " +
                    "  public.ordem_producao_posto_trabalho.opt_posto_operacao,   " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_1,   " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo1,   " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_2,   " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo2,   " +
                    "  public.ordem_producao_posto_trabalho.opt_operador_tempo_3,   " +
                    "  public.ordem_producao_posto_trabalho.opt_tempo3,   " +
                    "  public.posto_trabalho.pos_rastreamento,   " +
                    "  public.posto_trabalho.pos_acompanhamento,   " +
                    "  public.ordem_producao_posto_trabalho.opt_quantidade_entrada,   " +
                    "  public.ordem_producao_posto_trabalho.opt_quantidade_saida,   " +
                    "  public.ordem_producao.orp_data,   " +
                    "  public.ordem_producao.orp_situacao,   " +
                    "  public.ordem_producao_posto_trabalho.opt_sequencia,   " +
                    "  public.posto_trabalho.pos_rastreamento,  " +
                    "  public.posto_trabalho.pos_acompanhamento,  " +
                    "  public.produto.pro_codigo,   " +
                    "  public.produto.pro_descricao,   " +
                    "  public.ordem_producao_pedido.opp_cliente, " +
                    "  public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho  " +
                    "ORDER BY " +
                    " public.ordem_producao.id_ordem_producao ASC, " +
                    " public.ordem_producao_posto_trabalho.opt_sequencia ASC ";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                while (read.Read())
                {
                    row = ds.rastreabilidade.NewrastreabilidadeRow();
                    if (read["id_ordem_producao"] != DBNull.Value)
                    {
                        row.id_ordem_producao = Convert.ToInt32(read["id_ordem_producao"]);
                    }

                    row.opp_order_number = oc;
                    row.opp_order_pos = Convert.ToInt32(pos);
                    if (read["opp_quantidade"] != DBNull.Value)
                    {
                        row.opp_quantidade = Convert.ToDouble(read["opp_quantidade"]);
                    }
                    row.opt_operador_tempo_1 = read["opt_operador_tempo_1"].ToString();
                    if (read["opt_tempo3"] == DBNull.Value)
                    {
                        row.opt_operador_tempo_2 = "";
                        //row.opt_tempo2 = null;

                        if (read["opt_tempo2"] != DBNull.Value)
                        {
                            row.opt_tempo3 = Convert.ToDateTime(read["opt_tempo2"]);
                        }
                        row.opt_operador_tempo_3 = read["opt_operador_tempo_2"].ToString();
                    }
                    else
                    {
                        if (read["opt_tempo2"] != DBNull.Value)
                        {
                            row.opt_tempo2 = Convert.ToDateTime(read["opt_tempo2"]);
                        }
                        if (read["opt_tempo3"] != DBNull.Value)
                        {
                            row.opt_tempo3 = Convert.ToDateTime(read["opt_tempo3"]);
                        }
                        row.opt_operador_tempo_2 = read["opt_operador_tempo_2"].ToString();
                        row.opt_operador_tempo_3 = read["opt_operador_tempo_3"].ToString();
                    }
                    
                    row.opt_posto_codigo = read["opt_posto_codigo"].ToString();
                    row.opt_posto_nome = read["opt_posto_nome"].ToString();
                    row.opt_posto_operacao = read["opt_posto_operacao"].ToString();
                    if (read["opt_quantidade_entrada"] != DBNull.Value)
                    {
                        row.opt_quantidade_entrada = Convert.ToDouble(read["opt_quantidade_entrada"]);
                    }

                    if (read["opt_quantidade_saida"] != DBNull.Value)
                    {
                        row.opt_quantidade_saida = Convert.ToDouble(read["opt_quantidade_saida"]);
                    }

                    if (read["opt_sequencia"] != DBNull.Value)
                    {
                        row.opt_sequencia = Convert.ToInt32(read["opt_sequencia"]);
                    }
                    if (read["opt_tempo1"] != DBNull.Value)
                    {
                        row.opt_tempo1 = Convert.ToDateTime(read["opt_tempo1"]);
                    }
                  
                  
                    if (read["orp_data"] != DBNull.Value)
                    {
                        row.orp_data = Convert.ToDateTime(read["orp_data"]);
                    }
                    row.orp_situacao = read["situacao"].ToString();
                    row.pos_acompanhamento = read["acompanhamento"].ToString();
                    row.pos_rastreamento = read["rastreamento"].ToString();
                    row.pos_acompanhamento_original = Convert.ToInt16(read["pos_acompanhamento"]);
                    row.pos_rastreamento_original = Convert.ToInt32(read["pos_rastreamento"]);
                    row.oc_pos = read["opp_cliente"] + " - " + oc + "/" + pos;
                    row.pro_codigo = read["pro_codigo"].ToString();
                    row.pro_descricao = read["pro_descricao"].ToString();
                    row.idOrdemProducaoPostoTrabalho = Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]);

                    if (!leadTimes.ContainsKey(row.id_ordem_producao))
                    {
                        leadTimes.Add(row.id_ordem_producao, new leadTimeOpClass(row.id_ordem_producao));
                    }

                    DateTime? tempoSaida;
                    if (row["opt_tempo3"] != DBNull.Value)
                    {
                        tempoSaida = row.opt_tempo3;
                    }
                    else
                    {
                        if (row["opt_tempo2"] != DBNull.Value)
                        {
                            tempoSaida = row.opt_tempo2;
                        }
                        else
                        {
                            if (row.pos_acompanhamento_original == 1 && row["opt_tempo1"] != DBNull.Value)
                            {
                                tempoSaida = row.opt_tempo1;
                            }
                            else
                            {
                                tempoSaida = null;
                            }
                        }
                    }

                    DateTime? tempoEntrada;
                    if (row["opt_tempo1"] != DBNull.Value)
                    {
                        tempoEntrada = row.opt_tempo1;
                    }
                    else
                    {
                        tempoEntrada = null;
                    }

                    leadTimes[row.id_ordem_producao].addTempo(row.opt_sequencia, tempoEntrada, tempoSaida);                    
                    
                    ds.rastreabilidade.AddrastreabilidadeRow(row);

                    

                }
                read.Close();

                foreach (RastreabilidadeOPReportDataSet.rastreabilidadeRow row1 in ds.rastreabilidade.Rows)
                {
                    double? leadTime = leadTimes[row1.id_ordem_producao].getLeadTime();

                    if (leadTime != null)
                    {
                        row1.leadtime = ((double)leadTime).ToString("F2", CultureInfo.CurrentCulture) + " dias";
                    }
                    else
                    {
                        row1.leadtime = "";
                    }

                }



                command.CommandText =
                    "SELECT DISTINCT " +
                    "  public.ordem_producao_documento.opd_documento_tipo_tipo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_codigo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_revisao, " +
                    "  public.ordem_producao_documento.opd_documento_copia, " +
                    "  public.ordem_producao.id_ordem_producao " +
                    "FROM " +
                    "  public.ordem_producao_documento_op "+
                    "  INNER JOIN public.ordem_producao_documento ON (public.ordem_producao_documento_op.id_ordem_producao_documento = public.ordem_producao_documento.id_ordem_producao_documento) "+
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_documento_op.id_ordem_producao = public.ordem_producao.id_ordem_producao) "+
                    "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                    "  INNER JOIN public.order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "WHERE " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND                                                                                                         " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + pos + " AND "+
                    "  order_item_etiqueta.id_cliente =   " + idCliente + " " +
                    "ORDER BY " +
                    "  public.ordem_producao.id_ordem_producao, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_tipo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_codigo, " +
                    "  public.ordem_producao_documento.opd_documento_tipo_revisao, " +
                    "  public.ordem_producao_documento.opd_documento_copia ";

                read = command.ExecuteReader();

                RastreabilidadeOPReportDataSet.documentoRow rowDoc;
                while (read.Read())
                {
                    rowDoc = ds.documento.NewdocumentoRow();
                    rowDoc.documento = read["opd_documento_tipo_tipo"] + " " + read["opd_documento_tipo_codigo"] + " " + read["opd_documento_tipo_revisao"];
                    rowDoc.copia = read["opd_documento_copia"].ToString();
                    rowDoc.id_ordem_producao = Convert.ToInt32(read["id_ordem_producao"]);

                    ds.documento.AdddocumentoRow(rowDoc);
                }
                read.Close();

                command.CommandText =
                    "SELECT  DISTINCT " +
                    "  public.ordem_producao_historico.id_ordem_producao, " +
                    "  public.ordem_producao_historico.oph_data_hora, " +
                    "  public.acs_usuario.aus_name, " +
                    "  public.ordem_producao_historico.oph_historico " +
                    "FROM " +
                    "  public.ordem_producao_historico " +
                    "  INNER JOIN public.acs_usuario ON (public.ordem_producao_historico.id_acs_usuario = public.acs_usuario.id_acs_usuario) " +
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_historico.id_ordem_producao = public.ordem_producao.id_ordem_producao) " +
                    "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) " +
                    "  INNER JOIN public.order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "WHERE " +
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND                                                                                                         " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + pos + " AND " +
                    "  order_item_etiqueta.id_cliente =   " + idCliente + " " +
                    "ORDER BY " +
                    "  public.ordem_producao_historico.id_ordem_producao, " +
                    "  public.ordem_producao_historico.oph_data_hora, " +
                    "  public.ordem_producao_historico.oph_historico ";

                read = command.ExecuteReader();
                RastreabilidadeOPReportDataSet.op_historicoRow rowHis;
                while (read.Read())
                {
                    rowHis = ds.op_historico.Newop_historicoRow();
                    rowHis.id_ordem_producao = Convert.ToInt32(read["id_ordem_producao"]);
                    rowHis.data_hora = Convert.ToDateTime(read["oph_data_hora"]);
                    rowHis.historico = read["oph_historico"].ToString();
                    rowHis.usuario = read["aus_name"].ToString();

                    ds.op_historico.Addop_historicoRow(rowHis);
                }
                read.Close();


                command.CommandText =
                    "SELECT DISTINCT " +
                    "  public.ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho, "+
                    "  public.acs_usuario.aus_name, "+
                    "  public.ordem_producao_posto_trabalho_producao.opo_quantidade, "+
                    "  public.ordem_producao.id_ordem_producao, " +
                    "  public.ordem_producao_posto_trabalho_producao.opo_data_hora "+

                    "FROM "+
                    "  public.ordem_producao_posto_trabalho_producao "+
                    "  INNER JOIN public.ordem_producao_posto_trabalho ON (public.ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho = public.ordem_producao_posto_trabalho.id_ordem_producao_posto_trabalho) "+
                    "  INNER JOIN public.ordem_producao ON (public.ordem_producao_posto_trabalho.id_ordem_producao = public.ordem_producao.id_ordem_producao) "+
                    "  INNER JOIN public.ordem_producao_pedido ON (public.ordem_producao.id_ordem_producao = public.ordem_producao_pedido.id_ordem_producao) "+
                    "  INNER JOIN public.acs_usuario ON (public.ordem_producao_posto_trabalho_producao.id_acs_usuario = public.acs_usuario.id_acs_usuario) "+
                    "  INNER JOIN public.order_item_etiqueta ON ordem_producao_pedido.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta " +
                    "WHERE "+
                    "  public.ordem_producao_pedido.opp_order_number LIKE '" + oc + "' AND                                                                                                         " +
                    "  public.ordem_producao_pedido.opp_order_pos = " + pos + " AND " +
                    "  order_item_etiqueta.id_cliente =   " + idCliente + " AND " +
                    "  public.ordem_producao_posto_trabalho_producao.id_ordem_producao_posto_trabalho IN "+
                    "  ( " +
                    "       SELECT id_ordem_producao_posto_trabalho "+
                    "            FROM public.ordem_producao_posto_trabalho_producao " +
                    "            GROUP BY id_ordem_producao_posto_trabalho "+
                    "           HAVING count(id_ordem_producao_posto_trabalho) > 1 "+
                    "  ) "+
                    "ORDER BY "+
                    "  public.ordem_producao.id_ordem_producao, "+
                    "  public.ordem_producao_posto_trabalho_producao.opo_data_hora, "+
                    "  public.ordem_producao_posto_trabalho_producao.opo_quantidade ";

                read = command.ExecuteReader();
                RastreabilidadeOPReportDataSet.posto_trabalho_producaoRow rowProducao;
                while (read.Read())
                {
                    rowProducao = ds.posto_trabalho_producao.Newposto_trabalho_producaoRow();
                    rowProducao.idOrdemProducaoPostoTrabalho = Convert.ToInt32(read["id_ordem_producao_posto_trabalho"]);
                    rowProducao.data_hora = Convert.ToDateTime(read["opo_data_hora"]);
                    rowProducao.usuario = read["aus_name"].ToString();
                    rowProducao.quantidade = Convert.ToDouble(read["opo_quantidade"]);

                    ds.posto_trabalho_producao.Addposto_trabalho_producaoRow(rowProducao);
                }
                read.Close();


                RastreabilidadeOPReport toRet = new RastreabilidadeOPReport();
                toRet.SetDataSource(ds);
                return toRet;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o relatório de rastreabilidade.\r\n" + e.Message);
            }

        }

    }

    internal class leadTimeOpClass
    {
        int idOrdemProducao { get; set; }
        List<leadTimeOPRergistroClass> tempos { get; set; }

        public leadTimeOpClass(int idOrdemProducao)
        {
            this.idOrdemProducao = idOrdemProducao;
            this.tempos = new List<leadTimeOPRergistroClass>();
        }

        public void addTempo(int sequencia, DateTime? tempoEntrada, DateTime? tempoSaida)
        {
            this.tempos.Add(new leadTimeOPRergistroClass(sequencia, tempoEntrada, tempoSaida));
        }


        public double? getLeadTime()
        {
            if (this.tempos.Count > 0)
            {
                tempos.Sort();

                if (tempos[0].tempoEntrada != null && tempos[tempos.Count - 1].tempoSaida != null)
                {
                    TimeSpan? diferenca = tempos[tempos.Count - 1].tempoSaida.Value - tempos[0].tempoEntrada;
                    return diferenca.Value.TotalDays;
                }
            }

            return null;
        }



    }

    internal class leadTimeOPRergistroClass: IComparable
    {
        public int sequencia { get; private set; }
        public DateTime? tempoEntrada { get; private set; }
        public DateTime? tempoSaida { get; private set; }

        internal leadTimeOPRergistroClass(int sequencia, DateTime? tempoEntrada, DateTime? tempoSaida)
        {
            this.sequencia = sequencia;
            this.tempoEntrada = tempoEntrada;
            this.tempoSaida = tempoSaida;
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            return this.sequencia.CompareTo(((leadTimeOPRergistroClass)obj).sequencia);
        }

        #endregion
    }
}
