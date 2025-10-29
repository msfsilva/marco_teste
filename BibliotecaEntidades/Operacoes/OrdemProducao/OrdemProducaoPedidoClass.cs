using System;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

namespace BibliotecaEntidades.Operacoes.OrdemProducao
{
    public class OrdemProducaoPedidoClass
    {
        public int? idOrdemProducaoPedido { get; private set; }
        public string orderNumber { get; private set; }
        public int orderPos { get; private set; }
        public string produtoCodigo { get; private set; }
        public string produtoDescricao { get; private set; }
        
        public string Variavel1 { get; private set; }
        public string valorVariavel1 { get; private set; }
        public string Variavel2 { get; private set; }
        public string valorVariavel2 { get; private set; }
        public string Variavel3 { get; private set; }
        public string valorVariavel3 { get; private set; }
        public string Variavel4 { get; private set; }
        public string valorVariavel4 { get; private set; }
        public double Quantidade { get; private set; }
        public string tipoDocumento { get; private set; }
        public string numeroDocumento { get; private set; }
        public string revisaoDocumento { get; private set; }
        public string SAF { get; private set; }
        public string CNC { get; private set; }
        public string tipoLigacao { get; private set; }
        public string produtoCodigoItemPai { get; private set; }
        public string produtoDescricaoItemPai { get; private set; }
        public string produtoAcabamentoItemPai { get; private set; }
        public int semanaEntrega { get; private set; }
        public string Cliente { get; private set; }
        public string Dimensao { get; private set; }
        public int? idOrderItemEtiqueta { get; private set; }

        private int _statusAtual;
        private bool statusAtualInitialized = false;
        public int StatusAtual
        {
            get
            {
                if (!this.statusAtualInitialized)
                {
                    this.loadStatusAtual();    
                }

                return _statusAtual;
            }
        }

        private DateTime _dataEntregaAtual;
        private bool dataEntregaAtualInitialized = false;
        public DateTime dataEntregaAtual
        {
            get
            {
                if (!this.dataEntregaAtualInitialized)
                {
                    this.loadStatusAtual();
                }

                return _dataEntregaAtual;
            }
        }

