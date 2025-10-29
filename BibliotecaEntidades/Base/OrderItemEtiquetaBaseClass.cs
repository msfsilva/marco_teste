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
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("order_item_etiqueta","oie")]
     public class OrderItemEtiquetaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaClass";
protected const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaClass  ";
protected const string ErroSave = "Erro ao salvar o OrderItemEtiquetaClass.";
protected const string ErroCollectionAtendimentoClassOrderItemEtiqueta = "Erro ao carregar a coleção de AtendimentoClass.";
protected const string ErroCollectionOrdemProducaoPedidoClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrdemProducaoPedidoClass.";
protected const string ErroCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaClass.";
protected const string ErroCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaNfClass.";
protected const string ErroCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta = "Erro ao carregar a coleção de PedidoItemConfiguradoMaterialClass.";
protected const string ErroCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta = "Erro ao carregar a coleção de PlanoCorteItemPedidoClass.";
protected const string ErroStatusPedidoObrigatorio = "O campo StatusPedido é obrigatório";
protected const string ErroStatusPedidoComprimento = "O campo StatusPedido deve ter no máximo 2 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloEtiquetaExpedicaoObrigatorio = "O campo ModeloEtiquetaExpedicao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaClass.";
protected const string MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes AtendimentoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrdemProducaoPedidoClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaNfClass:";
protected const string MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes PedidoItemConfiguradoMaterialClass:";
protected const string MensagemUtilizadoCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta =  "A entidade OrderItemEtiquetaClass está sendo utilizada nos seguintes PlanoCorteItemPedidoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaClass está sendo utilizada.";
#endregion
       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("oie_order_number")]
        public virtual string OrderNumber
         { 
            get { return this._valueOrderNumber; } 
            set 
            { 
                if (this._valueOrderNumber == value)return;
                 this._valueOrderNumber = value; 
            } 
        } 

       protected int? _orderPosOriginal{get;private set;}
       private int? _orderPosOriginalCommited{get; set;}
        private int? _valueOrderPos;
         [Column("oie_order_pos")]
        public virtual int? OrderPos
         { 
            get { return this._valueOrderPos; } 
            set 
            { 
                if (this._valueOrderPos == value)return;
                 this._valueOrderPos = value; 
            } 
        } 

       protected string _codigoItemOriginal{get;private set;}
       private string _codigoItemOriginalCommited{get; set;}
        private string _valueCodigoItem;
         [Column("oie_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("oie_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected TipoControleEtiquetaProduto? _tipoItemOriginal{get;private set;}
       private TipoControleEtiquetaProduto? _tipoItemOriginalCommited{get; set;}
        private TipoControleEtiquetaProduto? _valueTipoItem;
         [Column("oie_tipo_item")]
        public virtual TipoControleEtiquetaProduto? TipoItem
         { 
            get { return this._valueTipoItem; } 
            set 
            { 
                if (this._valueTipoItem == value)return;
                 this._valueTipoItem = value; 
            } 
        } 

        public bool TipoItem_Kanban
         { 
            get { return this._valueTipoItem.HasValue && this._valueTipoItem.Value == BibliotecaEntidades.Base.TipoControleEtiquetaProduto.Kanban; } 
            set { if (value) this._valueTipoItem = BibliotecaEntidades.Base.TipoControleEtiquetaProduto.Kanban; }
         } 

        public bool TipoItem_Customizado
         { 
            get { return this._valueTipoItem.HasValue && this._valueTipoItem.Value == BibliotecaEntidades.Base.TipoControleEtiquetaProduto.Customizado; } 
            set { if (value) this._valueTipoItem = BibliotecaEntidades.Base.TipoControleEtiquetaProduto.Customizado; }
         } 

       protected string _dimensaoOriginal{get;private set;}
       private string _dimensaoOriginalCommited{get; set;}
        private string _valueDimensao;
         [Column("oie_dimensao")]
        public virtual string Dimensao
         { 
            get { return this._valueDimensao; } 
            set 
            { 
                if (this._valueDimensao == value)return;
                 this._valueDimensao = value; 
            } 
        } 

       protected int? _ppsOriginal{get;private set;}
       private int? _ppsOriginalCommited{get; set;}
        private int? _valuePps;
         [Column("oie_pps")]
        public virtual int? Pps
         { 
            get { return this._valuePps; } 
            set 
            { 
                if (this._valuePps == value)return;
                 this._valuePps = value; 
            } 
        } 

       protected int? _qtdEtiquetasOriginal{get;private set;}
       private int? _qtdEtiquetasOriginalCommited{get; set;}
        private int? _valueQtdEtiquetas;
         [Column("oie_qtd_etiquetas")]
        public virtual int? QtdEtiquetas
         { 
            get { return this._valueQtdEtiquetas; } 
            set 
            { 
                if (this._valueQtdEtiquetas == value)return;
                 this._valueQtdEtiquetas = value; 
            } 
        } 

       protected bool? _etiquetaAgrupadaOriginal{get;private set;}
       private bool? _etiquetaAgrupadaOriginalCommited{get; set;}
        private bool? _valueEtiquetaAgrupada;
         [Column("oie_etiqueta_agrupada")]
        public virtual bool? EtiquetaAgrupada
         { 
            get { return this._valueEtiquetaAgrupada; } 
            set 
            { 
                if (this._valueEtiquetaAgrupada == value)return;
                 this._valueEtiquetaAgrupada = value; 
            } 
        } 

       protected double? _cubagemOriginal{get;private set;}
       private double? _cubagemOriginalCommited{get; set;}
        private double? _valueCubagem;
         [Column("oie_cubagem")]
        public virtual double? Cubagem
         { 
            get { return this._valueCubagem; } 
            set 
            { 
                if (this._valueCubagem == value)return;
                 this._valueCubagem = value; 
            } 
        } 

       protected double? _pesoOriginal{get;private set;}
       private double? _pesoOriginalCommited{get; set;}
        private double? _valuePeso;
         [Column("oie_peso")]
        public virtual double? Peso
         { 
            get { return this._valuePeso; } 
            set 
            { 
                if (this._valuePeso == value)return;
                 this._valuePeso = value; 
            } 
        } 

       protected int? _volumesOriginal{get;private set;}
       private int? _volumesOriginalCommited{get; set;}
        private int? _valueVolumes;
         [Column("oie_volumes")]
        public virtual int? Volumes
         { 
            get { return this._valueVolumes; } 
            set 
            { 
                if (this._valueVolumes == value)return;
                 this._valueVolumes = value; 
            } 
        } 

       protected double _saldoOriginal{get;private set;}
       private double _saldoOriginalCommited{get; set;}
        private double _valueSaldo;
         [Column("oie_saldo")]
        public virtual double Saldo
         { 
            get { return this._valueSaldo; } 
            set 
            { 
                if (this._valueSaldo == value)return;
                 this._valueSaldo = value; 
            } 
        } 

       protected SituacaoConferencia _situacaoConferenciaOriginal{get;private set;}
       private SituacaoConferencia _situacaoConferenciaOriginalCommited{get; set;}
        private SituacaoConferencia _valueSituacaoConferencia;
         [Column("oie_situacao_conferencia")]
        public virtual SituacaoConferencia SituacaoConferencia
         { 
            get { return this._valueSituacaoConferencia; } 
            set 
            { 
                if (this._valueSituacaoConferencia == value)return;
                 this._valueSituacaoConferencia = value; 
            } 
        } 

        public bool SituacaoConferencia_NaoIniciada
         { 
            get { return this._valueSituacaoConferencia == BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; }
         } 

        public bool SituacaoConferencia_Parcial
         { 
            get { return this._valueSituacaoConferencia == BibliotecaEntidades.Base.SituacaoConferencia.Parcial; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.Parcial; }
         } 

        public bool SituacaoConferencia_Total
         { 
            get { return this._valueSituacaoConferencia == BibliotecaEntidades.Base.SituacaoConferencia.Total; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.Total; }
         } 

       protected short? _nivelItemOriginal{get;private set;}
       private short? _nivelItemOriginalCommited{get; set;}
        private short? _valueNivelItem;
         [Column("oie_nivel_item")]
        public virtual short? NivelItem
         { 
            get { return this._valueNivelItem; } 
            set 
            { 
                if (this._valueNivelItem == value)return;
                 this._valueNivelItem = value; 
            } 
        } 

       protected string _ovmOriginal{get;private set;}
       private string _ovmOriginalCommited{get; set;}
        private string _valueOvm;
         [Column("oie_ovm")]
        public virtual string Ovm
         { 
            get { return this._valueOvm; } 
            set 
            { 
                if (this._valueOvm == value)return;
                 this._valueOvm = value; 
            } 
        } 

       protected string _depsOriginal{get;private set;}
       private string _depsOriginalCommited{get; set;}
        private string _valueDeps;
         [Column("oie_deps")]
        public virtual string Deps
         { 
            get { return this._valueDeps; } 
            set 
            { 
                if (this._valueDeps == value)return;
                 this._valueDeps = value; 
            } 
        } 

       protected string _pepsOriginal{get;private set;}
       private string _pepsOriginalCommited{get; set;}
        private string _valuePeps;
         [Column("oie_peps")]
        public virtual string Peps
         { 
            get { return this._valuePeps; } 
            set 
            { 
                if (this._valuePeps == value)return;
                 this._valuePeps = value; 
            } 
        } 

       protected bool _etiquetaExpedicaoImpressaOriginal{get;private set;}
       private bool _etiquetaExpedicaoImpressaOriginalCommited{get; set;}
        private bool _valueEtiquetaExpedicaoImpressa;
         [Column("oie_etiqueta_expedicao_impressa")]
        public virtual bool EtiquetaExpedicaoImpressa
         { 
            get { return this._valueEtiquetaExpedicaoImpressa; } 
            set 
            { 
                if (this._valueEtiquetaExpedicaoImpressa == value)return;
                 this._valueEtiquetaExpedicaoImpressa = value; 
            } 
        } 

       protected bool _usarTimerOriginal{get;private set;}
       private bool _usarTimerOriginalCommited{get; set;}
        private bool _valueUsarTimer;
         [Column("oie_usar_timer")]
        public virtual bool UsarTimer
         { 
            get { return this._valueUsarTimer; } 
            set 
            { 
                if (this._valueUsarTimer == value)return;
                 this._valueUsarTimer = value; 
            } 
        } 

       protected bool _permitirParcialOriginal{get;private set;}
       private bool _permitirParcialOriginalCommited{get; set;}
        private bool _valuePermitirParcial;
         [Column("oie_permitir_parcial")]
        public virtual bool PermitirParcial
         { 
            get { return this._valuePermitirParcial; } 
            set 
            { 
                if (this._valuePermitirParcial == value)return;
                 this._valuePermitirParcial = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("oie_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected short? _palletOriginal{get;private set;}
       private short? _palletOriginalCommited{get; set;}
        private short? _valuePallet;
         [Column("oie_pallet")]
        public virtual short? Pallet
         { 
            get { return this._valuePallet; } 
            set 
            { 
                if (this._valuePallet == value)return;
                 this._valuePallet = value; 
            } 
        } 

       protected bool _notaFiscalEmitidaOriginal{get;private set;}
       private bool _notaFiscalEmitidaOriginalCommited{get; set;}
        private bool _valueNotaFiscalEmitida;
         [Column("oie_nota_fiscal_emitida")]
        public virtual bool NotaFiscalEmitida
         { 
            get { return this._valueNotaFiscalEmitida; } 
            set 
            { 
                if (this._valueNotaFiscalEmitida == value)return;
                 this._valueNotaFiscalEmitida = value; 
            } 
        } 

       protected SituacaoConferencia _situacaoConferenciaNfOriginal{get;private set;}
       private SituacaoConferencia _situacaoConferenciaNfOriginalCommited{get; set;}
        private SituacaoConferencia _valueSituacaoConferenciaNf;
         [Column("oie_situacao_conferencia_nf")]
        public virtual SituacaoConferencia SituacaoConferenciaNf
         { 
            get { return this._valueSituacaoConferenciaNf; } 
            set 
            { 
                if (this._valueSituacaoConferenciaNf == value)return;
                 this._valueSituacaoConferenciaNf = value; 
            } 
        } 

        public bool SituacaoConferenciaNf_NaoIniciada
         { 
            get { return this._valueSituacaoConferenciaNf == BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; } 
            set { if (value) this._valueSituacaoConferenciaNf = BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; }
         } 

        public bool SituacaoConferenciaNf_Parcial
         { 
            get { return this._valueSituacaoConferenciaNf == BibliotecaEntidades.Base.SituacaoConferencia.Parcial; } 
            set { if (value) this._valueSituacaoConferenciaNf = BibliotecaEntidades.Base.SituacaoConferencia.Parcial; }
         } 

        public bool SituacaoConferenciaNf_Total
         { 
            get { return this._valueSituacaoConferenciaNf == BibliotecaEntidades.Base.SituacaoConferencia.Total; } 
            set { if (value) this._valueSituacaoConferenciaNf = BibliotecaEntidades.Base.SituacaoConferencia.Total; }
         } 

       protected double? _precoTotalOriginal{get;private set;}
       private double? _precoTotalOriginalCommited{get; set;}
        private double? _valuePrecoTotal;
         [Column("oie_preco_total")]
        public virtual double? PrecoTotal
         { 
            get { return this._valuePrecoTotal; } 
            set 
            { 
                if (this._valuePrecoTotal == value)return;
                 this._valuePrecoTotal = value; 
            } 
        } 

       protected double? _precoUnitarioOriginal{get;private set;}
       private double? _precoUnitarioOriginalCommited{get; set;}
        private double? _valuePrecoUnitario;
         [Column("oie_preco_unitario")]
        public virtual double? PrecoUnitario
         { 
            get { return this._valuePrecoUnitario; } 
            set 
            { 
                if (this._valuePrecoUnitario == value)return;
                 this._valuePrecoUnitario = value; 
            } 
        } 

       protected bool _emissaoParcialOriginal{get;private set;}
       private bool _emissaoParcialOriginalCommited{get; set;}
        private bool _valueEmissaoParcial;
         [Column("oie_emissao_parcial")]
        public virtual bool EmissaoParcial
         { 
            get { return this._valueEmissaoParcial; } 
            set 
            { 
                if (this._valueEmissaoParcial == value)return;
                 this._valueEmissaoParcial = value; 
            } 
        } 

       protected string _statusPedidoOriginal{get;private set;}
       private string _statusPedidoOriginalCommited{get; set;}
        private string _valueStatusPedido;
         [Column("oie_status_pedido")]
        public virtual string StatusPedido
         { 
            get { return this._valueStatusPedido; } 
            set 
            { 
                if (this._valueStatusPedido == value)return;
                 this._valueStatusPedido = value; 
            } 
        } 

       protected string _armazenagemClienteOriginal{get;private set;}
       private string _armazenagemClienteOriginalCommited{get; set;}
        private string _valueArmazenagemCliente;
         [Column("oie_armazenagem_cliente")]
        public virtual string ArmazenagemCliente
         { 
            get { return this._valueArmazenagemCliente; } 
            set 
            { 
                if (this._valueArmazenagemCliente == value)return;
                 this._valueArmazenagemCliente = value; 
            } 
        } 

       protected string _descricaoClienteOriginal{get;private set;}
       private string _descricaoClienteOriginalCommited{get; set;}
        private string _valueDescricaoCliente;
         [Column("oie_descricao_cliente")]
        public virtual string DescricaoCliente
         { 
            get { return this._valueDescricaoCliente; } 
            set 
            { 
                if (this._valueDescricaoCliente == value)return;
                 this._valueDescricaoCliente = value; 
            } 
        } 

       protected string _codigoClienteOriginal{get;private set;}
       private string _codigoClienteOriginalCommited{get; set;}
        private string _valueCodigoCliente;
         [Column("oie_codigo_cliente")]
        public virtual string CodigoCliente
         { 
            get { return this._valueCodigoCliente; } 
            set 
            { 
                if (this._valueCodigoCliente == value)return;
                 this._valueCodigoCliente = value; 
            } 
        } 

       protected string _idExternoClienteAccessOriginal{get;private set;}
       private string _idExternoClienteAccessOriginalCommited{get; set;}
        private string _valueIdExternoClienteAccess;
         [Column("id_externo_cliente_access")]
        public virtual string IdExternoClienteAccess
         { 
            get { return this._valueIdExternoClienteAccess; } 
            set 
            { 
                if (this._valueIdExternoClienteAccess == value)return;
                 this._valueIdExternoClienteAccess = value; 
            } 
        } 

       protected string _cnpjPedidoOriginal{get;private set;}
       private string _cnpjPedidoOriginalCommited{get; set;}
        private string _valueCnpjPedido;
         [Column("oie_cnpj_pedido")]
        public virtual string CnpjPedido
         { 
            get { return this._valueCnpjPedido; } 
            set 
            { 
                if (this._valueCnpjPedido == value)return;
                 this._valueCnpjPedido = value; 
            } 
        } 

       protected int? _cfopOriginal{get;private set;}
       private int? _cfopOriginalCommited{get; set;}
        private int? _valueCfop;
         [Column("oie_cfop")]
        public virtual int? Cfop
         { 
            get { return this._valueCfop; } 
            set 
            { 
                if (this._valueCfop == value)return;
                 this._valueCfop = value; 
            } 
        } 

       protected string _naturezaOperacaoOriginal{get;private set;}
       private string _naturezaOperacaoOriginalCommited{get; set;}
        private string _valueNaturezaOperacao;
         [Column("oie_natureza_operacao")]
        public virtual string NaturezaOperacao
         { 
            get { return this._valueNaturezaOperacao; } 
            set 
            { 
                if (this._valueNaturezaOperacao == value)return;
                 this._valueNaturezaOperacao = value; 
            } 
        } 

       protected string _tipoOperacaoOriginal{get;private set;}
       private string _tipoOperacaoOriginalCommited{get; set;}
        private string _valueTipoOperacao;
         [Column("oie_tipo_operacao")]
        public virtual string TipoOperacao
         { 
            get { return this._valueTipoOperacao; } 
            set 
            { 
                if (this._valueTipoOperacao == value)return;
                 this._valueTipoOperacao = value; 
            } 
        } 

       protected string _nbmPedidoOriginal{get;private set;}
       private string _nbmPedidoOriginalCommited{get; set;}
        private string _valueNbmPedido;
         [Column("oie_nbm_pedido")]
        public virtual string NbmPedido
         { 
            get { return this._valueNbmPedido; } 
            set 
            { 
                if (this._valueNbmPedido == value)return;
                 this._valueNbmPedido = value; 
            } 
        } 

       protected double _freteOriginal{get;private set;}
       private double _freteOriginalCommited{get; set;}
        private double _valueFrete;
         [Column("oie_frete")]
        public virtual double Frete
         { 
            get { return this._valueFrete; } 
            set 
            { 
                if (this._valueFrete == value)return;
                 this._valueFrete = value; 
            } 
        } 

       protected bool? _notaFiscalOriginal{get;private set;}
       private bool? _notaFiscalOriginalCommited{get; set;}
        private bool? _valueNotaFiscal;
         [Column("oie_nota_fiscal")]
        public virtual bool? NotaFiscal
         { 
            get { return this._valueNotaFiscal; } 
            set 
            { 
                if (this._valueNotaFiscal == value)return;
                 this._valueNotaFiscal = value; 
            } 
        } 

       protected bool _etiquetaInternaOriginal{get;private set;}
       private bool _etiquetaInternaOriginalCommited{get; set;}
        private bool _valueEtiquetaInterna;
         [Column("oie_etiqueta_interna")]
        public virtual bool EtiquetaInterna
         { 
            get { return this._valueEtiquetaInterna; } 
            set 
            { 
                if (this._valueEtiquetaInterna == value)return;
                 this._valueEtiquetaInterna = value; 
            } 
        } 

       protected double _saldoConferenciaOriginal{get;private set;}
       private double _saldoConferenciaOriginalCommited{get; set;}
        private double _valueSaldoConferencia;
         [Column("oie_saldo_conferencia")]
        public virtual double SaldoConferencia
         { 
            get { return this._valueSaldoConferencia; } 
            set 
            { 
                if (this._valueSaldoConferencia == value)return;
                 this._valueSaldoConferencia = value; 
            } 
        } 

       protected string _cncOriginal{get;private set;}
       private string _cncOriginalCommited{get; set;}
        private string _valueCnc;
         [Column("oie_cnc")]
        public virtual string Cnc
         { 
            get { return this._valueCnc; } 
            set 
            { 
                if (this._valueCnc == value)return;
                 this._valueCnc = value; 
            } 
        } 

       protected string _coordenadaXOriginal{get;private set;}
       private string _coordenadaXOriginalCommited{get; set;}
        private string _valueCoordenadaX;
         [Column("oie_coordenada_x")]
        public virtual string CoordenadaX
         { 
            get { return this._valueCoordenadaX; } 
            set 
            { 
                if (this._valueCoordenadaX == value)return;
                 this._valueCoordenadaX = value; 
            } 
        } 

       protected string _coordenadaYOriginal{get;private set;}
       private string _coordenadaYOriginalCommited{get; set;}
        private string _valueCoordenadaY;
         [Column("oie_coordenada_y")]
        public virtual string CoordenadaY
         { 
            get { return this._valueCoordenadaY; } 
            set 
            { 
                if (this._valueCoordenadaY == value)return;
                 this._valueCoordenadaY = value; 
            } 
        } 

       protected bool _etiquetaInternaImpressaOriginal{get;private set;}
       private bool _etiquetaInternaImpressaOriginalCommited{get; set;}
        private bool _valueEtiquetaInternaImpressa;
         [Column("oie_etiqueta_interna_impressa")]
        public virtual bool EtiquetaInternaImpressa
         { 
            get { return this._valueEtiquetaInternaImpressa; } 
            set 
            { 
                if (this._valueEtiquetaInternaImpressa == value)return;
                 this._valueEtiquetaInternaImpressa = value; 
            } 
        } 

       protected string _safOriginal{get;private set;}
       private string _safOriginalCommited{get; set;}
        private string _valueSaf;
         [Column("oie_saf")]
        public virtual string Saf
         { 
            get { return this._valueSaf; } 
            set 
            { 
                if (this._valueSaf == value)return;
                 this._valueSaf = value; 
            } 
        } 

       protected string _programadorOriginal{get;private set;}
       private string _programadorOriginalCommited{get; set;}
        private string _valueProgramador;
         [Column("oie_programador")]
        public virtual string Programador
         { 
            get { return this._valueProgramador; } 
            set 
            { 
                if (this._valueProgramador == value)return;
                 this._valueProgramador = value; 
            } 
        } 

       protected bool _conferenciaCustomizadaRealizadaOriginal{get;private set;}
       private bool _conferenciaCustomizadaRealizadaOriginalCommited{get; set;}
        private bool _valueConferenciaCustomizadaRealizada;
         [Column("oie_conferencia_customizada_realizada")]
        public virtual bool ConferenciaCustomizadaRealizada
         { 
            get { return this._valueConferenciaCustomizadaRealizada; } 
            set 
            { 
                if (this._valueConferenciaCustomizadaRealizada == value)return;
                 this._valueConferenciaCustomizadaRealizada = value; 
            } 
        } 

       protected bool _conferenciaCustomizadaRealizadaForcadaOriginal{get;private set;}
       private bool _conferenciaCustomizadaRealizadaForcadaOriginalCommited{get; set;}
        private bool _valueConferenciaCustomizadaRealizadaForcada;
         [Column("oie_conferencia_customizada_realizada_forcada")]
        public virtual bool ConferenciaCustomizadaRealizadaForcada
         { 
            get { return this._valueConferenciaCustomizadaRealizadaForcada; } 
            set 
            { 
                if (this._valueConferenciaCustomizadaRealizadaForcada == value)return;
                 this._valueConferenciaCustomizadaRealizadaForcada = value; 
            } 
        } 

       protected int _qtdEtiquetaExpVolumeOriginal{get;private set;}
       private int _qtdEtiquetaExpVolumeOriginalCommited{get; set;}
        private int _valueQtdEtiquetaExpVolume;
         [Column("oie_qtd_etiqueta_exp_volume")]
        public virtual int QtdEtiquetaExpVolume
         { 
            get { return this._valueQtdEtiquetaExpVolume; } 
            set 
            { 
                if (this._valueQtdEtiquetaExpVolume == value)return;
                 this._valueQtdEtiquetaExpVolume = value; 
            } 
        } 

       protected string _descricaoPtOriginal{get;private set;}
       private string _descricaoPtOriginalCommited{get; set;}
        private string _valueDescricaoPt;
         [Column("oie_descricao_pt")]
        public virtual string DescricaoPt
         { 
            get { return this._valueDescricaoPt; } 
            set 
            { 
                if (this._valueDescricaoPt == value)return;
                 this._valueDescricaoPt = value; 
            } 
        } 

       protected string _descricaoEnOriginal{get;private set;}
       private string _descricaoEnOriginalCommited{get; set;}
        private string _valueDescricaoEn;
         [Column("oie_descricao_en")]
        public virtual string DescricaoEn
         { 
            get { return this._valueDescricaoEn; } 
            set 
            { 
                if (this._valueDescricaoEn == value)return;
                 this._valueDescricaoEn = value; 
            } 
        } 

       protected string _descricaoEsOriginal{get;private set;}
       private string _descricaoEsOriginalCommited{get; set;}
        private string _valueDescricaoEs;
         [Column("oie_descricao_es")]
        public virtual string DescricaoEs
         { 
            get { return this._valueDescricaoEs; } 
            set 
            { 
                if (this._valueDescricaoEs == value)return;
                 this._valueDescricaoEs = value; 
            } 
        } 

       protected bool _imprimePackingListOriginal{get;private set;}
       private bool _imprimePackingListOriginalCommited{get; set;}
        private bool _valueImprimePackingList;
         [Column("oie_imprime_packing_list")]
        public virtual bool ImprimePackingList
         { 
            get { return this._valueImprimePackingList; } 
            set 
            { 
                if (this._valueImprimePackingList == value)return;
                 this._valueImprimePackingList = value; 
            } 
        } 

       protected string _tipoBaseboardOriginal{get;private set;}
       private string _tipoBaseboardOriginalCommited{get; set;}
        private string _valueTipoBaseboard;
         [Column("oie_tipo_baseboard")]
        public virtual string TipoBaseboard
         { 
            get { return this._valueTipoBaseboard; } 
            set 
            { 
                if (this._valueTipoBaseboard == value)return;
                 this._valueTipoBaseboard = value; 
            } 
        } 

       protected double? _alturaOriginal{get;private set;}
       private double? _alturaOriginalCommited{get; set;}
        private double? _valueAltura;
         [Column("oie_altura")]
        public virtual double? Altura
         { 
            get { return this._valueAltura; } 
            set 
            { 
                if (this._valueAltura == value)return;
                 this._valueAltura = value; 
            } 
        } 

       protected double? _larguraOriginal{get;private set;}
       private double? _larguraOriginalCommited{get; set;}
        private double? _valueLargura;
         [Column("oie_largura")]
        public virtual double? Largura
         { 
            get { return this._valueLargura; } 
            set 
            { 
                if (this._valueLargura == value)return;
                 this._valueLargura = value; 
            } 
        } 

       protected double? _comprimentoOriginal{get;private set;}
       private double? _comprimentoOriginalCommited{get; set;}
        private double? _valueComprimento;
         [Column("oie_comprimento")]
        public virtual double? Comprimento
         { 
            get { return this._valueComprimento; } 
            set 
            { 
                if (this._valueComprimento == value)return;
                 this._valueComprimento = value; 
            } 
        } 

       protected string _tipoLigacaoOriginal{get;private set;}
       private string _tipoLigacaoOriginalCommited{get; set;}
        private string _valueTipoLigacao;
         [Column("oie_tipo_ligacao")]
        public virtual string TipoLigacao
         { 
            get { return this._valueTipoLigacao; } 
            set 
            { 
                if (this._valueTipoLigacao == value)return;
                 this._valueTipoLigacao = value; 
            } 
        } 

       protected bool? _packinglistKitImpressoOriginal{get;private set;}
       private bool? _packinglistKitImpressoOriginalCommited{get; set;}
        private bool? _valuePackinglistKitImpresso;
         [Column("oie_packinglist_kit_impresso")]
        public virtual bool? PackinglistKitImpresso
         { 
            get { return this._valuePackinglistKitImpresso; } 
            set 
            { 
                if (this._valuePackinglistKitImpresso == value)return;
                 this._valuePackinglistKitImpresso = value; 
            } 
        } 

       protected string _var1NomeOriginal{get;private set;}
       private string _var1NomeOriginalCommited{get; set;}
        private string _valueVar1Nome;
         [Column("oie_var_1_nome")]
        public virtual string Var1Nome
         { 
            get { return this._valueVar1Nome; } 
            set 
            { 
                if (this._valueVar1Nome == value)return;
                 this._valueVar1Nome = value; 
            } 
        } 

       protected string _var1ValorOriginal{get;private set;}
       private string _var1ValorOriginalCommited{get; set;}
        private string _valueVar1Valor;
         [Column("oie_var_1_valor")]
        public virtual string Var1Valor
         { 
            get { return this._valueVar1Valor; } 
            set 
            { 
                if (this._valueVar1Valor == value)return;
                 this._valueVar1Valor = value; 
            } 
        } 

       protected string _var2NomeOriginal{get;private set;}
       private string _var2NomeOriginalCommited{get; set;}
        private string _valueVar2Nome;
         [Column("oie_var_2_nome")]
        public virtual string Var2Nome
         { 
            get { return this._valueVar2Nome; } 
            set 
            { 
                if (this._valueVar2Nome == value)return;
                 this._valueVar2Nome = value; 
            } 
        } 

       protected string _var2ValorOriginal{get;private set;}
       private string _var2ValorOriginalCommited{get; set;}
        private string _valueVar2Valor;
         [Column("oie_var_2_valor")]
        public virtual string Var2Valor
         { 
            get { return this._valueVar2Valor; } 
            set 
            { 
                if (this._valueVar2Valor == value)return;
                 this._valueVar2Valor = value; 
            } 
        } 

       protected string _var3NomeOriginal{get;private set;}
       private string _var3NomeOriginalCommited{get; set;}
        private string _valueVar3Nome;
         [Column("oie_var_3_nome")]
        public virtual string Var3Nome
         { 
            get { return this._valueVar3Nome; } 
            set 
            { 
                if (this._valueVar3Nome == value)return;
                 this._valueVar3Nome = value; 
            } 
        } 

       protected string _var3ValorOriginal{get;private set;}
       private string _var3ValorOriginalCommited{get; set;}
        private string _valueVar3Valor;
         [Column("oie_var_3_valor")]
        public virtual string Var3Valor
         { 
            get { return this._valueVar3Valor; } 
            set 
            { 
                if (this._valueVar3Valor == value)return;
                 this._valueVar3Valor = value; 
            } 
        } 

       protected string _var4NomeOriginal{get;private set;}
       private string _var4NomeOriginalCommited{get; set;}
        private string _valueVar4Nome;
         [Column("oie_var_4_nome")]
        public virtual string Var4Nome
         { 
            get { return this._valueVar4Nome; } 
            set 
            { 
                if (this._valueVar4Nome == value)return;
                 this._valueVar4Nome = value; 
            } 
        } 

       protected string _var4ValorOriginal{get;private set;}
       private string _var4ValorOriginalCommited{get; set;}
        private string _valueVar4Valor;
         [Column("oie_var_4_valor")]
        public virtual string Var4Valor
         { 
            get { return this._valueVar4Valor; } 
            set 
            { 
                if (this._valueVar4Valor == value)return;
                 this._valueVar4Valor = value; 
            } 
        } 

       protected DateTime? _dataEntregaOriginal{get;private set;}
       private DateTime? _dataEntregaOriginalCommited{get; set;}
        private DateTime? _valueDataEntrega;
         [Column("oie_data_entrega")]
        public virtual DateTime? DataEntrega
         { 
            get { return this._valueDataEntrega; } 
            set 
            { 
                if (this._valueDataEntrega == value)return;
                 this._valueDataEntrega = value; 
            } 
        } 

       protected string _kitFantasiaOriginal{get;private set;}
       private string _kitFantasiaOriginalCommited{get; set;}
        private string _valueKitFantasia;
         [Column("oie_kit_fantasia")]
        public virtual string KitFantasia
         { 
            get { return this._valueKitFantasia; } 
            set 
            { 
                if (this._valueKitFantasia == value)return;
                 this._valueKitFantasia = value; 
            } 
        } 

       protected short? _pkKitTempOriginal{get;private set;}
       private short? _pkKitTempOriginalCommited{get; set;}
        private short? _valuePkKitTemp;
         [Column("oie_pk_kit_temp")]
        public virtual short? PkKitTemp
         { 
            get { return this._valuePkKitTemp; } 
            set 
            { 
                if (this._valuePkKitTemp == value)return;
                 this._valuePkKitTemp = value; 
            } 
        } 

       protected DateTime? _dataImpressaoOpOriginal{get;private set;}
       private DateTime? _dataImpressaoOpOriginalCommited{get; set;}
        private DateTime? _valueDataImpressaoOp;
         [Column("oie_data_impressao_op")]
        public virtual DateTime? DataImpressaoOp
         { 
            get { return this._valueDataImpressaoOp; } 
            set 
            { 
                if (this._valueDataImpressaoOp == value)return;
                 this._valueDataImpressaoOp = value; 
            } 
        } 

       protected string _tipoDocumentoOriginal{get;private set;}
       private string _tipoDocumentoOriginalCommited{get; set;}
        private string _valueTipoDocumento;
         [Column("oie_tipo_documento")]
        public virtual string TipoDocumento
         { 
            get { return this._valueTipoDocumento; } 
            set 
            { 
                if (this._valueTipoDocumento == value)return;
                 this._valueTipoDocumento = value; 
            } 
        } 

       protected string _numeroDocumentoOriginal{get;private set;}
       private string _numeroDocumentoOriginalCommited{get; set;}
        private string _valueNumeroDocumento;
         [Column("oie_numero_documento")]
        public virtual string NumeroDocumento
         { 
            get { return this._valueNumeroDocumento; } 
            set 
            { 
                if (this._valueNumeroDocumento == value)return;
                 this._valueNumeroDocumento = value; 
            } 
        } 

       protected string _revisaoDesenhoOriginal{get;private set;}
       private string _revisaoDesenhoOriginalCommited{get; set;}
        private string _valueRevisaoDesenho;
         [Column("oie_revisao_desenho")]
        public virtual string RevisaoDesenho
         { 
            get { return this._valueRevisaoDesenho; } 
            set 
            { 
                if (this._valueRevisaoDesenho == value)return;
                 this._valueRevisaoDesenho = value; 
            } 
        } 

       protected string _codigoItemPaiOriginal{get;private set;}
       private string _codigoItemPaiOriginalCommited{get; set;}
        private string _valueCodigoItemPai;
         [Column("oie_codigo_item_pai")]
        public virtual string CodigoItemPai
         { 
            get { return this._valueCodigoItemPai; } 
            set 
            { 
                if (this._valueCodigoItemPai == value)return;
                 this._valueCodigoItemPai = value; 
            } 
        } 

       protected bool _ordemProducaoImpressaOriginal{get;private set;}
       private bool _ordemProducaoImpressaOriginalCommited{get; set;}
        private bool _valueOrdemProducaoImpressa;
         [Column("oie_ordem_producao_impressa")]
        public virtual bool OrdemProducaoImpressa
         { 
            get { return this._valueOrdemProducaoImpressa; } 
            set 
            { 
                if (this._valueOrdemProducaoImpressa == value)return;
                 this._valueOrdemProducaoImpressa = value; 
            } 
        } 

       protected DateTime? _ordemProducaoImpressaDataOriginal{get;private set;}
       private DateTime? _ordemProducaoImpressaDataOriginalCommited{get; set;}
        private DateTime? _valueOrdemProducaoImpressaData;
         [Column("oie_ordem_producao_impressa_data")]
        public virtual DateTime? OrdemProducaoImpressaData
         { 
            get { return this._valueOrdemProducaoImpressaData; } 
            set 
            { 
                if (this._valueOrdemProducaoImpressaData == value)return;
                 this._valueOrdemProducaoImpressaData = value; 
            } 
        } 

       protected string _verOcOriginal{get;private set;}
       private string _verOcOriginalCommited{get; set;}
        private string _valueVerOc;
         [Column("oie_ver_oc")]
        public virtual string VerOc
         { 
            get { return this._valueVerOc; } 
            set 
            { 
                if (this._valueVerOc == value)return;
                 this._valueVerOc = value; 
            } 
        } 

       protected string _acabamentoSuperficialOriginal{get;private set;}
       private string _acabamentoSuperficialOriginalCommited{get; set;}
        private string _valueAcabamentoSuperficial;
         [Column("oie_acabamento_superficial")]
        public virtual string AcabamentoSuperficial
         { 
            get { return this._valueAcabamentoSuperficial; } 
            set 
            { 
                if (this._valueAcabamentoSuperficial == value)return;
                 this._valueAcabamentoSuperficial = value; 
            } 
        } 

       protected bool _itemOriginalPedidoOriginal{get;private set;}
       private bool _itemOriginalPedidoOriginalCommited{get; set;}
        private bool _valueItemOriginalPedido;
         [Column("oie_item_original_pedido")]
        public virtual bool ItemOriginalPedido
         { 
            get { return this._valueItemOriginalPedido; } 
            set 
            { 
                if (this._valueItemOriginalPedido == value)return;
                 this._valueItemOriginalPedido = value; 
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

       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItem;
        [Column("id_pedido_item", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItem
        { 
           get {                 return this._valuePedidoItem; } 
           set 
           { 
                if (this._valuePedidoItem == value)return;
                 this._valuePedidoItem = value; 
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

       protected string _descItemPaiOriginal{get;private set;}
       private string _descItemPaiOriginalCommited{get; set;}
        private string _valueDescItemPai;
         [Column("oie_desc_item_pai")]
        public virtual string DescItemPai
         { 
            get { return this._valueDescItemPai; } 
            set 
            { 
                if (this._valueDescItemPai == value)return;
                 this._valueDescItemPai = value; 
            } 
        } 

       protected string _acabItemPaiOriginal{get;private set;}
       private string _acabItemPaiOriginalCommited{get; set;}
        private string _valueAcabItemPai;
         [Column("oie_acab_item_pai")]
        public virtual string AcabItemPai
         { 
            get { return this._valueAcabItemPai; } 
            set 
            { 
                if (this._valueAcabItemPai == value)return;
                 this._valueAcabItemPai = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _produtoKOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProdutoKClass _valueProdutoK;
        [Column("id_produto_k", "produto_k", "id_produto_k")]
       public virtual BibliotecaEntidades.Entidades.ProdutoKClass ProdutoK
        { 
           get {                 return this._valueProdutoK; } 
           set 
           { 
                if (this._valueProdutoK == value)return;
                 this._valueProdutoK = value; 
           } 
       } 

       protected bool _compraMpGeradoOriginal{get;private set;}
       private bool _compraMpGeradoOriginalCommited{get; set;}
        private bool _valueCompraMpGerado;
         [Column("oie_compra_mp_gerado")]
        public virtual bool CompraMpGerado
         { 
            get { return this._valueCompraMpGerado; } 
            set 
            { 
                if (this._valueCompraMpGerado == value)return;
                 this._valueCompraMpGerado = value; 
            } 
        } 

       protected DateTime? _compraMpDataGeracaoOriginal{get;private set;}
       private DateTime? _compraMpDataGeracaoOriginalCommited{get; set;}
        private DateTime? _valueCompraMpDataGeracao;
         [Column("oie_compra_mp_data_geracao")]
        public virtual DateTime? CompraMpDataGeracao
         { 
            get { return this._valueCompraMpDataGeracao; } 
            set 
            { 
                if (this._valueCompraMpDataGeracao == value)return;
                 this._valueCompraMpDataGeracao = value; 
            } 
        } 

       protected string _informacoesEspeciaisOriginal{get;private set;}
       private string _informacoesEspeciaisOriginalCommited{get; set;}
        private string _valueInformacoesEspeciais;
         [Column("oie_informacoes_especiais")]
        public virtual string InformacoesEspeciais
         { 
            get { return this._valueInformacoesEspeciais; } 
            set 
            { 
                if (this._valueInformacoesEspeciais == value)return;
                 this._valueInformacoesEspeciais = value; 
            } 
        } 

       protected int _versaoEstruturaItemOriginal{get;private set;}
       private int _versaoEstruturaItemOriginalCommited{get; set;}
        private int _valueVersaoEstruturaItem;
         [Column("oie_versao_estrutura_item")]
        public virtual int VersaoEstruturaItem
         { 
            get { return this._valueVersaoEstruturaItem; } 
            set 
            { 
                if (this._valueVersaoEstruturaItem == value)return;
                 this._valueVersaoEstruturaItem = value; 
            } 
        } 

       protected bool _rastreamentoMaterialOriginal{get;private set;}
       private bool _rastreamentoMaterialOriginalCommited{get; set;}
        private bool _valueRastreamentoMaterial;
         [Column("oie_rastreamento_material")]
        public virtual bool RastreamentoMaterial
         { 
            get { return this._valueRastreamentoMaterial; } 
            set 
            { 
                if (this._valueRastreamentoMaterial == value)return;
                 this._valueRastreamentoMaterial = value; 
            } 
        } 

       protected ResponsavelFrete _responsavelFreteOriginal{get;private set;}
       private ResponsavelFrete _responsavelFreteOriginalCommited{get; set;}
        private ResponsavelFrete _valueResponsavelFrete;
         [Column("oie_responsavel_frete")]
        public virtual ResponsavelFrete ResponsavelFrete
         { 
            get { return this._valueResponsavelFrete; } 
            set 
            { 
                if (this._valueResponsavelFrete == value)return;
                 this._valueResponsavelFrete = value; 
            } 
        } 

        public bool ResponsavelFrete_ProprioRemetente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; }
         } 

        public bool ResponsavelFrete_ProprioDestinatario
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; }
         } 

        public bool ResponsavelFrete_Emitente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Emitente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Emitente; }
         } 

        public bool ResponsavelFrete_Cliente
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Cliente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Cliente; }
         } 

        public bool ResponsavelFrete_Terceiros
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; }
         } 

        public bool ResponsavelFrete_SemFrete
         { 
            get { return this._valueResponsavelFrete == BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; }
         } 

       protected bool _volumeUnicoOriginal{get;private set;}
       private bool _volumeUnicoOriginalCommited{get; set;}
        private bool _valueVolumeUnico;
         [Column("oie_volume_unico")]
        public virtual bool VolumeUnico
         { 
            get { return this._valueVolumeUnico; } 
            set 
            { 
                if (this._valueVolumeUnico == value)return;
                 this._valueVolumeUnico = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _valueOrderItemEtiquetaPai;
        [Column("id_order_item_etiqueta_pai", "order_item_etiqueta", "id_order_item_etiqueta")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaClass OrderItemEtiquetaPai
        { 
           get {                 return this._valueOrderItemEtiquetaPai; } 
           set 
           { 
                if (this._valueOrderItemEtiquetaPai == value)return;
                 this._valueOrderItemEtiquetaPai = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _modeloEtiquetaExpedicaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _modeloEtiquetaExpedicaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass _valueModeloEtiquetaExpedicao;
        [Column("id_modelo_etiqueta_expedicao", "modelo_etiqueta_expedicao", "id_modelo_etiqueta_expedicao")]
       public virtual BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass ModeloEtiquetaExpedicao
        { 
           get {                 return this._valueModeloEtiquetaExpedicao; } 
           set 
           { 
                if (this._valueModeloEtiquetaExpedicao == value)return;
                 this._valueModeloEtiquetaExpedicao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemLinhaPrincipalPedidoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemLinhaPrincipalPedidoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItemLinhaPrincipalPedido;
        [Column("id_pedido_item_linha_principal_pedido", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItemLinhaPrincipalPedido
        { 
           get {                 return this._valuePedidoItemLinhaPrincipalPedido; } 
           set 
           { 
                if (this._valuePedidoItemLinhaPrincipalPedido == value)return;
                 this._valuePedidoItemLinhaPrincipalPedido = value; 
           } 
       } 

       protected TipoAquisicao _tipoAquisicaoProdutoOriginal{get;private set;}
       private TipoAquisicao _tipoAquisicaoProdutoOriginalCommited{get; set;}
        private TipoAquisicao _valueTipoAquisicaoProduto;
         [Column("oie_tipo_aquisicao_produto")]
        public virtual TipoAquisicao TipoAquisicaoProduto
         { 
            get { return this._valueTipoAquisicaoProduto; } 
            set 
            { 
                if (this._valueTipoAquisicaoProduto == value)return;
                 this._valueTipoAquisicaoProduto = value; 
            } 
        } 

        public bool TipoAquisicaoProduto_Fabricado
         { 
            get { return this._valueTipoAquisicaoProduto == BibliotecaEntidades.Base.TipoAquisicao.Fabricado; } 
            set { if (value) this._valueTipoAquisicaoProduto = BibliotecaEntidades.Base.TipoAquisicao.Fabricado; }
         } 

        public bool TipoAquisicaoProduto_Comprado
         { 
            get { return this._valueTipoAquisicaoProduto == BibliotecaEntidades.Base.TipoAquisicao.Comprado; } 
            set { if (value) this._valueTipoAquisicaoProduto = BibliotecaEntidades.Base.TipoAquisicao.Comprado; }
         } 

       protected BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _unidadeMedidaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.UnidadeMedidaClass _valueUnidadeMedida;
        [Column("id_unidade_medida", "unidade_medida", "id_unidade_medida")]
       public virtual BibliotecaEntidades.Entidades.UnidadeMedidaClass UnidadeMedida
        { 
           get {                 return this._valueUnidadeMedida; } 
           set 
           { 
                if (this._valueUnidadeMedida == value)return;
                 this._valueUnidadeMedida = value; 
           } 
       } 

       private List<long> _collectionAtendimentoClassOrderItemEtiquetaOriginal;
       private List<Entidades.AtendimentoClass > _collectionAtendimentoClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AtendimentoClass> _valueCollectionAtendimentoClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AtendimentoClass> CollectionAtendimentoClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionAtendimentoClassOrderItemEtiqueta();}
return this._valueCollectionAtendimentoClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionAtendimentoClassOrderItemEtiqueta = value; 
               this._valueCollectionAtendimentoClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoPedidoClassOrderItemEtiquetaOriginal;
       private List<Entidades.OrdemProducaoPedidoClass > _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoPedidoClass> _valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoPedidoClass> CollectionOrdemProducaoPedidoClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoPedidoClassOrderItemEtiqueta();}
return this._valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta = value; 
               this._valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai();}
return this._valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai = value; 
               this._valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaOriginal;
       private List<Entidades.OrderItemEtiquetaConferenciaClass > _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaConferenciaClass> _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaConferenciaClass> CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta();}
return this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta = value; 
               this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaOriginal;
       private List<Entidades.OrderItemEtiquetaConferenciaNfClass > _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaConferenciaNfClass> _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaConferenciaNfClass> CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta();}
return this._valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta = value; 
               this._valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaOriginal;
       private List<Entidades.PedidoItemConfiguradoMaterialClass > _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemConfiguradoMaterialClass> _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemConfiguradoMaterialClass> CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta();}
return this._valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta = value; 
               this._valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

       private List<long> _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaOriginal;
       private List<Entidades.PlanoCorteItemPedidoClass > _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PlanoCorteItemPedidoClass> _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PlanoCorteItemPedidoClass> CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta 
       { 
           get { if(!_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded && !this.DisableLoadCollection){this.LoadCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta();}
return this._valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta; } 
           set 
           { 
               this._valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta = value; 
               this._valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded = true; 
           } 
       } 

        public OrderItemEtiquetaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.SituacaoConferencia = (SituacaoConferencia)0;
           this.EtiquetaExpedicaoImpressa = false;
           this.UsarTimer = true;
           this.PermitirParcial = false;
           this.Quantidade = 0;
           this.NotaFiscalEmitida = false;
           this.SituacaoConferenciaNf = (SituacaoConferencia)0;
           this.Frete = 0;
           this.EtiquetaInterna = false;
           this.SaldoConferencia = 0;
           this.EtiquetaInternaImpressa = false;
           this.ConferenciaCustomizadaRealizada = false;
           this.ConferenciaCustomizadaRealizadaForcada = false;
           this.QtdEtiquetaExpVolume = 2;
           this.ImprimePackingList = false;
           this.Altura = 0;
           this.Largura = 0;
           this.Comprimento = 0;
           this.PackinglistKitImpresso = false;
           this.PkKitTemp = 0;
           this.OrdemProducaoImpressa = false;
           this.ItemOriginalPedido = true;
           this.CompraMpGerado = false;
           this.VersaoEstruturaItem = 0;
           this.RastreamentoMaterial = false;
           this.ResponsavelFrete = (ResponsavelFrete)0;
           this.VolumeUnico = true;
           this.TipoAquisicaoProduto = (TipoAquisicao)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrderItemEtiquetaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrderItemEtiquetaClass) GetEntity(typeof(OrderItemEtiquetaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAtendimentoClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaChanged = true;
                  _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in e.OldItems) 
                 { 
                     _collectionAtendimentoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in _valueCollectionAtendimentoClassOrderItemEtiqueta) 
                 { 
                     _collectionAtendimentoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAtendimentoClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.AtendimentoClass> oc;
                _valueCollectionAtendimentoClassOrderItemEtiquetaChanged = false;
                 _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged = false;
                _collectionAtendimentoClassOrderItemEtiquetaRemovidos = new List<Entidades.AtendimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AtendimentoClass>();
                }
                else{ 
                   Entidades.AtendimentoClass search = new Entidades.AtendimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AtendimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this)                    }                       ).Cast<Entidades.AtendimentoClass>().ToList());
                 }
                 _valueCollectionAtendimentoClassOrderItemEtiqueta = new BindingList<Entidades.AtendimentoClass>(oc); 
                 _collectionAtendimentoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionAtendimentoClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionAtendimentoClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionAtendimentoClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAtendimentoClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoPedidoClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged = true;
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPedidoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoPedidoClass item in _valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta) 
                 { 
                     _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoPedidoClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoPedidoClass> oc;
                _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged = false;
                 _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged = false;
                _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos = new List<Entidades.OrdemProducaoPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoPedidoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoPedidoClass search = new Entidades.OrdemProducaoPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this),                     }                       ).Cast<Entidades.OrdemProducaoPedidoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta = new BindingList<Entidades.OrdemProducaoPedidoClass>(oc); 
                 _collectionOrdemProducaoPedidoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoPedidoClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoPedidoClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged = true;
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai) 
                 { 
                     _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged = false;
                 _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged = false;
                _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiquetaPai", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiOriginal= (from a in _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged = true;
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass> oc;
                _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged = false;
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged = false;
                _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaConferenciaClass search = new Entidades.OrderItemEtiquetaConferenciaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaConferenciaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta = new BindingList<Entidades.OrderItemEtiquetaConferenciaClass>(oc); 
                 _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged = true;
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaNfClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaNfClass item in _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaConferenciaNfClass> oc;
                _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged = false;
                 _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged = false;
                _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaNfClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaNfClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaConferenciaNfClass search = new Entidades.OrderItemEtiquetaConferenciaNfClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaNfClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaConferenciaNfClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta = new BindingList<Entidades.OrderItemEtiquetaConferenciaNfClass>(oc); 
                 _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged = true;
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.PedidoItemConfiguradoMaterialClass item in _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta) 
                 { 
                     _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass> oc;
                _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged = false;
                 _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged = false;
                _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>();
                }
                else{ 
                   Entidades.PedidoItemConfiguradoMaterialClass search = new Entidades.PedidoItemConfiguradoMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemConfiguradoMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this),                     }                       ).Cast<Entidades.PedidoItemConfiguradoMaterialClass>().ToList());
                 }
                 _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta = new BindingList<Entidades.PedidoItemConfiguradoMaterialClass>(oc); 
                 _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged = true;
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemPedidoClass item in e.OldItems) 
                 { 
                     _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged = true; 
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged = true;
                 foreach (Entidades.PlanoCorteItemPedidoClass item in _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta) 
                 { 
                     _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta()
         {
            try
            {
                 ObservableCollection<Entidades.PlanoCorteItemPedidoClass> oc;
                _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged = false;
                 _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged = false;
                _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos = new List<Entidades.PlanoCorteItemPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PlanoCorteItemPedidoClass>();
                }
                else{ 
                   Entidades.PlanoCorteItemPedidoClass search = new Entidades.PlanoCorteItemPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PlanoCorteItemPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiqueta", this),                     }                       ).Cast<Entidades.PlanoCorteItemPedidoClass>().ToList());
                 }
                 _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta = new BindingList<Entidades.PlanoCorteItemPedidoClass>(oc); 
                 _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta select a.ID).ToList();
                 _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded = true;
                 oc.CollectionChanged += CollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(StatusPedido))
                {
                    throw new Exception(ErroStatusPedidoObrigatorio);
                }
                if (StatusPedido.Length >2)
                {
                    throw new Exception( ErroStatusPedidoComprimento);
                }
                if ( _valueModeloEtiquetaExpedicao == null)
                {
                    throw new Exception(ErroModeloEtiquetaExpedicaoObrigatorio);
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
                    "  public.order_item_etiqueta  " +
                    "WHERE " +
                    "  id_order_item_etiqueta = :id";
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
                        "  public.order_item_etiqueta   " +
                        "SET  " + 
                        "  oie_order_number = :oie_order_number, " + 
                        "  oie_order_pos = :oie_order_pos, " + 
                        "  oie_codigo_item = :oie_codigo_item, " + 
                        "  oie_descricao = :oie_descricao, " + 
                        "  oie_tipo_item = :oie_tipo_item, " + 
                        "  oie_dimensao = :oie_dimensao, " + 
                        "  oie_pps = :oie_pps, " + 
                        "  oie_qtd_etiquetas = :oie_qtd_etiquetas, " + 
                        "  oie_etiqueta_agrupada = :oie_etiqueta_agrupada, " + 
                        "  oie_cubagem = :oie_cubagem, " + 
                        "  oie_peso = :oie_peso, " + 
                        "  oie_volumes = :oie_volumes, " + 
                        "  oie_saldo = :oie_saldo, " + 
                        "  oie_situacao_conferencia = :oie_situacao_conferencia, " + 
                        "  oie_nivel_item = :oie_nivel_item, " + 
                        "  oie_ovm = :oie_ovm, " + 
                        "  oie_deps = :oie_deps, " + 
                        "  oie_peps = :oie_peps, " + 
                        "  oie_etiqueta_expedicao_impressa = :oie_etiqueta_expedicao_impressa, " + 
                        "  oie_usar_timer = :oie_usar_timer, " + 
                        "  oie_permitir_parcial = :oie_permitir_parcial, " + 
                        "  oie_quantidade = :oie_quantidade, " + 
                        "  oie_pallet = :oie_pallet, " + 
                        "  oie_nota_fiscal_emitida = :oie_nota_fiscal_emitida, " + 
                        "  oie_situacao_conferencia_nf = :oie_situacao_conferencia_nf, " + 
                        "  oie_preco_total = :oie_preco_total, " + 
                        "  oie_preco_unitario = :oie_preco_unitario, " + 
                        "  oie_emissao_parcial = :oie_emissao_parcial, " + 
                        "  oie_status_pedido = :oie_status_pedido, " + 
                        "  oie_armazenagem_cliente = :oie_armazenagem_cliente, " + 
                        "  oie_descricao_cliente = :oie_descricao_cliente, " + 
                        "  oie_codigo_cliente = :oie_codigo_cliente, " + 
                        "  id_externo_cliente_access = :id_externo_cliente_access, " + 
                        "  oie_cnpj_pedido = :oie_cnpj_pedido, " + 
                        "  oie_cfop = :oie_cfop, " + 
                        "  oie_natureza_operacao = :oie_natureza_operacao, " + 
                        "  oie_tipo_operacao = :oie_tipo_operacao, " + 
                        "  oie_nbm_pedido = :oie_nbm_pedido, " + 
                        "  oie_frete = :oie_frete, " + 
                        "  oie_nota_fiscal = :oie_nota_fiscal, " + 
                        "  oie_etiqueta_interna = :oie_etiqueta_interna, " + 
                        "  oie_saldo_conferencia = :oie_saldo_conferencia, " + 
                        "  oie_cnc = :oie_cnc, " + 
                        "  oie_coordenada_x = :oie_coordenada_x, " + 
                        "  oie_coordenada_y = :oie_coordenada_y, " + 
                        "  oie_etiqueta_interna_impressa = :oie_etiqueta_interna_impressa, " + 
                        "  oie_saf = :oie_saf, " + 
                        "  oie_programador = :oie_programador, " + 
                        "  oie_conferencia_customizada_realizada = :oie_conferencia_customizada_realizada, " + 
                        "  oie_conferencia_customizada_realizada_forcada = :oie_conferencia_customizada_realizada_forcada, " + 
                        "  oie_qtd_etiqueta_exp_volume = :oie_qtd_etiqueta_exp_volume, " + 
                        "  oie_descricao_pt = :oie_descricao_pt, " + 
                        "  oie_descricao_en = :oie_descricao_en, " + 
                        "  oie_descricao_es = :oie_descricao_es, " + 
                        "  oie_imprime_packing_list = :oie_imprime_packing_list, " + 
                        "  oie_tipo_baseboard = :oie_tipo_baseboard, " + 
                        "  oie_altura = :oie_altura, " + 
                        "  oie_largura = :oie_largura, " + 
                        "  oie_comprimento = :oie_comprimento, " + 
                        "  oie_tipo_ligacao = :oie_tipo_ligacao, " + 
                        "  oie_packinglist_kit_impresso = :oie_packinglist_kit_impresso, " + 
                        "  oie_var_1_nome = :oie_var_1_nome, " + 
                        "  oie_var_1_valor = :oie_var_1_valor, " + 
                        "  oie_var_2_nome = :oie_var_2_nome, " + 
                        "  oie_var_2_valor = :oie_var_2_valor, " + 
                        "  oie_var_3_nome = :oie_var_3_nome, " + 
                        "  oie_var_3_valor = :oie_var_3_valor, " + 
                        "  oie_var_4_nome = :oie_var_4_nome, " + 
                        "  oie_var_4_valor = :oie_var_4_valor, " + 
                        "  oie_data_entrega = :oie_data_entrega, " + 
                        "  oie_kit_fantasia = :oie_kit_fantasia, " + 
                        "  oie_pk_kit_temp = :oie_pk_kit_temp, " + 
                        "  oie_data_impressao_op = :oie_data_impressao_op, " + 
                        "  oie_tipo_documento = :oie_tipo_documento, " + 
                        "  oie_numero_documento = :oie_numero_documento, " + 
                        "  oie_revisao_desenho = :oie_revisao_desenho, " + 
                        "  oie_codigo_item_pai = :oie_codigo_item_pai, " + 
                        "  oie_ordem_producao_impressa = :oie_ordem_producao_impressa, " + 
                        "  oie_ordem_producao_impressa_data = :oie_ordem_producao_impressa_data, " + 
                        "  oie_ver_oc = :oie_ver_oc, " + 
                        "  oie_acabamento_superficial = :oie_acabamento_superficial, " + 
                        "  oie_item_original_pedido = :oie_item_original_pedido, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_pedido_item = :id_pedido_item, " + 
                        "  id_produto = :id_produto, " + 
                        "  oie_desc_item_pai = :oie_desc_item_pai, " + 
                        "  oie_acab_item_pai = :oie_acab_item_pai, " + 
                        "  id_produto_k = :id_produto_k, " + 
                        "  oie_compra_mp_gerado = :oie_compra_mp_gerado, " + 
                        "  oie_compra_mp_data_geracao = :oie_compra_mp_data_geracao, " + 
                        "  oie_informacoes_especiais = :oie_informacoes_especiais, " + 
                        "  oie_versao_estrutura_item = :oie_versao_estrutura_item, " + 
                        "  oie_rastreamento_material = :oie_rastreamento_material, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  oie_responsavel_frete = :oie_responsavel_frete, " + 
                        "  oie_volume_unico = :oie_volume_unico, " + 
                        "  id_order_item_etiqueta_pai = :id_order_item_etiqueta_pai, " + 
                        "  id_modelo_etiqueta_expedicao = :id_modelo_etiqueta_expedicao, " + 
                        "  id_pedido_item_linha_principal_pedido = :id_pedido_item_linha_principal_pedido, " + 
                        "  oie_tipo_aquisicao_produto = :oie_tipo_aquisicao_produto, " + 
                        "  id_unidade_medida = :id_unidade_medida "+
                        "WHERE  " +
                        "  id_order_item_etiqueta = :id " +
                        "RETURNING id_order_item_etiqueta;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.order_item_etiqueta " +
                        "( " +
                        "  oie_order_number , " + 
                        "  oie_order_pos , " + 
                        "  oie_codigo_item , " + 
                        "  oie_descricao , " + 
                        "  oie_tipo_item , " + 
                        "  oie_dimensao , " + 
                        "  oie_pps , " + 
                        "  oie_qtd_etiquetas , " + 
                        "  oie_etiqueta_agrupada , " + 
                        "  oie_cubagem , " + 
                        "  oie_peso , " + 
                        "  oie_volumes , " + 
                        "  oie_saldo , " + 
                        "  oie_situacao_conferencia , " + 
                        "  oie_nivel_item , " + 
                        "  oie_ovm , " + 
                        "  oie_deps , " + 
                        "  oie_peps , " + 
                        "  oie_etiqueta_expedicao_impressa , " + 
                        "  oie_usar_timer , " + 
                        "  oie_permitir_parcial , " + 
                        "  oie_quantidade , " + 
                        "  oie_pallet , " + 
                        "  oie_nota_fiscal_emitida , " + 
                        "  oie_situacao_conferencia_nf , " + 
                        "  oie_preco_total , " + 
                        "  oie_preco_unitario , " + 
                        "  oie_emissao_parcial , " + 
                        "  oie_status_pedido , " + 
                        "  oie_armazenagem_cliente , " + 
                        "  oie_descricao_cliente , " + 
                        "  oie_codigo_cliente , " + 
                        "  id_externo_cliente_access , " + 
                        "  oie_cnpj_pedido , " + 
                        "  oie_cfop , " + 
                        "  oie_natureza_operacao , " + 
                        "  oie_tipo_operacao , " + 
                        "  oie_nbm_pedido , " + 
                        "  oie_frete , " + 
                        "  oie_nota_fiscal , " + 
                        "  oie_etiqueta_interna , " + 
                        "  oie_saldo_conferencia , " + 
                        "  oie_cnc , " + 
                        "  oie_coordenada_x , " + 
                        "  oie_coordenada_y , " + 
                        "  oie_etiqueta_interna_impressa , " + 
                        "  oie_saf , " + 
                        "  oie_programador , " + 
                        "  oie_conferencia_customizada_realizada , " + 
                        "  oie_conferencia_customizada_realizada_forcada , " + 
                        "  oie_qtd_etiqueta_exp_volume , " + 
                        "  oie_descricao_pt , " + 
                        "  oie_descricao_en , " + 
                        "  oie_descricao_es , " + 
                        "  oie_imprime_packing_list , " + 
                        "  oie_tipo_baseboard , " + 
                        "  oie_altura , " + 
                        "  oie_largura , " + 
                        "  oie_comprimento , " + 
                        "  oie_tipo_ligacao , " + 
                        "  oie_packinglist_kit_impresso , " + 
                        "  oie_var_1_nome , " + 
                        "  oie_var_1_valor , " + 
                        "  oie_var_2_nome , " + 
                        "  oie_var_2_valor , " + 
                        "  oie_var_3_nome , " + 
                        "  oie_var_3_valor , " + 
                        "  oie_var_4_nome , " + 
                        "  oie_var_4_valor , " + 
                        "  oie_data_entrega , " + 
                        "  oie_kit_fantasia , " + 
                        "  oie_pk_kit_temp , " + 
                        "  oie_data_impressao_op , " + 
                        "  oie_tipo_documento , " + 
                        "  oie_numero_documento , " + 
                        "  oie_revisao_desenho , " + 
                        "  oie_codigo_item_pai , " + 
                        "  oie_ordem_producao_impressa , " + 
                        "  oie_ordem_producao_impressa_data , " + 
                        "  oie_ver_oc , " + 
                        "  oie_acabamento_superficial , " + 
                        "  oie_item_original_pedido , " + 
                        "  id_cliente , " + 
                        "  id_pedido_item , " + 
                        "  id_produto , " + 
                        "  oie_desc_item_pai , " + 
                        "  oie_acab_item_pai , " + 
                        "  id_produto_k , " + 
                        "  oie_compra_mp_gerado , " + 
                        "  oie_compra_mp_data_geracao , " + 
                        "  oie_informacoes_especiais , " + 
                        "  oie_versao_estrutura_item , " + 
                        "  oie_rastreamento_material , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  oie_responsavel_frete , " + 
                        "  oie_volume_unico , " + 
                        "  id_order_item_etiqueta_pai , " + 
                        "  id_modelo_etiqueta_expedicao , " + 
                        "  id_pedido_item_linha_principal_pedido , " + 
                        "  oie_tipo_aquisicao_produto , " + 
                        "  id_unidade_medida  "+
                        ")  " +
                        "VALUES ( " +
                        "  :oie_order_number , " + 
                        "  :oie_order_pos , " + 
                        "  :oie_codigo_item , " + 
                        "  :oie_descricao , " + 
                        "  :oie_tipo_item , " + 
                        "  :oie_dimensao , " + 
                        "  :oie_pps , " + 
                        "  :oie_qtd_etiquetas , " + 
                        "  :oie_etiqueta_agrupada , " + 
                        "  :oie_cubagem , " + 
                        "  :oie_peso , " + 
                        "  :oie_volumes , " + 
                        "  :oie_saldo , " + 
                        "  :oie_situacao_conferencia , " + 
                        "  :oie_nivel_item , " + 
                        "  :oie_ovm , " + 
                        "  :oie_deps , " + 
                        "  :oie_peps , " + 
                        "  :oie_etiqueta_expedicao_impressa , " + 
                        "  :oie_usar_timer , " + 
                        "  :oie_permitir_parcial , " + 
                        "  :oie_quantidade , " + 
                        "  :oie_pallet , " + 
                        "  :oie_nota_fiscal_emitida , " + 
                        "  :oie_situacao_conferencia_nf , " + 
                        "  :oie_preco_total , " + 
                        "  :oie_preco_unitario , " + 
                        "  :oie_emissao_parcial , " + 
                        "  :oie_status_pedido , " + 
                        "  :oie_armazenagem_cliente , " + 
                        "  :oie_descricao_cliente , " + 
                        "  :oie_codigo_cliente , " + 
                        "  :id_externo_cliente_access , " + 
                        "  :oie_cnpj_pedido , " + 
                        "  :oie_cfop , " + 
                        "  :oie_natureza_operacao , " + 
                        "  :oie_tipo_operacao , " + 
                        "  :oie_nbm_pedido , " + 
                        "  :oie_frete , " + 
                        "  :oie_nota_fiscal , " + 
                        "  :oie_etiqueta_interna , " + 
                        "  :oie_saldo_conferencia , " + 
                        "  :oie_cnc , " + 
                        "  :oie_coordenada_x , " + 
                        "  :oie_coordenada_y , " + 
                        "  :oie_etiqueta_interna_impressa , " + 
                        "  :oie_saf , " + 
                        "  :oie_programador , " + 
                        "  :oie_conferencia_customizada_realizada , " + 
                        "  :oie_conferencia_customizada_realizada_forcada , " + 
                        "  :oie_qtd_etiqueta_exp_volume , " + 
                        "  :oie_descricao_pt , " + 
                        "  :oie_descricao_en , " + 
                        "  :oie_descricao_es , " + 
                        "  :oie_imprime_packing_list , " + 
                        "  :oie_tipo_baseboard , " + 
                        "  :oie_altura , " + 
                        "  :oie_largura , " + 
                        "  :oie_comprimento , " + 
                        "  :oie_tipo_ligacao , " + 
                        "  :oie_packinglist_kit_impresso , " + 
                        "  :oie_var_1_nome , " + 
                        "  :oie_var_1_valor , " + 
                        "  :oie_var_2_nome , " + 
                        "  :oie_var_2_valor , " + 
                        "  :oie_var_3_nome , " + 
                        "  :oie_var_3_valor , " + 
                        "  :oie_var_4_nome , " + 
                        "  :oie_var_4_valor , " + 
                        "  :oie_data_entrega , " + 
                        "  :oie_kit_fantasia , " + 
                        "  :oie_pk_kit_temp , " + 
                        "  :oie_data_impressao_op , " + 
                        "  :oie_tipo_documento , " + 
                        "  :oie_numero_documento , " + 
                        "  :oie_revisao_desenho , " + 
                        "  :oie_codigo_item_pai , " + 
                        "  :oie_ordem_producao_impressa , " + 
                        "  :oie_ordem_producao_impressa_data , " + 
                        "  :oie_ver_oc , " + 
                        "  :oie_acabamento_superficial , " + 
                        "  :oie_item_original_pedido , " + 
                        "  :id_cliente , " + 
                        "  :id_pedido_item , " + 
                        "  :id_produto , " + 
                        "  :oie_desc_item_pai , " + 
                        "  :oie_acab_item_pai , " + 
                        "  :id_produto_k , " + 
                        "  :oie_compra_mp_gerado , " + 
                        "  :oie_compra_mp_data_geracao , " + 
                        "  :oie_informacoes_especiais , " + 
                        "  :oie_versao_estrutura_item , " + 
                        "  :oie_rastreamento_material , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :oie_responsavel_frete , " + 
                        "  :oie_volume_unico , " + 
                        "  :id_order_item_etiqueta_pai , " + 
                        "  :id_modelo_etiqueta_expedicao , " + 
                        "  :id_pedido_item_linha_principal_pedido , " + 
                        "  :oie_tipo_aquisicao_produto , " + 
                        "  :id_unidade_medida  "+
                        ")RETURNING id_order_item_etiqueta;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_item", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoItem.HasValue ? (object)Convert.ToInt16(this.TipoItem) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_pps", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_qtd_etiquetas", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdEtiquetas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_etiqueta_agrupada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaAgrupada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_cubagem", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cubagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_peso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Volumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_saldo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saldo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_situacao_conferencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SituacaoConferencia);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_nivel_item", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NivelItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_ovm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ovm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_deps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Deps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_peps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_etiqueta_expedicao_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaExpedicaoImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_usar_timer", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsarTimer ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_permitir_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermitirParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pallet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_nota_fiscal_emitida", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaFiscalEmitida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_situacao_conferencia_nf", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SituacaoConferenciaNf);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_preco_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_emissao_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmissaoParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_status_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.StatusPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_armazenagem_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ArmazenagemCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_externo_cliente_access", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdExternoClienteAccess ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_cnpj_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_natureza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaturezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_nbm_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NbmPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Frete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_nota_fiscal", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaFiscal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_etiqueta_interna", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaInterna ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_saldo_conferencia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SaldoConferencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_cnc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_coordenada_x", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CoordenadaX ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_coordenada_y", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CoordenadaY ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_etiqueta_interna_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaInternaImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_saf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_programador", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Programador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_conferencia_customizada_realizada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaCustomizadaRealizada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_conferencia_customizada_realizada_forcada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaCustomizadaRealizadaForcada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_qtd_etiqueta_exp_volume", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdEtiquetaExpVolume ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_descricao_pt", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoPt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_descricao_en", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoEn ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_descricao_es", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoEs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_imprime_packing_list", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimePackingList ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_baseboard", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoBaseboard ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_altura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Altura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Largura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Comprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_ligacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoLigacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_packinglist_kit_impresso", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PackinglistKitImpresso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_1_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var1Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_1_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var1Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_2_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var2Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_2_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var2Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_3_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var3Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_3_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var3Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_4_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var4Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_var_4_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var4Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_data_entrega", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_kit_fantasia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.KitFantasia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_pk_kit_temp", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PkKitTemp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_data_impressao_op", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImpressaoOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_revisao_desenho", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RevisaoDesenho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_codigo_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_ordem_producao_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemProducaoImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_ordem_producao_impressa_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemProducaoImpressaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_ver_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VerOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_acabamento_superficial", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AcabamentoSuperficial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_item_original_pedido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemOriginalPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItem==null ? (object) DBNull.Value : this.PedidoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_desc_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_acab_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AcabItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoK==null ? (object) DBNull.Value : this.ProdutoK.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_compra_mp_gerado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompraMpGerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_compra_mp_data_geracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompraMpDataGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_informacoes_especiais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacoesEspeciais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_versao_estrutura_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstruturaItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_responsavel_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ResponsavelFrete);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_volume_unico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeUnico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiquetaPai==null ? (object) DBNull.Value : this.OrderItemEtiquetaPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_etiqueta_expedicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ModeloEtiquetaExpedicao==null ? (object) DBNull.Value : this.ModeloEtiquetaExpedicao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item_linha_principal_pedido", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItemLinhaPrincipalPedido==null ? (object) DBNull.Value : this.PedidoItemLinhaPrincipalPedido.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oie_tipo_aquisicao_produto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAquisicaoProduto);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_unidade_medida", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UnidadeMedida==null ? (object) DBNull.Value : this.UnidadeMedida.ID;

 
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
 if (CollectionAtendimentoClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.AtendimentoClass tmp in CollectionAtendimentoClassOrderItemEtiqueta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoPedidoClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.OrdemProducaoPedidoClass tmp in CollectionOrdemProducaoPedidoClassOrderItemEtiqueta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.OrderItemEtiquetaConferenciaClass tmp in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.OrderItemEtiquetaConferenciaNfClass tmp in CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.PedidoItemConfiguradoMaterialClass tmp in CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta+"\r\n";
                foreach (Entidades.PlanoCorteItemPedidoClass tmp in CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta)
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
        public static OrderItemEtiquetaClass CopiarEntidade(OrderItemEtiquetaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrderItemEtiquetaClass toRet = new OrderItemEtiquetaClass(usuario,conn);
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.TipoItem= entidadeCopiar.TipoItem;
 toRet.Dimensao= entidadeCopiar.Dimensao;
 toRet.Pps= entidadeCopiar.Pps;
 toRet.QtdEtiquetas= entidadeCopiar.QtdEtiquetas;
 toRet.EtiquetaAgrupada= entidadeCopiar.EtiquetaAgrupada;
 toRet.Cubagem= entidadeCopiar.Cubagem;
 toRet.Peso= entidadeCopiar.Peso;
 toRet.Volumes= entidadeCopiar.Volumes;
 toRet.Saldo= entidadeCopiar.Saldo;
 toRet.SituacaoConferencia= entidadeCopiar.SituacaoConferencia;
 toRet.NivelItem= entidadeCopiar.NivelItem;
 toRet.Ovm= entidadeCopiar.Ovm;
 toRet.Deps= entidadeCopiar.Deps;
 toRet.Peps= entidadeCopiar.Peps;
 toRet.EtiquetaExpedicaoImpressa= entidadeCopiar.EtiquetaExpedicaoImpressa;
 toRet.UsarTimer= entidadeCopiar.UsarTimer;
 toRet.PermitirParcial= entidadeCopiar.PermitirParcial;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Pallet= entidadeCopiar.Pallet;
 toRet.NotaFiscalEmitida= entidadeCopiar.NotaFiscalEmitida;
 toRet.SituacaoConferenciaNf= entidadeCopiar.SituacaoConferenciaNf;
 toRet.PrecoTotal= entidadeCopiar.PrecoTotal;
 toRet.PrecoUnitario= entidadeCopiar.PrecoUnitario;
 toRet.EmissaoParcial= entidadeCopiar.EmissaoParcial;
 toRet.StatusPedido= entidadeCopiar.StatusPedido;
 toRet.ArmazenagemCliente= entidadeCopiar.ArmazenagemCliente;
 toRet.DescricaoCliente= entidadeCopiar.DescricaoCliente;
 toRet.CodigoCliente= entidadeCopiar.CodigoCliente;
 toRet.IdExternoClienteAccess= entidadeCopiar.IdExternoClienteAccess;
 toRet.CnpjPedido= entidadeCopiar.CnpjPedido;
 toRet.Cfop= entidadeCopiar.Cfop;
 toRet.NaturezaOperacao= entidadeCopiar.NaturezaOperacao;
 toRet.TipoOperacao= entidadeCopiar.TipoOperacao;
 toRet.NbmPedido= entidadeCopiar.NbmPedido;
 toRet.Frete= entidadeCopiar.Frete;
 toRet.NotaFiscal= entidadeCopiar.NotaFiscal;
 toRet.EtiquetaInterna= entidadeCopiar.EtiquetaInterna;
 toRet.SaldoConferencia= entidadeCopiar.SaldoConferencia;
 toRet.Cnc= entidadeCopiar.Cnc;
 toRet.CoordenadaX= entidadeCopiar.CoordenadaX;
 toRet.CoordenadaY= entidadeCopiar.CoordenadaY;
 toRet.EtiquetaInternaImpressa= entidadeCopiar.EtiquetaInternaImpressa;
 toRet.Saf= entidadeCopiar.Saf;
 toRet.Programador= entidadeCopiar.Programador;
 toRet.ConferenciaCustomizadaRealizada= entidadeCopiar.ConferenciaCustomizadaRealizada;
 toRet.ConferenciaCustomizadaRealizadaForcada= entidadeCopiar.ConferenciaCustomizadaRealizadaForcada;
 toRet.QtdEtiquetaExpVolume= entidadeCopiar.QtdEtiquetaExpVolume;
 toRet.DescricaoPt= entidadeCopiar.DescricaoPt;
 toRet.DescricaoEn= entidadeCopiar.DescricaoEn;
 toRet.DescricaoEs= entidadeCopiar.DescricaoEs;
 toRet.ImprimePackingList= entidadeCopiar.ImprimePackingList;
 toRet.TipoBaseboard= entidadeCopiar.TipoBaseboard;
 toRet.Altura= entidadeCopiar.Altura;
 toRet.Largura= entidadeCopiar.Largura;
 toRet.Comprimento= entidadeCopiar.Comprimento;
 toRet.TipoLigacao= entidadeCopiar.TipoLigacao;
 toRet.PackinglistKitImpresso= entidadeCopiar.PackinglistKitImpresso;
 toRet.Var1Nome= entidadeCopiar.Var1Nome;
 toRet.Var1Valor= entidadeCopiar.Var1Valor;
 toRet.Var2Nome= entidadeCopiar.Var2Nome;
 toRet.Var2Valor= entidadeCopiar.Var2Valor;
 toRet.Var3Nome= entidadeCopiar.Var3Nome;
 toRet.Var3Valor= entidadeCopiar.Var3Valor;
 toRet.Var4Nome= entidadeCopiar.Var4Nome;
 toRet.Var4Valor= entidadeCopiar.Var4Valor;
 toRet.DataEntrega= entidadeCopiar.DataEntrega;
 toRet.KitFantasia= entidadeCopiar.KitFantasia;
 toRet.PkKitTemp= entidadeCopiar.PkKitTemp;
 toRet.DataImpressaoOp= entidadeCopiar.DataImpressaoOp;
 toRet.TipoDocumento= entidadeCopiar.TipoDocumento;
 toRet.NumeroDocumento= entidadeCopiar.NumeroDocumento;
 toRet.RevisaoDesenho= entidadeCopiar.RevisaoDesenho;
 toRet.CodigoItemPai= entidadeCopiar.CodigoItemPai;
 toRet.OrdemProducaoImpressa= entidadeCopiar.OrdemProducaoImpressa;
 toRet.OrdemProducaoImpressaData= entidadeCopiar.OrdemProducaoImpressaData;
 toRet.VerOc= entidadeCopiar.VerOc;
 toRet.AcabamentoSuperficial= entidadeCopiar.AcabamentoSuperficial;
 toRet.ItemOriginalPedido= entidadeCopiar.ItemOriginalPedido;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.PedidoItem= entidadeCopiar.PedidoItem;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.DescItemPai= entidadeCopiar.DescItemPai;
 toRet.AcabItemPai= entidadeCopiar.AcabItemPai;
 toRet.ProdutoK= entidadeCopiar.ProdutoK;
 toRet.CompraMpGerado= entidadeCopiar.CompraMpGerado;
 toRet.CompraMpDataGeracao= entidadeCopiar.CompraMpDataGeracao;
 toRet.InformacoesEspeciais= entidadeCopiar.InformacoesEspeciais;
 toRet.VersaoEstruturaItem= entidadeCopiar.VersaoEstruturaItem;
 toRet.RastreamentoMaterial= entidadeCopiar.RastreamentoMaterial;
 toRet.ResponsavelFrete= entidadeCopiar.ResponsavelFrete;
 toRet.VolumeUnico= entidadeCopiar.VolumeUnico;
 toRet.OrderItemEtiquetaPai= entidadeCopiar.OrderItemEtiquetaPai;
 toRet.ModeloEtiquetaExpedicao= entidadeCopiar.ModeloEtiquetaExpedicao;
 toRet.PedidoItemLinhaPrincipalPedido= entidadeCopiar.PedidoItemLinhaPrincipalPedido;
 toRet.TipoAquisicaoProduto= entidadeCopiar.TipoAquisicaoProduto;
 toRet.UnidadeMedida= entidadeCopiar.UnidadeMedida;

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
       _orderNumberOriginal = OrderNumber;
       _orderNumberOriginalCommited = _orderNumberOriginal;
       _orderPosOriginal = OrderPos;
       _orderPosOriginalCommited = _orderPosOriginal;
       _codigoItemOriginal = CodigoItem;
       _codigoItemOriginalCommited = _codigoItemOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _tipoItemOriginal = TipoItem;
       _tipoItemOriginalCommited = _tipoItemOriginal;
       _dimensaoOriginal = Dimensao;
       _dimensaoOriginalCommited = _dimensaoOriginal;
       _ppsOriginal = Pps;
       _ppsOriginalCommited = _ppsOriginal;
       _qtdEtiquetasOriginal = QtdEtiquetas;
       _qtdEtiquetasOriginalCommited = _qtdEtiquetasOriginal;
       _etiquetaAgrupadaOriginal = EtiquetaAgrupada;
       _etiquetaAgrupadaOriginalCommited = _etiquetaAgrupadaOriginal;
       _cubagemOriginal = Cubagem;
       _cubagemOriginalCommited = _cubagemOriginal;
       _pesoOriginal = Peso;
       _pesoOriginalCommited = _pesoOriginal;
       _volumesOriginal = Volumes;
       _volumesOriginalCommited = _volumesOriginal;
       _saldoOriginal = Saldo;
       _saldoOriginalCommited = _saldoOriginal;
       _situacaoConferenciaOriginal = SituacaoConferencia;
       _situacaoConferenciaOriginalCommited = _situacaoConferenciaOriginal;
       _nivelItemOriginal = NivelItem;
       _nivelItemOriginalCommited = _nivelItemOriginal;
       _ovmOriginal = Ovm;
       _ovmOriginalCommited = _ovmOriginal;
       _depsOriginal = Deps;
       _depsOriginalCommited = _depsOriginal;
       _pepsOriginal = Peps;
       _pepsOriginalCommited = _pepsOriginal;
       _etiquetaExpedicaoImpressaOriginal = EtiquetaExpedicaoImpressa;
       _etiquetaExpedicaoImpressaOriginalCommited = _etiquetaExpedicaoImpressaOriginal;
       _usarTimerOriginal = UsarTimer;
       _usarTimerOriginalCommited = _usarTimerOriginal;
       _permitirParcialOriginal = PermitirParcial;
       _permitirParcialOriginalCommited = _permitirParcialOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _palletOriginal = Pallet;
       _palletOriginalCommited = _palletOriginal;
       _notaFiscalEmitidaOriginal = NotaFiscalEmitida;
       _notaFiscalEmitidaOriginalCommited = _notaFiscalEmitidaOriginal;
       _situacaoConferenciaNfOriginal = SituacaoConferenciaNf;
       _situacaoConferenciaNfOriginalCommited = _situacaoConferenciaNfOriginal;
       _precoTotalOriginal = PrecoTotal;
       _precoTotalOriginalCommited = _precoTotalOriginal;
       _precoUnitarioOriginal = PrecoUnitario;
       _precoUnitarioOriginalCommited = _precoUnitarioOriginal;
       _emissaoParcialOriginal = EmissaoParcial;
       _emissaoParcialOriginalCommited = _emissaoParcialOriginal;
       _statusPedidoOriginal = StatusPedido;
       _statusPedidoOriginalCommited = _statusPedidoOriginal;
       _armazenagemClienteOriginal = ArmazenagemCliente;
       _armazenagemClienteOriginalCommited = _armazenagemClienteOriginal;
       _descricaoClienteOriginal = DescricaoCliente;
       _descricaoClienteOriginalCommited = _descricaoClienteOriginal;
       _codigoClienteOriginal = CodigoCliente;
       _codigoClienteOriginalCommited = _codigoClienteOriginal;
       _idExternoClienteAccessOriginal = IdExternoClienteAccess;
       _idExternoClienteAccessOriginalCommited = _idExternoClienteAccessOriginal;
       _cnpjPedidoOriginal = CnpjPedido;
       _cnpjPedidoOriginalCommited = _cnpjPedidoOriginal;
       _cfopOriginal = Cfop;
       _cfopOriginalCommited = _cfopOriginal;
       _naturezaOperacaoOriginal = NaturezaOperacao;
       _naturezaOperacaoOriginalCommited = _naturezaOperacaoOriginal;
       _tipoOperacaoOriginal = TipoOperacao;
       _tipoOperacaoOriginalCommited = _tipoOperacaoOriginal;
       _nbmPedidoOriginal = NbmPedido;
       _nbmPedidoOriginalCommited = _nbmPedidoOriginal;
       _freteOriginal = Frete;
       _freteOriginalCommited = _freteOriginal;
       _notaFiscalOriginal = NotaFiscal;
       _notaFiscalOriginalCommited = _notaFiscalOriginal;
       _etiquetaInternaOriginal = EtiquetaInterna;
       _etiquetaInternaOriginalCommited = _etiquetaInternaOriginal;
       _saldoConferenciaOriginal = SaldoConferencia;
       _saldoConferenciaOriginalCommited = _saldoConferenciaOriginal;
       _cncOriginal = Cnc;
       _cncOriginalCommited = _cncOriginal;
       _coordenadaXOriginal = CoordenadaX;
       _coordenadaXOriginalCommited = _coordenadaXOriginal;
       _coordenadaYOriginal = CoordenadaY;
       _coordenadaYOriginalCommited = _coordenadaYOriginal;
       _etiquetaInternaImpressaOriginal = EtiquetaInternaImpressa;
       _etiquetaInternaImpressaOriginalCommited = _etiquetaInternaImpressaOriginal;
       _safOriginal = Saf;
       _safOriginalCommited = _safOriginal;
       _programadorOriginal = Programador;
       _programadorOriginalCommited = _programadorOriginal;
       _conferenciaCustomizadaRealizadaOriginal = ConferenciaCustomizadaRealizada;
       _conferenciaCustomizadaRealizadaOriginalCommited = _conferenciaCustomizadaRealizadaOriginal;
       _conferenciaCustomizadaRealizadaForcadaOriginal = ConferenciaCustomizadaRealizadaForcada;
       _conferenciaCustomizadaRealizadaForcadaOriginalCommited = _conferenciaCustomizadaRealizadaForcadaOriginal;
       _qtdEtiquetaExpVolumeOriginal = QtdEtiquetaExpVolume;
       _qtdEtiquetaExpVolumeOriginalCommited = _qtdEtiquetaExpVolumeOriginal;
       _descricaoPtOriginal = DescricaoPt;
       _descricaoPtOriginalCommited = _descricaoPtOriginal;
       _descricaoEnOriginal = DescricaoEn;
       _descricaoEnOriginalCommited = _descricaoEnOriginal;
       _descricaoEsOriginal = DescricaoEs;
       _descricaoEsOriginalCommited = _descricaoEsOriginal;
       _imprimePackingListOriginal = ImprimePackingList;
       _imprimePackingListOriginalCommited = _imprimePackingListOriginal;
       _tipoBaseboardOriginal = TipoBaseboard;
       _tipoBaseboardOriginalCommited = _tipoBaseboardOriginal;
       _alturaOriginal = Altura;
       _alturaOriginalCommited = _alturaOriginal;
       _larguraOriginal = Largura;
       _larguraOriginalCommited = _larguraOriginal;
       _comprimentoOriginal = Comprimento;
       _comprimentoOriginalCommited = _comprimentoOriginal;
       _tipoLigacaoOriginal = TipoLigacao;
       _tipoLigacaoOriginalCommited = _tipoLigacaoOriginal;
       _packinglistKitImpressoOriginal = PackinglistKitImpresso;
       _packinglistKitImpressoOriginalCommited = _packinglistKitImpressoOriginal;
       _var1NomeOriginal = Var1Nome;
       _var1NomeOriginalCommited = _var1NomeOriginal;
       _var1ValorOriginal = Var1Valor;
       _var1ValorOriginalCommited = _var1ValorOriginal;
       _var2NomeOriginal = Var2Nome;
       _var2NomeOriginalCommited = _var2NomeOriginal;
       _var2ValorOriginal = Var2Valor;
       _var2ValorOriginalCommited = _var2ValorOriginal;
       _var3NomeOriginal = Var3Nome;
       _var3NomeOriginalCommited = _var3NomeOriginal;
       _var3ValorOriginal = Var3Valor;
       _var3ValorOriginalCommited = _var3ValorOriginal;
       _var4NomeOriginal = Var4Nome;
       _var4NomeOriginalCommited = _var4NomeOriginal;
       _var4ValorOriginal = Var4Valor;
       _var4ValorOriginalCommited = _var4ValorOriginal;
       _dataEntregaOriginal = DataEntrega;
       _dataEntregaOriginalCommited = _dataEntregaOriginal;
       _kitFantasiaOriginal = KitFantasia;
       _kitFantasiaOriginalCommited = _kitFantasiaOriginal;
       _pkKitTempOriginal = PkKitTemp;
       _pkKitTempOriginalCommited = _pkKitTempOriginal;
       _dataImpressaoOpOriginal = DataImpressaoOp;
       _dataImpressaoOpOriginalCommited = _dataImpressaoOpOriginal;
       _tipoDocumentoOriginal = TipoDocumento;
       _tipoDocumentoOriginalCommited = _tipoDocumentoOriginal;
       _numeroDocumentoOriginal = NumeroDocumento;
       _numeroDocumentoOriginalCommited = _numeroDocumentoOriginal;
       _revisaoDesenhoOriginal = RevisaoDesenho;
       _revisaoDesenhoOriginalCommited = _revisaoDesenhoOriginal;
       _codigoItemPaiOriginal = CodigoItemPai;
       _codigoItemPaiOriginalCommited = _codigoItemPaiOriginal;
       _ordemProducaoImpressaOriginal = OrdemProducaoImpressa;
       _ordemProducaoImpressaOriginalCommited = _ordemProducaoImpressaOriginal;
       _ordemProducaoImpressaDataOriginal = OrdemProducaoImpressaData;
       _ordemProducaoImpressaDataOriginalCommited = _ordemProducaoImpressaDataOriginal;
       _verOcOriginal = VerOc;
       _verOcOriginalCommited = _verOcOriginal;
       _acabamentoSuperficialOriginal = AcabamentoSuperficial;
       _acabamentoSuperficialOriginalCommited = _acabamentoSuperficialOriginal;
       _itemOriginalPedidoOriginal = ItemOriginalPedido;
       _itemOriginalPedidoOriginalCommited = _itemOriginalPedidoOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _pedidoItemOriginal = PedidoItem;
       _pedidoItemOriginalCommited = _pedidoItemOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _descItemPaiOriginal = DescItemPai;
       _descItemPaiOriginalCommited = _descItemPaiOriginal;
       _acabItemPaiOriginal = AcabItemPai;
       _acabItemPaiOriginalCommited = _acabItemPaiOriginal;
       _produtoKOriginal = ProdutoK;
       _produtoKOriginalCommited = _produtoKOriginal;
       _compraMpGeradoOriginal = CompraMpGerado;
       _compraMpGeradoOriginalCommited = _compraMpGeradoOriginal;
       _compraMpDataGeracaoOriginal = CompraMpDataGeracao;
       _compraMpDataGeracaoOriginalCommited = _compraMpDataGeracaoOriginal;
       _informacoesEspeciaisOriginal = InformacoesEspeciais;
       _informacoesEspeciaisOriginalCommited = _informacoesEspeciaisOriginal;
       _versaoEstruturaItemOriginal = VersaoEstruturaItem;
       _versaoEstruturaItemOriginalCommited = _versaoEstruturaItemOriginal;
       _rastreamentoMaterialOriginal = RastreamentoMaterial;
       _rastreamentoMaterialOriginalCommited = _rastreamentoMaterialOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _responsavelFreteOriginal = ResponsavelFrete;
       _responsavelFreteOriginalCommited = _responsavelFreteOriginal;
       _volumeUnicoOriginal = VolumeUnico;
       _volumeUnicoOriginalCommited = _volumeUnicoOriginal;
       _orderItemEtiquetaPaiOriginal = OrderItemEtiquetaPai;
       _orderItemEtiquetaPaiOriginalCommited = _orderItemEtiquetaPaiOriginal;
       _modeloEtiquetaExpedicaoOriginal = ModeloEtiquetaExpedicao;
       _modeloEtiquetaExpedicaoOriginalCommited = _modeloEtiquetaExpedicaoOriginal;
       _pedidoItemLinhaPrincipalPedidoOriginal = PedidoItemLinhaPrincipalPedido;
       _pedidoItemLinhaPrincipalPedidoOriginalCommited = _pedidoItemLinhaPrincipalPedidoOriginal;
       _tipoAquisicaoProdutoOriginal = TipoAquisicaoProduto;
       _tipoAquisicaoProdutoOriginalCommited = _tipoAquisicaoProdutoOriginal;
       _unidadeMedidaOriginal = UnidadeMedida;
       _unidadeMedidaOriginalCommited = _unidadeMedidaOriginal;

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
       _orderNumberOriginalCommited = OrderNumber;
       _orderPosOriginalCommited = OrderPos;
       _codigoItemOriginalCommited = CodigoItem;
       _descricaoOriginalCommited = Descricao;
       _tipoItemOriginalCommited = TipoItem;
       _dimensaoOriginalCommited = Dimensao;
       _ppsOriginalCommited = Pps;
       _qtdEtiquetasOriginalCommited = QtdEtiquetas;
       _etiquetaAgrupadaOriginalCommited = EtiquetaAgrupada;
       _cubagemOriginalCommited = Cubagem;
       _pesoOriginalCommited = Peso;
       _volumesOriginalCommited = Volumes;
       _saldoOriginalCommited = Saldo;
       _situacaoConferenciaOriginalCommited = SituacaoConferencia;
       _nivelItemOriginalCommited = NivelItem;
       _ovmOriginalCommited = Ovm;
       _depsOriginalCommited = Deps;
       _pepsOriginalCommited = Peps;
       _etiquetaExpedicaoImpressaOriginalCommited = EtiquetaExpedicaoImpressa;
       _usarTimerOriginalCommited = UsarTimer;
       _permitirParcialOriginalCommited = PermitirParcial;
       _quantidadeOriginalCommited = Quantidade;
       _palletOriginalCommited = Pallet;
       _notaFiscalEmitidaOriginalCommited = NotaFiscalEmitida;
       _situacaoConferenciaNfOriginalCommited = SituacaoConferenciaNf;
       _precoTotalOriginalCommited = PrecoTotal;
       _precoUnitarioOriginalCommited = PrecoUnitario;
       _emissaoParcialOriginalCommited = EmissaoParcial;
       _statusPedidoOriginalCommited = StatusPedido;
       _armazenagemClienteOriginalCommited = ArmazenagemCliente;
       _descricaoClienteOriginalCommited = DescricaoCliente;
       _codigoClienteOriginalCommited = CodigoCliente;
       _idExternoClienteAccessOriginalCommited = IdExternoClienteAccess;
       _cnpjPedidoOriginalCommited = CnpjPedido;
       _cfopOriginalCommited = Cfop;
       _naturezaOperacaoOriginalCommited = NaturezaOperacao;
       _tipoOperacaoOriginalCommited = TipoOperacao;
       _nbmPedidoOriginalCommited = NbmPedido;
       _freteOriginalCommited = Frete;
       _notaFiscalOriginalCommited = NotaFiscal;
       _etiquetaInternaOriginalCommited = EtiquetaInterna;
       _saldoConferenciaOriginalCommited = SaldoConferencia;
       _cncOriginalCommited = Cnc;
       _coordenadaXOriginalCommited = CoordenadaX;
       _coordenadaYOriginalCommited = CoordenadaY;
       _etiquetaInternaImpressaOriginalCommited = EtiquetaInternaImpressa;
       _safOriginalCommited = Saf;
       _programadorOriginalCommited = Programador;
       _conferenciaCustomizadaRealizadaOriginalCommited = ConferenciaCustomizadaRealizada;
       _conferenciaCustomizadaRealizadaForcadaOriginalCommited = ConferenciaCustomizadaRealizadaForcada;
       _qtdEtiquetaExpVolumeOriginalCommited = QtdEtiquetaExpVolume;
       _descricaoPtOriginalCommited = DescricaoPt;
       _descricaoEnOriginalCommited = DescricaoEn;
       _descricaoEsOriginalCommited = DescricaoEs;
       _imprimePackingListOriginalCommited = ImprimePackingList;
       _tipoBaseboardOriginalCommited = TipoBaseboard;
       _alturaOriginalCommited = Altura;
       _larguraOriginalCommited = Largura;
       _comprimentoOriginalCommited = Comprimento;
       _tipoLigacaoOriginalCommited = TipoLigacao;
       _packinglistKitImpressoOriginalCommited = PackinglistKitImpresso;
       _var1NomeOriginalCommited = Var1Nome;
       _var1ValorOriginalCommited = Var1Valor;
       _var2NomeOriginalCommited = Var2Nome;
       _var2ValorOriginalCommited = Var2Valor;
       _var3NomeOriginalCommited = Var3Nome;
       _var3ValorOriginalCommited = Var3Valor;
       _var4NomeOriginalCommited = Var4Nome;
       _var4ValorOriginalCommited = Var4Valor;
       _dataEntregaOriginalCommited = DataEntrega;
       _kitFantasiaOriginalCommited = KitFantasia;
       _pkKitTempOriginalCommited = PkKitTemp;
       _dataImpressaoOpOriginalCommited = DataImpressaoOp;
       _tipoDocumentoOriginalCommited = TipoDocumento;
       _numeroDocumentoOriginalCommited = NumeroDocumento;
       _revisaoDesenhoOriginalCommited = RevisaoDesenho;
       _codigoItemPaiOriginalCommited = CodigoItemPai;
       _ordemProducaoImpressaOriginalCommited = OrdemProducaoImpressa;
       _ordemProducaoImpressaDataOriginalCommited = OrdemProducaoImpressaData;
       _verOcOriginalCommited = VerOc;
       _acabamentoSuperficialOriginalCommited = AcabamentoSuperficial;
       _itemOriginalPedidoOriginalCommited = ItemOriginalPedido;
       _clienteOriginalCommited = Cliente;
       _pedidoItemOriginalCommited = PedidoItem;
       _produtoOriginalCommited = Produto;
       _descItemPaiOriginalCommited = DescItemPai;
       _acabItemPaiOriginalCommited = AcabItemPai;
       _produtoKOriginalCommited = ProdutoK;
       _compraMpGeradoOriginalCommited = CompraMpGerado;
       _compraMpDataGeracaoOriginalCommited = CompraMpDataGeracao;
       _informacoesEspeciaisOriginalCommited = InformacoesEspeciais;
       _versaoEstruturaItemOriginalCommited = VersaoEstruturaItem;
       _rastreamentoMaterialOriginalCommited = RastreamentoMaterial;
       _versionOriginalCommited = Version;
       _responsavelFreteOriginalCommited = ResponsavelFrete;
       _volumeUnicoOriginalCommited = VolumeUnico;
       _orderItemEtiquetaPaiOriginalCommited = OrderItemEtiquetaPai;
       _modeloEtiquetaExpedicaoOriginalCommited = ModeloEtiquetaExpedicao;
       _pedidoItemLinhaPrincipalPedidoOriginalCommited = PedidoItemLinhaPrincipalPedido;
       _tipoAquisicaoProdutoOriginalCommited = TipoAquisicaoProduto;
       _unidadeMedidaOriginalCommited = UnidadeMedida;

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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionAtendimentoClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionAtendimentoClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAtendimentoClassOrderItemEtiquetaRemovidos = new List<Entidades.AtendimentoClass>();
                  }
                  _collectionAtendimentoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionAtendimentoClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionAtendimentoClassOrderItemEtiquetaChanged = false;
                  _valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos = new List<Entidades.OrdemProducaoPedidoClass>();
                  }
                  _collectionOrdemProducaoPedidoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrdemProducaoPedidoClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged = false;
                  _valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiOriginal= (from a in _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPai select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged = false;
                  _valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                  }
                  _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged = false;
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaNfClass>();
                  }
                  _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged = false;
                  _valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos = new List<Entidades.PedidoItemConfiguradoMaterialClass>();
                  }
                  _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaOriginal= (from a in _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged = false;
                  _valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged = false;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos != null) 
                  {
                     _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos = new List<Entidades.PlanoCorteItemPedidoClass>();
                  }
                  _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaOriginal= (from a in _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiqueta select a.ID).ToList();
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged = false;
                  _valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged = false;
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
               OrderNumber=_orderNumberOriginal;
               _orderNumberOriginalCommited=_orderNumberOriginal;
               OrderPos=_orderPosOriginal;
               _orderPosOriginalCommited=_orderPosOriginal;
               CodigoItem=_codigoItemOriginal;
               _codigoItemOriginalCommited=_codigoItemOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               TipoItem=_tipoItemOriginal;
               _tipoItemOriginalCommited=_tipoItemOriginal;
               Dimensao=_dimensaoOriginal;
               _dimensaoOriginalCommited=_dimensaoOriginal;
               Pps=_ppsOriginal;
               _ppsOriginalCommited=_ppsOriginal;
               QtdEtiquetas=_qtdEtiquetasOriginal;
               _qtdEtiquetasOriginalCommited=_qtdEtiquetasOriginal;
               EtiquetaAgrupada=_etiquetaAgrupadaOriginal;
               _etiquetaAgrupadaOriginalCommited=_etiquetaAgrupadaOriginal;
               Cubagem=_cubagemOriginal;
               _cubagemOriginalCommited=_cubagemOriginal;
               Peso=_pesoOriginal;
               _pesoOriginalCommited=_pesoOriginal;
               Volumes=_volumesOriginal;
               _volumesOriginalCommited=_volumesOriginal;
               Saldo=_saldoOriginal;
               _saldoOriginalCommited=_saldoOriginal;
               SituacaoConferencia=_situacaoConferenciaOriginal;
               _situacaoConferenciaOriginalCommited=_situacaoConferenciaOriginal;
               NivelItem=_nivelItemOriginal;
               _nivelItemOriginalCommited=_nivelItemOriginal;
               Ovm=_ovmOriginal;
               _ovmOriginalCommited=_ovmOriginal;
               Deps=_depsOriginal;
               _depsOriginalCommited=_depsOriginal;
               Peps=_pepsOriginal;
               _pepsOriginalCommited=_pepsOriginal;
               EtiquetaExpedicaoImpressa=_etiquetaExpedicaoImpressaOriginal;
               _etiquetaExpedicaoImpressaOriginalCommited=_etiquetaExpedicaoImpressaOriginal;
               UsarTimer=_usarTimerOriginal;
               _usarTimerOriginalCommited=_usarTimerOriginal;
               PermitirParcial=_permitirParcialOriginal;
               _permitirParcialOriginalCommited=_permitirParcialOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Pallet=_palletOriginal;
               _palletOriginalCommited=_palletOriginal;
               NotaFiscalEmitida=_notaFiscalEmitidaOriginal;
               _notaFiscalEmitidaOriginalCommited=_notaFiscalEmitidaOriginal;
               SituacaoConferenciaNf=_situacaoConferenciaNfOriginal;
               _situacaoConferenciaNfOriginalCommited=_situacaoConferenciaNfOriginal;
               PrecoTotal=_precoTotalOriginal;
               _precoTotalOriginalCommited=_precoTotalOriginal;
               PrecoUnitario=_precoUnitarioOriginal;
               _precoUnitarioOriginalCommited=_precoUnitarioOriginal;
               EmissaoParcial=_emissaoParcialOriginal;
               _emissaoParcialOriginalCommited=_emissaoParcialOriginal;
               StatusPedido=_statusPedidoOriginal;
               _statusPedidoOriginalCommited=_statusPedidoOriginal;
               ArmazenagemCliente=_armazenagemClienteOriginal;
               _armazenagemClienteOriginalCommited=_armazenagemClienteOriginal;
               DescricaoCliente=_descricaoClienteOriginal;
               _descricaoClienteOriginalCommited=_descricaoClienteOriginal;
               CodigoCliente=_codigoClienteOriginal;
               _codigoClienteOriginalCommited=_codigoClienteOriginal;
               IdExternoClienteAccess=_idExternoClienteAccessOriginal;
               _idExternoClienteAccessOriginalCommited=_idExternoClienteAccessOriginal;
               CnpjPedido=_cnpjPedidoOriginal;
               _cnpjPedidoOriginalCommited=_cnpjPedidoOriginal;
               Cfop=_cfopOriginal;
               _cfopOriginalCommited=_cfopOriginal;
               NaturezaOperacao=_naturezaOperacaoOriginal;
               _naturezaOperacaoOriginalCommited=_naturezaOperacaoOriginal;
               TipoOperacao=_tipoOperacaoOriginal;
               _tipoOperacaoOriginalCommited=_tipoOperacaoOriginal;
               NbmPedido=_nbmPedidoOriginal;
               _nbmPedidoOriginalCommited=_nbmPedidoOriginal;
               Frete=_freteOriginal;
               _freteOriginalCommited=_freteOriginal;
               NotaFiscal=_notaFiscalOriginal;
               _notaFiscalOriginalCommited=_notaFiscalOriginal;
               EtiquetaInterna=_etiquetaInternaOriginal;
               _etiquetaInternaOriginalCommited=_etiquetaInternaOriginal;
               SaldoConferencia=_saldoConferenciaOriginal;
               _saldoConferenciaOriginalCommited=_saldoConferenciaOriginal;
               Cnc=_cncOriginal;
               _cncOriginalCommited=_cncOriginal;
               CoordenadaX=_coordenadaXOriginal;
               _coordenadaXOriginalCommited=_coordenadaXOriginal;
               CoordenadaY=_coordenadaYOriginal;
               _coordenadaYOriginalCommited=_coordenadaYOriginal;
               EtiquetaInternaImpressa=_etiquetaInternaImpressaOriginal;
               _etiquetaInternaImpressaOriginalCommited=_etiquetaInternaImpressaOriginal;
               Saf=_safOriginal;
               _safOriginalCommited=_safOriginal;
               Programador=_programadorOriginal;
               _programadorOriginalCommited=_programadorOriginal;
               ConferenciaCustomizadaRealizada=_conferenciaCustomizadaRealizadaOriginal;
               _conferenciaCustomizadaRealizadaOriginalCommited=_conferenciaCustomizadaRealizadaOriginal;
               ConferenciaCustomizadaRealizadaForcada=_conferenciaCustomizadaRealizadaForcadaOriginal;
               _conferenciaCustomizadaRealizadaForcadaOriginalCommited=_conferenciaCustomizadaRealizadaForcadaOriginal;
               QtdEtiquetaExpVolume=_qtdEtiquetaExpVolumeOriginal;
               _qtdEtiquetaExpVolumeOriginalCommited=_qtdEtiquetaExpVolumeOriginal;
               DescricaoPt=_descricaoPtOriginal;
               _descricaoPtOriginalCommited=_descricaoPtOriginal;
               DescricaoEn=_descricaoEnOriginal;
               _descricaoEnOriginalCommited=_descricaoEnOriginal;
               DescricaoEs=_descricaoEsOriginal;
               _descricaoEsOriginalCommited=_descricaoEsOriginal;
               ImprimePackingList=_imprimePackingListOriginal;
               _imprimePackingListOriginalCommited=_imprimePackingListOriginal;
               TipoBaseboard=_tipoBaseboardOriginal;
               _tipoBaseboardOriginalCommited=_tipoBaseboardOriginal;
               Altura=_alturaOriginal;
               _alturaOriginalCommited=_alturaOriginal;
               Largura=_larguraOriginal;
               _larguraOriginalCommited=_larguraOriginal;
               Comprimento=_comprimentoOriginal;
               _comprimentoOriginalCommited=_comprimentoOriginal;
               TipoLigacao=_tipoLigacaoOriginal;
               _tipoLigacaoOriginalCommited=_tipoLigacaoOriginal;
               PackinglistKitImpresso=_packinglistKitImpressoOriginal;
               _packinglistKitImpressoOriginalCommited=_packinglistKitImpressoOriginal;
               Var1Nome=_var1NomeOriginal;
               _var1NomeOriginalCommited=_var1NomeOriginal;
               Var1Valor=_var1ValorOriginal;
               _var1ValorOriginalCommited=_var1ValorOriginal;
               Var2Nome=_var2NomeOriginal;
               _var2NomeOriginalCommited=_var2NomeOriginal;
               Var2Valor=_var2ValorOriginal;
               _var2ValorOriginalCommited=_var2ValorOriginal;
               Var3Nome=_var3NomeOriginal;
               _var3NomeOriginalCommited=_var3NomeOriginal;
               Var3Valor=_var3ValorOriginal;
               _var3ValorOriginalCommited=_var3ValorOriginal;
               Var4Nome=_var4NomeOriginal;
               _var4NomeOriginalCommited=_var4NomeOriginal;
               Var4Valor=_var4ValorOriginal;
               _var4ValorOriginalCommited=_var4ValorOriginal;
               DataEntrega=_dataEntregaOriginal;
               _dataEntregaOriginalCommited=_dataEntregaOriginal;
               KitFantasia=_kitFantasiaOriginal;
               _kitFantasiaOriginalCommited=_kitFantasiaOriginal;
               PkKitTemp=_pkKitTempOriginal;
               _pkKitTempOriginalCommited=_pkKitTempOriginal;
               DataImpressaoOp=_dataImpressaoOpOriginal;
               _dataImpressaoOpOriginalCommited=_dataImpressaoOpOriginal;
               TipoDocumento=_tipoDocumentoOriginal;
               _tipoDocumentoOriginalCommited=_tipoDocumentoOriginal;
               NumeroDocumento=_numeroDocumentoOriginal;
               _numeroDocumentoOriginalCommited=_numeroDocumentoOriginal;
               RevisaoDesenho=_revisaoDesenhoOriginal;
               _revisaoDesenhoOriginalCommited=_revisaoDesenhoOriginal;
               CodigoItemPai=_codigoItemPaiOriginal;
               _codigoItemPaiOriginalCommited=_codigoItemPaiOriginal;
               OrdemProducaoImpressa=_ordemProducaoImpressaOriginal;
               _ordemProducaoImpressaOriginalCommited=_ordemProducaoImpressaOriginal;
               OrdemProducaoImpressaData=_ordemProducaoImpressaDataOriginal;
               _ordemProducaoImpressaDataOriginalCommited=_ordemProducaoImpressaDataOriginal;
               VerOc=_verOcOriginal;
               _verOcOriginalCommited=_verOcOriginal;
               AcabamentoSuperficial=_acabamentoSuperficialOriginal;
               _acabamentoSuperficialOriginalCommited=_acabamentoSuperficialOriginal;
               ItemOriginalPedido=_itemOriginalPedidoOriginal;
               _itemOriginalPedidoOriginalCommited=_itemOriginalPedidoOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               PedidoItem=_pedidoItemOriginal;
               _pedidoItemOriginalCommited=_pedidoItemOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               DescItemPai=_descItemPaiOriginal;
               _descItemPaiOriginalCommited=_descItemPaiOriginal;
               AcabItemPai=_acabItemPaiOriginal;
               _acabItemPaiOriginalCommited=_acabItemPaiOriginal;
               ProdutoK=_produtoKOriginal;
               _produtoKOriginalCommited=_produtoKOriginal;
               CompraMpGerado=_compraMpGeradoOriginal;
               _compraMpGeradoOriginalCommited=_compraMpGeradoOriginal;
               CompraMpDataGeracao=_compraMpDataGeracaoOriginal;
               _compraMpDataGeracaoOriginalCommited=_compraMpDataGeracaoOriginal;
               InformacoesEspeciais=_informacoesEspeciaisOriginal;
               _informacoesEspeciaisOriginalCommited=_informacoesEspeciaisOriginal;
               VersaoEstruturaItem=_versaoEstruturaItemOriginal;
               _versaoEstruturaItemOriginalCommited=_versaoEstruturaItemOriginal;
               RastreamentoMaterial=_rastreamentoMaterialOriginal;
               _rastreamentoMaterialOriginalCommited=_rastreamentoMaterialOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ResponsavelFrete=_responsavelFreteOriginal;
               _responsavelFreteOriginalCommited=_responsavelFreteOriginal;
               VolumeUnico=_volumeUnicoOriginal;
               _volumeUnicoOriginalCommited=_volumeUnicoOriginal;
               OrderItemEtiquetaPai=_orderItemEtiquetaPaiOriginal;
               _orderItemEtiquetaPaiOriginalCommited=_orderItemEtiquetaPaiOriginal;
               ModeloEtiquetaExpedicao=_modeloEtiquetaExpedicaoOriginal;
               _modeloEtiquetaExpedicaoOriginalCommited=_modeloEtiquetaExpedicaoOriginal;
               PedidoItemLinhaPrincipalPedido=_pedidoItemLinhaPrincipalPedidoOriginal;
               _pedidoItemLinhaPrincipalPedidoOriginalCommited=_pedidoItemLinhaPrincipalPedidoOriginal;
               TipoAquisicaoProduto=_tipoAquisicaoProdutoOriginal;
               _tipoAquisicaoProdutoOriginalCommited=_tipoAquisicaoProdutoOriginal;
               UnidadeMedida=_unidadeMedidaOriginal;
               _unidadeMedidaOriginalCommited=_unidadeMedidaOriginal;
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  CollectionAtendimentoClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionAtendimentoClassOrderItemEtiquetaOriginal)
                  {
                    CollectionAtendimentoClassOrderItemEtiqueta.Add(Entidades.AtendimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAtendimentoClassOrderItemEtiquetaRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionOrdemProducaoPedidoClassOrderItemEtiquetaOriginal)
                  {
                    CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Add(Entidades.OrdemProducaoPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoPedidoClassOrderItemEtiquetaRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiOriginal)
                  {
                    CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassOrderItemEtiquetaPaiRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaOriginal)
                  {
                    CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Add(Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaOriginal)
                  {
                    CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Add(Entidades.OrderItemEtiquetaConferenciaNfClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaOriginal)
                  {
                    CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Add(Entidades.PedidoItemConfiguradoMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaRemovidos.Clear();
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta.Clear();
                  foreach(int item in _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaOriginal)
                  {
                    CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta.Add(Entidades.PlanoCorteItemPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPlanoCorteItemPedidoClassOrderItemEtiquetaRemovidos.Clear();
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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionAtendimentoClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionAtendimentoClassOrderItemEtiqueta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta.Any(item => item.IsDirty());
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
       dirty = _orderNumberOriginal != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginal != OrderPos;
      if (dirty) return true;
       dirty = _codigoItemOriginal != CodigoItem;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _tipoItemOriginal != TipoItem;
      if (dirty) return true;
       dirty = _dimensaoOriginal != Dimensao;
      if (dirty) return true;
       dirty = _ppsOriginal != Pps;
      if (dirty) return true;
       dirty = _qtdEtiquetasOriginal != QtdEtiquetas;
      if (dirty) return true;
       dirty = _etiquetaAgrupadaOriginal != EtiquetaAgrupada;
      if (dirty) return true;
       dirty = _cubagemOriginal != Cubagem;
      if (dirty) return true;
       dirty = _pesoOriginal != Peso;
      if (dirty) return true;
       dirty = _volumesOriginal != Volumes;
      if (dirty) return true;
       dirty = _saldoOriginal != Saldo;
      if (dirty) return true;
       dirty = _situacaoConferenciaOriginal != SituacaoConferencia;
      if (dirty) return true;
       dirty = _nivelItemOriginal != NivelItem;
      if (dirty) return true;
       dirty = _ovmOriginal != Ovm;
      if (dirty) return true;
       dirty = _depsOriginal != Deps;
      if (dirty) return true;
       dirty = _pepsOriginal != Peps;
      if (dirty) return true;
       dirty = _etiquetaExpedicaoImpressaOriginal != EtiquetaExpedicaoImpressa;
      if (dirty) return true;
       dirty = _usarTimerOriginal != UsarTimer;
      if (dirty) return true;
       dirty = _permitirParcialOriginal != PermitirParcial;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _palletOriginal != Pallet;
      if (dirty) return true;
       dirty = _notaFiscalEmitidaOriginal != NotaFiscalEmitida;
      if (dirty) return true;
       dirty = _situacaoConferenciaNfOriginal != SituacaoConferenciaNf;
      if (dirty) return true;
       dirty = _precoTotalOriginal != PrecoTotal;
      if (dirty) return true;
       dirty = _precoUnitarioOriginal != PrecoUnitario;
      if (dirty) return true;
       dirty = _emissaoParcialOriginal != EmissaoParcial;
      if (dirty) return true;
       dirty = _statusPedidoOriginal != StatusPedido;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginal != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _descricaoClienteOriginal != DescricaoCliente;
      if (dirty) return true;
       dirty = _codigoClienteOriginal != CodigoCliente;
      if (dirty) return true;
       dirty = _idExternoClienteAccessOriginal != IdExternoClienteAccess;
      if (dirty) return true;
       dirty = _cnpjPedidoOriginal != CnpjPedido;
      if (dirty) return true;
       dirty = _cfopOriginal != Cfop;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginal != NaturezaOperacao;
      if (dirty) return true;
       dirty = _tipoOperacaoOriginal != TipoOperacao;
      if (dirty) return true;
       dirty = _nbmPedidoOriginal != NbmPedido;
      if (dirty) return true;
       dirty = _freteOriginal != Frete;
      if (dirty) return true;
       dirty = _notaFiscalOriginal != NotaFiscal;
      if (dirty) return true;
       dirty = _etiquetaInternaOriginal != EtiquetaInterna;
      if (dirty) return true;
       dirty = _saldoConferenciaOriginal != SaldoConferencia;
      if (dirty) return true;
       dirty = _cncOriginal != Cnc;
      if (dirty) return true;
       dirty = _coordenadaXOriginal != CoordenadaX;
      if (dirty) return true;
       dirty = _coordenadaYOriginal != CoordenadaY;
      if (dirty) return true;
       dirty = _etiquetaInternaImpressaOriginal != EtiquetaInternaImpressa;
      if (dirty) return true;
       dirty = _safOriginal != Saf;
      if (dirty) return true;
       dirty = _programadorOriginal != Programador;
      if (dirty) return true;
       dirty = _conferenciaCustomizadaRealizadaOriginal != ConferenciaCustomizadaRealizada;
      if (dirty) return true;
       dirty = _conferenciaCustomizadaRealizadaForcadaOriginal != ConferenciaCustomizadaRealizadaForcada;
      if (dirty) return true;
       dirty = _qtdEtiquetaExpVolumeOriginal != QtdEtiquetaExpVolume;
      if (dirty) return true;
       dirty = _descricaoPtOriginal != DescricaoPt;
      if (dirty) return true;
       dirty = _descricaoEnOriginal != DescricaoEn;
      if (dirty) return true;
       dirty = _descricaoEsOriginal != DescricaoEs;
      if (dirty) return true;
       dirty = _imprimePackingListOriginal != ImprimePackingList;
      if (dirty) return true;
       dirty = _tipoBaseboardOriginal != TipoBaseboard;
      if (dirty) return true;
       dirty = _alturaOriginal != Altura;
      if (dirty) return true;
       dirty = _larguraOriginal != Largura;
      if (dirty) return true;
       dirty = _comprimentoOriginal != Comprimento;
      if (dirty) return true;
       dirty = _tipoLigacaoOriginal != TipoLigacao;
      if (dirty) return true;
       dirty = _packinglistKitImpressoOriginal != PackinglistKitImpresso;
      if (dirty) return true;
       dirty = _var1NomeOriginal != Var1Nome;
      if (dirty) return true;
       dirty = _var1ValorOriginal != Var1Valor;
      if (dirty) return true;
       dirty = _var2NomeOriginal != Var2Nome;
      if (dirty) return true;
       dirty = _var2ValorOriginal != Var2Valor;
      if (dirty) return true;
       dirty = _var3NomeOriginal != Var3Nome;
      if (dirty) return true;
       dirty = _var3ValorOriginal != Var3Valor;
      if (dirty) return true;
       dirty = _var4NomeOriginal != Var4Nome;
      if (dirty) return true;
       dirty = _var4ValorOriginal != Var4Valor;
      if (dirty) return true;
       dirty = _dataEntregaOriginal != DataEntrega;
      if (dirty) return true;
       dirty = _kitFantasiaOriginal != KitFantasia;
      if (dirty) return true;
       dirty = _pkKitTempOriginal != PkKitTemp;
      if (dirty) return true;
       dirty = _dataImpressaoOpOriginal != DataImpressaoOp;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginal != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginal != NumeroDocumento;
      if (dirty) return true;
       dirty = _revisaoDesenhoOriginal != RevisaoDesenho;
      if (dirty) return true;
       dirty = _codigoItemPaiOriginal != CodigoItemPai;
      if (dirty) return true;
       dirty = _ordemProducaoImpressaOriginal != OrdemProducaoImpressa;
      if (dirty) return true;
       dirty = _ordemProducaoImpressaDataOriginal != OrdemProducaoImpressaData;
      if (dirty) return true;
       dirty = _verOcOriginal != VerOc;
      if (dirty) return true;
       dirty = _acabamentoSuperficialOriginal != AcabamentoSuperficial;
      if (dirty) return true;
       dirty = _itemOriginalPedidoOriginal != ItemOriginalPedido;
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
       if (_pedidoItemOriginal!=null)
       {
          dirty = !_pedidoItemOriginal.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
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
       dirty = _descItemPaiOriginal != DescItemPai;
      if (dirty) return true;
       dirty = _acabItemPaiOriginal != AcabItemPai;
      if (dirty) return true;
       if (_produtoKOriginal!=null)
       {
          dirty = !_produtoKOriginal.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       dirty = _compraMpGeradoOriginal != CompraMpGerado;
      if (dirty) return true;
       dirty = _compraMpDataGeracaoOriginal != CompraMpDataGeracao;
      if (dirty) return true;
       dirty = _informacoesEspeciaisOriginal != InformacoesEspeciais;
      if (dirty) return true;
       dirty = _versaoEstruturaItemOriginal != VersaoEstruturaItem;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginal != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _responsavelFreteOriginal != ResponsavelFrete;
      if (dirty) return true;
       dirty = _volumeUnicoOriginal != VolumeUnico;
      if (dirty) return true;
       if (_orderItemEtiquetaPaiOriginal!=null)
       {
          dirty = !_orderItemEtiquetaPaiOriginal.Equals(OrderItemEtiquetaPai);
       }
       else
       {
            dirty = OrderItemEtiquetaPai != null;
       }
      if (dirty) return true;
       if (_modeloEtiquetaExpedicaoOriginal!=null)
       {
          dirty = !_modeloEtiquetaExpedicaoOriginal.Equals(ModeloEtiquetaExpedicao);
       }
       else
       {
            dirty = ModeloEtiquetaExpedicao != null;
       }
      if (dirty) return true;
       if (_pedidoItemLinhaPrincipalPedidoOriginal!=null)
       {
          dirty = !_pedidoItemLinhaPrincipalPedidoOriginal.Equals(PedidoItemLinhaPrincipalPedido);
       }
       else
       {
            dirty = PedidoItemLinhaPrincipalPedido != null;
       }
      if (dirty) return true;
       dirty = _tipoAquisicaoProdutoOriginal != TipoAquisicaoProduto;
      if (dirty) return true;
       if (_unidadeMedidaOriginal!=null)
       {
          dirty = !_unidadeMedidaOriginal.Equals(UnidadeMedida);
       }
       else
       {
            dirty = UnidadeMedida != null;
       }

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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionAtendimentoClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionAtendimentoClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoPedidoClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                   tempRet = CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta.Any(item => item.IsDirtyCommited());
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
       dirty = _orderNumberOriginalCommited != OrderNumber;
      if (dirty) return true;
       dirty = _orderPosOriginalCommited != OrderPos;
      if (dirty) return true;
       dirty = _codigoItemOriginalCommited != CodigoItem;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _tipoItemOriginalCommited != TipoItem;
      if (dirty) return true;
       dirty = _dimensaoOriginalCommited != Dimensao;
      if (dirty) return true;
       dirty = _ppsOriginalCommited != Pps;
      if (dirty) return true;
       dirty = _qtdEtiquetasOriginalCommited != QtdEtiquetas;
      if (dirty) return true;
       dirty = _etiquetaAgrupadaOriginalCommited != EtiquetaAgrupada;
      if (dirty) return true;
       dirty = _cubagemOriginalCommited != Cubagem;
      if (dirty) return true;
       dirty = _pesoOriginalCommited != Peso;
      if (dirty) return true;
       dirty = _volumesOriginalCommited != Volumes;
      if (dirty) return true;
       dirty = _saldoOriginalCommited != Saldo;
      if (dirty) return true;
       dirty = _situacaoConferenciaOriginalCommited != SituacaoConferencia;
      if (dirty) return true;
       dirty = _nivelItemOriginalCommited != NivelItem;
      if (dirty) return true;
       dirty = _ovmOriginalCommited != Ovm;
      if (dirty) return true;
       dirty = _depsOriginalCommited != Deps;
      if (dirty) return true;
       dirty = _pepsOriginalCommited != Peps;
      if (dirty) return true;
       dirty = _etiquetaExpedicaoImpressaOriginalCommited != EtiquetaExpedicaoImpressa;
      if (dirty) return true;
       dirty = _usarTimerOriginalCommited != UsarTimer;
      if (dirty) return true;
       dirty = _permitirParcialOriginalCommited != PermitirParcial;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _palletOriginalCommited != Pallet;
      if (dirty) return true;
       dirty = _notaFiscalEmitidaOriginalCommited != NotaFiscalEmitida;
      if (dirty) return true;
       dirty = _situacaoConferenciaNfOriginalCommited != SituacaoConferenciaNf;
      if (dirty) return true;
       dirty = _precoTotalOriginalCommited != PrecoTotal;
      if (dirty) return true;
       dirty = _precoUnitarioOriginalCommited != PrecoUnitario;
      if (dirty) return true;
       dirty = _emissaoParcialOriginalCommited != EmissaoParcial;
      if (dirty) return true;
       dirty = _statusPedidoOriginalCommited != StatusPedido;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginalCommited != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _descricaoClienteOriginalCommited != DescricaoCliente;
      if (dirty) return true;
       dirty = _codigoClienteOriginalCommited != CodigoCliente;
      if (dirty) return true;
       dirty = _idExternoClienteAccessOriginalCommited != IdExternoClienteAccess;
      if (dirty) return true;
       dirty = _cnpjPedidoOriginalCommited != CnpjPedido;
      if (dirty) return true;
       dirty = _cfopOriginalCommited != Cfop;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginalCommited != NaturezaOperacao;
      if (dirty) return true;
       dirty = _tipoOperacaoOriginalCommited != TipoOperacao;
      if (dirty) return true;
       dirty = _nbmPedidoOriginalCommited != NbmPedido;
      if (dirty) return true;
       dirty = _freteOriginalCommited != Frete;
      if (dirty) return true;
       dirty = _notaFiscalOriginalCommited != NotaFiscal;
      if (dirty) return true;
       dirty = _etiquetaInternaOriginalCommited != EtiquetaInterna;
      if (dirty) return true;
       dirty = _saldoConferenciaOriginalCommited != SaldoConferencia;
      if (dirty) return true;
       dirty = _cncOriginalCommited != Cnc;
      if (dirty) return true;
       dirty = _coordenadaXOriginalCommited != CoordenadaX;
      if (dirty) return true;
       dirty = _coordenadaYOriginalCommited != CoordenadaY;
      if (dirty) return true;
       dirty = _etiquetaInternaImpressaOriginalCommited != EtiquetaInternaImpressa;
      if (dirty) return true;
       dirty = _safOriginalCommited != Saf;
      if (dirty) return true;
       dirty = _programadorOriginalCommited != Programador;
      if (dirty) return true;
       dirty = _conferenciaCustomizadaRealizadaOriginalCommited != ConferenciaCustomizadaRealizada;
      if (dirty) return true;
       dirty = _conferenciaCustomizadaRealizadaForcadaOriginalCommited != ConferenciaCustomizadaRealizadaForcada;
      if (dirty) return true;
       dirty = _qtdEtiquetaExpVolumeOriginalCommited != QtdEtiquetaExpVolume;
      if (dirty) return true;
       dirty = _descricaoPtOriginalCommited != DescricaoPt;
      if (dirty) return true;
       dirty = _descricaoEnOriginalCommited != DescricaoEn;
      if (dirty) return true;
       dirty = _descricaoEsOriginalCommited != DescricaoEs;
      if (dirty) return true;
       dirty = _imprimePackingListOriginalCommited != ImprimePackingList;
      if (dirty) return true;
       dirty = _tipoBaseboardOriginalCommited != TipoBaseboard;
      if (dirty) return true;
       dirty = _alturaOriginalCommited != Altura;
      if (dirty) return true;
       dirty = _larguraOriginalCommited != Largura;
      if (dirty) return true;
       dirty = _comprimentoOriginalCommited != Comprimento;
      if (dirty) return true;
       dirty = _tipoLigacaoOriginalCommited != TipoLigacao;
      if (dirty) return true;
       dirty = _packinglistKitImpressoOriginalCommited != PackinglistKitImpresso;
      if (dirty) return true;
       dirty = _var1NomeOriginalCommited != Var1Nome;
      if (dirty) return true;
       dirty = _var1ValorOriginalCommited != Var1Valor;
      if (dirty) return true;
       dirty = _var2NomeOriginalCommited != Var2Nome;
      if (dirty) return true;
       dirty = _var2ValorOriginalCommited != Var2Valor;
      if (dirty) return true;
       dirty = _var3NomeOriginalCommited != Var3Nome;
      if (dirty) return true;
       dirty = _var3ValorOriginalCommited != Var3Valor;
      if (dirty) return true;
       dirty = _var4NomeOriginalCommited != Var4Nome;
      if (dirty) return true;
       dirty = _var4ValorOriginalCommited != Var4Valor;
      if (dirty) return true;
       dirty = _dataEntregaOriginalCommited != DataEntrega;
      if (dirty) return true;
       dirty = _kitFantasiaOriginalCommited != KitFantasia;
      if (dirty) return true;
       dirty = _pkKitTempOriginalCommited != PkKitTemp;
      if (dirty) return true;
       dirty = _dataImpressaoOpOriginalCommited != DataImpressaoOp;
      if (dirty) return true;
       dirty = _tipoDocumentoOriginalCommited != TipoDocumento;
      if (dirty) return true;
       dirty = _numeroDocumentoOriginalCommited != NumeroDocumento;
      if (dirty) return true;
       dirty = _revisaoDesenhoOriginalCommited != RevisaoDesenho;
      if (dirty) return true;
       dirty = _codigoItemPaiOriginalCommited != CodigoItemPai;
      if (dirty) return true;
       dirty = _ordemProducaoImpressaOriginalCommited != OrdemProducaoImpressa;
      if (dirty) return true;
       dirty = _ordemProducaoImpressaDataOriginalCommited != OrdemProducaoImpressaData;
      if (dirty) return true;
       dirty = _verOcOriginalCommited != VerOc;
      if (dirty) return true;
       dirty = _acabamentoSuperficialOriginalCommited != AcabamentoSuperficial;
      if (dirty) return true;
       dirty = _itemOriginalPedidoOriginalCommited != ItemOriginalPedido;
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
       if (_pedidoItemOriginalCommited!=null)
       {
          dirty = !_pedidoItemOriginalCommited.Equals(PedidoItem);
       }
       else
       {
            dirty = PedidoItem != null;
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
       dirty = _descItemPaiOriginalCommited != DescItemPai;
      if (dirty) return true;
       dirty = _acabItemPaiOriginalCommited != AcabItemPai;
      if (dirty) return true;
       if (_produtoKOriginalCommited!=null)
       {
          dirty = !_produtoKOriginalCommited.Equals(ProdutoK);
       }
       else
       {
            dirty = ProdutoK != null;
       }
      if (dirty) return true;
       dirty = _compraMpGeradoOriginalCommited != CompraMpGerado;
      if (dirty) return true;
       dirty = _compraMpDataGeracaoOriginalCommited != CompraMpDataGeracao;
      if (dirty) return true;
       dirty = _informacoesEspeciaisOriginalCommited != InformacoesEspeciais;
      if (dirty) return true;
       dirty = _versaoEstruturaItemOriginalCommited != VersaoEstruturaItem;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginalCommited != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _responsavelFreteOriginalCommited != ResponsavelFrete;
      if (dirty) return true;
       dirty = _volumeUnicoOriginalCommited != VolumeUnico;
      if (dirty) return true;
       if (_orderItemEtiquetaPaiOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaPaiOriginalCommited.Equals(OrderItemEtiquetaPai);
       }
       else
       {
            dirty = OrderItemEtiquetaPai != null;
       }
      if (dirty) return true;
       if (_modeloEtiquetaExpedicaoOriginalCommited!=null)
       {
          dirty = !_modeloEtiquetaExpedicaoOriginalCommited.Equals(ModeloEtiquetaExpedicao);
       }
       else
       {
            dirty = ModeloEtiquetaExpedicao != null;
       }
      if (dirty) return true;
       if (_pedidoItemLinhaPrincipalPedidoOriginalCommited!=null)
       {
          dirty = !_pedidoItemLinhaPrincipalPedidoOriginalCommited.Equals(PedidoItemLinhaPrincipalPedido);
       }
       else
       {
            dirty = PedidoItemLinhaPrincipalPedido != null;
       }
      if (dirty) return true;
       dirty = _tipoAquisicaoProdutoOriginalCommited != TipoAquisicaoProduto;
      if (dirty) return true;
       if (_unidadeMedidaOriginalCommited!=null)
       {
          dirty = !_unidadeMedidaOriginalCommited.Equals(UnidadeMedida);
       }
       else
       {
            dirty = UnidadeMedida != null;
       }

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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassOrderItemEtiqueta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrdemProducaoPedidoClass item in CollectionOrdemProducaoPedidoClassOrderItemEtiqueta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaNfClass item in CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(PlanoCorteItemPedidoClass item in CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta)
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
             case "OrderNumber":
                return this.OrderNumber;
             case "OrderPos":
                return this.OrderPos;
             case "CodigoItem":
                return this.CodigoItem;
             case "Descricao":
                return this.Descricao;
             case "TipoItem":
                return this.TipoItem;
             case "Dimensao":
                return this.Dimensao;
             case "Pps":
                return this.Pps;
             case "QtdEtiquetas":
                return this.QtdEtiquetas;
             case "EtiquetaAgrupada":
                return this.EtiquetaAgrupada;
             case "Cubagem":
                return this.Cubagem;
             case "Peso":
                return this.Peso;
             case "Volumes":
                return this.Volumes;
             case "Saldo":
                return this.Saldo;
             case "SituacaoConferencia":
                return this.SituacaoConferencia;
             case "NivelItem":
                return this.NivelItem;
             case "Ovm":
                return this.Ovm;
             case "Deps":
                return this.Deps;
             case "Peps":
                return this.Peps;
             case "EtiquetaExpedicaoImpressa":
                return this.EtiquetaExpedicaoImpressa;
             case "UsarTimer":
                return this.UsarTimer;
             case "PermitirParcial":
                return this.PermitirParcial;
             case "Quantidade":
                return this.Quantidade;
             case "Pallet":
                return this.Pallet;
             case "NotaFiscalEmitida":
                return this.NotaFiscalEmitida;
             case "SituacaoConferenciaNf":
                return this.SituacaoConferenciaNf;
             case "PrecoTotal":
                return this.PrecoTotal;
             case "PrecoUnitario":
                return this.PrecoUnitario;
             case "EmissaoParcial":
                return this.EmissaoParcial;
             case "StatusPedido":
                return this.StatusPedido;
             case "ArmazenagemCliente":
                return this.ArmazenagemCliente;
             case "DescricaoCliente":
                return this.DescricaoCliente;
             case "CodigoCliente":
                return this.CodigoCliente;
             case "IdExternoClienteAccess":
                return this.IdExternoClienteAccess;
             case "CnpjPedido":
                return this.CnpjPedido;
             case "Cfop":
                return this.Cfop;
             case "NaturezaOperacao":
                return this.NaturezaOperacao;
             case "TipoOperacao":
                return this.TipoOperacao;
             case "NbmPedido":
                return this.NbmPedido;
             case "Frete":
                return this.Frete;
             case "NotaFiscal":
                return this.NotaFiscal;
             case "EtiquetaInterna":
                return this.EtiquetaInterna;
             case "SaldoConferencia":
                return this.SaldoConferencia;
             case "Cnc":
                return this.Cnc;
             case "CoordenadaX":
                return this.CoordenadaX;
             case "CoordenadaY":
                return this.CoordenadaY;
             case "EtiquetaInternaImpressa":
                return this.EtiquetaInternaImpressa;
             case "Saf":
                return this.Saf;
             case "Programador":
                return this.Programador;
             case "ConferenciaCustomizadaRealizada":
                return this.ConferenciaCustomizadaRealizada;
             case "ConferenciaCustomizadaRealizadaForcada":
                return this.ConferenciaCustomizadaRealizadaForcada;
             case "QtdEtiquetaExpVolume":
                return this.QtdEtiquetaExpVolume;
             case "DescricaoPt":
                return this.DescricaoPt;
             case "DescricaoEn":
                return this.DescricaoEn;
             case "DescricaoEs":
                return this.DescricaoEs;
             case "ImprimePackingList":
                return this.ImprimePackingList;
             case "TipoBaseboard":
                return this.TipoBaseboard;
             case "Altura":
                return this.Altura;
             case "Largura":
                return this.Largura;
             case "Comprimento":
                return this.Comprimento;
             case "TipoLigacao":
                return this.TipoLigacao;
             case "PackinglistKitImpresso":
                return this.PackinglistKitImpresso;
             case "Var1Nome":
                return this.Var1Nome;
             case "Var1Valor":
                return this.Var1Valor;
             case "Var2Nome":
                return this.Var2Nome;
             case "Var2Valor":
                return this.Var2Valor;
             case "Var3Nome":
                return this.Var3Nome;
             case "Var3Valor":
                return this.Var3Valor;
             case "Var4Nome":
                return this.Var4Nome;
             case "Var4Valor":
                return this.Var4Valor;
             case "DataEntrega":
                return this.DataEntrega;
             case "KitFantasia":
                return this.KitFantasia;
             case "PkKitTemp":
                return this.PkKitTemp;
             case "DataImpressaoOp":
                return this.DataImpressaoOp;
             case "TipoDocumento":
                return this.TipoDocumento;
             case "NumeroDocumento":
                return this.NumeroDocumento;
             case "RevisaoDesenho":
                return this.RevisaoDesenho;
             case "CodigoItemPai":
                return this.CodigoItemPai;
             case "OrdemProducaoImpressa":
                return this.OrdemProducaoImpressa;
             case "OrdemProducaoImpressaData":
                return this.OrdemProducaoImpressaData;
             case "VerOc":
                return this.VerOc;
             case "AcabamentoSuperficial":
                return this.AcabamentoSuperficial;
             case "ItemOriginalPedido":
                return this.ItemOriginalPedido;
             case "Cliente":
                return this.Cliente;
             case "PedidoItem":
                return this.PedidoItem;
             case "Produto":
                return this.Produto;
             case "DescItemPai":
                return this.DescItemPai;
             case "AcabItemPai":
                return this.AcabItemPai;
             case "ProdutoK":
                return this.ProdutoK;
             case "CompraMpGerado":
                return this.CompraMpGerado;
             case "CompraMpDataGeracao":
                return this.CompraMpDataGeracao;
             case "InformacoesEspeciais":
                return this.InformacoesEspeciais;
             case "VersaoEstruturaItem":
                return this.VersaoEstruturaItem;
             case "RastreamentoMaterial":
                return this.RastreamentoMaterial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ResponsavelFrete":
                return this.ResponsavelFrete;
             case "VolumeUnico":
                return this.VolumeUnico;
             case "OrderItemEtiquetaPai":
                return this.OrderItemEtiquetaPai;
             case "ModeloEtiquetaExpedicao":
                return this.ModeloEtiquetaExpedicao;
             case "PedidoItemLinhaPrincipalPedido":
                return this.PedidoItemLinhaPrincipalPedido;
             case "TipoAquisicaoProduto":
                return this.TipoAquisicaoProduto;
             case "UnidadeMedida":
                return this.UnidadeMedida;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (PedidoItem!=null)
                PedidoItem.ChangeSingleConnection(newConnection);
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (ProdutoK!=null)
                ProdutoK.ChangeSingleConnection(newConnection);
             if (OrderItemEtiquetaPai!=null)
                OrderItemEtiquetaPai.ChangeSingleConnection(newConnection);
             if (ModeloEtiquetaExpedicao!=null)
                ModeloEtiquetaExpedicao.ChangeSingleConnection(newConnection);
             if (PedidoItemLinhaPrincipalPedido!=null)
                PedidoItemLinhaPrincipalPedido.ChangeSingleConnection(newConnection);
             if (UnidadeMedida!=null)
                UnidadeMedida.ChangeSingleConnection(newConnection);
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassOrderItemEtiqueta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoPedidoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrdemProducaoPedidoClass item in CollectionOrdemProducaoPedidoClassOrderItemEtiqueta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassOrderItemEtiquetaPaiLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassOrderItemEtiquetaPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiqueta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiquetaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaNfClass item in CollectionOrderItemEtiquetaConferenciaNfClassOrderItemEtiqueta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemConfiguradoMaterialClassOrderItemEtiquetaLoaded) 
               {
                  foreach(PedidoItemConfiguradoMaterialClass item in CollectionPedidoItemConfiguradoMaterialClassOrderItemEtiqueta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPlanoCorteItemPedidoClassOrderItemEtiquetaLoaded) 
               {
                  foreach(PlanoCorteItemPedidoClass item in CollectionPlanoCorteItemPedidoClassOrderItemEtiqueta)
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
                  command.CommandText += " COUNT(order_item_etiqueta.id_order_item_etiqueta) " ;
               }
               else
               {
               command.CommandText += "order_item_etiqueta.id_order_item_etiqueta, " ;
               command.CommandText += "order_item_etiqueta.oie_order_number, " ;
               command.CommandText += "order_item_etiqueta.oie_order_pos, " ;
               command.CommandText += "order_item_etiqueta.oie_codigo_item, " ;
               command.CommandText += "order_item_etiqueta.oie_descricao, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_item, " ;
               command.CommandText += "order_item_etiqueta.oie_dimensao, " ;
               command.CommandText += "order_item_etiqueta.oie_pps, " ;
               command.CommandText += "order_item_etiqueta.oie_qtd_etiquetas, " ;
               command.CommandText += "order_item_etiqueta.oie_etiqueta_agrupada, " ;
               command.CommandText += "order_item_etiqueta.oie_cubagem, " ;
               command.CommandText += "order_item_etiqueta.oie_peso, " ;
               command.CommandText += "order_item_etiqueta.oie_volumes, " ;
               command.CommandText += "order_item_etiqueta.oie_saldo, " ;
               command.CommandText += "order_item_etiqueta.oie_situacao_conferencia, " ;
               command.CommandText += "order_item_etiqueta.oie_nivel_item, " ;
               command.CommandText += "order_item_etiqueta.oie_ovm, " ;
               command.CommandText += "order_item_etiqueta.oie_deps, " ;
               command.CommandText += "order_item_etiqueta.oie_peps, " ;
               command.CommandText += "order_item_etiqueta.oie_etiqueta_expedicao_impressa, " ;
               command.CommandText += "order_item_etiqueta.oie_usar_timer, " ;
               command.CommandText += "order_item_etiqueta.oie_permitir_parcial, " ;
               command.CommandText += "order_item_etiqueta.oie_quantidade, " ;
               command.CommandText += "order_item_etiqueta.oie_pallet, " ;
               command.CommandText += "order_item_etiqueta.oie_nota_fiscal_emitida, " ;
               command.CommandText += "order_item_etiqueta.oie_situacao_conferencia_nf, " ;
               command.CommandText += "order_item_etiqueta.oie_preco_total, " ;
               command.CommandText += "order_item_etiqueta.oie_preco_unitario, " ;
               command.CommandText += "order_item_etiqueta.oie_emissao_parcial, " ;
               command.CommandText += "order_item_etiqueta.oie_status_pedido, " ;
               command.CommandText += "order_item_etiqueta.oie_armazenagem_cliente, " ;
               command.CommandText += "order_item_etiqueta.oie_descricao_cliente, " ;
               command.CommandText += "order_item_etiqueta.oie_codigo_cliente, " ;
               command.CommandText += "order_item_etiqueta.id_externo_cliente_access, " ;
               command.CommandText += "order_item_etiqueta.oie_cnpj_pedido, " ;
               command.CommandText += "order_item_etiqueta.oie_cfop, " ;
               command.CommandText += "order_item_etiqueta.oie_natureza_operacao, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_operacao, " ;
               command.CommandText += "order_item_etiqueta.oie_nbm_pedido, " ;
               command.CommandText += "order_item_etiqueta.oie_frete, " ;
               command.CommandText += "order_item_etiqueta.oie_nota_fiscal, " ;
               command.CommandText += "order_item_etiqueta.oie_etiqueta_interna, " ;
               command.CommandText += "order_item_etiqueta.oie_saldo_conferencia, " ;
               command.CommandText += "order_item_etiqueta.oie_cnc, " ;
               command.CommandText += "order_item_etiqueta.oie_coordenada_x, " ;
               command.CommandText += "order_item_etiqueta.oie_coordenada_y, " ;
               command.CommandText += "order_item_etiqueta.oie_etiqueta_interna_impressa, " ;
               command.CommandText += "order_item_etiqueta.oie_saf, " ;
               command.CommandText += "order_item_etiqueta.oie_programador, " ;
               command.CommandText += "order_item_etiqueta.oie_conferencia_customizada_realizada, " ;
               command.CommandText += "order_item_etiqueta.oie_conferencia_customizada_realizada_forcada, " ;
               command.CommandText += "order_item_etiqueta.oie_qtd_etiqueta_exp_volume, " ;
               command.CommandText += "order_item_etiqueta.oie_descricao_pt, " ;
               command.CommandText += "order_item_etiqueta.oie_descricao_en, " ;
               command.CommandText += "order_item_etiqueta.oie_descricao_es, " ;
               command.CommandText += "order_item_etiqueta.oie_imprime_packing_list, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_baseboard, " ;
               command.CommandText += "order_item_etiqueta.oie_altura, " ;
               command.CommandText += "order_item_etiqueta.oie_largura, " ;
               command.CommandText += "order_item_etiqueta.oie_comprimento, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_ligacao, " ;
               command.CommandText += "order_item_etiqueta.oie_packinglist_kit_impresso, " ;
               command.CommandText += "order_item_etiqueta.oie_var_1_nome, " ;
               command.CommandText += "order_item_etiqueta.oie_var_1_valor, " ;
               command.CommandText += "order_item_etiqueta.oie_var_2_nome, " ;
               command.CommandText += "order_item_etiqueta.oie_var_2_valor, " ;
               command.CommandText += "order_item_etiqueta.oie_var_3_nome, " ;
               command.CommandText += "order_item_etiqueta.oie_var_3_valor, " ;
               command.CommandText += "order_item_etiqueta.oie_var_4_nome, " ;
               command.CommandText += "order_item_etiqueta.oie_var_4_valor, " ;
               command.CommandText += "order_item_etiqueta.oie_data_entrega, " ;
               command.CommandText += "order_item_etiqueta.oie_kit_fantasia, " ;
               command.CommandText += "order_item_etiqueta.oie_pk_kit_temp, " ;
               command.CommandText += "order_item_etiqueta.oie_data_impressao_op, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_documento, " ;
               command.CommandText += "order_item_etiqueta.oie_numero_documento, " ;
               command.CommandText += "order_item_etiqueta.oie_revisao_desenho, " ;
               command.CommandText += "order_item_etiqueta.oie_codigo_item_pai, " ;
               command.CommandText += "order_item_etiqueta.oie_ordem_producao_impressa, " ;
               command.CommandText += "order_item_etiqueta.oie_ordem_producao_impressa_data, " ;
               command.CommandText += "order_item_etiqueta.oie_ver_oc, " ;
               command.CommandText += "order_item_etiqueta.oie_acabamento_superficial, " ;
               command.CommandText += "order_item_etiqueta.oie_item_original_pedido, " ;
               command.CommandText += "order_item_etiqueta.id_cliente, " ;
               command.CommandText += "order_item_etiqueta.id_pedido_item, " ;
               command.CommandText += "order_item_etiqueta.id_produto, " ;
               command.CommandText += "order_item_etiqueta.oie_desc_item_pai, " ;
               command.CommandText += "order_item_etiqueta.oie_acab_item_pai, " ;
               command.CommandText += "order_item_etiqueta.id_produto_k, " ;
               command.CommandText += "order_item_etiqueta.oie_compra_mp_gerado, " ;
               command.CommandText += "order_item_etiqueta.oie_compra_mp_data_geracao, " ;
               command.CommandText += "order_item_etiqueta.oie_informacoes_especiais, " ;
               command.CommandText += "order_item_etiqueta.oie_versao_estrutura_item, " ;
               command.CommandText += "order_item_etiqueta.oie_rastreamento_material, " ;
               command.CommandText += "order_item_etiqueta.entity_uid, " ;
               command.CommandText += "order_item_etiqueta.version, " ;
               command.CommandText += "order_item_etiqueta.oie_responsavel_frete, " ;
               command.CommandText += "order_item_etiqueta.oie_volume_unico, " ;
               command.CommandText += "order_item_etiqueta.id_order_item_etiqueta_pai, " ;
               command.CommandText += "order_item_etiqueta.id_modelo_etiqueta_expedicao, " ;
               command.CommandText += "order_item_etiqueta.id_pedido_item_linha_principal_pedido, " ;
               command.CommandText += "order_item_etiqueta.oie_tipo_aquisicao_produto, " ;
               command.CommandText += "order_item_etiqueta.id_unidade_medida " ;
               }
               command.CommandText += " FROM  order_item_etiqueta ";
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
                        orderByClause += " , oie_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oie_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = order_item_etiqueta.id_acs_usuario_ultima_revisao ";
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
                     case "id_order_item_etiqueta":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_item":
                     case "TipoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_tipo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_dimensao":
                     case "Dimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_pps":
                     case "Pps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_pps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_pps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_qtd_etiquetas":
                     case "QtdEtiquetas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_qtd_etiquetas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_qtd_etiquetas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_etiqueta_agrupada":
                     case "EtiquetaAgrupada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_etiqueta_agrupada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_etiqueta_agrupada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_cubagem":
                     case "Cubagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_cubagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_cubagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_peso":
                     case "Peso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_peso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_peso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_volumes":
                     case "Volumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_saldo":
                     case "Saldo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_saldo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_saldo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_situacao_conferencia":
                     case "SituacaoConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_situacao_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_situacao_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_nivel_item":
                     case "NivelItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_nivel_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_nivel_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_ovm":
                     case "Ovm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_ovm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_ovm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_deps":
                     case "Deps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_deps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_deps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_peps":
                     case "Peps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_peps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_peps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_etiqueta_expedicao_impressa":
                     case "EtiquetaExpedicaoImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_etiqueta_expedicao_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_etiqueta_expedicao_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_usar_timer":
                     case "UsarTimer":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_usar_timer " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_usar_timer) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_permitir_parcial":
                     case "PermitirParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_permitir_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_permitir_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_pallet":
                     case "Pallet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_nota_fiscal_emitida":
                     case "NotaFiscalEmitida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_nota_fiscal_emitida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_nota_fiscal_emitida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_situacao_conferencia_nf":
                     case "SituacaoConferenciaNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_situacao_conferencia_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_situacao_conferencia_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_preco_total":
                     case "PrecoTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_preco_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_preco_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_preco_unitario":
                     case "PrecoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_preco_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_preco_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_emissao_parcial":
                     case "EmissaoParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_emissao_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_emissao_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_status_pedido":
                     case "StatusPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_status_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_status_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_armazenagem_cliente":
                     case "ArmazenagemCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_armazenagem_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_armazenagem_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_descricao_cliente":
                     case "DescricaoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_codigo_cliente":
                     case "CodigoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_codigo_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_codigo_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_externo_cliente_access":
                     case "IdExternoClienteAccess":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.id_externo_cliente_access " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.id_externo_cliente_access) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_cnpj_pedido":
                     case "CnpjPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_cnpj_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_cnpj_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_natureza_operacao":
                     case "NaturezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_natureza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_natureza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_operacao":
                     case "TipoOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_tipo_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_nbm_pedido":
                     case "NbmPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_nbm_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_nbm_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_frete":
                     case "Frete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_nota_fiscal":
                     case "NotaFiscal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_nota_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_nota_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_etiqueta_interna":
                     case "EtiquetaInterna":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_etiqueta_interna " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_etiqueta_interna) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_saldo_conferencia":
                     case "SaldoConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_saldo_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_saldo_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_cnc":
                     case "Cnc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_cnc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_cnc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_coordenada_x":
                     case "CoordenadaX":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_coordenada_x " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_coordenada_x) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_coordenada_y":
                     case "CoordenadaY":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_coordenada_y " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_coordenada_y) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_etiqueta_interna_impressa":
                     case "EtiquetaInternaImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_etiqueta_interna_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_etiqueta_interna_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_saf":
                     case "Saf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_saf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_saf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_programador":
                     case "Programador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_programador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_programador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_conferencia_customizada_realizada":
                     case "ConferenciaCustomizadaRealizada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_conferencia_customizada_realizada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_conferencia_customizada_realizada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_conferencia_customizada_realizada_forcada":
                     case "ConferenciaCustomizadaRealizadaForcada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_conferencia_customizada_realizada_forcada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_conferencia_customizada_realizada_forcada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_qtd_etiqueta_exp_volume":
                     case "QtdEtiquetaExpVolume":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_qtd_etiqueta_exp_volume " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_qtd_etiqueta_exp_volume) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_descricao_pt":
                     case "DescricaoPt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_descricao_pt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_descricao_pt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_descricao_en":
                     case "DescricaoEn":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_descricao_en " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_descricao_en) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_descricao_es":
                     case "DescricaoEs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_descricao_es " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_descricao_es) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_imprime_packing_list":
                     case "ImprimePackingList":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_imprime_packing_list " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_imprime_packing_list) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_baseboard":
                     case "TipoBaseboard":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_tipo_baseboard " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_baseboard) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_altura":
                     case "Altura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_altura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_altura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_largura":
                     case "Largura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_comprimento":
                     case "Comprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_ligacao":
                     case "TipoLigacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_tipo_ligacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_ligacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_packinglist_kit_impresso":
                     case "PackinglistKitImpresso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_packinglist_kit_impresso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_packinglist_kit_impresso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_1_nome":
                     case "Var1Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_1_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_1_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_1_valor":
                     case "Var1Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_1_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_1_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_2_nome":
                     case "Var2Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_2_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_2_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_2_valor":
                     case "Var2Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_2_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_2_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_3_nome":
                     case "Var3Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_3_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_3_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_3_valor":
                     case "Var3Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_3_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_3_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_4_nome":
                     case "Var4Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_4_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_4_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_var_4_valor":
                     case "Var4Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_var_4_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_var_4_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_data_entrega":
                     case "DataEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_data_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_data_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_kit_fantasia":
                     case "KitFantasia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_kit_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_kit_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_pk_kit_temp":
                     case "PkKitTemp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_pk_kit_temp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_pk_kit_temp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_data_impressao_op":
                     case "DataImpressaoOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_data_impressao_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_data_impressao_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_documento":
                     case "TipoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_tipo_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_numero_documento":
                     case "NumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_revisao_desenho":
                     case "RevisaoDesenho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_revisao_desenho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_revisao_desenho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_codigo_item_pai":
                     case "CodigoItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_codigo_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_codigo_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_ordem_producao_impressa":
                     case "OrdemProducaoImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_ordem_producao_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_ordem_producao_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_ordem_producao_impressa_data":
                     case "OrdemProducaoImpressaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_ordem_producao_impressa_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_ordem_producao_impressa_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_ver_oc":
                     case "VerOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_ver_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_ver_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_acabamento_superficial":
                     case "AcabamentoSuperficial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_acabamento_superficial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_acabamento_superficial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_item_original_pedido":
                     case "ItemOriginalPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_item_original_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_item_original_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = order_item_etiqueta.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_pedido_item":
                     case "PedidoItem":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItem ON pedido_item_PedidoItem.id_pedido_item = order_item_etiqueta.id_pedido_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItem.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItem.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItem.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = order_item_etiqueta.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "oie_desc_item_pai":
                     case "DescItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_desc_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_desc_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_acab_item_pai":
                     case "AcabItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_acab_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_acab_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_k":
                     case "ProdutoK":
                     command.CommandText += " LEFT JOIN produto_k as produto_k_ProdutoK ON produto_k_ProdutoK.id_produto_k = order_item_etiqueta.id_produto_k ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , produto_k_ProdutoK.prk_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(produto_k_ProdutoK.prk_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_compra_mp_gerado":
                     case "CompraMpGerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_compra_mp_gerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_compra_mp_gerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_compra_mp_data_geracao":
                     case "CompraMpDataGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_compra_mp_data_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_compra_mp_data_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_informacoes_especiais":
                     case "InformacoesEspeciais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.oie_informacoes_especiais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_informacoes_especiais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_versao_estrutura_item":
                     case "VersaoEstruturaItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_versao_estrutura_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_versao_estrutura_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item_etiqueta.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_responsavel_frete":
                     case "ResponsavelFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_responsavel_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_responsavel_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_volume_unico":
                     case "VolumeUnico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_volume_unico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_volume_unico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta_pai":
                     case "OrderItemEtiquetaPai":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiquetaPai ON order_item_etiqueta_OrderItemEtiquetaPai.id_order_item_etiqueta = order_item_etiqueta.id_order_item_etiqueta_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiquetaPai.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiquetaPai.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiquetaPai.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiquetaPai.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiquetaPai.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiquetaPai.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_modelo_etiqueta_expedicao":
                     case "ModeloEtiquetaExpedicao":
                     command.CommandText += " LEFT JOIN modelo_etiqueta_expedicao as modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao ON modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.id_modelo_etiqueta_expedicao = order_item_etiqueta.id_modelo_etiqueta_expedicao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.mee_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.mee_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item_linha_principal_pedido":
                     case "PedidoItemLinhaPrincipalPedido":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItemLinhaPrincipalPedido ON pedido_item_PedidoItemLinhaPrincipalPedido.id_pedido_item = order_item_etiqueta.id_pedido_item_linha_principal_pedido ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItemLinhaPrincipalPedido.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItemLinhaPrincipalPedido.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItemLinhaPrincipalPedido.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItemLinhaPrincipalPedido.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oie_tipo_aquisicao_produto":
                     case "TipoAquisicaoProduto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta.oie_tipo_aquisicao_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta.oie_tipo_aquisicao_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_unidade_medida":
                     case "UnidadeMedida":
                     command.CommandText += " LEFT JOIN unidade_medida as unidade_medida_UnidadeMedida ON unidade_medida_UnidadeMedida.id_unidade_medida = order_item_etiqueta.id_unidade_medida ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , unidade_medida_UnidadeMedida.unm_abreviada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(unidade_medida_UnidadeMedida.unm_abreviada) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_order_number")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_codigo_item")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_descricao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_dimensao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_ovm")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_ovm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_ovm) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_deps")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_deps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_deps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_peps")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_peps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_peps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_status_pedido")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_status_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_status_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_armazenagem_cliente")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_armazenagem_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_armazenagem_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_descricao_cliente")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_descricao_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_descricao_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_codigo_cliente")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_codigo_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_codigo_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("id_externo_cliente_access")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.id_externo_cliente_access) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.id_externo_cliente_access) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_cnpj_pedido")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_cnpj_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_cnpj_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_natureza_operacao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_natureza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_natureza_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_tipo_operacao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_tipo_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_tipo_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_nbm_pedido")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_nbm_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_nbm_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_cnc")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_cnc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_cnc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_coordenada_x")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_coordenada_x) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_coordenada_x) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_coordenada_y")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_coordenada_y) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_coordenada_y) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_saf")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_saf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_saf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_programador")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_programador) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_programador) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_descricao_pt")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_descricao_pt) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_descricao_pt) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_descricao_en")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_descricao_en) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_descricao_en) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_descricao_es")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_descricao_es) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_descricao_es) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_tipo_baseboard")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_tipo_baseboard) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_tipo_baseboard) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_tipo_ligacao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_tipo_ligacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_tipo_ligacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_1_nome")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_1_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_1_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_1_valor")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_1_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_1_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_2_nome")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_2_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_2_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_2_valor")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_2_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_2_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_3_nome")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_3_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_3_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_3_valor")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_3_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_3_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_4_nome")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_4_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_4_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_var_4_valor")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_var_4_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_var_4_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_kit_fantasia")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_kit_fantasia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_kit_fantasia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_tipo_documento")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_tipo_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_tipo_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_numero_documento")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_revisao_desenho")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_revisao_desenho) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_revisao_desenho) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_codigo_item_pai")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_codigo_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_codigo_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_ver_oc")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_ver_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_ver_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_acabamento_superficial")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_acabamento_superficial) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_acabamento_superficial) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_desc_item_pai")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_desc_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_desc_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_acab_item_pai")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_acab_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_acab_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oie_informacoes_especiais")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.oie_informacoes_especiais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.oie_informacoes_especiais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_order_item_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_order_item_etiqueta = :order_item_etiqueta_ID_7294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ID_7294", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "oie_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_order_number LIKE :order_item_etiqueta_OrderNumber_2223 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrderNumber_2223", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "oie_order_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_order_pos = :order_item_etiqueta_OrderPos_284 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrderPos_284", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "oie_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item LIKE :order_item_etiqueta_CodigoItem_7978 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoItem_7978", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "oie_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao LIKE :order_item_etiqueta_Descricao_3782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Descricao_3782", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoItem" || parametro.FieldName == "oie_tipo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoControleEtiquetaProduto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoControleEtiquetaProduto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_item = :order_item_etiqueta_TipoItem_9250 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoItem_9250", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao" || parametro.FieldName == "oie_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_dimensao LIKE :order_item_etiqueta_Dimensao_2514 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Dimensao_2514", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pps" || parametro.FieldName == "oie_pps")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_pps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_pps = :order_item_etiqueta_Pps_3918 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Pps_3918", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdEtiquetas" || parametro.FieldName == "oie_qtd_etiquetas")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_qtd_etiquetas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_qtd_etiquetas = :order_item_etiqueta_QtdEtiquetas_2509 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_QtdEtiquetas_2509", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaAgrupada" || parametro.FieldName == "oie_etiqueta_agrupada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_agrupada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_agrupada = :order_item_etiqueta_EtiquetaAgrupada_748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EtiquetaAgrupada_748", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cubagem" || parametro.FieldName == "oie_cubagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cubagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cubagem = :order_item_etiqueta_Cubagem_8056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Cubagem_8056", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peso" || parametro.FieldName == "oie_peso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_peso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_peso = :order_item_etiqueta_Peso_9859 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Peso_9859", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Volumes" || parametro.FieldName == "oie_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_volumes = :order_item_etiqueta_Volumes_4042 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Volumes_4042", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saldo" || parametro.FieldName == "oie_saldo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_saldo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_saldo = :order_item_etiqueta_Saldo_2198 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Saldo_2198", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoConferencia" || parametro.FieldName == "oie_situacao_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoConferencia)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoConferencia");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_situacao_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_situacao_conferencia = :order_item_etiqueta_SituacaoConferencia_3401 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_SituacaoConferencia_3401", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NivelItem" || parametro.FieldName == "oie_nivel_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_nivel_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_nivel_item = :order_item_etiqueta_NivelItem_9521 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NivelItem_9521", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ovm" || parametro.FieldName == "oie_ovm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ovm LIKE :order_item_etiqueta_Ovm_1047 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Ovm_1047", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Deps" || parametro.FieldName == "oie_deps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_deps LIKE :order_item_etiqueta_Deps_749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Deps_749", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peps" || parametro.FieldName == "oie_peps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_peps LIKE :order_item_etiqueta_Peps_9080 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Peps_9080", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaExpedicaoImpressa" || parametro.FieldName == "oie_etiqueta_expedicao_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_expedicao_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_expedicao_impressa = :order_item_etiqueta_EtiquetaExpedicaoImpressa_8068 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EtiquetaExpedicaoImpressa_8068", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsarTimer" || parametro.FieldName == "oie_usar_timer")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_usar_timer IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_usar_timer = :order_item_etiqueta_UsarTimer_457 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_UsarTimer_457", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermitirParcial" || parametro.FieldName == "oie_permitir_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_permitir_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_permitir_parcial = :order_item_etiqueta_PermitirParcial_9516 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PermitirParcial_9516", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "oie_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_quantidade = :order_item_etiqueta_Quantidade_454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Quantidade_454", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pallet" || parametro.FieldName == "oie_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_pallet = :order_item_etiqueta_Pallet_117 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Pallet_117", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscalEmitida" || parametro.FieldName == "oie_nota_fiscal_emitida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_nota_fiscal_emitida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_nota_fiscal_emitida = :order_item_etiqueta_NotaFiscalEmitida_3862 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NotaFiscalEmitida_3862", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoConferenciaNf" || parametro.FieldName == "oie_situacao_conferencia_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoConferencia)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoConferencia");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_situacao_conferencia_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_situacao_conferencia_nf = :order_item_etiqueta_SituacaoConferenciaNf_6624 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_SituacaoConferenciaNf_6624", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotal" || parametro.FieldName == "oie_preco_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_preco_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_preco_total = :order_item_etiqueta_PrecoTotal_5764 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PrecoTotal_5764", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoUnitario" || parametro.FieldName == "oie_preco_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_preco_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_preco_unitario = :order_item_etiqueta_PrecoUnitario_3403 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PrecoUnitario_3403", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmissaoParcial" || parametro.FieldName == "oie_emissao_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_emissao_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_emissao_parcial = :order_item_etiqueta_EmissaoParcial_6923 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EmissaoParcial_6923", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "StatusPedido" || parametro.FieldName == "oie_status_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_status_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_status_pedido LIKE :order_item_etiqueta_StatusPedido_3960 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_StatusPedido_3960", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemCliente" || parametro.FieldName == "oie_armazenagem_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_armazenagem_cliente LIKE :order_item_etiqueta_ArmazenagemCliente_7147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ArmazenagemCliente_7147", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoCliente" || parametro.FieldName == "oie_descricao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_cliente LIKE :order_item_etiqueta_DescricaoCliente_5929 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoCliente_5929", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCliente" || parametro.FieldName == "oie_codigo_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_cliente LIKE :order_item_etiqueta_CodigoCliente_8850 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoCliente_8850", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdExternoClienteAccess" || parametro.FieldName == "id_externo_cliente_access")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_externo_cliente_access IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_externo_cliente_access LIKE :order_item_etiqueta_IdExternoClienteAccess_4059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_IdExternoClienteAccess_4059", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjPedido" || parametro.FieldName == "oie_cnpj_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cnpj_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cnpj_pedido LIKE :order_item_etiqueta_CnpjPedido_1283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CnpjPedido_1283", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "oie_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cfop = :order_item_etiqueta_Cfop_1313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Cfop_1313", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacao" || parametro.FieldName == "oie_natureza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_natureza_operacao LIKE :order_item_etiqueta_NaturezaOperacao_442 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NaturezaOperacao_442", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoOperacao" || parametro.FieldName == "oie_tipo_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_operacao LIKE :order_item_etiqueta_TipoOperacao_7366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoOperacao_7366", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NbmPedido" || parametro.FieldName == "oie_nbm_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_nbm_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_nbm_pedido LIKE :order_item_etiqueta_NbmPedido_1124 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NbmPedido_1124", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Frete" || parametro.FieldName == "oie_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_frete = :order_item_etiqueta_Frete_9301 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Frete_9301", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscal" || parametro.FieldName == "oie_nota_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_nota_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_nota_fiscal = :order_item_etiqueta_NotaFiscal_1688 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NotaFiscal_1688", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaInterna" || parametro.FieldName == "oie_etiqueta_interna")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_interna IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_interna = :order_item_etiqueta_EtiquetaInterna_2090 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EtiquetaInterna_2090", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SaldoConferencia" || parametro.FieldName == "oie_saldo_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_saldo_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_saldo_conferencia = :order_item_etiqueta_SaldoConferencia_6883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_SaldoConferencia_6883", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnc" || parametro.FieldName == "oie_cnc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cnc LIKE :order_item_etiqueta_Cnc_7534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Cnc_7534", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaX" || parametro.FieldName == "oie_coordenada_x")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_x IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_x LIKE :order_item_etiqueta_CoordenadaX_107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CoordenadaX_107", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaY" || parametro.FieldName == "oie_coordenada_y")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_y IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_y LIKE :order_item_etiqueta_CoordenadaY_8677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CoordenadaY_8677", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaInternaImpressa" || parametro.FieldName == "oie_etiqueta_interna_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_interna_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_etiqueta_interna_impressa = :order_item_etiqueta_EtiquetaInternaImpressa_4297 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EtiquetaInternaImpressa_4297", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saf" || parametro.FieldName == "oie_saf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_saf LIKE :order_item_etiqueta_Saf_5051 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Saf_5051", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Programador" || parametro.FieldName == "oie_programador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_programador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_programador LIKE :order_item_etiqueta_Programador_3562 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Programador_3562", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaCustomizadaRealizada" || parametro.FieldName == "oie_conferencia_customizada_realizada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_conferencia_customizada_realizada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_conferencia_customizada_realizada = :order_item_etiqueta_ConferenciaCustomizadaRealizada_6816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ConferenciaCustomizadaRealizada_6816", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaCustomizadaRealizadaForcada" || parametro.FieldName == "oie_conferencia_customizada_realizada_forcada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_conferencia_customizada_realizada_forcada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_conferencia_customizada_realizada_forcada = :order_item_etiqueta_ConferenciaCustomizadaRealizadaForcada_5616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ConferenciaCustomizadaRealizadaForcada_5616", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdEtiquetaExpVolume" || parametro.FieldName == "oie_qtd_etiqueta_exp_volume")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_qtd_etiqueta_exp_volume IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_qtd_etiqueta_exp_volume = :order_item_etiqueta_QtdEtiquetaExpVolume_5511 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_QtdEtiquetaExpVolume_5511", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoPt" || parametro.FieldName == "oie_descricao_pt")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_pt LIKE :order_item_etiqueta_DescricaoPt_3011 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoPt_3011", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEn" || parametro.FieldName == "oie_descricao_en")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_en LIKE :order_item_etiqueta_DescricaoEn_993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoEn_993", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEs" || parametro.FieldName == "oie_descricao_es")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_es LIKE :order_item_etiqueta_DescricaoEs_9385 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoEs_9385", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimePackingList" || parametro.FieldName == "oie_imprime_packing_list")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_imprime_packing_list IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_imprime_packing_list = :order_item_etiqueta_ImprimePackingList_7777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ImprimePackingList_7777", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoBaseboard" || parametro.FieldName == "oie_tipo_baseboard")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_baseboard IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_baseboard LIKE :order_item_etiqueta_TipoBaseboard_1770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoBaseboard_1770", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Altura" || parametro.FieldName == "oie_altura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_altura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_altura = :order_item_etiqueta_Altura_167 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Altura_167", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Largura" || parametro.FieldName == "oie_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_largura = :order_item_etiqueta_Largura_4117 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Largura_4117", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprimento" || parametro.FieldName == "oie_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_comprimento = :order_item_etiqueta_Comprimento_7156 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Comprimento_7156", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoLigacao" || parametro.FieldName == "oie_tipo_ligacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_ligacao LIKE :order_item_etiqueta_TipoLigacao_3487 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoLigacao_3487", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PackinglistKitImpresso" || parametro.FieldName == "oie_packinglist_kit_impresso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_packinglist_kit_impresso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_packinglist_kit_impresso = :order_item_etiqueta_PackinglistKitImpresso_9110 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PackinglistKitImpresso_9110", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1Nome" || parametro.FieldName == "oie_var_1_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_nome LIKE :order_item_etiqueta_Var1Nome_6993 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var1Nome_6993", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1Valor" || parametro.FieldName == "oie_var_1_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_valor LIKE :order_item_etiqueta_Var1Valor_8548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var1Valor_8548", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2Nome" || parametro.FieldName == "oie_var_2_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_nome LIKE :order_item_etiqueta_Var2Nome_3600 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var2Nome_3600", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2Valor" || parametro.FieldName == "oie_var_2_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_valor LIKE :order_item_etiqueta_Var2Valor_2128 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var2Valor_2128", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3Nome" || parametro.FieldName == "oie_var_3_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_nome LIKE :order_item_etiqueta_Var3Nome_1009 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var3Nome_1009", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3Valor" || parametro.FieldName == "oie_var_3_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_valor LIKE :order_item_etiqueta_Var3Valor_9982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var3Valor_9982", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4Nome" || parametro.FieldName == "oie_var_4_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_nome LIKE :order_item_etiqueta_Var4Nome_915 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var4Nome_915", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4Valor" || parametro.FieldName == "oie_var_4_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_valor LIKE :order_item_etiqueta_Var4Valor_2088 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var4Valor_2088", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrega" || parametro.FieldName == "oie_data_entrega")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_data_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_data_entrega = :order_item_etiqueta_DataEntrega_9079 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DataEntrega_9079", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "KitFantasia" || parametro.FieldName == "oie_kit_fantasia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_kit_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_kit_fantasia LIKE :order_item_etiqueta_KitFantasia_3680 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_KitFantasia_3680", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PkKitTemp" || parametro.FieldName == "oie_pk_kit_temp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_pk_kit_temp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_pk_kit_temp = :order_item_etiqueta_PkKitTemp_9623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PkKitTemp_9623", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImpressaoOp" || parametro.FieldName == "oie_data_impressao_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_data_impressao_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_data_impressao_op = :order_item_etiqueta_DataImpressaoOp_9778 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DataImpressaoOp_9778", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumento" || parametro.FieldName == "oie_tipo_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_documento LIKE :order_item_etiqueta_TipoDocumento_6380 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoDocumento_6380", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumento" || parametro.FieldName == "oie_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_numero_documento LIKE :order_item_etiqueta_NumeroDocumento_8366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NumeroDocumento_8366", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDesenho" || parametro.FieldName == "oie_revisao_desenho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_revisao_desenho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_revisao_desenho LIKE :order_item_etiqueta_RevisaoDesenho_2634 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_RevisaoDesenho_2634", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemPai" || parametro.FieldName == "oie_codigo_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item_pai LIKE :order_item_etiqueta_CodigoItemPai_2918 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoItemPai_2918", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoImpressa" || parametro.FieldName == "oie_ordem_producao_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ordem_producao_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ordem_producao_impressa = :order_item_etiqueta_OrdemProducaoImpressa_10 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrdemProducaoImpressa_10", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoImpressaData" || parametro.FieldName == "oie_ordem_producao_impressa_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ordem_producao_impressa_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ordem_producao_impressa_data = :order_item_etiqueta_OrdemProducaoImpressaData_5183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrdemProducaoImpressaData_5183", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VerOc" || parametro.FieldName == "oie_ver_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ver_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ver_oc LIKE :order_item_etiqueta_VerOc_2328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_VerOc_2328", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabamentoSuperficial" || parametro.FieldName == "oie_acabamento_superficial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_acabamento_superficial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_acabamento_superficial LIKE :order_item_etiqueta_AcabamentoSuperficial_713 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_AcabamentoSuperficial_713", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ItemOriginalPedido" || parametro.FieldName == "oie_item_original_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_item_original_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_item_original_pedido = :order_item_etiqueta_ItemOriginalPedido_9839 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ItemOriginalPedido_9839", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  order_item_etiqueta.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_cliente = :order_item_etiqueta_Cliente_107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Cliente_107", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItem" || parametro.FieldName == "id_pedido_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_pedido_item = :order_item_etiqueta_PedidoItem_8343 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PedidoItem_8343", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  order_item_etiqueta.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_produto = :order_item_etiqueta_Produto_1636 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Produto_1636", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescItemPai" || parametro.FieldName == "oie_desc_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_desc_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_desc_item_pai LIKE :order_item_etiqueta_DescItemPai_2918 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescItemPai_2918", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabItemPai" || parametro.FieldName == "oie_acab_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_acab_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_acab_item_pai LIKE :order_item_etiqueta_AcabItemPai_7858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_AcabItemPai_7858", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoK" || parametro.FieldName == "id_produto_k")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProdutoKClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProdutoKClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_produto_k = :order_item_etiqueta_ProdutoK_4673 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ProdutoK_4673", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompraMpGerado" || parametro.FieldName == "oie_compra_mp_gerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_compra_mp_gerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_compra_mp_gerado = :order_item_etiqueta_CompraMpGerado_3504 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CompraMpGerado_3504", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompraMpDataGeracao" || parametro.FieldName == "oie_compra_mp_data_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_compra_mp_data_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_compra_mp_data_geracao = :order_item_etiqueta_CompraMpDataGeracao_9542 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CompraMpDataGeracao_9542", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesEspeciais" || parametro.FieldName == "oie_informacoes_especiais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_informacoes_especiais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_informacoes_especiais LIKE :order_item_etiqueta_InformacoesEspeciais_275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_InformacoesEspeciais_275", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstruturaItem" || parametro.FieldName == "oie_versao_estrutura_item")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_versao_estrutura_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_versao_estrutura_item = :order_item_etiqueta_VersaoEstruturaItem_3250 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_VersaoEstruturaItem_3250", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "oie_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_rastreamento_material = :order_item_etiqueta_RastreamentoMaterial_3967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_RastreamentoMaterial_3967", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  order_item_etiqueta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.entity_uid LIKE :order_item_etiqueta_EntityUid_5814 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EntityUid_5814", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.version = :order_item_etiqueta_Version_2577 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Version_2577", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResponsavelFrete" || parametro.FieldName == "oie_responsavel_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ResponsavelFrete)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ResponsavelFrete");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_responsavel_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_responsavel_frete = :order_item_etiqueta_ResponsavelFrete_5095 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ResponsavelFrete_5095", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeUnico" || parametro.FieldName == "oie_volume_unico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_volume_unico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_volume_unico = :order_item_etiqueta_VolumeUnico_8333 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_VolumeUnico_8333", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiquetaPai" || parametro.FieldName == "id_order_item_etiqueta_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_order_item_etiqueta_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_order_item_etiqueta_pai = :order_item_etiqueta_OrderItemEtiquetaPai_3935 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrderItemEtiquetaPai_3935", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloEtiquetaExpedicao" || parametro.FieldName == "id_modelo_etiqueta_expedicao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_modelo_etiqueta_expedicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_modelo_etiqueta_expedicao = :order_item_etiqueta_ModeloEtiquetaExpedicao_7978 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ModeloEtiquetaExpedicao_7978", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItemLinhaPrincipalPedido" || parametro.FieldName == "id_pedido_item_linha_principal_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_pedido_item_linha_principal_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_pedido_item_linha_principal_pedido = :order_item_etiqueta_PedidoItemLinhaPrincipalPedido_7669 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_PedidoItemLinhaPrincipalPedido_7669", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAquisicaoProduto" || parametro.FieldName == "oie_tipo_aquisicao_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoAquisicao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoAquisicao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_aquisicao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_aquisicao_produto = :order_item_etiqueta_TipoAquisicaoProduto_4313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoAquisicaoProduto_4313", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UnidadeMedida" || parametro.FieldName == "id_unidade_medida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.UnidadeMedidaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.UnidadeMedidaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_unidade_medida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_unidade_medida = :order_item_etiqueta_UnidadeMedida_4136 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_UnidadeMedida_4136", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumberExato" || parametro.FieldName == "OrderNumberExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_order_number LIKE :order_item_etiqueta_OrderNumber_1474 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_OrderNumber_1474", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemExato" || parametro.FieldName == "CodigoItemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item LIKE :order_item_etiqueta_CodigoItem_7736 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoItem_7736", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoExato" || parametro.FieldName == "DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao LIKE :order_item_etiqueta_Descricao_1936 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Descricao_1936", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DimensaoExato" || parametro.FieldName == "DimensaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_dimensao LIKE :order_item_etiqueta_Dimensao_5887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Dimensao_5887", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OvmExato" || parametro.FieldName == "OvmExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ovm LIKE :order_item_etiqueta_Ovm_3232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Ovm_3232", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DepsExato" || parametro.FieldName == "DepsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_deps LIKE :order_item_etiqueta_Deps_4612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Deps_4612", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PepsExato" || parametro.FieldName == "PepsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_peps LIKE :order_item_etiqueta_Peps_1020 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Peps_1020", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "StatusPedidoExato" || parametro.FieldName == "StatusPedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_status_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_status_pedido LIKE :order_item_etiqueta_StatusPedido_5144 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_StatusPedido_5144", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemClienteExato" || parametro.FieldName == "ArmazenagemClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_armazenagem_cliente LIKE :order_item_etiqueta_ArmazenagemCliente_8851 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_ArmazenagemCliente_8851", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoClienteExato" || parametro.FieldName == "DescricaoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_cliente LIKE :order_item_etiqueta_DescricaoCliente_158 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoCliente_158", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoClienteExato" || parametro.FieldName == "CodigoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_cliente LIKE :order_item_etiqueta_CodigoCliente_8932 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoCliente_8932", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdExternoClienteAccessExato" || parametro.FieldName == "IdExternoClienteAccessExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.id_externo_cliente_access IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.id_externo_cliente_access LIKE :order_item_etiqueta_IdExternoClienteAccess_4828 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_IdExternoClienteAccess_4828", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjPedidoExato" || parametro.FieldName == "CnpjPedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cnpj_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cnpj_pedido LIKE :order_item_etiqueta_CnpjPedido_2775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CnpjPedido_2775", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacaoExato" || parametro.FieldName == "NaturezaOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_natureza_operacao LIKE :order_item_etiqueta_NaturezaOperacao_9269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NaturezaOperacao_9269", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoOperacaoExato" || parametro.FieldName == "TipoOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_operacao LIKE :order_item_etiqueta_TipoOperacao_6887 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoOperacao_6887", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NbmPedidoExato" || parametro.FieldName == "NbmPedidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_nbm_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_nbm_pedido LIKE :order_item_etiqueta_NbmPedido_205 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NbmPedido_205", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CncExato" || parametro.FieldName == "CncExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_cnc LIKE :order_item_etiqueta_Cnc_1964 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Cnc_1964", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaXExato" || parametro.FieldName == "CoordenadaXExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_x IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_x LIKE :order_item_etiqueta_CoordenadaX_9208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CoordenadaX_9208", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaYExato" || parametro.FieldName == "CoordenadaYExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_y IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_coordenada_y LIKE :order_item_etiqueta_CoordenadaY_3150 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CoordenadaY_3150", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SafExato" || parametro.FieldName == "SafExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_saf LIKE :order_item_etiqueta_Saf_5309 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Saf_5309", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProgramadorExato" || parametro.FieldName == "ProgramadorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_programador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_programador LIKE :order_item_etiqueta_Programador_7409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Programador_7409", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoPtExato" || parametro.FieldName == "DescricaoPtExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_pt LIKE :order_item_etiqueta_DescricaoPt_2545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoPt_2545", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEnExato" || parametro.FieldName == "DescricaoEnExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_en LIKE :order_item_etiqueta_DescricaoEn_8804 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoEn_8804", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEsExato" || parametro.FieldName == "DescricaoEsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_descricao_es LIKE :order_item_etiqueta_DescricaoEs_431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescricaoEs_431", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoBaseboardExato" || parametro.FieldName == "TipoBaseboardExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_baseboard IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_baseboard LIKE :order_item_etiqueta_TipoBaseboard_5656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoBaseboard_5656", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoLigacaoExato" || parametro.FieldName == "TipoLigacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_ligacao LIKE :order_item_etiqueta_TipoLigacao_3965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoLigacao_3965", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1NomeExato" || parametro.FieldName == "Var1NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_nome LIKE :order_item_etiqueta_Var1Nome_3803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var1Nome_3803", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1ValorExato" || parametro.FieldName == "Var1ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_1_valor LIKE :order_item_etiqueta_Var1Valor_3271 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var1Valor_3271", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2NomeExato" || parametro.FieldName == "Var2NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_nome LIKE :order_item_etiqueta_Var2Nome_4299 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var2Nome_4299", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2ValorExato" || parametro.FieldName == "Var2ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_2_valor LIKE :order_item_etiqueta_Var2Valor_8981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var2Valor_8981", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3NomeExato" || parametro.FieldName == "Var3NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_nome LIKE :order_item_etiqueta_Var3Nome_2031 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var3Nome_2031", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3ValorExato" || parametro.FieldName == "Var3ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_3_valor LIKE :order_item_etiqueta_Var3Valor_7513 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var3Valor_7513", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4NomeExato" || parametro.FieldName == "Var4NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_nome LIKE :order_item_etiqueta_Var4Nome_8013 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var4Nome_8013", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4ValorExato" || parametro.FieldName == "Var4ValorExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_var_4_valor LIKE :order_item_etiqueta_Var4Valor_6576 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_Var4Valor_6576", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "KitFantasiaExato" || parametro.FieldName == "KitFantasiaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_kit_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_kit_fantasia LIKE :order_item_etiqueta_KitFantasia_8365 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_KitFantasia_8365", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumentoExato" || parametro.FieldName == "TipoDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_tipo_documento LIKE :order_item_etiqueta_TipoDocumento_2370 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_TipoDocumento_2370", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumentoExato" || parametro.FieldName == "NumeroDocumentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_numero_documento LIKE :order_item_etiqueta_NumeroDocumento_6407 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_NumeroDocumento_6407", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDesenhoExato" || parametro.FieldName == "RevisaoDesenhoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_revisao_desenho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_revisao_desenho LIKE :order_item_etiqueta_RevisaoDesenho_5748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_RevisaoDesenho_5748", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemPaiExato" || parametro.FieldName == "CodigoItemPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_codigo_item_pai LIKE :order_item_etiqueta_CodigoItemPai_9685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_CodigoItemPai_9685", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VerOcExato" || parametro.FieldName == "VerOcExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_ver_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_ver_oc LIKE :order_item_etiqueta_VerOc_3246 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_VerOc_3246", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabamentoSuperficialExato" || parametro.FieldName == "AcabamentoSuperficialExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_acabamento_superficial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_acabamento_superficial LIKE :order_item_etiqueta_AcabamentoSuperficial_3654 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_AcabamentoSuperficial_3654", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescItemPaiExato" || parametro.FieldName == "DescItemPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_desc_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_desc_item_pai LIKE :order_item_etiqueta_DescItemPai_8359 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_DescItemPai_8359", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabItemPaiExato" || parametro.FieldName == "AcabItemPaiExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_acab_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_acab_item_pai LIKE :order_item_etiqueta_AcabItemPai_691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_AcabItemPai_691", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesEspeciaisExato" || parametro.FieldName == "InformacoesEspeciaisExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta.oie_informacoes_especiais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.oie_informacoes_especiais LIKE :order_item_etiqueta_InformacoesEspeciais_118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_InformacoesEspeciais_118", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item_etiqueta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta.entity_uid LIKE :order_item_etiqueta_EntityUid_4316 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_EntityUid_4316", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrderItemEtiquetaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrderItemEtiquetaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrderItemEtiquetaClass), Convert.ToInt32(read["id_order_item_etiqueta"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrderItemEtiquetaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_order_item_etiqueta"]);
                     entidade.OrderNumber = (read["oie_order_number"] != DBNull.Value ? read["oie_order_number"].ToString() : null);
                     entidade.OrderPos = read["oie_order_pos"] as int?;
                     entidade.CodigoItem = (read["oie_codigo_item"] != DBNull.Value ? read["oie_codigo_item"].ToString() : null);
                     entidade.Descricao = (read["oie_descricao"] != DBNull.Value ? read["oie_descricao"].ToString() : null);
                     entidade.TipoItem = (TipoControleEtiquetaProduto?) (read["oie_tipo_item"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(TipoControleEtiquetaProduto?)), read["oie_tipo_item"]) : null);
                     entidade.Dimensao = (read["oie_dimensao"] != DBNull.Value ? read["oie_dimensao"].ToString() : null);
                     entidade.Pps = read["oie_pps"] as int?;
                     entidade.QtdEtiquetas = read["oie_qtd_etiquetas"] as int?;
                     entidade.EtiquetaAgrupada = (read["oie_etiqueta_agrupada"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["oie_etiqueta_agrupada"])) : null);
                     entidade.Cubagem = read["oie_cubagem"] as double?;
                     entidade.Peso = read["oie_peso"] as double?;
                     entidade.Volumes = read["oie_volumes"] as int?;
                     entidade.Saldo = (double)read["oie_saldo"];
                     entidade.SituacaoConferencia = (SituacaoConferencia) (read["oie_situacao_conferencia"] != DBNull.Value ? Enum.ToObject(typeof(SituacaoConferencia), read["oie_situacao_conferencia"]) : null);
                     entidade.NivelItem = read["oie_nivel_item"] as short?;
                     entidade.Ovm = (read["oie_ovm"] != DBNull.Value ? read["oie_ovm"].ToString() : null);
                     entidade.Deps = (read["oie_deps"] != DBNull.Value ? read["oie_deps"].ToString() : null);
                     entidade.Peps = (read["oie_peps"] != DBNull.Value ? read["oie_peps"].ToString() : null);
                     entidade.EtiquetaExpedicaoImpressa = Convert.ToBoolean(Convert.ToInt16(read["oie_etiqueta_expedicao_impressa"]));
                     entidade.UsarTimer = Convert.ToBoolean(Convert.ToInt16(read["oie_usar_timer"]));
                     entidade.PermitirParcial = Convert.ToBoolean(Convert.ToInt16(read["oie_permitir_parcial"]));
                     entidade.Quantidade = (double)read["oie_quantidade"];
                     entidade.Pallet = read["oie_pallet"] as short?;
                     entidade.NotaFiscalEmitida = Convert.ToBoolean(Convert.ToInt16(read["oie_nota_fiscal_emitida"]));
                     entidade.SituacaoConferenciaNf = (SituacaoConferencia) (read["oie_situacao_conferencia_nf"] != DBNull.Value ? Enum.ToObject(typeof(SituacaoConferencia), read["oie_situacao_conferencia_nf"]) : null);
                     entidade.PrecoTotal = read["oie_preco_total"] as double?;
                     entidade.PrecoUnitario = read["oie_preco_unitario"] as double?;
                     entidade.EmissaoParcial = Convert.ToBoolean(Convert.ToInt16(read["oie_emissao_parcial"]));
                     entidade.StatusPedido = (read["oie_status_pedido"] != DBNull.Value ? read["oie_status_pedido"].ToString() : null);
                     entidade.ArmazenagemCliente = (read["oie_armazenagem_cliente"] != DBNull.Value ? read["oie_armazenagem_cliente"].ToString() : null);
                     entidade.DescricaoCliente = (read["oie_descricao_cliente"] != DBNull.Value ? read["oie_descricao_cliente"].ToString() : null);
                     entidade.CodigoCliente = (read["oie_codigo_cliente"] != DBNull.Value ? read["oie_codigo_cliente"].ToString() : null);
                     entidade.IdExternoClienteAccess = (read["id_externo_cliente_access"] != DBNull.Value ? read["id_externo_cliente_access"].ToString() : null);
                     entidade.CnpjPedido = (read["oie_cnpj_pedido"] != DBNull.Value ? read["oie_cnpj_pedido"].ToString() : null);
                     entidade.Cfop = read["oie_cfop"] as int?;
                     entidade.NaturezaOperacao = (read["oie_natureza_operacao"] != DBNull.Value ? read["oie_natureza_operacao"].ToString() : null);
                     entidade.TipoOperacao = (read["oie_tipo_operacao"] != DBNull.Value ? read["oie_tipo_operacao"].ToString() : null);
                     entidade.NbmPedido = (read["oie_nbm_pedido"] != DBNull.Value ? read["oie_nbm_pedido"].ToString() : null);
                     entidade.Frete = (double)read["oie_frete"];
                     entidade.NotaFiscal = (read["oie_nota_fiscal"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["oie_nota_fiscal"])) : null);
                     entidade.EtiquetaInterna = Convert.ToBoolean(Convert.ToInt16(read["oie_etiqueta_interna"]));
                     entidade.SaldoConferencia = (double)read["oie_saldo_conferencia"];
                     entidade.Cnc = (read["oie_cnc"] != DBNull.Value ? read["oie_cnc"].ToString() : null);
                     entidade.CoordenadaX = (read["oie_coordenada_x"] != DBNull.Value ? read["oie_coordenada_x"].ToString() : null);
                     entidade.CoordenadaY = (read["oie_coordenada_y"] != DBNull.Value ? read["oie_coordenada_y"].ToString() : null);
                     entidade.EtiquetaInternaImpressa = Convert.ToBoolean(Convert.ToInt16(read["oie_etiqueta_interna_impressa"]));
                     entidade.Saf = (read["oie_saf"] != DBNull.Value ? read["oie_saf"].ToString() : null);
                     entidade.Programador = (read["oie_programador"] != DBNull.Value ? read["oie_programador"].ToString() : null);
                     entidade.ConferenciaCustomizadaRealizada = Convert.ToBoolean(Convert.ToInt16(read["oie_conferencia_customizada_realizada"]));
                     entidade.ConferenciaCustomizadaRealizadaForcada = Convert.ToBoolean(Convert.ToInt16(read["oie_conferencia_customizada_realizada_forcada"]));
                     entidade.QtdEtiquetaExpVolume = (int)read["oie_qtd_etiqueta_exp_volume"];
                     entidade.DescricaoPt = (read["oie_descricao_pt"] != DBNull.Value ? read["oie_descricao_pt"].ToString() : null);
                     entidade.DescricaoEn = (read["oie_descricao_en"] != DBNull.Value ? read["oie_descricao_en"].ToString() : null);
                     entidade.DescricaoEs = (read["oie_descricao_es"] != DBNull.Value ? read["oie_descricao_es"].ToString() : null);
                     entidade.ImprimePackingList = Convert.ToBoolean(Convert.ToInt16(read["oie_imprime_packing_list"]));
                     entidade.TipoBaseboard = (read["oie_tipo_baseboard"] != DBNull.Value ? read["oie_tipo_baseboard"].ToString() : null);
                     entidade.Altura = read["oie_altura"] as double?;
                     entidade.Largura = read["oie_largura"] as double?;
                     entidade.Comprimento = read["oie_comprimento"] as double?;
                     entidade.TipoLigacao = (read["oie_tipo_ligacao"] != DBNull.Value ? read["oie_tipo_ligacao"].ToString() : null);
                     entidade.PackinglistKitImpresso = (read["oie_packinglist_kit_impresso"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["oie_packinglist_kit_impresso"])) : null);
                     entidade.Var1Nome = (read["oie_var_1_nome"] != DBNull.Value ? read["oie_var_1_nome"].ToString() : null);
                     entidade.Var1Valor = (read["oie_var_1_valor"] != DBNull.Value ? read["oie_var_1_valor"].ToString() : null);
                     entidade.Var2Nome = (read["oie_var_2_nome"] != DBNull.Value ? read["oie_var_2_nome"].ToString() : null);
                     entidade.Var2Valor = (read["oie_var_2_valor"] != DBNull.Value ? read["oie_var_2_valor"].ToString() : null);
                     entidade.Var3Nome = (read["oie_var_3_nome"] != DBNull.Value ? read["oie_var_3_nome"].ToString() : null);
                     entidade.Var3Valor = (read["oie_var_3_valor"] != DBNull.Value ? read["oie_var_3_valor"].ToString() : null);
                     entidade.Var4Nome = (read["oie_var_4_nome"] != DBNull.Value ? read["oie_var_4_nome"].ToString() : null);
                     entidade.Var4Valor = (read["oie_var_4_valor"] != DBNull.Value ? read["oie_var_4_valor"].ToString() : null);
                     entidade.DataEntrega = read["oie_data_entrega"] as DateTime?;
                     entidade.KitFantasia = (read["oie_kit_fantasia"] != DBNull.Value ? read["oie_kit_fantasia"].ToString() : null);
                     entidade.PkKitTemp = read["oie_pk_kit_temp"] as short?;
                     entidade.DataImpressaoOp = read["oie_data_impressao_op"] as DateTime?;
                     entidade.TipoDocumento = (read["oie_tipo_documento"] != DBNull.Value ? read["oie_tipo_documento"].ToString() : null);
                     entidade.NumeroDocumento = (read["oie_numero_documento"] != DBNull.Value ? read["oie_numero_documento"].ToString() : null);
                     entidade.RevisaoDesenho = (read["oie_revisao_desenho"] != DBNull.Value ? read["oie_revisao_desenho"].ToString() : null);
                     entidade.CodigoItemPai = (read["oie_codigo_item_pai"] != DBNull.Value ? read["oie_codigo_item_pai"].ToString() : null);
                     entidade.OrdemProducaoImpressa = Convert.ToBoolean(Convert.ToInt16(read["oie_ordem_producao_impressa"]));
                     entidade.OrdemProducaoImpressaData = read["oie_ordem_producao_impressa_data"] as DateTime?;
                     entidade.VerOc = (read["oie_ver_oc"] != DBNull.Value ? read["oie_ver_oc"].ToString() : null);
                     entidade.AcabamentoSuperficial = (read["oie_acabamento_superficial"] != DBNull.Value ? read["oie_acabamento_superficial"].ToString() : null);
                     entidade.ItemOriginalPedido = Convert.ToBoolean(Convert.ToInt16(read["oie_item_original_pedido"]));
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_pedido_item"] != DBNull.Value)
                     {
                        entidade.PedidoItem = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItem = null ;
                     }
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.DescItemPai = (read["oie_desc_item_pai"] != DBNull.Value ? read["oie_desc_item_pai"].ToString() : null);
                     entidade.AcabItemPai = (read["oie_acab_item_pai"] != DBNull.Value ? read["oie_acab_item_pai"].ToString() : null);
                     if (read["id_produto_k"] != DBNull.Value)
                     {
                        entidade.ProdutoK = (BibliotecaEntidades.Entidades.ProdutoKClass)BibliotecaEntidades.Entidades.ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoK = null ;
                     }
                     entidade.CompraMpGerado = Convert.ToBoolean(Convert.ToInt16(read["oie_compra_mp_gerado"]));
                     entidade.CompraMpDataGeracao = read["oie_compra_mp_data_geracao"] as DateTime?;
                     entidade.InformacoesEspeciais = (read["oie_informacoes_especiais"] != DBNull.Value ? read["oie_informacoes_especiais"].ToString() : null);
                     entidade.VersaoEstruturaItem = (int)read["oie_versao_estrutura_item"];
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["oie_rastreamento_material"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ResponsavelFrete = (ResponsavelFrete) (read["oie_responsavel_frete"] != DBNull.Value ? Enum.ToObject(typeof(ResponsavelFrete), read["oie_responsavel_frete"]) : null);
                     entidade.VolumeUnico = Convert.ToBoolean(Convert.ToInt16(read["oie_volume_unico"]));
                     if (read["id_order_item_etiqueta_pai"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiquetaPai = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiquetaPai = null ;
                     }
                     if (read["id_modelo_etiqueta_expedicao"] != DBNull.Value)
                     {
                        entidade.ModeloEtiquetaExpedicao = (BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass)BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass.GetEntidade(Convert.ToInt32(read["id_modelo_etiqueta_expedicao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ModeloEtiquetaExpedicao = null ;
                     }
                     if (read["id_pedido_item_linha_principal_pedido"] != DBNull.Value)
                     {
                        entidade.PedidoItemLinhaPrincipalPedido = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item_linha_principal_pedido"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItemLinhaPrincipalPedido = null ;
                     }
                     entidade.TipoAquisicaoProduto = (TipoAquisicao) (read["oie_tipo_aquisicao_produto"] != DBNull.Value ? Enum.ToObject(typeof(TipoAquisicao), read["oie_tipo_aquisicao_produto"]) : null);
                     if (read["id_unidade_medida"] != DBNull.Value)
                     {
                        entidade.UnidadeMedida = (BibliotecaEntidades.Entidades.UnidadeMedidaClass)BibliotecaEntidades.Entidades.UnidadeMedidaClass.GetEntidade(Convert.ToInt32(read["id_unidade_medida"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UnidadeMedida = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrderItemEtiquetaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
