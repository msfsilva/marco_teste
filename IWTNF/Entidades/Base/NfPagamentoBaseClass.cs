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
using IWTNF.Entidades.Entidades;
using IWTDotNetLib.ComplexLoginModule.Entidades.Entidades;
namespace IWTNF.Entidades.Base 
{ 
    [Serializable()]
     [Table("nf_pagamento","nfg")]
     public class NfPagamentoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfPagamentoClass";
protected const string ErroDelete = "Erro ao excluir o NfPagamentoClass  ";
protected const string ErroSave = "Erro ao salvar o NfPagamentoClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfPagamentoClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfPagamentoClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _nfPrincipalOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfPrincipalClass _valueNfPrincipal;
        [Column("id_nf_principal", "nf_principal", "id_nf_principal")]
       public virtual IWTNF.Entidades.Entidades.NfPrincipalClass NfPrincipal
        { 
           get {                 return this._valueNfPrincipal; } 
           set 
           { 
                if (this._valueNfPrincipal == value)return;
                 this._valueNfPrincipal = value; 
           } 
       } 

       protected NfPagamentoTipo _tipoOriginal{get;private set;}
       private NfPagamentoTipo _tipoOriginalCommited{get; set;}
        private NfPagamentoTipo _valueTipo;
         [Column("nfg_tipo")]
        public virtual NfPagamentoTipo Tipo
         { 
            get { return this._valueTipo; } 
            set 
            { 
                if (this._valueTipo == value)return;
                 this._valueTipo = value; 
            } 
        } 

