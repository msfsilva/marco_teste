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
     [Table("lote","lot")]
     public class LoteBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LoteClass";
protected const string ErroDelete = "Erro ao excluir o LoteClass  ";
protected const string ErroSave = "Erro ao salvar o LoteClass.";
protected const string ErroCollectionHistoricoCompraEpiClassLote = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected const string ErroCollectionHistoricoCompraMaterialClassLote = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected const string ErroCollectionHistoricoCompraProdutoClassLote = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected const string ErroCollectionLoteSolicitacaoCompraClassLote = "Erro ao carregar a coleção de LoteSolicitacaoCompraClass.";
protected const string ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote = "Erro ao carregar a coleção de OrdemProducaoPostoTrabalhoProducaoLoteClass.";
protected const string ErroCollectionPedidoItemLoteClienteClassLote = "Erro ao carregar a coleção de PedidoItemLoteClienteClass.";
protected const string ErroNfSerieObrigatorio = "O campo NfSerie é obrigatório";
protected const string ErroNfSerieComprimento = "O campo NfSerie deve ter no máximo 255 caracteres";
protected const string ErroNfNumeroObrigatorio = "O campo NfNumero é obrigatório";
protected const string ErroNfNumeroComprimento = "O campo NfNumero deve ter no máximo 255 caracteres";
protected const string ErroCodigoItemFornecedorClienteObrigatorio = "O campo CodigoItemFornecedorCliente é obrigatório";
protected const string ErroCodigoItemFornecedorClienteComprimento = "O campo CodigoItemFornecedorCliente deve ter no máximo 255 caracteres";
protected const string ErroDescricaoItemFornecedorClienteObrigatorio = "O campo DescricaoItemFornecedorCliente é obrigatório";
protected const string ErroDescricaoItemFornecedorClienteComprimento = "O campo DescricaoItemFornecedorCliente deve ter no máximo 255 caracteres";
protected const string ErroNcmItemFornecedorClienteObrigatorio = "O campo NcmItemFornecedorCliente é obrigatório";
protected const string ErroNcmItemFornecedorClienteComprimento = "O campo NcmItemFornecedorCliente deve ter no máximo 255 caracteres";
protected const string ErroUnidadeItemFornecedorClienteObrigatorio = "O campo UnidadeItemFornecedorCliente é obrigatório";
protected const string ErroUnidadeItemFornecedorClienteComprimento = "O campo UnidadeItemFornecedorCliente deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do LoteClass.";
protected const string MensagemUtilizadoCollectionHistoricoCompraEpiClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected const string MensagemUtilizadoCollectionLoteSolicitacaoCompraClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes LoteSolicitacaoCompraClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes OrdemProducaoPostoTrabalhoProducaoLoteClass:";
protected const string MensagemUtilizadoCollectionPedidoItemLoteClienteClassLote =  "A entidade LoteClass está sendo utilizada nos seguintes PedidoItemLoteClienteClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LoteClass está sendo utilizada.";
#endregion
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

       protected BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _fornecedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FornecedorClass _valueFornecedor;
        [Column("id_fornecedor", "fornecedor", "id_fornecedor")]
       public virtual BibliotecaEntidades.Entidades.FornecedorClass Fornecedor
        { 
           get {                 return this._valueFornecedor; } 
           set 
           { 
                if (this._valueFornecedor == value)return;
                 this._valueFornecedor = value; 
           } 
       } 

       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("lot_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected double _qtdOriginal{get;private set;}
       private double _qtdOriginalCommited{get; set;}
        private double _valueQtd;
         [Column("lot_qtd")]
        public virtual double Qtd
         { 
            get { return this._valueQtd; } 
            set 
            { 
                if (this._valueQtd == value)return;
                 this._valueQtd = value; 
            } 
        } 

       protected DateTime _dataRecebimentoOriginal{get;private set;}
       private DateTime _dataRecebimentoOriginalCommited{get; set;}
        private DateTime _valueDataRecebimento;
         [Column("lot_data_recebimento")]
        public virtual DateTime DataRecebimento
         { 
            get { return this._valueDataRecebimento; } 
            set 
            { 
                if (this._valueDataRecebimento == value)return;
                 this._valueDataRecebimento = value; 
            } 
        } 

       protected DateTime? _dataFabricacaoOriginal{get;private set;}
       private DateTime? _dataFabricacaoOriginalCommited{get; set;}
        private DateTime? _valueDataFabricacao;
         [Column("lot_data_fabricacao")]
        public virtual DateTime? DataFabricacao
         { 
            get { return this._valueDataFabricacao; } 
            set 
            { 
                if (this._valueDataFabricacao == value)return;
                 this._valueDataFabricacao = value; 
            } 
        } 

       protected DateTime? _dataEmbalagemOriginal{get;private set;}
       private DateTime? _dataEmbalagemOriginalCommited{get; set;}
        private DateTime? _valueDataEmbalagem;
         [Column("lot_data_embalagem")]
        public virtual DateTime? DataEmbalagem
         { 
            get { return this._valueDataEmbalagem; } 
            set 
            { 
                if (this._valueDataEmbalagem == value)return;
                 this._valueDataEmbalagem = value; 
            } 
        } 

       protected DateTime? _dataValidadeOriginal{get;private set;}
       private DateTime? _dataValidadeOriginalCommited{get; set;}
        private DateTime? _valueDataValidade;
         [Column("lot_data_validade")]
        public virtual DateTime? DataValidade
         { 
            get { return this._valueDataValidade; } 
            set 
            { 
                if (this._valueDataValidade == value)return;
                 this._valueDataValidade = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueCliente;
        [Column("id_cliente", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass Cliente
        { 
           get {                 return this._valueCliente; } 
           set 
           { 
                if (this._valueCliente == value)return;
                 this._valueCliente = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.EmissorCertificadoClass _emissorCertificadoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EmissorCertificadoClass _emissorCertificadoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EmissorCertificadoClass _valueEmissorCertificado;
        [Column("id_emissor_certificado", "emissor_certificado", "id_emissor_certificado")]
       public virtual BibliotecaEntidades.Entidades.EmissorCertificadoClass EmissorCertificado
        { 
           get {                 return this._valueEmissorCertificado; } 
           set 
           { 
                if (this._valueEmissorCertificado == value)return;
                 this._valueEmissorCertificado = value; 
           } 
       } 

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

       protected string _certificadoOriginal{get;private set;}
       private string _certificadoOriginalCommited{get; set;}
        private string _valueCertificado;
         [Column("lot_certificado")]
        public virtual string Certificado
         { 
            get { return this._valueCertificado; } 
            set 
            { 
                if (this._valueCertificado == value)return;
                 this._valueCertificado = value; 
            } 
        } 

       protected string _obsOriginal{get;private set;}
       private string _obsOriginalCommited{get; set;}
        private string _valueObs;
         [Column("lot_obs")]
        public virtual string Obs
         { 
            get { return this._valueObs; } 
            set 
            { 
                if (this._valueObs == value)return;
                 this._valueObs = value; 
            } 
        } 

       protected double _saldoDevolucaoOriginal{get;private set;}
       private double _saldoDevolucaoOriginalCommited{get; set;}
        private double _valueSaldoDevolucao;
         [Column("lot_saldo_devolucao")]
        public virtual double SaldoDevolucao
         { 
            get { return this._valueSaldoDevolucao; } 
            set 
            { 
                if (this._valueSaldoDevolucao == value)return;
                 this._valueSaldoDevolucao = value; 
            } 
        } 

       protected StatusLote _situacaoOriginal{get;private set;}
       private StatusLote _situacaoOriginalCommited{get; set;}
        private StatusLote _valueSituacao;
         [Column("lot_situacao")]
        public virtual StatusLote Situacao
         { 
            get { return this._valueSituacao; } 
            set 
            { 
                if (this._valueSituacao == value)return;
                 this._valueSituacao = value; 
            } 
        } 

        public bool Situacao_EmAberto
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusLote.EmAberto; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusLote.EmAberto; }
         } 

        public bool Situacao_Encerrado
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusLote.Encerrado; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusLote.Encerrado; }
         } 

        public bool Situacao_Cancelado
         { 
            get { return this._valueSituacao == BibliotecaEntidades.Base.StatusLote.Cancelado; } 
            set { if (value) this._valueSituacao = BibliotecaEntidades.Base.StatusLote.Cancelado; }
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

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioEncerramentoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioEncerramento;
        [Column("id_acs_usuario_encerramento", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioEncerramento
        { 
           get {                 return this._valueAcsUsuarioEncerramento; } 
           set 
           { 
                if (this._valueAcsUsuarioEncerramento == value)return;
                 this._valueAcsUsuarioEncerramento = value; 
           } 
       } 

       protected double _saldoVinculoPedidoOriginal{get;private set;}
       private double _saldoVinculoPedidoOriginalCommited{get; set;}
        private double _valueSaldoVinculoPedido;
         [Column("lot_saldo_vinculo_pedido")]
        public virtual double SaldoVinculoPedido
         { 
            get { return this._valueSaldoVinculoPedido; } 
            set 
            { 
                if (this._valueSaldoVinculoPedido == value)return;
                 this._valueSaldoVinculoPedido = value; 
            } 
        } 

       protected string _nfSerieOriginal{get;private set;}
       private string _nfSerieOriginalCommited{get; set;}
        private string _valueNfSerie;
         [Column("lot_nf_serie")]
        public virtual string NfSerie
         { 
            get { return this._valueNfSerie; } 
            set 
            { 
                if (this._valueNfSerie == value)return;
                 this._valueNfSerie = value; 
            } 
        } 

       protected string _nfNumeroOriginal{get;private set;}
       private string _nfNumeroOriginalCommited{get; set;}
        private string _valueNfNumero;
         [Column("lot_nf_numero")]
        public virtual string NfNumero
         { 
            get { return this._valueNfNumero; } 
            set 
            { 
                if (this._valueNfNumero == value)return;
                 this._valueNfNumero = value; 
            } 
        } 

       protected DateTime _nfDataOriginal{get;private set;}
       private DateTime _nfDataOriginalCommited{get; set;}
        private DateTime _valueNfData;
         [Column("lot_nf_data")]
        public virtual DateTime NfData
         { 
            get { return this._valueNfData; } 
            set 
            { 
                if (this._valueNfData == value)return;
                 this._valueNfData = value; 
            } 
        } 

       protected double _qtdCompraOriginal{get;private set;}
       private double _qtdCompraOriginalCommited{get; set;}
        private double _valueQtdCompra;
         [Column("lot_qtd_compra")]
        public virtual double QtdCompra
         { 
            get { return this._valueQtdCompra; } 
            set 
            { 
                if (this._valueQtdCompra == value)return;
                 this._valueQtdCompra = value; 
            } 
        } 

       protected double _valorUnitarioOriginal{get;private set;}
       private double _valorUnitarioOriginalCommited{get; set;}
        private double _valueValorUnitario;
         [Column("lot_valor_unitario")]
        public virtual double ValorUnitario
         { 
            get { return this._valueValorUnitario; } 
            set 
            { 
                if (this._valueValorUnitario == value)return;
                 this._valueValorUnitario = value; 
            } 
        } 

       protected string _codigoItemFornecedorClienteOriginal{get;private set;}
       private string _codigoItemFornecedorClienteOriginalCommited{get; set;}
        private string _valueCodigoItemFornecedorCliente;
         [Column("lot_codigo_item_fornecedor_cliente")]
        public virtual string CodigoItemFornecedorCliente
         { 
            get { return this._valueCodigoItemFornecedorCliente; } 
            set 
            { 
                if (this._valueCodigoItemFornecedorCliente == value)return;
                 this._valueCodigoItemFornecedorCliente = value; 
            } 
        } 

       protected string _descricaoItemFornecedorClienteOriginal{get;private set;}
       private string _descricaoItemFornecedorClienteOriginalCommited{get; set;}
        private string _valueDescricaoItemFornecedorCliente;
         [Column("lot_descricao_item_fornecedor_cliente")]
        public virtual string DescricaoItemFornecedorCliente
         { 
            get { return this._valueDescricaoItemFornecedorCliente; } 
            set 
            { 
                if (this._valueDescricaoItemFornecedorCliente == value)return;
                 this._valueDescricaoItemFornecedorCliente = value; 
            } 
        } 

       protected string _ncmItemFornecedorClienteOriginal{get;private set;}
       private string _ncmItemFornecedorClienteOriginalCommited{get; set;}
        private string _valueNcmItemFornecedorCliente;
         [Column("lot_ncm_item_fornecedor_cliente")]
        public virtual string NcmItemFornecedorCliente
         { 
            get { return this._valueNcmItemFornecedorCliente; } 
            set 
            { 
                if (this._valueNcmItemFornecedorCliente == value)return;
                 this._valueNcmItemFornecedorCliente = value; 
            } 
        } 

       protected string _unidadeItemFornecedorClienteOriginal{get;private set;}
       private string _unidadeItemFornecedorClienteOriginalCommited{get; set;}
        private string _valueUnidadeItemFornecedorCliente;
         [Column("lot_unidade_item_fornecedor_cliente")]
        public virtual string UnidadeItemFornecedorCliente
         { 
            get { return this._valueUnidadeItemFornecedorCliente; } 
            set 
            { 
                if (this._valueUnidadeItemFornecedorCliente == value)return;
                 this._valueUnidadeItemFornecedorCliente = value; 
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

       protected string _codBenefFiscalItemFornecedorClienteOriginal{get;private set;}
       private string _codBenefFiscalItemFornecedorClienteOriginalCommited{get; set;}
        private string _valueCodBenefFiscalItemFornecedorCliente;
         [Column("lot_cod_benef_fiscal_item_fornecedor_cliente")]
        public virtual string CodBenefFiscalItemFornecedorCliente
         { 
            get { return this._valueCodBenefFiscalItemFornecedorCliente; } 
            set 
            { 
                if (this._valueCodBenefFiscalItemFornecedorCliente == value)return;
                 this._valueCodBenefFiscalItemFornecedorCliente = value; 
            } 
        } 

       private List<long> _collectionHistoricoCompraEpiClassLoteOriginal;
       private List<Entidades.HistoricoCompraEpiClass > _collectionHistoricoCompraEpiClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraEpiClass> _valueCollectionHistoricoCompraEpiClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraEpiClass> CollectionHistoricoCompraEpiClassLote 
       { 
           get { if(!_valueCollectionHistoricoCompraEpiClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraEpiClassLote();}
return this._valueCollectionHistoricoCompraEpiClassLote; } 
           set 
           { 
               this._valueCollectionHistoricoCompraEpiClassLote = value; 
               this._valueCollectionHistoricoCompraEpiClassLoteLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraMaterialClassLoteOriginal;
       private List<Entidades.HistoricoCompraMaterialClass > _collectionHistoricoCompraMaterialClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraMaterialClass> _valueCollectionHistoricoCompraMaterialClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraMaterialClass> CollectionHistoricoCompraMaterialClassLote 
       { 
           get { if(!_valueCollectionHistoricoCompraMaterialClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraMaterialClassLote();}
return this._valueCollectionHistoricoCompraMaterialClassLote; } 
           set 
           { 
               this._valueCollectionHistoricoCompraMaterialClassLote = value; 
               this._valueCollectionHistoricoCompraMaterialClassLoteLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraProdutoClassLoteOriginal;
       private List<Entidades.HistoricoCompraProdutoClass > _collectionHistoricoCompraProdutoClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraProdutoClass> _valueCollectionHistoricoCompraProdutoClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraProdutoClass> CollectionHistoricoCompraProdutoClassLote 
       { 
           get { if(!_valueCollectionHistoricoCompraProdutoClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraProdutoClassLote();}
return this._valueCollectionHistoricoCompraProdutoClassLote; } 
           set 
           { 
               this._valueCollectionHistoricoCompraProdutoClassLote = value; 
               this._valueCollectionHistoricoCompraProdutoClassLoteLoaded = true; 
           } 
       } 

       private List<long> _collectionLoteSolicitacaoCompraClassLoteOriginal;
       private List<Entidades.LoteSolicitacaoCompraClass > _collectionLoteSolicitacaoCompraClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.LoteSolicitacaoCompraClass> _valueCollectionLoteSolicitacaoCompraClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.LoteSolicitacaoCompraClass> CollectionLoteSolicitacaoCompraClassLote 
       { 
           get { if(!_valueCollectionLoteSolicitacaoCompraClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionLoteSolicitacaoCompraClassLote();}
return this._valueCollectionLoteSolicitacaoCompraClassLote; } 
           set 
           { 
               this._valueCollectionLoteSolicitacaoCompraClassLote = value; 
               this._valueCollectionLoteSolicitacaoCompraClassLoteLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteOriginal;
       private List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass > _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote 
       { 
           get { if(!_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote();}
return this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote = value; 
               this._valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemLoteClienteClassLoteOriginal;
       private List<Entidades.PedidoItemLoteClienteClass > _collectionPedidoItemLoteClienteClassLoteRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassLoteLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassLoteChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemLoteClienteClass> _valueCollectionPedidoItemLoteClienteClassLote { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemLoteClienteClass> CollectionPedidoItemLoteClienteClassLote 
       { 
           get { if(!_valueCollectionPedidoItemLoteClienteClassLoteLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemLoteClienteClassLote();}
return this._valueCollectionPedidoItemLoteClienteClassLote; } 
           set 
           { 
               this._valueCollectionPedidoItemLoteClienteClassLote = value; 
               this._valueCollectionPedidoItemLoteClienteClassLoteLoaded = true; 
           } 
       } 

        public LoteBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Qtd = 0;
           this.Situacao = (StatusLote)0;
           this.SaldoVinculoPedido = 0;
           this.ValorUnitario = 0;
           this.CodigoItemFornecedorCliente = "";
           this.DescricaoItemFornecedorCliente = "";
           this.NcmItemFornecedorCliente = "";
           this.UnidadeItemFornecedorCliente = "";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static LoteClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LoteClass) GetEntity(typeof(LoteClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionHistoricoCompraEpiClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraEpiClassLoteChanged = true;
                  _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraEpiClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraEpiClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraEpiClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in _valueCollectionHistoricoCompraEpiClassLote) 
                 { 
                     _collectionHistoricoCompraEpiClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraEpiClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraEpiClass> oc;
                _valueCollectionHistoricoCompraEpiClassLoteChanged = false;
                 _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged = false;
                _collectionHistoricoCompraEpiClassLoteRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraEpiClass>();
                }
                else{ 
                   Entidades.HistoricoCompraEpiClass search = new Entidades.HistoricoCompraEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.HistoricoCompraEpiClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraEpiClassLote = new BindingList<Entidades.HistoricoCompraEpiClass>(oc); 
                 _collectionHistoricoCompraEpiClassLoteOriginal= (from a in _valueCollectionHistoricoCompraEpiClassLote select a.ID).ToList();
                 _valueCollectionHistoricoCompraEpiClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraEpiClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraEpiClassLote+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraMaterialClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraMaterialClassLoteChanged = true;
                  _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraMaterialClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraMaterialClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraMaterialClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in _valueCollectionHistoricoCompraMaterialClassLote) 
                 { 
                     _collectionHistoricoCompraMaterialClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraMaterialClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraMaterialClass> oc;
                _valueCollectionHistoricoCompraMaterialClassLoteChanged = false;
                 _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged = false;
                _collectionHistoricoCompraMaterialClassLoteRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraMaterialClass>();
                }
                else{ 
                   Entidades.HistoricoCompraMaterialClass search = new Entidades.HistoricoCompraMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.HistoricoCompraMaterialClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraMaterialClassLote = new BindingList<Entidades.HistoricoCompraMaterialClass>(oc); 
                 _collectionHistoricoCompraMaterialClassLoteOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassLote select a.ID).ToList();
                 _valueCollectionHistoricoCompraMaterialClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraMaterialClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraMaterialClassLote+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraProdutoClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraProdutoClassLoteChanged = true;
                  _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraProdutoClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraProdutoClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraProdutoClassLoteChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in _valueCollectionHistoricoCompraProdutoClassLote) 
                 { 
                     _collectionHistoricoCompraProdutoClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraProdutoClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraProdutoClass> oc;
                _valueCollectionHistoricoCompraProdutoClassLoteChanged = false;
                 _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged = false;
                _collectionHistoricoCompraProdutoClassLoteRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraProdutoClass>();
                }
                else{ 
                   Entidades.HistoricoCompraProdutoClass search = new Entidades.HistoricoCompraProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.HistoricoCompraProdutoClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraProdutoClassLote = new BindingList<Entidades.HistoricoCompraProdutoClass>(oc); 
                 _collectionHistoricoCompraProdutoClassLoteOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassLote select a.ID).ToList();
                 _valueCollectionHistoricoCompraProdutoClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraProdutoClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraProdutoClassLote+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionLoteSolicitacaoCompraClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionLoteSolicitacaoCompraClassLoteChanged = true;
                  _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionLoteSolicitacaoCompraClassLoteChanged = true; 
                  _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged = true;
                 foreach (Entidades.LoteSolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionLoteSolicitacaoCompraClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionLoteSolicitacaoCompraClassLoteChanged = true; 
                  _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged = true;
                 foreach (Entidades.LoteSolicitacaoCompraClass item in _valueCollectionLoteSolicitacaoCompraClassLote) 
                 { 
                     _collectionLoteSolicitacaoCompraClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionLoteSolicitacaoCompraClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.LoteSolicitacaoCompraClass> oc;
                _valueCollectionLoteSolicitacaoCompraClassLoteChanged = false;
                 _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged = false;
                _collectionLoteSolicitacaoCompraClassLoteRemovidos = new List<Entidades.LoteSolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.LoteSolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.LoteSolicitacaoCompraClass search = new Entidades.LoteSolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.LoteSolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.LoteSolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionLoteSolicitacaoCompraClassLote = new BindingList<Entidades.LoteSolicitacaoCompraClass>(oc); 
                 _collectionLoteSolicitacaoCompraClassLoteOriginal= (from a in _valueCollectionLoteSolicitacaoCompraClassLote select a.ID).ToList();
                 _valueCollectionLoteSolicitacaoCompraClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionLoteSolicitacaoCompraClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionLoteSolicitacaoCompraClassLote+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged = true;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged = true; 
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass item in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote) 
                 { 
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass> oc;
                _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged = false;
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged = false;
                _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass search = new Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote = new BindingList<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>(oc); 
                 _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote select a.ID).ToList();
                 _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemLoteClienteClassLoteChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemLoteClienteClassLoteChanged = true;
                  _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemLoteClienteClassLoteChanged = true; 
                  _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged = true;
                 foreach (Entidades.PedidoItemLoteClienteClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemLoteClienteClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemLoteClienteClassLoteChanged = true; 
                  _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged = true;
                 foreach (Entidades.PedidoItemLoteClienteClass item in _valueCollectionPedidoItemLoteClienteClassLote) 
                 { 
                     _collectionPedidoItemLoteClienteClassLoteRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemLoteClienteClassLote()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemLoteClienteClass> oc;
                _valueCollectionPedidoItemLoteClienteClassLoteChanged = false;
                 _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged = false;
                _collectionPedidoItemLoteClienteClassLoteRemovidos = new List<Entidades.PedidoItemLoteClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemLoteClienteClass>();
                }
                else{ 
                   Entidades.PedidoItemLoteClienteClass search = new Entidades.PedidoItemLoteClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemLoteClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Lote", this),                     }                       ).Cast<Entidades.PedidoItemLoteClienteClass>().ToList());
                 }
                 _valueCollectionPedidoItemLoteClienteClassLote = new BindingList<Entidades.PedidoItemLoteClienteClass>(oc); 
                 _collectionPedidoItemLoteClienteClassLoteOriginal= (from a in _valueCollectionPedidoItemLoteClienteClassLote select a.ID).ToList();
                 _valueCollectionPedidoItemLoteClienteClassLoteLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemLoteClienteClassLoteChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemLoteClienteClassLote+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NfSerie))
                {
                    throw new Exception(ErroNfSerieObrigatorio);
                }
                if (NfSerie.Length >255)
                {
                    throw new Exception( ErroNfSerieComprimento);
                }
                if (string.IsNullOrEmpty(NfNumero))
                {
                    throw new Exception(ErroNfNumeroObrigatorio);
                }
                if (NfNumero.Length >255)
                {
                    throw new Exception( ErroNfNumeroComprimento);
                }
                if (string.IsNullOrEmpty(CodigoItemFornecedorCliente))
                {
                    throw new Exception(ErroCodigoItemFornecedorClienteObrigatorio);
                }
                if (CodigoItemFornecedorCliente.Length >255)
                {
                    throw new Exception( ErroCodigoItemFornecedorClienteComprimento);
                }
                if (string.IsNullOrEmpty(DescricaoItemFornecedorCliente))
                {
                    throw new Exception(ErroDescricaoItemFornecedorClienteObrigatorio);
                }
                if (DescricaoItemFornecedorCliente.Length >255)
                {
                    throw new Exception( ErroDescricaoItemFornecedorClienteComprimento);
                }
                if (string.IsNullOrEmpty(NcmItemFornecedorCliente))
                {
                    throw new Exception(ErroNcmItemFornecedorClienteObrigatorio);
                }
                if (NcmItemFornecedorCliente.Length >255)
                {
                    throw new Exception( ErroNcmItemFornecedorClienteComprimento);
                }
                if (string.IsNullOrEmpty(UnidadeItemFornecedorCliente))
                {
                    throw new Exception(ErroUnidadeItemFornecedorClienteObrigatorio);
                }
                if (UnidadeItemFornecedorCliente.Length >255)
                {
                    throw new Exception( ErroUnidadeItemFornecedorClienteComprimento);
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
                    "  public.lote  " +
                    "WHERE " +
                    "  id_lote = :id";
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
                        "  public.lote   " +
                        "SET  " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  id_fornecedor = :id_fornecedor, " + 
                        "  lot_numero = :lot_numero, " + 
                        "  lot_qtd = :lot_qtd, " + 
                        "  lot_data_recebimento = :lot_data_recebimento, " + 
                        "  lot_data_fabricacao = :lot_data_fabricacao, " + 
                        "  lot_data_embalagem = :lot_data_embalagem, " + 
                        "  lot_data_validade = :lot_data_validade, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_emissor_certificado = :id_emissor_certificado, " + 
                        "  id_material = :id_material, " + 
                        "  id_produto = :id_produto, " + 
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
                        "  lot_qtd_compra = :lot_qtd_compra, " + 
                        "  lot_valor_unitario = :lot_valor_unitario, " + 
                        "  lot_codigo_item_fornecedor_cliente = :lot_codigo_item_fornecedor_cliente, " + 
                        "  lot_descricao_item_fornecedor_cliente = :lot_descricao_item_fornecedor_cliente, " + 
                        "  lot_ncm_item_fornecedor_cliente = :lot_ncm_item_fornecedor_cliente, " + 
                        "  lot_unidade_item_fornecedor_cliente = :lot_unidade_item_fornecedor_cliente, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_epi = :id_epi, " + 
                        "  lot_cod_benef_fiscal_item_fornecedor_cliente = :lot_cod_benef_fiscal_item_fornecedor_cliente "+
                        "WHERE  " +
                        "  id_lote = :id " +
                        "RETURNING id_lote;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.lote " +
                        "( " +
                        "  id_acs_usuario , " + 
                        "  id_fornecedor , " + 
                        "  lot_numero , " + 
                        "  lot_qtd , " + 
                        "  lot_data_recebimento , " + 
                        "  lot_data_fabricacao , " + 
                        "  lot_data_embalagem , " + 
                        "  lot_data_validade , " + 
                        "  id_cliente , " + 
                        "  id_emissor_certificado , " + 
                        "  id_material , " + 
                        "  id_produto , " + 
                        "  lot_certificado , " + 
                        "  lot_obs , " + 
                        "  lot_saldo_devolucao , " + 
                        "  lot_situacao , " + 
                        "  id_acs_usuario_cancelamento , " + 
                        "  id_acs_usuario_encerramento , " + 
                        "  lot_saldo_vinculo_pedido , " + 
                        "  lot_nf_serie , " + 
                        "  lot_nf_numero , " + 
                        "  lot_nf_data , " + 
                        "  lot_qtd_compra , " + 
                        "  lot_valor_unitario , " + 
                        "  lot_codigo_item_fornecedor_cliente , " + 
                        "  lot_descricao_item_fornecedor_cliente , " + 
                        "  lot_ncm_item_fornecedor_cliente , " + 
                        "  lot_unidade_item_fornecedor_cliente , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_epi , " + 
                        "  lot_cod_benef_fiscal_item_fornecedor_cliente  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_acs_usuario , " + 
                        "  :id_fornecedor , " + 
                        "  :lot_numero , " + 
                        "  :lot_qtd , " + 
                        "  :lot_data_recebimento , " + 
                        "  :lot_data_fabricacao , " + 
                        "  :lot_data_embalagem , " + 
                        "  :lot_data_validade , " + 
                        "  :id_cliente , " + 
                        "  :id_emissor_certificado , " + 
                        "  :id_material , " + 
                        "  :id_produto , " + 
                        "  :lot_certificado , " + 
                        "  :lot_obs , " + 
                        "  :lot_saldo_devolucao , " + 
                        "  :lot_situacao , " + 
                        "  :id_acs_usuario_cancelamento , " + 
                        "  :id_acs_usuario_encerramento , " + 
                        "  :lot_saldo_vinculo_pedido , " + 
                        "  :lot_nf_serie , " + 
                        "  :lot_nf_numero , " + 
                        "  :lot_nf_data , " + 
                        "  :lot_qtd_compra , " + 
                        "  :lot_valor_unitario , " + 
                        "  :lot_codigo_item_fornecedor_cliente , " + 
                        "  :lot_descricao_item_fornecedor_cliente , " + 
                        "  :lot_ncm_item_fornecedor_cliente , " + 
                        "  :lot_unidade_item_fornecedor_cliente , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_epi , " + 
                        "  :lot_cod_benef_fiscal_item_fornecedor_cliente  "+
                        ")RETURNING id_lote;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_qtd", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Qtd ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_recebimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataRecebimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_fabricacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataFabricacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_embalagem", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEmbalagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_data_validade", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataValidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_emissor_certificado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EmissorCertificado==null ? (object) DBNull.Value : this.EmissorCertificado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_material", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Material==null ? (object) DBNull.Value : this.Material.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_certificado", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Certificado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Obs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_saldo_devolucao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SaldoDevolucao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_situacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Situacao);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_encerramento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioEncerramento==null ? (object) DBNull.Value : this.AcsUsuarioEncerramento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_saldo_vinculo_pedido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SaldoVinculoPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_serie", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfSerie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfNumero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_nf_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_qtd_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_valor_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_codigo_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItemFornecedorCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_descricao_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoItemFornecedorCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_ncm_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NcmItemFornecedorCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_unidade_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UnidadeItemFornecedorCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_epi", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Epi==null ? (object) DBNull.Value : this.Epi.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lot_cod_benef_fiscal_item_fornecedor_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodBenefFiscalItemFornecedorCliente ?? DBNull.Value;

 
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
 if (CollectionHistoricoCompraEpiClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraEpiClassLote+"\r\n";
                foreach (Entidades.HistoricoCompraEpiClass tmp in CollectionHistoricoCompraEpiClassLote)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraMaterialClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraMaterialClassLote+"\r\n";
                foreach (Entidades.HistoricoCompraMaterialClass tmp in CollectionHistoricoCompraMaterialClassLote)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraProdutoClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassLote+"\r\n";
                foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassLote)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionLoteSolicitacaoCompraClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionLoteSolicitacaoCompraClassLote+"\r\n";
                foreach (Entidades.LoteSolicitacaoCompraClass tmp in CollectionLoteSolicitacaoCompraClassLote)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote+"\r\n";
                foreach (Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass tmp in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemLoteClienteClassLote.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemLoteClienteClassLote+"\r\n";
                foreach (Entidades.PedidoItemLoteClienteClass tmp in CollectionPedidoItemLoteClienteClassLote)
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
        public static LoteClass CopiarEntidade(LoteClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LoteClass toRet = new LoteClass(usuario,conn);
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Qtd= entidadeCopiar.Qtd;
 toRet.DataRecebimento= entidadeCopiar.DataRecebimento;
 toRet.DataFabricacao= entidadeCopiar.DataFabricacao;
 toRet.DataEmbalagem= entidadeCopiar.DataEmbalagem;
 toRet.DataValidade= entidadeCopiar.DataValidade;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.EmissorCertificado= entidadeCopiar.EmissorCertificado;
 toRet.Material= entidadeCopiar.Material;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.Certificado= entidadeCopiar.Certificado;
 toRet.Obs= entidadeCopiar.Obs;
 toRet.SaldoDevolucao= entidadeCopiar.SaldoDevolucao;
 toRet.Situacao= entidadeCopiar.Situacao;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;
 toRet.AcsUsuarioEncerramento= entidadeCopiar.AcsUsuarioEncerramento;
 toRet.SaldoVinculoPedido= entidadeCopiar.SaldoVinculoPedido;
 toRet.NfSerie= entidadeCopiar.NfSerie;
 toRet.NfNumero= entidadeCopiar.NfNumero;
 toRet.NfData= entidadeCopiar.NfData;
 toRet.QtdCompra= entidadeCopiar.QtdCompra;
 toRet.ValorUnitario= entidadeCopiar.ValorUnitario;
 toRet.CodigoItemFornecedorCliente= entidadeCopiar.CodigoItemFornecedorCliente;
 toRet.DescricaoItemFornecedorCliente= entidadeCopiar.DescricaoItemFornecedorCliente;
 toRet.NcmItemFornecedorCliente= entidadeCopiar.NcmItemFornecedorCliente;
 toRet.UnidadeItemFornecedorCliente= entidadeCopiar.UnidadeItemFornecedorCliente;
 toRet.Epi= entidadeCopiar.Epi;
 toRet.CodBenefFiscalItemFornecedorCliente= entidadeCopiar.CodBenefFiscalItemFornecedorCliente;

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
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _qtdOriginal = Qtd;
       _qtdOriginalCommited = _qtdOriginal;
       _dataRecebimentoOriginal = DataRecebimento;
       _dataRecebimentoOriginalCommited = _dataRecebimentoOriginal;
       _dataFabricacaoOriginal = DataFabricacao;
       _dataFabricacaoOriginalCommited = _dataFabricacaoOriginal;
       _dataEmbalagemOriginal = DataEmbalagem;
       _dataEmbalagemOriginalCommited = _dataEmbalagemOriginal;
       _dataValidadeOriginal = DataValidade;
       _dataValidadeOriginalCommited = _dataValidadeOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _emissorCertificadoOriginal = EmissorCertificado;
       _emissorCertificadoOriginalCommited = _emissorCertificadoOriginal;
       _materialOriginal = Material;
       _materialOriginalCommited = _materialOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _certificadoOriginal = Certificado;
       _certificadoOriginalCommited = _certificadoOriginal;
       _obsOriginal = Obs;
       _obsOriginalCommited = _obsOriginal;
       _saldoDevolucaoOriginal = SaldoDevolucao;
       _saldoDevolucaoOriginalCommited = _saldoDevolucaoOriginal;
       _situacaoOriginal = Situacao;
       _situacaoOriginalCommited = _situacaoOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;
       _acsUsuarioEncerramentoOriginal = AcsUsuarioEncerramento;
       _acsUsuarioEncerramentoOriginalCommited = _acsUsuarioEncerramentoOriginal;
       _saldoVinculoPedidoOriginal = SaldoVinculoPedido;
       _saldoVinculoPedidoOriginalCommited = _saldoVinculoPedidoOriginal;
       _nfSerieOriginal = NfSerie;
       _nfSerieOriginalCommited = _nfSerieOriginal;
       _nfNumeroOriginal = NfNumero;
       _nfNumeroOriginalCommited = _nfNumeroOriginal;
       _nfDataOriginal = NfData;
       _nfDataOriginalCommited = _nfDataOriginal;
       _qtdCompraOriginal = QtdCompra;
       _qtdCompraOriginalCommited = _qtdCompraOriginal;
       _valorUnitarioOriginal = ValorUnitario;
       _valorUnitarioOriginalCommited = _valorUnitarioOriginal;
       _codigoItemFornecedorClienteOriginal = CodigoItemFornecedorCliente;
       _codigoItemFornecedorClienteOriginalCommited = _codigoItemFornecedorClienteOriginal;
       _descricaoItemFornecedorClienteOriginal = DescricaoItemFornecedorCliente;
       _descricaoItemFornecedorClienteOriginalCommited = _descricaoItemFornecedorClienteOriginal;
       _ncmItemFornecedorClienteOriginal = NcmItemFornecedorCliente;
       _ncmItemFornecedorClienteOriginalCommited = _ncmItemFornecedorClienteOriginal;
       _unidadeItemFornecedorClienteOriginal = UnidadeItemFornecedorCliente;
       _unidadeItemFornecedorClienteOriginalCommited = _unidadeItemFornecedorClienteOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _epiOriginal = Epi;
       _epiOriginalCommited = _epiOriginal;
       _codBenefFiscalItemFornecedorClienteOriginal = CodBenefFiscalItemFornecedorCliente;
       _codBenefFiscalItemFornecedorClienteOriginalCommited = _codBenefFiscalItemFornecedorClienteOriginal;

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
       _acsUsuarioOriginalCommited = AcsUsuario;
       _fornecedorOriginalCommited = Fornecedor;
       _numeroOriginalCommited = Numero;
       _qtdOriginalCommited = Qtd;
       _dataRecebimentoOriginalCommited = DataRecebimento;
       _dataFabricacaoOriginalCommited = DataFabricacao;
       _dataEmbalagemOriginalCommited = DataEmbalagem;
       _dataValidadeOriginalCommited = DataValidade;
       _clienteOriginalCommited = Cliente;
       _emissorCertificadoOriginalCommited = EmissorCertificado;
       _materialOriginalCommited = Material;
       _produtoOriginalCommited = Produto;
       _certificadoOriginalCommited = Certificado;
       _obsOriginalCommited = Obs;
       _saldoDevolucaoOriginalCommited = SaldoDevolucao;
       _situacaoOriginalCommited = Situacao;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;
       _acsUsuarioEncerramentoOriginalCommited = AcsUsuarioEncerramento;
       _saldoVinculoPedidoOriginalCommited = SaldoVinculoPedido;
       _nfSerieOriginalCommited = NfSerie;
       _nfNumeroOriginalCommited = NfNumero;
       _nfDataOriginalCommited = NfData;
       _qtdCompraOriginalCommited = QtdCompra;
       _valorUnitarioOriginalCommited = ValorUnitario;
       _codigoItemFornecedorClienteOriginalCommited = CodigoItemFornecedorCliente;
       _descricaoItemFornecedorClienteOriginalCommited = DescricaoItemFornecedorCliente;
       _ncmItemFornecedorClienteOriginalCommited = NcmItemFornecedorCliente;
       _unidadeItemFornecedorClienteOriginalCommited = UnidadeItemFornecedorCliente;
       _versionOriginalCommited = Version;
       _epiOriginalCommited = Epi;
       _codBenefFiscalItemFornecedorClienteOriginalCommited = CodBenefFiscalItemFornecedorCliente;

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
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  if (_collectionHistoricoCompraEpiClassLoteRemovidos != null) 
                  {
                     _collectionHistoricoCompraEpiClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraEpiClassLoteRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                  }
                  _collectionHistoricoCompraEpiClassLoteOriginal= (from a in _valueCollectionHistoricoCompraEpiClassLote select a.ID).ToList();
                  _valueCollectionHistoricoCompraEpiClassLoteChanged = false;
                  _valueCollectionHistoricoCompraEpiClassLoteCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  if (_collectionHistoricoCompraMaterialClassLoteRemovidos != null) 
                  {
                     _collectionHistoricoCompraMaterialClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraMaterialClassLoteRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                  }
                  _collectionHistoricoCompraMaterialClassLoteOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassLote select a.ID).ToList();
                  _valueCollectionHistoricoCompraMaterialClassLoteChanged = false;
                  _valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  if (_collectionHistoricoCompraProdutoClassLoteRemovidos != null) 
                  {
                     _collectionHistoricoCompraProdutoClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraProdutoClassLoteRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                  }
                  _collectionHistoricoCompraProdutoClassLoteOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassLote select a.ID).ToList();
                  _valueCollectionHistoricoCompraProdutoClassLoteChanged = false;
                  _valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged = false;
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  if (_collectionLoteSolicitacaoCompraClassLoteRemovidos != null) 
                  {
                     _collectionLoteSolicitacaoCompraClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionLoteSolicitacaoCompraClassLoteRemovidos = new List<Entidades.LoteSolicitacaoCompraClass>();
                  }
                  _collectionLoteSolicitacaoCompraClassLoteOriginal= (from a in _valueCollectionLoteSolicitacaoCompraClassLote select a.ID).ToList();
                  _valueCollectionLoteSolicitacaoCompraClassLoteChanged = false;
                  _valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  if (_collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos != null) 
                  {
                     _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos = new List<Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass>();
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteOriginal= (from a in _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote select a.ID).ToList();
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged = false;
                  _valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  if (_collectionPedidoItemLoteClienteClassLoteRemovidos != null) 
                  {
                     _collectionPedidoItemLoteClienteClassLoteRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemLoteClienteClassLoteRemovidos = new List<Entidades.PedidoItemLoteClienteClass>();
                  }
                  _collectionPedidoItemLoteClienteClassLoteOriginal= (from a in _valueCollectionPedidoItemLoteClienteClassLote select a.ID).ToList();
                  _valueCollectionPedidoItemLoteClienteClassLoteChanged = false;
                  _valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged = false;
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
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Qtd=_qtdOriginal;
               _qtdOriginalCommited=_qtdOriginal;
               DataRecebimento=_dataRecebimentoOriginal;
               _dataRecebimentoOriginalCommited=_dataRecebimentoOriginal;
               DataFabricacao=_dataFabricacaoOriginal;
               _dataFabricacaoOriginalCommited=_dataFabricacaoOriginal;
               DataEmbalagem=_dataEmbalagemOriginal;
               _dataEmbalagemOriginalCommited=_dataEmbalagemOriginal;
               DataValidade=_dataValidadeOriginal;
               _dataValidadeOriginalCommited=_dataValidadeOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               EmissorCertificado=_emissorCertificadoOriginal;
               _emissorCertificadoOriginalCommited=_emissorCertificadoOriginal;
               Material=_materialOriginal;
               _materialOriginalCommited=_materialOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               Certificado=_certificadoOriginal;
               _certificadoOriginalCommited=_certificadoOriginal;
               Obs=_obsOriginal;
               _obsOriginalCommited=_obsOriginal;
               SaldoDevolucao=_saldoDevolucaoOriginal;
               _saldoDevolucaoOriginalCommited=_saldoDevolucaoOriginal;
               Situacao=_situacaoOriginal;
               _situacaoOriginalCommited=_situacaoOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               AcsUsuarioEncerramento=_acsUsuarioEncerramentoOriginal;
               _acsUsuarioEncerramentoOriginalCommited=_acsUsuarioEncerramentoOriginal;
               SaldoVinculoPedido=_saldoVinculoPedidoOriginal;
               _saldoVinculoPedidoOriginalCommited=_saldoVinculoPedidoOriginal;
               NfSerie=_nfSerieOriginal;
               _nfSerieOriginalCommited=_nfSerieOriginal;
               NfNumero=_nfNumeroOriginal;
               _nfNumeroOriginalCommited=_nfNumeroOriginal;
               NfData=_nfDataOriginal;
               _nfDataOriginalCommited=_nfDataOriginal;
               QtdCompra=_qtdCompraOriginal;
               _qtdCompraOriginalCommited=_qtdCompraOriginal;
               ValorUnitario=_valorUnitarioOriginal;
               _valorUnitarioOriginalCommited=_valorUnitarioOriginal;
               CodigoItemFornecedorCliente=_codigoItemFornecedorClienteOriginal;
               _codigoItemFornecedorClienteOriginalCommited=_codigoItemFornecedorClienteOriginal;
               DescricaoItemFornecedorCliente=_descricaoItemFornecedorClienteOriginal;
               _descricaoItemFornecedorClienteOriginalCommited=_descricaoItemFornecedorClienteOriginal;
               NcmItemFornecedorCliente=_ncmItemFornecedorClienteOriginal;
               _ncmItemFornecedorClienteOriginalCommited=_ncmItemFornecedorClienteOriginal;
               UnidadeItemFornecedorCliente=_unidadeItemFornecedorClienteOriginal;
               _unidadeItemFornecedorClienteOriginalCommited=_unidadeItemFornecedorClienteOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Epi=_epiOriginal;
               _epiOriginalCommited=_epiOriginal;
               CodBenefFiscalItemFornecedorCliente=_codBenefFiscalItemFornecedorClienteOriginal;
               _codBenefFiscalItemFornecedorClienteOriginalCommited=_codBenefFiscalItemFornecedorClienteOriginal;
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  CollectionHistoricoCompraEpiClassLote.Clear();
                  foreach(int item in _collectionHistoricoCompraEpiClassLoteOriginal)
                  {
                    CollectionHistoricoCompraEpiClassLote.Add(Entidades.HistoricoCompraEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraEpiClassLoteRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  CollectionHistoricoCompraMaterialClassLote.Clear();
                  foreach(int item in _collectionHistoricoCompraMaterialClassLoteOriginal)
                  {
                    CollectionHistoricoCompraMaterialClassLote.Add(Entidades.HistoricoCompraMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraMaterialClassLoteRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  CollectionHistoricoCompraProdutoClassLote.Clear();
                  foreach(int item in _collectionHistoricoCompraProdutoClassLoteOriginal)
                  {
                    CollectionHistoricoCompraProdutoClassLote.Add(Entidades.HistoricoCompraProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraProdutoClassLoteRemovidos.Clear();
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  CollectionLoteSolicitacaoCompraClassLote.Clear();
                  foreach(int item in _collectionLoteSolicitacaoCompraClassLoteOriginal)
                  {
                    CollectionLoteSolicitacaoCompraClassLote.Add(Entidades.LoteSolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionLoteSolicitacaoCompraClassLoteRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Clear();
                  foreach(int item in _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteOriginal)
                  {
                    CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Add(Entidades.OrdemProducaoPostoTrabalhoProducaoLoteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  CollectionPedidoItemLoteClienteClassLote.Clear();
                  foreach(int item in _collectionPedidoItemLoteClienteClassLoteOriginal)
                  {
                    CollectionPedidoItemLoteClienteClassLote.Add(Entidades.PedidoItemLoteClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemLoteClienteClassLoteRemovidos.Clear();
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
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  if (_valueCollectionLoteSolicitacaoCompraClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  if (_valueCollectionPedidoItemLoteClienteClassLoteChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassLote.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassLote.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassLote.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                   tempRet = CollectionLoteSolicitacaoCompraClassLote.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                   tempRet = CollectionPedidoItemLoteClienteClassLote.Any(item => item.IsDirty());
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
       if (_acsUsuarioOriginal!=null)
       {
          dirty = !_acsUsuarioOriginal.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginal!=null)
       {
          dirty = !_fornecedorOriginal.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _qtdOriginal != Qtd;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginal != DataRecebimento;
      if (dirty) return true;
       dirty = _dataFabricacaoOriginal != DataFabricacao;
      if (dirty) return true;
       dirty = _dataEmbalagemOriginal != DataEmbalagem;
      if (dirty) return true;
       dirty = _dataValidadeOriginal != DataValidade;
      if (dirty) return true;
       if (_clienteOriginal!=null)
       {
          dirty = !_clienteOriginal.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       if (_emissorCertificadoOriginal!=null)
       {
          dirty = !_emissorCertificadoOriginal.Equals(EmissorCertificado);
       }
       else
       {
            dirty = EmissorCertificado != null;
       }
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
       dirty = _certificadoOriginal != Certificado;
      if (dirty) return true;
       dirty = _obsOriginal != Obs;
      if (dirty) return true;
       dirty = _saldoDevolucaoOriginal != SaldoDevolucao;
      if (dirty) return true;
       dirty = _situacaoOriginal != Situacao;
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
       if (_acsUsuarioEncerramentoOriginal!=null)
       {
          dirty = !_acsUsuarioEncerramentoOriginal.Equals(AcsUsuarioEncerramento);
       }
       else
       {
            dirty = AcsUsuarioEncerramento != null;
       }
      if (dirty) return true;
       dirty = _saldoVinculoPedidoOriginal != SaldoVinculoPedido;
      if (dirty) return true;
       dirty = _nfSerieOriginal != NfSerie;
      if (dirty) return true;
       dirty = _nfNumeroOriginal != NfNumero;
      if (dirty) return true;
       dirty = _nfDataOriginal != NfData;
      if (dirty) return true;
       dirty = _qtdCompraOriginal != QtdCompra;
      if (dirty) return true;
       dirty = _valorUnitarioOriginal != ValorUnitario;
      if (dirty) return true;
       dirty = _codigoItemFornecedorClienteOriginal != CodigoItemFornecedorCliente;
      if (dirty) return true;
       dirty = _descricaoItemFornecedorClienteOriginal != DescricaoItemFornecedorCliente;
      if (dirty) return true;
       dirty = _ncmItemFornecedorClienteOriginal != NcmItemFornecedorCliente;
      if (dirty) return true;
       dirty = _unidadeItemFornecedorClienteOriginal != UnidadeItemFornecedorCliente;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
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
       dirty = _codBenefFiscalItemFornecedorClienteOriginal != CodBenefFiscalItemFornecedorCliente;

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
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  if (_valueCollectionLoteSolicitacaoCompraClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  if (_valueCollectionPedidoItemLoteClienteClassLoteCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassLote.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassLote.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassLote.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                   tempRet = CollectionLoteSolicitacaoCompraClassLote.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                   tempRet = CollectionPedidoItemLoteClienteClassLote.Any(item => item.IsDirtyCommited());
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
       if (_acsUsuarioOriginalCommited!=null)
       {
          dirty = !_acsUsuarioOriginalCommited.Equals(AcsUsuario);
       }
       else
       {
            dirty = AcsUsuario != null;
       }
      if (dirty) return true;
       if (_fornecedorOriginalCommited!=null)
       {
          dirty = !_fornecedorOriginalCommited.Equals(Fornecedor);
       }
       else
       {
            dirty = Fornecedor != null;
       }
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _qtdOriginalCommited != Qtd;
      if (dirty) return true;
       dirty = _dataRecebimentoOriginalCommited != DataRecebimento;
      if (dirty) return true;
       dirty = _dataFabricacaoOriginalCommited != DataFabricacao;
      if (dirty) return true;
       dirty = _dataEmbalagemOriginalCommited != DataEmbalagem;
      if (dirty) return true;
       dirty = _dataValidadeOriginalCommited != DataValidade;
      if (dirty) return true;
       if (_clienteOriginalCommited!=null)
       {
          dirty = !_clienteOriginalCommited.Equals(Cliente);
       }
       else
       {
            dirty = Cliente != null;
       }
      if (dirty) return true;
       if (_emissorCertificadoOriginalCommited!=null)
       {
          dirty = !_emissorCertificadoOriginalCommited.Equals(EmissorCertificado);
       }
       else
       {
            dirty = EmissorCertificado != null;
       }
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
       dirty = _certificadoOriginalCommited != Certificado;
      if (dirty) return true;
       dirty = _obsOriginalCommited != Obs;
      if (dirty) return true;
       dirty = _saldoDevolucaoOriginalCommited != SaldoDevolucao;
      if (dirty) return true;
       dirty = _situacaoOriginalCommited != Situacao;
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
       if (_acsUsuarioEncerramentoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioEncerramentoOriginalCommited.Equals(AcsUsuarioEncerramento);
       }
       else
       {
            dirty = AcsUsuarioEncerramento != null;
       }
      if (dirty) return true;
       dirty = _saldoVinculoPedidoOriginalCommited != SaldoVinculoPedido;
      if (dirty) return true;
       dirty = _nfSerieOriginalCommited != NfSerie;
      if (dirty) return true;
       dirty = _nfNumeroOriginalCommited != NfNumero;
      if (dirty) return true;
       dirty = _nfDataOriginalCommited != NfData;
      if (dirty) return true;
       dirty = _qtdCompraOriginalCommited != QtdCompra;
      if (dirty) return true;
       dirty = _valorUnitarioOriginalCommited != ValorUnitario;
      if (dirty) return true;
       dirty = _codigoItemFornecedorClienteOriginalCommited != CodigoItemFornecedorCliente;
      if (dirty) return true;
       dirty = _descricaoItemFornecedorClienteOriginalCommited != DescricaoItemFornecedorCliente;
      if (dirty) return true;
       dirty = _ncmItemFornecedorClienteOriginalCommited != NcmItemFornecedorCliente;
      if (dirty) return true;
       dirty = _unidadeItemFornecedorClienteOriginalCommited != UnidadeItemFornecedorCliente;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
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
       dirty = _codBenefFiscalItemFornecedorClienteOriginalCommited != CodBenefFiscalItemFornecedorCliente;

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
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassLote)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassLote)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassLote)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  foreach(LoteSolicitacaoCompraClass item in CollectionLoteSolicitacaoCompraClassLote)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoLoteClass item in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  foreach(PedidoItemLoteClienteClass item in CollectionPedidoItemLoteClienteClassLote)
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
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Fornecedor":
                return this.Fornecedor;
             case "Numero":
                return this.Numero;
             case "Qtd":
                return this.Qtd;
             case "DataRecebimento":
                return this.DataRecebimento;
             case "DataFabricacao":
                return this.DataFabricacao;
             case "DataEmbalagem":
                return this.DataEmbalagem;
             case "DataValidade":
                return this.DataValidade;
             case "Cliente":
                return this.Cliente;
             case "EmissorCertificado":
                return this.EmissorCertificado;
             case "Material":
                return this.Material;
             case "Produto":
                return this.Produto;
             case "Certificado":
                return this.Certificado;
             case "Obs":
                return this.Obs;
             case "SaldoDevolucao":
                return this.SaldoDevolucao;
             case "Situacao":
                return this.Situacao;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
             case "AcsUsuarioEncerramento":
                return this.AcsUsuarioEncerramento;
             case "SaldoVinculoPedido":
                return this.SaldoVinculoPedido;
             case "NfSerie":
                return this.NfSerie;
             case "NfNumero":
                return this.NfNumero;
             case "NfData":
                return this.NfData;
             case "QtdCompra":
                return this.QtdCompra;
             case "ValorUnitario":
                return this.ValorUnitario;
             case "CodigoItemFornecedorCliente":
                return this.CodigoItemFornecedorCliente;
             case "DescricaoItemFornecedorCliente":
                return this.DescricaoItemFornecedorCliente;
             case "NcmItemFornecedorCliente":
                return this.NcmItemFornecedorCliente;
             case "UnidadeItemFornecedorCliente":
                return this.UnidadeItemFornecedorCliente;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Epi":
                return this.Epi;
             case "CodBenefFiscalItemFornecedorCliente":
                return this.CodBenefFiscalItemFornecedorCliente;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (Fornecedor!=null)
                Fornecedor.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (EmissorCertificado!=null)
                EmissorCertificado.ChangeSingleConnection(newConnection);
             if (Material!=null)
                Material.ChangeSingleConnection(newConnection);
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
             if (AcsUsuarioEncerramento!=null)
                AcsUsuarioEncerramento.ChangeSingleConnection(newConnection);
             if (Epi!=null)
                Epi.ChangeSingleConnection(newConnection);
               if (_valueCollectionHistoricoCompraEpiClassLoteLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassLote)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassLoteLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassLote)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassLoteLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassLote)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionLoteSolicitacaoCompraClassLoteLoaded) 
               {
                  foreach(LoteSolicitacaoCompraClass item in CollectionLoteSolicitacaoCompraClassLote)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLoteLoaded) 
               {
                  foreach(OrdemProducaoPostoTrabalhoProducaoLoteClass item in CollectionOrdemProducaoPostoTrabalhoProducaoLoteClassLote)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassLoteLoaded) 
               {
                  foreach(PedidoItemLoteClienteClass item in CollectionPedidoItemLoteClienteClassLote)
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
                  command.CommandText += " COUNT(lote.id_lote) " ;
               }
               else
               {
               command.CommandText += "lote.id_lote, " ;
               command.CommandText += "lote.id_acs_usuario, " ;
               command.CommandText += "lote.id_fornecedor, " ;
               command.CommandText += "lote.lot_numero, " ;
               command.CommandText += "lote.lot_qtd, " ;
               command.CommandText += "lote.lot_data_recebimento, " ;
               command.CommandText += "lote.lot_data_fabricacao, " ;
               command.CommandText += "lote.lot_data_embalagem, " ;
               command.CommandText += "lote.lot_data_validade, " ;
               command.CommandText += "lote.id_cliente, " ;
               command.CommandText += "lote.id_emissor_certificado, " ;
               command.CommandText += "lote.id_material, " ;
               command.CommandText += "lote.id_produto, " ;
               command.CommandText += "lote.lot_certificado, " ;
               command.CommandText += "lote.lot_obs, " ;
               command.CommandText += "lote.lot_saldo_devolucao, " ;
               command.CommandText += "lote.lot_situacao, " ;
               command.CommandText += "lote.id_acs_usuario_cancelamento, " ;
               command.CommandText += "lote.id_acs_usuario_encerramento, " ;
               command.CommandText += "lote.lot_saldo_vinculo_pedido, " ;
               command.CommandText += "lote.lot_nf_serie, " ;
               command.CommandText += "lote.lot_nf_numero, " ;
               command.CommandText += "lote.lot_nf_data, " ;
               command.CommandText += "lote.lot_qtd_compra, " ;
               command.CommandText += "lote.lot_valor_unitario, " ;
               command.CommandText += "lote.lot_codigo_item_fornecedor_cliente, " ;
               command.CommandText += "lote.lot_descricao_item_fornecedor_cliente, " ;
               command.CommandText += "lote.lot_ncm_item_fornecedor_cliente, " ;
               command.CommandText += "lote.lot_unidade_item_fornecedor_cliente, " ;
               command.CommandText += "lote.entity_uid, " ;
               command.CommandText += "lote.version, " ;
               command.CommandText += "lote.id_epi, " ;
               command.CommandText += "lote.lot_cod_benef_fiscal_item_fornecedor_cliente " ;
               }
               command.CommandText += " FROM  lote ";
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
                        orderByClause += " , lot_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lot_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = lote.id_acs_usuario_ultima_revisao ";
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
                     case "id_lote":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.id_lote " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.id_lote) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , lote.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = lote.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , fornecedor_Fornecedor.for_nome_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(fornecedor_Fornecedor.for_nome_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_qtd":
                     case "Qtd":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_qtd " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_qtd) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_data_recebimento":
                     case "DataRecebimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_data_recebimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_data_recebimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_data_fabricacao":
                     case "DataFabricacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_data_fabricacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_data_fabricacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_data_embalagem":
                     case "DataEmbalagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_data_embalagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_data_embalagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_data_validade":
                     case "DataValidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_data_validade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_data_validade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = lote.id_cliente ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_Cliente.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_Cliente.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_emissor_certificado":
                     case "EmissorCertificado":
                     command.CommandText += " LEFT JOIN emissor_certificado as emissor_certificado_EmissorCertificado ON emissor_certificado_EmissorCertificado.id_emissor_certificado = lote.id_emissor_certificado ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , emissor_certificado_EmissorCertificado.emc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(emissor_certificado_EmissorCertificado.emc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_material":
                     case "Material":
                     command.CommandText += " LEFT JOIN material as material_Material ON material_Material.id_material = lote.id_material ";                     switch (parametro.TipoOrdenacao)
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
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = lote.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "lot_certificado":
                     case "Certificado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_certificado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_certificado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_obs":
                     case "Obs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_saldo_devolucao":
                     case "SaldoDevolucao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_saldo_devolucao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_saldo_devolucao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_situacao":
                     case "Situacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_situacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_situacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , lote.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_acs_usuario_encerramento":
                     case "AcsUsuarioEncerramento":
                     orderByClause += " , lote.id_acs_usuario_encerramento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "lot_saldo_vinculo_pedido":
                     case "SaldoVinculoPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_saldo_vinculo_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_saldo_vinculo_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_nf_serie":
                     case "NfSerie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_nf_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_nf_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_nf_numero":
                     case "NfNumero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_nf_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_nf_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_nf_data":
                     case "NfData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_nf_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_nf_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_qtd_compra":
                     case "QtdCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_qtd_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_qtd_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_valor_unitario":
                     case "ValorUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote.lot_valor_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.lot_valor_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_codigo_item_fornecedor_cliente":
                     case "CodigoItemFornecedorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_codigo_item_fornecedor_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_codigo_item_fornecedor_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_descricao_item_fornecedor_cliente":
                     case "DescricaoItemFornecedorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_descricao_item_fornecedor_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_descricao_item_fornecedor_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_ncm_item_fornecedor_cliente":
                     case "NcmItemFornecedorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_ncm_item_fornecedor_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_ncm_item_fornecedor_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lot_unidade_item_fornecedor_cliente":
                     case "UnidadeItemFornecedorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_unidade_item_fornecedor_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_unidade_item_fornecedor_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , lote.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_epi":
                     case "Epi":
                     command.CommandText += " LEFT JOIN epi as epi_Epi ON epi_Epi.id_epi = lote.id_epi ";                     switch (parametro.TipoOrdenacao)
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
                     case "lot_cod_benef_fiscal_item_fornecedor_cliente":
                     case "CodBenefFiscalItemFornecedorCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote.lot_cod_benef_fiscal_item_fornecedor_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote.lot_cod_benef_fiscal_item_fornecedor_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_numero")) 
                        {
                           whereClause += " OR UPPER(lote.lot_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_certificado")) 
                        {
                           whereClause += " OR UPPER(lote.lot_certificado) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_certificado) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_obs")) 
                        {
                           whereClause += " OR UPPER(lote.lot_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_nf_serie")) 
                        {
                           whereClause += " OR UPPER(lote.lot_nf_serie) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_nf_serie) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_nf_numero")) 
                        {
                           whereClause += " OR UPPER(lote.lot_nf_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_nf_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_codigo_item_fornecedor_cliente")) 
                        {
                           whereClause += " OR UPPER(lote.lot_codigo_item_fornecedor_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_codigo_item_fornecedor_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_descricao_item_fornecedor_cliente")) 
                        {
                           whereClause += " OR UPPER(lote.lot_descricao_item_fornecedor_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_descricao_item_fornecedor_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_ncm_item_fornecedor_cliente")) 
                        {
                           whereClause += " OR UPPER(lote.lot_ncm_item_fornecedor_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_ncm_item_fornecedor_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_unidade_item_fornecedor_cliente")) 
                        {
                           whereClause += " OR UPPER(lote.lot_unidade_item_fornecedor_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_unidade_item_fornecedor_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(lote.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lot_cod_benef_fiscal_item_fornecedor_cliente")) 
                        {
                           whereClause += " OR UPPER(lote.lot_cod_benef_fiscal_item_fornecedor_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote.lot_cod_benef_fiscal_item_fornecedor_cliente) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.id_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_lote = :lote_ID_1330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_ID_1330", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  lote.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_acs_usuario = :lote_AcsUsuario_6757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_AcsUsuario_6757", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fornecedor" || parametro.FieldName == "id_fornecedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FornecedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FornecedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_fornecedor = :lote_Fornecedor_8654 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Fornecedor_8654", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "lot_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_numero LIKE :lote_Numero_6839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Numero_6839", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Qtd" || parametro.FieldName == "lot_qtd")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_qtd IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_qtd = :lote_Qtd_7383 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Qtd_7383", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataRecebimento" || parametro.FieldName == "lot_data_recebimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_data_recebimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_data_recebimento = :lote_DataRecebimento_1365 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DataRecebimento_1365", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataFabricacao" || parametro.FieldName == "lot_data_fabricacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_data_fabricacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_data_fabricacao = :lote_DataFabricacao_9355 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DataFabricacao_9355", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEmbalagem" || parametro.FieldName == "lot_data_embalagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_data_embalagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_data_embalagem = :lote_DataEmbalagem_3380 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DataEmbalagem_3380", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataValidade" || parametro.FieldName == "lot_data_validade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_data_validade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_data_validade = :lote_DataValidade_6130 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DataValidade_6130", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cliente" || parametro.FieldName == "id_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_cliente = :lote_Cliente_7832 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Cliente_7832", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmissorCertificado" || parametro.FieldName == "id_emissor_certificado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EmissorCertificadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EmissorCertificadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.id_emissor_certificado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_emissor_certificado = :lote_EmissorCertificado_9961 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_EmissorCertificado_9961", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  lote.id_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_material = :lote_Material_983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Material_983", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  lote.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_produto = :lote_Produto_7051 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Produto_7051", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Certificado" || parametro.FieldName == "lot_certificado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_certificado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_certificado LIKE :lote_Certificado_4223 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Certificado_4223", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Obs" || parametro.FieldName == "lot_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_obs LIKE :lote_Obs_6412 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Obs_6412", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SaldoDevolucao" || parametro.FieldName == "lot_saldo_devolucao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_saldo_devolucao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_saldo_devolucao = :lote_SaldoDevolucao_4241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_SaldoDevolucao_4241", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Situacao" || parametro.FieldName == "lot_situacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusLote)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusLote");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_situacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_situacao = :lote_Situacao_3342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Situacao_3342", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  lote.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_acs_usuario_cancelamento = :lote_AcsUsuarioCancelamento_7971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_AcsUsuarioCancelamento_7971", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioEncerramento" || parametro.FieldName == "id_acs_usuario_encerramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.id_acs_usuario_encerramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_acs_usuario_encerramento = :lote_AcsUsuarioEncerramento_6171 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_AcsUsuarioEncerramento_6171", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SaldoVinculoPedido" || parametro.FieldName == "lot_saldo_vinculo_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_saldo_vinculo_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_saldo_vinculo_pedido = :lote_SaldoVinculoPedido_1926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_SaldoVinculoPedido_1926", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfSerie" || parametro.FieldName == "lot_nf_serie")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_nf_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_nf_serie LIKE :lote_NfSerie_5089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NfSerie_5089", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfNumero" || parametro.FieldName == "lot_nf_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_nf_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_nf_numero LIKE :lote_NfNumero_2116 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NfNumero_2116", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfData" || parametro.FieldName == "lot_nf_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_nf_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_nf_data = :lote_NfData_6413 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NfData_6413", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdCompra" || parametro.FieldName == "lot_qtd_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_qtd_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_qtd_compra = :lote_QtdCompra_4625 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_QtdCompra_4625", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorUnitario" || parametro.FieldName == "lot_valor_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_valor_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_valor_unitario = :lote_ValorUnitario_1537 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_ValorUnitario_1537", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemFornecedorCliente" || parametro.FieldName == "lot_codigo_item_fornecedor_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_codigo_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_codigo_item_fornecedor_cliente LIKE :lote_CodigoItemFornecedorCliente_628 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_CodigoItemFornecedorCliente_628", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoItemFornecedorCliente" || parametro.FieldName == "lot_descricao_item_fornecedor_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_descricao_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_descricao_item_fornecedor_cliente LIKE :lote_DescricaoItemFornecedorCliente_5811 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DescricaoItemFornecedorCliente_5811", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NcmItemFornecedorCliente" || parametro.FieldName == "lot_ncm_item_fornecedor_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_ncm_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_ncm_item_fornecedor_cliente LIKE :lote_NcmItemFornecedorCliente_4692 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NcmItemFornecedorCliente_4692", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeItemFornecedorCliente" || parametro.FieldName == "lot_unidade_item_fornecedor_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_unidade_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_unidade_item_fornecedor_cliente LIKE :lote_UnidadeItemFornecedorCliente_9827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_UnidadeItemFornecedorCliente_9827", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.entity_uid LIKE :lote_EntityUid_9335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_EntityUid_9335", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  lote.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.version = :lote_Version_8898 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Version_8898", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  lote.id_epi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.id_epi = :lote_Epi_9087 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Epi_9087", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodBenefFiscalItemFornecedorCliente" || parametro.FieldName == "lot_cod_benef_fiscal_item_fornecedor_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_cod_benef_fiscal_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_cod_benef_fiscal_item_fornecedor_cliente LIKE :lote_CodBenefFiscalItemFornecedorCliente_6515 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_CodBenefFiscalItemFornecedorCliente_6515", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroExato" || parametro.FieldName == "NumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_numero LIKE :lote_Numero_3021 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Numero_3021", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CertificadoExato" || parametro.FieldName == "CertificadoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_certificado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_certificado LIKE :lote_Certificado_1803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Certificado_1803", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsExato" || parametro.FieldName == "ObsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_obs LIKE :lote_Obs_3745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_Obs_3745", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfSerieExato" || parametro.FieldName == "NfSerieExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_nf_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_nf_serie LIKE :lote_NfSerie_9566 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NfSerie_9566", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfNumeroExato" || parametro.FieldName == "NfNumeroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_nf_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_nf_numero LIKE :lote_NfNumero_4299 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NfNumero_4299", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemFornecedorClienteExato" || parametro.FieldName == "CodigoItemFornecedorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_codigo_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_codigo_item_fornecedor_cliente LIKE :lote_CodigoItemFornecedorCliente_6330 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_CodigoItemFornecedorCliente_6330", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoItemFornecedorClienteExato" || parametro.FieldName == "DescricaoItemFornecedorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_descricao_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_descricao_item_fornecedor_cliente LIKE :lote_DescricaoItemFornecedorCliente_2459 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_DescricaoItemFornecedorCliente_2459", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NcmItemFornecedorClienteExato" || parametro.FieldName == "NcmItemFornecedorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_ncm_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_ncm_item_fornecedor_cliente LIKE :lote_NcmItemFornecedorCliente_696 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_NcmItemFornecedorCliente_696", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeItemFornecedorClienteExato" || parametro.FieldName == "UnidadeItemFornecedorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_unidade_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_unidade_item_fornecedor_cliente LIKE :lote_UnidadeItemFornecedorCliente_7100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_UnidadeItemFornecedorCliente_7100", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  lote.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.entity_uid LIKE :lote_EntityUid_3931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_EntityUid_3931", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodBenefFiscalItemFornecedorClienteExato" || parametro.FieldName == "CodBenefFiscalItemFornecedorClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote.lot_cod_benef_fiscal_item_fornecedor_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote.lot_cod_benef_fiscal_item_fornecedor_cliente LIKE :lote_CodBenefFiscalItemFornecedorCliente_422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_CodBenefFiscalItemFornecedorCliente_422", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LoteClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LoteClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LoteClass), Convert.ToInt32(read["id_lote"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LoteClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_lote"]);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     entidade.Numero = (read["lot_numero"] != DBNull.Value ? read["lot_numero"].ToString() : null);
                     entidade.Qtd = (double)read["lot_qtd"];
                     entidade.DataRecebimento = (DateTime)read["lot_data_recebimento"];
                     entidade.DataFabricacao = read["lot_data_fabricacao"] as DateTime?;
                     entidade.DataEmbalagem = read["lot_data_embalagem"] as DateTime?;
                     entidade.DataValidade = read["lot_data_validade"] as DateTime?;
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_emissor_certificado"] != DBNull.Value)
                     {
                        entidade.EmissorCertificado = (BibliotecaEntidades.Entidades.EmissorCertificadoClass)BibliotecaEntidades.Entidades.EmissorCertificadoClass.GetEntidade(Convert.ToInt32(read["id_emissor_certificado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EmissorCertificado = null ;
                     }
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
                     entidade.Certificado = (read["lot_certificado"] != DBNull.Value ? read["lot_certificado"].ToString() : null);
                     entidade.Obs = (read["lot_obs"] != DBNull.Value ? read["lot_obs"].ToString() : null);
                     entidade.SaldoDevolucao = (double)read["lot_saldo_devolucao"];
                     entidade.Situacao = (StatusLote) (read["lot_situacao"] != DBNull.Value ? Enum.ToObject(typeof(StatusLote), read["lot_situacao"]) : null);
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     if (read["id_acs_usuario_encerramento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioEncerramento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_encerramento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioEncerramento = null ;
                     }
                     entidade.SaldoVinculoPedido = (double)read["lot_saldo_vinculo_pedido"];
                     entidade.NfSerie = (read["lot_nf_serie"] != DBNull.Value ? read["lot_nf_serie"].ToString() : null);
                     entidade.NfNumero = (read["lot_nf_numero"] != DBNull.Value ? read["lot_nf_numero"].ToString() : null);
                     entidade.NfData = (DateTime)read["lot_nf_data"];
                     entidade.QtdCompra = (double)read["lot_qtd_compra"];
                     entidade.ValorUnitario = (double)read["lot_valor_unitario"];
                     entidade.CodigoItemFornecedorCliente = (read["lot_codigo_item_fornecedor_cliente"] != DBNull.Value ? read["lot_codigo_item_fornecedor_cliente"].ToString() : null);
                     entidade.DescricaoItemFornecedorCliente = (read["lot_descricao_item_fornecedor_cliente"] != DBNull.Value ? read["lot_descricao_item_fornecedor_cliente"].ToString() : null);
                     entidade.NcmItemFornecedorCliente = (read["lot_ncm_item_fornecedor_cliente"] != DBNull.Value ? read["lot_ncm_item_fornecedor_cliente"].ToString() : null);
                     entidade.UnidadeItemFornecedorCliente = (read["lot_unidade_item_fornecedor_cliente"] != DBNull.Value ? read["lot_unidade_item_fornecedor_cliente"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_epi"] != DBNull.Value)
                     {
                        entidade.Epi = (BibliotecaEntidades.Entidades.EpiClass)BibliotecaEntidades.Entidades.EpiClass.GetEntidade(Convert.ToInt32(read["id_epi"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Epi = null ;
                     }
                     entidade.CodBenefFiscalItemFornecedorCliente = (read["lot_cod_benef_fiscal_item_fornecedor_cliente"] != DBNull.Value ? read["lot_cod_benef_fiscal_item_fornecedor_cliente"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LoteClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
