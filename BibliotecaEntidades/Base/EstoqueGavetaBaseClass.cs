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
     [Table("estoque_gaveta","esg")]
     public class EstoqueGavetaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstoqueGavetaClass";
protected const string ErroDelete = "Erro ao excluir o EstoqueGavetaClass  ";
protected const string ErroSave = "Erro ao salvar o EstoqueGavetaClass.";
protected const string ErroCollectionDocumentoFiscalDestinoClassEstoqueGaveta = "Erro ao carregar a coleção de DocumentoFiscalDestinoClass.";
protected const string ErroCollectionEstoqueGavetaItemClassEstoqueGaveta = "Erro ao carregar a coleção de EstoqueGavetaItemClass.";
protected const string ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
protected const string ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino = "Erro ao carregar a coleção de FomularioRetiradaManualEstoqueClass.";
protected const string ErroCollectionOrdemProducaoClassEstoqueGaveta = "Erro ao carregar a coleção de OrdemProducaoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEstoquePrateleiraObrigatorio = "O campo EstoquePrateleira é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do EstoqueGavetaClass.";
protected const string MensagemUtilizadoCollectionDocumentoFiscalDestinoClassEstoqueGaveta =  "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes DocumentoFiscalDestinoClass:";
protected const string MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoqueGaveta =  "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes EstoqueGavetaItemClass:";
protected const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta =  "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
protected const string MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino =  "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes FomularioRetiradaManualEstoqueClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoClassEstoqueGaveta =  "A entidade EstoqueGavetaClass está sendo utilizada nos seguintes OrdemProducaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueGavetaClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.EstoquePrateleiraClass _estoquePrateleiraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoquePrateleiraClass _estoquePrateleiraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoquePrateleiraClass _valueEstoquePrateleira;
        [Column("id_estoque_prateleira", "estoque_prateleira", "id_estoque_prateleira")]
       public virtual BibliotecaEntidades.Entidades.EstoquePrateleiraClass EstoquePrateleira
        { 
           get {                 return this._valueEstoquePrateleira; } 
           set 
           { 
                if (this._valueEstoquePrateleira == value)return;
                 this._valueEstoquePrateleira = value; 
           } 
       } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("esg_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("esg_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected bool _ativoOriginal{get;private set;}
       private bool _ativoOriginalCommited{get; set;}
        private bool _valueAtivo;
         [Column("esg_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       private List<long> _collectionDocumentoFiscalDestinoClassEstoqueGavetaOriginal;
       private List<Entidades.DocumentoFiscalDestinoClass > _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DocumentoFiscalDestinoClass> _valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DocumentoFiscalDestinoClass> CollectionDocumentoFiscalDestinoClassEstoqueGaveta 
       { 
           get { if(!_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded && !this.DisableLoadCollection){this.LoadCollectionDocumentoFiscalDestinoClassEstoqueGaveta();}
return this._valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta; } 
           set 
           { 
               this._valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta = value; 
               this._valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded = true; 
           } 
       } 

       private List<long> _collectionEstoqueGavetaItemClassEstoqueGavetaOriginal;
       private List<Entidades.EstoqueGavetaItemClass > _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueGavetaItemClass> _valueCollectionEstoqueGavetaItemClassEstoqueGaveta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueGavetaItemClass> CollectionEstoqueGavetaItemClassEstoqueGaveta 
       { 
           get { if(!_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueGavetaItemClassEstoqueGaveta();}
return this._valueCollectionEstoqueGavetaItemClassEstoqueGaveta; } 
           set 
           { 
               this._valueCollectionEstoqueGavetaItemClassEstoqueGaveta = value; 
               this._valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded = true; 
           } 
       } 

       private List<long> _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaOriginal;
       private List<Entidades.FomularioRetiradaManualEstoqueClass > _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FomularioRetiradaManualEstoqueClass> _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FomularioRetiradaManualEstoqueClass> CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta 
       { 
           get { if(!_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded && !this.DisableLoadCollection){this.LoadCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta();}
return this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta; } 
           set 
           { 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta = value; 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded = true; 
           } 
       } 

       private List<long> _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoOriginal;
       private List<Entidades.FomularioRetiradaManualEstoqueClass > _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.FomularioRetiradaManualEstoqueClass> _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.FomularioRetiradaManualEstoqueClass> CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino 
       { 
           get { if(!_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded && !this.DisableLoadCollection){this.LoadCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino();}
return this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino; } 
           set 
           { 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino = value; 
               this._valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoClassEstoqueGavetaOriginal;
       private List<Entidades.OrdemProducaoClass > _collectionOrdemProducaoClassEstoqueGavetaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassEstoqueGavetaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassEstoqueGavetaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoClass> _valueCollectionOrdemProducaoClassEstoqueGaveta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoClass> CollectionOrdemProducaoClassEstoqueGaveta 
       { 
           get { if(!_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoClassEstoqueGaveta();}
return this._valueCollectionOrdemProducaoClassEstoqueGaveta; } 
           set 
           { 
               this._valueCollectionOrdemProducaoClassEstoqueGaveta = value; 
               this._valueCollectionOrdemProducaoClassEstoqueGavetaLoaded = true; 
           } 
       } 

        public EstoqueGavetaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EstoqueGavetaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstoqueGavetaClass) GetEntity(typeof(EstoqueGavetaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDocumentoFiscalDestinoClassEstoqueGavetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged = true;
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged = true; 
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.DocumentoFiscalDestinoClass item in e.OldItems) 
                 { 
                     _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged = true; 
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.DocumentoFiscalDestinoClass item in _valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta) 
                 { 
                     _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDocumentoFiscalDestinoClassEstoqueGaveta()
         {
            try
            {
                 ObservableCollection<Entidades.DocumentoFiscalDestinoClass> oc;
                _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged = false;
                 _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged = false;
                _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos = new List<Entidades.DocumentoFiscalDestinoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DocumentoFiscalDestinoClass>();
                }
                else{ 
                   Entidades.DocumentoFiscalDestinoClass search = new Entidades.DocumentoFiscalDestinoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DocumentoFiscalDestinoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGaveta", this),                     }                       ).Cast<Entidades.DocumentoFiscalDestinoClass>().ToList());
                 }
                 _valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta = new BindingList<Entidades.DocumentoFiscalDestinoClass>(oc); 
                 _collectionDocumentoFiscalDestinoClassEstoqueGavetaOriginal= (from a in _valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta select a.ID).ToList();
                 _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded = true;
                 oc.CollectionChanged += CollectionDocumentoFiscalDestinoClassEstoqueGavetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDocumentoFiscalDestinoClassEstoqueGaveta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEstoqueGavetaItemClassEstoqueGavetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged = true;
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in e.OldItems) 
                 { 
                     _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged = true; 
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.EstoqueGavetaItemClass item in _valueCollectionEstoqueGavetaItemClassEstoqueGaveta) 
                 { 
                     _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueGavetaItemClassEstoqueGaveta()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueGavetaItemClass> oc;
                _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged = false;
                 _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged = false;
                _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueGavetaItemClass>();
                }
                else{ 
                   Entidades.EstoqueGavetaItemClass search = new Entidades.EstoqueGavetaItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueGavetaItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGaveta", this),                     }                       ).Cast<Entidades.EstoqueGavetaItemClass>().ToList());
                 }
                 _valueCollectionEstoqueGavetaItemClassEstoqueGaveta = new BindingList<Entidades.EstoqueGavetaItemClass>(oc); 
                 _collectionEstoqueGavetaItemClassEstoqueGavetaOriginal= (from a in _valueCollectionEstoqueGavetaItemClassEstoqueGaveta select a.ID).ToList();
                 _valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueGavetaItemClassEstoqueGavetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueGavetaItemClassEstoqueGaveta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged = true;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in e.OldItems) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta()
         {
            try
            {
                 ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass> oc;
                _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged = false;
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged = false;
                _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>();
                }
                else{ 
                   Entidades.FomularioRetiradaManualEstoqueClass search = new Entidades.FomularioRetiradaManualEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGaveta", this),                     }                       ).Cast<Entidades.FomularioRetiradaManualEstoqueClass>().ToList());
                 }
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta = new BindingList<Entidades.FomularioRetiradaManualEstoqueClass>(oc); 
                 _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta select a.ID).ToList();
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded = true;
                 oc.CollectionChanged += CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged = true;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in e.OldItems) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged = true; 
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged = true;
                 foreach (Entidades.FomularioRetiradaManualEstoqueClass item in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino) 
                 { 
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino()
         {
            try
            {
                 ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass> oc;
                _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged = false;
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged = false;
                _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>();
                }
                else{ 
                   Entidades.FomularioRetiradaManualEstoqueClass search = new Entidades.FomularioRetiradaManualEstoqueClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.FomularioRetiradaManualEstoqueClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGavetaDestino", this),                     }                       ).Cast<Entidades.FomularioRetiradaManualEstoqueClass>().ToList());
                 }
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino = new BindingList<Entidades.FomularioRetiradaManualEstoqueClass>(oc); 
                 _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino select a.ID).ToList();
                 _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded = true;
                 oc.CollectionChanged += CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoClassEstoqueGavetaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoClassEstoqueGavetaChanged = true;
                  _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoClassEstoqueGavetaChanged = true; 
                  _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoClassEstoqueGavetaChanged = true; 
                  _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in _valueCollectionOrdemProducaoClassEstoqueGaveta) 
                 { 
                     _collectionOrdemProducaoClassEstoqueGavetaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoClassEstoqueGaveta()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoClass> oc;
                _valueCollectionOrdemProducaoClassEstoqueGavetaChanged = false;
                 _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged = false;
                _collectionOrdemProducaoClassEstoqueGavetaRemovidos = new List<Entidades.OrdemProducaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoClass search = new Entidades.OrdemProducaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("EstoqueGaveta", this)                    }                       ).Cast<Entidades.OrdemProducaoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoClassEstoqueGaveta = new BindingList<Entidades.OrdemProducaoClass>(oc); 
                 _collectionOrdemProducaoClassEstoqueGavetaOriginal= (from a in _valueCollectionOrdemProducaoClassEstoqueGaveta select a.ID).ToList();
                 _valueCollectionOrdemProducaoClassEstoqueGavetaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoClassEstoqueGavetaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoClassEstoqueGaveta+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Identificacao))
                {
                    throw new Exception(ErroIdentificacaoObrigatorio);
                }
                if (Identificacao.Length >255)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
                }
                if ( _valueEstoquePrateleira == null)
                {
                    throw new Exception(ErroEstoquePrateleiraObrigatorio);
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
                    "  public.estoque_gaveta  " +
                    "WHERE " +
                    "  id_estoque_gaveta = :id";
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
                        "  public.estoque_gaveta   " +
                        "SET  " + 
                        "  id_estoque_prateleira = :id_estoque_prateleira, " + 
                        "  esg_identificacao = :esg_identificacao, " + 
                        "  esg_descricao = :esg_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  esg_ativo = :esg_ativo "+
                        "WHERE  " +
                        "  id_estoque_gaveta = :id " +
                        "RETURNING id_estoque_gaveta;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estoque_gaveta " +
                        "( " +
                        "  id_estoque_prateleira , " + 
                        "  esg_identificacao , " + 
                        "  esg_descricao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  esg_ativo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque_prateleira , " + 
                        "  :esg_identificacao , " + 
                        "  :esg_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :esg_ativo  "+
                        ")RETURNING id_estoque_gaveta;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_prateleira", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoquePrateleira==null ? (object) DBNull.Value : this.EstoquePrateleira.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esg_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esg_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("esg_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;

 
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
 if (CollectionDocumentoFiscalDestinoClassEstoqueGaveta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDocumentoFiscalDestinoClassEstoqueGaveta+"\r\n";
                foreach (Entidades.DocumentoFiscalDestinoClass tmp in CollectionDocumentoFiscalDestinoClassEstoqueGaveta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEstoqueGavetaItemClassEstoqueGaveta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueGavetaItemClassEstoqueGaveta+"\r\n";
                foreach (Entidades.EstoqueGavetaItemClass tmp in CollectionEstoqueGavetaItemClassEstoqueGaveta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta+"\r\n";
                foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino+"\r\n";
                foreach (Entidades.FomularioRetiradaManualEstoqueClass tmp in CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoClassEstoqueGaveta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoClassEstoqueGaveta+"\r\n";
                foreach (Entidades.OrdemProducaoClass tmp in CollectionOrdemProducaoClassEstoqueGaveta)
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
        public static EstoqueGavetaClass CopiarEntidade(EstoqueGavetaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstoqueGavetaClass toRet = new EstoqueGavetaClass(usuario,conn);
 toRet.EstoquePrateleira= entidadeCopiar.EstoquePrateleira;
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Ativo= entidadeCopiar.Ativo;

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
       _estoquePrateleiraOriginal = EstoquePrateleira;
       _estoquePrateleiraOriginalCommited = _estoquePrateleiraOriginal;
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;

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
       _estoquePrateleiraOriginalCommited = EstoquePrateleira;
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _versionOriginalCommited = Version;
       _ativoOriginalCommited = Ativo;

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
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  if (_collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos != null) 
                  {
                     _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos = new List<Entidades.DocumentoFiscalDestinoClass>();
                  }
                  _collectionDocumentoFiscalDestinoClassEstoqueGavetaOriginal= (from a in _valueCollectionDocumentoFiscalDestinoClassEstoqueGaveta select a.ID).ToList();
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged = false;
                  _valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged = false;
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  if (_collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos != null) 
                  {
                     _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos = new List<Entidades.EstoqueGavetaItemClass>();
                  }
                  _collectionEstoqueGavetaItemClassEstoqueGavetaOriginal= (from a in _valueCollectionEstoqueGavetaItemClassEstoqueGaveta select a.ID).ToList();
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged = false;
                  _valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged = false;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  if (_collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos != null) 
                  {
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta select a.ID).ToList();
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged = false;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged = false;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  if (_collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos != null) 
                  {
                     _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos = new List<Entidades.FomularioRetiradaManualEstoqueClass>();
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoOriginal= (from a in _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino select a.ID).ToList();
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged = false;
                  _valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  if (_collectionOrdemProducaoClassEstoqueGavetaRemovidos != null) 
                  {
                     _collectionOrdemProducaoClassEstoqueGavetaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoClassEstoqueGavetaRemovidos = new List<Entidades.OrdemProducaoClass>();
                  }
                  _collectionOrdemProducaoClassEstoqueGavetaOriginal= (from a in _valueCollectionOrdemProducaoClassEstoqueGaveta select a.ID).ToList();
                  _valueCollectionOrdemProducaoClassEstoqueGavetaChanged = false;
                  _valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged = false;
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
               EstoquePrateleira=_estoquePrateleiraOriginal;
               _estoquePrateleiraOriginalCommited=_estoquePrateleiraOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  CollectionDocumentoFiscalDestinoClassEstoqueGaveta.Clear();
                  foreach(int item in _collectionDocumentoFiscalDestinoClassEstoqueGavetaOriginal)
                  {
                    CollectionDocumentoFiscalDestinoClassEstoqueGaveta.Add(Entidades.DocumentoFiscalDestinoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDocumentoFiscalDestinoClassEstoqueGavetaRemovidos.Clear();
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  CollectionEstoqueGavetaItemClassEstoqueGaveta.Clear();
                  foreach(int item in _collectionEstoqueGavetaItemClassEstoqueGavetaOriginal)
                  {
                    CollectionEstoqueGavetaItemClassEstoqueGaveta.Add(Entidades.EstoqueGavetaItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueGavetaItemClassEstoqueGavetaRemovidos.Clear();
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta.Clear();
                  foreach(int item in _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaOriginal)
                  {
                    CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta.Add(Entidades.FomularioRetiradaManualEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaRemovidos.Clear();
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino.Clear();
                  foreach(int item in _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoOriginal)
                  {
                    CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino.Add(Entidades.FomularioRetiradaManualEstoqueClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  CollectionOrdemProducaoClassEstoqueGaveta.Clear();
                  foreach(int item in _collectionOrdemProducaoClassEstoqueGavetaOriginal)
                  {
                    CollectionOrdemProducaoClassEstoqueGaveta.Add(Entidades.OrdemProducaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoClassEstoqueGavetaRemovidos.Clear();
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
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassEstoqueGavetaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionDocumentoFiscalDestinoClassEstoqueGaveta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassEstoqueGaveta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassEstoqueGaveta.Any(item => item.IsDirty());
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
       if (_estoquePrateleiraOriginal!=null)
       {
          dirty = !_estoquePrateleiraOriginal.Equals(EstoquePrateleira);
       }
       else
       {
            dirty = EstoquePrateleira != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;

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
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassEstoqueGavetaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionDocumentoFiscalDestinoClassEstoqueGaveta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionEstoqueGavetaItemClassEstoqueGaveta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                   tempRet = CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassEstoqueGaveta.Any(item => item.IsDirtyCommited());
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
       if (_estoquePrateleiraOriginalCommited!=null)
       {
          dirty = !_estoquePrateleiraOriginalCommited.Equals(EstoquePrateleira);
       }
       else
       {
            dirty = EstoquePrateleira != null;
       }
      if (dirty) return true;
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;

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
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  foreach(DocumentoFiscalDestinoClass item in CollectionDocumentoFiscalDestinoClassEstoqueGaveta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassEstoqueGaveta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassEstoqueGaveta)
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
             case "EstoquePrateleira":
                return this.EstoquePrateleira;
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Ativo":
                return this.Ativo;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (EstoquePrateleira!=null)
                EstoquePrateleira.ChangeSingleConnection(newConnection);
               if (_valueCollectionDocumentoFiscalDestinoClassEstoqueGavetaLoaded) 
               {
                  foreach(DocumentoFiscalDestinoClass item in CollectionDocumentoFiscalDestinoClassEstoqueGaveta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEstoqueGavetaItemClassEstoqueGavetaLoaded) 
               {
                  foreach(EstoqueGavetaItemClass item in CollectionEstoqueGavetaItemClassEstoqueGaveta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEstoqueGaveta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestinoLoaded) 
               {
                  foreach(FomularioRetiradaManualEstoqueClass item in CollectionFomularioRetiradaManualEstoqueClassEstoqueGavetaDestino)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoClassEstoqueGavetaLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassEstoqueGaveta)
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
                  command.CommandText += " COUNT(estoque_gaveta.id_estoque_gaveta) " ;
               }
               else
               {
               command.CommandText += "estoque_gaveta.id_estoque_gaveta, " ;
               command.CommandText += "estoque_gaveta.id_estoque_prateleira, " ;
               command.CommandText += "estoque_gaveta.esg_identificacao, " ;
               command.CommandText += "estoque_gaveta.esg_descricao, " ;
               command.CommandText += "estoque_gaveta.entity_uid, " ;
               command.CommandText += "estoque_gaveta.version, " ;
               command.CommandText += "estoque_gaveta.esg_ativo " ;
               }
               command.CommandText += " FROM  estoque_gaveta ";
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
                        orderByClause += " , esg_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(esg_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estoque_gaveta.id_acs_usuario_ultima_revisao ";
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
                     case "id_estoque_gaveta":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_gaveta.id_estoque_gaveta " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta.id_estoque_gaveta) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_prateleira":
                     case "EstoquePrateleira":
                     command.CommandText += " LEFT JOIN estoque_prateleira as estoque_prateleira_EstoquePrateleira ON estoque_prateleira_EstoquePrateleira.id_estoque_prateleira = estoque_gaveta.id_estoque_prateleira ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_prateleira_EstoquePrateleira.esp_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_prateleira_EstoquePrateleira.esp_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esg_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esg_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta.esg_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta.esg_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estoque_gaveta.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "esg_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque_gaveta.esg_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque_gaveta.esg_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esg_identificacao")) 
                        {
                           whereClause += " OR UPPER(estoque_gaveta.esg_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_gaveta.esg_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("esg_descricao")) 
                        {
                           whereClause += " OR UPPER(estoque_gaveta.esg_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_gaveta.esg_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(estoque_gaveta.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque_gaveta.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estoque_gaveta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.id_estoque_gaveta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.id_estoque_gaveta = :estoque_gaveta_ID_4252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_ID_4252", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoquePrateleira" || parametro.FieldName == "id_estoque_prateleira")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoquePrateleiraClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoquePrateleiraClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.id_estoque_prateleira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.id_estoque_prateleira = :estoque_gaveta_EstoquePrateleira_6465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_EstoquePrateleira_6465", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "esg_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.esg_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.esg_identificacao LIKE :estoque_gaveta_Identificacao_2451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Identificacao_2451", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "esg_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.esg_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.esg_descricao LIKE :estoque_gaveta_Descricao_713 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Descricao_713", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_gaveta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.entity_uid LIKE :estoque_gaveta_EntityUid_7002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_EntityUid_7002", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque_gaveta.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.version = :estoque_gaveta_Version_2034 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Version_2034", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "esg_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.esg_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.esg_ativo = :estoque_gaveta_Ativo_2167 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Ativo_2167", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoExato" || parametro.FieldName == "IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque_gaveta.esg_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.esg_identificacao LIKE :estoque_gaveta_Identificacao_7075 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Identificacao_7075", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_gaveta.esg_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.esg_descricao LIKE :estoque_gaveta_Descricao_8552 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_Descricao_8552", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque_gaveta.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque_gaveta.entity_uid LIKE :estoque_gaveta_EntityUid_8321 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_gaveta_EntityUid_8321", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstoqueGavetaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstoqueGavetaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstoqueGavetaClass), Convert.ToInt32(read["id_estoque_gaveta"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstoqueGavetaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estoque_gaveta"]);
                     if (read["id_estoque_prateleira"] != DBNull.Value)
                     {
                        entidade.EstoquePrateleira = (BibliotecaEntidades.Entidades.EstoquePrateleiraClass)BibliotecaEntidades.Entidades.EstoquePrateleiraClass.GetEntidade(Convert.ToInt32(read["id_estoque_prateleira"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoquePrateleira = null ;
                     }
                     entidade.Identificacao = (read["esg_identificacao"] != DBNull.Value ? read["esg_identificacao"].ToString() : null);
                     entidade.Descricao = (read["esg_descricao"] != DBNull.Value ? read["esg_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["esg_ativo"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstoqueGavetaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
