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
     [Table("nf_item_tributo_icms","ntc")]
     public class NfItemTributoIcmsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfItemTributoIcmsClass";
protected const string ErroDelete = "Erro ao excluir o NfItemTributoIcmsClass  ";
protected const string ErroSave = "Erro ao salvar o NfItemTributoIcmsClass.";
protected const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected const string ErroCstComprimento = "O campo Cst deve ter no máximo 3 caracteres";
protected const string ErroCodigoAntecipacaoStObrigatorio = "O campo CodigoAntecipacaoSt é obrigatório";
protected const string ErroCodigoAntecipacaoStComprimento = "O campo CodigoAntecipacaoSt deve ter no máximo 1 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfItemTributoIcmsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfItemTributoIcmsClass está sendo utilizada.";
#endregion
       protected IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginal{get;private set;}
       private IWTNF.Entidades.Entidades.NfItemClass _nfItemOriginalCommited {get; set;}
       private IWTNF.Entidades.Entidades.NfItemClass _valueNfItem;
        [Column("id_nf_item", "nf_item", "id_nf_item")]
       public virtual IWTNF.Entidades.Entidades.NfItemClass NfItem
        { 
           get {                 return this._valueNfItem; } 
           set 
           { 
                if (this._valueNfItem == value)return;
                 this._valueNfItem = value; 
           } 
       } 

       protected OrigemMercadoria _origemOriginal{get;private set;}
       private OrigemMercadoria _origemOriginalCommited{get; set;}
        private OrigemMercadoria _valueOrigem;
         [Column("ntc_origem")]
        public virtual OrigemMercadoria Origem
         { 
            get { return this._valueOrigem; } 
            set 
            { 
                if (this._valueOrigem == value)return;
                 this._valueOrigem = value; 
            } 
        } 

        public bool Origem_Nacional
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.Nacional; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.Nacional; }
         } 

        public bool Origem_EstrangeiraImportacaoDireta
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraImportacaoDireta; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraImportacaoDireta; }
         } 

        public bool Origem_EstrangeiraMercadoInterno
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraMercadoInterno; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraMercadoInterno; }
         } 

        public bool Origem_NacionalComImportacao40a70
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacao40a70; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacao40a70; }
         } 

        public bool Origem_NacionalProducaoEmConformidade
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.NacionalProducaoEmConformidade; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.NacionalProducaoEmConformidade; }
         } 

        public bool Origem_NacionalComImportacaoAte40
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacaoAte40; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacaoAte40; }
         } 

        public bool Origem_EstrangeiraImportacaoDiretaNaCamex
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraImportacaoDiretaNaCamex; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraImportacaoDiretaNaCamex; }
         } 

        public bool Origem_EstrangeiraMercadoInternoNaCamex
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraMercadoInternoNaCamex; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.EstrangeiraMercadoInternoNaCamex; }
         } 

        public bool Origem_NacionalComImportacaoAcima70
         { 
            get { return this._valueOrigem == IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacaoAcima70; } 
            set { if (value) this._valueOrigem = IWTNF.Entidades.Base.OrigemMercadoria.NacionalComImportacaoAcima70; }
         } 

       protected string _cstOriginal{get;private set;}
       private string _cstOriginalCommited{get; set;}
        private string _valueCst;
         [Column("ntc_cst")]
        public virtual string Cst
         { 
            get { return this._valueCst; } 
            set 
            { 
                if (this._valueCst == value)return;
                 this._valueCst = value; 
            } 
        } 

       protected ModalidadeDeterminacaoBCICMS _modalidadeBcIcmsOriginal{get;private set;}
       private ModalidadeDeterminacaoBCICMS _modalidadeBcIcmsOriginalCommited{get; set;}
        private ModalidadeDeterminacaoBCICMS _valueModalidadeBcIcms;
         [Column("ntc_modalidade_bc_icms")]
        public virtual ModalidadeDeterminacaoBCICMS ModalidadeBcIcms
         { 
            get { return this._valueModalidadeBcIcms; } 
            set 
            { 
                if (this._valueModalidadeBcIcms == value)return;
                 this._valueModalidadeBcIcms = value; 
            } 
        } 

        public bool ModalidadeBcIcms_MargemValorAgregado
         { 
            get { return this._valueModalidadeBcIcms == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.MargemValorAgregado; } 
            set { if (value) this._valueModalidadeBcIcms = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.MargemValorAgregado; }
         } 

        public bool ModalidadeBcIcms_Pauta
         { 
            get { return this._valueModalidadeBcIcms == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.Pauta; } 
            set { if (value) this._valueModalidadeBcIcms = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.Pauta; }
         } 

        public bool ModalidadeBcIcms_PrecoTabeladoMax
         { 
            get { return this._valueModalidadeBcIcms == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.PrecoTabeladoMax; } 
            set { if (value) this._valueModalidadeBcIcms = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.PrecoTabeladoMax; }
         } 

        public bool ModalidadeBcIcms_ValorOperacao
         { 
            get { return this._valueModalidadeBcIcms == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.ValorOperacao; } 
            set { if (value) this._valueModalidadeBcIcms = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.ValorOperacao; }
         } 

       protected double _percentualReducaoBcOriginal{get;private set;}
       private double _percentualReducaoBcOriginalCommited{get; set;}
        private double _valuePercentualReducaoBc;
         [Column("ntc_percentual_reducao_bc")]
        public virtual double PercentualReducaoBc
         { 
            get { return this._valuePercentualReducaoBc; } 
            set 
            { 
                if (this._valuePercentualReducaoBc == value)return;
                 this._valuePercentualReducaoBc = value; 
            } 
        } 

       protected double _valorBcOriginal{get;private set;}
       private double _valorBcOriginalCommited{get; set;}
        private double _valueValorBc;
         [Column("ntc_valor_bc")]
        public virtual double ValorBc
         { 
            get { return this._valueValorBc; } 
            set 
            { 
                if (this._valueValorBc == value)return;
                 this._valueValorBc = value; 
            } 
        } 

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("ntc_aliquota")]
        public virtual double Aliquota
         { 
            get { return this._valueAliquota; } 
            set 
            { 
                if (this._valueAliquota == value)return;
                 this._valueAliquota = value; 
            } 
        } 

       protected double _valorIcmsOriginal{get;private set;}
       private double _valorIcmsOriginalCommited{get; set;}
        private double _valueValorIcms;
         [Column("ntc_valor_icms")]
        public virtual double ValorIcms
         { 
            get { return this._valueValorIcms; } 
            set 
            { 
                if (this._valueValorIcms == value)return;
                 this._valueValorIcms = value; 
            } 
        } 

       protected ModalidadeDeterminacaoBCICMSST _modalidadeBcStOriginal{get;private set;}
       private ModalidadeDeterminacaoBCICMSST _modalidadeBcStOriginalCommited{get; set;}
        private ModalidadeDeterminacaoBCICMSST _valueModalidadeBcSt;
         [Column("ntc_modalidade_bc_st")]
        public virtual ModalidadeDeterminacaoBCICMSST ModalidadeBcSt
         { 
            get { return this._valueModalidadeBcSt; } 
            set 
            { 
                if (this._valueModalidadeBcSt == value)return;
                 this._valueModalidadeBcSt = value; 
            } 
        } 

        public bool ModalidadeBcSt_PrecoTabelado
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.PrecoTabelado; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.PrecoTabelado; }
         } 

        public bool ModalidadeBcSt_ListaNegativa
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNegativa; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNegativa; }
         } 

        public bool ModalidadeBcSt_ListaPositiva
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaPositiva; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaPositiva; }
         } 

        public bool ModalidadeBcSt_ListaNeutra
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNeutra; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNeutra; }
         } 

        public bool ModalidadeBcSt_MargemValorAgregado
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.MargemValorAgregado; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.MargemValorAgregado; }
         } 

        public bool ModalidadeBcSt_Pauta
         { 
            get { return this._valueModalidadeBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.Pauta; } 
            set { if (value) this._valueModalidadeBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.Pauta; }
         } 

       protected double _percentualMvaStOriginal{get;private set;}
       private double _percentualMvaStOriginalCommited{get; set;}
        private double _valuePercentualMvaSt;
         [Column("ntc_percentual_mva_st")]
        public virtual double PercentualMvaSt
         { 
            get { return this._valuePercentualMvaSt; } 
            set 
            { 
                if (this._valuePercentualMvaSt == value)return;
                 this._valuePercentualMvaSt = value; 
            } 
        } 

       protected double _percentualReducaoBcStOriginal{get;private set;}
       private double _percentualReducaoBcStOriginalCommited{get; set;}
        private double _valuePercentualReducaoBcSt;
         [Column("ntc_percentual_reducao_bc_st")]
        public virtual double PercentualReducaoBcSt
         { 
            get { return this._valuePercentualReducaoBcSt; } 
            set 
            { 
                if (this._valuePercentualReducaoBcSt == value)return;
                 this._valuePercentualReducaoBcSt = value; 
            } 
        } 

       protected double _valorBcStOriginal{get;private set;}
       private double _valorBcStOriginalCommited{get; set;}
        private double _valueValorBcSt;
         [Column("ntc_valor_bc_st")]
        public virtual double ValorBcSt
         { 
            get { return this._valueValorBcSt; } 
            set 
            { 
                if (this._valueValorBcSt == value)return;
                 this._valueValorBcSt = value; 
            } 
        } 

       protected double _aliquotaStOriginal{get;private set;}
       private double _aliquotaStOriginalCommited{get; set;}
        private double _valueAliquotaSt;
         [Column("ntc_aliquota_st")]
        public virtual double AliquotaSt
         { 
            get { return this._valueAliquotaSt; } 
            set 
            { 
                if (this._valueAliquotaSt == value)return;
                 this._valueAliquotaSt = value; 
            } 
        } 

       protected double _valorIcmsStOriginal{get;private set;}
       private double _valorIcmsStOriginalCommited{get; set;}
        private double _valueValorIcmsSt;
         [Column("ntc_valor_icms_st")]
        public virtual double ValorIcmsSt
         { 
            get { return this._valueValorIcmsSt; } 
            set 
            { 
                if (this._valueValorIcmsSt == value)return;
                 this._valueValorIcmsSt = value; 
            } 
        } 

       protected string _codigoAntecipacaoStOriginal{get;private set;}
       private string _codigoAntecipacaoStOriginalCommited{get; set;}
        private string _valueCodigoAntecipacaoSt;
         [Column("ntc_codigo_antecipacao_st")]
        public virtual string CodigoAntecipacaoSt
         { 
            get { return this._valueCodigoAntecipacaoSt; } 
            set 
            { 
                if (this._valueCodigoAntecipacaoSt == value)return;
                 this._valueCodigoAntecipacaoSt = value; 
            } 
        } 

       protected double _percentualDiferimentoOriginal{get;private set;}
       private double _percentualDiferimentoOriginalCommited{get; set;}
        private double _valuePercentualDiferimento;
         [Column("ntc_percentual_diferimento")]
        public virtual double PercentualDiferimento
         { 
            get { return this._valuePercentualDiferimento; } 
            set 
            { 
                if (this._valuePercentualDiferimento == value)return;
                 this._valuePercentualDiferimento = value; 
            } 
        } 

       protected string _obsDiferimentoOriginal{get;private set;}
       private string _obsDiferimentoOriginalCommited{get; set;}
        private string _valueObsDiferimento;
         [Column("ntc_obs_diferimento")]
        public virtual string ObsDiferimento
         { 
            get { return this._valueObsDiferimento; } 
            set 
            { 
                if (this._valueObsDiferimento == value)return;
                 this._valueObsDiferimento = value; 
            } 
        } 

       protected double _icmsDiferidoOriginal{get;private set;}
       private double _icmsDiferidoOriginalCommited{get; set;}
        private double _valueIcmsDiferido;
         [Column("ntc_icms_diferido")]
        public virtual double IcmsDiferido
         { 
            get { return this._valueIcmsDiferido; } 
            set 
            { 
                if (this._valueIcmsDiferido == value)return;
                 this._valueIcmsDiferido = value; 
            } 
        } 

       protected double _percentualBcOperacaoPropriaOriginal{get;private set;}
       private double _percentualBcOperacaoPropriaOriginalCommited{get; set;}
        private double _valuePercentualBcOperacaoPropria;
         [Column("ntc_percentual_bc_operacao_propria")]
        public virtual double PercentualBcOperacaoPropria
         { 
            get { return this._valuePercentualBcOperacaoPropria; } 
            set 
            { 
                if (this._valuePercentualBcOperacaoPropria == value)return;
                 this._valuePercentualBcOperacaoPropria = value; 
            } 
        } 

       protected string _siglaUfDevidoIcmsOriginal{get;private set;}
       private string _siglaUfDevidoIcmsOriginalCommited{get; set;}
        private string _valueSiglaUfDevidoIcms;
         [Column("ntc_sigla_uf_devido_icms")]
        public virtual string SiglaUfDevidoIcms
         { 
            get { return this._valueSiglaUfDevidoIcms; } 
            set 
            { 
                if (this._valueSiglaUfDevidoIcms == value)return;
                 this._valueSiglaUfDevidoIcms = value; 
            } 
        } 

       protected double _valorBcStRetidoRemetenteOriginal{get;private set;}
       private double _valorBcStRetidoRemetenteOriginalCommited{get; set;}
        private double _valueValorBcStRetidoRemetente;
         [Column("ntc_valor_bc_st_retido_remetente")]
        public virtual double ValorBcStRetidoRemetente
         { 
            get { return this._valueValorBcStRetidoRemetente; } 
            set 
            { 
                if (this._valueValorBcStRetidoRemetente == value)return;
                 this._valueValorBcStRetidoRemetente = value; 
            } 
        } 

       protected double _valorIcmsStRetidoRemetenteOriginal{get;private set;}
       private double _valorIcmsStRetidoRemetenteOriginalCommited{get; set;}
        private double _valueValorIcmsStRetidoRemetente;
         [Column("ntc_valor_icms_st_retido_remetente")]
        public virtual double ValorIcmsStRetidoRemetente
         { 
            get { return this._valueValorIcmsStRetidoRemetente; } 
            set 
            { 
                if (this._valueValorIcmsStRetidoRemetente == value)return;
                 this._valueValorIcmsStRetidoRemetente = value; 
            } 
        } 

       protected double _valorBcStRetidoDestinatarioOriginal{get;private set;}
       private double _valorBcStRetidoDestinatarioOriginalCommited{get; set;}
        private double _valueValorBcStRetidoDestinatario;
         [Column("ntc_valor_bc_st_retido_destinatario")]
        public virtual double ValorBcStRetidoDestinatario
         { 
            get { return this._valueValorBcStRetidoDestinatario; } 
            set 
            { 
                if (this._valueValorBcStRetidoDestinatario == value)return;
                 this._valueValorBcStRetidoDestinatario = value; 
            } 
        } 

       protected double _valorIcmsStRetidoDestinatarioOriginal{get;private set;}
       private double _valorIcmsStRetidoDestinatarioOriginalCommited{get; set;}
        private double _valueValorIcmsStRetidoDestinatario;
         [Column("ntc_valor_icms_st_retido_destinatario")]
        public virtual double ValorIcmsStRetidoDestinatario
         { 
            get { return this._valueValorIcmsStRetidoDestinatario; } 
            set 
            { 
                if (this._valueValorIcmsStRetidoDestinatario == value)return;
                 this._valueValorIcmsStRetidoDestinatario = value; 
            } 
        } 

       protected int? _csoSimplesOriginal{get;private set;}
       private int? _csoSimplesOriginalCommited{get; set;}
        private int? _valueCsoSimples;
         [Column("ntc_cso_simples")]
        public virtual int? CsoSimples
         { 
            get { return this._valueCsoSimples; } 
            set 
            { 
                if (this._valueCsoSimples == value)return;
                 this._valueCsoSimples = value; 
            } 
        } 

       protected double _aliquotaCreditoSimplesOriginal{get;private set;}
       private double _aliquotaCreditoSimplesOriginalCommited{get; set;}
        private double _valueAliquotaCreditoSimples;
         [Column("ntc_aliquota_credito_simples")]
        public virtual double AliquotaCreditoSimples
         { 
            get { return this._valueAliquotaCreditoSimples; } 
            set 
            { 
                if (this._valueAliquotaCreditoSimples == value)return;
                 this._valueAliquotaCreditoSimples = value; 
            } 
        } 

       protected double _valorCreditoIcmsSimplesOriginal{get;private set;}
       private double _valorCreditoIcmsSimplesOriginalCommited{get; set;}
        private double _valueValorCreditoIcmsSimples;
         [Column("ntc_valor_credito_icms_simples")]
        public virtual double ValorCreditoIcmsSimples
         { 
            get { return this._valueValorCreditoIcmsSimples; } 
            set 
            { 
                if (this._valueValorCreditoIcmsSimples == value)return;
                 this._valueValorCreditoIcmsSimples = value; 
            } 
        } 

       protected short? _motivoDesoneracaoIcmsOriginal{get;private set;}
       private short? _motivoDesoneracaoIcmsOriginalCommited{get; set;}
        private short? _valueMotivoDesoneracaoIcms;
         [Column("ntc_motivo_desoneracao_icms")]
        public virtual short? MotivoDesoneracaoIcms
         { 
            get { return this._valueMotivoDesoneracaoIcms; } 
            set 
            { 
                if (this._valueMotivoDesoneracaoIcms == value)return;
                 this._valueMotivoDesoneracaoIcms = value; 
            } 
        } 

       protected double? _valorCreditoPresumidoOriginal{get;private set;}
       private double? _valorCreditoPresumidoOriginalCommited{get; set;}
        private double? _valueValorCreditoPresumido;
         [Column("ntc_valor_credito_presumido")]
        public virtual double? ValorCreditoPresumido
         { 
            get { return this._valueValorCreditoPresumido; } 
            set 
            { 
                if (this._valueValorCreditoPresumido == value)return;
                 this._valueValorCreditoPresumido = value; 
            } 
        } 

       protected string _observacaoCreditoPresumidoOriginal{get;private set;}
       private string _observacaoCreditoPresumidoOriginalCommited{get; set;}
        private string _valueObservacaoCreditoPresumido;
         [Column("ntc_observacao_credito_presumido")]
        public virtual string ObservacaoCreditoPresumido
         { 
            get { return this._valueObservacaoCreditoPresumido; } 
            set 
            { 
                if (this._valueObservacaoCreditoPresumido == value)return;
                 this._valueObservacaoCreditoPresumido = value; 
            } 
        } 

       protected double? _valorIcmsOperacaoOriginal{get;private set;}
       private double? _valorIcmsOperacaoOriginalCommited{get; set;}
        private double? _valueValorIcmsOperacao;
         [Column("nfc_valor_icms_operacao")]
        public virtual double? ValorIcmsOperacao
         { 
            get { return this._valueValorIcmsOperacao; } 
            set 
            { 
                if (this._valueValorIcmsOperacao == value)return;
                 this._valueValorIcmsOperacao = value; 
            } 
        } 

       protected string _observacaoCreditoSimplesOriginal{get;private set;}
       private string _observacaoCreditoSimplesOriginalCommited{get; set;}
        private string _valueObservacaoCreditoSimples;
         [Column("ntc_observacao_credito_simples")]
        public virtual string ObservacaoCreditoSimples
         { 
            get { return this._valueObservacaoCreditoSimples; } 
            set 
            { 
                if (this._valueObservacaoCreditoSimples == value)return;
                 this._valueObservacaoCreditoSimples = value; 
            } 
        } 

       protected double? _fcpRetidoBcOriginal{get;private set;}
       private double? _fcpRetidoBcOriginalCommited{get; set;}
        private double? _valueFcpRetidoBc;
         [Column("ntc_fcp_retido_bc")]
        public virtual double? FcpRetidoBc
         { 
            get { return this._valueFcpRetidoBc; } 
            set 
            { 
                if (this._valueFcpRetidoBc == value)return;
                 this._valueFcpRetidoBc = value; 
            } 
        } 

       protected double? _fcpRetidoAliquotaOriginal{get;private set;}
       private double? _fcpRetidoAliquotaOriginalCommited{get; set;}
        private double? _valueFcpRetidoAliquota;
         [Column("ntc_fcp_retido_aliquota")]
        public virtual double? FcpRetidoAliquota
         { 
            get { return this._valueFcpRetidoAliquota; } 
            set 
            { 
                if (this._valueFcpRetidoAliquota == value)return;
                 this._valueFcpRetidoAliquota = value; 
            } 
        } 

       protected double? _fcpRetidoValorOriginal{get;private set;}
       private double? _fcpRetidoValorOriginalCommited{get; set;}
        private double? _valueFcpRetidoValor;
         [Column("ntc_fcp_retido_valor")]
        public virtual double? FcpRetidoValor
         { 
            get { return this._valueFcpRetidoValor; } 
            set 
            { 
                if (this._valueFcpRetidoValor == value)return;
                 this._valueFcpRetidoValor = value; 
            } 
        } 

       protected double? _fcpBcOriginal{get;private set;}
       private double? _fcpBcOriginalCommited{get; set;}
        private double? _valueFcpBc;
         [Column("ntc_fcp_bc")]
        public virtual double? FcpBc
         { 
            get { return this._valueFcpBc; } 
            set 
            { 
                if (this._valueFcpBc == value)return;
                 this._valueFcpBc = value; 
            } 
        } 

       protected double? _fcpAliquotaOriginal{get;private set;}
       private double? _fcpAliquotaOriginalCommited{get; set;}
        private double? _valueFcpAliquota;
         [Column("ntc_fcp_aliquota")]
        public virtual double? FcpAliquota
         { 
            get { return this._valueFcpAliquota; } 
            set 
            { 
                if (this._valueFcpAliquota == value)return;
                 this._valueFcpAliquota = value; 
            } 
        } 

       protected double? _fcpValorOriginal{get;private set;}
       private double? _fcpValorOriginalCommited{get; set;}
        private double? _valueFcpValor;
         [Column("ntc_fcp_valor")]
        public virtual double? FcpValor
         { 
            get { return this._valueFcpValor; } 
            set 
            { 
                if (this._valueFcpValor == value)return;
                 this._valueFcpValor = value; 
            } 
        } 

       protected double _valorIcmsDesoneradoOriginal{get;private set;}
       private double _valorIcmsDesoneradoOriginalCommited{get; set;}
        private double _valueValorIcmsDesonerado;
         [Column("ntc_valor_icms_desonerado")]
        public virtual double ValorIcmsDesonerado
         { 
            get { return this._valueValorIcmsDesonerado; } 
            set 
            { 
                if (this._valueValorIcmsDesonerado == value)return;
                 this._valueValorIcmsDesonerado = value; 
            } 
        } 

        public NfItemTributoIcmsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.IcmsDiferido = 0;
           this.PercentualBcOperacaoPropria = 0;
           this.ValorBcStRetidoRemetente = 0;
           this.ValorIcmsStRetidoRemetente = 0;
           this.ValorBcStRetidoDestinatario = 0;
           this.ValorIcmsStRetidoDestinatario = 0;
           this.AliquotaCreditoSimples = 0;
           this.ValorCreditoIcmsSimples = 0;
           this.ValorIcmsDesonerado = 0;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfItemTributoIcmsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfItemTributoIcmsClass) GetEntity(typeof(NfItemTributoIcmsClass),id,usuarioAtual,connection, operacao);
        }
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Cst))
                {
                    throw new Exception(ErroCstObrigatorio);
                }
                if (Cst.Length >3)
                {
                    throw new Exception( ErroCstComprimento);
                }
                if (string.IsNullOrEmpty(CodigoAntecipacaoSt))
                {
                    throw new Exception(ErroCodigoAntecipacaoStObrigatorio);
                }
                if (CodigoAntecipacaoSt.Length >1)
                {
                    throw new Exception( ErroCodigoAntecipacaoStComprimento);
                }
                if ( _valueNfItem == null)
                {
                    throw new Exception(ErroNfItemObrigatorio);
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
                    "  public.nf_item_tributo_icms  " +
                    "WHERE " +
                    "  id_nf_item_tributo_icms = :id";
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
                        "  public.nf_item_tributo_icms   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  ntc_origem = :ntc_origem, " + 
                        "  ntc_cst = :ntc_cst, " + 
                        "  ntc_modalidade_bc_icms = :ntc_modalidade_bc_icms, " + 
                        "  ntc_percentual_reducao_bc = :ntc_percentual_reducao_bc, " + 
                        "  ntc_valor_bc = :ntc_valor_bc, " + 
                        "  ntc_aliquota = :ntc_aliquota, " + 
                        "  ntc_valor_icms = :ntc_valor_icms, " + 
                        "  ntc_modalidade_bc_st = :ntc_modalidade_bc_st, " + 
                        "  ntc_percentual_mva_st = :ntc_percentual_mva_st, " + 
                        "  ntc_percentual_reducao_bc_st = :ntc_percentual_reducao_bc_st, " + 
                        "  ntc_valor_bc_st = :ntc_valor_bc_st, " + 
                        "  ntc_aliquota_st = :ntc_aliquota_st, " + 
                        "  ntc_valor_icms_st = :ntc_valor_icms_st, " + 
                        "  ntc_codigo_antecipacao_st = :ntc_codigo_antecipacao_st, " + 
                        "  ntc_percentual_diferimento = :ntc_percentual_diferimento, " + 
                        "  ntc_obs_diferimento = :ntc_obs_diferimento, " + 
                        "  ntc_icms_diferido = :ntc_icms_diferido, " + 
                        "  ntc_percentual_bc_operacao_propria = :ntc_percentual_bc_operacao_propria, " + 
                        "  ntc_sigla_uf_devido_icms = :ntc_sigla_uf_devido_icms, " + 
                        "  ntc_valor_bc_st_retido_remetente = :ntc_valor_bc_st_retido_remetente, " + 
                        "  ntc_valor_icms_st_retido_remetente = :ntc_valor_icms_st_retido_remetente, " + 
                        "  ntc_valor_bc_st_retido_destinatario = :ntc_valor_bc_st_retido_destinatario, " + 
                        "  ntc_valor_icms_st_retido_destinatario = :ntc_valor_icms_st_retido_destinatario, " + 
                        "  ntc_cso_simples = :ntc_cso_simples, " + 
                        "  ntc_aliquota_credito_simples = :ntc_aliquota_credito_simples, " + 
                        "  ntc_valor_credito_icms_simples = :ntc_valor_credito_icms_simples, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ntc_motivo_desoneracao_icms = :ntc_motivo_desoneracao_icms, " + 
                        "  ntc_valor_credito_presumido = :ntc_valor_credito_presumido, " + 
                        "  ntc_observacao_credito_presumido = :ntc_observacao_credito_presumido, " + 
                        "  nfc_valor_icms_operacao = :nfc_valor_icms_operacao, " + 
                        "  ntc_observacao_credito_simples = :ntc_observacao_credito_simples, " + 
                        "  ntc_fcp_retido_bc = :ntc_fcp_retido_bc, " + 
                        "  ntc_fcp_retido_aliquota = :ntc_fcp_retido_aliquota, " + 
                        "  ntc_fcp_retido_valor = :ntc_fcp_retido_valor, " + 
                        "  ntc_fcp_bc = :ntc_fcp_bc, " + 
                        "  ntc_fcp_aliquota = :ntc_fcp_aliquota, " + 
                        "  ntc_fcp_valor = :ntc_fcp_valor, " + 
                        "  ntc_valor_icms_desonerado = :ntc_valor_icms_desonerado "+
                        "WHERE  " +
                        "  id_nf_item_tributo_icms = :id " +
                        "RETURNING id_nf_item_tributo_icms;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_item_tributo_icms " +
                        "( " +
                        "  id_nf_item , " + 
                        "  ntc_origem , " + 
                        "  ntc_cst , " + 
                        "  ntc_modalidade_bc_icms , " + 
                        "  ntc_percentual_reducao_bc , " + 
                        "  ntc_valor_bc , " + 
                        "  ntc_aliquota , " + 
                        "  ntc_valor_icms , " + 
                        "  ntc_modalidade_bc_st , " + 
                        "  ntc_percentual_mva_st , " + 
                        "  ntc_percentual_reducao_bc_st , " + 
                        "  ntc_valor_bc_st , " + 
                        "  ntc_aliquota_st , " + 
                        "  ntc_valor_icms_st , " + 
                        "  ntc_codigo_antecipacao_st , " + 
                        "  ntc_percentual_diferimento , " + 
                        "  ntc_obs_diferimento , " + 
                        "  ntc_icms_diferido , " + 
                        "  ntc_percentual_bc_operacao_propria , " + 
                        "  ntc_sigla_uf_devido_icms , " + 
                        "  ntc_valor_bc_st_retido_remetente , " + 
                        "  ntc_valor_icms_st_retido_remetente , " + 
                        "  ntc_valor_bc_st_retido_destinatario , " + 
                        "  ntc_valor_icms_st_retido_destinatario , " + 
                        "  ntc_cso_simples , " + 
                        "  ntc_aliquota_credito_simples , " + 
                        "  ntc_valor_credito_icms_simples , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ntc_motivo_desoneracao_icms , " + 
                        "  ntc_valor_credito_presumido , " + 
                        "  ntc_observacao_credito_presumido , " + 
                        "  nfc_valor_icms_operacao , " + 
                        "  ntc_observacao_credito_simples , " + 
                        "  ntc_fcp_retido_bc , " + 
                        "  ntc_fcp_retido_aliquota , " + 
                        "  ntc_fcp_retido_valor , " + 
                        "  ntc_fcp_bc , " + 
                        "  ntc_fcp_aliquota , " + 
                        "  ntc_fcp_valor , " + 
                        "  ntc_valor_icms_desonerado  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :ntc_origem , " + 
                        "  :ntc_cst , " + 
                        "  :ntc_modalidade_bc_icms , " + 
                        "  :ntc_percentual_reducao_bc , " + 
                        "  :ntc_valor_bc , " + 
                        "  :ntc_aliquota , " + 
                        "  :ntc_valor_icms , " + 
                        "  :ntc_modalidade_bc_st , " + 
                        "  :ntc_percentual_mva_st , " + 
                        "  :ntc_percentual_reducao_bc_st , " + 
                        "  :ntc_valor_bc_st , " + 
                        "  :ntc_aliquota_st , " + 
                        "  :ntc_valor_icms_st , " + 
                        "  :ntc_codigo_antecipacao_st , " + 
                        "  :ntc_percentual_diferimento , " + 
                        "  :ntc_obs_diferimento , " + 
                        "  :ntc_icms_diferido , " + 
                        "  :ntc_percentual_bc_operacao_propria , " + 
                        "  :ntc_sigla_uf_devido_icms , " + 
                        "  :ntc_valor_bc_st_retido_remetente , " + 
                        "  :ntc_valor_icms_st_retido_remetente , " + 
                        "  :ntc_valor_bc_st_retido_destinatario , " + 
                        "  :ntc_valor_icms_st_retido_destinatario , " + 
                        "  :ntc_cso_simples , " + 
                        "  :ntc_aliquota_credito_simples , " + 
                        "  :ntc_valor_credito_icms_simples , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ntc_motivo_desoneracao_icms , " + 
                        "  :ntc_valor_credito_presumido , " + 
                        "  :ntc_observacao_credito_presumido , " + 
                        "  :nfc_valor_icms_operacao , " + 
                        "  :ntc_observacao_credito_simples , " + 
                        "  :ntc_fcp_retido_bc , " + 
                        "  :ntc_fcp_retido_aliquota , " + 
                        "  :ntc_fcp_retido_valor , " + 
                        "  :ntc_fcp_bc , " + 
                        "  :ntc_fcp_aliquota , " + 
                        "  :ntc_fcp_valor , " + 
                        "  :ntc_valor_icms_desonerado  "+
                        ")RETURNING id_nf_item_tributo_icms;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_origem", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Origem);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_modalidade_bc_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeBcIcms);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_icms", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_modalidade_bc_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeBcSt);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_percentual_mva_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualMvaSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_aliquota_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_icms_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_codigo_antecipacao_st", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoAntecipacaoSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_obs_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObsDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_icms_diferido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsDiferido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_percentual_bc_operacao_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualBcOperacaoPropria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_sigla_uf_devido_icms", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUfDevidoIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_bc_st_retido_remetente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBcStRetidoRemetente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_icms_st_retido_remetente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsStRetidoRemetente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_bc_st_retido_destinatario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBcStRetidoDestinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_icms_st_retido_destinatario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsStRetidoDestinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_cso_simples", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CsoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_aliquota_credito_simples", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaCreditoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_credito_icms_simples", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorCreditoIcmsSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_motivo_desoneracao_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MotivoDesoneracaoIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_credito_presumido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_observacao_credito_presumido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nfc_valor_icms_operacao", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_observacao_credito_simples", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_retido_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_retido_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_retido_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoValor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_fcp_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpValor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ntc_valor_icms_desonerado", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsDesonerado ?? DBNull.Value;

 
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
        public static NfItemTributoIcmsClass CopiarEntidade(NfItemTributoIcmsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfItemTributoIcmsClass toRet = new NfItemTributoIcmsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.Origem= entidadeCopiar.Origem;
 toRet.Cst= entidadeCopiar.Cst;
 toRet.ModalidadeBcIcms= entidadeCopiar.ModalidadeBcIcms;
 toRet.PercentualReducaoBc= entidadeCopiar.PercentualReducaoBc;
 toRet.ValorBc= entidadeCopiar.ValorBc;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.ValorIcms= entidadeCopiar.ValorIcms;
 toRet.ModalidadeBcSt= entidadeCopiar.ModalidadeBcSt;
 toRet.PercentualMvaSt= entidadeCopiar.PercentualMvaSt;
 toRet.PercentualReducaoBcSt= entidadeCopiar.PercentualReducaoBcSt;
 toRet.ValorBcSt= entidadeCopiar.ValorBcSt;
 toRet.AliquotaSt= entidadeCopiar.AliquotaSt;
 toRet.ValorIcmsSt= entidadeCopiar.ValorIcmsSt;
 toRet.CodigoAntecipacaoSt= entidadeCopiar.CodigoAntecipacaoSt;
 toRet.PercentualDiferimento= entidadeCopiar.PercentualDiferimento;
 toRet.ObsDiferimento= entidadeCopiar.ObsDiferimento;
 toRet.IcmsDiferido= entidadeCopiar.IcmsDiferido;
 toRet.PercentualBcOperacaoPropria= entidadeCopiar.PercentualBcOperacaoPropria;
 toRet.SiglaUfDevidoIcms= entidadeCopiar.SiglaUfDevidoIcms;
 toRet.ValorBcStRetidoRemetente= entidadeCopiar.ValorBcStRetidoRemetente;
 toRet.ValorIcmsStRetidoRemetente= entidadeCopiar.ValorIcmsStRetidoRemetente;
 toRet.ValorBcStRetidoDestinatario= entidadeCopiar.ValorBcStRetidoDestinatario;
 toRet.ValorIcmsStRetidoDestinatario= entidadeCopiar.ValorIcmsStRetidoDestinatario;
 toRet.CsoSimples= entidadeCopiar.CsoSimples;
 toRet.AliquotaCreditoSimples= entidadeCopiar.AliquotaCreditoSimples;
 toRet.ValorCreditoIcmsSimples= entidadeCopiar.ValorCreditoIcmsSimples;
 toRet.MotivoDesoneracaoIcms= entidadeCopiar.MotivoDesoneracaoIcms;
 toRet.ValorCreditoPresumido= entidadeCopiar.ValorCreditoPresumido;
 toRet.ObservacaoCreditoPresumido= entidadeCopiar.ObservacaoCreditoPresumido;
 toRet.ValorIcmsOperacao= entidadeCopiar.ValorIcmsOperacao;
 toRet.ObservacaoCreditoSimples= entidadeCopiar.ObservacaoCreditoSimples;
 toRet.FcpRetidoBc= entidadeCopiar.FcpRetidoBc;
 toRet.FcpRetidoAliquota= entidadeCopiar.FcpRetidoAliquota;
 toRet.FcpRetidoValor= entidadeCopiar.FcpRetidoValor;
 toRet.FcpBc= entidadeCopiar.FcpBc;
 toRet.FcpAliquota= entidadeCopiar.FcpAliquota;
 toRet.FcpValor= entidadeCopiar.FcpValor;
 toRet.ValorIcmsDesonerado= entidadeCopiar.ValorIcmsDesonerado;

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
       _nfItemOriginal = NfItem;
       _nfItemOriginalCommited = _nfItemOriginal;
       _origemOriginal = Origem;
       _origemOriginalCommited = _origemOriginal;
       _cstOriginal = Cst;
       _cstOriginalCommited = _cstOriginal;
       _modalidadeBcIcmsOriginal = ModalidadeBcIcms;
       _modalidadeBcIcmsOriginalCommited = _modalidadeBcIcmsOriginal;
       _percentualReducaoBcOriginal = PercentualReducaoBc;
       _percentualReducaoBcOriginalCommited = _percentualReducaoBcOriginal;
       _valorBcOriginal = ValorBc;
       _valorBcOriginalCommited = _valorBcOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _valorIcmsOriginal = ValorIcms;
       _valorIcmsOriginalCommited = _valorIcmsOriginal;
       _modalidadeBcStOriginal = ModalidadeBcSt;
       _modalidadeBcStOriginalCommited = _modalidadeBcStOriginal;
       _percentualMvaStOriginal = PercentualMvaSt;
       _percentualMvaStOriginalCommited = _percentualMvaStOriginal;
       _percentualReducaoBcStOriginal = PercentualReducaoBcSt;
       _percentualReducaoBcStOriginalCommited = _percentualReducaoBcStOriginal;
       _valorBcStOriginal = ValorBcSt;
       _valorBcStOriginalCommited = _valorBcStOriginal;
       _aliquotaStOriginal = AliquotaSt;
       _aliquotaStOriginalCommited = _aliquotaStOriginal;
       _valorIcmsStOriginal = ValorIcmsSt;
       _valorIcmsStOriginalCommited = _valorIcmsStOriginal;
       _codigoAntecipacaoStOriginal = CodigoAntecipacaoSt;
       _codigoAntecipacaoStOriginalCommited = _codigoAntecipacaoStOriginal;
       _percentualDiferimentoOriginal = PercentualDiferimento;
       _percentualDiferimentoOriginalCommited = _percentualDiferimentoOriginal;
       _obsDiferimentoOriginal = ObsDiferimento;
       _obsDiferimentoOriginalCommited = _obsDiferimentoOriginal;
       _icmsDiferidoOriginal = IcmsDiferido;
       _icmsDiferidoOriginalCommited = _icmsDiferidoOriginal;
       _percentualBcOperacaoPropriaOriginal = PercentualBcOperacaoPropria;
       _percentualBcOperacaoPropriaOriginalCommited = _percentualBcOperacaoPropriaOriginal;
       _siglaUfDevidoIcmsOriginal = SiglaUfDevidoIcms;
       _siglaUfDevidoIcmsOriginalCommited = _siglaUfDevidoIcmsOriginal;
       _valorBcStRetidoRemetenteOriginal = ValorBcStRetidoRemetente;
       _valorBcStRetidoRemetenteOriginalCommited = _valorBcStRetidoRemetenteOriginal;
       _valorIcmsStRetidoRemetenteOriginal = ValorIcmsStRetidoRemetente;
       _valorIcmsStRetidoRemetenteOriginalCommited = _valorIcmsStRetidoRemetenteOriginal;
       _valorBcStRetidoDestinatarioOriginal = ValorBcStRetidoDestinatario;
       _valorBcStRetidoDestinatarioOriginalCommited = _valorBcStRetidoDestinatarioOriginal;
       _valorIcmsStRetidoDestinatarioOriginal = ValorIcmsStRetidoDestinatario;
       _valorIcmsStRetidoDestinatarioOriginalCommited = _valorIcmsStRetidoDestinatarioOriginal;
       _csoSimplesOriginal = CsoSimples;
       _csoSimplesOriginalCommited = _csoSimplesOriginal;
       _aliquotaCreditoSimplesOriginal = AliquotaCreditoSimples;
       _aliquotaCreditoSimplesOriginalCommited = _aliquotaCreditoSimplesOriginal;
       _valorCreditoIcmsSimplesOriginal = ValorCreditoIcmsSimples;
       _valorCreditoIcmsSimplesOriginalCommited = _valorCreditoIcmsSimplesOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _motivoDesoneracaoIcmsOriginal = MotivoDesoneracaoIcms;
       _motivoDesoneracaoIcmsOriginalCommited = _motivoDesoneracaoIcmsOriginal;
       _valorCreditoPresumidoOriginal = ValorCreditoPresumido;
       _valorCreditoPresumidoOriginalCommited = _valorCreditoPresumidoOriginal;
       _observacaoCreditoPresumidoOriginal = ObservacaoCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = _observacaoCreditoPresumidoOriginal;
       _valorIcmsOperacaoOriginal = ValorIcmsOperacao;
       _valorIcmsOperacaoOriginalCommited = _valorIcmsOperacaoOriginal;
       _observacaoCreditoSimplesOriginal = ObservacaoCreditoSimples;
       _observacaoCreditoSimplesOriginalCommited = _observacaoCreditoSimplesOriginal;
       _fcpRetidoBcOriginal = FcpRetidoBc;
       _fcpRetidoBcOriginalCommited = _fcpRetidoBcOriginal;
       _fcpRetidoAliquotaOriginal = FcpRetidoAliquota;
       _fcpRetidoAliquotaOriginalCommited = _fcpRetidoAliquotaOriginal;
       _fcpRetidoValorOriginal = FcpRetidoValor;
       _fcpRetidoValorOriginalCommited = _fcpRetidoValorOriginal;
       _fcpBcOriginal = FcpBc;
       _fcpBcOriginalCommited = _fcpBcOriginal;
       _fcpAliquotaOriginal = FcpAliquota;
       _fcpAliquotaOriginalCommited = _fcpAliquotaOriginal;
       _fcpValorOriginal = FcpValor;
       _fcpValorOriginalCommited = _fcpValorOriginal;
       _valorIcmsDesoneradoOriginal = ValorIcmsDesonerado;
       _valorIcmsDesoneradoOriginalCommited = _valorIcmsDesoneradoOriginal;

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
       _nfItemOriginalCommited = NfItem;
       _origemOriginalCommited = Origem;
       _cstOriginalCommited = Cst;
       _modalidadeBcIcmsOriginalCommited = ModalidadeBcIcms;
       _percentualReducaoBcOriginalCommited = PercentualReducaoBc;
       _valorBcOriginalCommited = ValorBc;
       _aliquotaOriginalCommited = Aliquota;
       _valorIcmsOriginalCommited = ValorIcms;
       _modalidadeBcStOriginalCommited = ModalidadeBcSt;
       _percentualMvaStOriginalCommited = PercentualMvaSt;
       _percentualReducaoBcStOriginalCommited = PercentualReducaoBcSt;
       _valorBcStOriginalCommited = ValorBcSt;
       _aliquotaStOriginalCommited = AliquotaSt;
       _valorIcmsStOriginalCommited = ValorIcmsSt;
       _codigoAntecipacaoStOriginalCommited = CodigoAntecipacaoSt;
       _percentualDiferimentoOriginalCommited = PercentualDiferimento;
       _obsDiferimentoOriginalCommited = ObsDiferimento;
       _icmsDiferidoOriginalCommited = IcmsDiferido;
       _percentualBcOperacaoPropriaOriginalCommited = PercentualBcOperacaoPropria;
       _siglaUfDevidoIcmsOriginalCommited = SiglaUfDevidoIcms;
       _valorBcStRetidoRemetenteOriginalCommited = ValorBcStRetidoRemetente;
       _valorIcmsStRetidoRemetenteOriginalCommited = ValorIcmsStRetidoRemetente;
       _valorBcStRetidoDestinatarioOriginalCommited = ValorBcStRetidoDestinatario;
       _valorIcmsStRetidoDestinatarioOriginalCommited = ValorIcmsStRetidoDestinatario;
       _csoSimplesOriginalCommited = CsoSimples;
       _aliquotaCreditoSimplesOriginalCommited = AliquotaCreditoSimples;
       _valorCreditoIcmsSimplesOriginalCommited = ValorCreditoIcmsSimples;
       _versionOriginalCommited = Version;
       _motivoDesoneracaoIcmsOriginalCommited = MotivoDesoneracaoIcms;
       _valorCreditoPresumidoOriginalCommited = ValorCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = ObservacaoCreditoPresumido;
       _valorIcmsOperacaoOriginalCommited = ValorIcmsOperacao;
       _observacaoCreditoSimplesOriginalCommited = ObservacaoCreditoSimples;
       _fcpRetidoBcOriginalCommited = FcpRetidoBc;
       _fcpRetidoAliquotaOriginalCommited = FcpRetidoAliquota;
       _fcpRetidoValorOriginalCommited = FcpRetidoValor;
       _fcpBcOriginalCommited = FcpBc;
       _fcpAliquotaOriginalCommited = FcpAliquota;
       _fcpValorOriginalCommited = FcpValor;
       _valorIcmsDesoneradoOriginalCommited = ValorIcmsDesonerado;

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
               NfItem=_nfItemOriginal;
               _nfItemOriginalCommited=_nfItemOriginal;
               Origem=_origemOriginal;
               _origemOriginalCommited=_origemOriginal;
               Cst=_cstOriginal;
               _cstOriginalCommited=_cstOriginal;
               ModalidadeBcIcms=_modalidadeBcIcmsOriginal;
               _modalidadeBcIcmsOriginalCommited=_modalidadeBcIcmsOriginal;
               PercentualReducaoBc=_percentualReducaoBcOriginal;
               _percentualReducaoBcOriginalCommited=_percentualReducaoBcOriginal;
               ValorBc=_valorBcOriginal;
               _valorBcOriginalCommited=_valorBcOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               ValorIcms=_valorIcmsOriginal;
               _valorIcmsOriginalCommited=_valorIcmsOriginal;
               ModalidadeBcSt=_modalidadeBcStOriginal;
               _modalidadeBcStOriginalCommited=_modalidadeBcStOriginal;
               PercentualMvaSt=_percentualMvaStOriginal;
               _percentualMvaStOriginalCommited=_percentualMvaStOriginal;
               PercentualReducaoBcSt=_percentualReducaoBcStOriginal;
               _percentualReducaoBcStOriginalCommited=_percentualReducaoBcStOriginal;
               ValorBcSt=_valorBcStOriginal;
               _valorBcStOriginalCommited=_valorBcStOriginal;
               AliquotaSt=_aliquotaStOriginal;
               _aliquotaStOriginalCommited=_aliquotaStOriginal;
               ValorIcmsSt=_valorIcmsStOriginal;
               _valorIcmsStOriginalCommited=_valorIcmsStOriginal;
               CodigoAntecipacaoSt=_codigoAntecipacaoStOriginal;
               _codigoAntecipacaoStOriginalCommited=_codigoAntecipacaoStOriginal;
               PercentualDiferimento=_percentualDiferimentoOriginal;
               _percentualDiferimentoOriginalCommited=_percentualDiferimentoOriginal;
               ObsDiferimento=_obsDiferimentoOriginal;
               _obsDiferimentoOriginalCommited=_obsDiferimentoOriginal;
               IcmsDiferido=_icmsDiferidoOriginal;
               _icmsDiferidoOriginalCommited=_icmsDiferidoOriginal;
               PercentualBcOperacaoPropria=_percentualBcOperacaoPropriaOriginal;
               _percentualBcOperacaoPropriaOriginalCommited=_percentualBcOperacaoPropriaOriginal;
               SiglaUfDevidoIcms=_siglaUfDevidoIcmsOriginal;
               _siglaUfDevidoIcmsOriginalCommited=_siglaUfDevidoIcmsOriginal;
               ValorBcStRetidoRemetente=_valorBcStRetidoRemetenteOriginal;
               _valorBcStRetidoRemetenteOriginalCommited=_valorBcStRetidoRemetenteOriginal;
               ValorIcmsStRetidoRemetente=_valorIcmsStRetidoRemetenteOriginal;
               _valorIcmsStRetidoRemetenteOriginalCommited=_valorIcmsStRetidoRemetenteOriginal;
               ValorBcStRetidoDestinatario=_valorBcStRetidoDestinatarioOriginal;
               _valorBcStRetidoDestinatarioOriginalCommited=_valorBcStRetidoDestinatarioOriginal;
               ValorIcmsStRetidoDestinatario=_valorIcmsStRetidoDestinatarioOriginal;
               _valorIcmsStRetidoDestinatarioOriginalCommited=_valorIcmsStRetidoDestinatarioOriginal;
               CsoSimples=_csoSimplesOriginal;
               _csoSimplesOriginalCommited=_csoSimplesOriginal;
               AliquotaCreditoSimples=_aliquotaCreditoSimplesOriginal;
               _aliquotaCreditoSimplesOriginalCommited=_aliquotaCreditoSimplesOriginal;
               ValorCreditoIcmsSimples=_valorCreditoIcmsSimplesOriginal;
               _valorCreditoIcmsSimplesOriginalCommited=_valorCreditoIcmsSimplesOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               MotivoDesoneracaoIcms=_motivoDesoneracaoIcmsOriginal;
               _motivoDesoneracaoIcmsOriginalCommited=_motivoDesoneracaoIcmsOriginal;
               ValorCreditoPresumido=_valorCreditoPresumidoOriginal;
               _valorCreditoPresumidoOriginalCommited=_valorCreditoPresumidoOriginal;
               ObservacaoCreditoPresumido=_observacaoCreditoPresumidoOriginal;
               _observacaoCreditoPresumidoOriginalCommited=_observacaoCreditoPresumidoOriginal;
               ValorIcmsOperacao=_valorIcmsOperacaoOriginal;
               _valorIcmsOperacaoOriginalCommited=_valorIcmsOperacaoOriginal;
               ObservacaoCreditoSimples=_observacaoCreditoSimplesOriginal;
               _observacaoCreditoSimplesOriginalCommited=_observacaoCreditoSimplesOriginal;
               FcpRetidoBc=_fcpRetidoBcOriginal;
               _fcpRetidoBcOriginalCommited=_fcpRetidoBcOriginal;
               FcpRetidoAliquota=_fcpRetidoAliquotaOriginal;
               _fcpRetidoAliquotaOriginalCommited=_fcpRetidoAliquotaOriginal;
               FcpRetidoValor=_fcpRetidoValorOriginal;
               _fcpRetidoValorOriginalCommited=_fcpRetidoValorOriginal;
               FcpBc=_fcpBcOriginal;
               _fcpBcOriginalCommited=_fcpBcOriginal;
               FcpAliquota=_fcpAliquotaOriginal;
               _fcpAliquotaOriginalCommited=_fcpAliquotaOriginal;
               FcpValor=_fcpValorOriginal;
               _fcpValorOriginalCommited=_fcpValorOriginal;
               ValorIcmsDesonerado=_valorIcmsDesoneradoOriginal;
               _valorIcmsDesoneradoOriginalCommited=_valorIcmsDesoneradoOriginal;

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
       if (_nfItemOriginal!=null)
       {
          dirty = !_nfItemOriginal.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _origemOriginal != Origem;
      if (dirty) return true;
       dirty = _cstOriginal != Cst;
      if (dirty) return true;
       dirty = _modalidadeBcIcmsOriginal != ModalidadeBcIcms;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginal != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _valorBcOriginal != ValorBc;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
       dirty = _valorIcmsOriginal != ValorIcms;
      if (dirty) return true;
       dirty = _modalidadeBcStOriginal != ModalidadeBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginal != PercentualMvaSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginal != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _valorBcStOriginal != ValorBcSt;
      if (dirty) return true;
       dirty = _aliquotaStOriginal != AliquotaSt;
      if (dirty) return true;
       dirty = _valorIcmsStOriginal != ValorIcmsSt;
      if (dirty) return true;
       dirty = _codigoAntecipacaoStOriginal != CodigoAntecipacaoSt;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginal != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginal != ObsDiferimento;
      if (dirty) return true;
       dirty = _icmsDiferidoOriginal != IcmsDiferido;
      if (dirty) return true;
       dirty = _percentualBcOperacaoPropriaOriginal != PercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _siglaUfDevidoIcmsOriginal != SiglaUfDevidoIcms;
      if (dirty) return true;
       dirty = _valorBcStRetidoRemetenteOriginal != ValorBcStRetidoRemetente;
      if (dirty) return true;
       dirty = _valorIcmsStRetidoRemetenteOriginal != ValorIcmsStRetidoRemetente;
      if (dirty) return true;
       dirty = _valorBcStRetidoDestinatarioOriginal != ValorBcStRetidoDestinatario;
      if (dirty) return true;
       dirty = _valorIcmsStRetidoDestinatarioOriginal != ValorIcmsStRetidoDestinatario;
      if (dirty) return true;
       dirty = _csoSimplesOriginal != CsoSimples;
      if (dirty) return true;
       dirty = _aliquotaCreditoSimplesOriginal != AliquotaCreditoSimples;
      if (dirty) return true;
       dirty = _valorCreditoIcmsSimplesOriginal != ValorCreditoIcmsSimples;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _motivoDesoneracaoIcmsOriginal != MotivoDesoneracaoIcms;
      if (dirty) return true;
       dirty = _valorCreditoPresumidoOriginal != ValorCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginal != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _valorIcmsOperacaoOriginal != ValorIcmsOperacao;
      if (dirty) return true;
       dirty = _observacaoCreditoSimplesOriginal != ObservacaoCreditoSimples;
      if (dirty) return true;
       dirty = _fcpRetidoBcOriginal != FcpRetidoBc;
      if (dirty) return true;
       dirty = _fcpRetidoAliquotaOriginal != FcpRetidoAliquota;
      if (dirty) return true;
       dirty = _fcpRetidoValorOriginal != FcpRetidoValor;
      if (dirty) return true;
       dirty = _fcpBcOriginal != FcpBc;
      if (dirty) return true;
       dirty = _fcpAliquotaOriginal != FcpAliquota;
      if (dirty) return true;
       dirty = _fcpValorOriginal != FcpValor;
      if (dirty) return true;
       dirty = _valorIcmsDesoneradoOriginal != ValorIcmsDesonerado;

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
       if (_nfItemOriginalCommited!=null)
       {
          dirty = !_nfItemOriginalCommited.Equals(NfItem);
       }
       else
       {
            dirty = NfItem != null;
       }
      if (dirty) return true;
       dirty = _origemOriginalCommited != Origem;
      if (dirty) return true;
       dirty = _cstOriginalCommited != Cst;
      if (dirty) return true;
       dirty = _modalidadeBcIcmsOriginalCommited != ModalidadeBcIcms;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginalCommited != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _valorBcOriginalCommited != ValorBc;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
       dirty = _valorIcmsOriginalCommited != ValorIcms;
      if (dirty) return true;
       dirty = _modalidadeBcStOriginalCommited != ModalidadeBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginalCommited != PercentualMvaSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginalCommited != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _valorBcStOriginalCommited != ValorBcSt;
      if (dirty) return true;
       dirty = _aliquotaStOriginalCommited != AliquotaSt;
      if (dirty) return true;
       dirty = _valorIcmsStOriginalCommited != ValorIcmsSt;
      if (dirty) return true;
       dirty = _codigoAntecipacaoStOriginalCommited != CodigoAntecipacaoSt;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginalCommited != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginalCommited != ObsDiferimento;
      if (dirty) return true;
       dirty = _icmsDiferidoOriginalCommited != IcmsDiferido;
      if (dirty) return true;
       dirty = _percentualBcOperacaoPropriaOriginalCommited != PercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _siglaUfDevidoIcmsOriginalCommited != SiglaUfDevidoIcms;
      if (dirty) return true;
       dirty = _valorBcStRetidoRemetenteOriginalCommited != ValorBcStRetidoRemetente;
      if (dirty) return true;
       dirty = _valorIcmsStRetidoRemetenteOriginalCommited != ValorIcmsStRetidoRemetente;
      if (dirty) return true;
       dirty = _valorBcStRetidoDestinatarioOriginalCommited != ValorBcStRetidoDestinatario;
      if (dirty) return true;
       dirty = _valorIcmsStRetidoDestinatarioOriginalCommited != ValorIcmsStRetidoDestinatario;
      if (dirty) return true;
       dirty = _csoSimplesOriginalCommited != CsoSimples;
      if (dirty) return true;
       dirty = _aliquotaCreditoSimplesOriginalCommited != AliquotaCreditoSimples;
      if (dirty) return true;
       dirty = _valorCreditoIcmsSimplesOriginalCommited != ValorCreditoIcmsSimples;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _motivoDesoneracaoIcmsOriginalCommited != MotivoDesoneracaoIcms;
      if (dirty) return true;
       dirty = _valorCreditoPresumidoOriginalCommited != ValorCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginalCommited != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _valorIcmsOperacaoOriginalCommited != ValorIcmsOperacao;
      if (dirty) return true;
       dirty = _observacaoCreditoSimplesOriginalCommited != ObservacaoCreditoSimples;
      if (dirty) return true;
       dirty = _fcpRetidoBcOriginalCommited != FcpRetidoBc;
      if (dirty) return true;
       dirty = _fcpRetidoAliquotaOriginalCommited != FcpRetidoAliquota;
      if (dirty) return true;
       dirty = _fcpRetidoValorOriginalCommited != FcpRetidoValor;
      if (dirty) return true;
       dirty = _fcpBcOriginalCommited != FcpBc;
      if (dirty) return true;
       dirty = _fcpAliquotaOriginalCommited != FcpAliquota;
      if (dirty) return true;
       dirty = _fcpValorOriginalCommited != FcpValor;
      if (dirty) return true;
       dirty = _valorIcmsDesoneradoOriginalCommited != ValorIcmsDesonerado;

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
             case "NfItem":
                return this.NfItem;
             case "Origem":
                return this.Origem;
             case "Cst":
                return this.Cst;
             case "ModalidadeBcIcms":
                return this.ModalidadeBcIcms;
             case "PercentualReducaoBc":
                return this.PercentualReducaoBc;
             case "ValorBc":
                return this.ValorBc;
             case "Aliquota":
                return this.Aliquota;
             case "ValorIcms":
                return this.ValorIcms;
             case "ModalidadeBcSt":
                return this.ModalidadeBcSt;
             case "PercentualMvaSt":
                return this.PercentualMvaSt;
             case "PercentualReducaoBcSt":
                return this.PercentualReducaoBcSt;
             case "ValorBcSt":
                return this.ValorBcSt;
             case "AliquotaSt":
                return this.AliquotaSt;
             case "ValorIcmsSt":
                return this.ValorIcmsSt;
             case "CodigoAntecipacaoSt":
                return this.CodigoAntecipacaoSt;
             case "PercentualDiferimento":
                return this.PercentualDiferimento;
             case "ObsDiferimento":
                return this.ObsDiferimento;
             case "IcmsDiferido":
                return this.IcmsDiferido;
             case "PercentualBcOperacaoPropria":
                return this.PercentualBcOperacaoPropria;
             case "SiglaUfDevidoIcms":
                return this.SiglaUfDevidoIcms;
             case "ValorBcStRetidoRemetente":
                return this.ValorBcStRetidoRemetente;
             case "ValorIcmsStRetidoRemetente":
                return this.ValorIcmsStRetidoRemetente;
             case "ValorBcStRetidoDestinatario":
                return this.ValorBcStRetidoDestinatario;
             case "ValorIcmsStRetidoDestinatario":
                return this.ValorIcmsStRetidoDestinatario;
             case "CsoSimples":
                return this.CsoSimples;
             case "AliquotaCreditoSimples":
                return this.AliquotaCreditoSimples;
             case "ValorCreditoIcmsSimples":
                return this.ValorCreditoIcmsSimples;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "MotivoDesoneracaoIcms":
                return this.MotivoDesoneracaoIcms;
             case "ValorCreditoPresumido":
                return this.ValorCreditoPresumido;
             case "ObservacaoCreditoPresumido":
                return this.ObservacaoCreditoPresumido;
             case "ValorIcmsOperacao":
                return this.ValorIcmsOperacao;
             case "ObservacaoCreditoSimples":
                return this.ObservacaoCreditoSimples;
             case "FcpRetidoBc":
                return this.FcpRetidoBc;
             case "FcpRetidoAliquota":
                return this.FcpRetidoAliquota;
             case "FcpRetidoValor":
                return this.FcpRetidoValor;
             case "FcpBc":
                return this.FcpBc;
             case "FcpAliquota":
                return this.FcpAliquota;
             case "FcpValor":
                return this.FcpValor;
             case "ValorIcmsDesonerado":
                return this.ValorIcmsDesonerado;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
             if (NfItem!=null)
                NfItem.ChangeSingleConnection(newConnection);
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
                  command.CommandText += " COUNT(nf_item_tributo_icms.id_nf_item_tributo_icms) " ;
               }
               else
               {
               command.CommandText += "nf_item_tributo_icms.id_nf_item, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_origem, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_cst, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_modalidade_bc_icms, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_percentual_reducao_bc, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_bc, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_aliquota, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_icms, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_modalidade_bc_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_percentual_mva_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_percentual_reducao_bc_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_bc_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_aliquota_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_icms_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_codigo_antecipacao_st, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_percentual_diferimento, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_obs_diferimento, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_icms_diferido, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_percentual_bc_operacao_propria, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_sigla_uf_devido_icms, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_bc_st_retido_remetente, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_icms_st_retido_remetente, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_bc_st_retido_destinatario, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_icms_st_retido_destinatario, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_cso_simples, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_aliquota_credito_simples, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_credito_icms_simples, " ;
               command.CommandText += "nf_item_tributo_icms.entity_uid, " ;
               command.CommandText += "nf_item_tributo_icms.version, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_motivo_desoneracao_icms, " ;
               command.CommandText += "nf_item_tributo_icms.id_nf_item_tributo_icms, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_credito_presumido, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_observacao_credito_presumido, " ;
               command.CommandText += "nf_item_tributo_icms.nfc_valor_icms_operacao, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_observacao_credito_simples, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_retido_bc, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_retido_aliquota, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_retido_valor, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_bc, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_aliquota, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_fcp_valor, " ;
               command.CommandText += "nf_item_tributo_icms.ntc_valor_icms_desonerado " ;
               }
               command.CommandText += " FROM  nf_item_tributo_icms ";
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
                        orderByClause += " , ntc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ntc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_item_tributo_icms.id_acs_usuario_ultima_revisao ";
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
                     case "id_nf_item":
                     case "NfItem":
                     orderByClause += " , nf_item_tributo_icms.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "ntc_origem":
                     case "Origem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_cst":
                     case "Cst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_modalidade_bc_icms":
                     case "ModalidadeBcIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_modalidade_bc_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_modalidade_bc_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_percentual_reducao_bc":
                     case "PercentualReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_percentual_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_percentual_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_bc":
                     case "ValorBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_icms":
                     case "ValorIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_modalidade_bc_st":
                     case "ModalidadeBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_modalidade_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_modalidade_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_percentual_mva_st":
                     case "PercentualMvaSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_percentual_mva_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_percentual_mva_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_percentual_reducao_bc_st":
                     case "PercentualReducaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_percentual_reducao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_percentual_reducao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_bc_st":
                     case "ValorBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_aliquota_st":
                     case "AliquotaSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_aliquota_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_aliquota_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_icms_st":
                     case "ValorIcmsSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_icms_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_icms_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_codigo_antecipacao_st":
                     case "CodigoAntecipacaoSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_codigo_antecipacao_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_codigo_antecipacao_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_percentual_diferimento":
                     case "PercentualDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_percentual_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_percentual_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_obs_diferimento":
                     case "ObsDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_obs_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_obs_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_icms_diferido":
                     case "IcmsDiferido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_icms_diferido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_icms_diferido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_percentual_bc_operacao_propria":
                     case "PercentualBcOperacaoPropria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_percentual_bc_operacao_propria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_percentual_bc_operacao_propria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_sigla_uf_devido_icms":
                     case "SiglaUfDevidoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_sigla_uf_devido_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_sigla_uf_devido_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_bc_st_retido_remetente":
                     case "ValorBcStRetidoRemetente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_bc_st_retido_remetente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_bc_st_retido_remetente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_icms_st_retido_remetente":
                     case "ValorIcmsStRetidoRemetente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_icms_st_retido_remetente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_icms_st_retido_remetente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_bc_st_retido_destinatario":
                     case "ValorBcStRetidoDestinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_bc_st_retido_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_bc_st_retido_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_icms_st_retido_destinatario":
                     case "ValorIcmsStRetidoDestinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_icms_st_retido_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_icms_st_retido_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_cso_simples":
                     case "CsoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_cso_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_cso_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_aliquota_credito_simples":
                     case "AliquotaCreditoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_aliquota_credito_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_aliquota_credito_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_credito_icms_simples":
                     case "ValorCreditoIcmsSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_credito_icms_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_credito_icms_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_item_tributo_icms.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_motivo_desoneracao_icms":
                     case "MotivoDesoneracaoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_motivo_desoneracao_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_motivo_desoneracao_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_item_tributo_icms":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.id_nf_item_tributo_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.id_nf_item_tributo_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_credito_presumido":
                     case "ValorCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_observacao_credito_presumido":
                     case "ObservacaoCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_observacao_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_observacao_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "nfc_valor_icms_operacao":
                     case "ValorIcmsOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.nfc_valor_icms_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.nfc_valor_icms_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_observacao_credito_simples":
                     case "ObservacaoCreditoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_item_tributo_icms.ntc_observacao_credito_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_observacao_credito_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_retido_bc":
                     case "FcpRetidoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_retido_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_retido_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_retido_aliquota":
                     case "FcpRetidoAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_retido_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_retido_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_retido_valor":
                     case "FcpRetidoValor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_retido_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_retido_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_bc":
                     case "FcpBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_aliquota":
                     case "FcpAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_fcp_valor":
                     case "FcpValor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_fcp_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_fcp_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ntc_valor_icms_desonerado":
                     case "ValorIcmsDesonerado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_item_tributo_icms.ntc_valor_icms_desonerado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_item_tributo_icms.ntc_valor_icms_desonerado) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_cst")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_codigo_antecipacao_st")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_codigo_antecipacao_st) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_codigo_antecipacao_st) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_obs_diferimento")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_obs_diferimento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_obs_diferimento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_sigla_uf_devido_icms")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_sigla_uf_devido_icms) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_sigla_uf_devido_icms) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_observacao_credito_presumido")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_observacao_credito_presumido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_observacao_credito_presumido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ntc_observacao_credito_simples")) 
                        {
                           whereClause += " OR UPPER(nf_item_tributo_icms.ntc_observacao_credito_simples) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_item_tributo_icms.ntc_observacao_credito_simples) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "NfItem" || parametro.FieldName == "id_nf_item")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IWTNF.Entidades.Entidades.NfItemClass)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IWTNF.Entidades.Entidades.NfItemClass");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.id_nf_item = :nf_item_tributo_icms_NfItem_7945 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_NfItem_7945", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Origem" || parametro.FieldName == "ntc_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is OrigemMercadoria)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo OrigemMercadoria");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_origem = :nf_item_tributo_icms_Origem_3286 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_Origem_3286", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cst" || parametro.FieldName == "ntc_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cst LIKE :nf_item_tributo_icms_Cst_8917 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_Cst_8917", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeBcIcms" || parametro.FieldName == "ntc_modalidade_bc_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeDeterminacaoBCICMS)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeDeterminacaoBCICMS");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_modalidade_bc_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_modalidade_bc_icms = :nf_item_tributo_icms_ModalidadeBcIcms_7353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ModalidadeBcIcms_7353", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBc" || parametro.FieldName == "ntc_percentual_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_reducao_bc = :nf_item_tributo_icms_PercentualReducaoBc_5881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_PercentualReducaoBc_5881", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBc" || parametro.FieldName == "ntc_valor_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc = :nf_item_tributo_icms_ValorBc_1467 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorBc_1467", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "ntc_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota = :nf_item_tributo_icms_Aliquota_3034 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_Aliquota_3034", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcms" || parametro.FieldName == "ntc_valor_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms = :nf_item_tributo_icms_ValorIcms_253 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcms_253", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeBcSt" || parametro.FieldName == "ntc_modalidade_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeDeterminacaoBCICMSST)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeDeterminacaoBCICMSST");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_modalidade_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_modalidade_bc_st = :nf_item_tributo_icms_ModalidadeBcSt_121 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ModalidadeBcSt_121", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualMvaSt" || parametro.FieldName == "ntc_percentual_mva_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_mva_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_mva_st = :nf_item_tributo_icms_PercentualMvaSt_1587 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_PercentualMvaSt_1587", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBcSt" || parametro.FieldName == "ntc_percentual_reducao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_reducao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_reducao_bc_st = :nf_item_tributo_icms_PercentualReducaoBcSt_3279 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_PercentualReducaoBcSt_3279", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBcSt" || parametro.FieldName == "ntc_valor_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st = :nf_item_tributo_icms_ValorBcSt_4459 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorBcSt_4459", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaSt" || parametro.FieldName == "ntc_aliquota_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota_st = :nf_item_tributo_icms_AliquotaSt_1765 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_AliquotaSt_1765", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsSt" || parametro.FieldName == "ntc_valor_icms_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st = :nf_item_tributo_icms_ValorIcmsSt_8501 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcmsSt_8501", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAntecipacaoSt" || parametro.FieldName == "ntc_codigo_antecipacao_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_codigo_antecipacao_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_codigo_antecipacao_st LIKE :nf_item_tributo_icms_CodigoAntecipacaoSt_3791 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_CodigoAntecipacaoSt_3791", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualDiferimento" || parametro.FieldName == "ntc_percentual_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_diferimento = :nf_item_tributo_icms_PercentualDiferimento_9171 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_PercentualDiferimento_9171", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsDiferimento" || parametro.FieldName == "ntc_obs_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_obs_diferimento LIKE :nf_item_tributo_icms_ObsDiferimento_922 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObsDiferimento_922", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsDiferido" || parametro.FieldName == "ntc_icms_diferido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_icms_diferido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_icms_diferido = :nf_item_tributo_icms_IcmsDiferido_3361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_IcmsDiferido_3361", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualBcOperacaoPropria" || parametro.FieldName == "ntc_percentual_bc_operacao_propria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_bc_operacao_propria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_percentual_bc_operacao_propria = :nf_item_tributo_icms_PercentualBcOperacaoPropria_7868 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_PercentualBcOperacaoPropria_7868", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfDevidoIcms" || parametro.FieldName == "ntc_sigla_uf_devido_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_sigla_uf_devido_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_sigla_uf_devido_icms LIKE :nf_item_tributo_icms_SiglaUfDevidoIcms_6008 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_SiglaUfDevidoIcms_6008", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBcStRetidoRemetente" || parametro.FieldName == "ntc_valor_bc_st_retido_remetente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st_retido_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st_retido_remetente = :nf_item_tributo_icms_ValorBcStRetidoRemetente_346 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorBcStRetidoRemetente_346", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsStRetidoRemetente" || parametro.FieldName == "ntc_valor_icms_st_retido_remetente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st_retido_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st_retido_remetente = :nf_item_tributo_icms_ValorIcmsStRetidoRemetente_6081 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcmsStRetidoRemetente_6081", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBcStRetidoDestinatario" || parametro.FieldName == "ntc_valor_bc_st_retido_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st_retido_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_bc_st_retido_destinatario = :nf_item_tributo_icms_ValorBcStRetidoDestinatario_818 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorBcStRetidoDestinatario_818", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsStRetidoDestinatario" || parametro.FieldName == "ntc_valor_icms_st_retido_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st_retido_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_st_retido_destinatario = :nf_item_tributo_icms_ValorIcmsStRetidoDestinatario_5883 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcmsStRetidoDestinatario_5883", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CsoSimples" || parametro.FieldName == "ntc_cso_simples")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cso_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cso_simples = :nf_item_tributo_icms_CsoSimples_7809 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_CsoSimples_7809", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaCreditoSimples" || parametro.FieldName == "ntc_aliquota_credito_simples")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_aliquota_credito_simples = :nf_item_tributo_icms_AliquotaCreditoSimples_1685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_AliquotaCreditoSimples_1685", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorCreditoIcmsSimples" || parametro.FieldName == "ntc_valor_credito_icms_simples")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_credito_icms_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_credito_icms_simples = :nf_item_tributo_icms_ValorCreditoIcmsSimples_5609 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorCreditoIcmsSimples_5609", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_item_tributo_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.entity_uid LIKE :nf_item_tributo_icms_EntityUid_6830 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_EntityUid_6830", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_item_tributo_icms.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.version = :nf_item_tributo_icms_Version_7602 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_Version_7602", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoDesoneracaoIcms" || parametro.FieldName == "ntc_motivo_desoneracao_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_motivo_desoneracao_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_motivo_desoneracao_icms = :nf_item_tributo_icms_MotivoDesoneracaoIcms_2790 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_MotivoDesoneracaoIcms_2790", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_item_tributo_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.id_nf_item_tributo_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.id_nf_item_tributo_icms = :nf_item_tributo_icms_ID_6423 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ID_6423", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorCreditoPresumido" || parametro.FieldName == "ntc_valor_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_credito_presumido = :nf_item_tributo_icms_ValorCreditoPresumido_6225 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorCreditoPresumido_6225", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoPresumido" || parametro.FieldName == "ntc_observacao_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_presumido LIKE :nf_item_tributo_icms_ObservacaoCreditoPresumido_8239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObservacaoCreditoPresumido_8239", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsOperacao" || parametro.FieldName == "nfc_valor_icms_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.nfc_valor_icms_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.nfc_valor_icms_operacao = :nf_item_tributo_icms_ValorIcmsOperacao_9721 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcmsOperacao_9721", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoSimples" || parametro.FieldName == "ntc_observacao_credito_simples")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_simples LIKE :nf_item_tributo_icms_ObservacaoCreditoSimples_4239 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObservacaoCreditoSimples_4239", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoBc" || parametro.FieldName == "ntc_fcp_retido_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_bc = :nf_item_tributo_icms_FcpRetidoBc_6859 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpRetidoBc_6859", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoAliquota" || parametro.FieldName == "ntc_fcp_retido_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_aliquota = :nf_item_tributo_icms_FcpRetidoAliquota_3862 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpRetidoAliquota_3862", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoValor" || parametro.FieldName == "ntc_fcp_retido_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_retido_valor = :nf_item_tributo_icms_FcpRetidoValor_938 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpRetidoValor_938", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpBc" || parametro.FieldName == "ntc_fcp_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_bc = :nf_item_tributo_icms_FcpBc_2023 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpBc_2023", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpAliquota" || parametro.FieldName == "ntc_fcp_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_aliquota = :nf_item_tributo_icms_FcpAliquota_4267 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpAliquota_4267", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpValor" || parametro.FieldName == "ntc_fcp_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_fcp_valor = :nf_item_tributo_icms_FcpValor_4949 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_FcpValor_4949", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsDesonerado" || parametro.FieldName == "ntc_valor_icms_desonerado")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_desonerado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_valor_icms_desonerado = :nf_item_tributo_icms_ValorIcmsDesonerado_6511 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ValorIcmsDesonerado_6511", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CstExato" || parametro.FieldName == "CstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_cst LIKE :nf_item_tributo_icms_Cst_373 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_Cst_373", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAntecipacaoStExato" || parametro.FieldName == "CodigoAntecipacaoStExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_codigo_antecipacao_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_codigo_antecipacao_st LIKE :nf_item_tributo_icms_CodigoAntecipacaoSt_2838 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_CodigoAntecipacaoSt_2838", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsDiferimentoExato" || parametro.FieldName == "ObsDiferimentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_obs_diferimento LIKE :nf_item_tributo_icms_ObsDiferimento_8078 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObsDiferimento_8078", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfDevidoIcmsExato" || parametro.FieldName == "SiglaUfDevidoIcmsExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_sigla_uf_devido_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_sigla_uf_devido_icms LIKE :nf_item_tributo_icms_SiglaUfDevidoIcms_9629 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_SiglaUfDevidoIcms_9629", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_item_tributo_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.entity_uid LIKE :nf_item_tributo_icms_EntityUid_7674 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_EntityUid_7674", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoPresumidoExato" || parametro.FieldName == "ObservacaoCreditoPresumidoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_presumido LIKE :nf_item_tributo_icms_ObservacaoCreditoPresumido_9486 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObservacaoCreditoPresumido_9486", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoSimplesExato" || parametro.FieldName == "ObservacaoCreditoSimplesExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_item_tributo_icms.ntc_observacao_credito_simples LIKE :nf_item_tributo_icms_ObservacaoCreditoSimples_1984 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_item_tributo_icms_ObservacaoCreditoSimples_1984", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfItemTributoIcmsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfItemTributoIcmsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfItemTributoIcmsClass), Convert.ToInt32(read["id_nf_item_tributo_icms"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfItemTributoIcmsClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     if (read["id_nf_item"] != DBNull.Value)
                     {
                        entidade.NfItem = (IWTNF.Entidades.Entidades.NfItemClass)IWTNF.Entidades.Entidades.NfItemClass.GetEntidade(Convert.ToInt32(read["id_nf_item"]),UsuarioAtual, SingleConnection, operacao.Value);
                     }
                     else
                     {
                        entidade.NfItem = null ;
                     }
                     entidade.Origem = (OrigemMercadoria) (read["ntc_origem"] != DBNull.Value ? Enum.ToObject(typeof(OrigemMercadoria), read["ntc_origem"]) : null);
                     entidade.Cst = (read["ntc_cst"] != DBNull.Value ? read["ntc_cst"].ToString() : null);
                     entidade.ModalidadeBcIcms = (ModalidadeDeterminacaoBCICMS) (read["ntc_modalidade_bc_icms"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), read["ntc_modalidade_bc_icms"]) : null);
                     entidade.PercentualReducaoBc = (double)read["ntc_percentual_reducao_bc"];
                     entidade.ValorBc = (double)read["ntc_valor_bc"];
                     entidade.Aliquota = (double)read["ntc_aliquota"];
                     entidade.ValorIcms = (double)read["ntc_valor_icms"];
                     entidade.ModalidadeBcSt = (ModalidadeDeterminacaoBCICMSST) (read["ntc_modalidade_bc_st"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), read["ntc_modalidade_bc_st"]) : null);
                     entidade.PercentualMvaSt = (double)read["ntc_percentual_mva_st"];
                     entidade.PercentualReducaoBcSt = (double)read["ntc_percentual_reducao_bc_st"];
                     entidade.ValorBcSt = (double)read["ntc_valor_bc_st"];
                     entidade.AliquotaSt = (double)read["ntc_aliquota_st"];
                     entidade.ValorIcmsSt = (double)read["ntc_valor_icms_st"];
                     entidade.CodigoAntecipacaoSt = (read["ntc_codigo_antecipacao_st"] != DBNull.Value ? read["ntc_codigo_antecipacao_st"].ToString() : null);
                     entidade.PercentualDiferimento = (double)read["ntc_percentual_diferimento"];
                     entidade.ObsDiferimento = (read["ntc_obs_diferimento"] != DBNull.Value ? read["ntc_obs_diferimento"].ToString() : null);
                     entidade.IcmsDiferido = (double)read["ntc_icms_diferido"];
                     entidade.PercentualBcOperacaoPropria = (double)read["ntc_percentual_bc_operacao_propria"];
                     entidade.SiglaUfDevidoIcms = (read["ntc_sigla_uf_devido_icms"] != DBNull.Value ? read["ntc_sigla_uf_devido_icms"].ToString() : null);
                     entidade.ValorBcStRetidoRemetente = (double)read["ntc_valor_bc_st_retido_remetente"];
                     entidade.ValorIcmsStRetidoRemetente = (double)read["ntc_valor_icms_st_retido_remetente"];
                     entidade.ValorBcStRetidoDestinatario = (double)read["ntc_valor_bc_st_retido_destinatario"];
                     entidade.ValorIcmsStRetidoDestinatario = (double)read["ntc_valor_icms_st_retido_destinatario"];
                     entidade.CsoSimples = read["ntc_cso_simples"] as int?;
                     entidade.AliquotaCreditoSimples = (double)read["ntc_aliquota_credito_simples"];
                     entidade.ValorCreditoIcmsSimples = (double)read["ntc_valor_credito_icms_simples"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.MotivoDesoneracaoIcms = read["ntc_motivo_desoneracao_icms"] as short?;
                     entidade.ID = Convert.ToInt64(read["id_nf_item_tributo_icms"]);
                     entidade.ValorCreditoPresumido = read["ntc_valor_credito_presumido"] as double?;
                     entidade.ObservacaoCreditoPresumido = (read["ntc_observacao_credito_presumido"] != DBNull.Value ? read["ntc_observacao_credito_presumido"].ToString() : null);
                     entidade.ValorIcmsOperacao = read["nfc_valor_icms_operacao"] as double?;
                     entidade.ObservacaoCreditoSimples = (read["ntc_observacao_credito_simples"] != DBNull.Value ? read["ntc_observacao_credito_simples"].ToString() : null);
                     entidade.FcpRetidoBc = read["ntc_fcp_retido_bc"] as double?;
                     entidade.FcpRetidoAliquota = read["ntc_fcp_retido_aliquota"] as double?;
                     entidade.FcpRetidoValor = read["ntc_fcp_retido_valor"] as double?;
                     entidade.FcpBc = read["ntc_fcp_bc"] as double?;
                     entidade.FcpAliquota = read["ntc_fcp_aliquota"] as double?;
                     entidade.FcpValor = read["ntc_fcp_valor"] as double?;
                     entidade.ValorIcmsDesonerado = (double)read["ntc_valor_icms_desonerado"];
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfItemTributoIcmsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
