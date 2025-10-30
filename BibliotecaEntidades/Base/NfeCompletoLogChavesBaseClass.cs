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
     [Table("nfe_completo_log_chaves","nlc")]
     public class NfeCompletoLogChavesBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfeCompletoLogChavesClass";
protected const string ErroDelete = "Erro ao excluir o NfeCompletoLogChavesClass  ";
protected const string ErroSave = "Erro ao salvar o NfeCompletoLogChavesClass.";
protected const string ErroChaveObrigatorio = "O campo Chave é obrigatório";
protected const string ErroChaveComprimento = "O campo Chave deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroModeloObrigatorio = "O campo Modelo é obrigatório";
protected const string ErroModeloComprimento = "O campo Modelo deve ter no máximo 10 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do NfeCompletoLogChavesClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfeCompletoLogChavesClass está sendo utilizada.";
#endregion
       protected string _chaveOriginal{get;private set;}
       private string _chaveOriginalCommited{get; set;}
        private string _valueChave;
         [Column("nlc_chave")]
        public virtual string Chave
         { 
            get { return this._valueChave; } 
            set 
            { 
                if (this._valueChave == value)return;
                 this._valueChave = value; 
            } 
        } 

       protected int _numeroOriginal{get;private set;}
       private int _numeroOriginalCommited{get; set;}
        private int _valueNumero;
         [Column("nlc_numero")]
        public virtual int Numero
         { 
            get { return this._valueNumero; } 
            set 
            { 
                if (this._valueNumero == value)return;
                 this._valueNumero = value; 
            } 
        } 

       protected int _serieOriginal{get;private set;}
       private int _serieOriginalCommited{get; set;}
        private int _valueSerie;
         [Column("nlc_serie")]
        public virtual int Serie
         { 
            get { return this._valueSerie; } 
            set 
            { 
                if (this._valueSerie == value)return;
                 this._valueSerie = value; 
            } 
        } 

       protected bool _homologacaoOriginal{get;private set;}
       private bool _homologacaoOriginalCommited{get; set;}
        private bool _valueHomologacao;
         [Column("nlc_homologacao")]
        public virtual bool Homologacao
         { 
            get { return this._valueHomologacao; } 
            set 
            { 
                if (this._valueHomologacao == value)return;
                 this._valueHomologacao = value; 
            } 
        } 

       protected DateTime _dataOriginal{get;private set;}
       private DateTime _dataOriginalCommited{get; set;}
        private DateTime _valueData;
         [Column("nlc_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected string _modeloOriginal{get;private set;}
       private string _modeloOriginalCommited{get; set;}
        private string _valueModelo;
         [Column("nlc_modelo")]
        public virtual string Modelo
         { 
            get { return this._valueModelo; } 
            set 
            { 
                if (this._valueModelo == value)return;
                 this._valueModelo = value; 
            } 
        } 

        public NfeCompletoLogChavesBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Data = Configurations.DataIndependenteClass.GetData();
           this.Modelo = "55";
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfeCompletoLogChavesClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfeCompletoLogChavesClass) GetEntity(typeof(NfeCompletoLogChavesClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Chave))
                {
                    throw new Exception(ErroChaveObrigatorio);
                }
                if (Chave.Length >255)
                {
                    throw new Exception( ErroChaveComprimento);
                }
                if (string.IsNullOrEmpty(Modelo))
                {
                    throw new Exception(ErroModeloObrigatorio);
                }
                if (Modelo.Length >10)
                {
                    throw new Exception( ErroModeloComprimento);
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
                    "  public.nfe_completo_log_chaves  " +
                    "WHERE " +
                    "  id_nfe_completo_log_chaves = :id";
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
                        "  public.nfe_completo_log_chaves   " +
                        "SET  " + 
                        "  nlc_chave = :nlc_chave, " + 
                        "  nlc_numero = :nlc_numero, " + 
                        "  nlc_serie = :nlc_serie, " + 
                        "  nlc_homologacao = :nlc_homologacao, " + 
                        "  nlc_data = :nlc_data, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nlc_modelo = :nlc_modelo "+
                        "WHERE  " +
                        "  id_nfe_completo_log_chaves = :id " +
                        "RETURNING id_nfe_completo_log_chaves;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nfe_completo_log_chaves " +
                        "( " +
                        "  nlc_chave , " + 
                        "  nlc_numero , " + 
                        "  nlc_serie , " + 
                        "  nlc_homologacao , " + 
                        "  nlc_data , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nlc_modelo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :nlc_chave , " + 
                        "  :nlc_numero , " + 
                        "  :nlc_serie , " + 
                        "  :nlc_homologacao , " + 
                        "  :nlc_data , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nlc_modelo  "+
                        ")RETURNING id_nfe_completo_log_chaves;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_chave", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Chave ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_numero", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Numero ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_serie", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Serie ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_homologacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Homologacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nlc_modelo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Modelo ?? DBNull.Value;

 
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
        public static NfeCompletoLogChavesClass CopiarEntidade(NfeCompletoLogChavesClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfeCompletoLogChavesClass toRet = new NfeCompletoLogChavesClass(usuario,conn);
 toRet.Chave= entidadeCopiar.Chave;
 toRet.Numero= entidadeCopiar.Numero;
 toRet.Serie= entidadeCopiar.Serie;
 toRet.Homologacao= entidadeCopiar.Homologacao;
 toRet.Data= entidadeCopiar.Data;
 toRet.Modelo= entidadeCopiar.Modelo;

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
       _chaveOriginal = Chave;
       _chaveOriginalCommited = _chaveOriginal;
       _numeroOriginal = Numero;
       _numeroOriginalCommited = _numeroOriginal;
       _serieOriginal = Serie;
       _serieOriginalCommited = _serieOriginal;
       _homologacaoOriginal = Homologacao;
       _homologacaoOriginalCommited = _homologacaoOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _modeloOriginal = Modelo;
       _modeloOriginalCommited = _modeloOriginal;

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
       _chaveOriginalCommited = Chave;
       _numeroOriginalCommited = Numero;
       _serieOriginalCommited = Serie;
       _homologacaoOriginalCommited = Homologacao;
       _dataOriginalCommited = Data;
       _versionOriginalCommited = Version;
       _modeloOriginalCommited = Modelo;

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
               Chave=_chaveOriginal;
               _chaveOriginalCommited=_chaveOriginal;
               Numero=_numeroOriginal;
               _numeroOriginalCommited=_numeroOriginal;
               Serie=_serieOriginal;
               _serieOriginalCommited=_serieOriginal;
               Homologacao=_homologacaoOriginal;
               _homologacaoOriginalCommited=_homologacaoOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Modelo=_modeloOriginal;
               _modeloOriginalCommited=_modeloOriginal;

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
       dirty = _chaveOriginal != Chave;
      if (dirty) return true;
       dirty = _numeroOriginal != Numero;
      if (dirty) return true;
       dirty = _serieOriginal != Serie;
      if (dirty) return true;
       dirty = _homologacaoOriginal != Homologacao;
      if (dirty) return true;
       dirty = _dataOriginal != Data;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _modeloOriginal != Modelo;

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
       dirty = _chaveOriginalCommited != Chave;
      if (dirty) return true;
       dirty = _numeroOriginalCommited != Numero;
      if (dirty) return true;
       dirty = _serieOriginalCommited != Serie;
      if (dirty) return true;
       dirty = _homologacaoOriginalCommited != Homologacao;
      if (dirty) return true;
       dirty = _dataOriginalCommited != Data;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _modeloOriginalCommited != Modelo;

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
             case "Chave":
                return this.Chave;
             case "Numero":
                return this.Numero;
             case "Serie":
                return this.Serie;
             case "Homologacao":
                return this.Homologacao;
             case "Data":
                return this.Data;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Modelo":
                return this.Modelo;
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
                  command.CommandText += " COUNT(nfe_completo_log_chaves.id_nfe_completo_log_chaves) " ;
               }
               else
               {
               command.CommandText += "nfe_completo_log_chaves.id_nfe_completo_log_chaves, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_chave, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_numero, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_serie, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_homologacao, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_data, " ;
               command.CommandText += "nfe_completo_log_chaves.entity_uid, " ;
               command.CommandText += "nfe_completo_log_chaves.version, " ;
               command.CommandText += "nfe_completo_log_chaves.nlc_modelo " ;
               }
               command.CommandText += " FROM  nfe_completo_log_chaves ";
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
                        orderByClause += " , nlc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nlc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nfe_completo_log_chaves.id_acs_usuario_ultima_revisao ";
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
                     case "id_nfe_completo_log_chaves":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_log_chaves.id_nfe_completo_log_chaves " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.id_nfe_completo_log_chaves) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_chave":
                     case "Chave":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_log_chaves.nlc_chave " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_chave) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_numero":
                     case "Numero":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_log_chaves.nlc_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_serie":
                     case "Serie":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_log_chaves.nlc_serie " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_serie) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_homologacao":
                     case "Homologacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_log_chaves.nlc_homologacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_homologacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nfe_completo_log_chaves.nlc_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_log_chaves.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nfe_completo_log_chaves.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nlc_modelo":
                     case "Modelo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nfe_completo_log_chaves.nlc_modelo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nfe_completo_log_chaves.nlc_modelo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nlc_chave")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_log_chaves.nlc_chave) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_log_chaves.nlc_chave) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_log_chaves.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_log_chaves.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nlc_modelo")) 
                        {
                           whereClause += " OR UPPER(nfe_completo_log_chaves.nlc_modelo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nfe_completo_log_chaves.nlc_modelo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nfe_completo_log_chaves")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.id_nfe_completo_log_chaves IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.id_nfe_completo_log_chaves = :nfe_completo_log_chaves_ID_3582 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_ID_3582", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Chave" || parametro.FieldName == "nlc_chave")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_chave LIKE :nfe_completo_log_chaves_Chave_6948 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Chave_6948", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Numero" || parametro.FieldName == "nlc_numero")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_numero IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_numero = :nfe_completo_log_chaves_Numero_4024 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Numero_4024", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Serie" || parametro.FieldName == "nlc_serie")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_serie IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_serie = :nfe_completo_log_chaves_Serie_2570 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Serie_2570", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Homologacao" || parametro.FieldName == "nlc_homologacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_homologacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_homologacao = :nfe_completo_log_chaves_Homologacao_3739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Homologacao_3739", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "nlc_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_data = :nfe_completo_log_chaves_Data_3805 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Data_3805", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
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
                         whereClause += "  nfe_completo_log_chaves.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.entity_uid LIKE :nfe_completo_log_chaves_EntityUid_8367 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_EntityUid_8367", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nfe_completo_log_chaves.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.version = :nfe_completo_log_chaves_Version_17 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Version_17", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Modelo" || parametro.FieldName == "nlc_modelo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_modelo LIKE :nfe_completo_log_chaves_Modelo_7361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Modelo_7361", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ChaveExato" || parametro.FieldName == "ChaveExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_chave IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_chave LIKE :nfe_completo_log_chaves_Chave_7770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Chave_7770", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nfe_completo_log_chaves.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.entity_uid LIKE :nfe_completo_log_chaves_EntityUid_5555 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_EntityUid_5555", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModeloExato" || parametro.FieldName == "ModeloExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_modelo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nfe_completo_log_chaves.nlc_modelo LIKE :nfe_completo_log_chaves_Modelo_5896 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfe_completo_log_chaves_Modelo_5896", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfeCompletoLogChavesClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfeCompletoLogChavesClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfeCompletoLogChavesClass), Convert.ToInt32(read["id_nfe_completo_log_chaves"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfeCompletoLogChavesClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nfe_completo_log_chaves"]);
                     entidade.Chave = (read["nlc_chave"] != DBNull.Value ? read["nlc_chave"].ToString() : null);
                     entidade.Numero = (int)read["nlc_numero"];
                     entidade.Serie = (int)read["nlc_serie"];
                     entidade.Homologacao = Convert.ToBoolean(Convert.ToInt16(read["nlc_homologacao"]));
                     entidade.Data = (DateTime)read["nlc_data"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Modelo = (read["nlc_modelo"] != DBNull.Value ? read["nlc_modelo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfeCompletoLogChavesClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
