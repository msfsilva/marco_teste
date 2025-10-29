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
using IWTNF.Entidades.Entidades; 
namespace BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("pedido_item","pei")]
     public class PedidoItemBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do PedidoItemClass";
protected const string ErroDelete = "Erro ao excluir o PedidoItemClass  ";
protected const string ErroSave = "Erro ao salvar o PedidoItemClass.";
protected const string ErroCollectionAtendimentoClassPedidoItem = "Erro ao carregar a coleção de AtendimentoClass.";
protected const string ErroCollectionGadPedidosUploadClassPedidoItem = "Erro ao carregar a coleção de GadPedidosUploadClass.";
protected const string ErroCollectionNotificacaoDesvioClassPedidoItem = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
protected const string ErroCollectionOrderItemEtiquetaClassPedidoItem = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido = "Erro ao carregar a coleção de OrderItemEtiquetaClass.";
protected const string ErroCollectionPedidoDocumentoClassPedidoItem = "Erro ao carregar a coleção de PedidoDocumentoClass.";
protected const string ErroCollectionPedidoItemClassPedidoItemPai = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPedidoItemFeedbackClassPedidoItem = "Erro ao carregar a coleção de PedidoItemFeedbackClass.";
protected const string ErroCollectionPedidoItemFeedbackSecundarioClassPedidoItem = "Erro ao carregar a coleção de PedidoItemFeedbackSecundarioClass.";
protected const string ErroCollectionPedidoItemHistoricoAlteracoesClassPedidoItem = "Erro ao carregar a coleção de PedidoItemHistoricoAlteracoesClass.";
protected const string ErroCollectionPedidoItemLoteClienteClassPedidoItem = "Erro ao carregar a coleção de PedidoItemLoteClienteClass.";
protected const string ErroCollectionPedidoItemQualidadeClassPedidoItem = "Erro ao carregar a coleção de PedidoItemQualidadeClass.";
protected const string ErroCollectionPedidoItemVariavelClassPedidoItem = "Erro ao carregar a coleção de PedidoItemVariavelClass.";
protected const string ErroCollectionPedidoItemVolumeClassPedidoItem = "Erro ao carregar a coleção de PedidoItemVolumeClass.";
protected const string ErroCollectionPedidoKitClassPedidoItem = "Erro ao carregar a coleção de PedidoKitClass.";
protected const string ErroCollectionPedidoVariavelClassPedidoItem = "Erro ao carregar a coleção de PedidoVariavelClass.";
protected const string ErroCollectionSolicitacaoCompraPedidoClassPedidoItem = "Erro ao carregar a coleção de SolicitacaoCompraPedidoClass.";
protected const string ErroNumeroObrigatorio = "O campo Numero é obrigatório";
protected const string ErroNumeroComprimento = "O campo Numero deve ter no máximo 255 caracteres";
protected const string ErroProdutoCodigoClienteObrigatorio = "O campo ProdutoCodigoCliente é obrigatório";
protected const string ErroProdutoCodigoClienteComprimento = "O campo ProdutoCodigoCliente deve ter no máximo 255 caracteres";
protected const string ErroProdutoDescricaoClienteObrigatorio = "O campo ProdutoDescricaoCliente é obrigatório";
protected const string ErroProdutoDescricaoClienteComprimento = "O campo ProdutoDescricaoCliente deve ter no máximo 255 caracteres";
protected const string ErroCnpjClienteObrigatorio = "O campo CnpjCliente é obrigatório";
protected const string ErroCnpjClienteComprimento = "O campo CnpjCliente deve ter no máximo 100 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroProdutoObrigatorio = "O campo Produto é obrigatório";
protected const string ErroClienteObrigatorio = "O campo Cliente é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do PedidoItemClass.";
protected const string MensagemUtilizadoCollectionAtendimentoClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes AtendimentoClass:";
protected const string MensagemUtilizadoCollectionGadPedidosUploadClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes GadPedidosUploadClass:";
protected const string MensagemUtilizadoCollectionNotificacaoDesvioClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido =  "A entidade PedidoItemClass está sendo utilizada nos seguintes OrderItemEtiquetaClass:";
protected const string MensagemUtilizadoCollectionPedidoDocumentoClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoDocumentoClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassPedidoItemPai =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemFeedbackClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemFeedbackClass:";
protected const string MensagemUtilizadoCollectionPedidoItemFeedbackSecundarioClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemFeedbackSecundarioClass:";
protected const string MensagemUtilizadoCollectionPedidoItemHistoricoAlteracoesClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemHistoricoAlteracoesClass:";
protected const string MensagemUtilizadoCollectionPedidoItemLoteClienteClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemLoteClienteClass:";
protected const string MensagemUtilizadoCollectionPedidoItemQualidadeClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemQualidadeClass:";
protected const string MensagemUtilizadoCollectionPedidoItemVariavelClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemVariavelClass:";
protected const string MensagemUtilizadoCollectionPedidoItemVolumeClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoItemVolumeClass:";
protected const string MensagemUtilizadoCollectionPedidoKitClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoKitClass:";
protected const string MensagemUtilizadoCollectionPedidoVariavelClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes PedidoVariavelClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassPedidoItem =  "A entidade PedidoItemClass está sendo utilizada nos seguintes SolicitacaoCompraPedidoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade PedidoItemClass está sendo utilizada.";
#endregion
       protected string _numeroOriginal{get;private set;}
       private string _numeroOriginalCommited{get; set;}
        private string _valueNumero;
         [Column("pei_numero")]
        public virtual string Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _posicaoOriginal{get;private set;}
       private int _posicaoOriginalCommited{get; set;}
        private int _valuePosicao;
         [Column("pei_posicao")]
        public virtual int Posicao
         { 
            get { return this._valuePosicao; } 
            set 
            { 
                if (this._valuePosicao == value)return;
                 this._valuePosicao = value; 
            } 
        } 

       protected int _subLinhaOriginal{get;private set;}
       private int _subLinhaOriginalCommited{get; set;}
        private int _valueSubLinha;
         [Column("pei_sub_linha")]
        public virtual int SubLinha
         { 
            get { return this._valueSubLinha; } 
            set 
            { 
                if (this._valueSubLinha == value)return;
                 this._valueSubLinha = value; 
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

       protected string _produtoCodigoClienteOriginal{get;private set;}
       private string _produtoCodigoClienteOriginalCommited{get; set;}
        private string _valueProdutoCodigoCliente;
         [Column("pei_produto_codigo_cliente")]
        public virtual string ProdutoCodigoCliente
         { 
            get { return this._valueProdutoCodigoCliente; } 
            set 
            { 
                if (this._valueProdutoCodigoCliente == value)return;
                 this._valueProdutoCodigoCliente = value; 
            } 
        } 

       protected string _produtoDescricaoClienteOriginal{get;private set;}
       private string _produtoDescricaoClienteOriginalCommited{get; set;}
        private string _valueProdutoDescricaoCliente;
         [Column("pei_produto_descricao_cliente")]
        public virtual string ProdutoDescricaoCliente
         { 
            get { return this._valueProdutoDescricaoCliente; } 
            set 
            { 
                if (this._valueProdutoDescricaoCliente == value)return;
                 this._valueProdutoDescricaoCliente = value; 
            } 
        } 

       protected string _projetoClienteOriginal{get;private set;}
       private string _projetoClienteOriginalCommited{get; set;}
        private string _valueProjetoCliente;
         [Column("pei_projeto_cliente")]
        public virtual string ProjetoCliente
         { 
            get { return this._valueProjetoCliente; } 
            set 
            { 
                if (this._valueProjetoCliente == value)return;
                 this._valueProjetoCliente = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("pei_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _saldoOriginal{get;private set;}
       private double _saldoOriginalCommited{get; set;}
        private double _valueSaldo;
         [Column("pei_saldo")]
        public virtual double Saldo
         { 
            get { return this._valueSaldo; } 
            set 
            { 
                if (this._valueSaldo == value)return;
                 this._valueSaldo = value; 
            } 
        } 

       protected double _precoUnitarioOriginal{get;private set;}
       private double _precoUnitarioOriginalCommited{get; set;}
        private double _valuePrecoUnitario;
         [Column("pei_preco_unitario")]
        public virtual double PrecoUnitario
         { 
            get { return this._valuePrecoUnitario; } 
            set 
            { 
                if (this._valuePrecoUnitario == value)return;
                 this._valuePrecoUnitario = value; 
            } 
        } 

       protected double _precoTotalOriginal{get;private set;}
       private double _precoTotalOriginalCommited{get; set;}
        private double _valuePrecoTotal;
         [Column("pei_preco_total")]
        public virtual double PrecoTotal
         { 
            get { return this._valuePrecoTotal; } 
            set 
            { 
                if (this._valuePrecoTotal == value)return;
                 this._valuePrecoTotal = value; 
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

       protected string _cnpjClienteOriginal{get;private set;}
       private string _cnpjClienteOriginalCommited{get; set;}
        private string _valueCnpjCliente;
         [Column("pei_cnpj_cliente")]
        public virtual string CnpjCliente
         { 
            get { return this._valueCnpjCliente; } 
            set 
            { 
                if (this._valueCnpjCliente == value)return;
                 this._valueCnpjCliente = value; 
            } 
        } 

       protected string _armazenagemClienteOriginal{get;private set;}
       private string _armazenagemClienteOriginalCommited{get; set;}
        private string _valueArmazenagemCliente;
         [Column("pei_armazenagem_cliente")]
        public virtual string ArmazenagemCliente
         { 
            get { return this._valueArmazenagemCliente; } 
            set 
            { 
                if (this._valueArmazenagemCliente == value)return;
                 this._valueArmazenagemCliente = value; 
            } 
        } 

       protected double _freteOriginal{get;private set;}
       private double _freteOriginalCommited{get; set;}
        private double _valueFrete;
         [Column("pei_frete")]
        public virtual double Frete
         { 
            get { return this._valueFrete; } 
            set 
            { 
                if (this._valueFrete == value)return;
                 this._valueFrete = value; 
            } 
        } 

       protected DateTime _dataEntregaOriginal{get;private set;}
       private DateTime _dataEntregaOriginalCommited{get; set;}
        private DateTime _valueDataEntrega;
         [Column("pei_data_entrega")]
        public virtual DateTime DataEntrega
         { 
            get { return this._valueDataEntrega; } 
            set 
            { 
                if (this._valueDataEntrega == value)return;
                 this._valueDataEntrega = value; 
            } 
        } 

       protected StatusPedido _statusOriginal{get;private set;}
       private StatusPedido _statusOriginalCommited{get; set;}
        private StatusPedido _valueStatus;
         [Column("pei_status")]
        public virtual StatusPedido Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

        public bool Status_Pendente
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusPedido.Pendente; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusPedido.Pendente; }
         } 

        public bool Status_Encerrado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusPedido.Encerrado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusPedido.Encerrado; }
         } 

        public bool Status_Cancelado
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusPedido.Cancelado; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusPedido.Cancelado; }
         } 

        public bool Status_Reaberto
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusPedido.Reaberto; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusPedido.Reaberto; }
         } 

        public bool Status_Suspenso
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusPedido.Suspenso; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusPedido.Suspenso; }
         } 

       protected DateTime _dataEntradaOriginal{get;private set;}
       private DateTime _dataEntradaOriginalCommited{get; set;}
        private DateTime _valueDataEntrada;
         [Column("pei_data_entrada")]
        public virtual DateTime DataEntrada
         { 
            get { return this._valueDataEntrada; } 
            set 
            { 
                if (this._valueDataEntrada == value)return;
                 this._valueDataEntrada = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _operacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _valueOperacao;
        [Column("id_operacao", "operacao", "id_operacao")]
       public virtual BibliotecaEntidades.Entidades.OperacaoClass Operacao
        { 
           get {                 return this._valueOperacao; } 
           set 
           { 
                if (this._valueOperacao == value)return;
                 this._valueOperacao = value; 
           } 
       } 

       protected bool _permiteEntregaParcialOriginal{get;private set;}
       private bool _permiteEntregaParcialOriginalCommited{get; set;}
        private bool _valuePermiteEntregaParcial;
         [Column("pei_permite_entrega_parcial")]
        public virtual bool PermiteEntregaParcial
         { 
            get { return this._valuePermiteEntregaParcial; } 
            set 
            { 
                if (this._valuePermiteEntregaParcial == value)return;
                 this._valuePermiteEntregaParcial = value; 
            } 
        } 

       protected bool _volumeUnicoOriginal{get;private set;}
       private bool _volumeUnicoOriginalCommited{get; set;}
        private bool _valueVolumeUnico;
         [Column("pei_volume_unico")]
        public virtual bool VolumeUnico
         { 
            get { return this._valueVolumeUnico; } 
            set 
            { 
                if (this._valueVolumeUnico == value)return;
                 this._valueVolumeUnico = value; 
            } 
        } 

       protected bool _configuradoOriginal{get;private set;}
       private bool _configuradoOriginalCommited{get; set;}
        private bool _valueConfigurado;
         [Column("pei_configurado")]
        public virtual bool Configurado
         { 
            get { return this._valueConfigurado; } 
            set 
            { 
                if (this._valueConfigurado == value)return;
                 this._valueConfigurado = value; 
            } 
        } 

       protected bool _exportacaoOriginal{get;private set;}
       private bool _exportacaoOriginalCommited{get; set;}
        private bool _valueExportacao;
         [Column("pei_exportacao")]
        public virtual bool Exportacao
         { 
            get { return this._valueExportacao; } 
            set 
            { 
                if (this._valueExportacao == value)return;
                 this._valueExportacao = value; 
            } 
        } 

       protected double _precoTotalOriginalOriginal{get;private set;}
       private double _precoTotalOriginalOriginalCommited{get; set;}
        private double _valuePrecoTotalOriginal;
         [Column("pei_preco_total_original")]
        public virtual double PrecoTotalOriginal
         { 
            get { return this._valuePrecoTotalOriginal; } 
            set 
            { 
                if (this._valuePrecoTotalOriginal == value)return;
                 this._valuePrecoTotalOriginal = value; 
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
         [Column("pei_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected string _justificativaCancelamentoOriginal{get;private set;}
       private string _justificativaCancelamentoOriginalCommited{get; set;}
        private string _valueJustificativaCancelamento;
         [Column("pei_justificativa_cancelamento")]
        public virtual string JustificativaCancelamento
         { 
            get { return this._valueJustificativaCancelamento; } 
            set 
            { 
                if (this._valueJustificativaCancelamento == value)return;
                 this._valueJustificativaCancelamento = value; 
            } 
        } 

       protected DateTime? _dataConfiguracaoOriginal{get;private set;}
       private DateTime? _dataConfiguracaoOriginalCommited{get; set;}
        private DateTime? _valueDataConfiguracao;
         [Column("pei_data_configuracao")]
        public virtual DateTime? DataConfiguracao
         { 
            get { return this._valueDataConfiguracao; } 
            set 
            { 
                if (this._valueDataConfiguracao == value)return;
                 this._valueDataConfiguracao = value; 
            } 
        } 

       protected UrgenciaPedido _urgenteOriginal{get;private set;}
       private UrgenciaPedido _urgenteOriginalCommited{get; set;}
        private UrgenciaPedido _valueUrgente;
         [Column("pei_urgente")]
        public virtual UrgenciaPedido Urgente
         { 
            get { return this._valueUrgente; } 
            set 
            { 
                if (this._valueUrgente == value)return;
                 this._valueUrgente = value; 
            } 
        } 

        public bool Urgente_Normal
         { 
            get { return this._valueUrgente == BibliotecaEntidades.Base.UrgenciaPedido.Normal; } 
            set { if (value) this._valueUrgente = BibliotecaEntidades.Base.UrgenciaPedido.Normal; }
         } 

        public bool Urgente_Antecipacao
         { 
            get { return this._valueUrgente == BibliotecaEntidades.Base.UrgenciaPedido.Antecipacao; } 
            set { if (value) this._valueUrgente = BibliotecaEntidades.Base.UrgenciaPedido.Antecipacao; }
         } 

        public bool Urgente_Urgente
         { 
            get { return this._valueUrgente == BibliotecaEntidades.Base.UrgenciaPedido.Urgente; } 
            set { if (value) this._valueUrgente = BibliotecaEntidades.Base.UrgenciaPedido.Urgente; }
         } 

        public bool Urgente_Critico
         { 
            get { return this._valueUrgente == BibliotecaEntidades.Base.UrgenciaPedido.Critico; } 
            set { if (value) this._valueUrgente = BibliotecaEntidades.Base.UrgenciaPedido.Critico; }
         } 

       protected string _urgenteSolicitanteOriginal{get;private set;}
       private string _urgenteSolicitanteOriginalCommited{get; set;}
        private string _valueUrgenteSolicitante;
         [Column("pei_urgente_solicitante")]
        public virtual string UrgenteSolicitante
         { 
            get { return this._valueUrgenteSolicitante; } 
            set 
            { 
                if (this._valueUrgenteSolicitante == value)return;
                 this._valueUrgenteSolicitante = value; 
            } 
        } 

       protected DateTime? _urgenteDataPrometidaOriginal{get;private set;}
       private DateTime? _urgenteDataPrometidaOriginalCommited{get; set;}
        private DateTime? _valueUrgenteDataPrometida;
         [Column("pei_urgente_data_prometida")]
        public virtual DateTime? UrgenteDataPrometida
         { 
            get { return this._valueUrgenteDataPrometida; } 
            set 
            { 
                if (this._valueUrgenteDataPrometida == value)return;
                 this._valueUrgenteDataPrometida = value; 
            } 
        } 

       protected string _urgenteInformacoesComplementaresOriginal{get;private set;}
       private string _urgenteInformacoesComplementaresOriginalCommited{get; set;}
        private string _valueUrgenteInformacoesComplementares;
         [Column("pei_urgente_informacoes_complementares")]
        public virtual string UrgenteInformacoesComplementares
         { 
            get { return this._valueUrgenteInformacoesComplementares; } 
            set 
            { 
                if (this._valueUrgenteInformacoesComplementares == value)return;
                 this._valueUrgenteInformacoesComplementares = value; 
            } 
        } 

       protected DateTime? _dataEntregaOriginalOriginal{get;private set;}
       private DateTime? _dataEntregaOriginalOriginalCommited{get; set;}
        private DateTime? _valueDataEntregaOriginal;
         [Column("pei_data_entrega_original")]
        public virtual DateTime? DataEntregaOriginal
         { 
            get { return this._valueDataEntregaOriginal; } 
            set 
            { 
                if (this._valueDataEntregaOriginal == value)return;
                 this._valueDataEntregaOriginal = value; 
            } 
        } 

       protected string _informacaoEspecialOriginal{get;private set;}
       private string _informacaoEspecialOriginalCommited{get; set;}
        private string _valueInformacaoEspecial;
         [Column("pei_informacao_especial")]
        public virtual string InformacaoEspecial
         { 
            get { return this._valueInformacaoEspecial; } 
            set 
            { 
                if (this._valueInformacaoEspecial == value)return;
                 this._valueInformacaoEspecial = value; 
            } 
        } 

       protected bool _rastreamentoMaterialOriginal{get;private set;}
       private bool _rastreamentoMaterialOriginalCommited{get; set;}
        private bool _valueRastreamentoMaterial;
         [Column("pei_rastreamento_material")]
        public virtual bool RastreamentoMaterial
         { 
            get { return this._valueRastreamentoMaterial; } 
            set 
            { 
                if (this._valueRastreamentoMaterial == value)return;
                 this._valueRastreamentoMaterial = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _contaBancariaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ContaBancariaClass _valueContaBancaria;
        [Column("id_conta_bancaria", "conta_bancaria", "id_conta_bancaria")]
       public virtual BibliotecaEntidades.Entidades.ContaBancariaClass ContaBancaria
        { 
           get {                 return this._valueContaBancaria; } 
           set 
           { 
                if (this._valueContaBancaria == value)return;
                 this._valueContaBancaria = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _centroCustoLucroOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CentroCustoLucroClass _valueCentroCustoLucro;
        [Column("id_centro_custo_lucro", "centro_custo_lucro", "id_centro_custo_lucro")]
       public virtual BibliotecaEntidades.Entidades.CentroCustoLucroClass CentroCustoLucro
        { 
           get {                 return this._valueCentroCustoLucro; } 
           set 
           { 
                if (this._valueCentroCustoLucro == value)return;
                 this._valueCentroCustoLucro = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FormaPagamentoClass _formaPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FormaPagamentoClass _formaPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FormaPagamentoClass _valueFormaPagamento;
        [Column("id_forma_pagamento", "forma_pagamento", "id_forma_pagamento")]
       public virtual BibliotecaEntidades.Entidades.FormaPagamentoClass FormaPagamento
        { 
           get {                 return this._valueFormaPagamento; } 
           set 
           { 
                if (this._valueFormaPagamento == value)return;
                 this._valueFormaPagamento = value; 
           } 
       } 

       protected bool _numeroPedidoAutomaticoOriginal{get;private set;}
       private bool _numeroPedidoAutomaticoOriginalCommited{get; set;}
        private bool _valueNumeroPedidoAutomatico;
         [Column("pei_numero_pedido_automatico")]
        public virtual bool NumeroPedidoAutomatico
         { 
            get { return this._valueNumeroPedidoAutomatico; } 
            set 
            { 
                if (this._valueNumeroPedidoAutomatico == value)return;
                 this._valueNumeroPedidoAutomatico = value; 
            } 
        } 

       protected FormaFretePedido _formaFreteOriginal{get;private set;}
       private FormaFretePedido _formaFreteOriginalCommited{get; set;}
        private FormaFretePedido _valueFormaFrete;
         [Column("pei_forma_frete")]
        public virtual FormaFretePedido FormaFrete
         { 
            get { return this._valueFormaFrete; } 
            set 
            { 
                if (this._valueFormaFrete == value)return;
                 this._valueFormaFrete = value; 
            } 
        } 

        public bool FormaFrete_Normal
         { 
            get { return this._valueFormaFrete == BibliotecaEntidades.Base.FormaFretePedido.Normal; } 
            set { if (value) this._valueFormaFrete = BibliotecaEntidades.Base.FormaFretePedido.Normal; }
         } 

        public bool FormaFrete_RateadoItens
         { 
            get { return this._valueFormaFrete == BibliotecaEntidades.Base.FormaFretePedido.RateadoItens; } 
            set { if (value) this._valueFormaFrete = BibliotecaEntidades.Base.FormaFretePedido.RateadoItens; }
         } 

       protected ResponsavelFrete? _responsavelFreteOriginal{get;private set;}
       private ResponsavelFrete? _responsavelFreteOriginalCommited{get; set;}
        private ResponsavelFrete? _valueResponsavelFrete;
         [Column("pei_responsavel_frete")]
        public virtual ResponsavelFrete? ResponsavelFrete
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
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioRemetente; }
         } 

        public bool ResponsavelFrete_ProprioDestinatario
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.ProprioDestinatario; }
         } 

        public bool ResponsavelFrete_Emitente
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Emitente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Emitente; }
         } 

        public bool ResponsavelFrete_Cliente
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Cliente; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Cliente; }
         } 

        public bool ResponsavelFrete_Terceiros
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.Terceiros; }
         } 

        public bool ResponsavelFrete_SemFrete
         { 
            get { return this._valueResponsavelFrete.HasValue && this._valueResponsavelFrete.Value == BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; } 
            set { if (value) this._valueResponsavelFrete = BibliotecaEntidades.Base.ResponsavelFrete.SemFrete; }
         } 

       protected string _ordemVendaOriginal{get;private set;}
       private string _ordemVendaOriginalCommited{get; set;}
        private string _valueOrdemVenda;
         [Column("pei_ordem_venda")]
        public virtual string OrdemVenda
         { 
            get { return this._valueOrdemVenda; } 
            set 
            { 
                if (this._valueOrdemVenda == value)return;
                 this._valueOrdemVenda = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.RepresentanteClass _representanteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.RepresentanteClass _representanteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.RepresentanteClass _valueRepresentante;
        [Column("id_representante", "representante", "id_representante")]
       public virtual BibliotecaEntidades.Entidades.RepresentanteClass Representante
        { 
           get {                 return this._valueRepresentante; } 
           set 
           { 
                if (this._valueRepresentante == value)return;
                 this._valueRepresentante = value; 
           } 
       } 

       protected double? _percComissaoRepresentanteOriginal{get;private set;}
       private double? _percComissaoRepresentanteOriginalCommited{get; set;}
        private double? _valuePercComissaoRepresentante;
         [Column("pei_perc_comissao_representante")]
        public virtual double? PercComissaoRepresentante
         { 
            get { return this._valuePercComissaoRepresentante; } 
            set 
            { 
                if (this._valuePercComissaoRepresentante == value)return;
                 this._valuePercComissaoRepresentante = value; 
            } 
        } 

       protected DateTime? _dataEncerramentoOriginal{get;private set;}
       private DateTime? _dataEncerramentoOriginalCommited{get; set;}
        private DateTime? _valueDataEncerramento;
         [Column("pei_data_encerramento")]
        public virtual DateTime? DataEncerramento
         { 
            get { return this._valueDataEncerramento; } 
            set 
            { 
                if (this._valueDataEncerramento == value)return;
                 this._valueDataEncerramento = value; 
            } 
        } 

       protected string _obsPadraoEspelhoOriginal{get;private set;}
       private string _obsPadraoEspelhoOriginalCommited{get; set;}
        private string _valueObsPadraoEspelho;
         [Column("pei_obs_padrao_espelho")]
        public virtual string ObsPadraoEspelho
         { 
            get { return this._valueObsPadraoEspelho; } 
            set 
            { 
                if (this._valueObsPadraoEspelho == value)return;
                 this._valueObsPadraoEspelho = value; 
            } 
        } 

       protected DateTime _dataUltimaAlteracaoOriginal{get;private set;}
       private DateTime _dataUltimaAlteracaoOriginalCommited{get; set;}
        private DateTime _valueDataUltimaAlteracao;
         [Column("pei_data_ultima_alteracao")]
        public virtual DateTime DataUltimaAlteracao
         { 
            get { return this._valueDataUltimaAlteracao; } 
            set 
            { 
                if (this._valueDataUltimaAlteracao == value)return;
                 this._valueDataUltimaAlteracao = value; 
            } 
        } 

       protected string _suspensaoObsOriginal{get;private set;}
       private string _suspensaoObsOriginalCommited{get; set;}
        private string _valueSuspensaoObs;
         [Column("pei_suspensao_obs")]
        public virtual string SuspensaoObs
         { 
            get { return this._valueSuspensaoObs; } 
            set 
            { 
                if (this._valueSuspensaoObs == value)return;
                 this._valueSuspensaoObs = value; 
            } 
        } 

       protected IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioResponsavelSuspensaoOriginal{get;private set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _acsUsuarioResponsavelSuspensaoOriginalCommited {get; set;}
       private IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass _valueAcsUsuarioResponsavelSuspensao;
        [Column("id_acs_usuario_responsavel_suspensao", "acs_usuario", "id_acs_usuario")]
       public virtual IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass AcsUsuarioResponsavelSuspensao
        { 
           get {                 return this._valueAcsUsuarioResponsavelSuspensao; } 
           set 
           { 
                if (this._valueAcsUsuarioResponsavelSuspensao == value)return;
                 this._valueAcsUsuarioResponsavelSuspensao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.VendedorClass _vendedorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.VendedorClass _valueVendedor;
        [Column("id_vendedor", "vendedor", "id_vendedor")]
       public virtual BibliotecaEntidades.Entidades.VendedorClass Vendedor
        { 
           get {                 return this._valueVendedor; } 
           set 
           { 
                if (this._valueVendedor == value)return;
                 this._valueVendedor = value; 
           } 
       } 

       protected double? _percComissaoVendedorOriginal{get;private set;}
       private double? _percComissaoVendedorOriginalCommited{get; set;}
        private double? _valuePercComissaoVendedor;
         [Column("pei_perc_comissao_vendedor")]
        public virtual double? PercComissaoVendedor
         { 
            get { return this._valuePercComissaoVendedor; } 
            set 
            { 
                if (this._valuePercComissaoVendedor == value)return;
                 this._valuePercComissaoVendedor = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _pedidoItemPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoItemClass _valuePedidoItemPai;
        [Column("id_pedido_item_pai", "pedido_item", "id_pedido_item")]
       public virtual BibliotecaEntidades.Entidades.PedidoItemClass PedidoItemPai
        { 
           get {                 return this._valuePedidoItemPai; } 
           set 
           { 
                if (this._valuePedidoItemPai == value)return;
                 this._valuePedidoItemPai = value; 
           } 
       } 

       protected bool _comissaoGeradaOriginal{get;private set;}
       private bool _comissaoGeradaOriginalCommited{get; set;}
        private bool _valueComissaoGerada;
         [Column("pei_comissao_gerada")]
        public virtual bool ComissaoGerada
         { 
            get { return this._valueComissaoGerada; } 
            set 
            { 
                if (this._valueComissaoGerada == value)return;
                 this._valueComissaoGerada = value; 
            } 
        } 

       protected string _observacaoNfOriginal{get;private set;}
       private string _observacaoNfOriginalCommited{get; set;}
        private string _valueObservacaoNf;
         [Column("pei_observacao_nf")]
        public virtual string ObservacaoNf
         { 
            get { return this._valueObservacaoNf; } 
            set 
            { 
                if (this._valueObservacaoNf == value)return;
                 this._valueObservacaoNf = value; 
            } 
        } 

       protected bool _faturamentoAntecipadoRealizadoOriginal{get;private set;}
       private bool _faturamentoAntecipadoRealizadoOriginalCommited{get; set;}
        private bool _valueFaturamentoAntecipadoRealizado;
         [Column("pei_faturamento_antecipado_realizado")]
        public virtual bool FaturamentoAntecipadoRealizado
         { 
            get { return this._valueFaturamentoAntecipadoRealizado; } 
            set 
            { 
                if (this._valueFaturamentoAntecipadoRealizado == value)return;
                 this._valueFaturamentoAntecipadoRealizado = value; 
            } 
        } 

       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalFaturamentoAntecipadoOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalFaturamentoAntecipadoOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipalFaturamentoAntecipado;
        [Column("id_nf_principal_faturamento_antecipado", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipalFaturamentoAntecipado
        { 
           get {                 return this._valueNfPrincipalFaturamentoAntecipado; } 
           set 
           { 
                if (this._valueNfPrincipalFaturamentoAntecipado == value)return;
                 this._valueNfPrincipalFaturamentoAntecipado = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.NcmClass _ncmOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NcmClass _ncmOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NcmClass _valueNcm;
        [Column("id_ncm", "ncm", "id_ncm")]
       public virtual BibliotecaEntidades.Entidades.NcmClass Ncm
        { 
           get {                 return this._valueNcm; } 
           set 
           { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
           } 
       } 

       protected GadIntegracaoPedidoSituacao _situacaoGadOriginal{get;private set;}
       private GadIntegracaoPedidoSituacao _situacaoGadOriginalCommited{get; set;}
        private GadIntegracaoPedidoSituacao _valueSituacaoGad;
         [Column("pei_situacao_gad")]
        public virtual GadIntegracaoPedidoSituacao SituacaoGad
         { 
            get { return this._valueSituacaoGad; } 
            set 
            { 
                if (this._valueSituacaoGad == value)return;
                 this._valueSituacaoGad = value; 
            } 
        } 

        public bool SituacaoGad_SemGad
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.SemGad; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.SemGad; }
         } 

        public bool SituacaoGad_Enviado
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Enviado; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Enviado; }
         } 

        public bool SituacaoGad_EmAnalise
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.EmAnalise; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.EmAnalise; }
         } 

        public bool SituacaoGad_Liberado
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Liberado; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Liberado; }
         } 

        public bool SituacaoGad_Programado
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Programado; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Programado; }
         } 

        public bool SituacaoGad_Cancelado
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Cancelado; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.Cancelado; }
         } 

        public bool SituacaoGad_ErroNoPedido
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.ErroNoPedido; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.ErroNoPedido; }
         } 

        public bool SituacaoGad_ErroRecepcionarPedido
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.ErroRecepcionarPedido; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.ErroRecepcionarPedido; }
         } 

        public bool SituacaoGad_AguardandoEnvio
         { 
            get { return this._valueSituacaoGad == BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.AguardandoEnvio; } 
            set { if (value) this._valueSituacaoGad = BibliotecaEntidades.Base.GadIntegracaoPedidoSituacao.AguardandoEnvio; }
         } 

       protected string _situacaoGadMensagemOriginal{get;private set;}
       private string _situacaoGadMensagemOriginalCommited{get; set;}
        private string _valueSituacaoGadMensagem;
         [Column("pei_situacao_gad_mensagem")]
        public virtual string SituacaoGadMensagem
         { 
            get { return this._valueSituacaoGadMensagem; } 
            set 
            { 
                if (this._valueSituacaoGadMensagem == value)return;
                 this._valueSituacaoGadMensagem = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ProgramacaoClass _programacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ProgramacaoClass _programacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ProgramacaoClass _valueProgramacao;
        [Column("id_programacao", "programacao", "id_programacao")]
       public virtual BibliotecaEntidades.Entidades.ProgramacaoClass Programacao
        { 
           get {                 return this._valueProgramacao; } 
           set 
           { 
                if (this._valueProgramacao == value)return;
                 this._valueProgramacao = value; 
           } 
       } 

       protected EasiEmissorNFe _emissorNfeOriginal{get;private set;}
       private EasiEmissorNFe _emissorNfeOriginalCommited{get; set;}
        private EasiEmissorNFe _valueEmissorNfe;
         [Column("pei_emissor_nfe")]
        public virtual EasiEmissorNFe EmissorNfe
         { 
            get { return this._valueEmissorNfe; } 
            set 
            { 
                if (this._valueEmissorNfe == value)return;
                 this._valueEmissorNfe = value; 
            } 
        } 

        public bool EmissorNfe_Primario
         { 
            get { return this._valueEmissorNfe == BibliotecaEntidades.Base.EasiEmissorNFe.Primario; } 
            set { if (value) this._valueEmissorNfe = BibliotecaEntidades.Base.EasiEmissorNFe.Primario; }
         } 

        public bool EmissorNfe_Secundario
         { 
            get { return this._valueEmissorNfe == BibliotecaEntidades.Base.EasiEmissorNFe.Secundario; } 
            set { if (value) this._valueEmissorNfe = BibliotecaEntidades.Base.EasiEmissorNFe.Secundario; }
         } 

       protected BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _valueOperacaoCompleta;
        [Column("id_operacao_completa", "operacao_completa", "id_operacao_completa")]
       public virtual BibliotecaEntidades.Entidades.OperacaoCompletaClass OperacaoCompleta
        { 
           get {                 return this._valueOperacaoCompleta; } 
           set 
           { 
                if (this._valueOperacaoCompleta == value)return;
                 this._valueOperacaoCompleta = value; 
           } 
       } 

       protected bool _gadProgramadoOriginal{get;private set;}
       private bool _gadProgramadoOriginalCommited{get; set;}
        private bool _valueGadProgramado;
         [Column("pei_gad_programado")]
        public virtual bool GadProgramado
         { 
            get { return this._valueGadProgramado; } 
            set 
            { 
                if (this._valueGadProgramado == value)return;
                 this._valueGadProgramado = value; 
            } 
        } 

       protected string _gadProgramacaoNomeOriginal{get;private set;}
       private string _gadProgramacaoNomeOriginalCommited{get; set;}
        private string _valueGadProgramacaoNome;
         [Column("pei_gad_programacao_nome")]
        public virtual string GadProgramacaoNome
         { 
            get { return this._valueGadProgramacaoNome; } 
            set 
            { 
                if (this._valueGadProgramacaoNome == value)return;
                 this._valueGadProgramacaoNome = value; 
            } 
        } 

       protected string _gadProgramacaoDataOriginal{get;private set;}
       private string _gadProgramacaoDataOriginalCommited{get; set;}
        private string _valueGadProgramacaoData;
         [Column("pei_gad_programacao_data")]
        public virtual string GadProgramacaoData
         { 
            get { return this._valueGadProgramacaoData; } 
            set 
            { 
                if (this._valueGadProgramacaoData == value)return;
                 this._valueGadProgramacaoData = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _tipoPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.TipoPagamentoClass _valueTipoPagamento;
        [Column("id_tipo_pagamento", "tipo_pagamento", "id_tipo_pagamento")]
       public virtual BibliotecaEntidades.Entidades.TipoPagamentoClass TipoPagamento
        { 
           get {                 return this._valueTipoPagamento; } 
           set 
           { 
                if (this._valueTipoPagamento == value)return;
                 this._valueTipoPagamento = value; 
           } 
       } 

       protected bool _envioTerceirosOriginal{get;private set;}
       private bool _envioTerceirosOriginalCommited{get; set;}
        private bool _valueEnvioTerceiros;
         [Column("ped_envio_terceiros")]
        public virtual bool EnvioTerceiros
         { 
            get { return this._valueEnvioTerceiros; } 
            set 
            { 
                if (this._valueEnvioTerceiros == value)return;
                 this._valueEnvioTerceiros = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.ClienteClass _clienteEnvioTerceirosOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.ClienteClass _clienteEnvioTerceirosOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.ClienteClass _valueClienteEnvioTerceiros;
        [Column("id_cliente_envio_terceiros", "cliente", "id_cliente")]
       public virtual BibliotecaEntidades.Entidades.ClienteClass ClienteEnvioTerceiros
        { 
           get {                 return this._valueClienteEnvioTerceiros; } 
           set 
           { 
                if (this._valueClienteEnvioTerceiros == value)return;
                 this._valueClienteEnvioTerceiros = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OperacaoClass _operacaoEnvioTerceirosOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _operacaoEnvioTerceirosOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoClass _valueOperacaoEnvioTerceiros;
        [Column("id_operacao_envio_terceiros", "operacao", "id_operacao")]
       public virtual BibliotecaEntidades.Entidades.OperacaoClass OperacaoEnvioTerceiros
        { 
           get {                 return this._valueOperacaoEnvioTerceiros; } 
           set 
           { 
                if (this._valueOperacaoEnvioTerceiros == value)return;
                 this._valueOperacaoEnvioTerceiros = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaEnvioTerceirosOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _operacaoCompletaEnvioTerceirosOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OperacaoCompletaClass _valueOperacaoCompletaEnvioTerceiros;
        [Column("id_operacao_completa_envio_terceiros", "operacao_completa", "id_operacao_completa")]
       public virtual BibliotecaEntidades.Entidades.OperacaoCompletaClass OperacaoCompletaEnvioTerceiros
        { 
           get {                 return this._valueOperacaoCompletaEnvioTerceiros; } 
           set 
           { 
                if (this._valueOperacaoCompletaEnvioTerceiros == value)return;
                 this._valueOperacaoCompletaEnvioTerceiros = value; 
           } 
       } 

       protected double _descontoOriginal{get;private set;}
       private double _descontoOriginalCommited{get; set;}
        private double _valueDesconto;
         [Column("pei_desconto")]
        public virtual double Desconto
         { 
            get { return this._valueDesconto; } 
            set 
            { 
                if (this._valueDesconto == value)return;
                 this._valueDesconto = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.PedidoClassificacaoClass _pedidoClassificacaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PedidoClassificacaoClass _pedidoClassificacaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PedidoClassificacaoClass _valuePedidoClassificacao;
        [Column("id_pedido_classificacao", "pedido_classificacao", "id_pedido_classificacao")]
       public virtual BibliotecaEntidades.Entidades.PedidoClassificacaoClass PedidoClassificacao
        { 
           get {                 return this._valuePedidoClassificacao; } 
           set 
           { 
                if (this._valuePedidoClassificacao == value)return;
                 this._valuePedidoClassificacao = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.MeioPagamentoClass _meioPagamentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.MeioPagamentoClass _meioPagamentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.MeioPagamentoClass _valueMeioPagamento;
        [Column("id_meio_pagamento", "meio_pagamento", "id_meio_pagamento")]
       public virtual BibliotecaEntidades.Entidades.MeioPagamentoClass MeioPagamento
        { 
           get {                 return this._valueMeioPagamento; } 
           set 
           { 
                if (this._valueMeioPagamento == value)return;
                 this._valueMeioPagamento = value; 
           } 
       } 

       private List<long> _collectionAtendimentoClassPedidoItemOriginal;
       private List<Entidades.AtendimentoClass > _collectionAtendimentoClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AtendimentoClass> _valueCollectionAtendimentoClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AtendimentoClass> CollectionAtendimentoClassPedidoItem 
       { 
           get { if(!_valueCollectionAtendimentoClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionAtendimentoClassPedidoItem();}
return this._valueCollectionAtendimentoClassPedidoItem; } 
           set 
           { 
               this._valueCollectionAtendimentoClassPedidoItem = value; 
               this._valueCollectionAtendimentoClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionGadPedidosUploadClassPedidoItemOriginal;
       private List<Entidades.GadPedidosUploadClass > _collectionGadPedidosUploadClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionGadPedidosUploadClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionGadPedidosUploadClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.GadPedidosUploadClass> _valueCollectionGadPedidosUploadClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.GadPedidosUploadClass> CollectionGadPedidosUploadClassPedidoItem 
       { 
           get { if(!_valueCollectionGadPedidosUploadClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionGadPedidosUploadClassPedidoItem();}
return this._valueCollectionGadPedidosUploadClassPedidoItem; } 
           set 
           { 
               this._valueCollectionGadPedidosUploadClassPedidoItem = value; 
               this._valueCollectionGadPedidosUploadClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionNotificacaoDesvioClassPedidoItemOriginal;
       private List<Entidades.NotificacaoDesvioClass > _collectionNotificacaoDesvioClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NotificacaoDesvioClass> _valueCollectionNotificacaoDesvioClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NotificacaoDesvioClass> CollectionNotificacaoDesvioClassPedidoItem 
       { 
           get { if(!_valueCollectionNotificacaoDesvioClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionNotificacaoDesvioClassPedidoItem();}
return this._valueCollectionNotificacaoDesvioClassPedidoItem; } 
           set 
           { 
               this._valueCollectionNotificacaoDesvioClassPedidoItem = value; 
               this._valueCollectionNotificacaoDesvioClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassPedidoItemOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassPedidoItem 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassPedidoItem();}
return this._valueCollectionOrderItemEtiquetaClassPedidoItem; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassPedidoItem = value; 
               this._valueCollectionOrderItemEtiquetaClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoOriginal;
       private List<Entidades.OrderItemEtiquetaClass > _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaClass> _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaClass> CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido();}
return this._valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido = value; 
               this._valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoDocumentoClassPedidoItemOriginal;
       private List<Entidades.PedidoDocumentoClass > _collectionPedidoDocumentoClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoDocumentoClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoDocumentoClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoDocumentoClass> _valueCollectionPedidoDocumentoClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoDocumentoClass> CollectionPedidoDocumentoClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoDocumentoClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoDocumentoClassPedidoItem();}
return this._valueCollectionPedidoDocumentoClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoDocumentoClassPedidoItem = value; 
               this._valueCollectionPedidoDocumentoClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassPedidoItemPaiOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassPedidoItemPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassPedidoItemPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassPedidoItemPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassPedidoItemPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassPedidoItemPai 
       { 
           get { if(!_valueCollectionPedidoItemClassPedidoItemPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassPedidoItemPai();}
return this._valueCollectionPedidoItemClassPedidoItemPai; } 
           set 
           { 
               this._valueCollectionPedidoItemClassPedidoItemPai = value; 
               this._valueCollectionPedidoItemClassPedidoItemPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemFeedbackClassPedidoItemOriginal;
       private List<Entidades.PedidoItemFeedbackClass > _collectionPedidoItemFeedbackClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemFeedbackClass> _valueCollectionPedidoItemFeedbackClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemFeedbackClass> CollectionPedidoItemFeedbackClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemFeedbackClassPedidoItem();}
return this._valueCollectionPedidoItemFeedbackClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemFeedbackClassPedidoItem = value; 
               this._valueCollectionPedidoItemFeedbackClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemFeedbackSecundarioClassPedidoItemOriginal;
       private List<Entidades.PedidoItemFeedbackSecundarioClass > _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemFeedbackSecundarioClass> _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemFeedbackSecundarioClass> CollectionPedidoItemFeedbackSecundarioClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemFeedbackSecundarioClassPedidoItem();}
return this._valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem = value; 
               this._valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemHistoricoAlteracoesClassPedidoItemOriginal;
       private List<Entidades.PedidoItemHistoricoAlteracoesClass > _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemHistoricoAlteracoesClass> _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemHistoricoAlteracoesClass> CollectionPedidoItemHistoricoAlteracoesClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemHistoricoAlteracoesClassPedidoItem();}
return this._valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem = value; 
               this._valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemLoteClienteClassPedidoItemOriginal;
       private List<Entidades.PedidoItemLoteClienteClass > _collectionPedidoItemLoteClienteClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemLoteClienteClass> _valueCollectionPedidoItemLoteClienteClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemLoteClienteClass> CollectionPedidoItemLoteClienteClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemLoteClienteClassPedidoItem();}
return this._valueCollectionPedidoItemLoteClienteClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemLoteClienteClassPedidoItem = value; 
               this._valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemQualidadeClassPedidoItemOriginal;
       private List<Entidades.PedidoItemQualidadeClass > _collectionPedidoItemQualidadeClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemQualidadeClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemQualidadeClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemQualidadeClass> _valueCollectionPedidoItemQualidadeClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemQualidadeClass> CollectionPedidoItemQualidadeClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemQualidadeClassPedidoItem();}
return this._valueCollectionPedidoItemQualidadeClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemQualidadeClassPedidoItem = value; 
               this._valueCollectionPedidoItemQualidadeClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemVariavelClassPedidoItemOriginal;
       private List<Entidades.PedidoItemVariavelClass > _collectionPedidoItemVariavelClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemVariavelClass> _valueCollectionPedidoItemVariavelClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemVariavelClass> CollectionPedidoItemVariavelClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemVariavelClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemVariavelClassPedidoItem();}
return this._valueCollectionPedidoItemVariavelClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemVariavelClassPedidoItem = value; 
               this._valueCollectionPedidoItemVariavelClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemVolumeClassPedidoItemOriginal;
       private List<Entidades.PedidoItemVolumeClass > _collectionPedidoItemVolumeClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVolumeClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVolumeClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemVolumeClass> _valueCollectionPedidoItemVolumeClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemVolumeClass> CollectionPedidoItemVolumeClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoItemVolumeClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemVolumeClassPedidoItem();}
return this._valueCollectionPedidoItemVolumeClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoItemVolumeClassPedidoItem = value; 
               this._valueCollectionPedidoItemVolumeClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoKitClassPedidoItemOriginal;
       private List<Entidades.PedidoKitClass > _collectionPedidoKitClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoKitClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoKitClass> _valueCollectionPedidoKitClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoKitClass> CollectionPedidoKitClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoKitClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoKitClassPedidoItem();}
return this._valueCollectionPedidoKitClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoKitClassPedidoItem = value; 
               this._valueCollectionPedidoKitClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoVariavelClassPedidoItemOriginal;
       private List<Entidades.PedidoVariavelClass > _collectionPedidoVariavelClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoVariavelClass> _valueCollectionPedidoVariavelClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoVariavelClass> CollectionPedidoVariavelClassPedidoItem 
       { 
           get { if(!_valueCollectionPedidoVariavelClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoVariavelClassPedidoItem();}
return this._valueCollectionPedidoVariavelClassPedidoItem; } 
           set 
           { 
               this._valueCollectionPedidoVariavelClassPedidoItem = value; 
               this._valueCollectionPedidoVariavelClassPedidoItemLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraPedidoClassPedidoItemOriginal;
       private List<Entidades.SolicitacaoCompraPedidoClass > _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraPedidoClass> _valueCollectionSolicitacaoCompraPedidoClassPedidoItem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraPedidoClass> CollectionSolicitacaoCompraPedidoClassPedidoItem 
       { 
           get { if(!_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraPedidoClassPedidoItem();}
return this._valueCollectionSolicitacaoCompraPedidoClassPedidoItem; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraPedidoClassPedidoItem = value; 
               this._valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded = true; 
           } 
       } 

        public PedidoItemBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Posicao = 1;
           this.SubLinha = 0;
           this.Quantidade = 1;
           this.Saldo = 1;
           this.Frete = 0;
           this.DataEntrada = Configurations.DataIndependenteClass.GetData();
           this.PermiteEntregaParcial = false;
           this.VolumeUnico = false;
           this.Configurado = false;
           this.Exportacao = false;
           this.Urgente = (UrgenciaPedido)0;
           this.RastreamentoMaterial = false;
           this.NumeroPedidoAutomatico = false;
           this.FormaFrete = (FormaFretePedido)1;
           this.ComissaoGerada = false;
           this.FaturamentoAntecipadoRealizado = false;
           this.SituacaoGad = (GadIntegracaoPedidoSituacao)0;
           this.EmissorNfe = (EasiEmissorNFe)0;
           this.GadProgramado = false;
           this.EnvioTerceiros = false;
           this.Desconto = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static PedidoItemClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (PedidoItemClass) GetEntity(typeof(PedidoItemClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAtendimentoClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAtendimentoClassPedidoItemChanged = true;
                  _valueCollectionAtendimentoClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAtendimentoClassPedidoItemChanged = true; 
                  _valueCollectionAtendimentoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in e.OldItems) 
                 { 
                     _collectionAtendimentoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAtendimentoClassPedidoItemChanged = true; 
                  _valueCollectionAtendimentoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in _valueCollectionAtendimentoClassPedidoItem) 
                 { 
                     _collectionAtendimentoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAtendimentoClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.AtendimentoClass> oc;
                _valueCollectionAtendimentoClassPedidoItemChanged = false;
                 _valueCollectionAtendimentoClassPedidoItemCommitedChanged = false;
                _collectionAtendimentoClassPedidoItemRemovidos = new List<Entidades.AtendimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AtendimentoClass>();
                }
                else{ 
                   Entidades.AtendimentoClass search = new Entidades.AtendimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AtendimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.AtendimentoClass>().ToList());
                 }
                 _valueCollectionAtendimentoClassPedidoItem = new BindingList<Entidades.AtendimentoClass>(oc); 
                 _collectionAtendimentoClassPedidoItemOriginal= (from a in _valueCollectionAtendimentoClassPedidoItem select a.ID).ToList();
                 _valueCollectionAtendimentoClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionAtendimentoClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAtendimentoClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionGadPedidosUploadClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionGadPedidosUploadClassPedidoItemChanged = true;
                  _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionGadPedidosUploadClassPedidoItemChanged = true; 
                  _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.GadPedidosUploadClass item in e.OldItems) 
                 { 
                     _collectionGadPedidosUploadClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionGadPedidosUploadClassPedidoItemChanged = true; 
                  _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.GadPedidosUploadClass item in _valueCollectionGadPedidosUploadClassPedidoItem) 
                 { 
                     _collectionGadPedidosUploadClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionGadPedidosUploadClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.GadPedidosUploadClass> oc;
                _valueCollectionGadPedidosUploadClassPedidoItemChanged = false;
                 _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged = false;
                _collectionGadPedidosUploadClassPedidoItemRemovidos = new List<Entidades.GadPedidosUploadClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.GadPedidosUploadClass>();
                }
                else{ 
                   Entidades.GadPedidosUploadClass search = new Entidades.GadPedidosUploadClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.GadPedidosUploadClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.GadPedidosUploadClass>().ToList());
                 }
                 _valueCollectionGadPedidosUploadClassPedidoItem = new BindingList<Entidades.GadPedidosUploadClass>(oc); 
                 _collectionGadPedidosUploadClassPedidoItemOriginal= (from a in _valueCollectionGadPedidosUploadClassPedidoItem select a.ID).ToList();
                 _valueCollectionGadPedidosUploadClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionGadPedidosUploadClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionGadPedidosUploadClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionNotificacaoDesvioClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNotificacaoDesvioClassPedidoItemChanged = true;
                  _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNotificacaoDesvioClassPedidoItemChanged = true; 
                  _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in e.OldItems) 
                 { 
                     _collectionNotificacaoDesvioClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNotificacaoDesvioClassPedidoItemChanged = true; 
                  _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in _valueCollectionNotificacaoDesvioClassPedidoItem) 
                 { 
                     _collectionNotificacaoDesvioClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNotificacaoDesvioClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.NotificacaoDesvioClass> oc;
                _valueCollectionNotificacaoDesvioClassPedidoItemChanged = false;
                 _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged = false;
                _collectionNotificacaoDesvioClassPedidoItemRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NotificacaoDesvioClass>();
                }
                else{ 
                   Entidades.NotificacaoDesvioClass search = new Entidades.NotificacaoDesvioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NotificacaoDesvioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.NotificacaoDesvioClass>().ToList());
                 }
                 _valueCollectionNotificacaoDesvioClassPedidoItem = new BindingList<Entidades.NotificacaoDesvioClass>(oc); 
                 _collectionNotificacaoDesvioClassPedidoItemOriginal= (from a in _valueCollectionNotificacaoDesvioClassPedidoItem select a.ID).ToList();
                 _valueCollectionNotificacaoDesvioClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionNotificacaoDesvioClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNotificacaoDesvioClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemChanged = true;
                  _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassPedidoItem) 
                 { 
                     _collectionOrderItemEtiquetaClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassPedidoItemChanged = false;
                 _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged = false;
                _collectionOrderItemEtiquetaClassPedidoItemRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassPedidoItem = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassPedidoItemOriginal= (from a in _valueCollectionOrderItemEtiquetaClassPedidoItem select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged = true;
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged = true; 
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaClass item in _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido) 
                 { 
                     _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaClass> oc;
                _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged = false;
                 _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged = false;
                _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaClass search = new Entidades.OrderItemEtiquetaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItemLinhaPrincipalPedido", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido = new BindingList<Entidades.OrderItemEtiquetaClass>(oc); 
                 _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoDocumentoClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoDocumentoClassPedidoItemChanged = true;
                  _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoDocumentoClassPedidoItemChanged = true; 
                  _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionPedidoDocumentoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoDocumentoClassPedidoItemChanged = true; 
                  _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoDocumentoClass item in _valueCollectionPedidoDocumentoClassPedidoItem) 
                 { 
                     _collectionPedidoDocumentoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoDocumentoClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoDocumentoClass> oc;
                _valueCollectionPedidoDocumentoClassPedidoItemChanged = false;
                 _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged = false;
                _collectionPedidoDocumentoClassPedidoItemRemovidos = new List<Entidades.PedidoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoDocumentoClass>();
                }
                else{ 
                   Entidades.PedidoDocumentoClass search = new Entidades.PedidoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoDocumentoClass>().ToList());
                 }
                 _valueCollectionPedidoDocumentoClassPedidoItem = new BindingList<Entidades.PedidoDocumentoClass>(oc); 
                 _collectionPedidoDocumentoClassPedidoItemOriginal= (from a in _valueCollectionPedidoDocumentoClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoDocumentoClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoDocumentoClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoDocumentoClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassPedidoItemPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassPedidoItemPaiChanged = true;
                  _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassPedidoItemPaiChanged = true; 
                  _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassPedidoItemPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassPedidoItemPaiChanged = true; 
                  _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassPedidoItemPai) 
                 { 
                     _collectionPedidoItemClassPedidoItemPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassPedidoItemPai()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassPedidoItemPaiChanged = false;
                 _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged = false;
                _collectionPedidoItemClassPedidoItemPaiRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItemPai", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassPedidoItemPai = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassPedidoItemPaiOriginal= (from a in _valueCollectionPedidoItemClassPedidoItemPai select a.ID).ToList();
                 _valueCollectionPedidoItemClassPedidoItemPaiLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassPedidoItemPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassPedidoItemPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemFeedbackClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemFeedbackClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemFeedbackClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemFeedbackClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemFeedbackClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemFeedbackClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemFeedbackClass item in _valueCollectionPedidoItemFeedbackClassPedidoItem) 
                 { 
                     _collectionPedidoItemFeedbackClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemFeedbackClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemFeedbackClass> oc;
                _valueCollectionPedidoItemFeedbackClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemFeedbackClassPedidoItemRemovidos = new List<Entidades.PedidoItemFeedbackClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemFeedbackClass>();
                }
                else{ 
                   Entidades.PedidoItemFeedbackClass search = new Entidades.PedidoItemFeedbackClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemFeedbackClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemFeedbackClass>().ToList());
                 }
                 _valueCollectionPedidoItemFeedbackClassPedidoItem = new BindingList<Entidades.PedidoItemFeedbackClass>(oc); 
                 _collectionPedidoItemFeedbackClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemFeedbackClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemFeedbackClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemFeedbackClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemFeedbackClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemFeedbackSecundarioClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemFeedbackSecundarioClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemFeedbackSecundarioClass item in _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem) 
                 { 
                     _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemFeedbackSecundarioClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemFeedbackSecundarioClass> oc;
                _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos = new List<Entidades.PedidoItemFeedbackSecundarioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemFeedbackSecundarioClass>();
                }
                else{ 
                   Entidades.PedidoItemFeedbackSecundarioClass search = new Entidades.PedidoItemFeedbackSecundarioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemFeedbackSecundarioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemFeedbackSecundarioClass>().ToList());
                 }
                 _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem = new BindingList<Entidades.PedidoItemFeedbackSecundarioClass>(oc); 
                 _collectionPedidoItemFeedbackSecundarioClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemFeedbackSecundarioClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemFeedbackSecundarioClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemHistoricoAlteracoesClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemHistoricoAlteracoesClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemHistoricoAlteracoesClass item in _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem) 
                 { 
                     _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemHistoricoAlteracoesClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemHistoricoAlteracoesClass> oc;
                _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos = new List<Entidades.PedidoItemHistoricoAlteracoesClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemHistoricoAlteracoesClass>();
                }
                else{ 
                   Entidades.PedidoItemHistoricoAlteracoesClass search = new Entidades.PedidoItemHistoricoAlteracoesClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemHistoricoAlteracoesClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemHistoricoAlteracoesClass>().ToList());
                 }
                 _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem = new BindingList<Entidades.PedidoItemHistoricoAlteracoesClass>(oc); 
                 _collectionPedidoItemHistoricoAlteracoesClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemHistoricoAlteracoesClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemHistoricoAlteracoesClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemLoteClienteClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemLoteClienteClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemLoteClienteClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemLoteClienteClass item in _valueCollectionPedidoItemLoteClienteClassPedidoItem) 
                 { 
                     _collectionPedidoItemLoteClienteClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemLoteClienteClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemLoteClienteClass> oc;
                _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemLoteClienteClassPedidoItemRemovidos = new List<Entidades.PedidoItemLoteClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemLoteClienteClass>();
                }
                else{ 
                   Entidades.PedidoItemLoteClienteClass search = new Entidades.PedidoItemLoteClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemLoteClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemLoteClienteClass>().ToList());
                 }
                 _valueCollectionPedidoItemLoteClienteClassPedidoItem = new BindingList<Entidades.PedidoItemLoteClienteClass>(oc); 
                 _collectionPedidoItemLoteClienteClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemLoteClienteClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemLoteClienteClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemLoteClienteClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemQualidadeClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemQualidadeClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemQualidadeClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemQualidadeClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemQualidadeClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemQualidadeClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemQualidadeClass item in _valueCollectionPedidoItemQualidadeClassPedidoItem) 
                 { 
                     _collectionPedidoItemQualidadeClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemQualidadeClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemQualidadeClass> oc;
                _valueCollectionPedidoItemQualidadeClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemQualidadeClassPedidoItemRemovidos = new List<Entidades.PedidoItemQualidadeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemQualidadeClass>();
                }
                else{ 
                   Entidades.PedidoItemQualidadeClass search = new Entidades.PedidoItemQualidadeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemQualidadeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemQualidadeClass>().ToList());
                 }
                 _valueCollectionPedidoItemQualidadeClassPedidoItem = new BindingList<Entidades.PedidoItemQualidadeClass>(oc); 
                 _collectionPedidoItemQualidadeClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemQualidadeClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemQualidadeClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemQualidadeClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemQualidadeClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemVariavelClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemVariavelClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemVariavelClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemVariavelClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemVariavelClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemVariavelClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemVariavelClass item in _valueCollectionPedidoItemVariavelClassPedidoItem) 
                 { 
                     _collectionPedidoItemVariavelClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemVariavelClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemVariavelClass> oc;
                _valueCollectionPedidoItemVariavelClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemVariavelClassPedidoItemRemovidos = new List<Entidades.PedidoItemVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemVariavelClass>();
                }
                else{ 
                   Entidades.PedidoItemVariavelClass search = new Entidades.PedidoItemVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemVariavelClass>().ToList());
                 }
                 _valueCollectionPedidoItemVariavelClassPedidoItem = new BindingList<Entidades.PedidoItemVariavelClass>(oc); 
                 _collectionPedidoItemVariavelClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemVariavelClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemVariavelClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemVariavelClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemVariavelClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemVolumeClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemVolumeClassPedidoItemChanged = true;
                  _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemVolumeClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemVolumeClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemVolumeClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemVolumeClassPedidoItemChanged = true; 
                  _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoItemVolumeClass item in _valueCollectionPedidoItemVolumeClassPedidoItem) 
                 { 
                     _collectionPedidoItemVolumeClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemVolumeClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemVolumeClass> oc;
                _valueCollectionPedidoItemVolumeClassPedidoItemChanged = false;
                 _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged = false;
                _collectionPedidoItemVolumeClassPedidoItemRemovidos = new List<Entidades.PedidoItemVolumeClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemVolumeClass>();
                }
                else{ 
                   Entidades.PedidoItemVolumeClass search = new Entidades.PedidoItemVolumeClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemVolumeClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoItemVolumeClass>().ToList());
                 }
                 _valueCollectionPedidoItemVolumeClassPedidoItem = new BindingList<Entidades.PedidoItemVolumeClass>(oc); 
                 _collectionPedidoItemVolumeClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemVolumeClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoItemVolumeClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemVolumeClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemVolumeClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoKitClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoKitClassPedidoItemChanged = true;
                  _valueCollectionPedidoKitClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoKitClassPedidoItemChanged = true; 
                  _valueCollectionPedidoKitClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoKitClass item in e.OldItems) 
                 { 
                     _collectionPedidoKitClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoKitClassPedidoItemChanged = true; 
                  _valueCollectionPedidoKitClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoKitClass item in _valueCollectionPedidoKitClassPedidoItem) 
                 { 
                     _collectionPedidoKitClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoKitClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoKitClass> oc;
                _valueCollectionPedidoKitClassPedidoItemChanged = false;
                 _valueCollectionPedidoKitClassPedidoItemCommitedChanged = false;
                _collectionPedidoKitClassPedidoItemRemovidos = new List<Entidades.PedidoKitClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoKitClass>();
                }
                else{ 
                   Entidades.PedidoKitClass search = new Entidades.PedidoKitClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoKitClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoKitClass>().ToList());
                 }
                 _valueCollectionPedidoKitClassPedidoItem = new BindingList<Entidades.PedidoKitClass>(oc); 
                 _collectionPedidoKitClassPedidoItemOriginal= (from a in _valueCollectionPedidoKitClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoKitClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoKitClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoKitClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoVariavelClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoVariavelClassPedidoItemChanged = true;
                  _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoVariavelClassPedidoItemChanged = true; 
                  _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoVariavelClass item in e.OldItems) 
                 { 
                     _collectionPedidoVariavelClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoVariavelClassPedidoItemChanged = true; 
                  _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.PedidoVariavelClass item in _valueCollectionPedidoVariavelClassPedidoItem) 
                 { 
                     _collectionPedidoVariavelClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoVariavelClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoVariavelClass> oc;
                _valueCollectionPedidoVariavelClassPedidoItemChanged = false;
                 _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged = false;
                _collectionPedidoVariavelClassPedidoItemRemovidos = new List<Entidades.PedidoVariavelClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoVariavelClass>();
                }
                else{ 
                   Entidades.PedidoVariavelClass search = new Entidades.PedidoVariavelClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoVariavelClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.PedidoVariavelClass>().ToList());
                 }
                 _valueCollectionPedidoVariavelClassPedidoItem = new BindingList<Entidades.PedidoVariavelClass>(oc); 
                 _collectionPedidoVariavelClassPedidoItemOriginal= (from a in _valueCollectionPedidoVariavelClassPedidoItem select a.ID).ToList();
                 _valueCollectionPedidoVariavelClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionPedidoVariavelClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoVariavelClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraPedidoClassPedidoItemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged = true;
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged = true; 
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraPedidoClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged = true; 
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraPedidoClass item in _valueCollectionSolicitacaoCompraPedidoClassPedidoItem) 
                 { 
                     _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraPedidoClassPedidoItem()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraPedidoClass> oc;
                _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged = false;
                 _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged = false;
                _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos = new List<Entidades.SolicitacaoCompraPedidoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraPedidoClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraPedidoClass search = new Entidades.SolicitacaoCompraPedidoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraPedidoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("PedidoItem", this),                     }                       ).Cast<Entidades.SolicitacaoCompraPedidoClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraPedidoClassPedidoItem = new BindingList<Entidades.SolicitacaoCompraPedidoClass>(oc); 
                 _collectionSolicitacaoCompraPedidoClassPedidoItemOriginal= (from a in _valueCollectionSolicitacaoCompraPedidoClassPedidoItem select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraPedidoClassPedidoItemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraPedidoClassPedidoItem+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Numero))
                {
                    throw new Exception(ErroNumeroObrigatorio);
                }
                if (Numero.Length >255)
                {
                    throw new Exception( ErroNumeroComprimento);
                }
                if (string.IsNullOrEmpty(ProdutoCodigoCliente))
                {
                    throw new Exception(ErroProdutoCodigoClienteObrigatorio);
                }
                if (ProdutoCodigoCliente.Length >255)
                {
                    throw new Exception( ErroProdutoCodigoClienteComprimento);
                }
                if (string.IsNullOrEmpty(ProdutoDescricaoCliente))
                {
                    throw new Exception(ErroProdutoDescricaoClienteObrigatorio);
                }
                if (ProdutoDescricaoCliente.Length >255)
                {
                    throw new Exception( ErroProdutoDescricaoClienteComprimento);
                }
                if (string.IsNullOrEmpty(CnpjCliente))
                {
                    throw new Exception(ErroCnpjClienteObrigatorio);
                }
                if (CnpjCliente.Length >100)
                {
                    throw new Exception( ErroCnpjClienteComprimento);
                }
                if ( _valueProduto == null)
                {
                    throw new Exception(ErroProdutoObrigatorio);
                }
                if ( _valueCliente == null)
                {
                    throw new Exception(ErroClienteObrigatorio);
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
                    "  public.pedido_item  " +
                    "WHERE " +
                    "  id_pedido_item = :id";
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
                        "  public.pedido_item   " +
                        "SET  " + 
                        "  pei_numero = :pei_numero, " + 
                        "  pei_posicao = :pei_posicao, " + 
                        "  pei_sub_linha = :pei_sub_linha, " + 
                        "  id_produto = :id_produto, " + 
                        "  pei_produto_codigo_cliente = :pei_produto_codigo_cliente, " + 
                        "  pei_produto_descricao_cliente = :pei_produto_descricao_cliente, " + 
                        "  pei_projeto_cliente = :pei_projeto_cliente, " + 
                        "  pei_quantidade = :pei_quantidade, " + 
                        "  pei_saldo = :pei_saldo, " + 
                        "  pei_preco_unitario = :pei_preco_unitario, " + 
                        "  pei_preco_total = :pei_preco_total, " + 
                        "  id_cliente = :id_cliente, " + 
                        "  pei_cnpj_cliente = :pei_cnpj_cliente, " + 
                        "  pei_armazenagem_cliente = :pei_armazenagem_cliente, " + 
                        "  pei_frete = :pei_frete, " + 
                        "  pei_data_entrega = :pei_data_entrega, " + 
                        "  pei_status = :pei_status, " + 
                        "  pei_data_entrada = :pei_data_entrada, " + 
                        "  id_operacao = :id_operacao, " + 
                        "  pei_permite_entrega_parcial = :pei_permite_entrega_parcial, " + 
                        "  pei_volume_unico = :pei_volume_unico, " + 
                        "  pei_configurado = :pei_configurado, " + 
                        "  pei_exportacao = :pei_exportacao, " + 
                        "  pei_preco_total_original = :pei_preco_total_original, " + 
                        "  id_acs_usuario_cancelamento = :id_acs_usuario_cancelamento, " + 
                        "  pei_data_cancelamento = :pei_data_cancelamento, " + 
                        "  pei_justificativa_cancelamento = :pei_justificativa_cancelamento, " + 
                        "  pei_data_configuracao = :pei_data_configuracao, " + 
                        "  pei_urgente = :pei_urgente, " + 
                        "  pei_urgente_solicitante = :pei_urgente_solicitante, " + 
                        "  pei_urgente_data_prometida = :pei_urgente_data_prometida, " + 
                        "  pei_urgente_informacoes_complementares = :pei_urgente_informacoes_complementares, " + 
                        "  pei_data_entrega_original = :pei_data_entrega_original, " + 
                        "  pei_informacao_especial = :pei_informacao_especial, " + 
                        "  pei_rastreamento_material = :pei_rastreamento_material, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  id_centro_custo_lucro = :id_centro_custo_lucro, " + 
                        "  id_forma_pagamento = :id_forma_pagamento, " + 
                        "  pei_numero_pedido_automatico = :pei_numero_pedido_automatico, " + 
                        "  pei_forma_frete = :pei_forma_frete, " + 
                        "  pei_responsavel_frete = :pei_responsavel_frete, " + 
                        "  pei_ordem_venda = :pei_ordem_venda, " + 
                        "  id_representante = :id_representante, " + 
                        "  pei_perc_comissao_representante = :pei_perc_comissao_representante, " + 
                        "  pei_data_encerramento = :pei_data_encerramento, " + 
                        "  pei_obs_padrao_espelho = :pei_obs_padrao_espelho, " + 
                        "  pei_data_ultima_alteracao = :pei_data_ultima_alteracao, " + 
                        "  pei_suspensao_obs = :pei_suspensao_obs, " + 
                        "  id_acs_usuario_responsavel_suspensao = :id_acs_usuario_responsavel_suspensao, " + 
                        "  id_vendedor = :id_vendedor, " + 
                        "  pei_perc_comissao_vendedor = :pei_perc_comissao_vendedor, " + 
                        "  id_pedido_item_pai = :id_pedido_item_pai, " + 
                        "  pei_comissao_gerada = :pei_comissao_gerada, " + 
                        "  pei_observacao_nf = :pei_observacao_nf, " + 
                        "  pei_faturamento_antecipado_realizado = :pei_faturamento_antecipado_realizado, " + 
                        "  id_nf_principal_faturamento_antecipado = :id_nf_principal_faturamento_antecipado, " + 
                        "  id_ncm = :id_ncm, " + 
                        "  pei_situacao_gad = :pei_situacao_gad, " + 
                        "  pei_situacao_gad_mensagem = :pei_situacao_gad_mensagem, " + 
                        "  id_programacao = :id_programacao, " + 
                        "  pei_emissor_nfe = :pei_emissor_nfe, " + 
                        "  id_operacao_completa = :id_operacao_completa, " + 
                        "  pei_gad_programado = :pei_gad_programado, " + 
                        "  pei_gad_programacao_nome = :pei_gad_programacao_nome, " + 
                        "  pei_gad_programacao_data = :pei_gad_programacao_data, " + 
                        "  id_tipo_pagamento = :id_tipo_pagamento, " + 
                        "  ped_envio_terceiros = :ped_envio_terceiros, " + 
                        "  id_cliente_envio_terceiros = :id_cliente_envio_terceiros, " + 
                        "  id_operacao_envio_terceiros = :id_operacao_envio_terceiros, " + 
                        "  id_operacao_completa_envio_terceiros = :id_operacao_completa_envio_terceiros, " + 
                        "  pei_desconto = :pei_desconto, " + 
                        "  id_pedido_classificacao = :id_pedido_classificacao, " + 
                        "  id_meio_pagamento = :id_meio_pagamento "+
                        "WHERE  " +
                        "  id_pedido_item = :id " +
                        "RETURNING id_pedido_item;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.pedido_item " +
                        "( " +
                        "  pei_numero , " + 
                        "  pei_posicao , " + 
                        "  pei_sub_linha , " + 
                        "  id_produto , " + 
                        "  pei_produto_codigo_cliente , " + 
                        "  pei_produto_descricao_cliente , " + 
                        "  pei_projeto_cliente , " + 
                        "  pei_quantidade , " + 
                        "  pei_saldo , " + 
                        "  pei_preco_unitario , " + 
                        "  pei_preco_total , " + 
                        "  id_cliente , " + 
                        "  pei_cnpj_cliente , " + 
                        "  pei_armazenagem_cliente , " + 
                        "  pei_frete , " + 
                        "  pei_data_entrega , " + 
                        "  pei_status , " + 
                        "  pei_data_entrada , " + 
                        "  id_operacao , " + 
                        "  pei_permite_entrega_parcial , " + 
                        "  pei_volume_unico , " + 
                        "  pei_configurado , " + 
                        "  pei_exportacao , " + 
                        "  pei_preco_total_original , " + 
                        "  id_acs_usuario_cancelamento , " + 
                        "  pei_data_cancelamento , " + 
                        "  pei_justificativa_cancelamento , " + 
                        "  pei_data_configuracao , " + 
                        "  pei_urgente , " + 
                        "  pei_urgente_solicitante , " + 
                        "  pei_urgente_data_prometida , " + 
                        "  pei_urgente_informacoes_complementares , " + 
                        "  pei_data_entrega_original , " + 
                        "  pei_informacao_especial , " + 
                        "  pei_rastreamento_material , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_conta_bancaria , " + 
                        "  id_centro_custo_lucro , " + 
                        "  id_forma_pagamento , " + 
                        "  pei_numero_pedido_automatico , " + 
                        "  pei_forma_frete , " + 
                        "  pei_responsavel_frete , " + 
                        "  pei_ordem_venda , " + 
                        "  id_representante , " + 
                        "  pei_perc_comissao_representante , " + 
                        "  pei_data_encerramento , " + 
                        "  pei_obs_padrao_espelho , " + 
                        "  pei_data_ultima_alteracao , " + 
                        "  pei_suspensao_obs , " + 
                        "  id_acs_usuario_responsavel_suspensao , " + 
                        "  id_vendedor , " + 
                        "  pei_perc_comissao_vendedor , " + 
                        "  id_pedido_item_pai , " + 
                        "  pei_comissao_gerada , " + 
                        "  pei_observacao_nf , " + 
                        "  pei_faturamento_antecipado_realizado , " + 
                        "  id_nf_principal_faturamento_antecipado , " + 
                        "  id_ncm , " + 
                        "  pei_situacao_gad , " + 
                        "  pei_situacao_gad_mensagem , " + 
                        "  id_programacao , " + 
                        "  pei_emissor_nfe , " + 
                        "  id_operacao_completa , " + 
                        "  pei_gad_programado , " + 
                        "  pei_gad_programacao_nome , " + 
                        "  pei_gad_programacao_data , " + 
                        "  id_tipo_pagamento , " + 
                        "  ped_envio_terceiros , " + 
                        "  id_cliente_envio_terceiros , " + 
                        "  id_operacao_envio_terceiros , " + 
                        "  id_operacao_completa_envio_terceiros , " + 
                        "  pei_desconto , " + 
                        "  id_pedido_classificacao , " + 
                        "  id_meio_pagamento  "+
                        ")  " +
                        "VALUES ( " +
                        "  :pei_numero , " + 
                        "  :pei_posicao , " + 
                        "  :pei_sub_linha , " + 
                        "  :id_produto , " + 
                        "  :pei_produto_codigo_cliente , " + 
                        "  :pei_produto_descricao_cliente , " + 
                        "  :pei_projeto_cliente , " + 
                        "  :pei_quantidade , " + 
                        "  :pei_saldo , " + 
                        "  :pei_preco_unitario , " + 
                        "  :pei_preco_total , " + 
                        "  :id_cliente , " + 
                        "  :pei_cnpj_cliente , " + 
                        "  :pei_armazenagem_cliente , " + 
                        "  :pei_frete , " + 
                        "  :pei_data_entrega , " + 
                        "  :pei_status , " + 
                        "  :pei_data_entrada , " + 
                        "  :id_operacao , " + 
                        "  :pei_permite_entrega_parcial , " + 
                        "  :pei_volume_unico , " + 
                        "  :pei_configurado , " + 
                        "  :pei_exportacao , " + 
                        "  :pei_preco_total_original , " + 
                        "  :id_acs_usuario_cancelamento , " + 
                        "  :pei_data_cancelamento , " + 
                        "  :pei_justificativa_cancelamento , " + 
                        "  :pei_data_configuracao , " + 
                        "  :pei_urgente , " + 
                        "  :pei_urgente_solicitante , " + 
                        "  :pei_urgente_data_prometida , " + 
                        "  :pei_urgente_informacoes_complementares , " + 
                        "  :pei_data_entrega_original , " + 
                        "  :pei_informacao_especial , " + 
                        "  :pei_rastreamento_material , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_conta_bancaria , " + 
                        "  :id_centro_custo_lucro , " + 
                        "  :id_forma_pagamento , " + 
                        "  :pei_numero_pedido_automatico , " + 
                        "  :pei_forma_frete , " + 
                        "  :pei_responsavel_frete , " + 
                        "  :pei_ordem_venda , " + 
                        "  :id_representante , " + 
                        "  :pei_perc_comissao_representante , " + 
                        "  :pei_data_encerramento , " + 
                        "  :pei_obs_padrao_espelho , " + 
                        "  :pei_data_ultima_alteracao , " + 
                        "  :pei_suspensao_obs , " + 
                        "  :id_acs_usuario_responsavel_suspensao , " + 
                        "  :id_vendedor , " + 
                        "  :pei_perc_comissao_vendedor , " + 
                        "  :id_pedido_item_pai , " + 
                        "  :pei_comissao_gerada , " + 
                        "  :pei_observacao_nf , " + 
                        "  :pei_faturamento_antecipado_realizado , " + 
                        "  :id_nf_principal_faturamento_antecipado , " + 
                        "  :id_ncm , " + 
                        "  :pei_situacao_gad , " + 
                        "  :pei_situacao_gad_mensagem , " + 
                        "  :id_programacao , " + 
                        "  :pei_emissor_nfe , " + 
                        "  :id_operacao_completa , " + 
                        "  :pei_gad_programado , " + 
                        "  :pei_gad_programacao_nome , " + 
                        "  :pei_gad_programacao_data , " + 
                        "  :id_tipo_pagamento , " + 
                        "  :ped_envio_terceiros , " + 
                        "  :id_cliente_envio_terceiros , " + 
                        "  :id_operacao_envio_terceiros , " + 
                        "  :id_operacao_completa_envio_terceiros , " + 
                        "  :pei_desconto , " + 
                        "  :id_pedido_classificacao , " + 
                        "  :id_meio_pagamento  "+
                        ")RETURNING id_pedido_item;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_posicao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Posicao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_sub_linha", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SubLinha ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_produto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Produto==null ? (object) DBNull.Value : this.Produto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_codigo_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoCodigoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_produto_descricao_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProdutoDescricaoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_projeto_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ProjetoCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_saldo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Saldo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Cliente==null ? (object) DBNull.Value : this.Cliente.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_cnpj_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_armazenagem_cliente", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ArmazenagemCliente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Frete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrega ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrada", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntrada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Operacao==null ? (object) DBNull.Value : this.Operacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_permite_entrega_parcial", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PermiteEntregaParcial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_volume_unico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VolumeUnico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_configurado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Configurado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_exportacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Exportacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_preco_total_original", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoTotalOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_configuracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataConfiguracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Urgente);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_solicitante", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UrgenteSolicitante ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_data_prometida", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UrgenteDataPrometida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_urgente_informacoes_complementares", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UrgenteInformacoesComplementares ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_entrega_original", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEntregaOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_informacao_especial", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InformacaoEspecial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_rastreamento_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RastreamentoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_centro_custo_lucro", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CentroCustoLucro==null ? (object) DBNull.Value : this.CentroCustoLucro.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FormaPagamento==null ? (object) DBNull.Value : this.FormaPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_numero_pedido_automatico", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroPedidoAutomatico ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_forma_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.FormaFrete);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_responsavel_frete", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.ResponsavelFrete.HasValue ? (object)Convert.ToInt16(this.ResponsavelFrete) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_ordem_venda", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrdemVenda ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_representante", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Representante==null ? (object) DBNull.Value : this.Representante.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_perc_comissao_representante", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoRepresentante ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_encerramento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEncerramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_obs_padrao_espelho", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObsPadraoEspelho ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_data_ultima_alteracao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataUltimaAlteracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_suspensao_obs", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SuspensaoObs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_responsavel_suspensao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioResponsavelSuspensao==null ? (object) DBNull.Value : this.AcsUsuarioResponsavelSuspensao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_vendedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Vendedor==null ? (object) DBNull.Value : this.Vendedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_perc_comissao_vendedor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercComissaoVendedor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_item_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoItemPai==null ? (object) DBNull.Value : this.PedidoItemPai.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_comissao_gerada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ComissaoGerada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_observacao_nf", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_faturamento_antecipado_realizado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FaturamentoAntecipadoRealizado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal_faturamento_antecipado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipalFaturamentoAntecipado==null ? (object) DBNull.Value : this.NfPrincipalFaturamentoAntecipado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Ncm==null ? (object) DBNull.Value : this.Ncm.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.SituacaoGad);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_situacao_gad_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SituacaoGadMensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_programacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Programacao==null ? (object) DBNull.Value : this.Programacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_emissor_nfe", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.EmissorNfe);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OperacaoCompleta==null ? (object) DBNull.Value : this.OperacaoCompleta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programado", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GadProgramado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programacao_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GadProgramacaoNome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_gad_programacao_data", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GadProgramacaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_tipo_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.TipoPagamento==null ? (object) DBNull.Value : this.TipoPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ped_envio_terceiros", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EnvioTerceiros ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cliente_envio_terceiros", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ClienteEnvioTerceiros==null ? (object) DBNull.Value : this.ClienteEnvioTerceiros.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_envio_terceiros", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OperacaoEnvioTerceiros==null ? (object) DBNull.Value : this.OperacaoEnvioTerceiros.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_operacao_completa_envio_terceiros", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OperacaoCompletaEnvioTerceiros==null ? (object) DBNull.Value : this.OperacaoCompletaEnvioTerceiros.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pei_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Desconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pedido_classificacao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.PedidoClassificacao==null ? (object) DBNull.Value : this.PedidoClassificacao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_meio_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.MeioPagamento==null ? (object) DBNull.Value : this.MeioPagamento.ID;

 
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
 if (CollectionAtendimentoClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAtendimentoClassPedidoItem+"\r\n";
                foreach (Entidades.AtendimentoClass tmp in CollectionAtendimentoClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionGadPedidosUploadClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionGadPedidosUploadClassPedidoItem+"\r\n";
                foreach (Entidades.GadPedidosUploadClass tmp in CollectionGadPedidosUploadClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionNotificacaoDesvioClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNotificacaoDesvioClassPedidoItem+"\r\n";
                foreach (Entidades.NotificacaoDesvioClass tmp in CollectionNotificacaoDesvioClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassPedidoItem+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido+"\r\n";
                foreach (Entidades.OrderItemEtiquetaClass tmp in CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoDocumentoClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoDocumentoClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoDocumentoClass tmp in CollectionPedidoDocumentoClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassPedidoItemPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassPedidoItemPai+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassPedidoItemPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemFeedbackClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemFeedbackClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemFeedbackClass tmp in CollectionPedidoItemFeedbackClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemFeedbackSecundarioClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemFeedbackSecundarioClass tmp in CollectionPedidoItemFeedbackSecundarioClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemHistoricoAlteracoesClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemHistoricoAlteracoesClass tmp in CollectionPedidoItemHistoricoAlteracoesClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemLoteClienteClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemLoteClienteClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemLoteClienteClass tmp in CollectionPedidoItemLoteClienteClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemQualidadeClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemQualidadeClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemQualidadeClass tmp in CollectionPedidoItemQualidadeClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemVariavelClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemVariavelClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemVariavelClass tmp in CollectionPedidoItemVariavelClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemVolumeClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemVolumeClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoItemVolumeClass tmp in CollectionPedidoItemVolumeClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoKitClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoKitClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoKitClass tmp in CollectionPedidoKitClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoVariavelClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoVariavelClassPedidoItem+"\r\n";
                foreach (Entidades.PedidoVariavelClass tmp in CollectionPedidoVariavelClassPedidoItem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraPedidoClassPedidoItem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraPedidoClassPedidoItem+"\r\n";
                foreach (Entidades.SolicitacaoCompraPedidoClass tmp in CollectionSolicitacaoCompraPedidoClassPedidoItem)
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
        public static PedidoItemClass CopiarEntidade(PedidoItemClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               PedidoItemClass toRet = new PedidoItemClass(usuario,conn);
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Posicao= entidadeCopiar.Posicao;
 toRet.SubLinha= entidadeCopiar.SubLinha;
 toRet.Produto= entidadeCopiar.Produto;
 toRet.ProdutoCodigoCliente= entidadeCopiar.ProdutoCodigoCliente;
 toRet.ProdutoDescricaoCliente= entidadeCopiar.ProdutoDescricaoCliente;
 toRet.ProjetoCliente= entidadeCopiar.ProjetoCliente;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Saldo= entidadeCopiar.Saldo;
 toRet.PrecoUnitario= entidadeCopiar.PrecoUnitario;
 toRet.PrecoTotal= entidadeCopiar.PrecoTotal;
 toRet.Cliente= entidadeCopiar.Cliente;
 toRet.CnpjCliente= entidadeCopiar.CnpjCliente;
 toRet.ArmazenagemCliente= entidadeCopiar.ArmazenagemCliente;
 toRet.Frete= entidadeCopiar.Frete;
 toRet.DataEntrega= entidadeCopiar.DataEntrega;
 toRet.Status= entidadeCopiar.Status;
 toRet.DataEntrada= entidadeCopiar.DataEntrada;
 toRet.Operacao= entidadeCopiar.Operacao;
 toRet.PermiteEntregaParcial= entidadeCopiar.PermiteEntregaParcial;
 toRet.VolumeUnico= entidadeCopiar.VolumeUnico;
 toRet.Configurado= entidadeCopiar.Configurado;
 toRet.Exportacao= entidadeCopiar.Exportacao;
 toRet.PrecoTotalOriginal= entidadeCopiar.PrecoTotalOriginal;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.JustificativaCancelamento= entidadeCopiar.JustificativaCancelamento;
 toRet.DataConfiguracao= entidadeCopiar.DataConfiguracao;
 toRet.Urgente= entidadeCopiar.Urgente;
 toRet.UrgenteSolicitante= entidadeCopiar.UrgenteSolicitante;
 toRet.UrgenteDataPrometida= entidadeCopiar.UrgenteDataPrometida;
 toRet.UrgenteInformacoesComplementares= entidadeCopiar.UrgenteInformacoesComplementares;
 toRet.DataEntregaOriginal= entidadeCopiar.DataEntregaOriginal;
 toRet.InformacaoEspecial= entidadeCopiar.InformacaoEspecial;
 toRet.RastreamentoMaterial= entidadeCopiar.RastreamentoMaterial;
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.CentroCustoLucro= entidadeCopiar.CentroCustoLucro;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.NumeroPedidoAutomatico= entidadeCopiar.NumeroPedidoAutomatico;
 toRet.FormaFrete= entidadeCopiar.FormaFrete;
 toRet.ResponsavelFrete= entidadeCopiar.ResponsavelFrete;
 toRet.OrdemVenda= entidadeCopiar.OrdemVenda;
 toRet.Representante= entidadeCopiar.Representante;
 toRet.PercComissaoRepresentante= entidadeCopiar.PercComissaoRepresentante;
 toRet.DataEncerramento= entidadeCopiar.DataEncerramento;
 toRet.ObsPadraoEspelho= entidadeCopiar.ObsPadraoEspelho;
 toRet.DataUltimaAlteracao= entidadeCopiar.DataUltimaAlteracao;
 toRet.SuspensaoObs= entidadeCopiar.SuspensaoObs;
 toRet.AcsUsuarioResponsavelSuspensao= entidadeCopiar.AcsUsuarioResponsavelSuspensao;
 toRet.Vendedor= entidadeCopiar.Vendedor;
 toRet.PercComissaoVendedor= entidadeCopiar.PercComissaoVendedor;
 toRet.PedidoItemPai= entidadeCopiar.PedidoItemPai;
 toRet.ComissaoGerada= entidadeCopiar.ComissaoGerada;
 toRet.ObservacaoNf= entidadeCopiar.ObservacaoNf;
 toRet.FaturamentoAntecipadoRealizado= entidadeCopiar.FaturamentoAntecipadoRealizado;
 toRet.NfPrincipalFaturamentoAntecipado= entidadeCopiar.NfPrincipalFaturamentoAntecipado;
 toRet.Ncm= entidadeCopiar.Ncm;
 toRet.SituacaoGad= entidadeCopiar.SituacaoGad;
 toRet.SituacaoGadMensagem= entidadeCopiar.SituacaoGadMensagem;
 toRet.Programacao= entidadeCopiar.Programacao;
 toRet.EmissorNfe= entidadeCopiar.EmissorNfe;
 toRet.OperacaoCompleta= entidadeCopiar.OperacaoCompleta;
 toRet.GadProgramado= entidadeCopiar.GadProgramado;
 toRet.GadProgramacaoNome= entidadeCopiar.GadProgramacaoNome;
 toRet.GadProgramacaoData= entidadeCopiar.GadProgramacaoData;
 toRet.TipoPagamento= entidadeCopiar.TipoPagamento;
 toRet.EnvioTerceiros= entidadeCopiar.EnvioTerceiros;
 toRet.ClienteEnvioTerceiros= entidadeCopiar.ClienteEnvioTerceiros;
 toRet.OperacaoEnvioTerceiros= entidadeCopiar.OperacaoEnvioTerceiros;
 toRet.OperacaoCompletaEnvioTerceiros= entidadeCopiar.OperacaoCompletaEnvioTerceiros;
 toRet.Desconto= entidadeCopiar.Desconto;
 toRet.PedidoClassificacao= entidadeCopiar.PedidoClassificacao;
 toRet.MeioPagamento= entidadeCopiar.MeioPagamento;

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
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _posicaoOriginal = Posicao;
       _posicaoOriginalCommited = _posicaoOriginal;
       _subLinhaOriginal = SubLinha;
       _subLinhaOriginalCommited = _subLinhaOriginal;
       _produtoOriginal = Produto;
       _produtoOriginalCommited = _produtoOriginal;
       _produtoCodigoClienteOriginal = ProdutoCodigoCliente;
       _produtoCodigoClienteOriginalCommited = _produtoCodigoClienteOriginal;
       _produtoDescricaoClienteOriginal = ProdutoDescricaoCliente;
       _produtoDescricaoClienteOriginalCommited = _produtoDescricaoClienteOriginal;
       _projetoClienteOriginal = ProjetoCliente;
       _projetoClienteOriginalCommited = _projetoClienteOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _saldoOriginal = Saldo;
       _saldoOriginalCommited = _saldoOriginal;
       _precoUnitarioOriginal = PrecoUnitario;
       _precoUnitarioOriginalCommited = _precoUnitarioOriginal;
       _precoTotalOriginal = PrecoTotal;
       _precoTotalOriginalCommited = _precoTotalOriginal;
       _clienteOriginal = Cliente;
       _clienteOriginalCommited = _clienteOriginal;
       _cnpjClienteOriginal = CnpjCliente;
       _cnpjClienteOriginalCommited = _cnpjClienteOriginal;
       _armazenagemClienteOriginal = ArmazenagemCliente;
       _armazenagemClienteOriginalCommited = _armazenagemClienteOriginal;
       _freteOriginal = Frete;
       _freteOriginalCommited = _freteOriginal;
       _dataEntregaOriginal = DataEntrega;
       _dataEntregaOriginalCommited = _dataEntregaOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _dataEntradaOriginal = DataEntrada;
       _dataEntradaOriginalCommited = _dataEntradaOriginal;
       _operacaoOriginal = Operacao;
       _operacaoOriginalCommited = _operacaoOriginal;
       _permiteEntregaParcialOriginal = PermiteEntregaParcial;
       _permiteEntregaParcialOriginalCommited = _permiteEntregaParcialOriginal;
       _volumeUnicoOriginal = VolumeUnico;
       _volumeUnicoOriginalCommited = _volumeUnicoOriginal;
       _configuradoOriginal = Configurado;
       _configuradoOriginalCommited = _configuradoOriginal;
       _exportacaoOriginal = Exportacao;
       _exportacaoOriginalCommited = _exportacaoOriginal;
       _precoTotalOriginalOriginal = PrecoTotalOriginal;
       _precoTotalOriginalOriginalCommited = _precoTotalOriginalOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _justificativaCancelamentoOriginal = JustificativaCancelamento;
       _justificativaCancelamentoOriginalCommited = _justificativaCancelamentoOriginal;
       _dataConfiguracaoOriginal = DataConfiguracao;
       _dataConfiguracaoOriginalCommited = _dataConfiguracaoOriginal;
       _urgenteOriginal = Urgente;
       _urgenteOriginalCommited = _urgenteOriginal;
       _urgenteSolicitanteOriginal = UrgenteSolicitante;
       _urgenteSolicitanteOriginalCommited = _urgenteSolicitanteOriginal;
       _urgenteDataPrometidaOriginal = UrgenteDataPrometida;
       _urgenteDataPrometidaOriginalCommited = _urgenteDataPrometidaOriginal;
       _urgenteInformacoesComplementaresOriginal = UrgenteInformacoesComplementares;
       _urgenteInformacoesComplementaresOriginalCommited = _urgenteInformacoesComplementaresOriginal;
       _dataEntregaOriginalOriginal = DataEntregaOriginal;
       _dataEntregaOriginalOriginalCommited = _dataEntregaOriginalOriginal;
       _informacaoEspecialOriginal = InformacaoEspecial;
       _informacaoEspecialOriginalCommited = _informacaoEspecialOriginal;
       _rastreamentoMaterialOriginal = RastreamentoMaterial;
       _rastreamentoMaterialOriginalCommited = _rastreamentoMaterialOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _centroCustoLucroOriginal = CentroCustoLucro;
       _centroCustoLucroOriginalCommited = _centroCustoLucroOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _numeroPedidoAutomaticoOriginal = NumeroPedidoAutomatico;
       _numeroPedidoAutomaticoOriginalCommited = _numeroPedidoAutomaticoOriginal;
       _formaFreteOriginal = FormaFrete;
       _formaFreteOriginalCommited = _formaFreteOriginal;
       _responsavelFreteOriginal = ResponsavelFrete;
       _responsavelFreteOriginalCommited = _responsavelFreteOriginal;
       _ordemVendaOriginal = OrdemVenda;
       _ordemVendaOriginalCommited = _ordemVendaOriginal;
       _representanteOriginal = Representante;
       _representanteOriginalCommited = _representanteOriginal;
       _percComissaoRepresentanteOriginal = PercComissaoRepresentante;
       _percComissaoRepresentanteOriginalCommited = _percComissaoRepresentanteOriginal;
       _dataEncerramentoOriginal = DataEncerramento;
       _dataEncerramentoOriginalCommited = _dataEncerramentoOriginal;
       _obsPadraoEspelhoOriginal = ObsPadraoEspelho;
       _obsPadraoEspelhoOriginalCommited = _obsPadraoEspelhoOriginal;
       _dataUltimaAlteracaoOriginal = DataUltimaAlteracao;
       _dataUltimaAlteracaoOriginalCommited = _dataUltimaAlteracaoOriginal;
       _suspensaoObsOriginal = SuspensaoObs;
       _suspensaoObsOriginalCommited = _suspensaoObsOriginal;
       _acsUsuarioResponsavelSuspensaoOriginal = AcsUsuarioResponsavelSuspensao;
       _acsUsuarioResponsavelSuspensaoOriginalCommited = _acsUsuarioResponsavelSuspensaoOriginal;
       _vendedorOriginal = Vendedor;
       _vendedorOriginalCommited = _vendedorOriginal;
       _percComissaoVendedorOriginal = PercComissaoVendedor;
       _percComissaoVendedorOriginalCommited = _percComissaoVendedorOriginal;
       _pedidoItemPaiOriginal = PedidoItemPai;
       _pedidoItemPaiOriginalCommited = _pedidoItemPaiOriginal;
       _comissaoGeradaOriginal = ComissaoGerada;
       _comissaoGeradaOriginalCommited = _comissaoGeradaOriginal;
       _observacaoNfOriginal = ObservacaoNf;
       _observacaoNfOriginalCommited = _observacaoNfOriginal;
       _faturamentoAntecipadoRealizadoOriginal = FaturamentoAntecipadoRealizado;
       _faturamentoAntecipadoRealizadoOriginalCommited = _faturamentoAntecipadoRealizadoOriginal;
       _nfPrincipalFaturamentoAntecipadoOriginal = NfPrincipalFaturamentoAntecipado;
       _nfPrincipalFaturamentoAntecipadoOriginalCommited = _nfPrincipalFaturamentoAntecipadoOriginal;
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;
       _situacaoGadOriginal = SituacaoGad;
       _situacaoGadOriginalCommited = _situacaoGadOriginal;
       _situacaoGadMensagemOriginal = SituacaoGadMensagem;
       _situacaoGadMensagemOriginalCommited = _situacaoGadMensagemOriginal;
       _programacaoOriginal = Programacao;
       _programacaoOriginalCommited = _programacaoOriginal;
       _emissorNfeOriginal = EmissorNfe;
       _emissorNfeOriginalCommited = _emissorNfeOriginal;
       _operacaoCompletaOriginal = OperacaoCompleta;
       _operacaoCompletaOriginalCommited = _operacaoCompletaOriginal;
       _gadProgramadoOriginal = GadProgramado;
       _gadProgramadoOriginalCommited = _gadProgramadoOriginal;
       _gadProgramacaoNomeOriginal = GadProgramacaoNome;
       _gadProgramacaoNomeOriginalCommited = _gadProgramacaoNomeOriginal;
       _gadProgramacaoDataOriginal = GadProgramacaoData;
       _gadProgramacaoDataOriginalCommited = _gadProgramacaoDataOriginal;
       _tipoPagamentoOriginal = TipoPagamento;
       _tipoPagamentoOriginalCommited = _tipoPagamentoOriginal;
       _envioTerceirosOriginal = EnvioTerceiros;
       _envioTerceirosOriginalCommited = _envioTerceirosOriginal;
       _clienteEnvioTerceirosOriginal = ClienteEnvioTerceiros;
       _clienteEnvioTerceirosOriginalCommited = _clienteEnvioTerceirosOriginal;
       _operacaoEnvioTerceirosOriginal = OperacaoEnvioTerceiros;
       _operacaoEnvioTerceirosOriginalCommited = _operacaoEnvioTerceirosOriginal;
       _operacaoCompletaEnvioTerceirosOriginal = OperacaoCompletaEnvioTerceiros;
       _operacaoCompletaEnvioTerceirosOriginalCommited = _operacaoCompletaEnvioTerceirosOriginal;
       _descontoOriginal = Desconto;
       _descontoOriginalCommited = _descontoOriginal;
       _pedidoClassificacaoOriginal = PedidoClassificacao;
       _pedidoClassificacaoOriginalCommited = _pedidoClassificacaoOriginal;
       _meioPagamentoOriginal = MeioPagamento;
       _meioPagamentoOriginalCommited = _meioPagamentoOriginal;

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
       _numeroOriginalCommited = Numero;
       _posicaoOriginalCommited = Posicao;
       _subLinhaOriginalCommited = SubLinha;
       _produtoOriginalCommited = Produto;
       _produtoCodigoClienteOriginalCommited = ProdutoCodigoCliente;
       _produtoDescricaoClienteOriginalCommited = ProdutoDescricaoCliente;
       _projetoClienteOriginalCommited = ProjetoCliente;
       _quantidadeOriginalCommited = Quantidade;
       _saldoOriginalCommited = Saldo;
       _precoUnitarioOriginalCommited = PrecoUnitario;
       _precoTotalOriginalCommited = PrecoTotal;
       _clienteOriginalCommited = Cliente;
       _cnpjClienteOriginalCommited = CnpjCliente;
       _armazenagemClienteOriginalCommited = ArmazenagemCliente;
       _freteOriginalCommited = Frete;
       _dataEntregaOriginalCommited = DataEntrega;
       _statusOriginalCommited = Status;
       _dataEntradaOriginalCommited = DataEntrada;
       _operacaoOriginalCommited = Operacao;
       _permiteEntregaParcialOriginalCommited = PermiteEntregaParcial;
       _volumeUnicoOriginalCommited = VolumeUnico;
       _configuradoOriginalCommited = Configurado;
       _exportacaoOriginalCommited = Exportacao;
       _precoTotalOriginalOriginalCommited = PrecoTotalOriginal;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _justificativaCancelamentoOriginalCommited = JustificativaCancelamento;
       _dataConfiguracaoOriginalCommited = DataConfiguracao;
       _urgenteOriginalCommited = Urgente;
       _urgenteSolicitanteOriginalCommited = UrgenteSolicitante;
       _urgenteDataPrometidaOriginalCommited = UrgenteDataPrometida;
       _urgenteInformacoesComplementaresOriginalCommited = UrgenteInformacoesComplementares;
       _dataEntregaOriginalOriginalCommited = DataEntregaOriginal;
       _informacaoEspecialOriginalCommited = InformacaoEspecial;
       _rastreamentoMaterialOriginalCommited = RastreamentoMaterial;
       _versionOriginalCommited = Version;
       _contaBancariaOriginalCommited = ContaBancaria;
       _centroCustoLucroOriginalCommited = CentroCustoLucro;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _numeroPedidoAutomaticoOriginalCommited = NumeroPedidoAutomatico;
       _formaFreteOriginalCommited = FormaFrete;
       _responsavelFreteOriginalCommited = ResponsavelFrete;
       _ordemVendaOriginalCommited = OrdemVenda;
       _representanteOriginalCommited = Representante;
       _percComissaoRepresentanteOriginalCommited = PercComissaoRepresentante;
       _dataEncerramentoOriginalCommited = DataEncerramento;
       _obsPadraoEspelhoOriginalCommited = ObsPadraoEspelho;
       _dataUltimaAlteracaoOriginalCommited = DataUltimaAlteracao;
       _suspensaoObsOriginalCommited = SuspensaoObs;
       _acsUsuarioResponsavelSuspensaoOriginalCommited = AcsUsuarioResponsavelSuspensao;
       _vendedorOriginalCommited = Vendedor;
       _percComissaoVendedorOriginalCommited = PercComissaoVendedor;
       _pedidoItemPaiOriginalCommited = PedidoItemPai;
       _comissaoGeradaOriginalCommited = ComissaoGerada;
       _observacaoNfOriginalCommited = ObservacaoNf;
       _faturamentoAntecipadoRealizadoOriginalCommited = FaturamentoAntecipadoRealizado;
       _nfPrincipalFaturamentoAntecipadoOriginalCommited = NfPrincipalFaturamentoAntecipado;
       _ncmOriginalCommited = Ncm;
       _situacaoGadOriginalCommited = SituacaoGad;
       _situacaoGadMensagemOriginalCommited = SituacaoGadMensagem;
       _programacaoOriginalCommited = Programacao;
       _emissorNfeOriginalCommited = EmissorNfe;
       _operacaoCompletaOriginalCommited = OperacaoCompleta;
       _gadProgramadoOriginalCommited = GadProgramado;
       _gadProgramacaoNomeOriginalCommited = GadProgramacaoNome;
       _gadProgramacaoDataOriginalCommited = GadProgramacaoData;
       _tipoPagamentoOriginalCommited = TipoPagamento;
       _envioTerceirosOriginalCommited = EnvioTerceiros;
       _clienteEnvioTerceirosOriginalCommited = ClienteEnvioTerceiros;
       _operacaoEnvioTerceirosOriginalCommited = OperacaoEnvioTerceiros;
       _operacaoCompletaEnvioTerceirosOriginalCommited = OperacaoCompletaEnvioTerceiros;
       _descontoOriginalCommited = Desconto;
       _pedidoClassificacaoOriginalCommited = PedidoClassificacao;
       _meioPagamentoOriginalCommited = MeioPagamento;

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
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  if (_collectionAtendimentoClassPedidoItemRemovidos != null) 
                  {
                     _collectionAtendimentoClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAtendimentoClassPedidoItemRemovidos = new List<Entidades.AtendimentoClass>();
                  }
                  _collectionAtendimentoClassPedidoItemOriginal= (from a in _valueCollectionAtendimentoClassPedidoItem select a.ID).ToList();
                  _valueCollectionAtendimentoClassPedidoItemChanged = false;
                  _valueCollectionAtendimentoClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  if (_collectionGadPedidosUploadClassPedidoItemRemovidos != null) 
                  {
                     _collectionGadPedidosUploadClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionGadPedidosUploadClassPedidoItemRemovidos = new List<Entidades.GadPedidosUploadClass>();
                  }
                  _collectionGadPedidosUploadClassPedidoItemOriginal= (from a in _valueCollectionGadPedidosUploadClassPedidoItem select a.ID).ToList();
                  _valueCollectionGadPedidosUploadClassPedidoItemChanged = false;
                  _valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  if (_collectionNotificacaoDesvioClassPedidoItemRemovidos != null) 
                  {
                     _collectionNotificacaoDesvioClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNotificacaoDesvioClassPedidoItemRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                  }
                  _collectionNotificacaoDesvioClassPedidoItemOriginal= (from a in _valueCollectionNotificacaoDesvioClassPedidoItem select a.ID).ToList();
                  _valueCollectionNotificacaoDesvioClassPedidoItemChanged = false;
                  _valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassPedidoItemRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassPedidoItemRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassPedidoItemOriginal= (from a in _valueCollectionOrderItemEtiquetaClassPedidoItem select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassPedidoItemChanged = false;
                  _valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  if (_collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos = new List<Entidades.OrderItemEtiquetaClass>();
                  }
                  _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoOriginal= (from a in _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged = false;
                  _valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged = false;
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoDocumentoClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoDocumentoClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoDocumentoClassPedidoItemRemovidos = new List<Entidades.PedidoDocumentoClass>();
                  }
                  _collectionPedidoDocumentoClassPedidoItemOriginal= (from a in _valueCollectionPedidoDocumentoClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoDocumentoClassPedidoItemChanged = false;
                  _valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  if (_collectionPedidoItemClassPedidoItemPaiRemovidos != null) 
                  {
                     _collectionPedidoItemClassPedidoItemPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassPedidoItemPaiRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassPedidoItemPaiOriginal= (from a in _valueCollectionPedidoItemClassPedidoItemPai select a.ID).ToList();
                  _valueCollectionPedidoItemClassPedidoItemPaiChanged = false;
                  _valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemFeedbackClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemFeedbackClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemFeedbackClassPedidoItemRemovidos = new List<Entidades.PedidoItemFeedbackClass>();
                  }
                  _collectionPedidoItemFeedbackClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemFeedbackClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemFeedbackClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos = new List<Entidades.PedidoItemFeedbackSecundarioClass>();
                  }
                  _collectionPedidoItemFeedbackSecundarioClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos = new List<Entidades.PedidoItemHistoricoAlteracoesClass>();
                  }
                  _collectionPedidoItemHistoricoAlteracoesClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemLoteClienteClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemLoteClienteClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemLoteClienteClassPedidoItemRemovidos = new List<Entidades.PedidoItemLoteClienteClass>();
                  }
                  _collectionPedidoItemLoteClienteClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemLoteClienteClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemQualidadeClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemQualidadeClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemQualidadeClassPedidoItemRemovidos = new List<Entidades.PedidoItemQualidadeClass>();
                  }
                  _collectionPedidoItemQualidadeClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemQualidadeClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemQualidadeClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemVariavelClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemVariavelClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemVariavelClassPedidoItemRemovidos = new List<Entidades.PedidoItemVariavelClass>();
                  }
                  _collectionPedidoItemVariavelClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemVariavelClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemVariavelClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoItemVolumeClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoItemVolumeClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemVolumeClassPedidoItemRemovidos = new List<Entidades.PedidoItemVolumeClass>();
                  }
                  _collectionPedidoItemVolumeClassPedidoItemOriginal= (from a in _valueCollectionPedidoItemVolumeClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoItemVolumeClassPedidoItemChanged = false;
                  _valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoKitClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoKitClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoKitClassPedidoItemRemovidos = new List<Entidades.PedidoKitClass>();
                  }
                  _collectionPedidoKitClassPedidoItemOriginal= (from a in _valueCollectionPedidoKitClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoKitClassPedidoItemChanged = false;
                  _valueCollectionPedidoKitClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  if (_collectionPedidoVariavelClassPedidoItemRemovidos != null) 
                  {
                     _collectionPedidoVariavelClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoVariavelClassPedidoItemRemovidos = new List<Entidades.PedidoVariavelClass>();
                  }
                  _collectionPedidoVariavelClassPedidoItemOriginal= (from a in _valueCollectionPedidoVariavelClassPedidoItem select a.ID).ToList();
                  _valueCollectionPedidoVariavelClassPedidoItemChanged = false;
                  _valueCollectionPedidoVariavelClassPedidoItemCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  if (_collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos = new List<Entidades.SolicitacaoCompraPedidoClass>();
                  }
                  _collectionSolicitacaoCompraPedidoClassPedidoItemOriginal= (from a in _valueCollectionSolicitacaoCompraPedidoClassPedidoItem select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged = false;
                  _valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged = false;
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
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Posicao=_posicaoOriginal;
               _posicaoOriginalCommited=_posicaoOriginal;
               SubLinha=_subLinhaOriginal;
               _subLinhaOriginalCommited=_subLinhaOriginal;
               Produto=_produtoOriginal;
               _produtoOriginalCommited=_produtoOriginal;
               ProdutoCodigoCliente=_produtoCodigoClienteOriginal;
               _produtoCodigoClienteOriginalCommited=_produtoCodigoClienteOriginal;
               ProdutoDescricaoCliente=_produtoDescricaoClienteOriginal;
               _produtoDescricaoClienteOriginalCommited=_produtoDescricaoClienteOriginal;
               ProjetoCliente=_projetoClienteOriginal;
               _projetoClienteOriginalCommited=_projetoClienteOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Saldo=_saldoOriginal;
               _saldoOriginalCommited=_saldoOriginal;
               PrecoUnitario=_precoUnitarioOriginal;
               _precoUnitarioOriginalCommited=_precoUnitarioOriginal;
               PrecoTotal=_precoTotalOriginal;
               _precoTotalOriginalCommited=_precoTotalOriginal;
               Cliente=_clienteOriginal;
               _clienteOriginalCommited=_clienteOriginal;
               CnpjCliente=_cnpjClienteOriginal;
               _cnpjClienteOriginalCommited=_cnpjClienteOriginal;
               ArmazenagemCliente=_armazenagemClienteOriginal;
               _armazenagemClienteOriginalCommited=_armazenagemClienteOriginal;
               Frete=_freteOriginal;
               _freteOriginalCommited=_freteOriginal;
               DataEntrega=_dataEntregaOriginal;
               _dataEntregaOriginalCommited=_dataEntregaOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               DataEntrada=_dataEntradaOriginal;
               _dataEntradaOriginalCommited=_dataEntradaOriginal;
               Operacao=_operacaoOriginal;
               _operacaoOriginalCommited=_operacaoOriginal;
               PermiteEntregaParcial=_permiteEntregaParcialOriginal;
               _permiteEntregaParcialOriginalCommited=_permiteEntregaParcialOriginal;
               VolumeUnico=_volumeUnicoOriginal;
               _volumeUnicoOriginalCommited=_volumeUnicoOriginal;
               Configurado=_configuradoOriginal;
               _configuradoOriginalCommited=_configuradoOriginal;
               Exportacao=_exportacaoOriginal;
               _exportacaoOriginalCommited=_exportacaoOriginal;
               PrecoTotalOriginal=_precoTotalOriginalOriginal;
               _precoTotalOriginalOriginalCommited=_precoTotalOriginalOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               JustificativaCancelamento=_justificativaCancelamentoOriginal;
               _justificativaCancelamentoOriginalCommited=_justificativaCancelamentoOriginal;
               DataConfiguracao=_dataConfiguracaoOriginal;
               _dataConfiguracaoOriginalCommited=_dataConfiguracaoOriginal;
               Urgente=_urgenteOriginal;
               _urgenteOriginalCommited=_urgenteOriginal;
               UrgenteSolicitante=_urgenteSolicitanteOriginal;
               _urgenteSolicitanteOriginalCommited=_urgenteSolicitanteOriginal;
               UrgenteDataPrometida=_urgenteDataPrometidaOriginal;
               _urgenteDataPrometidaOriginalCommited=_urgenteDataPrometidaOriginal;
               UrgenteInformacoesComplementares=_urgenteInformacoesComplementaresOriginal;
               _urgenteInformacoesComplementaresOriginalCommited=_urgenteInformacoesComplementaresOriginal;
               DataEntregaOriginal=_dataEntregaOriginalOriginal;
               _dataEntregaOriginalOriginalCommited=_dataEntregaOriginalOriginal;
               InformacaoEspecial=_informacaoEspecialOriginal;
               _informacaoEspecialOriginalCommited=_informacaoEspecialOriginal;
               RastreamentoMaterial=_rastreamentoMaterialOriginal;
               _rastreamentoMaterialOriginalCommited=_rastreamentoMaterialOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               CentroCustoLucro=_centroCustoLucroOriginal;
               _centroCustoLucroOriginalCommited=_centroCustoLucroOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               NumeroPedidoAutomatico=_numeroPedidoAutomaticoOriginal;
               _numeroPedidoAutomaticoOriginalCommited=_numeroPedidoAutomaticoOriginal;
               FormaFrete=_formaFreteOriginal;
               _formaFreteOriginalCommited=_formaFreteOriginal;
               ResponsavelFrete=_responsavelFreteOriginal;
               _responsavelFreteOriginalCommited=_responsavelFreteOriginal;
               OrdemVenda=_ordemVendaOriginal;
               _ordemVendaOriginalCommited=_ordemVendaOriginal;
               Representante=_representanteOriginal;
               _representanteOriginalCommited=_representanteOriginal;
               PercComissaoRepresentante=_percComissaoRepresentanteOriginal;
               _percComissaoRepresentanteOriginalCommited=_percComissaoRepresentanteOriginal;
               DataEncerramento=_dataEncerramentoOriginal;
               _dataEncerramentoOriginalCommited=_dataEncerramentoOriginal;
               ObsPadraoEspelho=_obsPadraoEspelhoOriginal;
               _obsPadraoEspelhoOriginalCommited=_obsPadraoEspelhoOriginal;
               DataUltimaAlteracao=_dataUltimaAlteracaoOriginal;
               _dataUltimaAlteracaoOriginalCommited=_dataUltimaAlteracaoOriginal;
               SuspensaoObs=_suspensaoObsOriginal;
               _suspensaoObsOriginalCommited=_suspensaoObsOriginal;
               AcsUsuarioResponsavelSuspensao=_acsUsuarioResponsavelSuspensaoOriginal;
               _acsUsuarioResponsavelSuspensaoOriginalCommited=_acsUsuarioResponsavelSuspensaoOriginal;
               Vendedor=_vendedorOriginal;
               _vendedorOriginalCommited=_vendedorOriginal;
               PercComissaoVendedor=_percComissaoVendedorOriginal;
               _percComissaoVendedorOriginalCommited=_percComissaoVendedorOriginal;
               PedidoItemPai=_pedidoItemPaiOriginal;
               _pedidoItemPaiOriginalCommited=_pedidoItemPaiOriginal;
               ComissaoGerada=_comissaoGeradaOriginal;
               _comissaoGeradaOriginalCommited=_comissaoGeradaOriginal;
               ObservacaoNf=_observacaoNfOriginal;
               _observacaoNfOriginalCommited=_observacaoNfOriginal;
               FaturamentoAntecipadoRealizado=_faturamentoAntecipadoRealizadoOriginal;
               _faturamentoAntecipadoRealizadoOriginalCommited=_faturamentoAntecipadoRealizadoOriginal;
               NfPrincipalFaturamentoAntecipado=_nfPrincipalFaturamentoAntecipadoOriginal;
               _nfPrincipalFaturamentoAntecipadoOriginalCommited=_nfPrincipalFaturamentoAntecipadoOriginal;
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
               SituacaoGad=_situacaoGadOriginal;
               _situacaoGadOriginalCommited=_situacaoGadOriginal;
               SituacaoGadMensagem=_situacaoGadMensagemOriginal;
               _situacaoGadMensagemOriginalCommited=_situacaoGadMensagemOriginal;
               Programacao=_programacaoOriginal;
               _programacaoOriginalCommited=_programacaoOriginal;
               EmissorNfe=_emissorNfeOriginal;
               _emissorNfeOriginalCommited=_emissorNfeOriginal;
               OperacaoCompleta=_operacaoCompletaOriginal;
               _operacaoCompletaOriginalCommited=_operacaoCompletaOriginal;
               GadProgramado=_gadProgramadoOriginal;
               _gadProgramadoOriginalCommited=_gadProgramadoOriginal;
               GadProgramacaoNome=_gadProgramacaoNomeOriginal;
               _gadProgramacaoNomeOriginalCommited=_gadProgramacaoNomeOriginal;
               GadProgramacaoData=_gadProgramacaoDataOriginal;
               _gadProgramacaoDataOriginalCommited=_gadProgramacaoDataOriginal;
               TipoPagamento=_tipoPagamentoOriginal;
               _tipoPagamentoOriginalCommited=_tipoPagamentoOriginal;
               EnvioTerceiros=_envioTerceirosOriginal;
               _envioTerceirosOriginalCommited=_envioTerceirosOriginal;
               ClienteEnvioTerceiros=_clienteEnvioTerceirosOriginal;
               _clienteEnvioTerceirosOriginalCommited=_clienteEnvioTerceirosOriginal;
               OperacaoEnvioTerceiros=_operacaoEnvioTerceirosOriginal;
               _operacaoEnvioTerceirosOriginalCommited=_operacaoEnvioTerceirosOriginal;
               OperacaoCompletaEnvioTerceiros=_operacaoCompletaEnvioTerceirosOriginal;
               _operacaoCompletaEnvioTerceirosOriginalCommited=_operacaoCompletaEnvioTerceirosOriginal;
               Desconto=_descontoOriginal;
               _descontoOriginalCommited=_descontoOriginal;
               PedidoClassificacao=_pedidoClassificacaoOriginal;
               _pedidoClassificacaoOriginalCommited=_pedidoClassificacaoOriginal;
               MeioPagamento=_meioPagamentoOriginal;
               _meioPagamentoOriginalCommited=_meioPagamentoOriginal;
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  CollectionAtendimentoClassPedidoItem.Clear();
                  foreach(int item in _collectionAtendimentoClassPedidoItemOriginal)
                  {
                    CollectionAtendimentoClassPedidoItem.Add(Entidades.AtendimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAtendimentoClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  CollectionGadPedidosUploadClassPedidoItem.Clear();
                  foreach(int item in _collectionGadPedidosUploadClassPedidoItemOriginal)
                  {
                    CollectionGadPedidosUploadClassPedidoItem.Add(Entidades.GadPedidosUploadClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionGadPedidosUploadClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  CollectionNotificacaoDesvioClassPedidoItem.Clear();
                  foreach(int item in _collectionNotificacaoDesvioClassPedidoItemOriginal)
                  {
                    CollectionNotificacaoDesvioClassPedidoItem.Add(Entidades.NotificacaoDesvioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNotificacaoDesvioClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  CollectionOrderItemEtiquetaClassPedidoItem.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassPedidoItemOriginal)
                  {
                    CollectionOrderItemEtiquetaClassPedidoItem.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoOriginal)
                  {
                    CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido.Add(Entidades.OrderItemEtiquetaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoRemovidos.Clear();
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  CollectionPedidoDocumentoClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoDocumentoClassPedidoItemOriginal)
                  {
                    CollectionPedidoDocumentoClassPedidoItem.Add(Entidades.PedidoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoDocumentoClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  CollectionPedidoItemClassPedidoItemPai.Clear();
                  foreach(int item in _collectionPedidoItemClassPedidoItemPaiOriginal)
                  {
                    CollectionPedidoItemClassPedidoItemPai.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassPedidoItemPaiRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemFeedbackClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemFeedbackClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemFeedbackClassPedidoItem.Add(Entidades.PedidoItemFeedbackClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemFeedbackClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemFeedbackSecundarioClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Add(Entidades.PedidoItemFeedbackSecundarioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemFeedbackSecundarioClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemHistoricoAlteracoesClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Add(Entidades.PedidoItemHistoricoAlteracoesClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemHistoricoAlteracoesClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemLoteClienteClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemLoteClienteClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemLoteClienteClassPedidoItem.Add(Entidades.PedidoItemLoteClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemLoteClienteClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemQualidadeClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemQualidadeClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemQualidadeClassPedidoItem.Add(Entidades.PedidoItemQualidadeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemQualidadeClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemVariavelClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemVariavelClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemVariavelClassPedidoItem.Add(Entidades.PedidoItemVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemVariavelClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  CollectionPedidoItemVolumeClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoItemVolumeClassPedidoItemOriginal)
                  {
                    CollectionPedidoItemVolumeClassPedidoItem.Add(Entidades.PedidoItemVolumeClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemVolumeClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  CollectionPedidoKitClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoKitClassPedidoItemOriginal)
                  {
                    CollectionPedidoKitClassPedidoItem.Add(Entidades.PedidoKitClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoKitClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  CollectionPedidoVariavelClassPedidoItem.Clear();
                  foreach(int item in _collectionPedidoVariavelClassPedidoItemOriginal)
                  {
                    CollectionPedidoVariavelClassPedidoItem.Add(Entidades.PedidoVariavelClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoVariavelClassPedidoItemRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  CollectionSolicitacaoCompraPedidoClassPedidoItem.Clear();
                  foreach(int item in _collectionSolicitacaoCompraPedidoClassPedidoItemOriginal)
                  {
                    CollectionSolicitacaoCompraPedidoClassPedidoItem.Add(Entidades.SolicitacaoCompraPedidoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraPedidoClassPedidoItemRemovidos.Clear();
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
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionAtendimentoClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  if (_valueCollectionGadPedidosUploadClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoDocumentoClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  if (_valueCollectionPedidoItemClassPedidoItemPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemFeedbackClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemLoteClienteClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemQualidadeClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemVariavelClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemVolumeClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoKitClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoVariavelClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionAtendimentoClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                   tempRet = CollectionGadPedidosUploadClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoDocumentoClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                   tempRet = CollectionPedidoItemClassPedidoItemPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemFeedbackClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemLoteClienteClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemQualidadeClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemVariavelClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemVolumeClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoKitClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoVariavelClassPedidoItem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraPedidoClassPedidoItem.Any(item => item.IsDirty());
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
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _posicaoOriginal != Posicao;
      if (dirty) return true;
       dirty = _subLinhaOriginal != SubLinha;
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
       dirty = _produtoCodigoClienteOriginal != ProdutoCodigoCliente;
      if (dirty) return true;
       dirty = _produtoDescricaoClienteOriginal != ProdutoDescricaoCliente;
      if (dirty) return true;
       dirty = _projetoClienteOriginal != ProjetoCliente;
      if (dirty) return true;
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _saldoOriginal != Saldo;
      if (dirty) return true;
       dirty = _precoUnitarioOriginal != PrecoUnitario;
      if (dirty) return true;
       dirty = _precoTotalOriginal != PrecoTotal;
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
       dirty = _cnpjClienteOriginal != CnpjCliente;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginal != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _freteOriginal != Frete;
      if (dirty) return true;
       dirty = _dataEntregaOriginal != DataEntrega;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _dataEntradaOriginal != DataEntrada;
      if (dirty) return true;
       if (_operacaoOriginal!=null)
       {
          dirty = !_operacaoOriginal.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       dirty = _permiteEntregaParcialOriginal != PermiteEntregaParcial;
      if (dirty) return true;
       dirty = _volumeUnicoOriginal != VolumeUnico;
      if (dirty) return true;
       dirty = _configuradoOriginal != Configurado;
      if (dirty) return true;
       dirty = _exportacaoOriginal != Exportacao;
      if (dirty) return true;
       dirty = _precoTotalOriginalOriginal != PrecoTotalOriginal;
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
       dirty = _justificativaCancelamentoOriginal != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _dataConfiguracaoOriginal != DataConfiguracao;
      if (dirty) return true;
       dirty = _urgenteOriginal != Urgente;
      if (dirty) return true;
       dirty = _urgenteSolicitanteOriginal != UrgenteSolicitante;
      if (dirty) return true;
       dirty = _urgenteDataPrometidaOriginal != UrgenteDataPrometida;
      if (dirty) return true;
       dirty = _urgenteInformacoesComplementaresOriginal != UrgenteInformacoesComplementares;
      if (dirty) return true;
       dirty = _dataEntregaOriginalOriginal != DataEntregaOriginal;
      if (dirty) return true;
       dirty = _informacaoEspecialOriginal != InformacaoEspecial;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginal != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_contaBancariaOriginal!=null)
       {
          dirty = !_contaBancariaOriginal.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginal!=null)
       {
          dirty = !_centroCustoLucroOriginal.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       if (_formaPagamentoOriginal!=null)
       {
          dirty = !_formaPagamentoOriginal.Equals(FormaPagamento);
       }
       else
       {
            dirty = FormaPagamento != null;
       }
      if (dirty) return true;
       dirty = _numeroPedidoAutomaticoOriginal != NumeroPedidoAutomatico;
      if (dirty) return true;
       dirty = _formaFreteOriginal != FormaFrete;
      if (dirty) return true;
       dirty = _responsavelFreteOriginal != ResponsavelFrete;
      if (dirty) return true;
       dirty = _ordemVendaOriginal != OrdemVenda;
      if (dirty) return true;
       if (_representanteOriginal!=null)
       {
          dirty = !_representanteOriginal.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginal != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _dataEncerramentoOriginal != DataEncerramento;
      if (dirty) return true;
       dirty = _obsPadraoEspelhoOriginal != ObsPadraoEspelho;
      if (dirty) return true;
       dirty = _dataUltimaAlteracaoOriginal != DataUltimaAlteracao;
      if (dirty) return true;
       dirty = _suspensaoObsOriginal != SuspensaoObs;
      if (dirty) return true;
       if (_acsUsuarioResponsavelSuspensaoOriginal!=null)
       {
          dirty = !_acsUsuarioResponsavelSuspensaoOriginal.Equals(AcsUsuarioResponsavelSuspensao);
       }
       else
       {
            dirty = AcsUsuarioResponsavelSuspensao != null;
       }
      if (dirty) return true;
       if (_vendedorOriginal!=null)
       {
          dirty = !_vendedorOriginal.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginal != PercComissaoVendedor;
      if (dirty) return true;
       if (_pedidoItemPaiOriginal!=null)
       {
          dirty = !_pedidoItemPaiOriginal.Equals(PedidoItemPai);
       }
       else
       {
            dirty = PedidoItemPai != null;
       }
      if (dirty) return true;
       dirty = _comissaoGeradaOriginal != ComissaoGerada;
      if (dirty) return true;
       dirty = _observacaoNfOriginal != ObservacaoNf;
      if (dirty) return true;
       dirty = _faturamentoAntecipadoRealizadoOriginal != FaturamentoAntecipadoRealizado;
      if (dirty) return true;
       if (_nfPrincipalFaturamentoAntecipadoOriginal!=null)
       {
          dirty = !_nfPrincipalFaturamentoAntecipadoOriginal.Equals(NfPrincipalFaturamentoAntecipado);
       }
       else
       {
            dirty = NfPrincipalFaturamentoAntecipado != null;
       }
      if (dirty) return true;
       if (_ncmOriginal!=null)
       {
          dirty = !_ncmOriginal.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
      if (dirty) return true;
       dirty = _situacaoGadOriginal != SituacaoGad;
      if (dirty) return true;
       dirty = _situacaoGadMensagemOriginal != SituacaoGadMensagem;
      if (dirty) return true;
       if (_programacaoOriginal!=null)
       {
          dirty = !_programacaoOriginal.Equals(Programacao);
       }
       else
       {
            dirty = Programacao != null;
       }
      if (dirty) return true;
       dirty = _emissorNfeOriginal != EmissorNfe;
      if (dirty) return true;
       if (_operacaoCompletaOriginal!=null)
       {
          dirty = !_operacaoCompletaOriginal.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
       }
      if (dirty) return true;
       dirty = _gadProgramadoOriginal != GadProgramado;
      if (dirty) return true;
       dirty = _gadProgramacaoNomeOriginal != GadProgramacaoNome;
      if (dirty) return true;
       dirty = _gadProgramacaoDataOriginal != GadProgramacaoData;
      if (dirty) return true;
       if (_tipoPagamentoOriginal!=null)
       {
          dirty = !_tipoPagamentoOriginal.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
       }
      if (dirty) return true;
       dirty = _envioTerceirosOriginal != EnvioTerceiros;
      if (dirty) return true;
       if (_clienteEnvioTerceirosOriginal!=null)
       {
          dirty = !_clienteEnvioTerceirosOriginal.Equals(ClienteEnvioTerceiros);
       }
       else
       {
            dirty = ClienteEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_operacaoEnvioTerceirosOriginal!=null)
       {
          dirty = !_operacaoEnvioTerceirosOriginal.Equals(OperacaoEnvioTerceiros);
       }
       else
       {
            dirty = OperacaoEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaEnvioTerceirosOriginal!=null)
       {
          dirty = !_operacaoCompletaEnvioTerceirosOriginal.Equals(OperacaoCompletaEnvioTerceiros);
       }
       else
       {
            dirty = OperacaoCompletaEnvioTerceiros != null;
       }
      if (dirty) return true;
       dirty = _descontoOriginal != Desconto;
      if (dirty) return true;
       if (_pedidoClassificacaoOriginal!=null)
       {
          dirty = !_pedidoClassificacaoOriginal.Equals(PedidoClassificacao);
       }
       else
       {
            dirty = PedidoClassificacao != null;
       }
      if (dirty) return true;
       if (_meioPagamentoOriginal!=null)
       {
          dirty = !_meioPagamentoOriginal.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
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
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionAtendimentoClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  if (_valueCollectionGadPedidosUploadClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoDocumentoClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  if (_valueCollectionPedidoItemClassPedidoItemPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemFeedbackClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemLoteClienteClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemQualidadeClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemVariavelClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoItemVolumeClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoKitClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  if (_valueCollectionPedidoVariavelClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionAtendimentoClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                   tempRet = CollectionGadPedidosUploadClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoDocumentoClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                   tempRet = CollectionPedidoItemClassPedidoItemPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemFeedbackClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemFeedbackSecundarioClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemHistoricoAlteracoesClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemLoteClienteClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemQualidadeClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemVariavelClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoItemVolumeClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoKitClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                   tempRet = CollectionPedidoVariavelClassPedidoItem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraPedidoClassPedidoItem.Any(item => item.IsDirtyCommited());
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
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _posicaoOriginalCommited != Posicao;
      if (dirty) return true;
       dirty = _subLinhaOriginalCommited != SubLinha;
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
       dirty = _produtoCodigoClienteOriginalCommited != ProdutoCodigoCliente;
      if (dirty) return true;
       dirty = _produtoDescricaoClienteOriginalCommited != ProdutoDescricaoCliente;
      if (dirty) return true;
       dirty = _projetoClienteOriginalCommited != ProjetoCliente;
      if (dirty) return true;
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _saldoOriginalCommited != Saldo;
      if (dirty) return true;
       dirty = _precoUnitarioOriginalCommited != PrecoUnitario;
      if (dirty) return true;
       dirty = _precoTotalOriginalCommited != PrecoTotal;
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
       dirty = _cnpjClienteOriginalCommited != CnpjCliente;
      if (dirty) return true;
       dirty = _armazenagemClienteOriginalCommited != ArmazenagemCliente;
      if (dirty) return true;
       dirty = _freteOriginalCommited != Frete;
      if (dirty) return true;
       dirty = _dataEntregaOriginalCommited != DataEntrega;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _dataEntradaOriginalCommited != DataEntrada;
      if (dirty) return true;
       if (_operacaoOriginalCommited!=null)
       {
          dirty = !_operacaoOriginalCommited.Equals(Operacao);
       }
       else
       {
            dirty = Operacao != null;
       }
      if (dirty) return true;
       dirty = _permiteEntregaParcialOriginalCommited != PermiteEntregaParcial;
      if (dirty) return true;
       dirty = _volumeUnicoOriginalCommited != VolumeUnico;
      if (dirty) return true;
       dirty = _configuradoOriginalCommited != Configurado;
      if (dirty) return true;
       dirty = _exportacaoOriginalCommited != Exportacao;
      if (dirty) return true;
       dirty = _precoTotalOriginalOriginalCommited != PrecoTotalOriginal;
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
       dirty = _justificativaCancelamentoOriginalCommited != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _dataConfiguracaoOriginalCommited != DataConfiguracao;
      if (dirty) return true;
       dirty = _urgenteOriginalCommited != Urgente;
      if (dirty) return true;
       dirty = _urgenteSolicitanteOriginalCommited != UrgenteSolicitante;
      if (dirty) return true;
       dirty = _urgenteDataPrometidaOriginalCommited != UrgenteDataPrometida;
      if (dirty) return true;
       dirty = _urgenteInformacoesComplementaresOriginalCommited != UrgenteInformacoesComplementares;
      if (dirty) return true;
       dirty = _dataEntregaOriginalOriginalCommited != DataEntregaOriginal;
      if (dirty) return true;
       dirty = _informacaoEspecialOriginalCommited != InformacaoEspecial;
      if (dirty) return true;
       dirty = _rastreamentoMaterialOriginalCommited != RastreamentoMaterial;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_contaBancariaOriginalCommited!=null)
       {
          dirty = !_contaBancariaOriginalCommited.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       if (_centroCustoLucroOriginalCommited!=null)
       {
          dirty = !_centroCustoLucroOriginalCommited.Equals(CentroCustoLucro);
       }
       else
       {
            dirty = CentroCustoLucro != null;
       }
      if (dirty) return true;
       if (_formaPagamentoOriginalCommited!=null)
       {
          dirty = !_formaPagamentoOriginalCommited.Equals(FormaPagamento);
       }
       else
       {
            dirty = FormaPagamento != null;
       }
      if (dirty) return true;
       dirty = _numeroPedidoAutomaticoOriginalCommited != NumeroPedidoAutomatico;
      if (dirty) return true;
       dirty = _formaFreteOriginalCommited != FormaFrete;
      if (dirty) return true;
       dirty = _responsavelFreteOriginalCommited != ResponsavelFrete;
      if (dirty) return true;
       dirty = _ordemVendaOriginalCommited != OrdemVenda;
      if (dirty) return true;
       if (_representanteOriginalCommited!=null)
       {
          dirty = !_representanteOriginalCommited.Equals(Representante);
       }
       else
       {
            dirty = Representante != null;
       }
      if (dirty) return true;
       dirty = _percComissaoRepresentanteOriginalCommited != PercComissaoRepresentante;
      if (dirty) return true;
       dirty = _dataEncerramentoOriginalCommited != DataEncerramento;
      if (dirty) return true;
       dirty = _obsPadraoEspelhoOriginalCommited != ObsPadraoEspelho;
      if (dirty) return true;
       dirty = _dataUltimaAlteracaoOriginalCommited != DataUltimaAlteracao;
      if (dirty) return true;
       dirty = _suspensaoObsOriginalCommited != SuspensaoObs;
      if (dirty) return true;
       if (_acsUsuarioResponsavelSuspensaoOriginalCommited!=null)
       {
          dirty = !_acsUsuarioResponsavelSuspensaoOriginalCommited.Equals(AcsUsuarioResponsavelSuspensao);
       }
       else
       {
            dirty = AcsUsuarioResponsavelSuspensao != null;
       }
      if (dirty) return true;
       if (_vendedorOriginalCommited!=null)
       {
          dirty = !_vendedorOriginalCommited.Equals(Vendedor);
       }
       else
       {
            dirty = Vendedor != null;
       }
      if (dirty) return true;
       dirty = _percComissaoVendedorOriginalCommited != PercComissaoVendedor;
      if (dirty) return true;
       if (_pedidoItemPaiOriginalCommited!=null)
       {
          dirty = !_pedidoItemPaiOriginalCommited.Equals(PedidoItemPai);
       }
       else
       {
            dirty = PedidoItemPai != null;
       }
      if (dirty) return true;
       dirty = _comissaoGeradaOriginalCommited != ComissaoGerada;
      if (dirty) return true;
       dirty = _observacaoNfOriginalCommited != ObservacaoNf;
      if (dirty) return true;
       dirty = _faturamentoAntecipadoRealizadoOriginalCommited != FaturamentoAntecipadoRealizado;
      if (dirty) return true;
       if (_nfPrincipalFaturamentoAntecipadoOriginalCommited!=null)
       {
          dirty = !_nfPrincipalFaturamentoAntecipadoOriginalCommited.Equals(NfPrincipalFaturamentoAntecipado);
       }
       else
       {
            dirty = NfPrincipalFaturamentoAntecipado != null;
       }
      if (dirty) return true;
       if (_ncmOriginalCommited!=null)
       {
          dirty = !_ncmOriginalCommited.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
      if (dirty) return true;
       dirty = _situacaoGadOriginalCommited != SituacaoGad;
      if (dirty) return true;
       dirty = _situacaoGadMensagemOriginalCommited != SituacaoGadMensagem;
      if (dirty) return true;
       if (_programacaoOriginalCommited!=null)
       {
          dirty = !_programacaoOriginalCommited.Equals(Programacao);
       }
       else
       {
            dirty = Programacao != null;
       }
      if (dirty) return true;
       dirty = _emissorNfeOriginalCommited != EmissorNfe;
      if (dirty) return true;
       if (_operacaoCompletaOriginalCommited!=null)
       {
          dirty = !_operacaoCompletaOriginalCommited.Equals(OperacaoCompleta);
       }
       else
       {
            dirty = OperacaoCompleta != null;
       }
      if (dirty) return true;
       dirty = _gadProgramadoOriginalCommited != GadProgramado;
      if (dirty) return true;
       dirty = _gadProgramacaoNomeOriginalCommited != GadProgramacaoNome;
      if (dirty) return true;
       dirty = _gadProgramacaoDataOriginalCommited != GadProgramacaoData;
      if (dirty) return true;
       if (_tipoPagamentoOriginalCommited!=null)
       {
          dirty = !_tipoPagamentoOriginalCommited.Equals(TipoPagamento);
       }
       else
       {
            dirty = TipoPagamento != null;
       }
      if (dirty) return true;
       dirty = _envioTerceirosOriginalCommited != EnvioTerceiros;
      if (dirty) return true;
       if (_clienteEnvioTerceirosOriginalCommited!=null)
       {
          dirty = !_clienteEnvioTerceirosOriginalCommited.Equals(ClienteEnvioTerceiros);
       }
       else
       {
            dirty = ClienteEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_operacaoEnvioTerceirosOriginalCommited!=null)
       {
          dirty = !_operacaoEnvioTerceirosOriginalCommited.Equals(OperacaoEnvioTerceiros);
       }
       else
       {
            dirty = OperacaoEnvioTerceiros != null;
       }
      if (dirty) return true;
       if (_operacaoCompletaEnvioTerceirosOriginalCommited!=null)
       {
          dirty = !_operacaoCompletaEnvioTerceirosOriginalCommited.Equals(OperacaoCompletaEnvioTerceiros);
       }
       else
       {
            dirty = OperacaoCompletaEnvioTerceiros != null;
       }
      if (dirty) return true;
       dirty = _descontoOriginalCommited != Desconto;
      if (dirty) return true;
       if (_pedidoClassificacaoOriginalCommited!=null)
       {
          dirty = !_pedidoClassificacaoOriginalCommited.Equals(PedidoClassificacao);
       }
       else
       {
            dirty = PedidoClassificacao != null;
       }
      if (dirty) return true;
       if (_meioPagamentoOriginalCommited!=null)
       {
          dirty = !_meioPagamentoOriginalCommited.Equals(MeioPagamento);
       }
       else
       {
            dirty = MeioPagamento != null;
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
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  foreach(GadPedidosUploadClass item in CollectionGadPedidosUploadClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  foreach(PedidoDocumentoClass item in CollectionPedidoDocumentoClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassPedidoItemPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemFeedbackClass item in CollectionPedidoItemFeedbackClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemFeedbackSecundarioClass item in CollectionPedidoItemFeedbackSecundarioClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemHistoricoAlteracoesClass item in CollectionPedidoItemHistoricoAlteracoesClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemLoteClienteClass item in CollectionPedidoItemLoteClienteClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemQualidadeClass item in CollectionPedidoItemQualidadeClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemVariavelClass item in CollectionPedidoItemVariavelClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemVolumeClass item in CollectionPedidoItemVolumeClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  foreach(PedidoKitClass item in CollectionPedidoKitClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  foreach(PedidoVariavelClass item in CollectionPedidoVariavelClassPedidoItem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  foreach(SolicitacaoCompraPedidoClass item in CollectionSolicitacaoCompraPedidoClassPedidoItem)
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
             case "Numero":
                return this.Numero;
             case "Posicao":
                return this.Posicao;
             case "SubLinha":
                return this.SubLinha;
             case "Produto":
                return this.Produto;
             case "ProdutoCodigoCliente":
                return this.ProdutoCodigoCliente;
             case "ProdutoDescricaoCliente":
                return this.ProdutoDescricaoCliente;
             case "ProjetoCliente":
                return this.ProjetoCliente;
             case "Quantidade":
                return this.Quantidade;
             case "Saldo":
                return this.Saldo;
             case "PrecoUnitario":
                return this.PrecoUnitario;
             case "PrecoTotal":
                return this.PrecoTotal;
             case "Cliente":
                return this.Cliente;
             case "CnpjCliente":
                return this.CnpjCliente;
             case "ArmazenagemCliente":
                return this.ArmazenagemCliente;
             case "Frete":
                return this.Frete;
             case "DataEntrega":
                return this.DataEntrega;
             case "Status":
                return this.Status;
             case "DataEntrada":
                return this.DataEntrada;
             case "Operacao":
                return this.Operacao;
             case "PermiteEntregaParcial":
                return this.PermiteEntregaParcial;
             case "VolumeUnico":
                return this.VolumeUnico;
             case "Configurado":
                return this.Configurado;
             case "Exportacao":
                return this.Exportacao;
             case "PrecoTotalOriginal":
                return this.PrecoTotalOriginal;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "JustificativaCancelamento":
                return this.JustificativaCancelamento;
             case "DataConfiguracao":
                return this.DataConfiguracao;
             case "Urgente":
                return this.Urgente;
             case "UrgenteSolicitante":
                return this.UrgenteSolicitante;
             case "UrgenteDataPrometida":
                return this.UrgenteDataPrometida;
             case "UrgenteInformacoesComplementares":
                return this.UrgenteInformacoesComplementares;
             case "DataEntregaOriginal":
                return this.DataEntregaOriginal;
             case "InformacaoEspecial":
                return this.InformacaoEspecial;
             case "RastreamentoMaterial":
                return this.RastreamentoMaterial;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ContaBancaria":
                return this.ContaBancaria;
             case "CentroCustoLucro":
                return this.CentroCustoLucro;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "NumeroPedidoAutomatico":
                return this.NumeroPedidoAutomatico;
             case "FormaFrete":
                return this.FormaFrete;
             case "ResponsavelFrete":
                return this.ResponsavelFrete;
             case "OrdemVenda":
                return this.OrdemVenda;
             case "Representante":
                return this.Representante;
             case "PercComissaoRepresentante":
                return this.PercComissaoRepresentante;
             case "DataEncerramento":
                return this.DataEncerramento;
             case "ObsPadraoEspelho":
                return this.ObsPadraoEspelho;
             case "DataUltimaAlteracao":
                return this.DataUltimaAlteracao;
             case "SuspensaoObs":
                return this.SuspensaoObs;
             case "AcsUsuarioResponsavelSuspensao":
                return this.AcsUsuarioResponsavelSuspensao;
             case "Vendedor":
                return this.Vendedor;
             case "PercComissaoVendedor":
                return this.PercComissaoVendedor;
             case "PedidoItemPai":
                return this.PedidoItemPai;
             case "ComissaoGerada":
                return this.ComissaoGerada;
             case "ObservacaoNf":
                return this.ObservacaoNf;
             case "FaturamentoAntecipadoRealizado":
                return this.FaturamentoAntecipadoRealizado;
             case "NfPrincipalFaturamentoAntecipado":
                return this.NfPrincipalFaturamentoAntecipado;
             case "Ncm":
                return this.Ncm;
             case "SituacaoGad":
                return this.SituacaoGad;
             case "SituacaoGadMensagem":
                return this.SituacaoGadMensagem;
             case "Programacao":
                return this.Programacao;
             case "EmissorNfe":
                return this.EmissorNfe;
             case "OperacaoCompleta":
                return this.OperacaoCompleta;
             case "GadProgramado":
                return this.GadProgramado;
             case "GadProgramacaoNome":
                return this.GadProgramacaoNome;
             case "GadProgramacaoData":
                return this.GadProgramacaoData;
             case "TipoPagamento":
                return this.TipoPagamento;
             case "EnvioTerceiros":
                return this.EnvioTerceiros;
             case "ClienteEnvioTerceiros":
                return this.ClienteEnvioTerceiros;
             case "OperacaoEnvioTerceiros":
                return this.OperacaoEnvioTerceiros;
             case "OperacaoCompletaEnvioTerceiros":
                return this.OperacaoCompletaEnvioTerceiros;
             case "Desconto":
                return this.Desconto;
             case "PedidoClassificacao":
                return this.PedidoClassificacao;
             case "MeioPagamento":
                return this.MeioPagamento;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Produto!=null)
                Produto.ChangeSingleConnection(newConnection);
             if (Cliente!=null)
                Cliente.ChangeSingleConnection(newConnection);
             if (Operacao!=null)
                Operacao.ChangeSingleConnection(newConnection);
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (CentroCustoLucro!=null)
                CentroCustoLucro.ChangeSingleConnection(newConnection);
             if (FormaPagamento!=null)
                FormaPagamento.ChangeSingleConnection(newConnection);
             if (Representante!=null)
                Representante.ChangeSingleConnection(newConnection);
             if (AcsUsuarioResponsavelSuspensao!=null)
                AcsUsuarioResponsavelSuspensao.ChangeSingleConnection(newConnection);
             if (Vendedor!=null)
                Vendedor.ChangeSingleConnection(newConnection);
             if (PedidoItemPai!=null)
                PedidoItemPai.ChangeSingleConnection(newConnection);
             if (NfPrincipalFaturamentoAntecipado!=null)
                NfPrincipalFaturamentoAntecipado.ChangeSingleConnection(newConnection);
             if (Ncm!=null)
                Ncm.ChangeSingleConnection(newConnection);
             if (Programacao!=null)
                Programacao.ChangeSingleConnection(newConnection);
             if (OperacaoCompleta!=null)
                OperacaoCompleta.ChangeSingleConnection(newConnection);
             if (TipoPagamento!=null)
                TipoPagamento.ChangeSingleConnection(newConnection);
             if (ClienteEnvioTerceiros!=null)
                ClienteEnvioTerceiros.ChangeSingleConnection(newConnection);
             if (OperacaoEnvioTerceiros!=null)
                OperacaoEnvioTerceiros.ChangeSingleConnection(newConnection);
             if (OperacaoCompletaEnvioTerceiros!=null)
                OperacaoCompletaEnvioTerceiros.ChangeSingleConnection(newConnection);
             if (PedidoClassificacao!=null)
                PedidoClassificacao.ChangeSingleConnection(newConnection);
             if (MeioPagamento!=null)
                MeioPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionAtendimentoClassPedidoItemLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionGadPedidosUploadClassPedidoItemLoaded) 
               {
                  foreach(GadPedidosUploadClass item in CollectionGadPedidosUploadClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassPedidoItemLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedidoLoaded) 
               {
                  foreach(OrderItemEtiquetaClass item in CollectionOrderItemEtiquetaClassPedidoItemLinhaPrincipalPedido)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoDocumentoClassPedidoItemLoaded) 
               {
                  foreach(PedidoDocumentoClass item in CollectionPedidoDocumentoClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassPedidoItemPaiLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassPedidoItemPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemFeedbackClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemFeedbackClass item in CollectionPedidoItemFeedbackClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemFeedbackSecundarioClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemFeedbackSecundarioClass item in CollectionPedidoItemFeedbackSecundarioClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemHistoricoAlteracoesClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemHistoricoAlteracoesClass item in CollectionPedidoItemHistoricoAlteracoesClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemLoteClienteClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemLoteClienteClass item in CollectionPedidoItemLoteClienteClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemQualidadeClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemQualidadeClass item in CollectionPedidoItemQualidadeClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemVariavelClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemVariavelClass item in CollectionPedidoItemVariavelClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemVolumeClassPedidoItemLoaded) 
               {
                  foreach(PedidoItemVolumeClass item in CollectionPedidoItemVolumeClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoKitClassPedidoItemLoaded) 
               {
                  foreach(PedidoKitClass item in CollectionPedidoKitClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoVariavelClassPedidoItemLoaded) 
               {
                  foreach(PedidoVariavelClass item in CollectionPedidoVariavelClassPedidoItem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraPedidoClassPedidoItemLoaded) 
               {
                  foreach(SolicitacaoCompraPedidoClass item in CollectionSolicitacaoCompraPedidoClassPedidoItem)
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
                  command.CommandText += " COUNT(pedido_item.id_pedido_item) " ;
               }
               else
               {
               command.CommandText += "pedido_item.id_pedido_item, " ;
               command.CommandText += "pedido_item.pei_numero, " ;
               command.CommandText += "pedido_item.pei_posicao, " ;
               command.CommandText += "pedido_item.pei_sub_linha, " ;
               command.CommandText += "pedido_item.id_produto, " ;
               command.CommandText += "pedido_item.pei_produto_codigo_cliente, " ;
               command.CommandText += "pedido_item.pei_produto_descricao_cliente, " ;
               command.CommandText += "pedido_item.pei_projeto_cliente, " ;
               command.CommandText += "pedido_item.pei_quantidade, " ;
               command.CommandText += "pedido_item.pei_saldo, " ;
               command.CommandText += "pedido_item.pei_preco_unitario, " ;
               command.CommandText += "pedido_item.pei_preco_total, " ;
               command.CommandText += "pedido_item.id_cliente, " ;
               command.CommandText += "pedido_item.pei_cnpj_cliente, " ;
               command.CommandText += "pedido_item.pei_armazenagem_cliente, " ;
               command.CommandText += "pedido_item.pei_frete, " ;
               command.CommandText += "pedido_item.pei_data_entrega, " ;
               command.CommandText += "pedido_item.pei_status, " ;
               command.CommandText += "pedido_item.pei_data_entrada, " ;
               command.CommandText += "pedido_item.id_operacao, " ;
               command.CommandText += "pedido_item.pei_permite_entrega_parcial, " ;
               command.CommandText += "pedido_item.pei_volume_unico, " ;
               command.CommandText += "pedido_item.pei_configurado, " ;
               command.CommandText += "pedido_item.pei_exportacao, " ;
               command.CommandText += "pedido_item.pei_preco_total_original, " ;
               command.CommandText += "pedido_item.id_acs_usuario_cancelamento, " ;
               command.CommandText += "pedido_item.pei_data_cancelamento, " ;
               command.CommandText += "pedido_item.pei_justificativa_cancelamento, " ;
               command.CommandText += "pedido_item.pei_data_configuracao, " ;
               command.CommandText += "pedido_item.pei_urgente, " ;
               command.CommandText += "pedido_item.pei_urgente_solicitante, " ;
               command.CommandText += "pedido_item.pei_urgente_data_prometida, " ;
               command.CommandText += "pedido_item.pei_urgente_informacoes_complementares, " ;
               command.CommandText += "pedido_item.pei_data_entrega_original, " ;
               command.CommandText += "pedido_item.pei_informacao_especial, " ;
               command.CommandText += "pedido_item.pei_rastreamento_material, " ;
               command.CommandText += "pedido_item.entity_uid, " ;
               command.CommandText += "pedido_item.version, " ;
               command.CommandText += "pedido_item.id_conta_bancaria, " ;
               command.CommandText += "pedido_item.id_centro_custo_lucro, " ;
               command.CommandText += "pedido_item.id_forma_pagamento, " ;
               command.CommandText += "pedido_item.pei_numero_pedido_automatico, " ;
               command.CommandText += "pedido_item.pei_forma_frete, " ;
               command.CommandText += "pedido_item.pei_responsavel_frete, " ;
               command.CommandText += "pedido_item.pei_ordem_venda, " ;
               command.CommandText += "pedido_item.id_representante, " ;
               command.CommandText += "pedido_item.pei_perc_comissao_representante, " ;
               command.CommandText += "pedido_item.pei_data_encerramento, " ;
               command.CommandText += "pedido_item.pei_obs_padrao_espelho, " ;
               command.CommandText += "pedido_item.pei_data_ultima_alteracao, " ;
               command.CommandText += "pedido_item.pei_suspensao_obs, " ;
               command.CommandText += "pedido_item.id_acs_usuario_responsavel_suspensao, " ;
               command.CommandText += "pedido_item.id_vendedor, " ;
               command.CommandText += "pedido_item.pei_perc_comissao_vendedor, " ;
               command.CommandText += "pedido_item.id_pedido_item_pai, " ;
               command.CommandText += "pedido_item.pei_comissao_gerada, " ;
               command.CommandText += "pedido_item.pei_observacao_nf, " ;
               command.CommandText += "pedido_item.pei_faturamento_antecipado_realizado, " ;
               command.CommandText += "pedido_item.id_nf_principal_faturamento_antecipado, " ;
               command.CommandText += "pedido_item.id_ncm, " ;
               command.CommandText += "pedido_item.pei_situacao_gad, " ;
               command.CommandText += "pedido_item.pei_situacao_gad_mensagem, " ;
               command.CommandText += "pedido_item.id_programacao, " ;
               command.CommandText += "pedido_item.pei_emissor_nfe, " ;
               command.CommandText += "pedido_item.id_operacao_completa, " ;
               command.CommandText += "pedido_item.pei_gad_programado, " ;
               command.CommandText += "pedido_item.pei_gad_programacao_nome, " ;
               command.CommandText += "pedido_item.pei_gad_programacao_data, " ;
               command.CommandText += "pedido_item.id_tipo_pagamento, " ;
               command.CommandText += "pedido_item.ped_envio_terceiros, " ;
               command.CommandText += "pedido_item.id_cliente_envio_terceiros, " ;
               command.CommandText += "pedido_item.id_operacao_envio_terceiros, " ;
               command.CommandText += "pedido_item.id_operacao_completa_envio_terceiros, " ;
               command.CommandText += "pedido_item.pei_desconto, " ;
               command.CommandText += "pedido_item.id_pedido_classificacao, " ;
               command.CommandText += "pedido_item.id_meio_pagamento " ;
               }
               command.CommandText += " FROM  pedido_item ";
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
                        orderByClause += " , pei_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(pei_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = pedido_item.id_acs_usuario_ultima_revisao ";
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
                     case "id_pedido_item":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.id_pedido_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.id_pedido_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_posicao":
                     case "Posicao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_sub_linha":
                     case "SubLinha":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_sub_linha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_sub_linha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_produto":
                     case "Produto":
                     command.CommandText += " LEFT JOIN produto as produto_Produto ON produto_Produto.id_produto = pedido_item.id_produto ";                     switch (parametro.TipoOrdenacao)
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
                     case "pei_produto_codigo_cliente":
                     case "ProdutoCodigoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_produto_codigo_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_produto_codigo_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_produto_descricao_cliente":
                     case "ProdutoDescricaoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_produto_descricao_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_produto_descricao_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_projeto_cliente":
                     case "ProjetoCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_projeto_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_projeto_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_saldo":
                     case "Saldo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_saldo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_saldo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_preco_unitario":
                     case "PrecoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_preco_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_preco_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_preco_total":
                     case "PrecoTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_preco_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_preco_total) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente":
                     case "Cliente":
                     command.CommandText += " LEFT JOIN cliente as cliente_Cliente ON cliente_Cliente.id_cliente = pedido_item.id_cliente ";                     switch (parametro.TipoOrdenacao)
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
                     case "pei_cnpj_cliente":
                     case "CnpjCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_cnpj_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_cnpj_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_armazenagem_cliente":
                     case "ArmazenagemCliente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_armazenagem_cliente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_armazenagem_cliente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_frete":
                     case "Frete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_entrega":
                     case "DataEntrega":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_entrega " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_entrega) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_entrada":
                     case "DataEntrada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_entrada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_entrada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao":
                     case "Operacao":
                     command.CommandText += " LEFT JOIN operacao as operacao_Operacao ON operacao_Operacao.id_operacao = pedido_item.id_operacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_Operacao.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_Operacao.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_permite_entrega_parcial":
                     case "PermiteEntregaParcial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_permite_entrega_parcial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_permite_entrega_parcial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_volume_unico":
                     case "VolumeUnico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_volume_unico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_volume_unico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_configurado":
                     case "Configurado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_configurado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_configurado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_exportacao":
                     case "Exportacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_exportacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_exportacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_preco_total_original":
                     case "PrecoTotalOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_preco_total_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_preco_total_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , pedido_item.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "pei_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_justificativa_cancelamento":
                     case "JustificativaCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_justificativa_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_justificativa_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_configuracao":
                     case "DataConfiguracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_configuracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_configuracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_urgente":
                     case "Urgente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_urgente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_urgente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_urgente_solicitante":
                     case "UrgenteSolicitante":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_urgente_solicitante " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_urgente_solicitante) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_urgente_data_prometida":
                     case "UrgenteDataPrometida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_urgente_data_prometida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_urgente_data_prometida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_urgente_informacoes_complementares":
                     case "UrgenteInformacoesComplementares":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_urgente_informacoes_complementares " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_urgente_informacoes_complementares) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_entrega_original":
                     case "DataEntregaOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_entrega_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_entrega_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_informacao_especial":
                     case "InformacaoEspecial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_informacao_especial " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_informacao_especial) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_rastreamento_material":
                     case "RastreamentoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_rastreamento_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_rastreamento_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , pedido_item.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = pedido_item.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conta_bancaria_ContaBancaria.cba_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conta_bancaria_ContaBancaria.cba_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_centro_custo_lucro":
                     case "CentroCustoLucro":
                     command.CommandText += " LEFT JOIN centro_custo_lucro as centro_custo_lucro_CentroCustoLucro ON centro_custo_lucro_CentroCustoLucro.id_centro_custo_lucro = pedido_item.id_centro_custo_lucro ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , centro_custo_lucro_CentroCustoLucro.ccl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(centro_custo_lucro_CentroCustoLucro.ccl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_forma_pagamento":
                     case "FormaPagamento":
                     command.CommandText += " LEFT JOIN forma_pagamento as forma_pagamento_FormaPagamento ON forma_pagamento_FormaPagamento.id_forma_pagamento = pedido_item.id_forma_pagamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , forma_pagamento_FormaPagamento.fop_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(forma_pagamento_FormaPagamento.fop_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_numero_pedido_automatico":
                     case "NumeroPedidoAutomatico":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_numero_pedido_automatico " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_numero_pedido_automatico) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_forma_frete":
                     case "FormaFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_forma_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_forma_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_responsavel_frete":
                     case "ResponsavelFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_responsavel_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_responsavel_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_ordem_venda":
                     case "OrdemVenda":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_ordem_venda " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_ordem_venda) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_representante":
                     case "Representante":
                     command.CommandText += " LEFT JOIN representante as representante_Representante ON representante_Representante.id_representante = pedido_item.id_representante ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , representante_Representante.rep_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(representante_Representante.rep_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_perc_comissao_representante":
                     case "PercComissaoRepresentante":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_perc_comissao_representante " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_perc_comissao_representante) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_encerramento":
                     case "DataEncerramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_encerramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_encerramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_obs_padrao_espelho":
                     case "ObsPadraoEspelho":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_obs_padrao_espelho " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_obs_padrao_espelho) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_data_ultima_alteracao":
                     case "DataUltimaAlteracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_data_ultima_alteracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_data_ultima_alteracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_suspensao_obs":
                     case "SuspensaoObs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_suspensao_obs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_suspensao_obs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_responsavel_suspensao":
                     case "AcsUsuarioResponsavelSuspensao":
                     orderByClause += " , pedido_item.id_acs_usuario_responsavel_suspensao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_vendedor":
                     case "Vendedor":
                     command.CommandText += " LEFT JOIN vendedor as vendedor_Vendedor ON vendedor_Vendedor.id_vendedor = pedido_item.id_vendedor ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , vendedor_Vendedor.ven_razao_social " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(vendedor_Vendedor.ven_razao_social) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_perc_comissao_vendedor":
                     case "PercComissaoVendedor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_perc_comissao_vendedor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_perc_comissao_vendedor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_item_pai":
                     case "PedidoItemPai":
                     command.CommandText += " LEFT JOIN pedido_item as pedido_item_PedidoItemPai ON pedido_item_PedidoItemPai.id_pedido_item = pedido_item.id_pedido_item_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item_PedidoItemPai.pei_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item_PedidoItemPai.pei_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item_PedidoItemPai.pei_posicao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item_PedidoItemPai.pei_posicao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_comissao_gerada":
                     case "ComissaoGerada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_comissao_gerada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_comissao_gerada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_observacao_nf":
                     case "ObservacaoNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_observacao_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_observacao_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_faturamento_antecipado_realizado":
                     case "FaturamentoAntecipadoRealizado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_faturamento_antecipado_realizado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_faturamento_antecipado_realizado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal_faturamento_antecipado":
                     case "NfPrincipalFaturamentoAntecipado":
                     orderByClause += " , pedido_item.id_nf_principal_faturamento_antecipado " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_ncm":
                     case "Ncm":
                     command.CommandText += " LEFT JOIN ncm as ncm_Ncm ON ncm_Ncm.id_ncm = pedido_item.id_ncm ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_Ncm.ncm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_Ncm.ncm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_situacao_gad":
                     case "SituacaoGad":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_situacao_gad " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_situacao_gad) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_situacao_gad_mensagem":
                     case "SituacaoGadMensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_situacao_gad_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_situacao_gad_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_programacao":
                     case "Programacao":
                     command.CommandText += " LEFT JOIN programacao as programacao_Programacao ON programacao_Programacao.id_programacao = pedido_item.id_programacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , programacao_Programacao.prg_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(programacao_Programacao.prg_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_emissor_nfe":
                     case "EmissorNfe":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_emissor_nfe " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_emissor_nfe) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao_completa":
                     case "OperacaoCompleta":
                     command.CommandText += " LEFT JOIN operacao_completa as operacao_completa_OperacaoCompleta ON operacao_completa_OperacaoCompleta.id_operacao_completa = pedido_item.id_operacao_completa ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa_OperacaoCompleta.opc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa_OperacaoCompleta.opc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_gad_programado":
                     case "GadProgramado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_gad_programado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_gad_programado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_gad_programacao_nome":
                     case "GadProgramacaoNome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_gad_programacao_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_gad_programacao_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_gad_programacao_data":
                     case "GadProgramacaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_item.pei_gad_programacao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_item.pei_gad_programacao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_tipo_pagamento":
                     case "TipoPagamento":
                     command.CommandText += " LEFT JOIN tipo_pagamento as tipo_pagamento_TipoPagamento ON tipo_pagamento_TipoPagamento.id_tipo_pagamento = pedido_item.id_tipo_pagamento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_pagamento_TipoPagamento.tip_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_pagamento_TipoPagamento.tip_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ped_envio_terceiros":
                     case "EnvioTerceiros":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.ped_envio_terceiros " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.ped_envio_terceiros) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cliente_envio_terceiros":
                     case "ClienteEnvioTerceiros":
                     command.CommandText += " LEFT JOIN cliente as cliente_ClienteEnvioTerceiros ON cliente_ClienteEnvioTerceiros.id_cliente = pedido_item.id_cliente_envio_terceiros ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cliente_ClienteEnvioTerceiros.cli_nome_resumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cliente_ClienteEnvioTerceiros.cli_nome_resumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao_envio_terceiros":
                     case "OperacaoEnvioTerceiros":
                     command.CommandText += " LEFT JOIN operacao as operacao_OperacaoEnvioTerceiros ON operacao_OperacaoEnvioTerceiros.id_operacao = pedido_item.id_operacao_envio_terceiros ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_OperacaoEnvioTerceiros.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_OperacaoEnvioTerceiros.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_operacao_completa_envio_terceiros":
                     case "OperacaoCompletaEnvioTerceiros":
                     command.CommandText += " LEFT JOIN operacao_completa as operacao_completa_OperacaoCompletaEnvioTerceiros ON operacao_completa_OperacaoCompletaEnvioTerceiros.id_operacao_completa = pedido_item.id_operacao_completa_envio_terceiros ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa_OperacaoCompletaEnvioTerceiros.opc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa_OperacaoCompletaEnvioTerceiros.opc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "pei_desconto":
                     case "Desconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , pedido_item.pei_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(pedido_item.pei_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pedido_classificacao":
                     case "PedidoClassificacao":
                     command.CommandText += " LEFT JOIN pedido_classificacao as pedido_classificacao_PedidoClassificacao ON pedido_classificacao_PedidoClassificacao.id_pedido_classificacao = pedido_item.id_pedido_classificacao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pedido_classificacao_PedidoClassificacao.pcl_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pedido_classificacao_PedidoClassificacao.pcl_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_meio_pagamento":
                     case "MeioPagamento":
                     orderByClause += " , pedido_item.id_meio_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_numero")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_numero) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_numero) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_produto_codigo_cliente")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_produto_codigo_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_produto_codigo_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_produto_descricao_cliente")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_produto_descricao_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_produto_descricao_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_projeto_cliente")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_projeto_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_projeto_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_cnpj_cliente")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_cnpj_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_cnpj_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_armazenagem_cliente")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_armazenagem_cliente) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_armazenagem_cliente) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_justificativa_cancelamento")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_justificativa_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_justificativa_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_urgente_solicitante")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_urgente_solicitante) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_urgente_solicitante) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_urgente_informacoes_complementares")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_urgente_informacoes_complementares) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_urgente_informacoes_complementares) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_informacao_especial")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_informacao_especial) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_informacao_especial) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(pedido_item.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_ordem_venda")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_ordem_venda) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_ordem_venda) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_obs_padrao_espelho")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_obs_padrao_espelho) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_obs_padrao_espelho) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_suspensao_obs")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_suspensao_obs) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_suspensao_obs) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_observacao_nf")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_observacao_nf) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_observacao_nf) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_situacao_gad_mensagem")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_situacao_gad_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_situacao_gad_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_gad_programacao_nome")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_gad_programacao_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_gad_programacao_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("pei_gad_programacao_data")) 
                        {
                           whereClause += " OR UPPER(pedido_item.pei_gad_programacao_data) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(pedido_item.pei_gad_programacao_data) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_pedido_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_pedido_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_pedido_item = :pedido_item_ID_4198 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ID_4198", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "pei_numero")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_numero LIKE :pedido_item_Numero_9141 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Numero_9141", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Posicao" || parametro.FieldName == "pei_posicao")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_posicao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_posicao = :pedido_item_Posicao_4048 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Posicao_4048", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SubLinha" || parametro.FieldName == "pei_sub_linha")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_sub_linha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_sub_linha = :pedido_item_SubLinha_2912 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SubLinha_2912", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  pedido_item.id_produto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_produto = :pedido_item_Produto_2584 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Produto_2584", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoCliente" || parametro.FieldName == "pei_produto_codigo_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_produto_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_produto_codigo_cliente LIKE :pedido_item_ProdutoCodigoCliente_1732 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProdutoCodigoCliente_1732", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoCliente" || parametro.FieldName == "pei_produto_descricao_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_produto_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_produto_descricao_cliente LIKE :pedido_item_ProdutoDescricaoCliente_2919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProdutoDescricaoCliente_2919", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProjetoCliente" || parametro.FieldName == "pei_projeto_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_projeto_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_projeto_cliente LIKE :pedido_item_ProjetoCliente_7602 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProjetoCliente_7602", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "pei_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_quantidade = :pedido_item_Quantidade_9403 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Quantidade_9403", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Saldo" || parametro.FieldName == "pei_saldo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_saldo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_saldo = :pedido_item_Saldo_579 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Saldo_579", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoUnitario" || parametro.FieldName == "pei_preco_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_preco_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_preco_unitario = :pedido_item_PrecoUnitario_4578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PrecoUnitario_4578", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotal" || parametro.FieldName == "pei_preco_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_preco_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_preco_total = :pedido_item_PrecoTotal_5427 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PrecoTotal_5427", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  pedido_item.id_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_cliente = :pedido_item_Cliente_1334 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Cliente_1334", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCliente" || parametro.FieldName == "pei_cnpj_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_cnpj_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_cnpj_cliente LIKE :pedido_item_CnpjCliente_2145 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_CnpjCliente_2145", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ArmazenagemCliente" || parametro.FieldName == "pei_armazenagem_cliente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_armazenagem_cliente LIKE :pedido_item_ArmazenagemCliente_3922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ArmazenagemCliente_3922", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Frete" || parametro.FieldName == "pei_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_frete = :pedido_item_Frete_5112 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Frete_5112", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrega" || parametro.FieldName == "pei_data_entrega")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_entrega IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_entrega = :pedido_item_DataEntrega_9761 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataEntrega_9761", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "pei_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusPedido)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusPedido");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_status = :pedido_item_Status_9335 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Status_9335", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntrada" || parametro.FieldName == "pei_data_entrada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_entrada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_entrada = :pedido_item_DataEntrada_91 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataEntrada_91", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Operacao" || parametro.FieldName == "id_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_operacao = :pedido_item_Operacao_2168 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Operacao_2168", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PermiteEntregaParcial" || parametro.FieldName == "pei_permite_entrega_parcial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_permite_entrega_parcial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_permite_entrega_parcial = :pedido_item_PermiteEntregaParcial_3241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PermiteEntregaParcial_3241", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VolumeUnico" || parametro.FieldName == "pei_volume_unico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_volume_unico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_volume_unico = :pedido_item_VolumeUnico_7600 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_VolumeUnico_7600", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Configurado" || parametro.FieldName == "pei_configurado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_configurado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_configurado = :pedido_item_Configurado_8607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Configurado_8607", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Exportacao" || parametro.FieldName == "pei_exportacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_exportacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_exportacao = :pedido_item_Exportacao_9475 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Exportacao_9475", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoTotalOriginal" || parametro.FieldName == "pei_preco_total_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_preco_total_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_preco_total_original = :pedido_item_PrecoTotalOriginal_2899 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PrecoTotalOriginal_2899", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  pedido_item.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_acs_usuario_cancelamento = :pedido_item_AcsUsuarioCancelamento_32 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_AcsUsuarioCancelamento_32", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "pei_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_cancelamento = :pedido_item_DataCancelamento_7560 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataCancelamento_7560", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamento" || parametro.FieldName == "pei_justificativa_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_justificativa_cancelamento LIKE :pedido_item_JustificativaCancelamento_5326 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_JustificativaCancelamento_5326", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataConfiguracao" || parametro.FieldName == "pei_data_configuracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_configuracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_configuracao = :pedido_item_DataConfiguracao_831 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataConfiguracao_831", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Urgente" || parametro.FieldName == "pei_urgente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is UrgenciaPedido)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo UrgenciaPedido");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente = :pedido_item_Urgente_9233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Urgente_9233", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UrgenteSolicitante" || parametro.FieldName == "pei_urgente_solicitante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente_solicitante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente_solicitante LIKE :pedido_item_UrgenteSolicitante_4244 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_UrgenteSolicitante_4244", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UrgenteDataPrometida" || parametro.FieldName == "pei_urgente_data_prometida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente_data_prometida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente_data_prometida = :pedido_item_UrgenteDataPrometida_1748 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_UrgenteDataPrometida_1748", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UrgenteInformacoesComplementares" || parametro.FieldName == "pei_urgente_informacoes_complementares")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente_informacoes_complementares IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente_informacoes_complementares LIKE :pedido_item_UrgenteInformacoesComplementares_7022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_UrgenteInformacoesComplementares_7022", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEntregaOriginal" || parametro.FieldName == "pei_data_entrega_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_entrega_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_entrega_original = :pedido_item_DataEntregaOriginal_1012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataEntregaOriginal_1012", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacaoEspecial" || parametro.FieldName == "pei_informacao_especial")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_informacao_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_informacao_especial LIKE :pedido_item_InformacaoEspecial_7794 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_InformacaoEspecial_7794", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RastreamentoMaterial" || parametro.FieldName == "pei_rastreamento_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_rastreamento_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_rastreamento_material = :pedido_item_RastreamentoMaterial_9358 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_RastreamentoMaterial_9358", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  pedido_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.entity_uid LIKE :pedido_item_EntityUid_7230 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_EntityUid_7230", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  pedido_item.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.version = :pedido_item_Version_3291 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Version_3291", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ContaBancaria" || parametro.FieldName == "id_conta_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ContaBancariaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ContaBancariaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_conta_bancaria = :pedido_item_ContaBancaria_7543 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ContaBancaria_7543", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CentroCustoLucro" || parametro.FieldName == "id_centro_custo_lucro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CentroCustoLucroClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CentroCustoLucroClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_centro_custo_lucro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_centro_custo_lucro = :pedido_item_CentroCustoLucro_8987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_CentroCustoLucro_8987", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaPagamento" || parametro.FieldName == "id_forma_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FormaPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FormaPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_forma_pagamento = :pedido_item_FormaPagamento_5550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_FormaPagamento_5550", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroPedidoAutomatico" || parametro.FieldName == "pei_numero_pedido_automatico")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_numero_pedido_automatico IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_numero_pedido_automatico = :pedido_item_NumeroPedidoAutomatico_3429 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_NumeroPedidoAutomatico_3429", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FormaFrete" || parametro.FieldName == "pei_forma_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is FormaFretePedido)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo FormaFretePedido");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_forma_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_forma_frete = :pedido_item_FormaFrete_542 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_FormaFrete_542", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ResponsavelFrete" || parametro.FieldName == "pei_responsavel_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ResponsavelFrete?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ResponsavelFrete?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_responsavel_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_responsavel_frete = :pedido_item_ResponsavelFrete_4718 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ResponsavelFrete_4718", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemVenda" || parametro.FieldName == "pei_ordem_venda")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_ordem_venda IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_ordem_venda LIKE :pedido_item_OrdemVenda_8934 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_OrdemVenda_8934", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Representante" || parametro.FieldName == "id_representante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.RepresentanteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.RepresentanteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_representante = :pedido_item_Representante_5976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Representante_5976", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoRepresentante" || parametro.FieldName == "pei_perc_comissao_representante")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_perc_comissao_representante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_perc_comissao_representante = :pedido_item_PercComissaoRepresentante_8265 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PercComissaoRepresentante_8265", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEncerramento" || parametro.FieldName == "pei_data_encerramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_encerramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_encerramento = :pedido_item_DataEncerramento_1842 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataEncerramento_1842", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsPadraoEspelho" || parametro.FieldName == "pei_obs_padrao_espelho")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_obs_padrao_espelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_obs_padrao_espelho LIKE :pedido_item_ObsPadraoEspelho_7285 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ObsPadraoEspelho_7285", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataUltimaAlteracao" || parametro.FieldName == "pei_data_ultima_alteracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_data_ultima_alteracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_data_ultima_alteracao = :pedido_item_DataUltimaAlteracao_7660 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_DataUltimaAlteracao_7660", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SuspensaoObs" || parametro.FieldName == "pei_suspensao_obs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_suspensao_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_suspensao_obs LIKE :pedido_item_SuspensaoObs_4151 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SuspensaoObs_4151", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AcsUsuarioResponsavelSuspensao" || parametro.FieldName == "id_acs_usuario_responsavel_suspensao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_acs_usuario_responsavel_suspensao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_acs_usuario_responsavel_suspensao = :pedido_item_AcsUsuarioResponsavelSuspensao_941 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_AcsUsuarioResponsavelSuspensao_941", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Vendedor" || parametro.FieldName == "id_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.VendedorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.VendedorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_vendedor = :pedido_item_Vendedor_9691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Vendedor_9691", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercComissaoVendedor" || parametro.FieldName == "pei_perc_comissao_vendedor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_perc_comissao_vendedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_perc_comissao_vendedor = :pedido_item_PercComissaoVendedor_463 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PercComissaoVendedor_463", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoItemPai" || parametro.FieldName == "id_pedido_item_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_pedido_item_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_pedido_item_pai = :pedido_item_PedidoItemPai_9296 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PedidoItemPai_9296", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ComissaoGerada" || parametro.FieldName == "pei_comissao_gerada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_comissao_gerada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_comissao_gerada = :pedido_item_ComissaoGerada_6596 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ComissaoGerada_6596", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoNf" || parametro.FieldName == "pei_observacao_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_observacao_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_observacao_nf LIKE :pedido_item_ObservacaoNf_534 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ObservacaoNf_534", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FaturamentoAntecipadoRealizado" || parametro.FieldName == "pei_faturamento_antecipado_realizado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_faturamento_antecipado_realizado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_faturamento_antecipado_realizado = :pedido_item_FaturamentoAntecipadoRealizado_4572 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_FaturamentoAntecipadoRealizado_4572", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipalFaturamentoAntecipado" || parametro.FieldName == "id_nf_principal_faturamento_antecipado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_nf_principal_faturamento_antecipado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_nf_principal_faturamento_antecipado = :pedido_item_NfPrincipalFaturamentoAntecipado_13 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_NfPrincipalFaturamentoAntecipado_13", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "id_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NcmClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NcmClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_ncm = :pedido_item_Ncm_2552 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Ncm_2552", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGad" || parametro.FieldName == "pei_situacao_gad")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is GadIntegracaoPedidoSituacao)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo GadIntegracaoPedidoSituacao");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_situacao_gad IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_situacao_gad = :pedido_item_SituacaoGad_4170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SituacaoGad_4170", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGadMensagem" || parametro.FieldName == "pei_situacao_gad_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_situacao_gad_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_situacao_gad_mensagem LIKE :pedido_item_SituacaoGadMensagem_7592 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SituacaoGadMensagem_7592", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Programacao" || parametro.FieldName == "id_programacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ProgramacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ProgramacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_programacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_programacao = :pedido_item_Programacao_6772 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Programacao_6772", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmissorNfe" || parametro.FieldName == "pei_emissor_nfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiEmissorNFe)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiEmissorNFe");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_emissor_nfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_emissor_nfe = :pedido_item_EmissorNfe_171 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_EmissorNfe_171", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoCompleta" || parametro.FieldName == "id_operacao_completa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoCompletaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoCompletaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_operacao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_operacao_completa = :pedido_item_OperacaoCompleta_6334 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_OperacaoCompleta_6334", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GadProgramado" || parametro.FieldName == "pei_gad_programado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_gad_programado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_gad_programado = :pedido_item_GadProgramado_2830 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_GadProgramado_2830", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GadProgramacaoNome" || parametro.FieldName == "pei_gad_programacao_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_nome LIKE :pedido_item_GadProgramacaoNome_8404 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_GadProgramacaoNome_8404", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GadProgramacaoData" || parametro.FieldName == "pei_gad_programacao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_data LIKE :pedido_item_GadProgramacaoData_322 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_GadProgramacaoData_322", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoPagamento" || parametro.FieldName == "id_tipo_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.TipoPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.TipoPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_tipo_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_tipo_pagamento = :pedido_item_TipoPagamento_4350 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_TipoPagamento_4350", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EnvioTerceiros" || parametro.FieldName == "ped_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.ped_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.ped_envio_terceiros = :pedido_item_EnvioTerceiros_4562 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_EnvioTerceiros_4562", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ClienteEnvioTerceiros" || parametro.FieldName == "id_cliente_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.ClienteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.ClienteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_cliente_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_cliente_envio_terceiros = :pedido_item_ClienteEnvioTerceiros_7881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ClienteEnvioTerceiros_7881", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoEnvioTerceiros" || parametro.FieldName == "id_operacao_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_operacao_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_operacao_envio_terceiros = :pedido_item_OperacaoEnvioTerceiros_6470 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_OperacaoEnvioTerceiros_6470", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OperacaoCompletaEnvioTerceiros" || parametro.FieldName == "id_operacao_completa_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OperacaoCompletaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OperacaoCompletaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_operacao_completa_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_operacao_completa_envio_terceiros = :pedido_item_OperacaoCompletaEnvioTerceiros_1793 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_OperacaoCompletaEnvioTerceiros_1793", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Desconto" || parametro.FieldName == "pei_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_desconto = :pedido_item_Desconto_1102 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Desconto_1102", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PedidoClassificacao" || parametro.FieldName == "id_pedido_classificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PedidoClassificacaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PedidoClassificacaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_pedido_classificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_pedido_classificacao = :pedido_item_PedidoClassificacao_6617 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_PedidoClassificacao_6617", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MeioPagamento" || parametro.FieldName == "id_meio_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.MeioPagamentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.MeioPagamentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.id_meio_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.id_meio_pagamento = :pedido_item_MeioPagamento_9811 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_MeioPagamento_9811", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  pedido_item.pei_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_numero LIKE :pedido_item_Numero_7058 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_Numero_7058", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoCodigoClienteExato" || parametro.FieldName == "ProdutoCodigoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_produto_codigo_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_produto_codigo_cliente LIKE :pedido_item_ProdutoCodigoCliente_3890 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProdutoCodigoCliente_3890", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProdutoDescricaoClienteExato" || parametro.FieldName == "ProdutoDescricaoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_produto_descricao_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_produto_descricao_cliente LIKE :pedido_item_ProdutoDescricaoCliente_542 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProdutoDescricaoCliente_542", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ProjetoClienteExato" || parametro.FieldName == "ProjetoClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_projeto_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_projeto_cliente LIKE :pedido_item_ProjetoCliente_6922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ProjetoCliente_6922", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjClienteExato" || parametro.FieldName == "CnpjClienteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_cnpj_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_cnpj_cliente LIKE :pedido_item_CnpjCliente_1766 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_CnpjCliente_1766", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_item.pei_armazenagem_cliente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_armazenagem_cliente LIKE :pedido_item_ArmazenagemCliente_5719 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ArmazenagemCliente_5719", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamentoExato" || parametro.FieldName == "JustificativaCancelamentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_justificativa_cancelamento LIKE :pedido_item_JustificativaCancelamento_8039 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_JustificativaCancelamento_8039", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UrgenteSolicitanteExato" || parametro.FieldName == "UrgenteSolicitanteExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente_solicitante IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente_solicitante LIKE :pedido_item_UrgenteSolicitante_3169 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_UrgenteSolicitante_3169", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UrgenteInformacoesComplementaresExato" || parametro.FieldName == "UrgenteInformacoesComplementaresExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_urgente_informacoes_complementares IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_urgente_informacoes_complementares LIKE :pedido_item_UrgenteInformacoesComplementares_5082 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_UrgenteInformacoesComplementares_5082", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InformacaoEspecialExato" || parametro.FieldName == "InformacaoEspecialExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_informacao_especial IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_informacao_especial LIKE :pedido_item_InformacaoEspecial_3304 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_InformacaoEspecial_3304", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  pedido_item.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.entity_uid LIKE :pedido_item_EntityUid_2056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_EntityUid_2056", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemVendaExato" || parametro.FieldName == "OrdemVendaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_ordem_venda IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_ordem_venda LIKE :pedido_item_OrdemVenda_6560 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_OrdemVenda_6560", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsPadraoEspelhoExato" || parametro.FieldName == "ObsPadraoEspelhoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_obs_padrao_espelho IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_obs_padrao_espelho LIKE :pedido_item_ObsPadraoEspelho_1715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ObsPadraoEspelho_1715", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SuspensaoObsExato" || parametro.FieldName == "SuspensaoObsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_suspensao_obs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_suspensao_obs LIKE :pedido_item_SuspensaoObs_1198 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SuspensaoObs_1198", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoNfExato" || parametro.FieldName == "ObservacaoNfExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_observacao_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_observacao_nf LIKE :pedido_item_ObservacaoNf_8824 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_ObservacaoNf_8824", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SituacaoGadMensagemExato" || parametro.FieldName == "SituacaoGadMensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_situacao_gad_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_situacao_gad_mensagem LIKE :pedido_item_SituacaoGadMensagem_2658 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_SituacaoGadMensagem_2658", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GadProgramacaoNomeExato" || parametro.FieldName == "GadProgramacaoNomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_nome LIKE :pedido_item_GadProgramacaoNome_3279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_GadProgramacaoNome_3279", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GadProgramacaoDataExato" || parametro.FieldName == "GadProgramacaoDataExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  pedido_item.pei_gad_programacao_data LIKE :pedido_item_GadProgramacaoData_4991 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("pedido_item_GadProgramacaoData_4991", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  PedidoItemClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (PedidoItemClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(PedidoItemClass), Convert.ToInt32(read["id_pedido_item"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new PedidoItemClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_pedido_item"]);
                     entidade.Numero = (read["pei_numero"] != DBNull.Value ? read["pei_numero"].ToString() : null);
                     entidade.Posicao = (int)read["pei_posicao"];
                     entidade.SubLinha = (int)read["pei_sub_linha"];
                     if (read["id_produto"] != DBNull.Value)
                     {
                        entidade.Produto = (BibliotecaEntidades.Entidades.ProdutoClass)BibliotecaEntidades.Entidades.ProdutoClass.GetEntidade(Convert.ToInt32(read["id_produto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Produto = null ;
                     }
                     entidade.ProdutoCodigoCliente = (read["pei_produto_codigo_cliente"] != DBNull.Value ? read["pei_produto_codigo_cliente"].ToString() : null);
                     entidade.ProdutoDescricaoCliente = (read["pei_produto_descricao_cliente"] != DBNull.Value ? read["pei_produto_descricao_cliente"].ToString() : null);
                     entidade.ProjetoCliente = (read["pei_projeto_cliente"] != DBNull.Value ? read["pei_projeto_cliente"].ToString() : null);
                     entidade.Quantidade = (double)read["pei_quantidade"];
                     entidade.Saldo = (double)read["pei_saldo"];
                     entidade.PrecoUnitario = (double)read["pei_preco_unitario"];
                     entidade.PrecoTotal = (double)read["pei_preco_total"];
                     if (read["id_cliente"] != DBNull.Value)
                     {
                        entidade.Cliente = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Cliente = null ;
                     }
                     entidade.CnpjCliente = (read["pei_cnpj_cliente"] != DBNull.Value ? read["pei_cnpj_cliente"].ToString() : null);
                     entidade.ArmazenagemCliente = (read["pei_armazenagem_cliente"] != DBNull.Value ? read["pei_armazenagem_cliente"].ToString() : null);
                     entidade.Frete = (double)read["pei_frete"];
                     entidade.DataEntrega = (DateTime)read["pei_data_entrega"];
                     entidade.Status = (StatusPedido) (read["pei_status"] != DBNull.Value ? Enum.ToObject(typeof(StatusPedido), read["pei_status"]) : null);
                     entidade.DataEntrada = (DateTime)read["pei_data_entrada"];
                     if (read["id_operacao"] != DBNull.Value)
                     {
                        entidade.Operacao = (BibliotecaEntidades.Entidades.OperacaoClass)BibliotecaEntidades.Entidades.OperacaoClass.GetEntidade(Convert.ToInt32(read["id_operacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Operacao = null ;
                     }
                     entidade.PermiteEntregaParcial = Convert.ToBoolean(Convert.ToInt16(read["pei_permite_entrega_parcial"]));
                     entidade.VolumeUnico = Convert.ToBoolean(Convert.ToInt16(read["pei_volume_unico"]));
                     entidade.Configurado = Convert.ToBoolean(Convert.ToInt16(read["pei_configurado"]));
                     entidade.Exportacao = Convert.ToBoolean(Convert.ToInt16(read["pei_exportacao"]));
                     entidade.PrecoTotalOriginal = (double)read["pei_preco_total_original"];
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.DataCancelamento = read["pei_data_cancelamento"] as DateTime?;
                     entidade.JustificativaCancelamento = (read["pei_justificativa_cancelamento"] != DBNull.Value ? read["pei_justificativa_cancelamento"].ToString() : null);
                     entidade.DataConfiguracao = read["pei_data_configuracao"] as DateTime?;
                     entidade.Urgente = (UrgenciaPedido) (read["pei_urgente"] != DBNull.Value ? Enum.ToObject(typeof(UrgenciaPedido), read["pei_urgente"]) : null);
                     entidade.UrgenteSolicitante = (read["pei_urgente_solicitante"] != DBNull.Value ? read["pei_urgente_solicitante"].ToString() : null);
                     entidade.UrgenteDataPrometida = read["pei_urgente_data_prometida"] as DateTime?;
                     entidade.UrgenteInformacoesComplementares = (read["pei_urgente_informacoes_complementares"] != DBNull.Value ? read["pei_urgente_informacoes_complementares"].ToString() : null);
                     entidade.DataEntregaOriginal = read["pei_data_entrega_original"] as DateTime?;
                     entidade.InformacaoEspecial = (read["pei_informacao_especial"] != DBNull.Value ? read["pei_informacao_especial"].ToString() : null);
                     entidade.RastreamentoMaterial = Convert.ToBoolean(Convert.ToInt16(read["pei_rastreamento_material"]));
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     if (read["id_centro_custo_lucro"] != DBNull.Value)
                     {
                        entidade.CentroCustoLucro = (BibliotecaEntidades.Entidades.CentroCustoLucroClass)BibliotecaEntidades.Entidades.CentroCustoLucroClass.GetEntidade(Convert.ToInt32(read["id_centro_custo_lucro"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CentroCustoLucro = null ;
                     }
                     if (read["id_forma_pagamento"] != DBNull.Value)
                     {
                        entidade.FormaPagamento = (BibliotecaEntidades.Entidades.FormaPagamentoClass)BibliotecaEntidades.Entidades.FormaPagamentoClass.GetEntidade(Convert.ToInt32(read["id_forma_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FormaPagamento = null ;
                     }
                     entidade.NumeroPedidoAutomatico = Convert.ToBoolean(Convert.ToInt16(read["pei_numero_pedido_automatico"]));
                     entidade.FormaFrete = (FormaFretePedido) (read["pei_forma_frete"] != DBNull.Value ? Enum.ToObject(typeof(FormaFretePedido), read["pei_forma_frete"]) : null);
                     entidade.ResponsavelFrete = (ResponsavelFrete?) (read["pei_responsavel_frete"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(ResponsavelFrete?)), read["pei_responsavel_frete"]) : null);
                     entidade.OrdemVenda = (read["pei_ordem_venda"] != DBNull.Value ? read["pei_ordem_venda"].ToString() : null);
                     if (read["id_representante"] != DBNull.Value)
                     {
                        entidade.Representante = (BibliotecaEntidades.Entidades.RepresentanteClass)BibliotecaEntidades.Entidades.RepresentanteClass.GetEntidade(Convert.ToInt32(read["id_representante"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Representante = null ;
                     }
                     entidade.PercComissaoRepresentante = read["pei_perc_comissao_representante"] as double?;
                     entidade.DataEncerramento = read["pei_data_encerramento"] as DateTime?;
                     entidade.ObsPadraoEspelho = (read["pei_obs_padrao_espelho"] != DBNull.Value ? read["pei_obs_padrao_espelho"].ToString() : null);
                     entidade.DataUltimaAlteracao = (DateTime)read["pei_data_ultima_alteracao"];
                     entidade.SuspensaoObs = (read["pei_suspensao_obs"] != DBNull.Value ? read["pei_suspensao_obs"].ToString() : null);
                     if (read["id_acs_usuario_responsavel_suspensao"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioResponsavelSuspensao = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_responsavel_suspensao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioResponsavelSuspensao = null ;
                     }
                     if (read["id_vendedor"] != DBNull.Value)
                     {
                        entidade.Vendedor = (BibliotecaEntidades.Entidades.VendedorClass)BibliotecaEntidades.Entidades.VendedorClass.GetEntidade(Convert.ToInt32(read["id_vendedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Vendedor = null ;
                     }
                     entidade.PercComissaoVendedor = read["pei_perc_comissao_vendedor"] as double?;
                     if (read["id_pedido_item_pai"] != DBNull.Value)
                     {
                        entidade.PedidoItemPai = (BibliotecaEntidades.Entidades.PedidoItemClass)BibliotecaEntidades.Entidades.PedidoItemClass.GetEntidade(Convert.ToInt32(read["id_pedido_item_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoItemPai = null ;
                     }
                     entidade.ComissaoGerada = Convert.ToBoolean(Convert.ToInt16(read["pei_comissao_gerada"]));
                     entidade.ObservacaoNf = (read["pei_observacao_nf"] != DBNull.Value ? read["pei_observacao_nf"].ToString() : null);
                     entidade.FaturamentoAntecipadoRealizado = Convert.ToBoolean(Convert.ToInt16(read["pei_faturamento_antecipado_realizado"]));
                     if (read["id_nf_principal_faturamento_antecipado"] != DBNull.Value)
                     {
                        entidade.NfPrincipalFaturamentoAntecipado = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal_faturamento_antecipado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipalFaturamentoAntecipado = null ;
                     }
                     if (read["id_ncm"] != DBNull.Value)
                     {
                        entidade.Ncm = (BibliotecaEntidades.Entidades.NcmClass)BibliotecaEntidades.Entidades.NcmClass.GetEntidade(Convert.ToInt32(read["id_ncm"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Ncm = null ;
                     }
                     entidade.SituacaoGad = (GadIntegracaoPedidoSituacao) (read["pei_situacao_gad"] != DBNull.Value ? Enum.ToObject(typeof(GadIntegracaoPedidoSituacao), read["pei_situacao_gad"]) : null);
                     entidade.SituacaoGadMensagem = (read["pei_situacao_gad_mensagem"] != DBNull.Value ? read["pei_situacao_gad_mensagem"].ToString() : null);
                     if (read["id_programacao"] != DBNull.Value)
                     {
                        entidade.Programacao = (BibliotecaEntidades.Entidades.ProgramacaoClass)BibliotecaEntidades.Entidades.ProgramacaoClass.GetEntidade(Convert.ToInt32(read["id_programacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Programacao = null ;
                     }
                     entidade.EmissorNfe = (EasiEmissorNFe) (read["pei_emissor_nfe"] != DBNull.Value ? Enum.ToObject(typeof(EasiEmissorNFe), read["pei_emissor_nfe"]) : null);
                     if (read["id_operacao_completa"] != DBNull.Value)
                     {
                        entidade.OperacaoCompleta = (BibliotecaEntidades.Entidades.OperacaoCompletaClass)BibliotecaEntidades.Entidades.OperacaoCompletaClass.GetEntidade(Convert.ToInt32(read["id_operacao_completa"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OperacaoCompleta = null ;
                     }
                     entidade.GadProgramado = Convert.ToBoolean(Convert.ToInt16(read["pei_gad_programado"]));
                     entidade.GadProgramacaoNome = (read["pei_gad_programacao_nome"] != DBNull.Value ? read["pei_gad_programacao_nome"].ToString() : null);
                     entidade.GadProgramacaoData = (read["pei_gad_programacao_data"] != DBNull.Value ? read["pei_gad_programacao_data"].ToString() : null);
                     if (read["id_tipo_pagamento"] != DBNull.Value)
                     {
                        entidade.TipoPagamento = (BibliotecaEntidades.Entidades.TipoPagamentoClass)BibliotecaEntidades.Entidades.TipoPagamentoClass.GetEntidade(Convert.ToInt32(read["id_tipo_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.TipoPagamento = null ;
                     }
                     entidade.EnvioTerceiros = Convert.ToBoolean(Convert.ToInt16(read["ped_envio_terceiros"]));
                     if (read["id_cliente_envio_terceiros"] != DBNull.Value)
                     {
                        entidade.ClienteEnvioTerceiros = (BibliotecaEntidades.Entidades.ClienteClass)BibliotecaEntidades.Entidades.ClienteClass.GetEntidade(Convert.ToInt32(read["id_cliente_envio_terceiros"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ClienteEnvioTerceiros = null ;
                     }
                     if (read["id_operacao_envio_terceiros"] != DBNull.Value)
                     {
                        entidade.OperacaoEnvioTerceiros = (BibliotecaEntidades.Entidades.OperacaoClass)BibliotecaEntidades.Entidades.OperacaoClass.GetEntidade(Convert.ToInt32(read["id_operacao_envio_terceiros"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OperacaoEnvioTerceiros = null ;
                     }
                     if (read["id_operacao_completa_envio_terceiros"] != DBNull.Value)
                     {
                        entidade.OperacaoCompletaEnvioTerceiros = (BibliotecaEntidades.Entidades.OperacaoCompletaClass)BibliotecaEntidades.Entidades.OperacaoCompletaClass.GetEntidade(Convert.ToInt32(read["id_operacao_completa_envio_terceiros"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OperacaoCompletaEnvioTerceiros = null ;
                     }
                     entidade.Desconto = (double)read["pei_desconto"];
                     if (read["id_pedido_classificacao"] != DBNull.Value)
                     {
                        entidade.PedidoClassificacao = (BibliotecaEntidades.Entidades.PedidoClassificacaoClass)BibliotecaEntidades.Entidades.PedidoClassificacaoClass.GetEntidade(Convert.ToInt32(read["id_pedido_classificacao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.PedidoClassificacao = null ;
                     }
                     if (read["id_meio_pagamento"] != DBNull.Value)
                     {
                        entidade.MeioPagamento = (BibliotecaEntidades.Entidades.MeioPagamentoClass)BibliotecaEntidades.Entidades.MeioPagamentoClass.GetEntidade(Convert.ToInt32(read["id_meio_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.MeioPagamento = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (PedidoItemClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
