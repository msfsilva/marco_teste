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
     [Table("nf_produto_icms","npc")]
     public class NfProdutoIcmsBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do NfProdutoIcmsClass";
protected const string ErroDelete = "Erro ao excluir o NfProdutoIcmsClass  ";
protected const string ErroSave = "Erro ao salvar o NfProdutoIcmsClass.";
protected const string ErroCstObrigatorio = "O campo Cst é obrigatório";
protected const string ErroCstComprimento = "O campo Cst deve ter no máximo 3 caracteres";
protected const string ErroCodigoAntecipacaoStObrigatorio = "O campo CodigoAntecipacaoSt é obrigatório";
protected const string ErroCodigoAntecipacaoStComprimento = "O campo CodigoAntecipacaoSt deve ter no máximo 1 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroNfItemObrigatorio = "O campo NfItem é obrigatório";
protected const string ErroValidate = "Erro ao validar os dados do NfProdutoIcmsClass.";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade NfProdutoIcmsClass está sendo utilizada.";
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

       protected string _cstOriginal{get;private set;}
       private string _cstOriginalCommited{get; set;}
        private string _valueCst;
         [Column("npc_cst")]
        public virtual string Cst
         { 
            get { return this._valueCst; } 
            set 
            { 
                if (this._valueCst == value)return;
                 this._valueCst = value; 
            } 
        } 

       protected OrigemMercadoria _origemOriginal{get;private set;}
       private OrigemMercadoria _origemOriginalCommited{get; set;}
        private OrigemMercadoria _valueOrigem;
         [Column("npc_origem")]
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

       protected ModalidadeDeterminacaoBCICMS _modalidadeDeterminacaoBcOriginal{get;private set;}
       private ModalidadeDeterminacaoBCICMS _modalidadeDeterminacaoBcOriginalCommited{get; set;}
        private ModalidadeDeterminacaoBCICMS _valueModalidadeDeterminacaoBc;
         [Column("npc_modalidade_determinacao_bc")]
        public virtual ModalidadeDeterminacaoBCICMS ModalidadeDeterminacaoBc
         { 
            get { return this._valueModalidadeDeterminacaoBc; } 
            set 
            { 
                if (this._valueModalidadeDeterminacaoBc == value)return;
                 this._valueModalidadeDeterminacaoBc = value; 
            } 
        } 

        public bool ModalidadeDeterminacaoBc_MargemValorAgregado
         { 
            get { return this._valueModalidadeDeterminacaoBc == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.MargemValorAgregado; } 
            set { if (value) this._valueModalidadeDeterminacaoBc = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.MargemValorAgregado; }
         } 

        public bool ModalidadeDeterminacaoBc_Pauta
         { 
            get { return this._valueModalidadeDeterminacaoBc == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.Pauta; } 
            set { if (value) this._valueModalidadeDeterminacaoBc = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.Pauta; }
         } 

        public bool ModalidadeDeterminacaoBc_PrecoTabeladoMax
         { 
            get { return this._valueModalidadeDeterminacaoBc == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.PrecoTabeladoMax; } 
            set { if (value) this._valueModalidadeDeterminacaoBc = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.PrecoTabeladoMax; }
         } 

        public bool ModalidadeDeterminacaoBc_ValorOperacao
         { 
            get { return this._valueModalidadeDeterminacaoBc == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.ValorOperacao; } 
            set { if (value) this._valueModalidadeDeterminacaoBc = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMS.ValorOperacao; }
         } 

       protected double _aliquotaOriginal{get;private set;}
       private double _aliquotaOriginalCommited{get; set;}
        private double _valueAliquota;
         [Column("npc_aliquota")]
        public virtual double Aliquota
         { 
            get { return this._valueAliquota; } 
            set 
            { 
                if (this._valueAliquota == value)return;
                 this._valueAliquota = value; 
            } 
        } 

       protected double _aliquotaStOriginal{get;private set;}
       private double _aliquotaStOriginalCommited{get; set;}
        private double _valueAliquotaSt;
         [Column("npc_aliquota_st")]
        public virtual double AliquotaSt
         { 
            get { return this._valueAliquotaSt; } 
            set 
            { 
                if (this._valueAliquotaSt == value)return;
                 this._valueAliquotaSt = value; 
            } 
        } 

       protected double _percentualReducaoBcOriginal{get;private set;}
       private double _percentualReducaoBcOriginalCommited{get; set;}
        private double _valuePercentualReducaoBc;
         [Column("npc_percentual_reducao_bc")]
        public virtual double PercentualReducaoBc
         { 
            get { return this._valuePercentualReducaoBc; } 
            set 
            { 
                if (this._valuePercentualReducaoBc == value)return;
                 this._valuePercentualReducaoBc = value; 
            } 
        } 

       protected ModalidadeDeterminacaoBCICMSST _modalidadeDeterminacaoBcStOriginal{get;private set;}
       private ModalidadeDeterminacaoBCICMSST _modalidadeDeterminacaoBcStOriginalCommited{get; set;}
        private ModalidadeDeterminacaoBCICMSST _valueModalidadeDeterminacaoBcSt;
         [Column("npc_modalidade_determinacao_bc_st")]
        public virtual ModalidadeDeterminacaoBCICMSST ModalidadeDeterminacaoBcSt
         { 
            get { return this._valueModalidadeDeterminacaoBcSt; } 
            set 
            { 
                if (this._valueModalidadeDeterminacaoBcSt == value)return;
                 this._valueModalidadeDeterminacaoBcSt = value; 
            } 
        } 

        public bool ModalidadeDeterminacaoBcSt_PrecoTabelado
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.PrecoTabelado; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.PrecoTabelado; }
         } 

        public bool ModalidadeDeterminacaoBcSt_ListaNegativa
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNegativa; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNegativa; }
         } 

        public bool ModalidadeDeterminacaoBcSt_ListaPositiva
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaPositiva; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaPositiva; }
         } 

        public bool ModalidadeDeterminacaoBcSt_ListaNeutra
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNeutra; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.ListaNeutra; }
         } 

        public bool ModalidadeDeterminacaoBcSt_MargemValorAgregado
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.MargemValorAgregado; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.MargemValorAgregado; }
         } 

        public bool ModalidadeDeterminacaoBcSt_Pauta
         { 
            get { return this._valueModalidadeDeterminacaoBcSt == IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.Pauta; } 
            set { if (value) this._valueModalidadeDeterminacaoBcSt = IWTNF.Entidades.Base.ModalidadeDeterminacaoBCICMSST.Pauta; }
         } 

       protected double _percentualReducaoBcStOriginal{get;private set;}
       private double _percentualReducaoBcStOriginalCommited{get; set;}
        private double _valuePercentualReducaoBcSt;
         [Column("npc_percentual_reducao_bc_st")]
        public virtual double PercentualReducaoBcSt
         { 
            get { return this._valuePercentualReducaoBcSt; } 
            set 
            { 
                if (this._valuePercentualReducaoBcSt == value)return;
                 this._valuePercentualReducaoBcSt = value; 
            } 
        } 

       protected double _percentualMvaStOriginal{get;private set;}
       private double _percentualMvaStOriginalCommited{get; set;}
        private double _valuePercentualMvaSt;
         [Column("npc_percentual_mva_st")]
        public virtual double PercentualMvaSt
         { 
            get { return this._valuePercentualMvaSt; } 
            set 
            { 
                if (this._valuePercentualMvaSt == value)return;
                 this._valuePercentualMvaSt = value; 
            } 
        } 

       protected string _codigoAntecipacaoStOriginal{get;private set;}
       private string _codigoAntecipacaoStOriginalCommited{get; set;}
        private string _valueCodigoAntecipacaoSt;
         [Column("npc_codigo_antecipacao_st")]
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
         [Column("npc_percentual_diferimento")]
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
         [Column("npc_obs_diferimento")]
        public virtual string ObsDiferimento
         { 
            get { return this._valueObsDiferimento; } 
            set 
            { 
                if (this._valueObsDiferimento == value)return;
                 this._valueObsDiferimento = value; 
            } 
        } 

       protected double _percentualBcOperacaoPropriaOriginal{get;private set;}
       private double _percentualBcOperacaoPropriaOriginalCommited{get; set;}
        private double _valuePercentualBcOperacaoPropria;
         [Column("npc_percentual_bc_operacao_propria")]
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
         [Column("npc_sigla_uf_devido_icms")]
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
         [Column("npc_valor_bc_st_retido_remetente")]
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
         [Column("npc_valor_icms_st_retido_remetente")]
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
         [Column("npc_valor_bc_st_retido_destinatario")]
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
         [Column("npc_valor_icms_st_retido_destinatario")]
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
         [Column("npc_cso_simples")]
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
         [Column("npc_aliquota_credito_simples")]
        public virtual double AliquotaCreditoSimples
         { 
            get { return this._valueAliquotaCreditoSimples; } 
            set 
            { 
                if (this._valueAliquotaCreditoSimples == value)return;
                 this._valueAliquotaCreditoSimples = value; 
            } 
        } 

       protected short? _motivoDesoneracaoIcmsOriginal{get;private set;}
       private short? _motivoDesoneracaoIcmsOriginalCommited{get; set;}
        private short? _valueMotivoDesoneracaoIcms;
         [Column("npc_motivo_desoneracao_icms")]
        public virtual short? MotivoDesoneracaoIcms
         { 
            get { return this._valueMotivoDesoneracaoIcms; } 
            set 
            { 
                if (this._valueMotivoDesoneracaoIcms == value)return;
                 this._valueMotivoDesoneracaoIcms = value; 
            } 
        } 

       protected double? _percentualCreditoPresumidoOriginal{get;private set;}
       private double? _percentualCreditoPresumidoOriginalCommited{get; set;}
        private double? _valuePercentualCreditoPresumido;
         [Column("npc_percentual_credito_presumido")]
        public virtual double? PercentualCreditoPresumido
         { 
            get { return this._valuePercentualCreditoPresumido; } 
            set 
            { 
                if (this._valuePercentualCreditoPresumido == value)return;
                 this._valuePercentualCreditoPresumido = value; 
            } 
        } 

       protected double? _percentualLimiteCreditoPresumidoOriginal{get;private set;}
       private double? _percentualLimiteCreditoPresumidoOriginalCommited{get; set;}
        private double? _valuePercentualLimiteCreditoPresumido;
         [Column("npc_percentual_limite_credito_presumido")]
        public virtual double? PercentualLimiteCreditoPresumido
         { 
            get { return this._valuePercentualLimiteCreditoPresumido; } 
            set 
            { 
                if (this._valuePercentualLimiteCreditoPresumido == value)return;
                 this._valuePercentualLimiteCreditoPresumido = value; 
            } 
        } 

       protected string _observacaoCreditoPresumidoOriginal{get;private set;}
       private string _observacaoCreditoPresumidoOriginalCommited{get; set;}
        private string _valueObservacaoCreditoPresumido;
         [Column("npc_observacao_credito_presumido")]
        public virtual string ObservacaoCreditoPresumido
         { 
            get { return this._valueObservacaoCreditoPresumido; } 
            set 
            { 
                if (this._valueObservacaoCreditoPresumido == value)return;
                 this._valueObservacaoCreditoPresumido = value; 
            } 
        } 

       protected string _observacaoCreditoSimplesOriginal{get;private set;}
       private string _observacaoCreditoSimplesOriginalCommited{get; set;}
        private string _valueObservacaoCreditoSimples;
         [Column("npc_observacao_credito_simples")]
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
         [Column("npc_fcp_retido_bc")]
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
         [Column("npc_fcp_retido_aliquota")]
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
         [Column("npc_fcp_retido_valor")]
        public virtual double? FcpRetidoValor
         { 
            get { return this._valueFcpRetidoValor; } 
            set 
            { 
                if (this._valueFcpRetidoValor == value)return;
                 this._valueFcpRetidoValor = value; 
            } 
        } 

       protected double? _aliquotaSuportadaConsumidorFinalOriginal{get;private set;}
       private double? _aliquotaSuportadaConsumidorFinalOriginalCommited{get; set;}
        private double? _valueAliquotaSuportadaConsumidorFinal;
         [Column("npc_aliquota_suportada_consumidor_final")]
        public virtual double? AliquotaSuportadaConsumidorFinal
         { 
            get { return this._valueAliquotaSuportadaConsumidorFinal; } 
            set 
            { 
                if (this._valueAliquotaSuportadaConsumidorFinal == value)return;
                 this._valueAliquotaSuportadaConsumidorFinal = value; 
            } 
        } 

       protected bool _compoeTotalOriginal{get;private set;}
       private bool _compoeTotalOriginalCommited{get; set;}
        private bool _valueCompoeTotal;
         [Column("npc_compoe_total")]
        public virtual bool CompoeTotal
         { 
            get { return this._valueCompoeTotal; } 
            set 
            { 
                if (this._valueCompoeTotal == value)return;
                 this._valueCompoeTotal = value; 
            } 
        } 

        public NfProdutoIcmsBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.PercentualBcOperacaoPropria = 0;
           this.ValorBcStRetidoRemetente = 0;
           this.ValorIcmsStRetidoRemetente = 0;
           this.ValorBcStRetidoDestinatario = 0;
           this.ValorIcmsStRetidoDestinatario = 0;
           this.AliquotaCreditoSimples = 0;
           this.CompoeTotal = true;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static NfProdutoIcmsClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (NfProdutoIcmsClass) GetEntity(typeof(NfProdutoIcmsClass),id,usuarioAtual,connection, operacao);
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
                    "  public.nf_produto_icms  " +
                    "WHERE " +
                    "  id_nf_produto_icms = :id";
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
                        "  public.nf_produto_icms   " +
                        "SET  " + 
                        "  id_nf_item = :id_nf_item, " + 
                        "  npc_cst = :npc_cst, " + 
                        "  npc_origem = :npc_origem, " + 
                        "  npc_modalidade_determinacao_bc = :npc_modalidade_determinacao_bc, " + 
                        "  npc_aliquota = :npc_aliquota, " + 
                        "  npc_aliquota_st = :npc_aliquota_st, " + 
                        "  npc_percentual_reducao_bc = :npc_percentual_reducao_bc, " + 
                        "  npc_modalidade_determinacao_bc_st = :npc_modalidade_determinacao_bc_st, " + 
                        "  npc_percentual_reducao_bc_st = :npc_percentual_reducao_bc_st, " + 
                        "  npc_percentual_mva_st = :npc_percentual_mva_st, " + 
                        "  npc_codigo_antecipacao_st = :npc_codigo_antecipacao_st, " + 
                        "  npc_percentual_diferimento = :npc_percentual_diferimento, " + 
                        "  npc_obs_diferimento = :npc_obs_diferimento, " + 
                        "  npc_percentual_bc_operacao_propria = :npc_percentual_bc_operacao_propria, " + 
                        "  npc_sigla_uf_devido_icms = :npc_sigla_uf_devido_icms, " + 
                        "  npc_valor_bc_st_retido_remetente = :npc_valor_bc_st_retido_remetente, " + 
                        "  npc_valor_icms_st_retido_remetente = :npc_valor_icms_st_retido_remetente, " + 
                        "  npc_valor_bc_st_retido_destinatario = :npc_valor_bc_st_retido_destinatario, " + 
                        "  npc_valor_icms_st_retido_destinatario = :npc_valor_icms_st_retido_destinatario, " + 
                        "  npc_cso_simples = :npc_cso_simples, " + 
                        "  npc_aliquota_credito_simples = :npc_aliquota_credito_simples, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  npc_motivo_desoneracao_icms = :npc_motivo_desoneracao_icms, " + 
                        "  npc_percentual_credito_presumido = :npc_percentual_credito_presumido, " + 
                        "  npc_percentual_limite_credito_presumido = :npc_percentual_limite_credito_presumido, " + 
                        "  npc_observacao_credito_presumido = :npc_observacao_credito_presumido, " + 
                        "  npc_observacao_credito_simples = :npc_observacao_credito_simples, " + 
                        "  npc_fcp_retido_bc = :npc_fcp_retido_bc, " + 
                        "  npc_fcp_retido_aliquota = :npc_fcp_retido_aliquota, " + 
                        "  npc_fcp_retido_valor = :npc_fcp_retido_valor, " + 
                        "  npc_aliquota_suportada_consumidor_final = :npc_aliquota_suportada_consumidor_final, " + 
                        "  npc_compoe_total = :npc_compoe_total "+
                        "WHERE  " +
                        "  id_nf_produto_icms = :id " +
                        "RETURNING id_nf_produto_icms;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.nf_produto_icms " +
                        "( " +
                        "  id_nf_item , " + 
                        "  npc_cst , " + 
                        "  npc_origem , " + 
                        "  npc_modalidade_determinacao_bc , " + 
                        "  npc_aliquota , " + 
                        "  npc_aliquota_st , " + 
                        "  npc_percentual_reducao_bc , " + 
                        "  npc_modalidade_determinacao_bc_st , " + 
                        "  npc_percentual_reducao_bc_st , " + 
                        "  npc_percentual_mva_st , " + 
                        "  npc_codigo_antecipacao_st , " + 
                        "  npc_percentual_diferimento , " + 
                        "  npc_obs_diferimento , " + 
                        "  npc_percentual_bc_operacao_propria , " + 
                        "  npc_sigla_uf_devido_icms , " + 
                        "  npc_valor_bc_st_retido_remetente , " + 
                        "  npc_valor_icms_st_retido_remetente , " + 
                        "  npc_valor_bc_st_retido_destinatario , " + 
                        "  npc_valor_icms_st_retido_destinatario , " + 
                        "  npc_cso_simples , " + 
                        "  npc_aliquota_credito_simples , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  npc_motivo_desoneracao_icms , " + 
                        "  npc_percentual_credito_presumido , " + 
                        "  npc_percentual_limite_credito_presumido , " + 
                        "  npc_observacao_credito_presumido , " + 
                        "  npc_observacao_credito_simples , " + 
                        "  npc_fcp_retido_bc , " + 
                        "  npc_fcp_retido_aliquota , " + 
                        "  npc_fcp_retido_valor , " + 
                        "  npc_aliquota_suportada_consumidor_final , " + 
                        "  npc_compoe_total  "+
                        ")  " +
                        "VALUES ( " +
                        "  :id_nf_item , " + 
                        "  :npc_cst , " + 
                        "  :npc_origem , " + 
                        "  :npc_modalidade_determinacao_bc , " + 
                        "  :npc_aliquota , " + 
                        "  :npc_aliquota_st , " + 
                        "  :npc_percentual_reducao_bc , " + 
                        "  :npc_modalidade_determinacao_bc_st , " + 
                        "  :npc_percentual_reducao_bc_st , " + 
                        "  :npc_percentual_mva_st , " + 
                        "  :npc_codigo_antecipacao_st , " + 
                        "  :npc_percentual_diferimento , " + 
                        "  :npc_obs_diferimento , " + 
                        "  :npc_percentual_bc_operacao_propria , " + 
                        "  :npc_sigla_uf_devido_icms , " + 
                        "  :npc_valor_bc_st_retido_remetente , " + 
                        "  :npc_valor_icms_st_retido_remetente , " + 
                        "  :npc_valor_bc_st_retido_destinatario , " + 
                        "  :npc_valor_icms_st_retido_destinatario , " + 
                        "  :npc_cso_simples , " + 
                        "  :npc_aliquota_credito_simples , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :npc_motivo_desoneracao_icms , " + 
                        "  :npc_percentual_credito_presumido , " + 
                        "  :npc_percentual_limite_credito_presumido , " + 
                        "  :npc_observacao_credito_presumido , " + 
                        "  :npc_observacao_credito_simples , " + 
                        "  :npc_fcp_retido_bc , " + 
                        "  :npc_fcp_retido_aliquota , " + 
                        "  :npc_fcp_retido_valor , " + 
                        "  :npc_aliquota_suportada_consumidor_final , " + 
                        "  :npc_compoe_total  "+
                        ")RETURNING id_nf_produto_icms;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id_nf_item", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value =  this.NfItem==null ? (object) DBNull.Value : this.NfItem.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_origem", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.Origem);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_modalidade_determinacao_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeDeterminacaoBc);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Aliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_aliquota_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_modalidade_determinacao_bc_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ModalidadeDeterminacaoBcSt);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualReducaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_mva_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualMvaSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_codigo_antecipacao_st", NpgsqlDbType.Char));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CodigoAntecipacaoSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_obs_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObsDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_bc_operacao_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualBcOperacaoPropria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_sigla_uf_devido_icms", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SiglaUfDevidoIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_valor_bc_st_retido_remetente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBcStRetidoRemetente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_valor_icms_st_retido_remetente", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsStRetidoRemetente ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_valor_bc_st_retido_destinatario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorBcStRetidoDestinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_valor_icms_st_retido_destinatario", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ValorIcmsStRetidoDestinatario ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_cso_simples", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CsoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_aliquota_credito_simples", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaCreditoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_motivo_desoneracao_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.MotivoDesoneracaoIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_credito_presumido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_percentual_limite_credito_presumido", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PercentualLimiteCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_observacao_credito_presumido", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoPresumido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_observacao_credito_simples", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ObservacaoCreditoSimples ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_fcp_retido_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_fcp_retido_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_fcp_retido_valor", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.FcpRetidoValor ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_aliquota_suportada_consumidor_final", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.AliquotaSuportadaConsumidorFinal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("npc_compoe_total", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CompoeTotal ?? DBNull.Value;

 
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
        public static NfProdutoIcmsClass CopiarEntidade(NfProdutoIcmsClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               NfProdutoIcmsClass toRet = new NfProdutoIcmsClass(usuario,conn);
 toRet.NfItem= entidadeCopiar.NfItem;
 toRet.Cst= entidadeCopiar.Cst;
 toRet.Origem= entidadeCopiar.Origem;
 toRet.ModalidadeDeterminacaoBc= entidadeCopiar.ModalidadeDeterminacaoBc;
 toRet.Aliquota= entidadeCopiar.Aliquota;
 toRet.AliquotaSt= entidadeCopiar.AliquotaSt;
 toRet.PercentualReducaoBc= entidadeCopiar.PercentualReducaoBc;
 toRet.ModalidadeDeterminacaoBcSt= entidadeCopiar.ModalidadeDeterminacaoBcSt;
 toRet.PercentualReducaoBcSt= entidadeCopiar.PercentualReducaoBcSt;
 toRet.PercentualMvaSt= entidadeCopiar.PercentualMvaSt;
 toRet.CodigoAntecipacaoSt= entidadeCopiar.CodigoAntecipacaoSt;
 toRet.PercentualDiferimento= entidadeCopiar.PercentualDiferimento;
 toRet.ObsDiferimento= entidadeCopiar.ObsDiferimento;
 toRet.PercentualBcOperacaoPropria= entidadeCopiar.PercentualBcOperacaoPropria;
 toRet.SiglaUfDevidoIcms= entidadeCopiar.SiglaUfDevidoIcms;
 toRet.ValorBcStRetidoRemetente= entidadeCopiar.ValorBcStRetidoRemetente;
 toRet.ValorIcmsStRetidoRemetente= entidadeCopiar.ValorIcmsStRetidoRemetente;
 toRet.ValorBcStRetidoDestinatario= entidadeCopiar.ValorBcStRetidoDestinatario;
 toRet.ValorIcmsStRetidoDestinatario= entidadeCopiar.ValorIcmsStRetidoDestinatario;
 toRet.CsoSimples= entidadeCopiar.CsoSimples;
 toRet.AliquotaCreditoSimples= entidadeCopiar.AliquotaCreditoSimples;
 toRet.MotivoDesoneracaoIcms= entidadeCopiar.MotivoDesoneracaoIcms;
 toRet.PercentualCreditoPresumido= entidadeCopiar.PercentualCreditoPresumido;
 toRet.PercentualLimiteCreditoPresumido= entidadeCopiar.PercentualLimiteCreditoPresumido;
 toRet.ObservacaoCreditoPresumido= entidadeCopiar.ObservacaoCreditoPresumido;
 toRet.ObservacaoCreditoSimples= entidadeCopiar.ObservacaoCreditoSimples;
 toRet.FcpRetidoBc= entidadeCopiar.FcpRetidoBc;
 toRet.FcpRetidoAliquota= entidadeCopiar.FcpRetidoAliquota;
 toRet.FcpRetidoValor= entidadeCopiar.FcpRetidoValor;
 toRet.AliquotaSuportadaConsumidorFinal= entidadeCopiar.AliquotaSuportadaConsumidorFinal;
 toRet.CompoeTotal= entidadeCopiar.CompoeTotal;

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
       _cstOriginal = Cst;
       _cstOriginalCommited = _cstOriginal;
       _origemOriginal = Origem;
       _origemOriginalCommited = _origemOriginal;
       _modalidadeDeterminacaoBcOriginal = ModalidadeDeterminacaoBc;
       _modalidadeDeterminacaoBcOriginalCommited = _modalidadeDeterminacaoBcOriginal;
       _aliquotaOriginal = Aliquota;
       _aliquotaOriginalCommited = _aliquotaOriginal;
       _aliquotaStOriginal = AliquotaSt;
       _aliquotaStOriginalCommited = _aliquotaStOriginal;
       _percentualReducaoBcOriginal = PercentualReducaoBc;
       _percentualReducaoBcOriginalCommited = _percentualReducaoBcOriginal;
       _modalidadeDeterminacaoBcStOriginal = ModalidadeDeterminacaoBcSt;
       _modalidadeDeterminacaoBcStOriginalCommited = _modalidadeDeterminacaoBcStOriginal;
       _percentualReducaoBcStOriginal = PercentualReducaoBcSt;
       _percentualReducaoBcStOriginalCommited = _percentualReducaoBcStOriginal;
       _percentualMvaStOriginal = PercentualMvaSt;
       _percentualMvaStOriginalCommited = _percentualMvaStOriginal;
       _codigoAntecipacaoStOriginal = CodigoAntecipacaoSt;
       _codigoAntecipacaoStOriginalCommited = _codigoAntecipacaoStOriginal;
       _percentualDiferimentoOriginal = PercentualDiferimento;
       _percentualDiferimentoOriginalCommited = _percentualDiferimentoOriginal;
       _obsDiferimentoOriginal = ObsDiferimento;
       _obsDiferimentoOriginalCommited = _obsDiferimentoOriginal;
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
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _motivoDesoneracaoIcmsOriginal = MotivoDesoneracaoIcms;
       _motivoDesoneracaoIcmsOriginalCommited = _motivoDesoneracaoIcmsOriginal;
       _percentualCreditoPresumidoOriginal = PercentualCreditoPresumido;
       _percentualCreditoPresumidoOriginalCommited = _percentualCreditoPresumidoOriginal;
       _percentualLimiteCreditoPresumidoOriginal = PercentualLimiteCreditoPresumido;
       _percentualLimiteCreditoPresumidoOriginalCommited = _percentualLimiteCreditoPresumidoOriginal;
       _observacaoCreditoPresumidoOriginal = ObservacaoCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = _observacaoCreditoPresumidoOriginal;
       _observacaoCreditoSimplesOriginal = ObservacaoCreditoSimples;
       _observacaoCreditoSimplesOriginalCommited = _observacaoCreditoSimplesOriginal;
       _fcpRetidoBcOriginal = FcpRetidoBc;
       _fcpRetidoBcOriginalCommited = _fcpRetidoBcOriginal;
       _fcpRetidoAliquotaOriginal = FcpRetidoAliquota;
       _fcpRetidoAliquotaOriginalCommited = _fcpRetidoAliquotaOriginal;
       _fcpRetidoValorOriginal = FcpRetidoValor;
       _fcpRetidoValorOriginalCommited = _fcpRetidoValorOriginal;
       _aliquotaSuportadaConsumidorFinalOriginal = AliquotaSuportadaConsumidorFinal;
       _aliquotaSuportadaConsumidorFinalOriginalCommited = _aliquotaSuportadaConsumidorFinalOriginal;
       _compoeTotalOriginal = CompoeTotal;
       _compoeTotalOriginalCommited = _compoeTotalOriginal;

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
       _cstOriginalCommited = Cst;
       _origemOriginalCommited = Origem;
       _modalidadeDeterminacaoBcOriginalCommited = ModalidadeDeterminacaoBc;
       _aliquotaOriginalCommited = Aliquota;
       _aliquotaStOriginalCommited = AliquotaSt;
       _percentualReducaoBcOriginalCommited = PercentualReducaoBc;
       _modalidadeDeterminacaoBcStOriginalCommited = ModalidadeDeterminacaoBcSt;
       _percentualReducaoBcStOriginalCommited = PercentualReducaoBcSt;
       _percentualMvaStOriginalCommited = PercentualMvaSt;
       _codigoAntecipacaoStOriginalCommited = CodigoAntecipacaoSt;
       _percentualDiferimentoOriginalCommited = PercentualDiferimento;
       _obsDiferimentoOriginalCommited = ObsDiferimento;
       _percentualBcOperacaoPropriaOriginalCommited = PercentualBcOperacaoPropria;
       _siglaUfDevidoIcmsOriginalCommited = SiglaUfDevidoIcms;
       _valorBcStRetidoRemetenteOriginalCommited = ValorBcStRetidoRemetente;
       _valorIcmsStRetidoRemetenteOriginalCommited = ValorIcmsStRetidoRemetente;
       _valorBcStRetidoDestinatarioOriginalCommited = ValorBcStRetidoDestinatario;
       _valorIcmsStRetidoDestinatarioOriginalCommited = ValorIcmsStRetidoDestinatario;
       _csoSimplesOriginalCommited = CsoSimples;
       _aliquotaCreditoSimplesOriginalCommited = AliquotaCreditoSimples;
       _versionOriginalCommited = Version;
       _motivoDesoneracaoIcmsOriginalCommited = MotivoDesoneracaoIcms;
       _percentualCreditoPresumidoOriginalCommited = PercentualCreditoPresumido;
       _percentualLimiteCreditoPresumidoOriginalCommited = PercentualLimiteCreditoPresumido;
       _observacaoCreditoPresumidoOriginalCommited = ObservacaoCreditoPresumido;
       _observacaoCreditoSimplesOriginalCommited = ObservacaoCreditoSimples;
       _fcpRetidoBcOriginalCommited = FcpRetidoBc;
       _fcpRetidoAliquotaOriginalCommited = FcpRetidoAliquota;
       _fcpRetidoValorOriginalCommited = FcpRetidoValor;
       _aliquotaSuportadaConsumidorFinalOriginalCommited = AliquotaSuportadaConsumidorFinal;
       _compoeTotalOriginalCommited = CompoeTotal;

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
               Cst=_cstOriginal;
               _cstOriginalCommited=_cstOriginal;
               Origem=_origemOriginal;
               _origemOriginalCommited=_origemOriginal;
               ModalidadeDeterminacaoBc=_modalidadeDeterminacaoBcOriginal;
               _modalidadeDeterminacaoBcOriginalCommited=_modalidadeDeterminacaoBcOriginal;
               Aliquota=_aliquotaOriginal;
               _aliquotaOriginalCommited=_aliquotaOriginal;
               AliquotaSt=_aliquotaStOriginal;
               _aliquotaStOriginalCommited=_aliquotaStOriginal;
               PercentualReducaoBc=_percentualReducaoBcOriginal;
               _percentualReducaoBcOriginalCommited=_percentualReducaoBcOriginal;
               ModalidadeDeterminacaoBcSt=_modalidadeDeterminacaoBcStOriginal;
               _modalidadeDeterminacaoBcStOriginalCommited=_modalidadeDeterminacaoBcStOriginal;
               PercentualReducaoBcSt=_percentualReducaoBcStOriginal;
               _percentualReducaoBcStOriginalCommited=_percentualReducaoBcStOriginal;
               PercentualMvaSt=_percentualMvaStOriginal;
               _percentualMvaStOriginalCommited=_percentualMvaStOriginal;
               CodigoAntecipacaoSt=_codigoAntecipacaoStOriginal;
               _codigoAntecipacaoStOriginalCommited=_codigoAntecipacaoStOriginal;
               PercentualDiferimento=_percentualDiferimentoOriginal;
               _percentualDiferimentoOriginalCommited=_percentualDiferimentoOriginal;
               ObsDiferimento=_obsDiferimentoOriginal;
               _obsDiferimentoOriginalCommited=_obsDiferimentoOriginal;
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
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               MotivoDesoneracaoIcms=_motivoDesoneracaoIcmsOriginal;
               _motivoDesoneracaoIcmsOriginalCommited=_motivoDesoneracaoIcmsOriginal;
               PercentualCreditoPresumido=_percentualCreditoPresumidoOriginal;
               _percentualCreditoPresumidoOriginalCommited=_percentualCreditoPresumidoOriginal;
               PercentualLimiteCreditoPresumido=_percentualLimiteCreditoPresumidoOriginal;
               _percentualLimiteCreditoPresumidoOriginalCommited=_percentualLimiteCreditoPresumidoOriginal;
               ObservacaoCreditoPresumido=_observacaoCreditoPresumidoOriginal;
               _observacaoCreditoPresumidoOriginalCommited=_observacaoCreditoPresumidoOriginal;
               ObservacaoCreditoSimples=_observacaoCreditoSimplesOriginal;
               _observacaoCreditoSimplesOriginalCommited=_observacaoCreditoSimplesOriginal;
               FcpRetidoBc=_fcpRetidoBcOriginal;
               _fcpRetidoBcOriginalCommited=_fcpRetidoBcOriginal;
               FcpRetidoAliquota=_fcpRetidoAliquotaOriginal;
               _fcpRetidoAliquotaOriginalCommited=_fcpRetidoAliquotaOriginal;
               FcpRetidoValor=_fcpRetidoValorOriginal;
               _fcpRetidoValorOriginalCommited=_fcpRetidoValorOriginal;
               AliquotaSuportadaConsumidorFinal=_aliquotaSuportadaConsumidorFinalOriginal;
               _aliquotaSuportadaConsumidorFinalOriginalCommited=_aliquotaSuportadaConsumidorFinalOriginal;
               CompoeTotal=_compoeTotalOriginal;
               _compoeTotalOriginalCommited=_compoeTotalOriginal;

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
       dirty = _cstOriginal != Cst;
      if (dirty) return true;
       dirty = _origemOriginal != Origem;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcOriginal != ModalidadeDeterminacaoBc;
      if (dirty) return true;
       dirty = _aliquotaOriginal != Aliquota;
      if (dirty) return true;
       dirty = _aliquotaStOriginal != AliquotaSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginal != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcStOriginal != ModalidadeDeterminacaoBcSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginal != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginal != PercentualMvaSt;
      if (dirty) return true;
       dirty = _codigoAntecipacaoStOriginal != CodigoAntecipacaoSt;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginal != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginal != ObsDiferimento;
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
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _motivoDesoneracaoIcmsOriginal != MotivoDesoneracaoIcms;
      if (dirty) return true;
       dirty = _percentualCreditoPresumidoOriginal != PercentualCreditoPresumido;
      if (dirty) return true;
       dirty = _percentualLimiteCreditoPresumidoOriginal != PercentualLimiteCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginal != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoSimplesOriginal != ObservacaoCreditoSimples;
      if (dirty) return true;
       dirty = _fcpRetidoBcOriginal != FcpRetidoBc;
      if (dirty) return true;
       dirty = _fcpRetidoAliquotaOriginal != FcpRetidoAliquota;
      if (dirty) return true;
       dirty = _fcpRetidoValorOriginal != FcpRetidoValor;
      if (dirty) return true;
       dirty = _aliquotaSuportadaConsumidorFinalOriginal != AliquotaSuportadaConsumidorFinal;
      if (dirty) return true;
       dirty = _compoeTotalOriginal != CompoeTotal;

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
       dirty = _cstOriginalCommited != Cst;
      if (dirty) return true;
       dirty = _origemOriginalCommited != Origem;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcOriginalCommited != ModalidadeDeterminacaoBc;
      if (dirty) return true;
       dirty = _aliquotaOriginalCommited != Aliquota;
      if (dirty) return true;
       dirty = _aliquotaStOriginalCommited != AliquotaSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcOriginalCommited != PercentualReducaoBc;
      if (dirty) return true;
       dirty = _modalidadeDeterminacaoBcStOriginalCommited != ModalidadeDeterminacaoBcSt;
      if (dirty) return true;
       dirty = _percentualReducaoBcStOriginalCommited != PercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _percentualMvaStOriginalCommited != PercentualMvaSt;
      if (dirty) return true;
       dirty = _codigoAntecipacaoStOriginalCommited != CodigoAntecipacaoSt;
      if (dirty) return true;
       dirty = _percentualDiferimentoOriginalCommited != PercentualDiferimento;
      if (dirty) return true;
       dirty = _obsDiferimentoOriginalCommited != ObsDiferimento;
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
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _motivoDesoneracaoIcmsOriginalCommited != MotivoDesoneracaoIcms;
      if (dirty) return true;
       dirty = _percentualCreditoPresumidoOriginalCommited != PercentualCreditoPresumido;
      if (dirty) return true;
       dirty = _percentualLimiteCreditoPresumidoOriginalCommited != PercentualLimiteCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoPresumidoOriginalCommited != ObservacaoCreditoPresumido;
      if (dirty) return true;
       dirty = _observacaoCreditoSimplesOriginalCommited != ObservacaoCreditoSimples;
      if (dirty) return true;
       dirty = _fcpRetidoBcOriginalCommited != FcpRetidoBc;
      if (dirty) return true;
       dirty = _fcpRetidoAliquotaOriginalCommited != FcpRetidoAliquota;
      if (dirty) return true;
       dirty = _fcpRetidoValorOriginalCommited != FcpRetidoValor;
      if (dirty) return true;
       dirty = _aliquotaSuportadaConsumidorFinalOriginalCommited != AliquotaSuportadaConsumidorFinal;
      if (dirty) return true;
       dirty = _compoeTotalOriginalCommited != CompoeTotal;

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
             case "Cst":
                return this.Cst;
             case "Origem":
                return this.Origem;
             case "ModalidadeDeterminacaoBc":
                return this.ModalidadeDeterminacaoBc;
             case "Aliquota":
                return this.Aliquota;
             case "AliquotaSt":
                return this.AliquotaSt;
             case "PercentualReducaoBc":
                return this.PercentualReducaoBc;
             case "ModalidadeDeterminacaoBcSt":
                return this.ModalidadeDeterminacaoBcSt;
             case "PercentualReducaoBcSt":
                return this.PercentualReducaoBcSt;
             case "PercentualMvaSt":
                return this.PercentualMvaSt;
             case "CodigoAntecipacaoSt":
                return this.CodigoAntecipacaoSt;
             case "PercentualDiferimento":
                return this.PercentualDiferimento;
             case "ObsDiferimento":
                return this.ObsDiferimento;
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
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "MotivoDesoneracaoIcms":
                return this.MotivoDesoneracaoIcms;
             case "PercentualCreditoPresumido":
                return this.PercentualCreditoPresumido;
             case "PercentualLimiteCreditoPresumido":
                return this.PercentualLimiteCreditoPresumido;
             case "ObservacaoCreditoPresumido":
                return this.ObservacaoCreditoPresumido;
             case "ObservacaoCreditoSimples":
                return this.ObservacaoCreditoSimples;
             case "FcpRetidoBc":
                return this.FcpRetidoBc;
             case "FcpRetidoAliquota":
                return this.FcpRetidoAliquota;
             case "FcpRetidoValor":
                return this.FcpRetidoValor;
             case "AliquotaSuportadaConsumidorFinal":
                return this.AliquotaSuportadaConsumidorFinal;
             case "CompoeTotal":
                return this.CompoeTotal;
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
                  command.CommandText += " COUNT(nf_produto_icms.id_nf_produto_icms) " ;
               }
               else
               {
               command.CommandText += "nf_produto_icms.id_nf_item, " ;
               command.CommandText += "nf_produto_icms.npc_cst, " ;
               command.CommandText += "nf_produto_icms.npc_origem, " ;
               command.CommandText += "nf_produto_icms.npc_modalidade_determinacao_bc, " ;
               command.CommandText += "nf_produto_icms.npc_aliquota, " ;
               command.CommandText += "nf_produto_icms.npc_aliquota_st, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_reducao_bc, " ;
               command.CommandText += "nf_produto_icms.npc_modalidade_determinacao_bc_st, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_reducao_bc_st, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_mva_st, " ;
               command.CommandText += "nf_produto_icms.npc_codigo_antecipacao_st, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_diferimento, " ;
               command.CommandText += "nf_produto_icms.npc_obs_diferimento, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_bc_operacao_propria, " ;
               command.CommandText += "nf_produto_icms.npc_sigla_uf_devido_icms, " ;
               command.CommandText += "nf_produto_icms.npc_valor_bc_st_retido_remetente, " ;
               command.CommandText += "nf_produto_icms.npc_valor_icms_st_retido_remetente, " ;
               command.CommandText += "nf_produto_icms.npc_valor_bc_st_retido_destinatario, " ;
               command.CommandText += "nf_produto_icms.npc_valor_icms_st_retido_destinatario, " ;
               command.CommandText += "nf_produto_icms.npc_cso_simples, " ;
               command.CommandText += "nf_produto_icms.npc_aliquota_credito_simples, " ;
               command.CommandText += "nf_produto_icms.entity_uid, " ;
               command.CommandText += "nf_produto_icms.version, " ;
               command.CommandText += "nf_produto_icms.npc_motivo_desoneracao_icms, " ;
               command.CommandText += "nf_produto_icms.id_nf_produto_icms, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_credito_presumido, " ;
               command.CommandText += "nf_produto_icms.npc_percentual_limite_credito_presumido, " ;
               command.CommandText += "nf_produto_icms.npc_observacao_credito_presumido, " ;
               command.CommandText += "nf_produto_icms.npc_observacao_credito_simples, " ;
               command.CommandText += "nf_produto_icms.npc_fcp_retido_bc, " ;
               command.CommandText += "nf_produto_icms.npc_fcp_retido_aliquota, " ;
               command.CommandText += "nf_produto_icms.npc_fcp_retido_valor, " ;
               command.CommandText += "nf_produto_icms.npc_aliquota_suportada_consumidor_final, " ;
               command.CommandText += "nf_produto_icms.npc_compoe_total " ;
               }
               command.CommandText += " FROM  nf_produto_icms ";
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
                        orderByClause += " , npc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(npc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = nf_produto_icms.id_acs_usuario_ultima_revisao ";
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
                     orderByClause += " , nf_produto_icms.id_nf_item " + parametro.Ordenacao.ToString().ToUpper(); 
                     break;
                     case "npc_cst":
                     case "Cst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_origem":
                     case "Origem":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_origem " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_origem) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_modalidade_determinacao_bc":
                     case "ModalidadeDeterminacaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_modalidade_determinacao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_modalidade_determinacao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_aliquota":
                     case "Aliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_aliquota_st":
                     case "AliquotaSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_aliquota_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_aliquota_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_reducao_bc":
                     case "PercentualReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_modalidade_determinacao_bc_st":
                     case "ModalidadeDeterminacaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_modalidade_determinacao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_modalidade_determinacao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_reducao_bc_st":
                     case "PercentualReducaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_reducao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_reducao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_mva_st":
                     case "PercentualMvaSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_mva_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_mva_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_codigo_antecipacao_st":
                     case "CodigoAntecipacaoSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_codigo_antecipacao_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_codigo_antecipacao_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_diferimento":
                     case "PercentualDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_obs_diferimento":
                     case "ObsDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_obs_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_obs_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_bc_operacao_propria":
                     case "PercentualBcOperacaoPropria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_bc_operacao_propria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_bc_operacao_propria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_sigla_uf_devido_icms":
                     case "SiglaUfDevidoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_sigla_uf_devido_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_sigla_uf_devido_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_valor_bc_st_retido_remetente":
                     case "ValorBcStRetidoRemetente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_valor_bc_st_retido_remetente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_valor_bc_st_retido_remetente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_valor_icms_st_retido_remetente":
                     case "ValorIcmsStRetidoRemetente":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_valor_icms_st_retido_remetente " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_valor_icms_st_retido_remetente) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_valor_bc_st_retido_destinatario":
                     case "ValorBcStRetidoDestinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_valor_bc_st_retido_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_valor_bc_st_retido_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_valor_icms_st_retido_destinatario":
                     case "ValorIcmsStRetidoDestinatario":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_valor_icms_st_retido_destinatario " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_valor_icms_st_retido_destinatario) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_cso_simples":
                     case "CsoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_cso_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_cso_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_aliquota_credito_simples":
                     case "AliquotaCreditoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_aliquota_credito_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_aliquota_credito_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , nf_produto_icms.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_motivo_desoneracao_icms":
                     case "MotivoDesoneracaoIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_motivo_desoneracao_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_motivo_desoneracao_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "id_nf_produto_icms":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.id_nf_produto_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.id_nf_produto_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_credito_presumido":
                     case "PercentualCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_percentual_limite_credito_presumido":
                     case "PercentualLimiteCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_percentual_limite_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_percentual_limite_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_observacao_credito_presumido":
                     case "ObservacaoCreditoPresumido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_observacao_credito_presumido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_observacao_credito_presumido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_observacao_credito_simples":
                     case "ObservacaoCreditoSimples":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , nf_produto_icms.npc_observacao_credito_simples " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(nf_produto_icms.npc_observacao_credito_simples) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_fcp_retido_bc":
                     case "FcpRetidoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_fcp_retido_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_fcp_retido_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_fcp_retido_aliquota":
                     case "FcpRetidoAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_fcp_retido_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_fcp_retido_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_fcp_retido_valor":
                     case "FcpRetidoValor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_fcp_retido_valor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_fcp_retido_valor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_aliquota_suportada_consumidor_final":
                     case "AliquotaSuportadaConsumidorFinal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_aliquota_suportada_consumidor_final " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_aliquota_suportada_consumidor_final) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "npc_compoe_total":
                     case "CompoeTotal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , nf_produto_icms.npc_compoe_total " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(nf_produto_icms.npc_compoe_total) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_cst")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_codigo_antecipacao_st")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_codigo_antecipacao_st) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_codigo_antecipacao_st) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_obs_diferimento")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_obs_diferimento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_obs_diferimento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_sigla_uf_devido_icms")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_sigla_uf_devido_icms) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_sigla_uf_devido_icms) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_observacao_credito_presumido")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_observacao_credito_presumido) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_observacao_credito_presumido) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("npc_observacao_credito_simples")) 
                        {
                           whereClause += " OR UPPER(nf_produto_icms.npc_observacao_credito_simples) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(nf_produto_icms.npc_observacao_credito_simples) LIKE :buscaCompletaLower ";
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
                         whereClause += "  nf_produto_icms.id_nf_item IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.id_nf_item = :nf_produto_icms_NfItem_769 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_NfItem_769", NpgsqlDbType.Integer, ((AbstractEntity)parametro.Fieldvalue).ID));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cst" || parametro.FieldName == "npc_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_cst LIKE :nf_produto_icms_Cst_8067 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_Cst_8067", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Origem" || parametro.FieldName == "npc_origem")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is OrigemMercadoria)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo OrigemMercadoria");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_origem IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_origem = :nf_produto_icms_Origem_1691 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_Origem_1691", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeDeterminacaoBc" || parametro.FieldName == "npc_modalidade_determinacao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeDeterminacaoBCICMS)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeDeterminacaoBCICMS");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_modalidade_determinacao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_modalidade_determinacao_bc = :nf_produto_icms_ModalidadeDeterminacaoBc_4844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ModalidadeDeterminacaoBc_4844", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Aliquota" || parametro.FieldName == "npc_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota = :nf_produto_icms_Aliquota_5454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_Aliquota_5454", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaSt" || parametro.FieldName == "npc_aliquota_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_st = :nf_produto_icms_AliquotaSt_1878 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_AliquotaSt_1878", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBc" || parametro.FieldName == "npc_percentual_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_reducao_bc = :nf_produto_icms_PercentualReducaoBc_5102 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualReducaoBc_5102", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ModalidadeDeterminacaoBcSt" || parametro.FieldName == "npc_modalidade_determinacao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is ModalidadeDeterminacaoBCICMSST)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo ModalidadeDeterminacaoBCICMSST");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_modalidade_determinacao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_modalidade_determinacao_bc_st = :nf_produto_icms_ModalidadeDeterminacaoBcSt_8283 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ModalidadeDeterminacaoBcSt_8283", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualReducaoBcSt" || parametro.FieldName == "npc_percentual_reducao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_reducao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_reducao_bc_st = :nf_produto_icms_PercentualReducaoBcSt_5068 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualReducaoBcSt_5068", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualMvaSt" || parametro.FieldName == "npc_percentual_mva_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_mva_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_mva_st = :nf_produto_icms_PercentualMvaSt_2409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualMvaSt_2409", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CodigoAntecipacaoSt" || parametro.FieldName == "npc_codigo_antecipacao_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_codigo_antecipacao_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_codigo_antecipacao_st LIKE :nf_produto_icms_CodigoAntecipacaoSt_6503 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_CodigoAntecipacaoSt_6503", NpgsqlDbType.Char,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualDiferimento" || parametro.FieldName == "npc_percentual_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_diferimento = :nf_produto_icms_PercentualDiferimento_6079 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualDiferimento_6079", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObsDiferimento" || parametro.FieldName == "npc_obs_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_obs_diferimento LIKE :nf_produto_icms_ObsDiferimento_7497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObsDiferimento_7497", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualBcOperacaoPropria" || parametro.FieldName == "npc_percentual_bc_operacao_propria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_bc_operacao_propria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_bc_operacao_propria = :nf_produto_icms_PercentualBcOperacaoPropria_6463 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualBcOperacaoPropria_6463", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SiglaUfDevidoIcms" || parametro.FieldName == "npc_sigla_uf_devido_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_sigla_uf_devido_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_sigla_uf_devido_icms LIKE :nf_produto_icms_SiglaUfDevidoIcms_3781 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_SiglaUfDevidoIcms_3781", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBcStRetidoRemetente" || parametro.FieldName == "npc_valor_bc_st_retido_remetente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_valor_bc_st_retido_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_valor_bc_st_retido_remetente = :nf_produto_icms_ValorBcStRetidoRemetente_5939 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ValorBcStRetidoRemetente_5939", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsStRetidoRemetente" || parametro.FieldName == "npc_valor_icms_st_retido_remetente")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_valor_icms_st_retido_remetente IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_valor_icms_st_retido_remetente = :nf_produto_icms_ValorIcmsStRetidoRemetente_3611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ValorIcmsStRetidoRemetente_3611", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorBcStRetidoDestinatario" || parametro.FieldName == "npc_valor_bc_st_retido_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_valor_bc_st_retido_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_valor_bc_st_retido_destinatario = :nf_produto_icms_ValorBcStRetidoDestinatario_4465 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ValorBcStRetidoDestinatario_4465", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValorIcmsStRetidoDestinatario" || parametro.FieldName == "npc_valor_icms_st_retido_destinatario")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_valor_icms_st_retido_destinatario IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_valor_icms_st_retido_destinatario = :nf_produto_icms_ValorIcmsStRetidoDestinatario_4318 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ValorIcmsStRetidoDestinatario_4318", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CsoSimples" || parametro.FieldName == "npc_cso_simples")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_cso_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_cso_simples = :nf_produto_icms_CsoSimples_9106 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_CsoSimples_9106", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaCreditoSimples" || parametro.FieldName == "npc_aliquota_credito_simples")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_credito_simples = :nf_produto_icms_AliquotaCreditoSimples_5059 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_AliquotaCreditoSimples_5059", NpgsqlDbType.Double, parametro.Fieldvalue));
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
                         whereClause += "  nf_produto_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.entity_uid LIKE :nf_produto_icms_EntityUid_550 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_EntityUid_550", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  nf_produto_icms.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.version = :nf_produto_icms_Version_1508 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_Version_1508", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "MotivoDesoneracaoIcms" || parametro.FieldName == "npc_motivo_desoneracao_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_motivo_desoneracao_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_motivo_desoneracao_icms = :nf_produto_icms_MotivoDesoneracaoIcms_8174 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_MotivoDesoneracaoIcms_8174", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_nf_produto_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.id_nf_produto_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.id_nf_produto_icms = :nf_produto_icms_ID_8243 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ID_8243", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualCreditoPresumido" || parametro.FieldName == "npc_percentual_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_credito_presumido = :nf_produto_icms_PercentualCreditoPresumido_619 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualCreditoPresumido_619", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PercentualLimiteCreditoPresumido" || parametro.FieldName == "npc_percentual_limite_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_limite_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_percentual_limite_credito_presumido = :nf_produto_icms_PercentualLimiteCreditoPresumido_5792 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_PercentualLimiteCreditoPresumido_5792", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoPresumido" || parametro.FieldName == "npc_observacao_credito_presumido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_presumido LIKE :nf_produto_icms_ObservacaoCreditoPresumido_8338 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObservacaoCreditoPresumido_8338", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ObservacaoCreditoSimples" || parametro.FieldName == "npc_observacao_credito_simples")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_simples LIKE :nf_produto_icms_ObservacaoCreditoSimples_8529 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObservacaoCreditoSimples_8529", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoBc" || parametro.FieldName == "npc_fcp_retido_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_bc = :nf_produto_icms_FcpRetidoBc_98 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_FcpRetidoBc_98", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoAliquota" || parametro.FieldName == "npc_fcp_retido_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_aliquota = :nf_produto_icms_FcpRetidoAliquota_7408 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_FcpRetidoAliquota_7408", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "FcpRetidoValor" || parametro.FieldName == "npc_fcp_retido_valor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_valor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_fcp_retido_valor = :nf_produto_icms_FcpRetidoValor_9789 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_FcpRetidoValor_9789", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "AliquotaSuportadaConsumidorFinal" || parametro.FieldName == "npc_aliquota_suportada_consumidor_final")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_suportada_consumidor_final IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_aliquota_suportada_consumidor_final = :nf_produto_icms_AliquotaSuportadaConsumidorFinal_9217 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_AliquotaSuportadaConsumidorFinal_9217", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CompoeTotal" || parametro.FieldName == "npc_compoe_total")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  nf_produto_icms.npc_compoe_total IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_compoe_total = :nf_produto_icms_CompoeTotal_2830 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_CompoeTotal_2830", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  nf_produto_icms.npc_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_cst LIKE :nf_produto_icms_Cst_9988 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_Cst_9988", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.npc_codigo_antecipacao_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_codigo_antecipacao_st LIKE :nf_produto_icms_CodigoAntecipacaoSt_8366 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_CodigoAntecipacaoSt_8366", NpgsqlDbType.Char,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.npc_obs_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_obs_diferimento LIKE :nf_produto_icms_ObsDiferimento_2379 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObsDiferimento_2379", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.npc_sigla_uf_devido_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_sigla_uf_devido_icms LIKE :nf_produto_icms_SiglaUfDevidoIcms_7744 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_SiglaUfDevidoIcms_7744", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.entity_uid LIKE :nf_produto_icms_EntityUid_5626 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_EntityUid_5626", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.npc_observacao_credito_presumido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_presumido LIKE :nf_produto_icms_ObservacaoCreditoPresumido_4714 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObservacaoCreditoPresumido_4714", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  nf_produto_icms.npc_observacao_credito_simples IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  nf_produto_icms.npc_observacao_credito_simples LIKE :nf_produto_icms_ObservacaoCreditoSimples_7100 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("nf_produto_icms_ObservacaoCreditoSimples_7100", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  NfProdutoIcmsClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (NfProdutoIcmsClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(NfProdutoIcmsClass), Convert.ToInt32(read["id_nf_produto_icms"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new NfProdutoIcmsClass(UsuarioAtual, SingleConnection);
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
                     entidade.Cst = (read["npc_cst"] != DBNull.Value ? read["npc_cst"].ToString() : null);
                     entidade.Origem = (OrigemMercadoria) (read["npc_origem"] != DBNull.Value ? Enum.ToObject(typeof(OrigemMercadoria), read["npc_origem"]) : null);
                     entidade.ModalidadeDeterminacaoBc = (ModalidadeDeterminacaoBCICMS) (read["npc_modalidade_determinacao_bc"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMS), read["npc_modalidade_determinacao_bc"]) : null);
                     entidade.Aliquota = (double)read["npc_aliquota"];
                     entidade.AliquotaSt = (double)read["npc_aliquota_st"];
                     entidade.PercentualReducaoBc = (double)read["npc_percentual_reducao_bc"];
                     entidade.ModalidadeDeterminacaoBcSt = (ModalidadeDeterminacaoBCICMSST) (read["npc_modalidade_determinacao_bc_st"] != DBNull.Value ? Enum.ToObject(typeof(ModalidadeDeterminacaoBCICMSST), read["npc_modalidade_determinacao_bc_st"]) : null);
                     entidade.PercentualReducaoBcSt = (double)read["npc_percentual_reducao_bc_st"];
                     entidade.PercentualMvaSt = (double)read["npc_percentual_mva_st"];
                     entidade.CodigoAntecipacaoSt = (read["npc_codigo_antecipacao_st"] != DBNull.Value ? read["npc_codigo_antecipacao_st"].ToString() : null);
                     entidade.PercentualDiferimento = (double)read["npc_percentual_diferimento"];
                     entidade.ObsDiferimento = (read["npc_obs_diferimento"] != DBNull.Value ? read["npc_obs_diferimento"].ToString() : null);
                     entidade.PercentualBcOperacaoPropria = (double)read["npc_percentual_bc_operacao_propria"];
                     entidade.SiglaUfDevidoIcms = (read["npc_sigla_uf_devido_icms"] != DBNull.Value ? read["npc_sigla_uf_devido_icms"].ToString() : null);
                     entidade.ValorBcStRetidoRemetente = (double)read["npc_valor_bc_st_retido_remetente"];
                     entidade.ValorIcmsStRetidoRemetente = (double)read["npc_valor_icms_st_retido_remetente"];
                     entidade.ValorBcStRetidoDestinatario = (double)read["npc_valor_bc_st_retido_destinatario"];
                     entidade.ValorIcmsStRetidoDestinatario = (double)read["npc_valor_icms_st_retido_destinatario"];
                     entidade.CsoSimples = read["npc_cso_simples"] as int?;
                     entidade.AliquotaCreditoSimples = (double)read["npc_aliquota_credito_simples"];
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.MotivoDesoneracaoIcms = read["npc_motivo_desoneracao_icms"] as short?;
                     entidade.ID = Convert.ToInt64(read["id_nf_produto_icms"]);
                     entidade.PercentualCreditoPresumido = read["npc_percentual_credito_presumido"] as double?;
                     entidade.PercentualLimiteCreditoPresumido = read["npc_percentual_limite_credito_presumido"] as double?;
                     entidade.ObservacaoCreditoPresumido = (read["npc_observacao_credito_presumido"] != DBNull.Value ? read["npc_observacao_credito_presumido"].ToString() : null);
                     entidade.ObservacaoCreditoSimples = (read["npc_observacao_credito_simples"] != DBNull.Value ? read["npc_observacao_credito_simples"].ToString() : null);
                     entidade.FcpRetidoBc = read["npc_fcp_retido_bc"] as double?;
                     entidade.FcpRetidoAliquota = read["npc_fcp_retido_aliquota"] as double?;
                     entidade.FcpRetidoValor = read["npc_fcp_retido_valor"] as double?;
                     entidade.AliquotaSuportadaConsumidorFinal = read["npc_aliquota_suportada_consumidor_final"] as double?;
                     entidade.CompoeTotal = Convert.ToBoolean(Convert.ToInt16(read["npc_compoe_total"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (NfProdutoIcmsClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