        public bool Tipo_BoletoBancario
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.BoletoBancario; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.BoletoBancario; }
         } 

        public bool Tipo_SemPagamento
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.SemPagamento; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.SemPagamento; }
         } 

        public bool Tipo_Dinheiro
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.Dinheiro; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.Dinheiro; }
         } 

        public bool Tipo_Cheque
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.Cheque; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.Cheque; }
         } 

        public bool Tipo_CartaoCredito
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.CartaoCredito; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.CartaoCredito; }
         } 

        public bool Tipo_CartaoDebito
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.CartaoDebito; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.CartaoDebito; }
         } 

        public bool Tipo_CreditoLoja
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.CreditoLoja; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.CreditoLoja; }
         } 

        public bool Tipo_ValeAlimentacao
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.ValeAlimentacao; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.ValeAlimentacao; }
         } 

        public bool Tipo_Outros
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.Outros; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.Outros; }
         } 

        public bool Tipo_ValeRefeicao
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.ValeRefeicao; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.ValeRefeicao; }
         } 

        public bool Tipo_ValePresente
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.ValePresente; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.ValePresente; }
         } 

        public bool Tipo_ValeCombustivel
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.ValeCombustivel; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.ValeCombustivel; }
         } 

        public bool Tipo_DepositoBancario
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.DepositoBancario; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.DepositoBancario; }
         } 

        public bool Tipo_Pix
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.Pix; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.Pix; }
         } 

        public bool Tipo_TransferenciaBancaria
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.TransferenciaBancaria; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.TransferenciaBancaria; }
         } 

        public bool Tipo_ProgramaFidelidade
         { 
            get { return this._valueTipo == IWTNF.Entidades.Base.NfPagamentoTipo.ProgramaFidelidade; } 
            set { if (value) this._valueTipo = IWTNF.Entidades.Base.NfPagamentoTipo.ProgramaFidelidade; }
         } 

       protected double _valorOriginal{get;private set;}
       private double _valorOriginalCommited{get; set;}
        private double _valueValor;
         [Column("nfg_valor")]
        public virtual double Valor
         { 
            get { return this._valueValor; } 
            set 
            { 
                if (this._valueValor == value)return;
                 this._valueValor = value; 
            } 
        } 

       protected string _cnpjCredenciadoraOriginal{get;private set;}
       private string _cnpjCredenciadoraOriginalCommited{get; set;}
        private string _valueCnpjCredenciadora;
         [Column("nfg_cnpj_credenciadora")]
        public virtual string CnpjCredenciadora
         { 
            get { return this._valueCnpjCredenciadora; } 
            set 
            { 
                if (this._valueCnpjCredenciadora == value)return;
                 this._valueCnpjCredenciadora = value; 
            } 
        } 

       protected NfPagamentoBandeira? _bandeiraOriginal{get;private set;}
       private NfPagamentoBandeira? _bandeiraOriginalCommited{get; set;}
        private NfPagamentoBandeira? _valueBandeira;
         [Column("nfg_bandeira")]
        public virtual NfPagamentoBandeira? Bandeira
         { 
            get { return this._valueBandeira; } 
            set 
            { 
                if (this._valueBandeira == value)return;
                 this._valueBandeira = value; 
            } 
        } 

        public bool Bandeira_Diners
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Diners; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Diners; }
         } 

        public bool Bandeira_Elo
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Elo; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Elo; }
         } 

        public bool Bandeira_Hipercard
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Hipercard; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Hipercard; }
         } 

        public bool Bandeira_Aura
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Aura; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Aura; }
         } 

        public bool Bandeira_Cabal
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Cabal; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Cabal; }
         } 

        public bool Bandeira_Visa
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Visa; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Visa; }
         } 

        public bool Bandeira_Mastercard
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Mastercard; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Mastercard; }
         } 

        public bool Bandeira_American
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.American; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.American; }
         } 

        public bool Bandeira_Sorocred
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Sorocred; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Sorocred; }
         } 

        public bool Bandeira_Outros
         { 
            get { return this._valueBandeira.HasValue && this._valueBandeira.Value == IWTNF.Entidades.Base.NfPagamentoBandeira.Outros; } 
            set { if (value) this._valueBandeira = IWTNF.Entidades.Base.NfPagamentoBandeira.Outros; }
         } 

       protected string _numeroAutorizacaoOriginal{get;private set;}
       private string _numeroAutorizacaoOriginalCommited{get; set;}
        private string _valueNumeroAutorizacao;
         [Column("nfg_numero_autorizacao")]
        public virtual string NumeroAutorizacao
         { 
            get { return this._valueNumeroAutorizacao; } 
            set 
            { 
                if (this._valueNumeroAutorizacao == value)return;
                 this._valueNumeroAutorizacao = value; 
            } 
        } 

       protected NfPagamentoTipoIntegracao? _tipoIntegracaoOriginal{get;private set;}
       private NfPagamentoTipoIntegracao? _tipoIntegracaoOriginalCommited{get; set;}
        private NfPagamentoTipoIntegracao? _valueTipoIntegracao;
         [Column("nfg_tipo_integracao")]
        public virtual NfPagamentoTipoIntegracao? TipoIntegracao
         { 
            get { return this._valueTipoIntegracao; } 
            set 
            { 
                if (this._valueTipoIntegracao == value)return;
                 this._valueTipoIntegracao = value; 
            } 
        } 

        public bool TipoIntegracao_Integrado
         { 
            get { return this._valueTipoIntegracao.HasValue && this._valueTipoIntegracao.Value == IWTNF.Entidades.Base.NfPagamentoTipoIntegracao.Integrado; } 
            set { if (value) this._valueTipoIntegracao = IWTNF.Entidades.Base.NfPagamentoTipoIntegracao.Integrado; }
         } 

        public bool TipoIntegracao_NaoIntegrado
         { 
            get { return this._valueTipoIntegracao.HasValue && this._valueTipoIntegracao.Value == IWTNF.Entidades.Base.NfPagamentoTipoIntegracao.NaoIntegrado; } 
            set { if (value) this._valueTipoIntegracao = IWTNF.Entidades.Base.NfPagamentoTipoIntegracao.NaoIntegrado; }
         } 

       protected double? _trocoOriginal{get;private set;}
       private double? _trocoOriginalCommited{get; set;}
        private double? _valueTroco;
         [Column("nfg_troco")]
        public virtual double? Troco
         { 
            get { return this._valueTroco; } 
            set 
            { 
                if (this._valueTroco == value)return;
                 this._valueTroco = value; 
            } 
        } 

       protected string _tipoDescricaoOriginal{get;private set;}
       private string _tipoDescricaoOriginalCommited{get; set;}
        private string _valueTipoDescricao;
         [Column("nfg_tipo_descricao")]
        public virtual string TipoDescricao
         { 
            get { return this._valueTipoDescricao; } 
            set 
            { 
                if (this._valueTipoDescricao == value)return;
                 this._valueTipoDescricao = value; 
            } 
        } 

        public NfPagamentoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.Tipo = (NfPagamentoTipo)1;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfPagamentoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfPagamentoClass) GetEntity(typeof(NfPagamentoClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if ( _valueNfPrincipal == null)
                {
                    throw new Exception(ErroNfPrincipalObrigatorio);
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
                    "  public.nf_pagamento  " +
                    "WHERE " +
                    "  id_nf_pagamento = :id";
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
                        "  public.nf_pagamento   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nfg_tipo = :nfg_tipo, " + 
                        "  nfg_valor = :nfg_valor, " + 
                        "  nfg_cnpj_credenciadora = :nfg_cnpj_credenciadora, " + 
                        "  nfg_bandeira = :nfg_bandeira, " + 
                        "  nfg_numero_autorizacao = :nfg_numero_autorizacao, " + 
                        "  nfg_tipo_integracao = :nfg_tipo_integracao, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfg_troco = :nfg_troco, " + 
                        "  nfg_tipo_descricao = :nfg_tipo_descricao "+
                        "WHERE  " +
                        "  id_nf_pagamento = :id " +
                        "RETURNING id_nf_pagamento;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_pagamento " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nfg_tipo , " + 
                        "  nfg_valor , " + 
                        "  nfg_cnpj_credenciadora , " + 
                        "  nfg_bandeira , " + 
                        "  nfg_numero_autorizacao , " + 
                        "  nfg_tipo_integracao , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfg_troco , " + 
                        "  nfg_tipo_descricao  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nfg_tipo , " + 
                        "  :nfg_valor , " + 
                        "  :nfg_cnpj_credenciadora , " + 
                        "  :nfg_bandeira , " + 
                        "  :nfg_numero_autorizacao , " + 
                        "  :nfg_tipo_integracao , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfg_troco , " + 
                        "  :nfg_tipo_descricao  "+
                        ")RETURNING id_nf_pagamento;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_tipo", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Tipo);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Valor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_cnpj_credenciadora", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CnpjCredenciadora ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_bandeira", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.Bandeira.HasValue ? (object)Convert.ToInt16(this.Bandeira) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_numero_autorizacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NumeroAutorizacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_tipo_integracao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.TipoIntegracao.HasValue ? (object)Convert.ToInt16(this.TipoIntegracao) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_troco", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Troco ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfg_tipo_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TipoDescricao ?? DBNull.Value;

 
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
        public static NfPagamentoClass CopiarEntidade(NfPagamentoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfPagamentoClass toRet = new NfPagamentoClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.Tipo= entidadeCopiar.Tipo;
 toRet.Valor= entidadeCopiar.Valor;
 toRet.CnpjCredenciadora= entidadeCopiar.CnpjCredenciadora;
 toRet.Bandeira= entidadeCopiar.Bandeira;
 toRet.NumeroAutorizacao= entidadeCopiar.NumeroAutorizacao;
 toRet.TipoIntegracao= entidadeCopiar.TipoIntegracao;
 toRet.Troco= entidadeCopiar.Troco;
 toRet.TipoDescricao= entidadeCopiar.TipoDescricao;

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
       _nfPrincipalOriginal = NfPrincipal;
       _nfPrincipalOriginalCommited = _nfPrincipalOriginal;
       _tipoOriginal = Tipo;
       _tipoOriginalCommited = _tipoOriginal;
       _valorOriginal = Valor;
       _valorOriginalCommited = _valorOriginal;
       _cnpjCredenciadoraOriginal = CnpjCredenciadora;
       _cnpjCredenciadoraOriginalCommited = _cnpjCredenciadoraOriginal;
       _bandeiraOriginal = Bandeira;
       _bandeiraOriginalCommited = _bandeiraOriginal;
       _numeroAutorizacaoOriginal = NumeroAutorizacao;
       _numeroAutorizacaoOriginalCommited = _numeroAutorizacaoOriginal;
       _tipoIntegracaoOriginal = TipoIntegracao;
       _tipoIntegracaoOriginalCommited = _tipoIntegracaoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _trocoOriginal = Troco;
       _trocoOriginalCommited = _trocoOriginal;
       _tipoDescricaoOriginal = TipoDescricao;
       _tipoDescricaoOriginalCommited = _tipoDescricaoOriginal;

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
       _nfPrincipalOriginalCommited = NfPrincipal;
       _tipoOriginalCommited = Tipo;
       _valorOriginalCommited = Valor;
       _cnpjCredenciadoraOriginalCommited = CnpjCredenciadora;
       _bandeiraOriginalCommited = Bandeira;
       _numeroAutorizacaoOriginalCommited = NumeroAutorizacao;
       _tipoIntegracaoOriginalCommited = TipoIntegracao;
       _versionOriginalCommited = Version;
       _trocoOriginalCommited = Troco;
       _tipoDescricaoOriginalCommited = TipoDescricao;

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
               NfPrincipal=_nfPrincipalOriginal;
               _nfPrincipalOriginalCommited=_nfPrincipalOriginal;
               Tipo=_tipoOriginal;
               _tipoOriginalCommited=_tipoOriginal;
               Valor=_valorOriginal;
               _valorOriginalCommited=_valorOriginal;
               CnpjCredenciadora=_cnpjCredenciadoraOriginal;
               _cnpjCredenciadoraOriginalCommited=_cnpjCredenciadoraOriginal;
               Bandeira=_bandeiraOriginal;
               _bandeiraOriginalCommited=_bandeiraOriginal;
               NumeroAutorizacao=_numeroAutorizacaoOriginal;
               _numeroAutorizacaoOriginalCommited=_numeroAutorizacaoOriginal;
               TipoIntegracao=_tipoIntegracaoOriginal;
               _tipoIntegracaoOriginalCommited=_tipoIntegracaoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               Troco=_trocoOriginal;
               _trocoOriginalCommited=_trocoOriginal;
               TipoDescricao=_tipoDescricaoOriginal;
               _tipoDescricaoOriginalCommited=_tipoDescricaoOriginal;

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
       if (_nfPrincipalOriginal!=null)
       {
          dirty = !_nfPrincipalOriginal.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _tipoOriginal != Tipo;
      if (dirty) return true;
       dirty = _valorOriginal != Valor;
      if (dirty) return true;
       dirty = _cnpjCredenciadoraOriginal != CnpjCredenciadora;
      if (dirty) return true;
       dirty = _bandeiraOriginal != Bandeira;
      if (dirty) return true;
       dirty = _numeroAutorizacaoOriginal != NumeroAutorizacao;
      if (dirty) return true;
       dirty = _tipoIntegracaoOriginal != TipoIntegracao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _trocoOriginal != Troco;
      if (dirty) return true;
       dirty = _tipoDescricaoOriginal != TipoDescricao;

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
       if (_nfPrincipalOriginalCommited!=null)
       {
          dirty = !_nfPrincipalOriginalCommited.Equals(NfPrincipal);
       }
       else
       {
            dirty = NfPrincipal != null;
       }
      if (dirty) return true;
       dirty = _tipoOriginalCommited != Tipo;
      if (dirty) return true;
       dirty = _valorOriginalCommited != Valor;
      if (dirty) return true;
       dirty = _cnpjCredenciadoraOriginalCommited != CnpjCredenciadora;
      if (dirty) return true;
       dirty = _bandeiraOriginalCommited != Bandeira;
      if (dirty) return true;
       dirty = _numeroAutorizacaoOriginalCommited != NumeroAutorizacao;
      if (dirty) return true;
       dirty = _tipoIntegracaoOriginalCommited != TipoIntegracao;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _trocoOriginalCommited != Troco;
      if (dirty) return true;
       dirty = _tipoDescricaoOriginalCommited != TipoDescricao;

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
             case "NfPrincipal":
                return this.NfPrincipal;
             case "Tipo":
                return this.Tipo;
             case "Valor":
                return this.Valor;
             case "CnpjCredenciadora":
                return this.CnpjCredenciadora;
             case "Bandeira":
                return this.Bandeira;
             case "NumeroAutorizacao":
                return this.NumeroAutorizacao;
             case "TipoIntegracao":
                return this.TipoIntegracao;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "Troco":
                return this.Troco;
             case "TipoDescricao":
                return this.TipoDescricao;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfPrincipal!=null)
                NfPrincipal.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_pagamento.id_nf_pagamento) " ;
               }
               else
               {
               command.CommandText += "nf_pagamento.id_nf_pagamento, " ;
               command.CommandText += "nf_pagamento.id_nf_principal, " ;
               command.CommandText += "nf_pagamento.nfg_tipo, " ;
               command.CommandText += "nf_pagamento.nfg_valor, " ;
               command.CommandText += "nf_pagamento.nfg_cnpj_credenciadora, " ;
               command.CommandText += "nf_pagamento.nfg_bandeira, " ;
               command.CommandText += "nf_pagamento.nfg_numero_autorizacao, " ;
               command.CommandText += "nf_pagamento.nfg_tipo_integracao, " ;
               command.CommandText += "nf_pagamento.entity_uid, " ;
               command.CommandText += "nf_pagamento.version, " ;
               command.CommandText += "nf_pagamento.nfg_troco, " ;
               command.CommandText += "nf_pagamento.nfg_tipo_descricao " ;
               }
               command.CommandText += " FROM  nf_pagamento ";
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
                        orderByClause += " , nfg_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfg_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_pagamento.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_pagamento":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.id_nf_pagamento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.id_nf_pagamento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_principal":
                     case "NfPrincipal":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_pagamento.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_principal_NfPrincipal.nfp_numero " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_principal_NfPrincipal.nfp_numero) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_tipo":
                     case "Tipo":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.nfg_tipo " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.nfg_tipo) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_valor":
                     case "Valor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.nfg_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.nfg_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_cnpj_credenciadora":
                     case "CnpjCredenciadora":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_pagamento.nfg_cnpj_credenciadora " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_pagamento.nfg_cnpj_credenciadora) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_bandeira":
                     case "Bandeira":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.nfg_bandeira " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.nfg_bandeira) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_numero_autorizacao":
                     case "NumeroAutorizacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_pagamento.nfg_numero_autorizacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_pagamento.nfg_numero_autorizacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_tipo_integracao":
                     case "TipoIntegracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.nfg_tipo_integracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.nfg_tipo_integracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_pagamento.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_pagamento.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_pagamento.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_troco":
                     case "Troco":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_pagamento.nfg_troco " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_pagamento.nfg_troco) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfg_tipo_descricao":
                     case "TipoDescricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_pagamento.nfg_tipo_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_pagamento.nfg_tipo_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfg_cnpj_credenciadora")) 
                        {
                           whereClause += " OR UPPER(nf_pagamento.nfg_cnpj_credenciadora) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_pagamento.nfg_cnpj_credenciadora) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfg_numero_autorizacao")) 
                        {
                           whereClause += " OR UPPER(nf_pagamento.nfg_numero_autorizacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_pagamento.nfg_numero_autorizacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_pagamento.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_pagamento.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("nfg_tipo_descricao")) 
                        {
                           whereClause += " OR UPPER(nf_pagamento.nfg_tipo_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_pagamento.nfg_tipo_descricao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_pagamento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.id_nf_pagamento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.id_nf_pagamento = :nf_pagamento_ID_7421 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_ID_7421", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NfPrincipal" || parametro.FieldName == "id_nf_principal")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfPrincipalClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfPrincipalClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.id_nf_principal = :nf_pagamento_NfPrincipal_7646 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_NfPrincipal_7646", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Tipo" || parametro.FieldName == "nfg_tipo")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is NfPagamentoTipo)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo NfPagamentoTipo");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_tipo IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_tipo = :nf_pagamento_Tipo_9971 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_Tipo_9971", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Valor" || parametro.FieldName == "nfg_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_valor = :nf_pagamento_Valor_4064 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_Valor_4064", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCredenciadora" || parametro.FieldName == "nfg_cnpj_credenciadora")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_cnpj_credenciadora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_cnpj_credenciadora LIKE :nf_pagamento_CnpjCredenciadora_9364 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_CnpjCredenciadora_9364", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Bandeira" || parametro.FieldName == "nfg_bandeira")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is NfPagamentoBandeira?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo NfPagamentoBandeira?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_bandeira IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_bandeira = :nf_pagamento_Bandeira_7453 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_Bandeira_7453", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroAutorizacao" || parametro.FieldName == "nfg_numero_autorizacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_numero_autorizacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_numero_autorizacao LIKE :nf_pagamento_NumeroAutorizacao_3479 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_NumeroAutorizacao_3479", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoIntegracao" || parametro.FieldName == "nfg_tipo_integracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is NfPagamentoTipoIntegracao?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo NfPagamentoTipoIntegracao?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_integracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_integracao = :nf_pagamento_TipoIntegracao_1834 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_TipoIntegracao_1834", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
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
                         whereClause += "  nf_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.entity_uid LIKE :nf_pagamento_EntityUid_8975 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_EntityUid_8975", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_pagamento.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.version = :nf_pagamento_Version_3022 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_Version_3022", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Troco" || parametro.FieldName == "nfg_troco")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_troco IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_troco = :nf_pagamento_Troco_7715 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_Troco_7715", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDescricao" || parametro.FieldName == "nfg_tipo_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_descricao LIKE :nf_pagamento_TipoDescricao_9607 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_TipoDescricao_9607", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CnpjCredenciadoraExato" || parametro.FieldName == "CnpjCredenciadoraExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_cnpj_credenciadora IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_cnpj_credenciadora LIKE :nf_pagamento_CnpjCredenciadora_6239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_CnpjCredenciadora_6239", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NumeroAutorizacaoExato" || parametro.FieldName == "NumeroAutorizacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_numero_autorizacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_numero_autorizacao LIKE :nf_pagamento_NumeroAutorizacao_2384 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_NumeroAutorizacao_2384", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_pagamento.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.entity_uid LIKE :nf_pagamento_EntityUid_2848 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_EntityUid_2848", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TipoDescricaoExato" || parametro.FieldName == "TipoDescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_pagamento.nfg_tipo_descricao LIKE :nf_pagamento_TipoDescricao_1395 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_pagamento_TipoDescricao_1395", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfPagamentoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfPagamentoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfPagamentoClass), Convert.ToInt32(read["id_nf_pagamento"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfPagamentoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_nf_pagamento"]);
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.Tipo = (NfPagamentoTipo) (read["nfg_tipo"] != DBNull.Value ? Enum.ToObject(typeof(NfPagamentoTipo), read["nfg_tipo"]) : null);
                     entidade.Valor = (double)read["nfg_valor"];
                     entidade.CnpjCredenciadora = (read["nfg_cnpj_credenciadora"] != DBNull.Value ? read["nfg_cnpj_credenciadora"].ToString() : null);
                     entidade.Bandeira = (NfPagamentoBandeira?) (read["nfg_bandeira"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(NfPagamentoBandeira?)), read["nfg_bandeira"]) : null);
                     entidade.NumeroAutorizacao = (read["nfg_numero_autorizacao"] != DBNull.Value ? read["nfg_numero_autorizacao"].ToString() : null);
                     entidade.TipoIntegracao = (NfPagamentoTipoIntegracao?) (read["nfg_tipo_integracao"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(NfPagamentoTipoIntegracao?)), read["nfg_tipo_integracao"]) : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.Troco = read["nfg_troco"] as double?;
                     entidade.TipoDescricao = (read["nfg_tipo_descricao"] != DBNull.Value ? read["nfg_tipo_descricao"].ToString() : null);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfPagamentoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
