#region Referencias

using System;
using System.Collections.Generic;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    public class RelatorioPedidosProdutosTempClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        public RelatorioPedidosProdutosTempClass(IWTPostgreNpgsqlConnection conn)
        {
            this.conn = conn;
        }


        public List<PedidoRelatorioPedidosProdutosTempClass> gerarRelatorio()
        {
            try
            {
                List<int> produtosAdicionados = new List<int>();

                List<PedidoRelatorioPedidosProdutosTempClass> toRet = new List<PedidoRelatorioPedidosProdutosTempClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText =
                    "SELECT    " +
                    "  public.pedido_item.pei_numero,   " +
                    "  public.pedido_item.pei_posicao,   " +
                    "  public.pedido_item.pei_sub_linha,   " +
                    "  public.pedido_item.pei_quantidade,   " +
                    "  public.cliente.cli_nome_resumido,   " +
                    "  public.pedido_item.pei_data_entrega,   " +
                    "  public.pedido_item.pei_data_entrada, " +
                    "  public.pedido_item.pei_urgente,   " +
                    "  CASE pei_urgente WHEN 0 THEN 'Normal' WHEN 1 THEN 'Antecipação' WHEN 2 THEN 'Urgente' WHEN 3 THEN 'Crítico' END AS urgente,   " +
                    "  public.produto.pro_codigo,   " +
                    "  public.pedido_item.pei_produto_descricao_cliente,   " +
                    "  public.produto.id_produto,  " +
                    "  CASE WHEN pro_temporario = 1 THEN 'Cadastro Incompleto' WHEN pro_estrutura_em_revisao = 1 THEN 'Item em Revisão' ELSE '' END tipo   " +
                    "FROM   " +
                    "  public.pedido_item   " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente)   " +
                    "  INNER JOIN public.produto ON (public.pedido_item.id_produto = public.produto.id_produto)   " +
                    "  INNER JOIN ( " +
                    "     SELECT  " +
                    "       p.pei_numero,   " +
                    "       p.pei_posicao,  " +
                    "       p.id_cliente " +
                    "     FROM " +
                    "       pedido_item p " +
                    "     WHERE  " +
                    "       p.pei_sub_linha = 0 AND " +
                    "       (p.pei_status = 0 OR p.pei_status = 3) " +
                    "     ) as pedido_pai ON pedido_item.pei_numero = pedido_pai.pei_numero AND  " +
                    "     pedido_item.pei_posicao = pedido_pai.pei_posicao AND  " +
                    "     pedido_item.id_cliente = pedido_pai.id_cliente  " +
                    "WHERE   " +
                    "  (public.produto.pro_temporario = 1 OR public.produto.pro_estrutura_em_revisao = 1)   " +
                    "ORDER BY " +
                    "  public.pedido_item.pei_data_entrada, " +
                    "  public.pedido_item.pei_numero,   " +
                    "  public.pedido_item.pei_posicao,   " +
                    "  public.pedido_item.pei_sub_linha   ";


                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        int idProduto = Convert.ToInt32(read["id_produto"]);
                        if (produtosAdicionados.Contains(idProduto))
                        {
                            continue;
                        }
                        else
                        {
                            produtosAdicionados.Add(idProduto);
                        }

                        PedidoRelatorioPedidosProdutosTempClass item = new PedidoRelatorioPedidosProdutosTempClass
                                                                           {
                                                                               Numero = read["pei_numero"].ToString(),
                                                                               Pos = Convert.ToInt32(read["pei_posicao"]),
                                                                               Sublinha = Convert.ToInt32(read["pei_sub_linha"]),
                                                                               Cliente = read["cli_nome_resumido"].ToString(),
                                                                               Urgente = read["urgente"].ToString(),
                                                                               codigoItem = read["pro_codigo"].ToString(),
                                                                               descricaoItem = read["pei_produto_descricao_cliente"].ToString(),
                                                                               quantidadeItem = Convert.ToDouble(read["pei_quantidade"]),
                                                                               dataEntrada = Convert.ToDateTime(read["pei_data_entrada"]),
                                                                               dataEntrega = Convert.ToDateTime(read["pei_data_entrega"]),
                                                                               tipoPendencia = read["tipo"].ToString()
                                                                           };

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
                throw new Exception("Erro ao gerar o relatório de Pedidos com cadastro de Itens incompletos.\r\n" + e.Message, e);
            }
        }

    }

    public class PedidoRelatorioPedidosProdutosTempClass
    {
        public string Numero { get;  set; }
        public int Pos { get;  set; }
        public int Sublinha { get;  set; }
        public string Cliente { get;  set; }
        public string Urgente { get;  set; }
        public string codigoItem { get;  set; }
        public string descricaoItem { get;  set; }
        public double quantidadeItem { get;  set; }
        public DateTime dataEntrada { get;  set; }
        public DateTime dataEntrega { get;  set; }
        public double precoPedido { get;  set; }
        public string tipoPendencia { get;  set; }
        public string status { get; set; }


    }

}
