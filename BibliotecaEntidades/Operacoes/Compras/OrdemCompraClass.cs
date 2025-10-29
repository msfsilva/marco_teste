using System;
using System.Collections.Generic;
using System.Linq;
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule;
using Configurations;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTLog;
using IWTPostgreNpgsql;
using Newtonsoft.Json;
using Npgsql;
using NpgsqlTypes;
using ProjectConstants;
using SolicitacaoCompraClass = BibliotecaEntidades.Operacoes.Compras.SolicitacaoCompraClass;

namespace BibliotecaEntidades.Operacoes.Compras
{
    public enum TipoOC { OC, Cotacao }
    public enum StatusOC { Nova, Enviada, RecebidaParcial, Recebida, Cancelada }
    public class OrdemCompraClass
    {
        public int? Id { get; private set; }
        [JsonIgnore]
        public AcsUsuarioClass Usuario { get; private set; }
        public TipoOC Tipo { get; private set; }
        public DateTime Data { get; private set; }
        public DateTime? DataEnvio { get; private set; }
        [JsonIgnore]
        public FornecedorClass Fornecedor { get; private set; }
        public int? IdComprador { get; private set; }
        public double ValorTotal { get; private set; }
        public double ValorComImpostos { get; private set; }
        public StatusOC Status { get; private set; }
        public string Observacao { get; private set; }
        public int? IdFormaPagamento { get; private set; }
        
        
        
        public string Rodape { get; private set; }
        public string MensagemEmail { get; private set; }

        public double DescontoP { get; private set; }
        public double DescontoR { get; private set; }

        [JsonIgnore]
        public AcsUsuarioClass UsuarioCancelamento { get; private set; }
        public DateTime? DataCancelamento { get; private set; }
        public string JustificativaCancelamento { get; private set; }

        public List<SolicitacaoCompraClass> SolicitacoesList
        {
            get
            {
                List < SolicitacaoCompraClass > toRet =  new List<SolicitacaoCompraClass>(this.Solicitacoes.Values);
                toRet.Sort(new SolicitacaoComparerOrdenacaoLinha());
                return toRet;
            }
        }

        private bool solicitacoesCarregadas = false;


        public Dictionary<int, SolicitacaoCompraClass> Solicitacoes;

        IWTPostgreNpgsqlConnection conn;
        AcsUsuarioClass UsuarioAtual;
        private List<SolicitacaoCompraClass> SolicitacoesRemovidas;
        [JsonIgnore]
        private List<OrdemCompraDocumentoEnviadoClass> DocumentosEnviados; 

        public OrdemCompraClass(int id, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, bool carregarSolicitacoes)
        {
            Id = id;
            this.conn = conn;
            UsuarioAtual = usuario;

            IWTPostgreNpgsqlCommand tmp = this.conn.CreateCommand();
            this.Load(ref tmp, carregarSolicitacoes);
        }

        public OrdemCompraClass(int id, ref IWTPostgreNpgsqlCommand command, AcsUsuarioClass usuario, bool carregarSolicitacoes)
        {
            Id = id;
            this.conn = command.Connection;
            UsuarioAtual = usuario;

            this.Load(ref command, carregarSolicitacoes);
        }

        public OrdemCompraClass(TipoOC tipo, FornecedorClass _fornecedor, int? idComprador, string rodape, string mensagemEmail, IWTPostgreNpgsqlConnection conn, AcsUsuarioClass usuario, int? idFormaPagamento, string obs, double descontoP)
        {
            Tipo = tipo;
            Fornecedor = _fornecedor;
            IdComprador = idComprador;
            Rodape = rodape;
            MensagemEmail = mensagemEmail;
            this.conn = conn;
            UsuarioAtual = usuario;

            this.Data = Configurations.DataIndependenteClass.GetData();
            this.Usuario = usuario;
            this.Status = StatusOC.Nova;

            this.ValorTotal = 0;
            this.ValorComImpostos = 0;

            this.IdFormaPagamento = idFormaPagamento;
            this.Observacao = obs;

            this.DescontoP = descontoP;

            this.Solicitacoes = new Dictionary<int, SolicitacaoCompraClass>();
            this.solicitacoesCarregadas = true;

            this.DocumentosEnviados = new List<OrdemCompraDocumentoEnviadoClass>();

            
        }