        private void loadStatusAtual()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.pedido_item.pei_status,  " +
                    "  public.pedido_item.pei_data_entrega " +
                    "FROM " +
                    "  public.ordem_producao_pedido " +
                    "  INNER JOIN public.order_item_etiqueta ON (public.ordem_producao_pedido.id_order_item_etiqueta = public.order_item_etiqueta.id_order_item_etiqueta) " +
                    "  INNER JOIN public.pedido_item ON (public.order_item_etiqueta.id_cliente = public.pedido_item.id_cliente) " +
                    "  AND (public.order_item_etiqueta.oie_order_number = public.pedido_item.pei_numero) " +
                    "  AND (public.order_item_etiqueta.oie_order_pos = public.pedido_item.pei_posicao) " +
                    "WHERE " +
                    "  public.pedido_item.pei_sub_linha = 0 AND  " +
                    "  public.pedido_item.pei_numero LIKE '" + this.orderNumber + "' AND " +
                    "  public.pedido_item.pei_posicao = " + this.orderPos.ToString() + " AND " +
                    "  public.ordem_producao_pedido.id_ordem_producao_pedido = " + this.idOrdemProducaoPedido + ";";

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                if (read.HasRows)
                {

                    read.Read();
                    this.statusAtualInitialized = true;
                    this.dataEntregaAtualInitialized = true;

                    this._statusAtual = Convert.ToInt32(read["pei_status"]);
                    this._dataEntregaAtual = Convert.ToDateTime(read["pei_data_entrega"]);
                }

                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o status atual do pedido.\r\n" + e.Message);
            }
        }

        private readonly IWTPostgreNpgsqlConnection conn;
        private readonly OrdemProducaoClass Parent;

        public bool toDelete { get; private set; }

        public OrdemProducaoPedidoClass(int? idOrdemProducaoPedido, string orderNumber, int orderPos, string produtoCodigo, string produtoDescricao,
                                        string Variavel1, string valorVariavel1, string Variavel2, string valorVariavel2, string Variavel3, string valorVariavel3, string Variavel4,
                                        string valorVariavel4, double Quantidade, string tipoDocumento, string numeroDocumento, string revisaoDocumento, string SAF, string CNC,
                                        string tipoLigacao, string produtoCodigoItemPai,string produtoDescricaoItemPai,string produtoAcabamentoItemPai ,  int semanaEntrega, string Cliente,
                                        string Dimensao, int? idOrderItemEtiqueta,
                                        OrdemProducaoClass Parent, IWTPostgreNpgsqlConnection conn
            )
        {
            this.idOrdemProducaoPedido = idOrdemProducaoPedido;
            this.orderNumber = orderNumber;
            this.orderPos = orderPos;
            this.produtoCodigo = produtoCodigo;
            this.produtoDescricao = produtoDescricao;
            this.Variavel1 = Variavel1;
            this.valorVariavel1 = valorVariavel1;
            this.Variavel2 = Variavel2;
            this.valorVariavel2 = valorVariavel2;
            this.Variavel3 = Variavel3;
            this.valorVariavel3 = valorVariavel3;
            this.Variavel4 = Variavel4;
            this.valorVariavel4 = valorVariavel4;
            this.Quantidade = Quantidade;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.revisaoDocumento = revisaoDocumento;
            this.SAF = SAF;
            this.CNC = CNC;
            this.tipoLigacao = tipoLigacao;
            this.produtoCodigoItemPai = produtoCodigoItemPai;
            this.produtoDescricaoItemPai = produtoDescricaoItemPai;
            this.produtoAcabamentoItemPai = produtoAcabamentoItemPai;
            this.semanaEntrega = semanaEntrega;
            this.Cliente = Cliente;
            this.Dimensao = Dimensao;
            this.idOrderItemEtiqueta = idOrderItemEtiqueta;

            this.conn = conn;
            this.Parent = Parent;

            this.toDelete = false;
        }

        public void Delete()
        {
            this.toDelete = true;
        }

        public void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (toDelete)
                {
                    if (idOrdemProducaoPedido != null)
                    {
                        command.CommandText =
                            "DELETE FROM  " +
                            "  public.ordem_producao_pedido  " +
                            "WHERE  " +
                            "  id_ordem_producao_pedido = :id_ordem_producao_pedido " +
                            "; ";

                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_pedido", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPedido;
                        command.ExecuteNonQuery();
                    }
                }
                else
                {
                    if (this.idOrdemProducaoPedido == null)
                    {
                        command.CommandText =
                            "INSERT INTO  " +
                            "  public.ordem_producao_pedido " +
                            "( " +
                            "  id_ordem_producao, " +
                            "  opp_produto_codigo, " +
                            "  opp_produto_descricao, " +
                            "  opp_order_number, " +
                            "  opp_order_pos, " +
                            "  opp_variavel_1, " +
                            "  opp_valor_variavel_1, " +
                            "  opp_variavel_2, " +
                            "  opp_valor_variavel_2, " +
                            "  opp_variavel_3, " +
                            "  opp_valor_variavel_3, " +
                            "  opp_variavel_4, " +
                            "  opp_valor_variavel_4, " +
                            "  opp_quantidade, " +
                            "  opp_tipo_documento, " +
                            "  opp_numero_documento, " +
                            "  opp_saf, " +
                            "  opp_cnc, " +
                            "  opp_tipo_ligacao, " +
                            "  opp_produto_codigo_pai, " +
                            "  opp_produto_acabamento_pai, "+
                            "  opp_produto_descricao_pai, "+
                            "  opp_cliente, " +
                            "  opp_semana_entrega, " +
                            "  opp_revisao_documento, " +
                            "  opp_dimensao, " +
                            "  id_order_item_etiqueta "+
                            ")  " +
                            "VALUES ( " +
                            "  :id_ordem_producao, " +
                            "  :opp_produto_codigo, " +
                            "  :opp_produto_descricao, " +
                            "  :opp_order_number, " +
                            "  :opp_order_pos, " +
                            "  :opp_variavel_1, " +
                            "  :opp_valor_variavel_1, " +
                            "  :opp_variavel_2, " +
                            "  :opp_valor_variavel_2, " +
                            "  :opp_variavel_3, " +
                            "  :opp_valor_variavel_3, " +
                            "  :opp_variavel_4, " +
                            "  :opp_valor_variavel_4, " +
                            "  :opp_quantidade, " +
                            "  :opp_tipo_documento, " +
                            "  :opp_numero_documento, " +
                            "  :opp_saf, " +
                            "  :opp_cnc, " +
                            "  :opp_tipo_ligacao, " +
                            "  :opp_produto_codigo_pai, " +
                            "  :opp_produto_acabamento_pai, " +
                            "  :opp_produto_descricao_pai, " +
                            "  :opp_cliente, " +
                            "  :opp_semana_entrega, " +
                            "  :opp_revisao_documento, " +
                            "  :opp_dimensao, " +
                            "  :id_order_item_etiqueta " +
                            ") RETURNING id_ordem_producao_pedido;";
                    }
                    else
                    {
                        command.CommandText =
                            "UPDATE  " +
                            "  public.ordem_producao_pedido   " +
                            "SET  " +
                            "  id_ordem_producao = :id_ordem_producao, " +
                            "  opp_produto_codigo = :opp_produto_codigo, " +
                            "  opp_produto_descricao = :opp_produto_descricao, " +
                            "  opp_order_number = :opp_order_number, " +
                            "  opp_order_pos = :opp_order_pos, " +
                            "  opp_variavel_1 = :opp_variavel_1, " +
                            "  opp_valor_variavel_1 = :opp_valor_variavel_1, " +
                            "  opp_variavel_2 = :opp_variavel_2, " +
                            "  opp_valor_variavel_2 = :opp_valor_variavel_2, " +
                            "  opp_variavel_3 = :opp_variavel_3, " +
                            "  opp_valor_variavel_3 = :opp_valor_variavel_3, " +
                            "  opp_variavel_4 = :opp_variavel_4, " +
                            "  opp_valor_variavel_4 = :opp_valor_variavel_4, " +
                            "  opp_quantidade = :opp_quantidade, " +
                            "  opp_tipo_documento = :opp_tipo_documento, " +
                            "  opp_numero_documento = :opp_numero_documento, " +
                            "  opp_saf = :opp_saf, " +
                            "  opp_cnc = :opp_cnc, " +
                            "  opp_tipo_ligacao = :opp_tipo_ligacao, " +
                            "  opp_produto_codigo_pai = :opp_produto_codigo_pai, " +
                            "  opp_produto_acabamento_pai = :opp_produto_acabamento_pai, " +
                            "  opp_produto_descricao_pai = :opp_produto_descricao_pai, " +
                            "  opp_cliente = :opp_cliente, " +
                            "  opp_semana_entrega = :opp_semana_entrega, " +
                            "  opp_revisao_documento = :opp_revisao_documento, " +
                            "  opp_dimensao = :opp_dimensao, " +
                            "  id_order_item_etiqueta = :id_order_item_etiqueta "+
                            "WHERE  " +
                            "  id_ordem_producao_pedido = :id_ordem_producao_pedido " +
                            "RETURNING  id_ordem_producao_pedido;";
                    }

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_pedido", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrdemProducaoPedido;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Parent.idOrdemProducao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_codigo", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.produtoCodigo;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_descricao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.produtoDescricao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_number", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.orderNumber;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_order_pos", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.orderPos;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_1", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Variavel1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_1", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorVariavel1;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_2", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Variavel2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_2", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorVariavel2;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_3", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Variavel3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_3", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorVariavel3;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_variavel_4", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Variavel4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_valor_variavel_4", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.valorVariavel4;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_quantidade", NpgsqlDbType.Double));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Quantidade;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_tipo_documento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.tipoDocumento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_numero_documento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.numeroDocumento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_saf", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.SAF;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_cnc", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.CNC;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_tipo_ligacao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.tipoLigacao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_codigo_pai", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.produtoCodigoItemPai;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_acabamento_pai", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.produtoAcabamentoItemPai;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_produto_descricao_pai", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.produtoDescricaoItemPai;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_cliente", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Cliente;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_semana_entrega", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.semanaEntrega;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_revisao_documento", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.revisaoDocumento;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opp_dimensao", NpgsqlDbType.Varchar));
                    command.Parameters[command.Parameters.Count - 1].Value = this.Dimensao;
                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.idOrderItemEtiqueta;
                    

                    this.idOrdemProducaoPedido = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o Pedido.\r\n" + e.Message);
            }
        }

        public override string ToString()
        {
            return this.orderNumber + "/" + this.orderPos;
        }
    }
}