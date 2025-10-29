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
     [Table("buffer_email_anexo","bea")]
     public class BufferEmailAnexoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do BufferEmailAnexoClass";
protected const string ErroDelete = "Erro ao excluir o BufferEmailAnexoClass  ";
protected const string ErroSave = "Erro ao salvar o BufferEmailAnexoClass.";
protected const string ErroNomeArquivoObrigatorio = "O campo NomeArquivo é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroBufferEmailObrigatorio = "O campo BufferEmail é obrigatório";
protected const string ErroArquivoObrigatorio = "O campo Arquivo é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do BufferEmailAnexoClass.";
protected const string ErroArquivoLoad = "O campo Arquivo não pode ser carregado";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade BufferEmailAnexoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.BufferEmailClass _bufferEmailOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.BufferEmailClass _bufferEmailOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.BufferEmailClass _valueBufferEmail;
        [Column("id_buffer_email", "buffer_email", "id_buffer_email")]
       public virtual BibliotecaEntidades.Entidades.BufferEmailClass BufferEmail
        { 
           get {                 return this._valueBufferEmail; } 
           set 
           { 
                if (this._valueBufferEmail == value)return;
                 this._valueBufferEmail = value; 
           } 
       } 

       protected string _nomeArquivoOriginal{get;private set;}
       private string _nomeArquivoOriginalCommited{get; set;}
        private string _valueNomeArquivo;
         [Column("bea_nome_arquivo")]
        public virtual string NomeArquivo
         { 
            get { return this._valueNomeArquivo; } 
            set 
            { 
                if (this._valueNomeArquivo == value)return;
                 this._valueNomeArquivo = value; 
            } 
        } 

       protected string _arquivoOriginal= null;
        private string _arquivoOriginalCommited= null;
        private bool _ArquivoLoaded = false;
        [UnCloneable(UnCloneableAttributeType.RetFalse)]
       protected bool ArquivoLoaded 
       { 
            get {                     return _ArquivoLoaded; } 
           set 
           { 
                this._ArquivoLoaded = value;
           } 
       } 
        [UnCloneable(UnCloneableAttributeType.RetNull)] 
         private byte[] _valueArquivo;
         [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
         [Column("bea_arquivo")]
        public virtual byte[] Arquivo
         { 
            get { 
                   if (!this.ArquivoLoaded) 
                   {
                       this.LoadArquivo();
                   }
                   return this._valueArquivo; } 
            set 
            { 
                ArquivoLoaded = true; 
                if (this._valueArquivo == value)return;
                 this._valueArquivo = value; 
            } 
        } 

        public BufferEmailAnexoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static BufferEmailAnexoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (BufferEmailAnexoClass) GetEntity(typeof(BufferEmailAnexoClass),id,usuarioAtual,connection, operacao);
        }
