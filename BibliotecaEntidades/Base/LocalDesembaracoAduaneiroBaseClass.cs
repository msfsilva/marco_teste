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
     [Table("local_desembaraco_aduaneiro","lda")]
     public class LocalDesembaracoAduaneiroBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LocalDesembaracoAduaneiroClass";
protected const string ErroDelete = "Erro ao excluir o LocalDesembaracoAduaneiroClass  ";
protected const string ErroSave = "Erro ao salvar o LocalDesembaracoAduaneiroClass.";
protected const string ErroCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro = "Erro ao carregar a coleção de DeclaracaoImportacaoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do LocalDesembaracoAduaneiroClass.";
protected const string MensagemUtilizadoCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro =  "A entidade LocalDesembaracoAduaneiroClass está sendo utilizada nos seguintes DeclaracaoImportacaoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LocalDesembaracoAduaneiroClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("lda_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
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

       private List<long> _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroOriginal;
       private List<Entidades.DeclaracaoImportacaoClass > _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DeclaracaoImportacaoClass> _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DeclaracaoImportacaoClass> CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro 
       { 
           get { if(!_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded && !this.DisableLoadCollection){this.LoadCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro();}
return this._valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro; } 
           set 
           { 
               this._valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro = value; 
               this._valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded = true; 
           } 
       } 

        public LocalDesembaracoAduaneiroBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static LocalDesembaracoAduaneiroClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LocalDesembaracoAduaneiroClass) GetEntity(typeof(LocalDesembaracoAduaneiroClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged = true;
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged = true; 
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoClass item in e.OldItems) 
                 { 
                     _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged = true; 
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged = true;
                 foreach (Entidades.DeclaracaoImportacaoClass item in _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro) 
                 { 
                     _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro()
         {
            try
            {
                 ObservableCollection<Entidades.DeclaracaoImportacaoClass> oc;
                _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged = false;
                 _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged = false;
                _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos = new List<Entidades.DeclaracaoImportacaoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DeclaracaoImportacaoClass>();
                }
                else{ 
                   Entidades.DeclaracaoImportacaoClass search = new Entidades.DeclaracaoImportacaoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DeclaracaoImportacaoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("LocalDesembaracoAduaneiro", this)                    }                       ).Cast<Entidades.DeclaracaoImportacaoClass>().ToList());
                 }
                 _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro = new BindingList<Entidades.DeclaracaoImportacaoClass>(oc); 
                 _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroOriginal= (from a in _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro select a.ID).ToList();
                 _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded = true;
                 oc.CollectionChanged += CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro+"\r\n" + e.Message, e);
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
                if ( _valueEstado == null)
                {
                    throw new Exception(ErroEstadoObrigatorio);
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
                    "  public.local_desembaraco_aduaneiro  " +
                    "WHERE " +
                    "  id_local_desembaraco_aduaneiro = :id";
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
                        "  public.local_desembaraco_aduaneiro   " +
                        "SET  " + 
                        "  lda_identificacao = :lda_identificacao, " + 
                        "  id_estado = :id_estado, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_local_desembaraco_aduaneiro = :id " +
                        "RETURNING id_local_desembaraco_aduaneiro;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.local_desembaraco_aduaneiro " +
                        "( " +
                        "  lda_identificacao , " + 
                        "  id_estado , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :lda_identificacao , " + 
                        "  :id_estado , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_local_desembaraco_aduaneiro;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lda_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
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
 if (CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro+"\r\n";
                foreach (Entidades.DeclaracaoImportacaoClass tmp in CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro)
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
        public static LocalDesembaracoAduaneiroClass CopiarEntidade(LocalDesembaracoAduaneiroClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LocalDesembaracoAduaneiroClass toRet = new LocalDesembaracoAduaneiroClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Estado= entidadeCopiar.Estado;

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
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
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
       _estadoOriginalCommited = Estado;
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
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  if (_collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos != null) 
                  {
                     _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos = new List<Entidades.DeclaracaoImportacaoClass>();
                  }
                  _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroOriginal= (from a in _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro select a.ID).ToList();
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged = false;
                  _valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged = false;
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
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro.Clear();
                  foreach(int item in _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroOriginal)
                  {
                    CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro.Add(Entidades.DeclaracaoImportacaoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroRemovidos.Clear();
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
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro.Any(item => item.IsDirty());
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
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                   tempRet = CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro.Any(item => item.IsDirtyCommited());
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
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  foreach(DeclaracaoImportacaoClass item in CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro)
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
             case "Estado":
                return this.Estado;
             case "Version":
                return this.Version;
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
               if (_valueCollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiroLoaded) 
               {
                  foreach(DeclaracaoImportacaoClass item in CollectionDeclaracaoImportacaoClassLocalDesembaracoAduaneiro)
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
                  command.CommandText += " COUNT(local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro) " ;
               }
               else
               {
               command.CommandText += "local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro, " ;
               command.CommandText += "local_desembaraco_aduaneiro.lda_identificacao, " ;
               command.CommandText += "local_desembaraco_aduaneiro.id_estado, " ;
               command.CommandText += "local_desembaraco_aduaneiro.version, " ;
               command.CommandText += "local_desembaraco_aduaneiro.entity_uid " ;
               }
               command.CommandText += " FROM  local_desembaraco_aduaneiro ";
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
                        orderByClause += " , lda_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lda_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = local_desembaraco_aduaneiro.id_acs_usuario_ultima_revisao ";
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
                     case "id_local_desembaraco_aduaneiro":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lda_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , local_desembaraco_aduaneiro.lda_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(local_desembaraco_aduaneiro.lda_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = local_desembaraco_aduaneiro.id_estado ";                     switch (parametro.TipoOrdenacao)
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
                           orderByClause += " , local_desembaraco_aduaneiro.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(local_desembaraco_aduaneiro.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , local_desembaraco_aduaneiro.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(local_desembaraco_aduaneiro.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lda_identificacao")) 
                        {
                           whereClause += " OR UPPER(local_desembaraco_aduaneiro.lda_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(local_desembaraco_aduaneiro.lda_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(local_desembaraco_aduaneiro.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(local_desembaraco_aduaneiro.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_local_desembaraco_aduaneiro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.id_local_desembaraco_aduaneiro = :local_desembaraco_aduaneiro_ID_5494 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_ID_5494", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "lda_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  local_desembaraco_aduaneiro.lda_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.lda_identificacao LIKE :local_desembaraco_aduaneiro_Identificacao_6668 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_Identificacao_6668", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  local_desembaraco_aduaneiro.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.id_estado = :local_desembaraco_aduaneiro_Estado_7840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_Estado_7840", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  local_desembaraco_aduaneiro.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.version = :local_desembaraco_aduaneiro_Version_2081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_Version_2081", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  local_desembaraco_aduaneiro.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.entity_uid LIKE :local_desembaraco_aduaneiro_EntityUid_557 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_EntityUid_557", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  local_desembaraco_aduaneiro.lda_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.lda_identificacao LIKE :local_desembaraco_aduaneiro_Identificacao_5503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_Identificacao_5503", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  local_desembaraco_aduaneiro.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  local_desembaraco_aduaneiro.entity_uid LIKE :local_desembaraco_aduaneiro_EntityUid_9847 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("local_desembaraco_aduaneiro_EntityUid_9847", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LocalDesembaracoAduaneiroClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LocalDesembaracoAduaneiroClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LocalDesembaracoAduaneiroClass), Convert.ToInt32(read["id_local_desembaraco_aduaneiro"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LocalDesembaracoAduaneiroClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_local_desembaraco_aduaneiro"]);
                     entidade.Identificacao = (read["lda_identificacao"] != DBNull.Value ? read["lda_identificacao"].ToString() : null);
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LocalDesembaracoAduaneiroClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
