#region Referencias

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaGerenciamentoLog;
using BibliotecaProdutos;
using Configurations;
using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;

#endregion

namespace BibliotecaInterfaceModulosCliente
{
    public class InterfaceModulosCliente
    {
        readonly IWTPostgreNpgsqlConnection conn;
        readonly AcsUsuarioClass Usuario;

        public InterfaceModulosCliente(IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            this.conn = conn;
            this.Usuario = Usuario;
        }

        public int getCliente(string CNPJ)
        {
            try
            {
                IWTPostgreNpgsqlCommand command2 = this.conn.CreateCommand();
                command2.CommandText =
                    "SELECT  " +
                    "  public.cliente.id_cliente " +
                    "FROM " +
                    "  public.cliente " +
                    "WHERE " +
                    "  public.cliente.cli_cnpj LIKE '" + CNPJ.Trim() + "'OR " +
                    "  public.cliente.cli_cnpj LIKE '" + CNPJ.Trim().Replace(".", "").Replace("/", "").Replace("-", "") + "'";

                object tmp = command2.ExecuteScalar();

                if (tmp == null || tmp == DBNull.Value)
                {
                    throw new EasiException("Não foi possível encontrar o cliente para o cnpj " + CNPJ + ".");
                }
                else
                {
                    return (int)tmp;
                }
            }
            catch (EasiException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro inesperado ao identificar o cliente cadastrado.", e.Message);
            }
            
        }

        public long getProduto(long idCliente, string codigoProdutoCliente, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

                command.CommandText =
                    "SELECT  " +
                    "  public.cliente.id_familia_cliente " +
                    "FROM " +
                    "  public.cliente " +
                    "WHERE " +
                    "  public.cliente.id_cliente = " + idCliente.ToString() + ";";

                object tmp = command.ExecuteScalar();

                if (tmp == null || tmp == DBNull.Value)
                {
                    throw new EasiException("Não foi possível encontrar a familia do cliente para o id " + idCliente);
                }

                long idFamiliaCliente = Convert.ToInt64(tmp);

                command.CommandText =
                    "SELECT  " +
                    "  public.produto.id_produto " +
                    "FROM " +
                    "  public.produto " +
                    "WHERE " +
                    "  (UPPER(public.produto.pro_codigo_cliente) LIKE '" + codigoProdutoCliente.Trim().ToUpper() +
                    "' OR LOWER(public.produto.pro_codigo_cliente) LIKE '" + codigoProdutoCliente.Trim().ToLower() + "') AND  " +
                    "  (public.produto.id_familia_cliente = " + idFamiliaCliente.ToString() + " OR  " +
                    "  public.produto.id_familia_cliente IS NULL) ";

                tmp = command.ExecuteScalar();
                if (tmp == null || tmp == DBNull.Value)
                {
                    command.CommandText =
                     "SELECT  " +
                     "  public.produto.id_produto " +
                     "FROM " +
                     "  public.produto " +
                     "WHERE " +
                     "  (UPPER(public.produto.pro_codigo) LIKE '" + codigoProdutoCliente.Trim().ToUpper() +
                     "' OR LOWER(public.produto.pro_codigo) LIKE '" + codigoProdutoCliente.Trim().ToLower() + "')  ";

                    tmp = command.ExecuteScalar();

                    if (tmp == null || tmp == DBNull.Value)
                    {
                        return this.criaProdutoTemporario(idCliente, idFamiliaCliente, codigoProdutoCliente.Trim(), ref command);
                    }
                    else
                    {
                        throw new EasiException("Código interno do produto duplicado", "Já existe um produto com o mesmo código interno (" + codigoProdutoCliente + ") no sistema, mas ele não pode ser utilizado para esse pedido pois o código do cliente está incorreto ou pois o produto não está vinculado ao cliente do pedido.");
                    }
                }
                else
                {
                    return Convert.ToInt64(tmp);
                }
            }
            catch (EasiException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro ao identificar o produto cadastrado", e.Message);
            }

        }

