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
     [Table("comprador","com")]
     public class CompradorBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CompradorClass";
protected const string ErroDelete = "Erro ao excluir o CompradorClass  ";
protected const string ErroSave = "Erro ao salvar o CompradorClass.";
protected const string ErroCollectionClassificacaoProdutoClassComprador = "Erro ao carregar a coleção de ClassificacaoProdutoClass.";
protected const string ErroCollectionFamiliaMaterialClassComprador = "Erro ao carregar a coleção de FamiliaMaterialClass.";
protected const string ErroCollectionMaterialClassComprador = "Erro ao carregar a coleção de MaterialClass.";
protected const string ErroCollectionOrdemCompraClassComprador = "Erro ao carregar a coleção de OrdemCompraClass.";
protected const string ErroCollectionProdutoClassComprador = "Erro ao carregar a coleção de ProdutoClass.";
protected const string ErroApelidoObrigatorio = "O campo Apelido é obrigatório";
protected const string ErroApelidoComprimento = "O campo Apelido deve ter no máximo 255 caracteres";
protected const string ErroNomeObrigatorio = "O campo Nome é obrigatório";
protected const string ErroNomeComprimento = "O campo Nome deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do CompradorClass.";
protected const string MensagemUtilizadoCollectionClassificacaoProdutoClassComprador =  "A entidade CompradorClass está sendo utilizada nos seguintes ClassificacaoProdutoClass:";
protected const string MensagemUtilizadoCollectionFamiliaMaterialClassComprador =  "A entidade CompradorClass está sendo utilizada nos seguintes FamiliaMaterialClass:";
protected const string MensagemUtilizadoCollectionMaterialClassComprador =  "A entidade CompradorClass está sendo utilizada nos seguintes MaterialClass:";
protected const string MensagemUtilizadoCollectionOrdemCompraClassComprador =  "A entidade CompradorClass está sendo utilizada nos seguintes OrdemCompraClass:";
protected const string MensagemUtilizadoCollectionProdutoClassComprador =  "A entidade CompradorClass está sendo utilizada nos seguintes ProdutoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CompradorClass está sendo utilizada.";
#endregion
       protected string _apelidoOriginal{get;private set;}
       private string _apelidoOriginalCommited{get; set;}
        private string _valueApelido;
         [Column("com_apelido")]
        public virtual string Apelido
         { 
            get { return this._valueApelido; } 
            set 
            { 
                if (this._valueApelido == value)return;
                 this._valueApelido = value; 
            } 
        } 

       protected string _nomeOriginal{get;private set;}
       private string _nomeOriginalCommited{get; set;}
        private string _valueNome;
         [Column("com_nome")]
        public virtual string Nome
         { 
            get { return this._valueNome; } 
            set 
            { 
                if (this._valueNome == value)return;
                 this._valueNome = value; 
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

       protected string _emailOriginal{get;private set;}
       private string _emailOriginalCommited{get; set;}
        private string _valueEmail;
         [Column("com_email")]
        public virtual string Email
         { 
            get { return this._valueEmail; } 
            set 
            { 
                if (this._valueEmail == value)return;
                 this._valueEmail = value; 
            } 
        } 

       protected string _foneOriginal{get;private set;}
       private string _foneOriginalCommited{get; set;}
        private string _valueFone;
         [Column("com_fone")]
        public virtual string Fone
         { 
            get { return this._valueFone; } 
            set 
            { 
                if (this._valueFone == value)return;
                 this._valueFone = value; 
            } 
        } 

       protected string _ramalOriginal{get;private set;}
       private string _ramalOriginalCommited{get; set;}
        private string _valueRamal;
         [Column("com_ramal")]
        public virtual string Ramal
         { 
            get { return this._valueRamal; } 
            set 
            { 
                if (this._valueRamal == value)return;
                 this._valueRamal = value; 
            } 
        } 

       protected string _observacaoOriginal{get;private set;}
       private string _observacaoOriginalCommited{get; set;}
        private string _valueObservacao;
         [Column("com_observacao")]
        public virtual string Observacao
         { 
            get { return this._valueObservacao; } 
            set 
            { 
                if (this._valueObservacao == value)return;
                 this._valueObservacao = value; 
            } 
        } 

       private List<long> _collectionClassificacaoProdutoClassCompradorOriginal;
       private List<Entidades.ClassificacaoProdutoClass > _collectionClassificacaoProdutoClassCompradorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClassificacaoProdutoClassCompradorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClassificacaoProdutoClassCompradorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ClassificacaoProdutoClass> _valueCollectionClassificacaoProdutoClassComprador { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ClassificacaoProdutoClass> CollectionClassificacaoProdutoClassComprador 
       { 
           get { if(!_valueCollectionClassificacaoProdutoClassCompradorLoaded && !this.DisableLoadCollection){this.LoadCollectionClassificacaoProdutoClassComprador();}
return this._valueCollectionClassificacaoProdutoClassComprador; } 
           set 
           { 
               this._valueCollectionClassificacaoProdutoClassComprador = value; 
               this._valueCollectionClassificacaoProdutoClassCompradorLoaded = true; 
           } 
       } 

       private List<long> _collectionFamiliaMaterialClassCompradorOriginal;
       private List<Entidades.FamiliaMaterialClass > _collectionFamiliaMaterialClassCompradorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassCompradorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassCompradorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFamiliaMaterialClassCompradorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FamiliaMaterialClass> _valueCollectionFamiliaMaterialClassComprador { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FamiliaMaterialClass> CollectionFamiliaMaterialClassComprador 
       { 
           get { if(!_valueCollectionFamiliaMaterialClassCompradorLoaded && !this.DisableLoadCollection){this.LoadCollectionFamiliaMaterialClassComprador();}
return this._valueCollectionFamiliaMaterialClassComprador; } 
           set 
           { 
               this._valueCollectionFamiliaMaterialClassComprador = value; 
               this._valueCollectionFamiliaMaterialClassCompradorLoaded = true; 
           } 
       } 

       private List<long> _collectionMaterialClassCompradorOriginal;
       private List<Entidades.MaterialClass > _collectionMaterialClassCompradorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassCompradorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassCompradorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionMaterialClassCompradorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.MaterialClass> _valueCollectionMaterialClassComprador { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.MaterialClass> CollectionMaterialClassComprador 
       { 
           get { if(!_valueCollectionMaterialClassCompradorLoaded && !this.DisableLoadCollection){this.LoadCollectionMaterialClassComprador();}
return this._valueCollectionMaterialClassComprador; } 
           set 
           { 
               this._valueCollectionMaterialClassComprador = value; 
               this._valueCollectionMaterialClassCompradorLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemCompraClassCompradorOriginal;
       private List<Entidades.OrdemCompraClass > _collectionOrdemCompraClassCompradorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassCompradorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassCompradorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemCompraClassCompradorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemCompraClass> _valueCollectionOrdemCompraClassComprador { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemCompraClass> CollectionOrdemCompraClassComprador 
       { 
           get { if(!_valueCollectionOrdemCompraClassCompradorLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemCompraClassComprador();}
return this._valueCollectionOrdemCompraClassComprador; } 
           set 
           { 
               this._valueCollectionOrdemCompraClassComprador = value; 
               this._valueCollectionOrdemCompraClassCompradorLoaded = true; 
           } 
       } 

       private List<long> _collectionProdutoClassCompradorOriginal;
       private List<Entidades.ProdutoClass > _collectionProdutoClassCompradorRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassCompradorLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassCompradorChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionProdutoClassCompradorCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ProdutoClass> _valueCollectionProdutoClassComprador { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ProdutoClass> CollectionProdutoClassComprador 
       { 
           get { if(!_valueCollectionProdutoClassCompradorLoaded && !this.DisableLoadCollection){this.LoadCollectionProdutoClassComprador();}
return this._valueCollectionProdutoClassComprador; } 
           set 
           { 
               this._valueCollectionProdutoClassComprador = value; 
               this._valueCollectionProdutoClassCompradorLoaded = true; 
           } 
       } 

        public CompradorBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static CompradorClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CompradorClass) GetEntity(typeof(CompradorClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionClassificacaoProdutoClassCompradorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionClassificacaoProdutoClassCompradorChanged = true;
                  _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionClassificacaoProdutoClassCompradorChanged = true; 
                  _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged = true;
                 foreach (Entidades.ClassificacaoProdutoClass item in e.OldItems) 
                 { 
                     _collectionClassificacaoProdutoClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionClassificacaoProdutoClassCompradorChanged = true; 
                  _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged = true;
                 foreach (Entidades.ClassificacaoProdutoClass item in _valueCollectionClassificacaoProdutoClassComprador) 
                 { 
                     _collectionClassificacaoProdutoClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionClassificacaoProdutoClassComprador()
         {
            try
            {
                 ObservableCollection<Entidades.ClassificacaoProdutoClass> oc;
                _valueCollectionClassificacaoProdutoClassCompradorChanged = false;
                 _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged = false;
                _collectionClassificacaoProdutoClassCompradorRemovidos = new List<Entidades.ClassificacaoProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ClassificacaoProdutoClass>();
                }
                else{ 
                   Entidades.ClassificacaoProdutoClass search = new Entidades.ClassificacaoProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ClassificacaoProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Comprador", this),                     }                       ).Cast<Entidades.ClassificacaoProdutoClass>().ToList());
                 }
                 _valueCollectionClassificacaoProdutoClassComprador = new BindingList<Entidades.ClassificacaoProdutoClass>(oc); 
                 _collectionClassificacaoProdutoClassCompradorOriginal= (from a in _valueCollectionClassificacaoProdutoClassComprador select a.ID).ToList();
                 _valueCollectionClassificacaoProdutoClassCompradorLoaded = true;
                 oc.CollectionChanged += CollectionClassificacaoProdutoClassCompradorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionClassificacaoProdutoClassComprador+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFamiliaMaterialClassCompradorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFamiliaMaterialClassCompradorChanged = true;
                  _valueCollectionFamiliaMaterialClassCompradorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFamiliaMaterialClassCompradorChanged = true; 
                  _valueCollectionFamiliaMaterialClassCompradorCommitedChanged = true;
                 foreach (Entidades.FamiliaMaterialClass item in e.OldItems) 
                 { 
                     _collectionFamiliaMaterialClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFamiliaMaterialClassCompradorChanged = true; 
                  _valueCollectionFamiliaMaterialClassCompradorCommitedChanged = true;
                 foreach (Entidades.FamiliaMaterialClass item in _valueCollectionFamiliaMaterialClassComprador) 
                 { 
                     _collectionFamiliaMaterialClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFamiliaMaterialClassComprador()
         {
            try
            {
                 ObservableCollection<Entidades.FamiliaMaterialClass> oc;
                _valueCollectionFamiliaMaterialClassCompradorChanged = false;
                 _valueCollectionFamiliaMaterialClassCompradorCommitedChanged = false;
                _collectionFamiliaMaterialClassCompradorRemovidos = new List<Entidades.FamiliaMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FamiliaMaterialClass>();
                }
                else{ 
                   Entidades.FamiliaMaterialClass search = new Entidades.FamiliaMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FamiliaMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Comprador", this),                     }                       ).Cast<Entidades.FamiliaMaterialClass>().ToList());
                 }
                 _valueCollectionFamiliaMaterialClassComprador = new BindingList<Entidades.FamiliaMaterialClass>(oc); 
                 _collectionFamiliaMaterialClassCompradorOriginal= (from a in _valueCollectionFamiliaMaterialClassComprador select a.ID).ToList();
                 _valueCollectionFamiliaMaterialClassCompradorLoaded = true;
                 oc.CollectionChanged += CollectionFamiliaMaterialClassCompradorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFamiliaMaterialClassComprador+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionMaterialClassCompradorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionMaterialClassCompradorChanged = true;
                  _valueCollectionMaterialClassCompradorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionMaterialClassCompradorChanged = true; 
                  _valueCollectionMaterialClassCompradorCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in e.OldItems) 
                 { 
                     _collectionMaterialClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionMaterialClassCompradorChanged = true; 
                  _valueCollectionMaterialClassCompradorCommitedChanged = true;
                 foreach (Entidades.MaterialClass item in _valueCollectionMaterialClassComprador) 
                 { 
                     _collectionMaterialClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionMaterialClassComprador()
         {
            try
            {
                 ObservableCollection<Entidades.MaterialClass> oc;
                _valueCollectionMaterialClassCompradorChanged = false;
                 _valueCollectionMaterialClassCompradorCommitedChanged = false;
                _collectionMaterialClassCompradorRemovidos = new List<Entidades.MaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.MaterialClass>();
                }
                else{ 
                   Entidades.MaterialClass search = new Entidades.MaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.MaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Comprador", this),                     }                       ).Cast<Entidades.MaterialClass>().ToList());
                 }
                 _valueCollectionMaterialClassComprador = new BindingList<Entidades.MaterialClass>(oc); 
                 _collectionMaterialClassCompradorOriginal= (from a in _valueCollectionMaterialClassComprador select a.ID).ToList();
                 _valueCollectionMaterialClassCompradorLoaded = true;
                 oc.CollectionChanged += CollectionMaterialClassCompradorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionMaterialClassComprador+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemCompraClassCompradorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemCompraClassCompradorChanged = true;
                  _valueCollectionOrdemCompraClassCompradorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemCompraClassCompradorChanged = true; 
                  _valueCollectionOrdemCompraClassCompradorCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in e.OldItems) 
                 { 
                     _collectionOrdemCompraClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemCompraClassCompradorChanged = true; 
                  _valueCollectionOrdemCompraClassCompradorCommitedChanged = true;
                 foreach (Entidades.OrdemCompraClass item in _valueCollectionOrdemCompraClassComprador) 
                 { 
                     _collectionOrdemCompraClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemCompraClassComprador()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemCompraClass> oc;
                _valueCollectionOrdemCompraClassCompradorChanged = false;
                 _valueCollectionOrdemCompraClassCompradorCommitedChanged = false;
                _collectionOrdemCompraClassCompradorRemovidos = new List<Entidades.OrdemCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemCompraClass>();
                }
                else{ 
                   Entidades.OrdemCompraClass search = new Entidades.OrdemCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Comprador", this),                     }                       ).Cast<Entidades.OrdemCompraClass>().ToList());
                 }
                 _valueCollectionOrdemCompraClassComprador = new BindingList<Entidades.OrdemCompraClass>(oc); 
                 _collectionOrdemCompraClassCompradorOriginal= (from a in _valueCollectionOrdemCompraClassComprador select a.ID).ToList();
                 _valueCollectionOrdemCompraClassCompradorLoaded = true;
                 oc.CollectionChanged += CollectionOrdemCompraClassCompradorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemCompraClassComprador+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionProdutoClassCompradorChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionProdutoClassCompradorChanged = true;
                  _valueCollectionProdutoClassCompradorCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionProdutoClassCompradorChanged = true; 
                  _valueCollectionProdutoClassCompradorCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in e.OldItems) 
                 { 
                     _collectionProdutoClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionProdutoClassCompradorChanged = true; 
                  _valueCollectionProdutoClassCompradorCommitedChanged = true;
                 foreach (Entidades.ProdutoClass item in _valueCollectionProdutoClassComprador) 
                 { 
                     _collectionProdutoClassCompradorRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionProdutoClassComprador()
         {
            try
            {
                 ObservableCollection<Entidades.ProdutoClass> oc;
                _valueCollectionProdutoClassCompradorChanged = false;
                 _valueCollectionProdutoClassCompradorCommitedChanged = false;
                _collectionProdutoClassCompradorRemovidos = new List<Entidades.ProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ProdutoClass>();
                }
                else{ 
                   Entidades.ProdutoClass search = new Entidades.ProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Comprador", this),                     }                       ).Cast<Entidades.ProdutoClass>().ToList());
                 }
                 _valueCollectionProdutoClassComprador = new BindingList<Entidades.ProdutoClass>(oc); 
                 _collectionProdutoClassCompradorOriginal= (from a in _valueCollectionProdutoClassComprador select a.ID).ToList();
                 _valueCollectionProdutoClassCompradorLoaded = true;
                 oc.CollectionChanged += CollectionProdutoClassCompradorChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionProdutoClassComprador+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Apelido))
                {
                    throw new Exception(ErroApelidoObrigatorio);
                }
                if (Apelido.Length >255)
                {
                    throw new Exception( ErroApelidoComprimento);
                }
                if (string.IsNullOrEmpty(Nome))
                {
                    throw new Exception(ErroNomeObrigatorio);
                }
                if (Nome.Length >255)
                {
                    throw new Exception( ErroNomeComprimento);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
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
                    "  public.comprador  " +
                    "WHERE " +
                    "  id_comprador = :id";
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
                        "  public.comprador   " +
                        "SET  " + 
                        "  com_apelido = :com_apelido, " + 
                        "  com_nome = :com_nome, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  com_email = :com_email, " + 
                        "  com_fone = :com_fone, " + 
                        "  com_ramal = :com_ramal, " + 
                        "  com_observacao = :com_observacao "+
                        "WHERE  " +
                        "  id_comprador = :id " +
                        "RETURNING id_comprador;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.comprador " +
                        "( " +
                        "  com_apelido , " + 
                        "  com_nome , " + 
                        "  id_acs_usuario , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  com_email , " + 
                        "  com_fone , " + 
                        "  com_ramal , " + 
                        "  com_observacao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :com_apelido , " + 
                        "  :com_nome , " + 
                        "  :id_acs_usuario , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :com_email , " + 
                        "  :com_fone , " + 
                        "  :com_ramal , " + 
                        "  :com_observacao  "+
                        ")RETURNING id_comprador;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_apelido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Apelido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_nome", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Nome ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_email", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Email ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_fone", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Fone ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_ramal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ramal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("com_observacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Observacao ?? DBNull.Value;

 
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
 if (CollectionClassificacaoProdutoClassComprador.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionClassificacaoProdutoClassComprador+"\r\n";
                foreach (Entidades.ClassificacaoProdutoClass tmp in CollectionClassificacaoProdutoClassComprador)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFamiliaMaterialClassComprador.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFamiliaMaterialClassComprador+"\r\n";
                foreach (Entidades.FamiliaMaterialClass tmp in CollectionFamiliaMaterialClassComprador)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionMaterialClassComprador.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionMaterialClassComprador+"\r\n";
                foreach (Entidades.MaterialClass tmp in CollectionMaterialClassComprador)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemCompraClassComprador.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemCompraClassComprador+"\r\n";
                foreach (Entidades.OrdemCompraClass tmp in CollectionOrdemCompraClassComprador)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionProdutoClassComprador.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionProdutoClassComprador+"\r\n";
                foreach (Entidades.ProdutoClass tmp in CollectionProdutoClassComprador)
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
        public static CompradorClass CopiarEntidade(CompradorClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CompradorClass toRet = new CompradorClass(usuario,conn);
 toRet.Apelido= entidadeCopiar.Apelido;
 toRet.Nome= entidadeCopiar.Nome;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Email= entidadeCopiar.Email;
 toRet.Fone= entidadeCopiar.Fone;
 toRet.Ramal= entidadeCopiar.Ramal;
 toRet.Observacao= entidadeCopiar.Observacao;

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
       _apelidoOriginal = Apelido;
       _apelidoOriginalCommited = _apelidoOriginal;
       _nomeOriginal = Nome;
       _nomeOriginalCommited = _nomeOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _emailOriginal = Email;
       _emailOriginalCommited = _emailOriginal;
       _foneOriginal = Fone;
       _foneOriginalCommited = _foneOriginal;
       _ramalOriginal = Ramal;
       _ramalOriginalCommited = _ramalOriginal;
       _observacaoOriginal = Observacao;
       _observacaoOriginalCommited = _observacaoOriginal;

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
       _apelidoOriginalCommited = Apelido;
       _nomeOriginalCommited = Nome;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _versionOriginalCommited = Version;
       _emailOriginalCommited = Email;
       _foneOriginalCommited = Fone;
       _ramalOriginalCommited = Ramal;
       _observacaoOriginalCommited = Observacao;

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
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  if (_collectionClassificacaoProdutoClassCompradorRemovidos != null) 
                  {
                     _collectionClassificacaoProdutoClassCompradorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionClassificacaoProdutoClassCompradorRemovidos = new List<Entidades.ClassificacaoProdutoClass>();
                  }
                  _collectionClassificacaoProdutoClassCompradorOriginal= (from a in _valueCollectionClassificacaoProdutoClassComprador select a.ID).ToList();
                  _valueCollectionClassificacaoProdutoClassCompradorChanged = false;
                  _valueCollectionClassificacaoProdutoClassCompradorCommitedChanged = false;
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  if (_collectionFamiliaMaterialClassCompradorRemovidos != null) 
                  {
                     _collectionFamiliaMaterialClassCompradorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFamiliaMaterialClassCompradorRemovidos = new List<Entidades.FamiliaMaterialClass>();
                  }
                  _collectionFamiliaMaterialClassCompradorOriginal= (from a in _valueCollectionFamiliaMaterialClassComprador select a.ID).ToList();
                  _valueCollectionFamiliaMaterialClassCompradorChanged = false;
                  _valueCollectionFamiliaMaterialClassCompradorCommitedChanged = false;
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  if (_collectionMaterialClassCompradorRemovidos != null) 
                  {
                     _collectionMaterialClassCompradorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionMaterialClassCompradorRemovidos = new List<Entidades.MaterialClass>();
                  }
                  _collectionMaterialClassCompradorOriginal= (from a in _valueCollectionMaterialClassComprador select a.ID).ToList();
                  _valueCollectionMaterialClassCompradorChanged = false;
                  _valueCollectionMaterialClassCompradorCommitedChanged = false;
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  if (_collectionOrdemCompraClassCompradorRemovidos != null) 
                  {
                     _collectionOrdemCompraClassCompradorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemCompraClassCompradorRemovidos = new List<Entidades.OrdemCompraClass>();
                  }
                  _collectionOrdemCompraClassCompradorOriginal= (from a in _valueCollectionOrdemCompraClassComprador select a.ID).ToList();
                  _valueCollectionOrdemCompraClassCompradorChanged = false;
                  _valueCollectionOrdemCompraClassCompradorCommitedChanged = false;
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  if (_collectionProdutoClassCompradorRemovidos != null) 
                  {
                     _collectionProdutoClassCompradorRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionProdutoClassCompradorRemovidos = new List<Entidades.ProdutoClass>();
                  }
                  _collectionProdutoClassCompradorOriginal= (from a in _valueCollectionProdutoClassComprador select a.ID).ToList();
                  _valueCollectionProdutoClassCompradorChanged = false;
                  _valueCollectionProdutoClassCompradorCommitedChanged = false;
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
               Apelido=_apelidoOriginal;
               _apelidoOriginalCommited=_apelidoOriginal;
               Nome=_nomeOriginal;
               _nomeOriginalCommited=_nomeOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Email=_emailOriginal;
               _emailOriginalCommited=_emailOriginal;
               Fone=_foneOriginal;
               _foneOriginalCommited=_foneOriginal;
               Ramal=_ramalOriginal;
               _ramalOriginalCommited=_ramalOriginal;
               Observacao=_observacaoOriginal;
               _observacaoOriginalCommited=_observacaoOriginal;
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  CollectionClassificacaoProdutoClassComprador.Clear();
                  foreach(int item in _collectionClassificacaoProdutoClassCompradorOriginal)
                  {
                    CollectionClassificacaoProdutoClassComprador.Add(Entidades.ClassificacaoProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionClassificacaoProdutoClassCompradorRemovidos.Clear();
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  CollectionFamiliaMaterialClassComprador.Clear();
                  foreach(int item in _collectionFamiliaMaterialClassCompradorOriginal)
                  {
                    CollectionFamiliaMaterialClassComprador.Add(Entidades.FamiliaMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFamiliaMaterialClassCompradorRemovidos.Clear();
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  CollectionMaterialClassComprador.Clear();
                  foreach(int item in _collectionMaterialClassCompradorOriginal)
                  {
                    CollectionMaterialClassComprador.Add(Entidades.MaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionMaterialClassCompradorRemovidos.Clear();
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  CollectionOrdemCompraClassComprador.Clear();
                  foreach(int item in _collectionOrdemCompraClassCompradorOriginal)
                  {
                    CollectionOrdemCompraClassComprador.Add(Entidades.OrdemCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemCompraClassCompradorRemovidos.Clear();
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  CollectionProdutoClassComprador.Clear();
                  foreach(int item in _collectionProdutoClassCompradorOriginal)
                  {
                    CollectionProdutoClassComprador.Add(Entidades.ProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionProdutoClassCompradorRemovidos.Clear();
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
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  if (_valueCollectionClassificacaoProdutoClassCompradorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  if (_valueCollectionFamiliaMaterialClassCompradorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  if (_valueCollectionMaterialClassCompradorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassCompradorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  if (_valueCollectionProdutoClassCompradorChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                   tempRet = CollectionClassificacaoProdutoClassComprador.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                   tempRet = CollectionFamiliaMaterialClassComprador.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                   tempRet = CollectionMaterialClassComprador.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassComprador.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                   tempRet = CollectionProdutoClassComprador.Any(item => item.IsDirty());
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
       dirty = _apelidoOriginal != Apelido;
      if (dirty) return true;
       dirty = _nomeOriginal != Nome;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _emailOriginal != Email;
      if (dirty) return true;
       dirty = _foneOriginal != Fone;
      if (dirty) return true;
       dirty = _ramalOriginal != Ramal;
      if (dirty) return true;
       dirty = _observacaoOriginal != Observacao;

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
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  if (_valueCollectionClassificacaoProdutoClassCompradorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  if (_valueCollectionFamiliaMaterialClassCompradorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  if (_valueCollectionMaterialClassCompradorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  if (_valueCollectionOrdemCompraClassCompradorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  if (_valueCollectionProdutoClassCompradorCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                   tempRet = CollectionClassificacaoProdutoClassComprador.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                   tempRet = CollectionFamiliaMaterialClassComprador.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                   tempRet = CollectionMaterialClassComprador.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                   tempRet = CollectionOrdemCompraClassComprador.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                   tempRet = CollectionProdutoClassComprador.Any(item => item.IsDirtyCommited());
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
       dirty = _apelidoOriginalCommited != Apelido;
      if (dirty) return true;
       dirty = _nomeOriginalCommited != Nome;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _emailOriginalCommited != Email;
      if (dirty) return true;
       dirty = _foneOriginalCommited != Fone;
      if (dirty) return true;
       dirty = _ramalOriginalCommited != Ramal;
      if (dirty) return true;
       dirty = _observacaoOriginalCommited != Observacao;

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
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  foreach(ClassificacaoProdutoClass item in CollectionClassificacaoProdutoClassComprador)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  foreach(FamiliaMaterialClass item in CollectionFamiliaMaterialClassComprador)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassComprador)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassComprador)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassComprador)
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
             case "Apelido":
                return this.Apelido;
             case "Nome":
                return this.Nome;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Email":
                return this.Email;
             case "Fone":
                return this.Fone;
             case "Ramal":
                return this.Ramal;
             case "Observacao":
                return this.Observacao;
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
               if (_valueCollectionClassificacaoProdutoClassCompradorLoaded) 
               {
                  foreach(ClassificacaoProdutoClass item in CollectionClassificacaoProdutoClassComprador)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFamiliaMaterialClassCompradorLoaded) 
               {
                  foreach(FamiliaMaterialClass item in CollectionFamiliaMaterialClassComprador)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionMaterialClassCompradorLoaded) 
               {
                  foreach(MaterialClass item in CollectionMaterialClassComprador)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemCompraClassCompradorLoaded) 
               {
                  foreach(OrdemCompraClass item in CollectionOrdemCompraClassComprador)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionProdutoClassCompradorLoaded) 
               {
                  foreach(ProdutoClass item in CollectionProdutoClassComprador)
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
                  command.CommandText += " COUNT(comprador.id_comprador) " ;
               }
               else
               {
               command.CommandText += "comprador.id_comprador, " ;
               command.CommandText += "comprador.com_apelido, " ;
               command.CommandText += "comprador.com_nome, " ;
               command.CommandText += "comprador.id_acs_usuario, " ;
               command.CommandText += "comprador.entity_uid, " ;
               command.CommandText += "comprador.version, " ;
               command.CommandText += "comprador.com_email, " ;
               command.CommandText += "comprador.com_fone, " ;
               command.CommandText += "comprador.com_ramal, " ;
               command.CommandText += "comprador.com_observacao " ;
               }
               command.CommandText += " FROM  comprador ";
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
                        orderByClause += " , com_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(com_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = comprador.id_acs_usuario_ultima_revisao ";
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
                     case "id_comprador":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , comprador.id_comprador " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(comprador.id_comprador) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_apelido":
                     case "Apelido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_apelido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_apelido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_nome":
                     case "Nome":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , comprador.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , comprador.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(comprador.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_email":
                     case "Email":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_email " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_email) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_fone":
                     case "Fone":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_fone " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_fone) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_ramal":
                     case "Ramal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_ramal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_ramal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "com_observacao":
                     case "Observacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , comprador.com_observacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(comprador.com_observacao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_apelido")) 
                        {
                           whereClause += " OR UPPER(comprador.com_apelido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_apelido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_nome")) 
                        {
                           whereClause += " OR UPPER(comprador.com_nome) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_nome) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(comprador.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_email")) 
                        {
                           whereClause += " OR UPPER(comprador.com_email) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_email) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_fone")) 
                        {
                           whereClause += " OR UPPER(comprador.com_fone) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_fone) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_ramal")) 
                        {
                           whereClause += " OR UPPER(comprador.com_ramal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_ramal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("com_observacao")) 
                        {
                           whereClause += " OR UPPER(comprador.com_observacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(comprador.com_observacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_comprador")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.id_comprador IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.id_comprador = :comprador_ID_9998 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_ID_9998", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Apelido" || parametro.FieldName == "com_apelido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_apelido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_apelido LIKE :comprador_Apelido_2280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Apelido_2280", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Nome" || parametro.FieldName == "com_nome")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_nome LIKE :comprador_Nome_2571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Nome_2571", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  comprador.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.id_acs_usuario = :comprador_AcsUsuario_6282 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_AcsUsuario_6282", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  comprador.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.entity_uid LIKE :comprador_EntityUid_2145 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_EntityUid_2145", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  comprador.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.version = :comprador_Version_3056 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Version_3056", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Email" || parametro.FieldName == "com_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_email LIKE :comprador_Email_1600 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Email_1600", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Fone" || parametro.FieldName == "com_fone")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_fone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_fone LIKE :comprador_Fone_232 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Fone_232", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ramal" || parametro.FieldName == "com_ramal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_ramal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_ramal LIKE :comprador_Ramal_1386 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Ramal_1386", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Observacao" || parametro.FieldName == "com_observacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_observacao LIKE :comprador_Observacao_812 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Observacao_812", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ApelidoExato" || parametro.FieldName == "ApelidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_apelido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_apelido LIKE :comprador_Apelido_1106 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Apelido_1106", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  comprador.com_nome IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_nome LIKE :comprador_Nome_6522 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Nome_6522", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  comprador.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.entity_uid LIKE :comprador_EntityUid_8014 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_EntityUid_8014", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EmailExato" || parametro.FieldName == "EmailExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_email LIKE :comprador_Email_5599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Email_5599", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FoneExato" || parametro.FieldName == "FoneExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_fone IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_fone LIKE :comprador_Fone_967 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Fone_967", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RamalExato" || parametro.FieldName == "RamalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  comprador.com_ramal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_ramal LIKE :comprador_Ramal_3670 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Ramal_3670", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  comprador.com_observacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  comprador.com_observacao LIKE :comprador_Observacao_676 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("comprador_Observacao_676", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CompradorClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CompradorClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CompradorClass), Convert.ToInt32(read["id_comprador"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CompradorClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_comprador"]);
                     entidade.Apelido = (read["com_apelido"] != DBNull.Value ? read["com_apelido"].ToString() : null);
                     entidade.Nome = (read["com_nome"] != DBNull.Value ? read["com_nome"].ToString() : null);
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Email = (read["com_email"] != DBNull.Value ? read["com_email"].ToString() : null);
                     entidade.Fone = (read["com_fone"] != DBNull.Value ? read["com_fone"].ToString() : null);
                     entidade.Ramal = (read["com_ramal"] != DBNull.Value ? read["com_ramal"].ToString() : null);
                     entidade.Observacao = (read["com_observacao"] != DBNull.Value ? read["com_observacao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CompradorClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
