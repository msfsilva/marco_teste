using System; 
using System.Collections.Generic; 
using System.Collections.ObjectModel;
using System.Collections.Specialized; 
using System.ComponentModel; 
 using System.Diagnostics; 
using System.Linq; 
using System.Text; 
using System.Security.Cryptography;
using IWTDotNetLib.ComplexLoginModule; 
using IWTDotNetLib; 
using IWTPostgreNpgsql; 
using Npgsql; 
using NpgsqlTypes; 
using BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("solicitacao_compra","soc")]
     public class SolicitacaoCompraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do SolicitacaoCompraClass";
protected const string ErroDelete = "Erro ao excluir o SolicitacaoCompraClass  ";
protected const string ErroSave = "Erro ao salvar o SolicitacaoCompraClass.";
protected const string ErroCollectionLoteSolicitacaoCompraClassSolicitacaoCompra = "Erro ao carregar a coleção de LoteSolicitacaoCompraClass.";
protected const string ErroCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra = "Erro ao carregar a coleção de SolicitacaoCompraFeedbackClass.";
protected const string ErroCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra = "Erro ao carregar a coleção de SolicitacaoCompraPedidoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroUnidadeCompraObrigatorio = "O campo UnidadeCompra é obrigatório";
protected const string ErroUnidadeCompraComprimento = "O campo UnidadeCompra deve ter no máximo 255 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do SolicitacaoCompraClass.";
protected const string MensagemUtilizadoCollectionLoteSolicitacaoCompraClassSolicitacaoCompra =  "A entidade SolicitacaoCompraClass está sendo utilizada nos seguintes LoteSolicitacaoCompraClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra =  "A entidade SolicitacaoCompraClass está sendo utilizada nos seguintes SolicitacaoCompraFeedbackClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra =  "A entidade SolicitacaoCompraClass está sendo utilizada nos seguintes SolicitacaoCompraPedidoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade SolicitacaoCompraClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.MaterialClass _materialOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MaterialClass _materialOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MaterialClass _valueMaterial;
        [Column("id_material", "material", "id_material")]
       public virtual BibliotecaEntidades.Entidades.MaterialClass Material
        { 
           get {                 return this._valueMaterial; } 
           set 
           { 
                if (this._valueMaterial == value)return;
                 this._valueMaterial = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _produtoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoClass _valueProduto;
        [Column("id_produto", "produto", "id_produto")]
       public virtual BibliotecaEntidades.Entidades.ProdutoClass Produto
        { 
           get {                 return this._valueProduto; } 
           set 
           { 
                if (this._valueProduto == value)return;
                 this._valueProduto = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OrdemCompraClass _ordemCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemCompraClass _ordemCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemCompraClass _valueOrdemCompra;
        [Column("id_ordem_compra", "ordem_compra", "id_ordem_compra")]
       public virtual BibliotecaEntidades.Entidades.OrdemCompraClass OrdemCompra
        { 
           get {                 return this._valueOrdemCompra; } 
           set 
           { 
                if (this._valueOrdemCompra == value)return;
                 this._valueOrdemCompra = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuario;
        [Column("id_acs_usuario", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuario
        { 
           get {                 return this._valueAcsUsuario; } 
           set 
           { 
                if (this._valueAcsUsuario == value)return;
                 this._valueAcsUsuario = value; 
           } 
       } 

       protected double? _qtdOriginal{get;private set;}
       private double? _qtdOriginalCommited{get; set;}
        private double? _valueQtd;
         [Column("soc_qtd")]
        public virtual double? Qtd
         { 
            get { return this._valueQtd; } 
            set 
            { 
                if (this._valueQtd == value)return;
                 this._valueQtd = value; 
            } 
        } 

       protected StatusSolicitacaoCompra? _statusOriginal{get;private set;}
       private StatusSolicitacaoCompra? _statusOriginalCommited{get; set;}
        private StatusSolicitacaoCompra? _valueStatus;
         [Column("soc_status")]
        public virtual StatusSolicitacaoCompra? Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_Nova
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.Nova; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.Nova; }
         } 

        public bool Status_AprovadaPCP
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.AprovadaPCP; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.AprovadaPCP; }
         } 

        public bool Status_AprovadaCompras
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.AprovadaCompras; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.AprovadaCompras; }
         } 

        public bool Status_Comprada
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.Comprada; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.Comprada; }
         } 

        public bool Status_RecebidaParcial
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.RecebidaParcial; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.RecebidaParcial; }
         } 

        public bool Status_RecebidaTotal
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.RecebidaTotal; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.RecebidaTotal; }
         } 

        public bool Status_Cancelada
         { 
            get { return this._valueStatus.HasValue && this._valueStatus.Value == BibliotecaEntidades.Base.StatusSolicitacaoCompra.Cancelada; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusSolicitacaoCompra.Cancelada; }
         } 

       protected DateTime? _dataAberturaOriginal{get;private set;}
       private DateTime? _dataAberturaOriginalCommited{get; set;}
        private DateTime? _valueDataAbertura;
         [Column("soc_data_abertura")]
        public virtual DateTime? DataAbertura
         { 
            get { return this._valueDataAbertura; } 
            set 
            { 
                if (this._valueDataAbertura == value)return;
                 this._valueDataAbertura = value; 
            } 
        } 

       protected double? _saldoRecebimentoOriginal{get;private set;}
       private double? _saldoRecebimentoOriginalCommited{get; set;}
        private double? _valueSaldoRecebimento;
         [Column("soc_saldo_recebimento")]
        public virtual double? SaldoRecebimento
         { 
            get { return this._valueSaldoRecebimento; } 
            set 
            { 
                if (this._valueSaldoRecebimento == value)return;
                 this._valueSaldoRecebimento = value; 
            } 
        } 

       protected DateTime? _entregaPrevistaOriginal{get;private set;}
       private DateTime? _entregaPrevistaOriginalCommited{get; set;}
        private DateTime? _valueEntregaPrevista;
         [Column("soc_entrega_prevista")]
        public virtual DateTime? EntregaPrevista
         { 
            get { return this._valueEntregaPrevista; } 
            set 
            { 
                if (this._valueEntregaPrevista == value)return;
                 this._valueEntregaPrevista = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioPcpOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioPcpOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioPcp;
        [Column("id_acs_usuario_pcp", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioPcp
        { 
           get {                 return this._valueAcsUsuarioPcp; } 
           set 
           { 
                if (this._valueAcsUsuarioPcp == value)return;
                 this._valueAcsUsuarioPcp = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCompradorOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCompradorOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioComprador;
        [Column("id_acs_usuario_comprador", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioComprador
        { 
           get {                 return this._valueAcsUsuarioComprador; } 
           set 
           { 
                if (this._valueAcsUsuarioComprador == value)return;
                 this._valueAcsUsuarioComprador = value; 
           } 
       } 

       protected DateTime? _dataAprovacaoPcpOriginal{get;private set;}
       private DateTime? _dataAprovacaoPcpOriginalCommited{get; set;}
        private DateTime? _valueDataAprovacaoPcp;
         [Column("soc_data_aprovacao_pcp")]
        public virtual DateTime? DataAprovacaoPcp
         { 
            get { return this._valueDataAprovacaoPcp; } 
            set 
            { 
                if (this._valueDataAprovacaoPcp == value)return;
                 this._valueDataAprovacaoPcp = value; 
            } 
        } 

       protected DateTime? _dataAprovacaoComprasOriginal{get;private set;}
       private DateTime? _dataAprovacaoComprasOriginalCommited{get; set;}
        private DateTime? _valueDataAprovacaoCompras;
         [Column("soc_data_aprovacao_compras")]
        public virtual DateTime? DataAprovacaoCompras
         { 
            get { return this._valueDataAprovacaoCompras; } 
            set 
            { 
                if (this._valueDataAprovacaoCompras == value)return;
                 this._valueDataAprovacaoCompras = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("soc_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.MarcaClass _marcaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MarcaClass _marcaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MarcaClass _valueMarca;
        [Column("id_marca", "marca", "id_marca")]
       public virtual BibliotecaEntidades.Entidades.MarcaClass Marca
        { 
           get {                 return this._valueMarca; } 
           set 
           { 
                if (this._valueMarca == value)return;
                 this._valueMarca = value; 
           } 
       } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioCancelamentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioCancelamento;
        [Column("id_acs_usuario_cancelamento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioCancelamento
        { 
           get {                 return this._valueAcsUsuarioCancelamento; } 
           set 
           { 
                if (this._valueAcsUsuarioCancelamento == value)return;
                 this._valueAcsUsuarioCancelamento = value; 
           } 
       } 

       protected DateTime? _dataCancelamentoOriginal{get;private set;}
       private DateTime? _dataCancelamentoOriginalCommited{get; set;}
        private DateTime? _valueDataCancelamento;
         [Column("soc_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected int? _numeroLinhaOcOriginal{get;private set;}
       private int? _numeroLinhaOcOriginalCommited{get; set;}
        private int? _valueNumeroLinhaOc;
         [Column("soc_numero_linha_oc")]
        public virtual int? NumeroLinhaOc
         { 
            get { return this._valueNumeroLinhaOc; } 
            set 
            { 
                if (this._valueNumeroLinhaOc == value)return;
                 this._valueNumeroLinhaOc = value; 
            } 
        } 

       protected double? _valorUnitarioOcOriginal{get;private set;}
       private double? _valorUnitarioOcOriginalCommited{get; set;}
        private double? _valueValorUnitarioOc;
         [Column("soc_valor_unitario_oc")]
        public virtual double? ValorUnitarioOc
         { 
            get { return this._valueValorUnitarioOc; } 
            set 
            { 
                if (this._valueValorUnitarioOc == value)return;
                 this._valueValorUnitarioOc = value; 
            } 
        } 

       protected double? _valorTotalOcOriginal{get;private set;}
       private double? _valorTotalOcOriginalCommited{get; set;}
        private double? _valueValorTotalOc;
         [Column("soc_valor_total_oc")]
        public virtual double? ValorTotalOc
         { 
            get { return this._valueValorTotalOc; } 
            set 
            { 
                if (this._valueValorTotalOc == value)return;
                 this._valueValorTotalOc = value; 
            } 
        } 

       protected double? _aliquotaIpiOcOriginal{get;private set;}
       private double? _aliquotaIpiOcOriginalCommited{get; set;}
        private double? _valueAliquotaIpiOc;
         [Column("soc_aliquota_ipi_oc")]
        public virtual double? AliquotaIpiOc
         { 
            get { return this._valueAliquotaIpiOc; } 
            set 
            { 
                if (this._valueAliquotaIpiOc == value)return;
                 this._valueAliquotaIpiOc = value; 
            } 
        } 

       protected double? _aliquotaIcmsOcOriginal{get;private set;}
       private double? _aliquotaIcmsOcOriginalCommited{get; set;}
        private double? _valueAliquotaIcmsOc;
         [Column("soc_aliquota_icms_oc")]
        public virtual double? AliquotaIcmsOc
         { 
            get { return this._valueAliquotaIcmsOc; } 
            set 
            { 
                if (this._valueAliquotaIcmsOc == value)return;
                 this._valueAliquotaIcmsOc = value; 
            } 
        } 

       protected double _qtdUnidadeUsoOriginal{get;private set;}
       private double _qtdUnidadeUsoOriginalCommited{get; set;}
        private double _valueQtdUnidadeUso;
         [Column("soc_qtd_unidade_uso")]
        public virtual double QtdUnidadeUso
         { 
            get { return this._valueQtdUnidadeUso; } 
            set 
            { 
                if (this._valueQtdUnidadeUso == value)return;
                 this._valueQtdUnidadeUso = value; 
            } 
        } 

       protected string _unidadeCompraOriginal{get;private set;}
       private string _unidadeCompraOriginalCommited{get; set;}
        private string _valueUnidadeCompra;
         [Column("soc_unidade_compra")]
        public virtual string UnidadeCompra
         { 
            get { return this._valueUnidadeCompra; } 
            set 
            { 
                if (this._valueUnidadeCompra == value)return;
                 this._valueUnidadeCompra = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EpiClass _epiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EpiClass _epiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EpiClass _valueEpi;
        [Column("id_epi", "epi", "id_epi")]
       public virtual BibliotecaEntidades.Entidades.EpiClass Epi
        { 
           get {                 return this._valueEpi; } 
           set 
           { 
                if (this._valueEpi == value)return;
                 this._valueEpi = value; 
           } 
       } 

       protected string _historicoCalculoNecessidadeOriginal{get;private set;}
       private string _historicoCalculoNecessidadeOriginalCommited{get; set;}
        private string _valueHistoricoCalculoNecessidade;
         [Column("soc_historico_calculo_necessidade")]
        public virtual string HistoricoCalculoNecessidade
         { 
            get { return this._valueHistoricoCalculoNecessidade; } 
            set 
            { 
                if (this._valueHistoricoCalculoNecessidade == value)return;
                 this._valueHistoricoCalculoNecessidade = value; 
            } 
        } 

       protected double _qtdOriginalOriginal{get;private set;}
       private double _qtdOriginalOriginalCommited{get; set;}
        private double _valueQtdOriginal;
         [Column("soc_qtd_original")]
        public virtual double QtdOriginal
         { 
            get { return this._valueQtdOriginal; } 
            set 
            { 
                if (this._valueQtdOriginal == value)return;
                 this._valueQtdOriginal = value; 
            } 
        } 

       protected DateTime _entregaPrevistaOriginalOriginal{get;private set;}
       private DateTime _entregaPrevistaOriginalOriginalCommited{get; set;}
        private DateTime _valueEntregaPrevistaOriginal;
         [Column("soc_entrega_prevista_original")]
        public virtual DateTime EntregaPrevistaOriginal
         { 
            get { return this._valueEntregaPrevistaOriginal; } 
            set 
            { 
                if (this._valueEntregaPrevistaOriginal == value)return;
                 this._valueEntregaPrevistaOriginal = value; 
            } 
        } 

       protected EASITipoAlocacaoEstoque _tipoAlocacaoEstoqueOriginal{get;private set;}
       private EASITipoAlocacaoEstoque _tipoAlocacaoEstoqueOriginalCommited{get; set;}
        private EASITipoAlocacaoEstoque _valueTipoAlocacaoEstoque;
         [Column("soc_tipo_alocacao_estoque")]
        public virtual EASITipoAlocacaoEstoque TipoAlocacaoEstoque
         { 
            get { return this._valueTipoAlocacaoEstoque; } 
            set 
            { 
                if (this._valueTipoAlocacaoEstoque == value)return;
                 this._valueTipoAlocacaoEstoque = value; 
            } 
        } 

        public bool TipoAlocacaoEstoque_MateriaPrima
         { 
            get { return this._valueTipoAlocacaoEstoque == BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.MateriaPrima; } 
            set { if (value) this._valueTipoAlocacaoEstoque = BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.MateriaPrima; }
         } 

        public bool TipoAlocacaoEstoque_Consumo
         { 
            get { return this._valueTipoAlocacaoEstoque == BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.Consumo; } 
            set { if (value) this._valueTipoAlocacaoEstoque = BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.Consumo; }
         } 

       protected bool _naoAtualizaPrecoRecebimentoOriginal{get;private set;}
       private bool _naoAtualizaPrecoRecebimentoOriginalCommited{get; set;}
        private bool _valueNaoAtualizaPrecoRecebimento;
         [Column("soc_nao_atualiza_preco_recebimento")]
        public virtual bool NaoAtualizaPrecoRecebimento
         { 
            get { return this._valueNaoAtualizaPrecoRecebimento; } 
            set 
            { 
                if (this._valueNaoAtualizaPrecoRecebimento == value)return;
                 this._valueNaoAtualizaPrecoRecebimento = value; 
            } 
        } 

       private List<long> _collectionLoteSolicitacaoCompraClassSolicitacaoCompraOriginal;
       private List<Entidades.LoteSolicitacaoCompraClass > _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteSolicitacaoCompraClass> _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteSolicitacaoCompraClass> CollectionLoteSolicitacaoCompraClassSolicitacaoCompra 
       { 
           get { if(!_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteSolicitacaoCompraClassSolicitacaoCompra();}
return this._valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra; } 
           set 
           { 
               this._valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra = value; 
               this._valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraOriginal;
       private List<Entidades.SolicitacaoCompraFeedbackClass > _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraFeedbackClass> _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraFeedbackClass> CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra 
       { 
           get { if(!_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra();}
return this._valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra = value; 
               this._valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraOriginal;
       private List<Entidades.SolicitacaoCompraPedidoClass > _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraPedidoClass> _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraPedidoClass> CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra 
       { 
           get { if(!_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra();}
return this._valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra = value; 
               this._valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded = true; 
           } 
       } 

        public SolicitacaoCompraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Status = (StatusSolicitacaoCompra?)0;
           this.TipoAlocacaoEstoque = (EASITipoAlocacaoEstoque)0;
           this.NaoAtualizaPrecoRecebimento = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static SolicitacaoCompraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (SolicitacaoCompraClass) GetEntity(typeof(SolicitacaoCompraClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionLoteSolicitacaoCompraClassSolicitacaoCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged = true;
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged = true; 
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.LoteSolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged = true; 
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.LoteSolicitacaoCompraClass item in _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra) 
                 { 
                     _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteSolicitacaoCompraClassSolicitacaoCompra()
         {
            try
            {
                 ObservableCollection<Entidades.LoteSolicitacaoCompraClass> oc;
                _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged = false;
                 _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged = false;
                _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos = new List<Entidades.LoteSolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteSolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.LoteSolicitacaoCompraClass search = new Entidades.LoteSolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteSolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("SolicitacaoCompra", this),                     }                       ).Cast<Entidades.LoteSolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra = new BindingList<Entidades.LoteSolicitacaoCompraClass>(oc); 
                 _collectionLoteSolicitacaoCompraClassSolicitacaoCompraOriginal= (from a in _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra select a.ID).ToList();
                 _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded = true;
                 oc.CollectionChanged += CollectionLoteSolicitacaoCompraClassSolicitacaoCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteSolicitacaoCompraClassSolicitacaoCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged = true;
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraFeedbackClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraFeedbackClass item in _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra) 
                 { 
                     _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraFeedbackClass> oc;
                _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged = false;
                 _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged = false;
                _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos = new List<Entidades.SolicitacaoCompraFeedbackClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraFeedbackClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraFeedbackClass search = new Entidades.SolicitacaoCompraFeedbackClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraFeedbackClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("SolicitacaoCompra", this),                     }                       ).Cast<Entidades.SolicitacaoCompraFeedbackClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra = new BindingList<Entidades.SolicitacaoCompraFeedbackClass>(oc); 
                 _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraOriginal= (from a in _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged = true;
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraPedidoClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraPedidoClass item in _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra) 
                 { 
                     _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraPedidoClass> oc;
                _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged = false;
                 _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged = false;
                _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos = new List<Entidades.SolicitacaoCompraPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraPedidoClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraPedidoClass search = new Entidades.SolicitacaoCompraPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("SolicitacaoCompra", this),                     }                       ).Cast<Entidades.SolicitacaoCompraPedidoClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra = new BindingList<Entidades.SolicitacaoCompraPedidoClass>(oc); 
                 _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraOriginal= (from a in _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(UnidadeCompra))
                {
                    throw new Exception(ErroUnidadeCompraObrigatorio);
                }
                if (UnidadeCompra.Length >255)
                {
                    throw new Exception( ErroUnidadeCompraComprimento);
                }

                return this.ValidateDataCustom(ref command);
            }
            catch (ExcecaoTratada)
            {
                throw;
            }
            catch (Exception e)
            {
                throw new Exception(ErroValidate+"\r\n" + e.Message, e);
            }
        } 
         protected virtual bool ValidateDataCustom(ref IWTPostgreNpgsqlCommand command)
         {
             return true;
         }
       protected override void internalDelete(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                AcoesExtrasAntesDelete(ref command);
                command.CommandText =
                    "DELETE FROM  " +
                    "  public.solicitacao_compra  " +
                    "WHERE " +
                    "  id_solicitacao_compra = :id";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                command.ExecuteNonQuery();
                AcoesExtrasDepoisDelete(ref command);
            }
            catch (Exception e)
            {
                throw new Exception(ErroDelete+"\r\n" + e.Message, e);
            }
        } 
       protected virtual void AcoesExtrasAntesDelete(ref IWTPostgreNpgsqlCommand command)
        {
        }
       protected virtual void AcoesExtrasDepoisDelete(ref IWTPostgreNpgsqlCommand command)
        {
        }
        protected override void internalSave(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (this.ID != -1)
                {
                    command.CommandText =
                        "UPDATE  " +
                        "  public.solicitacao_compra   " +
                        "SET  " + 
                        "  id_material = :id_material, " + 
                        "  id_produto = :id_produto, " + 
                        "  id_ordem_compra = :id_ordem_compra, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  soc_qtd = :soc_qtd, " + 
                        "  soc_status = :soc_status, " + 
                        "  soc_data_abertura = :soc_data_abertura, " + 
                        "  soc_saldo_recebimento = :soc_saldo_recebimento, " + 
                        "  soc_entrega_prevista = :soc_entrega_prevista, " + 
                        "  id_acs_usuario_pcp = :id_acs_usuario_pcp, " + 
                        "  id_acs_usuario_comprador = :id_acs_usuario_comprador, " + 
                        "  soc_data_aprovacao_pcp = :soc_data_aprovacao_pcp, " + 
                        "  soc_data_aprovacao_compras = :soc_data_aprovacao_compras, " + 
                        "  soc_observacao = :soc_observacao, " + 
                        "  id_marca = :id_marca, " + 
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " + 
                        "  soc_data_cancelamento = :soc_data_cancelamento, " + 
                        "  soc_numero_linha_oc = :soc_numero_linha_oc, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  soc_valor_unitario_oc = :soc_valor_unitario_oc, " + 
                        "  soc_valor_total_oc = :soc_valor_total_oc, " + 
                        "  soc_aliquota_ipi_oc = :soc_aliquota_ipi_oc, " + 
                        "  soc_aliquota_icms_oc = :soc_aliquota_icms_oc, " + 
                        "  soc_qtd_unidade_uso = :soc_qtd_unidade_uso, " + 
                        "  soc_unidade_compra = :soc_unidade_compra, " + 
                        "  id_epi = :id_epi, " + 
                        "  soc_historico_calculo_necessidade = :soc_historico_calculo_necessidade, " + 
                        "  soc_qtd_original = :soc_qtd_original, " + 
                        "  soc_entrega_prevista_original = :soc_entrega_prevista_original, " + 
                        "  soc_tipo_alocacao_estoque = :soc_tipo_alocacao_estoque, " + 
                        "  soc_nao_atualiza_preco_recebimento = :soc_nao_atualiza_preco_recebimento "+
                        "WHERE  " +
                        "  id_solicitacao_compra = :id " +
                        "RETURNING id_solicitacao_compra;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.solicitacao_compra " +
                        "( " +
                        "  id_material , " + 
                        "  id_produto , " + 
                        "  id_ordem_compra , " + 
                        "  id_acs_usuario , " + 
                        "  soc_qtd , " + 
                        "  soc_status , " + 
                        "  soc_data_abertura , " + 
                        "  soc_saldo_recebimento , " + 
                        "  soc_entrega_prevista , " + 
                        "  id_acs_usuario_pcp , " + 
                        "  id_acs_usuario_comprador , " + 
                        "  soc_data_aprovacao_pcp , " + 
                        "  soc_data_aprovacao_compras , " + 
                        "  soc_observacao , " + 
                        "  id_marca , " + 
                        "  id_acs_usuario_cancelamento , " + 
                        "  soc_data_cancelamento , " + 
                        "  soc_numero_linha_oc , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  soc_valor_unitario_oc , " + 
                        "  soc_valor_total_oc , " + 
                        "  soc_aliquota_ipi_oc , " + 
                        "  soc_aliquota_icms_oc , " + 
                        "  soc_qtd_unidade_uso , " + 
                        "  soc_unidade_compra , " + 
                        "  id_epi , " + 
                        "  soc_historico_calculo_necessidade , " + 
                        "  soc_qtd_original , " + 
                        "  soc_entrega_prevista_original , " + 
                        "  soc_tipo_alocacao_estoque , " + 
                        "  soc_nao_atualiza_preco_recebimento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_material , " + 
                        "  :id_produto , " + 
                        "  :id_ordem_compra , " + 
                        "  :id_acs_usuario , " + 
                        "  :soc_qtd , " + 
                        "  :soc_status , " + 
                        "  :soc_data_abertura , " + 
                        "  :soc_saldo_recebimento , " + 
                        "  :soc_entrega_prevista , " + 
                        "  :id_acs_usuario_pcp , " + 
                        "  :id_acs_usuario_comprador , " + 
                        "  :soc_data_aprovacao_pcp , " + 
                        "  :soc_data_aprovacao_compras , " + 
                        "  :soc_observacao , " + 
                        "  :id_marca , " + 
                        "  :id_acs_usuario_cancelamento , " + 
                        "  :soc_data_cancelamento , " + 
                        "  :soc_numero_linha_oc , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :soc_valor_unitario_oc , " + 
                        "  :soc_valor_total_oc , " + 
                        "  :soc_aliquota_ipi_oc , " + 
                        "  :soc_aliquota_icms_oc , " + 
                        "  :soc_qtd_unidade_uso , " + 
                        "  :soc_unidade_compra , " + 
                        "  :id_epi , " + 
                        "  :soc_historico_calculo_necessidade , " + 
                        "  :soc_qtd_original , " + 
                        "  :soc_entrega_prevista_original , " + 
                        "  :soc_tipo_alocacao_estoque , " + 
                        "  :soc_nao_atualiza_preco_recebimento  "+
                        ")RETURNING id_solicitacao_compra;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemCompra==null ? (object) DBNull.Value : this.OrdemCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Qtd ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Status.HasValue ? (object)Convert.ToInt16(this.Status) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_abertura", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAbertura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_saldo_recebimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SaldoRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_entrega_prevista", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaPrevista ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_pcp", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioPcp==null ? (object) DBNull.Value : this.AcsUsuarioPcp.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioComprador==null ? (object) DBNull.Value : this.AcsUsuarioComprador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_aprovacao_pcp", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAprovacaoPcp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_aprovacao_compras", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataAprovacaoCompras ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_marca", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Marca==null ? (object) DBNull.Value : this.Marca.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_numero_linha_oc", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroLinhaOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_valor_unitario_oc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitarioOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_valor_total_oc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_aliquota_ipi_oc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaIpiOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_aliquota_icms_oc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaIcmsOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd_unidade_uso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdUnidadeUso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_unidade_compra", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_historico_calculo_necessidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.HistoricoCalculoNecessidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_qtd_original", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_entrega_prevista_original", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaPrevistaOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_tipo_alocacao_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAlocacaoEstoque);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("soc_nao_atualiza_preco_recebimento", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaoAtualizaPrecoRecebimento ?? DBNull.Value;

 
                 bool inserting = this.ID == -1; 
                this.ID = Convert.ToInt32(command.ExecuteScalar()); 
                this.InternalSaveCustom(ref command); 
                this.AcoesExtrasAposSalvar(ref command, inserting); 
            } 
            catch (Exception e) 
            { 
                throw new Exception(ErroSave+"\r\n" + e.Message, e); 
            } 
        } 

        protected virtual void InternalSaveCustom(ref IWTPostgreNpgsqlCommand command)
        {
            return;
        } 
  public override bool Utilizado(out string mensagemUtilizado)
        {
            try
            {
                mensagemUtilizado = "";
                if (this.ID == -1)
                {
                    return false;
                } 
 if (CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteSolicitacaoCompraClassSolicitacaoCompra+"\r\n";
                foreach (Entidades.LoteSolicitacaoCompraClass tmp in CollectionLoteSolicitacaoCompraClassSolicitacaoCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra+"\r\n";
                foreach (Entidades.SolicitacaoCompraFeedbackClass tmp in CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra+"\r\n";
                foreach (Entidades.SolicitacaoCompraPedidoClass tmp in CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
                return false;

            }
            catch (Exception e)
            {
                throw new Exception(ErroUtilizado+"\r\n" + e.Message, e);
            }
        } 
       public override string ToString()
        {
           throw new NotImplementedException();
        }
        public static SolicitacaoCompraClass CopiarEntidade(SolicitacaoCompraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               SolicitacaoCompraClass toRet = new SolicitacaoCompraClass(usuario,conn);
 toRet.Material= entidadeCopiar.Material;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.OrdemCompra= entidadeCopiar.OrdemCompra;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Qtd= entidadeCopiar.Qtd;
 toRet.Status= entidadeCopiar.Status;
 toRet.DataAbertura= entidadeCopiar.DataAbertura;
 toRet.SaldoRecebimento= entidadeCopiar.SaldoRecebimento;
 toRet.EntregaPrevista= entidadeCopiar.EntregaPrevista;
 toRet.AcsUsuarioPcp= entidadeCopiar.AcsUsuarioPcp;
 toRet.AcsUsuarioComprador= entidadeCopiar.AcsUsuarioComprador;
 toRet.DataAprovacaoPcp= entidadeCopiar.DataAprovacaoPcp;
 toRet.DataAprovacaoCompras= entidadeCopiar.DataAprovacaoCompras;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.Marca= entidadeCopiar.Marca;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.NumeroLinhaOc= entidadeCopiar.NumeroLinhaOc;
 toRet.ValorUnitarioOc= entidadeCopiar.ValorUnitarioOc;
 toRet.ValorTotalOc= entidadeCopiar.ValorTotalOc;
 toRet.AliquotaIpiOc= entidadeCopiar.AliquotaIpiOc;
 toRet.AliquotaIcmsOc= entidadeCopiar.AliquotaIcmsOc;
 toRet.QtdUnidadeUso= entidadeCopiar.QtdUnidadeUso;
 toRet.UnidadeCompra= entidadeCopiar.UnidadeCompra;
 toRet.Epi= entidadeCopiar.Epi;
 toRet.HistoricoCalculoNecessidade= entidadeCopiar.HistoricoCalculoNecessidade;
 toRet.QtdOriginal= entidadeCopiar.QtdOriginal;
 toRet.EntregaPrevistaOriginal= entidadeCopiar.EntregaPrevistaOriginal;
 toRet.TipoAlocacaoEstoque= entidadeCopiar.TipoAlocacaoEstoque;
 toRet.NaoAtualizaPrecoRecebimento= entidadeCopiar.NaoAtualizaPrecoRecebimento;

            return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao copiar a entidade+\r\n" + e.Message, e);
            }
        } 
        protected override void  SalvaValoresOriginais()
        {
            try
            {
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _ordemCompraOriginal = OrdemCompra;
       _ordemCompraOriginalCommited = _ordemCompraOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _qtdOriginal = Qtd;
       _qtdOriginalCommited = _qtdOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _dataAberturaOriginal = DataAbertura;
       _dataAberturaOriginalCommited = _dataAberturaOriginal;
       _saldoRecebimentoOriginal = SaldoRecebimento;
       _saldoRecebimentoOriginalCommited = _saldoRecebimentoOriginal;
       _entregaPrevistaOriginal = EntregaPrevista;
       _entregaPrevistaOriginalCommited = _entregaPrevistaOriginal;
       _acsUsuarioPcpOriginal = AcsUsuarioPcp;
       _acsUsuarioPcpOriginalCommited = _acsUsuarioPcpOriginal;
       _acsUsuarioCompradorOriginal = AcsUsuarioComprador;
       _acsUsuarioCompradorOriginalCommited = _acsUsuarioCompradorOriginal;
       _dataAprovacaoPcpOriginal = DataAprovacaoPcp;
       _dataAprovacaoPcpOriginalCommited = _dataAprovacaoPcpOriginal;
       _dataAprovacaoComprasOriginal = DataAprovacaoCompras;
       _dataAprovacaoComprasOriginalCommited = _dataAprovacaoComprasOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _marcaOriginal = Marca;
       _marcaOriginalCommited = _marcaOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _numeroLinhaOcOriginal = NumeroLinhaOc;
       _numeroLinhaOcOriginalCommited = _numeroLinhaOcOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _valorUnitarioOcOriginal = ValorUnitarioOc;
       _valorUnitarioOcOriginalCommited = _valorUnitarioOcOriginal;
       _valorTotalOcOriginal = ValorTotalOc;
       _valorTotalOcOriginalCommited = _valorTotalOcOriginal;
       _aliquotaIpiOcOriginal = AliquotaIpiOc;
       _aliquotaIpiOcOriginalCommited = _aliquotaIpiOcOriginal;
       _aliquotaIcmsOcOriginal = AliquotaIcmsOc;
       _aliquotaIcmsOcOriginalCommited = _aliquotaIcmsOcOriginal;
       _qtdUnidadeUsoOriginal = QtdUnidadeUso;
       _qtdUnidadeUsoOriginalCommited = _qtdUnidadeUsoOriginal;
       _unidadeCompraOriginal = UnidadeCompra;
       _unidadeCompraOriginalCommited = _unidadeCompraOriginal;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;
       _historicoCalculoNecessidadeOriginal = HistoricoCalculoNecessidade;
       _historicoCalculoNecessidadeOriginalCommited = _historicoCalculoNecessidadeOriginal;
       _qtdOriginalOriginal = QtdOriginal;
       _qtdOriginalOriginalCommited = _qtdOriginalOriginal;
       _entregaPrevistaOriginalOriginal = EntregaPrevistaOriginal;
       _entregaPrevistaOriginalOriginalCommited = _entregaPrevistaOriginalOriginal;
       _tipoAlocacaoEstoqueOriginal = TipoAlocacaoEstoque;
       _tipoAlocacaoEstoqueOriginalCommited = _tipoAlocacaoEstoqueOriginal;
       _naoAtualizaPrecoRecebimentoOriginal = NaoAtualizaPrecoRecebimento;
       _naoAtualizaPrecoRecebimentoOriginalCommited = _naoAtualizaPrecoRecebimentoOriginal;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void  SalvaValoresCommited()
        {
            try
            {
       _materialOriginalCommited = Material;
       _produtoOriginalCommited = Produto;
       _ordemCompraOriginalCommited = OrdemCompra;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _qtdOriginalCommited = Qtd;
       _statusOriginalCommited = Status;
       _dataAberturaOriginalCommited = DataAbertura;
       _saldoRecebimentoOriginalCommited = SaldoRecebimento;
       _entregaPrevistaOriginalCommited = EntregaPrevista;
       _acsUsuarioPcpOriginalCommited = AcsUsuarioPcp;
       _acsUsuarioCompradorOriginalCommited = AcsUsuarioComprador;
       _dataAprovacaoPcpOriginalCommited = DataAprovacaoPcp;
       _dataAprovacaoComprasOriginalCommited = DataAprovacaoCompras;
       _observacaoOriginalCommited = Observacao;
       _marcaOriginalCommited = Marca;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _numeroLinhaOcOriginalCommited = NumeroLinhaOc;
       _versionOriginalCommited = Version;
       _valorUnitarioOcOriginalCommited = ValorUnitarioOc;
       _valorTotalOcOriginalCommited = ValorTotalOc;
       _aliquotaIpiOcOriginalCommited = AliquotaIpiOc;
       _aliquotaIcmsOcOriginalCommited = AliquotaIcmsOc;
       _qtdUnidadeUsoOriginalCommited = QtdUnidadeUso;
       _unidadeCompraOriginalCommited = UnidadeCompra;
       _epiOriginalCommited = Epi;
       _historicoCalculoNecessidadeOriginalCommited = HistoricoCalculoNecessidade;
       _qtdOriginalOriginalCommited = QtdOriginal;
       _entregaPrevistaOriginalOriginalCommited = EntregaPrevistaOriginal;
       _tipoAlocacaoEstoqueOriginalCommited = TipoAlocacaoEstoque;
       _naoAtualizaPrecoRecebimentoOriginalCommited = NaoAtualizaPrecoRecebimento;

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void CommitChangesEntidade()
        {
            try
            {
               SalvaValoresOriginais();
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  if (_collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos != null) 
                  {
                     _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos = new List<Entidades.LoteSolicitacaoCompraClass>();
                  }
                  _collectionLoteSolicitacaoCompraClassSolicitacaoCompraOriginal= (from a in _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompra select a.ID).ToList();
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged = false;
                  _valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  if (_collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos = new List<Entidades.SolicitacaoCompraFeedbackClass>();
                  }
                  _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraOriginal= (from a in _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged = false;
                  _valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  if (_collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos = new List<Entidades.SolicitacaoCompraPedidoClass>();
                  }
                  _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraOriginal= (from a in _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompra select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged = false;
                  _valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged = false;
               }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
        } 
        protected override void RollbackChangesEntidade()
        {
            bool disableEventosRemocaoVetoresAntigo = DisableEventosRemocaoVetores ;
            DisableEventosRemocaoVetores = true;
            try
            {
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               OrdemCompra=_ordemCompraOriginal;
               _ordemCompraOriginalCommited=_ordemCompraOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Qtd=_qtdOriginal;
               _qtdOriginalCommited=_qtdOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               DataAbertura=_dataAberturaOriginal;
               _dataAberturaOriginalCommited=_dataAberturaOriginal;
               SaldoRecebimento=_saldoRecebimentoOriginal;
               _saldoRecebimentoOriginalCommited=_saldoRecebimentoOriginal;
               EntregaPrevista=_entregaPrevistaOriginal;
               _entregaPrevistaOriginalCommited=_entregaPrevistaOriginal;
               AcsUsuarioPcp=_acsUsuarioPcpOriginal;
               _acsUsuarioPcpOriginalCommited=_acsUsuarioPcpOriginal;
               AcsUsuarioComprador=_acsUsuarioCompradorOriginal;
               _acsUsuarioCompradorOriginalCommited=_acsUsuarioCompradorOriginal;
               DataAprovacaoPcp=_dataAprovacaoPcpOriginal;
               _dataAprovacaoPcpOriginalCommited=_dataAprovacaoPcpOriginal;
               DataAprovacaoCompras=_dataAprovacaoComprasOriginal;
               _dataAprovacaoComprasOriginalCommited=_dataAprovacaoComprasOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               Marca=_marcaOriginal;
               _marcaOriginalCommited=_marcaOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               NumeroLinhaOc=_numeroLinhaOcOriginal;
               _numeroLinhaOcOriginalCommited=_numeroLinhaOcOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ValorUnitarioOc=_valorUnitarioOcOriginal;
               _valorUnitarioOcOriginalCommited=_valorUnitarioOcOriginal;
               ValorTotalOc=_valorTotalOcOriginal;
               _valorTotalOcOriginalCommited=_valorTotalOcOriginal;
               AliquotaIpiOc=_aliquotaIpiOcOriginal;
               _aliquotaIpiOcOriginalCommited=_aliquotaIpiOcOriginal;
               AliquotaIcmsOc=_aliquotaIcmsOcOriginal;
               _aliquotaIcmsOcOriginalCommited=_aliquotaIcmsOcOriginal;
               QtdUnidadeUso=_qtdUnidadeUsoOriginal;
               _qtdUnidadeUsoOriginalCommited=_qtdUnidadeUsoOriginal;
               UnidadeCompra=_unidadeCompraOriginal;
               _unidadeCompraOriginalCommited=_unidadeCompraOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
               HistoricoCalculoNecessidade=_historicoCalculoNecessidadeOriginal;
               _historicoCalculoNecessidadeOriginalCommited=_historicoCalculoNecessidadeOriginal;
               QtdOriginal=_qtdOriginalOriginal;
               _qtdOriginalOriginalCommited=_qtdOriginalOriginal;
               EntregaPrevistaOriginal=_entregaPrevistaOriginalOriginal;
               _entregaPrevistaOriginalOriginalCommited=_entregaPrevistaOriginalOriginal;
               TipoAlocacaoEstoque=_tipoAlocacaoEstoqueOriginal;
               _tipoAlocacaoEstoqueOriginalCommited=_tipoAlocacaoEstoqueOriginal;
               NaoAtualizaPrecoRecebimento=_naoAtualizaPrecoRecebimentoOriginal;
               _naoAtualizaPrecoRecebimentoOriginalCommited=_naoAtualizaPrecoRecebimentoOriginal;
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Clear();
                  foreach(int item in _collectionLoteSolicitacaoCompraClassSolicitacaoCompraOriginal)
                  {
                    CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Add(Entidades.LoteSolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteSolicitacaoCompraClassSolicitacaoCompraRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Clear();
                  foreach(int item in _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraOriginal)
                  {
                    CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Add(Entidades.SolicitacaoCompraFeedbackClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraFeedbackClassSolicitacaoCompraRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra.Clear();
                  foreach(int item in _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraOriginal)
                  {
                    CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra.Add(Entidades.SolicitacaoCompraPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraPedidoClassSolicitacaoCompraRemovidos.Clear();
               }

            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar os valores originais +\r\n" + e.Message, e);
            }
            finally
            {
               DisableEventosRemocaoVetores = disableEventosRemocaoVetoresAntigo ;
            }
        } 
        protected override bool DirtyCollections()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
               bool tempRet = false;
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               return false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das collections +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyPropriedadesNativas()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
            bool dirty = false;
      if (dirty) return true;
       if (_materialOriginal!=null)
       {
          dirty = !_materialOriginal.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       if (_produtoOriginal!=null)
       {
          dirty = !_produtoOriginal.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_ordemCompraOriginal!=null)
       {
          dirty = !_ordemCompraOriginal.Equals(OrdemCompra);
       }
       else
       {
            dirty = OrdemCompra != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _qtdOriginal != Qtd;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _dataAberturaOriginal != DataAbertura;
      if (dirty) return true;
       dirty = _saldoRecebimentoOriginal != SaldoRecebimento;
      if (dirty) return true;
       dirty = _entregaPrevistaOriginal != EntregaPrevista;
      if (dirty) return true;
       if (_acsUsuarioPcpOriginal!=null)
       {
          dirty = !_acsUsuarioPcpOriginal.Equals(AcsUsuarioPcp);
       }
       else
       {
            dirty = AcsUsuarioPcp != null;
       }
      if (dirty) return true;
       if (_acsUsuarioCompradorOriginal!=null)
       {
          dirty = !_acsUsuarioCompradorOriginal.Equals(AcsUsuarioComprador);
       }
       else
       {
            dirty = AcsUsuarioComprador != null;
       }
      if (dirty) return true;
       dirty = _dataAprovacaoPcpOriginal != DataAprovacaoPcp;
      if (dirty) return true;
       dirty = _dataAprovacaoComprasOriginal != DataAprovacaoCompras;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
      if (dirty) return true;
       if (_marcaOriginal!=null)
       {
          dirty = !_marcaOriginal.Equals(Marca);
       }
       else
       {
            dirty = Marca != null;
       }
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginal!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginal.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }
      if (dirty) return true;
       dirty = _dataCancelamentoOriginal != DataCancelamento;
      if (dirty) return true;
       dirty = _numeroLinhaOcOriginal != NumeroLinhaOc;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _valorUnitarioOcOriginal != ValorUnitarioOc;
      if (dirty) return true;
       dirty = _valorTotalOcOriginal != ValorTotalOc;
      if (dirty) return true;
       dirty = _aliquotaIpiOcOriginal != AliquotaIpiOc;
      if (dirty) return true;
       dirty = _aliquotaIcmsOcOriginal != AliquotaIcmsOc;
      if (dirty) return true;
       dirty = _qtdUnidadeUsoOriginal != QtdUnidadeUso;
      if (dirty) return true;
       dirty = _unidadeCompraOriginal != UnidadeCompra;
      if (dirty) return true;
       if (_epiOriginal!=null)
       {
          dirty = !_epiOriginal.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }
      if (dirty) return true;
       dirty = _historicoCalculoNecessidadeOriginal != HistoricoCalculoNecessidade;
      if (dirty) return true;
       dirty = _qtdOriginalOriginal != QtdOriginal;
      if (dirty) return true;
       dirty = _entregaPrevistaOriginalOriginal != EntregaPrevistaOriginal;
      if (dirty) return true;
       dirty = _tipoAlocacaoEstoqueOriginal != TipoAlocacaoEstoque;
      if (dirty) return true;
       dirty = _naoAtualizaPrecoRecebimentoOriginal != NaoAtualizaPrecoRecebimento;

               return dirty;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das propriedades nativas +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyCollectionsCommited()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
               bool tempRet = false;
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionLoteSolicitacaoCompraClassSolicitacaoCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               return false;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das collections +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override bool DirtyPropriedadesNativasCommited()
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
            bool dirty = false;
      if (dirty) return true;
       if (_materialOriginalCommited!=null)
       {
          dirty = !_materialOriginalCommited.Equals(Material);
       }
       else
       {
            dirty = Material != null;
       }
      if (dirty) return true;
       if (_produtoOriginalCommited!=null)
       {
          dirty = !_produtoOriginalCommited.Equals(Produto);
       }
       else
       {
            dirty = Produto != null;
       }
      if (dirty) return true;
       if (_ordemCompraOriginalCommited!=null)
       {
          dirty = !_ordemCompraOriginalCommited.Equals(OrdemCompra);
       }
       else
       {
            dirty = OrdemCompra != null;
       }
      if (dirty) return true;
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       dirty = _qtdOriginalCommited != Qtd;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _dataAberturaOriginalCommited != DataAbertura;
      if (dirty) return true;
       dirty = _saldoRecebimentoOriginalCommited != SaldoRecebimento;
      if (dirty) return true;
       dirty = _entregaPrevistaOriginalCommited != EntregaPrevista;
      if (dirty) return true;
       if (_acsUsuarioPcpOriginalCommited!=null)
       {
          dirty = !_acsUsuarioPcpOriginalCommited.Equals(AcsUsuarioPcp);
       }
       else
       {
            dirty = AcsUsuarioPcp != null;
       }
      if (dirty) return true;
       if (_acsUsuarioCompradorOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCompradorOriginalCommited.Equals(AcsUsuarioComprador);
       }
       else
       {
            dirty = AcsUsuarioComprador != null;
       }
      if (dirty) return true;
       dirty = _dataAprovacaoPcpOriginalCommited != DataAprovacaoPcp;
      if (dirty) return true;
       dirty = _dataAprovacaoComprasOriginalCommited != DataAprovacaoCompras;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
      if (dirty) return true;
       if (_marcaOriginalCommited!=null)
       {
          dirty = !_marcaOriginalCommited.Equals(Marca);
       }
       else
       {
            dirty = Marca != null;
       }
      if (dirty) return true;
       if (_acsUsuarioCancelamentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioCancelamentoOriginalCommited.Equals(AcsUsuarioCancelamento);
       }
       else
       {
            dirty = AcsUsuarioCancelamento != null;
       }
      if (dirty) return true;
       dirty = _dataCancelamentoOriginalCommited != DataCancelamento;
      if (dirty) return true;
       dirty = _numeroLinhaOcOriginalCommited != NumeroLinhaOc;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _valorUnitarioOcOriginalCommited != ValorUnitarioOc;
      if (dirty) return true;
       dirty = _valorTotalOcOriginalCommited != ValorTotalOc;
      if (dirty) return true;
       dirty = _aliquotaIpiOcOriginalCommited != AliquotaIpiOc;
      if (dirty) return true;
       dirty = _aliquotaIcmsOcOriginalCommited != AliquotaIcmsOc;
      if (dirty) return true;
       dirty = _qtdUnidadeUsoOriginalCommited != QtdUnidadeUso;
      if (dirty) return true;
       dirty = _unidadeCompraOriginalCommited != UnidadeCompra;
      if (dirty) return true;
       if (_epiOriginalCommited!=null)
       {
          dirty = !_epiOriginalCommited.Equals(Epi);
       }
       else
       {
            dirty = Epi != null;
       }
      if (dirty) return true;
       dirty = _historicoCalculoNecessidadeOriginalCommited != HistoricoCalculoNecessidade;
      if (dirty) return true;
       dirty = _qtdOriginalOriginalCommited != QtdOriginal;
      if (dirty) return true;
       dirty = _entregaPrevistaOriginalOriginalCommited != EntregaPrevistaOriginal;
      if (dirty) return true;
       dirty = _tipoAlocacaoEstoqueOriginalCommited != TipoAlocacaoEstoque;
      if (dirty) return true;
       dirty = _naoAtualizaPrecoRecebimentoOriginalCommited != NaoAtualizaPrecoRecebimento;

               return dirty;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao verificar a situação de dirty das propriedades nativas +\r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        protected override void SaveCollections(ref IWTPostgreNpgsqlCommand command)
        {
            bool sitAnteriorSalvarValoresAntigosHabilitado = this.SalvarValoresAntigosHabilitado;
            this.SalvarValoresAntigosHabilitado = false;
            bool sitAnteriorDisableLoadCollection = DisableLoadCollection;
            this.DisableLoadCollection = true;
            try
            {
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  foreach(LoteSolicitacaoCompraClass item in CollectionLoteSolicitacaoCompraClassSolicitacaoCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  foreach(SolicitacaoCompraFeedbackClass item in CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  foreach(SolicitacaoCompraPedidoClass item in CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao salvar as collections \r\n" + e.Message, e);
            }
            finally
            {
                SalvarValoresAntigosHabilitado = sitAnteriorSalvarValoresAntigosHabilitado; 
                DisableLoadCollection = sitAnteriorDisableLoadCollection; 
            }
        } 
        public override object GetValorPropriedade(string nomePropriedade)
        {
          switch (nomePropriedade) 
          {
             case "ID":
                return this.ID;
             case "UltimaRevisao":
                return this.UltimaRevisao;
             case "UltimaRevisaoData":
                return this.UltimaRevisaoData;
             case "UltimaRevisaoUsuario":
                return this.UltimaRevisaoUsuario;
             case "Material":
                return this.Material;
             case "Produto":
                return this.Produto;
             case "OrdemCompra":
                return this.OrdemCompra;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Qtd":
                return this.Qtd;
             case "Status":
                return this.Status;
             case "DataAbertura":
                return this.DataAbertura;
             case "SaldoRecebimento":
                return this.SaldoRecebimento;
             case "EntregaPrevista":
                return this.EntregaPrevista;
             case "AcsUsuarioPcp":
                return this.AcsUsuarioPcp;
             case "AcsUsuarioComprador":
                return this.AcsUsuarioComprador;
             case "DataAprovacaoPcp":
                return this.DataAprovacaoPcp;
             case "DataAprovacaoCompras":
                return this.DataAprovacaoCompras;
             case "Observacao":
                return this.Observacao;
             case "Marca":
                return this.Marca;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "NumeroLinhaOc":
                return this.NumeroLinhaOc;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ValorUnitarioOc":
                return this.ValorUnitarioOc;
             case "ValorTotalOc":
                return this.ValorTotalOc;
             case "AliquotaIpiOc":
                return this.AliquotaIpiOc;
             case "AliquotaIcmsOc":
                return this.AliquotaIcmsOc;
             case "QtdUnidadeUso":
                return this.QtdUnidadeUso;
             case "UnidadeCompra":
                return this.UnidadeCompra;
             case "Epi":
                return this.Epi;
             case "HistoricoCalculoNecessidade":
                return this.HistoricoCalculoNecessidade;
             case "QtdOriginal":
                return this.QtdOriginal;
             case "EntregaPrevistaOriginal":
                return this.EntregaPrevistaOriginal;
             case "TipoAlocacaoEstoque":
                return this.TipoAlocacaoEstoque;
             case "NaoAtualizaPrecoRecebimento":
                return this.NaoAtualizaPrecoRecebimento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (OrdemCompra!=null)
                OrdemCompra.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (AcsUsuarioPcp!=null)
                AcsUsuarioPcp.ChangeSingleConnection(newConnection);
             if (AcsUsuarioComprador!=null)
                AcsUsuarioComprador.ChangeSingleConnection(newConnection);
             if (Marca!=null)
                Marca.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
               if (_valueCollectionLoteSolicitacaoCompraClassSolicitacaoCompraLoaded) 
               {
                  foreach(LoteSolicitacaoCompraClass item in CollectionLoteSolicitacaoCompraClassSolicitacaoCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraFeedbackClassSolicitacaoCompraLoaded) 
               {
                  foreach(SolicitacaoCompraFeedbackClass item in CollectionSolicitacaoCompraFeedbackClassSolicitacaoCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassSolicitacaoCompraLoaded) 
               {
                  foreach(SolicitacaoCompraPedidoClass item in CollectionSolicitacaoCompraPedidoClassSolicitacaoCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
        }
        protected override List<AbstractEntity> NewSearch(List<SearchParameterClass> parametros, bool somenteCount,out int qtdRegistros, bool utilizarOr = false, int? offset = null, int? limit = null, bool utilizarBuffer = true, Guid? operacao = null)
        {
            IWTPostgreNpgsqlCommand command = null; 
            bool transacaoInterna = false; 
            try
            {
               List<AbstractEntity> toRet = new List<AbstractEntity>();
               command = this.SingleConnection.CreateCommand();
               if (!command.Connection.IsInTransaction())
               {
                  command.Transaction = command.Connection.BeginTransaction();
                  transacaoInterna = true;
               }
               command.CommandText = "SELECT "  ;
               if (somenteCount)
               {
                  command.CommandText += " COUNT(solicitacao_compra.id_solicitacao_compra) " ;
               }
               else
               {
               command.CommandText += "solicitacao_compra.id_solicitacao_compra, " ;
               command.CommandText += "solicitacao_compra.id_material, " ;
               command.CommandText += "solicitacao_compra.id_produto, " ;
               command.CommandText += "solicitacao_compra.id_ordem_compra, " ;
               command.CommandText += "solicitacao_compra.id_acs_usuario, " ;
               command.CommandText += "solicitacao_compra.soc_qtd, " ;
               command.CommandText += "solicitacao_compra.soc_status, " ;
               command.CommandText += "solicitacao_compra.soc_data_abertura, " ;
               command.CommandText += "solicitacao_compra.soc_saldo_recebimento, " ;
               command.CommandText += "solicitacao_compra.soc_entrega_prevista, " ;
               command.CommandText += "solicitacao_compra.id_acs_usuario_pcp, " ;
               command.CommandText += "solicitacao_compra.id_acs_usuario_comprador, " ;
               command.CommandText += "solicitacao_compra.soc_data_aprovacao_pcp, " ;
               command.CommandText += "solicitacao_compra.soc_data_aprovacao_compras, " ;
               command.CommandText += "solicitacao_compra.soc_observacao, " ;
               command.CommandText += "solicitacao_compra.id_marca, " ;
               command.CommandText += "solicitacao_compra.id_acs_usuario_cancelamento, " ;
               command.CommandText += "solicitacao_compra.soc_data_cancelamento, " ;
               command.CommandText += "solicitacao_compra.soc_numero_linha_oc, " ;
               command.CommandText += "solicitacao_compra.entity_uid, " ;
               command.CommandText += "solicitacao_compra.version, " ;
               command.CommandText += "solicitacao_compra.soc_valor_unitario_oc, " ;
               command.CommandText += "solicitacao_compra.soc_valor_total_oc, " ;
               command.CommandText += "solicitacao_compra.soc_aliquota_ipi_oc, " ;
               command.CommandText += "solicitacao_compra.soc_aliquota_icms_oc, " ;
               command.CommandText += "solicitacao_compra.soc_qtd_unidade_uso, " ;
               command.CommandText += "solicitacao_compra.soc_unidade_compra, " ;
               command.CommandText += "solicitacao_compra.id_epi, " ;
               command.CommandText += "solicitacao_compra.soc_historico_calculo_necessidade, " ;
               command.CommandText += "solicitacao_compra.soc_qtd_original, " ;
               command.CommandText += "solicitacao_compra.soc_entrega_prevista_original, " ;
               command.CommandText += "solicitacao_compra.soc_tipo_alocacao_estoque, " ;
               command.CommandText += "solicitacao_compra.soc_nao_atualiza_preco_recebimento " ;
               }
               command.CommandText += " FROM  solicitacao_compra ";
               string whereClause = "";
               string orderByClause = "";
               command.Parameters.Clear();
               List < SearchParameterClass > parametrosTmp = new List<SearchParameterClass>();
               for (int i = 0; i < parametros.Count; i++)
               {
                   SearchParameterClass parametro = parametros[i];
                   int iUltimo = i;
                   for (int j = i + 1; j < parametros.Count; j++)
                   {
                       if (parametro.FieldName == parametros[j].FieldName)
                       {
                           if (parametro.Operacao == parametros[j].Operacao)
                           {
                               iUltimo = j;
                           }
                       }
                   }
                   parametrosTmp.Add(parametros[iUltimo]);
                   if (iUltimo != i)
                   {
                       parametros.RemoveAt(iUltimo);
                   }
               }
               parametros = parametrosTmp; 
               foreach (SearchParameterClass parametro in parametros) 
               {
                  if (parametro.Operacao == SearchOperacao.SomenteOrdenacao) 
                  {
                     if (OrderByCustom(parametro, ref orderByClause,parametro.Ordenacao, ref command ))
                     {
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData")
                     {
                        orderByClause += " , soc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(soc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = solicitacao_compra.id_acs_usuario_ultima_revisao ";
                        continue;
                     }
                     if (parametro.FieldName.Contains("_"))
                     {
                        if (parametro.TipoOrdenacao == TipoOrdenacao.String)
                        {
                           orderByClause += " ,  UPPER(" + parametro.FieldName + ") " + parametro.Ordenacao.ToString().ToUpper();
                        }
                        else
                        {
                            orderByClause += " ,  " + parametro.FieldName + " " + parametro.Ordenacao.ToString();
                        }
                        continue;
                     }
                     switch(parametro.FieldName)
                     {
                     case "id_solicitacao_compra":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.id_solicitacao_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.id_solicitacao_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = solicitacao_compra.id_material ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , material_Material.mat_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(material_Material.mat_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = solicitacao_compra.id_produto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_Produto.pro_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_Produto.pro_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_compra":
                     case "OrdemCompra":
                     command.CommandText += " LEFT JOIN ordem_compra as ordem_compra_OrdemCompra ON ordem_compra_OrdemCompra.id_ordem_compra = solicitacao_compra.id_ordem_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra_OrdemCompra.id_ordem_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra_OrdemCompra.id_ordem_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , solicitacao_compra.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "soc_qtd":
                     case "Qtd":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_qtd " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_qtd) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_data_abertura":
                     case "DataAbertura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_data_abertura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_data_abertura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_saldo_recebimento":
                     case "SaldoRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_saldo_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_saldo_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_entrega_prevista":
                     case "EntregaPrevista":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_entrega_prevista " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_entrega_prevista) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_pcp":
                     case "AcsUsuarioPcp":
                     orderByClause += " , solicitacao_compra.id_acs_usuario_pcp " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_acs_usuario_comprador":
                     case "AcsUsuarioComprador":
                     orderByClause += " , solicitacao_compra.id_acs_usuario_comprador " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "soc_data_aprovacao_pcp":
                     case "DataAprovacaoPcp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_data_aprovacao_pcp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_data_aprovacao_pcp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_data_aprovacao_compras":
                     case "DataAprovacaoCompras":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_data_aprovacao_compras " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_data_aprovacao_compras) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra.soc_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra.soc_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_marca":
                     case "Marca":
                     command.CommandText += " LEFT JOIN marca as marca_Marca ON marca_Marca.id_marca = solicitacao_compra.id_marca ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , marca_Marca.mar_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(marca_Marca.mar_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , solicitacao_compra.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "soc_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_numero_linha_oc":
                     case "NumeroLinhaOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_numero_linha_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_numero_linha_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "version":
                     case "Version":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_valor_unitario_oc":
                     case "ValorUnitarioOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_valor_unitario_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_valor_unitario_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_valor_total_oc":
                     case "ValorTotalOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_valor_total_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_valor_total_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_aliquota_ipi_oc":
                     case "AliquotaIpiOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_aliquota_ipi_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_aliquota_ipi_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_aliquota_icms_oc":
                     case "AliquotaIcmsOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_aliquota_icms_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_aliquota_icms_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_qtd_unidade_uso":
                     case "QtdUnidadeUso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_qtd_unidade_uso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_qtd_unidade_uso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_unidade_compra":
                     case "UnidadeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra.soc_unidade_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra.soc_unidade_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = solicitacao_compra.id_epi ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , epi_Epi.epi_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(epi_Epi.epi_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_historico_calculo_necessidade":
                     case "HistoricoCalculoNecessidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra.soc_historico_calculo_necessidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra.soc_historico_calculo_necessidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_qtd_original":
                     case "QtdOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_qtd_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_qtd_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_entrega_prevista_original":
                     case "EntregaPrevistaOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_entrega_prevista_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_entrega_prevista_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_tipo_alocacao_estoque":
                     case "TipoAlocacaoEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_tipo_alocacao_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_tipo_alocacao_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "soc_nao_atualiza_preco_recebimento":
                     case "NaoAtualizaPrecoRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra.soc_nao_atualiza_preco_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra.soc_nao_atualiza_preco_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                        default:
                           throw new Exception("Parâmetro de ordenação não encontrado: " + parametro.FieldName);
                     }
                  }
                  else
                  {
                     if (SearchCustom(parametro, ref whereClause, ref command ))
                     {
                        continue;
                     }
                     if (parametro.FieldName == "BuscaCompleta")
                     {
                        whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(FALSE ";
                        if (!CamposNaoIncluirBuscaCompleta.Contains("soc_observacao")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra.soc_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra.soc_observacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("soc_unidade_compra")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra.soc_unidade_compra) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra.soc_unidade_compra) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("soc_historico_calculo_necessidade")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra.soc_historico_calculo_necessidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra.soc_historico_calculo_necessidade) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_solicitacao_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_solicitacao_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_solicitacao_compra = :solicitacao_compra_ID_3086 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_ID_3086", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Material" || parametro.FieldName == "id_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MaterialClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MaterialClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_material = :solicitacao_compra_Material_1555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Material_1555", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Produto" || parametro.FieldName == "id_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_produto = :solicitacao_compra_Produto_3658 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Produto_3658", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemCompra" || parametro.FieldName == "id_ordem_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemCompraClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemCompraClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_ordem_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_ordem_compra = :solicitacao_compra_OrdemCompra_8070 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_OrdemCompra_8070", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuario" || parametro.FieldName == "id_acs_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario = :solicitacao_compra_AcsUsuario_2711 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AcsUsuario_2711", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Qtd" || parametro.FieldName == "soc_qtd")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_qtd IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_qtd = :solicitacao_compra_Qtd_8557 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Qtd_8557", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "soc_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusSolicitacaoCompra?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusSolicitacaoCompra?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_status = :solicitacao_compra_Status_4285 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Status_4285", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAbertura" || parametro.FieldName == "soc_data_abertura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_data_abertura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_data_abertura = :solicitacao_compra_DataAbertura_1556 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_DataAbertura_1556", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SaldoRecebimento" || parametro.FieldName == "soc_saldo_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_saldo_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_saldo_recebimento = :solicitacao_compra_SaldoRecebimento_8655 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_SaldoRecebimento_8655", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaPrevista" || parametro.FieldName == "soc_entrega_prevista")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_entrega_prevista IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_entrega_prevista = :solicitacao_compra_EntregaPrevista_4219 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_EntregaPrevista_4219", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioPcp" || parametro.FieldName == "id_acs_usuario_pcp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_pcp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_pcp = :solicitacao_compra_AcsUsuarioPcp_887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AcsUsuarioPcp_887", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioComprador" || parametro.FieldName == "id_acs_usuario_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_comprador = :solicitacao_compra_AcsUsuarioComprador_7186 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AcsUsuarioComprador_7186", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAprovacaoPcp" || parametro.FieldName == "soc_data_aprovacao_pcp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_data_aprovacao_pcp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_data_aprovacao_pcp = :solicitacao_compra_DataAprovacaoPcp_6887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_DataAprovacaoPcp_6887", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataAprovacaoCompras" || parametro.FieldName == "soc_data_aprovacao_compras")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_data_aprovacao_compras IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_data_aprovacao_compras = :solicitacao_compra_DataAprovacaoCompras_175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_DataAprovacaoCompras_175", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "soc_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_observacao LIKE :solicitacao_compra_Observacao_7521 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Observacao_7521", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Marca" || parametro.FieldName == "id_marca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MarcaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MarcaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_marca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_marca = :solicitacao_compra_Marca_5799 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Marca_5799", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioCancelamento" || parametro.FieldName == "id_acs_usuario_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_acs_usuario_cancelamento = :solicitacao_compra_AcsUsuarioCancelamento_7267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AcsUsuarioCancelamento_7267", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "soc_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_data_cancelamento = :solicitacao_compra_DataCancelamento_5727 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_DataCancelamento_5727", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroLinhaOc" || parametro.FieldName == "soc_numero_linha_oc")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_numero_linha_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_numero_linha_oc = :solicitacao_compra_NumeroLinhaOc_5031 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_NumeroLinhaOc_5031", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntityUid" || parametro.FieldName == "entity_uid")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.entity_uid LIKE :solicitacao_compra_EntityUid_8220 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_EntityUid_8220", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Version" || parametro.FieldName == "version")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.version = :solicitacao_compra_Version_2661 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Version_2661", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitarioOc" || parametro.FieldName == "soc_valor_unitario_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_valor_unitario_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_valor_unitario_oc = :solicitacao_compra_ValorUnitarioOc_6288 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_ValorUnitarioOc_6288", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalOc" || parametro.FieldName == "soc_valor_total_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_valor_total_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_valor_total_oc = :solicitacao_compra_ValorTotalOc_1860 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_ValorTotalOc_1860", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaIpiOc" || parametro.FieldName == "soc_aliquota_ipi_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_aliquota_ipi_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_aliquota_ipi_oc = :solicitacao_compra_AliquotaIpiOc_7174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AliquotaIpiOc_7174", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaIcmsOc" || parametro.FieldName == "soc_aliquota_icms_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_aliquota_icms_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_aliquota_icms_oc = :solicitacao_compra_AliquotaIcmsOc_6540 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_AliquotaIcmsOc_6540", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdUnidadeUso" || parametro.FieldName == "soc_qtd_unidade_uso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_qtd_unidade_uso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_qtd_unidade_uso = :solicitacao_compra_QtdUnidadeUso_6093 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_QtdUnidadeUso_6093", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeCompra" || parametro.FieldName == "soc_unidade_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_unidade_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_unidade_compra LIKE :solicitacao_compra_UnidadeCompra_3419 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_UnidadeCompra_3419", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Epi" || parametro.FieldName == "id_epi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EpiClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EpiClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.id_epi = :solicitacao_compra_Epi_6151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Epi_6151", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "HistoricoCalculoNecessidade" || parametro.FieldName == "soc_historico_calculo_necessidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_historico_calculo_necessidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_historico_calculo_necessidade LIKE :solicitacao_compra_HistoricoCalculoNecessidade_8578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_HistoricoCalculoNecessidade_8578", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdOriginal" || parametro.FieldName == "soc_qtd_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_qtd_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_qtd_original = :solicitacao_compra_QtdOriginal_1448 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_QtdOriginal_1448", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaPrevistaOriginal" || parametro.FieldName == "soc_entrega_prevista_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_entrega_prevista_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_entrega_prevista_original = :solicitacao_compra_EntregaPrevistaOriginal_3952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_EntregaPrevistaOriginal_3952", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAlocacaoEstoque" || parametro.FieldName == "soc_tipo_alocacao_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EASITipoAlocacaoEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EASITipoAlocacaoEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_tipo_alocacao_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_tipo_alocacao_estoque = :solicitacao_compra_TipoAlocacaoEstoque_7392 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_TipoAlocacaoEstoque_7392", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaoAtualizaPrecoRecebimento" || parametro.FieldName == "soc_nao_atualiza_preco_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_nao_atualiza_preco_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_nao_atualiza_preco_recebimento = :solicitacao_compra_NaoAtualizaPrecoRecebimento_5225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_NaoAtualizaPrecoRecebimento_5225", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoExato" || parametro.FieldName == "ObservacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_observacao LIKE :solicitacao_compra_Observacao_7515 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_Observacao_7515", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntityUidExato" || parametro.FieldName == "EntityUidExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.entity_uid LIKE :solicitacao_compra_EntityUid_3115 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_EntityUid_3115", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeCompraExato" || parametro.FieldName == "UnidadeCompraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_unidade_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_unidade_compra LIKE :solicitacao_compra_UnidadeCompra_5625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_UnidadeCompra_5625", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "HistoricoCalculoNecessidadeExato" || parametro.FieldName == "HistoricoCalculoNecessidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra.soc_historico_calculo_necessidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra.soc_historico_calculo_necessidade LIKE :solicitacao_compra_HistoricoCalculoNecessidade_6357 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_HistoricoCalculoNecessidade_6357", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                  throw new Exception("Parâmetro de busca não encontrado: " + parametro.FieldName);
                  }
               }
               if (whereClause.Length > 0)
               {
                  command.CommandText += " WHERE " + whereClause.Substring(5);
               }
               if (!somenteCount && orderByClause.Length > 0)
               {
                  command.CommandText += " ORDER BY " + orderByClause.Substring(2);
               }
               if (!somenteCount && limit.HasValue)
               {
                  command.CommandText += " LIMIT " + limit.Value + " ";
               }
               if (!somenteCount && offset.HasValue)
               {
                  command.CommandText += " OFFSET " + offset.Value + " ";
               }
               if (somenteCount)
               {
                  object tmp = command.ExecuteScalar();
                  if (tmp != DBNull.Value)
                  {
                     qtdRegistros = Convert.ToInt32(tmp);
                  }
                  else
                  {
                     qtdRegistros = 0;
                  }
                  if (transacaoInterna)
                  {
                     command.Transaction.Commit();
                  }
                  return null;
               }
               qtdRegistros = 0;
               if (PararThread()) 
               { 
                   return toRet; 
               } 
               IWTPostgreNpgsqlDataReader read = command.ExecuteReader();
               while (read.Read())
               {
                  if (PararThread()) 
                  { 
                      break; 
                  } 
                  qtdRegistros++;
                  SolicitacaoCompraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (SolicitacaoCompraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(SolicitacaoCompraClass), Convert.ToInt32(read["id_solicitacao_compra"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new SolicitacaoCompraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_solicitacao_compra"]);
                     if (read["id_material"] != DBNull.Value)
                     {
                        entidade.Material = (BibliotecaEntidades.Entidades.MaterialClass)BibliotecaEntidades.Entidades.MaterialClass.GetEntidade(Convert.ToInt32(read["id_material"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Material = null ;
                     }
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     if (read["id_ordem_compra"] != DBNull.Value)
                     {
                        entidade.OrdemCompra = (BibliotecaEntidades.Entidades.OrdemCompraClass)BibliotecaEntidades.Entidades.OrdemCompraClass.GetEntidade(Convert.ToInt32(read["id_ordem_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemCompra = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Qtd = read["soc_qtd"] as double?;
                     entidade.Status = (StatusSolicitacaoCompra?) (read["soc_status"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(StatusSolicitacaoCompra?)), read["soc_status"]) : null);
                     entidade.DataAbertura = read["soc_data_abertura"] as DateTime?;
                     entidade.SaldoRecebimento = read["soc_saldo_recebimento"] as double?;
                     entidade.EntregaPrevista = read["soc_entrega_prevista"] as DateTime?;
                     if (read["id_acs_usuario_pcp"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioPcp = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_pcp"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioPcp = null ;
                     }
                     if (read["id_acs_usuario_comprador"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioComprador = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioComprador = null ;
                     }
                     entidade.DataAprovacaoPcp = read["soc_data_aprovacao_pcp"] as DateTime?;
                     entidade.DataAprovacaoCompras = read["soc_data_aprovacao_compras"] as DateTime?;
                     entidade.Observacao = (read["soc_observacao"] != DBNull.Value ? read["soc_observacao"].ToString() : null);
                     if (read["id_marca"] != DBNull.Value)
                     {
                        entidade.Marca = (BibliotecaEntidades.Entidades.MarcaClass)BibliotecaEntidades.Entidades.MarcaClass.GetEntidade(Convert.ToInt32(read["id_marca"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Marca = null ;
                     }
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.DataCancelamento = read["soc_data_cancelamento"] as DateTime?;
                     entidade.NumeroLinhaOc = read["soc_numero_linha_oc"] as int?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ValorUnitarioOc = read["soc_valor_unitario_oc"] as double?;
                     entidade.ValorTotalOc = read["soc_valor_total_oc"] as double?;
                     entidade.AliquotaIpiOc = read["soc_aliquota_ipi_oc"] as double?;
                     entidade.AliquotaIcmsOc = read["soc_aliquota_icms_oc"] as double?;
                     entidade.QtdUnidadeUso = (double)read["soc_qtd_unidade_uso"];
                     entidade.UnidadeCompra = (read["soc_unidade_compra"] != DBNull.Value ? read["soc_unidade_compra"].ToString() : null);
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     entidade.HistoricoCalculoNecessidade = (read["soc_historico_calculo_necessidade"] != DBNull.Value ? read["soc_historico_calculo_necessidade"].ToString() : null);
                     entidade.QtdOriginal = (double)read["soc_qtd_original"];
                     entidade.EntregaPrevistaOriginal = (DateTime)read["soc_entrega_prevista_original"];
                     entidade.TipoAlocacaoEstoque = (EASITipoAlocacaoEstoque) (read["soc_tipo_alocacao_estoque"] != DBNull.Value ? Enum.ToObject(typeof(EASITipoAlocacaoEstoque), read["soc_tipo_alocacao_estoque"]) : null);
                     entidade.NaoAtualizaPrecoRecebimento = Convert.ToBoolean(Convert.ToInt16(read["soc_nao_atualiza_preco_recebimento"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (SolicitacaoCompraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
                  }
                  toRet.Add(entidade);

               }
               read.Close();
               if (transacaoInterna)
               {
                  command.Transaction.Commit();
               }
               return toRet;
            }
            catch (Exception e)
            {
                throw new Exception("Erro ao realizar o new search\r\n" + e.Message, e);
            }
        } 
    }
}
