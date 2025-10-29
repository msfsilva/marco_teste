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
     [Table("lote_solicitacao_compra","lsc")]
     public class LoteSolicitacaoCompraBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do LoteSolicitacaoCompraClass";
protected const string ErroDelete = "Erro ao excluir o LoteSolicitacaoCompraClass  ";
protected const string ErroSave = "Erro ao salvar o LoteSolicitacaoCompraClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroLoteObrigatorio = "O campo Lote é obrigatório";
protected const string ErroSolicitacaoCompraObrigatorio = "O campo SolicitacaoCompra é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do LoteSolicitacaoCompraClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade LoteSolicitacaoCompraClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.LoteClass _loteOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.LoteClass _loteOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.LoteClass _valueLote;
        [Column("id_lote", "lote", "id_lote")]
       public virtual BibliotecaEntidades.Entidades.LoteClass Lote
        { 
           get {                 return this._valueLote; } 
           set 
           { 
                if (this._valueLote == value)return;
                 this._valueLote = value; 
           } 
       } 

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

       protected double _quantidadeOriginal{get;private set;}
       private double _quantidadeOriginalCommited{get; set;}
        private double _valueQuantidade;
         [Column("lsc_quantidade")]
        public virtual double Quantidade
         { 
            get { return this._valueQuantidade; } 
            set 
            { 
                if (this._valueQuantidade == value)return;
                 this._valueQuantidade = value; 
            } 
        } 

       protected double _quantidadeCompraOriginal{get;private set;}
       private double _quantidadeCompraOriginalCommited{get; set;}
        private double _valueQuantidadeCompra;
         [Column("lsc_quantidade_compra")]
        public virtual double QuantidadeCompra
         { 
            get { return this._valueQuantidadeCompra; } 
            set 
            { 
                if (this._valueQuantidadeCompra == value)return;
                 this._valueQuantidadeCompra = value; 
            } 
        } 

       protected short _recebidoComDivergenciaOriginal{get;private set;}
       private short _recebidoComDivergenciaOriginalCommited{get; set;}
        private short _valueRecebidoComDivergencia;
         [Column("lsc_recebido_com_divergencia")]
        public virtual short RecebidoComDivergencia
         { 
            get { return this._valueRecebidoComDivergencia; } 
            set 
            { 
                if (this._valueRecebidoComDivergencia == value)return;
                 this._valueRecebidoComDivergencia = value; 
            } 
        } 

       protected long? _idAcsUsuarioAutorizadorDivergenciaOriginal{get;private set;}
       private long? _idAcsUsuarioAutorizadorDivergenciaOriginalCommited{get; set;}
        private long? _valueIdAcsUsuarioAutorizadorDivergencia;
         [Column("id_acs_usuario_autorizador_divergencia")]
        public virtual long? IdAcsUsuarioAutorizadorDivergencia
         { 
            get { return this._valueIdAcsUsuarioAutorizadorDivergencia; } 
            set 
            { 
                if (this._valueIdAcsUsuarioAutorizadorDivergencia == value)return;
                 this._valueIdAcsUsuarioAutorizadorDivergencia = value; 
            } 
        } 

       protected double _precoPrevistoOriginal{get;private set;}
       private double _precoPrevistoOriginalCommited{get; set;}
        private double _valuePrecoPrevisto;
         [Column("lsc_preco_previsto")]
        public virtual double PrecoPrevisto
         { 
            get { return this._valuePrecoPrevisto; } 
            set 
            { 
                if (this._valuePrecoPrevisto == value)return;
                 this._valuePrecoPrevisto = value; 
            } 
        } 

       protected double _precoRecebidoOriginal{get;private set;}
       private double _precoRecebidoOriginalCommited{get; set;}
        private double _valuePrecoRecebido;
         [Column("lsc_preco_recebido")]
        public virtual double PrecoRecebido
         { 
            get { return this._valuePrecoRecebido; } 
            set 
            { 
                if (this._valuePrecoRecebido == value)return;
                 this._valuePrecoRecebido = value; 
            } 
        } 

       protected double _icmsPrevistoOriginal{get;private set;}
       private double _icmsPrevistoOriginalCommited{get; set;}
        private double _valueIcmsPrevisto;
         [Column("lsc_icms_previsto")]
        public virtual double IcmsPrevisto
         { 
            get { return this._valueIcmsPrevisto; } 
            set 
            { 
                if (this._valueIcmsPrevisto == value)return;
                 this._valueIcmsPrevisto = value; 
            } 
        } 

       protected double _icmsRecebidoOriginal{get;private set;}
       private double _icmsRecebidoOriginalCommited{get; set;}
        private double _valueIcmsRecebido;
         [Column("lsc_icms_recebido")]
        public virtual double IcmsRecebido
         { 
            get { return this._valueIcmsRecebido; } 
            set 
            { 
                if (this._valueIcmsRecebido == value)return;
                 this._valueIcmsRecebido = value; 
            } 
        } 

       protected double _ipiPrevistoOriginal{get;private set;}
       private double _ipiPrevistoOriginalCommited{get; set;}
        private double _valueIpiPrevisto;
         [Column("lsc_ipi_previsto")]
        public virtual double IpiPrevisto
         { 
            get { return this._valueIpiPrevisto; } 
            set 
            { 
                if (this._valueIpiPrevisto == value)return;
                 this._valueIpiPrevisto = value; 
            } 
        } 

       protected double _ipiRecebidoOriginal{get;private set;}
       private double _ipiRecebidoOriginalCommited{get; set;}
        private double _valueIpiRecebido;
         [Column("lsc_ipi_recebido")]
        public virtual double IpiRecebido
         { 
            get { return this._valueIpiRecebido; } 
            set 
            { 
                if (this._valueIpiRecebido == value)return;
                 this._valueIpiRecebido = value; 
            } 
        } 

        public LoteSolicitacaoCompraBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.RecebidoComDivergencia = 0;
           this.PrecoPrevisto = 0;
           this.PrecoRecebido = 0;
           this.IcmsPrevisto = 0;
           this.IcmsRecebido = 0;
           this.IpiPrevisto = 0;
           this.IpiRecebido = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static LoteSolicitacaoCompraClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (LoteSolicitacaoCompraClass) GetEntity(typeof(LoteSolicitacaoCompraClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueLote == null)
                {
                    throw new Exception(ErroLoteObrigatorio);
                }
                if ( _valueSolicitacaoCompra == null)
                {
                    throw new Exception(ErroSolicitacaoCompraObrigatorio);
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
                    "  public.lote_solicitacao_compra  " +
                    "WHERE " +
                    "  id_lote_solicitacao_compra = :id";
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
                        "  public.lote_solicitacao_compra   " +
                        "SET  " + 
                        "  id_lote = :id_lote, " + 
                        "  id_solicitacao_compra = :id_solicitacao_compra, " + 
                        "  lsc_quantidade = :lsc_quantidade, " + 
                        "  lsc_quantidade_compra = :lsc_quantidade_compra, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  lsc_recebido_com_divergencia = :lsc_recebido_com_divergencia, " + 
                        "  id_acs_usuario_autorizador_divergencia = :id_acs_usuario_autorizador_divergencia, " + 
                        "  lsc_preco_previsto = :lsc_preco_previsto, " + 
                        "  lsc_preco_recebido = :lsc_preco_recebido, " + 
                        "  lsc_icms_previsto = :lsc_icms_previsto, " + 
                        "  lsc_icms_recebido = :lsc_icms_recebido, " + 
                        "  lsc_ipi_previsto = :lsc_ipi_previsto, " + 
                        "  lsc_ipi_recebido = :lsc_ipi_recebido "+
                        "WHERE  " +
                        "  id_lote_solicitacao_compra = :id " +
                        "RETURNING id_lote_solicitacao_compra;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.lote_solicitacao_compra " +
                        "( " +
                        "  id_lote , " + 
                        "  id_solicitacao_compra , " + 
                        "  lsc_quantidade , " + 
                        "  lsc_quantidade_compra , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  lsc_recebido_com_divergencia , " + 
                        "  id_acs_usuario_autorizador_divergencia , " + 
                        "  lsc_preco_previsto , " + 
                        "  lsc_preco_recebido , " + 
                        "  lsc_icms_previsto , " + 
                        "  lsc_icms_recebido , " + 
                        "  lsc_ipi_previsto , " + 
                        "  lsc_ipi_recebido  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_lote , " + 
                        "  :id_solicitacao_compra , " + 
                        "  :lsc_quantidade , " + 
                        "  :lsc_quantidade_compra , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :lsc_recebido_com_divergencia , " + 
                        "  :id_acs_usuario_autorizador_divergencia , " + 
                        "  :lsc_preco_previsto , " + 
                        "  :lsc_preco_recebido , " + 
                        "  :lsc_icms_previsto , " + 
                        "  :lsc_icms_recebido , " + 
                        "  :lsc_ipi_previsto , " + 
                        "  :lsc_ipi_recebido  "+
                        ")RETURNING id_lote_solicitacao_compra;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_lote", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.Lote==null ? (object) DBNull.Value : this.Lote.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_solicitacao_compra", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.SolicitacaoCompra==null ? (object) DBNull.Value : this.SolicitacaoCompra.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_quantidade", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Quantidade ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_quantidade_compra", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.QuantidadeCompra ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_recebido_com_divergencia", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.RecebidoComDivergencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_acs_usuario_autorizador_divergencia", NpgsqlDbType.Bigint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IdAcsUsuarioAutorizadorDivergencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_preco_previsto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoPrevisto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_preco_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PrecoRecebido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_icms_previsto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPrevisto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_icms_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsRecebido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_ipi_previsto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiPrevisto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lsc_ipi_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiRecebido ?? DBNull.Value;

 
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
        public static LoteSolicitacaoCompraClass CopiarEntidade(LoteSolicitacaoCompraClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               LoteSolicitacaoCompraClass toRet = new LoteSolicitacaoCompraClass(usuario,conn);
 toRet.Lote= entidadeCopiar.Lote;
 toRet.SolicitacaoCompra= entidadeCopiar.SolicitacaoCompra;
 toRet.Quantidade= entidadeCopiar.Quantidade;
 toRet.QuantidadeCompra= entidadeCopiar.QuantidadeCompra;
 toRet.RecebidoComDivergencia= entidadeCopiar.RecebidoComDivergencia;
 toRet.IdAcsUsuarioAutorizadorDivergencia= entidadeCopiar.IdAcsUsuarioAutorizadorDivergencia;
 toRet.PrecoPrevisto= entidadeCopiar.PrecoPrevisto;
 toRet.PrecoRecebido= entidadeCopiar.PrecoRecebido;
 toRet.IcmsPrevisto= entidadeCopiar.IcmsPrevisto;
 toRet.IcmsRecebido= entidadeCopiar.IcmsRecebido;
 toRet.IpiPrevisto= entidadeCopiar.IpiPrevisto;
 toRet.IpiRecebido= entidadeCopiar.IpiRecebido;

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
       _loteOriginal = Lote;
       _loteOriginalCommited = _loteOriginal;
       _solicitacaoCompraOriginal = SolicitacaoCompra;
       _solicitacaoCompraOriginalCommited = _solicitacaoCompraOriginal;
       _quantidadeOriginal = Quantidade;
       _quantidadeOriginalCommited = _quantidadeOriginal;
       _quantidadeCompraOriginal = QuantidadeCompra;
       _quantidadeCompraOriginalCommited = _quantidadeCompraOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _recebidoComDivergenciaOriginal = RecebidoComDivergencia;
       _recebidoComDivergenciaOriginalCommited = _recebidoComDivergenciaOriginal;
       _idAcsUsuarioAutorizadorDivergenciaOriginal = IdAcsUsuarioAutorizadorDivergencia;
       _idAcsUsuarioAutorizadorDivergenciaOriginalCommited = _idAcsUsuarioAutorizadorDivergenciaOriginal;
       _precoPrevistoOriginal = PrecoPrevisto;
       _precoPrevistoOriginalCommited = _precoPrevistoOriginal;
       _precoRecebidoOriginal = PrecoRecebido;
       _precoRecebidoOriginalCommited = _precoRecebidoOriginal;
       _icmsPrevistoOriginal = IcmsPrevisto;
       _icmsPrevistoOriginalCommited = _icmsPrevistoOriginal;
       _icmsRecebidoOriginal = IcmsRecebido;
       _icmsRecebidoOriginalCommited = _icmsRecebidoOriginal;
       _ipiPrevistoOriginal = IpiPrevisto;
       _ipiPrevistoOriginalCommited = _ipiPrevistoOriginal;
       _ipiRecebidoOriginal = IpiRecebido;
       _ipiRecebidoOriginalCommited = _ipiRecebidoOriginal;

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
       _loteOriginalCommited = Lote;
       _solicitacaoCompraOriginalCommited = SolicitacaoCompra;
       _quantidadeOriginalCommited = Quantidade;
       _quantidadeCompraOriginalCommited = QuantidadeCompra;
       _versionOriginalCommited = Version;
       _recebidoComDivergenciaOriginalCommited = RecebidoComDivergencia;
       _idAcsUsuarioAutorizadorDivergenciaOriginalCommited = IdAcsUsuarioAutorizadorDivergencia;
       _precoPrevistoOriginalCommited = PrecoPrevisto;
       _precoRecebidoOriginalCommited = PrecoRecebido;
       _icmsPrevistoOriginalCommited = IcmsPrevisto;
       _icmsRecebidoOriginalCommited = IcmsRecebido;
       _ipiPrevistoOriginalCommited = IpiPrevisto;
       _ipiRecebidoOriginalCommited = IpiRecebido;

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
               Lote=_loteOriginal;
               _loteOriginalCommited=_loteOriginal;
               SolicitacaoCompra=_solicitacaoCompraOriginal;
               _solicitacaoCompraOriginalCommited=_solicitacaoCompraOriginal;
               Quantidade=_quantidadeOriginal;
               _quantidadeOriginalCommited=_quantidadeOriginal;
               QuantidadeCompra=_quantidadeCompraOriginal;
               _quantidadeCompraOriginalCommited=_quantidadeCompraOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               RecebidoComDivergencia=_recebidoComDivergenciaOriginal;
               _recebidoComDivergenciaOriginalCommited=_recebidoComDivergenciaOriginal;
               IdAcsUsuarioAutorizadorDivergencia=_idAcsUsuarioAutorizadorDivergenciaOriginal;
               _idAcsUsuarioAutorizadorDivergenciaOriginalCommited=_idAcsUsuarioAutorizadorDivergenciaOriginal;
               PrecoPrevisto=_precoPrevistoOriginal;
               _precoPrevistoOriginalCommited=_precoPrevistoOriginal;
               PrecoRecebido=_precoRecebidoOriginal;
               _precoRecebidoOriginalCommited=_precoRecebidoOriginal;
               IcmsPrevisto=_icmsPrevistoOriginal;
               _icmsPrevistoOriginalCommited=_icmsPrevistoOriginal;
               IcmsRecebido=_icmsRecebidoOriginal;
               _icmsRecebidoOriginalCommited=_icmsRecebidoOriginal;
               IpiPrevisto=_ipiPrevistoOriginal;
               _ipiPrevistoOriginalCommited=_ipiPrevistoOriginal;
               IpiRecebido=_ipiRecebidoOriginal;
               _ipiRecebidoOriginalCommited=_ipiRecebidoOriginal;

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
       if (_loteOriginal!=null)
       {
          dirty = !_loteOriginal.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
       }
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
       dirty = _quantidadeOriginal != Quantidade;
      if (dirty) return true;
       dirty = _quantidadeCompraOriginal != QuantidadeCompra;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _recebidoComDivergenciaOriginal != RecebidoComDivergencia;
      if (dirty) return true;
       dirty = _idAcsUsuarioAutorizadorDivergenciaOriginal != IdAcsUsuarioAutorizadorDivergencia;
      if (dirty) return true;
       dirty = _precoPrevistoOriginal != PrecoPrevisto;
      if (dirty) return true;
       dirty = _precoRecebidoOriginal != PrecoRecebido;
      if (dirty) return true;
       dirty = _icmsPrevistoOriginal != IcmsPrevisto;
      if (dirty) return true;
       dirty = _icmsRecebidoOriginal != IcmsRecebido;
      if (dirty) return true;
       dirty = _ipiPrevistoOriginal != IpiPrevisto;
      if (dirty) return true;
       dirty = _ipiRecebidoOriginal != IpiRecebido;

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
       if (_loteOriginalCommited!=null)
       {
          dirty = !_loteOriginalCommited.Equals(Lote);
       }
       else
       {
            dirty = Lote != null;
       }
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
       dirty = _quantidadeOriginalCommited != Quantidade;
      if (dirty) return true;
       dirty = _quantidadeCompraOriginalCommited != QuantidadeCompra;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _recebidoComDivergenciaOriginalCommited != RecebidoComDivergencia;
      if (dirty) return true;
       dirty = _idAcsUsuarioAutorizadorDivergenciaOriginalCommited != IdAcsUsuarioAutorizadorDivergencia;
      if (dirty) return true;
       dirty = _precoPrevistoOriginalCommited != PrecoPrevisto;
      if (dirty) return true;
       dirty = _precoRecebidoOriginalCommited != PrecoRecebido;
      if (dirty) return true;
       dirty = _icmsPrevistoOriginalCommited != IcmsPrevisto;
      if (dirty) return true;
       dirty = _icmsRecebidoOriginalCommited != IcmsRecebido;
      if (dirty) return true;
       dirty = _ipiPrevistoOriginalCommited != IpiPrevisto;
      if (dirty) return true;
       dirty = _ipiRecebidoOriginalCommited != IpiRecebido;

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
             case "Lote":
                return this.Lote;
             case "SolicitacaoCompra":
                return this.SolicitacaoCompra;
             case "Quantidade":
                return this.Quantidade;
             case "QuantidadeCompra":
                return this.QuantidadeCompra;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "RecebidoComDivergencia":
                return this.RecebidoComDivergencia;
             case "IdAcsUsuarioAutorizadorDivergencia":
                return this.IdAcsUsuarioAutorizadorDivergencia;
             case "PrecoPrevisto":
                return this.PrecoPrevisto;
             case "PrecoRecebido":
                return this.PrecoRecebido;
             case "IcmsPrevisto":
                return this.IcmsPrevisto;
             case "IcmsRecebido":
                return this.IcmsRecebido;
             case "IpiPrevisto":
                return this.IpiPrevisto;
             case "IpiRecebido":
                return this.IpiRecebido;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (Lote!=null)
                Lote.ChangeSingleConnection(newConnection);
             if (SolicitacaoCompra!=null)
                SolicitacaoCompra.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(lote_solicitacao_compra.id_lote_solicitacao_compra) " ;
               }
               else
               {
               command.CommandText += "lote_solicitacao_compra.id_lote_solicitacao_compra, " ;
               command.CommandText += "lote_solicitacao_compra.id_lote, " ;
               command.CommandText += "lote_solicitacao_compra.id_solicitacao_compra, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_quantidade, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_quantidade_compra, " ;
               command.CommandText += "lote_solicitacao_compra.entity_uid, " ;
               command.CommandText += "lote_solicitacao_compra.version, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_recebido_com_divergencia, " ;
               command.CommandText += "lote_solicitacao_compra.id_acs_usuario_autorizador_divergencia, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_preco_previsto, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_preco_recebido, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_icms_previsto, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_icms_recebido, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_ipi_previsto, " ;
               command.CommandText += "lote_solicitacao_compra.lsc_ipi_recebido " ;
               }
               command.CommandText += " FROM  lote_solicitacao_compra ";
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
                        orderByClause += " , lsc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(lsc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = lote_solicitacao_compra.id_acs_usuario_ultima_revisao ";
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
                     case "id_lote_solicitacao_compra":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.id_lote_solicitacao_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.id_lote_solicitacao_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_lote":
                     case "Lote":
                     command.CommandText += " LEFT JOIN lote as lote_Lote ON lote_Lote.id_lote = lote_solicitacao_compra.id_lote ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote_Lote.lot_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote_Lote.lot_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_solicitacao_compra":
                     case "SolicitacaoCompra":
                     command.CommandText += " LEFT JOIN solicitacao_compra as solicitacao_compra_SolicitacaoCompra ON solicitacao_compra_SolicitacaoCompra.id_solicitacao_compra = lote_solicitacao_compra.id_solicitacao_compra ";                     switch (parametro.TipoOrdenacao)
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
                     case "lsc_quantidade":
                     case "Quantidade":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_quantidade " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_quantidade) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_quantidade_compra":
                     case "QuantidadeCompra":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_quantidade_compra " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_quantidade_compra) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , lote_solicitacao_compra.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(lote_solicitacao_compra.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , lote_solicitacao_compra.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_recebido_com_divergencia":
                     case "RecebidoComDivergencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_recebido_com_divergencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_recebido_com_divergencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_acs_usuario_autorizador_divergencia":
                     case "IdAcsUsuarioAutorizadorDivergencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.id_acs_usuario_autorizador_divergencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.id_acs_usuario_autorizador_divergencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_preco_previsto":
                     case "PrecoPrevisto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_preco_previsto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_preco_previsto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_preco_recebido":
                     case "PrecoRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_preco_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_preco_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_icms_previsto":
                     case "IcmsPrevisto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_icms_previsto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_icms_previsto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_icms_recebido":
                     case "IcmsRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_icms_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_icms_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_ipi_previsto":
                     case "IpiPrevisto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_ipi_previsto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_ipi_previsto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "lsc_ipi_recebido":
                     case "IpiRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , lote_solicitacao_compra.lsc_ipi_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(lote_solicitacao_compra.lsc_ipi_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(lote_solicitacao_compra.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(lote_solicitacao_compra.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_lote_solicitacao_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.id_lote_solicitacao_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.id_lote_solicitacao_compra = :lote_solicitacao_compra_ID_3837 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_ID_3837", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Lote" || parametro.FieldName == "id_lote")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.LoteClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.LoteClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.id_lote IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.id_lote = :lote_solicitacao_compra_Lote_7891 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_Lote_7891", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
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
                         whereClause += "  lote_solicitacao_compra.id_solicitacao_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.id_solicitacao_compra = :lote_solicitacao_compra_SolicitacaoCompra_3444 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_SolicitacaoCompra_3444", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Quantidade" || parametro.FieldName == "lsc_quantidade")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_quantidade IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_quantidade = :lote_solicitacao_compra_Quantidade_355 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_Quantidade_355", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "QuantidadeCompra" || parametro.FieldName == "lsc_quantidade_compra")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_quantidade_compra IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_quantidade_compra = :lote_solicitacao_compra_QuantidadeCompra_5225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_QuantidadeCompra_5225", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  lote_solicitacao_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.entity_uid LIKE :lote_solicitacao_compra_EntityUid_9723 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_EntityUid_9723", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  lote_solicitacao_compra.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.version = :lote_solicitacao_compra_Version_9870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_Version_9870", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "RecebidoComDivergencia" || parametro.FieldName == "lsc_recebido_com_divergencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_recebido_com_divergencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_recebido_com_divergencia = :lote_solicitacao_compra_RecebidoComDivergencia_2067 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_RecebidoComDivergencia_2067", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdAcsUsuarioAutorizadorDivergencia" || parametro.FieldName == "id_acs_usuario_autorizador_divergencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.id_acs_usuario_autorizador_divergencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.id_acs_usuario_autorizador_divergencia = :lote_solicitacao_compra_IdAcsUsuarioAutorizadorDivergencia_9630 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_IdAcsUsuarioAutorizadorDivergencia_9630", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoPrevisto" || parametro.FieldName == "lsc_preco_previsto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_preco_previsto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_preco_previsto = :lote_solicitacao_compra_PrecoPrevisto_208 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_PrecoPrevisto_208", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PrecoRecebido" || parametro.FieldName == "lsc_preco_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_preco_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_preco_recebido = :lote_solicitacao_compra_PrecoRecebido_5312 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_PrecoRecebido_5312", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPrevisto" || parametro.FieldName == "lsc_icms_previsto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_icms_previsto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_icms_previsto = :lote_solicitacao_compra_IcmsPrevisto_2026 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_IcmsPrevisto_2026", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsRecebido" || parametro.FieldName == "lsc_icms_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_icms_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_icms_recebido = :lote_solicitacao_compra_IcmsRecebido_840 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_IcmsRecebido_840", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiPrevisto" || parametro.FieldName == "lsc_ipi_previsto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_ipi_previsto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_ipi_previsto = :lote_solicitacao_compra_IpiPrevisto_8423 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_IpiPrevisto_8423", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiRecebido" || parametro.FieldName == "lsc_ipi_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_ipi_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.lsc_ipi_recebido = :lote_solicitacao_compra_IpiRecebido_435 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_IpiRecebido_435", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  lote_solicitacao_compra.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  lote_solicitacao_compra.entity_uid LIKE :lote_solicitacao_compra_EntityUid_7114 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("lote_solicitacao_compra_EntityUid_7114", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  LoteSolicitacaoCompraClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (LoteSolicitacaoCompraClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(LoteSolicitacaoCompraClass), Convert.ToInt32(read["id_lote_solicitacao_compra"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new LoteSolicitacaoCompraClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_lote_solicitacao_compra"]);
                     if (read["id_lote"] != DBNull.Value)
                     {
                        entidade.Lote = (BibliotecaEntidades.Entidades.LoteClass)BibliotecaEntidades.Entidades.LoteClass.GetEntidade(Convert.ToInt32(read["id_lote"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.Lote = null ;
                     }
                     if (read["id_solicitacao_compra"] != DBNull.Value)
                     {
                        entidade.SolicitacaoCompra = (BibliotecaEntidades.Entidades.SolicitacaoCompraClass)BibliotecaEntidades.Entidades.SolicitacaoCompraClass.GetEntidade(Convert.ToInt32(read["id_solicitacao_compra"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.SolicitacaoCompra = null ;
                     }
                     entidade.Quantidade = (double)read["lsc_quantidade"];
                     entidade.QuantidadeCompra = (double)read["lsc_quantidade_compra"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.RecebidoComDivergencia = (short)read["lsc_recebido_com_divergencia"];
                     entidade.IdAcsUsuarioAutorizadorDivergencia = (read["id_acs_usuario_autorizador_divergencia"] != DBNull.Value ? (long?)Convert.ToInt64(read["id_acs_usuario_autorizador_divergencia"]) : null);
                     entidade.PrecoPrevisto = (double)read["lsc_preco_previsto"];
                     entidade.PrecoRecebido = (double)read["lsc_preco_recebido"];
                     entidade.IcmsPrevisto = (double)read["lsc_icms_previsto"];
                     entidade.IcmsRecebido = (double)read["lsc_icms_recebido"];
                     entidade.IpiPrevisto = (double)read["lsc_ipi_previsto"];
                     entidade.IpiRecebido = (double)read["lsc_ipi_recebido"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (LoteSolicitacaoCompraClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
