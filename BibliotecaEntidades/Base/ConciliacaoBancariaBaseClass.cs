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
     [Table("conciliacao_bancaria","cob")]
     public class ConciliacaoBancariaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do ConciliacaoBancariaClass";
protected const string ErroDelete = "Erro ao excluir o ConciliacaoBancariaClass  ";
protected const string ErroSave = "Erro ao salvar o ConciliacaoBancariaClass.";
protected const string ErroCollectionContaPagarClassConciliacaoBancaria = "Erro ao carregar a coleção de ContaPagarClass.";
protected const string ErroCollectionContaReceberClassConciliacaoBancaria = "Erro ao carregar a coleção de ContaReceberClass.";
protected const string ErroCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
protected const string ErroCollectionTransferenciaBancariaClassConciliacaoBancariaDestino = "Erro ao carregar a coleção de TransferenciaBancariaClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroContaBancariaObrigatorio = "O campo ContaBancaria é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do ConciliacaoBancariaClass.";
protected const string MensagemUtilizadoCollectionContaPagarClassConciliacaoBancaria =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes ContaPagarClass:";
protected const string MensagemUtilizadoCollectionContaReceberClassConciliacaoBancaria =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes ContaReceberClass:";
protected const string MensagemUtilizadoCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
protected const string MensagemUtilizadoCollectionTransferenciaBancariaClassConciliacaoBancariaDestino =  "A entidade ConciliacaoBancariaClass está sendo utilizada nos seguintes TransferenciaBancariaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade ConciliacaoBancariaClass está sendo utilizada.";
#endregion
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

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("cob_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("cob_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
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

       private List<long> _collectionContaPagarClassConciliacaoBancariaOriginal;
       private List<Entidades.ContaPagarClass > _collectionContaPagarClassConciliacaoBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassConciliacaoBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassConciliacaoBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaPagarClass> _valueCollectionContaPagarClassConciliacaoBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaPagarClass> CollectionContaPagarClassConciliacaoBancaria 
       { 
           get { if(!_valueCollectionContaPagarClassConciliacaoBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaPagarClassConciliacaoBancaria();}
return this._valueCollectionContaPagarClassConciliacaoBancaria; } 
           set 
           { 
               this._valueCollectionContaPagarClassConciliacaoBancaria = value; 
               this._valueCollectionContaPagarClassConciliacaoBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionContaReceberClassConciliacaoBancariaOriginal;
       private List<Entidades.ContaReceberClass > _collectionContaReceberClassConciliacaoBancariaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassConciliacaoBancariaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassConciliacaoBancariaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.ContaReceberClass> _valueCollectionContaReceberClassConciliacaoBancaria { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.ContaReceberClass> CollectionContaReceberClassConciliacaoBancaria 
       { 
           get { if(!_valueCollectionContaReceberClassConciliacaoBancariaLoaded && !this.DisableLoadCollection){this.LoadCollectionContaReceberClassConciliacaoBancaria();}
return this._valueCollectionContaReceberClassConciliacaoBancaria; } 
           set 
           { 
               this._valueCollectionContaReceberClassConciliacaoBancaria = value; 
               this._valueCollectionContaReceberClassConciliacaoBancariaLoaded = true; 
           } 
       } 

       private List<long> _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemOriginal;
       private List<Entidades.TransferenciaBancariaClass > _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransferenciaBancariaClass> _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransferenciaBancariaClass> CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem 
       { 
           get { if(!_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded && !this.DisableLoadCollection){this.LoadCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem();}
return this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem; } 
           set 
           { 
               this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem = value; 
               this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded = true; 
           } 
       } 

       private List<long> _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoOriginal;
       private List<Entidades.TransferenciaBancariaClass > _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.TransferenciaBancariaClass> _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.TransferenciaBancariaClass> CollectionTransferenciaBancariaClassConciliacaoBancariaDestino 
       { 
           get { if(!_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded && !this.DisableLoadCollection){this.LoadCollectionTransferenciaBancariaClassConciliacaoBancariaDestino();}
return this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino; } 
           set 
           { 
               this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino = value; 
               this._valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded = true; 
           } 
       } 

        public ConciliacaoBancariaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static ConciliacaoBancariaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (ConciliacaoBancariaClass) GetEntity(typeof(ConciliacaoBancariaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionContaPagarClassConciliacaoBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaPagarClassConciliacaoBancariaChanged = true;
                  _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaPagarClassConciliacaoBancariaChanged = true; 
                  _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in e.OldItems) 
                 { 
                     _collectionContaPagarClassConciliacaoBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaPagarClassConciliacaoBancariaChanged = true; 
                  _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged = true;
                 foreach (Entidades.ContaPagarClass item in _valueCollectionContaPagarClassConciliacaoBancaria) 
                 { 
                     _collectionContaPagarClassConciliacaoBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaPagarClassConciliacaoBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaPagarClass> oc;
                _valueCollectionContaPagarClassConciliacaoBancariaChanged = false;
                 _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged = false;
                _collectionContaPagarClassConciliacaoBancariaRemovidos = new List<Entidades.ContaPagarClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaPagarClass>();
                }
                else{ 
                   Entidades.ContaPagarClass search = new Entidades.ContaPagarClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaPagarClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ConciliacaoBancaria", this),                     }                       ).Cast<Entidades.ContaPagarClass>().ToList());
                 }
                 _valueCollectionContaPagarClassConciliacaoBancaria = new BindingList<Entidades.ContaPagarClass>(oc); 
                 _collectionContaPagarClassConciliacaoBancariaOriginal= (from a in _valueCollectionContaPagarClassConciliacaoBancaria select a.ID).ToList();
                 _valueCollectionContaPagarClassConciliacaoBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaPagarClassConciliacaoBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaPagarClassConciliacaoBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionContaReceberClassConciliacaoBancariaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionContaReceberClassConciliacaoBancariaChanged = true;
                  _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionContaReceberClassConciliacaoBancariaChanged = true; 
                  _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in e.OldItems) 
                 { 
                     _collectionContaReceberClassConciliacaoBancariaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionContaReceberClassConciliacaoBancariaChanged = true; 
                  _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged = true;
                 foreach (Entidades.ContaReceberClass item in _valueCollectionContaReceberClassConciliacaoBancaria) 
                 { 
                     _collectionContaReceberClassConciliacaoBancariaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionContaReceberClassConciliacaoBancaria()
         {
            try
            {
                 ObservableCollection<Entidades.ContaReceberClass> oc;
                _valueCollectionContaReceberClassConciliacaoBancariaChanged = false;
                 _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged = false;
                _collectionContaReceberClassConciliacaoBancariaRemovidos = new List<Entidades.ContaReceberClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.ContaReceberClass>();
                }
                else{ 
                   Entidades.ContaReceberClass search = new Entidades.ContaReceberClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.ContaReceberClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ConciliacaoBancaria", this)                    }                       ).Cast<Entidades.ContaReceberClass>().ToList());
                 }
                 _valueCollectionContaReceberClassConciliacaoBancaria = new BindingList<Entidades.ContaReceberClass>(oc); 
                 _collectionContaReceberClassConciliacaoBancariaOriginal= (from a in _valueCollectionContaReceberClassConciliacaoBancaria select a.ID).ToList();
                 _valueCollectionContaReceberClassConciliacaoBancariaLoaded = true;
                 oc.CollectionChanged += CollectionContaReceberClassConciliacaoBancariaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionContaReceberClassConciliacaoBancaria+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged = true;
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged = true; 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in e.OldItems) 
                 { 
                     _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged = true; 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem) 
                 { 
                     _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem()
         {
            try
            {
                 ObservableCollection<Entidades.TransferenciaBancariaClass> oc;
                _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged = false;
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged = false;
                _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransferenciaBancariaClass>();
                }
                else{ 
                   Entidades.TransferenciaBancariaClass search = new Entidades.TransferenciaBancariaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransferenciaBancariaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ConciliacaoBancariaOrigem", this),                     }                       ).Cast<Entidades.TransferenciaBancariaClass>().ToList());
                 }
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem = new BindingList<Entidades.TransferenciaBancariaClass>(oc); 
                 _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemOriginal= (from a in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem select a.ID).ToList();
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded = true;
                 oc.CollectionChanged += CollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged = true;
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged = true; 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in e.OldItems) 
                 { 
                     _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged = true; 
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged = true;
                 foreach (Entidades.TransferenciaBancariaClass item in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino) 
                 { 
                     _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionTransferenciaBancariaClassConciliacaoBancariaDestino()
         {
            try
            {
                 ObservableCollection<Entidades.TransferenciaBancariaClass> oc;
                _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged = false;
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged = false;
                _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.TransferenciaBancariaClass>();
                }
                else{ 
                   Entidades.TransferenciaBancariaClass search = new Entidades.TransferenciaBancariaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.TransferenciaBancariaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("ConciliacaoBancariaDestino", this),                     }                       ).Cast<Entidades.TransferenciaBancariaClass>().ToList());
                 }
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino = new BindingList<Entidades.TransferenciaBancariaClass>(oc); 
                 _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoOriginal= (from a in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino select a.ID).ToList();
                 _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded = true;
                 oc.CollectionChanged += CollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionTransferenciaBancariaClassConciliacaoBancariaDestino+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueContaBancaria == null)
                {
                    throw new Exception(ErroContaBancariaObrigatorio);
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
                    "  public.conciliacao_bancaria  " +
                    "WHERE " +
                    "  id_conciliacao_bancaria = :id";
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
                        "  public.conciliacao_bancaria   " +
                        "SET  " + 
                        "  id_conta_bancaria = :id_conta_bancaria, " + 
                        "  cob_data = :cob_data, " + 
                        "  cob_valor = :cob_valor, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_conciliacao_bancaria = :id " +
                        "RETURNING id_conciliacao_bancaria;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.conciliacao_bancaria " +
                        "( " +
                        "  id_conta_bancaria , " + 
                        "  cob_data , " + 
                        "  cob_valor , " + 
                        "  id_acs_usuario , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_conta_bancaria , " + 
                        "  :cob_data , " + 
                        "  :cob_valor , " + 
                        "  :id_acs_usuario , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_conciliacao_bancaria;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_conta_bancaria", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.ContaBancaria==null ? (object) DBNull.Value : this.ContaBancaria.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;

 
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
 if (CollectionContaPagarClassConciliacaoBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaPagarClassConciliacaoBancaria+"\r\n";
                foreach (Entidades.ContaPagarClass tmp in CollectionContaPagarClassConciliacaoBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionContaReceberClassConciliacaoBancaria.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionContaReceberClassConciliacaoBancaria+"\r\n";
                foreach (Entidades.ContaReceberClass tmp in CollectionContaReceberClassConciliacaoBancaria)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem+"\r\n";
                foreach (Entidades.TransferenciaBancariaClass tmp in CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionTransferenciaBancariaClassConciliacaoBancariaDestino.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionTransferenciaBancariaClassConciliacaoBancariaDestino+"\r\n";
                foreach (Entidades.TransferenciaBancariaClass tmp in CollectionTransferenciaBancariaClassConciliacaoBancariaDestino)
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
        public static ConciliacaoBancariaClass CopiarEntidade(ConciliacaoBancariaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               ConciliacaoBancariaClass toRet = new ConciliacaoBancariaClass(usuario,conn);
 toRet.ContaBancaria= entidadeCopiar.ContaBancaria;
 toRet.Data= entidadeCopiar.Data;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;

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
       _contaBancariaOriginal = ContaBancaria;
       _contaBancariaOriginalCommited = _contaBancariaOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;

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
       _contaBancariaOriginalCommited = ContaBancaria;
       _dataOriginalCommited = Data;
       _valorOriginalCommited = Valor;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _versionOriginalCommited = Version;

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
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  if (_collectionContaPagarClassConciliacaoBancariaRemovidos != null) 
                  {
                     _collectionContaPagarClassConciliacaoBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaPagarClassConciliacaoBancariaRemovidos = new List<Entidades.ContaPagarClass>();
                  }
                  _collectionContaPagarClassConciliacaoBancariaOriginal= (from a in _valueCollectionContaPagarClassConciliacaoBancaria select a.ID).ToList();
                  _valueCollectionContaPagarClassConciliacaoBancariaChanged = false;
                  _valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged = false;
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  if (_collectionContaReceberClassConciliacaoBancariaRemovidos != null) 
                  {
                     _collectionContaReceberClassConciliacaoBancariaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionContaReceberClassConciliacaoBancariaRemovidos = new List<Entidades.ContaReceberClass>();
                  }
                  _collectionContaReceberClassConciliacaoBancariaOriginal= (from a in _valueCollectionContaReceberClassConciliacaoBancaria select a.ID).ToList();
                  _valueCollectionContaReceberClassConciliacaoBancariaChanged = false;
                  _valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged = false;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  if (_collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos != null) 
                  {
                     _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                  }
                  _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemOriginal= (from a in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigem select a.ID).ToList();
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged = false;
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged = false;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  if (_collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos != null) 
                  {
                     _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos = new List<Entidades.TransferenciaBancariaClass>();
                  }
                  _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoOriginal= (from a in _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestino select a.ID).ToList();
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged = false;
                  _valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged = false;
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
               ContaBancaria=_contaBancariaOriginal;
               _contaBancariaOriginalCommited=_contaBancariaOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  CollectionContaPagarClassConciliacaoBancaria.Clear();
                  foreach(int item in _collectionContaPagarClassConciliacaoBancariaOriginal)
                  {
                    CollectionContaPagarClassConciliacaoBancaria.Add(Entidades.ContaPagarClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaPagarClassConciliacaoBancariaRemovidos.Clear();
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  CollectionContaReceberClassConciliacaoBancaria.Clear();
                  foreach(int item in _collectionContaReceberClassConciliacaoBancariaOriginal)
                  {
                    CollectionContaReceberClassConciliacaoBancaria.Add(Entidades.ContaReceberClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionContaReceberClassConciliacaoBancariaRemovidos.Clear();
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem.Clear();
                  foreach(int item in _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemOriginal)
                  {
                    CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem.Add(Entidades.TransferenciaBancariaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransferenciaBancariaClassConciliacaoBancariaOrigemRemovidos.Clear();
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  CollectionTransferenciaBancariaClassConciliacaoBancariaDestino.Clear();
                  foreach(int item in _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoOriginal)
                  {
                    CollectionTransferenciaBancariaClassConciliacaoBancariaDestino.Add(Entidades.TransferenciaBancariaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionTransferenciaBancariaClassConciliacaoBancariaDestinoRemovidos.Clear();
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
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  if (_valueCollectionContaPagarClassConciliacaoBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberClassConciliacaoBancariaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                   tempRet = CollectionContaPagarClassConciliacaoBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberClassConciliacaoBancaria.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassConciliacaoBancariaDestino.Any(item => item.IsDirty());
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
       if (_contaBancariaOriginal!=null)
       {
          dirty = !_contaBancariaOriginal.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
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
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  if (_valueCollectionContaPagarClassConciliacaoBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  if (_valueCollectionContaReceberClassConciliacaoBancariaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                   tempRet = CollectionContaPagarClassConciliacaoBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                   tempRet = CollectionContaReceberClassConciliacaoBancaria.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                   tempRet = CollectionTransferenciaBancariaClassConciliacaoBancariaDestino.Any(item => item.IsDirtyCommited());
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
       if (_contaBancariaOriginalCommited!=null)
       {
          dirty = !_contaBancariaOriginalCommited.Equals(ContaBancaria);
       }
       else
       {
            dirty = ContaBancaria != null;
       }
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
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
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassConciliacaoBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassConciliacaoBancaria)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassConciliacaoBancariaDestino)
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
             case "ContaBancaria":
                return this.ContaBancaria;
             case "Data":
                return this.Data;
             case "Valor":
                return this.Valor;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (ContaBancaria!=null)
                ContaBancaria.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
               if (_valueCollectionContaPagarClassConciliacaoBancariaLoaded) 
               {
                  foreach(ContaPagarClass item in CollectionContaPagarClassConciliacaoBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionContaReceberClassConciliacaoBancariaLoaded) 
               {
                  foreach(ContaReceberClass item in CollectionContaReceberClassConciliacaoBancaria)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaOrigemLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassConciliacaoBancariaOrigem)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionTransferenciaBancariaClassConciliacaoBancariaDestinoLoaded) 
               {
                  foreach(TransferenciaBancariaClass item in CollectionTransferenciaBancariaClassConciliacaoBancariaDestino)
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
                  command.CommandText += " COUNT(conciliacao_bancaria.id_conciliacao_bancaria) " ;
               }
               else
               {
               command.CommandText += "conciliacao_bancaria.id_conciliacao_bancaria, " ;
               command.CommandText += "conciliacao_bancaria.id_conta_bancaria, " ;
               command.CommandText += "conciliacao_bancaria.cob_data, " ;
               command.CommandText += "conciliacao_bancaria.cob_valor, " ;
               command.CommandText += "conciliacao_bancaria.id_acs_usuario, " ;
               command.CommandText += "conciliacao_bancaria.entity_uid, " ;
               command.CommandText += "conciliacao_bancaria.version " ;
               }
               command.CommandText += " FROM  conciliacao_bancaria ";
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
                        orderByClause += " , cob_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cob_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = conciliacao_bancaria.id_acs_usuario_ultima_revisao ";
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
                     case "id_conciliacao_bancaria":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria.id_conciliacao_bancaria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria.id_conciliacao_bancaria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_conta_bancaria":
                     case "ContaBancaria":
                     command.CommandText += " LEFT JOIN conta_bancaria as conta_bancaria_ContaBancaria ON conta_bancaria_ContaBancaria.id_conta_bancaria = conciliacao_bancaria.id_conta_bancaria ";                     switch (parametro.TipoOrdenacao)
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
                     case "cob_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria.cob_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria.cob_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cob_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , conciliacao_bancaria.cob_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria.cob_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , conciliacao_bancaria.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , conciliacao_bancaria.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(conciliacao_bancaria.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , conciliacao_bancaria.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(conciliacao_bancaria.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(conciliacao_bancaria.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(conciliacao_bancaria.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_conciliacao_bancaria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conciliacao_bancaria.id_conciliacao_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.id_conciliacao_bancaria = :conciliacao_bancaria_ID_1951 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_ID_1951", NpgsqlDbType.Bigint, parametro.Fieldvalue));
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
                         whereClause += "  conciliacao_bancaria.id_conta_bancaria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.id_conta_bancaria = :conciliacao_bancaria_ContaBancaria_3240 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_ContaBancaria_3240", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "cob_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conciliacao_bancaria.cob_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.cob_data = :conciliacao_bancaria_Data_9256 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_Data_9256", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "cob_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  conciliacao_bancaria.cob_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.cob_valor = :conciliacao_bancaria_Valor_2451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_Valor_2451", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  conciliacao_bancaria.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.id_acs_usuario = :conciliacao_bancaria_AcsUsuario_2106 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_AcsUsuario_2106", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  conciliacao_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.entity_uid LIKE :conciliacao_bancaria_EntityUid_3964 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_EntityUid_3964", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  conciliacao_bancaria.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.version = :conciliacao_bancaria_Version_498 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_Version_498", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  conciliacao_bancaria.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  conciliacao_bancaria.entity_uid LIKE :conciliacao_bancaria_EntityUid_5753 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("conciliacao_bancaria_EntityUid_5753", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  ConciliacaoBancariaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (ConciliacaoBancariaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(ConciliacaoBancariaClass), Convert.ToInt32(read["id_conciliacao_bancaria"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new ConciliacaoBancariaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_conciliacao_bancaria"]);
                     if (read["id_conta_bancaria"] != DBNull.Value)
                     {
                        entidade.ContaBancaria = (BibliotecaEntidades.Entidades.ContaBancariaClass)BibliotecaEntidades.Entidades.ContaBancariaClass.GetEntidade(Convert.ToInt32(read["id_conta_bancaria"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.ContaBancaria = null ;
                     }
                     entidade.Data = (DateTime)read["cob_data"];
                     entidade.Valor = (double)read["cob_valor"];
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
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (ConciliacaoBancariaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
