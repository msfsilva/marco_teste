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
     [Table("cidade","cid")]
     public class CidadeBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CidadeClass";
protected const string ErroDelete = "Erro ao excluir o CidadeClass  ";
protected const string ErroSave = "Erro ao salvar o CidadeClass.";
protected const string ErroCollectionClienteClassCidade = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionClienteClassCidadeCob = "Erro ao carregar a coleção de ClienteClass.";
protected const string ErroCollectionFornecedorClassCidade = "Erro ao carregar a coleção de FornecedorClass.";
protected const string ErroCollectionFuncionarioClassCidade = "Erro ao carregar a coleção de FuncionarioClass.";
protected const string ErroCollectionRepresentanteClassCidade = "Erro ao carregar a coleção de RepresentanteClass.";
protected const string ErroCollectionTransporteClassCidade = "Erro ao carregar a coleção de TransporteClass.";
protected const string ErroCollectionVendedorClassCidade = "Erro ao carregar a coleção de VendedorClass.";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroPaisObrigatorio = "O campo Pais é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do CidadeClass.";
protected const string MensagemUtilizadoCollectionClienteClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionClienteClassCidadeCob =  "A entidade CidadeClass está sendo utilizada nos seguintes ClienteClass:";
protected const string MensagemUtilizadoCollectionFornecedorClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes FornecedorClass:";
protected const string MensagemUtilizadoCollectionFuncionarioClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes FuncionarioClass:";
protected const string MensagemUtilizadoCollectionRepresentanteClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes RepresentanteClass:";
protected const string MensagemUtilizadoCollectionTransporteClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes TransporteClass:";
protected const string MensagemUtilizadoCollectionVendedorClassCidade =  "A entidade CidadeClass está sendo utilizada nos seguintes VendedorClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CidadeClass está sendo utilizada.";
#endregion
       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("cid_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
            } 
        } 

       protected int _codigoIbgeOriginal{get;private set;}
       private int _codigoIbgeOriginalCommited{get; set;}
        private int _valueCodigoIbge;
         [Column("cid_codigo_ibge")]
        public virtual int CodigoIbge
         { 
            get { return this._valueCodigoIbge; } 
            set 
            { 
                if (this._valueCodigoIbge == value)return;
                 this._valueCodigoIbge = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.EstadoClass _estadoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstadoClass _estadoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstadoClass _valueEstado;
        [Column("id_estado", "estado", "id_estado")]
       public virtual BibliotecaEntidades.Entidades.EstadoClass Estado
        { 
           get {                 return this._valueEstado; } 
           set 
           { 
                if (this._valueEstado == value)return;
                 this._valueEstado = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.PaisClass _paisOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.PaisClass _paisOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.PaisClass _valuePais;
        [Column("id_pais", "pais", "id_pais")]
       public virtual BibliotecaEntidades.Entidades.PaisClass Pais
        { 
           get {                 return this._valuePais; } 
           set 
           { 
                if (this._valuePais == value)return;
                 this._valuePais = value; 
           } 
       } 

       private List<long> _collectionClienteClassCidadeOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassCidade 
       { 
           get { if(!_valueCollectionClienteClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassCidade();}
return this._valueCollectionClienteClassCidade; } 
           set 
           { 
               this._valueCollectionClienteClassCidade = value; 
               this._valueCollectionClienteClassCidadeLoaded = true; 
           } 
       } 

       private List<long> _collectionClienteClassCidadeCobOriginal;
       private List<Entidades.ClienteClass > _collectionClienteClassCidadeCobRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeCobLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeCobChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClienteClassCidadeCobCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClienteClass> _valueCollectionClienteClassCidadeCob { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClienteClass> CollectionClienteClassCidadeCob 
       { 
           get { if(!_valueCollectionClienteClassCidadeCobLoaded && !this.DisableLoadCollection){this.LoadCollectionClienteClassCidadeCob();}
return this._valueCollectionClienteClassCidadeCob; } 
           set 
           { 
               this._valueCollectionClienteClassCidadeCob = value; 
               this._valueCollectionClienteClassCidadeCobLoaded = true; 
           } 
       } 

       private List<long> _collectionFornecedorClassCidadeOriginal;
       private List<Entidades.FornecedorClass > _collectionFornecedorClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFornecedorClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FornecedorClass> _valueCollectionFornecedorClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FornecedorClass> CollectionFornecedorClassCidade 
       { 
           get { if(!_valueCollectionFornecedorClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionFornecedorClassCidade();}
return this._valueCollectionFornecedorClassCidade; } 
           set 
           { 
               this._valueCollectionFornecedorClassCidade = value; 
               this._valueCollectionFornecedorClassCidadeLoaded = true; 
           } 
       } 

       private List<long> _collectionFuncionarioClassCidadeOriginal;
       private List<Entidades.FuncionarioClass > _collectionFuncionarioClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFuncionarioClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FuncionarioClass> _valueCollectionFuncionarioClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FuncionarioClass> CollectionFuncionarioClassCidade 
       { 
           get { if(!_valueCollectionFuncionarioClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionFuncionarioClassCidade();}
return this._valueCollectionFuncionarioClassCidade; } 
           set 
           { 
               this._valueCollectionFuncionarioClassCidade = value; 
               this._valueCollectionFuncionarioClassCidadeLoaded = true; 
           } 
       } 

       private List<long> _collectionRepresentanteClassCidadeOriginal;
       private List<Entidades.RepresentanteClass > _collectionRepresentanteClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionRepresentanteClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.RepresentanteClass> _valueCollectionRepresentanteClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.RepresentanteClass> CollectionRepresentanteClassCidade 
       { 
           get { if(!_valueCollectionRepresentanteClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionRepresentanteClassCidade();}
return this._valueCollectionRepresentanteClassCidade; } 
           set 
           { 
               this._valueCollectionRepresentanteClassCidade = value; 
               this._valueCollectionRepresentanteClassCidadeLoaded = true; 
           } 
       } 

       private List<long> _collectionTransporteClassCidadeOriginal;
       private List<Entidades.TransporteClass > _collectionTransporteClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransporteClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransporteClass> _valueCollectionTransporteClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransporteClass> CollectionTransporteClassCidade 
       { 
           get { if(!_valueCollectionTransporteClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionTransporteClassCidade();}
return this._valueCollectionTransporteClassCidade; } 
           set 
           { 
               this._valueCollectionTransporteClassCidade = value; 
               this._valueCollectionTransporteClassCidadeLoaded = true; 
           } 
       } 

       private List<long> _collectionVendedorClassCidadeOriginal;
       private List<Entidades.VendedorClass > _collectionVendedorClassCidadeRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCidadeLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCidadeChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionVendedorClassCidadeCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.VendedorClass> _valueCollectionVendedorClassCidade { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.VendedorClass> CollectionVendedorClassCidade 
       { 
           get { if(!_valueCollectionVendedorClassCidadeLoaded && !this.DisableLoadCollection){this.LoadCollectionVendedorClassCidade();}
return this._valueCollectionVendedorClassCidade; } 
           set 
           { 
               this._valueCollectionVendedorClassCidade = value; 
               this._valueCollectionVendedorClassCidadeLoaded = true; 
           } 
       } 

        public CidadeBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static CidadeClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CidadeClass) GetEntity(typeof(CidadeClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClienteClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassCidadeChanged = true;
                  _valueCollectionClienteClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassCidadeChanged = true; 
                  _valueCollectionClienteClassCidadeCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassCidadeChanged = true; 
                  _valueCollectionClienteClassCidadeCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassCidade) 
                 { 
                     _collectionClienteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassCidadeChanged = false;
                 _valueCollectionClienteClassCidadeCommitedChanged = false;
                _collectionClienteClassCidadeRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassCidade = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassCidadeOriginal= (from a in _valueCollectionClienteClassCidade select a.ID).ToList();
                 _valueCollectionClienteClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassCidade+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionClienteClassCidadeCobChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClienteClassCidadeCobChanged = true;
                  _valueCollectionClienteClassCidadeCobCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClienteClassCidadeCobChanged = true; 
                  _valueCollectionClienteClassCidadeCobCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in e.OldItems) 
                 { 
                     _collectionClienteClassCidadeCobRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClienteClassCidadeCobChanged = true; 
                  _valueCollectionClienteClassCidadeCobCommitedChanged = true;
                 foreach (Entidades.ClienteClass item in _valueCollectionClienteClassCidadeCob) 
                 { 
                     _collectionClienteClassCidadeCobRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClienteClassCidadeCob()
         {
            try
            {
                 ObservableCollection<Entidades.ClienteClass> oc;
                _valueCollectionClienteClassCidadeCobChanged = false;
                 _valueCollectionClienteClassCidadeCobCommitedChanged = false;
                _collectionClienteClassCidadeCobRemovidos = new List<Entidades.ClienteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClienteClass>();
                }
                else{ 
                   Entidades.ClienteClass search = new Entidades.ClienteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClienteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("CidadeCob", this),                     }                       ).Cast<Entidades.ClienteClass>().ToList());
                 }
                 _valueCollectionClienteClassCidadeCob = new BindingList<Entidades.ClienteClass>(oc); 
                 _collectionClienteClassCidadeCobOriginal= (from a in _valueCollectionClienteClassCidadeCob select a.ID).ToList();
                 _valueCollectionClienteClassCidadeCobLoaded = true;
                 oc.CollectionChanged += CollectionClienteClassCidadeCobChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClienteClassCidadeCob+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFornecedorClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFornecedorClassCidadeChanged = true;
                  _valueCollectionFornecedorClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFornecedorClassCidadeChanged = true; 
                  _valueCollectionFornecedorClassCidadeCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in e.OldItems) 
                 { 
                     _collectionFornecedorClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFornecedorClassCidadeChanged = true; 
                  _valueCollectionFornecedorClassCidadeCommitedChanged = true;
                 foreach (Entidades.FornecedorClass item in _valueCollectionFornecedorClassCidade) 
                 { 
                     _collectionFornecedorClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFornecedorClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.FornecedorClass> oc;
                _valueCollectionFornecedorClassCidadeChanged = false;
                 _valueCollectionFornecedorClassCidadeCommitedChanged = false;
                _collectionFornecedorClassCidadeRemovidos = new List<Entidades.FornecedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FornecedorClass>();
                }
                else{ 
                   Entidades.FornecedorClass search = new Entidades.FornecedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FornecedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.FornecedorClass>().ToList());
                 }
                 _valueCollectionFornecedorClassCidade = new BindingList<Entidades.FornecedorClass>(oc); 
                 _collectionFornecedorClassCidadeOriginal= (from a in _valueCollectionFornecedorClassCidade select a.ID).ToList();
                 _valueCollectionFornecedorClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionFornecedorClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFornecedorClassCidade+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFuncionarioClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFuncionarioClassCidadeChanged = true;
                  _valueCollectionFuncionarioClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFuncionarioClassCidadeChanged = true; 
                  _valueCollectionFuncionarioClassCidadeCommitedChanged = true;
                 foreach (Entidades.FuncionarioClass item in e.OldItems) 
                 { 
                     _collectionFuncionarioClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFuncionarioClassCidadeChanged = true; 
                  _valueCollectionFuncionarioClassCidadeCommitedChanged = true;
                 foreach (Entidades.FuncionarioClass item in _valueCollectionFuncionarioClassCidade) 
                 { 
                     _collectionFuncionarioClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFuncionarioClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.FuncionarioClass> oc;
                _valueCollectionFuncionarioClassCidadeChanged = false;
                 _valueCollectionFuncionarioClassCidadeCommitedChanged = false;
                _collectionFuncionarioClassCidadeRemovidos = new List<Entidades.FuncionarioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FuncionarioClass>();
                }
                else{ 
                   Entidades.FuncionarioClass search = new Entidades.FuncionarioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FuncionarioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.FuncionarioClass>().ToList());
                 }
                 _valueCollectionFuncionarioClassCidade = new BindingList<Entidades.FuncionarioClass>(oc); 
                 _collectionFuncionarioClassCidadeOriginal= (from a in _valueCollectionFuncionarioClassCidade select a.ID).ToList();
                 _valueCollectionFuncionarioClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionFuncionarioClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFuncionarioClassCidade+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionRepresentanteClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionRepresentanteClassCidadeChanged = true;
                  _valueCollectionRepresentanteClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionRepresentanteClassCidadeChanged = true; 
                  _valueCollectionRepresentanteClassCidadeCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in e.OldItems) 
                 { 
                     _collectionRepresentanteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionRepresentanteClassCidadeChanged = true; 
                  _valueCollectionRepresentanteClassCidadeCommitedChanged = true;
                 foreach (Entidades.RepresentanteClass item in _valueCollectionRepresentanteClassCidade) 
                 { 
                     _collectionRepresentanteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionRepresentanteClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.RepresentanteClass> oc;
                _valueCollectionRepresentanteClassCidadeChanged = false;
                 _valueCollectionRepresentanteClassCidadeCommitedChanged = false;
                _collectionRepresentanteClassCidadeRemovidos = new List<Entidades.RepresentanteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.RepresentanteClass>();
                }
                else{ 
                   Entidades.RepresentanteClass search = new Entidades.RepresentanteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.RepresentanteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.RepresentanteClass>().ToList());
                 }
                 _valueCollectionRepresentanteClassCidade = new BindingList<Entidades.RepresentanteClass>(oc); 
                 _collectionRepresentanteClassCidadeOriginal= (from a in _valueCollectionRepresentanteClassCidade select a.ID).ToList();
                 _valueCollectionRepresentanteClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionRepresentanteClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionRepresentanteClassCidade+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransporteClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransporteClassCidadeChanged = true;
                  _valueCollectionTransporteClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransporteClassCidadeChanged = true; 
                  _valueCollectionTransporteClassCidadeCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in e.OldItems) 
                 { 
                     _collectionTransporteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransporteClassCidadeChanged = true; 
                  _valueCollectionTransporteClassCidadeCommitedChanged = true;
                 foreach (Entidades.TransporteClass item in _valueCollectionTransporteClassCidade) 
                 { 
                     _collectionTransporteClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransporteClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.TransporteClass> oc;
                _valueCollectionTransporteClassCidadeChanged = false;
                 _valueCollectionTransporteClassCidadeCommitedChanged = false;
                _collectionTransporteClassCidadeRemovidos = new List<Entidades.TransporteClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransporteClass>();
                }
                else{ 
                   Entidades.TransporteClass search = new Entidades.TransporteClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransporteClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.TransporteClass>().ToList());
                 }
                 _valueCollectionTransporteClassCidade = new BindingList<Entidades.TransporteClass>(oc); 
                 _collectionTransporteClassCidadeOriginal= (from a in _valueCollectionTransporteClassCidade select a.ID).ToList();
                 _valueCollectionTransporteClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionTransporteClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransporteClassCidade+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionVendedorClassCidadeChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionVendedorClassCidadeChanged = true;
                  _valueCollectionVendedorClassCidadeCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionVendedorClassCidadeChanged = true; 
                  _valueCollectionVendedorClassCidadeCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in e.OldItems) 
                 { 
                     _collectionVendedorClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionVendedorClassCidadeChanged = true; 
                  _valueCollectionVendedorClassCidadeCommitedChanged = true;
                 foreach (Entidades.VendedorClass item in _valueCollectionVendedorClassCidade) 
                 { 
                     _collectionVendedorClassCidadeRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionVendedorClassCidade()
         {
            try
            {
                 ObservableCollection<Entidades.VendedorClass> oc;
                _valueCollectionVendedorClassCidadeChanged = false;
                 _valueCollectionVendedorClassCidadeCommitedChanged = false;
                _collectionVendedorClassCidadeRemovidos = new List<Entidades.VendedorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.VendedorClass>();
                }
                else{ 
                   Entidades.VendedorClass search = new Entidades.VendedorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.VendedorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Cidade", this),                     }                       ).Cast<Entidades.VendedorClass>().ToList());
                 }
                 _valueCollectionVendedorClassCidade = new BindingList<Entidades.VendedorClass>(oc); 
                 _collectionVendedorClassCidadeOriginal= (from a in _valueCollectionVendedorClassCidade select a.ID).ToList();
                 _valueCollectionVendedorClassCidadeLoaded = true;
                 oc.CollectionChanged += CollectionVendedorClassCidadeChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionVendedorClassCidade+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
                }
                if ( _valuePais == null)
                {
                    throw new Exception(ErroPaisObrigatorio);
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
                    "  public.cidade  " +
                    "WHERE " +
                    "  id_cidade = :id";
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
                        "  public.cidade   " +
                        "SET  " + 
                        "  cid_nome = :cid_nome, " + 
                        "  cid_codigo_ibge = :cid_codigo_ibge, " + 
                        "  id_estado = :id_estado, " + 
                        "  version = :version, " + 
                        "  id_pais = :id_pais, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_cidade = :id " +
                        "RETURNING id_cidade;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cidade " +
                        "( " +
                        "  cid_nome , " + 
                        "  cid_codigo_ibge , " + 
                        "  id_estado , " + 
                        "  version , " + 
                        "  id_pais , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :cid_nome , " + 
                        "  :cid_codigo_ibge , " + 
                        "  :id_estado , " + 
                        "  :version , " + 
                        "  :id_pais , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_cidade;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cid_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cid_codigo_ibge", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoIbge ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_pais", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Pais==null ? (object) DBNull.Value : this.Pais.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;

 
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
 if (CollectionClienteClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassCidade+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassCidade)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionClienteClassCidadeCob.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClienteClassCidadeCob+"\r\n";
                foreach (Entidades.ClienteClass tmp in CollectionClienteClassCidadeCob)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFornecedorClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFornecedorClassCidade+"\r\n";
                foreach (Entidades.FornecedorClass tmp in CollectionFornecedorClassCidade)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFuncionarioClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFuncionarioClassCidade+"\r\n";
                foreach (Entidades.FuncionarioClass tmp in CollectionFuncionarioClassCidade)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionRepresentanteClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionRepresentanteClassCidade+"\r\n";
                foreach (Entidades.RepresentanteClass tmp in CollectionRepresentanteClassCidade)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransporteClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransporteClassCidade+"\r\n";
                foreach (Entidades.TransporteClass tmp in CollectionTransporteClassCidade)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionVendedorClassCidade.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionVendedorClassCidade+"\r\n";
                foreach (Entidades.VendedorClass tmp in CollectionVendedorClassCidade)
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
        public static CidadeClass CopiarEntidade(CidadeClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CidadeClass toRet = new CidadeClass(usuario,conn);
 toRet.Nome= entidadeCopiar.Nome;
 toRet.CodigoIbge= entidadeCopiar.CodigoIbge;
 toRet.Estado= entidadeCopiar.Estado;
 toRet.Pais= entidadeCopiar.Pais;

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
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _codigoIbgeOriginal = CodigoIbge;
       _codigoIbgeOriginalCommited = _codigoIbgeOriginal;
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _paisOriginal = Pais;
       _paisOriginalCommited = _paisOriginal;

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
       _nomeOriginalCommited = Nome;
       _codigoIbgeOriginalCommited = CodigoIbge;
       _estadoOriginalCommited = Estado;
       _versionOriginalCommited = Version;
       _paisOriginalCommited = Pais;

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
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  if (_collectionClienteClassCidadeRemovidos != null) 
                  {
                     _collectionClienteClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassCidadeRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassCidadeOriginal= (from a in _valueCollectionClienteClassCidade select a.ID).ToList();
                  _valueCollectionClienteClassCidadeChanged = false;
                  _valueCollectionClienteClassCidadeCommitedChanged = false;
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  if (_collectionClienteClassCidadeCobRemovidos != null) 
                  {
                     _collectionClienteClassCidadeCobRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClienteClassCidadeCobRemovidos = new List<Entidades.ClienteClass>();
                  }
                  _collectionClienteClassCidadeCobOriginal= (from a in _valueCollectionClienteClassCidadeCob select a.ID).ToList();
                  _valueCollectionClienteClassCidadeCobChanged = false;
                  _valueCollectionClienteClassCidadeCobCommitedChanged = false;
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  if (_collectionFornecedorClassCidadeRemovidos != null) 
                  {
                     _collectionFornecedorClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFornecedorClassCidadeRemovidos = new List<Entidades.FornecedorClass>();
                  }
                  _collectionFornecedorClassCidadeOriginal= (from a in _valueCollectionFornecedorClassCidade select a.ID).ToList();
                  _valueCollectionFornecedorClassCidadeChanged = false;
                  _valueCollectionFornecedorClassCidadeCommitedChanged = false;
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  if (_collectionFuncionarioClassCidadeRemovidos != null) 
                  {
                     _collectionFuncionarioClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFuncionarioClassCidadeRemovidos = new List<Entidades.FuncionarioClass>();
                  }
                  _collectionFuncionarioClassCidadeOriginal= (from a in _valueCollectionFuncionarioClassCidade select a.ID).ToList();
                  _valueCollectionFuncionarioClassCidadeChanged = false;
                  _valueCollectionFuncionarioClassCidadeCommitedChanged = false;
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  if (_collectionRepresentanteClassCidadeRemovidos != null) 
                  {
                     _collectionRepresentanteClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionRepresentanteClassCidadeRemovidos = new List<Entidades.RepresentanteClass>();
                  }
                  _collectionRepresentanteClassCidadeOriginal= (from a in _valueCollectionRepresentanteClassCidade select a.ID).ToList();
                  _valueCollectionRepresentanteClassCidadeChanged = false;
                  _valueCollectionRepresentanteClassCidadeCommitedChanged = false;
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  if (_collectionTransporteClassCidadeRemovidos != null) 
                  {
                     _collectionTransporteClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransporteClassCidadeRemovidos = new List<Entidades.TransporteClass>();
                  }
                  _collectionTransporteClassCidadeOriginal= (from a in _valueCollectionTransporteClassCidade select a.ID).ToList();
                  _valueCollectionTransporteClassCidadeChanged = false;
                  _valueCollectionTransporteClassCidadeCommitedChanged = false;
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  if (_collectionVendedorClassCidadeRemovidos != null) 
                  {
                     _collectionVendedorClassCidadeRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionVendedorClassCidadeRemovidos = new List<Entidades.VendedorClass>();
                  }
                  _collectionVendedorClassCidadeOriginal= (from a in _valueCollectionVendedorClassCidade select a.ID).ToList();
                  _valueCollectionVendedorClassCidadeChanged = false;
                  _valueCollectionVendedorClassCidadeCommitedChanged = false;
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
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               CodigoIbge=_codigoIbgeOriginal;
               _codigoIbgeOriginalCommited=_codigoIbgeOriginal;
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Pais=_paisOriginal;
               _paisOriginalCommited=_paisOriginal;
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  CollectionClienteClassCidade.Clear();
                  foreach(int item in _collectionClienteClassCidadeOriginal)
                  {
                    CollectionClienteClassCidade.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassCidadeRemovidos.Clear();
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  CollectionClienteClassCidadeCob.Clear();
                  foreach(int item in _collectionClienteClassCidadeCobOriginal)
                  {
                    CollectionClienteClassCidadeCob.Add(Entidades.ClienteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClienteClassCidadeCobRemovidos.Clear();
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  CollectionFornecedorClassCidade.Clear();
                  foreach(int item in _collectionFornecedorClassCidadeOriginal)
                  {
                    CollectionFornecedorClassCidade.Add(Entidades.FornecedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFornecedorClassCidadeRemovidos.Clear();
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  CollectionFuncionarioClassCidade.Clear();
                  foreach(int item in _collectionFuncionarioClassCidadeOriginal)
                  {
                    CollectionFuncionarioClassCidade.Add(Entidades.FuncionarioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFuncionarioClassCidadeRemovidos.Clear();
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  CollectionRepresentanteClassCidade.Clear();
                  foreach(int item in _collectionRepresentanteClassCidadeOriginal)
                  {
                    CollectionRepresentanteClassCidade.Add(Entidades.RepresentanteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionRepresentanteClassCidadeRemovidos.Clear();
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  CollectionTransporteClassCidade.Clear();
                  foreach(int item in _collectionTransporteClassCidadeOriginal)
                  {
                    CollectionTransporteClassCidade.Add(Entidades.TransporteClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransporteClassCidadeRemovidos.Clear();
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  CollectionVendedorClassCidade.Clear();
                  foreach(int item in _collectionVendedorClassCidadeOriginal)
                  {
                    CollectionVendedorClassCidade.Add(Entidades.VendedorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionVendedorClassCidadeRemovidos.Clear();
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
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  if (_valueCollectionClienteClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  if (_valueCollectionClienteClassCidadeCobChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  if (_valueCollectionFornecedorClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  if (_valueCollectionFuncionarioClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  if (_valueCollectionRepresentanteClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  if (_valueCollectionTransporteClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  if (_valueCollectionVendedorClassCidadeChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                   tempRet = CollectionClienteClassCidade.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                   tempRet = CollectionClienteClassCidadeCob.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                   tempRet = CollectionFornecedorClassCidade.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                   tempRet = CollectionFuncionarioClassCidade.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                   tempRet = CollectionRepresentanteClassCidade.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                   tempRet = CollectionTransporteClassCidade.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                   tempRet = CollectionVendedorClassCidade.Any(item => item.IsDirty());
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
       dirty = _nomeOriginal != Nome;
      if (dirty) return true;
       dirty = _codigoIbgeOriginal != CodigoIbge;
      if (dirty) return true;
       if (_estadoOriginal!=null)
       {
          dirty = !_estadoOriginal.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       if (_paisOriginal!=null)
       {
          dirty = !_paisOriginal.Equals(Pais);
       }
       else
       {
            dirty = Pais != null;
       }
      if (dirty) return true;

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
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  if (_valueCollectionClienteClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  if (_valueCollectionClienteClassCidadeCobCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  if (_valueCollectionFornecedorClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  if (_valueCollectionFuncionarioClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  if (_valueCollectionRepresentanteClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  if (_valueCollectionTransporteClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  if (_valueCollectionVendedorClassCidadeCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                   tempRet = CollectionClienteClassCidade.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                   tempRet = CollectionClienteClassCidadeCob.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                   tempRet = CollectionFornecedorClassCidade.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                   tempRet = CollectionFuncionarioClassCidade.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                   tempRet = CollectionRepresentanteClassCidade.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                   tempRet = CollectionTransporteClassCidade.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                   tempRet = CollectionVendedorClassCidade.Any(item => item.IsDirtyCommited());
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
       dirty = _nomeOriginalCommited != Nome;
      if (dirty) return true;
       dirty = _codigoIbgeOriginalCommited != CodigoIbge;
      if (dirty) return true;
       if (_estadoOriginalCommited!=null)
       {
          dirty = !_estadoOriginalCommited.Equals(Estado);
       }
       else
       {
            dirty = Estado != null;
       }
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       if (_paisOriginalCommited!=null)
       {
          dirty = !_paisOriginalCommited.Equals(Pais);
       }
       else
       {
            dirty = Pais != null;
       }
      if (dirty) return true;

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
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCidade)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCidadeCob)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassCidade)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  foreach(FuncionarioClass item in CollectionFuncionarioClassCidade)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassCidade)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassCidade)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassCidade)
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
             case "Nome":
                return this.Nome;
             case "CodigoIbge":
                return this.CodigoIbge;
             case "Estado":
                return this.Estado;
             case "Version":
                return this.Version;
             case "Pais":
                return this.Pais;
             case "EntityUid":
                return this.EntityUid;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Estado!=null)
                Estado.ChangeSingleConnection(newConnection);
             if (Pais!=null)
                Pais.ChangeSingleConnection(newConnection);
               if (_valueCollectionClienteClassCidadeLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCidade)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionClienteClassCidadeCobLoaded) 
               {
                  foreach(ClienteClass item in CollectionClienteClassCidadeCob)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFornecedorClassCidadeLoaded) 
               {
                  foreach(FornecedorClass item in CollectionFornecedorClassCidade)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFuncionarioClassCidadeLoaded) 
               {
                  foreach(FuncionarioClass item in CollectionFuncionarioClassCidade)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionRepresentanteClassCidadeLoaded) 
               {
                  foreach(RepresentanteClass item in CollectionRepresentanteClassCidade)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransporteClassCidadeLoaded) 
               {
                  foreach(TransporteClass item in CollectionTransporteClassCidade)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionVendedorClassCidadeLoaded) 
               {
                  foreach(VendedorClass item in CollectionVendedorClassCidade)
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
                  command.CommandText += " COUNT(cidade.id_cidade) " ;
               }
               else
               {
               command.CommandText += "cidade.id_cidade, " ;
               command.CommandText += "cidade.cid_nome, " ;
               command.CommandText += "cidade.cid_codigo_ibge, " ;
               command.CommandText += "cidade.id_estado, " ;
               command.CommandText += "cidade.version, " ;
               command.CommandText += "cidade.id_pais, " ;
               command.CommandText += "cidade.entity_uid " ;
               }
               command.CommandText += " FROM  cidade ";
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
                        orderByClause += " , cid_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cid_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cidade.id_acs_usuario_ultima_revisao ";
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
                     case "id_cidade":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cidade.id_cidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cidade.id_cidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cid_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cidade.cid_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cidade.cid_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cid_codigo_ibge":
                     case "CodigoIbge":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cidade.cid_codigo_ibge " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cidade.cid_codigo_ibge) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = cidade.id_estado ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_sigla " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_sigla) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estado_Estado.est_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estado_Estado.est_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cidade.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cidade.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_pais":
                     case "Pais":
                     command.CommandText += " LEFT JOIN pais as pais_Pais ON pais_Pais.id_pais = cidade.id_pais ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , pais_Pais.pai_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(pais_Pais.pai_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cidade.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cidade.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cid_nome")) 
                        {
                           whereClause += " OR UPPER(cidade.cid_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cidade.cid_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cidade.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cidade.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.id_cidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.id_cidade = :cidade_ID_6269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_ID_6269", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "cid_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.cid_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.cid_nome LIKE :cidade_Nome_3733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_Nome_3733", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoIbge" || parametro.FieldName == "cid_codigo_ibge")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.cid_codigo_ibge IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.cid_codigo_ibge = :cidade_CodigoIbge_1637 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_CodigoIbge_1637", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Estado" || parametro.FieldName == "id_estado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstadoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstadoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.id_estado = :cidade_Estado_5143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_Estado_5143", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cidade.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.version = :cidade_Version_3803 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_Version_3803", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pais" || parametro.FieldName == "id_pais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.PaisClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.PaisClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.id_pais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.id_pais = :cidade_Pais_8089 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_Pais_8089", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  cidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.entity_uid LIKE :cidade_EntityUid_589 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_EntityUid_589", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeExato" || parametro.FieldName == "NomeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cidade.cid_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.cid_nome LIKE :cidade_Nome_1807 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_Nome_1807", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cidade.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cidade.entity_uid LIKE :cidade_EntityUid_5364 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cidade_EntityUid_5364", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CidadeClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CidadeClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CidadeClass), Convert.ToInt32(read["id_cidade"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CidadeClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cidade"]);
                     entidade.Nome = (read["cid_nome"] != DBNull.Value ? read["cid_nome"].ToString() : null);
                     entidade.CodigoIbge = (int)read["cid_codigo_ibge"];
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     entidade.Version = (int)read["version"];
                     if (read["id_pais"] != DBNull.Value)
                     {
                        entidade.Pais = (BibliotecaEntidades.Entidades.PaisClass)BibliotecaEntidades.Entidades.PaisClass.GetEntidade(Convert.ToInt32(read["id_pais"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Pais = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CidadeClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
