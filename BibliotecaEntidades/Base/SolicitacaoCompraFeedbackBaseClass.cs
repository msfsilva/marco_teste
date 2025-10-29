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
     [Table("solicitacao_compra_feedback","scf")]
     public class SolicitacaoCompraFeedbackBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do SolicitacaoCompraFeedbackClass";
protected const string ErroDelete = "Erro ao excluir o SolicitacaoCompraFeedbackClass  ";
protected const string ErroSave = "Erro ao salvar o SolicitacaoCompraFeedbackClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroSolicitacaoCompraObrigatorio = "O campo SolicitacaoCompra é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do SolicitacaoCompraFeedbackClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade SolicitacaoCompraFeedbackClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.SolicitacaoCompraClass _solicitacaoCompraOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.SolicitacaoCompraClass _solicitacaoCompraOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.SolicitacaoCompraClass _valueSolicitacaoCompra;
        [Column("id_solicitacao_compra", "solicitacao_compra", "id_solicitacao_compra")]
       public virtual BibliotecaEntidades.Entidades.SolicitacaoCompraClass SolicitacaoCompra
        { 
           get {                 return this._valueSolicitacaoCompra; } 
           set 
           { 
                if (this._valueSolicitacaoCompra == value)return;
                 this._valueSolicitacaoCompra = value; 
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
         [Column("scf_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected bool _atualOriginal{get;private set;}
       private bool _atualOriginalCommited{get; set;}
        private bool _valueAtual;
         [Column("scf_atual")]
        public virtual bool Atual
         { 
            get { return this._valueAtual; } 
            set 
            { 
                if (this._valueAtual == value)return;
                 this._valueAtual = value; 
            } 
        } 

       protected string _textoOriginal{get;private set;}
       private string _textoOriginalCommited{get; set;}
        private string _valueTexto;
         [Column("scf_texto")]
        public virtual string Texto
         { 
            get { return this._valueTexto; } 
            set 
            { 
                if (this._valueTexto == value)return;
                 this._valueTexto = value; 
            } 
        } 

        public SolicitacaoCompraFeedbackBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Atual = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static SolicitacaoCompraFeedbackClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (SolicitacaoCompraFeedbackClass) GetEntity(typeof(SolicitacaoCompraFeedbackClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueSolicitacaoCompra == null)
                {
                    throw new Exception(ErroSolicitacaoCompraObrigatorio);
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
                    "  public.solicitacao_compra_feedback  " +
                    "WHERE " +
                    "  id_solicitacao_compra_feedback = :id";
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
                        "  public.solicitacao_compra_feedback   " +
                        "SET  " + 
                        "  id_solicitacao_compra = :id_solicitacao_compra, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  scf_data = :scf_data, " + 
                        "  scf_atual = :scf_atual, " + 
                        "  scf_texto = :scf_texto, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_solicitacao_compra_feedback = :id " +
                        "RETURNING id_solicitacao_compra_feedback;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.solicitacao_compra_feedback " +
                        "( " +
                        "  id_solicitacao_compra , " + 
                        "  id_acs_usuario , " + 
                        "  scf_data , " + 
                        "  scf_atual , " + 
                        "  scf_texto , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_solicitacao_compra , " + 
                        "  :id_acs_usuario , " + 
                        "  :scf_data , " + 
                        "  :scf_atual , " + 
                        "  :scf_texto , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_solicitacao_compra_feedback;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.SolicitacaoCompra==null ? (object) DBNull.Value : this.SolicitacaoCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("scf_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("scf_atual", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Atual ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("scf_texto", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Texto ?? DBNull.Value;
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
        public static SolicitacaoCompraFeedbackClass CopiarEntidade(SolicitacaoCompraFeedbackClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               SolicitacaoCompraFeedbackClass toRet = new SolicitacaoCompraFeedbackClass(usuario,conn);
 toRet.SolicitacaoCompra= entidadeCopiar.SolicitacaoCompra;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Data= entidadeCopiar.Data;
 toRet.Atual= entidadeCopiar.Atual;
 toRet.Texto= entidadeCopiar.Texto;

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
       _solicitacaoCompraOriginal = SolicitacaoCompra;
       _solicitacaoCompraOriginalCommited = _solicitacaoCompraOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _atualOriginal = Atual;
       _atualOriginalCommited = _atualOriginal;
       _textoOriginal = Texto;
       _textoOriginalCommited = _textoOriginal;
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
       _solicitacaoCompraOriginalCommited = SolicitacaoCompra;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataOriginalCommited = Data;
       _atualOriginalCommited = Atual;
       _textoOriginalCommited = Texto;
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
               SolicitacaoCompra=_solicitacaoCompraOriginal;
               _solicitacaoCompraOriginalCommited=_solicitacaoCompraOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Atual=_atualOriginal;
               _atualOriginalCommited=_atualOriginal;
               Texto=_textoOriginal;
               _textoOriginalCommited=_textoOriginal;
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
       if (_solicitacaoCompraOriginal!=null)
       {
          dirty = !_solicitacaoCompraOriginal.Equals(SolicitacaoCompra);
       }
       else
       {
            dirty = SolicitacaoCompra != null;
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
       dirty = _atualOriginal != Atual;
      if (dirty) return true;
       dirty = _textoOriginal != Texto;
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
       if (_solicitacaoCompraOriginalCommited!=null)
       {
          dirty = !_solicitacaoCompraOriginalCommited.Equals(SolicitacaoCompra);
       }
       else
       {
            dirty = SolicitacaoCompra != null;
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
       dirty = _atualOriginalCommited != Atual;
      if (dirty) return true;
       dirty = _textoOriginalCommited != Texto;
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
             case "SolicitacaoCompra":
                return this.SolicitacaoCompra;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Data":
                return this.Data;
             case "Atual":
                return this.Atual;
             case "Texto":
                return this.Texto;
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
             if (SolicitacaoCompra!=null)
                SolicitacaoCompra.ChangeSingleConnection(newConnection);
             if (AcsUsuario!=null)
                AcsUsuario.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(solicitacao_compra_feedback.id_solicitacao_compra_feedback) " ;
               }
               else
               {
               command.CommandText += "solicitacao_compra_feedback.id_solicitacao_compra_feedback, " ;
               command.CommandText += "solicitacao_compra_feedback.id_solicitacao_compra, " ;
               command.CommandText += "solicitacao_compra_feedback.id_acs_usuario, " ;
               command.CommandText += "solicitacao_compra_feedback.scf_data, " ;
               command.CommandText += "solicitacao_compra_feedback.scf_atual, " ;
               command.CommandText += "solicitacao_compra_feedback.scf_texto, " ;
               command.CommandText += "solicitacao_compra_feedback.version, " ;
               command.CommandText += "solicitacao_compra_feedback.entity_uid " ;
               }
               command.CommandText += " FROM  solicitacao_compra_feedback ";
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
                        orderByClause += " , scf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(scf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = solicitacao_compra_feedback.id_acs_usuario_ultima_revisao ";
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
                     case "id_solicitacao_compra_feedback":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra_feedback.id_solicitacao_compra_feedback " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.id_solicitacao_compra_feedback) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_solicitacao_compra":
                     case "SolicitacaoCompra":
                     command.CommandText += " LEFT JOIN solicitacao_compra as solicitacao_compra_SolicitacaoCompra ON solicitacao_compra_SolicitacaoCompra.id_solicitacao_compra = solicitacao_compra_feedback.id_solicitacao_compra ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra_SolicitacaoCompra.id_solicitacao_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra_SolicitacaoCompra.id_solicitacao_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , solicitacao_compra_feedback.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "scf_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra_feedback.scf_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.scf_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "scf_atual":
                     case "Atual":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , solicitacao_compra_feedback.scf_atual " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.scf_atual) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "scf_texto":
                     case "Texto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra_feedback.scf_texto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.scf_texto) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , solicitacao_compra_feedback.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , solicitacao_compra_feedback.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(solicitacao_compra_feedback.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("scf_texto")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra_feedback.scf_texto) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra_feedback.scf_texto) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(solicitacao_compra_feedback.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(solicitacao_compra_feedback.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_solicitacao_compra_feedback")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.id_solicitacao_compra_feedback IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.id_solicitacao_compra_feedback = :solicitacao_compra_feedback_ID_3586 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_ID_3586", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SolicitacaoCompra" || parametro.FieldName == "id_solicitacao_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.SolicitacaoCompraClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.SolicitacaoCompraClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.id_solicitacao_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.id_solicitacao_compra = :solicitacao_compra_feedback_SolicitacaoCompra_6466 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_SolicitacaoCompra_6466", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  solicitacao_compra_feedback.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.id_acs_usuario = :solicitacao_compra_feedback_AcsUsuario_8593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_AcsUsuario_8593", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "scf_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_data = :solicitacao_compra_feedback_Data_582 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_Data_582", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Atual" || parametro.FieldName == "scf_atual")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_atual IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_atual = :solicitacao_compra_feedback_Atual_8493 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_Atual_8493", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Texto" || parametro.FieldName == "scf_texto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_texto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_texto LIKE :solicitacao_compra_feedback_Texto_1150 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_Texto_1150", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  solicitacao_compra_feedback.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.version = :solicitacao_compra_feedback_Version_8685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_Version_8685", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  solicitacao_compra_feedback.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.entity_uid LIKE :solicitacao_compra_feedback_EntityUid_221 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_EntityUid_221", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TextoExato" || parametro.FieldName == "TextoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_texto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.scf_texto LIKE :solicitacao_compra_feedback_Texto_1632 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_Texto_1632", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  solicitacao_compra_feedback.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  solicitacao_compra_feedback.entity_uid LIKE :solicitacao_compra_feedback_EntityUid_49 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("solicitacao_compra_feedback_EntityUid_49", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  SolicitacaoCompraFeedbackClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (SolicitacaoCompraFeedbackClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(SolicitacaoCompraFeedbackClass), Convert.ToInt32(read["id_solicitacao_compra_feedback"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new SolicitacaoCompraFeedbackClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_solicitacao_compra_feedback"]);
                     if (read["id_solicitacao_compra"] != DBNull.Value)
                     {
                        entidade.SolicitacaoCompra = (BibliotecaEntidades.Entidades.SolicitacaoCompraClass)BibliotecaEntidades.Entidades.SolicitacaoCompraClass.GetEntidade(Convert.ToInt32(read["id_solicitacao_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.SolicitacaoCompra = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Data = (DateTime)read["scf_data"];
                     entidade.Atual = Convert.ToBoolean(Convert.ToInt16(read["scf_atual"]));
                     entidade.Texto = (read["scf_texto"] != DBNull.Value ? read["scf_texto"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (SolicitacaoCompraFeedbackClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
