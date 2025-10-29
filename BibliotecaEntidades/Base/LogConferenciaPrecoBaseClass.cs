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
     [Table("log_conferencia_preco","lcp")]
     public class LogConferenciaPrecoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LogConferenciaPrecoClass";
protected const string ErroDelete = "Erro ao excluir o LogConferenciaPrecoClass  ";
protected const string ErroSave = "Erro ao salvar o LogConferenciaPrecoClass.";
protected const string ErroOcObrigatorio = "O campo Oc é obrigatório";
protected const string ErroOcComprimento = "O campo Oc deve ter no máximo 255 caracteres";
protected const string ErroCodigoItemObrigatorio = "O campo CodigoItem é obrigatório";
protected const string ErroCodigoItemComprimento = "O campo CodigoItem deve ter no máximo 255 caracteres";
protected const string ErroMensagemObrigatorio = "O campo Mensagem é obrigatório";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do LogConferenciaPrecoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LogConferenciaPrecoClass está sendo utilizada.";
#endregion
       protected string _ocOriginal{get;private set;}
       private string _ocOriginalCommited{get; set;}
        private string _valueOc;
         [Column("lcp_oc")]
        public virtual string Oc
         { 
            get { return this._valueOc; } 
            set 
            { 
                if (this._valueOc == value)return;
                 this._valueOc = value; 
            } 
        } 

       protected int _posOriginal{get;private set;}
       private int _posOriginalCommited{get; set;}
        private int _valuePos;
         [Column("lcp_pos")]
        public virtual int Pos
         { 
            get { return this._valuePos; } 
            set 
            { 
                if (this._valuePos == value)return;
                 this._valuePos = value; 
            } 
        } 

       protected string _codigoItemOriginal{get;private set;}
       private string _codigoItemOriginalCommited{get; set;}
        private string _valueCodigoItem;
         [Column("lcp_codigo_item")]
        public virtual string CodigoItem
         { 
            get { return this._valueCodigoItem; } 
            set 
            { 
                if (this._valueCodigoItem == value)return;
                 this._valueCodigoItem = value; 
            } 
        } 

       protected TipoLogPrecos _tipoOriginal{get;private set;}
       private TipoLogPrecos _tipoOriginalCommited{get; set;}
        private TipoLogPrecos _valueTipo;
         [Column("lcp_tipo")]
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

       protected string _mensagemOriginal{get;private set;}
       private string _mensagemOriginalCommited{get; set;}
        private string _valueMensagem;
         [Column("lcp_mensagem")]
        public virtual string Mensagem
         { 
            get { return this._valueMensagem; } 
            set 
            { 
                if (this._valueMensagem == value)return;
                 this._valueMensagem = value; 
            } 
        } 

       protected DateTime _dataHoraOriginal{get;private set;}
       private DateTime _dataHoraOriginalCommited{get; set;}
        private DateTime _valueDataHora;
         [Column("lcp_data_hora")]
        public virtual DateTime DataHora
         { 
            get { return this._valueDataHora; } 
            set 
            { 
                if (this._valueDataHora == value)return;
                 this._valueDataHora = value; 
            } 
        } 

       protected double? _precoOriginalOriginal{get;private set;}
       private double? _precoOriginalOriginalCommited{get; set;}
        private double? _valuePrecoOriginal;
         [Column("lcp_preco_original")]
        public virtual double? PrecoOriginal
         { 
            get { return this._valuePrecoOriginal; } 
            set 
            { 
                if (this._valuePrecoOriginal == value)return;
                 this._valuePrecoOriginal = value; 
            } 
        } 

       protected double? _precoCalculadoOriginal{get;private set;}
       private double? _precoCalculadoOriginalCommited{get; set;}
        private double? _valuePrecoCalculado;
         [Column("lcp_preco_calculado")]
        public virtual double? PrecoCalculado
         { 
            get { return this._valuePrecoCalculado; } 
            set 
            { 
                if (this._valuePrecoCalculado == value)return;
                 this._valuePrecoCalculado = value; 
            } 
        } 

       protected string _logCalculoOriginal{get;private set;}
       private string _logCalculoOriginalCommited{get; set;}
        private string _valueLogCalculo;
         [Column("lcp_log_calculo")]
        public virtual string LogCalculo
         { 
            get { return this._valueLogCalculo; } 
            set 
            { 
                if (this._valueLogCalculo == value)return;
                 this._valueLogCalculo = value; 
            } 
        } 

        public LogConferenciaPrecoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (TipoLogPrecos)0;
           this.DataHora = Configurations.DataIndependenteClass.GetData();
            base.SalvarValoresAntigosHabilitado = true;
         }

