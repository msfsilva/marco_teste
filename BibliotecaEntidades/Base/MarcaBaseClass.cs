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
     [Table("marca","mar")]
     public class MarcaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MarcaClass";
protected const string ErroDelete = "Erro ao excluir o MarcaClass  ";
protected const string ErroSave = "Erro ao salvar o MarcaClass.";
protected const string ErroCollectionHistoricoCompraEpiClassMarca = "Erro ao carregar a coleção de HistoricoCompraEpiClass.";
protected const string ErroCollectionHistoricoCompraMaterialClassMarca = "Erro ao carregar a coleção de HistoricoCompraMaterialClass.";
protected const string ErroCollectionHistoricoCompraProdutoClassMarca = "Erro ao carregar a coleção de HistoricoCompraProdutoClass.";
protected const string ErroCollectionSolicitacaoCompraClassMarca = "Erro ao carregar a coleção de SolicitacaoCompraClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do MarcaClass.";
protected const string MensagemUtilizadoCollectionHistoricoCompraEpiClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraEpiClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraMaterialClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraMaterialClass:";
protected const string MensagemUtilizadoCollectionHistoricoCompraProdutoClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes HistoricoCompraProdutoClass:";
protected const string MensagemUtilizadoCollectionSolicitacaoCompraClassMarca =  "A entidade MarcaClass está sendo utilizada nos seguintes SolicitacaoCompraClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MarcaClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("mar_identificacao")]
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
         [Column("mar_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionHistoricoCompraEpiClassMarcaOriginal;
       private List<Entidades.HistoricoCompraEpiClass > _collectionHistoricoCompraEpiClassMarcaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassMarcaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassMarcaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraEpiClass> _valueCollectionHistoricoCompraEpiClassMarca { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraEpiClass> CollectionHistoricoCompraEpiClassMarca 
       { 
           get { if(!_valueCollectionHistoricoCompraEpiClassMarcaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraEpiClassMarca();}
return this._valueCollectionHistoricoCompraEpiClassMarca; } 
           set 
           { 
               this._valueCollectionHistoricoCompraEpiClassMarca = value; 
               this._valueCollectionHistoricoCompraEpiClassMarcaLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraMaterialClassMarcaOriginal;
       private List<Entidades.HistoricoCompraMaterialClass > _collectionHistoricoCompraMaterialClassMarcaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMarcaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMarcaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraMaterialClass> _valueCollectionHistoricoCompraMaterialClassMarca { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraMaterialClass> CollectionHistoricoCompraMaterialClassMarca 
       { 
           get { if(!_valueCollectionHistoricoCompraMaterialClassMarcaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraMaterialClassMarca();}
return this._valueCollectionHistoricoCompraMaterialClassMarca; } 
           set 
           { 
               this._valueCollectionHistoricoCompraMaterialClassMarca = value; 
               this._valueCollectionHistoricoCompraMaterialClassMarcaLoaded = true; 
           } 
       } 

       private List<long> _collectionHistoricoCompraProdutoClassMarcaOriginal;
       private List<Entidades.HistoricoCompraProdutoClass > _collectionHistoricoCompraProdutoClassMarcaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassMarcaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassMarcaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.HistoricoCompraProdutoClass> _valueCollectionHistoricoCompraProdutoClassMarca { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.HistoricoCompraProdutoClass> CollectionHistoricoCompraProdutoClassMarca 
       { 
           get { if(!_valueCollectionHistoricoCompraProdutoClassMarcaLoaded && !this.DisableLoadCollection){this.LoadCollectionHistoricoCompraProdutoClassMarca();}
return this._valueCollectionHistoricoCompraProdutoClassMarca; } 
           set 
           { 
               this._valueCollectionHistoricoCompraProdutoClassMarca = value; 
               this._valueCollectionHistoricoCompraProdutoClassMarcaLoaded = true; 
           } 
       } 

       private List<long> _collectionSolicitacaoCompraClassMarcaOriginal;
       private List<Entidades.SolicitacaoCompraClass > _collectionSolicitacaoCompraClassMarcaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMarcaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMarcaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.SolicitacaoCompraClass> _valueCollectionSolicitacaoCompraClassMarca { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.SolicitacaoCompraClass> CollectionSolicitacaoCompraClassMarca 
       { 
           get { if(!_valueCollectionSolicitacaoCompraClassMarcaLoaded && !this.DisableLoadCollection){this.LoadCollectionSolicitacaoCompraClassMarca();}
return this._valueCollectionSolicitacaoCompraClassMarca; } 
           set 
           { 
               this._valueCollectionSolicitacaoCompraClassMarca = value; 
               this._valueCollectionSolicitacaoCompraClassMarcaLoaded = true; 
           } 
       } 

        public MarcaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MarcaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MarcaClass) GetEntity(typeof(MarcaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionHistoricoCompraEpiClassMarcaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraEpiClassMarcaChanged = true;
                  _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraEpiClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraEpiClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraEpiClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraEpiClass item in _valueCollectionHistoricoCompraEpiClassMarca) 
                 { 
                     _collectionHistoricoCompraEpiClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraEpiClassMarca()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraEpiClass> oc;
                _valueCollectionHistoricoCompraEpiClassMarcaChanged = false;
                 _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged = false;
                _collectionHistoricoCompraEpiClassMarcaRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraEpiClass>();
                }
                else{ 
                   Entidades.HistoricoCompraEpiClass search = new Entidades.HistoricoCompraEpiClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraEpiClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Marca", this),                     }                       ).Cast<Entidades.HistoricoCompraEpiClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraEpiClassMarca = new BindingList<Entidades.HistoricoCompraEpiClass>(oc); 
                 _collectionHistoricoCompraEpiClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraEpiClassMarca select a.ID).ToList();
                 _valueCollectionHistoricoCompraEpiClassMarcaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraEpiClassMarcaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraEpiClassMarca+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraMaterialClassMarcaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraMaterialClassMarcaChanged = true;
                  _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraMaterialClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraMaterialClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraMaterialClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraMaterialClass item in _valueCollectionHistoricoCompraMaterialClassMarca) 
                 { 
                     _collectionHistoricoCompraMaterialClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraMaterialClassMarca()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraMaterialClass> oc;
                _valueCollectionHistoricoCompraMaterialClassMarcaChanged = false;
                 _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged = false;
                _collectionHistoricoCompraMaterialClassMarcaRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraMaterialClass>();
                }
                else{ 
                   Entidades.HistoricoCompraMaterialClass search = new Entidades.HistoricoCompraMaterialClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraMaterialClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Marca", this),                     }                       ).Cast<Entidades.HistoricoCompraMaterialClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraMaterialClassMarca = new BindingList<Entidades.HistoricoCompraMaterialClass>(oc); 
                 _collectionHistoricoCompraMaterialClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassMarca select a.ID).ToList();
                 _valueCollectionHistoricoCompraMaterialClassMarcaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraMaterialClassMarcaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraMaterialClassMarca+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionHistoricoCompraProdutoClassMarcaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionHistoricoCompraProdutoClassMarcaChanged = true;
                  _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionHistoricoCompraProdutoClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in e.OldItems) 
                 { 
                     _collectionHistoricoCompraProdutoClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionHistoricoCompraProdutoClassMarcaChanged = true; 
                  _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged = true;
                 foreach (Entidades.HistoricoCompraProdutoClass item in _valueCollectionHistoricoCompraProdutoClassMarca) 
                 { 
                     _collectionHistoricoCompraProdutoClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionHistoricoCompraProdutoClassMarca()
         {
            try
            {
                 ObservableCollection<Entidades.HistoricoCompraProdutoClass> oc;
                _valueCollectionHistoricoCompraProdutoClassMarcaChanged = false;
                 _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged = false;
                _collectionHistoricoCompraProdutoClassMarcaRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.HistoricoCompraProdutoClass>();
                }
                else{ 
                   Entidades.HistoricoCompraProdutoClass search = new Entidades.HistoricoCompraProdutoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.HistoricoCompraProdutoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Marca", this),                     }                       ).Cast<Entidades.HistoricoCompraProdutoClass>().ToList());
                 }
                 _valueCollectionHistoricoCompraProdutoClassMarca = new BindingList<Entidades.HistoricoCompraProdutoClass>(oc); 
                 _collectionHistoricoCompraProdutoClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassMarca select a.ID).ToList();
                 _valueCollectionHistoricoCompraProdutoClassMarcaLoaded = true;
                 oc.CollectionChanged += CollectionHistoricoCompraProdutoClassMarcaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionHistoricoCompraProdutoClassMarca+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionSolicitacaoCompraClassMarcaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionSolicitacaoCompraClassMarcaChanged = true;
                  _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionSolicitacaoCompraClassMarcaChanged = true; 
                  _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in e.OldItems) 
                 { 
                     _collectionSolicitacaoCompraClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionSolicitacaoCompraClassMarcaChanged = true; 
                  _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged = true;
                 foreach (Entidades.SolicitacaoCompraClass item in _valueCollectionSolicitacaoCompraClassMarca) 
                 { 
                     _collectionSolicitacaoCompraClassMarcaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionSolicitacaoCompraClassMarca()
         {
            try
            {
                 ObservableCollection<Entidades.SolicitacaoCompraClass> oc;
                _valueCollectionSolicitacaoCompraClassMarcaChanged = false;
                 _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged = false;
                _collectionSolicitacaoCompraClassMarcaRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.SolicitacaoCompraClass>();
                }
                else{ 
                   Entidades.SolicitacaoCompraClass search = new Entidades.SolicitacaoCompraClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.SolicitacaoCompraClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Marca", this),                     }                       ).Cast<Entidades.SolicitacaoCompraClass>().ToList());
                 }
                 _valueCollectionSolicitacaoCompraClassMarca = new BindingList<Entidades.SolicitacaoCompraClass>(oc); 
                 _collectionSolicitacaoCompraClassMarcaOriginal= (from a in _valueCollectionSolicitacaoCompraClassMarca select a.ID).ToList();
                 _valueCollectionSolicitacaoCompraClassMarcaLoaded = true;
                 oc.CollectionChanged += CollectionSolicitacaoCompraClassMarcaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionSolicitacaoCompraClassMarca+"\r\n" + e.Message, e);
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
                    "  public.marca  " +
                    "WHERE " +
                    "  id_marca = :id";
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
                        "  public.marca   " +
                        "SET  " + 
                        "  mar_identificacao = :mar_identificacao, " + 
                        "  mar_descricao = :mar_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_marca = :id " +
                        "RETURNING id_marca;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.marca " +
                        "( " +
                        "  mar_identificacao , " + 
                        "  mar_descricao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :mar_identificacao , " + 
                        "  :mar_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_marca;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mar_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mar_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
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
 if (CollectionHistoricoCompraEpiClassMarca.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraEpiClassMarca+"\r\n";
                foreach (Entidades.HistoricoCompraEpiClass tmp in CollectionHistoricoCompraEpiClassMarca)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraMaterialClassMarca.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraMaterialClassMarca+"\r\n";
                foreach (Entidades.HistoricoCompraMaterialClass tmp in CollectionHistoricoCompraMaterialClassMarca)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionHistoricoCompraProdutoClassMarca.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionHistoricoCompraProdutoClassMarca+"\r\n";
                foreach (Entidades.HistoricoCompraProdutoClass tmp in CollectionHistoricoCompraProdutoClassMarca)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionSolicitacaoCompraClassMarca.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionSolicitacaoCompraClassMarca+"\r\n";
                foreach (Entidades.SolicitacaoCompraClass tmp in CollectionSolicitacaoCompraClassMarca)
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
        public static MarcaClass CopiarEntidade(MarcaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MarcaClass toRet = new MarcaClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;

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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
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
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  if (_collectionHistoricoCompraEpiClassMarcaRemovidos != null) 
                  {
                     _collectionHistoricoCompraEpiClassMarcaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraEpiClassMarcaRemovidos = new List<Entidades.HistoricoCompraEpiClass>();
                  }
                  _collectionHistoricoCompraEpiClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraEpiClassMarca select a.ID).ToList();
                  _valueCollectionHistoricoCompraEpiClassMarcaChanged = false;
                  _valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  if (_collectionHistoricoCompraMaterialClassMarcaRemovidos != null) 
                  {
                     _collectionHistoricoCompraMaterialClassMarcaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraMaterialClassMarcaRemovidos = new List<Entidades.HistoricoCompraMaterialClass>();
                  }
                  _collectionHistoricoCompraMaterialClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraMaterialClassMarca select a.ID).ToList();
                  _valueCollectionHistoricoCompraMaterialClassMarcaChanged = false;
                  _valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged = false;
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  if (_collectionHistoricoCompraProdutoClassMarcaRemovidos != null) 
                  {
                     _collectionHistoricoCompraProdutoClassMarcaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionHistoricoCompraProdutoClassMarcaRemovidos = new List<Entidades.HistoricoCompraProdutoClass>();
                  }
                  _collectionHistoricoCompraProdutoClassMarcaOriginal= (from a in _valueCollectionHistoricoCompraProdutoClassMarca select a.ID).ToList();
                  _valueCollectionHistoricoCompraProdutoClassMarcaChanged = false;
                  _valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged = false;
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  if (_collectionSolicitacaoCompraClassMarcaRemovidos != null) 
                  {
                     _collectionSolicitacaoCompraClassMarcaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionSolicitacaoCompraClassMarcaRemovidos = new List<Entidades.SolicitacaoCompraClass>();
                  }
                  _collectionSolicitacaoCompraClassMarcaOriginal= (from a in _valueCollectionSolicitacaoCompraClassMarca select a.ID).ToList();
                  _valueCollectionSolicitacaoCompraClassMarcaChanged = false;
                  _valueCollectionSolicitacaoCompraClassMarcaCommitedChanged = false;
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
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  CollectionHistoricoCompraEpiClassMarca.Clear();
                  foreach(int item in _collectionHistoricoCompraEpiClassMarcaOriginal)
                  {
                    CollectionHistoricoCompraEpiClassMarca.Add(Entidades.HistoricoCompraEpiClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraEpiClassMarcaRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  CollectionHistoricoCompraMaterialClassMarca.Clear();
                  foreach(int item in _collectionHistoricoCompraMaterialClassMarcaOriginal)
                  {
                    CollectionHistoricoCompraMaterialClassMarca.Add(Entidades.HistoricoCompraMaterialClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraMaterialClassMarcaRemovidos.Clear();
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  CollectionHistoricoCompraProdutoClassMarca.Clear();
                  foreach(int item in _collectionHistoricoCompraProdutoClassMarcaOriginal)
                  {
                    CollectionHistoricoCompraProdutoClassMarca.Add(Entidades.HistoricoCompraProdutoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionHistoricoCompraProdutoClassMarcaRemovidos.Clear();
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  CollectionSolicitacaoCompraClassMarca.Clear();
                  foreach(int item in _collectionSolicitacaoCompraClassMarcaOriginal)
                  {
                    CollectionSolicitacaoCompraClassMarca.Add(Entidades.SolicitacaoCompraClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionSolicitacaoCompraClassMarcaRemovidos.Clear();
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
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassMarcaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassMarcaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassMarcaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassMarcaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassMarca.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassMarca.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassMarca.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassMarca.Any(item => item.IsDirty());
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
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
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
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraEpiClassMarcaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraMaterialClassMarcaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  if (_valueCollectionHistoricoCompraProdutoClassMarcaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  if (_valueCollectionSolicitacaoCompraClassMarcaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraEpiClassMarca.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraMaterialClassMarca.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                   tempRet = CollectionHistoricoCompraProdutoClassMarca.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                   tempRet = CollectionSolicitacaoCompraClassMarca.Any(item => item.IsDirtyCommited());
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
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
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
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassMarca)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassMarca)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassMarca)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassMarca)
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
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
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
               if (_valueCollectionHistoricoCompraEpiClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraEpiClass item in CollectionHistoricoCompraEpiClassMarca)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraMaterialClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraMaterialClass item in CollectionHistoricoCompraMaterialClassMarca)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionHistoricoCompraProdutoClassMarcaLoaded) 
               {
                  foreach(HistoricoCompraProdutoClass item in CollectionHistoricoCompraProdutoClassMarca)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionSolicitacaoCompraClassMarcaLoaded) 
               {
                  foreach(SolicitacaoCompraClass item in CollectionSolicitacaoCompraClassMarca)
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
                  command.CommandText += " COUNT(marca.id_marca) " ;
               }
               else
               {
               command.CommandText += "marca.id_marca, " ;
               command.CommandText += "marca.mar_identificacao, " ;
               command.CommandText += "marca.mar_descricao, " ;
               command.CommandText += "marca.entity_uid, " ;
               command.CommandText += "marca.version " ;
               }
               command.CommandText += " FROM  marca ";
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
                        orderByClause += " , mar_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mar_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = marca.id_acs_usuario_ultima_revisao ";
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
                     case "id_marca":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , marca.id_marca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(marca.id_marca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mar_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , marca.mar_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(marca.mar_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mar_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , marca.mar_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(marca.mar_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , marca.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(marca.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , marca.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(marca.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mar_identificacao")) 
                        {
                           whereClause += " OR UPPER(marca.mar_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(marca.mar_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mar_descricao")) 
                        {
                           whereClause += " OR UPPER(marca.mar_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(marca.mar_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(marca.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(marca.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_marca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  marca.id_marca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.id_marca = :marca_ID_5996 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_ID_5996", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "mar_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  marca.mar_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.mar_identificacao LIKE :marca_Identificacao_9517 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_Identificacao_9517", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "mar_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  marca.mar_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.mar_descricao LIKE :marca_Descricao_7541 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_Descricao_7541", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  marca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.entity_uid LIKE :marca_EntityUid_1628 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_EntityUid_1628", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  marca.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.version = :marca_Version_4018 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_Version_4018", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  marca.mar_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.mar_identificacao LIKE :marca_Identificacao_2652 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_Identificacao_2652", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  marca.mar_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.mar_descricao LIKE :marca_Descricao_2218 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_Descricao_2218", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  marca.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  marca.entity_uid LIKE :marca_EntityUid_5233 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("marca_EntityUid_5233", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MarcaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MarcaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MarcaClass), Convert.ToInt32(read["id_marca"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MarcaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_marca"]);
                     entidade.Identificacao = (read["mar_identificacao"] != DBNull.Value ? read["mar_identificacao"].ToString() : null);
                     entidade.Descricao = (read["mar_descricao"] != DBNull.Value ? read["mar_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MarcaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
