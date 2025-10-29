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
     [Table("liberacao_documento","lid")]
     public class LiberacaoDocumentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LiberacaoDocumentoClass";
protected const string ErroDelete = "Erro ao excluir o LiberacaoDocumentoClass  ";
protected const string ErroSave = "Erro ao salvar o LiberacaoDocumentoClass.";
protected const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroDocumentoCopiaObrigatorio = "O campo DocumentoCopia é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroOrdemProducaoDocumentoObrigatorio = "O campo OrdemProducaoDocumento é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do LiberacaoDocumentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LiberacaoDocumentoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.DocumentoCopiaClass _documentoCopiaOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.DocumentoCopiaClass _documentoCopiaOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.DocumentoCopiaClass _valueDocumentoCopia;
        [Column("id_documento_copia", "documento_copia", "id_documento_copia")]
       public virtual BibliotecaEntidades.Entidades.DocumentoCopiaClass DocumentoCopia
        { 
           get {                 return this._valueDocumentoCopia; } 
           set 
           { 
                if (this._valueDocumentoCopia == value)return;
                 this._valueDocumentoCopia = value; 
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

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("lid_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _justificativaOriginal{get;private set;}
       private string _justificativaOriginalCommited{get; set;}
        private string _valueJustificativa;
         [Column("lid_justificativa")]
        public virtual string Justificativa
         { 
            get { return this._valueJustificativa; } 
            set 
            { 
                if (this._valueJustificativa == value)return;
                 this._valueJustificativa = value; 
            } 
        } 

       protected BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass _ordemProducaoDocumentoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass _ordemProducaoDocumentoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass _valueOrdemProducaoDocumento;
        [Column("id_ordem_producao_documento", "ordem_producao_documento", "id_ordem_producao_documento")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass OrdemProducaoDocumento
        { 
           get {                 return this._valueOrdemProducaoDocumento; } 
           set 
           { 
                if (this._valueOrdemProducaoDocumento == value)return;
                 this._valueOrdemProducaoDocumento = value; 
           } 
       } 

        public LiberacaoDocumentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static LiberacaoDocumentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LiberacaoDocumentoClass) GetEntity(typeof(LiberacaoDocumentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Justificativa))
                {
                    throw new Exception(ErroJustificativaObrigatorio);
                }
                if (Justificativa.Length >255)
                {
                    throw new Exception( ErroJustificativaComprimento);
                }
                if ( _valueDocumentoCopia == null)
                {
                    throw new Exception(ErroDocumentoCopiaObrigatorio);
                }
                if ( _valueAcsUsuario == null)
                {
                    throw new Exception(ErroAcsUsuarioObrigatorio);
                }
                if ( _valueOrdemProducaoDocumento == null)
                {
                    throw new Exception(ErroOrdemProducaoDocumentoObrigatorio);
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
                    "  public.liberacao_documento  " +
                    "WHERE " +
                    "  id_liberacao_documento = :id";
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
                        "  public.liberacao_documento   " +
                        "SET  " + 
                        "  id_documento_copia = :id_documento_copia, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  lid_data = :lid_data, " + 
                        "  lid_justificativa = :lid_justificativa, " + 
                        "  id_ordem_producao_documento = :id_ordem_producao_documento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_liberacao_documento = :id " +
                        "RETURNING id_liberacao_documento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.liberacao_documento " +
                        "( " +
                        "  id_documento_copia , " + 
                        "  id_acs_usuario , " + 
                        "  lid_data , " + 
                        "  lid_justificativa , " + 
                        "  id_ordem_producao_documento , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_documento_copia , " + 
                        "  :id_acs_usuario , " + 
                        "  :lid_data , " + 
                        "  :lid_justificativa , " + 
                        "  :id_ordem_producao_documento , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_liberacao_documento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_documento_copia", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.DocumentoCopia==null ? (object) DBNull.Value : this.DocumentoCopia.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lid_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lid_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Justificativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_documento", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoDocumento==null ? (object) DBNull.Value : this.OrdemProducaoDocumento.ID;
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
        public static LiberacaoDocumentoClass CopiarEntidade(LiberacaoDocumentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LiberacaoDocumentoClass toRet = new LiberacaoDocumentoClass(usuario,conn);
 toRet.DocumentoCopia= entidadeCopiar.DocumentoCopia;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Data= entidadeCopiar.Data;
 toRet.Justificativa= entidadeCopiar.Justificativa;
 toRet.OrdemProducaoDocumento= entidadeCopiar.OrdemProducaoDocumento;

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
       _documentoCopiaOriginal = DocumentoCopia;
       _documentoCopiaOriginalCommited = _documentoCopiaOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _justificativaOriginal = Justificativa;
       _justificativaOriginalCommited = _justificativaOriginal;
       _ordemProducaoDocumentoOriginal = OrdemProducaoDocumento;
       _ordemProducaoDocumentoOriginalCommited = _ordemProducaoDocumentoOriginal;
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
       _documentoCopiaOriginalCommited = DocumentoCopia;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataOriginalCommited = Data;
       _justificativaOriginalCommited = Justificativa;
       _ordemProducaoDocumentoOriginalCommited = OrdemProducaoDocumento;
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
               DocumentoCopia=_documentoCopiaOriginal;
               _documentoCopiaOriginalCommited=_documentoCopiaOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Justificativa=_justificativaOriginal;
               _justificativaOriginalCommited=_justificativaOriginal;
               OrdemProducaoDocumento=_ordemProducaoDocumentoOriginal;
               _ordemProducaoDocumentoOriginalCommited=_ordemProducaoDocumentoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;

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
       if (_documentoCopiaOriginal!=null)
       {
          dirty = !_documentoCopiaOriginal.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
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
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _justificativaOriginal != Justificativa;
      if (dirty) return true;
       if (_ordemProducaoDocumentoOriginal!=null)
       {
          dirty = !_ordemProducaoDocumentoOriginal.Equals(OrdemProducaoDocumento);
       }
       else
       {
            dirty = OrdemProducaoDocumento != null;
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
       if (_documentoCopiaOriginalCommited!=null)
       {
          dirty = !_documentoCopiaOriginalCommited.Equals(DocumentoCopia);
       }
       else
       {
            dirty = DocumentoCopia != null;
       }
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
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _justificativaOriginalCommited != Justificativa;
      if (dirty) return true;
       if (_ordemProducaoDocumentoOriginalCommited!=null)
       {
          dirty = !_ordemProducaoDocumentoOriginalCommited.Equals(OrdemProducaoDocumento);
       }
       else
       {
            dirty = OrdemProducaoDocumento != null;
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
             case "DocumentoCopia":
                return this.DocumentoCopia;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Data":
                return this.Data;
             case "Justificativa":
                return this.Justificativa;
             case "OrdemProducaoDocumento":
                return this.OrdemProducaoDocumento;
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
             if (DocumentoCopia!=null)
                DocumentoCopia.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
             if (OrdemProducaoDocumento!=null)
                OrdemProducaoDocumento.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(liberacao_documento.id_liberacao_documento) " ;
               }
               else
               {
               command.CommandText += "liberacao_documento.id_liberacao_documento, " ;
               command.CommandText += "liberacao_documento.id_documento_copia, " ;
               command.CommandText += "liberacao_documento.id_acs_usuario, " ;
               command.CommandText += "liberacao_documento.lid_data, " ;
               command.CommandText += "liberacao_documento.lid_justificativa, " ;
               command.CommandText += "liberacao_documento.id_ordem_producao_documento, " ;
               command.CommandText += "liberacao_documento.entity_uid, " ;
               command.CommandText += "liberacao_documento.version " ;
               }
               command.CommandText += " FROM  liberacao_documento ";
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
                        orderByClause += " , lid_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lid_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = liberacao_documento.id_acs_usuario_ultima_revisao ";
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
                     case "id_liberacao_documento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , liberacao_documento.id_liberacao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(liberacao_documento.id_liberacao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_documento_copia":
                     case "DocumentoCopia":
                     command.CommandText += " LEFT JOIN documento_copia as documento_copia_DocumentoCopia ON documento_copia_DocumentoCopia.id_documento_copia = liberacao_documento.id_documento_copia ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , documento_copia_DocumentoCopia.doc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(documento_copia_DocumentoCopia.doc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , liberacao_documento.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "lid_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , liberacao_documento.lid_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(liberacao_documento.lid_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lid_justificativa":
                     case "Justificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , liberacao_documento.lid_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(liberacao_documento.lid_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_documento":
                     case "OrdemProducaoDocumento":
                     command.CommandText += " LEFT JOIN ordem_producao_documento as ordem_producao_documento_OrdemProducaoDocumento ON ordem_producao_documento_OrdemProducaoDocumento.id_ordem_producao_documento = liberacao_documento.id_ordem_producao_documento ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_documento_OrdemProducaoDocumento.id_ordem_producao_documento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_documento_OrdemProducaoDocumento.id_ordem_producao_documento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , liberacao_documento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(liberacao_documento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , liberacao_documento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(liberacao_documento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lid_justificativa")) 
                        {
                           whereClause += " OR UPPER(liberacao_documento.lid_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(liberacao_documento.lid_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(liberacao_documento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(liberacao_documento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_liberacao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.id_liberacao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.id_liberacao_documento = :liberacao_documento_ID_1886 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_ID_1886", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DocumentoCopia" || parametro.FieldName == "id_documento_copia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.DocumentoCopiaClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.DocumentoCopiaClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.id_documento_copia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.id_documento_copia = :liberacao_documento_DocumentoCopia_6931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_DocumentoCopia_6931", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  liberacao_documento.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.id_acs_usuario = :liberacao_documento_AcsUsuario_6757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_AcsUsuario_6757", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "lid_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.lid_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.lid_data = :liberacao_documento_Data_4187 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_Data_4187", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Justificativa" || parametro.FieldName == "lid_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.lid_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.lid_justificativa LIKE :liberacao_documento_Justificativa_5264 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_Justificativa_5264", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoDocumento" || parametro.FieldName == "id_ordem_producao_documento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.id_ordem_producao_documento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.id_ordem_producao_documento = :liberacao_documento_OrdemProducaoDocumento_8815 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_OrdemProducaoDocumento_8815", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  liberacao_documento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.entity_uid LIKE :liberacao_documento_EntityUid_975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_EntityUid_975", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  liberacao_documento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.version = :liberacao_documento_Version_6544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_Version_6544", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "JustificativaExato" || parametro.FieldName == "JustificativaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  liberacao_documento.lid_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.lid_justificativa LIKE :liberacao_documento_Justificativa_1280 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_Justificativa_1280", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  liberacao_documento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  liberacao_documento.entity_uid LIKE :liberacao_documento_EntityUid_5894 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("liberacao_documento_EntityUid_5894", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LiberacaoDocumentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LiberacaoDocumentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LiberacaoDocumentoClass), Convert.ToInt32(read["id_liberacao_documento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LiberacaoDocumentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_liberacao_documento"]);
                     if (read["id_documento_copia"] != DBNull.Value)
                     {
                        entidade.DocumentoCopia = (BibliotecaEntidades.Entidades.DocumentoCopiaClass)BibliotecaEntidades.Entidades.DocumentoCopiaClass.GetEntidade(Convert.ToInt32(read["id_documento_copia"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.DocumentoCopia = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Data = (DateTime)read["lid_data"];
                     entidade.Justificativa = (read["lid_justificativa"] != DBNull.Value ? read["lid_justificativa"].ToString() : null);
                     if (read["id_ordem_producao_documento"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoDocumento = (BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass)BibliotecaEntidades.Entidades.OrdemProducaoDocumentoClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_documento"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoDocumento = null ;
                     }
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LiberacaoDocumentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
