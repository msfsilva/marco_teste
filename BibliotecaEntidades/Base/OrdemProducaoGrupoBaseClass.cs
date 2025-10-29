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
     [Table("ordem_producao_grupo","opg")]
     public class OrdemProducaoGrupoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoGrupoClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoGrupoClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoGrupoClass.";
protected const string ErroCollectionOrdemProducaoClassOrdemProducaoGrupo = "Erro ao carregar a coleção de OrdemProducaoClass.";
protected const string ErroCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo = "Erro ao carregar a coleção de OrdemProducaoDocumentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoGrupoClass.";
protected const string MensagemUtilizadoCollectionOrdemProducaoClassOrdemProducaoGrupo =  "A entidade OrdemProducaoGrupoClass está sendo utilizada nos seguintes OrdemProducaoClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo =  "A entidade OrdemProducaoGrupoClass está sendo utilizada nos seguintes OrdemProducaoDocumentoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoGrupoClass está sendo utilizada.";
#endregion
       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("opg_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       private List<long> _collectionOrdemProducaoClassOrdemProducaoGrupoOriginal;
       private List<Entidades.OrdemProducaoClass > _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoClass> _valueCollectionOrdemProducaoClassOrdemProducaoGrupo { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoClass> CollectionOrdemProducaoClassOrdemProducaoGrupo 
       { 
           get { if(!_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoClassOrdemProducaoGrupo();}
return this._valueCollectionOrdemProducaoClassOrdemProducaoGrupo; } 
           set 
           { 
               this._valueCollectionOrdemProducaoClassOrdemProducaoGrupo = value; 
               this._valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoOriginal;
       private List<Entidades.OrdemProducaoDocumentoClass > _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoDocumentoClass> _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoDocumentoClass> CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo 
       { 
           get { if(!_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo();}
return this._valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo; } 
           set 
           { 
               this._valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo = value; 
               this._valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded = true; 
           } 
       } 

        public OrdemProducaoGrupoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Data = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OrdemProducaoGrupoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoGrupoClass) GetEntity(typeof(OrdemProducaoGrupoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrdemProducaoClassOrdemProducaoGrupoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged = true;
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged = true; 
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged = true; 
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoClass item in _valueCollectionOrdemProducaoClassOrdemProducaoGrupo) 
                 { 
                     _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoClassOrdemProducaoGrupo()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoClass> oc;
                _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged = false;
                 _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged = false;
                _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos = new List<Entidades.OrdemProducaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoClass search = new Entidades.OrdemProducaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoGrupo", this)                    }                       ).Cast<Entidades.OrdemProducaoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoClassOrdemProducaoGrupo = new BindingList<Entidades.OrdemProducaoClass>(oc); 
                 _collectionOrdemProducaoClassOrdemProducaoGrupoOriginal= (from a in _valueCollectionOrdemProducaoClassOrdemProducaoGrupo select a.ID).ToList();
                 _valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoClassOrdemProducaoGrupoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoClassOrdemProducaoGrupo+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged = true;
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged = true; 
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoDocumentoClass item in _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo) 
                 { 
                     _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoDocumentoClass> oc;
                _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged = false;
                 _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged = false;
                _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>();
                }
                else{ 
                   Entidades.OrdemProducaoDocumentoClass search = new Entidades.OrdemProducaoDocumentoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoDocumentoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OrdemProducaoGrupo", this),                     }                       ).Cast<Entidades.OrdemProducaoDocumentoClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo = new BindingList<Entidades.OrdemProducaoDocumentoClass>(oc); 
                 _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo select a.ID).ToList();
                 _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {

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
                    "  public.ordem_producao_grupo  " +
                    "WHERE " +
                    "  id_ordem_producao_grupo = :id";
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
                        "  public.ordem_producao_grupo   " +
                        "SET  " + 
                        "  opg_data = :opg_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_grupo = :id " +
                        "RETURNING id_ordem_producao_grupo;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_grupo " +
                        "( " +
                        "  opg_data , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :opg_data , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_grupo;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opg_data", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
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
 if (CollectionOrdemProducaoClassOrdemProducaoGrupo.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoClassOrdemProducaoGrupo+"\r\n";
                foreach (Entidades.OrdemProducaoClass tmp in CollectionOrdemProducaoClassOrdemProducaoGrupo)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo+"\r\n";
                foreach (Entidades.OrdemProducaoDocumentoClass tmp in CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo)
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
        public static OrdemProducaoGrupoClass CopiarEntidade(OrdemProducaoGrupoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoGrupoClass toRet = new OrdemProducaoGrupoClass(usuario,conn);
 toRet.Data= entidadeCopiar.Data;

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
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
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
       _dataOriginalCommited = Data;
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
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos != null) 
                  {
                     _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos = new List<Entidades.OrdemProducaoClass>();
                  }
                  _collectionOrdemProducaoClassOrdemProducaoGrupoOriginal= (from a in _valueCollectionOrdemProducaoClassOrdemProducaoGrupo select a.ID).ToList();
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged = false;
                  _valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos != null) 
                  {
                     _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos = new List<Entidades.OrdemProducaoDocumentoClass>();
                  }
                  _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoOriginal= (from a in _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo select a.ID).ToList();
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged = false;
                  _valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged = false;
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
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  CollectionOrdemProducaoClassOrdemProducaoGrupo.Clear();
                  foreach(int item in _collectionOrdemProducaoClassOrdemProducaoGrupoOriginal)
                  {
                    CollectionOrdemProducaoClassOrdemProducaoGrupo.Add(Entidades.OrdemProducaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoClassOrdemProducaoGrupoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo.Clear();
                  foreach(int item in _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoOriginal)
                  {
                    CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo.Add(Entidades.OrdemProducaoDocumentoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoDocumentoClassOrdemProducaoGrupoRemovidos.Clear();
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
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassOrdemProducaoGrupo.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo.Any(item => item.IsDirty());
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
       dirty = _dataOriginal != Data;
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
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoClassOrdemProducaoGrupo.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo.Any(item => item.IsDirtyCommited());
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
       dirty = _dataOriginalCommited != Data;
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
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassOrdemProducaoGrupo)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo)
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
             case "Data":
                return this.Data;
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
               if (_valueCollectionOrdemProducaoClassOrdemProducaoGrupoLoaded) 
               {
                  foreach(OrdemProducaoClass item in CollectionOrdemProducaoClassOrdemProducaoGrupo)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoDocumentoClassOrdemProducaoGrupoLoaded) 
               {
                  foreach(OrdemProducaoDocumentoClass item in CollectionOrdemProducaoDocumentoClassOrdemProducaoGrupo)
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
                  command.CommandText += " COUNT(ordem_producao_grupo.id_ordem_producao_grupo) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_grupo.id_ordem_producao_grupo, " ;
               command.CommandText += "ordem_producao_grupo.opg_data, " ;
               command.CommandText += "ordem_producao_grupo.entity_uid, " ;
               command.CommandText += "ordem_producao_grupo.version " ;
               }
               command.CommandText += " FROM  ordem_producao_grupo ";
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
                        orderByClause += " , opg_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opg_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_grupo.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_grupo":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_grupo.id_ordem_producao_grupo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_grupo.id_ordem_producao_grupo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opg_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_grupo.opg_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_grupo.opg_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_grupo.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_grupo.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_grupo.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_grupo.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(ordem_producao_grupo.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_grupo.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_grupo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_grupo.id_ordem_producao_grupo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_grupo.id_ordem_producao_grupo = :ordem_producao_grupo_ID_6629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_grupo_ID_6629", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "opg_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_grupo.opg_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_grupo.opg_data = :ordem_producao_grupo_Data_4984 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_grupo_Data_4984", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  ordem_producao_grupo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_grupo.entity_uid LIKE :ordem_producao_grupo_EntityUid_2241 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_grupo_EntityUid_2241", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_grupo.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_grupo.version = :ordem_producao_grupo_Version_7700 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_grupo_Version_7700", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_grupo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_grupo.entity_uid LIKE :ordem_producao_grupo_EntityUid_1162 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_grupo_EntityUid_1162", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoGrupoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoGrupoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoGrupoClass), Convert.ToInt32(read["id_ordem_producao_grupo"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoGrupoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_grupo"]);
                     entidade.Data = (DateTime)read["opg_data"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoGrupoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
