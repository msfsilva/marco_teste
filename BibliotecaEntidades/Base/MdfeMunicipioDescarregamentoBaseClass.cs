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
using IWTNFCompleto.BibliotecaEntidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNFCompleto.BibliotecaEntidades.Base 
{ 
    [Serializable()]
     [Table("mdfe_municipio_descarregamento","mmd")]
     public class MdfeMunicipioDescarregamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do MdfeMunicipioDescarregamentoClass";
protected const string ErroDelete = "Erro ao excluir o MdfeMunicipioDescarregamentoClass  ";
protected const string ErroSave = "Erro ao salvar o MdfeMunicipioDescarregamentoClass.";
protected const string ErroNomeMunicipioObrigatorio = "O campo NomeMunicipio é obrigatório";
protected const string ErroNomeMunicipioComprimento = "O campo NomeMunicipio deve ter no máximo 60 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroMdfeObrigatorio = "O campo Mdfe é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do MdfeMunicipioDescarregamentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade MdfeMunicipioDescarregamentoClass está sendo utilizada.";
#endregion
       protected IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _mdfeOriginal{get;private set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _mdfeOriginalCommited {get; set;}
       private IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass _valueMdfe;
        [Column("id_mdfe", "mdfe", "id_mdfe")]
       public virtual IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass Mdfe
        { 
           get {                 return this._valueMdfe; } 
           set 
           { 
                if (this._valueMdfe == value)return;
                 this._valueMdfe = value; 
           } 
       } 

       protected int _codigoIbgeMunicipioOriginal{get;private set;}
       private int _codigoIbgeMunicipioOriginalCommited{get; set;}
        private int _valueCodigoIbgeMunicipio;
         [Column("mmd_codigo_ibge_municipio")]
        public virtual int CodigoIbgeMunicipio
         { 
            get { return this._valueCodigoIbgeMunicipio; } 
            set 
            { 
                if (this._valueCodigoIbgeMunicipio == value)return;
                 this._valueCodigoIbgeMunicipio = value; 
            } 
        } 

       protected string _nomeMunicipioOriginal{get;private set;}
       private string _nomeMunicipioOriginalCommited{get; set;}
        private string _valueNomeMunicipio;
         [Column("mmd_nome_municipio")]
        public virtual string NomeMunicipio
         { 
            get { return this._valueNomeMunicipio; } 
            set 
            { 
                if (this._valueNomeMunicipio == value)return;
                 this._valueNomeMunicipio = value; 
            } 
        } 

        public MdfeMunicipioDescarregamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static MdfeMunicipioDescarregamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (MdfeMunicipioDescarregamentoClass) GetEntity(typeof(MdfeMunicipioDescarregamentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(NomeMunicipio))
                {
                    throw new Exception(ErroNomeMunicipioObrigatorio);
                }
                if (NomeMunicipio.Length >60)
                {
                    throw new Exception( ErroNomeMunicipioComprimento);
                }
                if ( _valueMdfe == null)
                {
                    throw new Exception(ErroMdfeObrigatorio);
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
                    "  public.mdfe_municipio_descarregamento  " +
                    "WHERE " +
                    "  id_mdfe_municipio_descarregamento = :id";
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
                        "  public.mdfe_municipio_descarregamento   " +
                        "SET  " + 
                        "  id_mdfe = :id_mdfe, " + 
                        "  mmd_codigo_ibge_municipio = :mmd_codigo_ibge_municipio, " + 
                        "  mmd_nome_municipio = :mmd_nome_municipio, " + 
                        "  version = :version, " + 
                        "  entity_uid = :entity_uid "+
                        "WHERE  " +
                        "  id_mdfe_municipio_descarregamento = :id " +
                        "RETURNING id_mdfe_municipio_descarregamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.mdfe_municipio_descarregamento " +
                        "( " +
                        "  id_mdfe , " + 
                        "  mmd_codigo_ibge_municipio , " + 
                        "  mmd_nome_municipio , " + 
                        "  version , " + 
                        "  entity_uid  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_mdfe , " + 
                        "  :mmd_codigo_ibge_municipio , " + 
                        "  :mmd_nome_municipio , " + 
                        "  :version , " + 
                        "  :entity_uid  "+
                        ")RETURNING id_mdfe_municipio_descarregamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_mdfe", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Mdfe==null ? (object) DBNull.Value : this.Mdfe.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mmd_codigo_ibge_municipio", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoIbgeMunicipio ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mmd_nome_municipio", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NomeMunicipio ?? DBNull.Value;
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
        public static MdfeMunicipioDescarregamentoClass CopiarEntidade(MdfeMunicipioDescarregamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               MdfeMunicipioDescarregamentoClass toRet = new MdfeMunicipioDescarregamentoClass(usuario,conn);
 toRet.Mdfe= entidadeCopiar.Mdfe;
 toRet.CodigoIbgeMunicipio= entidadeCopiar.CodigoIbgeMunicipio;
 toRet.NomeMunicipio= entidadeCopiar.NomeMunicipio;

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
       _mdfeOriginal = Mdfe;
       _mdfeOriginalCommited = _mdfeOriginal;
       _codigoIbgeMunicipioOriginal = CodigoIbgeMunicipio;
       _codigoIbgeMunicipioOriginalCommited = _codigoIbgeMunicipioOriginal;
       _nomeMunicipioOriginal = NomeMunicipio;
       _nomeMunicipioOriginalCommited = _nomeMunicipioOriginal;
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
       _mdfeOriginalCommited = Mdfe;
       _codigoIbgeMunicipioOriginalCommited = CodigoIbgeMunicipio;
       _nomeMunicipioOriginalCommited = NomeMunicipio;
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
               Mdfe=_mdfeOriginal;
               _mdfeOriginalCommited=_mdfeOriginal;
               CodigoIbgeMunicipio=_codigoIbgeMunicipioOriginal;
               _codigoIbgeMunicipioOriginalCommited=_codigoIbgeMunicipioOriginal;
               NomeMunicipio=_nomeMunicipioOriginal;
               _nomeMunicipioOriginalCommited=_nomeMunicipioOriginal;
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
       if (_mdfeOriginal!=null)
       {
          dirty = !_mdfeOriginal.Equals(Mdfe);
       }
       else
       {
            dirty = Mdfe != null;
       }
      if (dirty) return true;
       dirty = _codigoIbgeMunicipioOriginal != CodigoIbgeMunicipio;
      if (dirty) return true;
       dirty = _nomeMunicipioOriginal != NomeMunicipio;
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
       if (_mdfeOriginalCommited!=null)
       {
          dirty = !_mdfeOriginalCommited.Equals(Mdfe);
       }
       else
       {
            dirty = Mdfe != null;
       }
      if (dirty) return true;
       dirty = _codigoIbgeMunicipioOriginalCommited != CodigoIbgeMunicipio;
      if (dirty) return true;
       dirty = _nomeMunicipioOriginalCommited != NomeMunicipio;
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
             case "Mdfe":
                return this.Mdfe;
             case "CodigoIbgeMunicipio":
                return this.CodigoIbgeMunicipio;
             case "NomeMunicipio":
                return this.NomeMunicipio;
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
             if (Mdfe!=null)
                Mdfe.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento) " ;
               }
               else
               {
               command.CommandText += "mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento, " ;
               command.CommandText += "mdfe_municipio_descarregamento.id_mdfe, " ;
               command.CommandText += "mdfe_municipio_descarregamento.mmd_codigo_ibge_municipio, " ;
               command.CommandText += "mdfe_municipio_descarregamento.mmd_nome_municipio, " ;
               command.CommandText += "mdfe_municipio_descarregamento.version, " ;
               command.CommandText += "mdfe_municipio_descarregamento.entity_uid " ;
               }
               command.CommandText += " FROM  mdfe_municipio_descarregamento ";
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
                        orderByClause += " , mmd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(mmd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = mdfe_municipio_descarregamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_mdfe_municipio_descarregamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_mdfe":
                     case "Mdfe":
                     orderByClause += " , mdfe_municipio_descarregamento.id_mdfe " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "mmd_codigo_ibge_municipio":
                     case "CodigoIbgeMunicipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , mdfe_municipio_descarregamento.mmd_codigo_ibge_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_municipio_descarregamento.mmd_codigo_ibge_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "mmd_nome_municipio":
                     case "NomeMunicipio":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_municipio_descarregamento.mmd_nome_municipio " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_municipio_descarregamento.mmd_nome_municipio) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , mdfe_municipio_descarregamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(mdfe_municipio_descarregamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , mdfe_municipio_descarregamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(mdfe_municipio_descarregamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("mmd_nome_municipio")) 
                        {
                           whereClause += " OR UPPER(mdfe_municipio_descarregamento.mmd_nome_municipio) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_municipio_descarregamento.mmd_nome_municipio) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(mdfe_municipio_descarregamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(mdfe_municipio_descarregamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_mdfe_municipio_descarregamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.id_mdfe_municipio_descarregamento = :mdfe_municipio_descarregamento_ID_2535 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_ID_2535", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mdfe" || parametro.FieldName == "id_mdfe")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_municipio_descarregamento.id_mdfe IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.id_mdfe = :mdfe_municipio_descarregamento_Mdfe_5669 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_Mdfe_5669", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoIbgeMunicipio" || parametro.FieldName == "mmd_codigo_ibge_municipio")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_codigo_ibge_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_codigo_ibge_municipio = :mdfe_municipio_descarregamento_CodigoIbgeMunicipio_6132 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_CodigoIbgeMunicipio_6132", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeMunicipio" || parametro.FieldName == "mmd_nome_municipio")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_nome_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_nome_municipio LIKE :mdfe_municipio_descarregamento_NomeMunicipio_5991 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_NomeMunicipio_5991", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  mdfe_municipio_descarregamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.version = :mdfe_municipio_descarregamento_Version_707 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_Version_707", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  mdfe_municipio_descarregamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.entity_uid LIKE :mdfe_municipio_descarregamento_EntityUid_5780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_EntityUid_5780", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NomeMunicipioExato" || parametro.FieldName == "NomeMunicipioExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_nome_municipio IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.mmd_nome_municipio LIKE :mdfe_municipio_descarregamento_NomeMunicipio_9257 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_NomeMunicipio_9257", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  mdfe_municipio_descarregamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  mdfe_municipio_descarregamento.entity_uid LIKE :mdfe_municipio_descarregamento_EntityUid_3177 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("mdfe_municipio_descarregamento_EntityUid_3177", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  MdfeMunicipioDescarregamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (MdfeMunicipioDescarregamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(MdfeMunicipioDescarregamentoClass), Convert.ToInt32(read["id_mdfe_municipio_descarregamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new MdfeMunicipioDescarregamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_mdfe_municipio_descarregamento"]);
                     if (read["id_mdfe"] != DBNull.Value)
                     {
                        entidade.Mdfe = (IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass)IWTNFCompleto.BibliotecaEntidades.Entidades.MdfeClass.GetEntidade(Convert.ToInt32(read["id_mdfe"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Mdfe = null ;
                     }
                     entidade.CodigoIbgeMunicipio = (int)read["mmd_codigo_ibge_municipio"];
                     entidade.NomeMunicipio = (read["mmd_nome_municipio"] != DBNull.Value ? read["mmd_nome_municipio"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (MdfeMunicipioDescarregamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