        private long criaProdutoTemporario(long idCliente, long idFamiliaCliente, string codigoProdutoCliente, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                ProdutoClass produto = new ProdutoClass(this.Usuario, this.conn);
                produto.CodigoCliente = codigoProdutoCliente;
                if (codigoProdutoCliente.Length > 15)
                {
                    produto.Codigo = codigoProdutoCliente.Substring(0, 15);
                }
                else
                {
                    produto.Codigo = codigoProdutoCliente;
                }

                produto.Cliente = ClienteBaseClass.GetEntidade(idCliente, this.Usuario, this.conn);
                produto.FamiliaCliente = produto.Cliente.FamiliaCliente;
                produto.ModeloEtiquetaExpedicao = ModeloEtiquetaExpedicaoClass.GetEntidade(1, Usuario, command.Connection);

                produto.Temporario = true;

                produto.Save(ref command);

                return produto.ID;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro ao criar o produto temporário", e.Message);
            }

        }
       
        public DataSet getClienteList()
        {
            try
            {
                DataSet ds = new DataSet();
                string sql =

                    "SELECT  " +
                    "  public.cliente.id_cliente, " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.familia_cliente.fac_nome " +
                    "FROM " +
                    "  public.familia_cliente " +
                    "  JOIN public.cliente ON (public.familia_cliente.id_familia_cliente = public.cliente.id_familia_cliente) " +
                    "ORDER BY " +
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.familia_cliente.fac_nome ";                    


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    adapter.Fill(ds);

                }

                return ds;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro ao buscar a lista de clientes.", e.Message);
            }
        }

        public DataSet getOperacoesList()
        {
            try
            {
                string sql;
                DataSet ds = new DataSet();
                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    sql =
                        "SELECT                              " +
                        "  id_operacao_completa as id_operacao,                       " +
                        "  opc_identificacao as ope_descricao                    " +
                        "FROM                                " +
                        "  public.operacao_completa                    " +
                        "ORDER BY opc_descricao";
                }
                else
                {
                    sql =
                        "SELECT                              " +
                        "  id_operacao,                       " +
                        "  ope_descricao                     " +
                        "FROM                                " +
                        "  public.operacao                    " +
                        "ORDER BY ope_descricao";
                }
               


                IWTPostgreNpgsqlAdapter adapter = new IWTPostgreNpgsqlAdapter(sql, this.conn);
                if (adapter != null)
                {
                    adapter.Fill(ds);

                }

                return ds;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro ao buscar a lista de operações." , e.Message);
            }
        }

        public void inserirPedido(PedidoEasi Pedido, ref IWTPostgreNpgsqlCommand command, string descricaoModulo)
        {
            try
            {
                if (this.verificaExistenciaPedido(new long[] { Pedido.idCliente }, Pedido.Numero, Pedido.Posicao, ref command))
                {
                    throw new PedidoJaExistente(Pedido.Numero,Pedido.Posicao);
                }

                //Validação do preço. Valor zero deve ser alterado para 0,01
                if(Pedido.ItemPai.precoUnitario == 0)
                {
                    Pedido.ItemPai.precoUnitario = 0.01;
                }

                //identifica o cadastro do NCMs

                NcmClass ncm = (NcmClass) new NcmClass(Usuario,command.Connection).Search(new List<SearchParameterClass>()
                {
                    new SearchParameterClass("CodigoExato",Pedido.NBM),
                    new SearchParameterClass("ID",null,SearchOperacao.SomenteOrdenacao,SearchOrdenacao.Asc,TipoOrdenacao.Automatica)
                }).FirstOrDefault();

                long? idNcm = null;
                if (ncm != null)
                {
                    idNcm = ncm.ID;
                }

                command.CommandText =
                    "INSERT INTO " +
                    "  public.pedido_item " +
                    "( " +
                    "  pei_numero, " +
                    "  pei_posicao, " +
                    "  pei_sub_linha, " +
                    "  id_produto, " +
                    "  pei_produto_codigo_cliente, " +
                    "  pei_produto_descricao_cliente, " +
                    "  pei_projeto_cliente, " +
                    "  pei_quantidade, " +
                    "  pei_saldo, " +
                    "  pei_preco_unitario, " +
                    "  pei_preco_total, " +
                    "  id_cliente, " +
                    "  pei_cnpj_cliente, " +
                    "  pei_armazenagem_cliente, " +
                    "  pei_frete, " +
                    "  id_ncm, " +
                    "  pei_data_entrega, " +
                    "  pei_status, " +
                    "  pei_data_entrada, " +
                    "  id_operacao, " +
                    "  pei_permite_entrega_parcial, " +
                    "  pei_volume_unico, " +
                    "  pei_configurado, " +
                    "  pei_exportacao, " +
                    "  pei_preco_total_original, " +
                    "  id_acs_usuario_cancelamento, " +
                    "  pei_data_cancelamento, " +
                    "  pei_justificativa_cancelamento, " +
                    "  pei_data_configuracao, " +
                    "  pei_urgente, " +
                    "  pei_urgente_solicitante, " +
                    "  pei_urgente_data_prometida, " +
                    "  pei_urgente_informacoes_complementares, " +
                    "  pei_data_entrega_original, " +
                    "  pei_informacao_especial, " +
                    "  pei_data_ultima_alteracao, "+
                    "  id_pedido_item_pai, "+
                    "  pei_situacao_gad, "+
                    "  pei_situacao_gad_mensagem, " +
                    "  id_operacao_completa " +
                    ")  " +
                    "VALUES ( " +
                    "  :pei_numero, " +
                    "  :pei_posicao, " +
                    "  :pei_sub_linha, " +
                    "  :id_produto, " +
                    "  :pei_produto_codigo_cliente, " +
                    "  :pei_produto_descricao_cliente, " +
                    "  :pei_projeto_cliente, " +
                    "  :pei_quantidade, " +
                    "  :pei_saldo, " +
                    "  :pei_preco_unitario, " +
                    "  :pei_preco_total, " +
                    "  :id_cliente, " +
                    "  :pei_cnpj_cliente, " +
                    "  :pei_armazenagem_cliente, " +
                    "  :pei_frete, " +
                    "  :id_ncm, " +
                    "  :pei_data_entrega, " +
                    "  :pei_status, " +
                    "  :pei_data_entrada, " +
                    "  :id_operacao, " +
                    "  :pei_permite_entrega_parcial, " +
                    "  :pei_volume_unico, " +
                    "  :pei_configurado, " +
                    "  :pei_exportacao, " +
                    "  :pei_preco_total_original, " +
                    "  :id_acs_usuario_cancelamento, " +
                    "  :pei_data_cancelamento, " +
                    "  :pei_justificativa_cancelamento, " +
                    "  :pei_data_configuracao, " +
                    "  :pei_urgente, " +
                    "  :pei_urgente_solicitante, " +
                    "  :pei_urgente_data_prometida, " +
                    "  :pei_urgente_informacoes_complementares, " +
                    "  :pei_data_entrega_original, " +
                    "  :pei_informacao_especial, " +
                    "  :pei_data_ultima_alteracao, " +
                    "  :id_pedido_item_pai, " +
                    "  :pei_situacao_gad, " +
                    "  :pei_situacao_gad_mensagem," +
                    "  :id_operacao_completa " +
                    ") RETURNING id_pedido_item";


                //Insere o item Pai
                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_sub_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.subLinha;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idProduto;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.codigoProdutoCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.descricaoProdutoCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_projeto_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.projetoCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.Quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_saldo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.Quantidade;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.precoUnitario;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.precoTotal;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_cnpj_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.CNPJCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_armazenagem_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.armazenagemCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.Frete;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = idNcm;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.dataEntrega;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = 0;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_permite_entrega_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.permiteEntregaParcial);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_volume_unico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.volumeUnico);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_configurado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = 0;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_exportacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.Exportacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total_original", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.precoTotal;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_configuracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.Urgente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_solicitante", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.urgenteSolicitante;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_data_prometida", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.urgenteDataPrometida;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_informacoes_complementares", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = "";
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega_original", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.dataEntrega;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_informacao_especial", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.informacaoEspecial;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_ultima_alteracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = null;


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.SituacaoGad);

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad_mensagem", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = Pedido.SituacaoGadMensagem;

                if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                {
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Bigint));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idOperacao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                else
                {
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Bigint));
                    command.Parameters[command.Parameters.Count - 1].Value = null;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idOperacao;
                }
      

                Pedido.ItemPai.idPedidoItem = (int)command.ExecuteScalar();

                //Insere os filhos

                

                foreach (PedidoEasiItem item in Pedido.SubLinhas)
                {

                    if (item.Quantidade < 0.00001)
                    {
                        GerenciamentoLog.InserirLog(TipoLog.Aviso, this.Usuario.Login, descricaoModulo, "Item (" + item.codigoProdutoCliente + ") com quantidade zero ignorado no pedido número: " + Pedido.Numero + " posição: " + Pedido.Posicao,
                                                    command.Connection);
                        continue;
                    }

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_sub_linha", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = item.subLinha;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = item.idProduto;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_codigo_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = item.codigoProdutoCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_descricao_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = item.descricaoProdutoCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_projeto_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.projetoCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = item.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_saldo", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = item.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_unitario", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = item.precoUnitario;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = item.precoTotal;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_cnpj_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.CNPJCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_armazenagem_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.armazenagemCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_frete", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Frete;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = idNcm;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.dataEntrega;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_status", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = 0;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrada", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_permite_entrega_parcial", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.permiteEntregaParcial);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_volume_unico", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.volumeUnico);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_configurado", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = 0;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_exportacao", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.Exportacao);
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total_original", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = item.precoTotal;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_cancelamento", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_justificativa_cancelamento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_configuracao", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Urgente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_solicitante", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.urgenteSolicitante;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_data_prometida", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.urgenteDataPrometida;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_informacoes_complementares", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = "";
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega_original", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.dataEntrega;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_informacao_especial", NpgsqlDbType.Text));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.informacaoEspecial;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_ultima_alteracao", NpgsqlDbType.Timestamp));
                    command.Parameters[command.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item_pai", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idPedidoItem;

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad", NpgsqlDbType.Smallint));
                    command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(Pedido.SituacaoGad);

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad_mensagem", NpgsqlDbType.Text));
                    command.Parameters[command.Parameters.Count - 1].Value = null;


                    if (IWTConfiguration.Conf.getBoolConf(Constants.TRIBUTACAO_OPERACAO))
                    {
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Bigint));
                        command.Parameters[command.Parameters.Count - 1].Value = Pedido.idOperacao;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = null;
                    }
                    else
                    {
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Bigint));
                        command.Parameters[command.Parameters.Count - 1].Value = null;

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = Pedido.idOperacao;
                    }

                    item.idPedidoItem = (int)command.ExecuteScalar();

                }

                //Insere o Pedido Kit
                if (Pedido.tipoKit != null && Pedido.tipoKit.Trim().Length > 0)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.pedido_kit " +
                        "( " +
                        "  pek_oc, " +
                        "  pek_pos, " +
                        "  pek_tipo_kit, " +
                        "  id_cliente, " +
                        "  id_pedido_item " +
                        ")  " +
                        "VALUES ( " +
                        "  :pek_oc, " +
                        "  :pek_pos, " +
                        "  :pek_tipo_kit, " +
                        "  :id_cliente, " +
                        "  :id_pedido_item " +
                        ");";

                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pek_oc", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pek_pos", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pek_tipo_kit", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.tipoKit;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idPedidoItem;
                    command.ExecuteNonQuery();
                }

                //Insere as variaveis do Pedido
                command.CommandText =
                    "INSERT INTO  " +
                    "  public.pedido_variavel " +
                    "( " +
                    "  pev_pedido_numero, " +
                    "  pev_pedido_posicao, " +
                    "  id_cliente, " +
                    "  pev_codigo, " +
                    "  pev_valor, " +
                    "  id_pedido_item " +
                    ")  " +
                    "VALUES ( " +
                    "  :pev_pedido_numero, " +
                    "  :pev_pedido_posicao, " +
                    "  :id_cliente, " +
                    "  :pev_codigo, " +
                    "  :pev_valor, " +
                    "  :id_pedido_item " +
                    ");";
                foreach (PedidoEasiVariavel var in Pedido.VariaveisPedido)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_pedido_numero", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_pedido_posicao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = var.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pev_valor", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = var.Valor;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idPedidoItem;
                    command.ExecuteNonQuery();
                }


                command.CommandText =
                    "INSERT INTO  " +
                    "  public.pedido_item_variavel " +
                    "( " +
                    "  piv_pedido_numero, " +
                    "  piv_pedido_posicao, " +
                    "  id_cliente, " +
                    "  piv_sub_linha, " +
                    "  piv_codigo, " +
                    "  piv_valor, " +
                    "  id_pedido_item " +
                    ")  " +
                    "VALUES ( " +
                    "  :piv_pedido_numero, " +
                    "  :piv_pedido_posicao, " +
                    "  :id_cliente, " +
                    "  :piv_sub_linha, " +
                    "  :piv_codigo, " +
                    "  :piv_valor, " +
                    "  :id_pedido_item " +
                    ");";
                //Insere as variaveis do item pai
                foreach (PedidoEasiVariavel var in Pedido.ItemPai.VariaveisItem)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_pedido_numero", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_pedido_posicao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_sub_linha", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.subLinha;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = var.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_valor", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = var.Valor;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idPedidoItem;
                    command.ExecuteNonQuery();
                }

                //Insere as variaveis das sublinhas
                foreach (PedidoEasiItem item in Pedido.SubLinhas)
                {
                    if (item.Quantidade < 0.00001)
                    {
                        continue;
                    }
                    foreach (PedidoEasiVariavel var in item.VariaveisItem)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_pedido_numero", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = Pedido.Numero;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_pedido_posicao", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = Pedido.Posicao;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = Pedido.idCliente;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_sub_linha", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = item.subLinha;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_codigo", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = var.Codigo;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("piv_valor", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = var.Valor;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = item.idPedidoItem;
                        command.ExecuteNonQuery();
                    }

                }

                //Insere os documentos do item pai
                command.CommandText =
                    "INSERT INTO  " +
                    "  public.pedido_documento " +
                    "( " +
                    "  id_pedido_item, " +
                    "  peo_tipo, " +
                    "  peo_codigo, " +
                    "  peo_revisao " +
                    ")  " +
                    "VALUES ( " +
                    "  :id_pedido_item, " +
                    "  :peo_tipo, " +
                    "  :peo_codigo, " +
                    "  :peo_revisao " +
                    ");";

                foreach (PedidoEasiDocumento doc in Pedido.ItemPai.DocumentosItem)
                {
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = Pedido.ItemPai.idPedidoItem;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_tipo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = doc.Tipo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = doc.Codigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_revisao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = doc.Revisao;
                    command.ExecuteNonQuery();
                }

                //Insere os documentos das sublinhas
                foreach (PedidoEasiItem item in Pedido.SubLinhas)
                {
                    if (item.Quantidade < 0.00001)
                    {
                        continue;
                    }

                    foreach (PedidoEasiDocumento doc in item.DocumentosItem)
                    {
                        command.Parameters.Clear();
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = item.idPedidoItem;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_tipo", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = doc.Tipo;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_codigo", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = doc.Codigo;
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("peo_revisao", NpgsqlDbType.Varchar));
                        command.Parameters[command.Parameters.Count - 1].Value = doc.Revisao;
                        command.ExecuteNonQuery();
                    }
                }


                if (Pedido.Feedbacks.Count > 0)
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_item_feedback " +
                        "( " +
                        "   id_pedido_item, " +
                        "   id_acs_usuario, " +
                        "   pif_data, " +
                        "   pif_atual, " +
                        "   pif_texto " +
                        ") " +
                        "VALUES( " +
                        "   :id_pedido_item, " +
                        "   :id_acs_usuario, " +
                        "   :pif_data, " +
                        "   :pif_atual, " +
                        "   :pif_texto " +
                        "); ";

                    string feedbackInicial = Pedido.Feedbacks.Aggregate("", (acumulador, proximo) => acumulador + proximo + Environment.NewLine);
                    command.Parameters.Clear();
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item",NpgsqlDbType.Integer,Pedido.ItemPai.idPedidoItem));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer, Usuario.ID));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pif_data", NpgsqlDbType.Timestamp,DataIndependenteClass.GetData()));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pif_atual", NpgsqlDbType.Smallint,1));
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pif_texto", NpgsqlDbType.Text,feedbackInicial));

                    command.ExecuteNonQuery();
                }


            }
            catch (EasiException e)
            {
                throw e;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro inesperado ao salvar o pedido", e.Message);
            }

        }

        public void inserirPedidoRejeitado(PedidoEasiRejeitado PedidoRejeitado)
        {
            IWTPostgreNpgsqlConnection connIsolada = null;
            IWTPostgreNpgsqlCommand command2 = null;
            try
            {
                connIsolada = new IWTPostgreNpgsqlConnection(this.conn.ConnectionString);
                connIsolada.Open();

                command2 = connIsolada.CreateCommand();
                command2.Transaction = command2.Connection.BeginTransaction();

                command2.CommandText =
                    "INSERT INTO  " +
                    "  public.pedido_rejeitado " +
                    "( " +
                    "  per_nome_arquivo, " +
                    "  per_arquivo, " +
                    "  per_motivo_rejeicao, " +
                    "  per_observacao, " +
                    "  per_modulo_importador, " +
                    "  per_data_entrada, " +
                    "  per_data_ultimo_processamento, " +
                    "  per_tipo_arquivo " +
                    ")  " +
                    "VALUES ( " +
                    "  :per_nome_arquivo, " +
                    "  :per_arquivo, " +
                    "  :per_motivo_rejeicao, " +
                    "  :per_observacao, " +
                    "  :per_modulo_importador, " +
                    "  :per_data_entrada, " +
                    "  :per_data_ultimo_processamento, " +
                    "  :per_tipo_arquivo " +
                    ") RETURNING id_pedido_rejeitado; ";

                command2.Parameters.Clear();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_nome_arquivo", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.nomeArquivo;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_arquivo", NpgsqlDbType.Bytea));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.Arquivo;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_motivo_rejeicao", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.motivoRejeicao;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_observacao", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.Obs;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_modulo_importador", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.moduloImportador;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_data_entrada", NpgsqlDbType.Timestamp));
                command2.Parameters[command2.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_data_ultimo_processamento", NpgsqlDbType.Timestamp));
                command2.Parameters[command2.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_tipo_arquivo", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = PedidoRejeitado.tipoArquivo;
                command2.ExecuteNonQuery();

 command2.Transaction.Commit();
            }
            catch (Exception e)
            {
                 if (command2 != null && command2.Transaction!=null)
                {
                    command2.Transaction.Rollback();
                }
                throw new EasiException("Erro inesperado ao inserir o pedido rejeitado", e.Message);
            }
            finally
            {
                if (connIsolada != null)
                {
                    connIsolada.ForceClose();
                }
            }

        }

        public List<PedidoEasiRejeitado> getPedidosPendentes(string moduloImportador, string tipoArquivo=null)
        {
            IWTPostgreNpgsqlCommand command2 = null;
            try
            {
                List<PedidoEasiRejeitado> toRet = new List<PedidoEasiRejeitado>();
                command2 = this.conn.CreateCommand();
                command2.Transaction = command2.Connection.BeginTransaction();

                command2.CommandText =
                    "SELECT  " +
                    "  public.pedido_rejeitado.id_pedido_rejeitado, " +
                    "  public.pedido_rejeitado.per_nome_arquivo, " +
                    "  public.pedido_rejeitado.per_arquivo, " +
                    "  public.pedido_rejeitado.per_motivo_rejeicao, " +
                    "  public.pedido_rejeitado.per_observacao, " +
                    "  public.pedido_rejeitado.per_modulo_importador, " +
                    "  public.pedido_rejeitado.per_data_entrada, " +
                    "  public.pedido_rejeitado.per_data_ultimo_processamento " +
                    "FROM " +
                    "  public.pedido_rejeitado " +
                    "WHERE " +
                    "  public.pedido_rejeitado.per_modulo_importador LIKE '" + moduloImportador + "' ";
                
                if(tipoArquivo != null)
                {
                    command2.CommandText += " AND per_tipo_arquivo='" + tipoArquivo +"' ";
                }

                IWTPostgreNpgsqlDataReader read = command2.ExecuteReader();

                while (read.Read())
                {
                    PedidoEasiRejeitado ped = new PedidoEasiRejeitado();
                    ped.idPedidoRejeitado = Convert.ToInt32(read["id_pedido_rejeitado"]);
                    ped.nomeArquivo = read["per_nome_arquivo"].ToString();
                    ped.Arquivo = (byte[]) read["per_arquivo"];
                    ped.motivoRejeicao = read["per_motivo_rejeicao"].ToString();
                    ped.Obs = read["per_observacao"].ToString();
                    ped.moduloImportador = moduloImportador;
                    ped.dataEntrada = Convert.ToDateTime(read["per_data_entrada"]);
                    ped.dataUltimoProcessamento = Convert.ToDateTime(read["per_data_ultimo_processamento"]);
                    toRet.Add(ped);


                }
                read.Close();;

                command2.Transaction.Commit();

                return toRet;
            }
            catch (Exception e)
            {
                if (command2 != null && command2.Transaction != null)
                {
                    command2.Transaction.Rollback();
                }
                throw new EasiException("Erro inesperado ao carregar os pedidos rejeitados", e.Message);
            }

        }

        public void atualizaPedidoRejeitado(PedidoEasiRejeitado pedidoRejeitado)
        {
            IWTPostgreNpgsqlConnection connIsolada = null;

            IWTPostgreNpgsqlCommand command2 = null;
            try
            {
                connIsolada = new IWTPostgreNpgsqlConnection(this.conn.ConnectionString);
                connIsolada.Open();

                command2 = connIsolada.CreateCommand();
                command2.Transaction = command2.Connection.BeginTransaction();

                command2.CommandText =
                    "UPDATE  " +
                    "  public.pedido_rejeitado   " +
                    "SET  " +
                    "  per_motivo_rejeicao = :per_motivo_rejeicao, " +
                    "  per_observacao = :per_observacao, " +
                    "  per_data_ultimo_processamento = :per_data_ultimo_processamento " +
                    "WHERE  " +
                    "  id_pedido_rejeitado = :id_pedido_rejeitado " +
                    ";";

                command2.Parameters.Clear();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_motivo_rejeicao", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = pedidoRejeitado.motivoRejeicao;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_observacao", NpgsqlDbType.Varchar));
                command2.Parameters[command2.Parameters.Count - 1].Value = pedidoRejeitado.Obs;
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("per_data_ultimo_processamento", NpgsqlDbType.Timestamp));
                command2.Parameters[command2.Parameters.Count - 1].Value = Configurations.DataIndependenteClass.GetData();
                command2.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_rejeitado", NpgsqlDbType.Integer));
                command2.Parameters[command2.Parameters.Count - 1].Value = pedidoRejeitado.idPedidoRejeitado;

                command2.ExecuteNonQuery();

                command2.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command2 != null && command2.Transaction != null)
                {
                    command2.Transaction.Rollback();
                }
                throw new EasiException("Erro inesperado ao atualizar o pedido rejeitado id " + pedidoRejeitado.idPedidoRejeitado,
                                        e.Message);
            }
            finally
            {
                if (connIsolada != null )
                {
                    connIsolada.ForceClose();
                }
            }
        }

        public void excluirPedidoRejeitado(int idPedidoRejeitado)
        {
            IWTPostgreNpgsqlConnection connIsolada = null;
            IWTPostgreNpgsqlCommand command2 = null;
            try
            {
                connIsolada = new IWTPostgreNpgsqlConnection(this.conn.ConnectionString);
                connIsolada.Open();

                command2 = connIsolada.CreateCommand();
                command2.Transaction = command2.Connection.BeginTransaction();

                command2.CommandText =
                    "DELETE FROM  " +
                    "  public.pedido_rejeitado  " +
                    "WHERE  " +
                    "  id_pedido_rejeitado =  " + idPedidoRejeitado +
                    "; ";
                command2.ExecuteNonQuery();
                command2.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command2 != null && command2.Transaction != null)
                {
                    command2.Transaction.Rollback();
                }
                throw new EasiException("Erro inesperado ao excluir o pedido rejeitado id " + idPedidoRejeitado,
                                        e.Message);
            }
            finally
            {
                if (connIsolada != null)
                {
                    connIsolada.ForceClose();
                }
            }
        }

        public bool verificaExistenciaPedido(long[] idCliente, string Numero, int Posicao, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                string clienteClause = "";
                if (idCliente != null && idCliente.Length > 0)
                {
                    foreach (long i in idCliente)
                    {
                        if (String.IsNullOrEmpty(clienteClause))
                        {
                            clienteClause += " AND id_cliente IN ( " + i;   
                        }
                        else
                        {
                            clienteClause += " , " + i;    
                        }                        
                    }
                }
                else
                {
                    throw new EasiException("Cliente não identificado ao verificar a existência do pedido " + Numero + "/" + Posicao);
                }

                clienteClause += " ) ";


                //Verifica se o pedido já existe
                command.CommandText = "SELECT id_pedido_item FROM pedido_item WHERE pei_numero LIKE '" + Numero + "' AND pei_posicao = " + Posicao + "  " + clienteClause;
                object tmp = command.ExecuteScalar();
                if (tmp != null && tmp != DBNull.Value)
                {
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                throw new EasiException("Erro inesperado ao verificar se o pedido existe", e.Message);
            }


        }
    }
}
