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
     [Table("ordem_producao_envio_terceiros_canc_saldo_receb","otr")]
     public class OrdemProducaoEnvioTerceirosCancSaldoRecebBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OrdemProducaoEnvioTerceirosCancSaldoRecebClass";
protected const string ErroDelete = "Erro ao excluir o OrdemProducaoEnvioTerceirosCancSaldoRecebClass  ";
protected const string ErroSave = "Erro ao salvar o OrdemProducaoEnvioTerceirosCancSaldoRecebClass.";
protected const string ErroJustificativaObrigatorio = "O campo Justificativa é obrigatório";
protected const string ErroJustificativaComprimento = "O campo Justificativa deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroOrdemProducaoEnvioTerceirosObrigatorio = "O campo OrdemProducaoEnvioTerceiros é obrigatório";
protected const string ErroAcsUsuarioObrigatorio = "O campo AcsUsuario é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do OrdemProducaoEnvioTerceirosCancSaldoRecebClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OrdemProducaoEnvioTerceirosCancSaldoRecebClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _ordemProducaoEnvioTerceirosOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _ordemProducaoEnvioTerceirosOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass _valueOrdemProducaoEnvioTerceiros;
        [Column("id_ordem_producao_envio_terceiros", "ordem_producao_envio_terceiros", "id_ordem_producao_envio_terceiros")]
       public virtual BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass OrdemProducaoEnvioTerceiros
        { 
           get {                 return this._valueOrdemProducaoEnvioTerceiros; } 
           set 
           { 
                if (this._valueOrdemProducaoEnvioTerceiros == value)return;
                 this._valueOrdemProducaoEnvioTerceiros = value; 
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
         [Column("otr_data")]
        public virtual DateTime Data
         { 
            get { return this._valueData; } 
            set 
            { 
                if (this._valueData == value)return;
                 this._valueData = value; 
            } 
        } 

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("otr_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected string _justificativaOriginal{get;private set;}
       private string _justificativaOriginalCommited{get; set;}
        private string _valueJustificativa;
         [Column("otr_justificativa")]
        public virtual string Justificativa
         { 
            get { return this._valueJustificativa; } 
            set 
            { 
                if (this._valueJustificativa == value)return;
                 this._valueJustificativa = value; 
            } 
        } 

        public OrdemProducaoEnvioTerceirosCancSaldoRecebBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
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

public static OrdemProducaoEnvioTerceirosCancSaldoRecebClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OrdemProducaoEnvioTerceirosCancSaldoRecebClass) GetEntity(typeof(OrdemProducaoEnvioTerceirosCancSaldoRecebClass),id,usuarioAtual,connection, operacao);
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
                if ( _valueOrdemProducaoEnvioTerceiros == null)
                {
                    throw new Exception(ErroOrdemProducaoEnvioTerceirosObrigatorio);
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
                    "  public.ordem_producao_envio_terceiros_canc_saldo_receb  " +
                    "WHERE " +
                    "  id_ordem_producao_envio_terceiros_canc_saldo_receb = :id";
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
                        "  public.ordem_producao_envio_terceiros_canc_saldo_receb   " +
                        "SET  " + 
                        "  id_ordem_producao_envio_terceiros = :id_ordem_producao_envio_terceiros, " + 
                        "  id_acs_usuario = :id_acs_usuario, " + 
                        "  otr_data = :otr_data, " + 
                        "  otr_quantidade = :otr_quantidade, " + 
                        "  otr_justificativa = :otr_justificativa, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_ordem_producao_envio_terceiros_canc_saldo_receb = :id " +
                        "RETURNING id_ordem_producao_envio_terceiros_canc_saldo_receb;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.ordem_producao_envio_terceiros_canc_saldo_receb " +
                        "( " +
                        "  id_ordem_producao_envio_terceiros , " + 
                        "  id_acs_usuario , " + 
                        "  otr_data , " + 
                        "  otr_quantidade , " + 
                        "  otr_justificativa , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_ordem_producao_envio_terceiros , " + 
                        "  :id_acs_usuario , " + 
                        "  :otr_data , " + 
                        "  :otr_quantidade , " + 
                        "  :otr_justificativa , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_ordem_producao_envio_terceiros_canc_saldo_receb;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_ordem_producao_envio_terceiros", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.OrdemProducaoEnvioTerceiros==null ? (object) DBNull.Value : this.OrdemProducaoEnvioTerceiros.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.AcsUsuario==null ? (object) DBNull.Value : this.AcsUsuario.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("otr_data", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Data ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("otr_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("otr_justificativa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Justificativa ?? DBNull.Value;
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
        public static OrdemProducaoEnvioTerceirosCancSaldoRecebClass CopiarEntidade(OrdemProducaoEnvioTerceirosCancSaldoRecebClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OrdemProducaoEnvioTerceirosCancSaldoRecebClass toRet = new OrdemProducaoEnvioTerceirosCancSaldoRecebClass(usuario,conn);
 toRet.OrdemProducaoEnvioTerceiros= entidadeCopiar.OrdemProducaoEnvioTerceiros;
 toRet.AcsUsuario= entidadeCopiar.AcsUsuario;
 toRet.Data= entidadeCopiar.Data;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.Justificativa= entidadeCopiar.Justificativa;

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
       _ordemProducaoEnvioTerceirosOriginal = OrdemProducaoEnvioTerceiros;
       _ordemProducaoEnvioTerceirosOriginalCommited = _ordemProducaoEnvioTerceirosOriginal;
       _acsUsuarioOriginal = AcsUsuario;
       _acsUsuarioOriginalCommited = _acsUsuarioOriginal;
       _dataOriginal = Data;
       _dataOriginalCommited = _dataOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _justificativaOriginal = Justificativa;
       _justificativaOriginalCommited = _justificativaOriginal;
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
       _ordemProducaoEnvioTerceirosOriginalCommited = OrdemProducaoEnvioTerceiros;
       _acsUsuarioOriginalCommited = AcsUsuario;
       _dataOriginalCommited = Data;
       _quantidadeOriginalCommited = Quantidade;
       _justificativaOriginalCommited = Justificativa;
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
               OrdemProducaoEnvioTerceiros=_ordemProducaoEnvioTerceirosOriginal;
               _ordemProducaoEnvioTerceirosOriginalCommited=_ordemProducaoEnvioTerceirosOriginal;
               AcsUsuario=_acsUsuarioOriginal;
               _acsUsuarioOriginalCommited=_acsUsuarioOriginal;
               Data=_dataOriginal;
               _dataOriginalCommited=_dataOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               Justificativa=_justificativaOriginal;
               _justificativaOriginalCommited=_justificativaOriginal;
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
       if (_ordemProducaoEnvioTerceirosOriginal!=null)
       {
          dirty = !_ordemProducaoEnvioTerceirosOriginal.Equals(OrdemProducaoEnvioTerceiros);
       }
       else
       {
            dirty = OrdemProducaoEnvioTerceiros != null;
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _justificativaOriginal != Justificativa;
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
       if (_ordemProducaoEnvioTerceirosOriginalCommited!=null)
       {
          dirty = !_ordemProducaoEnvioTerceirosOriginalCommited.Equals(OrdemProducaoEnvioTerceiros);
       }
       else
       {
            dirty = OrdemProducaoEnvioTerceiros != null;
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _justificativaOriginalCommited != Justificativa;
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
             case "OrdemProducaoEnvioTerceiros":
                return this.OrdemProducaoEnvioTerceiros;
             case "AcsUsuario":
                return this.AcsUsuario;
             case "Data":
                return this.Data;
             case "Quantidade":
                return this.Quantidade;
             case "Justificativa":
                return this.Justificativa;
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
             if (OrdemProducaoEnvioTerceiros!=null)
                OrdemProducaoEnvioTerceiros.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb) " ;
               }
               else
               {
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.id_acs_usuario, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.otr_data, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.otr_quantidade, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid, " ;
               command.CommandText += "ordem_producao_envio_terceiros_canc_saldo_receb.version " ;
               }
               command.CommandText += " FROM  ordem_producao_envio_terceiros_canc_saldo_receb ";
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
                        orderByClause += " , otr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(otr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = ordem_producao_envio_terceiros_canc_saldo_receb.id_acs_usuario_ultima_revisao ";
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
                     case "id_ordem_producao_envio_terceiros_canc_saldo_receb":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_ordem_producao_envio_terceiros":
                     case "OrdemProducaoEnvioTerceiros":
                     orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "id_acs_usuario":
                     case "AcsUsuario":
                     orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.id_acs_usuario " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "otr_data":
                     case "Data":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.otr_data " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.otr_data) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "otr_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.otr_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.otr_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "otr_justificativa":
                     case "Justificativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , ordem_producao_envio_terceiros_canc_saldo_receb.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("otr_justificativa")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_ordem_producao_envio_terceiros_canc_saldo_receb")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros_canc_saldo_receb = :ordem_producao_envio_terceiros_canc_saldo_receb_ID_8111 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_ID_8111", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OrdemProducaoEnvioTerceiros" || parametro.FieldName == "id_ordem_producao_envio_terceiros")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_ordem_producao_envio_terceiros = :ordem_producao_envio_terceiros_canc_saldo_receb_OrdemProducaoEnvioTerceiros_4867 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_OrdemProducaoEnvioTerceiros_4867", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_acs_usuario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.id_acs_usuario = :ordem_producao_envio_terceiros_canc_saldo_receb_AcsUsuario_2569 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_AcsUsuario_2569", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Data" || parametro.FieldName == "otr_data")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_data IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_data = :ordem_producao_envio_terceiros_canc_saldo_receb_Data_8525 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_Data_8525", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "otr_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_quantidade = :ordem_producao_envio_terceiros_canc_saldo_receb_Quantidade_3137 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_Quantidade_3137", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Justificativa" || parametro.FieldName == "otr_justificativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa LIKE :ordem_producao_envio_terceiros_canc_saldo_receb_Justificativa_5565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_Justificativa_5565", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid LIKE :ordem_producao_envio_terceiros_canc_saldo_receb_EntityUid_7623 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_EntityUid_7623", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.version = :ordem_producao_envio_terceiros_canc_saldo_receb_Version_3638 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_Version_3638", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.otr_justificativa LIKE :ordem_producao_envio_terceiros_canc_saldo_receb_Justificativa_1944 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_Justificativa_1944", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  ordem_producao_envio_terceiros_canc_saldo_receb.entity_uid LIKE :ordem_producao_envio_terceiros_canc_saldo_receb_EntityUid_5965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ordem_producao_envio_terceiros_canc_saldo_receb_EntityUid_5965", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OrdemProducaoEnvioTerceirosCancSaldoRecebClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OrdemProducaoEnvioTerceirosCancSaldoRecebClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OrdemProducaoEnvioTerceirosCancSaldoRecebClass), Convert.ToInt32(read["id_ordem_producao_envio_terceiros_canc_saldo_receb"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OrdemProducaoEnvioTerceirosCancSaldoRecebClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_ordem_producao_envio_terceiros_canc_saldo_receb"]);
                     if (read["id_ordem_producao_envio_terceiros"] != DBNull.Value)
                     {
                        entidade.OrdemProducaoEnvioTerceiros = (BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass)BibliotecaEntidades.Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(Convert.ToInt32(read["id_ordem_producao_envio_terceiros"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.OrdemProducaoEnvioTerceiros = null ;
                     }
                     if (read["id_acs_usuario"] != DBNull.Value)
                     {
                        entidade.AcsUsuario = (IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass)IWTDotNetLib.ComplexLoginModule.Entidades.Entidades.AcsUsuarioClass.GetEntidade(Convert.ToInt32(read["id_acs_usuario"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.AcsUsuario = null ;
                     }
                     entidade.Data = (DateTime)read["otr_data"];
                     entidade.Quantidade = (double)read["otr_quantidade"];
                     entidade.Justificativa = (read["otr_justificativa"] != DBNull.Value ? read["otr_justificativa"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OrdemProducaoEnvioTerceirosCancSaldoRecebClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
