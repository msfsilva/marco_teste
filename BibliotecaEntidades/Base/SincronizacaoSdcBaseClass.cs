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
     [Table("sincronizacao_sdc","ssd")]
     public class SincronizacaoSdcBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do SincronizacaoSdcClass";
protected const string ErroDelete = "Erro ao excluir o SincronizacaoSdcClass  ";
protected const string ErroSave = "Erro ao salvar o SincronizacaoSdcClass.";
protected const string ErroTipoEntidadeObrigatorio = "O campo TipoEntidade é obrigatório";
protected const string ErroTipoEntidadeComprimento = "O campo TipoEntidade deve ter no máximo 50 caracteres";
protected const string ErroTipoOperacaoObrigatorio = "O campo TipoOperacao é obrigatório";
protected const string ErroTipoOperacaoComprimento = "O campo TipoOperacao deve ter no máximo 20 caracteres";
protected const string ErroDadosPayloadObrigatorio = "O campo DadosPayload é obrigatório";
protected const string ErroStatusObrigatorio = "O campo Status é obrigatório";
protected const string ErroStatusComprimento = "O campo Status deve ter no máximo 20 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do SincronizacaoSdcClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade SincronizacaoSdcClass está sendo utilizada.";
#endregion
       protected string _tipoEntidadeOriginal{get;private set;}
       private string _tipoEntidadeOriginalCommited{get; set;}
        private string _valueTipoEntidade;
         [Column("ssd_tipo_entidade")]
        public virtual string TipoEntidade
         { 
            get { return this._valueTipoEntidade; } 
            set 
            { 
                if (this._valueTipoEntidade == value)return;
                 this._valueTipoEntidade = value; 
            } 
        } 

       protected string _tipoOperacaoOriginal{get;private set;}
       private string _tipoOperacaoOriginalCommited{get; set;}
        private string _valueTipoOperacao;
         [Column("ssd_tipo_operacao")]
        public virtual string TipoOperacao
         { 
            get { return this._valueTipoOperacao; } 
            set 
            { 
                if (this._valueTipoOperacao == value)return;
                 this._valueTipoOperacao = value; 
            } 
        } 

       protected string _dadosPayloadOriginal{get;private set;}
       private string _dadosPayloadOriginalCommited{get; set;}
        private string _valueDadosPayload;
         [Column("ssd_dados_payload")]
        public virtual string DadosPayload
         { 
            get { return this._valueDadosPayload; } 
            set 
            { 
                if (this._valueDadosPayload == value)return;
                 this._valueDadosPayload = value; 
            } 
        } 

       protected string _statusOriginal{get;private set;}
       private string _statusOriginalCommited{get; set;}
        private string _valueStatus;
         [Column("ssd_status")]
        public virtual string Status
         { 
            get { return this._valueStatus; } 
            set 
            { 
                if (this._valueStatus == value)return;
                 this._valueStatus = value; 
            } 
        } 

       protected DateTime _dataCriacaoOriginal{get;private set;}
       private DateTime _dataCriacaoOriginalCommited{get; set;}
        private DateTime _valueDataCriacao;
         [Column("ssd_data_criacao")]
        public virtual DateTime DataCriacao
         { 
            get { return this._valueDataCriacao; } 
            set 
            { 
                if (this._valueDataCriacao == value)return;
                 this._valueDataCriacao = value; 
            } 
        } 

       protected DateTime? _dataUltimaTentativaOriginal{get;private set;}
       private DateTime? _dataUltimaTentativaOriginalCommited{get; set;}
        private DateTime? _valueDataUltimaTentativa;
         [Column("ssd_data_ultima_tentativa")]
        public virtual DateTime? DataUltimaTentativa
         { 
            get { return this._valueDataUltimaTentativa; } 
            set 
            { 
                if (this._valueDataUltimaTentativa == value)return;
                 this._valueDataUltimaTentativa = value; 
            } 
        } 

       protected int _numeroTentativasOriginal{get;private set;}
       private int _numeroTentativasOriginalCommited{get; set;}
        private int _valueNumeroTentativas;
         [Column("ssd_numero_tentativas")]
        public virtual int NumeroTentativas
         { 
            get { return this._valueNumeroTentativas; } 
            set 
            { 
                if (this._valueNumeroTentativas == value)return;
                 this._valueNumeroTentativas = value; 
            } 
        } 

       protected string _mensagemErroOriginal{get;private set;}
       private string _mensagemErroOriginalCommited{get; set;}
        private string _valueMensagemErro;
         [Column("ssd_mensagem_erro")]
        public virtual string MensagemErro
         { 
            get { return this._valueMensagemErro; } 
            set 
            { 
                if (this._valueMensagemErro == value)return;
                 this._valueMensagemErro = value; 
            } 
        } 

        public SincronizacaoSdcBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Status = "PENDENTE";
           this.DataCriacao = Configurations.DataIndependenteClass.GetData();
           this.NumeroTentativas = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static SincronizacaoSdcClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (SincronizacaoSdcClass) GetEntity(typeof(SincronizacaoSdcClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(TipoEntidade))
                {
                    throw new Exception(ErroTipoEntidadeObrigatorio);
                }
                if (TipoEntidade.Length >50)
                {
                    throw new Exception( ErroTipoEntidadeComprimento);
                }
                if (string.IsNullOrEmpty(TipoOperacao))
                {
                    throw new Exception(ErroTipoOperacaoObrigatorio);
                }
                if (TipoOperacao.Length >20)
                {
                    throw new Exception( ErroTipoOperacaoComprimento);
                }
                if (string.IsNullOrEmpty(DadosPayload))
                {
                    throw new Exception(ErroDadosPayloadObrigatorio);
                }
                if (string.IsNullOrEmpty(Status))
                {
                    throw new Exception(ErroStatusObrigatorio);
                }
                if (Status.Length >20)
                {
                    throw new Exception( ErroStatusComprimento);
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
                    "  public.sincronizacao_sdc  " +
                    "WHERE " +
                    "  id_sincronizacao_sdc = :id";
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
                        "  public.sincronizacao_sdc   " +
                        "SET  " + 
                        "  ssd_tipo_entidade = :ssd_tipo_entidade, " + 
                        "  ssd_tipo_operacao = :ssd_tipo_operacao, " + 
                        "  ssd_dados_payload = :ssd_dados_payload, " + 
                        "  ssd_status = :ssd_status, " + 
                        "  ssd_data_criacao = :ssd_data_criacao, " + 
                        "  ssd_data_ultima_tentativa = :ssd_data_ultima_tentativa, " + 
                        "  ssd_numero_tentativas = :ssd_numero_tentativas, " + 
                        "  ssd_mensagem_erro = :ssd_mensagem_erro, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_sincronizacao_sdc = :id " +
                        "RETURNING id_sincronizacao_sdc;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.sincronizacao_sdc " +
                        "( " +
                        "  ssd_tipo_entidade , " + 
                        "  ssd_tipo_operacao , " + 
                        "  ssd_dados_payload , " + 
                        "  ssd_status , " + 
                        "  ssd_data_criacao , " + 
                        "  ssd_data_ultima_tentativa , " + 
                        "  ssd_numero_tentativas , " + 
                        "  ssd_mensagem_erro , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ssd_tipo_entidade , " + 
                        "  :ssd_tipo_operacao , " + 
                        "  :ssd_dados_payload , " + 
                        "  :ssd_status , " + 
                        "  :ssd_data_criacao , " + 
                        "  :ssd_data_ultima_tentativa , " + 
                        "  :ssd_numero_tentativas , " + 
                        "  :ssd_mensagem_erro , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_sincronizacao_sdc;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_tipo_entidade", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoEntidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_tipo_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_dados_payload", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DadosPayload ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_status", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Status ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_data_criacao", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCriacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_data_ultima_tentativa", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataUltimaTentativa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_numero_tentativas", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroTentativas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ssd_mensagem_erro", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MensagemErro ?? DBNull.Value;
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
        public static SincronizacaoSdcClass CopiarEntidade(SincronizacaoSdcClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               SincronizacaoSdcClass toRet = new SincronizacaoSdcClass(usuario,conn);
 toRet.TipoEntidade= entidadeCopiar.TipoEntidade;
 toRet.TipoOperacao= entidadeCopiar.TipoOperacao;
 toRet.DadosPayload= entidadeCopiar.DadosPayload;
 toRet.Status= entidadeCopiar.Status;
 toRet.DataCriacao= entidadeCopiar.DataCriacao;
 toRet.DataUltimaTentativa= entidadeCopiar.DataUltimaTentativa;
 toRet.NumeroTentativas= entidadeCopiar.NumeroTentativas;
 toRet.MensagemErro= entidadeCopiar.MensagemErro;

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
       _tipoEntidadeOriginal = TipoEntidade;
       _tipoEntidadeOriginalCommited = _tipoEntidadeOriginal;
       _tipoOperacaoOriginal = TipoOperacao;
       _tipoOperacaoOriginalCommited = _tipoOperacaoOriginal;
       _dadosPayloadOriginal = DadosPayload;
       _dadosPayloadOriginalCommited = _dadosPayloadOriginal;
       _statusOriginal = Status;
       _statusOriginalCommited = _statusOriginal;
       _dataCriacaoOriginal = DataCriacao;
       _dataCriacaoOriginalCommited = _dataCriacaoOriginal;
       _dataUltimaTentativaOriginal = DataUltimaTentativa;
       _dataUltimaTentativaOriginalCommited = _dataUltimaTentativaOriginal;
       _numeroTentativasOriginal = NumeroTentativas;
       _numeroTentativasOriginalCommited = _numeroTentativasOriginal;
       _mensagemErroOriginal = MensagemErro;
       _mensagemErroOriginalCommited = _mensagemErroOriginal;
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
       _tipoEntidadeOriginalCommited = TipoEntidade;
       _tipoOperacaoOriginalCommited = TipoOperacao;
       _dadosPayloadOriginalCommited = DadosPayload;
       _statusOriginalCommited = Status;
       _dataCriacaoOriginalCommited = DataCriacao;
       _dataUltimaTentativaOriginalCommited = DataUltimaTentativa;
       _numeroTentativasOriginalCommited = NumeroTentativas;
       _mensagemErroOriginalCommited = MensagemErro;
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
               TipoEntidade=_tipoEntidadeOriginal;
               _tipoEntidadeOriginalCommited=_tipoEntidadeOriginal;
               TipoOperacao=_tipoOperacaoOriginal;
               _tipoOperacaoOriginalCommited=_tipoOperacaoOriginal;
               DadosPayload=_dadosPayloadOriginal;
               _dadosPayloadOriginalCommited=_dadosPayloadOriginal;
               Status=_statusOriginal;
               _statusOriginalCommited=_statusOriginal;
               DataCriacao=_dataCriacaoOriginal;
               _dataCriacaoOriginalCommited=_dataCriacaoOriginal;
               DataUltimaTentativa=_dataUltimaTentativaOriginal;
               _dataUltimaTentativaOriginalCommited=_dataUltimaTentativaOriginal;
               NumeroTentativas=_numeroTentativasOriginal;
               _numeroTentativasOriginalCommited=_numeroTentativasOriginal;
               MensagemErro=_mensagemErroOriginal;
               _mensagemErroOriginalCommited=_mensagemErroOriginal;
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
       dirty = _tipoEntidadeOriginal != TipoEntidade;
      if (dirty) return true;
       dirty = _tipoOperacaoOriginal != TipoOperacao;
      if (dirty) return true;
       dirty = _dadosPayloadOriginal != DadosPayload;
      if (dirty) return true;
       dirty = _statusOriginal != Status;
      if (dirty) return true;
       dirty = _dataCriacaoOriginal != DataCriacao;
      if (dirty) return true;
       dirty = _dataUltimaTentativaOriginal != DataUltimaTentativa;
      if (dirty) return true;
       dirty = _numeroTentativasOriginal != NumeroTentativas;
      if (dirty) return true;
       dirty = _mensagemErroOriginal != MensagemErro;
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
       dirty = _tipoEntidadeOriginalCommited != TipoEntidade;
      if (dirty) return true;
       dirty = _tipoOperacaoOriginalCommited != TipoOperacao;
      if (dirty) return true;
       dirty = _dadosPayloadOriginalCommited != DadosPayload;
      if (dirty) return true;
       dirty = _statusOriginalCommited != Status;
      if (dirty) return true;
       dirty = _dataCriacaoOriginalCommited != DataCriacao;
      if (dirty) return true;
       dirty = _dataUltimaTentativaOriginalCommited != DataUltimaTentativa;
      if (dirty) return true;
       dirty = _numeroTentativasOriginalCommited != NumeroTentativas;
      if (dirty) return true;
       dirty = _mensagemErroOriginalCommited != MensagemErro;
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
             case "TipoEntidade":
                return this.TipoEntidade;
             case "TipoOperacao":
                return this.TipoOperacao;
             case "DadosPayload":
                return this.DadosPayload;
             case "Status":
                return this.Status;
             case "DataCriacao":
                return this.DataCriacao;
             case "DataUltimaTentativa":
                return this.DataUltimaTentativa;
             case "NumeroTentativas":
                return this.NumeroTentativas;
             case "MensagemErro":
                return this.MensagemErro;
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
                  command.CommandText += " COUNT(sincronizacao_sdc.id_sincronizacao_sdc) " ;
               }
               else
               {
               command.CommandText += "sincronizacao_sdc.id_sincronizacao_sdc, " ;
               command.CommandText += "sincronizacao_sdc.ssd_tipo_entidade, " ;
               command.CommandText += "sincronizacao_sdc.ssd_tipo_operacao, " ;
               command.CommandText += "sincronizacao_sdc.ssd_dados_payload, " ;
               command.CommandText += "sincronizacao_sdc.ssd_status, " ;
               command.CommandText += "sincronizacao_sdc.ssd_data_criacao, " ;
               command.CommandText += "sincronizacao_sdc.ssd_data_ultima_tentativa, " ;
               command.CommandText += "sincronizacao_sdc.ssd_numero_tentativas, " ;
               command.CommandText += "sincronizacao_sdc.ssd_mensagem_erro, " ;
               command.CommandText += "sincronizacao_sdc.entity_uid, " ;
               command.CommandText += "sincronizacao_sdc.version " ;
               }
               command.CommandText += " FROM  sincronizacao_sdc ";
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
                        orderByClause += " , ssd_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ssd_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = sincronizacao_sdc.id_acs_usuario_ultima_revisao ";
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
                     case "id_sincronizacao_sdc":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , sincronizacao_sdc.id_sincronizacao_sdc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(sincronizacao_sdc.id_sincronizacao_sdc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_tipo_entidade":
                     case "TipoEntidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.ssd_tipo_entidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_tipo_entidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_tipo_operacao":
                     case "TipoOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.ssd_tipo_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_tipo_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_dados_payload":
                     case "DadosPayload":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.ssd_dados_payload " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_dados_payload) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_status":
                     case "Status":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.ssd_status " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_status) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_data_criacao":
                     case "DataCriacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , sincronizacao_sdc.ssd_data_criacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_data_criacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_data_ultima_tentativa":
                     case "DataUltimaTentativa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , sincronizacao_sdc.ssd_data_ultima_tentativa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_data_ultima_tentativa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_numero_tentativas":
                     case "NumeroTentativas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , sincronizacao_sdc.ssd_numero_tentativas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_numero_tentativas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ssd_mensagem_erro":
                     case "MensagemErro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.ssd_mensagem_erro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.ssd_mensagem_erro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , sincronizacao_sdc.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(sincronizacao_sdc.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , sincronizacao_sdc.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(sincronizacao_sdc.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ssd_tipo_entidade")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.ssd_tipo_entidade) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.ssd_tipo_entidade) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ssd_tipo_operacao")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.ssd_tipo_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.ssd_tipo_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ssd_dados_payload")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.ssd_dados_payload) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.ssd_dados_payload) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ssd_status")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.ssd_status) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.ssd_status) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ssd_mensagem_erro")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.ssd_mensagem_erro) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.ssd_mensagem_erro) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(sincronizacao_sdc.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(sincronizacao_sdc.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_sincronizacao_sdc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.id_sincronizacao_sdc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.id_sincronizacao_sdc = :sincronizacao_sdc_ID_578 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_ID_578", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEntidade" || parametro.FieldName == "ssd_tipo_entidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_entidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_entidade LIKE :sincronizacao_sdc_TipoEntidade_422 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_TipoEntidade_422", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoOperacao" || parametro.FieldName == "ssd_tipo_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_operacao LIKE :sincronizacao_sdc_TipoOperacao_8867 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_TipoOperacao_8867", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DadosPayload" || parametro.FieldName == "ssd_dados_payload")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_dados_payload IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_dados_payload LIKE :sincronizacao_sdc_DadosPayload_4556 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_DadosPayload_4556", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Status" || parametro.FieldName == "ssd_status")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_status LIKE :sincronizacao_sdc_Status_4870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_Status_4870", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCriacao" || parametro.FieldName == "ssd_data_criacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_data_criacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_data_criacao = :sincronizacao_sdc_DataCriacao_199 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_DataCriacao_199", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataUltimaTentativa" || parametro.FieldName == "ssd_data_ultima_tentativa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_data_ultima_tentativa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_data_ultima_tentativa = :sincronizacao_sdc_DataUltimaTentativa_3770 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_DataUltimaTentativa_3770", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroTentativas" || parametro.FieldName == "ssd_numero_tentativas")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_numero_tentativas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_numero_tentativas = :sincronizacao_sdc_NumeroTentativas_2869 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_NumeroTentativas_2869", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemErro" || parametro.FieldName == "ssd_mensagem_erro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_mensagem_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_mensagem_erro LIKE :sincronizacao_sdc_MensagemErro_5154 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_MensagemErro_5154", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  sincronizacao_sdc.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.entity_uid LIKE :sincronizacao_sdc_EntityUid_1845 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_EntityUid_1845", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  sincronizacao_sdc.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.version = :sincronizacao_sdc_Version_5536 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_Version_5536", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoEntidadeExato" || parametro.FieldName == "TipoEntidadeExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_entidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_entidade LIKE :sincronizacao_sdc_TipoEntidade_6143 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_TipoEntidade_6143", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoOperacaoExato" || parametro.FieldName == "TipoOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_tipo_operacao LIKE :sincronizacao_sdc_TipoOperacao_3100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_TipoOperacao_3100", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DadosPayloadExato" || parametro.FieldName == "DadosPayloadExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_dados_payload IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_dados_payload LIKE :sincronizacao_sdc_DadosPayload_5973 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_DadosPayload_5973", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "StatusExato" || parametro.FieldName == "StatusExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_status IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_status LIKE :sincronizacao_sdc_Status_3500 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_Status_3500", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemErroExato" || parametro.FieldName == "MensagemErroExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  sincronizacao_sdc.ssd_mensagem_erro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.ssd_mensagem_erro LIKE :sincronizacao_sdc_MensagemErro_2926 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_MensagemErro_2926", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  sincronizacao_sdc.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  sincronizacao_sdc.entity_uid LIKE :sincronizacao_sdc_EntityUid_5148 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("sincronizacao_sdc_EntityUid_5148", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  SincronizacaoSdcClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (SincronizacaoSdcClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(SincronizacaoSdcClass), Convert.ToInt32(read["id_sincronizacao_sdc"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new SincronizacaoSdcClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_sincronizacao_sdc"]);
                     entidade.TipoEntidade = (read["ssd_tipo_entidade"] != DBNull.Value ? read["ssd_tipo_entidade"].ToString() : null);
                     entidade.TipoOperacao = (read["ssd_tipo_operacao"] != DBNull.Value ? read["ssd_tipo_operacao"].ToString() : null);
                     entidade.DadosPayload = (read["ssd_dados_payload"] != DBNull.Value ? read["ssd_dados_payload"].ToString() : null);
                     entidade.Status = (read["ssd_status"] != DBNull.Value ? read["ssd_status"].ToString() : null);
                     entidade.DataCriacao = (DateTime)read["ssd_data_criacao"];
                     entidade.DataUltimaTentativa = read["ssd_data_ultima_tentativa"] as DateTime?;
                     entidade.NumeroTentativas = (int)read["ssd_numero_tentativas"];
                     entidade.MensagemErro = (read["ssd_mensagem_erro"] != DBNull.Value ? read["ssd_mensagem_erro"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (SincronizacaoSdcClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
