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
     [Table("cob_boleto_retorno","cbr")]
     public class CobBoletoRetornoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do CobBoletoRetornoClass";
protected const string ErroDelete = "Erro ao excluir o CobBoletoRetornoClass  ";
protected const string ErroSave = "Erro ao salvar o CobBoletoRetornoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroCobRetornoObrigatorio = "O campo CobRetorno é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do CobBoletoRetornoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade CobBoletoRetornoClass está sendo utilizada.";
#endregion
       protected BibliotecaEntidades.Entidades.CobBoletoClass _cobBoletoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CobBoletoClass _cobBoletoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CobBoletoClass _valueCobBoleto;
        [Column("id_cob_boleto", "cob_boleto", "id_cob_boleto")]
       public virtual BibliotecaEntidades.Entidades.CobBoletoClass CobBoleto
        { 
           get {                 return this._valueCobBoleto; } 
           set 
           { 
                if (this._valueCobBoleto == value)return;
                 this._valueCobBoleto = value; 
           } 
       } 

       protected BibliotecaEntidades.Entidades.CobRetornoClass _cobRetornoOriginal{get;private set;}
       private BibliotecaEntidades.Entidades.CobRetornoClass _cobRetornoOriginalCommited {get; set;}
       private BibliotecaEntidades.Entidades.CobRetornoClass _valueCobRetorno;
        [Column("id_cob_retorno", "cob_retorno", "id_cob_retorno")]
       public virtual BibliotecaEntidades.Entidades.CobRetornoClass CobRetorno
        { 
           get {                 return this._valueCobRetorno; } 
           set 
           { 
                if (this._valueCobRetorno == value)return;
                 this._valueCobRetorno = value; 
           } 
       } 

       protected int _codigoRetornoOriginal{get;private set;}
       private int _codigoRetornoOriginalCommited{get; set;}
        private int _valueCodigoRetorno;
         [Column("cbr_codigo_retorno")]
        public virtual int CodigoRetorno
         { 
            get { return this._valueCodigoRetorno; } 
            set 
            { 
                if (this._valueCodigoRetorno == value)return;
                 this._valueCodigoRetorno = value; 
            } 
        } 

       protected DateTime _dataOcorrenciaOriginal{get;private set;}
       private DateTime _dataOcorrenciaOriginalCommited{get; set;}
        private DateTime _valueDataOcorrencia;
         [Column("cbr_data_ocorrencia")]
        public virtual DateTime DataOcorrencia
         { 
            get { return this._valueDataOcorrencia; } 
            set 
            { 
                if (this._valueDataOcorrencia == value)return;
                 this._valueDataOcorrencia = value; 
            } 
        } 

       protected DateTime? _dataVencimentoOriginal{get;private set;}
       private DateTime? _dataVencimentoOriginalCommited{get; set;}
        private DateTime? _valueDataVencimento;
         [Column("cbr_data_vencimento")]
        public virtual DateTime? DataVencimento
         { 
            get { return this._valueDataVencimento; } 
            set 
            { 
                if (this._valueDataVencimento == value)return;
                 this._valueDataVencimento = value; 
            } 
        } 

       protected double? _valorTituloOriginal{get;private set;}
       private double? _valorTituloOriginalCommited{get; set;}
        private double? _valueValorTitulo;
         [Column("cbr_valor_titulo")]
        public virtual double? ValorTitulo
         { 
            get { return this._valueValorTitulo; } 
            set 
            { 
                if (this._valueValorTitulo == value)return;
                 this._valueValorTitulo = value; 
            } 
        } 

       protected double? _tarifaCobrancaOriginal{get;private set;}
       private double? _tarifaCobrancaOriginalCommited{get; set;}
        private double? _valueTarifaCobranca;
         [Column("cbr_tarifa_cobranca")]
        public virtual double? TarifaCobranca
         { 
            get { return this._valueTarifaCobranca; } 
            set 
            { 
                if (this._valueTarifaCobranca == value)return;
                 this._valueTarifaCobranca = value; 
            } 
        } 

       protected double? _valorDescontoOriginal{get;private set;}
       private double? _valorDescontoOriginalCommited{get; set;}
        private double? _valueValorDesconto;
         [Column("cbr_valor_desconto")]
        public virtual double? ValorDesconto
         { 
            get { return this._valueValorDesconto; } 
            set 
            { 
                if (this._valueValorDesconto == value)return;
                 this._valueValorDesconto = value; 
            } 
        } 

       protected double? _valorLiquidoRecebidoOriginal{get;private set;}
       private double? _valorLiquidoRecebidoOriginalCommited{get; set;}
        private double? _valueValorLiquidoRecebido;
         [Column("cbr_valor_liquido_recebido")]
        public virtual double? ValorLiquidoRecebido
         { 
            get { return this._valueValorLiquidoRecebido; } 
            set 
            { 
                if (this._valueValorLiquidoRecebido == value)return;
                 this._valueValorLiquidoRecebido = value; 
            } 
        } 

       protected double? _valorJurosMultaOriginal{get;private set;}
       private double? _valorJurosMultaOriginalCommited{get; set;}
        private double? _valueValorJurosMulta;
         [Column("cbr_valor_juros_multa")]
        public virtual double? ValorJurosMulta
         { 
            get { return this._valueValorJurosMulta; } 
            set 
            { 
                if (this._valueValorJurosMulta == value)return;
                 this._valueValorJurosMulta = value; 
            } 
        } 

       protected double? _outrosCreditosOriginal{get;private set;}
       private double? _outrosCreditosOriginalCommited{get; set;}
        private double? _valueOutrosCreditos;
         [Column("cbr_outros_creditos")]
        public virtual double? OutrosCreditos
         { 
            get { return this._valueOutrosCreditos; } 
            set 
            { 
                if (this._valueOutrosCreditos == value)return;
                 this._valueOutrosCreditos = value; 
            } 
        } 

       protected DateTime? _dataCreditoOriginal{get;private set;}
       private DateTime? _dataCreditoOriginalCommited{get; set;}
        private DateTime? _valueDataCredito;
         [Column("cbr_data_credito")]
        public virtual DateTime? DataCredito
         { 
            get { return this._valueDataCredito; } 
            set 
            { 
                if (this._valueDataCredito == value)return;
                 this._valueDataCredito = value; 
            } 
        } 

       protected int? _codigoInstrucaoCanceladaOriginal{get;private set;}
       private int? _codigoInstrucaoCanceladaOriginalCommited{get; set;}
        private int? _valueCodigoInstrucaoCancelada;
         [Column("cbr_codigo_instrucao_cancelada")]
        public virtual int? CodigoInstrucaoCancelada
         { 
            get { return this._valueCodigoInstrucaoCancelada; } 
            set 
            { 
                if (this._valueCodigoInstrucaoCancelada == value)return;
                 this._valueCodigoInstrucaoCancelada = value; 
            } 
        } 

       protected string _mensagemOriginal{get;private set;}
       private string _mensagemOriginalCommited{get; set;}
        private string _valueMensagem;
         [Column("cbr_mensagem")]
        public virtual string Mensagem
         { 
            get { return this._valueMensagem; } 
            set 
            { 
                if (this._valueMensagem == value)return;
                 this._valueMensagem = value; 
            } 
        } 

       protected string _mensagemSistemaOriginal{get;private set;}
       private string _mensagemSistemaOriginalCommited{get; set;}
        private string _valueMensagemSistema;
         [Column("cbr_mensagem_sistema")]
        public virtual string MensagemSistema
         { 
            get { return this._valueMensagemSistema; } 
            set 
            { 
                if (this._valueMensagemSistema == value)return;
                 this._valueMensagemSistema = value; 
            } 
        } 

       protected int _processarOriginal{get;private set;}
       private int _processarOriginalCommited{get; set;}
        private int _valueProcessar;
         [Column("cbr_processar")]
        public virtual int Processar
         { 
            get { return this._valueProcessar; } 
            set 
            { 
                if (this._valueProcessar == value)return;
                 this._valueProcessar = value; 
            } 
        } 

        public CobBoletoRetornoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Processar = 1;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static CobBoletoRetornoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (CobBoletoRetornoClass) GetEntity(typeof(CobBoletoRetornoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueCobRetorno == null)
                {
                    throw new Exception(ErroCobRetornoObrigatorio);
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
                    "  public.cob_boleto_retorno  " +
                    "WHERE " +
                    "  id_cob_boleto_retorno = :id";
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
                        "  public.cob_boleto_retorno   " +
                        "SET  " + 
                        "  id_cob_boleto = :id_cob_boleto, " + 
                        "  id_cob_retorno = :id_cob_retorno, " + 
                        "  cbr_codigo_retorno = :cbr_codigo_retorno, " + 
                        "  cbr_data_ocorrencia = :cbr_data_ocorrencia, " + 
                        "  cbr_data_vencimento = :cbr_data_vencimento, " + 
                        "  cbr_valor_titulo = :cbr_valor_titulo, " + 
                        "  cbr_tarifa_cobranca = :cbr_tarifa_cobranca, " + 
                        "  cbr_valor_desconto = :cbr_valor_desconto, " + 
                        "  cbr_valor_liquido_recebido = :cbr_valor_liquido_recebido, " + 
                        "  cbr_valor_juros_multa = :cbr_valor_juros_multa, " + 
                        "  cbr_outros_creditos = :cbr_outros_creditos, " + 
                        "  cbr_data_credito = :cbr_data_credito, " + 
                        "  cbr_codigo_instrucao_cancelada = :cbr_codigo_instrucao_cancelada, " + 
                        "  cbr_mensagem = :cbr_mensagem, " + 
                        "  cbr_mensagem_sistema = :cbr_mensagem_sistema, " + 
                        "  cbr_processar = :cbr_processar, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version "+
                        "WHERE  " +
                        "  id_cob_boleto_retorno = :id " +
                        "RETURNING id_cob_boleto_retorno;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.cob_boleto_retorno " +
                        "( " +
                        "  id_cob_boleto , " + 
                        "  id_cob_retorno , " + 
                        "  cbr_codigo_retorno , " + 
                        "  cbr_data_ocorrencia , " + 
                        "  cbr_data_vencimento , " + 
                        "  cbr_valor_titulo , " + 
                        "  cbr_tarifa_cobranca , " + 
                        "  cbr_valor_desconto , " + 
                        "  cbr_valor_liquido_recebido , " + 
                        "  cbr_valor_juros_multa , " + 
                        "  cbr_outros_creditos , " + 
                        "  cbr_data_credito , " + 
                        "  cbr_codigo_instrucao_cancelada , " + 
                        "  cbr_mensagem , " + 
                        "  cbr_mensagem_sistema , " + 
                        "  cbr_processar , " + 
                        "  entity_uid , " + 
                        "  version  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_cob_boleto , " + 
                        "  :id_cob_retorno , " + 
                        "  :cbr_codigo_retorno , " + 
                        "  :cbr_data_ocorrencia , " + 
                        "  :cbr_data_vencimento , " + 
                        "  :cbr_valor_titulo , " + 
                        "  :cbr_tarifa_cobranca , " + 
                        "  :cbr_valor_desconto , " + 
                        "  :cbr_valor_liquido_recebido , " + 
                        "  :cbr_valor_juros_multa , " + 
                        "  :cbr_outros_creditos , " + 
                        "  :cbr_data_credito , " + 
                        "  :cbr_codigo_instrucao_cancelada , " + 
                        "  :cbr_mensagem , " + 
                        "  :cbr_mensagem_sistema , " + 
                        "  :cbr_processar , " + 
                        "  :entity_uid , " + 
                        "  :version  "+
                        ")RETURNING id_cob_boleto_retorno;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cob_boleto", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CobBoleto==null ? (object) DBNull.Value : this.CobBoleto.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_cob_retorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.CobRetorno==null ? (object) DBNull.Value : this.CobRetorno.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_codigo_retorno", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoRetorno ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_data_ocorrencia", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataOcorrencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_data_vencimento", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataVencimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_valor_titulo", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTitulo ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_tarifa_cobranca", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TarifaCobranca ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_valor_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorDesconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_valor_liquido_recebido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorLiquidoRecebido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_valor_juros_multa", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorJurosMulta ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_outros_creditos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OutrosCreditos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_data_credito", NpgsqlDbType.Date));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DataCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_codigo_instrucao_cancelada", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoInstrucaoCancelada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_mensagem", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Mensagem ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_mensagem_sistema", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MensagemSistema ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cbr_processar", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Processar ?? DBNull.Value;
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
        public static CobBoletoRetornoClass CopiarEntidade(CobBoletoRetornoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               CobBoletoRetornoClass toRet = new CobBoletoRetornoClass(usuario,conn);
 toRet.CobBoleto= entidadeCopiar.CobBoleto;
 toRet.CobRetorno= entidadeCopiar.CobRetorno;
 toRet.CodigoRetorno= entidadeCopiar.CodigoRetorno;
 toRet.DataOcorrencia= entidadeCopiar.DataOcorrencia;
 toRet.DataVencimento= entidadeCopiar.DataVencimento;
 toRet.ValorTitulo= entidadeCopiar.ValorTitulo;
 toRet.TarifaCobranca= entidadeCopiar.TarifaCobranca;
 toRet.ValorDesconto= entidadeCopiar.ValorDesconto;
 toRet.ValorLiquidoRecebido= entidadeCopiar.ValorLiquidoRecebido;
 toRet.ValorJurosMulta= entidadeCopiar.ValorJurosMulta;
 toRet.OutrosCreditos= entidadeCopiar.OutrosCreditos;
 toRet.DataCredito= entidadeCopiar.DataCredito;
 toRet.CodigoInstrucaoCancelada= entidadeCopiar.CodigoInstrucaoCancelada;
 toRet.Mensagem= entidadeCopiar.Mensagem;
 toRet.MensagemSistema= entidadeCopiar.MensagemSistema;
 toRet.Processar= entidadeCopiar.Processar;

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
       _cobBoletoOriginal = CobBoleto;
       _cobBoletoOriginalCommited = _cobBoletoOriginal;
       _cobRetornoOriginal = CobRetorno;
       _cobRetornoOriginalCommited = _cobRetornoOriginal;
       _codigoRetornoOriginal = CodigoRetorno;
       _codigoRetornoOriginalCommited = _codigoRetornoOriginal;
       _dataOcorrenciaOriginal = DataOcorrencia;
       _dataOcorrenciaOriginalCommited = _dataOcorrenciaOriginal;
       _dataVencimentoOriginal = DataVencimento;
       _dataVencimentoOriginalCommited = _dataVencimentoOriginal;
       _valorTituloOriginal = ValorTitulo;
       _valorTituloOriginalCommited = _valorTituloOriginal;
       _tarifaCobrancaOriginal = TarifaCobranca;
       _tarifaCobrancaOriginalCommited = _tarifaCobrancaOriginal;
       _valorDescontoOriginal = ValorDesconto;
       _valorDescontoOriginalCommited = _valorDescontoOriginal;
       _valorLiquidoRecebidoOriginal = ValorLiquidoRecebido;
       _valorLiquidoRecebidoOriginalCommited = _valorLiquidoRecebidoOriginal;
       _valorJurosMultaOriginal = ValorJurosMulta;
       _valorJurosMultaOriginalCommited = _valorJurosMultaOriginal;
       _outrosCreditosOriginal = OutrosCreditos;
       _outrosCreditosOriginalCommited = _outrosCreditosOriginal;
       _dataCreditoOriginal = DataCredito;
       _dataCreditoOriginalCommited = _dataCreditoOriginal;
       _codigoInstrucaoCanceladaOriginal = CodigoInstrucaoCancelada;
       _codigoInstrucaoCanceladaOriginalCommited = _codigoInstrucaoCanceladaOriginal;
       _mensagemOriginal = Mensagem;
       _mensagemOriginalCommited = _mensagemOriginal;
       _mensagemSistemaOriginal = MensagemSistema;
       _mensagemSistemaOriginalCommited = _mensagemSistemaOriginal;
       _processarOriginal = Processar;
       _processarOriginalCommited = _processarOriginal;
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
       _cobBoletoOriginalCommited = CobBoleto;
       _cobRetornoOriginalCommited = CobRetorno;
       _codigoRetornoOriginalCommited = CodigoRetorno;
       _dataOcorrenciaOriginalCommited = DataOcorrencia;
       _dataVencimentoOriginalCommited = DataVencimento;
       _valorTituloOriginalCommited = ValorTitulo;
       _tarifaCobrancaOriginalCommited = TarifaCobranca;
       _valorDescontoOriginalCommited = ValorDesconto;
       _valorLiquidoRecebidoOriginalCommited = ValorLiquidoRecebido;
       _valorJurosMultaOriginalCommited = ValorJurosMulta;
       _outrosCreditosOriginalCommited = OutrosCreditos;
       _dataCreditoOriginalCommited = DataCredito;
       _codigoInstrucaoCanceladaOriginalCommited = CodigoInstrucaoCancelada;
       _mensagemOriginalCommited = Mensagem;
       _mensagemSistemaOriginalCommited = MensagemSistema;
       _processarOriginalCommited = Processar;
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
               CobBoleto=_cobBoletoOriginal;
               _cobBoletoOriginalCommited=_cobBoletoOriginal;
               CobRetorno=_cobRetornoOriginal;
               _cobRetornoOriginalCommited=_cobRetornoOriginal;
               CodigoRetorno=_codigoRetornoOriginal;
               _codigoRetornoOriginalCommited=_codigoRetornoOriginal;
               DataOcorrencia=_dataOcorrenciaOriginal;
               _dataOcorrenciaOriginalCommited=_dataOcorrenciaOriginal;
               DataVencimento=_dataVencimentoOriginal;
               _dataVencimentoOriginalCommited=_dataVencimentoOriginal;
               ValorTitulo=_valorTituloOriginal;
               _valorTituloOriginalCommited=_valorTituloOriginal;
               TarifaCobranca=_tarifaCobrancaOriginal;
               _tarifaCobrancaOriginalCommited=_tarifaCobrancaOriginal;
               ValorDesconto=_valorDescontoOriginal;
               _valorDescontoOriginalCommited=_valorDescontoOriginal;
               ValorLiquidoRecebido=_valorLiquidoRecebidoOriginal;
               _valorLiquidoRecebidoOriginalCommited=_valorLiquidoRecebidoOriginal;
               ValorJurosMulta=_valorJurosMultaOriginal;
               _valorJurosMultaOriginalCommited=_valorJurosMultaOriginal;
               OutrosCreditos=_outrosCreditosOriginal;
               _outrosCreditosOriginalCommited=_outrosCreditosOriginal;
               DataCredito=_dataCreditoOriginal;
               _dataCreditoOriginalCommited=_dataCreditoOriginal;
               CodigoInstrucaoCancelada=_codigoInstrucaoCanceladaOriginal;
               _codigoInstrucaoCanceladaOriginalCommited=_codigoInstrucaoCanceladaOriginal;
               Mensagem=_mensagemOriginal;
               _mensagemOriginalCommited=_mensagemOriginal;
               MensagemSistema=_mensagemSistemaOriginal;
               _mensagemSistemaOriginalCommited=_mensagemSistemaOriginal;
               Processar=_processarOriginal;
               _processarOriginalCommited=_processarOriginal;
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
       if (_cobBoletoOriginal!=null)
       {
          dirty = !_cobBoletoOriginal.Equals(CobBoleto);
       }
       else
       {
            dirty = CobBoleto != null;
       }
      if (dirty) return true;
       if (_cobRetornoOriginal!=null)
       {
          dirty = !_cobRetornoOriginal.Equals(CobRetorno);
       }
       else
       {
            dirty = CobRetorno != null;
       }
      if (dirty) return true;
       dirty = _codigoRetornoOriginal != CodigoRetorno;
      if (dirty) return true;
       dirty = _dataOcorrenciaOriginal != DataOcorrencia;
      if (dirty) return true;
       dirty = _dataVencimentoOriginal != DataVencimento;
      if (dirty) return true;
       dirty = _valorTituloOriginal != ValorTitulo;
      if (dirty) return true;
       dirty = _tarifaCobrancaOriginal != TarifaCobranca;
      if (dirty) return true;
       dirty = _valorDescontoOriginal != ValorDesconto;
      if (dirty) return true;
       dirty = _valorLiquidoRecebidoOriginal != ValorLiquidoRecebido;
      if (dirty) return true;
       dirty = _valorJurosMultaOriginal != ValorJurosMulta;
      if (dirty) return true;
       dirty = _outrosCreditosOriginal != OutrosCreditos;
      if (dirty) return true;
       dirty = _dataCreditoOriginal != DataCredito;
      if (dirty) return true;
       dirty = _codigoInstrucaoCanceladaOriginal != CodigoInstrucaoCancelada;
      if (dirty) return true;
       dirty = _mensagemOriginal != Mensagem;
      if (dirty) return true;
       dirty = _mensagemSistemaOriginal != MensagemSistema;
      if (dirty) return true;
       dirty = _processarOriginal != Processar;
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
       if (_cobBoletoOriginalCommited!=null)
       {
          dirty = !_cobBoletoOriginalCommited.Equals(CobBoleto);
       }
       else
       {
            dirty = CobBoleto != null;
       }
      if (dirty) return true;
       if (_cobRetornoOriginalCommited!=null)
       {
          dirty = !_cobRetornoOriginalCommited.Equals(CobRetorno);
       }
       else
       {
            dirty = CobRetorno != null;
       }
      if (dirty) return true;
       dirty = _codigoRetornoOriginalCommited != CodigoRetorno;
      if (dirty) return true;
       dirty = _dataOcorrenciaOriginalCommited != DataOcorrencia;
      if (dirty) return true;
       dirty = _dataVencimentoOriginalCommited != DataVencimento;
      if (dirty) return true;
       dirty = _valorTituloOriginalCommited != ValorTitulo;
      if (dirty) return true;
       dirty = _tarifaCobrancaOriginalCommited != TarifaCobranca;
      if (dirty) return true;
       dirty = _valorDescontoOriginalCommited != ValorDesconto;
      if (dirty) return true;
       dirty = _valorLiquidoRecebidoOriginalCommited != ValorLiquidoRecebido;
      if (dirty) return true;
       dirty = _valorJurosMultaOriginalCommited != ValorJurosMulta;
      if (dirty) return true;
       dirty = _outrosCreditosOriginalCommited != OutrosCreditos;
      if (dirty) return true;
       dirty = _dataCreditoOriginalCommited != DataCredito;
      if (dirty) return true;
       dirty = _codigoInstrucaoCanceladaOriginalCommited != CodigoInstrucaoCancelada;
      if (dirty) return true;
       dirty = _mensagemOriginalCommited != Mensagem;
      if (dirty) return true;
       dirty = _mensagemSistemaOriginalCommited != MensagemSistema;
      if (dirty) return true;
       dirty = _processarOriginalCommited != Processar;
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
             case "CobBoleto":
                return this.CobBoleto;
             case "CobRetorno":
                return this.CobRetorno;
             case "CodigoRetorno":
                return this.CodigoRetorno;
             case "DataOcorrencia":
                return this.DataOcorrencia;
             case "DataVencimento":
                return this.DataVencimento;
             case "ValorTitulo":
                return this.ValorTitulo;
             case "TarifaCobranca":
                return this.TarifaCobranca;
             case "ValorDesconto":
                return this.ValorDesconto;
             case "ValorLiquidoRecebido":
                return this.ValorLiquidoRecebido;
             case "ValorJurosMulta":
                return this.ValorJurosMulta;
             case "OutrosCreditos":
                return this.OutrosCreditos;
             case "DataCredito":
                return this.DataCredito;
             case "CodigoInstrucaoCancelada":
                return this.CodigoInstrucaoCancelada;
             case "Mensagem":
                return this.Mensagem;
             case "MensagemSistema":
                return this.MensagemSistema;
             case "Processar":
                return this.Processar;
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
             if (CobBoleto!=null)
                CobBoleto.ChangeSingleConnection(newConnection);
             if (CobRetorno!=null)
                CobRetorno.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(cob_boleto_retorno.id_cob_boleto_retorno) " ;
               }
               else
               {
               command.CommandText += "cob_boleto_retorno.id_cob_boleto_retorno, " ;
               command.CommandText += "cob_boleto_retorno.id_cob_boleto, " ;
               command.CommandText += "cob_boleto_retorno.id_cob_retorno, " ;
               command.CommandText += "cob_boleto_retorno.cbr_codigo_retorno, " ;
               command.CommandText += "cob_boleto_retorno.cbr_data_ocorrencia, " ;
               command.CommandText += "cob_boleto_retorno.cbr_data_vencimento, " ;
               command.CommandText += "cob_boleto_retorno.cbr_valor_titulo, " ;
               command.CommandText += "cob_boleto_retorno.cbr_tarifa_cobranca, " ;
               command.CommandText += "cob_boleto_retorno.cbr_valor_desconto, " ;
               command.CommandText += "cob_boleto_retorno.cbr_valor_liquido_recebido, " ;
               command.CommandText += "cob_boleto_retorno.cbr_valor_juros_multa, " ;
               command.CommandText += "cob_boleto_retorno.cbr_outros_creditos, " ;
               command.CommandText += "cob_boleto_retorno.cbr_data_credito, " ;
               command.CommandText += "cob_boleto_retorno.cbr_codigo_instrucao_cancelada, " ;
               command.CommandText += "cob_boleto_retorno.cbr_mensagem, " ;
               command.CommandText += "cob_boleto_retorno.cbr_mensagem_sistema, " ;
               command.CommandText += "cob_boleto_retorno.cbr_processar, " ;
               command.CommandText += "cob_boleto_retorno.entity_uid, " ;
               command.CommandText += "cob_boleto_retorno.version " ;
               }
               command.CommandText += " FROM  cob_boleto_retorno ";
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
                        orderByClause += " , cbr_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(cbr_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = cob_boleto_retorno.id_acs_usuario_ultima_revisao ";
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
                     case "id_cob_boleto_retorno":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.id_cob_boleto_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.id_cob_boleto_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cob_boleto":
                     case "CobBoleto":
                     command.CommandText += " LEFT JOIN cob_boleto as cob_boleto_CobBoleto ON cob_boleto_CobBoleto.id_cob_boleto = cob_boleto_retorno.id_cob_boleto ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_CobBoleto.bol_nosso_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_CobBoleto.bol_nosso_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_cob_retorno":
                     case "CobRetorno":
                     command.CommandText += " LEFT JOIN cob_retorno as cob_retorno_CobRetorno ON cob_retorno_CobRetorno.id_cob_retorno = cob_boleto_retorno.id_cob_retorno ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_retorno_CobRetorno.ret_nome_arquivo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_retorno_CobRetorno.ret_nome_arquivo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_codigo_retorno":
                     case "CodigoRetorno":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_codigo_retorno " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_codigo_retorno) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_data_ocorrencia":
                     case "DataOcorrencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_data_ocorrencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_data_ocorrencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_data_vencimento":
                     case "DataVencimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_data_vencimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_data_vencimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_valor_titulo":
                     case "ValorTitulo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_valor_titulo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_valor_titulo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_tarifa_cobranca":
                     case "TarifaCobranca":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_tarifa_cobranca " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_tarifa_cobranca) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_valor_desconto":
                     case "ValorDesconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_valor_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_valor_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_valor_liquido_recebido":
                     case "ValorLiquidoRecebido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_valor_liquido_recebido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_valor_liquido_recebido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_valor_juros_multa":
                     case "ValorJurosMulta":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_valor_juros_multa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_valor_juros_multa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_outros_creditos":
                     case "OutrosCreditos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_outros_creditos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_outros_creditos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_data_credito":
                     case "DataCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_data_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_data_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_codigo_instrucao_cancelada":
                     case "CodigoInstrucaoCancelada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_codigo_instrucao_cancelada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_codigo_instrucao_cancelada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_mensagem":
                     case "Mensagem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_retorno.cbr_mensagem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_mensagem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_mensagem_sistema":
                     case "MensagemSistema":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_retorno.cbr_mensagem_sistema " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_mensagem_sistema) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "cbr_processar":
                     case "Processar":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , cob_boleto_retorno.cbr_processar " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.cbr_processar) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , cob_boleto_retorno.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(cob_boleto_retorno.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , cob_boleto_retorno.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(cob_boleto_retorno.version) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cbr_mensagem")) 
                        {
                           whereClause += " OR UPPER(cob_boleto_retorno.cbr_mensagem) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto_retorno.cbr_mensagem) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("cbr_mensagem_sistema")) 
                        {
                           whereClause += " OR UPPER(cob_boleto_retorno.cbr_mensagem_sistema) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto_retorno.cbr_mensagem_sistema) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(cob_boleto_retorno.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(cob_boleto_retorno.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_cob_boleto_retorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_boleto_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_boleto_retorno = :cob_boleto_retorno_ID_7271 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_ID_7271", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobBoleto" || parametro.FieldName == "id_cob_boleto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CobBoletoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CobBoletoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_boleto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_boleto = :cob_boleto_retorno_CobBoleto_1495 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_CobBoleto_1495", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CobRetorno" || parametro.FieldName == "id_cob_retorno")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is BibliotecaEntidades.Entidades.CobRetornoClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo BibliotecaEntidades.Entidades.CobRetornoClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.id_cob_retorno = :cob_boleto_retorno_CobRetorno_6273 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_CobRetorno_6273", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoRetorno" || parametro.FieldName == "cbr_codigo_retorno")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_codigo_retorno IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_codigo_retorno = :cob_boleto_retorno_CodigoRetorno_7200 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_CodigoRetorno_7200", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataOcorrencia" || parametro.FieldName == "cbr_data_ocorrencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_ocorrencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_ocorrencia = :cob_boleto_retorno_DataOcorrencia_3049 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_DataOcorrencia_3049", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataVencimento" || parametro.FieldName == "cbr_data_vencimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_vencimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_vencimento = :cob_boleto_retorno_DataVencimento_7830 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_DataVencimento_7830", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTitulo" || parametro.FieldName == "cbr_valor_titulo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_titulo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_titulo = :cob_boleto_retorno_ValorTitulo_7359 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_ValorTitulo_7359", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TarifaCobranca" || parametro.FieldName == "cbr_tarifa_cobranca")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_tarifa_cobranca IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_tarifa_cobranca = :cob_boleto_retorno_TarifaCobranca_4163 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_TarifaCobranca_4163", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorDesconto" || parametro.FieldName == "cbr_valor_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_desconto = :cob_boleto_retorno_ValorDesconto_4340 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_ValorDesconto_4340", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorLiquidoRecebido" || parametro.FieldName == "cbr_valor_liquido_recebido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_liquido_recebido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_liquido_recebido = :cob_boleto_retorno_ValorLiquidoRecebido_8011 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_ValorLiquidoRecebido_8011", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorJurosMulta" || parametro.FieldName == "cbr_valor_juros_multa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_juros_multa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_valor_juros_multa = :cob_boleto_retorno_ValorJurosMulta_355 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_ValorJurosMulta_355", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OutrosCreditos" || parametro.FieldName == "cbr_outros_creditos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_outros_creditos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_outros_creditos = :cob_boleto_retorno_OutrosCreditos_9457 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_OutrosCreditos_9457", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DataCredito" || parametro.FieldName == "cbr_data_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is DateTime?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo DateTime?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_data_credito = :cob_boleto_retorno_DataCredito_2725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_DataCredito_2725", NpgsqlDbType.Date, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoInstrucaoCancelada" || parametro.FieldName == "cbr_codigo_instrucao_cancelada")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_codigo_instrucao_cancelada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_codigo_instrucao_cancelada = :cob_boleto_retorno_CodigoInstrucaoCancelada_872 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_CodigoInstrucaoCancelada_872", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Mensagem" || parametro.FieldName == "cbr_mensagem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem LIKE :cob_boleto_retorno_Mensagem_237 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_Mensagem_237", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemSistema" || parametro.FieldName == "cbr_mensagem_sistema")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem_sistema IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem_sistema LIKE :cob_boleto_retorno_MensagemSistema_307 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_MensagemSistema_307", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Processar" || parametro.FieldName == "cbr_processar")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_processar IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_processar = :cob_boleto_retorno_Processar_7259 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_Processar_7259", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_boleto_retorno.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.entity_uid LIKE :cob_boleto_retorno_EntityUid_7215 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_EntityUid_7215", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  cob_boleto_retorno.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.version = :cob_boleto_retorno_Version_928 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_Version_928", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  cob_boleto_retorno.cbr_mensagem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem LIKE :cob_boleto_retorno_Mensagem_5560 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_Mensagem_5560", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MensagemSistemaExato" || parametro.FieldName == "MensagemSistemaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem_sistema IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.cbr_mensagem_sistema LIKE :cob_boleto_retorno_MensagemSistema_9762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_MensagemSistema_9762", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  cob_boleto_retorno.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  cob_boleto_retorno.entity_uid LIKE :cob_boleto_retorno_EntityUid_4484 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("cob_boleto_retorno_EntityUid_4484", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  CobBoletoRetornoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (CobBoletoRetornoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(CobBoletoRetornoClass), Convert.ToInt32(read["id_cob_boleto_retorno"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new CobBoletoRetornoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_cob_boleto_retorno"]);
                     if (read["id_cob_boleto"] != DBNull.Value)
                     {
                        entidade.CobBoleto = (BibliotecaEntidades.Entidades.CobBoletoClass)BibliotecaEntidades.Entidades.CobBoletoClass.GetEntidade(Convert.ToInt32(read["id_cob_boleto"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CobBoleto = null ;
                     }
                     if (read["id_cob_retorno"] != DBNull.Value)
                     {
                        entidade.CobRetorno = (BibliotecaEntidades.Entidades.CobRetornoClass)BibliotecaEntidades.Entidades.CobRetornoClass.GetEntidade(Convert.ToInt32(read["id_cob_retorno"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.CobRetorno = null ;
                     }
                     entidade.CodigoRetorno = (int)read["cbr_codigo_retorno"];
                     entidade.DataOcorrencia = (DateTime)read["cbr_data_ocorrencia"];
                     entidade.DataVencimento = read["cbr_data_vencimento"] as DateTime?;
                     entidade.ValorTitulo = read["cbr_valor_titulo"] as double?;
                     entidade.TarifaCobranca = read["cbr_tarifa_cobranca"] as double?;
                     entidade.ValorDesconto = read["cbr_valor_desconto"] as double?;
                     entidade.ValorLiquidoRecebido = read["cbr_valor_liquido_recebido"] as double?;
                     entidade.ValorJurosMulta = read["cbr_valor_juros_multa"] as double?;
                     entidade.OutrosCreditos = read["cbr_outros_creditos"] as double?;
                     entidade.DataCredito = read["cbr_data_credito"] as DateTime?;
                     entidade.CodigoInstrucaoCancelada = read["cbr_codigo_instrucao_cancelada"] as int?;
                     entidade.Mensagem = (read["cbr_mensagem"] != DBNull.Value ? read["cbr_mensagem"].ToString() : null);
                     entidade.MensagemSistema = (read["cbr_mensagem_sistema"] != DBNull.Value ? read["cbr_mensagem_sistema"].ToString() : null);
                     entidade.Processar = (int)read["cbr_processar"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (CobBoletoRetornoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
