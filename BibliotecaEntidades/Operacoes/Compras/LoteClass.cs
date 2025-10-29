#region Referencias

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using BibliotecaEntidades.Base;
using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Operacoes.Estoque;
using BibliotecaEntidades.SDC;
using BibliotecaEntidades.SDC.dto;


using IWTDotNetLib.ComplexLoginModule;
using IWTDotNetLib;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTPostgreNpgsql;
using Npgsql;
using NpgsqlTypes;

#endregion

namespace BibliotecaEntidades.Operacoes.Compras
{
    public enum LoteSituacao { EmAberto, Encerrado, Cancelado }
    public class LoteClass
    {
        private int? ID;
        public int IDClean
        {
            get
            {
                if (this.ID != null)
                {
                    return this.ID.Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        private readonly List<LoteSolicitacao> solicitacoesCompra;
        public List<LoteSolicitacao> solicitacoesCompraAtuais
        {
            get
            {
                return new List<LoteSolicitacao>(this.solicitacoesCompra.Where(a => !a.toDelete));
            }
        }

        public AcsUsuarioClass usuarioCadastro { get; private set; }
        public AcsUsuarioClass usuarioCancelamento { get; private set; }
        public AcsUsuarioClass usuarioEncerramento { get; private set; }

        private FornecedorClass _fornecedor;
        private ClienteClass _cliente;

        public string FornecedorCliente
        {
            get
            {
                if (_fornecedor != null)
                {
                    return _fornecedor.RazaoSocial;
                }

                if (_cliente != null)
                {
                    return _cliente.NomeResumido;
                }

                return null;
            }
        }

        private int? idEmissorCertificado;
        public string emissorCertificado { get; private set; }

        public BibliotecaEntidades.Entidades.MaterialClass Material { get; private set; }
        public BibliotecaEntidades.Entidades.ProdutoClass Produto { get; private set; }
        public EpiClass Epi { get; private set; }

        public string MaterialProduto { get; private set; }

        public string Numero { get; set; }
        public double qtdUnidadeUso { get; private set; }
        public double qtdUnidadeCompra { get; private set; }
        
        string _unidadeUso = null;
        public string unidadeUso
        {
            get
            {
                if (this._unidadeUso == null)
                {
                    this.loadUnidades();
                }
                return this._unidadeUso;
            }
        }
        
        string _unidadeCompra = null;
        public string unidadeCompra
        {
            get
            {
                if (this._unidadeCompra == null)
                {
                    this.loadUnidades();
                }
                return this._unidadeCompra;
            }
        }

        public double quantidadeUnidadesUsoPorUnidadeCompra { get; private set; }
        
        public double saldoDevolucaoUnidadeUso { get; set; }
        public double saldoVinculoPedidoUnidadeUso { get; set; }

        public double valorUnitario { get; private set; }

        public DateTime dataRecebimento { get; set; }
        private DateTime? _dataFabricacao;
        private DateTime? _dataEmbalagem;
        private DateTime? _dataValidade;

        public string Certificado { get; set; }
        public string Observacoes { get; set; }

        public LoteSituacao Status { get; private set; }

        public int qtdEtiquetas { get; set; }

        public List<LoteEstoque> gavetasEstoque { get; set; }
        public string localizacaoEstoque
        {
            get
            {
                string toRet = "";
                if (gavetasEstoque != null)
                {
                    foreach (LoteEstoque estoque in this.gavetasEstoque)
                    {
                        toRet += " / " + estoque.Gaveta.GetLocalizacaoCompleta();
                    }
                }

                if (toRet.Length > 0)
                {
                    toRet = toRet.Substring(3);
                }
                return toRet;
            }
        }
        
        private byte[] _codigoBarras;
        public byte[] codigoBarras
        {
            get
            {
                if (this._codigoBarras == null)
                {
                    this.loadCodigoBarras();
                }
                return this._codigoBarras;
            }
        }

        public string nfNumero { get;  set; }
        public string nfSerie { get;  set; }
        public DateTime nfData { get; private set; }

        public string codigoItemFornecedorCliente { get; private set; }
        public string descricaoItemFornecedorCliente { get; private set; }
        public string ncmItemFornecedorCliente { get; private set; }

        public string beneficioFiscalFornecedorCliente { get; private set; }
        public string unidadeItemFornecedorCliente { get; private set; }

        public ClienteClass Cliente
        {
            get { return _cliente; }
        }

        public FornecedorClass Fornecedor
        {
            get { return _fornecedor; }
        }

        readonly AcsUsuarioClass usuarioAtual;
        readonly IWTPostgreNpgsqlConnection conn;
        
        public LoteClass(int? ID, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            this.ID = ID;
            this.conn = conn;
            this.usuarioAtual = usuario;

            this.solicitacoesCompra = new List<LoteSolicitacao>();

            if (this.ID != null)
            {
                this.Load();
            }
            else
            {
                this.usuarioCadastro = this.usuarioAtual;
                this.dataRecebimento = Configurations.DataIndependenteClass.GetData();
            }

        }

        private void Load()
        {
            try
            {
                IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                command.CommandText =
                "SELECT  " +
                "  public.lote.id_lote, " +
                "  public.lote.id_acs_usuario, " +
                "  public.lote.id_fornecedor, " +
                "  public.lote.lot_numero, " +
                "  public.lote.lot_qtd, " +
                "  public.lote.lot_qtd_compra, " +
                "  public.lote.lot_data_recebimento, " +
                "  public.lote.lot_data_fabricacao, " +
                "  public.lote.lot_data_embalagem, " +
                "  public.lote.lot_data_validade, " +
                "  public.lote.id_cliente, " +
                "  public.lote.id_emissor_certificado, " +
                "  public.lote.id_material, " +
                "  public.lote.id_produto, " +
                "  public.lote.id_epi, " +
                "  public.lote.lot_certificado, " +
                "  public.lote.lot_obs, " +
                "  public.lote.lot_saldo_devolucao, " +
                "  public.lote.lot_situacao, " +
                "  public.lote.id_acs_usuario_cancelamento, " +
                "  public.lote.id_acs_usuario_encerramento, " +
                "  public.lote.lot_saldo_vinculo_pedido, " +
                "  public.lote.lot_nf_serie, " +
                "  public.lote.lot_nf_numero, " +
                "  public.lote.lot_nf_data, " +
                "  public.lote.lot_valor_unitario, "+
                "  public.lote.lot_codigo_item_fornecedor_cliente, "+
                "  public.lote.lot_descricao_item_fornecedor_cliente, " +
                "  public.lote.lot_ncm_item_fornecedor_cliente, "+
                "  public.lote.lot_cod_benef_fiscal_item_fornecedor_cliente, " +
                "  public.lote.lot_unidade_item_fornecedor_cliente, " +
                "  CASE  " +
                "    WHEN lote.id_produto IS NOT NULL " +
                "      THEN pro_codigo " +
                "    ELSE  public.familia_material.fam_codigo || ' ' || public.material.mat_codigo " +
                "  END AS item " +
              
                "FROM  " +
                "  public.lote " +
                "  LEFT OUTER JOIN public.material ON (public.lote.id_material = public.material.id_material) " +
                "  LEFT OUTER JOIN public.familia_material ON (public.material.id_familia_material = public.familia_material.id_familia_material) " +
                "  LEFT OUTER JOIN public.produto ON (public.lote.id_produto = public.produto.id_produto) " +
                "  LEFT OUTER JOIN public.cliente ON (public.lote.id_cliente = public.cliente.id_cliente) "+
                "  LEFT OUTER JOIN public.fornecedor ON (public.lote.id_fornecedor = public.fornecedor.id_fornecedor) " +
                "WHERE " +
                "  public.lote.id_lote = :id_lote ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                IWTPostgreNpgsqlDataReader read = command.ExecuteReader();

                if (!read.HasRows)
                {
                    throw new Exception("ID Inválido");
                }

                read.Read();

                this.usuarioCadastro = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]), usuarioAtual, this.conn);


                if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                {
                    this.usuarioCancelamento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]), usuarioAtual, this.conn);

                }


