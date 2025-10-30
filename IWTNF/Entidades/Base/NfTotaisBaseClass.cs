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
     [Table("nf_totais","nfo")]
     public class NfTotaisBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfTotaisClass";
protected const string ErroDelete = "Erro ao excluir o NfTotaisClass  ";
protected const string ErroSave = "Erro ao salvar o NfTotaisClass.";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfPrincipalObrigatorio = "O campo NfPrincipal é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfTotaisClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfTotaisClass está sendo utilizada.";
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

       protected double _baseCalculoIcmsOriginal{get;private set;}
       private double _baseCalculoIcmsOriginalCommited{get; set;}
        private double _valueBaseCalculoIcms;
         [Column("nfo_base_calculo_icms")]
        public virtual double BaseCalculoIcms
         { 
            get { return this._valueBaseCalculoIcms; } 
            set 
            { 
                if (this._valueBaseCalculoIcms == value)return;
                 this._valueBaseCalculoIcms = value; 
            } 
        } 

       protected double _valorTotalIcmsOriginal{get;private set;}
       private double _valorTotalIcmsOriginalCommited{get; set;}
        private double _valueValorTotalIcms;
         [Column("nfo_valor_total_icms")]
        public virtual double ValorTotalIcms
         { 
            get { return this._valueValorTotalIcms; } 
            set 
            { 
                if (this._valueValorTotalIcms == value)return;
                 this._valueValorTotalIcms = value; 
            } 
        } 

       protected double _baseCalculoIcmsStOriginal{get;private set;}
       private double _baseCalculoIcmsStOriginalCommited{get; set;}
        private double _valueBaseCalculoIcmsSt;
         [Column("nfo_base_calculo_icms_st")]
        public virtual double BaseCalculoIcmsSt
         { 
            get { return this._valueBaseCalculoIcmsSt; } 
            set 
            { 
                if (this._valueBaseCalculoIcmsSt == value)return;
                 this._valueBaseCalculoIcmsSt = value; 
            } 
        } 

       protected double _valorTotalIcmsStOriginal{get;private set;}
       private double _valorTotalIcmsStOriginalCommited{get; set;}
        private double _valueValorTotalIcmsSt;
         [Column("nfo_valor_total_icms_st")]
        public virtual double ValorTotalIcmsSt
         { 
            get { return this._valueValorTotalIcmsSt; } 
            set 
            { 
                if (this._valueValorTotalIcmsSt == value)return;
                 this._valueValorTotalIcmsSt = value; 
            } 
        } 

       protected double _valorTotalProdutosServicosIcmsOriginal{get;private set;}
       private double _valorTotalProdutosServicosIcmsOriginalCommited{get; set;}
        private double _valueValorTotalProdutosServicosIcms;
         [Column("nfo_valor_total_produtos_servicos_icms")]
        public virtual double ValorTotalProdutosServicosIcms
         { 
            get { return this._valueValorTotalProdutosServicosIcms; } 
            set 
            { 
                if (this._valueValorTotalProdutosServicosIcms == value)return;
                 this._valueValorTotalProdutosServicosIcms = value; 
            } 
        } 

       protected double _valorTotalFreteOriginal{get;private set;}
       private double _valorTotalFreteOriginalCommited{get; set;}
        private double _valueValorTotalFrete;
         [Column("nfo_valor_total_frete")]
        public virtual double ValorTotalFrete
         { 
            get { return this._valueValorTotalFrete; } 
            set 
            { 
                if (this._valueValorTotalFrete == value)return;
                 this._valueValorTotalFrete = value; 
            } 
        } 

       protected double _valorTotalSeguroOriginal{get;private set;}
       private double _valorTotalSeguroOriginalCommited{get; set;}
        private double _valueValorTotalSeguro;
         [Column("nfo_valor_total_seguro")]
        public virtual double ValorTotalSeguro
         { 
            get { return this._valueValorTotalSeguro; } 
            set 
            { 
                if (this._valueValorTotalSeguro == value)return;
                 this._valueValorTotalSeguro = value; 
            } 
        } 

       protected double _valorTotalDescontoOriginal{get;private set;}
       private double _valorTotalDescontoOriginalCommited{get; set;}
        private double _valueValorTotalDesconto;
         [Column("nfo_valor_total_desconto")]
        public virtual double ValorTotalDesconto
         { 
            get { return this._valueValorTotalDesconto; } 
            set 
            { 
                if (this._valueValorTotalDesconto == value)return;
                 this._valueValorTotalDesconto = value; 
            } 
        } 

       protected double _valorTotalDescontoIiOriginal{get;private set;}
       private double _valorTotalDescontoIiOriginalCommited{get; set;}
        private double _valueValorTotalDescontoIi;
         [Column("nfo_valor_total_desconto_ii")]
        public virtual double ValorTotalDescontoIi
         { 
            get { return this._valueValorTotalDescontoIi; } 
            set 
            { 
                if (this._valueValorTotalDescontoIi == value)return;
                 this._valueValorTotalDescontoIi = value; 
            } 
        } 

       protected double _valorTotalIpiOriginal{get;private set;}
       private double _valorTotalIpiOriginalCommited{get; set;}
        private double _valueValorTotalIpi;
         [Column("nfo_valor_total_ipi")]
        public virtual double ValorTotalIpi
         { 
            get { return this._valueValorTotalIpi; } 
            set 
            { 
                if (this._valueValorTotalIpi == value)return;
                 this._valueValorTotalIpi = value; 
            } 
        } 

       protected double _valorTotalPisOriginal{get;private set;}
       private double _valorTotalPisOriginalCommited{get; set;}
        private double _valueValorTotalPis;
         [Column("nfo_valor_total_pis")]
        public virtual double ValorTotalPis
         { 
            get { return this._valueValorTotalPis; } 
            set 
            { 
                if (this._valueValorTotalPis == value)return;
                 this._valueValorTotalPis = value; 
            } 
        } 

       protected double _valorTotalCofinsOriginal{get;private set;}
       private double _valorTotalCofinsOriginalCommited{get; set;}
        private double _valueValorTotalCofins;
         [Column("nfo_valor_total_cofins")]
        public virtual double ValorTotalCofins
         { 
            get { return this._valueValorTotalCofins; } 
            set 
            { 
                if (this._valueValorTotalCofins == value)return;
                 this._valueValorTotalCofins = value; 
            } 
        } 

       protected double _outrasDespesasOriginal{get;private set;}
       private double _outrasDespesasOriginalCommited{get; set;}
        private double _valueOutrasDespesas;
         [Column("nfo_outras_despesas")]
        public virtual double OutrasDespesas
         { 
            get { return this._valueOutrasDespesas; } 
            set 
            { 
                if (this._valueOutrasDespesas == value)return;
                 this._valueOutrasDespesas = value; 
            } 
        } 

       protected double _valorTotalNfOriginal{get;private set;}
       private double _valorTotalNfOriginalCommited{get; set;}
        private double _valueValorTotalNf;
         [Column("nfo_valor_total_nf")]
        public virtual double ValorTotalNf
         { 
            get { return this._valueValorTotalNf; } 
            set 
            { 
                if (this._valueValorTotalNf == value)return;
                 this._valueValorTotalNf = value; 
            } 
        } 

       protected double? _valorTotalServicosOriginal{get;private set;}
       private double? _valorTotalServicosOriginalCommited{get; set;}
        private double? _valueValorTotalServicos;
         [Column("nfo_valor_total_servicos")]
        public virtual double? ValorTotalServicos
         { 
            get { return this._valueValorTotalServicos; } 
            set 
            { 
                if (this._valueValorTotalServicos == value)return;
                 this._valueValorTotalServicos = value; 
            } 
        } 

       protected double? _baseCalculoIssOriginal{get;private set;}
       private double? _baseCalculoIssOriginalCommited{get; set;}
        private double? _valueBaseCalculoIss;
         [Column("nfo_base_calculo_iss")]
        public virtual double? BaseCalculoIss
         { 
            get { return this._valueBaseCalculoIss; } 
            set 
            { 
                if (this._valueBaseCalculoIss == value)return;
                 this._valueBaseCalculoIss = value; 
            } 
        } 

       protected double? _valorTotalIssOriginal{get;private set;}
       private double? _valorTotalIssOriginalCommited{get; set;}
        private double? _valueValorTotalIss;
         [Column("nfo_valor_total_iss")]
        public virtual double? ValorTotalIss
         { 
            get { return this._valueValorTotalIss; } 
            set 
            { 
                if (this._valueValorTotalIss == value)return;
                 this._valueValorTotalIss = value; 
            } 
        } 

       protected double? _valorTotalPisServicosOriginal{get;private set;}
       private double? _valorTotalPisServicosOriginalCommited{get; set;}
        private double? _valueValorTotalPisServicos;
         [Column("nfo_valor_total_pis_servicos")]
        public virtual double? ValorTotalPisServicos
         { 
            get { return this._valueValorTotalPisServicos; } 
            set 
            { 
                if (this._valueValorTotalPisServicos == value)return;
                 this._valueValorTotalPisServicos = value; 
            } 
        } 

       protected double? _valorTotalCofinsServicosOriginal{get;private set;}
       private double? _valorTotalCofinsServicosOriginalCommited{get; set;}
        private double? _valueValorTotalCofinsServicos;
         [Column("nfo_valor_total_cofins_servicos")]
        public virtual double? ValorTotalCofinsServicos
         { 
            get { return this._valueValorTotalCofinsServicos; } 
            set 
            { 
                if (this._valueValorTotalCofinsServicos == value)return;
                 this._valueValorTotalCofinsServicos = value; 
            } 
        } 

       protected double _valorTotalIimpOriginal{get;private set;}
       private double _valorTotalIimpOriginalCommited{get; set;}
        private double _valueValorTotalIimp;
         [Column("nfo_valor_total_iimp")]
        public virtual double ValorTotalIimp
         { 
            get { return this._valueValorTotalIimp; } 
            set 
            { 
                if (this._valueValorTotalIimp == value)return;
                 this._valueValorTotalIimp = value; 
            } 
        } 

       protected double _valorTotalIcmsDiferidoOriginal{get;private set;}
       private double _valorTotalIcmsDiferidoOriginalCommited{get; set;}
        private double _valueValorTotalIcmsDiferido;
         [Column("nfo_valor_total_icms_diferido")]
        public virtual double ValorTotalIcmsDiferido
         { 
            get { return this._valueValorTotalIcmsDiferido; } 
            set 
            { 
                if (this._valueValorTotalIcmsDiferido == value)return;
                 this._valueValorTotalIcmsDiferido = value; 
            } 
        } 

       protected double? _valorRetidoPisOriginal{get;private set;}
       private double? _valorRetidoPisOriginalCommited{get; set;}
        private double? _valueValorRetidoPis;
         [Column("nfo_valor_retido_pis")]
        public virtual double? ValorRetidoPis
         { 
            get { return this._valueValorRetidoPis; } 
            set 
            { 
                if (this._valueValorRetidoPis == value)return;
                 this._valueValorRetidoPis = value; 
            } 
        } 

       protected double? _valorRetidoCofinsOriginal{get;private set;}
       private double? _valorRetidoCofinsOriginalCommited{get; set;}
        private double? _valueValorRetidoCofins;
         [Column("nfo_valor_retido_cofins")]
        public virtual double? ValorRetidoCofins
         { 
            get { return this._valueValorRetidoCofins; } 
            set 
            { 
                if (this._valueValorRetidoCofins == value)return;
                 this._valueValorRetidoCofins = value; 
            } 
        } 

       protected double? _valorRetidoCsllOriginal{get;private set;}
       private double? _valorRetidoCsllOriginalCommited{get; set;}
        private double? _valueValorRetidoCsll;
         [Column("nfo_valor_retido_csll")]
        public virtual double? ValorRetidoCsll
         { 
            get { return this._valueValorRetidoCsll; } 
            set 
            { 
                if (this._valueValorRetidoCsll == value)return;
                 this._valueValorRetidoCsll = value; 
            } 
        } 

       protected double? _valorRetidoBcIrrfOriginal{get;private set;}
       private double? _valorRetidoBcIrrfOriginalCommited{get; set;}
        private double? _valueValorRetidoBcIrrf;
         [Column("nfo_valor_retido_bc_irrf")]
        public virtual double? ValorRetidoBcIrrf
         { 
            get { return this._valueValorRetidoBcIrrf; } 
            set 
            { 
                if (this._valueValorRetidoBcIrrf == value)return;
                 this._valueValorRetidoBcIrrf = value; 
            } 
        } 

       protected double? _valorRetidoIrrfOriginal{get;private set;}
       private double? _valorRetidoIrrfOriginalCommited{get; set;}
        private double? _valueValorRetidoIrrf;
         [Column("nfo_valor_retido_irrf")]
        public virtual double? ValorRetidoIrrf
         { 
            get { return this._valueValorRetidoIrrf; } 
            set 
            { 
                if (this._valueValorRetidoIrrf == value)return;
                 this._valueValorRetidoIrrf = value; 
            } 
        } 

       protected double? _valorRetidoBcPrevidenciaOriginal{get;private set;}
       private double? _valorRetidoBcPrevidenciaOriginalCommited{get; set;}
        private double? _valueValorRetidoBcPrevidencia;
         [Column("nfo_valor_retido_bc_previdencia")]
        public virtual double? ValorRetidoBcPrevidencia
         { 
            get { return this._valueValorRetidoBcPrevidencia; } 
            set 
            { 
                if (this._valueValorRetidoBcPrevidencia == value)return;
                 this._valueValorRetidoBcPrevidencia = value; 
            } 
        } 

       protected double? _valorRetidoPrevienciaOriginal{get;private set;}
       private double? _valorRetidoPrevienciaOriginalCommited{get; set;}
        private double? _valueValorRetidoPreviencia;
         [Column("nfo_valor_retido_previencia")]
        public virtual double? ValorRetidoPreviencia
         { 
            get { return this._valueValorRetidoPreviencia; } 
            set 
            { 
                if (this._valueValorRetidoPreviencia == value)return;
                 this._valueValorRetidoPreviencia = value; 
            } 
        } 

       protected double? _valorTotalAproximadoTributosOriginal{get;private set;}
       private double? _valorTotalAproximadoTributosOriginalCommited{get; set;}
        private double? _valueValorTotalAproximadoTributos;
         [Column("nfo_valor_total_aproximado_tributos")]
        public virtual double? ValorTotalAproximadoTributos
         { 
            get { return this._valueValorTotalAproximadoTributos; } 
            set 
            { 
                if (this._valueValorTotalAproximadoTributos == value)return;
                 this._valueValorTotalAproximadoTributos = value; 
            } 
        } 

       protected double _valorTotalIcmsDesoneradoOriginal{get;private set;}
       private double _valorTotalIcmsDesoneradoOriginalCommited{get; set;}
        private double _valueValorTotalIcmsDesonerado;
         [Column("nfo_valor_total_icms_desonerado")]
        public virtual double ValorTotalIcmsDesonerado
         { 
            get { return this._valueValorTotalIcmsDesonerado; } 
            set 
            { 
                if (this._valueValorTotalIcmsDesonerado == value)return;
                 this._valueValorTotalIcmsDesonerado = value; 
            } 
        } 

       protected double? _totalIbsOriginal{get;private set;}
       private double? _totalIbsOriginalCommited{get; set;}
        private double? _valueTotalIbs;
         [Column("nfo_total_ibs")]
        public virtual double? TotalIbs
         { 
            get { return this._valueTotalIbs; } 
            set 
            { 
                if (this._valueTotalIbs == value)return;
                 this._valueTotalIbs = value; 
            } 
        } 

       protected double? _totalCbsOriginal{get;private set;}
       private double? _totalCbsOriginalCommited{get; set;}
        private double? _valueTotalCbs;
         [Column("nfo_total_cbs")]
        public virtual double? TotalCbs
         { 
            get { return this._valueTotalCbs; } 
            set 
            { 
                if (this._valueTotalCbs == value)return;
                 this._valueTotalCbs = value; 
            } 
        } 

       protected double? _totalIsOriginal{get;private set;}
       private double? _totalIsOriginalCommited{get; set;}
        private double? _valueTotalIs;
         [Column("nfo_total_is")]
        public virtual double? TotalIs
         { 
            get { return this._valueTotalIs; } 
            set 
            { 
                if (this._valueTotalIs == value)return;
                 this._valueTotalIs = value; 
            } 
        } 

       protected double? _vIbsCredOriginal{get;private set;}
       private double? _vIbsCredOriginalCommited{get; set;}
        private double? _valueVIbsCred;
         [Column("nfo_v_ibs_cred")]
        public virtual double? VIbsCred
         { 
            get { return this._valueVIbsCred; } 
            set 
            { 
                if (this._valueVIbsCred == value)return;
                 this._valueVIbsCred = value; 
            } 
        } 

       protected double? _vIbsDifOriginal{get;private set;}
       private double? _vIbsDifOriginalCommited{get; set;}
        private double? _valueVIbsDif;
         [Column("nfo_v_ibs_dif")]
        public virtual double? VIbsDif
         { 
            get { return this._valueVIbsDif; } 
            set 
            { 
                if (this._valueVIbsDif == value)return;
                 this._valueVIbsDif = value; 
            } 
        } 

       protected double? _vIbsDevOriginal{get;private set;}
       private double? _vIbsDevOriginalCommited{get; set;}
        private double? _valueVIbsDev;
         [Column("nfo_v_ibs_dev")]
        public virtual double? VIbsDev
         { 
            get { return this._valueVIbsDev; } 
            set 
            { 
                if (this._valueVIbsDev == value)return;
                 this._valueVIbsDev = value; 
            } 
        } 

       protected double? _vIbsRetOriginal{get;private set;}
       private double? _vIbsRetOriginalCommited{get; set;}
        private double? _valueVIbsRet;
         [Column("nfo_v_ibs_ret")]
        public virtual double? VIbsRet
         { 
            get { return this._valueVIbsRet; } 
            set 
            { 
                if (this._valueVIbsRet == value)return;
                 this._valueVIbsRet = value; 
            } 
        } 

       protected double? _vCbsCredOriginal{get;private set;}
       private double? _vCbsCredOriginalCommited{get; set;}
        private double? _valueVCbsCred;
         [Column("nfo_v_cbs_cred")]
        public virtual double? VCbsCred
         { 
            get { return this._valueVCbsCred; } 
            set 
            { 
                if (this._valueVCbsCred == value)return;
                 this._valueVCbsCred = value; 
            } 
        } 

       protected double? _vCbsDifOriginal{get;private set;}
       private double? _vCbsDifOriginalCommited{get; set;}
        private double? _valueVCbsDif;
         [Column("nfo_v_cbs_dif")]
        public virtual double? VCbsDif
         { 
            get { return this._valueVCbsDif; } 
            set 
            { 
                if (this._valueVCbsDif == value)return;
                 this._valueVCbsDif = value; 
            } 
        } 

       protected double? _vCbsDevOriginal{get;private set;}
       private double? _vCbsDevOriginalCommited{get; set;}
        private double? _valueVCbsDev;
         [Column("nfo_v_cbs_dev")]
        public virtual double? VCbsDev
         { 
            get { return this._valueVCbsDev; } 
            set 
            { 
                if (this._valueVCbsDev == value)return;
                 this._valueVCbsDev = value; 
            } 
        } 

       protected double? _vCbsRetOriginal{get;private set;}
       private double? _vCbsRetOriginalCommited{get; set;}
        private double? _valueVCbsRet;
         [Column("nfo_v_cbs_ret")]
        public virtual double? VCbsRet
         { 
            get { return this._valueVCbsRet; } 
            set 
            { 
                if (this._valueVCbsRet == value)return;
                 this._valueVCbsRet = value; 
            } 
        } 

       protected double? _vIsDevOriginal{get;private set;}
       private double? _vIsDevOriginalCommited{get; set;}
        private double? _valueVIsDev;
         [Column("nfo_v_is_dev")]
        public virtual double? VIsDev
         { 
            get { return this._valueVIsDev; } 
            set 
            { 
                if (this._valueVIsDev == value)return;
                 this._valueVIsDev = value; 
            } 
        } 

       protected double? _vIsRetOriginal{get;private set;}
       private double? _vIsRetOriginalCommited{get; set;}
        private double? _valueVIsRet;
         [Column("nfo_v_is_ret")]
        public virtual double? VIsRet
         { 
            get { return this._valueVIsRet; } 
            set 
            { 
                if (this._valueVIsRet == value)return;
                 this._valueVIsRet = value; 
            } 
        } 

        public NfTotaisBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ValorTotalIcmsDiferido = 0;
           this.ValorTotalIcmsDesonerado = 0;
           this.TotalIbs = 0;
           this.TotalCbs = 0;
           this.TotalIs = 0;
           this.VIbsCred = 0;
           this.VIbsDif = 0;
           this.VIbsDev = 0;
           this.VIbsRet = 0;
           this.VCbsCred = 0;
           this.VCbsDif = 0;
           this.VCbsDev = 0;
           this.VCbsRet = 0;
           this.VIsDev = 0;
           this.VIsRet = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfTotaisClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfTotaisClass) GetEntity(typeof(NfTotaisClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_totais  " +
                    "WHERE " +
                    "  id_nf_totais = :id";
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
                        "  public.nf_totais   " +
                        "SET  " + 
                        "  id_nf_principal = :id_nf_principal, " + 
                        "  nfo_base_calculo_icms = :nfo_base_calculo_icms, " + 
                        "  nfo_valor_total_icms = :nfo_valor_total_icms, " + 
                        "  nfo_base_calculo_icms_st = :nfo_base_calculo_icms_st, " + 
                        "  nfo_valor_total_icms_st = :nfo_valor_total_icms_st, " + 
                        "  nfo_valor_total_produtos_servicos_icms = :nfo_valor_total_produtos_servicos_icms, " + 
                        "  nfo_valor_total_frete = :nfo_valor_total_frete, " + 
                        "  nfo_valor_total_seguro = :nfo_valor_total_seguro, " + 
                        "  nfo_valor_total_desconto = :nfo_valor_total_desconto, " + 
                        "  nfo_valor_total_desconto_ii = :nfo_valor_total_desconto_ii, " + 
                        "  nfo_valor_total_ipi = :nfo_valor_total_ipi, " + 
                        "  nfo_valor_total_pis = :nfo_valor_total_pis, " + 
                        "  nfo_valor_total_cofins = :nfo_valor_total_cofins, " + 
                        "  nfo_outras_despesas = :nfo_outras_despesas, " + 
                        "  nfo_valor_total_nf = :nfo_valor_total_nf, " + 
                        "  nfo_valor_total_servicos = :nfo_valor_total_servicos, " + 
                        "  nfo_base_calculo_iss = :nfo_base_calculo_iss, " + 
                        "  nfo_valor_total_iss = :nfo_valor_total_iss, " + 
                        "  nfo_valor_total_pis_servicos = :nfo_valor_total_pis_servicos, " + 
                        "  nfo_valor_total_cofins_servicos = :nfo_valor_total_cofins_servicos, " + 
                        "  nfo_valor_total_iimp = :nfo_valor_total_iimp, " + 
                        "  nfo_valor_total_icms_diferido = :nfo_valor_total_icms_diferido, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  nfo_valor_retido_pis = :nfo_valor_retido_pis, " + 
                        "  nfo_valor_retido_cofins = :nfo_valor_retido_cofins, " + 
                        "  nfo_valor_retido_csll = :nfo_valor_retido_csll, " + 
                        "  nfo_valor_retido_bc_irrf = :nfo_valor_retido_bc_irrf, " + 
                        "  nfo_valor_retido_irrf = :nfo_valor_retido_irrf, " + 
                        "  nfo_valor_retido_bc_previdencia = :nfo_valor_retido_bc_previdencia, " + 
                        "  nfo_valor_retido_previencia = :nfo_valor_retido_previencia, " + 
                        "  nfo_valor_total_aproximado_tributos = :nfo_valor_total_aproximado_tributos, " + 
                        "  nfo_valor_total_icms_desonerado = :nfo_valor_total_icms_desonerado, " + 
                        "  nfo_total_ibs = :nfo_total_ibs, " + 
                        "  nfo_total_cbs = :nfo_total_cbs, " + 
                        "  nfo_total_is = :nfo_total_is, " + 
                        "  nfo_v_ibs_cred = :nfo_v_ibs_cred, " + 
                        "  nfo_v_ibs_dif = :nfo_v_ibs_dif, " + 
                        "  nfo_v_ibs_dev = :nfo_v_ibs_dev, " + 
                        "  nfo_v_ibs_ret = :nfo_v_ibs_ret, " + 
                        "  nfo_v_cbs_cred = :nfo_v_cbs_cred, " + 
                        "  nfo_v_cbs_dif = :nfo_v_cbs_dif, " + 
                        "  nfo_v_cbs_dev = :nfo_v_cbs_dev, " + 
                        "  nfo_v_cbs_ret = :nfo_v_cbs_ret, " + 
                        "  nfo_v_is_dev = :nfo_v_is_dev, " + 
                        "  nfo_v_is_ret = :nfo_v_is_ret "+
                        "WHERE  " +
                        "  id_nf_totais = :id " +
                        "RETURNING id_nf_totais;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_totais " +
                        "( " +
                        "  id_nf_principal , " + 
                        "  nfo_base_calculo_icms , " + 
                        "  nfo_valor_total_icms , " + 
                        "  nfo_base_calculo_icms_st , " + 
                        "  nfo_valor_total_icms_st , " + 
                        "  nfo_valor_total_produtos_servicos_icms , " + 
                        "  nfo_valor_total_frete , " + 
                        "  nfo_valor_total_seguro , " + 
                        "  nfo_valor_total_desconto , " + 
                        "  nfo_valor_total_desconto_ii , " + 
                        "  nfo_valor_total_ipi , " + 
                        "  nfo_valor_total_pis , " + 
                        "  nfo_valor_total_cofins , " + 
                        "  nfo_outras_despesas , " + 
                        "  nfo_valor_total_nf , " + 
                        "  nfo_valor_total_servicos , " + 
                        "  nfo_base_calculo_iss , " + 
                        "  nfo_valor_total_iss , " + 
                        "  nfo_valor_total_pis_servicos , " + 
                        "  nfo_valor_total_cofins_servicos , " + 
                        "  nfo_valor_total_iimp , " + 
                        "  nfo_valor_total_icms_diferido , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  nfo_valor_retido_pis , " + 
                        "  nfo_valor_retido_cofins , " + 
                        "  nfo_valor_retido_csll , " + 
                        "  nfo_valor_retido_bc_irrf , " + 
                        "  nfo_valor_retido_irrf , " + 
                        "  nfo_valor_retido_bc_previdencia , " + 
                        "  nfo_valor_retido_previencia , " + 
                        "  nfo_valor_total_aproximado_tributos , " + 
                        "  nfo_valor_total_icms_desonerado , " + 
                        "  nfo_total_ibs , " + 
                        "  nfo_total_cbs , " + 
                        "  nfo_total_is , " + 
                        "  nfo_v_ibs_cred , " + 
                        "  nfo_v_ibs_dif , " + 
                        "  nfo_v_ibs_dev , " + 
                        "  nfo_v_ibs_ret , " + 
                        "  nfo_v_cbs_cred , " + 
                        "  nfo_v_cbs_dif , " + 
                        "  nfo_v_cbs_dev , " + 
                        "  nfo_v_cbs_ret , " + 
                        "  nfo_v_is_dev , " + 
                        "  nfo_v_is_ret  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_principal , " + 
                        "  :nfo_base_calculo_icms , " + 
                        "  :nfo_valor_total_icms , " + 
                        "  :nfo_base_calculo_icms_st , " + 
                        "  :nfo_valor_total_icms_st , " + 
                        "  :nfo_valor_total_produtos_servicos_icms , " + 
                        "  :nfo_valor_total_frete , " + 
                        "  :nfo_valor_total_seguro , " + 
                        "  :nfo_valor_total_desconto , " + 
                        "  :nfo_valor_total_desconto_ii , " + 
                        "  :nfo_valor_total_ipi , " + 
                        "  :nfo_valor_total_pis , " + 
                        "  :nfo_valor_total_cofins , " + 
                        "  :nfo_outras_despesas , " + 
                        "  :nfo_valor_total_nf , " + 
                        "  :nfo_valor_total_servicos , " + 
                        "  :nfo_base_calculo_iss , " + 
                        "  :nfo_valor_total_iss , " + 
                        "  :nfo_valor_total_pis_servicos , " + 
                        "  :nfo_valor_total_cofins_servicos , " + 
                        "  :nfo_valor_total_iimp , " + 
                        "  :nfo_valor_total_icms_diferido , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :nfo_valor_retido_pis , " + 
                        "  :nfo_valor_retido_cofins , " + 
                        "  :nfo_valor_retido_csll , " + 
                        "  :nfo_valor_retido_bc_irrf , " + 
                        "  :nfo_valor_retido_irrf , " + 
                        "  :nfo_valor_retido_bc_previdencia , " + 
                        "  :nfo_valor_retido_previencia , " + 
                        "  :nfo_valor_total_aproximado_tributos , " + 
                        "  :nfo_valor_total_icms_desonerado , " + 
                        "  :nfo_total_ibs , " + 
                        "  :nfo_total_cbs , " + 
                        "  :nfo_total_is , " + 
                        "  :nfo_v_ibs_cred , " + 
                        "  :nfo_v_ibs_dif , " + 
                        "  :nfo_v_ibs_dev , " + 
                        "  :nfo_v_ibs_ret , " + 
                        "  :nfo_v_cbs_cred , " + 
                        "  :nfo_v_cbs_dif , " + 
                        "  :nfo_v_cbs_dev , " + 
                        "  :nfo_v_cbs_ret , " + 
                        "  :nfo_v_is_dev , " + 
                        "  :nfo_v_is_ret  "+
                        ")RETURNING id_nf_totais;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_principal", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfPrincipal==null ? (object) DBNull.Value : this.NfPrincipal.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_base_calculo_icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BaseCalculoIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_base_calculo_icms_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BaseCalculoIcmsSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_icms_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIcmsSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_produtos_servicos_icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalProdutosServicosIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_frete", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalFrete ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_seguro", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalSeguro ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_desconto", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalDesconto ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_desconto_ii", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalDescontoIi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_ipi", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIpi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_pis", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalPis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_cofins", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalCofins ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_outras_despesas", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.OutrasDespesas ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_nf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalNf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_servicos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalServicos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_base_calculo_iss", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.BaseCalculoIss ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_iss", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIss ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_pis_servicos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalPisServicos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_cofins_servicos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalCofinsServicos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_iimp", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIimp ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_icms_diferido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIcmsDiferido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_pis", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoPis ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_cofins", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoCofins ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_csll", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoCsll ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_bc_irrf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoBcIrrf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_irrf", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoIrrf ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_bc_previdencia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoBcPrevidencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_retido_previencia", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorRetidoPreviencia ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_aproximado_tributos", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalAproximadoTributos ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_valor_total_icms_desonerado", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorTotalIcmsDesonerado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_total_ibs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TotalIbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_total_cbs", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TotalCbs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_total_is", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.TotalIs ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_ibs_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_ibs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_ibs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_ibs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_cbs_cred", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsCred ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_cbs_dif", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsDif ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_cbs_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_cbs_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VCbsRet ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_is_dev", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIsDev ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfo_v_is_ret", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.VIsRet ?? DBNull.Value;

 
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
        public static NfTotaisClass CopiarEntidade(NfTotaisClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfTotaisClass toRet = new NfTotaisClass(usuario,conn);
 toRet.NfPrincipal= entidadeCopiar.NfPrincipal;
 toRet.BaseCalculoIcms= entidadeCopiar.BaseCalculoIcms;
 toRet.ValorTotalIcms= entidadeCopiar.ValorTotalIcms;
 toRet.BaseCalculoIcmsSt= entidadeCopiar.BaseCalculoIcmsSt;
 toRet.ValorTotalIcmsSt= entidadeCopiar.ValorTotalIcmsSt;
 toRet.ValorTotalProdutosServicosIcms= entidadeCopiar.ValorTotalProdutosServicosIcms;
 toRet.ValorTotalFrete= entidadeCopiar.ValorTotalFrete;
 toRet.ValorTotalSeguro= entidadeCopiar.ValorTotalSeguro;
 toRet.ValorTotalDesconto= entidadeCopiar.ValorTotalDesconto;
 toRet.ValorTotalDescontoIi= entidadeCopiar.ValorTotalDescontoIi;
 toRet.ValorTotalIpi= entidadeCopiar.ValorTotalIpi;
 toRet.ValorTotalPis= entidadeCopiar.ValorTotalPis;
 toRet.ValorTotalCofins= entidadeCopiar.ValorTotalCofins;
 toRet.OutrasDespesas= entidadeCopiar.OutrasDespesas;
 toRet.ValorTotalNf= entidadeCopiar.ValorTotalNf;
 toRet.ValorTotalServicos= entidadeCopiar.ValorTotalServicos;
 toRet.BaseCalculoIss= entidadeCopiar.BaseCalculoIss;
 toRet.ValorTotalIss= entidadeCopiar.ValorTotalIss;
 toRet.ValorTotalPisServicos= entidadeCopiar.ValorTotalPisServicos;
 toRet.ValorTotalCofinsServicos= entidadeCopiar.ValorTotalCofinsServicos;
 toRet.ValorTotalIimp= entidadeCopiar.ValorTotalIimp;
 toRet.ValorTotalIcmsDiferido= entidadeCopiar.ValorTotalIcmsDiferido;
 toRet.ValorRetidoPis= entidadeCopiar.ValorRetidoPis;
 toRet.ValorRetidoCofins= entidadeCopiar.ValorRetidoCofins;
 toRet.ValorRetidoCsll= entidadeCopiar.ValorRetidoCsll;
 toRet.ValorRetidoBcIrrf= entidadeCopiar.ValorRetidoBcIrrf;
 toRet.ValorRetidoIrrf= entidadeCopiar.ValorRetidoIrrf;
 toRet.ValorRetidoBcPrevidencia= entidadeCopiar.ValorRetidoBcPrevidencia;
 toRet.ValorRetidoPreviencia= entidadeCopiar.ValorRetidoPreviencia;
 toRet.ValorTotalAproximadoTributos= entidadeCopiar.ValorTotalAproximadoTributos;
 toRet.ValorTotalIcmsDesonerado= entidadeCopiar.ValorTotalIcmsDesonerado;
 toRet.TotalIbs= entidadeCopiar.TotalIbs;
 toRet.TotalCbs= entidadeCopiar.TotalCbs;
 toRet.TotalIs= entidadeCopiar.TotalIs;
 toRet.VIbsCred= entidadeCopiar.VIbsCred;
 toRet.VIbsDif= entidadeCopiar.VIbsDif;
 toRet.VIbsDev= entidadeCopiar.VIbsDev;
 toRet.VIbsRet= entidadeCopiar.VIbsRet;
 toRet.VCbsCred= entidadeCopiar.VCbsCred;
 toRet.VCbsDif= entidadeCopiar.VCbsDif;
 toRet.VCbsDev= entidadeCopiar.VCbsDev;
 toRet.VCbsRet= entidadeCopiar.VCbsRet;
 toRet.VIsDev= entidadeCopiar.VIsDev;
 toRet.VIsRet= entidadeCopiar.VIsRet;

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
       _baseCalculoIcmsOriginal = BaseCalculoIcms;
       _baseCalculoIcmsOriginalCommited = _baseCalculoIcmsOriginal;
       _valorTotalIcmsOriginal = ValorTotalIcms;
       _valorTotalIcmsOriginalCommited = _valorTotalIcmsOriginal;
       _baseCalculoIcmsStOriginal = BaseCalculoIcmsSt;
       _baseCalculoIcmsStOriginalCommited = _baseCalculoIcmsStOriginal;
       _valorTotalIcmsStOriginal = ValorTotalIcmsSt;
       _valorTotalIcmsStOriginalCommited = _valorTotalIcmsStOriginal;
       _valorTotalProdutosServicosIcmsOriginal = ValorTotalProdutosServicosIcms;
       _valorTotalProdutosServicosIcmsOriginalCommited = _valorTotalProdutosServicosIcmsOriginal;
       _valorTotalFreteOriginal = ValorTotalFrete;
       _valorTotalFreteOriginalCommited = _valorTotalFreteOriginal;
       _valorTotalSeguroOriginal = ValorTotalSeguro;
       _valorTotalSeguroOriginalCommited = _valorTotalSeguroOriginal;
       _valorTotalDescontoOriginal = ValorTotalDesconto;
       _valorTotalDescontoOriginalCommited = _valorTotalDescontoOriginal;
       _valorTotalDescontoIiOriginal = ValorTotalDescontoIi;
       _valorTotalDescontoIiOriginalCommited = _valorTotalDescontoIiOriginal;
       _valorTotalIpiOriginal = ValorTotalIpi;
       _valorTotalIpiOriginalCommited = _valorTotalIpiOriginal;
       _valorTotalPisOriginal = ValorTotalPis;
       _valorTotalPisOriginalCommited = _valorTotalPisOriginal;
       _valorTotalCofinsOriginal = ValorTotalCofins;
       _valorTotalCofinsOriginalCommited = _valorTotalCofinsOriginal;
       _outrasDespesasOriginal = OutrasDespesas;
       _outrasDespesasOriginalCommited = _outrasDespesasOriginal;
       _valorTotalNfOriginal = ValorTotalNf;
       _valorTotalNfOriginalCommited = _valorTotalNfOriginal;
       _valorTotalServicosOriginal = ValorTotalServicos;
       _valorTotalServicosOriginalCommited = _valorTotalServicosOriginal;
       _baseCalculoIssOriginal = BaseCalculoIss;
       _baseCalculoIssOriginalCommited = _baseCalculoIssOriginal;
       _valorTotalIssOriginal = ValorTotalIss;
       _valorTotalIssOriginalCommited = _valorTotalIssOriginal;
       _valorTotalPisServicosOriginal = ValorTotalPisServicos;
       _valorTotalPisServicosOriginalCommited = _valorTotalPisServicosOriginal;
       _valorTotalCofinsServicosOriginal = ValorTotalCofinsServicos;
       _valorTotalCofinsServicosOriginalCommited = _valorTotalCofinsServicosOriginal;
       _valorTotalIimpOriginal = ValorTotalIimp;
       _valorTotalIimpOriginalCommited = _valorTotalIimpOriginal;
       _valorTotalIcmsDiferidoOriginal = ValorTotalIcmsDiferido;
       _valorTotalIcmsDiferidoOriginalCommited = _valorTotalIcmsDiferidoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _valorRetidoPisOriginal = ValorRetidoPis;
       _valorRetidoPisOriginalCommited = _valorRetidoPisOriginal;
       _valorRetidoCofinsOriginal = ValorRetidoCofins;
       _valorRetidoCofinsOriginalCommited = _valorRetidoCofinsOriginal;
       _valorRetidoCsllOriginal = ValorRetidoCsll;
       _valorRetidoCsllOriginalCommited = _valorRetidoCsllOriginal;
       _valorRetidoBcIrrfOriginal = ValorRetidoBcIrrf;
       _valorRetidoBcIrrfOriginalCommited = _valorRetidoBcIrrfOriginal;
       _valorRetidoIrrfOriginal = ValorRetidoIrrf;
       _valorRetidoIrrfOriginalCommited = _valorRetidoIrrfOriginal;
       _valorRetidoBcPrevidenciaOriginal = ValorRetidoBcPrevidencia;
       _valorRetidoBcPrevidenciaOriginalCommited = _valorRetidoBcPrevidenciaOriginal;
       _valorRetidoPrevienciaOriginal = ValorRetidoPreviencia;
       _valorRetidoPrevienciaOriginalCommited = _valorRetidoPrevienciaOriginal;
       _valorTotalAproximadoTributosOriginal = ValorTotalAproximadoTributos;
       _valorTotalAproximadoTributosOriginalCommited = _valorTotalAproximadoTributosOriginal;
       _valorTotalIcmsDesoneradoOriginal = ValorTotalIcmsDesonerado;
       _valorTotalIcmsDesoneradoOriginalCommited = _valorTotalIcmsDesoneradoOriginal;
       _totalIbsOriginal = TotalIbs;
       _totalIbsOriginalCommited = _totalIbsOriginal;
       _totalCbsOriginal = TotalCbs;
       _totalCbsOriginalCommited = _totalCbsOriginal;
       _totalIsOriginal = TotalIs;
       _totalIsOriginalCommited = _totalIsOriginal;
       _vIbsCredOriginal = VIbsCred;
       _vIbsCredOriginalCommited = _vIbsCredOriginal;
       _vIbsDifOriginal = VIbsDif;
       _vIbsDifOriginalCommited = _vIbsDifOriginal;
       _vIbsDevOriginal = VIbsDev;
       _vIbsDevOriginalCommited = _vIbsDevOriginal;
       _vIbsRetOriginal = VIbsRet;
       _vIbsRetOriginalCommited = _vIbsRetOriginal;
       _vCbsCredOriginal = VCbsCred;
       _vCbsCredOriginalCommited = _vCbsCredOriginal;
       _vCbsDifOriginal = VCbsDif;
       _vCbsDifOriginalCommited = _vCbsDifOriginal;
       _vCbsDevOriginal = VCbsDev;
       _vCbsDevOriginalCommited = _vCbsDevOriginal;
       _vCbsRetOriginal = VCbsRet;
       _vCbsRetOriginalCommited = _vCbsRetOriginal;
       _vIsDevOriginal = VIsDev;
       _vIsDevOriginalCommited = _vIsDevOriginal;
       _vIsRetOriginal = VIsRet;
       _vIsRetOriginalCommited = _vIsRetOriginal;

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
       _baseCalculoIcmsOriginalCommited = BaseCalculoIcms;
       _valorTotalIcmsOriginalCommited = ValorTotalIcms;
       _baseCalculoIcmsStOriginalCommited = BaseCalculoIcmsSt;
       _valorTotalIcmsStOriginalCommited = ValorTotalIcmsSt;
       _valorTotalProdutosServicosIcmsOriginalCommited = ValorTotalProdutosServicosIcms;
       _valorTotalFreteOriginalCommited = ValorTotalFrete;
       _valorTotalSeguroOriginalCommited = ValorTotalSeguro;
       _valorTotalDescontoOriginalCommited = ValorTotalDesconto;
       _valorTotalDescontoIiOriginalCommited = ValorTotalDescontoIi;
       _valorTotalIpiOriginalCommited = ValorTotalIpi;
       _valorTotalPisOriginalCommited = ValorTotalPis;
       _valorTotalCofinsOriginalCommited = ValorTotalCofins;
       _outrasDespesasOriginalCommited = OutrasDespesas;
       _valorTotalNfOriginalCommited = ValorTotalNf;
       _valorTotalServicosOriginalCommited = ValorTotalServicos;
       _baseCalculoIssOriginalCommited = BaseCalculoIss;
       _valorTotalIssOriginalCommited = ValorTotalIss;
       _valorTotalPisServicosOriginalCommited = ValorTotalPisServicos;
       _valorTotalCofinsServicosOriginalCommited = ValorTotalCofinsServicos;
       _valorTotalIimpOriginalCommited = ValorTotalIimp;
       _valorTotalIcmsDiferidoOriginalCommited = ValorTotalIcmsDiferido;
       _versionOriginalCommited = Version;
       _valorRetidoPisOriginalCommited = ValorRetidoPis;
       _valorRetidoCofinsOriginalCommited = ValorRetidoCofins;
       _valorRetidoCsllOriginalCommited = ValorRetidoCsll;
       _valorRetidoBcIrrfOriginalCommited = ValorRetidoBcIrrf;
       _valorRetidoIrrfOriginalCommited = ValorRetidoIrrf;
       _valorRetidoBcPrevidenciaOriginalCommited = ValorRetidoBcPrevidencia;
       _valorRetidoPrevienciaOriginalCommited = ValorRetidoPreviencia;
       _valorTotalAproximadoTributosOriginalCommited = ValorTotalAproximadoTributos;
       _valorTotalIcmsDesoneradoOriginalCommited = ValorTotalIcmsDesonerado;
       _totalIbsOriginalCommited = TotalIbs;
       _totalCbsOriginalCommited = TotalCbs;
       _totalIsOriginalCommited = TotalIs;
       _vIbsCredOriginalCommited = VIbsCred;
       _vIbsDifOriginalCommited = VIbsDif;
       _vIbsDevOriginalCommited = VIbsDev;
       _vIbsRetOriginalCommited = VIbsRet;
       _vCbsCredOriginalCommited = VCbsCred;
       _vCbsDifOriginalCommited = VCbsDif;
       _vCbsDevOriginalCommited = VCbsDev;
       _vCbsRetOriginalCommited = VCbsRet;
       _vIsDevOriginalCommited = VIsDev;
       _vIsRetOriginalCommited = VIsRet;

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
               BaseCalculoIcms=_baseCalculoIcmsOriginal;
               _baseCalculoIcmsOriginalCommited=_baseCalculoIcmsOriginal;
               ValorTotalIcms=_valorTotalIcmsOriginal;
               _valorTotalIcmsOriginalCommited=_valorTotalIcmsOriginal;
               BaseCalculoIcmsSt=_baseCalculoIcmsStOriginal;
               _baseCalculoIcmsStOriginalCommited=_baseCalculoIcmsStOriginal;
               ValorTotalIcmsSt=_valorTotalIcmsStOriginal;
               _valorTotalIcmsStOriginalCommited=_valorTotalIcmsStOriginal;
               ValorTotalProdutosServicosIcms=_valorTotalProdutosServicosIcmsOriginal;
               _valorTotalProdutosServicosIcmsOriginalCommited=_valorTotalProdutosServicosIcmsOriginal;
               ValorTotalFrete=_valorTotalFreteOriginal;
               _valorTotalFreteOriginalCommited=_valorTotalFreteOriginal;
               ValorTotalSeguro=_valorTotalSeguroOriginal;
               _valorTotalSeguroOriginalCommited=_valorTotalSeguroOriginal;
               ValorTotalDesconto=_valorTotalDescontoOriginal;
               _valorTotalDescontoOriginalCommited=_valorTotalDescontoOriginal;
               ValorTotalDescontoIi=_valorTotalDescontoIiOriginal;
               _valorTotalDescontoIiOriginalCommited=_valorTotalDescontoIiOriginal;
               ValorTotalIpi=_valorTotalIpiOriginal;
               _valorTotalIpiOriginalCommited=_valorTotalIpiOriginal;
               ValorTotalPis=_valorTotalPisOriginal;
               _valorTotalPisOriginalCommited=_valorTotalPisOriginal;
               ValorTotalCofins=_valorTotalCofinsOriginal;
               _valorTotalCofinsOriginalCommited=_valorTotalCofinsOriginal;
               OutrasDespesas=_outrasDespesasOriginal;
               _outrasDespesasOriginalCommited=_outrasDespesasOriginal;
               ValorTotalNf=_valorTotalNfOriginal;
               _valorTotalNfOriginalCommited=_valorTotalNfOriginal;
               ValorTotalServicos=_valorTotalServicosOriginal;
               _valorTotalServicosOriginalCommited=_valorTotalServicosOriginal;
               BaseCalculoIss=_baseCalculoIssOriginal;
               _baseCalculoIssOriginalCommited=_baseCalculoIssOriginal;
               ValorTotalIss=_valorTotalIssOriginal;
               _valorTotalIssOriginalCommited=_valorTotalIssOriginal;
               ValorTotalPisServicos=_valorTotalPisServicosOriginal;
               _valorTotalPisServicosOriginalCommited=_valorTotalPisServicosOriginal;
               ValorTotalCofinsServicos=_valorTotalCofinsServicosOriginal;
               _valorTotalCofinsServicosOriginalCommited=_valorTotalCofinsServicosOriginal;
               ValorTotalIimp=_valorTotalIimpOriginal;
               _valorTotalIimpOriginalCommited=_valorTotalIimpOriginal;
               ValorTotalIcmsDiferido=_valorTotalIcmsDiferidoOriginal;
               _valorTotalIcmsDiferidoOriginalCommited=_valorTotalIcmsDiferidoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ValorRetidoPis=_valorRetidoPisOriginal;
               _valorRetidoPisOriginalCommited=_valorRetidoPisOriginal;
               ValorRetidoCofins=_valorRetidoCofinsOriginal;
               _valorRetidoCofinsOriginalCommited=_valorRetidoCofinsOriginal;
               ValorRetidoCsll=_valorRetidoCsllOriginal;
               _valorRetidoCsllOriginalCommited=_valorRetidoCsllOriginal;
               ValorRetidoBcIrrf=_valorRetidoBcIrrfOriginal;
               _valorRetidoBcIrrfOriginalCommited=_valorRetidoBcIrrfOriginal;
               ValorRetidoIrrf=_valorRetidoIrrfOriginal;
               _valorRetidoIrrfOriginalCommited=_valorRetidoIrrfOriginal;
               ValorRetidoBcPrevidencia=_valorRetidoBcPrevidenciaOriginal;
               _valorRetidoBcPrevidenciaOriginalCommited=_valorRetidoBcPrevidenciaOriginal;
               ValorRetidoPreviencia=_valorRetidoPrevienciaOriginal;
               _valorRetidoPrevienciaOriginalCommited=_valorRetidoPrevienciaOriginal;
               ValorTotalAproximadoTributos=_valorTotalAproximadoTributosOriginal;
               _valorTotalAproximadoTributosOriginalCommited=_valorTotalAproximadoTributosOriginal;
               ValorTotalIcmsDesonerado=_valorTotalIcmsDesoneradoOriginal;
               _valorTotalIcmsDesoneradoOriginalCommited=_valorTotalIcmsDesoneradoOriginal;
               TotalIbs=_totalIbsOriginal;
               _totalIbsOriginalCommited=_totalIbsOriginal;
               TotalCbs=_totalCbsOriginal;
               _totalCbsOriginalCommited=_totalCbsOriginal;
               TotalIs=_totalIsOriginal;
               _totalIsOriginalCommited=_totalIsOriginal;
               VIbsCred=_vIbsCredOriginal;
               _vIbsCredOriginalCommited=_vIbsCredOriginal;
               VIbsDif=_vIbsDifOriginal;
               _vIbsDifOriginalCommited=_vIbsDifOriginal;
               VIbsDev=_vIbsDevOriginal;
               _vIbsDevOriginalCommited=_vIbsDevOriginal;
               VIbsRet=_vIbsRetOriginal;
               _vIbsRetOriginalCommited=_vIbsRetOriginal;
               VCbsCred=_vCbsCredOriginal;
               _vCbsCredOriginalCommited=_vCbsCredOriginal;
               VCbsDif=_vCbsDifOriginal;
               _vCbsDifOriginalCommited=_vCbsDifOriginal;
               VCbsDev=_vCbsDevOriginal;
               _vCbsDevOriginalCommited=_vCbsDevOriginal;
               VCbsRet=_vCbsRetOriginal;
               _vCbsRetOriginalCommited=_vCbsRetOriginal;
               VIsDev=_vIsDevOriginal;
               _vIsDevOriginalCommited=_vIsDevOriginal;
               VIsRet=_vIsRetOriginal;
               _vIsRetOriginalCommited=_vIsRetOriginal;

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
       dirty = _baseCalculoIcmsOriginal != BaseCalculoIcms;
      if (dirty) return true;
       dirty = _valorTotalIcmsOriginal != ValorTotalIcms;
      if (dirty) return true;
       dirty = _baseCalculoIcmsStOriginal != BaseCalculoIcmsSt;
      if (dirty) return true;
       dirty = _valorTotalIcmsStOriginal != ValorTotalIcmsSt;
      if (dirty) return true;
       dirty = _valorTotalProdutosServicosIcmsOriginal != ValorTotalProdutosServicosIcms;
      if (dirty) return true;
       dirty = _valorTotalFreteOriginal != ValorTotalFrete;
      if (dirty) return true;
       dirty = _valorTotalSeguroOriginal != ValorTotalSeguro;
      if (dirty) return true;
       dirty = _valorTotalDescontoOriginal != ValorTotalDesconto;
      if (dirty) return true;
       dirty = _valorTotalDescontoIiOriginal != ValorTotalDescontoIi;
      if (dirty) return true;
       dirty = _valorTotalIpiOriginal != ValorTotalIpi;
      if (dirty) return true;
       dirty = _valorTotalPisOriginal != ValorTotalPis;
      if (dirty) return true;
       dirty = _valorTotalCofinsOriginal != ValorTotalCofins;
      if (dirty) return true;
       dirty = _outrasDespesasOriginal != OutrasDespesas;
      if (dirty) return true;
       dirty = _valorTotalNfOriginal != ValorTotalNf;
      if (dirty) return true;
       dirty = _valorTotalServicosOriginal != ValorTotalServicos;
      if (dirty) return true;
       dirty = _baseCalculoIssOriginal != BaseCalculoIss;
      if (dirty) return true;
       dirty = _valorTotalIssOriginal != ValorTotalIss;
      if (dirty) return true;
       dirty = _valorTotalPisServicosOriginal != ValorTotalPisServicos;
      if (dirty) return true;
       dirty = _valorTotalCofinsServicosOriginal != ValorTotalCofinsServicos;
      if (dirty) return true;
       dirty = _valorTotalIimpOriginal != ValorTotalIimp;
      if (dirty) return true;
       dirty = _valorTotalIcmsDiferidoOriginal != ValorTotalIcmsDiferido;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _valorRetidoPisOriginal != ValorRetidoPis;
      if (dirty) return true;
       dirty = _valorRetidoCofinsOriginal != ValorRetidoCofins;
      if (dirty) return true;
       dirty = _valorRetidoCsllOriginal != ValorRetidoCsll;
      if (dirty) return true;
       dirty = _valorRetidoBcIrrfOriginal != ValorRetidoBcIrrf;
      if (dirty) return true;
       dirty = _valorRetidoIrrfOriginal != ValorRetidoIrrf;
      if (dirty) return true;
       dirty = _valorRetidoBcPrevidenciaOriginal != ValorRetidoBcPrevidencia;
      if (dirty) return true;
       dirty = _valorRetidoPrevienciaOriginal != ValorRetidoPreviencia;
      if (dirty) return true;
       dirty = _valorTotalAproximadoTributosOriginal != ValorTotalAproximadoTributos;
      if (dirty) return true;
       dirty = _valorTotalIcmsDesoneradoOriginal != ValorTotalIcmsDesonerado;
      if (dirty) return true;
       dirty = _totalIbsOriginal != TotalIbs;
      if (dirty) return true;
       dirty = _totalCbsOriginal != TotalCbs;
      if (dirty) return true;
       dirty = _totalIsOriginal != TotalIs;
      if (dirty) return true;
       dirty = _vIbsCredOriginal != VIbsCred;
      if (dirty) return true;
       dirty = _vIbsDifOriginal != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginal != VIbsDev;
      if (dirty) return true;
       dirty = _vIbsRetOriginal != VIbsRet;
      if (dirty) return true;
       dirty = _vCbsCredOriginal != VCbsCred;
      if (dirty) return true;
       dirty = _vCbsDifOriginal != VCbsDif;
      if (dirty) return true;
       dirty = _vCbsDevOriginal != VCbsDev;
      if (dirty) return true;
       dirty = _vCbsRetOriginal != VCbsRet;
      if (dirty) return true;
       dirty = _vIsDevOriginal != VIsDev;
      if (dirty) return true;
       dirty = _vIsRetOriginal != VIsRet;

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
       dirty = _baseCalculoIcmsOriginalCommited != BaseCalculoIcms;
      if (dirty) return true;
       dirty = _valorTotalIcmsOriginalCommited != ValorTotalIcms;
      if (dirty) return true;
       dirty = _baseCalculoIcmsStOriginalCommited != BaseCalculoIcmsSt;
      if (dirty) return true;
       dirty = _valorTotalIcmsStOriginalCommited != ValorTotalIcmsSt;
      if (dirty) return true;
       dirty = _valorTotalProdutosServicosIcmsOriginalCommited != ValorTotalProdutosServicosIcms;
      if (dirty) return true;
       dirty = _valorTotalFreteOriginalCommited != ValorTotalFrete;
      if (dirty) return true;
       dirty = _valorTotalSeguroOriginalCommited != ValorTotalSeguro;
      if (dirty) return true;
       dirty = _valorTotalDescontoOriginalCommited != ValorTotalDesconto;
      if (dirty) return true;
       dirty = _valorTotalDescontoIiOriginalCommited != ValorTotalDescontoIi;
      if (dirty) return true;
       dirty = _valorTotalIpiOriginalCommited != ValorTotalIpi;
      if (dirty) return true;
       dirty = _valorTotalPisOriginalCommited != ValorTotalPis;
      if (dirty) return true;
       dirty = _valorTotalCofinsOriginalCommited != ValorTotalCofins;
      if (dirty) return true;
       dirty = _outrasDespesasOriginalCommited != OutrasDespesas;
      if (dirty) return true;
       dirty = _valorTotalNfOriginalCommited != ValorTotalNf;
      if (dirty) return true;
       dirty = _valorTotalServicosOriginalCommited != ValorTotalServicos;
      if (dirty) return true;
       dirty = _baseCalculoIssOriginalCommited != BaseCalculoIss;
      if (dirty) return true;
       dirty = _valorTotalIssOriginalCommited != ValorTotalIss;
      if (dirty) return true;
       dirty = _valorTotalPisServicosOriginalCommited != ValorTotalPisServicos;
      if (dirty) return true;
       dirty = _valorTotalCofinsServicosOriginalCommited != ValorTotalCofinsServicos;
      if (dirty) return true;
       dirty = _valorTotalIimpOriginalCommited != ValorTotalIimp;
      if (dirty) return true;
       dirty = _valorTotalIcmsDiferidoOriginalCommited != ValorTotalIcmsDiferido;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _valorRetidoPisOriginalCommited != ValorRetidoPis;
      if (dirty) return true;
       dirty = _valorRetidoCofinsOriginalCommited != ValorRetidoCofins;
      if (dirty) return true;
       dirty = _valorRetidoCsllOriginalCommited != ValorRetidoCsll;
      if (dirty) return true;
       dirty = _valorRetidoBcIrrfOriginalCommited != ValorRetidoBcIrrf;
      if (dirty) return true;
       dirty = _valorRetidoIrrfOriginalCommited != ValorRetidoIrrf;
      if (dirty) return true;
       dirty = _valorRetidoBcPrevidenciaOriginalCommited != ValorRetidoBcPrevidencia;
      if (dirty) return true;
       dirty = _valorRetidoPrevienciaOriginalCommited != ValorRetidoPreviencia;
      if (dirty) return true;
       dirty = _valorTotalAproximadoTributosOriginalCommited != ValorTotalAproximadoTributos;
      if (dirty) return true;
       dirty = _valorTotalIcmsDesoneradoOriginalCommited != ValorTotalIcmsDesonerado;
      if (dirty) return true;
       dirty = _totalIbsOriginalCommited != TotalIbs;
      if (dirty) return true;
       dirty = _totalCbsOriginalCommited != TotalCbs;
      if (dirty) return true;
       dirty = _totalIsOriginalCommited != TotalIs;
      if (dirty) return true;
       dirty = _vIbsCredOriginalCommited != VIbsCred;
      if (dirty) return true;
       dirty = _vIbsDifOriginalCommited != VIbsDif;
      if (dirty) return true;
       dirty = _vIbsDevOriginalCommited != VIbsDev;
      if (dirty) return true;
       dirty = _vIbsRetOriginalCommited != VIbsRet;
      if (dirty) return true;
       dirty = _vCbsCredOriginalCommited != VCbsCred;
      if (dirty) return true;
       dirty = _vCbsDifOriginalCommited != VCbsDif;
      if (dirty) return true;
       dirty = _vCbsDevOriginalCommited != VCbsDev;
      if (dirty) return true;
       dirty = _vCbsRetOriginalCommited != VCbsRet;
      if (dirty) return true;
       dirty = _vIsDevOriginalCommited != VIsDev;
      if (dirty) return true;
       dirty = _vIsRetOriginalCommited != VIsRet;

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
             case "BaseCalculoIcms":
                return this.BaseCalculoIcms;
             case "ValorTotalIcms":
                return this.ValorTotalIcms;
             case "BaseCalculoIcmsSt":
                return this.BaseCalculoIcmsSt;
             case "ValorTotalIcmsSt":
                return this.ValorTotalIcmsSt;
             case "ValorTotalProdutosServicosIcms":
                return this.ValorTotalProdutosServicosIcms;
             case "ValorTotalFrete":
                return this.ValorTotalFrete;
             case "ValorTotalSeguro":
                return this.ValorTotalSeguro;
             case "ValorTotalDesconto":
                return this.ValorTotalDesconto;
             case "ValorTotalDescontoIi":
                return this.ValorTotalDescontoIi;
             case "ValorTotalIpi":
                return this.ValorTotalIpi;
             case "ValorTotalPis":
                return this.ValorTotalPis;
             case "ValorTotalCofins":
                return this.ValorTotalCofins;
             case "OutrasDespesas":
                return this.OutrasDespesas;
             case "ValorTotalNf":
                return this.ValorTotalNf;
             case "ValorTotalServicos":
                return this.ValorTotalServicos;
             case "BaseCalculoIss":
                return this.BaseCalculoIss;
             case "ValorTotalIss":
                return this.ValorTotalIss;
             case "ValorTotalPisServicos":
                return this.ValorTotalPisServicos;
             case "ValorTotalCofinsServicos":
                return this.ValorTotalCofinsServicos;
             case "ValorTotalIimp":
                return this.ValorTotalIimp;
             case "ValorTotalIcmsDiferido":
                return this.ValorTotalIcmsDiferido;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ValorRetidoPis":
                return this.ValorRetidoPis;
             case "ValorRetidoCofins":
                return this.ValorRetidoCofins;
             case "ValorRetidoCsll":
                return this.ValorRetidoCsll;
             case "ValorRetidoBcIrrf":
                return this.ValorRetidoBcIrrf;
             case "ValorRetidoIrrf":
                return this.ValorRetidoIrrf;
             case "ValorRetidoBcPrevidencia":
                return this.ValorRetidoBcPrevidencia;
             case "ValorRetidoPreviencia":
                return this.ValorRetidoPreviencia;
             case "ValorTotalAproximadoTributos":
                return this.ValorTotalAproximadoTributos;
             case "ValorTotalIcmsDesonerado":
                return this.ValorTotalIcmsDesonerado;
             case "TotalIbs":
                return this.TotalIbs;
             case "TotalCbs":
                return this.TotalCbs;
             case "TotalIs":
                return this.TotalIs;
             case "VIbsCred":
                return this.VIbsCred;
             case "VIbsDif":
                return this.VIbsDif;
             case "VIbsDev":
                return this.VIbsDev;
             case "VIbsRet":
                return this.VIbsRet;
             case "VCbsCred":
                return this.VCbsCred;
             case "VCbsDif":
                return this.VCbsDif;
             case "VCbsDev":
                return this.VCbsDev;
             case "VCbsRet":
                return this.VCbsRet;
             case "VIsDev":
                return this.VIsDev;
             case "VIsRet":
                return this.VIsRet;
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
                  command.CommandText += " COUNT(nf_totais.id_nf_totais) " ;
               }
               else
               {
               command.CommandText += "nf_totais.id_nf_principal, " ;
               command.CommandText += "nf_totais.nfo_base_calculo_icms, " ;
               command.CommandText += "nf_totais.nfo_valor_total_icms, " ;
               command.CommandText += "nf_totais.nfo_base_calculo_icms_st, " ;
               command.CommandText += "nf_totais.nfo_valor_total_icms_st, " ;
               command.CommandText += "nf_totais.nfo_valor_total_produtos_servicos_icms, " ;
               command.CommandText += "nf_totais.nfo_valor_total_frete, " ;
               command.CommandText += "nf_totais.nfo_valor_total_seguro, " ;
               command.CommandText += "nf_totais.nfo_valor_total_desconto, " ;
               command.CommandText += "nf_totais.nfo_valor_total_desconto_ii, " ;
               command.CommandText += "nf_totais.nfo_valor_total_ipi, " ;
               command.CommandText += "nf_totais.nfo_valor_total_pis, " ;
               command.CommandText += "nf_totais.nfo_valor_total_cofins, " ;
               command.CommandText += "nf_totais.nfo_outras_despesas, " ;
               command.CommandText += "nf_totais.nfo_valor_total_nf, " ;
               command.CommandText += "nf_totais.nfo_valor_total_servicos, " ;
               command.CommandText += "nf_totais.nfo_base_calculo_iss, " ;
               command.CommandText += "nf_totais.nfo_valor_total_iss, " ;
               command.CommandText += "nf_totais.nfo_valor_total_pis_servicos, " ;
               command.CommandText += "nf_totais.nfo_valor_total_cofins_servicos, " ;
               command.CommandText += "nf_totais.nfo_valor_total_iimp, " ;
               command.CommandText += "nf_totais.nfo_valor_total_icms_diferido, " ;
               command.CommandText += "nf_totais.entity_uid, " ;
               command.CommandText += "nf_totais.version, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_pis, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_cofins, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_csll, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_bc_irrf, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_irrf, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_bc_previdencia, " ;
               command.CommandText += "nf_totais.nfo_valor_retido_previencia, " ;
               command.CommandText += "nf_totais.id_nf_totais, " ;
               command.CommandText += "nf_totais.nfo_valor_total_aproximado_tributos, " ;
               command.CommandText += "nf_totais.nfo_valor_total_icms_desonerado, " ;
               command.CommandText += "nf_totais.nfo_total_ibs, " ;
               command.CommandText += "nf_totais.nfo_total_cbs, " ;
               command.CommandText += "nf_totais.nfo_total_is, " ;
               command.CommandText += "nf_totais.nfo_v_ibs_cred, " ;
               command.CommandText += "nf_totais.nfo_v_ibs_dif, " ;
               command.CommandText += "nf_totais.nfo_v_ibs_dev, " ;
               command.CommandText += "nf_totais.nfo_v_ibs_ret, " ;
               command.CommandText += "nf_totais.nfo_v_cbs_cred, " ;
               command.CommandText += "nf_totais.nfo_v_cbs_dif, " ;
               command.CommandText += "nf_totais.nfo_v_cbs_dev, " ;
               command.CommandText += "nf_totais.nfo_v_cbs_ret, " ;
               command.CommandText += "nf_totais.nfo_v_is_dev, " ;
               command.CommandText += "nf_totais.nfo_v_is_ret " ;
               }
               command.CommandText += " FROM  nf_totais ";
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
                        orderByClause += " , nfo_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(nfo_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_totais.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_principal":
                     case "NfPrincipal":
                     command.CommandText += " LEFT JOIN nf_principal as nf_principal_NfPrincipal ON nf_principal_NfPrincipal.id_nf_principal = nf_totais.id_nf_principal ";                     switch (parametro.TipoOrdenacao)
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
                     case "nfo_base_calculo_icms":
                     case "BaseCalculoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_base_calculo_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_base_calculo_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_icms":
                     case "ValorTotalIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_base_calculo_icms_st":
                     case "BaseCalculoIcmsSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_base_calculo_icms_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_base_calculo_icms_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_icms_st":
                     case "ValorTotalIcmsSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_icms_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_icms_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_produtos_servicos_icms":
                     case "ValorTotalProdutosServicosIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_produtos_servicos_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_produtos_servicos_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_frete":
                     case "ValorTotalFrete":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_frete " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_frete) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_seguro":
                     case "ValorTotalSeguro":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_seguro " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_seguro) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_desconto":
                     case "ValorTotalDesconto":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_desconto " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_desconto) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_desconto_ii":
                     case "ValorTotalDescontoIi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_desconto_ii " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_desconto_ii) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_ipi":
                     case "ValorTotalIpi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_pis":
                     case "ValorTotalPis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_cofins":
                     case "ValorTotalCofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_outras_despesas":
                     case "OutrasDespesas":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_outras_despesas " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_outras_despesas) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_nf":
                     case "ValorTotalNf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_nf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_nf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_servicos":
                     case "ValorTotalServicos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_servicos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_servicos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_base_calculo_iss":
                     case "BaseCalculoIss":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_base_calculo_iss " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_base_calculo_iss) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_iss":
                     case "ValorTotalIss":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_iss " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_iss) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_pis_servicos":
                     case "ValorTotalPisServicos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_pis_servicos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_pis_servicos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_cofins_servicos":
                     case "ValorTotalCofinsServicos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_cofins_servicos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_cofins_servicos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_iimp":
                     case "ValorTotalIimp":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_iimp " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_iimp) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_icms_diferido":
                     case "ValorTotalIcmsDiferido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_icms_diferido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_icms_diferido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_totais.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_totais.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_totais.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_pis":
                     case "ValorRetidoPis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_cofins":
                     case "ValorRetidoCofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_csll":
                     case "ValorRetidoCsll":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_csll " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_csll) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_bc_irrf":
                     case "ValorRetidoBcIrrf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_bc_irrf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_bc_irrf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_irrf":
                     case "ValorRetidoIrrf":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_irrf " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_irrf) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_bc_previdencia":
                     case "ValorRetidoBcPrevidencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_bc_previdencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_bc_previdencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_retido_previencia":
                     case "ValorRetidoPreviencia":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_retido_previencia " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_retido_previencia) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_totais":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.id_nf_totais " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.id_nf_totais) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_aproximado_tributos":
                     case "ValorTotalAproximadoTributos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_aproximado_tributos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_aproximado_tributos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_valor_total_icms_desonerado":
                     case "ValorTotalIcmsDesonerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_valor_total_icms_desonerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_valor_total_icms_desonerado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_total_ibs":
                     case "TotalIbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_total_ibs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_total_ibs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_total_cbs":
                     case "TotalCbs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_total_cbs " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_total_cbs) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_total_is":
                     case "TotalIs":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_total_is " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_total_is) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_ibs_cred":
                     case "VIbsCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_ibs_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_ibs_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_ibs_dif":
                     case "VIbsDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_ibs_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_ibs_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_ibs_dev":
                     case "VIbsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_ibs_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_ibs_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_ibs_ret":
                     case "VIbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_ibs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_ibs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_cbs_cred":
                     case "VCbsCred":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_cbs_cred " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_cbs_cred) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_cbs_dif":
                     case "VCbsDif":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_cbs_dif " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_cbs_dif) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_cbs_dev":
                     case "VCbsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_cbs_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_cbs_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_cbs_ret":
                     case "VCbsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_cbs_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_cbs_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_is_dev":
                     case "VIsDev":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_is_dev " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_is_dev) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfo_v_is_ret":
                     case "VIsRet":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_totais.nfo_v_is_ret " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_totais.nfo_v_is_ret) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           whereClause += " OR UPPER(nf_totais.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_totais.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
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
                         whereClause += "  nf_totais.id_nf_principal IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.id_nf_principal = :nf_totais_NfPrincipal_73 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_NfPrincipal_73", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BaseCalculoIcms" || parametro.FieldName == "nfo_base_calculo_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_icms = :nf_totais_BaseCalculoIcms_380 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_BaseCalculoIcms_380", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIcms" || parametro.FieldName == "nfo_valor_total_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms = :nf_totais_ValorTotalIcms_3858 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIcms_3858", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BaseCalculoIcmsSt" || parametro.FieldName == "nfo_base_calculo_icms_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_icms_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_icms_st = :nf_totais_BaseCalculoIcmsSt_4568 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_BaseCalculoIcmsSt_4568", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIcmsSt" || parametro.FieldName == "nfo_valor_total_icms_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_st = :nf_totais_ValorTotalIcmsSt_3310 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIcmsSt_3310", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalProdutosServicosIcms" || parametro.FieldName == "nfo_valor_total_produtos_servicos_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_produtos_servicos_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_produtos_servicos_icms = :nf_totais_ValorTotalProdutosServicosIcms_956 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalProdutosServicosIcms_956", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalFrete" || parametro.FieldName == "nfo_valor_total_frete")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_frete IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_frete = :nf_totais_ValorTotalFrete_3318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalFrete_3318", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalSeguro" || parametro.FieldName == "nfo_valor_total_seguro")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_seguro IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_seguro = :nf_totais_ValorTotalSeguro_8674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalSeguro_8674", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalDesconto" || parametro.FieldName == "nfo_valor_total_desconto")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_desconto IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_desconto = :nf_totais_ValorTotalDesconto_8703 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalDesconto_8703", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalDescontoIi" || parametro.FieldName == "nfo_valor_total_desconto_ii")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_desconto_ii IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_desconto_ii = :nf_totais_ValorTotalDescontoIi_5342 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalDescontoIi_5342", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIpi" || parametro.FieldName == "nfo_valor_total_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_ipi = :nf_totais_ValorTotalIpi_6931 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIpi_6931", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalPis" || parametro.FieldName == "nfo_valor_total_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_pis = :nf_totais_ValorTotalPis_8030 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalPis_8030", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalCofins" || parametro.FieldName == "nfo_valor_total_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_cofins = :nf_totais_ValorTotalCofins_9019 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalCofins_9019", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "OutrasDespesas" || parametro.FieldName == "nfo_outras_despesas")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_outras_despesas IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_outras_despesas = :nf_totais_OutrasDespesas_9777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_OutrasDespesas_9777", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalNf" || parametro.FieldName == "nfo_valor_total_nf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_nf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_nf = :nf_totais_ValorTotalNf_3650 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalNf_3650", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalServicos" || parametro.FieldName == "nfo_valor_total_servicos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_servicos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_servicos = :nf_totais_ValorTotalServicos_1777 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalServicos_1777", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "BaseCalculoIss" || parametro.FieldName == "nfo_base_calculo_iss")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_iss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_base_calculo_iss = :nf_totais_BaseCalculoIss_2717 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_BaseCalculoIss_2717", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIss" || parametro.FieldName == "nfo_valor_total_iss")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_iss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_iss = :nf_totais_ValorTotalIss_3358 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIss_3358", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalPisServicos" || parametro.FieldName == "nfo_valor_total_pis_servicos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_pis_servicos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_pis_servicos = :nf_totais_ValorTotalPisServicos_3221 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalPisServicos_3221", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalCofinsServicos" || parametro.FieldName == "nfo_valor_total_cofins_servicos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_cofins_servicos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_cofins_servicos = :nf_totais_ValorTotalCofinsServicos_2034 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalCofinsServicos_2034", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIimp" || parametro.FieldName == "nfo_valor_total_iimp")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_iimp IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_iimp = :nf_totais_ValorTotalIimp_4698 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIimp_4698", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIcmsDiferido" || parametro.FieldName == "nfo_valor_total_icms_diferido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_diferido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_diferido = :nf_totais_ValorTotalIcmsDiferido_2766 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIcmsDiferido_2766", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_totais.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.entity_uid LIKE :nf_totais_EntityUid_5842 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_EntityUid_5842", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_totais.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.version = :nf_totais_Version_2613 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_Version_2613", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoPis" || parametro.FieldName == "nfo_valor_retido_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_pis = :nf_totais_ValorRetidoPis_7838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoPis_7838", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoCofins" || parametro.FieldName == "nfo_valor_retido_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_cofins = :nf_totais_ValorRetidoCofins_7599 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoCofins_7599", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoCsll" || parametro.FieldName == "nfo_valor_retido_csll")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_csll IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_csll = :nf_totais_ValorRetidoCsll_4434 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoCsll_4434", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoBcIrrf" || parametro.FieldName == "nfo_valor_retido_bc_irrf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_bc_irrf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_bc_irrf = :nf_totais_ValorRetidoBcIrrf_4870 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoBcIrrf_4870", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoIrrf" || parametro.FieldName == "nfo_valor_retido_irrf")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_irrf IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_irrf = :nf_totais_ValorRetidoIrrf_8666 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoIrrf_8666", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoBcPrevidencia" || parametro.FieldName == "nfo_valor_retido_bc_previdencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_bc_previdencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_bc_previdencia = :nf_totais_ValorRetidoBcPrevidencia_9587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoBcPrevidencia_9587", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorRetidoPreviencia" || parametro.FieldName == "nfo_valor_retido_previencia")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_previencia IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_retido_previencia = :nf_totais_ValorRetidoPreviencia_2313 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorRetidoPreviencia_2313", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_totais")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.id_nf_totais IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.id_nf_totais = :nf_totais_ID_3259 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ID_3259", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalAproximadoTributos" || parametro.FieldName == "nfo_valor_total_aproximado_tributos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_aproximado_tributos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_aproximado_tributos = :nf_totais_ValorTotalAproximadoTributos_8859 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalAproximadoTributos_8859", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorTotalIcmsDesonerado" || parametro.FieldName == "nfo_valor_total_icms_desonerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_desonerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_valor_total_icms_desonerado = :nf_totais_ValorTotalIcmsDesonerado_5075 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_ValorTotalIcmsDesonerado_5075", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TotalIbs" || parametro.FieldName == "nfo_total_ibs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_total_ibs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_total_ibs = :nf_totais_TotalIbs_133 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_TotalIbs_133", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TotalCbs" || parametro.FieldName == "nfo_total_cbs")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_total_cbs IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_total_cbs = :nf_totais_TotalCbs_3550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_TotalCbs_3550", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "TotalIs" || parametro.FieldName == "nfo_total_is")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_total_is IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_total_is = :nf_totais_TotalIs_5608 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_TotalIs_5608", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsCred" || parametro.FieldName == "nfo_v_ibs_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_cred = :nf_totais_VIbsCred_8430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIbsCred_8430", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDif" || parametro.FieldName == "nfo_v_ibs_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_dif = :nf_totais_VIbsDif_8281 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIbsDif_8281", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsDev" || parametro.FieldName == "nfo_v_ibs_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_dev = :nf_totais_VIbsDev_3283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIbsDev_3283", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIbsRet" || parametro.FieldName == "nfo_v_ibs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_ibs_ret = :nf_totais_VIbsRet_3429 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIbsRet_3429", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsCred" || parametro.FieldName == "nfo_v_cbs_cred")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_cred IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_cred = :nf_totais_VCbsCred_5631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VCbsCred_5631", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsDif" || parametro.FieldName == "nfo_v_cbs_dif")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_dif IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_dif = :nf_totais_VCbsDif_1106 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VCbsDif_1106", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsDev" || parametro.FieldName == "nfo_v_cbs_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_dev = :nf_totais_VCbsDev_8656 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VCbsDev_8656", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VCbsRet" || parametro.FieldName == "nfo_v_cbs_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_cbs_ret = :nf_totais_VCbsRet_4259 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VCbsRet_4259", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIsDev" || parametro.FieldName == "nfo_v_is_dev")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_is_dev IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_is_dev = :nf_totais_VIsDev_2830 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIsDev_2830", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "VIsRet" || parametro.FieldName == "nfo_v_is_ret")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_totais.nfo_v_is_ret IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.nfo_v_is_ret = :nf_totais_VIsRet_8781 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_VIsRet_8781", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_totais.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_totais.entity_uid LIKE :nf_totais_EntityUid_7815 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_totais_EntityUid_7815", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfTotaisClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfTotaisClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfTotaisClass), Convert.ToInt32(read["id_nf_totais"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfTotaisClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_nf_principal"] != DBNull.Value)
                     {
                        entidade.NfPrincipal = (IWTNF.Entidades.Entidades.NfPrincipalClass)IWTNF.Entidades.Entidades.NfPrincipalClass.GetEntidade(Convert.ToInt32(read["id_nf_principal"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfPrincipal = null ;
                     }
                     entidade.BaseCalculoIcms = (double)read["nfo_base_calculo_icms"];
                     entidade.ValorTotalIcms = (double)read["nfo_valor_total_icms"];
                     entidade.BaseCalculoIcmsSt = (double)read["nfo_base_calculo_icms_st"];
                     entidade.ValorTotalIcmsSt = (double)read["nfo_valor_total_icms_st"];
                     entidade.ValorTotalProdutosServicosIcms = (double)read["nfo_valor_total_produtos_servicos_icms"];
                     entidade.ValorTotalFrete = (double)read["nfo_valor_total_frete"];
                     entidade.ValorTotalSeguro = (double)read["nfo_valor_total_seguro"];
                     entidade.ValorTotalDesconto = (double)read["nfo_valor_total_desconto"];
                     entidade.ValorTotalDescontoIi = (double)read["nfo_valor_total_desconto_ii"];
                     entidade.ValorTotalIpi = (double)read["nfo_valor_total_ipi"];
                     entidade.ValorTotalPis = (double)read["nfo_valor_total_pis"];
                     entidade.ValorTotalCofins = (double)read["nfo_valor_total_cofins"];
                     entidade.OutrasDespesas = (double)read["nfo_outras_despesas"];
                     entidade.ValorTotalNf = (double)read["nfo_valor_total_nf"];
                     entidade.ValorTotalServicos = read["nfo_valor_total_servicos"] as double?;
                     entidade.BaseCalculoIss = read["nfo_base_calculo_iss"] as double?;
                     entidade.ValorTotalIss = read["nfo_valor_total_iss"] as double?;
                     entidade.ValorTotalPisServicos = read["nfo_valor_total_pis_servicos"] as double?;
                     entidade.ValorTotalCofinsServicos = read["nfo_valor_total_cofins_servicos"] as double?;
                     entidade.ValorTotalIimp = (double)read["nfo_valor_total_iimp"];
                     entidade.ValorTotalIcmsDiferido = (double)read["nfo_valor_total_icms_diferido"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ValorRetidoPis = read["nfo_valor_retido_pis"] as double?;
                     entidade.ValorRetidoCofins = read["nfo_valor_retido_cofins"] as double?;
                     entidade.ValorRetidoCsll = read["nfo_valor_retido_csll"] as double?;
                     entidade.ValorRetidoBcIrrf = read["nfo_valor_retido_bc_irrf"] as double?;
                     entidade.ValorRetidoIrrf = read["nfo_valor_retido_irrf"] as double?;
                     entidade.ValorRetidoBcPrevidencia = read["nfo_valor_retido_bc_previdencia"] as double?;
                     entidade.ValorRetidoPreviencia = read["nfo_valor_retido_previencia"] as double?;
                     entidade.ID = Convert.ToInt64(read["id_nf_totais"]);
                     entidade.ValorTotalAproximadoTributos = read["nfo_valor_total_aproximado_tributos"] as double?;
                     entidade.ValorTotalIcmsDesonerado = (double)read["nfo_valor_total_icms_desonerado"];
                     entidade.TotalIbs = read["nfo_total_ibs"] as double?;
                     entidade.TotalCbs = read["nfo_total_cbs"] as double?;
                     entidade.TotalIs = read["nfo_total_is"] as double?;
                     entidade.VIbsCred = read["nfo_v_ibs_cred"] as double?;
                     entidade.VIbsDif = read["nfo_v_ibs_dif"] as double?;
                     entidade.VIbsDev = read["nfo_v_ibs_dev"] as double?;
                     entidade.VIbsRet = read["nfo_v_ibs_ret"] as double?;
                     entidade.VCbsCred = read["nfo_v_cbs_cred"] as double?;
                     entidade.VCbsDif = read["nfo_v_cbs_dif"] as double?;
                     entidade.VCbsDev = read["nfo_v_cbs_dev"] as double?;
                     entidade.VCbsRet = read["nfo_v_cbs_ret"] as double?;
                     entidade.VIsDev = read["nfo_v_is_dev"] as double?;
                     entidade.VIsRet = read["nfo_v_is_ret"] as double?;
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfTotaisClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
