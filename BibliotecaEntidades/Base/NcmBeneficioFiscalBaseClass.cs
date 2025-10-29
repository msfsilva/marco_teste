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
     [Table("ncm_beneficio_fiscal","nbf")]
     public class NcmBeneficioFiscalBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NcmBeneficioFiscalClass";
protected const string ErroDelete = "Erro ao excluir o NcmBeneficioFiscalClass  ";
protected const string ErroSave = "Erro ao salvar o NcmBeneficioFiscalClass.";
protected const string ErroCodigoBeneficioFiscalObrigatorio = "O campo CodigoBeneficioFiscal é obrigatório";
protected const string ErroCodigoBeneficioFiscalComprimento = "O campo CodigoBeneficioFiscal deve ter no máximo 10 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNcmObrigatorio = "O campo Ncm é obrigatório";
protected const string ErroEstadoObrigatorio = "O campo Estado é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NcmBeneficioFiscalClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NcmBeneficioFiscalClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.NcmClass _ncmOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.NcmClass _ncmOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.NcmClass _valueNcm;
        [Column("id_ncm", "ncm", "id_ncm")]
       public virtual BibliotecaEntidades.Entidades.NcmClass Ncm
        { 
           get {                 return this._valueNcm; } 
           set 
           { 
                if (this._valueNcm == value)return;
                 this._valueNcm = value; 
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

       protected string _codigoBeneficioFiscalOriginal{get;private set;}
       private string _codigoBeneficioFiscalOriginalCommited{get; set;}
        private string _valueCodigoBeneficioFiscal;
         [Column("nbf_codigo_beneficio_fiscal")]
        public virtual string CodigoBeneficioFiscal
         { 
            get { return this._valueCodigoBeneficioFiscal; } 
            set 
            { 
                if (this._valueCodigoBeneficioFiscal == value)return;
                 this._valueCodigoBeneficioFiscal = value; 
            } 
        } 

       protected int _cfopOriginal{get;private set;}
       private int _cfopOriginalCommited{get; set;}
        private int _valueCfop;
         [Column("nbf_cfop")]
        public virtual int Cfop
         { 
            get { return this._valueCfop; } 
            set 
            { 
                if (this._valueCfop == value)return;
                 this._valueCfop = value; 
            } 
        } 

        public NcmBeneficioFiscalBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static NcmBeneficioFiscalClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NcmBeneficioFiscalClass) GetEntity(typeof(NcmBeneficioFiscalClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(CodigoBeneficioFiscal))
                {
                    throw new Exception(ErroCodigoBeneficioFiscalObrigatorio);
                }
                if (CodigoBeneficioFiscal.Length >10)
                {
                    throw new Exception( ErroCodigoBeneficioFiscalComprimento);
                }
                if ( _valueNcm == null)
                {
                    throw new Exception(ErroNcmObrigatorio);
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
                    "  public.ncm_beneficio_fiscal  " +
                    "WHERE " +
                    "  id_ncm_beneficio_fiscal = :id";
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
                        "  public.ncm_beneficio_fiscal   " +
                        "SET  " + 
                        "  id_ncm = :id_ncm, " + 
                        "  id_estado = :id_estado, " + 
                        "  nbf_codigo_beneficio_fiscal = :nbf_codigo_beneficio_fiscal, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nbf_cfop = :nbf_cfop "+
                        "WHERE  " +
                        "  id_ncm_beneficio_fiscal = :id " +
                        "RETURNING id_ncm_beneficio_fiscal;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ncm_beneficio_fiscal " +
                        "( " +
                        "  id_ncm , " + 
                        "  id_estado , " + 
                        "  nbf_codigo_beneficio_fiscal , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nbf_cfop  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ncm , " + 
                        "  :id_estado , " + 
                        "  :nbf_codigo_beneficio_fiscal , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nbf_cfop  "+
                        ")RETURNING id_ncm_beneficio_fiscal;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ncm", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Ncm==null ? (object) DBNull.Value : this.Ncm.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Estado==null ? (object) DBNull.Value : this.Estado.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nbf_codigo_beneficio_fiscal", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoBeneficioFiscal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nbf_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;

 
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
        public static NcmBeneficioFiscalClass CopiarEntidade(NcmBeneficioFiscalClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NcmBeneficioFiscalClass toRet = new NcmBeneficioFiscalClass(usuario,conn);
 toRet.Ncm= entidadeCopiar.Ncm;
 toRet.Estado= entidadeCopiar.Estado;
 toRet.CodigoBeneficioFiscal= entidadeCopiar.CodigoBeneficioFiscal;
 toRet.Cfop= entidadeCopiar.Cfop;

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
       _ncmOriginal = Ncm;
       _ncmOriginalCommited = _ncmOriginal;
       _estadoOriginal = Estado;
       _estadoOriginalCommited = _estadoOriginal;
       _codigoBeneficioFiscalOriginal = CodigoBeneficioFiscal;
       _codigoBeneficioFiscalOriginalCommited = _codigoBeneficioFiscalOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _cfopOriginal = Cfop;
       _cfopOriginalCommited = _cfopOriginal;

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
       _ncmOriginalCommited = Ncm;
       _estadoOriginalCommited = Estado;
       _codigoBeneficioFiscalOriginalCommited = CodigoBeneficioFiscal;
       _versionOriginalCommited = Version;
       _cfopOriginalCommited = Cfop;

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
               Ncm=_ncmOriginal;
               _ncmOriginalCommited=_ncmOriginal;
               Estado=_estadoOriginal;
               _estadoOriginalCommited=_estadoOriginal;
               CodigoBeneficioFiscal=_codigoBeneficioFiscalOriginal;
               _codigoBeneficioFiscalOriginalCommited=_codigoBeneficioFiscalOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Cfop=_cfopOriginal;
               _cfopOriginalCommited=_cfopOriginal;

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
       if (_ncmOriginal!=null)
       {
          dirty = !_ncmOriginal.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
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
       dirty = _codigoBeneficioFiscalOriginal != CodigoBeneficioFiscal;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _cfopOriginal != Cfop;

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
       if (_ncmOriginalCommited!=null)
       {
          dirty = !_ncmOriginalCommited.Equals(Ncm);
       }
       else
       {
            dirty = Ncm != null;
       }
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
       dirty = _codigoBeneficioFiscalOriginalCommited != CodigoBeneficioFiscal;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _cfopOriginalCommited != Cfop;

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
             case "Ncm":
                return this.Ncm;
             case "Estado":
                return this.Estado;
             case "CodigoBeneficioFiscal":
                return this.CodigoBeneficioFiscal;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Cfop":
                return this.Cfop;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Ncm!=null)
                Ncm.ChangeSingleConnection(newConnection);
             if (Estado!=null)
                Estado.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ncm_beneficio_fiscal.id_ncm_beneficio_fiscal) " ;
               }
               else
               {
               command.CommandText += "ncm_beneficio_fiscal.id_ncm_beneficio_fiscal, " ;
               command.CommandText += "ncm_beneficio_fiscal.id_ncm, " ;
               command.CommandText += "ncm_beneficio_fiscal.id_estado, " ;
               command.CommandText += "ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal, " ;
               command.CommandText += "ncm_beneficio_fiscal.entity_uid, " ;
               command.CommandText += "ncm_beneficio_fiscal.version, " ;
               command.CommandText += "ncm_beneficio_fiscal.nbf_cfop " ;
               }
               command.CommandText += " FROM  ncm_beneficio_fiscal ";
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
                        orderByClause += " , nbf_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nbf_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ncm_beneficio_fiscal.id_acs_usuario_ultima_revisao ";
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
                     case "id_ncm_beneficio_fiscal":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm_beneficio_fiscal.id_ncm_beneficio_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm_beneficio_fiscal.id_ncm_beneficio_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ncm":
                     case "Ncm":
                     command.CommandText += " LEFT JOIN ncm as ncm_Ncm ON ncm_Ncm.id_ncm = ncm_beneficio_fiscal.id_ncm ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_Ncm.ncm_codigo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_Ncm.ncm_codigo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_estado":
                     case "Estado":
                     command.CommandText += " LEFT JOIN estado as estado_Estado ON estado_Estado.id_estado = ncm_beneficio_fiscal.id_estado ";                     switch (parametro.TipoOrdenacao)
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
                     case "nbf_codigo_beneficio_fiscal":
                     case "CodigoBeneficioFiscal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ncm_beneficio_fiscal.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ncm_beneficio_fiscal.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ncm_beneficio_fiscal.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm_beneficio_fiscal.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nbf_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ncm_beneficio_fiscal.nbf_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ncm_beneficio_fiscal.nbf_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nbf_codigo_beneficio_fiscal")) 
                        {
                           whereClause += " OR UPPER(ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ncm_beneficio_fiscal.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ncm_beneficio_fiscal.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ncm_beneficio_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm_beneficio_fiscal.id_ncm_beneficio_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.id_ncm_beneficio_fiscal = :ncm_beneficio_fiscal_ID_7446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_ID_7446", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Ncm" || parametro.FieldName == "id_ncm")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.NcmClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.NcmClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm_beneficio_fiscal.id_ncm IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.id_ncm = :ncm_beneficio_fiscal_Ncm_7627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_Ncm_7627", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ncm_beneficio_fiscal.id_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.id_estado = :ncm_beneficio_fiscal_Estado_4527 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_Estado_4527", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBeneficioFiscal" || parametro.FieldName == "nbf_codigo_beneficio_fiscal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal LIKE :ncm_beneficio_fiscal_CodigoBeneficioFiscal_8247 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_CodigoBeneficioFiscal_8247", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ncm_beneficio_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.entity_uid LIKE :ncm_beneficio_fiscal_EntityUid_518 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_EntityUid_518", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ncm_beneficio_fiscal.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.version = :ncm_beneficio_fiscal_Version_6411 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_Version_6411", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "nbf_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_cfop = :ncm_beneficio_fiscal_Cfop_8744 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_Cfop_8744", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoBeneficioFiscalExato" || parametro.FieldName == "CodigoBeneficioFiscalExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.nbf_codigo_beneficio_fiscal LIKE :ncm_beneficio_fiscal_CodigoBeneficioFiscal_7063 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_CodigoBeneficioFiscal_7063", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ncm_beneficio_fiscal.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ncm_beneficio_fiscal.entity_uid LIKE :ncm_beneficio_fiscal_EntityUid_4571 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ncm_beneficio_fiscal_EntityUid_4571", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NcmBeneficioFiscalClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NcmBeneficioFiscalClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NcmBeneficioFiscalClass), Convert.ToInt32(read["id_ncm_beneficio_fiscal"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NcmBeneficioFiscalClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ncm_beneficio_fiscal"]);
                     if (read["id_ncm"] != DBNull.Value)
                     {
                        entidade.Ncm = (BibliotecaEntidades.Entidades.NcmClass)BibliotecaEntidades.Entidades.NcmClass.GetEntidade(Convert.ToInt32(read["id_ncm"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Ncm = null ;
                     }
                     if (read["id_estado"] != DBNull.Value)
                     {
                        entidade.Estado = (BibliotecaEntidades.Entidades.EstadoClass)BibliotecaEntidades.Entidades.EstadoClass.GetEntidade(Convert.ToInt32(read["id_estado"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Estado = null ;
                     }
                     entidade.CodigoBeneficioFiscal = (read["nbf_codigo_beneficio_fiscal"] != DBNull.Value ? read["nbf_codigo_beneficio_fiscal"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Cfop = (int)read["nbf_cfop"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NcmBeneficioFiscalClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
