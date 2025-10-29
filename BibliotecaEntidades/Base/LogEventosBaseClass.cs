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
     [Table("log_eventos","loe")]
     public class LogEventosBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LogEventosClass";
protected const string ErroDelete = "Erro ao excluir o LogEventosClass  ";
protected const string ErroSave = "Erro ao salvar o LogEventosClass.";
protected const string ErroUsuarioResponsavelObrigatorio = "O campo UsuarioResponsavel é obrigatório";
protected const string ErroUsuarioResponsavelComprimento = "O campo UsuarioResponsavel deve ter no máximo 255 caracteres";
protected const string ErroLocalGeracaoObrigatorio = "O campo LocalGeracao é obrigatório";
protected const string ErroLocalGeracaoComprimento = "O campo LocalGeracao deve ter no máximo 255 caracteres";
protected const string ErroEventoObrigatorio = "O campo Evento é obrigatório";
protected const string ErroEventoComprimento = "O campo Evento deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do LogEventosClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LogEventosClass está sendo utilizada.";
#endregion
       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("loe_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected TipoLogPrecos _tipoOriginal{get;private set;}
       private TipoLogPrecos _tipoOriginalCommited{get; set;}
        private TipoLogPrecos _valueTipo;
         [Column("loe_tipo")]
        public virtual TipoLogPrecos Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_Erro
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoLogPrecos.Erro; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoLogPrecos.Erro; }
         } 

        public bool Tipo_Aviso
         { 
            get { return this._valueTipo == BibliotecaEntidades.Base.TipoLogPrecos.Aviso; } 
            set { if (value) this._valueTipo = BibliotecaEntidades.Base.TipoLogPrecos.Aviso; }
         } 

       protected string _usuarioResponsavelOriginal{get;private set;}
       private string _usuarioResponsavelOriginalCommited{get; set;}
        private string _valueUsuarioResponsavel;
         [Column("loe_usuario_responsavel")]
        public virtual string UsuarioResponsavel
         { 
            get { return this._valueUsuarioResponsavel; } 
            set 
            { 
                if (this._valueUsuarioResponsavel == value)return;
                 this._valueUsuarioResponsavel = value; 
            } 
        } 

       protected string _localGeracaoOriginal{get;private set;}
       private string _localGeracaoOriginalCommited{get; set;}
        private string _valueLocalGeracao;
         [Column("loe_local_geracao")]
        public virtual string LocalGeracao
         { 
            get { return this._valueLocalGeracao; } 
            set 
            { 
                if (this._valueLocalGeracao == value)return;
                 this._valueLocalGeracao = value; 
            } 
        } 

       protected string _eventoOriginal{get;private set;}
       private string _eventoOriginalCommited{get; set;}
        private string _valueEvento;
         [Column("loe_evento")]
        public virtual string Evento
         { 
            get { return this._valueEvento; } 
            set 
            { 
                if (this._valueEvento == value)return;
                 this._valueEvento = value; 
            } 
        } 

        public LogEventosBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoLogPrecos)0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static LogEventosClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LogEventosClass) GetEntity(typeof(LogEventosClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(UsuarioResponsavel))
                {
                    throw new Exception(ErroUsuarioResponsavelObrigatorio);
                }
                if (UsuarioResponsavel.Length >255)
                {
                    throw new Exception( ErroUsuarioResponsavelComprimento);
                }
                if (string.IsNullOrEmpty(LocalGeracao))
                {
                    throw new Exception(ErroLocalGeracaoObrigatorio);
                }
                if (LocalGeracao.Length >255)
                {
                    throw new Exception( ErroLocalGeracaoComprimento);
                }
                if (string.IsNullOrEmpty(Evento))
                {
                    throw new Exception(ErroEventoObrigatorio);
                }
                if (Evento.Length >255)
                {
                    throw new Exception( ErroEventoComprimento);
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
                    "  public.log_eventos  " +
                    "WHERE " +
                    "  id_log_eventos = :id";
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
                        "  public.log_eventos   " +
                        "SET  " + 
                        "  loe_data = :loe_data, " + 
                        "  loe_tipo = :loe_tipo, " + 
                        "  loe_usuario_responsavel = :loe_usuario_responsavel, " + 
                        "  loe_local_geracao = :loe_local_geracao, " + 
                        "  loe_evento = :loe_evento, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_log_eventos = :id " +
                        "RETURNING id_log_eventos;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.log_eventos " +
                        "( " +
                        "  loe_data , " + 
                        "  loe_tipo , " + 
                        "  loe_usuario_responsavel , " + 
                        "  loe_local_geracao , " + 
                        "  loe_evento , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :loe_data , " + 
                        "  :loe_tipo , " + 
                        "  :loe_usuario_responsavel , " + 
                        "  :loe_local_geracao , " + 
                        "  :loe_evento , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_log_eventos;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_usuario_responsavel", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.UsuarioResponsavel ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_local_geracao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LocalGeracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("loe_evento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Evento ?? DBNull.Value;
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
        public static LogEventosClass CopiarEntidade(LogEventosClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LogEventosClass toRet = new LogEventosClass(usuario,conn);
 toRet.Data= entidadeCopiar.Data;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.UsuarioResponsavel= entidadeCopiar.UsuarioResponsavel;
 toRet.LocalGeracao= entidadeCopiar.LocalGeracao;
 toRet.Evento= entidadeCopiar.Evento;

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
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _usuarioResponsavelOriginal = UsuarioResponsavel;
       _usuarioResponsavelOriginalCommited = _usuarioResponsavelOriginal;
       _localGeracaoOriginal = LocalGeracao;
       _localGeracaoOriginalCommited = _localGeracaoOriginal;
       _eventoOriginal = Evento;
       _eventoOriginalCommited = _eventoOriginal;
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
       _tipoOriginalCommited = Tipo;
       _usuarioResponsavelOriginalCommited = UsuarioResponsavel;
       _localGeracaoOriginalCommited = LocalGeracao;
       _eventoOriginalCommited = Evento;
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
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               UsuarioResponsavel=_usuarioResponsavelOriginal;
               _usuarioResponsavelOriginalCommited=_usuarioResponsavelOriginal;
               LocalGeracao=_localGeracaoOriginal;
               _localGeracaoOriginalCommited=_localGeracaoOriginal;
               Evento=_eventoOriginal;
               _eventoOriginalCommited=_eventoOriginal;
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
       dirty = _dataOriginal != Data;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _usuarioResponsavelOriginal != UsuarioResponsavel;
      if (dirty) return true;
       dirty = _localGeracaoOriginal != LocalGeracao;
      if (dirty) return true;
       dirty = _eventoOriginal != Evento;
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
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _usuarioResponsavelOriginalCommited != UsuarioResponsavel;
      if (dirty) return true;
       dirty = _localGeracaoOriginalCommited != LocalGeracao;
      if (dirty) return true;
       dirty = _eventoOriginalCommited != Evento;
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
             case "Data":
                return this.Data;
             case "Tipo":
                return this.Tipo;
             case "UsuarioResponsavel":
                return this.UsuarioResponsavel;
             case "LocalGeracao":
                return this.LocalGeracao;
             case "Evento":
                return this.Evento;
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
                  command.CommandText += " COUNT(log_eventos.id_log_eventos) " ;
               }
               else
               {
               command.CommandText += "log_eventos.id_log_eventos, " ;
               command.CommandText += "log_eventos.loe_data, " ;
               command.CommandText += "log_eventos.loe_tipo, " ;
               command.CommandText += "log_eventos.loe_usuario_responsavel, " ;
               command.CommandText += "log_eventos.loe_local_geracao, " ;
               command.CommandText += "log_eventos.loe_evento, " ;
               command.CommandText += "log_eventos.entity_uid, " ;
               command.CommandText += "log_eventos.version " ;
               }
               command.CommandText += " FROM  log_eventos ";
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
                        orderByClause += " , loe_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(loe_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = log_eventos.id_acs_usuario_ultima_revisao ";
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
                     case "id_log_eventos":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_eventos.id_log_eventos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_eventos.id_log_eventos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "loe_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_eventos.loe_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_eventos.loe_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "loe_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_eventos.loe_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_eventos.loe_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "loe_usuario_responsavel":
                     case "UsuarioResponsavel":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_eventos.loe_usuario_responsavel " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_eventos.loe_usuario_responsavel) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "loe_local_geracao":
                     case "LocalGeracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_eventos.loe_local_geracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_eventos.loe_local_geracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "loe_evento":
                     case "Evento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_eventos.loe_evento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_eventos.loe_evento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_eventos.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_eventos.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , log_eventos.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_eventos.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("loe_usuario_responsavel")) 
                        {
                           whereClause += " OR UPPER(log_eventos.loe_usuario_responsavel) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_eventos.loe_usuario_responsavel) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("loe_local_geracao")) 
                        {
                           whereClause += " OR UPPER(log_eventos.loe_local_geracao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_eventos.loe_local_geracao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("loe_evento")) 
                        {
                           whereClause += " OR UPPER(log_eventos.loe_evento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_eventos.loe_evento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(log_eventos.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_eventos.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_log_eventos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.id_log_eventos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.id_log_eventos = :log_eventos_ID_7545 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_ID_7545", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "loe_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_data = :log_eventos_Data_3648 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_Data_3648", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "loe_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoLogPrecos)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoLogPrecos");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_tipo = :log_eventos_Tipo_5133 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_Tipo_5133", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioResponsavel" || parametro.FieldName == "loe_usuario_responsavel")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_usuario_responsavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_usuario_responsavel LIKE :log_eventos_UsuarioResponsavel_7751 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_UsuarioResponsavel_7751", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalGeracao" || parametro.FieldName == "loe_local_geracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_local_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_local_geracao LIKE :log_eventos_LocalGeracao_513 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_LocalGeracao_513", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Evento" || parametro.FieldName == "loe_evento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_evento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_evento LIKE :log_eventos_Evento_7825 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_Evento_7825", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  log_eventos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.entity_uid LIKE :log_eventos_EntityUid_3699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_EntityUid_3699", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  log_eventos.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.version = :log_eventos_Version_5763 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_Version_5763", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "UsuarioResponsavelExato" || parametro.FieldName == "UsuarioResponsavelExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_usuario_responsavel IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_usuario_responsavel LIKE :log_eventos_UsuarioResponsavel_509 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_UsuarioResponsavel_509", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LocalGeracaoExato" || parametro.FieldName == "LocalGeracaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_local_geracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_local_geracao LIKE :log_eventos_LocalGeracao_907 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_LocalGeracao_907", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EventoExato" || parametro.FieldName == "EventoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_eventos.loe_evento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.loe_evento LIKE :log_eventos_Evento_4623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_Evento_4623", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  log_eventos.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_eventos.entity_uid LIKE :log_eventos_EntityUid_251 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_eventos_EntityUid_251", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LogEventosClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LogEventosClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LogEventosClass), Convert.ToInt32(read["id_log_eventos"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LogEventosClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_log_eventos"]);
                     entidade.Data = (DateTime)read["loe_data"];
                     entidade.Tipo = (TipoLogPrecos) (read["loe_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoLogPrecos), read["loe_tipo"]) : null);
                     entidade.UsuarioResponsavel = (read["loe_usuario_responsavel"] != DBNull.Value ? read["loe_usuario_responsavel"].ToString() : null);
                     entidade.LocalGeracao = (read["loe_local_geracao"] != DBNull.Value ? read["loe_local_geracao"].ToString() : null);
                     entidade.Evento = (read["loe_evento"] != DBNull.Value ? read["loe_evento"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LogEventosClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