                if (read["id_acs_usuario_encerramento"] != DBNull.Value)
                {
                    this.usuarioEncerramento = AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_encerramento"]), usuarioAtual, this.conn);

                }



                if (read["id_fornecedor"] != DBNull.Value)
                {
                    this._fornecedor = FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]), usuarioAtual, conn);
                }

                if (read["id_cliente"] != DBNull.Value)
                {
                    this._cliente = ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]), usuarioAtual, conn);
                }

                if (read["id_emissor_certificado"] != DBNull.Value)
                {
                    this.idEmissorCertificado = Convert.ToInt32(read["id_emissor_certificado"]);
                }

                if (read["id_material"] != DBNull.Value)
                {
                    MaterialClass search = new MaterialClass(this.usuarioAtual, this.conn);
                    MaterialClass mat = (MaterialClass) search.Search(new List<SearchParameterClass>()
                                                                          {
                                                                              new SearchParameterClass("ID", Convert.ToInt64(read["id_material"]))
                                                                          }).FirstOrDefault();
                    if (mat == null)
                    {
                        throw new ExcecaoTratada("Não foi possível identificar o material com o id "+Convert.ToInt32(read["id_material"]));
                    }

                    this.Material = mat;
                }

                if (read["id_produto"] != DBNull.Value)
                {

                    ProdutoClass search = new ProdutoClass(this.usuarioAtual, this.conn);
                    ProdutoClass prod = (ProdutoClass)search.Search(new List<SearchParameterClass>()
                                                                          {
                                                                              new SearchParameterClass("ID", Convert.ToInt64(read["id_produto"]))
                                                                          }).FirstOrDefault();
                    if (prod == null)
                    {
                        throw new ExcecaoTratada("Não foi possível identificar o produto com o id " + Convert.ToInt32(read["id_produto"]));
                    }

                    this.Produto = prod;
                }

                if (read["id_epi"] != DBNull.Value)
                {
                    EpiClass search = new EpiClass(this.usuarioAtual, this.conn);
                    EpiClass epi = (EpiClass)search.Search(new List<SearchParameterClass>()
                                                                          {
                                                                              new SearchParameterClass("ID", Convert.ToInt64(read["id_epi"]))
                                                                          }).FirstOrDefault();
                    if (epi == null)
                    {
                        throw new ExcecaoTratada("Não foi possível identificar o epi com o id " + Convert.ToInt32(read["id_epi"]));
                    }



                    this.Epi = epi;
                }

                this.MaterialProduto = read["item"].ToString();


                this.Numero = read["lot_numero"].ToString();
                this.qtdUnidadeUso = Convert.ToDouble(read["lot_qtd"]);
                this.saldoDevolucaoUnidadeUso = Convert.ToDouble(read["lot_saldo_devolucao"]);
                this.saldoVinculoPedidoUnidadeUso = Convert.ToDouble(read["lot_saldo_vinculo_pedido"]);
                this.qtdUnidadeCompra = Convert.ToDouble(read["lot_qtd_compra"]);
                this.valorUnitario = Convert.ToDouble(read["lot_valor_unitario"]);

                this.dataRecebimento = Convert.ToDateTime(read["lot_data_recebimento"]);
                if (read["lot_data_fabricacao"] != DBNull.Value)
                {
                    this.setDataFabricacao(Convert.ToDateTime(read["lot_data_fabricacao"]));
                }
                if (read["lot_data_embalagem"] != DBNull.Value)
                {
                    this.setDataEmbalagem(Convert.ToDateTime(read["lot_data_embalagem"]));
                }

                if (read["lot_data_validade"] != DBNull.Value)
                {
                    this.setDataValidade(Convert.ToDateTime(read["lot_data_validade"]));
                }

                this.Certificado = read["lot_certificado"].ToString();
                this.Observacoes = read["lot_obs"].ToString();

                this.Status = (LoteSituacao)Enum.ToObject(typeof(LoteSituacao), read["lot_situacao"]);

                if (read["lot_nf_data"] != DBNull.Value)
                {
                    this.setNf(
                        Convert.ToDateTime(read["lot_nf_data"]),
                        read["lot_nf_serie"].ToString(),
                        read["lot_nf_numero"].ToString()
                        );
                }

                this.codigoItemFornecedorCliente = read["lot_codigo_item_fornecedor_cliente"].ToString();
                this.descricaoItemFornecedorCliente = read["lot_descricao_item_fornecedor_cliente"].ToString();
                this.ncmItemFornecedorCliente = read["lot_ncm_item_fornecedor_cliente"].ToString();
                this.beneficioFiscalFornecedorCliente = read["lot_cod_benef_fiscal_item_fornecedor_cliente"].ToString();
                this.unidadeItemFornecedorCliente = read["lot_unidade_item_fornecedor_cliente"].ToString();


                read.Close();

                command.CommandText =
                    "SELECT " +
                    "   id_lote_solicitacao_compra, " +
                    "   id_lote, " +
                    "   id_solicitacao_compra, " +
                    "   lsc_quantidade, " +
                    "   lsc_quantidade_compra, " +
                    "   lsc_recebido_com_divergencia, " +
                    "   id_acs_usuario_autorizador_divergencia, " +
                    "   lsc_preco_previsto, " +
                    "   lsc_preco_recebido, " +
                    "   lsc_icms_previsto, " +
                    "   lsc_icms_recebido, " +
                    "   lsc_ipi_previsto, " +
                    "   lsc_ipi_recebido " +
                    "  FROM " +
                    "   public.lote_solicitacao_compra  " +
                    "  WHERE " +
                    "   id_lote = :id_lote ";
                read = command.ExecuteReader();

                while (read.Read())
                {
                    this.solicitacoesCompra.Add(
                        new LoteSolicitacao(
                            Convert.ToInt32(read["id_lote_solicitacao_compra"]),
                            this,
                            new SolicitacaoCompraClass(Convert.ToInt32(read["id_solicitacao_compra"]), null, this.usuarioAtual, this.conn),
                            Convert.ToDouble(read["lsc_quantidade"]),
                            Convert.ToDouble(read["lsc_quantidade_compra"]),
                            Convert.ToDouble(read["lsc_preco_previsto"]),
                            Convert.ToDouble(read["lsc_preco_recebido"]),
                            Convert.ToDouble(read["lsc_icms_previsto"]),
                            Convert.ToDouble(read["lsc_icms_recebido"]),
                            Convert.ToDouble(read["lsc_ipi_previsto"]),
                            Convert.ToDouble(read["lsc_ipi_recebido"]),
                            Convert.ToBoolean(Convert.ToInt16(read["lsc_recebido_com_divergencia"])),
                            read["id_acs_usuario_autorizador_divergencia"] != DBNull.Value ? AcsUsuarioClass.GetEntidade(Convert.ToInt64(read["id_acs_usuario_autorizador_divergencia"]), usuarioAtual, conn) : null
                        )
                    );
                }

                read.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar os dados do Lote.\r\n" + e.Message, e);
            }
        }

        public void Salvar()
        {
            IWTPostgreNpgsqlCommand command = null;
            try
            {
                command = this.conn.CreateCommand();
                command.Transaction = this.conn.BeginTransaction();

                this.Salvar(ref command);

                command.Transaction.Commit();
            }
            catch (Exception e)
            {
                if (command != null && command.Transaction != null)
                {
                    command.Transaction.Rollback();
                }
                throw e;
            }
        }

        public void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                double qtdSolicitacoes = 0;

                //Só devem existir solicitações se o lote for de compras e não do cliente
                if (this._fornecedor != null && this._cliente == null)
                {
                    foreach (LoteSolicitacao sol in this.solicitacoesCompraAtuais)
                    {
                        qtdSolicitacoes += sol.quantidadeUnidadeUso;

                    }

                    if (Math.Abs(qtdSolicitacoes - qtdUnidadeUso) > 0.0001)
                    {
                        throw new Exception("Não é possível salvar o lote pois a quantidade do lote não é igual a soma das quantidades das solicitações.");
                    }
                }

                this.quantidadeEstoqueValida();

                #region AjustaStatus

                if (this.saldoDevolucaoUnidadeUso == 0 && this.Status == LoteSituacao.EmAberto)
                {
                    this.Status = LoteSituacao.Encerrado;
                    this.usuarioEncerramento = this.usuarioAtual;
                }

                #endregion

                bool inserting = (this.ID == null || this.ID == -1);

                if (this.ID == null)
                {
                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.lote " +
                        "( " +
                        "  id_acs_usuario, " +
                        "  id_fornecedor, " +
                        "  lot_numero, " +
                        "  lot_qtd, " +
                        "  lot_qtd_compra, " +
                        "  lot_data_recebimento, " +
                        "  lot_data_fabricacao, " +
                        "  lot_data_embalagem, " +
                        "  lot_data_validade, " +
                        "  id_cliente, " +
                        "  id_emissor_certificado, " +
                        "  id_material, " +
                        "  id_produto, " +
                        "  id_epi, " +
                        "  lot_certificado, " +
                        "  lot_obs, " +
                        "  lot_saldo_devolucao, " +
                        "  lot_situacao, " +
                        "  id_acs_usuario_cancelamento, " +
                        "  id_acs_usuario_encerramento, " +
                        "  lot_saldo_vinculo_pedido, " +
                        "  lot_nf_serie, " +
                        "  lot_nf_numero, " +
                        "  lot_nf_data, " +
                        "  lot_valor_unitario, "+
                        "  lot_codigo_item_fornecedor_cliente, "+
                        "  lot_descricao_item_fornecedor_cliente, "+
                        "  lot_ncm_item_fornecedor_cliente, "+
                        "  lot_cod_benef_fiscal_item_fornecedor_cliente, "+
                        "  lot_unidade_item_fornecedor_cliente " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_acs_usuario, " +
                        "  :id_fornecedor, " +
                        "  :lot_numero, " +
                        "  :lot_qtd, " +
                        "  :lot_qtd_compra, " +
                        "  :lot_data_recebimento, " +
                        "  :lot_data_fabricacao, " +
                        "  :lot_data_embalagem, " +
                        "  :lot_data_validade, " +
                        "  :id_cliente, " +
                        "  :id_emissor_certificado, " +
                        "  :id_material, " +
                        "  :id_produto, " +
                        "  :id_epi, " +
                        "  :lot_certificado, " +
                        "  :lot_obs, " +
                        "  :lot_saldo_devolucao, " +
                        "  :lot_situacao, " +
                        "  :id_acs_usuario_cancelamento, " +
                        "  :id_acs_usuario_encerramento, " +
                        "  :lot_saldo_vinculo_pedido, " +
                        "  :lot_nf_serie, " +
                        "  :lot_nf_numero, " +
                        "  :lot_nf_data, " +
                        "  :lot_valor_unitario, "+
                        "  :lot_codigo_item_fornecedor_cliente, " +
                        "  :lot_descricao_item_fornecedor_cliente, " +
                        "  :lot_ncm_item_fornecedor_cliente, "+
                        "  :lot_cod_benef_fiscal_item_fornecedor_cliente, "+
                        "  :lot_unidade_item_fornecedor_cliente " +
                        ") RETURNING id_lote; ";
                }
                else
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.lote   " +
                        "SET  " +
                        "  id_acs_usuario = :id_acs_usuario, " +
                        "  id_fornecedor = :id_fornecedor, " +
                        "  lot_numero = :lot_numero, " +
                        "  lot_qtd = :lot_qtd, " +
                        "  lot_qtd_compra = :lot_qtd_compra, " +
                        "  lot_data_recebimento = :lot_data_recebimento, " +
                        "  lot_data_fabricacao = :lot_data_fabricacao, " +
                        "  lot_data_embalagem = :lot_data_embalagem, " +
                        "  lot_data_validade = :lot_data_validade, " +
                        "  id_cliente = :id_cliente, " +
                        "  id_emissor_certificado = :id_emissor_certificado, " +
                        "  id_material = :id_material, " +
                        "  id_produto = :id_produto, " +
                        "  id_epi = :id_epi, " +
                        "  lot_certificado = :lot_certificado, " +
                        "  lot_obs = :lot_obs, " +
                        "  lot_saldo_devolucao = :lot_saldo_devolucao, " +
                        "  lot_situacao = :lot_situacao, " +
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " +
                        "  id_acs_usuario_encerramento = :id_acs_usuario_encerramento, " +
                        "  lot_saldo_vinculo_pedido = :lot_saldo_vinculo_pedido, " +
                        "  lot_nf_serie = :lot_nf_serie, " +
                        "  lot_nf_numero = :lot_nf_numero, " +
                        "  lot_nf_data = :lot_nf_data, " +
                        "  lot_valor_unitario = :lot_valor_unitario, "+
                        "  lot_codigo_item_fornecedor_cliente = :lot_codigo_item_fornecedor_cliente, " +
                        "  lot_descricao_item_fornecedor_cliente = :lot_descricao_item_fornecedor_cliente, " +
                        "  lot_ncm_item_fornecedor_cliente = :lot_ncm_item_fornecedor_cliente, "+
                        "  lot_cod_benef_fiscal_item_fornecedor_cliente = :lot_cod_benef_fiscal_item_fornecedor_cliente, "+
                        "  lot_unidade_item_fornecedor_cliente = :lot_unidade_item_fornecedor_cliente " +
                        "WHERE  " +
                        "  id_lote = :id_lote " +
                        " RETURNING id_lote ";

                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.usuarioCadastro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._fornecedor != null ? (object) this._fornecedor.ID : null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Numero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_qtd", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.qtdUnidadeUso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_qtd_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.qtdUnidadeCompra;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_recebimento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this.dataRecebimento;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_fabricacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this._dataFabricacao;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_embalagem", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this._dataEmbalagem;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_validade", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = this._dataValidade;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this._cliente != null ? (object)this._cliente.ID : null;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_emissor_certificado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.idEmissorCertificado;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                if (this.Material != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Material.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                if (this.Produto != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Produto.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                if (this.Epi != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.Epi.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_certificado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Certificado;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.Observacoes;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_saldo_devolucao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.saldoDevolucaoUnidadeUso;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_saldo_vinculo_pedido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.saldoVinculoPedidoUnidadeUso;


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                if (this.usuarioCancelamento != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioCancelamento.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_encerramento", NpgsqlDbType.Integer));
                if (this.usuarioEncerramento != null)
                {
                    command.Parameters[command.Parameters.Count - 1].Value = this.usuarioEncerramento.ID;
                }
                else
                {
                    command.Parameters[command.Parameters.Count - 1].Value = null;
                }


                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.nfSerie;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.nfNumero;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = this.nfData;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_valor_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.valorUnitario;

                
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_codigo_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.codigoItemFornecedorCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_descricao_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.descricaoItemFornecedorCliente;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_ncm_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.ncmItemFornecedorCliente;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_cod_benef_fiscal_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.beneficioFiscalFornecedorCliente;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_unidade_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = this.unidadeItemFornecedorCliente;
                

                object tmp = command.ExecuteScalar();



                this.ID = Convert.ToInt32(tmp);

                if (this.Numero == null || this.Numero.Length == 0)
                {
                    this.Numero = this.ID.ToString().PadLeft(5, '0');
                    this.Salvar(ref command);
                }


                foreach (LoteSolicitacao solicita in this.solicitacoesCompra)
                {
                    solicita.Salvar(ref command);
                }

                if (this.gavetasEstoque != null)
                {
                    foreach (LoteEstoque lte in this.gavetasEstoque.Where(a => !a.Salvo && a.Quantidade > 0))
                    {
                        if (this.Produto != null)
                        {
                            EstoqueMovimentacao.LancaMovimentoEstoqueProduto(lte.Gaveta, this.Produto, lte.Quantidade,
                                                                             "Recebimento de NFe", this.nfNumero,
                                                                             this.usuarioAtual, false, ref command);

                        }
                        else
                        {
                            if (this.Epi != null)
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueEpi(lte.Gaveta, this.Epi, lte.Quantidade,
                                                                                 "Recebimento de NFe", this.nfNumero,
                                                                                 this.usuarioAtual, false, ref command);

                            }
                            else
                            {
                                EstoqueMovimentacao.LancaMovimentoEstoqueMaterial(lte.Gaveta, this.Material,
                                                                                  lte.Quantidade, "Recebimento de NFe",
                                                                                  this.nfNumero, this.usuarioAtual, false,
                                                                                  ref command);


                            }

                        }
                        lte.setSalvo();
                    }
                }

                if (inserting && Fornecedor !=null)
                {
                    long idSimulador = -1;
                    if (Produto != null)
                    {

                        ProdutoFornecedorClass produtoFornecedor = Produto.CollectionProdutoFornecedorClassProduto.FirstOrDefault(a => a.Ativo && a.Fornecedor.ID == this.Fornecedor.ID);
                        if (produtoFornecedor == null)
                        {
                            throw new ExcecaoTratada("Erro inesperado ao identificar o produto fornecedor para o SDC. Informe o Suporte IWT");
                        }

                        idSimulador = produtoFornecedor.ID + 10000000;
                        ApiSimuladorCompras.SincronizarProdutoFornecedor(idSimulador, false, usuarioAtual, command);
                    }

                    if (Material != null)
                    {
                        MaterialFornecedorClass materialFornecedor = Material.CollectionMaterialFornecedorClassMaterial.FirstOrDefault(a => a.Ativo && a.Fornecedor.ID == this.Fornecedor.ID);
                        if (materialFornecedor == null)
                        {
                            throw new ExcecaoTratada("Erro inesperado ao identificar o material fornecedor para o SDC. Informe o Suporte IWT");
                        }

                        idSimulador = materialFornecedor.ID + 20000000;
                        ApiSimuladorCompras.SincronizarMaterialFornecedor(idSimulador, false, usuarioAtual, command);
                    }

                    if (Epi != null)
                    {
                        EpiFornecedorClass epiFornecedor = Epi.CollectionEpiFornecedorClassEpi.FirstOrDefault(a => a.Ativo && a.Fornecedor.ID == this.Fornecedor.ID);
                        if (epiFornecedor == null)
                        {
                            throw new ExcecaoTratada("Erro inesperado ao identificar o epi fornecedor para o SDC. Informe o Suporte IWT");
                        }

                        idSimulador = epiFornecedor.ID + 30000000;
                        ApiSimuladorCompras.SincronizarEpiFornecedor(idSimulador, false, usuarioAtual, command);
                    }

                }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o lote.\r\n" + e.Message, e);
            }
        }

        public void Salvar2(ref IWTPostgreNpgsqlCommand command)
        {
            if (this.Produto != null)
            {
                this.Produto.DesabilitarJustificativaRevisaoProduto = true;
                this.Produto.Save(ref command);
                this.Produto.DesabilitarJustificativaRevisaoProduto = false;
            }
            else
            {
                if (Material != null)
                {
                    this.Material.ControleRevisaoHabilitado = false;
                    this.Material.Save(ref command);
                }
                else
                {
                    if (Epi != null)
                    {
                        this.Epi.ControleRevisaoHabilitado = false;
                        this.Epi.Save(ref command);
                    }
                }
            }
        }

        private void loadCodigoBarras()
        {
            try
            {
                if (this.ID == null)
                {
                    return;
                }

                string tempDir = Environment.GetEnvironmentVariable("temp");

                Process process = new Process();
                process.StartInfo.WorkingDirectory = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\";
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.FileName = @AppDomain.CurrentDomain.BaseDirectory + "\\barcode\\barcode.exe";

                process.StartInfo.Arguments = "LT|" + this.ID.ToString() + " " + tempDir + "\\code.bmp";

                process.Start();
                process.WaitForExit();

                FileStream fs = new FileStream(@tempDir + "\\code.bmp", FileMode.Open);
                BinaryReader br = new BinaryReader(fs);
                this._codigoBarras = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao montar o código de barras.\r\n" + e.Message, e);
            }

        }

        public void adicionarSolicitacao(SolicitacaoCompraClass Solicitacao, double qtdUnidadeUso, double qtdUnidadeCompra, 
            double precoPrevisto, double precoRecebido,
            double icmsPrevisto, double icmsRecebido, 
            double ipiPrevisto, double ipiRecebido,
            bool aprovadoComDivergencia, AcsUsuarioClass usuarioAprovador
            )
        {
            try
            {
                if (Solicitacao.saldoEntrega >= qtdUnidadeCompra)
                {

                    this.solicitacoesCompra.Add(
                        new LoteSolicitacao(
                            null, this, Solicitacao, qtdUnidadeUso, qtdUnidadeCompra,
                            precoPrevisto,precoRecebido,
                            icmsPrevisto,icmsRecebido,
                            ipiPrevisto,ipiRecebido,
                            aprovadoComDivergencia,
                            usuarioAprovador));
                }
                else
                {
                    if (Solicitacao.SaldoEntregaMaximo >= qtdUnidadeCompra)
                    {
                        double difQtd = Math.Round(qtdUnidadeCompra - Solicitacao.saldoEntrega, 4, MidpointRounding.ToEven);
                        Solicitacao.Quantidade = Solicitacao.Quantidade + difQtd;

                        this.solicitacoesCompra.Add(
                            new LoteSolicitacao(
                                null, this, Solicitacao, qtdUnidadeUso, qtdUnidadeCompra,
                                precoPrevisto, precoRecebido,
                                icmsPrevisto, icmsRecebido,
                                ipiPrevisto, ipiRecebido,
                                aprovadoComDivergencia,
                                usuarioAprovador));

                    }
                    else
                    {
                        throw new Exception("A solicitação selecionada não possui saldo suficiente.");
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao adicionar a solicitação ao lote.\r\n" + e.Message, e);
            }
        }

        public void removerTodasSolicitacoes()
        {
            try
            {
                while (this.solicitacoesCompraAtuais.Count > 0)
                {
                    this.solicitacoesCompraAtuais[0].Excluir();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao remover as solicitações do lote.\r\n" + e.Message, e);
            }
        }

        public void setGavetasEstoque(List<EstoqueGavetaClass> Gavetas)
        {
            try
            {
                this.gavetasEstoque = new List<LoteEstoque>();
                EstoqueGavetaClass gavUtilizacaoRecente = null;
                DateTime? dataUtilizacaoGavetaRecente = null;
                foreach (EstoqueGavetaClass gav in Gavetas)
                {
                    DateTime? dataUltimaUtilizacao = gav.BuscaDataUltimaMovimentacaoItem(
                        this.Produto,
                        this.Material,
                        null,
                        null,
                        null,
                        this.Epi
                        );

                    if (gavUtilizacaoRecente == null || (dataUltimaUtilizacao.HasValue && !dataUtilizacaoGavetaRecente.HasValue) || (dataUltimaUtilizacao.HasValue && dataUltimaUtilizacao.Value > dataUtilizacaoGavetaRecente.Value))
                    {
                        gavUtilizacaoRecente = gav;
                        dataUtilizacaoGavetaRecente = dataUltimaUtilizacao;
                    }

                    this.gavetasEstoque.Add(new LoteEstoque(gav));
                    
                }

                if (this.gavetasEstoque.Count > 0)
                {
                    if (gavUtilizacaoRecente == null)
                    {

                        this.gavetasEstoque[0].Quantidade = Math.Round(this.gavetasEstoque[0].Quantidade + this.qtdUnidadeUso, 5);
                    }
                    else
                    {
                        LoteEstoque gav = this.gavetasEstoque.First(a => a.Gaveta == gavUtilizacaoRecente);
                        gav.Quantidade = Math.Round(gav.Quantidade + this.qtdUnidadeUso, 5);
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir as gavetas disponiveis de estoque\r\n" + e.Message, e);
            }
        }

        public void removerTodasGavetas()
        {
            this.gavetasEstoque = new List<LoteEstoque>();
        }

        public void quantidadeEstoqueValida()
        {
            if (this.gavetasEstoque != null)
            {

                double qtdEstoque = 0;
                foreach (LoteEstoque lte in this.gavetasEstoque.Where(a => a.Quantidade > 0))
                {
                    qtdEstoque += lte.Quantidade;
                }


                qtdEstoque = Math.Round(qtdEstoque, 5);
                qtdUnidadeUso = Math.Round(qtdUnidadeUso, 5);
                if (Math.Abs(qtdEstoque - this.qtdUnidadeUso) > 0.000001)
                {
                    throw new Exception("A quantidade do lote não é igual a soma das quantidades dos estoques. A soma deve ser igual a " + this.qtdUnidadeUso.ToString("F4", CultureInfo.CurrentCulture));
                }
            }
        }

        public void setFornecedorCliente(FornecedorClass fornecedor, ClienteClass cliente)
        {
            this._fornecedor = fornecedor;
            this._cliente = cliente;
            
            
        }

        public void setEmissorCertificado(int? Id, string Identificacao)
        {
            this.idEmissorCertificado = idEmissorCertificado;
            this.emissorCertificado = Identificacao;
        }

        public void setMaterialProduto(BibliotecaEntidades.Entidades.MaterialClass material, BibliotecaEntidades.Entidades.ProdutoClass produto, EpiClass epi, string Identificacao,
            string codigoItemFornecedorCliente, string descricaoItemFornecedorCliente, string ncmItemFornecedorCliente, string beneficioFiscalFornecedorCliente,
            string unidadeItemFornecedorCliente, double valorUnitario)
        {
            this.Material = material;
            this.Produto = produto;
            this.Epi = epi;
            this.MaterialProduto = Identificacao;
            this.valorUnitario = valorUnitario;
            this.codigoItemFornecedorCliente = codigoItemFornecedorCliente;
            this.descricaoItemFornecedorCliente = descricaoItemFornecedorCliente;
            this.ncmItemFornecedorCliente = ncmItemFornecedorCliente;
            this.unidadeItemFornecedorCliente = unidadeItemFornecedorCliente;
            this.beneficioFiscalFornecedorCliente = beneficioFiscalFornecedorCliente;
        }

        public void setQuantidade(double novaQuantidadeUnidadeUso, double novaQuantidadeUnidadeUsoCompra, double quantidadeUnidadesUsoPorUnidadeCompra)
        {
            try
            {
                if (novaQuantidadeUnidadeUso < saldoDevolucaoUnidadeUso)
                {
                    throw new Exception("A nova quantidade é menor que o saldo de devolução.");
                }

                if (novaQuantidadeUnidadeUso < saldoVinculoPedidoUnidadeUso)
                {
                    throw new Exception("A nova quantidade é menor que o saldo de vinculo com os pedidos.");
                }

                double qtdAnterior = this.qtdUnidadeUso;
                this.saldoDevolucaoUnidadeUso = this.saldoDevolucaoUnidadeUso + (novaQuantidadeUnidadeUso - qtdAnterior);
                this.saldoVinculoPedidoUnidadeUso = this.saldoVinculoPedidoUnidadeUso + (novaQuantidadeUnidadeUso - qtdAnterior);
                this.qtdUnidadeUso = novaQuantidadeUnidadeUso;
                this.qtdUnidadeCompra = novaQuantidadeUnidadeUsoCompra;
                this.quantidadeUnidadesUsoPorUnidadeCompra = quantidadeUnidadesUsoPorUnidadeCompra;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao definir a quantidade.\r\n" + e.Message, e);
            }

        }

        public DateTime? getDataFabricacao()
        {
            return this._dataFabricacao;
        }

        public void setDataFabricacao(DateTime? dataFabricacao)
        {
            this._dataFabricacao = dataFabricacao;
        }

        public DateTime? getDataEmbalagem()
        {
            return this._dataEmbalagem;
        }

        public void setDataEmbalagem(DateTime? dataEmbalagem)
        {
            this._dataEmbalagem = dataEmbalagem;
        }

        public DateTime? getDataValidade()
        {
            return this._dataValidade;
        }

        public void setDataValidade(DateTime? dataValidade)
        {
            this._dataValidade = dataValidade;
        }

        public int? getIdEmissorCertificado()
        {
            return this.idEmissorCertificado;
        }
        public void setIdEmissorCertificado(int? idEmissorCertificado)
        {
            this.idEmissorCertificado = idEmissorCertificado;
        }

       

        public long? getIdMaterial()
        {
            if (this.Material != null)
            {
                return this.Material.ID;
            }
            else
            {
                return null;
            }
        }

        public long? getIdProduto()
        {
            if (this.Produto != null)
            {
                return this.Produto.ID;
            }
            else
            {
                return null;
            }
        }

        public long? getIdEpi()
        {
            if (this.Epi != null)
            {
                return this.Epi.ID;
            }
            else
            {
                return null;
            }
        }

        public int? getID()
        {
            return this.ID;
        }

        public void setNf(DateTime Data, string Serie, string Numero)
        {
            this.nfData = Data;
            this.nfSerie = Serie;
            this.nfNumero = Numero;
        }

        public void baixarSaldo(double Quantidade)
        {
            try
            {
                if (Quantidade > this.saldoDevolucaoUnidadeUso)
                {
                    throw new Exception("A quantidade a baixar é maior do que saldo de devolução.");
                }

                this.saldoDevolucaoUnidadeUso -= Quantidade;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao baixar o saldo do lote\r\n" + e.Message, e);
            }

        }

        public void baixarSaldoPedido(double Quantidade)
        {
            try
            {
                if (Quantidade > this.saldoVinculoPedidoUnidadeUso)
                {
                    throw new Exception("A quantidade a baixar é maior do que saldo de vinculo com os pedidos.");
                }

                this.saldoVinculoPedidoUnidadeUso -= Quantidade;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao baixar o saldo de vinculo do pedido do lote\r\n" + e.Message, e);
            }

        }

        public void Cancelar()
        {
            try
            {
                this.Status = LoteSituacao.Cancelado;
                this.usuarioCancelamento = this.usuarioAtual;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao cancelar o lote.\r\n" + e.Message, e);
            }
        }

        public void ForcarEncerramento()
        {
            try
            {
                this.saldoDevolucaoUnidadeUso = 0;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao encerrar o lote.\r\n" + e.Message, e);
            }
        }

        public override string ToString()
        {
            return this.Numero;
        }

        private void loadUnidades()
        {
            try
            {

                if (this.solicitacoesCompraAtuais != null && this.solicitacoesCompraAtuais.Count > 0)
                {
                    this._unidadeUso = this.solicitacoesCompraAtuais[0].Solicitacao.unidadeUsoProdutoMaterial;
                    this._unidadeCompra = this.solicitacoesCompraAtuais[0].Solicitacao.UnidadeCompra;
                }
                else
                {
                    IWTPostgreNpgsqlCommand command = this.conn.CreateCommand();
                    if (this.Produto != null)
                    {
                        command.CommandText =
                            "SELECT  " +
                            "  unidade_medida_compra.unm_abreviada as unidade_compra, " +
                            "  unidade_medida_uso.unm_abreviada as unidade_uso " +
                            "FROM " +
                            "  public.produto " +
                            "  LEFT OUTER JOIN public.unidade_medida unidade_medida_uso ON (unidade_medida_uso.id_unidade_medida = public.produto.id_unidade_medida) " +
                            "  LEFT OUTER JOIN public.unidade_medida unidade_medida_compra ON (public.produto.id_unidade_medida_compra = unidade_medida_compra.id_unidade_medida) " +
                            "WHERE " +
                            "  public.produto.id_produto = " + this.Produto.ID + " ";
                    }
                    else
                    {
                        if (this.Material != null)
                        {
                            command.CommandText =
                                "SELECT  " +
                                "  unidade_medida_compra.unm_abreviada as unidade_compra, " +
                                "  unidade_medida_uso.unm_abreviada as unidade_uso " +
                                "FROM " +
                                "  public.material " +
                                "  LEFT OUTER JOIN public.unidade_medida unidade_medida_uso ON (unidade_medida_uso.id_unidade_medida = public.material.id_unidade_medida) " +
                                "  LEFT OUTER JOIN public.unidade_medida unidade_medida_compra ON (public.material.id_unidade_medida_compra = unidade_medida_compra.id_unidade_medida) " +
                                "WHERE " +
                                "  public.material.id_material = " + this.Material.ID + " ";
                        }
                        else
                        {
                            if (this.Epi != null)
                            {
                                command.CommandText =
                                    "SELECT  " +
                                    "  unidade_medida_compra.unm_abreviada as unidade_compra, " +
                                    "  unidade_medida_uso.unm_abreviada as unidade_uso " +
                                    "FROM " +
                                    "  public.epi " +
                                    "  LEFT OUTER JOIN public.unidade_medida unidade_medida_uso ON (unidade_medida_uso.id_unidade_medida = public.epi.id_unidade_medida_uso) " +
                                    "  LEFT OUTER JOIN public.unidade_medida unidade_medida_compra ON (public.epi.id_unidade_medida_compra = unidade_medida_compra.id_unidade_medida) " +
                                    "WHERE " +
                                    "  public.epi.id_epi = " + this.Epi.ID.ToString() + " ";
                            }
                            else
                            {
                                return;
                            }
                        }
                    }

                    IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
                    if (!read.HasRows)
                    {
                        throw new Exception("ID Inválido");
                    }
                    read.Read();
                    this._unidadeUso = read["unidade_uso"].ToString();
                    this._unidadeCompra = read["unidade_compra"].ToString();
                    read.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao carregar as unidades\r\n" + e.Message, e);
            }
        }

    }

    public class LoteSolicitacao
    {
        public int? ID { get; private set; }
        public LoteClass Lote { get; private set; }
        public SolicitacaoCompraClass Solicitacao { get; private set; }
        public double quantidadeUnidadeUso { get; private set; }
        public double quantidadeUnidadeCompra { get; private set; }

        private double quantidadeUnidadeUsoOriginal = 0;
        private double quantidadeUnidadeCompraOriginal = 0;


        private double _precoPrevisto;
        private double _precoRecebido;
        private double _icmsPrevisto;
        private double _icmsRecebido;
        private double _ipiPrevisto;
        private double _ipiRecebido;

        private bool _aprovadoComDivergencia;
        private AcsUsuarioClass _usuarioAprovadorDivergencia;




        public bool toDelete { get; private set; }



        public LoteSolicitacao(int? ID, LoteClass Lote, SolicitacaoCompraClass Solicitacao, double quantidadeUnidadeUso, double quantidadeUnidadeCompra, double precoPrevisto, double precoRecebido, double icmsPrevisto, double icmsRecebido, double ipiPrevisto, double ipiRecebido, bool aprovadoComDivergencia, AcsUsuarioClass usuarioAprovadorDivergencia)
        {
            this.ID = ID;
            this.Lote = Lote;
            this.Solicitacao = Solicitacao;
            this.quantidadeUnidadeUso = quantidadeUnidadeUso;
            this.quantidadeUnidadeCompra = quantidadeUnidadeCompra;

            _precoPrevisto = precoPrevisto;
            _precoRecebido = precoRecebido;
            _icmsPrevisto = icmsPrevisto;
            _icmsRecebido = icmsRecebido;
            _ipiPrevisto = ipiPrevisto;
            _ipiRecebido = ipiRecebido;
            _usuarioAprovadorDivergencia = usuarioAprovadorDivergencia;
            _aprovadoComDivergencia = aprovadoComDivergencia;

            this.toDelete = false;

            if (this.ID == null)
            {
                this.quantidadeUnidadeUsoOriginal = 0;
                this.quantidadeUnidadeCompraOriginal = 0;
                this.Solicitacao.lancarBaixa(this.quantidadeUnidadeCompra);
            }
            else
            {
                this.quantidadeUnidadeUsoOriginal = this.quantidadeUnidadeUso;
                this.quantidadeUnidadeCompraOriginal = this.quantidadeUnidadeCompra;
            }
        }

        public void alterarQuantidade(double novaQuantidadeUnidadeUso, double novaQuantidadeUnidadeCompra)
        {
            try
            {
                double qtdAnterior = this.quantidadeUnidadeCompra;

                double qtdBaixa = 0;
                if (this.quantidadeUnidadeCompraOriginal == qtdAnterior)
                {

                    qtdBaixa = -1*(this.quantidadeUnidadeCompraOriginal - novaQuantidadeUnidadeCompra);

                    this.Solicitacao.lancarBaixa(qtdBaixa);
                }
                else
                {
                    qtdBaixa = -1*(qtdAnterior - novaQuantidadeUnidadeCompra);
                    this.Solicitacao.lancarBaixa(qtdBaixa);
                }

                this.quantidadeUnidadeUso = novaQuantidadeUnidadeUso;
                this.quantidadeUnidadeCompra = novaQuantidadeUnidadeCompra;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao alterar a quantidade.\r\n" + e.Message, e);
            }
        }

        public void Excluir()
        {
            try
            {
                this.toDelete = true;
                this.alterarQuantidade(0, 0);
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao excluir.\r\n" + e.Message, e);
            }
        }

        public void Salvar(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.toDelete)
                {
                    if (this.quantidadeUnidadeCompra != this.quantidadeUnidadeCompraOriginal)
                    {
                        this.Solicitacao.lancarBaixa(-1 * (this.quantidadeUnidadeCompraOriginal - this.quantidadeUnidadeCompra));
                        this.Solicitacao.Save(ref command, null, false);
                        this.quantidadeUnidadeCompraOriginal = this.quantidadeUnidadeCompra;
                    }

                    if (this.ID != null)
                    {
                        command.CommandText =
                        "DELETE FROM  " +
                        "  public.lote_solicitacao_compra  " +
                        "WHERE  " +
                        "  id_lote_solicitacao_compra = :id_lote_solicitacao_compra " +
                        "; ";
                        command.Parameters.Clear();

                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote_solicitacao_compra", NpgsqlDbType.Integer));
                        command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                        command.ExecuteNonQuery();
                    }

                    return;

                }

                if (this.ID == null)
                {

                    this.Solicitacao.Save(ref command, null, false);
                    this.quantidadeUnidadeUsoOriginal = this.quantidadeUnidadeUso;

                    command.CommandText =
                        "INSERT INTO  " +
                        "  public.lote_solicitacao_compra " +
                        "( " +
                        "  id_lote, " +
                        "  id_solicitacao_compra, " +
                        "  lsc_quantidade, " +
                        "  lsc_quantidade_compra, "+
                        "  lsc_recebido_com_divergencia, " +
                        "  id_acs_usuario_autorizador_divergencia, " +
                        "  lsc_preco_previsto, " +
                        "  lsc_preco_recebido, " +
                        "  lsc_icms_previsto, " +
                        "  lsc_icms_recebido, " +
                        "  lsc_ipi_previsto, " +
                        "  lsc_ipi_recebido " +
                        ")  " +
                        "VALUES ( " +
                        "  :id_lote, " +
                        "  :id_solicitacao_compra, " +
                        "  :lsc_quantidade, " +
                        "  :lsc_quantidade_compra, "+
                        "  :lsc_recebido_com_divergencia, " +
                        "  :id_acs_usuario_autorizador_divergencia, " +
                        "  :lsc_preco_previsto, " +
                        "  :lsc_preco_recebido, " +
                        "  :lsc_icms_previsto, " +
                        "  :lsc_icms_recebido, " +
                        "  :lsc_ipi_previsto, " +
                        "  :lsc_ipi_recebido " +
                        ") RETURNING  id_lote_solicitacao_compra; ";


                }
                else
                {
                    if (this.quantidadeUnidadeUso != this.quantidadeUnidadeUsoOriginal)
                    {
                        this.Solicitacao.Save(ref command, null, false);
                        this.quantidadeUnidadeUsoOriginal = this.quantidadeUnidadeUso;
                    }

                    command.CommandText =
                        "UPDATE  " +
                        "  public.lote_solicitacao_compra   " +
                        "SET  " +
                        "  id_lote = :id_lote, " +
                        "  id_solicitacao_compra = :id_solicitacao_compra, " +
                        "  lsc_quantidade = :lsc_quantidade, " +
                        "  lsc_quantidade_compra = :lsc_quantidade_compra, "+
                        "  lsc_recebido_com_divergencia = :lsc_recebido_com_divergencia, " +
                        "  id_acs_usuario_autorizador_divergencia = :id_acs_usuario_autorizador_divergencia, " +
                        "  lsc_preco_previsto = :lsc_preco_previsto, " +
                        "  lsc_preco_recebido = :lsc_preco_recebido, " +
                        "  lsc_icms_previsto = :lsc_icms_previsto, " +
                        "  lsc_icms_recebido = :lsc_icms_recebido, " +
                        "  lsc_ipi_previsto = :lsc_ipi_previsto, " +
                        "  lsc_ipi_recebido = :lsc_ipi_recebido " +
                        "WHERE  " +
                        "  id_lote_solicitacao_compra = :id_lote_solicitacao_compra " +
                        "; ";

                   
                }

                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Lote.getID();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.Solicitacao.idSolicitacaoCompra;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.quantidadeUnidadeUso;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_quantidade_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = this.quantidadeUnidadeCompra;

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_recebido_com_divergencia", NpgsqlDbType.Smallint,Convert.ToInt16(_aprovadoComDivergencia)));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_autorizador_divergencia", NpgsqlDbType.Bigint, _usuarioAprovadorDivergencia == null ? (long?)null : _usuarioAprovadorDivergencia.ID));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_preco_previsto", NpgsqlDbType.Double,_precoPrevisto));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_preco_recebido", NpgsqlDbType.Double,_precoRecebido));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_icms_previsto", NpgsqlDbType.Double,_icmsPrevisto));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_icms_recebido", NpgsqlDbType.Double,_icmsRecebido));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_ipi_previsto", NpgsqlDbType.Double,_ipiPrevisto));
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_ipi_recebido", NpgsqlDbType.Double,_ipiRecebido));

                this.ID = Convert.ToInt32(command.ExecuteScalar());

                

            }

            catch (Exception e)
            {
                throw new Exception("Erro ao salvar o lote solicitação.\r\n" + e.Message, e);
            }
        }
    }

    public class LoteEstoque : IComparable<LoteEstoque>
    {
        EstoqueGavetaClass _Gaveta;
        public EstoqueGavetaClass Gaveta
        {
            get
            {
                return this._Gaveta;
            }

            set
            {
                this._Gaveta = value;
                this.Salvo = false;
            }
        }
        double _Quantidade;
        public double Quantidade
        {
            get
            {
                return this._Quantidade;
            }
            set
            {
                this._Quantidade = value;
                this.Salvo = false;
            }
        }
        public bool Salvo { get; private set; }

        public LoteEstoque(EstoqueGavetaClass Gaveta)
        {
            this.Gaveta = Gaveta;
            this.Quantidade = 0;
            this.Salvo = false;
        }

        public void setSalvo()
        {
            this.Salvo = true;
        }

        #region IComparable<LoteEstoque> Members

        public int CompareTo(LoteEstoque other)
        {
            int identiThis;
            int identOther; 
            //Estoques Iguais
            if (this.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.ID == other.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.ID)
            {
                //Corredores Iguais
                if (this.Gaveta.EstoquePrateleira.EstoqueCorredor.ID == other.Gaveta.EstoquePrateleira.EstoqueCorredor.ID)
                {
                    //Gavetas Iguais
                    if (this.Gaveta.ID == other.Gaveta.ID)
                    {
                        return 0;
                    }
                    else
                    {

                        if (int.TryParse(this.Gaveta.Identificacao, out identiThis) && int.TryParse(other.Gaveta.Identificacao, out identOther))
                        {
                            return identiThis.CompareTo(identOther);
                        }
                        else
                        {
                            return this.Gaveta.Identificacao.CompareTo(other.Gaveta.Identificacao);
                        }
                    }
                }
                else
                {

                    if (int.TryParse(this.Gaveta.EstoquePrateleira.EstoqueCorredor.Identificacao, out identiThis) && int.TryParse(other.Gaveta.EstoquePrateleira.EstoqueCorredor.Identificacao, out identOther))
                    {
                        return identiThis.CompareTo(identOther);
                    }
                    else
                    {
                        return this.Gaveta.EstoquePrateleira.EstoqueCorredor.Identificacao.CompareTo(other.Gaveta.EstoquePrateleira.EstoqueCorredor.Identificacao);
                    }
                }
            }
            else
            {

                if (int.TryParse(this.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao, out identiThis) && int.TryParse(other.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao, out identOther))
                {
                    return identiThis.CompareTo(identOther);
                }
                else
                {
                    return this.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao.CompareTo(other.Gaveta.EstoquePrateleira.EstoqueCorredor.Estoque.Identificacao);
                }
            }
        }

        #endregion
    }
}
