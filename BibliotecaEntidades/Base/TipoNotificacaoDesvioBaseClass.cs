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
     [Table("tipo_notificacao_desvio","tnd")]
     public class TipoNotificacaoDesvioBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do TipoNotificacaoDesvioClass";
protected const string ErroDelete = "Erro ao excluir o TipoNotificacaoDesvioClass  ";
protected const string ErroSave = "Erro ao salvar o TipoNotificacaoDesvioClass.";
protected const string ErroCollectionNotificacaoDesvioClassTipoNotificacaoDesvio = "Erro ao carregar a coleção de NotificacaoDesvioClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do TipoNotificacaoDesvioClass.";
protected const string MensagemUtilizadoCollectionNotificacaoDesvioClassTipoNotificacaoDesvio =  "A entidade TipoNotificacaoDesvioClass está sendo utilizada nos seguintes NotificacaoDesvioClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade TipoNotificacaoDesvioClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("tnd_identificacao")]
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
         [Column("tnd_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionNotificacaoDesvioClassTipoNotificacaoDesvioOriginal;
       private List<Entidades.NotificacaoDesvioClass > _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.NotificacaoDesvioClass> _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.NotificacaoDesvioClass> CollectionNotificacaoDesvioClassTipoNotificacaoDesvio 
       { 
           get { if(!_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded && !this.DisableLoadCollection){this.LoadCollectionNotificacaoDesvioClassTipoNotificacaoDesvio();}
return this._valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio; } 
           set 
           { 
               this._valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio = value; 
               this._valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded = true; 
           } 
       } 

        public TipoNotificacaoDesvioBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static TipoNotificacaoDesvioClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (TipoNotificacaoDesvioClass) GetEntity(typeof(TipoNotificacaoDesvioClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionNotificacaoDesvioClassTipoNotificacaoDesvioChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged = true;
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged = true; 
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in e.OldItems) 
                 { 
                     _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged = true; 
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged = true;
                 foreach (Entidades.NotificacaoDesvioClass item in _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio) 
                 { 
                     _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionNotificacaoDesvioClassTipoNotificacaoDesvio()
         {
            try
            {
                 ObservableCollection<Entidades.NotificacaoDesvioClass> oc;
                _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged = false;
                 _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged = false;
                _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.NotificacaoDesvioClass>();
                }
                else{ 
                   Entidades.NotificacaoDesvioClass search = new Entidades.NotificacaoDesvioClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.NotificacaoDesvioClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("TipoNotificacaoDesvio", this),                     }                       ).Cast<Entidades.NotificacaoDesvioClass>().ToList());
                 }
                 _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio = new BindingList<Entidades.NotificacaoDesvioClass>(oc); 
                 _collectionNotificacaoDesvioClassTipoNotificacaoDesvioOriginal= (from a in _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio select a.ID).ToList();
                 _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded = true;
                 oc.CollectionChanged += CollectionNotificacaoDesvioClassTipoNotificacaoDesvioChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionNotificacaoDesvioClassTipoNotificacaoDesvio+"\r\n" + e.Message, e);
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
                    "  public.tipo_notificacao_desvio  " +
                    "WHERE " +
                    "  id_tipo_notificacao_desvio = :id";
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
                        "  public.tipo_notificacao_desvio   " +
                        "SET  " + 
                        "  tnd_identificacao = :tnd_identificacao, " + 
                        "  tnd_descricao = :tnd_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_tipo_notificacao_desvio = :id " +
                        "RETURNING id_tipo_notificacao_desvio;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.tipo_notificacao_desvio " +
                        "( " +
                        "  tnd_identificacao , " + 
                        "  tnd_descricao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :tnd_identificacao , " + 
                        "  :tnd_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_tipo_notificacao_desvio;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tnd_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tnd_descricao", NpgsqlDbType.Varchar));
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
 if (CollectionNotificacaoDesvioClassTipoNotificacaoDesvio.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionNotificacaoDesvioClassTipoNotificacaoDesvio+"\r\n";
                foreach (Entidades.NotificacaoDesvioClass tmp in CollectionNotificacaoDesvioClassTipoNotificacaoDesvio)
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
        public static TipoNotificacaoDesvioClass CopiarEntidade(TipoNotificacaoDesvioClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               TipoNotificacaoDesvioClass toRet = new TipoNotificacaoDesvioClass(usuario,conn);
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  if (_collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos != null) 
                  {
                     _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos = new List<Entidades.NotificacaoDesvioClass>();
                  }
                  _collectionNotificacaoDesvioClassTipoNotificacaoDesvioOriginal= (from a in _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvio select a.ID).ToList();
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged = false;
                  _valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged = false;
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  CollectionNotificacaoDesvioClassTipoNotificacaoDesvio.Clear();
                  foreach(int item in _collectionNotificacaoDesvioClassTipoNotificacaoDesvioOriginal)
                  {
                    CollectionNotificacaoDesvioClassTipoNotificacaoDesvio.Add(Entidades.NotificacaoDesvioClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionNotificacaoDesvioClassTipoNotificacaoDesvioRemovidos.Clear();
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassTipoNotificacaoDesvio.Any(item => item.IsDirty());
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                   tempRet = CollectionNotificacaoDesvioClassTipoNotificacaoDesvio.Any(item => item.IsDirtyCommited());
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassTipoNotificacaoDesvio)
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
               if (_valueCollectionNotificacaoDesvioClassTipoNotificacaoDesvioLoaded) 
               {
                  foreach(NotificacaoDesvioClass item in CollectionNotificacaoDesvioClassTipoNotificacaoDesvio)
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
                  command.CommandText += " COUNT(tipo_notificacao_desvio.id_tipo_notificacao_desvio) " ;
               }
               else
               {
               command.CommandText += "tipo_notificacao_desvio.id_tipo_notificacao_desvio, " ;
               command.CommandText += "tipo_notificacao_desvio.tnd_identificacao, " ;
               command.CommandText += "tipo_notificacao_desvio.tnd_descricao, " ;
               command.CommandText += "tipo_notificacao_desvio.entity_uid, " ;
               command.CommandText += "tipo_notificacao_desvio.version " ;
               }
               command.CommandText += " FROM  tipo_notificacao_desvio ";
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
                        orderByClause += " , tnd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(tnd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = tipo_notificacao_desvio.id_acs_usuario_ultima_revisao ";
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
                     case "id_tipo_notificacao_desvio":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , tipo_notificacao_desvio.id_tipo_notificacao_desvio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_notificacao_desvio.id_tipo_notificacao_desvio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tnd_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_notificacao_desvio.tnd_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_notificacao_desvio.tnd_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "tnd_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_notificacao_desvio.tnd_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_notificacao_desvio.tnd_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , tipo_notificacao_desvio.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(tipo_notificacao_desvio.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , tipo_notificacao_desvio.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(tipo_notificacao_desvio.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("tnd_identificacao")) 
                        {
                           whereClause += " OR UPPER(tipo_notificacao_desvio.tnd_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_notificacao_desvio.tnd_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("tnd_descricao")) 
                        {
                           whereClause += " OR UPPER(tipo_notificacao_desvio.tnd_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_notificacao_desvio.tnd_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(tipo_notificacao_desvio.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(tipo_notificacao_desvio.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_tipo_notificacao_desvio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_notificacao_desvio.id_tipo_notificacao_desvio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.id_tipo_notificacao_desvio = :tipo_notificacao_desvio_ID_7174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_ID_7174", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "tnd_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_identificacao LIKE :tipo_notificacao_desvio_Identificacao_3414 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_Identificacao_3414", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "tnd_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_descricao LIKE :tipo_notificacao_desvio_Descricao_432 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_Descricao_432", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_notificacao_desvio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.entity_uid LIKE :tipo_notificacao_desvio_EntityUid_4732 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_EntityUid_4732", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  tipo_notificacao_desvio.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.version = :tipo_notificacao_desvio_Version_733 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_Version_733", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  tipo_notificacao_desvio.tnd_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_identificacao LIKE :tipo_notificacao_desvio_Identificacao_974 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_Identificacao_974", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  tipo_notificacao_desvio.tnd_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.tnd_descricao LIKE :tipo_notificacao_desvio_Descricao_376 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_Descricao_376", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  tipo_notificacao_desvio.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  tipo_notificacao_desvio.entity_uid LIKE :tipo_notificacao_desvio_EntityUid_491 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("tipo_notificacao_desvio_EntityUid_491", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  TipoNotificacaoDesvioClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (TipoNotificacaoDesvioClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(TipoNotificacaoDesvioClass), Convert.ToInt32(read["id_tipo_notificacao_desvio"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new TipoNotificacaoDesvioClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_tipo_notificacao_desvio"]);
                     entidade.Identificacao = (read["tnd_identificacao"] != DBNull.Value ? read["tnd_identificacao"].ToString() : null);
                     entidade.Descricao = (read["tnd_descricao"] != DBNull.Value ? read["tnd_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (TipoNotificacaoDesvioClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
