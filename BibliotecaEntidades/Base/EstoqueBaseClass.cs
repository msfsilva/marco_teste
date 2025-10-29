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
     [Table("estoque","est")]
     public class EstoqueBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do EstoqueClass";
protected const string ErroDelete = "Erro ao excluir o EstoqueClass  ";
protected const string ErroSave = "Erro ao salvar o EstoqueClass.";
protected const string ErroCollectionEstoqueCorredorClassEstoque = "Erro ao carregar a coleção de EstoqueCorredorClass.";
protected const string ErroCollectionEstoqueHistoricoValorClassEstoque = "Erro ao carregar a coleção de EstoqueHistoricoValorClass.";
protected const string ErroCollectionOrdemProducaoDiferencaClassEstoque = "Erro ao carregar a coleção de OrdemProducaoDiferencaClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do EstoqueClass.";
protected const string MensagemUtilizadoCollectionEstoqueCorredorClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueCorredorClass:";
protected const string MensagemUtilizadoCollectionEstoqueHistoricoValorClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes EstoqueHistoricoValorClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDiferencaClassEstoque =  "A entidade EstoqueClass está sendo utilizada nos seguintes OrdemProducaoDiferencaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade EstoqueClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("est_identificacao")]
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
         [Column("est_descricao")]
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
         [Column("est_ativo")]
        public virtual bool Ativo
         { 
            get { return this._valueAtivo; } 
            set 
            { 
                if (this._valueAtivo == value)return;
                 this._valueAtivo = value; 
            } 
        } 

       protected EASITipoAlocacaoEstoque _tipoAlocacaoEstoqueOriginal{get;private set;}
       private EASITipoAlocacaoEstoque _tipoAlocacaoEstoqueOriginalCommited{get; set;}
        private EASITipoAlocacaoEstoque _valueTipoAlocacaoEstoque;
         [Column("est_tipo_alocacao_estoque")]
        public virtual EASITipoAlocacaoEstoque TipoAlocacaoEstoque
         { 
            get { return this._valueTipoAlocacaoEstoque; } 
            set 
            { 
                if (this._valueTipoAlocacaoEstoque == value)return;
                 this._valueTipoAlocacaoEstoque = value; 
            } 
        } 

        public bool TipoAlocacaoEstoque_MateriaPrima
         { 
            get { return this._valueTipoAlocacaoEstoque == BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.MateriaPrima; } 
            set { if (value) this._valueTipoAlocacaoEstoque = BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.MateriaPrima; }
         } 

        public bool TipoAlocacaoEstoque_Consumo
         { 
            get { return this._valueTipoAlocacaoEstoque == BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.Consumo; } 
            set { if (value) this._valueTipoAlocacaoEstoque = BibliotecaEntidades.Base.EASITipoAlocacaoEstoque.Consumo; }
         } 

       private List<long> _collectionEstoqueCorredorClassEstoqueOriginal;
       private List<Entidades.EstoqueCorredorClass > _collectionEstoqueCorredorClassEstoqueRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueCorredorClassEstoqueLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueCorredorClassEstoqueChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueCorredorClass> _valueCollectionEstoqueCorredorClassEstoque { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueCorredorClass> CollectionEstoqueCorredorClassEstoque 
       { 
           get { if(!_valueCollectionEstoqueCorredorClassEstoqueLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueCorredorClassEstoque();}
return this._valueCollectionEstoqueCorredorClassEstoque; } 
           set 
           { 
               this._valueCollectionEstoqueCorredorClassEstoque = value; 
               this._valueCollectionEstoqueCorredorClassEstoqueLoaded = true; 
           } 
       } 

       private List<long> _collectionEstoqueHistoricoValorClassEstoqueOriginal;
       private List<Entidades.EstoqueHistoricoValorClass > _collectionEstoqueHistoricoValorClassEstoqueRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueHistoricoValorClassEstoqueLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueHistoricoValorClassEstoqueChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.EstoqueHistoricoValorClass> _valueCollectionEstoqueHistoricoValorClassEstoque { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.EstoqueHistoricoValorClass> CollectionEstoqueHistoricoValorClassEstoque 
       { 
           get { if(!_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded && !this.DisableLoadCollection){this.LoadCollectionEstoqueHistoricoValorClassEstoque();}
return this._valueCollectionEstoqueHistoricoValorClassEstoque; } 
           set 
           { 
               this._valueCollectionEstoqueHistoricoValorClassEstoque = value; 
               this._valueCollectionEstoqueHistoricoValorClassEstoqueLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDiferencaClassEstoqueOriginal;
       private List<Entidades.OrdemProducaoDiferencaClass > _collectionOrdemProducaoDiferencaClassEstoqueRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDiferencaClass> _valueCollectionOrdemProducaoDiferencaClassEstoque { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDiferencaClass> CollectionOrdemProducaoDiferencaClassEstoque 
       { 
           get { if(!_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDiferencaClassEstoque();}
return this._valueCollectionOrdemProducaoDiferencaClassEstoque; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDiferencaClassEstoque = value; 
               this._valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded = true; 
           } 
       } 

        public EstoqueBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Ativo = true;
           this.TipoAlocacaoEstoque = (EASITipoAlocacaoEstoque)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static EstoqueClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (EstoqueClass) GetEntity(typeof(EstoqueClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionEstoqueCorredorClassEstoqueChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueCorredorClassEstoqueChanged = true;
                  _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueCorredorClassEstoqueChanged = true; 
                  _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged = true;
                 foreach (Entidades.EstoqueCorredorClass item in e.OldItems) 
                 { 
                     _collectionEstoqueCorredorClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueCorredorClassEstoqueChanged = true; 
                  _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged = true;
                 foreach (Entidades.EstoqueCorredorClass item in _valueCollectionEstoqueCorredorClassEstoque) 
                 { 
                     _collectionEstoqueCorredorClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueCorredorClassEstoque()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueCorredorClass> oc;
                _valueCollectionEstoqueCorredorClassEstoqueChanged = false;
                 _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged = false;
                _collectionEstoqueCorredorClassEstoqueRemovidos = new List<Entidades.EstoqueCorredorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueCorredorClass>();
                }
                else{ 
                   Entidades.EstoqueCorredorClass search = new Entidades.EstoqueCorredorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueCorredorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estoque", this)                    }                       ).Cast<Entidades.EstoqueCorredorClass>().ToList());
                 }
                 _valueCollectionEstoqueCorredorClassEstoque = new BindingList<Entidades.EstoqueCorredorClass>(oc); 
                 _collectionEstoqueCorredorClassEstoqueOriginal= (from a in _valueCollectionEstoqueCorredorClassEstoque select a.ID).ToList();
                 _valueCollectionEstoqueCorredorClassEstoqueLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueCorredorClassEstoqueChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueCorredorClassEstoque+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionEstoqueHistoricoValorClassEstoqueChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionEstoqueHistoricoValorClassEstoqueChanged = true;
                  _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionEstoqueHistoricoValorClassEstoqueChanged = true; 
                  _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged = true;
                 foreach (Entidades.EstoqueHistoricoValorClass item in e.OldItems) 
                 { 
                     _collectionEstoqueHistoricoValorClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionEstoqueHistoricoValorClassEstoqueChanged = true; 
                  _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged = true;
                 foreach (Entidades.EstoqueHistoricoValorClass item in _valueCollectionEstoqueHistoricoValorClassEstoque) 
                 { 
                     _collectionEstoqueHistoricoValorClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionEstoqueHistoricoValorClassEstoque()
         {
            try
            {
                 ObservableCollection<Entidades.EstoqueHistoricoValorClass> oc;
                _valueCollectionEstoqueHistoricoValorClassEstoqueChanged = false;
                 _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged = false;
                _collectionEstoqueHistoricoValorClassEstoqueRemovidos = new List<Entidades.EstoqueHistoricoValorClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.EstoqueHistoricoValorClass>();
                }
                else{ 
                   Entidades.EstoqueHistoricoValorClass search = new Entidades.EstoqueHistoricoValorClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.EstoqueHistoricoValorClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estoque", this),                     }                       ).Cast<Entidades.EstoqueHistoricoValorClass>().ToList());
                 }
                 _valueCollectionEstoqueHistoricoValorClassEstoque = new BindingList<Entidades.EstoqueHistoricoValorClass>(oc); 
                 _collectionEstoqueHistoricoValorClassEstoqueOriginal= (from a in _valueCollectionEstoqueHistoricoValorClassEstoque select a.ID).ToList();
                 _valueCollectionEstoqueHistoricoValorClassEstoqueLoaded = true;
                 oc.CollectionChanged += CollectionEstoqueHistoricoValorClassEstoqueChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionEstoqueHistoricoValorClassEstoque+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDiferencaClassEstoqueChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged = true;
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDiferencaClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged = true; 
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDiferencaClass item in _valueCollectionOrdemProducaoDiferencaClassEstoque) 
                 { 
                     _collectionOrdemProducaoDiferencaClassEstoqueRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDiferencaClassEstoque()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDiferencaClass> oc;
                _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged = false;
                 _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged = false;
                _collectionOrdemProducaoDiferencaClassEstoqueRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDiferencaClass search = new Entidades.OrdemProducaoDiferencaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDiferencaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Estoque", this),                     }                       ).Cast<Entidades.OrdemProducaoDiferencaClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDiferencaClassEstoque = new BindingList<Entidades.OrdemProducaoDiferencaClass>(oc); 
                 _collectionOrdemProducaoDiferencaClassEstoqueOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassEstoque select a.ID).ToList();
                 _valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDiferencaClassEstoqueChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDiferencaClassEstoque+"\r\n" + e.Message, e);
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
                    "  public.estoque  " +
                    "WHERE " +
                    "  id_estoque = :id";
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
                        "  public.estoque   " +
                        "SET  " + 
                        "  est_identificacao = :est_identificacao, " + 
                        "  est_descricao = :est_descricao, " + 
                        "  est_ultima_revisao = :est_ultima_revisao, " + 
                        "  est_ultima_revisao_data = :est_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  est_ativo = :est_ativo, " + 
                        "  est_tipo_alocacao_estoque = :est_tipo_alocacao_estoque "+
                        "WHERE  " +
                        "  id_estoque = :id " +
                        "RETURNING id_estoque;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.estoque " +
                        "( " +
                        "  est_identificacao , " + 
                        "  est_descricao , " + 
                        "  est_ultima_revisao , " + 
                        "  est_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  est_ativo , " + 
                        "  est_tipo_alocacao_estoque  "+
                        ")  " +
                        "VALUES ( " +
                        "  :est_identificacao , " + 
                        "  :est_descricao , " + 
                        "  :est_ultima_revisao , " + 
                        "  :est_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :est_ativo , " + 
                        "  :est_tipo_alocacao_estoque  "+
                        ")RETURNING id_estoque;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_ativo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Ativo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("est_tipo_alocacao_estoque", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.TipoAlocacaoEstoque);

 
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
 if (CollectionEstoqueCorredorClassEstoque.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueCorredorClassEstoque+"\r\n";
                foreach (Entidades.EstoqueCorredorClass tmp in CollectionEstoqueCorredorClassEstoque)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionEstoqueHistoricoValorClassEstoque.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionEstoqueHistoricoValorClassEstoque+"\r\n";
                foreach (Entidades.EstoqueHistoricoValorClass tmp in CollectionEstoqueHistoricoValorClassEstoque)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDiferencaClassEstoque.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDiferencaClassEstoque+"\r\n";
                foreach (Entidades.OrdemProducaoDiferencaClass tmp in CollectionOrdemProducaoDiferencaClassEstoque)
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
        public static EstoqueClass CopiarEntidade(EstoqueClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               EstoqueClass toRet = new EstoqueClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Ativo= entidadeCopiar.Ativo;
 toRet.TipoAlocacaoEstoque= entidadeCopiar.TipoAlocacaoEstoque;

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
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _ativoOriginal = Ativo;
       _ativoOriginalCommited = _ativoOriginal;
       _tipoAlocacaoEstoqueOriginal = TipoAlocacaoEstoque;
       _tipoAlocacaoEstoqueOriginalCommited = _tipoAlocacaoEstoqueOriginal;

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
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
       _versionOriginalCommited = Version;
       _ativoOriginalCommited = Ativo;
       _tipoAlocacaoEstoqueOriginalCommited = TipoAlocacaoEstoque;

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
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  if (_collectionEstoqueCorredorClassEstoqueRemovidos != null) 
                  {
                     _collectionEstoqueCorredorClassEstoqueRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueCorredorClassEstoqueRemovidos = new List<Entidades.EstoqueCorredorClass>();
                  }
                  _collectionEstoqueCorredorClassEstoqueOriginal= (from a in _valueCollectionEstoqueCorredorClassEstoque select a.ID).ToList();
                  _valueCollectionEstoqueCorredorClassEstoqueChanged = false;
                  _valueCollectionEstoqueCorredorClassEstoqueCommitedChanged = false;
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  if (_collectionEstoqueHistoricoValorClassEstoqueRemovidos != null) 
                  {
                     _collectionEstoqueHistoricoValorClassEstoqueRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionEstoqueHistoricoValorClassEstoqueRemovidos = new List<Entidades.EstoqueHistoricoValorClass>();
                  }
                  _collectionEstoqueHistoricoValorClassEstoqueOriginal= (from a in _valueCollectionEstoqueHistoricoValorClassEstoque select a.ID).ToList();
                  _valueCollectionEstoqueHistoricoValorClassEstoqueChanged = false;
                  _valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  if (_collectionOrdemProducaoDiferencaClassEstoqueRemovidos != null) 
                  {
                     _collectionOrdemProducaoDiferencaClassEstoqueRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDiferencaClassEstoqueRemovidos = new List<Entidades.OrdemProducaoDiferencaClass>();
                  }
                  _collectionOrdemProducaoDiferencaClassEstoqueOriginal= (from a in _valueCollectionOrdemProducaoDiferencaClassEstoque select a.ID).ToList();
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueChanged = false;
                  _valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged = false;
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
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Ativo=_ativoOriginal;
               _ativoOriginalCommited=_ativoOriginal;
               TipoAlocacaoEstoque=_tipoAlocacaoEstoqueOriginal;
               _tipoAlocacaoEstoqueOriginalCommited=_tipoAlocacaoEstoqueOriginal;
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  CollectionEstoqueCorredorClassEstoque.Clear();
                  foreach(int item in _collectionEstoqueCorredorClassEstoqueOriginal)
                  {
                    CollectionEstoqueCorredorClassEstoque.Add(Entidades.EstoqueCorredorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueCorredorClassEstoqueRemovidos.Clear();
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  CollectionEstoqueHistoricoValorClassEstoque.Clear();
                  foreach(int item in _collectionEstoqueHistoricoValorClassEstoqueOriginal)
                  {
                    CollectionEstoqueHistoricoValorClassEstoque.Add(Entidades.EstoqueHistoricoValorClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionEstoqueHistoricoValorClassEstoqueRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  CollectionOrdemProducaoDiferencaClassEstoque.Clear();
                  foreach(int item in _collectionOrdemProducaoDiferencaClassEstoqueOriginal)
                  {
                    CollectionOrdemProducaoDiferencaClassEstoque.Add(Entidades.OrdemProducaoDiferencaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDiferencaClassEstoqueRemovidos.Clear();
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
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  if (_valueCollectionEstoqueCorredorClassEstoqueChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  if (_valueCollectionEstoqueHistoricoValorClassEstoqueChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassEstoqueChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                   tempRet = CollectionEstoqueCorredorClassEstoque.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                   tempRet = CollectionEstoqueHistoricoValorClassEstoque.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassEstoque.Any(item => item.IsDirty());
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
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _ativoOriginal != Ativo;
      if (dirty) return true;
       dirty = _tipoAlocacaoEstoqueOriginal != TipoAlocacaoEstoque;

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
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  if (_valueCollectionEstoqueCorredorClassEstoqueCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  if (_valueCollectionEstoqueHistoricoValorClassEstoqueCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDiferencaClassEstoqueCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                   tempRet = CollectionEstoqueCorredorClassEstoque.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                   tempRet = CollectionEstoqueHistoricoValorClassEstoque.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDiferencaClassEstoque.Any(item => item.IsDirtyCommited());
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
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _ativoOriginalCommited != Ativo;
      if (dirty) return true;
       dirty = _tipoAlocacaoEstoqueOriginalCommited != TipoAlocacaoEstoque;

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
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  foreach(EstoqueCorredorClass item in CollectionEstoqueCorredorClassEstoque)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  foreach(EstoqueHistoricoValorClass item in CollectionEstoqueHistoricoValorClassEstoque)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassEstoque)
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
             case "Ativo":
                return this.Ativo;
             case "TipoAlocacaoEstoque":
                return this.TipoAlocacaoEstoque;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionEstoqueCorredorClassEstoqueLoaded) 
               {
                  foreach(EstoqueCorredorClass item in CollectionEstoqueCorredorClassEstoque)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionEstoqueHistoricoValorClassEstoqueLoaded) 
               {
                  foreach(EstoqueHistoricoValorClass item in CollectionEstoqueHistoricoValorClassEstoque)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDiferencaClassEstoqueLoaded) 
               {
                  foreach(OrdemProducaoDiferencaClass item in CollectionOrdemProducaoDiferencaClassEstoque)
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
                  command.CommandText += " COUNT(estoque.id_estoque) " ;
               }
               else
               {
               command.CommandText += "estoque.id_estoque, " ;
               command.CommandText += "estoque.est_identificacao, " ;
               command.CommandText += "estoque.est_descricao, " ;
               command.CommandText += "estoque.est_ultima_revisao, " ;
               command.CommandText += "estoque.est_ultima_revisao_data, " ;
               command.CommandText += "estoque.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "estoque.entity_uid, " ;
               command.CommandText += "estoque.version, " ;
               command.CommandText += "estoque.est_ativo, " ;
               command.CommandText += "estoque.est_tipo_alocacao_estoque " ;
               }
               command.CommandText += " FROM  estoque ";
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
                        orderByClause += " , est_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(est_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = estoque.id_acs_usuario_ultima_revisao ";
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
                     case "id_estoque":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque.id_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque.id_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque.est_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque.est_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque.est_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque.est_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque.est_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque.est_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque.est_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque.est_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , estoque.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , estoque.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_ativo":
                     case "Ativo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque.est_ativo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque.est_ativo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "est_tipo_alocacao_estoque":
                     case "TipoAlocacaoEstoque":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , estoque.est_tipo_alocacao_estoque " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(estoque.est_tipo_alocacao_estoque) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("est_identificacao")) 
                        {
                           whereClause += " OR UPPER(estoque.est_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque.est_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("est_descricao")) 
                        {
                           whereClause += " OR UPPER(estoque.est_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque.est_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("est_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(estoque.est_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque.est_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(estoque.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(estoque.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.id_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.id_estoque = :estoque_ID_2616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_ID_2616", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "est_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_identificacao LIKE :estoque_Identificacao_479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Identificacao_479", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "est_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_descricao LIKE :estoque_Descricao_7298 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Descricao_7298", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "est_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_ultima_revisao LIKE :estoque_UltimaRevisao_2729 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_UltimaRevisao_2729", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "est_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_ultima_revisao_data = :estoque_UltimaRevisaoData_4725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_UltimaRevisaoData_4725", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario" || parametro.FieldName == "id_acs_usuario_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.id_acs_usuario_ultima_revisao = :estoque_UltimaRevisaoUsuario_3118 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_UltimaRevisaoUsuario_3118", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  estoque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.entity_uid LIKE :estoque_EntityUid_9374 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_EntityUid_9374", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  estoque.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.version = :estoque_Version_2328 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Version_2328", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ativo" || parametro.FieldName == "est_ativo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_ativo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_ativo = :estoque_Ativo_7110 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Ativo_7110", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoAlocacaoEstoque" || parametro.FieldName == "est_tipo_alocacao_estoque")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EASITipoAlocacaoEstoque)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EASITipoAlocacaoEstoque");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_tipo_alocacao_estoque IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_tipo_alocacao_estoque = :estoque_TipoAlocacaoEstoque_3635 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_TipoAlocacaoEstoque_3635", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  estoque.est_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_identificacao LIKE :estoque_Identificacao_8919 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Identificacao_8919", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque.est_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_descricao LIKE :estoque_Descricao_775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_Descricao_775", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoExato" || parametro.FieldName == "UltimaRevisaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  estoque.est_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.est_ultima_revisao LIKE :estoque_UltimaRevisao_5642 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_UltimaRevisao_5642", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  estoque.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  estoque.entity_uid LIKE :estoque_EntityUid_6190 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("estoque_EntityUid_6190", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  EstoqueClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (EstoqueClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(EstoqueClass), Convert.ToInt32(read["id_estoque"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new EstoqueClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_estoque"]);
                     entidade.Identificacao = (read["est_identificacao"] != DBNull.Value ? read["est_identificacao"].ToString() : null);
                     entidade.Descricao = (read["est_descricao"] != DBNull.Value ? read["est_descricao"].ToString() : null);
                     entidade.UltimaRevisao = (read["est_ultima_revisao"] != DBNull.Value ? read["est_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["est_ultima_revisao_data"] as DateTime?;
                     if (read["id_acs_usuario_ultima_revisao"] != DBNull.Value)
                     {
                        entidade.UltimaRevisaoUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario_ultima_revisao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.UltimaRevisaoUsuario = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Ativo = Convert.ToBoolean(Convert.ToInt16(read["est_ativo"]));
                     entidade.TipoAlocacaoEstoque = (EASITipoAlocacaoEstoque) (read["est_tipo_alocacao_estoque"] != DBNull.Value ? Enum.ToObject(typeof(EASITipoAlocacaoEstoque), read["est_tipo_alocacao_estoque"]) : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (EstoqueClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