private void LoadArquivo()
        {
            try
            {
                if (this.ID == -1)
                {

                    ArquivoLoaded = true;
                    return;
                }

                IWTPostgreNpgsqlCommand command = this.SingleConnection.CreateCommand();
                command.CommandText = "SELECT bea_arquivo FROM buffer_email_anexo WHERE id_buffer_email_anexo = :id ";
                command.Parameters.Clear();

                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;

                object tmp = command.ExecuteScalar();
                if (tmp != DBNull.Value)
                {
                    this._valueArquivo = (byte[]) tmp;
                }
                if (this._valueArquivo != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _arquivoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                     }
                  } 
                  else 
                  { 
                        _arquivoOriginal = null ;
                  } 
                ArquivoLoaded = true;
            }
            catch (Exception e)
            {
                throw new Exception(ErroArquivoLoad + "\r\n" + e.Message, e);
            }
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeArquivo))
                {
                    throw new Exception(ErroNomeArquivoObrigatorio);
                }
                if (Arquivo==null)
                {
                    throw new Exception(ErroArquivoObrigatorio);
                }
                if ( _valueBufferEmail == null)
                {
                    throw new Exception(ErroBufferEmailObrigatorio);
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
                    "  public.buffer_email_anexo  " +
                    "WHERE " +
                    "  id_buffer_email_anexo = :id";
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
                        "  public.buffer_email_anexo   " +
                        "SET  " + 
                        "  id_buffer_email = :id_buffer_email, " + 
                        "  bea_nome_arquivo = :bea_nome_arquivo, " + 
                        "  bea_arquivo = :bea_arquivo, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_buffer_email_anexo = :id " +
                        "RETURNING id_buffer_email_anexo;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.buffer_email_anexo " +
                        "( " +
                        "  id_buffer_email , " + 
                        "  bea_nome_arquivo , " + 
                        "  bea_arquivo , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_buffer_email , " + 
                        "  :bea_nome_arquivo , " + 
                        "  :bea_arquivo , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_buffer_email_anexo;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_buffer_email", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.BufferEmail==null ? (object) DBNull.Value : this.BufferEmail.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bea_nome_arquivo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeArquivo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("bea_arquivo", NpgsqlDbType.Bytea));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Arquivo ?? DBNull.Value;
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
        public static BufferEmailAnexoClass CopiarEntidade(BufferEmailAnexoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               BufferEmailAnexoClass toRet = new BufferEmailAnexoClass(usuario,conn);
 toRet.BufferEmail= entidadeCopiar.BufferEmail;
 toRet.NomeArquivo= entidadeCopiar.NomeArquivo;
 toRet.Arquivo= entidadeCopiar.Arquivo;

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
       _bufferEmailOriginal = BufferEmail;
       _bufferEmailOriginalCommited = _bufferEmailOriginal;
       _nomeArquivoOriginal = NomeArquivo;
       _nomeArquivoOriginalCommited = _nomeArquivoOriginal;
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
       _bufferEmailOriginalCommited = BufferEmail;
       _nomeArquivoOriginalCommited = NomeArquivo;
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
               if (ArquivoLoaded)
               {
                  if(this._valueArquivo != null)
                  { 
                     using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                     { 
                        _arquivoOriginal = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                     }
                  } 
                  else 
                  { 
                        _arquivoOriginal = null ;
                  } 
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
               BufferEmail=_bufferEmailOriginal;
               _bufferEmailOriginalCommited=_bufferEmailOriginal;
               NomeArquivo=_nomeArquivoOriginal;
               _nomeArquivoOriginalCommited=_nomeArquivoOriginal;
               ArquivoLoaded = false;
               this._arquivoOriginal = null;
               this._arquivoOriginalCommited = null;
               this._valueArquivo = null;
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
       if (_bufferEmailOriginal!=null)
       {
          dirty = !_bufferEmailOriginal.Equals(BufferEmail);
       }
       else
       {
            dirty = BufferEmail != null;
       }
      if (dirty) return true;
       dirty = _nomeArquivoOriginal != NomeArquivo;
      if (dirty) return true;
               if (ArquivoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpArquivo ;
                      if (this._valueArquivo == null) 
                      { 
                         tmpArquivo = null; 
                      } 
                      else 
                      { 
                         tmpArquivo = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                      } 
                       dirty = _arquivoOriginal != tmpArquivo;
                   }
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
       if (_bufferEmailOriginalCommited!=null)
       {
          dirty = !_bufferEmailOriginalCommited.Equals(BufferEmail);
       }
       else
       {
            dirty = BufferEmail != null;
       }
      if (dirty) return true;
       dirty = _nomeArquivoOriginalCommited != NomeArquivo;
      if (dirty) return true;
               if (ArquivoLoaded)
               {
                using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider()) 
                   { 
                      string tmpArquivo ;
                      if (this._valueArquivo == null) 
                      { 
                         tmpArquivo = null; 
                      } 
                      else 
                      { 
                         tmpArquivo = Convert.ToBase64String(sha1.ComputeHash(this._valueArquivo));
                      } 
                       dirty = _arquivoOriginalCommited != tmpArquivo;
                   }
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
             case "BufferEmail":
                return this.BufferEmail;
             case "NomeArquivo":
                return this.NomeArquivo;
             case "Arquivo":
                return this.Arquivo;
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
             if (BufferEmail!=null)
                BufferEmail.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(buffer_email_anexo.id_buffer_email_anexo) " ;
               }
               else
               {
               command.CommandText += "buffer_email_anexo.id_buffer_email_anexo, " ;
               command.CommandText += "buffer_email_anexo.id_buffer_email, " ;
               command.CommandText += "buffer_email_anexo.bea_nome_arquivo, " ;
               command.CommandText += "buffer_email_anexo.entity_uid, " ;
               command.CommandText += "buffer_email_anexo.version " ;
               }
               command.CommandText += " FROM  buffer_email_anexo ";
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
                        orderByClause += " , bea_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(bea_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = buffer_email_anexo.id_acs_usuario_ultima_revisao ";
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
                     case "id_buffer_email_anexo":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email_anexo.id_buffer_email_anexo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email_anexo.id_buffer_email_anexo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_buffer_email":
                     case "BufferEmail":
                     orderByClause += " , buffer_email_anexo.id_buffer_email " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "bea_nome_arquivo":
                     case "NomeArquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email_anexo.bea_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email_anexo.bea_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "bea_arquivo":
                     case "Arquivo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , buffer_email_anexo.bea_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email_anexo.bea_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , buffer_email_anexo.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(buffer_email_anexo.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , buffer_email_anexo.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(buffer_email_anexo.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("bea_nome_arquivo")) 
                        {
                           whereClause += " OR UPPER(buffer_email_anexo.bea_nome_arquivo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email_anexo.bea_nome_arquivo) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(buffer_email_anexo.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(buffer_email_anexo.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_buffer_email_anexo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email_anexo.id_buffer_email_anexo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.id_buffer_email_anexo = :buffer_email_anexo_ID_9255 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_ID_9255", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BufferEmail" || parametro.FieldName == "id_buffer_email")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.BufferEmailClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.BufferEmailClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email_anexo.id_buffer_email IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.id_buffer_email = :buffer_email_anexo_BufferEmail_6988 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_BufferEmail_6988", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivo" || parametro.FieldName == "bea_nome_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email_anexo.bea_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.bea_nome_arquivo LIKE :buffer_email_anexo_NomeArquivo_2117 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_NomeArquivo_2117", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Arquivo" || parametro.FieldName == "bea_arquivo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is byte[])))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo byte[]");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email_anexo.bea_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.bea_arquivo = :buffer_email_anexo_Arquivo_7425 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_Arquivo_7425", NpgsqlDbType.Bytea, parametro.Fieldvalue));
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
                         whereClause += "  buffer_email_anexo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.entity_uid LIKE :buffer_email_anexo_EntityUid_4374 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_EntityUid_4374", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  buffer_email_anexo.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.version = :buffer_email_anexo_Version_2178 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_Version_2178", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeArquivoExato" || parametro.FieldName == "NomeArquivoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  buffer_email_anexo.bea_nome_arquivo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.bea_nome_arquivo LIKE :buffer_email_anexo_NomeArquivo_8319 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_NomeArquivo_8319", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  buffer_email_anexo.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  buffer_email_anexo.entity_uid LIKE :buffer_email_anexo_EntityUid_4430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buffer_email_anexo_EntityUid_4430", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  BufferEmailAnexoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (BufferEmailAnexoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(BufferEmailAnexoClass), Convert.ToInt32(read["id_buffer_email_anexo"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new BufferEmailAnexoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_buffer_email_anexo"]);
                     if (read["id_buffer_email"] != DBNull.Value)
                     {
                        entidade.BufferEmail = (BibliotecaEntidades.Entidades.BufferEmailClass)BibliotecaEntidades.Entidades.BufferEmailClass.GetEntidade(Convert.ToInt32(read["id_buffer_email"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.BufferEmail = null ;
                     }
                     entidade.NomeArquivo = (read["bea_nome_arquivo"] != DBNull.Value ? read["bea_nome_arquivo"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (BufferEmailAnexoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
