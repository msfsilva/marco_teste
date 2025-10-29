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
     [Table("orcamento_configurado","orc")]
     public class OrcamentoConfiguradoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrcamentoConfiguradoClass";
protected const string ErroDelete = "Erro ao excluir o OrcamentoConfiguradoClass  ";
protected const string ErroSave = "Erro ao salvar o OrcamentoConfiguradoClass.";
protected const string ErroCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai = "Erro ao carregar a coleção de OrcamentoConfiguradoClass.";
protected const string ErroStatusPedidoObrigatorio = "O campo StatusPedido é obrigatório";
protected const string ErroStatusPedidoComprimento = "O campo StatusPedido deve ter no máximo 2 caracteres";
protected const string ErroArmazenagemClienteObrigatorio = "O campo ArmazenagemCliente é obrigatório";
protected const string ErroArmazenagemClienteComprimento = "O campo ArmazenagemCliente deve ter no máximo 100 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloEtiquetaExpedicaoObrigatorio = "O campo ModeloEtiquetaExpedicao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrcamentoConfiguradoClass.";
protected const string MensagemUtilizadoCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai =  "A entidade OrcamentoConfiguradoClass está sendo utilizada nos seguintes OrcamentoConfiguradoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrcamentoConfiguradoClass está sendo utilizada.";
#endregion
       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("orc_order_number")]
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
         [Column("orc_order_pos")]
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
         [Column("orc_codigo_item")]
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
         [Column("orc_descricao")]
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
         [Column("orc_tipo_item")]
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
         [Column("orc_dimensao")]
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
         [Column("orc_pps")]
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
         [Column("orc_qtd_etiquetas")]
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
         [Column("orc_etiqueta_agrupada")]
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
         [Column("orc_cubagem")]
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
         [Column("orc_peso")]
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
         [Column("orc_volumes")]
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
         [Column("orc_saldo")]
        public virtual double Saldo
         { 
            get { return this._valueSaldo; } 
            set 
            { 
                if (this._valueSaldo == value)return;
                 this._valueSaldo = value; 
            } 
        } 

       protected SituacaoConferencia? _situacaoConferenciaOriginal{get;private set;}
       private SituacaoConferencia? _situacaoConferenciaOriginalCommited{get; set;}
        private SituacaoConferencia? _valueSituacaoConferencia;
         [Column("orc_situacao_conferencia")]
        public virtual SituacaoConferencia? SituacaoConferencia
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
            get { return this._valueSituacaoConferencia.HasValue && this._valueSituacaoConferencia.Value == BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.NaoIniciada; }
         } 

        public bool SituacaoConferencia_Parcial
         { 
            get { return this._valueSituacaoConferencia.HasValue && this._valueSituacaoConferencia.Value == BibliotecaEntidades.Base.SituacaoConferencia.Parcial; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.Parcial; }
         } 

        public bool SituacaoConferencia_Total
         { 
            get { return this._valueSituacaoConferencia.HasValue && this._valueSituacaoConferencia.Value == BibliotecaEntidades.Base.SituacaoConferencia.Total; } 
            set { if (value) this._valueSituacaoConferencia = BibliotecaEntidades.Base.SituacaoConferencia.Total; }
         } 

       protected short? _nivelItemOriginal{get;private set;}
       private short? _nivelItemOriginalCommited{get; set;}
        private short? _valueNivelItem;
         [Column("orc_nivel_item")]
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
         [Column("orc_ovm")]
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
         [Column("orc_deps")]
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
         [Column("orc_peps")]
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
         [Column("orc_etiqueta_expedicao_impressa")]
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
         [Column("orc_usar_timer")]
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
         [Column("orc_permitir_parcial")]
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
         [Column("orc_quantidade")]
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
         [Column("orc_pallet")]
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
         [Column("orc_nota_fiscal_emitida")]
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
         [Column("orc_situacao_conferencia_nf")]
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
         [Column("orc_preco_total")]
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
         [Column("orc_preco_unitario")]
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
         [Column("orc_emissao_parcial")]
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
         [Column("orc_status_pedido")]
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
         [Column("orc_armazenagem_cliente")]
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
         [Column("orc_descricao_cliente")]
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
         [Column("orc_codigo_cliente")]
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
         [Column("orc_cnpj_pedido")]
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
         [Column("orc_cfop")]
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
         [Column("orc_natureza_operacao")]
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
         [Column("orc_tipo_operacao")]
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
         [Column("orc_nbm_pedido")]
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
         [Column("orc_frete")]
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
         [Column("orc_nota_fiscal")]
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
         [Column("orc_etiqueta_interna")]
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
         [Column("orc_saldo_conferencia")]
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
         [Column("orc_cnc")]
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
         [Column("orc_coordenada_x")]
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
         [Column("orc_coordenada_y")]
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
         [Column("orc_etiqueta_interna_impressa")]
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
         [Column("orc_saf")]
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
         [Column("orc_programador")]
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
         [Column("orc_conferencia_customizada_realizada")]
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
         [Column("orc_conferencia_customizada_realizada_forcada")]
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
         [Column("orc_qtd_etiqueta_exp_volume")]
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
         [Column("orc_descricao_pt")]
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
         [Column("orc_descricao_en")]
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
         [Column("orc_descricao_es")]
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
         [Column("orc_imprime_packing_list")]
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
         [Column("orc_tipo_baseboard")]
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
         [Column("orc_altura")]
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
         [Column("orc_largura")]
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
         [Column("orc_comprimento")]
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
         [Column("orc_tipo_ligacao")]
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
         [Column("orc_packinglist_kit_impresso")]
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
         [Column("orc_var_1_nome")]
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
         [Column("orc_var_1_valor")]
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
         [Column("orc_var_2_nome")]
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
         [Column("orc_var_2_valor")]
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
         [Column("orc_var_3_nome")]
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
         [Column("orc_var_3_valor")]
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
         [Column("orc_var_4_nome")]
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
         [Column("orc_var_4_valor")]
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
         [Column("orc_data_entrega")]
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
         [Column("orc_kit_fantasia")]
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
         [Column("orc_pk_kit_temp")]
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
         [Column("orc_data_impressao_op")]
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
         [Column("orc_tipo_documento")]
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
         [Column("orc_numero_documento")]
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
         [Column("orc_revisao_desenho")]
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
         [Column("orc_codigo_item_pai")]
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
         [Column("orc_ordem_producao_impressa")]
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
         [Column("orc_ordem_producao_impressa_data")]
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
         [Column("orc_ver_oc")]
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
         [Column("orc_acabamento_superficial")]
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
         [Column("orc_item_original_pedido")]
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

       protected BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _orcamentoItemOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoItemClass _valueOrcamentoItem;
        [Column("id_orcamento_item", "orcamento_item", "id_orcamento_item")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoItemClass OrcamentoItem
        { 
           get {                 return this._valueOrcamentoItem; } 
           set 
           { 
                if (this._valueOrcamentoItem == value)return;
                 this._valueOrcamentoItem = value; 
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
         [Column("orc_desc_item_pai")]
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
         [Column("orc_acab_item_pai")]
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
         [Column("orc_compra_mp_gerado")]
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
         [Column("orc_compra_mp_data_geracao")]
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
         [Column("orc_informacoes_especiais")]
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
         [Column("orc_versao_estrutura_item")]
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
         [Column("orc_rastreamento_material")]
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
         [Column("orc_responsavel_frete")]
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
         [Column("orc_volume_unico")]
        public virtual bool VolumeUnico
         { 
            get { return this._valueVolumeUnico; } 
            set 
            { 
                if (this._valueVolumeUnico == value)return;
                 this._valueVolumeUnico = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass _orcamentoConfiguradoPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass _orcamentoConfiguradoPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass _valueOrcamentoConfiguradoPai;
        [Column("id_orcamento_configurado_pai", "orcamento_configurado", "id_orcamento_configurado")]
       public virtual BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass OrcamentoConfiguradoPai
        { 
           get {                 return this._valueOrcamentoConfiguradoPai; } 
           set 
           { 
                if (this._valueOrcamentoConfiguradoPai == value)return;
                 this._valueOrcamentoConfiguradoPai = value; 
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

       protected TipoAquisicao _tipoAquisicaoProdutoOriginal{get;private set;}
       private TipoAquisicao _tipoAquisicaoProdutoOriginalCommited{get; set;}
        private TipoAquisicao _valueTipoAquisicaoProduto;
         [Column("orc_tipo_aquisicao_produto")]
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

       private List<long> _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiOriginal;
       private List<Entidades.OrcamentoConfiguradoClass > _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoConfiguradoClass> _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoConfiguradoClass> CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai 
       { 
           get { if(!_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai();}
return this._valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai; } 
           set 
           { 
               this._valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai = value; 
               this._valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded = true; 
           } 
       } 

        public OrcamentoConfiguradoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.SituacaoConferencia = (SituacaoConferencia?)0;
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

public static OrcamentoConfiguradoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrcamentoConfiguradoClass) GetEntity(typeof(OrcamentoConfiguradoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged = true;
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged = true; 
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged = true;
                 foreach (Entidades.OrcamentoConfiguradoClass item in _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai) 
                 { 
                     _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoConfiguradoClass> oc;
                _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged = false;
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged = false;
                _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoConfiguradoClass>();
                }
                else{ 
                   Entidades.OrcamentoConfiguradoClass search = new Entidades.OrcamentoConfiguradoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoConfiguradoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrcamentoConfiguradoPai", this),                     }                       ).Cast<Entidades.OrcamentoConfiguradoClass>().ToList());
                 }
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai = new BindingList<Entidades.OrcamentoConfiguradoClass>(oc); 
                 _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai select a.ID).ToList();
                 _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai+"\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(ArmazenagemCliente))
                {
                    throw new Exception(ErroArmazenagemClienteObrigatorio);
                }
                if (ArmazenagemCliente.Length >100)
                {
                    throw new Exception( ErroArmazenagemClienteComprimento);
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
                    "  public.orcamento_configurado  " +
                    "WHERE " +
                    "  id_orcamento_configurado = :id";
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
                        "  public.orcamento_configurado   " +
                        "SET  " + 
                        "  orc_order_number = :orc_order_number, " + 
                        "  orc_order_pos = :orc_order_pos, " + 
                        "  orc_codigo_item = :orc_codigo_item, " + 
                        "  orc_descricao = :orc_descricao, " + 
                        "  orc_tipo_item = :orc_tipo_item, " + 
                        "  orc_dimensao = :orc_dimensao, " + 
                        "  orc_pps = :orc_pps, " + 
                        "  orc_qtd_etiquetas = :orc_qtd_etiquetas, " + 
                        "  orc_etiqueta_agrupada = :orc_etiqueta_agrupada, " + 
                        "  orc_cubagem = :orc_cubagem, " + 
                        "  orc_peso = :orc_peso, " + 
                        "  orc_volumes = :orc_volumes, " + 
                        "  orc_saldo = :orc_saldo, " + 
                        "  orc_situacao_conferencia = :orc_situacao_conferencia, " + 
                        "  orc_nivel_item = :orc_nivel_item, " + 
                        "  orc_ovm = :orc_ovm, " + 
                        "  orc_deps = :orc_deps, " + 
                        "  orc_peps = :orc_peps, " + 
                        "  orc_etiqueta_expedicao_impressa = :orc_etiqueta_expedicao_impressa, " + 
                        "  orc_usar_timer = :orc_usar_timer, " + 
                        "  orc_permitir_parcial = :orc_permitir_parcial, " + 
                        "  orc_quantidade = :orc_quantidade, " + 
                        "  orc_pallet = :orc_pallet, " + 
                        "  orc_nota_fiscal_emitida = :orc_nota_fiscal_emitida, " + 
                        "  orc_situacao_conferencia_nf = :orc_situacao_conferencia_nf, " + 
                        "  orc_preco_total = :orc_preco_total, " + 
                        "  orc_preco_unitario = :orc_preco_unitario, " + 
                        "  orc_emissao_parcial = :orc_emissao_parcial, " + 
                        "  orc_status_pedido = :orc_status_pedido, " + 
                        "  orc_armazenagem_cliente = :orc_armazenagem_cliente, " + 
                        "  orc_descricao_cliente = :orc_descricao_cliente, " + 
                        "  orc_codigo_cliente = :orc_codigo_cliente, " + 
                        "  id_externo_cliente_access = :id_externo_cliente_access, " + 
                        "  orc_cnpj_pedido = :orc_cnpj_pedido, " + 
                        "  orc_cfop = :orc_cfop, " + 
                        "  orc_natureza_operacao = :orc_natureza_operacao, " + 
                        "  orc_tipo_operacao = :orc_tipo_operacao, " + 
                        "  orc_nbm_pedido = :orc_nbm_pedido, " + 
                        "  orc_frete = :orc_frete, " + 
                        "  orc_nota_fiscal = :orc_nota_fiscal, " + 
                        "  orc_etiqueta_interna = :orc_etiqueta_interna, " + 
                        "  orc_saldo_conferencia = :orc_saldo_conferencia, " + 
                        "  orc_cnc = :orc_cnc, " + 
                        "  orc_coordenada_x = :orc_coordenada_x, " + 
                        "  orc_coordenada_y = :orc_coordenada_y, " + 
                        "  orc_etiqueta_interna_impressa = :orc_etiqueta_interna_impressa, " + 
                        "  orc_saf = :orc_saf, " + 
                        "  orc_programador = :orc_programador, " + 
                        "  orc_conferencia_customizada_realizada = :orc_conferencia_customizada_realizada, " + 
                        "  orc_conferencia_customizada_realizada_forcada = :orc_conferencia_customizada_realizada_forcada, " + 
                        "  orc_qtd_etiqueta_exp_volume = :orc_qtd_etiqueta_exp_volume, " + 
                        "  orc_descricao_pt = :orc_descricao_pt, " + 
                        "  orc_descricao_en = :orc_descricao_en, " + 
                        "  orc_descricao_es = :orc_descricao_es, " + 
                        "  orc_imprime_packing_list = :orc_imprime_packing_list, " + 
                        "  orc_tipo_baseboard = :orc_tipo_baseboard, " + 
                        "  orc_altura = :orc_altura, " + 
                        "  orc_largura = :orc_largura, " + 
                        "  orc_comprimento = :orc_comprimento, " + 
                        "  orc_tipo_ligacao = :orc_tipo_ligacao, " + 
                        "  orc_packinglist_kit_impresso = :orc_packinglist_kit_impresso, " + 
                        "  orc_var_1_nome = :orc_var_1_nome, " + 
                        "  orc_var_1_valor = :orc_var_1_valor, " + 
                        "  orc_var_2_nome = :orc_var_2_nome, " + 
                        "  orc_var_2_valor = :orc_var_2_valor, " + 
                        "  orc_var_3_nome = :orc_var_3_nome, " + 
                        "  orc_var_3_valor = :orc_var_3_valor, " + 
                        "  orc_var_4_nome = :orc_var_4_nome, " + 
                        "  orc_var_4_valor = :orc_var_4_valor, " + 
                        "  orc_data_entrega = :orc_data_entrega, " + 
                        "  orc_kit_fantasia = :orc_kit_fantasia, " + 
                        "  orc_pk_kit_temp = :orc_pk_kit_temp, " + 
                        "  orc_data_impressao_op = :orc_data_impressao_op, " + 
                        "  orc_tipo_documento = :orc_tipo_documento, " + 
                        "  orc_numero_documento = :orc_numero_documento, " + 
                        "  orc_revisao_desenho = :orc_revisao_desenho, " + 
                        "  orc_codigo_item_pai = :orc_codigo_item_pai, " + 
                        "  orc_ordem_producao_impressa = :orc_ordem_producao_impressa, " + 
                        "  orc_ordem_producao_impressa_data = :orc_ordem_producao_impressa_data, " + 
                        "  orc_ver_oc = :orc_ver_oc, " + 
                        "  orc_acabamento_superficial = :orc_acabamento_superficial, " + 
                        "  orc_item_original_pedido = :orc_item_original_pedido, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  id_orcamento_item = :id_orcamento_item, " + 
                        "  id_produto = :id_produto, " + 
                        "  orc_desc_item_pai = :orc_desc_item_pai, " + 
                        "  orc_acab_item_pai = :orc_acab_item_pai, " + 
                        "  id_produto_k = :id_produto_k, " + 
                        "  orc_compra_mp_gerado = :orc_compra_mp_gerado, " + 
                        "  orc_compra_mp_data_geracao = :orc_compra_mp_data_geracao, " + 
                        "  orc_informacoes_especiais = :orc_informacoes_especiais, " + 
                        "  orc_versao_estrutura_item = :orc_versao_estrutura_item, " + 
                        "  orc_rastreamento_material = :orc_rastreamento_material, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  orc_responsavel_frete = :orc_responsavel_frete, " + 
                        "  orc_volume_unico = :orc_volume_unico, " + 
                        "  id_orcamento_configurado_pai = :id_orcamento_configurado_pai, " + 
                        "  id_modelo_etiqueta_expedicao = :id_modelo_etiqueta_expedicao, " + 
                        "  orc_tipo_aquisicao_produto = :orc_tipo_aquisicao_produto "+
                        "WHERE  " +
                        "  id_orcamento_configurado = :id " +
                        "RETURNING id_orcamento_configurado;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.orcamento_configurado " +
                        "( " +
                        "  orc_order_number , " + 
                        "  orc_order_pos , " + 
                        "  orc_codigo_item , " + 
                        "  orc_descricao , " + 
                        "  orc_tipo_item , " + 
                        "  orc_dimensao , " + 
                        "  orc_pps , " + 
                        "  orc_qtd_etiquetas , " + 
                        "  orc_etiqueta_agrupada , " + 
                        "  orc_cubagem , " + 
                        "  orc_peso , " + 
                        "  orc_volumes , " + 
                        "  orc_saldo , " + 
                        "  orc_situacao_conferencia , " + 
                        "  orc_nivel_item , " + 
                        "  orc_ovm , " + 
                        "  orc_deps , " + 
                        "  orc_peps , " + 
                        "  orc_etiqueta_expedicao_impressa , " + 
                        "  orc_usar_timer , " + 
                        "  orc_permitir_parcial , " + 
                        "  orc_quantidade , " + 
                        "  orc_pallet , " + 
                        "  orc_nota_fiscal_emitida , " + 
                        "  orc_situacao_conferencia_nf , " + 
                        "  orc_preco_total , " + 
                        "  orc_preco_unitario , " + 
                        "  orc_emissao_parcial , " + 
                        "  orc_status_pedido , " + 
                        "  orc_armazenagem_cliente , " + 
                        "  orc_descricao_cliente , " + 
                        "  orc_codigo_cliente , " + 
                        "  id_externo_cliente_access , " + 
                        "  orc_cnpj_pedido , " + 
                        "  orc_cfop , " + 
                        "  orc_natureza_operacao , " + 
                        "  orc_tipo_operacao , " + 
                        "  orc_nbm_pedido , " + 
                        "  orc_frete , " + 
                        "  orc_nota_fiscal , " + 
                        "  orc_etiqueta_interna , " + 
                        "  orc_saldo_conferencia , " + 
                        "  orc_cnc , " + 
                        "  orc_coordenada_x , " + 
                        "  orc_coordenada_y , " + 
                        "  orc_etiqueta_interna_impressa , " + 
                        "  orc_saf , " + 
                        "  orc_programador , " + 
                        "  orc_conferencia_customizada_realizada , " + 
                        "  orc_conferencia_customizada_realizada_forcada , " + 
                        "  orc_qtd_etiqueta_exp_volume , " + 
                        "  orc_descricao_pt , " + 
                        "  orc_descricao_en , " + 
                        "  orc_descricao_es , " + 
                        "  orc_imprime_packing_list , " + 
                        "  orc_tipo_baseboard , " + 
                        "  orc_altura , " + 
                        "  orc_largura , " + 
                        "  orc_comprimento , " + 
                        "  orc_tipo_ligacao , " + 
                        "  orc_packinglist_kit_impresso , " + 
                        "  orc_var_1_nome , " + 
                        "  orc_var_1_valor , " + 
                        "  orc_var_2_nome , " + 
                        "  orc_var_2_valor , " + 
                        "  orc_var_3_nome , " + 
                        "  orc_var_3_valor , " + 
                        "  orc_var_4_nome , " + 
                        "  orc_var_4_valor , " + 
                        "  orc_data_entrega , " + 
                        "  orc_kit_fantasia , " + 
                        "  orc_pk_kit_temp , " + 
                        "  orc_data_impressao_op , " + 
                        "  orc_tipo_documento , " + 
                        "  orc_numero_documento , " + 
                        "  orc_revisao_desenho , " + 
                        "  orc_codigo_item_pai , " + 
                        "  orc_ordem_producao_impressa , " + 
                        "  orc_ordem_producao_impressa_data , " + 
                        "  orc_ver_oc , " + 
                        "  orc_acabamento_superficial , " + 
                        "  orc_item_original_pedido , " + 
                        "  id_cliente , " + 
                        "  id_orcamento_item , " + 
                        "  id_produto , " + 
                        "  orc_desc_item_pai , " + 
                        "  orc_acab_item_pai , " + 
                        "  id_produto_k , " + 
                        "  orc_compra_mp_gerado , " + 
                        "  orc_compra_mp_data_geracao , " + 
                        "  orc_informacoes_especiais , " + 
                        "  orc_versao_estrutura_item , " + 
                        "  orc_rastreamento_material , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  orc_responsavel_frete , " + 
                        "  orc_volume_unico , " + 
                        "  id_orcamento_configurado_pai , " + 
                        "  id_modelo_etiqueta_expedicao , " + 
                        "  orc_tipo_aquisicao_produto  "+
                        ")  " +
                        "VALUES ( " +
                        "  :orc_order_number , " + 
                        "  :orc_order_pos , " + 
                        "  :orc_codigo_item , " + 
                        "  :orc_descricao , " + 
                        "  :orc_tipo_item , " + 
                        "  :orc_dimensao , " + 
                        "  :orc_pps , " + 
                        "  :orc_qtd_etiquetas , " + 
                        "  :orc_etiqueta_agrupada , " + 
                        "  :orc_cubagem , " + 
                        "  :orc_peso , " + 
                        "  :orc_volumes , " + 
                        "  :orc_saldo , " + 
                        "  :orc_situacao_conferencia , " + 
                        "  :orc_nivel_item , " + 
                        "  :orc_ovm , " + 
                        "  :orc_deps , " + 
                        "  :orc_peps , " + 
                        "  :orc_etiqueta_expedicao_impressa , " + 
                        "  :orc_usar_timer , " + 
                        "  :orc_permitir_parcial , " + 
                        "  :orc_quantidade , " + 
                        "  :orc_pallet , " + 
                        "  :orc_nota_fiscal_emitida , " + 
                        "  :orc_situacao_conferencia_nf , " + 
                        "  :orc_preco_total , " + 
                        "  :orc_preco_unitario , " + 
                        "  :orc_emissao_parcial , " + 
                        "  :orc_status_pedido , " + 
                        "  :orc_armazenagem_cliente , " + 
                        "  :orc_descricao_cliente , " + 
                        "  :orc_codigo_cliente , " + 
                        "  :id_externo_cliente_access , " + 
                        "  :orc_cnpj_pedido , " + 
                        "  :orc_cfop , " + 
                        "  :orc_natureza_operacao , " + 
                        "  :orc_tipo_operacao , " + 
                        "  :orc_nbm_pedido , " + 
                        "  :orc_frete , " + 
                        "  :orc_nota_fiscal , " + 
                        "  :orc_etiqueta_interna , " + 
                        "  :orc_saldo_conferencia , " + 
                        "  :orc_cnc , " + 
                        "  :orc_coordenada_x , " + 
                        "  :orc_coordenada_y , " + 
                        "  :orc_etiqueta_interna_impressa , " + 
                        "  :orc_saf , " + 
                        "  :orc_programador , " + 
                        "  :orc_conferencia_customizada_realizada , " + 
                        "  :orc_conferencia_customizada_realizada_forcada , " + 
                        "  :orc_qtd_etiqueta_exp_volume , " + 
                        "  :orc_descricao_pt , " + 
                        "  :orc_descricao_en , " + 
                        "  :orc_descricao_es , " + 
                        "  :orc_imprime_packing_list , " + 
                        "  :orc_tipo_baseboard , " + 
                        "  :orc_altura , " + 
                        "  :orc_largura , " + 
                        "  :orc_comprimento , " + 
                        "  :orc_tipo_ligacao , " + 
                        "  :orc_packinglist_kit_impresso , " + 
                        "  :orc_var_1_nome , " + 
                        "  :orc_var_1_valor , " + 
                        "  :orc_var_2_nome , " + 
                        "  :orc_var_2_valor , " + 
                        "  :orc_var_3_nome , " + 
                        "  :orc_var_3_valor , " + 
                        "  :orc_var_4_nome , " + 
                        "  :orc_var_4_valor , " + 
                        "  :orc_data_entrega , " + 
                        "  :orc_kit_fantasia , " + 
                        "  :orc_pk_kit_temp , " + 
                        "  :orc_data_impressao_op , " + 
                        "  :orc_tipo_documento , " + 
                        "  :orc_numero_documento , " + 
                        "  :orc_revisao_desenho , " + 
                        "  :orc_codigo_item_pai , " + 
                        "  :orc_ordem_producao_impressa , " + 
                        "  :orc_ordem_producao_impressa_data , " + 
                        "  :orc_ver_oc , " + 
                        "  :orc_acabamento_superficial , " + 
                        "  :orc_item_original_pedido , " + 
                        "  :id_cliente , " + 
                        "  :id_orcamento_item , " + 
                        "  :id_produto , " + 
                        "  :orc_desc_item_pai , " + 
                        "  :orc_acab_item_pai , " + 
                        "  :id_produto_k , " + 
                        "  :orc_compra_mp_gerado , " + 
                        "  :orc_compra_mp_data_geracao , " + 
                        "  :orc_informacoes_especiais , " + 
                        "  :orc_versao_estrutura_item , " + 
                        "  :orc_rastreamento_material , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :orc_responsavel_frete , " + 
                        "  :orc_volume_unico , " + 
                        "  :id_orcamento_configurado_pai , " + 
                        "  :id_modelo_etiqueta_expedicao , " + 
                        "  :orc_tipo_aquisicao_produto  "+
                        ")RETURNING id_orcamento_configurado;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_item", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoItem.HasValue ? (object)Convert.ToInt16(this.TipoItem) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_dimensao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Dimensao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_pps", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_qtd_etiquetas", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdEtiquetas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_etiqueta_agrupada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaAgrupada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_cubagem", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cubagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_peso", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Volumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_saldo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saldo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_situacao_conferencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.SituacaoConferencia.HasValue ? (object)Convert.ToInt16(this.SituacaoConferencia) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_nivel_item", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NivelItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_ovm", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ovm ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_deps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Deps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_peps", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Peps ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_etiqueta_expedicao_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaExpedicaoImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_usar_timer", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsarTimer ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_permitir_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermitirParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pallet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_nota_fiscal_emitida", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaFiscalEmitida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_situacao_conferencia_nf", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SituacaoConferenciaNf);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_preco_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_emissao_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EmissaoParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_status_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.StatusPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_armazenagem_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ArmazenagemCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_externo_cliente_access", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdExternoClienteAccess ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_cnpj_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_natureza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaturezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_nbm_pedido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NbmPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Frete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_nota_fiscal", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NotaFiscal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_etiqueta_interna", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaInterna ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_saldo_conferencia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SaldoConferencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_cnc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cnc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_coordenada_x", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CoordenadaX ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_coordenada_y", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CoordenadaY ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_etiqueta_interna_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EtiquetaInternaImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_saf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_programador", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Programador ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_conferencia_customizada_realizada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaCustomizadaRealizada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_conferencia_customizada_realizada_forcada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaCustomizadaRealizadaForcada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_qtd_etiqueta_exp_volume", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QtdEtiquetaExpVolume ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_descricao_pt", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoPt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_descricao_en", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoEn ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_descricao_es", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescricaoEs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_imprime_packing_list", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ImprimePackingList ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_baseboard", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoBaseboard ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_altura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Altura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_largura", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Largura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_comprimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Comprimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_ligacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoLigacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_packinglist_kit_impresso", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PackinglistKitImpresso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_1_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var1Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_1_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var1Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_2_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var2Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_2_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var2Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_3_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var3Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_3_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var3Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_4_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var4Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_var_4_valor", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Var4Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_entrega", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_kit_fantasia", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.KitFantasia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_pk_kit_temp", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PkKitTemp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_impressao_op", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataImpressaoOp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_numero_documento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroDocumento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_revisao_desenho", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RevisaoDesenho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_codigo_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_ordem_producao_impressa", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemProducaoImpressa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_ordem_producao_impressa_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemProducaoImpressaData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_ver_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VerOc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_acabamento_superficial", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AcabamentoSuperficial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_item_original_pedido", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ItemOriginalPedido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoItem==null ? (object) DBNull.Value : this.OrcamentoItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_desc_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_acab_item_pai", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AcabItemPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto_k", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ProdutoK==null ? (object) DBNull.Value : this.ProdutoK.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_compra_mp_gerado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompraMpGerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_compra_mp_data_geracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompraMpDataGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_informacoes_especiais", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacoesEspeciais ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_versao_estrutura_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VersaoEstruturaItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_responsavel_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ResponsavelFrete);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_volume_unico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeUnico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_orcamento_configurado_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrcamentoConfiguradoPai==null ? (object) DBNull.Value : this.OrcamentoConfiguradoPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_modelo_etiqueta_expedicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ModeloEtiquetaExpedicao==null ? (object) DBNull.Value : this.ModeloEtiquetaExpedicao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo_aquisicao_produto", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAquisicaoProduto);

 
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
 if (CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai+"\r\n";
                foreach (Entidades.OrcamentoConfiguradoClass tmp in CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai)
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
        public static OrcamentoConfiguradoClass CopiarEntidade(OrcamentoConfiguradoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrcamentoConfiguradoClass toRet = new OrcamentoConfiguradoClass(usuario,conn);
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
 toRet.OrcamentoItem= entidadeCopiar.OrcamentoItem;
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
 toRet.OrcamentoConfiguradoPai= entidadeCopiar.OrcamentoConfiguradoPai;
 toRet.ModeloEtiquetaExpedicao= entidadeCopiar.ModeloEtiquetaExpedicao;
 toRet.TipoAquisicaoProduto= entidadeCopiar.TipoAquisicaoProduto;

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
       _orcamentoItemOriginal = OrcamentoItem;
       _orcamentoItemOriginalCommited = _orcamentoItemOriginal;
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
       _orcamentoConfiguradoPaiOriginal = OrcamentoConfiguradoPai;
       _orcamentoConfiguradoPaiOriginalCommited = _orcamentoConfiguradoPaiOriginal;
       _modeloEtiquetaExpedicaoOriginal = ModeloEtiquetaExpedicao;
       _modeloEtiquetaExpedicaoOriginalCommited = _modeloEtiquetaExpedicaoOriginal;
       _tipoAquisicaoProdutoOriginal = TipoAquisicaoProduto;
       _tipoAquisicaoProdutoOriginalCommited = _tipoAquisicaoProdutoOriginal;

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
       _orcamentoItemOriginalCommited = OrcamentoItem;
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
       _orcamentoConfiguradoPaiOriginalCommited = OrcamentoConfiguradoPai;
       _modeloEtiquetaExpedicaoOriginalCommited = ModeloEtiquetaExpedicao;
       _tipoAquisicaoProdutoOriginalCommited = TipoAquisicaoProduto;

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  if (_collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos != null) 
                  {
                     _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos = new List<Entidades.OrcamentoConfiguradoClass>();
                  }
                  _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiOriginal= (from a in _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai select a.ID).ToList();
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged = false;
                  _valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged = false;
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
               OrcamentoItem=_orcamentoItemOriginal;
               _orcamentoItemOriginalCommited=_orcamentoItemOriginal;
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
               OrcamentoConfiguradoPai=_orcamentoConfiguradoPaiOriginal;
               _orcamentoConfiguradoPaiOriginalCommited=_orcamentoConfiguradoPaiOriginal;
               ModeloEtiquetaExpedicao=_modeloEtiquetaExpedicaoOriginal;
               _modeloEtiquetaExpedicaoOriginalCommited=_modeloEtiquetaExpedicaoOriginal;
               TipoAquisicaoProduto=_tipoAquisicaoProdutoOriginal;
               _tipoAquisicaoProdutoOriginalCommited=_tipoAquisicaoProdutoOriginal;
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai.Clear();
                  foreach(int item in _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiOriginal)
                  {
                    CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai.Add(Entidades.OrcamentoConfiguradoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiRemovidos.Clear();
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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai.Any(item => item.IsDirty());
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
       if (_orcamentoItemOriginal!=null)
       {
          dirty = !_orcamentoItemOriginal.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
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
       if (_orcamentoConfiguradoPaiOriginal!=null)
       {
          dirty = !_orcamentoConfiguradoPaiOriginal.Equals(OrcamentoConfiguradoPai);
       }
       else
       {
            dirty = OrcamentoConfiguradoPai != null;
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
       dirty = _tipoAquisicaoProdutoOriginal != TipoAquisicaoProduto;

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                   tempRet = CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai.Any(item => item.IsDirtyCommited());
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
       if (_orcamentoItemOriginalCommited!=null)
       {
          dirty = !_orcamentoItemOriginalCommited.Equals(OrcamentoItem);
       }
       else
       {
            dirty = OrcamentoItem != null;
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
       if (_orcamentoConfiguradoPaiOriginalCommited!=null)
       {
          dirty = !_orcamentoConfiguradoPaiOriginalCommited.Equals(OrcamentoConfiguradoPai);
       }
       else
       {
            dirty = OrcamentoConfiguradoPai != null;
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
       dirty = _tipoAquisicaoProdutoOriginalCommited != TipoAquisicaoProduto;

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
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai)
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
             case "OrcamentoItem":
                return this.OrcamentoItem;
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
             case "OrcamentoConfiguradoPai":
                return this.OrcamentoConfiguradoPai;
             case "ModeloEtiquetaExpedicao":
                return this.ModeloEtiquetaExpedicao;
             case "TipoAquisicaoProduto":
                return this.TipoAquisicaoProduto;
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
             if (OrcamentoItem!=null)
                OrcamentoItem.ChangeSingleConnection(newConnection);
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (ProdutoK!=null)
                ProdutoK.ChangeSingleConnection(newConnection);
             if (OrcamentoConfiguradoPai!=null)
                OrcamentoConfiguradoPai.ChangeSingleConnection(newConnection);
             if (ModeloEtiquetaExpedicao!=null)
                ModeloEtiquetaExpedicao.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPaiLoaded) 
               {
                  foreach(OrcamentoConfiguradoClass item in CollectionOrcamentoConfiguradoClassOrcamentoConfiguradoPai)
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
                  command.CommandText += " COUNT(orcamento_configurado.id_orcamento_configurado) " ;
               }
               else
               {
               command.CommandText += "orcamento_configurado.id_orcamento_configurado, " ;
               command.CommandText += "orcamento_configurado.orc_order_number, " ;
               command.CommandText += "orcamento_configurado.orc_order_pos, " ;
               command.CommandText += "orcamento_configurado.orc_codigo_item, " ;
               command.CommandText += "orcamento_configurado.orc_descricao, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_item, " ;
               command.CommandText += "orcamento_configurado.orc_dimensao, " ;
               command.CommandText += "orcamento_configurado.orc_pps, " ;
               command.CommandText += "orcamento_configurado.orc_qtd_etiquetas, " ;
               command.CommandText += "orcamento_configurado.orc_etiqueta_agrupada, " ;
               command.CommandText += "orcamento_configurado.orc_cubagem, " ;
               command.CommandText += "orcamento_configurado.orc_peso, " ;
               command.CommandText += "orcamento_configurado.orc_volumes, " ;
               command.CommandText += "orcamento_configurado.orc_saldo, " ;
               command.CommandText += "orcamento_configurado.orc_situacao_conferencia, " ;
               command.CommandText += "orcamento_configurado.orc_nivel_item, " ;
               command.CommandText += "orcamento_configurado.orc_ovm, " ;
               command.CommandText += "orcamento_configurado.orc_deps, " ;
               command.CommandText += "orcamento_configurado.orc_peps, " ;
               command.CommandText += "orcamento_configurado.orc_etiqueta_expedicao_impressa, " ;
               command.CommandText += "orcamento_configurado.orc_usar_timer, " ;
               command.CommandText += "orcamento_configurado.orc_permitir_parcial, " ;
               command.CommandText += "orcamento_configurado.orc_quantidade, " ;
               command.CommandText += "orcamento_configurado.orc_pallet, " ;
               command.CommandText += "orcamento_configurado.orc_nota_fiscal_emitida, " ;
               command.CommandText += "orcamento_configurado.orc_situacao_conferencia_nf, " ;
               command.CommandText += "orcamento_configurado.orc_preco_total, " ;
               command.CommandText += "orcamento_configurado.orc_preco_unitario, " ;
               command.CommandText += "orcamento_configurado.orc_emissao_parcial, " ;
               command.CommandText += "orcamento_configurado.orc_status_pedido, " ;
               command.CommandText += "orcamento_configurado.orc_armazenagem_cliente, " ;
               command.CommandText += "orcamento_configurado.orc_descricao_cliente, " ;
               command.CommandText += "orcamento_configurado.orc_codigo_cliente, " ;
               command.CommandText += "orcamento_configurado.id_externo_cliente_access, " ;
               command.CommandText += "orcamento_configurado.orc_cnpj_pedido, " ;
               command.CommandText += "orcamento_configurado.orc_cfop, " ;
               command.CommandText += "orcamento_configurado.orc_natureza_operacao, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_operacao, " ;
               command.CommandText += "orcamento_configurado.orc_nbm_pedido, " ;
               command.CommandText += "orcamento_configurado.orc_frete, " ;
               command.CommandText += "orcamento_configurado.orc_nota_fiscal, " ;
               command.CommandText += "orcamento_configurado.orc_etiqueta_interna, " ;
               command.CommandText += "orcamento_configurado.orc_saldo_conferencia, " ;
               command.CommandText += "orcamento_configurado.orc_cnc, " ;
               command.CommandText += "orcamento_configurado.orc_coordenada_x, " ;
               command.CommandText += "orcamento_configurado.orc_coordenada_y, " ;
               command.CommandText += "orcamento_configurado.orc_etiqueta_interna_impressa, " ;
               command.CommandText += "orcamento_configurado.orc_saf, " ;
               command.CommandText += "orcamento_configurado.orc_programador, " ;
               command.CommandText += "orcamento_configurado.orc_conferencia_customizada_realizada, " ;
               command.CommandText += "orcamento_configurado.orc_conferencia_customizada_realizada_forcada, " ;
               command.CommandText += "orcamento_configurado.orc_qtd_etiqueta_exp_volume, " ;
               command.CommandText += "orcamento_configurado.orc_descricao_pt, " ;
               command.CommandText += "orcamento_configurado.orc_descricao_en, " ;
               command.CommandText += "orcamento_configurado.orc_descricao_es, " ;
               command.CommandText += "orcamento_configurado.orc_imprime_packing_list, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_baseboard, " ;
               command.CommandText += "orcamento_configurado.orc_altura, " ;
               command.CommandText += "orcamento_configurado.orc_largura, " ;
               command.CommandText += "orcamento_configurado.orc_comprimento, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_ligacao, " ;
               command.CommandText += "orcamento_configurado.orc_packinglist_kit_impresso, " ;
               command.CommandText += "orcamento_configurado.orc_var_1_nome, " ;
               command.CommandText += "orcamento_configurado.orc_var_1_valor, " ;
               command.CommandText += "orcamento_configurado.orc_var_2_nome, " ;
               command.CommandText += "orcamento_configurado.orc_var_2_valor, " ;
               command.CommandText += "orcamento_configurado.orc_var_3_nome, " ;
               command.CommandText += "orcamento_configurado.orc_var_3_valor, " ;
               command.CommandText += "orcamento_configurado.orc_var_4_nome, " ;
               command.CommandText += "orcamento_configurado.orc_var_4_valor, " ;
               command.CommandText += "orcamento_configurado.orc_data_entrega, " ;
               command.CommandText += "orcamento_configurado.orc_kit_fantasia, " ;
               command.CommandText += "orcamento_configurado.orc_pk_kit_temp, " ;
               command.CommandText += "orcamento_configurado.orc_data_impressao_op, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_documento, " ;
               command.CommandText += "orcamento_configurado.orc_numero_documento, " ;
               command.CommandText += "orcamento_configurado.orc_revisao_desenho, " ;
               command.CommandText += "orcamento_configurado.orc_codigo_item_pai, " ;
               command.CommandText += "orcamento_configurado.orc_ordem_producao_impressa, " ;
               command.CommandText += "orcamento_configurado.orc_ordem_producao_impressa_data, " ;
               command.CommandText += "orcamento_configurado.orc_ver_oc, " ;
               command.CommandText += "orcamento_configurado.orc_acabamento_superficial, " ;
               command.CommandText += "orcamento_configurado.orc_item_original_pedido, " ;
               command.CommandText += "orcamento_configurado.id_cliente, " ;
               command.CommandText += "orcamento_configurado.id_orcamento_item, " ;
               command.CommandText += "orcamento_configurado.id_produto, " ;
               command.CommandText += "orcamento_configurado.orc_desc_item_pai, " ;
               command.CommandText += "orcamento_configurado.orc_acab_item_pai, " ;
               command.CommandText += "orcamento_configurado.id_produto_k, " ;
               command.CommandText += "orcamento_configurado.orc_compra_mp_gerado, " ;
               command.CommandText += "orcamento_configurado.orc_compra_mp_data_geracao, " ;
               command.CommandText += "orcamento_configurado.orc_informacoes_especiais, " ;
               command.CommandText += "orcamento_configurado.orc_versao_estrutura_item, " ;
               command.CommandText += "orcamento_configurado.orc_rastreamento_material, " ;
               command.CommandText += "orcamento_configurado.entity_uid, " ;
               command.CommandText += "orcamento_configurado.version, " ;
               command.CommandText += "orcamento_configurado.orc_responsavel_frete, " ;
               command.CommandText += "orcamento_configurado.orc_volume_unico, " ;
               command.CommandText += "orcamento_configurado.id_orcamento_configurado_pai, " ;
               command.CommandText += "orcamento_configurado.id_modelo_etiqueta_expedicao, " ;
               command.CommandText += "orcamento_configurado.orc_tipo_aquisicao_produto " ;
               }
               command.CommandText += " FROM  orcamento_configurado ";
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
                        orderByClause += " , orc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(orc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = orcamento_configurado.id_acs_usuario_ultima_revisao ";
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
                     case "id_orcamento_configurado":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.id_orcamento_configurado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.id_orcamento_configurado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo_item":
                     case "TipoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_tipo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_dimensao":
                     case "Dimensao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_dimensao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_dimensao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_pps":
                     case "Pps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_pps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_pps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_qtd_etiquetas":
                     case "QtdEtiquetas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_qtd_etiquetas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_qtd_etiquetas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_etiqueta_agrupada":
                     case "EtiquetaAgrupada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_etiqueta_agrupada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_etiqueta_agrupada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_cubagem":
                     case "Cubagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_cubagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_cubagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_peso":
                     case "Peso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_peso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_peso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_volumes":
                     case "Volumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_saldo":
                     case "Saldo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_saldo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_saldo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_situacao_conferencia":
                     case "SituacaoConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_situacao_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_situacao_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_nivel_item":
                     case "NivelItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_nivel_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_nivel_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_ovm":
                     case "Ovm":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_ovm " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_ovm) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_deps":
                     case "Deps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_deps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_deps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_peps":
                     case "Peps":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_peps " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_peps) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_etiqueta_expedicao_impressa":
                     case "EtiquetaExpedicaoImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_etiqueta_expedicao_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_etiqueta_expedicao_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_usar_timer":
                     case "UsarTimer":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_usar_timer " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_usar_timer) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_permitir_parcial":
                     case "PermitirParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_permitir_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_permitir_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_pallet":
                     case "Pallet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_nota_fiscal_emitida":
                     case "NotaFiscalEmitida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_nota_fiscal_emitida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_nota_fiscal_emitida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_situacao_conferencia_nf":
                     case "SituacaoConferenciaNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_situacao_conferencia_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_situacao_conferencia_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_preco_total":
                     case "PrecoTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_preco_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_preco_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_preco_unitario":
                     case "PrecoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_preco_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_preco_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_emissao_parcial":
                     case "EmissaoParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_emissao_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_emissao_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_status_pedido":
                     case "StatusPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_status_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_status_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_armazenagem_cliente":
                     case "ArmazenagemCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_armazenagem_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_armazenagem_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_descricao_cliente":
                     case "DescricaoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_codigo_cliente":
                     case "CodigoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_codigo_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_codigo_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_externo_cliente_access":
                     case "IdExternoClienteAccess":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.id_externo_cliente_access " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.id_externo_cliente_access) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_cnpj_pedido":
                     case "CnpjPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_cnpj_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_cnpj_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_natureza_operacao":
                     case "NaturezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_natureza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_natureza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo_operacao":
                     case "TipoOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_tipo_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_nbm_pedido":
                     case "NbmPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_nbm_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_nbm_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_frete":
                     case "Frete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_nota_fiscal":
                     case "NotaFiscal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_nota_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_nota_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_etiqueta_interna":
                     case "EtiquetaInterna":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_etiqueta_interna " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_etiqueta_interna) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_saldo_conferencia":
                     case "SaldoConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_saldo_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_saldo_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_cnc":
                     case "Cnc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_cnc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_cnc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_coordenada_x":
                     case "CoordenadaX":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_coordenada_x " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_coordenada_x) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_coordenada_y":
                     case "CoordenadaY":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_coordenada_y " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_coordenada_y) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_etiqueta_interna_impressa":
                     case "EtiquetaInternaImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_etiqueta_interna_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_etiqueta_interna_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_saf":
                     case "Saf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_saf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_saf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_programador":
                     case "Programador":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_programador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_programador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_conferencia_customizada_realizada":
                     case "ConferenciaCustomizadaRealizada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_conferencia_customizada_realizada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_conferencia_customizada_realizada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_conferencia_customizada_realizada_forcada":
                     case "ConferenciaCustomizadaRealizadaForcada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_conferencia_customizada_realizada_forcada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_conferencia_customizada_realizada_forcada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_qtd_etiqueta_exp_volume":
                     case "QtdEtiquetaExpVolume":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_qtd_etiqueta_exp_volume " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_qtd_etiqueta_exp_volume) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_descricao_pt":
                     case "DescricaoPt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_descricao_pt " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_descricao_pt) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_descricao_en":
                     case "DescricaoEn":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_descricao_en " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_descricao_en) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_descricao_es":
                     case "DescricaoEs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_descricao_es " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_descricao_es) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_imprime_packing_list":
                     case "ImprimePackingList":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_imprime_packing_list " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_imprime_packing_list) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo_baseboard":
                     case "TipoBaseboard":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_tipo_baseboard " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_baseboard) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_altura":
                     case "Altura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_altura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_altura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_largura":
                     case "Largura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_largura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_largura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_comprimento":
                     case "Comprimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_comprimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_comprimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo_ligacao":
                     case "TipoLigacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_tipo_ligacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_ligacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_packinglist_kit_impresso":
                     case "PackinglistKitImpresso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_packinglist_kit_impresso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_packinglist_kit_impresso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_1_nome":
                     case "Var1Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_1_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_1_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_1_valor":
                     case "Var1Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_1_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_1_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_2_nome":
                     case "Var2Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_2_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_2_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_2_valor":
                     case "Var2Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_2_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_2_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_3_nome":
                     case "Var3Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_3_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_3_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_3_valor":
                     case "Var3Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_3_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_3_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_4_nome":
                     case "Var4Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_4_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_4_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_var_4_valor":
                     case "Var4Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_var_4_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_var_4_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_data_entrega":
                     case "DataEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_data_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_data_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_kit_fantasia":
                     case "KitFantasia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_kit_fantasia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_kit_fantasia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_pk_kit_temp":
                     case "PkKitTemp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_pk_kit_temp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_pk_kit_temp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_data_impressao_op":
                     case "DataImpressaoOp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_data_impressao_op " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_data_impressao_op) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo_documento":
                     case "TipoDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_tipo_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_numero_documento":
                     case "NumeroDocumento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_numero_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_numero_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_revisao_desenho":
                     case "RevisaoDesenho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_revisao_desenho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_revisao_desenho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_codigo_item_pai":
                     case "CodigoItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_codigo_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_codigo_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_ordem_producao_impressa":
                     case "OrdemProducaoImpressa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_ordem_producao_impressa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_ordem_producao_impressa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_ordem_producao_impressa_data":
                     case "OrdemProducaoImpressaData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_ordem_producao_impressa_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_ordem_producao_impressa_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_ver_oc":
                     case "VerOc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_ver_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_ver_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_acabamento_superficial":
                     case "AcabamentoSuperficial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_acabamento_superficial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_acabamento_superficial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_item_original_pedido":
                     case "ItemOriginalPedido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_item_original_pedido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_item_original_pedido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = orcamento_configurado.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "id_orcamento_item":
                     case "OrcamentoItem":
                     command.CommandText += " LEFT JOIN orcamento_item as orcamento_item_OrcamentoItem ON orcamento_item_OrcamentoItem.id_orcamento_item = orcamento_configurado.id_orcamento_item ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_item_OrcamentoItem.id_orcamento_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_item_OrcamentoItem.id_orcamento_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = orcamento_configurado.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "orc_desc_item_pai":
                     case "DescItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_desc_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_desc_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_acab_item_pai":
                     case "AcabItemPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_acab_item_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_acab_item_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto_k":
                     case "ProdutoK":
                     command.CommandText += " LEFT JOIN produto_k as produto_k_ProdutoK ON produto_k_ProdutoK.id_produto_k = orcamento_configurado.id_produto_k ";                     switch (parametro.TipoOrdenacao)
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
                     case "orc_compra_mp_gerado":
                     case "CompraMpGerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_compra_mp_gerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_compra_mp_gerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_compra_mp_data_geracao":
                     case "CompraMpDataGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_compra_mp_data_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_compra_mp_data_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_informacoes_especiais":
                     case "InformacoesEspeciais":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.orc_informacoes_especiais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.orc_informacoes_especiais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_versao_estrutura_item":
                     case "VersaoEstruturaItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_versao_estrutura_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_versao_estrutura_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , orcamento_configurado.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(orcamento_configurado.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , orcamento_configurado.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_responsavel_frete":
                     case "ResponsavelFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_responsavel_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_responsavel_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_volume_unico":
                     case "VolumeUnico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_volume_unico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_volume_unico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_orcamento_configurado_pai":
                     case "OrcamentoConfiguradoPai":
                     command.CommandText += " LEFT JOIN orcamento_configurado as orcamento_configurado_OrcamentoConfiguradoPai ON orcamento_configurado_OrcamentoConfiguradoPai.id_orcamento_configurado = orcamento_configurado.id_orcamento_configurado_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado_OrcamentoConfiguradoPai.id_orcamento_configurado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado_OrcamentoConfiguradoPai.id_orcamento_configurado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_modelo_etiqueta_expedicao":
                     case "ModeloEtiquetaExpedicao":
                     command.CommandText += " LEFT JOIN modelo_etiqueta_expedicao as modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao ON modelo_etiqueta_expedicao_ModeloEtiquetaExpedicao.id_modelo_etiqueta_expedicao = orcamento_configurado.id_modelo_etiqueta_expedicao ";                     switch (parametro.TipoOrdenacao)
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
                     case "orc_tipo_aquisicao_produto":
                     case "TipoAquisicaoProduto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , orcamento_configurado.orc_tipo_aquisicao_produto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(orcamento_configurado.orc_tipo_aquisicao_produto) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_order_number")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_codigo_item")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_descricao")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_dimensao")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_dimensao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_dimensao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_ovm")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_ovm) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_ovm) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_deps")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_deps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_deps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_peps")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_peps) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_peps) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_status_pedido")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_status_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_status_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_armazenagem_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_armazenagem_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_armazenagem_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_descricao_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_descricao_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_descricao_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_codigo_cliente")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_codigo_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_codigo_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("id_externo_cliente_access")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.id_externo_cliente_access) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.id_externo_cliente_access) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_cnpj_pedido")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_cnpj_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_cnpj_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_natureza_operacao")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_natureza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_natureza_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_tipo_operacao")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_tipo_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_tipo_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_nbm_pedido")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_nbm_pedido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_nbm_pedido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_cnc")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_cnc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_cnc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_coordenada_x")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_coordenada_x) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_coordenada_x) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_coordenada_y")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_coordenada_y) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_coordenada_y) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_saf")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_saf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_saf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_programador")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_programador) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_programador) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_descricao_pt")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_descricao_pt) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_descricao_pt) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_descricao_en")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_descricao_en) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_descricao_en) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_descricao_es")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_descricao_es) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_descricao_es) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_tipo_baseboard")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_tipo_baseboard) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_tipo_baseboard) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_tipo_ligacao")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_tipo_ligacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_tipo_ligacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_1_nome")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_1_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_1_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_1_valor")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_1_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_1_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_2_nome")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_2_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_2_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_2_valor")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_2_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_2_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_3_nome")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_3_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_3_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_3_valor")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_3_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_3_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_4_nome")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_4_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_4_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_var_4_valor")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_var_4_valor) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_var_4_valor) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_kit_fantasia")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_kit_fantasia) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_kit_fantasia) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_tipo_documento")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_tipo_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_tipo_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_numero_documento")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_numero_documento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_numero_documento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_revisao_desenho")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_revisao_desenho) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_revisao_desenho) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_codigo_item_pai")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_codigo_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_codigo_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_ver_oc")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_ver_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_ver_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_acabamento_superficial")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_acabamento_superficial) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_acabamento_superficial) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_desc_item_pai")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_desc_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_desc_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_acab_item_pai")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_acab_item_pai) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_acab_item_pai) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_informacoes_especiais")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.orc_informacoes_especiais) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.orc_informacoes_especiais) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(orcamento_configurado.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(orcamento_configurado.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_orcamento_configurado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_configurado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_configurado = :orcamento_configurado_ID_8821 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ID_8821", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "orc_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_order_number LIKE :orcamento_configurado_OrderNumber_8384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrderNumber_8384", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "orc_order_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_order_pos = :orcamento_configurado_OrderPos_9679 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrderPos_9679", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "orc_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item LIKE :orcamento_configurado_CodigoItem_3178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoItem_3178", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "orc_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao LIKE :orcamento_configurado_Descricao_5431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Descricao_5431", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoItem" || parametro.FieldName == "orc_tipo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoControleEtiquetaProduto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoControleEtiquetaProduto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_item = :orcamento_configurado_TipoItem_4734 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoItem_4734", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Dimensao" || parametro.FieldName == "orc_dimensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_dimensao LIKE :orcamento_configurado_Dimensao_3443 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Dimensao_3443", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pps" || parametro.FieldName == "orc_pps")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_pps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_pps = :orcamento_configurado_Pps_4974 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Pps_4974", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdEtiquetas" || parametro.FieldName == "orc_qtd_etiquetas")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_qtd_etiquetas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_qtd_etiquetas = :orcamento_configurado_QtdEtiquetas_2179 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_QtdEtiquetas_2179", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaAgrupada" || parametro.FieldName == "orc_etiqueta_agrupada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_agrupada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_agrupada = :orcamento_configurado_EtiquetaAgrupada_5222 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EtiquetaAgrupada_5222", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cubagem" || parametro.FieldName == "orc_cubagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_cubagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cubagem = :orcamento_configurado_Cubagem_4847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Cubagem_4847", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peso" || parametro.FieldName == "orc_peso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_peso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_peso = :orcamento_configurado_Peso_9741 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Peso_9741", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Volumes" || parametro.FieldName == "orc_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_volumes = :orcamento_configurado_Volumes_175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Volumes_175", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saldo" || parametro.FieldName == "orc_saldo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_saldo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_saldo = :orcamento_configurado_Saldo_3895 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Saldo_3895", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoConferencia" || parametro.FieldName == "orc_situacao_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoConferencia?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoConferencia?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_situacao_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_situacao_conferencia = :orcamento_configurado_SituacaoConferencia_52 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_SituacaoConferencia_52", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NivelItem" || parametro.FieldName == "orc_nivel_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_nivel_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_nivel_item = :orcamento_configurado_NivelItem_599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NivelItem_599", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ovm" || parametro.FieldName == "orc_ovm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ovm LIKE :orcamento_configurado_Ovm_2345 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Ovm_2345", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Deps" || parametro.FieldName == "orc_deps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_deps LIKE :orcamento_configurado_Deps_6363 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Deps_6363", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Peps" || parametro.FieldName == "orc_peps")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_peps LIKE :orcamento_configurado_Peps_3214 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Peps_3214", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaExpedicaoImpressa" || parametro.FieldName == "orc_etiqueta_expedicao_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_expedicao_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_expedicao_impressa = :orcamento_configurado_EtiquetaExpedicaoImpressa_5891 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EtiquetaExpedicaoImpressa_5891", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsarTimer" || parametro.FieldName == "orc_usar_timer")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_usar_timer IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_usar_timer = :orcamento_configurado_UsarTimer_8488 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_UsarTimer_8488", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermitirParcial" || parametro.FieldName == "orc_permitir_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_permitir_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_permitir_parcial = :orcamento_configurado_PermitirParcial_7332 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_PermitirParcial_7332", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "orc_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_quantidade = :orcamento_configurado_Quantidade_3057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Quantidade_3057", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pallet" || parametro.FieldName == "orc_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_pallet = :orcamento_configurado_Pallet_3239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Pallet_3239", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscalEmitida" || parametro.FieldName == "orc_nota_fiscal_emitida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_nota_fiscal_emitida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_nota_fiscal_emitida = :orcamento_configurado_NotaFiscalEmitida_7969 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NotaFiscalEmitida_7969", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoConferenciaNf" || parametro.FieldName == "orc_situacao_conferencia_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is SituacaoConferencia)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo SituacaoConferencia");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_situacao_conferencia_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_situacao_conferencia_nf = :orcamento_configurado_SituacaoConferenciaNf_6233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_SituacaoConferenciaNf_6233", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotal" || parametro.FieldName == "orc_preco_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_preco_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_preco_total = :orcamento_configurado_PrecoTotal_7997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_PrecoTotal_7997", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoUnitario" || parametro.FieldName == "orc_preco_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_preco_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_preco_unitario = :orcamento_configurado_PrecoUnitario_8066 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_PrecoUnitario_8066", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmissaoParcial" || parametro.FieldName == "orc_emissao_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_emissao_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_emissao_parcial = :orcamento_configurado_EmissaoParcial_879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EmissaoParcial_879", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "StatusPedido" || parametro.FieldName == "orc_status_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_status_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_status_pedido LIKE :orcamento_configurado_StatusPedido_4046 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_StatusPedido_4046", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemCliente" || parametro.FieldName == "orc_armazenagem_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_armazenagem_cliente LIKE :orcamento_configurado_ArmazenagemCliente_1758 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ArmazenagemCliente_1758", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoCliente" || parametro.FieldName == "orc_descricao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_cliente LIKE :orcamento_configurado_DescricaoCliente_5963 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoCliente_5963", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoCliente" || parametro.FieldName == "orc_codigo_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_cliente LIKE :orcamento_configurado_CodigoCliente_1746 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoCliente_1746", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_configurado.id_externo_cliente_access IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_externo_cliente_access LIKE :orcamento_configurado_IdExternoClienteAccess_4426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_IdExternoClienteAccess_4426", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjPedido" || parametro.FieldName == "orc_cnpj_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_cnpj_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cnpj_pedido LIKE :orcamento_configurado_CnpjPedido_8272 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CnpjPedido_8272", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "orc_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cfop = :orcamento_configurado_Cfop_9337 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Cfop_9337", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacao" || parametro.FieldName == "orc_natureza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_natureza_operacao LIKE :orcamento_configurado_NaturezaOperacao_9005 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NaturezaOperacao_9005", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoOperacao" || parametro.FieldName == "orc_tipo_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_operacao LIKE :orcamento_configurado_TipoOperacao_1114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoOperacao_1114", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NbmPedido" || parametro.FieldName == "orc_nbm_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_nbm_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_nbm_pedido LIKE :orcamento_configurado_NbmPedido_1780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NbmPedido_1780", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Frete" || parametro.FieldName == "orc_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_frete = :orcamento_configurado_Frete_1695 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Frete_1695", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NotaFiscal" || parametro.FieldName == "orc_nota_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_nota_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_nota_fiscal = :orcamento_configurado_NotaFiscal_2558 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NotaFiscal_2558", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaInterna" || parametro.FieldName == "orc_etiqueta_interna")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_interna IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_interna = :orcamento_configurado_EtiquetaInterna_8801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EtiquetaInterna_8801", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SaldoConferencia" || parametro.FieldName == "orc_saldo_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_saldo_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_saldo_conferencia = :orcamento_configurado_SaldoConferencia_8850 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_SaldoConferencia_8850", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cnc" || parametro.FieldName == "orc_cnc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cnc LIKE :orcamento_configurado_Cnc_1184 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Cnc_1184", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaX" || parametro.FieldName == "orc_coordenada_x")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_x IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_x LIKE :orcamento_configurado_CoordenadaX_411 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CoordenadaX_411", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CoordenadaY" || parametro.FieldName == "orc_coordenada_y")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_y IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_y LIKE :orcamento_configurado_CoordenadaY_8282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CoordenadaY_8282", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EtiquetaInternaImpressa" || parametro.FieldName == "orc_etiqueta_interna_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_interna_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_etiqueta_interna_impressa = :orcamento_configurado_EtiquetaInternaImpressa_8379 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EtiquetaInternaImpressa_8379", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saf" || parametro.FieldName == "orc_saf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_saf LIKE :orcamento_configurado_Saf_2856 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Saf_2856", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Programador" || parametro.FieldName == "orc_programador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_programador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_programador LIKE :orcamento_configurado_Programador_4883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Programador_4883", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaCustomizadaRealizada" || parametro.FieldName == "orc_conferencia_customizada_realizada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_conferencia_customizada_realizada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_conferencia_customizada_realizada = :orcamento_configurado_ConferenciaCustomizadaRealizada_1061 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ConferenciaCustomizadaRealizada_1061", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaCustomizadaRealizadaForcada" || parametro.FieldName == "orc_conferencia_customizada_realizada_forcada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_conferencia_customizada_realizada_forcada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_conferencia_customizada_realizada_forcada = :orcamento_configurado_ConferenciaCustomizadaRealizadaForcada_9548 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ConferenciaCustomizadaRealizadaForcada_9548", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QtdEtiquetaExpVolume" || parametro.FieldName == "orc_qtd_etiqueta_exp_volume")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_qtd_etiqueta_exp_volume IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_qtd_etiqueta_exp_volume = :orcamento_configurado_QtdEtiquetaExpVolume_5316 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_QtdEtiquetaExpVolume_5316", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoPt" || parametro.FieldName == "orc_descricao_pt")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_pt LIKE :orcamento_configurado_DescricaoPt_378 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoPt_378", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEn" || parametro.FieldName == "orc_descricao_en")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_en LIKE :orcamento_configurado_DescricaoEn_827 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoEn_827", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoEs" || parametro.FieldName == "orc_descricao_es")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_es LIKE :orcamento_configurado_DescricaoEs_77 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoEs_77", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ImprimePackingList" || parametro.FieldName == "orc_imprime_packing_list")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_imprime_packing_list IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_imprime_packing_list = :orcamento_configurado_ImprimePackingList_1489 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ImprimePackingList_1489", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoBaseboard" || parametro.FieldName == "orc_tipo_baseboard")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_baseboard IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_baseboard LIKE :orcamento_configurado_TipoBaseboard_5327 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoBaseboard_5327", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Altura" || parametro.FieldName == "orc_altura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_altura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_altura = :orcamento_configurado_Altura_6441 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Altura_6441", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Largura" || parametro.FieldName == "orc_largura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_largura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_largura = :orcamento_configurado_Largura_5208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Largura_5208", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprimento" || parametro.FieldName == "orc_comprimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_comprimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_comprimento = :orcamento_configurado_Comprimento_9196 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Comprimento_9196", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoLigacao" || parametro.FieldName == "orc_tipo_ligacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_ligacao LIKE :orcamento_configurado_TipoLigacao_6735 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoLigacao_6735", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PackinglistKitImpresso" || parametro.FieldName == "orc_packinglist_kit_impresso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_packinglist_kit_impresso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_packinglist_kit_impresso = :orcamento_configurado_PackinglistKitImpresso_5376 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_PackinglistKitImpresso_5376", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1Nome" || parametro.FieldName == "orc_var_1_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_nome LIKE :orcamento_configurado_Var1Nome_4095 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var1Nome_4095", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var1Valor" || parametro.FieldName == "orc_var_1_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_valor LIKE :orcamento_configurado_Var1Valor_8131 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var1Valor_8131", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2Nome" || parametro.FieldName == "orc_var_2_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_nome LIKE :orcamento_configurado_Var2Nome_3464 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var2Nome_3464", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var2Valor" || parametro.FieldName == "orc_var_2_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_valor LIKE :orcamento_configurado_Var2Valor_8882 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var2Valor_8882", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3Nome" || parametro.FieldName == "orc_var_3_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_nome LIKE :orcamento_configurado_Var3Nome_7996 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var3Nome_7996", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var3Valor" || parametro.FieldName == "orc_var_3_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_valor LIKE :orcamento_configurado_Var3Valor_5747 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var3Valor_5747", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4Nome" || parametro.FieldName == "orc_var_4_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_nome LIKE :orcamento_configurado_Var4Nome_5622 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var4Nome_5622", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Var4Valor" || parametro.FieldName == "orc_var_4_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_valor LIKE :orcamento_configurado_Var4Valor_714 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var4Valor_714", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrega" || parametro.FieldName == "orc_data_entrega")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_data_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_data_entrega = :orcamento_configurado_DataEntrega_1593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DataEntrega_1593", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "KitFantasia" || parametro.FieldName == "orc_kit_fantasia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_kit_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_kit_fantasia LIKE :orcamento_configurado_KitFantasia_1232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_KitFantasia_1232", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PkKitTemp" || parametro.FieldName == "orc_pk_kit_temp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_pk_kit_temp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_pk_kit_temp = :orcamento_configurado_PkKitTemp_4583 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_PkKitTemp_4583", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataImpressaoOp" || parametro.FieldName == "orc_data_impressao_op")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_data_impressao_op IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_data_impressao_op = :orcamento_configurado_DataImpressaoOp_1520 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DataImpressaoOp_1520", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDocumento" || parametro.FieldName == "orc_tipo_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_documento LIKE :orcamento_configurado_TipoDocumento_3334 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoDocumento_3334", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroDocumento" || parametro.FieldName == "orc_numero_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_numero_documento LIKE :orcamento_configurado_NumeroDocumento_9686 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NumeroDocumento_9686", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoDesenho" || parametro.FieldName == "orc_revisao_desenho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_revisao_desenho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_revisao_desenho LIKE :orcamento_configurado_RevisaoDesenho_8480 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_RevisaoDesenho_8480", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemPai" || parametro.FieldName == "orc_codigo_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item_pai LIKE :orcamento_configurado_CodigoItemPai_1874 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoItemPai_1874", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoImpressa" || parametro.FieldName == "orc_ordem_producao_impressa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_ordem_producao_impressa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ordem_producao_impressa = :orcamento_configurado_OrdemProducaoImpressa_2829 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrdemProducaoImpressa_2829", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoImpressaData" || parametro.FieldName == "orc_ordem_producao_impressa_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_ordem_producao_impressa_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ordem_producao_impressa_data = :orcamento_configurado_OrdemProducaoImpressaData_9685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrdemProducaoImpressaData_9685", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VerOc" || parametro.FieldName == "orc_ver_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_ver_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ver_oc LIKE :orcamento_configurado_VerOc_7853 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_VerOc_7853", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabamentoSuperficial" || parametro.FieldName == "orc_acabamento_superficial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_acabamento_superficial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_acabamento_superficial LIKE :orcamento_configurado_AcabamentoSuperficial_5142 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_AcabamentoSuperficial_5142", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ItemOriginalPedido" || parametro.FieldName == "orc_item_original_pedido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_item_original_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_item_original_pedido = :orcamento_configurado_ItemOriginalPedido_3183 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ItemOriginalPedido_3183", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_configurado.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_cliente = :orcamento_configurado_Cliente_9816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Cliente_9816", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoItem" || parametro.FieldName == "id_orcamento_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_item = :orcamento_configurado_OrcamentoItem_4497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrcamentoItem_4497", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_configurado.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_produto = :orcamento_configurado_Produto_6440 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Produto_6440", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescItemPai" || parametro.FieldName == "orc_desc_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_desc_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_desc_item_pai LIKE :orcamento_configurado_DescItemPai_5586 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescItemPai_5586", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcabItemPai" || parametro.FieldName == "orc_acab_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_acab_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_acab_item_pai LIKE :orcamento_configurado_AcabItemPai_919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_AcabItemPai_919", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_configurado.id_produto_k IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_produto_k = :orcamento_configurado_ProdutoK_4350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ProdutoK_4350", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompraMpGerado" || parametro.FieldName == "orc_compra_mp_gerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_compra_mp_gerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_compra_mp_gerado = :orcamento_configurado_CompraMpGerado_6783 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CompraMpGerado_6783", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompraMpDataGeracao" || parametro.FieldName == "orc_compra_mp_data_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_compra_mp_data_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_compra_mp_data_geracao = :orcamento_configurado_CompraMpDataGeracao_4010 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CompraMpDataGeracao_4010", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacoesEspeciais" || parametro.FieldName == "orc_informacoes_especiais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_informacoes_especiais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_informacoes_especiais LIKE :orcamento_configurado_InformacoesEspeciais_2565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_InformacoesEspeciais_2565", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VersaoEstruturaItem" || parametro.FieldName == "orc_versao_estrutura_item")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_versao_estrutura_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_versao_estrutura_item = :orcamento_configurado_VersaoEstruturaItem_5905 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_VersaoEstruturaItem_5905", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "orc_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_rastreamento_material = :orcamento_configurado_RastreamentoMaterial_2582 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_RastreamentoMaterial_2582", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_configurado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.entity_uid LIKE :orcamento_configurado_EntityUid_4958 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EntityUid_4958", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  orcamento_configurado.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.version = :orcamento_configurado_Version_7181 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Version_7181", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResponsavelFrete" || parametro.FieldName == "orc_responsavel_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ResponsavelFrete)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ResponsavelFrete");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_responsavel_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_responsavel_frete = :orcamento_configurado_ResponsavelFrete_4707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ResponsavelFrete_4707", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeUnico" || parametro.FieldName == "orc_volume_unico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_volume_unico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_volume_unico = :orcamento_configurado_VolumeUnico_720 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_VolumeUnico_720", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrcamentoConfiguradoPai" || parametro.FieldName == "id_orcamento_configurado_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_configurado_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_orcamento_configurado_pai = :orcamento_configurado_OrcamentoConfiguradoPai_7719 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrcamentoConfiguradoPai_7719", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  orcamento_configurado.id_modelo_etiqueta_expedicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_modelo_etiqueta_expedicao = :orcamento_configurado_ModeloEtiquetaExpedicao_1527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ModeloEtiquetaExpedicao_1527", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAquisicaoProduto" || parametro.FieldName == "orc_tipo_aquisicao_produto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoAquisicao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoAquisicao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_aquisicao_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_aquisicao_produto = :orcamento_configurado_TipoAquisicaoProduto_287 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoAquisicaoProduto_287", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  orcamento_configurado.orc_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_order_number LIKE :orcamento_configurado_OrderNumber_2632 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_OrderNumber_2632", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item LIKE :orcamento_configurado_CodigoItem_7232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoItem_7232", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao LIKE :orcamento_configurado_Descricao_4170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Descricao_4170", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_dimensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_dimensao LIKE :orcamento_configurado_Dimensao_9467 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Dimensao_9467", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_ovm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ovm LIKE :orcamento_configurado_Ovm_8317 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Ovm_8317", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_deps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_deps LIKE :orcamento_configurado_Deps_734 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Deps_734", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_peps IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_peps LIKE :orcamento_configurado_Peps_8857 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Peps_8857", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_status_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_status_pedido LIKE :orcamento_configurado_StatusPedido_7492 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_StatusPedido_7492", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_armazenagem_cliente LIKE :orcamento_configurado_ArmazenagemCliente_390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_ArmazenagemCliente_390", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_cliente LIKE :orcamento_configurado_DescricaoCliente_3008 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoCliente_3008", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_cliente LIKE :orcamento_configurado_CodigoCliente_3453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoCliente_3453", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.id_externo_cliente_access IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.id_externo_cliente_access LIKE :orcamento_configurado_IdExternoClienteAccess_3612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_IdExternoClienteAccess_3612", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_cnpj_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cnpj_pedido LIKE :orcamento_configurado_CnpjPedido_5521 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CnpjPedido_5521", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_natureza_operacao LIKE :orcamento_configurado_NaturezaOperacao_1344 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NaturezaOperacao_1344", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_operacao LIKE :orcamento_configurado_TipoOperacao_1594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoOperacao_1594", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_nbm_pedido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_nbm_pedido LIKE :orcamento_configurado_NbmPedido_2193 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NbmPedido_2193", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_cnc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_cnc LIKE :orcamento_configurado_Cnc_4277 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Cnc_4277", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_coordenada_x IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_x LIKE :orcamento_configurado_CoordenadaX_3635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CoordenadaX_3635", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_coordenada_y IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_coordenada_y LIKE :orcamento_configurado_CoordenadaY_7022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CoordenadaY_7022", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_saf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_saf LIKE :orcamento_configurado_Saf_3297 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Saf_3297", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_programador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_programador LIKE :orcamento_configurado_Programador_7077 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Programador_7077", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_descricao_pt IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_pt LIKE :orcamento_configurado_DescricaoPt_1397 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoPt_1397", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_descricao_en IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_en LIKE :orcamento_configurado_DescricaoEn_8838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoEn_8838", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_descricao_es IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_descricao_es LIKE :orcamento_configurado_DescricaoEs_6702 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescricaoEs_6702", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_tipo_baseboard IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_baseboard LIKE :orcamento_configurado_TipoBaseboard_9027 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoBaseboard_9027", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_tipo_ligacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_ligacao LIKE :orcamento_configurado_TipoLigacao_5325 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoLigacao_5325", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_1_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_nome LIKE :orcamento_configurado_Var1Nome_2002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var1Nome_2002", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_1_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_1_valor LIKE :orcamento_configurado_Var1Valor_6560 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var1Valor_6560", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_2_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_nome LIKE :orcamento_configurado_Var2Nome_6151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var2Nome_6151", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_2_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_2_valor LIKE :orcamento_configurado_Var2Valor_4979 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var2Valor_4979", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_3_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_nome LIKE :orcamento_configurado_Var3Nome_7760 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var3Nome_7760", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_3_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_3_valor LIKE :orcamento_configurado_Var3Valor_4154 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var3Valor_4154", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_4_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_nome LIKE :orcamento_configurado_Var4Nome_1302 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var4Nome_1302", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_var_4_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_var_4_valor LIKE :orcamento_configurado_Var4Valor_9399 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_Var4Valor_9399", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_kit_fantasia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_kit_fantasia LIKE :orcamento_configurado_KitFantasia_5221 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_KitFantasia_5221", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_tipo_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_tipo_documento LIKE :orcamento_configurado_TipoDocumento_7908 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_TipoDocumento_7908", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_numero_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_numero_documento LIKE :orcamento_configurado_NumeroDocumento_9012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_NumeroDocumento_9012", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_revisao_desenho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_revisao_desenho LIKE :orcamento_configurado_RevisaoDesenho_350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_RevisaoDesenho_350", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_codigo_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_codigo_item_pai LIKE :orcamento_configurado_CodigoItemPai_6178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_CodigoItemPai_6178", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_ver_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_ver_oc LIKE :orcamento_configurado_VerOc_5707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_VerOc_5707", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_acabamento_superficial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_acabamento_superficial LIKE :orcamento_configurado_AcabamentoSuperficial_6728 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_AcabamentoSuperficial_6728", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_desc_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_desc_item_pai LIKE :orcamento_configurado_DescItemPai_3426 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_DescItemPai_3426", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_acab_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_acab_item_pai LIKE :orcamento_configurado_AcabItemPai_3961 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_AcabItemPai_3961", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.orc_informacoes_especiais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.orc_informacoes_especiais LIKE :orcamento_configurado_InformacoesEspeciais_3775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_InformacoesEspeciais_3775", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  orcamento_configurado.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  orcamento_configurado.entity_uid LIKE :orcamento_configurado_EntityUid_558 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orcamento_configurado_EntityUid_558", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrcamentoConfiguradoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrcamentoConfiguradoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrcamentoConfiguradoClass), Convert.ToInt32(read["id_orcamento_configurado"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrcamentoConfiguradoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_orcamento_configurado"]);
                     entidade.OrderNumber = (read["orc_order_number"] != DBNull.Value ? read["orc_order_number"].ToString() : null);
                     entidade.OrderPos = read["orc_order_pos"] as int?;
                     entidade.CodigoItem = (read["orc_codigo_item"] != DBNull.Value ? read["orc_codigo_item"].ToString() : null);
                     entidade.Descricao = (read["orc_descricao"] != DBNull.Value ? read["orc_descricao"].ToString() : null);
                     entidade.TipoItem = (TipoControleEtiquetaProduto?) (read["orc_tipo_item"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(TipoControleEtiquetaProduto?)), read["orc_tipo_item"]) : null);
                     entidade.Dimensao = (read["orc_dimensao"] != DBNull.Value ? read["orc_dimensao"].ToString() : null);
                     entidade.Pps = read["orc_pps"] as int?;
                     entidade.QtdEtiquetas = read["orc_qtd_etiquetas"] as int?;
                     entidade.EtiquetaAgrupada = (read["orc_etiqueta_agrupada"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["orc_etiqueta_agrupada"])) : null);
                     entidade.Cubagem = read["orc_cubagem"] as double?;
                     entidade.Peso = read["orc_peso"] as double?;
                     entidade.Volumes = read["orc_volumes"] as int?;
                     entidade.Saldo = (double)read["orc_saldo"];
                     entidade.SituacaoConferencia = (SituacaoConferencia?) (read["orc_situacao_conferencia"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(SituacaoConferencia?)), read["orc_situacao_conferencia"]) : null);
                     entidade.NivelItem = read["orc_nivel_item"] as short?;
                     entidade.Ovm = (read["orc_ovm"] != DBNull.Value ? read["orc_ovm"].ToString() : null);
                     entidade.Deps = (read["orc_deps"] != DBNull.Value ? read["orc_deps"].ToString() : null);
                     entidade.Peps = (read["orc_peps"] != DBNull.Value ? read["orc_peps"].ToString() : null);
                     entidade.EtiquetaExpedicaoImpressa = Convert.ToBoolean(Convert.ToInt16(read["orc_etiqueta_expedicao_impressa"]));
                     entidade.UsarTimer = Convert.ToBoolean(Convert.ToInt16(read["orc_usar_timer"]));
                     entidade.PermitirParcial = Convert.ToBoolean(Convert.ToInt16(read["orc_permitir_parcial"]));
                     entidade.Quantidade = (double)read["orc_quantidade"];
                     entidade.Pallet = read["orc_pallet"] as short?;
                     entidade.NotaFiscalEmitida = Convert.ToBoolean(Convert.ToInt16(read["orc_nota_fiscal_emitida"]));
                     entidade.SituacaoConferenciaNf = (SituacaoConferencia) (read["orc_situacao_conferencia_nf"] != DBNull.Value ? Enum.ToObject(typeof(SituacaoConferencia), read["orc_situacao_conferencia_nf"]) : null);
                     entidade.PrecoTotal = read["orc_preco_total"] as double?;
                     entidade.PrecoUnitario = read["orc_preco_unitario"] as double?;
                     entidade.EmissaoParcial = Convert.ToBoolean(Convert.ToInt16(read["orc_emissao_parcial"]));
                     entidade.StatusPedido = (read["orc_status_pedido"] != DBNull.Value ? read["orc_status_pedido"].ToString() : null);
                     entidade.ArmazenagemCliente = (read["orc_armazenagem_cliente"] != DBNull.Value ? read["orc_armazenagem_cliente"].ToString() : null);
                     entidade.DescricaoCliente = (read["orc_descricao_cliente"] != DBNull.Value ? read["orc_descricao_cliente"].ToString() : null);
                     entidade.CodigoCliente = (read["orc_codigo_cliente"] != DBNull.Value ? read["orc_codigo_cliente"].ToString() : null);
                     entidade.IdExternoClienteAccess = (read["id_externo_cliente_access"] != DBNull.Value ? read["id_externo_cliente_access"].ToString() : null);
                     entidade.CnpjPedido = (read["orc_cnpj_pedido"] != DBNull.Value ? read["orc_cnpj_pedido"].ToString() : null);
                     entidade.Cfop = read["orc_cfop"] as int?;
                     entidade.NaturezaOperacao = (read["orc_natureza_operacao"] != DBNull.Value ? read["orc_natureza_operacao"].ToString() : null);
                     entidade.TipoOperacao = (read["orc_tipo_operacao"] != DBNull.Value ? read["orc_tipo_operacao"].ToString() : null);
                     entidade.NbmPedido = (read["orc_nbm_pedido"] != DBNull.Value ? read["orc_nbm_pedido"].ToString() : null);
                     entidade.Frete = (double)read["orc_frete"];
                     entidade.NotaFiscal = (read["orc_nota_fiscal"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["orc_nota_fiscal"])) : null);
                     entidade.EtiquetaInterna = Convert.ToBoolean(Convert.ToInt16(read["orc_etiqueta_interna"]));
                     entidade.SaldoConferencia = (double)read["orc_saldo_conferencia"];
                     entidade.Cnc = (read["orc_cnc"] != DBNull.Value ? read["orc_cnc"].ToString() : null);
                     entidade.CoordenadaX = (read["orc_coordenada_x"] != DBNull.Value ? read["orc_coordenada_x"].ToString() : null);
                     entidade.CoordenadaY = (read["orc_coordenada_y"] != DBNull.Value ? read["orc_coordenada_y"].ToString() : null);
                     entidade.EtiquetaInternaImpressa = Convert.ToBoolean(Convert.ToInt16(read["orc_etiqueta_interna_impressa"]));
                     entidade.Saf = (read["orc_saf"] != DBNull.Value ? read["orc_saf"].ToString() : null);
                     entidade.Programador = (read["orc_programador"] != DBNull.Value ? read["orc_programador"].ToString() : null);
                     entidade.ConferenciaCustomizadaRealizada = Convert.ToBoolean(Convert.ToInt16(read["orc_conferencia_customizada_realizada"]));
                     entidade.ConferenciaCustomizadaRealizadaForcada = Convert.ToBoolean(Convert.ToInt16(read["orc_conferencia_customizada_realizada_forcada"]));
                     entidade.QtdEtiquetaExpVolume = (int)read["orc_qtd_etiqueta_exp_volume"];
                     entidade.DescricaoPt = (read["orc_descricao_pt"] != DBNull.Value ? read["orc_descricao_pt"].ToString() : null);
                     entidade.DescricaoEn = (read["orc_descricao_en"] != DBNull.Value ? read["orc_descricao_en"].ToString() : null);
                     entidade.DescricaoEs = (read["orc_descricao_es"] != DBNull.Value ? read["orc_descricao_es"].ToString() : null);
                     entidade.ImprimePackingList = Convert.ToBoolean(Convert.ToInt16(read["orc_imprime_packing_list"]));
                     entidade.TipoBaseboard = (read["orc_tipo_baseboard"] != DBNull.Value ? read["orc_tipo_baseboard"].ToString() : null);
                     entidade.Altura = read["orc_altura"] as double?;
                     entidade.Largura = read["orc_largura"] as double?;
                     entidade.Comprimento = read["orc_comprimento"] as double?;
                     entidade.TipoLigacao = (read["orc_tipo_ligacao"] != DBNull.Value ? read["orc_tipo_ligacao"].ToString() : null);
                     entidade.PackinglistKitImpresso = (read["orc_packinglist_kit_impresso"] != DBNull.Value ? (bool?)Convert.ToBoolean(Convert.ToInt16(read["orc_packinglist_kit_impresso"])) : null);
                     entidade.Var1Nome = (read["orc_var_1_nome"] != DBNull.Value ? read["orc_var_1_nome"].ToString() : null);
                     entidade.Var1Valor = (read["orc_var_1_valor"] != DBNull.Value ? read["orc_var_1_valor"].ToString() : null);
                     entidade.Var2Nome = (read["orc_var_2_nome"] != DBNull.Value ? read["orc_var_2_nome"].ToString() : null);
                     entidade.Var2Valor = (read["orc_var_2_valor"] != DBNull.Value ? read["orc_var_2_valor"].ToString() : null);
                     entidade.Var3Nome = (read["orc_var_3_nome"] != DBNull.Value ? read["orc_var_3_nome"].ToString() : null);
                     entidade.Var3Valor = (read["orc_var_3_valor"] != DBNull.Value ? read["orc_var_3_valor"].ToString() : null);
                     entidade.Var4Nome = (read["orc_var_4_nome"] != DBNull.Value ? read["orc_var_4_nome"].ToString() : null);
                     entidade.Var4Valor = (read["orc_var_4_valor"] != DBNull.Value ? read["orc_var_4_valor"].ToString() : null);
                     entidade.DataEntrega = read["orc_data_entrega"] as DateTime?;
                     entidade.KitFantasia = (read["orc_kit_fantasia"] != DBNull.Value ? read["orc_kit_fantasia"].ToString() : null);
                     entidade.PkKitTemp = read["orc_pk_kit_temp"] as short?;
                     entidade.DataImpressaoOp = read["orc_data_impressao_op"] as DateTime?;
                     entidade.TipoDocumento = (read["orc_tipo_documento"] != DBNull.Value ? read["orc_tipo_documento"].ToString() : null);
                     entidade.NumeroDocumento = (read["orc_numero_documento"] != DBNull.Value ? read["orc_numero_documento"].ToString() : null);
                     entidade.RevisaoDesenho = (read["orc_revisao_desenho"] != DBNull.Value ? read["orc_revisao_desenho"].ToString() : null);
                     entidade.CodigoItemPai = (read["orc_codigo_item_pai"] != DBNull.Value ? read["orc_codigo_item_pai"].ToString() : null);
                     entidade.OrdemProducaoImpressa = Convert.ToBoolean(Convert.ToInt16(read["orc_ordem_producao_impressa"]));
                     entidade.OrdemProducaoImpressaData = read["orc_ordem_producao_impressa_data"] as DateTime?;
                     entidade.VerOc = (read["orc_ver_oc"] != DBNull.Value ? read["orc_ver_oc"].ToString() : null);
                     entidade.AcabamentoSuperficial = (read["orc_acabamento_superficial"] != DBNull.Value ? read["orc_acabamento_superficial"].ToString() : null);
                     entidade.ItemOriginalPedido = Convert.ToBoolean(Convert.ToInt16(read["orc_item_original_pedido"]));
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     if (read["id_orcamento_item"] != DBNull.Value)
                     {
                        entidade.OrcamentoItem = (BibliotecaEntidades.Entidades.OrcamentoItemClass)BibliotecaEntidades.Entidades.OrcamentoItemClass.GetEntidade(Convert.ToInt32(read["id_orcamento_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoItem = null ;
                     }
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.DescItemPai = (read["orc_desc_item_pai"] != DBNull.Value ? read["orc_desc_item_pai"].ToString() : null);
                     entidade.AcabItemPai = (read["orc_acab_item_pai"] != DBNull.Value ? read["orc_acab_item_pai"].ToString() : null);
                     if (read["id_produto_k"] != DBNull.Value)
                     {
                        entidade.ProdutoK = (BibliotecaEntidades.Entidades.ProdutoKClass)BibliotecaEntidades.Entidades.ProdutoKClass.GetEntidade(Convert.ToInt32(read["id_produto_k"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ProdutoK = null ;
                     }
                     entidade.CompraMpGerado = Convert.ToBoolean(Convert.ToInt16(read["orc_compra_mp_gerado"]));
                     entidade.CompraMpDataGeracao = read["orc_compra_mp_data_geracao"] as DateTime?;
                     entidade.InformacoesEspeciais = (read["orc_informacoes_especiais"] != DBNull.Value ? read["orc_informacoes_especiais"].ToString() : null);
                     entidade.VersaoEstruturaItem = (int)read["orc_versao_estrutura_item"];
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["orc_rastreamento_material"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ResponsavelFrete = (ResponsavelFrete) (read["orc_responsavel_frete"] != DBNull.Value ? Enum.ToObject(typeof(ResponsavelFrete), read["orc_responsavel_frete"]) : null);
                     entidade.VolumeUnico = Convert.ToBoolean(Convert.ToInt16(read["orc_volume_unico"]));
                     if (read["id_orcamento_configurado_pai"] != DBNull.Value)
                     {
                        entidade.OrcamentoConfiguradoPai = (BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass)BibliotecaEntidades.Entidades.OrcamentoConfiguradoClass.GetEntidade(Convert.ToInt32(read["id_orcamento_configurado_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrcamentoConfiguradoPai = null ;
                     }
                     if (read["id_modelo_etiqueta_expedicao"] != DBNull.Value)
                     {
                        entidade.ModeloEtiquetaExpedicao = (BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass)BibliotecaEntidades.Entidades.ModeloEtiquetaExpedicaoClass.GetEntidade(Convert.ToInt32(read["id_modelo_etiqueta_expedicao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ModeloEtiquetaExpedicao = null ;
                     }
                     entidade.TipoAquisicaoProduto = (TipoAquisicao) (read["orc_tipo_aquisicao_produto"] != DBNull.Value ? Enum.ToObject(typeof(TipoAquisicao), read["orc_tipo_aquisicao_produto"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrcamentoConfiguradoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
