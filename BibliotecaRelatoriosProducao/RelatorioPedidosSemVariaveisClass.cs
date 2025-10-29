#region Referencias

using System;
using System.Collections.Generic;
using BibliotecaEntidades.ClassesAuxiliares;
using BibliotecaEntidades.Operacoes.Configurador;
using BibliotecaPedidos;
using IWTDotNetLib.ComplexLoginModule;
using IWTPostgreNpgsql;
using Npgsql;

#endregion

namespace BibliotecaRelatoriosProducao
{
    internal class RelatorioPedidosSemVariaveisClass
    {
        readonly IWTPostgreNpgsqlConnection conn;
        private IConfiguradorEASIFactory configuradorEasiFactory;
        internal RelatorioPedidosSemVariaveisClass(IWTPostgreNpgsqlConnection conn, IConfiguradorEASIFactory configuradorEasiFactory)
        {
            this.conn = conn;
            this.configuradorEasiFactory = configuradorEasiFactory;


        }


        internal List<PedidosSemVariaveisClass> gerarRelatorio()
        {
            try
            {
                List<PedidosSemVariaveisClass> toRet = new List<PedidosSemVariaveisClass>();
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                command.CommandText =
                    "SELECT  " +
                    "  public.pedido_item.id_pedido_item, " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.pedido_item.pei_sub_linha, " +
                    "  public.pedido_item.id_produto, " +
                    "  public.pedido_item.pei_quantidade, " +
                    "  public.pedido_item.id_cliente, " +
                    "  public.pedido_item.pei_data_entrada, " +
                    "  public.pedido_item.pei_data_entrega, " +
                    "  public.produto.pro_versao_estrutura_atual, "+
                    "  public.produto.pro_codigo, " +
                    "  public.produto.pro_descricao, " +
                    "  public.cliente.cli_nome_resumido "+
                    "FROM " +
                    "  public.pedido_item " +
                    "  INNER JOIN produto ON produto.id_produto = pedido_item.id_produto "+
                    "  INNER JOIN cliente ON cliente.id_cliente = pedido_item.id_cliente " +
                    "WHERE " +
                    "  public.pedido_item.pei_configurado = 0 AND " +
                    "  (public.pedido_item.pei_status = 0 OR public.pedido_item.pei_status = 3) ";
                
                 IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                 while (read.Read())
                 {

                     PedidosSemVariaveisClass pedido = new PedidosSemVariaveisClass(
                         read["pei_numero"].ToString(),
                         Convert.ToInt32(read["pei_posicao"]),
                         Convert.ToInt32(read["pei_sub_linha"]),
                         read["pro_codigo"].ToString(),
                         read["pro_descricao"].ToString(),
                         Convert.ToDouble(read["pei_quantidade"]),
                         read["cli_nome_resumido"].ToString(),
                         Convert.ToDateTime(read["pei_data_entrada"]),
                         Convert.ToDateTime(read["pei_data_entrega"])
                         );

                     List<string> variaveisNecessarias = this.getVariaveisNecessarias(
                         Convert.ToInt32(read["id_produto"]),
                         Convert.ToInt32(read["pro_versao_estrutura_atual"]));

                     Dictionary<string, Variavel> variaveisDisponiveis = this.getVariaveisPedido(
                         pedido.OC,
                         pedido.Pos,
                         pedido.Sublinha,
                         read["id_cliente"].ToString());

                  
                     foreach (string var in variaveisNecessarias)
                     {
                         if (!variaveisDisponiveis.ContainsKey(var))
                         {
                             pedido.variaveisFaltando.Add(var);
                         }
                     }

                     if (pedido.variaveisFaltando.Count > 0)
                     {
                         toRet.Add(pedido);
                     }
                 }

                 return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao gerar o relatório de pedidos sem variáveis.\r\n" + e.Message, e);
            }
        }

