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
     [Table("funcionario_funcao","fuf")]
     public class FuncionarioFuncaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do FuncionarioFuncaoClass";
protected const string ErroDelete = "Erro ao excluir o FuncionarioFuncaoClass  ";
protected const string ErroSave = "Erro ao salvar o FuncionarioFuncaoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroFuncionarioObrigatorio = "O campo Funcionario é obrigatório";
protected const string ErroFuncaoObrigatorio = "O campo Funcao é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do FuncionarioFuncaoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade FuncionarioFuncaoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _funcionarioOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FuncionarioClass _valueFuncionario;
        [Column("id_funcionario", "funcionario", "id_funcionario")]
       public virtual BibliotecaEntidades.Entidades.FuncionarioClass Funcionario
        { 
           get {                 return this._valueFuncionario; } 
           set 
           { 
                if (this._valueFuncionario == value)return;
                 this._valueFuncionario = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.FuncaoClass _funcaoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.FuncaoClass _funcaoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.FuncaoClass _valueFuncao;
        [Column("id_funcao", "funcao", "id_funcao")]
       public virtual BibliotecaEntidades.Entidades.FuncaoClass Funcao
        { 
           get {                 return this._valueFuncao; } 
           set 
           { 
                if (this._valueFuncao == value)return;
                 this._valueFuncao = value; 
           } 
       } 

       protected DateTime _inicioVigenciaOriginal{get;private set;}
       private DateTime _inicioVigenciaOriginalCommited{get; set;}
        private DateTime _valueInicioVigencia;
         [Column("fuf_inicio_vigencia")]
        public virtual DateTime InicioVigencia
         { 
            get { return this._valueInicioVigencia; } 
            set 
            { 
                if (this._valueInicioVigencia == value)return;
                 this._valueInicioVigencia = value; 
            } 
        } 

       protected DateTime? _fimVigenciaOriginal{get;private set;}
       private DateTime? _fimVigenciaOriginalCommited{get; set;}
        private DateTime? _valueFimVigencia;
         [Column("fuf_fim_vigencia")]
        public virtual DateTime? FimVigencia
         { 
            get { return this._valueFimVigencia; } 
            set 
            { 
                if (this._valueFimVigencia == value)return;
                 this._valueFimVigencia = value; 
            } 
        } 

        public FuncionarioFuncaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static FuncionarioFuncaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (FuncionarioFuncaoClass) GetEntity(typeof(FuncionarioFuncaoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueFuncionario == null)
                {
                    throw new Exception(ErroFuncionarioObrigatorio);
                }
                if ( _valueFuncao == null)
                {
                    throw new Exception(ErroFuncaoObrigatorio);
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
                    "  public.funcionario_funcao  " +
                    "WHERE " +
                    "  id_funcionario_funcao = :id";
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
                        "  public.funcionario_funcao   " +
                        "SET  " + 
                        "  id_funcionario = :id_funcionario, " + 
                        "  id_funcao = :id_funcao, " + 
                        "  fuf_inicio_vigencia = :fuf_inicio_vigencia, " + 
                        "  fuf_fim_vigencia = :fuf_fim_vigencia, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_funcionario_funcao = :id " +
                        "RETURNING id_funcionario_funcao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.funcionario_funcao " +
                        "( " +
                        "  id_funcionario , " + 
                        "  id_funcao , " + 
                        "  fuf_inicio_vigencia , " + 
                        "  fuf_fim_vigencia , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_funcionario , " + 
                        "  :id_funcao , " + 
                        "  :fuf_inicio_vigencia , " + 
                        "  :fuf_fim_vigencia , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_funcionario_funcao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_funcionario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Funcionario==null ? (object) DBNull.Value : this.Funcionario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_funcao", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Funcao==null ? (object) DBNull.Value : this.Funcao.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuf_inicio_vigencia", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.InicioVigencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("fuf_fim_vigencia", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FimVigencia ?? DBNull.Value;
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
        public static FuncionarioFuncaoClass CopiarEntidade(FuncionarioFuncaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               FuncionarioFuncaoClass toRet = new FuncionarioFuncaoClass(usuario,conn);
 toRet.Funcionario= entidadeCopiar.Funcionario;
 toRet.Funcao= entidadeCopiar.Funcao;
 toRet.InicioVigencia= entidadeCopiar.InicioVigencia;
 toRet.FimVigencia= entidadeCopiar.FimVigencia;

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
       _funcionarioOriginal = Funcionario;
       _funcionarioOriginalCommited = _funcionarioOriginal;
       _funcaoOriginal = Funcao;
       _funcaoOriginalCommited = _funcaoOriginal;
       _inicioVigenciaOriginal = InicioVigencia;
       _inicioVigenciaOriginalCommited = _inicioVigenciaOriginal;
       _fimVigenciaOriginal = FimVigencia;
       _fimVigenciaOriginalCommited = _fimVigenciaOriginal;
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
       _funcionarioOriginalCommited = Funcionario;
       _funcaoOriginalCommited = Funcao;
       _inicioVigenciaOriginalCommited = InicioVigencia;
       _fimVigenciaOriginalCommited = FimVigencia;
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
               Funcionario=_funcionarioOriginal;
               _funcionarioOriginalCommited=_funcionarioOriginal;
               Funcao=_funcaoOriginal;
               _funcaoOriginalCommited=_funcaoOriginal;
               InicioVigencia=_inicioVigenciaOriginal;
               _inicioVigenciaOriginalCommited=_inicioVigenciaOriginal;
               FimVigencia=_fimVigenciaOriginal;
               _fimVigenciaOriginalCommited=_fimVigenciaOriginal;
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
       if (_funcionarioOriginal!=null)
       {
          dirty = !_funcionarioOriginal.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       if (_funcaoOriginal!=null)
       {
          dirty = !_funcaoOriginal.Equals(Funcao);
       }
       else
       {
            dirty = Funcao != null;
       }
      if (dirty) return true;
       dirty = _inicioVigenciaOriginal != InicioVigencia;
      if (dirty) return true;
       dirty = _fimVigenciaOriginal != FimVigencia;
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
       if (_funcionarioOriginalCommited!=null)
       {
          dirty = !_funcionarioOriginalCommited.Equals(Funcionario);
       }
       else
       {
            dirty = Funcionario != null;
       }
      if (dirty) return true;
       if (_funcaoOriginalCommited!=null)
       {
          dirty = !_funcaoOriginalCommited.Equals(Funcao);
       }
       else
       {
            dirty = Funcao != null;
       }
      if (dirty) return true;
       dirty = _inicioVigenciaOriginalCommited != InicioVigencia;
      if (dirty) return true;
       dirty = _fimVigenciaOriginalCommited != FimVigencia;
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
             case "Funcionario":
                return this.Funcionario;
             case "Funcao":
                return this.Funcao;
             case "InicioVigencia":
                return this.InicioVigencia;
             case "FimVigencia":
                return this.FimVigencia;
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
             if (Funcionario!=null)
                Funcionario.ChangeSingleConnection(newConnection);
             if (Funcao!=null)
                Funcao.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(funcionario_funcao.id_funcionario_funcao) " ;
               }
               else
               {
               command.CommandText += "funcionario_funcao.id_funcionario_funcao, " ;
               command.CommandText += "funcionario_funcao.id_funcionario, " ;
               command.CommandText += "funcionario_funcao.id_funcao, " ;
               command.CommandText += "funcionario_funcao.fuf_inicio_vigencia, " ;
               command.CommandText += "funcionario_funcao.fuf_fim_vigencia, " ;
               command.CommandText += "funcionario_funcao.entity_uid, " ;
               command.CommandText += "funcionario_funcao.version " ;
               }
               command.CommandText += " FROM  funcionario_funcao ";
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
                        orderByClause += " , fuf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(fuf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = funcionario_funcao.id_acs_usuario_ultima_revisao ";
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
                     case "id_funcionario_funcao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario_funcao.id_funcionario_funcao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario_funcao.id_funcionario_funcao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_funcionario":
                     case "Funcionario":
                     command.CommandText += " LEFT JOIN funcionario as funcionario_Funcionario ON funcionario_Funcionario.id_funcionario = funcionario_funcao.id_funcionario ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario_Funcionario.fuc_nome " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario_Funcionario.fuc_nome) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_funcao":
                     case "Funcao":
                     command.CommandText += " LEFT JOIN funcao as funcao_Funcao ON funcao_Funcao.id_funcao = funcionario_funcao.id_funcao ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcao_Funcao.fun_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcao_Funcao.fun_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuf_inicio_vigencia":
                     case "InicioVigencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario_funcao.fuf_inicio_vigencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario_funcao.fuf_inicio_vigencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "fuf_fim_vigencia":
                     case "FimVigencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , funcionario_funcao.fuf_fim_vigencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario_funcao.fuf_fim_vigencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , funcionario_funcao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(funcionario_funcao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , funcionario_funcao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(funcionario_funcao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(funcionario_funcao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(funcionario_funcao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_funcionario_funcao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario_funcao.id_funcionario_funcao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.id_funcionario_funcao = :funcionario_funcao_ID_4950 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_ID_4950", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Funcionario" || parametro.FieldName == "id_funcionario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FuncionarioClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FuncionarioClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario_funcao.id_funcionario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.id_funcionario = :funcionario_funcao_Funcionario_8238 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_Funcionario_8238", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Funcao" || parametro.FieldName == "id_funcao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.FuncaoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.FuncaoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario_funcao.id_funcao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.id_funcao = :funcionario_funcao_Funcao_9649 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_Funcao_9649", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "InicioVigencia" || parametro.FieldName == "fuf_inicio_vigencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario_funcao.fuf_inicio_vigencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.fuf_inicio_vigencia = :funcionario_funcao_InicioVigencia_5049 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_InicioVigencia_5049", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FimVigencia" || parametro.FieldName == "fuf_fim_vigencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  funcionario_funcao.fuf_fim_vigencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.fuf_fim_vigencia = :funcionario_funcao_FimVigencia_987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_FimVigencia_987", NpgsqlDbType.Date, parametro.Fieldvalue));
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
                         whereClause += "  funcionario_funcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.entity_uid LIKE :funcionario_funcao_EntityUid_4627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_EntityUid_4627", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  funcionario_funcao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.version = :funcionario_funcao_Version_3108 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_Version_3108", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  funcionario_funcao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  funcionario_funcao.entity_uid LIKE :funcionario_funcao_EntityUid_8393 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("funcionario_funcao_EntityUid_8393", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  FuncionarioFuncaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (FuncionarioFuncaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(FuncionarioFuncaoClass), Convert.ToInt32(read["id_funcionario_funcao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new FuncionarioFuncaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_funcionario_funcao"]);
                     if (read["id_funcionario"] != DBNull.Value)
                     {
                        entidade.Funcionario = (BibliotecaEntidades.Entidades.FuncionarioClass)BibliotecaEntidades.Entidades.FuncionarioClass.GetEntidade(Convert.ToInt32(read["id_funcionario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Funcionario = null ;
                     }
                     if (read["id_funcao"] != DBNull.Value)
                     {
                        entidade.Funcao = (BibliotecaEntidades.Entidades.FuncaoClass)BibliotecaEntidades.Entidades.FuncaoClass.GetEntidade(Convert.ToInt32(read["id_funcao"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Funcao = null ;
                     }
                     entidade.InicioVigencia = (DateTime)read["fuf_inicio_vigencia"];
                     entidade.FimVigencia = read["fuf_fim_vigencia"] as DateTime?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (FuncionarioFuncaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
