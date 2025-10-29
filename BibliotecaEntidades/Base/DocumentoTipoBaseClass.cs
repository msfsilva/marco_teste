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
     [Table("documento_tipo","dot")]
     public class DocumentoTipoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DocumentoTipoClass";
protected const string ErroDelete = "Erro ao excluir o DocumentoTipoClass  ";
protected const string ErroSave = "Erro ao salvar o DocumentoTipoClass.";
protected const string ErroCollectionDocumentoTipoFamiliaClassDocumentoTipo = "Erro ao carregar a coleção de DocumentoTipoFamiliaClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroRevisaoAtualObrigatorio = "O campo RevisaoAtual é obrigatório";
protected const string ErroRevisaoAtualComprimento = "O campo RevisaoAtual deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DocumentoTipoClass.";
protected const string MensagemUtilizadoCollectionDocumentoTipoFamiliaClassDocumentoTipo =  "A entidade DocumentoTipoClass está sendo utilizada nos seguintes DocumentoTipoFamiliaClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoTipoClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("dot_identificacao")]
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
         [Column("dot_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected string _revisaoAtualOriginal{get;private set;}
       private string _revisaoAtualOriginalCommited{get; set;}
        private string _valueRevisaoAtual;
         [Column("dot_revisao_atual")]
        public virtual string RevisaoAtual
         { 
            get { return this._valueRevisaoAtual; } 
            set 
            { 
                if (this._valueRevisaoAtual == value)return;
                 this._valueRevisaoAtual = value; 
            } 
        } 

       private List<long> _collectionDocumentoTipoFamiliaClassDocumentoTipoOriginal;
       private List<Entidades.DocumentoTipoFamiliaClass > _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DocumentoTipoFamiliaClass> _valueCollectionDocumentoTipoFamiliaClassDocumentoTipo { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DocumentoTipoFamiliaClass> CollectionDocumentoTipoFamiliaClassDocumentoTipo 
       { 
           get { if(!_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded && !this.DisableLoadCollection){this.LoadCollectionDocumentoTipoFamiliaClassDocumentoTipo();}
return this._valueCollectionDocumentoTipoFamiliaClassDocumentoTipo; } 
           set 
           { 
               this._valueCollectionDocumentoTipoFamiliaClassDocumentoTipo = value; 
               this._valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded = true; 
           } 
       } 

        public DocumentoTipoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
             base.SalvarValoresAntigosHabilitado = true;
         }

public static DocumentoTipoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DocumentoTipoClass) GetEntity(typeof(DocumentoTipoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDocumentoTipoFamiliaClassDocumentoTipoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged = true;
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged = true; 
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged = true;
                 foreach (Entidades.DocumentoTipoFamiliaClass item in e.OldItems) 
                 { 
                     _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged = true; 
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged = true;
                 foreach (Entidades.DocumentoTipoFamiliaClass item in _valueCollectionDocumentoTipoFamiliaClassDocumentoTipo) 
                 { 
                     _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDocumentoTipoFamiliaClassDocumentoTipo()
         {
            try
            {
                 ObservableCollection<Entidades.DocumentoTipoFamiliaClass> oc;
                _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged = false;
                 _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged = false;
                _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos = new List<Entidades.DocumentoTipoFamiliaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DocumentoTipoFamiliaClass>();
                }
                else{ 
                   Entidades.DocumentoTipoFamiliaClass search = new Entidades.DocumentoTipoFamiliaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DocumentoTipoFamiliaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoTipo", this),                     }                       ).Cast<Entidades.DocumentoTipoFamiliaClass>().ToList());
                 }
                 _valueCollectionDocumentoTipoFamiliaClassDocumentoTipo = new BindingList<Entidades.DocumentoTipoFamiliaClass>(oc); 
                 _collectionDocumentoTipoFamiliaClassDocumentoTipoOriginal= (from a in _valueCollectionDocumentoTipoFamiliaClassDocumentoTipo select a.ID).ToList();
                 _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded = true;
                 oc.CollectionChanged += CollectionDocumentoTipoFamiliaClassDocumentoTipoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDocumentoTipoFamiliaClassDocumentoTipo+"\r\n" + e.Message, e);
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
                if (string.IsNullOrEmpty(RevisaoAtual))
                {
                    throw new Exception(ErroRevisaoAtualObrigatorio);
                }
                if (RevisaoAtual.Length >255)
                {
                    throw new Exception( ErroRevisaoAtualComprimento);
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
                    "  public.documento_tipo  " +
                    "WHERE " +
                    "  id_documento_tipo = :id";
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
                        "  public.documento_tipo   " +
                        "SET  " + 
                        "  dot_identificacao = :dot_identificacao, " + 
                        "  dot_descricao = :dot_descricao, " + 
                        "  dot_revisao_atual = :dot_revisao_atual, " + 
                        "  dot_ultima_revisao = :dot_ultima_revisao, " + 
                        "  dot_ultima_revisao_data = :dot_ultima_revisao_data, " + 
                        "  id_acs_usuario_ultima_revisao = :id_acs_usuario_ultima_revisao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_documento_tipo = :id " +
                        "RETURNING id_documento_tipo;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.documento_tipo " +
                        "( " +
                        "  dot_identificacao , " + 
                        "  dot_descricao , " + 
                        "  dot_revisao_atual , " + 
                        "  dot_ultima_revisao , " + 
                        "  dot_ultima_revisao_data , " + 
                        "  id_acs_usuario_ultima_revisao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :dot_identificacao , " + 
                        "  :dot_descricao , " + 
                        "  :dot_revisao_atual , " + 
                        "  :dot_ultima_revisao , " + 
                        "  :dot_ultima_revisao_data , " + 
                        "  :id_acs_usuario_ultima_revisao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_documento_tipo;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dot_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dot_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dot_revisao_atual", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RevisaoAtual ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dot_ultima_revisao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dot_ultima_revisao_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UltimaRevisaoData ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_ultima_revisao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.UltimaRevisaoUsuario==null ? (object) DBNull.Value : this.UltimaRevisaoUsuario.ID;
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
 if (CollectionDocumentoTipoFamiliaClassDocumentoTipo.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDocumentoTipoFamiliaClassDocumentoTipo+"\r\n";
                foreach (Entidades.DocumentoTipoFamiliaClass tmp in CollectionDocumentoTipoFamiliaClassDocumentoTipo)
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
        public static DocumentoTipoClass CopiarEntidade(DocumentoTipoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DocumentoTipoClass toRet = new DocumentoTipoClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.RevisaoAtual= entidadeCopiar.RevisaoAtual;

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
       _revisaoAtualOriginal = RevisaoAtual;
       _revisaoAtualOriginalCommited = _revisaoAtualOriginal;
       _ultimaRevisaoOriginal = UltimaRevisao;
       _ultimaRevisaoOriginalCommited = _ultimaRevisaoOriginal ;
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
       _revisaoAtualOriginalCommited = RevisaoAtual;
       _ultimaRevisaoOriginalCommited = UltimaRevisao;
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
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  if (_collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos != null) 
                  {
                     _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos = new List<Entidades.DocumentoTipoFamiliaClass>();
                  }
                  _collectionDocumentoTipoFamiliaClassDocumentoTipoOriginal= (from a in _valueCollectionDocumentoTipoFamiliaClassDocumentoTipo select a.ID).ToList();
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged = false;
                  _valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged = false;
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
               RevisaoAtual=_revisaoAtualOriginal;
               _revisaoAtualOriginalCommited=_revisaoAtualOriginal;
               UltimaRevisao=_ultimaRevisaoOriginal;
               _ultimaRevisaoOriginalCommited=_ultimaRevisaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  CollectionDocumentoTipoFamiliaClassDocumentoTipo.Clear();
                  foreach(int item in _collectionDocumentoTipoFamiliaClassDocumentoTipoOriginal)
                  {
                    CollectionDocumentoTipoFamiliaClassDocumentoTipo.Add(Entidades.DocumentoTipoFamiliaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDocumentoTipoFamiliaClassDocumentoTipoRemovidos.Clear();
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
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                   tempRet = CollectionDocumentoTipoFamiliaClassDocumentoTipo.Any(item => item.IsDirty());
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
       dirty = _revisaoAtualOriginal != RevisaoAtual;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginal != UltimaRevisao;
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
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                   tempRet = CollectionDocumentoTipoFamiliaClassDocumentoTipo.Any(item => item.IsDirtyCommited());
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
       dirty = _revisaoAtualOriginalCommited != RevisaoAtual;
      if (dirty) return true;
       dirty = _ultimaRevisaoOriginalCommited != UltimaRevisao;
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
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  foreach(DocumentoTipoFamiliaClass item in CollectionDocumentoTipoFamiliaClassDocumentoTipo)
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
             case "RevisaoAtual":
                return this.RevisaoAtual;
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
               if (_valueCollectionDocumentoTipoFamiliaClassDocumentoTipoLoaded) 
               {
                  foreach(DocumentoTipoFamiliaClass item in CollectionDocumentoTipoFamiliaClassDocumentoTipo)
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
                  command.CommandText += " COUNT(documento_tipo.id_documento_tipo) " ;
               }
               else
               {
               command.CommandText += "documento_tipo.id_documento_tipo, " ;
               command.CommandText += "documento_tipo.dot_identificacao, " ;
               command.CommandText += "documento_tipo.dot_descricao, " ;
               command.CommandText += "documento_tipo.dot_revisao_atual, " ;
               command.CommandText += "documento_tipo.dot_ultima_revisao, " ;
               command.CommandText += "documento_tipo.dot_ultima_revisao_data, " ;
               command.CommandText += "documento_tipo.id_acs_usuario_ultima_revisao, " ;
               command.CommandText += "documento_tipo.entity_uid, " ;
               command.CommandText += "documento_tipo.version " ;
               }
               command.CommandText += " FROM  documento_tipo ";
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
                        orderByClause += " , dot_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dot_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = documento_tipo.id_acs_usuario_ultima_revisao ";
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
                     case "id_documento_tipo":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo.id_documento_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo.id_documento_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dot_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo.dot_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo.dot_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dot_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo.dot_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo.dot_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dot_revisao_atual":
                     case "RevisaoAtual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo.dot_revisao_atual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo.dot_revisao_atual) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dot_ultima_revisao":
                     case "UltimaRevisao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo.dot_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo.dot_ultima_revisao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dot_ultima_revisao_data":
                     case "UltimaRevisaoData":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_tipo.dot_ultima_revisao_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo.dot_ultima_revisao_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_ultima_revisao":
                     case "UltimaRevisaoUsuario":
                     orderByClause += " , documento_tipo.id_acs_usuario_ultima_revisao " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_tipo.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_tipo.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , documento_tipo.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_tipo.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dot_identificacao")) 
                        {
                           whereClause += " OR UPPER(documento_tipo.dot_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo.dot_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dot_descricao")) 
                        {
                           whereClause += " OR UPPER(documento_tipo.dot_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo.dot_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dot_revisao_atual")) 
                        {
                           whereClause += " OR UPPER(documento_tipo.dot_revisao_atual) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo.dot_revisao_atual) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dot_ultima_revisao")) 
                        {
                           whereClause += " OR UPPER(documento_tipo.dot_ultima_revisao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo.dot_ultima_revisao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(documento_tipo.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_tipo.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_documento_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.id_documento_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.id_documento_tipo = :documento_tipo_ID_7980 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_ID_7980", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "dot_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_identificacao LIKE :documento_tipo_Identificacao_2252 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_Identificacao_2252", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "dot_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_descricao LIKE :documento_tipo_Descricao_7569 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_Descricao_7569", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoAtual" || parametro.FieldName == "dot_revisao_atual")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_revisao_atual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_revisao_atual LIKE :documento_tipo_RevisaoAtual_2000 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_RevisaoAtual_2000", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao" || parametro.FieldName == "dot_ultima_revisao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_ultima_revisao LIKE :documento_tipo_UltimaRevisao_9454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_UltimaRevisao_9454", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoData" || parametro.FieldName == "dot_ultima_revisao_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_ultima_revisao_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_ultima_revisao_data = :documento_tipo_UltimaRevisaoData_5269 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_UltimaRevisaoData_5269", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  documento_tipo.id_acs_usuario_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.id_acs_usuario_ultima_revisao = :documento_tipo_UltimaRevisaoUsuario_8575 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_UltimaRevisaoUsuario_8575", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  documento_tipo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.entity_uid LIKE :documento_tipo_EntityUid_5219 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_EntityUid_5219", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_tipo.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.version = :documento_tipo_Version_5026 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_Version_5026", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  documento_tipo.dot_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_identificacao LIKE :documento_tipo_Identificacao_7505 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_Identificacao_7505", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_tipo.dot_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_descricao LIKE :documento_tipo_Descricao_9916 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_Descricao_9916", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RevisaoAtualExato" || parametro.FieldName == "RevisaoAtualExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_tipo.dot_revisao_atual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_revisao_atual LIKE :documento_tipo_RevisaoAtual_6159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_RevisaoAtual_6159", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_tipo.dot_ultima_revisao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.dot_ultima_revisao LIKE :documento_tipo_UltimaRevisao_4599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_UltimaRevisao_4599", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_tipo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_tipo.entity_uid LIKE :documento_tipo_EntityUid_714 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_tipo_EntityUid_714", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DocumentoTipoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DocumentoTipoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DocumentoTipoClass), Convert.ToInt32(read["id_documento_tipo"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DocumentoTipoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_documento_tipo"]);
                     entidade.Identificacao = (read["dot_identificacao"] != DBNull.Value ? read["dot_identificacao"].ToString() : null);
                     entidade.Descricao = (read["dot_descricao"] != DBNull.Value ? read["dot_descricao"].ToString() : null);
                     entidade.RevisaoAtual = (read["dot_revisao_atual"] != DBNull.Value ? read["dot_revisao_atual"].ToString() : null);
                     entidade.UltimaRevisao = (read["dot_ultima_revisao"] != DBNull.Value ? read["dot_ultima_revisao"].ToString() : null);
                     entidade.UltimaRevisaoData = read["dot_ultima_revisao_data"] as DateTime?;
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
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DocumentoTipoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