        private List<string> getVariaveisNecessarias(int idProduto, int revisaoEstrutura)
        {
            try
            {
                List<string> toRet = new List<string>();

                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  var1.var_nome as nomeVar1, "+
                    "  var2.var_nome as nomeVar2, " +
                    "  var3.var_nome as nomeVar3, " +
                    "  var4.var_nome as nomeVar4 " +
                    "FROM "+
                    "  public.produto "+
                    "  LEFT JOIN public.variavel var1 ON (public.produto.id_variavel_1 = var1.id_variavel) "+
                    "  LEFT JOIN public.variavel var2 ON (public.produto.id_variavel_2 = var2.id_variavel) "+
                    "  LEFT JOIN public.variavel var3 ON (public.produto.id_variavel_3 = var3.id_variavel) "+
                    "  LEFT JOIN public.variavel var4 ON (public.produto.id_variavel_4 = var4.id_variavel) "+
                    "WHERE "+
                    "  public.produto.id_produto = " + idProduto + " ";
                 IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                 if (!read.HasRows)
                 {
                     throw new Exception("ID Inválido");
                 }
                 read.Read();
                 if (read["nomeVar1"] != DBNull.Value)
                 {
                     toRet.Add(read["nomeVar1"].ToString().ToUpper());
                 }

                 if (read["nomeVar2"] != DBNull.Value)
                 {
                     toRet.Add(read["nomeVar2"].ToString().ToUpper());

                 }

                 if (read["nomeVar3"] != DBNull.Value)
                 {
                     toRet.Add(read["nomeVar3"].ToString().ToUpper());

                 }

                 if (read["nomeVar4"] != DBNull.Value)
                 {
                     toRet.Add(read["nomeVar4"].ToString().ToUpper());

                 }
                 read.Close();

                 command.CommandText =
                     "SELECT  " +
                     "  public.produto_pai_filho.id_produto_filho, " +
                     "  public.produto_pai_filho.ppf_versao_estrutura_filho " +
                     "FROM " +
                     "  public.produto_pai_filho " +
                     "WHERE " +
                     "  public.produto_pai_filho.id_produto_pai = " + idProduto + " AND " +
                     "  public.produto_pai_filho.ppf_versao_estrutura = " + revisaoEstrutura + " ";
                 read = command.ExecuteReader();

                 while (read.Read())
                 {
                     List<string> tmp = this.getVariaveisNecessarias(
                         Convert.ToInt32(read["id_produto_filho"]),
                         Convert.ToInt32(read["ppf_versao_estrutura_filho"])
                         );

                     foreach (string var in tmp)
                     {
                         if (!toRet.Contains(var))
                         {
                             toRet.Add(var);
                         }
                     }

                 }

                 read.Close();

                 return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao idenficar as variáveis necessárias para o pedido.\r\n" + e.Message, e);
            }
        }

        private Dictionary<string, Variavel> getVariaveisPedido(string oc, int pos, int subLinha, string idCliente)
        {
            try
            {
                IConfiguradorEASI conf = this.configuradorEasiFactory.getInstance(this.conn,LoginClass.LogById(LoginClass.UsuarioLogado.loggedUser.ID,conn,true).loggedUser, null, null);
                Dictionary<string, Variavel> toRet = conf.getVariaveis(oc, pos, idCliente,PedidoOrcamento.Pedido);

                Dictionary<string, Variavel> tmp = conf.getVariaveisItem(oc, pos, idCliente, subLinha, PedidoOrcamento.Pedido);

                foreach (KeyValuePair<string, Variavel> var in tmp)
                {
                    if (!toRet.ContainsKey(var.Key))
                    {
                        toRet.Add(var.Key, var.Value);
                    }
                }

                return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao buscar as variáveis do pedido.\r\n" + e.Message, e);
            }
        }
    }

    internal class PedidosSemVariaveisClass
    {
        public string OC { get; private set; }
        public int Pos { get; private set; }
        public int Sublinha { get; private set; }
        public string codProduto { get; private set; }
        public string descProduto { get; private set; }
        public double Quantidade { get; private set; }
        public string Cliente { get; private set; }
        public DateTime dataEntrada { get; private set; }
        public DateTime dataEntrega { get; private set; }

        public string variaveisF
        {
            get
            {
                string toRet = "";
                foreach (string var in this.variaveisFaltando)
                {
                    toRet += " / " + var;
                }

                if (toRet.Length > 0)
                {
                    toRet = toRet.Substring(3);
                }

                return toRet;
            }
        }

        internal List<string> variaveisFaltando;

        public PedidosSemVariaveisClass(
            string OC, int Pos, int Sublinha, string codProduto, string descProduto, double Quantidade,
            string Cliente, DateTime dataEntrada, DateTime dataEntrega)
        {
            this.OC = OC;
            this.Pos = Pos;
            this.Sublinha = Sublinha;
            this.codProduto = codProduto;
            this.descProduto = descProduto;
            this.Quantidade = Quantidade;
            this.Cliente = Cliente;
            this.dataEntrada = dataEntrada;
            this.dataEntrega = dataEntrega;

            this.variaveisFaltando = new List<string>();
        }



    }

    
}
