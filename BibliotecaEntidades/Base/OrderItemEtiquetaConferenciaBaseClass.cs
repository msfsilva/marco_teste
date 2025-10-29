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
     [Table("order_item_etiqueta_conferencia","oic")]
     public class OrderItemEtiquetaConferenciaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrderItemEtiquetaConferenciaClass";
protected const string ErroDelete = "Erro ao excluir o OrderItemEtiquetaConferenciaClass  ";
protected const string ErroSave = "Erro ao salvar o OrderItemEtiquetaConferenciaClass.";
protected const string ErroCollectionAtendimentoClassOrderItemEtiquetaConferencia = "Erro ao carregar a coleção de AtendimentoClass.";
protected const string ErroCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaClass.";
protected const string ErroCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia = "Erro ao carregar a coleção de OrderItemEtiquetaConferenciaVolumesClass.";
protected const string ErroOrderNumberObrigatorio = "O campo OrderNumber é obrigatório";
protected const string ErroOrderNumberComprimento = "O campo OrderNumber deve ter no máximo 30 caracteres";
protected const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected const string ErroIdentificacaoEstacaoObrigatorio = "O campo IdentificacaoEstacao é obrigatório";
protected const string ErroIdentificacaoEstacaoComprimento = "O campo IdentificacaoEstacao deve ter no máximo 255 caracteres";
protected const string ErroIdentificacaoUsuarioObrigatorio = "O campo IdentificacaoUsuario é obrigatório";
protected const string ErroIdentificacaoUsuarioComprimento = "O campo IdentificacaoUsuario deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrderItemEtiquetaObrigatorio = "O campo OrderItemEtiqueta é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrderItemEtiquetaConferenciaClass.";
protected const string MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiquetaConferencia =  "A entidade OrderItemEtiquetaConferenciaClass está sendo utilizada nos seguintes AtendimentoClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai =  "A entidade OrderItemEtiquetaConferenciaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaClass:";
protected const string MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia =  "A entidade OrderItemEtiquetaConferenciaClass está sendo utilizada nos seguintes OrderItemEtiquetaConferenciaVolumesClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrderItemEtiquetaConferenciaClass está sendo utilizada.";
#endregion
       protected string _orderNumberOriginal{get;private set;}
       private string _orderNumberOriginalCommited{get; set;}
        private string _valueOrderNumber;
         [Column("oic_order_number")]
        public virtual string OrderNumber
         { 
            get { return this._valueOrderNumber; } 
            set 
            { 
                if (this._valueOrderNumber == value)return;
                 this._valueOrderNumber = value; 
            } 
        } 

       protected int _orderPosOriginal{get;private set;}
       private int _orderPosOriginalCommited{get; set;}
        private int _valueOrderPos;
         [Column("oic_order_pos")]
        public virtual int OrderPos
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
         [Column("oic_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

       protected double _quantidadeConferidaOriginal{get;private set;}
       private double _quantidadeConferidaOriginalCommited{get; set;}
        private double _valueQuantidadeConferida;
         [Column("oic_quantidade_conferida")]
        public virtual double QuantidadeConferida
         { 
            get { return this._valueQuantidadeConferida; } 
            set 
            { 
                if (this._valueQuantidadeConferida == value)return;
                 this._valueQuantidadeConferida = value; 
            } 
        } 

       protected DateTime _dataConferenciaOriginal{get;private set;}
       private DateTime _dataConferenciaOriginalCommited{get; set;}
        private DateTime _valueDataConferencia;
         [Column("oic_data_conferencia")]
        public virtual DateTime DataConferencia
         { 
            get { return this._valueDataConferencia; } 
            set 
            { 
                if (this._valueDataConferencia == value)return;
                 this._valueDataConferencia = value; 
            } 
        } 

       protected string _identificacaoEstacaoOriginal{get;private set;}
       private string _identificacaoEstacaoOriginalCommited{get; set;}
        private string _valueIdentificacaoEstacao;
         [Column("oic_identificacao_estacao")]
        public virtual string IdentificacaoEstacao
         { 
            get { return this._valueIdentificacaoEstacao; } 
            set 
            { 
                if (this._valueIdentificacaoEstacao == value)return;
                 this._valueIdentificacaoEstacao = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _orderItemEtiquetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaClass _valueOrderItemEtiqueta;
        [Column("id_order_item_etiqueta", "order_item_etiqueta", "id_order_item_etiqueta")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaClass OrderItemEtiqueta
        { 
           get {                 return this._valueOrderItemEtiqueta; } 
           set 
           { 
                if (this._valueOrderItemEtiqueta == value)return;
                 this._valueOrderItemEtiqueta = value; 
           } 
       } 

       protected string _identificacaoUsuarioOriginal{get;private set;}
       private string _identificacaoUsuarioOriginalCommited{get; set;}
        private string _valueIdentificacaoUsuario;
         [Column("oic_identificacao_usuario")]
        public virtual string IdentificacaoUsuario
         { 
            get { return this._valueIdentificacaoUsuario; } 
            set 
            { 
                if (this._valueIdentificacaoUsuario == value)return;
                 this._valueIdentificacaoUsuario = value; 
            } 
        } 

       protected bool _conferenciaPaiOriginal{get;private set;}
       private bool _conferenciaPaiOriginalCommited{get; set;}
        private bool _valueConferenciaPai;
         [Column("oic_conferencia_pai")]
        public virtual bool ConferenciaPai
         { 
            get { return this._valueConferenciaPai; } 
            set 
            { 
                if (this._valueConferenciaPai == value)return;
                 this._valueConferenciaPai = value; 
            } 
        } 

       protected int? _volumesOriginal{get;private set;}
       private int? _volumesOriginalCommited{get; set;}
        private int? _valueVolumes;
         [Column("oic_volumes")]
        public virtual int? Volumes
         { 
            get { return this._valueVolumes; } 
            set 
            { 
                if (this._valueVolumes == value)return;
                 this._valueVolumes = value; 
            } 
        } 

       protected bool _conferenciaPalletOriginal{get;private set;}
       private bool _conferenciaPalletOriginalCommited{get; set;}
        private bool _valueConferenciaPallet;
         [Column("oic_conferencia_pallet")]
        public virtual bool ConferenciaPallet
         { 
            get { return this._valueConferenciaPallet; } 
            set 
            { 
                if (this._valueConferenciaPallet == value)return;
                 this._valueConferenciaPallet = value; 
            } 
        } 

       protected short? _palletOriginal{get;private set;}
       private short? _palletOriginalCommited{get; set;}
        private short? _valuePallet;
         [Column("oic_pallet")]
        public virtual short? Pallet
         { 
            get { return this._valuePallet; } 
            set 
            { 
                if (this._valuePallet == value)return;
                 this._valuePallet = value; 
            } 
        } 

       protected long? _palletSequenciaOriginal{get;private set;}
       private long? _palletSequenciaOriginalCommited{get; set;}
        private long? _valuePalletSequencia;
         [Column("oic_pallet_sequencia")]
        public virtual long? PalletSequencia
         { 
            get { return this._valuePalletSequencia; } 
            set 
            { 
                if (this._valuePalletSequencia == value)return;
                 this._valuePalletSequencia = value; 
            } 
        } 

       protected bool _nfEmitidaOriginal{get;private set;}
       private bool _nfEmitidaOriginalCommited{get; set;}
        private bool _valueNfEmitida;
         [Column("oic_nf_emitida")]
        public virtual bool NfEmitida
         { 
            get { return this._valueNfEmitida; } 
            set 
            { 
                if (this._valueNfEmitida == value)return;
                 this._valueNfEmitida = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EmbarqueClass _embarqueOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EmbarqueClass _embarqueOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EmbarqueClass _valueEmbarque;
        [Column("id_embarque", "embarque", "id_embarque")]
       public virtual BibliotecaEntidades.Entidades.EmbarqueClass Embarque
        { 
           get {                 return this._valueEmbarque; } 
           set 
           { 
                if (this._valueEmbarque == value)return;
                 this._valueEmbarque = value; 
           } 
       } 

       protected string _conferenciaPalletUsuarioOriginal{get;private set;}
       private string _conferenciaPalletUsuarioOriginalCommited{get; set;}
        private string _valueConferenciaPalletUsuario;
         [Column("oic_conferencia_pallet_usuario")]
        public virtual string ConferenciaPalletUsuario
         { 
            get { return this._valueConferenciaPalletUsuario; } 
            set 
            { 
                if (this._valueConferenciaPalletUsuario == value)return;
                 this._valueConferenciaPalletUsuario = value; 
            } 
        } 

       protected DateTime? _conferenciaPalletDataOriginal{get;private set;}
       private DateTime? _conferenciaPalletDataOriginalCommited{get; set;}
        private DateTime? _valueConferenciaPalletData;
         [Column("oic_conferencia_pallet_data")]
        public virtual DateTime? ConferenciaPalletData
         { 
            get { return this._valueConferenciaPalletData; } 
            set 
            { 
                if (this._valueConferenciaPalletData == value)return;
                 this._valueConferenciaPalletData = value; 
            } 
        } 

       protected double _pesoUnitarioOriginal{get;private set;}
       private double _pesoUnitarioOriginalCommited{get; set;}
        private double _valuePesoUnitario;
         [Column("oic_peso_unitario")]
        public virtual double PesoUnitario
         { 
            get { return this._valuePesoUnitario; } 
            set 
            { 
                if (this._valuePesoUnitario == value)return;
                 this._valuePesoUnitario = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaPaiOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _orderItemEtiquetaConferenciaPaiOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass _valueOrderItemEtiquetaConferenciaPai;
        [Column("id_order_item_etiqueta_conferencia_pai", "order_item_etiqueta_conferencia", "id_order_item_etiqueta_conferencia")]
       public virtual BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass OrderItemEtiquetaConferenciaPai
        { 
           get {                 return this._valueOrderItemEtiquetaConferenciaPai; } 
           set 
           { 
                if (this._valueOrderItemEtiquetaConferenciaPai == value)return;
                 this._valueOrderItemEtiquetaConferenciaPai = value; 
           } 
       } 

       private List<long> _collectionAtendimentoClassOrderItemEtiquetaConferenciaOriginal;
       private List<Entidades.AtendimentoClass > _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.AtendimentoClass> _valueCollectionAtendimentoClassOrderItemEtiquetaConferencia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.AtendimentoClass> CollectionAtendimentoClassOrderItemEtiquetaConferencia 
       { 
           get { if(!_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded && !this.DisableLoadCollection){this.LoadCollectionAtendimentoClassOrderItemEtiquetaConferencia();}
return this._valueCollectionAtendimentoClassOrderItemEtiquetaConferencia; } 
           set 
           { 
               this._valueCollectionAtendimentoClassOrderItemEtiquetaConferencia = value; 
               this._valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiOriginal;
       private List<Entidades.OrderItemEtiquetaConferenciaClass > _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaConferenciaClass> _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaConferenciaClass> CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai();}
return this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai = value; 
               this._valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded = true; 
           } 
       } 

       private List<long> _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaOriginal;
       private List<Entidades.OrderItemEtiquetaConferenciaVolumesClass > _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrderItemEtiquetaConferenciaVolumesClass> _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrderItemEtiquetaConferenciaVolumesClass> CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia 
       { 
           get { if(!_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia();}
return this._valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia; } 
           set 
           { 
               this._valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia = value; 
               this._valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded = true; 
           } 
       } 

        public OrderItemEtiquetaConferenciaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ConferenciaPai = false;
           this.ConferenciaPallet = false;
           this.NfEmitida = false;
           this.PesoUnitario = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrderItemEtiquetaConferenciaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrderItemEtiquetaConferenciaClass) GetEntity(typeof(OrderItemEtiquetaConferenciaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionAtendimentoClassOrderItemEtiquetaConferenciaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged = true;
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged = true; 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in e.OldItems) 
                 { 
                     _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged = true; 
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 foreach (Entidades.AtendimentoClass item in _valueCollectionAtendimentoClassOrderItemEtiquetaConferencia) 
                 { 
                     _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionAtendimentoClassOrderItemEtiquetaConferencia()
         {
            try
            {
                 ObservableCollection<Entidades.AtendimentoClass> oc;
                _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged = false;
                 _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged = false;
                _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos = new List<Entidades.AtendimentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.AtendimentoClass>();
                }
                else{ 
                   Entidades.AtendimentoClass search = new Entidades.AtendimentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.AtendimentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiquetaConferencia", this),                     }                       ).Cast<Entidades.AtendimentoClass>().ToList());
                 }
                 _valueCollectionAtendimentoClassOrderItemEtiquetaConferencia = new BindingList<Entidades.AtendimentoClass>(oc); 
                 _collectionAtendimentoClassOrderItemEtiquetaConferenciaOriginal= (from a in _valueCollectionAtendimentoClassOrderItemEtiquetaConferencia select a.ID).ToList();
                 _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded = true;
                 oc.CollectionChanged += CollectionAtendimentoClassOrderItemEtiquetaConferenciaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionAtendimentoClassOrderItemEtiquetaConferencia+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged = true;
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaClass item in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass> oc;
                _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged = false;
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged = false;
                _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaConferenciaClass search = new Entidades.OrderItemEtiquetaConferenciaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiquetaConferenciaPai", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaConferenciaClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai = new BindingList<Entidades.OrderItemEtiquetaConferenciaClass>(oc); 
                 _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged = true;
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaVolumesClass item in e.OldItems) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged = true; 
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged = true;
                 foreach (Entidades.OrderItemEtiquetaConferenciaVolumesClass item in _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia) 
                 { 
                     _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia()
         {
            try
            {
                 ObservableCollection<Entidades.OrderItemEtiquetaConferenciaVolumesClass> oc;
                _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged = false;
                 _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged = false;
                _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaVolumesClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaVolumesClass>();
                }
                else{ 
                   Entidades.OrderItemEtiquetaConferenciaVolumesClass search = new Entidades.OrderItemEtiquetaConferenciaVolumesClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrderItemEtiquetaConferenciaVolumesClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrderItemEtiquetaConferencia", this),                     }                       ).Cast<Entidades.OrderItemEtiquetaConferenciaVolumesClass>().ToList());
                 }
                 _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia = new BindingList<Entidades.OrderItemEtiquetaConferenciaVolumesClass>(oc); 
                 _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia select a.ID).ToList();
                 _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded = true;
                 oc.CollectionChanged += CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(OrderNumber))
                {
                    throw new Exception(ErroOrderNumberObrigatorio);
                }
                if (OrderNumber.Length >30)
                {
                    throw new Exception( ErroOrderNumberComprimento);
                }
                if (string.IsNullOrEmpty(CodigoItem))
                {
                    throw new Exception(ErroCodigoItemObrigatorio);
                }
                if (CodigoItem.Length >255)
                {
                    throw new Exception( ErroCodigoItemComprimento);
                }
                if (string.IsNullOrEmpty(IdentificacaoEstacao))
                {
                    throw new Exception(ErroIdentificacaoEstacaoObrigatorio);
                }
                if (IdentificacaoEstacao.Length >255)
                {
                    throw new Exception( ErroIdentificacaoEstacaoComprimento);
                }
                if (string.IsNullOrEmpty(IdentificacaoUsuario))
                {
                    throw new Exception(ErroIdentificacaoUsuarioObrigatorio);
                }
                if (IdentificacaoUsuario.Length >255)
                {
                    throw new Exception( ErroIdentificacaoUsuarioComprimento);
                }
                if ( _valueOrderItemEtiqueta == null)
                {
                    throw new Exception(ErroOrderItemEtiquetaObrigatorio);
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
                    "  public.order_item_etiqueta_conferencia  " +
                    "WHERE " +
                    "  id_order_item_etiqueta_conferencia = :id";
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
                        "  public.order_item_etiqueta_conferencia   " +
                        "SET  " + 
                        "  oic_order_number = :oic_order_number, " + 
                        "  oic_order_pos = :oic_order_pos, " + 
                        "  oic_codigo_item = :oic_codigo_item, " + 
                        "  oic_quantidade_conferida = :oic_quantidade_conferida, " + 
                        "  oic_data_conferencia = :oic_data_conferencia, " + 
                        "  oic_identificacao_estacao = :oic_identificacao_estacao, " + 
                        "  id_order_item_etiqueta = :id_order_item_etiqueta, " + 
                        "  oic_identificacao_usuario = :oic_identificacao_usuario, " + 
                        "  oic_conferencia_pai = :oic_conferencia_pai, " + 
                        "  oic_volumes = :oic_volumes, " + 
                        "  oic_conferencia_pallet = :oic_conferencia_pallet, " + 
                        "  oic_pallet = :oic_pallet, " + 
                        "  oic_pallet_sequencia = :oic_pallet_sequencia, " + 
                        "  oic_nf_emitida = :oic_nf_emitida, " + 
                        "  id_embarque = :id_embarque, " + 
                        "  oic_conferencia_pallet_usuario = :oic_conferencia_pallet_usuario, " + 
                        "  oic_conferencia_pallet_data = :oic_conferencia_pallet_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  oic_peso_unitario = :oic_peso_unitario, " + 
                        "  id_order_item_etiqueta_conferencia_pai = :id_order_item_etiqueta_conferencia_pai "+
                        "WHERE  " +
                        "  id_order_item_etiqueta_conferencia = :id " +
                        "RETURNING id_order_item_etiqueta_conferencia;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.order_item_etiqueta_conferencia " +
                        "( " +
                        "  oic_order_number , " + 
                        "  oic_order_pos , " + 
                        "  oic_codigo_item , " + 
                        "  oic_quantidade_conferida , " + 
                        "  oic_data_conferencia , " + 
                        "  oic_identificacao_estacao , " + 
                        "  id_order_item_etiqueta , " + 
                        "  oic_identificacao_usuario , " + 
                        "  oic_conferencia_pai , " + 
                        "  oic_volumes , " + 
                        "  oic_conferencia_pallet , " + 
                        "  oic_pallet , " + 
                        "  oic_pallet_sequencia , " + 
                        "  oic_nf_emitida , " + 
                        "  id_embarque , " + 
                        "  oic_conferencia_pallet_usuario , " + 
                        "  oic_conferencia_pallet_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  oic_peso_unitario , " + 
                        "  id_order_item_etiqueta_conferencia_pai  "+
                        ")  " +
                        "VALUES ( " +
                        "  :oic_order_number , " + 
                        "  :oic_order_pos , " + 
                        "  :oic_codigo_item , " + 
                        "  :oic_quantidade_conferida , " + 
                        "  :oic_data_conferencia , " + 
                        "  :oic_identificacao_estacao , " + 
                        "  :id_order_item_etiqueta , " + 
                        "  :oic_identificacao_usuario , " + 
                        "  :oic_conferencia_pai , " + 
                        "  :oic_volumes , " + 
                        "  :oic_conferencia_pallet , " + 
                        "  :oic_pallet , " + 
                        "  :oic_pallet_sequencia , " + 
                        "  :oic_nf_emitida , " + 
                        "  :id_embarque , " + 
                        "  :oic_conferencia_pallet_usuario , " + 
                        "  :oic_conferencia_pallet_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :oic_peso_unitario , " + 
                        "  :id_order_item_etiqueta_conferencia_pai  "+
                        ")RETURNING id_order_item_etiqueta_conferencia;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_number", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderNumber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_order_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OrderPos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_quantidade_conferida", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeConferida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_data_conferencia", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataConferencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_identificacao_estacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificacaoEstacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiqueta==null ? (object) DBNull.Value : this.OrderItemEtiqueta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_identificacao_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdentificacaoUsuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pai", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaPai ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_volumes", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Volumes ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaPallet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pallet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_pallet_sequencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PalletSequencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_nf_emitida", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NfEmitida ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_embarque", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Embarque==null ? (object) DBNull.Value : this.Embarque.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pallet_usuario", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaPalletUsuario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_conferencia_pallet_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConferenciaPalletData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("oic_peso_unitario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PesoUnitario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_order_item_etiqueta_conferencia_pai", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrderItemEtiquetaConferenciaPai==null ? (object) DBNull.Value : this.OrderItemEtiquetaConferenciaPai.ID;

 
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
 if (CollectionAtendimentoClassOrderItemEtiquetaConferencia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionAtendimentoClassOrderItemEtiquetaConferencia+"\r\n";
                foreach (Entidades.AtendimentoClass tmp in CollectionAtendimentoClassOrderItemEtiquetaConferencia)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai+"\r\n";
                foreach (Entidades.OrderItemEtiquetaConferenciaClass tmp in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia+"\r\n";
                foreach (Entidades.OrderItemEtiquetaConferenciaVolumesClass tmp in CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia)
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
        public static OrderItemEtiquetaConferenciaClass CopiarEntidade(OrderItemEtiquetaConferenciaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrderItemEtiquetaConferenciaClass toRet = new OrderItemEtiquetaConferenciaClass(usuario,conn);
 toRet.OrderNumber= entidadeCopiar.OrderNumber;
 toRet.OrderPos= entidadeCopiar.OrderPos;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;
 toRet.QuantidadeConferida= entidadeCopiar.QuantidadeConferida;
 toRet.DataConferencia= entidadeCopiar.DataConferencia;
 toRet.IdentificacaoEstacao= entidadeCopiar.IdentificacaoEstacao;
 toRet.OrderItemEtiqueta= entidadeCopiar.OrderItemEtiqueta;
 toRet.IdentificacaoUsuario= entidadeCopiar.IdentificacaoUsuario;
 toRet.ConferenciaPai= entidadeCopiar.ConferenciaPai;
 toRet.Volumes= entidadeCopiar.Volumes;
 toRet.ConferenciaPallet= entidadeCopiar.ConferenciaPallet;
 toRet.Pallet= entidadeCopiar.Pallet;
 toRet.PalletSequencia= entidadeCopiar.PalletSequencia;
 toRet.NfEmitida= entidadeCopiar.NfEmitida;
 toRet.Embarque= entidadeCopiar.Embarque;
 toRet.ConferenciaPalletUsuario= entidadeCopiar.ConferenciaPalletUsuario;
 toRet.ConferenciaPalletData= entidadeCopiar.ConferenciaPalletData;
 toRet.PesoUnitario= entidadeCopiar.PesoUnitario;
 toRet.OrderItemEtiquetaConferenciaPai= entidadeCopiar.OrderItemEtiquetaConferenciaPai;

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
       _quantidadeConferidaOriginal = QuantidadeConferida;
       _quantidadeConferidaOriginalCommited = _quantidadeConferidaOriginal;
       _dataConferenciaOriginal = DataConferencia;
       _dataConferenciaOriginalCommited = _dataConferenciaOriginal;
       _identificacaoEstacaoOriginal = IdentificacaoEstacao;
       _identificacaoEstacaoOriginalCommited = _identificacaoEstacaoOriginal;
       _orderItemEtiquetaOriginal = OrderItemEtiqueta;
       _orderItemEtiquetaOriginalCommited = _orderItemEtiquetaOriginal;
       _identificacaoUsuarioOriginal = IdentificacaoUsuario;
       _identificacaoUsuarioOriginalCommited = _identificacaoUsuarioOriginal;
       _conferenciaPaiOriginal = ConferenciaPai;
       _conferenciaPaiOriginalCommited = _conferenciaPaiOriginal;
       _volumesOriginal = Volumes;
       _volumesOriginalCommited = _volumesOriginal;
       _conferenciaPalletOriginal = ConferenciaPallet;
       _conferenciaPalletOriginalCommited = _conferenciaPalletOriginal;
       _palletOriginal = Pallet;
       _palletOriginalCommited = _palletOriginal;
       _palletSequenciaOriginal = PalletSequencia;
       _palletSequenciaOriginalCommited = _palletSequenciaOriginal;
       _nfEmitidaOriginal = NfEmitida;
       _nfEmitidaOriginalCommited = _nfEmitidaOriginal;
       _embarqueOriginal = Embarque;
       _embarqueOriginalCommited = _embarqueOriginal;
       _conferenciaPalletUsuarioOriginal = ConferenciaPalletUsuario;
       _conferenciaPalletUsuarioOriginalCommited = _conferenciaPalletUsuarioOriginal;
       _conferenciaPalletDataOriginal = ConferenciaPalletData;
       _conferenciaPalletDataOriginalCommited = _conferenciaPalletDataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _pesoUnitarioOriginal = PesoUnitario;
       _pesoUnitarioOriginalCommited = _pesoUnitarioOriginal;
       _orderItemEtiquetaConferenciaPaiOriginal = OrderItemEtiquetaConferenciaPai;
       _orderItemEtiquetaConferenciaPaiOriginalCommited = _orderItemEtiquetaConferenciaPaiOriginal;

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
       _quantidadeConferidaOriginalCommited = QuantidadeConferida;
       _dataConferenciaOriginalCommited = DataConferencia;
       _identificacaoEstacaoOriginalCommited = IdentificacaoEstacao;
       _orderItemEtiquetaOriginalCommited = OrderItemEtiqueta;
       _identificacaoUsuarioOriginalCommited = IdentificacaoUsuario;
       _conferenciaPaiOriginalCommited = ConferenciaPai;
       _volumesOriginalCommited = Volumes;
       _conferenciaPalletOriginalCommited = ConferenciaPallet;
       _palletOriginalCommited = Pallet;
       _palletSequenciaOriginalCommited = PalletSequencia;
       _nfEmitidaOriginalCommited = NfEmitida;
       _embarqueOriginalCommited = Embarque;
       _conferenciaPalletUsuarioOriginalCommited = ConferenciaPalletUsuario;
       _conferenciaPalletDataOriginalCommited = ConferenciaPalletData;
       _versionOriginalCommited = Version;
       _pesoUnitarioOriginalCommited = PesoUnitario;
       _orderItemEtiquetaConferenciaPaiOriginalCommited = OrderItemEtiquetaConferenciaPai;

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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos != null) 
                  {
                     _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos = new List<Entidades.AtendimentoClass>();
                  }
                  _collectionAtendimentoClassOrderItemEtiquetaConferenciaOriginal= (from a in _valueCollectionAtendimentoClassOrderItemEtiquetaConferencia select a.ID).ToList();
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged = false;
                  _valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  if (_collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaClass>();
                  }
                  _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged = false;
                  _valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged = false;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos != null) 
                  {
                     _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos = new List<Entidades.OrderItemEtiquetaConferenciaVolumesClass>();
                  }
                  _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaOriginal= (from a in _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia select a.ID).ToList();
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged = false;
                  _valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged = false;
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
               QuantidadeConferida=_quantidadeConferidaOriginal;
               _quantidadeConferidaOriginalCommited=_quantidadeConferidaOriginal;
               DataConferencia=_dataConferenciaOriginal;
               _dataConferenciaOriginalCommited=_dataConferenciaOriginal;
               IdentificacaoEstacao=_identificacaoEstacaoOriginal;
               _identificacaoEstacaoOriginalCommited=_identificacaoEstacaoOriginal;
               OrderItemEtiqueta=_orderItemEtiquetaOriginal;
               _orderItemEtiquetaOriginalCommited=_orderItemEtiquetaOriginal;
               IdentificacaoUsuario=_identificacaoUsuarioOriginal;
               _identificacaoUsuarioOriginalCommited=_identificacaoUsuarioOriginal;
               ConferenciaPai=_conferenciaPaiOriginal;
               _conferenciaPaiOriginalCommited=_conferenciaPaiOriginal;
               Volumes=_volumesOriginal;
               _volumesOriginalCommited=_volumesOriginal;
               ConferenciaPallet=_conferenciaPalletOriginal;
               _conferenciaPalletOriginalCommited=_conferenciaPalletOriginal;
               Pallet=_palletOriginal;
               _palletOriginalCommited=_palletOriginal;
               PalletSequencia=_palletSequenciaOriginal;
               _palletSequenciaOriginalCommited=_palletSequenciaOriginal;
               NfEmitida=_nfEmitidaOriginal;
               _nfEmitidaOriginalCommited=_nfEmitidaOriginal;
               Embarque=_embarqueOriginal;
               _embarqueOriginalCommited=_embarqueOriginal;
               ConferenciaPalletUsuario=_conferenciaPalletUsuarioOriginal;
               _conferenciaPalletUsuarioOriginalCommited=_conferenciaPalletUsuarioOriginal;
               ConferenciaPalletData=_conferenciaPalletDataOriginal;
               _conferenciaPalletDataOriginalCommited=_conferenciaPalletDataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               PesoUnitario=_pesoUnitarioOriginal;
               _pesoUnitarioOriginalCommited=_pesoUnitarioOriginal;
               OrderItemEtiquetaConferenciaPai=_orderItemEtiquetaConferenciaPaiOriginal;
               _orderItemEtiquetaConferenciaPaiOriginalCommited=_orderItemEtiquetaConferenciaPaiOriginal;
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  CollectionAtendimentoClassOrderItemEtiquetaConferencia.Clear();
                  foreach(int item in _collectionAtendimentoClassOrderItemEtiquetaConferenciaOriginal)
                  {
                    CollectionAtendimentoClassOrderItemEtiquetaConferencia.Add(Entidades.AtendimentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionAtendimentoClassOrderItemEtiquetaConferenciaRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiOriginal)
                  {
                    CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai.Add(Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiRemovidos.Clear();
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Clear();
                  foreach(int item in _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaOriginal)
                  {
                    CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Add(Entidades.OrderItemEtiquetaConferenciaVolumesClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaRemovidos.Clear();
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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                   tempRet = CollectionAtendimentoClassOrderItemEtiquetaConferencia.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Any(item => item.IsDirty());
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
       dirty = _quantidadeConferidaOriginal != QuantidadeConferida;
      if (dirty) return true;
       dirty = _dataConferenciaOriginal != DataConferencia;
      if (dirty) return true;
       dirty = _identificacaoEstacaoOriginal != IdentificacaoEstacao;
      if (dirty) return true;
       if (_orderItemEtiquetaOriginal!=null)
       {
          dirty = !_orderItemEtiquetaOriginal.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _identificacaoUsuarioOriginal != IdentificacaoUsuario;
      if (dirty) return true;
       dirty = _conferenciaPaiOriginal != ConferenciaPai;
      if (dirty) return true;
       dirty = _volumesOriginal != Volumes;
      if (dirty) return true;
       dirty = _conferenciaPalletOriginal != ConferenciaPallet;
      if (dirty) return true;
       dirty = _palletOriginal != Pallet;
      if (dirty) return true;
       dirty = _palletSequenciaOriginal != PalletSequencia;
      if (dirty) return true;
       dirty = _nfEmitidaOriginal != NfEmitida;
      if (dirty) return true;
       if (_embarqueOriginal!=null)
       {
          dirty = !_embarqueOriginal.Equals(Embarque);
       }
       else
       {
            dirty = Embarque != null;
       }
      if (dirty) return true;
       dirty = _conferenciaPalletUsuarioOriginal != ConferenciaPalletUsuario;
      if (dirty) return true;
       dirty = _conferenciaPalletDataOriginal != ConferenciaPalletData;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _pesoUnitarioOriginal != PesoUnitario;
      if (dirty) return true;
       if (_orderItemEtiquetaConferenciaPaiOriginal!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaPaiOriginal.Equals(OrderItemEtiquetaConferenciaPai);
       }
       else
       {
            dirty = OrderItemEtiquetaConferenciaPai != null;
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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                   tempRet = CollectionAtendimentoClassOrderItemEtiquetaConferencia.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                   tempRet = CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia.Any(item => item.IsDirtyCommited());
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
       dirty = _quantidadeConferidaOriginalCommited != QuantidadeConferida;
      if (dirty) return true;
       dirty = _dataConferenciaOriginalCommited != DataConferencia;
      if (dirty) return true;
       dirty = _identificacaoEstacaoOriginalCommited != IdentificacaoEstacao;
      if (dirty) return true;
       if (_orderItemEtiquetaOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaOriginalCommited.Equals(OrderItemEtiqueta);
       }
       else
       {
            dirty = OrderItemEtiqueta != null;
       }
      if (dirty) return true;
       dirty = _identificacaoUsuarioOriginalCommited != IdentificacaoUsuario;
      if (dirty) return true;
       dirty = _conferenciaPaiOriginalCommited != ConferenciaPai;
      if (dirty) return true;
       dirty = _volumesOriginalCommited != Volumes;
      if (dirty) return true;
       dirty = _conferenciaPalletOriginalCommited != ConferenciaPallet;
      if (dirty) return true;
       dirty = _palletOriginalCommited != Pallet;
      if (dirty) return true;
       dirty = _palletSequenciaOriginalCommited != PalletSequencia;
      if (dirty) return true;
       dirty = _nfEmitidaOriginalCommited != NfEmitida;
      if (dirty) return true;
       if (_embarqueOriginalCommited!=null)
       {
          dirty = !_embarqueOriginalCommited.Equals(Embarque);
       }
       else
       {
            dirty = Embarque != null;
       }
      if (dirty) return true;
       dirty = _conferenciaPalletUsuarioOriginalCommited != ConferenciaPalletUsuario;
      if (dirty) return true;
       dirty = _conferenciaPalletDataOriginalCommited != ConferenciaPalletData;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _pesoUnitarioOriginalCommited != PesoUnitario;
      if (dirty) return true;
       if (_orderItemEtiquetaConferenciaPaiOriginalCommited!=null)
       {
          dirty = !_orderItemEtiquetaConferenciaPaiOriginalCommited.Equals(OrderItemEtiquetaConferenciaPai);
       }
       else
       {
            dirty = OrderItemEtiquetaConferenciaPai != null;
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
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassOrderItemEtiquetaConferencia)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaVolumesClass item in CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia)
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
             case "QuantidadeConferida":
                return this.QuantidadeConferida;
             case "DataConferencia":
                return this.DataConferencia;
             case "IdentificacaoEstacao":
                return this.IdentificacaoEstacao;
             case "OrderItemEtiqueta":
                return this.OrderItemEtiqueta;
             case "IdentificacaoUsuario":
                return this.IdentificacaoUsuario;
             case "ConferenciaPai":
                return this.ConferenciaPai;
             case "Volumes":
                return this.Volumes;
             case "ConferenciaPallet":
                return this.ConferenciaPallet;
             case "Pallet":
                return this.Pallet;
             case "PalletSequencia":
                return this.PalletSequencia;
             case "NfEmitida":
                return this.NfEmitida;
             case "Embarque":
                return this.Embarque;
             case "ConferenciaPalletUsuario":
                return this.ConferenciaPalletUsuario;
             case "ConferenciaPalletData":
                return this.ConferenciaPalletData;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "PesoUnitario":
                return this.PesoUnitario;
             case "OrderItemEtiquetaConferenciaPai":
                return this.OrderItemEtiquetaConferenciaPai;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (OrderItemEtiqueta!=null)
                OrderItemEtiqueta.ChangeSingleConnection(newConnection);
             if (Embarque!=null)
                Embarque.ChangeSingleConnection(newConnection);
             if (OrderItemEtiquetaConferenciaPai!=null)
                OrderItemEtiquetaConferenciaPai.ChangeSingleConnection(newConnection);
               if (_valueCollectionAtendimentoClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  foreach(AtendimentoClass item in CollectionAtendimentoClassOrderItemEtiquetaConferencia)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPaiLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaClass item in CollectionOrderItemEtiquetaConferenciaClassOrderItemEtiquetaConferenciaPai)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferenciaLoaded) 
               {
                  foreach(OrderItemEtiquetaConferenciaVolumesClass item in CollectionOrderItemEtiquetaConferenciaVolumesClassOrderItemEtiquetaConferencia)
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
                  command.CommandText += " COUNT(order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " ;
               }
               else
               {
               command.CommandText += "order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_order_number, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_order_pos, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_codigo_item, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_quantidade_conferida, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_data_conferencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_identificacao_estacao, " ;
               command.CommandText += "order_item_etiqueta_conferencia.id_order_item_etiqueta, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_identificacao_usuario, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_conferencia_pai, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_volumes, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_conferencia_pallet, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_pallet, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_pallet_sequencia, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_nf_emitida, " ;
               command.CommandText += "order_item_etiqueta_conferencia.id_embarque, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_conferencia_pallet_data, " ;
               command.CommandText += "order_item_etiqueta_conferencia.entity_uid, " ;
               command.CommandText += "order_item_etiqueta_conferencia.version, " ;
               command.CommandText += "order_item_etiqueta_conferencia.oic_peso_unitario, " ;
               command.CommandText += "order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia_pai " ;
               }
               command.CommandText += " FROM  order_item_etiqueta_conferencia ";
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
                        orderByClause += " , oic_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(oic_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = order_item_etiqueta_conferencia.id_acs_usuario_ultima_revisao ";
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
                     case "id_order_item_etiqueta_conferencia":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_order_number":
                     case "OrderNumber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_order_pos":
                     case "OrderPos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_quantidade_conferida":
                     case "QuantidadeConferida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_quantidade_conferida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_quantidade_conferida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_data_conferencia":
                     case "DataConferencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_data_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_data_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_identificacao_estacao":
                     case "IdentificacaoEstacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_identificacao_estacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_identificacao_estacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta":
                     case "OrderItemEtiqueta":
                     command.CommandText += " LEFT JOIN order_item_etiqueta as order_item_etiqueta_OrderItemEtiqueta ON order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta = order_item_etiqueta_conferencia.id_order_item_etiqueta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.id_order_item_etiqueta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_number " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_number) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_OrderItemEtiqueta.oie_order_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_OrderItemEtiqueta.oie_order_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_identificacao_usuario":
                     case "IdentificacaoUsuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_identificacao_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_identificacao_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_conferencia_pai":
                     case "ConferenciaPai":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_conferencia_pai " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_conferencia_pai) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_volumes":
                     case "Volumes":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_volumes " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_volumes) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_conferencia_pallet":
                     case "ConferenciaPallet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_conferencia_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_conferencia_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_pallet":
                     case "Pallet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_pallet " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_pallet) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_pallet_sequencia":
                     case "PalletSequencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_pallet_sequencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_pallet_sequencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_nf_emitida":
                     case "NfEmitida":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_nf_emitida " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_nf_emitida) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_embarque":
                     case "Embarque":
                     command.CommandText += " LEFT JOIN embarque as embarque_Embarque ON embarque_Embarque.id_embarque = order_item_etiqueta_conferencia.id_embarque ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , embarque_Embarque.id_embarque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(embarque_Embarque.id_embarque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_conferencia_pallet_usuario":
                     case "ConferenciaPalletUsuario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_conferencia_pallet_data":
                     case "ConferenciaPalletData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_conferencia_pallet_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_conferencia_pallet_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , order_item_etiqueta_conferencia.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , order_item_etiqueta_conferencia.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "oic_peso_unitario":
                     case "PesoUnitario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia.oic_peso_unitario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia.oic_peso_unitario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_order_item_etiqueta_conferencia_pai":
                     case "OrderItemEtiquetaConferenciaPai":
                     command.CommandText += " LEFT JOIN order_item_etiqueta_conferencia as order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai ON order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai.id_order_item_etiqueta_conferencia = order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia_pai ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai.id_order_item_etiqueta_conferencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai.id_order_item_etiqueta_conferencia) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oic_order_number")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.oic_order_number) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.oic_order_number) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oic_codigo_item")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.oic_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.oic_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oic_identificacao_estacao")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.oic_identificacao_estacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.oic_identificacao_estacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oic_identificacao_usuario")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.oic_identificacao_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.oic_identificacao_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("oic_conferencia_pallet_usuario")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(order_item_etiqueta_conferencia.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(order_item_etiqueta_conferencia.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_order_item_etiqueta_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia = :order_item_etiqueta_conferencia_ID_2660 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ID_2660", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderNumber" || parametro.FieldName == "oic_order_number")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_number LIKE :order_item_etiqueta_conferencia_OrderNumber_3997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_OrderNumber_3997", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderPos" || parametro.FieldName == "oic_order_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_pos = :order_item_etiqueta_conferencia_OrderPos_554 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_OrderPos_554", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "oic_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_codigo_item LIKE :order_item_etiqueta_conferencia_CodigoItem_7249 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_CodigoItem_7249", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeConferida" || parametro.FieldName == "oic_quantidade_conferida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_quantidade_conferida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_quantidade_conferida = :order_item_etiqueta_conferencia_QuantidadeConferida_8511 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_QuantidadeConferida_8511", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataConferencia" || parametro.FieldName == "oic_data_conferencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_data_conferencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_data_conferencia = :order_item_etiqueta_conferencia_DataConferencia_1403 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_DataConferencia_1403", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoEstacao" || parametro.FieldName == "oic_identificacao_estacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_estacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_estacao LIKE :order_item_etiqueta_conferencia_IdentificacaoEstacao_1715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_IdentificacaoEstacao_1715", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiqueta" || parametro.FieldName == "id_order_item_etiqueta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta = :order_item_etiqueta_conferencia_OrderItemEtiqueta_6809 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_OrderItemEtiqueta_6809", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoUsuario" || parametro.FieldName == "oic_identificacao_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_usuario LIKE :order_item_etiqueta_conferencia_IdentificacaoUsuario_425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_IdentificacaoUsuario_425", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaPai" || parametro.FieldName == "oic_conferencia_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pai = :order_item_etiqueta_conferencia_ConferenciaPai_4618 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ConferenciaPai_4618", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Volumes" || parametro.FieldName == "oic_volumes")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_volumes IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_volumes = :order_item_etiqueta_conferencia_Volumes_9053 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_Volumes_9053", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaPallet" || parametro.FieldName == "oic_conferencia_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet = :order_item_etiqueta_conferencia_ConferenciaPallet_5245 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ConferenciaPallet_5245", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pallet" || parametro.FieldName == "oic_pallet")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_pallet IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_pallet = :order_item_etiqueta_conferencia_Pallet_2999 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_Pallet_2999", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PalletSequencia" || parametro.FieldName == "oic_pallet_sequencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_pallet_sequencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_pallet_sequencia = :order_item_etiqueta_conferencia_PalletSequencia_6719 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_PalletSequencia_6719", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfEmitida" || parametro.FieldName == "oic_nf_emitida")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_nf_emitida IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_nf_emitida = :order_item_etiqueta_conferencia_NfEmitida_9519 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_NfEmitida_9519", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Embarque" || parametro.FieldName == "id_embarque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EmbarqueClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EmbarqueClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_embarque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_embarque = :order_item_etiqueta_conferencia_Embarque_4044 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_Embarque_4044", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaPalletUsuario" || parametro.FieldName == "oic_conferencia_pallet_usuario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario LIKE :order_item_etiqueta_conferencia_ConferenciaPalletUsuario_7131 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ConferenciaPalletUsuario_7131", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaPalletData" || parametro.FieldName == "oic_conferencia_pallet_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_data = :order_item_etiqueta_conferencia_ConferenciaPalletData_4351 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ConferenciaPalletData_4351", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  order_item_etiqueta_conferencia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.entity_uid LIKE :order_item_etiqueta_conferencia_EntityUid_4844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_EntityUid_4844", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  order_item_etiqueta_conferencia.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.version = :order_item_etiqueta_conferencia_Version_4064 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_Version_4064", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PesoUnitario" || parametro.FieldName == "oic_peso_unitario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_peso_unitario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_peso_unitario = :order_item_etiqueta_conferencia_PesoUnitario_9741 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_PesoUnitario_9741", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrderItemEtiquetaConferenciaPai" || parametro.FieldName == "id_order_item_etiqueta_conferencia_pai")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia_pai IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.id_order_item_etiqueta_conferencia_pai = :order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai_4196 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_OrderItemEtiquetaConferenciaPai_4196", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_number IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_order_number LIKE :order_item_etiqueta_conferencia_OrderNumber_7251 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_OrderNumber_7251", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item_etiqueta_conferencia.oic_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_codigo_item LIKE :order_item_etiqueta_conferencia_CodigoItem_5876 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_CodigoItem_5876", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoEstacaoExato" || parametro.FieldName == "IdentificacaoEstacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_estacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_estacao LIKE :order_item_etiqueta_conferencia_IdentificacaoEstacao_278 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_IdentificacaoEstacao_278", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoUsuarioExato" || parametro.FieldName == "IdentificacaoUsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_identificacao_usuario LIKE :order_item_etiqueta_conferencia_IdentificacaoUsuario_2393 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_IdentificacaoUsuario_2393", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConferenciaPalletUsuarioExato" || parametro.FieldName == "ConferenciaPalletUsuarioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.oic_conferencia_pallet_usuario LIKE :order_item_etiqueta_conferencia_ConferenciaPalletUsuario_7555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_ConferenciaPalletUsuario_7555", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  order_item_etiqueta_conferencia.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  order_item_etiqueta_conferencia.entity_uid LIKE :order_item_etiqueta_conferencia_EntityUid_8656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("order_item_etiqueta_conferencia_EntityUid_8656", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrderItemEtiquetaConferenciaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrderItemEtiquetaConferenciaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrderItemEtiquetaConferenciaClass), Convert.ToInt32(read["id_order_item_etiqueta_conferencia"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrderItemEtiquetaConferenciaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_order_item_etiqueta_conferencia"]);
                     entidade.OrderNumber = (read["oic_order_number"] != DBNull.Value ? read["oic_order_number"].ToString() : null);
                     entidade.OrderPos = (int)read["oic_order_pos"];
                     entidade.CodigoItem = (read["oic_codigo_item"] != DBNull.Value ? read["oic_codigo_item"].ToString() : null);
                     entidade.QuantidadeConferida = (double)read["oic_quantidade_conferida"];
                     entidade.DataConferencia = (DateTime)read["oic_data_conferencia"];
                     entidade.IdentificacaoEstacao = (read["oic_identificacao_estacao"] != DBNull.Value ? read["oic_identificacao_estacao"].ToString() : null);
                     if (read["id_order_item_etiqueta"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiqueta = (BibliotecaEntidades.Entidades.OrderItemEtiquetaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiqueta = null ;
                     }
                     entidade.IdentificacaoUsuario = (read["oic_identificacao_usuario"] != DBNull.Value ? read["oic_identificacao_usuario"].ToString() : null);
                     entidade.ConferenciaPai = Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pai"]));
                     entidade.Volumes = read["oic_volumes"] as int?;
                     entidade.ConferenciaPallet = Convert.ToBoolean(Convert.ToInt16(read["oic_conferencia_pallet"]));
                     entidade.Pallet = read["oic_pallet"] as short?;
                     entidade.PalletSequencia = (read["oic_pallet_sequencia"] != DBNull.Value ? (long?)Convert.ToInt64(read["oic_pallet_sequencia"]) : null);
                     entidade.NfEmitida = Convert.ToBoolean(Convert.ToInt16(read["oic_nf_emitida"]));
                     if (read["id_embarque"] != DBNull.Value)
                     {
                        entidade.Embarque = (BibliotecaEntidades.Entidades.EmbarqueClass)BibliotecaEntidades.Entidades.EmbarqueClass.GetEntidade(Convert.ToInt32(read["id_embarque"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Embarque = null ;
                     }
                     entidade.ConferenciaPalletUsuario = (read["oic_conferencia_pallet_usuario"] != DBNull.Value ? read["oic_conferencia_pallet_usuario"].ToString() : null);
                     entidade.ConferenciaPalletData = read["oic_conferencia_pallet_data"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.PesoUnitario = (double)read["oic_peso_unitario"];
                     if (read["id_order_item_etiqueta_conferencia_pai"] != DBNull.Value)
                     {
                        entidade.OrderItemEtiquetaConferenciaPai = (BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass)BibliotecaEntidades.Entidades.OrderItemEtiquetaConferenciaClass.GetEntidade(Convert.ToInt32(read["id_order_item_etiqueta_conferencia_pai"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrderItemEtiquetaConferenciaPai = null ;
                     }
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrderItemEtiquetaConferenciaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