        private void Load(ref IWTPostgreNpgsqlCommand command, bool carregarSolicitacoes)
        {
            try
            {
                command.CommandText =
                    "SELECT  " +
                    "  id_acs_usuario, " +
                    "  orc_valor, " +
                    "  orc_status, " +
                    "  id_fornecedor, " +
                    "  orc_data, " +
                    "  id_acs_usuario_cancelamento, " +
                    "  orc_data_cancelamento, " +
                    "  orc_tipo, " +
                    "  orc_valor_com_impostos, " +
                    "  orc_rodape, " +
                    "  orc_msg_email, " +
                    "  id_comprador, " +
                    "  orc_justificativa_cancelamento, "+
                    "  orc_observacao, " +
                    "  id_forma_pagamento," +
                    "  orc_desconto_p, " +
                    "  orc_desconto_R, " +
                    "  orc_data_envio "+
                    "FROM  " +
                    "  public.ordem_compra  " +
                    "WHERE " +
                    "  id_ordem_compra = :id_ordem_compra ";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Id;
                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();
                this.Usuario = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]), UsuarioAtual, conn);
                    
                  
                this.ValorTotal = Convert.ToDouble(read["orc_valor"]);
                this.ValorComImpostos = Convert.ToDouble(read["orc_valor_com_impostos"]);
                this.Status = (StatusOC)Enum.ToObject(typeof(StatusOC), read["orc_status"]);
                this.Fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), UsuarioAtual, conn);
                this.Data = Convert.ToDateTime(read["orc_data"]);
                this.DataEnvio = read["orc_data_envio"] as DateTime?;
                if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                {
                    this.UsuarioCancelamento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]), UsuarioAtual, conn);
                    this.DataCancelamento = Convert.ToDateTime(read["orc_data_cancelamento"]);
                    this.JustificativaCancelamento = read["orc_justificativa_cancelamento"].ToString();
                }

                this.Tipo = (TipoOC)Enum.ToObject(typeof(TipoOC), read["orc_tipo"]);

                if (read["id_comprador"] != DBNull.Value)
                {
                    this.IdComprador = Convert.ToInt32(read["id_comprador"]);
                }

                this.Rodape = read["orc_rodape"].ToString();
                this.MensagemEmail = read["orc_msg_email"].ToString();
                if (read["id_forma_pagamento"] != DBNull.Value)
                {
                    this.IdFormaPagamento = Convert.ToInt32(read["id_forma_pagamento"]);
                }
                this.Observacao = read["orc_observacao"].ToString();

                this.DescontoP = Convert.ToDouble(read["orc_desconto_p"]);
                this.DescontoR = Convert.ToDouble(read["orc_desconto_r"]);


                read.Close();

                if (carregarSolicitacoes)
                {
                    this.carregarSolicitacoes(ref command);
                }
                this.carregarDocumentos(ref command);

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados da OC\r\n" + e.Message, e);
            }
        }

        private void carregarDocumentos(ref IWTPostgreNpgsqlCommand command)
        {
            this.DocumentosEnviados = new List<OrdemCompraDocumentoEnviadoClass>();
            if (this.Id == null)
            {
                return;
            }

            command.CommandText =
                "SELECT " +
                "  public.ordem_compra_documento_enviado.id_ordem_compra_documento_enviado " +
                "FROM " +
                "  public.ordem_compra_documento_enviado " +
                "WHERE " +
                "  public.ordem_compra_documento_enviado.id_ordem_compra = :id_ordem_compra  ";

            command.Parameters.Clear();

            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
            command.Parameters[command.Parameters.Count - 1].Value = this.Id;

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                this.DocumentosEnviados.Add(
                    new OrdemCompraDocumentoEnviadoClass(
                        Convert.ToInt32(read["id_ordem_compra_documento_enviado"]),
                        this,
                        this.conn
                        )
                    );
            }
            read.Close();

        }

        private void carregarSolicitacoes(ref IWTPostgreNpgsqlCommand command)
        {
            #region carrega as solicitações

            this.Solicitacoes = new Dictionary<int, SolicitacaoCompraClass>();
            if (this.Id == null)
            {
                this.solicitacoesCarregadas = true; 
                return;
            }

            command.CommandText =
                "SELECT  " +
                "  public.solicitacao_compra.id_solicitacao_compra, " +
                "  public.solicitacao_compra.soc_numero_linha_oc " +
                "FROM " +
                "  public.solicitacao_compra " +
                "WHERE " +
                "  public.solicitacao_compra.id_ordem_compra = :id_ordem_compra ";

                            command.Parameters.Clear();

                            command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Id;

            IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
            while (read.Read())
            {
                this.Solicitacoes.Add(
                    Convert.ToInt32(read["id_solicitacao_compra"]),
                    new SolicitacaoCompraClass(
                        Convert.ToInt32(read["id_solicitacao_compra"]),
                        this,
                        this.UsuarioAtual,
                        command.Connection)
                        );
            }
            read.Close();
            this.solicitacoesCarregadas = true; 


            #endregion
        }

        public void adicionarSolicitacao(long idSolicitacaoCompra, ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (!this.solicitacoesCarregadas)
                {
                    this.carregarSolicitacoes(ref command);
                }


                SolicitacaoCompraClass sol =
                           new SolicitacaoCompraClass(idSolicitacaoCompra,
                                                      null,
                                                      this.UsuarioAtual, this.conn);

                int numeroLinha = this.Solicitacoes.Count + 1;
                Solicitacoes.Add(numeroLinha,sol);

                sol.Comprar(this, numeroLinha);

                double valorUnitario = 0;
                double aliquotaIPI = 0;
                double aliquotaICMS = 0;



                if (sol.Produto != null)
                {
                    

                    List<ProdutoFornecedorClass> tmpFornecedoresProdutos = sol.Produto.CollectionProdutoFornecedorClassProduto.Where(a => a.Ativo && a.Fornecedor == this.Fornecedor).ToList();

                    if (tmpFornecedoresProdutos.Count > 1)
                    {
                        throw new Exception("Foram encontrados mais de um fornecedor ativo para o conjunto fornecedor " + this.Fornecedor.ID + " e produto " + sol.Produto.ID + ". Consulte a equipe IWT");
                    }

                    ProdutoFornecedorClass fornecedor = tmpFornecedoresProdutos.FirstOrDefault();


                    valorUnitario = fornecedor.UltimoPreco;
                    aliquotaIPI = fornecedor.Ipi;
                    aliquotaICMS = fornecedor.Icms;

                    //Se o produto tiver uma unidade de compra definida nesse fornecedor deve ajustar a qtd e a unidade
                    if (fornecedor.UnidadeMedidaCompra!=null && fornecedor.UnidadesPorUnCompra.HasValue)
                    {
                        double quantidade = sol.QtdUnidadeUso / fornecedor.UnidadesPorUnCompra.Value;


                        if (fornecedor.LotePadrao.HasValue)
                        {

                            double loteMinimo = fornecedor.LoteMinimo.HasValue ? fornecedor.LoteMinimo.Value : 0;

                            quantidade = quantidade - loteMinimo;

                            int qtdLotesPadrao = (int)Math.Truncate(quantidade / fornecedor.LotePadrao.Value);
                            double tmp = Math.Round(qtdLotesPadrao * fornecedor.LotePadrao.Value, 4);
                            if (tmp < quantidade)
                            {
                                tmp += fornecedor.LotePadrao.Value;
                            }

                            quantidade = Math.Round(tmp + loteMinimo, 4);
                        }


                        sol.Quantidade = quantidade;
                        sol.UnidadeCompra = fornecedor.UnidadeMedidaCompra.ToString();
                    }
                }
                else
                {
                    if (sol.Material != null)
                    {
                        List<MaterialFornecedorClass> tmpFornecedoresMaterial = sol.Material.CollectionMaterialFornecedorClassMaterial.Where(a => a.Ativo && a.Fornecedor == this.Fornecedor).ToList();

                        if (tmpFornecedoresMaterial.Count > 1)
                        {
                            throw new Exception("Foram encontrados mais de um fornecedor ativo para o conjunto fornecedor " + this.Fornecedor.ID + " e material " + sol.Material.ID + ". Consulte a equipe IWT");
                        }

                        MaterialFornecedorClass fornecedor = tmpFornecedoresMaterial.FirstOrDefault();

                        if (fornecedor != null)
                        {
                            valorUnitario = fornecedor.UltimoPreco;
                            aliquotaIPI = fornecedor.Ipi;
                            aliquotaICMS = fornecedor.Icms;

                            //Se o material tiver uma unidade de compra definida nesse fornecedor deve ajustar a qtd e a unidade
                            if (fornecedor.UnidadeMedidaCompra!= null && fornecedor.UnidadesPorUnCompra.HasValue)
                            {
                                double quantidade = sol.QtdUnidadeUso / fornecedor.UnidadesPorUnCompra.Value;


                                if (fornecedor.LotePadrao.HasValue)
                                {
                                    double loteMinimo = fornecedor.LoteMinimo.HasValue ? fornecedor.LoteMinimo.Value : 0;

                                    quantidade = quantidade - loteMinimo;

                                    int qtdLotesPadrao = (int)Math.Truncate(quantidade / fornecedor.LotePadrao.Value);
                                    double tmp = Math.Round(qtdLotesPadrao * fornecedor.LotePadrao.Value, 4);
                                    if (tmp < quantidade)
                                    {
                                        tmp += fornecedor.LotePadrao.Value;
                                    }

                                    quantidade = Math.Round(tmp + loteMinimo, 4);
                                }


                                sol.Quantidade = quantidade;
                                sol.UnidadeCompra = fornecedor.UnidadeMedidaCompra.ToString();
                            }
                        }
                    }
                    else
                    {

                        List<EpiFornecedorClass> tmpFornecedoresEpis = sol.Epi.CollectionEpiFornecedorClassEpi.Where(a => a.Ativo && a.Fornecedor == this.Fornecedor).ToList();

                        if (tmpFornecedoresEpis.Count > 1)
                        {
                            throw new Exception("Foram encontrados mais de um fornecedor ativo para o conjunto fornecedor " + this.Fornecedor.ID + " e epi " + sol.Epi.ID + ". Consulte a equipe IWT");
                        }

                        EpiFornecedorClass fornecedor = tmpFornecedoresEpis.FirstOrDefault();


                        valorUnitario = fornecedor.UltimoPreco;
                        aliquotaIPI = fornecedor.Ipi;
                        aliquotaICMS = fornecedor.Icms;

                        //Se o Epi tiver uma unidade de compra definida nesse fornecedor deve ajustar a qtd e a unidade
                        if (fornecedor.UnidadeMedidaCompra != null && fornecedor.UnidadesPorUnCompra.HasValue)
                        {
                            double quantidade = sol.QtdUnidadeUso / fornecedor.UnidadesPorUnCompra.Value;


                            if (fornecedor.LotePadrao.HasValue)
                            {
                                double loteMinimo = fornecedor.LoteMinimo.HasValue ? fornecedor.LoteMinimo.Value : 0;

                                quantidade = quantidade - loteMinimo;

                                int qtdLotesPadrao = (int)Math.Truncate(quantidade / fornecedor.LotePadrao.Value);
                                double tmp = Math.Round(qtdLotesPadrao * fornecedor.LotePadrao.Value, 4);
                                if (tmp < quantidade)
                                {
                                    tmp += fornecedor.LotePadrao.Value;
                                }

                                quantidade = Math.Round(tmp + loteMinimo, 4);
                            }


                            sol.Quantidade = quantidade;
                            sol.UnidadeCompra = fornecedor.UnidadeMedidaCompra.NomeUnidade;
                        }
                    }
                }

                sol.DefinirValores(valorUnitario, aliquotaIPI, aliquotaICMS);

                //this.ValorTotal += valorUnitario * sol.Quantidade;
                //this.ValorComImpostos += (valorUnitario * sol.Quantidade) * (1 + (aliquotaIPI / 100));

                bool itemNaoDeveAtualizarPrecosNoRecebimento = false;
                bool possuiDesconto = false;

                if (sol.OrdemCompra.DescontoP > 0 || sol.OrdemCompra.DescontoR > 0)
                {
                    possuiDesconto = true;
                }

                if (
                    !IWTConfiguration.Conf.getBoolConf(Constants.SIMULADOR_COMPRAS_HABILITADO) &&
                    IWTConfiguration.Conf.getBoolConf(Constants.MARCAR_AUTOMATICAMENTE_OC_COM_DESCONTO_PARA_NAO_ATUALIZAR_PRECO_PRODUTOS) &&
                    possuiDesconto
                    )
                {
                    itemNaoDeveAtualizarPrecosNoRecebimento = true;
                }

                sol.itemNaoDeveAtualizarPrecosNoRecebimento = itemNaoDeveAtualizarPrecosNoRecebimento;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a solicitação\r\n" + e.Message, e);
            }
        }

        private void GerarLog(string local)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string dados = JsonConvert.SerializeObject(this, settings);
            Log.Registrar(IWTLogSeveridade.Info, "SAVE", this.GetType().ToString(), local , dados, conn.ConnectionString);

        }

        public void Salvar(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {
                bool ocNova = false;
                if (this.Id == null)
                {
                    ocNova = true;
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.ordem_compra " +
                        "( " +
                        "  id_acs_usuario, " +
                        "  orc_valor, " +
                        "  orc_status, " +
                        "  id_fornecedor, " +
                        "  orc_data, " +
                        "  id_acs_usuario_cancelamento, " +
                        "  orc_data_cancelamento, " +
                        "  orc_tipo, " +
                        "  orc_valor_com_impostos, " +
                        "  orc_rodape, " +
                        "  orc_msg_email, " +
                        "  id_comprador, " +
                        "  orc_justificativa_cancelamento, " +
                        "  id_forma_pagamento, " +
                        "  orc_observacao, " +
                        "  orc_desconto_p, " +
                        "  orc_data_envio " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_acs_usuario, " +
                        "  :orc_valor, " +
                        "  :orc_status, " +
                        "  :id_fornecedor, " +
                        "  :orc_data, " +
                        "  :id_acs_usuario_cancelamento, " +
                        "  :orc_data_cancelamento, " +
                        "  :orc_tipo, " +
                        "  :orc_valor_com_impostos, " +
                        "  :orc_rodape, " +
                        "  :orc_msg_email, " +
                        "  :id_comprador, " +
                        "  :orc_justificativa_cancelamento," +
                        "  :id_forma_pagamento, " +
                        "  :orc_observacao, " +
                        "  :orc_desconto_p, " +
                        "  :orc_data_envio " +
                        ") RETURNING id_ordem_compra; ";
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.ordem_compra   " +
                        "SET  " +
                        "  id_acs_usuario = :id_acs_usuario, " +
                        "  orc_valor = :orc_valor, " +
                        "  orc_status = :orc_status, " +
                        "  id_fornecedor = :id_fornecedor, " +
                        "  orc_data = :orc_data, " +
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " +
                        "  orc_data_cancelamento = :orc_data_cancelamento, " +
                        "  orc_tipo = :orc_tipo, " +
                        "  orc_valor_com_impostos = :orc_valor_com_impostos, " +
                        "  orc_rodape = :orc_rodape, " +
                        "  orc_msg_email = :orc_msg_email, " +
                        "  id_comprador = :id_comprador, " +
                        "  orc_justificativa_cancelamento = :orc_justificativa_cancelamento, " +
                        "  orc_observacao = :orc_observacao, " +
                        "  id_forma_pagamento = :id_forma_pagamento, " +
                        "  orc_desconto_p = :orc_desconto_p, " +
                        "  orc_data_envio = :orc_data_envio " +
                        "WHERE  " +
                        "  id_ordem_compra = :id_ordem_compra " +
                        "RETURNING id_ordem_compra; ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Usuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.ValorTotal;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.Data;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_envio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.DataEnvio;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_justificativa_cancelamento", NpgsqlDbType.Text));
                if (this.UsuarioCancelamento != null)
                {
                    command.Parameters[command.Parameters.Count - 3].Value = this.UsuarioCancelamento.ID;
                    command.Parameters[command.Parameters.Count - 2].Value = this.DataCancelamento;
                    command.Parameters[command.Parameters.Count - 1].Value = this.JustificativaCancelamento;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 3].Value = null;
                    command.Parameters[command.Parameters.Count - 2].Value = null;
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor_com_impostos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.ValorComImpostos;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_rodape", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.Rodape;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_msg_email", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.MensagemEmail;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdComprador;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_observacao", NpgsqlDbType.Text));
                command.Parameters[command.Parameters.Count - 1].Value = this.Observacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdFormaPagamento;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_desconto_p", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.DescontoP;


                this.Id = Convert.ToInt32(command.ExecuteScalar());

                if (this.solicitacoesCarregadas)
                {
                    foreach (SolicitacaoCompraClass sol in Solicitacoes.Values)
                    {
                        sol.Save(ref command, ocNova, true);
                    }
                }

                if (this.SolicitacoesRemovidas != null)
                {
                    foreach (SolicitacaoCompraClass sol in SolicitacoesRemovidas)
                    {
                        sol.Save(ref command, null, true);
                    }
                }

                if (this.DocumentosEnviados != null)
                {
                    foreach (OrdemCompraDocumentoEnviadoClass documentoEnviado in DocumentosEnviados)
                    {
                        documentoEnviado.Save(ref command);
                    }
                }

                this.verificaStatus(ref command);


            }
            catch (Exception e)
            {
                GerarLog("Save Ordem de Compra Class - Erro - " + e.Message);
                throw new Exception("Erro ao salvar a OC\r\n" + e.Message, e);
            }
            finally
            {
                GerarLog("Save Ordem de Compra Class - Finally");
            }
        }

        public void setEnviada()
        {
            if (this.Status < StatusOC.Enviada)
            {
                this.Status = StatusOC.Enviada;
                this.DataEnvio = DataIndependenteClass.GetData();
            }
            else
            {
                throw new Exception("Não é possível enviar uma OC já enviada");
            }
        }

        public void Cancelar(string justificativa)
        {
            try
            {
                if (this.Status == StatusOC.Cancelada)
                {
                    throw new Exception("Não é possivel cancelar uma OC já cancelada");
                }

                this.Status = StatusOC.Cancelada;
                this.UsuarioCancelamento = this.UsuarioAtual;
                this.DataCancelamento = Configurations.DataIndependenteClass.GetData();
                this.JustificativaCancelamento = justificativa;

                if (this.Id != null && !this.solicitacoesCarregadas)
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    this.carregarSolicitacoes(ref command);
                }


                foreach (SolicitacaoCompraClass sol in Solicitacoes.Values)
                {
                    if (sol.Status != SolicitacaoCompraStatus.Cancelada)
                    {
                        sol.Cancelar();
                    }
                }
               
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar a OC\r\n" + e.Message, e);
            }
        }

        public void setStatus(StatusOC novoStatus)
        {
            this.Status = novoStatus;
        }

        public void verificaStatus(ref IWTPostgreNpgsqlCommand command)
        {

            try
            {
                if (this.Id != null && !this.solicitacoesCarregadas)
                {
                    this.carregarSolicitacoes(ref command);
                }

                SolicitacaoCompraStatus menorStatus = SolicitacaoCompraStatus.Cancelada;
                SolicitacaoCompraStatus maiorStatus = SolicitacaoCompraStatus.Nova;

                foreach (SolicitacaoCompraClass sol in Solicitacoes.Values)
                {
                    if (sol.Status < menorStatus)
                    {
                        menorStatus = sol.Status;
                    }
                    if (sol.Status > maiorStatus)
                    {
                        maiorStatus = sol.Status;
                    }

                }

                StatusOC statusOC; // Não inicializar com um valor default que pode ser incorreto

                if (this.Solicitacoes.Values.All(s => s.Status == SolicitacaoCompraStatus.Cancelada))
                {
                    statusOC = StatusOC.Cancelada;
                }
                else if (this.Solicitacoes.Values.All(s => s.Status == SolicitacaoCompraStatus.RecebidaTotal || s.Status == SolicitacaoCompraStatus.Cancelada))
                {
                    // Se tudo que não foi cancelado, foi totalmente recebido
                    statusOC = StatusOC.Recebida;
                }
                else if (this.Solicitacoes.Values.Any(s => s.Status == SolicitacaoCompraStatus.RecebidaParcial || s.Status == SolicitacaoCompraStatus.RecebidaTotal))
                {
                    // Se existe qualquer recebimento (parcial ou total), mas não se encaixa na regra acima
                    statusOC = StatusOC.RecebidaParcial;
                }
                else if (this.Solicitacoes.Values.All(s => s.Status >= SolicitacaoCompraStatus.Comprada))
                {
                    // Se todas estão compradas (ou status superior, mas não recebidas/canceladas), mantém o status atual se for Enviada, ou atualiza.
                    statusOC = this.Status == StatusOC.Nova ? StatusOC.Enviada : this.Status;
                }
                else
                {
                    // Se nenhuma das condições acima for atendida, mantém o status atual para evitar regressão.
                    statusOC = this.Status;
                }


                if (statusOC != this.Status)
                {
                    this.setStatus(statusOC);
                    // A chamada Salvar() já está no código original e deve ser mantida.
                    this.Salvar(ref command);
                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao ajustar o status da ordem de compra.\r\n" + e.Message, e);
            }



        }

        public void setFornecedor(FornecedorClass fornecedor)
        {
            try
            {

                foreach (SolicitacaoCompraClass solicitacao in Solicitacoes.Values)
                {
                    if (solicitacao.Material != null && solicitacao.Material.CollectionMaterialFornecedorClassMaterial.All(a => a.Fornecedor != fornecedor))
                    {
                        throw new Exception("Não é possível utilizar esse fornecedor pois ele não possui o material "+solicitacao.Material);
                    }

                    if (solicitacao.Produto != null && solicitacao.Produto.CollectionProdutoFornecedorClassProduto.All(a => a.Fornecedor != fornecedor))
                    {
                        throw new Exception("Não é possível utilizar esse fornecedor pois ele não possui o produto "+solicitacao.Produto);
                    }
                }


                this.Fornecedor = fornecedor;
            }
            catch (Exception e)
            {
                throw new Exception("\r\n" + e.Message, e);
            }


         
        }

        public void recalcularTotais()
        {
            try
            {
                double tmpValorTotal = 0;
                double tmpValorTotalComImpostos = 0;

                foreach (SolicitacaoCompraClass sol in SolicitacoesList)
                {

                    if (this.DescontoP > 0)
                    {
                        sol.aplicaDescontos(this.DescontoP/100);
                    }
                    tmpValorTotal += sol.ValorTotalCompra;
                    tmpValorTotalComImpostos += sol.ValorTotalCompraComImpostos;
                }

                this.ValorTotal = tmpValorTotal;
                this.ValorComImpostos = tmpValorTotalComImpostos;



            }
            catch (Exception e)
            {
                throw new Exception("Erro ao recalcular os totais.\r\n" + e.Message, e);
            }
        }

        public void setMensagens(string email, string rodape)
        {
            this.MensagemEmail = email;
            this.Rodape = rodape;

        }

        public void setFormaPagamento(int id)
        {
            this.IdFormaPagamento = id;
        }

        public void setObservacao(string obs)
        {
            this.Observacao = obs;
        }

        public void removerLinha(int id)
        {
            try
            {
                if (!this.solicitacoesCarregadas)
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    this.carregarSolicitacoes(ref command);
                }

                if (!this.Solicitacoes.ContainsKey(id))
                {
                    throw new Exception("Linha não encontrada.");
                }

                if (this.Solicitacoes.Count == 1)
                {
                    throw new Exception("Não é possível excluir a última solicitação da OC, você deve excluir a OC.");
                }

                if (this.SolicitacoesRemovidas == null) this.SolicitacoesRemovidas = new List<SolicitacaoCompraClass>();
                SolicitacaoCompraClass sol = this.Solicitacoes[id];
                sol.removerOC();
                this.SolicitacoesRemovidas.Add(sol);
                this.Solicitacoes.Remove(id);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover a linha da OC\r\n" + e.Message, e);
            }
        }

        public void adicionarDocumento(ProdutoDocumentoTipoClass documento)
        {
            if (this.DocumentosEnviados==null)
            {
                this.DocumentosEnviados = new List<OrdemCompraDocumentoEnviadoClass>();
            }
            
            if (this.DocumentosEnviados.Count(a=>a.IdDocumentoTipoFamilia==documento.DocumentoTipoFamilia.ID)>0)
            {
                return;
            }

            this.DocumentosEnviados.Add(
                new OrdemCompraDocumentoEnviadoClass(
                    documento.DocumentoTipoFamilia.ID,
                    documento.DocumentoTipoFamilia.Documento,
                    documento.DocumentoTipoFamilia.DocumentoNome,
                    this,
                    this.conn
                    )
                );
        }
    }

    public class OrdemCompraDocumentoEnviadoClass
    {
        public int? Id { get; private set; }
        public long IdDocumentoTipoFamilia { get; private set; }
        public OrdemCompraClass OrdemCompra { get; private set; }
        IWTPostgreNpgsqlConnection conn;


        private byte[] _DocumentoScaneado;
        public byte[] DocumentoScaneado
        {
            get
            {
                if (this._DocumentoScaneado == null)
                {
                    this.LoadDocumentoScaneado();
                }

                return this._DocumentoScaneado;
            }
        }

        private string _DocumentoScaneadoNome;
        public string DocumentoScaneadoNome
        {
            get
            {
                if (this._DocumentoScaneadoNome == null)
                {
                    this.LoadDocumentoScaneado();
                }

                return this._DocumentoScaneadoNome;
            }
        }


        public OrdemCompraDocumentoEnviadoClass (long idDocumentoTipoFamilia, byte[] documentoScaneado, string documentoScaneadoNome, OrdemCompraClass ordemCompra, IWTPostgreNpgsqlConnection conn)
        {
            Id = null;
            this.IdDocumentoTipoFamilia = idDocumentoTipoFamilia;
            _DocumentoScaneado = documentoScaneado;
            _DocumentoScaneadoNome = documentoScaneadoNome;
            OrdemCompra = ordemCompra;
            this.conn = conn;
        }

        public OrdemCompraDocumentoEnviadoClass(int id, OrdemCompraClass ordemCompra, IWTPostgreNpgsqlConnection conn)
        {
            Id = id;
            OrdemCompra = ordemCompra;
            this.conn = conn;
            this.Load();
        }

        private void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT  " +
                    "  public.ordem_compra_documento_enviado.id_documento_tipo_familia " +
                    "FROM " +
                    "  public.ordem_compra_documento_enviado " +
                    "WHERE " +
                    "  public.ordem_compra_documento_enviado.id_ordem_compra_documento_enviado = :id_ordem_compra_documento_enviado ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra_documento_enviado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Id;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }
                
                read.Read();
                this.IdDocumentoTipoFamilia = Convert.ToInt32(read["id_documento_tipo_familia"]);
                read.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o documento enviado.\r\n" + e.Message, e);
            }
        }

        internal void Save(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (!this.Id.HasValue)
                {
                    command.CommandText = 
                        "INSERT INTO  "+
                        "  public.ordem_compra_documento_enviado "+
                        "( "+
                        "  id_documento_tipo_familia, "+
                        "  id_ordem_compra, "+
                        "  ocd_nome_documento "+
                        ")  "+
                        "VALUES ( "+
                        "  :id_documento_tipo_familia, "+
                        "  :id_ordem_compra, "+
                        "  :ocd_nome_documento "+
                        ") RETURNING id_ordem_compra_documento_enviado; ";
                }
                else
                {
                    command.CommandText = 
                        "UPDATE  "+
                        "  public.ordem_compra_documento_enviado   "+
                        "SET  "+
                        "  id_documento_tipo_familia = :id_documento_tipo_familia, "+
                        "  id_ordem_compra = :id_ordem_compra, "+
                        "  ocd_nome_documento = :ocd_nome_documento "+
                        "WHERE  "+
                        "  id_ordem_compra_documento_enviado = :id_ordem_compra_documento_enviado "+
                        " RETURNING id_ordem_compra_documento_enviado; ";
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra_documento_enviado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdDocumentoTipoFamilia;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.OrdemCompra.Id;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ocd_nome_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this._DocumentoScaneadoNome;
                
                this.Id = Convert.ToInt32(command.ExecuteScalar());

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o documento enviado.\r\n" + e.Message, e);
            }
        }

        private void LoadDocumentoScaneado()
        {
            try
            {


                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                    "SELECT dtf_documento, dtf_documento_nome FROM documento_tipo_familia WHERE id_documento_tipo_familia = :id_documento_tipo_familia";

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_tipo_familia",
                                                                            NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.IdDocumentoTipoFamilia;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();

                this._DocumentoScaneado = read["dtf_documento"] as byte[];
                this._DocumentoScaneadoNome = read["dtf_documento_nome"] as string;

                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar o documento escaneado.\r\n" + e.Message, e);
            }
        }

    }
}
