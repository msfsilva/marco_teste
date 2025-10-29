#region Referencias

using System;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaGerenciamentoND
{
    public class NotificacaoDesvioClass
    {
        public int? ID { get; private set; }
        public int idPedidoItem { get; private set; }
        public string OC { get; private set; }
        public string Pos { get; private set; }
        public int idCliente { get; private set; }
        public string cliNomeResumido { get; private set; }

        public string Numero { get; internal set; }

        public int idTipoNotificacaoDesvio { get; private set; }
        public string tipoNotificacaoDesvio { get; private set; }

        public DateTime Data { get; internal set; }
        public string defeitoDescricao { get; internal set; }
        
        public int? idTipoDefeito { get; private set; }
        public string tipoDefeito { get; private set; }

        public int? idPostoTrabalho { get; private set; }
        public string postoTrabalho { get; private set; }

        public double qtdPecasDefeituosas { get; internal set; }
        public double qtdPecasDevolvidas { get; internal set; }
        public string nfClienteNumero { get; internal set; }
        public DateTime? nfClienteData { get; internal set; }
        public double? nfClienteValor { get; internal set; }
        public string justificativaProducao { get; internal set; }

        public byte[] DocumentoScaneado { get; private set; }
        public string DocumentoScaneadoNome { get; private set; }


        public AcsUsuarioClass usuarioNotificacao { get; private set; }
        public AcsUsuarioClass usuarioAtual { get; private set; }

        readonly IWTPostgreNpgsqlConnection conn;

        public NotificacaoDesvioClass(int? idNotificacaoDesvio, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass Usuario)
        {
            try
            {
                this.usuarioNotificacao = Usuario;
                this.usuarioAtual = Usuario;

                this.conn = conn;

                if (idNotificacaoDesvio != null)
                {
                    this.ID = idNotificacaoDesvio;
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    command.CommandText =
                    "SELECT  " +
                    "  public.notificacao_desvio.id_notificacao_desvio, " +
                    "  public.notificacao_desvio.id_pedido_item, " +
                    "  public.notificacao_desvio.nod_numero, " +
                    "  public.notificacao_desvio.id_tipo_notificacao_desvio, " +
                    "  public.notificacao_desvio.nod_data, " +
                    "  public.notificacao_desvio.nod_descricao_defeito, " +
                    "  public.notificacao_desvio.id_tipo_defeito, " +
                    "  public.notificacao_desvio.id_posto_trabalho, " +
                    "  public.notificacao_desvio.nod_qtd_pecas_defeituosas, " +
                    "  public.notificacao_desvio.nod_qtd_pecas_devolvidas, " +
                    "  public.notificacao_desvio.nod_numero_nf_cliente, " +
                    "  public.notificacao_desvio.nod_data_emissao_nf_cliente, " +
                    "  public.notificacao_desvio.nod_valor_nf_cliente, " +
                    "  public.notificacao_desvio.nod_justificativa_producao, " +
                    "  public.notificacao_desvio.id_acs_usuario_notificacao, " +
                    "  public.pedido_item.pei_numero, " +
                    "  public.pedido_item.pei_posicao, " +
                    "  public.tipo_defeito.tde_identificacao, " +
                    "  public.tipo_notificacao_desvio.tnd_identificacao, " +
                    "  public.posto_trabalho.pos_codigo, " +
                    "  public.pedido_item.id_cliente, "+
                    "  public.cliente.cli_nome_resumido, " +
                    "  public.notificacao_desvio.nod_documento, "+
                    "  public.notificacao_desvio.nod_documento_nome "+
                    "FROM " +
                    "  public.notificacao_desvio " +
                    "  INNER JOIN public.pedido_item ON (public.notificacao_desvio.id_pedido_item = public.pedido_item.id_pedido_item) " +
                    "  LEFT OUTER JOIN public.tipo_defeito ON (public.notificacao_desvio.id_tipo_defeito = public.tipo_defeito.id_tipo_defeito) " +
                    "  INNER JOIN public.tipo_notificacao_desvio ON (public.notificacao_desvio.id_tipo_notificacao_desvio = public.tipo_notificacao_desvio.id_tipo_notificacao_desvio) " +
                    "  LEFT OUTER JOIN public.posto_trabalho ON (public.notificacao_desvio.id_posto_trabalho = public.posto_trabalho.id_posto_trabalho) " +
                    "  INNER JOIN public.cliente ON (public.pedido_item.id_cliente = public.cliente.id_cliente) "+
                    "WHERE " +
                    "  public.notificacao_desvio.id_notificacao_desvio = :id_notificacao_desvio ";

                    command.Parameters.Clear();

                    command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_notificacao_desvio", NpgsqlDbType.Integer));
                    command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        throw new Exception("ID Inválido");
                    }

                    read.Read();

                    this.Data = Convert.ToDateTime(read["nod_data"]);
                    this.defeitoDescricao = read["nod_descricao_defeito"].ToString();

                    this.idPedidoItem = Convert.ToInt32(read["id_pedido_item"]);
                    this.OC = read["pei_numero"].ToString();
                    this.Pos = read["pei_posicao"].ToString();
                    this.idCliente = Convert.ToInt32(read["id_cliente"]);
                    this.cliNomeResumido = read["cli_nome_resumido"].ToString();

                    if (read["id_posto_trabalho"] != DBNull.Value)
                    {
                        this.idPostoTrabalho = Convert.ToInt32(read["id_posto_trabalho"]);
                        this.postoTrabalho = read["pos_codigo"].ToString();
                    }
                    else
                    {
                        this.idPostoTrabalho = null;
                        this.postoTrabalho = "";
                    }

                    if (read["id_tipo_defeito"] != DBNull.Value)
                    {
                        this.idTipoDefeito = Convert.ToInt32(read["id_tipo_defeito"]);
                        this.tipoDefeito = read["tde_identificacao"].ToString();
                    }
                    else
                    {
                        this.idTipoDefeito = null;
                        this.tipoDefeito = "";
                    }


                    this.idTipoNotificacaoDesvio = Convert.ToInt32(read["id_tipo_notificacao_desvio"]);
                    this.tipoNotificacaoDesvio = read["tnd_identificacao"].ToString();


                    this.justificativaProducao = read["nod_justificativa_producao"].ToString();
                    if (read["nod_data_emissao_nf_cliente"] != DBNull.Value)
                    {
                        this.nfClienteData = Convert.ToDateTime(read["nod_data_emissao_nf_cliente"]);
                    }
                    else
                    {
                        this.nfClienteData = null;
                    }

                    if (read["nod_numero_nf_cliente"] != DBNull.Value)
                    {
                        this.nfClienteNumero = read["nod_numero_nf_cliente"].ToString();
                    }
                    else
                    {
                        this.nfClienteNumero = null;
                    }

                    if (read["nod_valor_nf_cliente"] != DBNull.Value)
                    {
                        this.nfClienteValor = Convert.ToDouble(read["nod_valor_nf_cliente"]);
                    }
                    else
                    {
                        this.nfClienteValor = null;
                    }


                    this.Numero = read["nod_numero"].ToString();


                    this.qtdPecasDefeituosas = Convert.ToDouble(read["nod_qtd_pecas_defeituosas"]);
                    this.qtdPecasDevolvidas = Convert.ToDouble(read["nod_qtd_pecas_devolvidas"]);


                    this.usuarioNotificacao = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_notificacao"]), Usuario, this.conn);


                    this.DocumentoScaneado = read["nod_documento"] as byte[];
                    this.DocumentoScaneadoNome = read["nod_documento_nome"] as string;

                    read.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar a notificação\r\n" + e.Message, e);
            }

        }

        public void setPedido(int idPedidoItem, string OC, string Pos, int idCliente, string cliNomeResumido)
        {
            this.idPedidoItem = idPedidoItem;
            this.OC = OC;
            this.Pos = Pos;
            this.idCliente = idCliente;
            this.cliNomeResumido = cliNomeResumido;
        }

        public void setTipoNotificacaoDesvio(int idTipoNotificacaoDesvio, string tipoNotificacaoDesvio)
        {
            this.idTipoNotificacaoDesvio = idTipoNotificacaoDesvio;
            this.tipoNotificacaoDesvio = tipoNotificacaoDesvio;
        }

        public void setTipoDefeito(int idTipoDefeito, string tipoDefeito)
        {
            this.idTipoDefeito = idTipoDefeito;
            this.tipoDefeito = tipoDefeito;
        }

        public void setPostoTrabalho(int? idPostoTrabalho, string postoTrabalho)
        {
            this.idPostoTrabalho = idPostoTrabalho;
            this.postoTrabalho = postoTrabalho;
        }

        public void Salvar()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();

                if (this.ID == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.notificacao_desvio " +
                        "( " +
                        "  id_pedido_item, " +
                        "  nod_numero, " +
                        "  id_tipo_notificacao_desvio, " +
                        "  nod_data, " +
                        "  nod_descricao_defeito, " +
                        "  id_tipo_defeito, " +
                        "  id_posto_trabalho, " +
                        "  nod_qtd_pecas_defeituosas, " +
                        "  nod_qtd_pecas_devolvidas, " +
                        "  nod_numero_nf_cliente, " +
                        "  nod_data_emissao_nf_cliente, " +
                        "  nod_valor_nf_cliente, " +
                        "  nod_justificativa_producao, " +
                        "  id_acs_usuario_notificacao, " +
                        "  nod_documento, "+
                        "  nod_documento_nome " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_pedido_item, " +
                        "  :nod_numero, " +
                        "  :id_tipo_notificacao_desvio, " +
                        "  :nod_data, " +
                        "  :nod_descricao_defeito, " +
                        "  :id_tipo_defeito, " +
                        "  :id_posto_trabalho, " +
                        "  :nod_qtd_pecas_defeituosas, " +
                        "  :nod_qtd_pecas_devolvidas, " +
                        "  :nod_numero_nf_cliente, " +
                        "  :nod_data_emissao_nf_cliente, " +
                        "  :nod_valor_nf_cliente, " +
                        "  :nod_justificativa_producao, " +
                        "  :id_acs_usuario_notificacao, " +
                        "  :nod_documento, " +
                        "  :nod_documento_nome " +
                        ") RETURNING id_notificacao_desvio; ";

                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.notificacao_desvio   " +
                        "SET  " +
                        "  id_pedido_item = :id_pedido_item, " +
                        "  nod_numero = :nod_numero, " +
                        "  id_tipo_notificacao_desvio = :id_tipo_notificacao_desvio, " +
                        "  nod_data = :nod_data, " +
                        "  nod_descricao_defeito = :nod_descricao_defeito, " +
                        "  id_tipo_defeito = :id_tipo_defeito, " +
                        "  id_posto_trabalho = :id_posto_trabalho, " +
                        "  nod_qtd_pecas_defeituosas = :nod_qtd_pecas_defeituosas, " +
                        "  nod_qtd_pecas_devolvidas = :nod_qtd_pecas_devolvidas, " +
                        "  nod_numero_nf_cliente = :nod_numero_nf_cliente, " +
                        "  nod_data_emissao_nf_cliente = :nod_data_emissao_nf_cliente, " +
                        "  nod_valor_nf_cliente = :nod_valor_nf_cliente, " +
                        "  nod_justificativa_producao = :nod_justificativa_producao, " +
                        "  id_acs_usuario_notificacao = :id_acs_usuario_notificacao, " +
                        "  nod_documento = :nod_documento, " +
                        "  nod_documento_nome = :nod_documento_nome " +
                        "WHERE  " +
                        "  id_notificacao_desvio = :id_notificacao_desvio " +
                        "RETURNING id_notificacao_desvio; ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_notificacao_desvio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idPedidoItem;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_notificacao_desvio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idTipoNotificacaoDesvio;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.Data.Date ;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_descricao_defeito", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.defeitoDescricao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_defeito", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idTipoDefeito;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_posto_trabalho", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idPostoTrabalho;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_qtd_pecas_defeituosas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.qtdPecasDefeituosas;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_qtd_pecas_devolvidas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.qtdPecasDevolvidas;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_numero_nf_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.nfClienteNumero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_data_emissao_nf_cliente", NpgsqlDbType.Timestamp));
                if (this.nfClienteData != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.nfClienteData.Value.Date;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_valor_nf_cliente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.nfClienteValor;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_justificativa_producao", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.justificativaProducao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_notificacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.usuarioNotificacao.ID;


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_documento", NpgsqlDbType.Bytea));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nod_documento_nome", NpgsqlDbType.Varchar));

                if (this.DocumentoScaneado != null)
                {
                    command.Parameters["nod_documento"].Value = this.DocumentoScaneado;
                    command.Parameters["nod_documento_nome"].Value = this.DocumentoScaneadoNome;
                }
                else
                {
                    command.Parameters["nod_documento"].Value = null;
                    command.Parameters["nod_documento_nome"].Value = null;
                }

                this.ID = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar a notificação de desvio\r\n" + e.Message, e);
            }

        }


        public void setDocumentoEscaneado(byte[] novoDocumentoScaneado, string novoDocumentoScaneadoNome)
        {
            this.DocumentoScaneado = novoDocumentoScaneado;
            this.DocumentoScaneadoNome = novoDocumentoScaneadoNome;
        }
    }
}
