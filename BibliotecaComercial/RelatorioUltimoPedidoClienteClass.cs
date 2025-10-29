using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaComercial
{
    class RelatorioUltimoPedidoClienteClass
    {

        public string nomeCliente { get; private set; }
        public Int32 qtdPedidos { get; private set; }
        public double valorTotalPedidos { get; private set; }
        public string dataUltimoPedido { get; private set; }
        public string dataEncerramentoUltimoPedido { get; private set; }
        public string projetoCliente { get; set; }

      

        public RelatorioUltimoPedidoClienteClass()
         {
             
         }

        public static List<RelatorioUltimoPedidoClienteClass> gerar(DateTime inicio, int? idRepresentante, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
                List<RelatorioUltimoPedidoClienteClass> toRet = new List<RelatorioUltimoPedidoClienteClass>();
                IWTPostgreNpgsqlCommand command = conn.CreateCommand();

                command.CommandText =

                    "    SELECT 	  " +
                    "        tab2.cli_nome_resumido as nome_cliente,                         " +
                    "        count(ped.id_pedido_item) as qtd_pedidos,                       " +
                    "        sum(ped.pei_preco_total) as valor_total_pedidos_periodo,        " +
                    "        tab2.pei_data_entrada as data_ultimo_pedido,                    " +
                    "        tab2.pei_data_encerramento as data_encerramento_ultimo_pedido,  " +
                    "        tab2.pei_projeto_cliente as projeto_cliente                         " +
                    "        FROM (                                                          " +
                    "           SELECT 	     tab.id_pedido_item,                             " +
                    "                        tab.id_cliente,                                 " +
                    "                        cliente.cli_nome_resumido,                      " +
                    "                        tab.pei_data_entrada,                           " +
                    "                        tab.pei_data_encerramento,                      " +
                    "                        tab.pei_projeto_cliente,                        " +
                    "                        tab.pei_preco_total,                            " +
                    "                        cliente.id_representante                        " +
                    "            FROM (                                                      " +
                    "                   SELECT  pedido_item.id_pedido_item,                  " +
                    "                            pedido_item.id_cliente,                     " +
                    "                           pedido_item.pei_data_entrada,                " +
                    "                           pedido_item.pei_data_encerramento,           " +
                    "                          pedido_item.pei_projeto_cliente,              " +
                    "                         pedido_item.pei_preco_total,                   " +
                    "                        rank() OVER w AS ran                            " +
                    "               FROM pedido_item                                         " +
                    "              WHERE pedido_item.pei_data_entrada > :data WINDOW w AS (PARTITION BY             " +
                    "             pedido_item.id_cliente                                                                   " +
                    "            ORDER BY pedido_item.pei_data_entrada DESC , pedido_item.id_pedido_item desc)             " +
                    "            ) tab                                                                                     " +
                    "        JOIN cliente ON tab.id_cliente = cliente.id_cliente                                           " +
                    "                WHERE tab.ran = 1                                                                           " +
                    "       ) tab2                                                                                              " +
                    "        INNER JOIN pedido_item as ped ON ped.id_cliente = tab2.id_cliente                                   " +
                    "        WHERE ped.pei_data_entrada > :data AND                                                       " +
                    "        CASE WHEN  :id_rep <> 0                                                                                   " +
                    "            THEN :id_rep = coalesce(ped.id_representante, tab2.id_representante)                                  " +
                    "            ELSE 1=1                                                                                        " +
                    "        END                                                                                                 " +
                    "        GROUP BY                                                                                            " +
                    "            tab2.id_pedido_item,                                                                            " +
                    "            tab2.id_cliente,                                                                                " +
                    "            tab2.cli_nome_resumido,                                                                         " +
                    "            tab2.pei_data_entrada,                                                                          " +
                    "            tab2.pei_data_encerramento,                                                                     " +
                    "            tab2.pei_projeto_cliente                                                                        " +
                    "        ORDER BY                                                                                            " +
                    "            valor_total_pedidos_periodo DESC                                                                          ";

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("data", NpgsqlDbType.Date));
                command.Parameters["data"].Value = inicio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_rep", NpgsqlDbType.Integer));
                command.Parameters["id_rep"].Value = idRepresentante.HasValue? idRepresentante : 0;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        RelatorioUltimoPedidoClienteClass item = new RelatorioUltimoPedidoClienteClass();

                        item.nomeCliente = read["nome_cliente"].ToString();
                        item.qtdPedidos = Int32.Parse(read["qtd_pedidos"].ToString());
                        item.valorTotalPedidos = double.Parse(read["valor_total_pedidos_periodo"].ToString());
                        item.dataUltimoPedido = Convert.ToDateTime(read["data_ultimo_pedido"]).ToString("dd/MM/yyyy");
                        item.dataEncerramentoUltimoPedido = read["data_encerramento_ultimo_pedido"] != DBNull.Value ? Convert.ToDateTime(read["data_encerramento_ultimo_pedido"]).Date.ToString("dd/MM/yyyy") : "";
                        item.projetoCliente = read["projeto_cliente"].ToString();
                       

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
                throw new Exception("Erro ao gerar o relatório de últimos pedidos de cliente.\r\n" + e.Message, e);
            }
        } 


    }
}
