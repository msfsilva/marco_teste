#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public class RelatorioPedidoDataEntradaClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public RelatorioPedidoDataEntradaClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }

        internal List<PedidoRelatorioPedidosProdutosTempClass> gerarRelatorio(DateTime? Inicio, DateTime? Fim, bool incluirCancelados, bool ordernarDataEntrega)
        {
            try
            {
                List<PedidoRelatorioPedidosProdutosTempClass> toRet = new List<PedidoRelatorioPedidosProdutosTempClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText =

                    "SELECT  " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_sub_linha, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.produto.pro_codigo, " +
                    "  public.pedido_item.pei_produto_descricao_cliente, " +
                    "  CASE pei_urgente WHEN 0 THEN 'Normal' WHEN 1 THEN 'Antecipação' WHEN 2 THEN 'Urgente' WHEN 3 THEN 'Crítico' END AS urgente, " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.pedido_item.pei_data_entrega, " +
                    "  DATE(public.pedido_item.pei_data_entrada) as data_entrada, " +
                    "  public.pedido_item.pei_preco_total, "+
                    "  public.pedido_item.pei_status "+
                    "FROM " +
                    "  public.pedido_item " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) " +
                    "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto) " +
                    "WHERE " +
                    "  public.pedido_item.pei_sub_linha = 0  ";

                if (!incluirCancelados)
                {
                    command.CommandText += " AND public.pedido_item.pei_status <> 2 ";
                }

                if (Inicio != null)
                {
                    command.CommandText += " AND pei_data_entrada >= '" + Inicio.Value.ToString("yyyy-MM-dd") + "' ";
                }

                if (Fim != null)
                {
                    command.CommandText += " AND pei_data_entrada < '" + Fim.Value.AddDays(1).Date.ToString("yyyy-MM-dd") + "' ";
                }

                /*if (whereClause.Length > 0)
                {
                    command.CommandText += " WHERE " + whereClause.Substring(4) + " ";
                }*/

                command.CommandText +=
                    "ORDER BY "+
                    "  DATE(public.pedido_item.pei_data_entrada), ";

                if (ordernarDataEntrega)
                {
                    command.CommandText +=
                        "  public.pedido_item.pei_data_entrega, " +
                        "  public.produto.pro_codigo ";

                }
                else
                {
                    command.CommandText +=
                        "  public.cliente.cli_nome_resumido, " +
                        "  public.pedido_item.pei_numero, " +
                        "  public.pedido_item.pei_posicao ";
                }

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {



                    while (read.Read())
                    {
                        PedidoRelatorioPedidosProdutosTempClass item = new PedidoRelatorioPedidosProdutosTempClass();

                        item.Numero = read["pei_numero"].ToString();
                        item.Pos = Convert.ToInt32(read["pei_posicao"]);
                        item.Sublinha = Convert.ToInt32(read["pei_sub_linha"]);
                        item.Cliente = read["cli_nome_resumido"].ToString();
                        item.Urgente = read["urgente"].ToString();
                        item.codigoItem = read["pro_codigo"].ToString();
                        item.descricaoItem = read["pei_produto_descricao_cliente"].ToString();
                        item.quantidadeItem = Convert.ToDouble(read["pei_quantidade"]);
                        item.dataEntrada = Convert.ToDateTime(read["data_entrada"]);
                        item.dataEntrega = Convert.ToDateTime(read["pei_data_entrega"]);
                        item.precoPedido = Convert.ToDouble(read["pei_preco_total"]);
                        

                        switch (Convert.ToInt16(read["pei_status"]))
                        {
                            case 0:
                                item.status = "P";
                                break;
                            case 1:
                                item.status = "E";
                                break;
                            case 2:
                                item.status = "C";
                                break;
                            case 3:
                                item.status = "R";
                                break;
                            case 4:
                                item.status = "S";
                                break;

                        }

                        toRet.Add(item);
                    }
                    read.Close();
                }
                else
                {
                    throw new Exception("Não existem pedidos para os parâmetros selecionados.");
                }

               

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de pedidos com produtos temporários.\r\n" + e.Message, e);
            }
        }
    }


}
