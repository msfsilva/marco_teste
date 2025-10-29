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
     [Table("documento_fiscal_destino","dfd")]
     public class DocumentoFiscalDestinoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do DocumentoFiscalDestinoClass";
protected const string ErroDelete = "Erro ao excluir o DocumentoFiscalDestinoClass  ";
protected const string ErroSave = "Erro ao salvar o DocumentoFiscalDestinoClass.";
protected const string ErroCollectionDocumentoFiscalClassDocumentoFiscalDestino = "Erro ao carregar a coleção de DocumentoFiscalClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do DocumentoFiscalDestinoClass.";
protected const string MensagemUtilizadoCollectionDocumentoFiscalClassDocumentoFiscalDestino =  "A entidade DocumentoFiscalDestinoClass está sendo utilizada nos seguintes DocumentoFiscalClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade DocumentoFiscalDestinoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _estoqueGavetaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.EstoqueGavetaClass _valueEstoqueGaveta;
        [Column("id_estoque_gaveta", "estoque_gaveta", "id_estoque_gaveta")]
       public virtual BibliotecaEntidades.Entidades.EstoqueGavetaClass EstoqueGaveta
        { 
           get {                 return this._valueEstoqueGaveta; } 
           set 
           { 
                if (this._valueEstoqueGaveta == value)return;
                 this._valueEstoqueGaveta = value; 
           } 
       } 

       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("dfd_identificacao")]
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
         [Column("dfd_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       private List<long> _collectionDocumentoFiscalClassDocumentoFiscalDestinoOriginal;
       private List<Entidades.DocumentoFiscalClass > _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.DocumentoFiscalClass> _valueCollectionDocumentoFiscalClassDocumentoFiscalDestino { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.DocumentoFiscalClass> CollectionDocumentoFiscalClassDocumentoFiscalDestino 
       { 
           get { if(!_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded && !this.DisableLoadCollection){this.LoadCollectionDocumentoFiscalClassDocumentoFiscalDestino();}
return this._valueCollectionDocumentoFiscalClassDocumentoFiscalDestino; } 
           set 
           { 
               this._valueCollectionDocumentoFiscalClassDocumentoFiscalDestino = value; 
               this._valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded = true; 
           } 
       } 

        public DocumentoFiscalDestinoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static DocumentoFiscalDestinoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (DocumentoFiscalDestinoClass) GetEntity(typeof(DocumentoFiscalDestinoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionDocumentoFiscalClassDocumentoFiscalDestinoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged = true;
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged = true; 
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged = true;
                 foreach (Entidades.DocumentoFiscalClass item in e.OldItems) 
                 { 
                     _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged = true; 
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged = true;
                 foreach (Entidades.DocumentoFiscalClass item in _valueCollectionDocumentoFiscalClassDocumentoFiscalDestino) 
                 { 
                     _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionDocumentoFiscalClassDocumentoFiscalDestino()
         {
            try
            {
                 ObservableCollection<Entidades.DocumentoFiscalClass> oc;
                _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged = false;
                 _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged = false;
                _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos = new List<Entidades.DocumentoFiscalClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.DocumentoFiscalClass>();
                }
                else{ 
                   Entidades.DocumentoFiscalClass search = new Entidades.DocumentoFiscalClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.DocumentoFiscalClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("DocumentoFiscalDestino", this),                     }                       ).Cast<Entidades.DocumentoFiscalClass>().ToList());
                 }
                 _valueCollectionDocumentoFiscalClassDocumentoFiscalDestino = new BindingList<Entidades.DocumentoFiscalClass>(oc); 
                 _collectionDocumentoFiscalClassDocumentoFiscalDestinoOriginal= (from a in _valueCollectionDocumentoFiscalClassDocumentoFiscalDestino select a.ID).ToList();
                 _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded = true;
                 oc.CollectionChanged += CollectionDocumentoFiscalClassDocumentoFiscalDestinoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionDocumentoFiscalClassDocumentoFiscalDestino+"\r\n" + e.Message, e);
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
                    "  public.documento_fiscal_destino  " +
                    "WHERE " +
                    "  id_documento_fiscal_destino = :id";
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
                        "  public.documento_fiscal_destino   " +
                        "SET  " + 
                        "  id_estoque_gaveta = :id_estoque_gaveta, " + 
                        "  dfd_identificacao = :dfd_identificacao, " + 
                        "  dfd_descricao = :dfd_descricao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_documento_fiscal_destino = :id " +
                        "RETURNING id_documento_fiscal_destino;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.documento_fiscal_destino " +
                        "( " +
                        "  id_estoque_gaveta , " + 
                        "  dfd_identificacao , " + 
                        "  dfd_descricao , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_estoque_gaveta , " + 
                        "  :dfd_identificacao , " + 
                        "  :dfd_descricao , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_documento_fiscal_destino;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estoque_gaveta", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.EstoqueGaveta==null ? (object) DBNull.Value : this.EstoqueGaveta.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dfd_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("dfd_descricao", NpgsqlDbType.Varchar));
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
 if (CollectionDocumentoFiscalClassDocumentoFiscalDestino.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionDocumentoFiscalClassDocumentoFiscalDestino+"\r\n";
                foreach (Entidades.DocumentoFiscalClass tmp in CollectionDocumentoFiscalClassDocumentoFiscalDestino)
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
        public static DocumentoFiscalDestinoClass CopiarEntidade(DocumentoFiscalDestinoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               DocumentoFiscalDestinoClass toRet = new DocumentoFiscalDestinoClass(usuario,conn);
 toRet.EstoqueGaveta= entidadeCopiar.EstoqueGaveta;
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
       _estoqueGavetaOriginal = EstoqueGaveta;
       _estoqueGavetaOriginalCommited = _estoqueGavetaOriginal;
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
       _estoqueGavetaOriginalCommited = EstoqueGaveta;
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
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  if (_collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos != null) 
                  {
                     _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos = new List<Entidades.DocumentoFiscalClass>();
                  }
                  _collectionDocumentoFiscalClassDocumentoFiscalDestinoOriginal= (from a in _valueCollectionDocumentoFiscalClassDocumentoFiscalDestino select a.ID).ToList();
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged = false;
                  _valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged = false;
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
               EstoqueGaveta=_estoqueGavetaOriginal;
               _estoqueGavetaOriginalCommited=_estoqueGavetaOriginal;
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  CollectionDocumentoFiscalClassDocumentoFiscalDestino.Clear();
                  foreach(int item in _collectionDocumentoFiscalClassDocumentoFiscalDestinoOriginal)
                  {
                    CollectionDocumentoFiscalClassDocumentoFiscalDestino.Add(Entidades.DocumentoFiscalClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionDocumentoFiscalClassDocumentoFiscalDestinoRemovidos.Clear();
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
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                   tempRet = CollectionDocumentoFiscalClassDocumentoFiscalDestino.Any(item => item.IsDirty());
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
       if (_estoqueGavetaOriginal!=null)
       {
          dirty = !_estoqueGavetaOriginal.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
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
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                   tempRet = CollectionDocumentoFiscalClassDocumentoFiscalDestino.Any(item => item.IsDirtyCommited());
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
       if (_estoqueGavetaOriginalCommited!=null)
       {
          dirty = !_estoqueGavetaOriginalCommited.Equals(EstoqueGaveta);
       }
       else
       {
            dirty = EstoqueGaveta != null;
       }
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
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  foreach(DocumentoFiscalClass item in CollectionDocumentoFiscalClassDocumentoFiscalDestino)
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
             case "EstoqueGaveta":
                return this.EstoqueGaveta;
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
             if (EstoqueGaveta!=null)
                EstoqueGaveta.ChangeSingleConnection(newConnection);
               if (_valueCollectionDocumentoFiscalClassDocumentoFiscalDestinoLoaded) 
               {
                  foreach(DocumentoFiscalClass item in CollectionDocumentoFiscalClassDocumentoFiscalDestino)
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
                  command.CommandText += " COUNT(documento_fiscal_destino.id_documento_fiscal_destino) " ;
               }
               else
               {
               command.CommandText += "documento_fiscal_destino.id_documento_fiscal_destino, " ;
               command.CommandText += "documento_fiscal_destino.id_estoque_gaveta, " ;
               command.CommandText += "documento_fiscal_destino.dfd_identificacao, " ;
               command.CommandText += "documento_fiscal_destino.dfd_descricao, " ;
               command.CommandText += "documento_fiscal_destino.entity_uid, " ;
               command.CommandText += "documento_fiscal_destino.version " ;
               }
               command.CommandText += " FROM  documento_fiscal_destino ";
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
                        orderByClause += " , dfd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(dfd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = documento_fiscal_destino.id_acs_usuario_ultima_revisao ";
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
                     case "id_documento_fiscal_destino":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , documento_fiscal_destino.id_documento_fiscal_destino " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_fiscal_destino.id_documento_fiscal_destino) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estoque_gaveta":
                     case "EstoqueGaveta":
                     command.CommandText += " LEFT JOIN estoque_gaveta as estoque_gaveta_EstoqueGaveta ON estoque_gaveta_EstoqueGaveta.id_estoque_gaveta = documento_fiscal_destino.id_estoque_gaveta ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , estoque_gaveta_EstoqueGaveta.esg_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(estoque_gaveta_EstoqueGaveta.esg_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dfd_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal_destino.dfd_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal_destino.dfd_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "dfd_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal_destino.dfd_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal_destino.dfd_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_fiscal_destino.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_fiscal_destino.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , documento_fiscal_destino.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(documento_fiscal_destino.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dfd_identificacao")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal_destino.dfd_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal_destino.dfd_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("dfd_descricao")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal_destino.dfd_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal_destino.dfd_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(documento_fiscal_destino.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(documento_fiscal_destino.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_documento_fiscal_destino")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal_destino.id_documento_fiscal_destino IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.id_documento_fiscal_destino = :documento_fiscal_destino_ID_4077 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_ID_4077", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EstoqueGaveta" || parametro.FieldName == "id_estoque_gaveta")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.EstoqueGavetaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.EstoqueGavetaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal_destino.id_estoque_gaveta IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.id_estoque_gaveta = :documento_fiscal_destino_EstoqueGaveta_333 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_EstoqueGaveta_333", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "dfd_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal_destino.dfd_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.dfd_identificacao LIKE :documento_fiscal_destino_Identificacao_4197 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_Identificacao_4197", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "dfd_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  documento_fiscal_destino.dfd_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.dfd_descricao LIKE :documento_fiscal_destino_Descricao_9664 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_Descricao_9664", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_fiscal_destino.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.entity_uid LIKE :documento_fiscal_destino_EntityUid_9533 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_EntityUid_9533", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  documento_fiscal_destino.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.version = :documento_fiscal_destino_Version_3453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_Version_3453", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  documento_fiscal_destino.dfd_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.dfd_identificacao LIKE :documento_fiscal_destino_Identificacao_782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_Identificacao_782", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_fiscal_destino.dfd_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.dfd_descricao LIKE :documento_fiscal_destino_Descricao_4175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_Descricao_4175", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  documento_fiscal_destino.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  documento_fiscal_destino.entity_uid LIKE :documento_fiscal_destino_EntityUid_8321 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("documento_fiscal_destino_EntityUid_8321", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  DocumentoFiscalDestinoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (DocumentoFiscalDestinoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(DocumentoFiscalDestinoClass), Convert.ToInt32(read["id_documento_fiscal_destino"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new DocumentoFiscalDestinoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_documento_fiscal_destino"]);
                     if (read["id_estoque_gaveta"] != DBNull.Value)
                     {
                        entidade.EstoqueGaveta = (BibliotecaEntidades.Entidades.EstoqueGavetaClass)BibliotecaEntidades.Entidades.EstoqueGavetaClass.GetEntidade(Convert.ToInt32(read["id_estoque_gaveta"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.EstoqueGaveta = null ;
                     }
                     entidade.Identificacao = (read["dfd_identificacao"] != DBNull.Value ? read["dfd_identificacao"].ToString() : null);
                     entidade.Descricao = (read["dfd_descricao"] != DBNull.Value ? read["dfd_descricao"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (DocumentoFiscalDestinoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