public static LogConferenciaPrecoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LogConferenciaPrecoClass) GetEntity(typeof(LogConferenciaPrecoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Oc))
                {
                    throw new Exception(ErroOcObrigatorio);
                }
                if (Oc.Length >255)
                {
                    throw new Exception( ErroOcComprimento);
                }
                if (string.IsNullOrEmpty(CodigoItem))
                {
                    throw new Exception(ErroCodigoItemObrigatorio);
                }
                if (CodigoItem.Length >255)
                {
                    throw new Exception( ErroCodigoItemComprimento);
                }
                if (string.IsNullOrEmpty(Mensagem))
                {
                    throw new Exception(ErroMensagemObrigatorio);
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
                    "  public.log_conferencia_preco  " +
                    "WHERE " +
                    "  id_log_conferencia_preco = :id";
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
                        "  public.log_conferencia_preco   " +
                        "SET  " + 
                        "  lcp_oc = :lcp_oc, " + 
                        "  lcp_pos = :lcp_pos, " + 
                        "  lcp_codigo_item = :lcp_codigo_item, " + 
                        "  lcp_tipo = :lcp_tipo, " + 
                        "  lcp_mensagem = :lcp_mensagem, " + 
                        "  lcp_data_hora = :lcp_data_hora, " + 
                        "  lcp_preco_original = :lcp_preco_original, " + 
                        "  lcp_preco_calculado = :lcp_preco_calculado, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  lcp_log_calculo = :lcp_log_calculo "+
                        "WHERE  " +
                        "  id_log_conferencia_preco = :id " +
                        "RETURNING id_log_conferencia_preco;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.log_conferencia_preco " +
                        "( " +
                        "  lcp_oc , " + 
                        "  lcp_pos , " + 
                        "  lcp_codigo_item , " + 
                        "  lcp_tipo , " + 
                        "  lcp_mensagem , " + 
                        "  lcp_data_hora , " + 
                        "  lcp_preco_original , " + 
                        "  lcp_preco_calculado , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  lcp_log_calculo  "+
                        ")  " +
                        "VALUES ( " +
                        "  :lcp_oc , " + 
                        "  :lcp_pos , " + 
                        "  :lcp_codigo_item , " + 
                        "  :lcp_tipo , " + 
                        "  :lcp_mensagem , " + 
                        "  :lcp_data_hora , " + 
                        "  :lcp_preco_original , " + 
                        "  :lcp_preco_calculado , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :lcp_log_calculo  "+
                        ")RETURNING id_log_conferencia_preco;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_oc", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Oc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_pos", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Pos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_codigo_item", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoItem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Mensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_data_hora", NpgsqlDbType.Timestamp));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataHora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_original", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoOriginal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_preco_calculado", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoCalculado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lcp_log_calculo", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.LogCalculo ?? DBNull.Value;

 
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
        public static LogConferenciaPrecoClass CopiarEntidade(LogConferenciaPrecoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LogConferenciaPrecoClass toRet = new LogConferenciaPrecoClass(usuario,conn);
 toRet.Oc= entidadeCopiar.Oc;
 toRet.Pos= entidadeCopiar.Pos;
 toRet.CodigoItem= entidadeCopiar.CodigoItem;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.Mensagem= entidadeCopiar.Mensagem;
 toRet.DataHora= entidadeCopiar.DataHora;
 toRet.PrecoOriginal= entidadeCopiar.PrecoOriginal;
 toRet.PrecoCalculado= entidadeCopiar.PrecoCalculado;
 toRet.LogCalculo= entidadeCopiar.LogCalculo;

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
       _ocOriginal = Oc;
       _ocOriginalCommited = _ocOriginal;
       _posOriginal = Pos;
       _posOriginalCommited = _posOriginal;
       _codigoItemOriginal = CodigoItem;
       _codigoItemOriginalCommited = _codigoItemOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _mensagemOriginal = Mensagem;
       _mensagemOriginalCommited = _mensagemOriginal;
       _dataHoraOriginal = DataHora;
       _dataHoraOriginalCommited = _dataHoraOriginal;
       _precoOriginalOriginal = PrecoOriginal;
       _precoOriginalOriginalCommited = _precoOriginalOriginal;
       _precoCalculadoOriginal = PrecoCalculado;
       _precoCalculadoOriginalCommited = _precoCalculadoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _logCalculoOriginal = LogCalculo;
       _logCalculoOriginalCommited = _logCalculoOriginal;

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
       _ocOriginalCommited = Oc;
       _posOriginalCommited = Pos;
       _codigoItemOriginalCommited = CodigoItem;
       _tipoOriginalCommited = Tipo;
       _mensagemOriginalCommited = Mensagem;
       _dataHoraOriginalCommited = DataHora;
       _precoOriginalOriginalCommited = PrecoOriginal;
       _precoCalculadoOriginalCommited = PrecoCalculado;
       _versionOriginalCommited = Version;
       _logCalculoOriginalCommited = LogCalculo;

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
               Oc=_ocOriginal;
               _ocOriginalCommited=_ocOriginal;
               Pos=_posOriginal;
               _posOriginalCommited=_posOriginal;
               CodigoItem=_codigoItemOriginal;
               _codigoItemOriginalCommited=_codigoItemOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               Mensagem=_mensagemOriginal;
               _mensagemOriginalCommited=_mensagemOriginal;
               DataHora=_dataHoraOriginal;
               _dataHoraOriginalCommited=_dataHoraOriginal;
               PrecoOriginal=_precoOriginalOriginal;
               _precoOriginalOriginalCommited=_precoOriginalOriginal;
               PrecoCalculado=_precoCalculadoOriginal;
               _precoCalculadoOriginalCommited=_precoCalculadoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               LogCalculo=_logCalculoOriginal;
               _logCalculoOriginalCommited=_logCalculoOriginal;

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
       dirty = _ocOriginal != Oc;
      if (dirty) return true;
       dirty = _posOriginal != Pos;
      if (dirty) return true;
       dirty = _codigoItemOriginal != CodigoItem;
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _mensagemOriginal != Mensagem;
      if (dirty) return true;
       dirty = _dataHoraOriginal != DataHora;
      if (dirty) return true;
       dirty = _precoOriginalOriginal != PrecoOriginal;
      if (dirty) return true;
       dirty = _precoCalculadoOriginal != PrecoCalculado;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _logCalculoOriginal != LogCalculo;

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
       dirty = _ocOriginalCommited != Oc;
      if (dirty) return true;
       dirty = _posOriginalCommited != Pos;
      if (dirty) return true;
       dirty = _codigoItemOriginalCommited != CodigoItem;
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _mensagemOriginalCommited != Mensagem;
      if (dirty) return true;
       dirty = _dataHoraOriginalCommited != DataHora;
      if (dirty) return true;
       dirty = _precoOriginalOriginalCommited != PrecoOriginal;
      if (dirty) return true;
       dirty = _precoCalculadoOriginalCommited != PrecoCalculado;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _logCalculoOriginalCommited != LogCalculo;

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
             case "Oc":
                return this.Oc;
             case "Pos":
                return this.Pos;
             case "CodigoItem":
                return this.CodigoItem;
             case "Tipo":
                return this.Tipo;
             case "Mensagem":
                return this.Mensagem;
             case "DataHora":
                return this.DataHora;
             case "PrecoOriginal":
                return this.PrecoOriginal;
             case "PrecoCalculado":
                return this.PrecoCalculado;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "LogCalculo":
                return this.LogCalculo;
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
                  command.CommandText += " COUNT(log_conferencia_preco.id_log_conferencia_preco) " ;
               }
               else
               {
               command.CommandText += "log_conferencia_preco.id_log_conferencia_preco, " ;
               command.CommandText += "log_conferencia_preco.lcp_oc, " ;
               command.CommandText += "log_conferencia_preco.lcp_pos, " ;
               command.CommandText += "log_conferencia_preco.lcp_codigo_item, " ;
               command.CommandText += "log_conferencia_preco.lcp_tipo, " ;
               command.CommandText += "log_conferencia_preco.lcp_mensagem, " ;
               command.CommandText += "log_conferencia_preco.lcp_data_hora, " ;
               command.CommandText += "log_conferencia_preco.lcp_preco_original, " ;
               command.CommandText += "log_conferencia_preco.lcp_preco_calculado, " ;
               command.CommandText += "log_conferencia_preco.entity_uid, " ;
               command.CommandText += "log_conferencia_preco.version, " ;
               command.CommandText += "log_conferencia_preco.lcp_log_calculo " ;
               }
               command.CommandText += " FROM  log_conferencia_preco ";
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
                        orderByClause += " , lcp_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lcp_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = log_conferencia_preco.id_acs_usuario_ultima_revisao ";
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
                     case "id_log_conferencia_preco":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.id_log_conferencia_preco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.id_log_conferencia_preco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_oc":
                     case "Oc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_conferencia_preco.lcp_oc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_oc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_pos":
                     case "Pos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.lcp_pos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_pos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_codigo_item":
                     case "CodigoItem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_conferencia_preco.lcp_codigo_item " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_codigo_item) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.lcp_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_mensagem":
                     case "Mensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_conferencia_preco.lcp_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_data_hora":
                     case "DataHora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.lcp_data_hora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_data_hora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_preco_original":
                     case "PrecoOriginal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.lcp_preco_original " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_preco_original) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_preco_calculado":
                     case "PrecoCalculado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , log_conferencia_preco.lcp_preco_calculado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_preco_calculado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_conferencia_preco.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_conferencia_preco.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , log_conferencia_preco.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(log_conferencia_preco.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lcp_log_calculo":
                     case "LogCalculo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , log_conferencia_preco.lcp_log_calculo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(log_conferencia_preco.lcp_log_calculo) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lcp_oc")) 
                        {
                           whereClause += " OR UPPER(log_conferencia_preco.lcp_oc) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_conferencia_preco.lcp_oc) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lcp_codigo_item")) 
                        {
                           whereClause += " OR UPPER(log_conferencia_preco.lcp_codigo_item) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_conferencia_preco.lcp_codigo_item) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lcp_mensagem")) 
                        {
                           whereClause += " OR UPPER(log_conferencia_preco.lcp_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_conferencia_preco.lcp_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(log_conferencia_preco.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_conferencia_preco.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("lcp_log_calculo")) 
                        {
                           whereClause += " OR UPPER(log_conferencia_preco.lcp_log_calculo) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(log_conferencia_preco.lcp_log_calculo) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_log_conferencia_preco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.id_log_conferencia_preco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.id_log_conferencia_preco = :log_conferencia_preco_ID_5594 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_ID_5594", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Oc" || parametro.FieldName == "lcp_oc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_oc LIKE :log_conferencia_preco_Oc_2689 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Oc_2689", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Pos" || parametro.FieldName == "lcp_pos")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_pos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_pos = :log_conferencia_preco_Pos_8446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Pos_8446", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItem" || parametro.FieldName == "lcp_codigo_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_codigo_item LIKE :log_conferencia_preco_CodigoItem_1585 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_CodigoItem_1585", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "lcp_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is TipoLogPrecos)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo TipoLogPrecos");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_tipo = :log_conferencia_preco_Tipo_553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Tipo_553", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mensagem" || parametro.FieldName == "lcp_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_mensagem LIKE :log_conferencia_preco_Mensagem_6917 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Mensagem_6917", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataHora" || parametro.FieldName == "lcp_data_hora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_data_hora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_data_hora = :log_conferencia_preco_DataHora_4801 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_DataHora_4801", NpgsqlDbType.Timestamp, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoOriginal" || parametro.FieldName == "lcp_preco_original")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_preco_original IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_preco_original = :log_conferencia_preco_PrecoOriginal_242 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_PrecoOriginal_242", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoCalculado" || parametro.FieldName == "lcp_preco_calculado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_preco_calculado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_preco_calculado = :log_conferencia_preco_PrecoCalculado_2157 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_PrecoCalculado_2157", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  log_conferencia_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.entity_uid LIKE :log_conferencia_preco_EntityUid_6593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_EntityUid_6593", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  log_conferencia_preco.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.version = :log_conferencia_preco_Version_6236 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Version_6236", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LogCalculo" || parametro.FieldName == "lcp_log_calculo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_log_calculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_log_calculo LIKE :log_conferencia_preco_LogCalculo_8228 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_LogCalculo_8228", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OcExato" || parametro.FieldName == "OcExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_oc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_oc LIKE :log_conferencia_preco_Oc_677 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Oc_677", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoItemExato" || parametro.FieldName == "CodigoItemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_codigo_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_codigo_item LIKE :log_conferencia_preco_CodigoItem_4375 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_CodigoItem_4375", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemExato" || parametro.FieldName == "MensagemExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_mensagem LIKE :log_conferencia_preco_Mensagem_1544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_Mensagem_1544", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  log_conferencia_preco.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.entity_uid LIKE :log_conferencia_preco_EntityUid_8673 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_EntityUid_8673", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "LogCalculoExato" || parametro.FieldName == "LogCalculoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  log_conferencia_preco.lcp_log_calculo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  log_conferencia_preco.lcp_log_calculo LIKE :log_conferencia_preco_LogCalculo_9387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("log_conferencia_preco_LogCalculo_9387", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LogConferenciaPrecoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LogConferenciaPrecoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LogConferenciaPrecoClass), Convert.ToInt32(read["id_log_conferencia_preco"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LogConferenciaPrecoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_log_conferencia_preco"]);
                     entidade.Oc = (read["lcp_oc"] != DBNull.Value ? read["lcp_oc"].ToString() : null);
                     entidade.Pos = (int)read["lcp_pos"];
                     entidade.CodigoItem = (read["lcp_codigo_item"] != DBNull.Value ? read["lcp_codigo_item"].ToString() : null);
                     entidade.Tipo = (TipoLogPrecos) (read["lcp_tipo"] != DBNull.Value ? Enum.ToObject(typeof(TipoLogPrecos), read["lcp_tipo"]) : null);
                     entidade.Mensagem = (read["lcp_mensagem"] != DBNull.Value ? read["lcp_mensagem"].ToString() : null);
                     entidade.DataHora = (DateTime)read["lcp_data_hora"];
                     entidade.PrecoOriginal = read["lcp_preco_original"] as double?;
                     entidade.PrecoCalculado = read["lcp_preco_calculado"] as double?;
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.LogCalculo = (read["lcp_log_calculo"] != DBNull.Value ? read["lcp_log_calculo"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LogConferenciaPrecoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
