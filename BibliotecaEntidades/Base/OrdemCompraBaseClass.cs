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
     [Table("ordem_compra","orc")]
     public class OrdemCompraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemCompraClass";
protected const string ErroDelete = "Erro ao excluir o OrdemCompraClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemCompraClass.";
protected const string ErroCollectionOrdemCompraAprovacaoClassOrdemCompra = "Erro ao carregar a coleção de OrdemCompraAprovacaoClass.";
protected const string ErroCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra = "Erro ao carregar a coleção de OrdemCompraDocumentoEnviadoClass.";
protected const string ErroCollectionSolicitacaoCompraClassOrdemCompra = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroFornecedorObrigatorio = "O campo Fornecedor é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemCompraClass.";
protected const string MensagemUtilizadoCollectionOrdemCompraAprovacaoClassOrdemCompra =  "A entidade OrdemCompraClass está sendo utilizada nos seguintes OrdemCompraAprovacaoClass:";
protected const string MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra =  "A entidade OrdemCompraClass está sendo utilizada nos seguintes OrdemCompraDocumentoEnviadoClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraClassOrdemCompra =  "A entidade OrdemCompraClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemCompraClass está sendo utilizada.";
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

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("orc_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected StatusOrdemCompra _statusOriginal{get;private set;}
       private StatusOrdemCompra _statusOriginalCommited{get; set;}
        private StatusOrdemCompra _valueStatus;
         [Column("orc_status")]
        public virtual StatusOrdemCompra Status
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
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.Nova; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.Nova; }
         } 

        public bool Status_Enviada
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.Enviada; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.Enviada; }
         } 

        public bool Status_RecebidaParcial
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.RecebidaParcial; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.RecebidaParcial; }
         } 

        public bool Status_Recebida
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.Recebida; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.Recebida; }
         } 

        public bool Status_Cancelada
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.Cancelada; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.Cancelada; }
         } 

        public bool Status_AguardandoAprovacaoCompras
         { 
            get { return this._valueStatus == BibliotecaEntidades.Base.StatusOrdemCompra.AguardandoAprovacaoCompras; } 
            set { if (value) this._valueStatus = BibliotecaEntidades.Base.StatusOrdemCompra.AguardandoAprovacaoCompras; }
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

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("orc_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
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
         [Column("orc_data_cancelamento")]
        public virtual DateTime? DataCancelamento
         { 
            get { return this._valueDataCancelamento; } 
            set 
            { 
                if (this._valueDataCancelamento == value)return;
                 this._valueDataCancelamento = value; 
            } 
        } 

       protected TipoOrdemCompra _tipoOriginal{get;private set;}
       private TipoOrdemCompra _tipoOriginalCommited{get; set;}
        private TipoOrdemCompra _valueTipo;
         [Column("orc_tipo")]
        public virtual TipoOrdemCompra Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_OrdemCompra
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoOrdemCompra.OrdemCompra; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoOrdemCompra.OrdemCompra; }
         } 

        public bool Tipo_PedidoCotacao
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoOrdemCompra.PedidoCotacao; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoOrdemCompra.PedidoCotacao; }
         } 

       protected double _valorComImpostosOriginal{get;private set;}
       private double _valorComImpostosOriginalCommited{get; set;}
        private double _valueValorComImpostos;
         [Column("orc_valor_com_impostos")]
        public virtual double ValorComImpostos
         { 
            get { return this._valueValorComImpostos; } 
            set 
            { 
                if (this._valueValorComImpostos == value)return;
                 this._valueValorComImpostos = value; 
            } 
        } 

       protected string _rodapeOriginal{get;private set;}
       private string _rodapeOriginalCommited{get; set;}
        private string _valueRodape;
         [Column("orc_rodape")]
        public virtual string Rodape
         { 
            get { return this._valueRodape; } 
            set 
            { 
                if (this._valueRodape == value)return;
                 this._valueRodape = value; 
            } 
        } 

       protected string _msgEmailOriginal{get;private set;}
       private string _msgEmailOriginalCommited{get; set;}
        private string _valueMsgEmail;
         [Column("orc_msg_email")]
        public virtual string MsgEmail
         { 
            get { return this._valueMsgEmail; } 
            set 
            { 
                if (this._valueMsgEmail == value)return;
                 this._valueMsgEmail = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.CompradorClass _compradorOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CompradorClass _compradorOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CompradorClass _valueComprador;
        [Column("id_comprador", "comprador", "id_comprador")]
       public virtual BibliotecaEntidades.Entidades.CompradorClass Comprador
        { 
           get {                 return this._valueComprador; } 
           set 
           { 
                if (this._valueComprador == value)return;
                 this._valueComprador = value; 
           } 
       } 

       protected string _justificativaCancelamentoOriginal{get;private set;}
       private string _justificativaCancelamentoOriginalCommited{get; set;}
        private string _valueJustificativaCancelamento;
         [Column("orc_justificativa_cancelamento")]
        public virtual string JustificativaCancelamento
         { 
            get { return this._valueJustificativaCancelamento; } 
            set 
            { 
                if (this._valueJustificativaCancelamento == value)return;
                 this._valueJustificativaCancelamento = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("orc_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
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

       protected double _descontoPOriginal{get;private set;}
       private double _descontoPOriginalCommited{get; set;}
        private double _valueDescontoP;
         [Column("orc_desconto_p")]
        public virtual double DescontoP
         { 
            get { return this._valueDescontoP; } 
            set 
            { 
                if (this._valueDescontoP == value)return;
                 this._valueDescontoP = value; 
            } 
        } 

       protected double _descontoROriginal{get;private set;}
       private double _descontoROriginalCommited{get; set;}
        private double _valueDescontoR;
         [Column("orc_desconto_r")]
        public virtual double DescontoR
         { 
            get { return this._valueDescontoR; } 
            set 
            { 
                if (this._valueDescontoR == value)return;
                 this._valueDescontoR = value; 
            } 
        } 

       protected DateTime? _dataEnvioOriginal{get;private set;}
       private DateTime? _dataEnvioOriginalCommited{get; set;}
        private DateTime? _valueDataEnvio;
         [Column("orc_data_envio")]
        public virtual DateTime? DataEnvio
         { 
            get { return this._valueDataEnvio; } 
            set 
            { 
                if (this._valueDataEnvio == value)return;
                 this._valueDataEnvio = value; 
            } 
        } 

       private List<long> _collectionOrdemCompraAprovacaoClassOrdemCompraOriginal;
       private List<Entidades.OrdemCompraAprovacaoClass > _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraAprovacaoClass> _valueCollectionOrdemCompraAprovacaoClassOrdemCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraAprovacaoClass> CollectionOrdemCompraAprovacaoClassOrdemCompra 
       { 
           get { if(!_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraAprovacaoClassOrdemCompra();}
return this._valueCollectionOrdemCompraAprovacaoClassOrdemCompra; } 
           set 
           { 
               this._valueCollectionOrdemCompraAprovacaoClassOrdemCompra = value; 
               this._valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraOriginal;
       private List<Entidades.OrdemCompraDocumentoEnviadoClass > _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraDocumentoEnviadoClass> _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraDocumentoEnviadoClass> CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra 
       { 
           get { if(!_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra();}
return this._valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra; } 
           set 
           { 
               this._valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra = value; 
               this._valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraClassOrdemCompraOriginal;
       private List<Entidades.SolicitacaoCompraClass > _collectionSolicitacaoCompraClassOrdemCompraRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassOrdemCompraLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassOrdemCompraChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraClass> _valueCollectionSolicitacaoCompraClassOrdemCompra { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraClass> CollectionSolicitacaoCompraClassOrdemCompra 
       { 
           get { if(!_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraClassOrdemCompra();}
return this._valueCollectionSolicitacaoCompraClassOrdemCompra; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraClassOrdemCompra = value; 
               this._valueCollectionSolicitacaoCompraClassOrdemCompraLoaded = true; 
           } 
       } 

        public OrdemCompraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Valor = 0;
           this.Status = (StatusOrdemCompra)0;
           this.Data = Configurations.DataIndependenteClass.GetData();
           this.Tipo = (TipoOrdemCompra)1;
           this.DescontoP = 0;
           this.DescontoR = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemCompraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemCompraClass) GetEntity(typeof(OrdemCompraClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemCompraAprovacaoClassOrdemCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged = true;
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged = true; 
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.OrdemCompraAprovacaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged = true; 
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.OrdemCompraAprovacaoClass item in _valueCollectionOrdemCompraAprovacaoClassOrdemCompra) 
                 { 
                     _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraAprovacaoClassOrdemCompra()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraAprovacaoClass> oc;
                _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged = false;
                 _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged = false;
                _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos = new List<Entidades.OrdemCompraAprovacaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraAprovacaoClass>();
                }
                else{ 
                   Entidades.OrdemCompraAprovacaoClass search = new Entidades.OrdemCompraAprovacaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraAprovacaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemCompra", this),                     }                       ).Cast<Entidades.OrdemCompraAprovacaoClass>().ToList());
                 }
                 _valueCollectionOrdemCompraAprovacaoClassOrdemCompra = new BindingList<Entidades.OrdemCompraAprovacaoClass>(oc); 
                 _collectionOrdemCompraAprovacaoClassOrdemCompraOriginal= (from a in _valueCollectionOrdemCompraAprovacaoClassOrdemCompra select a.ID).ToList();
                 _valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraAprovacaoClassOrdemCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraAprovacaoClassOrdemCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged = true;
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged = true; 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.OrdemCompraDocumentoEnviadoClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged = true; 
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.OrdemCompraDocumentoEnviadoClass item in _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra) 
                 { 
                     _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass> oc;
                _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged = false;
                 _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged = false;
                _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos = new List<Entidades.OrdemCompraDocumentoEnviadoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass>();
                }
                else{ 
                   Entidades.OrdemCompraDocumentoEnviadoClass search = new Entidades.OrdemCompraDocumentoEnviadoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraDocumentoEnviadoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemCompra", this),                     }                       ).Cast<Entidades.OrdemCompraDocumentoEnviadoClass>().ToList());
                 }
                 _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra = new BindingList<Entidades.OrdemCompraDocumentoEnviadoClass>(oc); 
                 _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraOriginal= (from a in _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra select a.ID).ToList();
                 _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraClassOrdemCompraChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraClassOrdemCompraChanged = true;
                  _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraClassOrdemCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraClassOrdemCompraChanged = true; 
                  _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in _valueCollectionSolicitacaoCompraClassOrdemCompra) 
                 { 
                     _collectionSolicitacaoCompraClassOrdemCompraRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraClassOrdemCompra()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraClass> oc;
                _valueCollectionSolicitacaoCompraClassOrdemCompraChanged = false;
                 _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged = false;
                _collectionSolicitacaoCompraClassOrdemCompraRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraClass search = new Entidades.SolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemCompra", this),                     }                       ).Cast<Entidades.SolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraClassOrdemCompra = new BindingList<Entidades.SolicitacaoCompraClass>(oc); 
                 _collectionSolicitacaoCompraClassOrdemCompraOriginal= (from a in _valueCollectionSolicitacaoCompraClassOrdemCompra select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraClassOrdemCompraLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraClassOrdemCompraChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraClassOrdemCompra+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
                }
                if ( _valueFornecedor == null)
                {
                    throw new Exception(ErroFornecedorObrigatorio);
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
                    "  public.ordem_compra  " +
                    "WHERE " +
                    "  id_ordem_compra = :id";
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
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  id_comprador = :id_comprador, " + 
                        "  orc_justificativa_cancelamento = :orc_justificativa_cancelamento, " + 
                        "  orc_observacao = :orc_observacao, " + 
                        "  id_forma_pagamento = :id_forma_pagamento, " + 
                        "  orc_desconto_p = :orc_desconto_p, " + 
                        "  orc_desconto_r = :orc_desconto_r, " + 
                        "  orc_data_envio = :orc_data_envio "+
                        "WHERE  " +
                        "  id_ordem_compra = :id " +
                        "RETURNING id_ordem_compra;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_compra " +
                        "( " +
                        "  id_acs_usuario , " + 
                        "  orc_valor , " + 
                        "  orc_status , " + 
                        "  id_fornecedor , " + 
                        "  orc_data , " + 
                        "  id_acs_usuario_cancelamento , " + 
                        "  orc_data_cancelamento , " + 
                        "  orc_tipo , " + 
                        "  orc_valor_com_impostos , " + 
                        "  orc_rodape , " + 
                        "  orc_msg_email , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  id_comprador , " + 
                        "  orc_justificativa_cancelamento , " + 
                        "  orc_observacao , " + 
                        "  id_forma_pagamento , " + 
                        "  orc_desconto_p , " + 
                        "  orc_desconto_r , " + 
                        "  orc_data_envio  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_acs_usuario , " + 
                        "  :orc_valor , " + 
                        "  :orc_status , " + 
                        "  :id_fornecedor , " + 
                        "  :orc_data , " + 
                        "  :id_acs_usuario_cancelamento , " + 
                        "  :orc_data_cancelamento , " + 
                        "  :orc_tipo , " + 
                        "  :orc_valor_com_impostos , " + 
                        "  :orc_rodape , " + 
                        "  :orc_msg_email , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :id_comprador , " + 
                        "  :orc_justificativa_cancelamento , " + 
                        "  :orc_observacao , " + 
                        "  :id_forma_pagamento , " + 
                        "  :orc_desconto_p , " + 
                        "  :orc_desconto_r , " + 
                        "  :orc_data_envio  "+
                        ")RETURNING id_ordem_compra;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_status", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Status);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_fornecedor", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Fornecedor==null ? (object) DBNull.Value : this.Fornecedor.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_cancelamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuarioCancelamento==null ? (object) DBNull.Value : this.AcsUsuarioCancelamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_cancelamento", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_valor_com_impostos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorComImpostos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_rodape", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Rodape ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_msg_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MsgEmail ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_comprador", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Comprador==null ? (object) DBNull.Value : this.Comprador.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_justificativa_cancelamento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.JustificativaCancelamento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_forma_pagamento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.FormaPagamento==null ? (object) DBNull.Value : this.FormaPagamento.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_desconto_p", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescontoP ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_desconto_r", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DescontoR ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("orc_data_envio", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataEnvio ?? DBNull.Value;

 
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
 if (CollectionOrdemCompraAprovacaoClassOrdemCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraAprovacaoClassOrdemCompra+"\r\n";
                foreach (Entidades.OrdemCompraAprovacaoClass tmp in CollectionOrdemCompraAprovacaoClassOrdemCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra+"\r\n";
                foreach (Entidades.OrdemCompraDocumentoEnviadoClass tmp in CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraClassOrdemCompra.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassOrdemCompra+"\r\n";
                foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassOrdemCompra)
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
        public static OrdemCompraClass CopiarEntidade(OrdemCompraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemCompraClass toRet = new OrdemCompraClass(usuario,conn);
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.Status= entidadeCopiar.Status;
 toRet.Fornecedor= entidadeCopiar.Fornecedor;
 toRet.Data= entidadeCopiar.Data;
 toRet.AcsUsuarioCancelamento= entidadeCopiar.AcsUsuarioCancelamento;
 toRet.DataCancelamento= entidadeCopiar.DataCancelamento;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.ValorComImpostos= entidadeCopiar.ValorComImpostos;
 toRet.Rodape= entidadeCopiar.Rodape;
 toRet.MsgEmail= entidadeCopiar.MsgEmail;
 toRet.Comprador= entidadeCopiar.Comprador;
 toRet.JustificativaCancelamento= entidadeCopiar.JustificativaCancelamento;
 toRet.Observacao= entidadeCopiar.Observacao;
 toRet.FormaPagamento= entidadeCopiar.FormaPagamento;
 toRet.DescontoP= entidadeCopiar.DescontoP;
 toRet.DescontoR= entidadeCopiar.DescontoR;
 toRet.DataEnvio= entidadeCopiar.DataEnvio;

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
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _fornecedorOriginal = Fornecedor;
       _fornecedorOriginalCommited = _fornecedorOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _acsUsuarioCancelamentoOriginal = AcsUsuarioCancelamento;
       _acsUsuarioCancelamentoOriginalCommited = _acsUsuarioCancelamentoOriginal;
       _dataCancelamentoOriginal = DataCancelamento;
       _dataCancelamentoOriginalCommited = _dataCancelamentoOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _valorComImpostosOriginal = ValorComImpostos;
       _valorComImpostosOriginalCommited = _valorComImpostosOriginal;
       _rodapeOriginal = Rodape;
       _rodapeOriginalCommited = _rodapeOriginal;
       _msgEmailOriginal = MsgEmail;
       _msgEmailOriginalCommited = _msgEmailOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _compradorOriginal = Comprador;
       _compradorOriginalCommited = _compradorOriginal;
       _justificativaCancelamentoOriginal = JustificativaCancelamento;
       _justificativaCancelamentoOriginalCommited = _justificativaCancelamentoOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;
       _formaPagamentoOriginal = FormaPagamento;
       _formaPagamentoOriginalCommited = _formaPagamentoOriginal;
       _descontoPOriginal = DescontoP;
       _descontoPOriginalCommited = _descontoPOriginal;
       _descontoROriginal = DescontoR;
       _descontoROriginalCommited = _descontoROriginal;
       _dataEnvioOriginal = DataEnvio;
       _dataEnvioOriginalCommited = _dataEnvioOriginal;

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
       _valorOriginalCommited = Valor;
       _statusOriginalCommited = Status;
       _fornecedorOriginalCommited = Fornecedor;
       _dataOriginalCommited = Data;
       _acsUsuarioCancelamentoOriginalCommited = AcsUsuarioCancelamento;
       _dataCancelamentoOriginalCommited = DataCancelamento;
       _tipoOriginalCommited = Tipo;
       _valorComImpostosOriginalCommited = ValorComImpostos;
       _rodapeOriginalCommited = Rodape;
       _msgEmailOriginalCommited = MsgEmail;
       _versionOriginalCommited = Version;
       _compradorOriginalCommited = Comprador;
       _justificativaCancelamentoOriginalCommited = JustificativaCancelamento;
       _observacaoOriginalCommited = Observacao;
       _formaPagamentoOriginalCommited = FormaPagamento;
       _descontoPOriginalCommited = DescontoP;
       _descontoROriginalCommited = DescontoR;
       _dataEnvioOriginalCommited = DataEnvio;

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
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  if (_collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos != null) 
                  {
                     _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos = new List<Entidades.OrdemCompraAprovacaoClass>();
                  }
                  _collectionOrdemCompraAprovacaoClassOrdemCompraOriginal= (from a in _valueCollectionOrdemCompraAprovacaoClassOrdemCompra select a.ID).ToList();
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged = false;
                  _valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged = false;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  if (_collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos != null) 
                  {
                     _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos = new List<Entidades.OrdemCompraDocumentoEnviadoClass>();
                  }
                  _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraOriginal= (from a in _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompra select a.ID).ToList();
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged = false;
                  _valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  if (_collectionSolicitacaoCompraClassOrdemCompraRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraClassOrdemCompraRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraClassOrdemCompraRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                  }
                  _collectionSolicitacaoCompraClassOrdemCompraOriginal= (from a in _valueCollectionSolicitacaoCompraClassOrdemCompra select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraClassOrdemCompraChanged = false;
                  _valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged = false;
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
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               Fornecedor=_fornecedorOriginal;
               _fornecedorOriginalCommited=_fornecedorOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               AcsUsuarioCancelamento=_acsUsuarioCancelamentoOriginal;
               _acsUsuarioCancelamentoOriginalCommited=_acsUsuarioCancelamentoOriginal;
               DataCancelamento=_dataCancelamentoOriginal;
               _dataCancelamentoOriginalCommited=_dataCancelamentoOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               ValorComImpostos=_valorComImpostosOriginal;
               _valorComImpostosOriginalCommited=_valorComImpostosOriginal;
               Rodape=_rodapeOriginal;
               _rodapeOriginalCommited=_rodapeOriginal;
               MsgEmail=_msgEmailOriginal;
               _msgEmailOriginalCommited=_msgEmailOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Comprador=_compradorOriginal;
               _compradorOriginalCommited=_compradorOriginal;
               JustificativaCancelamento=_justificativaCancelamentoOriginal;
               _justificativaCancelamentoOriginalCommited=_justificativaCancelamentoOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               FormaPagamento=_formaPagamentoOriginal;
               _formaPagamentoOriginalCommited=_formaPagamentoOriginal;
               DescontoP=_descontoPOriginal;
               _descontoPOriginalCommited=_descontoPOriginal;
               DescontoR=_descontoROriginal;
               _descontoROriginalCommited=_descontoROriginal;
               DataEnvio=_dataEnvioOriginal;
               _dataEnvioOriginalCommited=_dataEnvioOriginal;
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  CollectionOrdemCompraAprovacaoClassOrdemCompra.Clear();
                  foreach(int item in _collectionOrdemCompraAprovacaoClassOrdemCompraOriginal)
                  {
                    CollectionOrdemCompraAprovacaoClassOrdemCompra.Add(Entidades.OrdemCompraAprovacaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraAprovacaoClassOrdemCompraRemovidos.Clear();
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra.Clear();
                  foreach(int item in _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraOriginal)
                  {
                    CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra.Add(Entidades.OrdemCompraDocumentoEnviadoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraDocumentoEnviadoClassOrdemCompraRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  CollectionSolicitacaoCompraClassOrdemCompra.Clear();
                  foreach(int item in _collectionSolicitacaoCompraClassOrdemCompraOriginal)
                  {
                    CollectionSolicitacaoCompraClassOrdemCompra.Add(Entidades.SolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraClassOrdemCompraRemovidos.Clear();
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
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassOrdemCompraChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionOrdemCompraAprovacaoClassOrdemCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassOrdemCompra.Any(item => item.IsDirty());
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
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
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
       dirty = _dataOriginal != Data;
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
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _valorComImpostosOriginal != ValorComImpostos;
      if (dirty) return true;
       dirty = _rodapeOriginal != Rodape;
      if (dirty) return true;
       dirty = _msgEmailOriginal != MsgEmail;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_compradorOriginal!=null)
       {
          dirty = !_compradorOriginal.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginal != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;
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
       dirty = _descontoPOriginal != DescontoP;
      if (dirty) return true;
       dirty = _descontoROriginal != DescontoR;
      if (dirty) return true;
       dirty = _dataEnvioOriginal != DataEnvio;

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
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassOrdemCompraCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionOrdemCompraAprovacaoClassOrdemCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassOrdemCompra.Any(item => item.IsDirtyCommited());
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
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
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
       dirty = _dataOriginalCommited != Data;
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
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _valorComImpostosOriginalCommited != ValorComImpostos;
      if (dirty) return true;
       dirty = _rodapeOriginalCommited != Rodape;
      if (dirty) return true;
       dirty = _msgEmailOriginalCommited != MsgEmail;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_compradorOriginalCommited!=null)
       {
          dirty = !_compradorOriginalCommited.Equals(Comprador);
       }
       else
       {
            dirty = Comprador != null;
       }
      if (dirty) return true;
       dirty = _justificativaCancelamentoOriginalCommited != JustificativaCancelamento;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;
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
       dirty = _descontoPOriginalCommited != DescontoP;
      if (dirty) return true;
       dirty = _descontoROriginalCommited != DescontoR;
      if (dirty) return true;
       dirty = _dataEnvioOriginalCommited != DataEnvio;

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
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  foreach(OrdemCompraAprovacaoClass item in CollectionOrdemCompraAprovacaoClassOrdemCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  foreach(OrdemCompraDocumentoEnviadoClass item in CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassOrdemCompra)
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
             case "Valor":
                return this.Valor;
             case "Status":
                return this.Status;
             case "Fornecedor":
                return this.Fornecedor;
             case "Data":
                return this.Data;
             case "AcsUsuarioCancelamento":
                return this.AcsUsuarioCancelamento;
             case "DataCancelamento":
                return this.DataCancelamento;
             case "Tipo":
                return this.Tipo;
             case "ValorComImpostos":
                return this.ValorComImpostos;
             case "Rodape":
                return this.Rodape;
             case "MsgEmail":
                return this.MsgEmail;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Comprador":
                return this.Comprador;
             case "JustificativaCancelamento":
                return this.JustificativaCancelamento;
             case "Observacao":
                return this.Observacao;
             case "FormaPagamento":
                return this.FormaPagamento;
             case "DescontoP":
                return this.DescontoP;
             case "DescontoR":
                return this.DescontoR;
             case "DataEnvio":
                return this.DataEnvio;
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
             if (AcsUsuarioCancelamento!=null)
                AcsUsuarioCancelamento.ChangeSingleConnection(newConnection);
             if (Comprador!=null)
                Comprador.ChangeSingleConnection(newConnection);
             if (FormaPagamento!=null)
                FormaPagamento.ChangeSingleConnection(newConnection);
               if (_valueCollectionOrdemCompraAprovacaoClassOrdemCompraLoaded) 
               {
                  foreach(OrdemCompraAprovacaoClass item in CollectionOrdemCompraAprovacaoClassOrdemCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemCompraDocumentoEnviadoClassOrdemCompraLoaded) 
               {
                  foreach(OrdemCompraDocumentoEnviadoClass item in CollectionOrdemCompraDocumentoEnviadoClassOrdemCompra)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassOrdemCompraLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassOrdemCompra)
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
                  command.CommandText += " COUNT(ordem_compra.id_ordem_compra) " ;
               }
               else
               {
               command.CommandText += "ordem_compra.id_ordem_compra, " ;
               command.CommandText += "ordem_compra.id_acs_usuario, " ;
               command.CommandText += "ordem_compra.orc_valor, " ;
               command.CommandText += "ordem_compra.orc_status, " ;
               command.CommandText += "ordem_compra.id_fornecedor, " ;
               command.CommandText += "ordem_compra.orc_data, " ;
               command.CommandText += "ordem_compra.id_acs_usuario_cancelamento, " ;
               command.CommandText += "ordem_compra.orc_data_cancelamento, " ;
               command.CommandText += "ordem_compra.orc_tipo, " ;
               command.CommandText += "ordem_compra.orc_valor_com_impostos, " ;
               command.CommandText += "ordem_compra.orc_rodape, " ;
               command.CommandText += "ordem_compra.orc_msg_email, " ;
               command.CommandText += "ordem_compra.entity_uid, " ;
               command.CommandText += "ordem_compra.version, " ;
               command.CommandText += "ordem_compra.id_comprador, " ;
               command.CommandText += "ordem_compra.orc_justificativa_cancelamento, " ;
               command.CommandText += "ordem_compra.orc_observacao, " ;
               command.CommandText += "ordem_compra.id_forma_pagamento, " ;
               command.CommandText += "ordem_compra.orc_desconto_p, " ;
               command.CommandText += "ordem_compra.orc_desconto_r, " ;
               command.CommandText += "ordem_compra.orc_data_envio " ;
               }
               command.CommandText += " FROM  ordem_compra ";
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
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_compra.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_compra":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.id_ordem_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.id_ordem_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , ordem_compra.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orc_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_fornecedor":
                     case "Fornecedor":
                     command.CommandText += " LEFT JOIN fornecedor as fornecedor_Fornecedor ON fornecedor_Fornecedor.id_fornecedor = ordem_compra.id_fornecedor ";                     switch (parametro.TipoOrdenacao)
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
                     case "orc_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_cancelamento":
                     case "AcsUsuarioCancelamento":
                     orderByClause += " , ordem_compra.id_acs_usuario_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "orc_data_cancelamento":
                     case "DataCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_data_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_data_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_valor_com_impostos":
                     case "ValorComImpostos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_valor_com_impostos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_valor_com_impostos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_rodape":
                     case "Rodape":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra.orc_rodape " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra.orc_rodape) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_msg_email":
                     case "MsgEmail":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra.orc_msg_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra.orc_msg_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_compra.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_comprador":
                     case "Comprador":
                     command.CommandText += " LEFT JOIN comprador as comprador_Comprador ON comprador_Comprador.id_comprador = ordem_compra.id_comprador ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador_Comprador.com_apelido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador_Comprador.com_apelido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_justificativa_cancelamento":
                     case "JustificativaCancelamento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra.orc_justificativa_cancelamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra.orc_justificativa_cancelamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_compra.orc_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_compra.orc_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_forma_pagamento":
                     case "FormaPagamento":
                     command.CommandText += " LEFT JOIN forma_pagamento as forma_pagamento_FormaPagamento ON forma_pagamento_FormaPagamento.id_forma_pagamento = ordem_compra.id_forma_pagamento ";                     switch (parametro.TipoOrdenacao)
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
                     case "orc_desconto_p":
                     case "DescontoP":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_desconto_p " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_desconto_p) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_desconto_r":
                     case "DescontoR":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_desconto_r " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_desconto_r) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "orc_data_envio":
                     case "DataEnvio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_compra.orc_data_envio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_compra.orc_data_envio) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_rodape")) 
                        {
                           whereClause += " OR UPPER(ordem_compra.orc_rodape) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra.orc_rodape) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_msg_email")) 
                        {
                           whereClause += " OR UPPER(ordem_compra.orc_msg_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra.orc_msg_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_compra.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_justificativa_cancelamento")) 
                        {
                           whereClause += " OR UPPER(ordem_compra.orc_justificativa_cancelamento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra.orc_justificativa_cancelamento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("orc_observacao")) 
                        {
                           whereClause += " OR UPPER(ordem_compra.orc_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_compra.orc_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.id_ordem_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_ordem_compra = :ordem_compra_ID_8057 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_ID_8057", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  ordem_compra.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_acs_usuario = :ordem_compra_AcsUsuario_305 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_AcsUsuario_305", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "orc_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_valor = :ordem_compra_Valor_9980 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Valor_9980", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "orc_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is StatusOrdemCompra)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo StatusOrdemCompra");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_status = :ordem_compra_Status_579 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Status_579", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_compra.id_fornecedor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_fornecedor = :ordem_compra_Fornecedor_4606 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Fornecedor_4606", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "orc_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_data = :ordem_compra_Data_6992 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Data_6992", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  ordem_compra.id_acs_usuario_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_acs_usuario_cancelamento = :ordem_compra_AcsUsuarioCancelamento_2978 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_AcsUsuarioCancelamento_2978", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCancelamento" || parametro.FieldName == "orc_data_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_data_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_data_cancelamento = :ordem_compra_DataCancelamento_4446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_DataCancelamento_4446", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "orc_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoOrdemCompra)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoOrdemCompra");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_tipo = :ordem_compra_Tipo_2344 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Tipo_2344", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorComImpostos" || parametro.FieldName == "orc_valor_com_impostos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_valor_com_impostos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_valor_com_impostos = :ordem_compra_ValorComImpostos_7984 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_ValorComImpostos_7984", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Rodape" || parametro.FieldName == "orc_rodape")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_rodape IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_rodape LIKE :ordem_compra_Rodape_1453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Rodape_1453", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MsgEmail" || parametro.FieldName == "orc_msg_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_msg_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_msg_email LIKE :ordem_compra_MsgEmail_4801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_MsgEmail_4801", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.entity_uid LIKE :ordem_compra_EntityUid_7107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_EntityUid_7107", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_compra.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.version = :ordem_compra_Version_8045 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Version_8045", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Comprador" || parametro.FieldName == "id_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CompradorClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CompradorClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_comprador = :ordem_compra_Comprador_1727 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Comprador_1727", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaCancelamento" || parametro.FieldName == "orc_justificativa_cancelamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_justificativa_cancelamento LIKE :ordem_compra_JustificativaCancelamento_61 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_JustificativaCancelamento_61", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "orc_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_observacao LIKE :ordem_compra_Observacao_1696 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Observacao_1696", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_compra.id_forma_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.id_forma_pagamento = :ordem_compra_FormaPagamento_3556 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_FormaPagamento_3556", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescontoP" || parametro.FieldName == "orc_desconto_p")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_desconto_p IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_desconto_p = :ordem_compra_DescontoP_6147 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_DescontoP_6147", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescontoR" || parametro.FieldName == "orc_desconto_r")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_desconto_r IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_desconto_r = :ordem_compra_DescontoR_1981 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_DescontoR_1981", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataEnvio" || parametro.FieldName == "orc_data_envio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_data_envio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_data_envio = :ordem_compra_DataEnvio_4473 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_DataEnvio_4473", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RodapeExato" || parametro.FieldName == "RodapeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_rodape IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_rodape LIKE :ordem_compra_Rodape_3425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Rodape_3425", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MsgEmailExato" || parametro.FieldName == "MsgEmailExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_compra.orc_msg_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_msg_email LIKE :ordem_compra_MsgEmail_6755 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_MsgEmail_6755", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.entity_uid LIKE :ordem_compra_EntityUid_1678 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_EntityUid_1678", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_compra.orc_justificativa_cancelamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_justificativa_cancelamento LIKE :ordem_compra_JustificativaCancelamento_916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_JustificativaCancelamento_916", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_compra.orc_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_compra.orc_observacao LIKE :ordem_compra_Observacao_1430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_compra_Observacao_1430", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemCompraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemCompraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemCompraClass), Convert.ToInt32(read["id_ordem_compra"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemCompraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_compra"]);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Valor = (double)read["orc_valor"];
                     entidade.Status = (StatusOrdemCompra) (read["orc_status"] != DBNull.Value ? Enum.ToObject(typeof(StatusOrdemCompra), read["orc_status"]) : null);
                     if (read["id_fornecedor"] != DBNull.Value)
                     {
                        entidade.Fornecedor = (BibliotecaEntidades.Entidades.FornecedorClass)BibliotecaEntidades.Entidades.FornecedorClass.GetEntidade(Convert.ToInt32(read["id_fornecedor"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Fornecedor = null ;
                     }
                     entidade.Data = (DateTime)read["orc_data"];
                     if (read["id_acs_usuario_cancelamento"] != DBNull.Value)
                     {
                        entidade.AcsUsuarioCancelamento = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_cancelamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuarioCancelamento = null ;
                     }
                     entidade.DataCancelamento = read["orc_data_cancelamento"] as DateTime?;
                     entidade.Tipo = (TipoOrdemCompra) (read["orc_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoOrdemCompra), read["orc_tipo"]) : null);
                     entidade.ValorComImpostos = (double)read["orc_valor_com_impostos"];
                     entidade.Rodape = (read["orc_rodape"] != DBNull.Value ? read["orc_rodape"].ToString() : null);
                     entidade.MsgEmail = (read["orc_msg_email"] != DBNull.Value ? read["orc_msg_email"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     if (read["id_comprador"] != DBNull.Value)
                     {
                        entidade.Comprador = (BibliotecaEntidades.Entidades.CompradorClass)BibliotecaEntidades.Entidades.CompradorClass.GetEntidade(Convert.ToInt32(read["id_comprador"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Comprador = null ;
                     }
                     entidade.JustificativaCancelamento = (read["orc_justificativa_cancelamento"] != DBNull.Value ? read["orc_justificativa_cancelamento"].ToString() : null);
                     entidade.Observacao = (read["orc_observacao"] != DBNull.Value ? read["orc_observacao"].ToString() : null);
                     if (read["id_forma_pagamento"] != DBNull.Value)
                     {
                        entidade.FormaPagamento = (BibliotecaEntidades.Entidades.FormaPagamentoClass)BibliotecaEntidades.Entidades.FormaPagamentoClass.GetEntidade(Convert.ToInt32(read["id_forma_pagamento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.FormaPagamento = null ;
                     }
                     entidade.DescontoP = (double)read["orc_desconto_p"];
                     entidade.DescontoR = (double)read["orc_desconto_r"];
                     entidade.DataEnvio = read["orc_data_envio"] as DateTime?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemCompraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
