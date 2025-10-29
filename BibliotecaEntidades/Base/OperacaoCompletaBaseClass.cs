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
     [Table("operacao_completa","opc")]
     public class OperacaoCompletaBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OperacaoCompletaClass";
protected const string ErroDelete = "Erro ao excluir o OperacaoCompletaClass  ";
protected const string ErroSave = "Erro ao salvar o OperacaoCompletaClass.";
protected const string ErroCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta = "Erro ao carregar a coleção de OperacaoCompletaIcmsAliquotaClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionPedidoItemClassOperacaoCompleta = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPostoTrabalhoClassOperacaoCompleta = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected const string ErroIdentificacaoObrigatorio = "O campo Identificacao é obrigatório";
protected const string ErroIdentificacaoComprimento = "O campo Identificacao deve ter no máximo 70 caracteres";
protected const string ErroNaturezaOperacaoObrigatorio = "O campo NaturezaOperacao é obrigatório";
protected const string ErroNaturezaOperacaoComprimento = "O campo NaturezaOperacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OperacaoCompletaClass.";
protected const string MensagemUtilizadoCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta =  "A entidade OperacaoCompletaClass está sendo utilizada nos seguintes OperacaoCompletaIcmsAliquotaClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta =  "A entidade OperacaoCompletaClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassOperacaoCompleta =  "A entidade OperacaoCompletaClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros =  "A entidade OperacaoCompletaClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPostoTrabalhoClassOperacaoCompleta =  "A entidade OperacaoCompletaClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OperacaoCompletaClass está sendo utilizada.";
#endregion
       protected string _identificacaoOriginal{get;private set;}
       private string _identificacaoOriginalCommited{get; set;}
        private string _valueIdentificacao;
         [Column("opc_identificacao")]
        public virtual string Identificacao
         { 
            get { return this._valueIdentificacao; } 
            set 
            { 
                if (this._valueIdentificacao == value)return;
                 this._valueIdentificacao = value; 
            } 
        } 

       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("opc_descricao")]
        public virtual string Descricao
         { 
            get { return this._valueDescricao; } 
            set 
            { 
                if (this._valueDescricao == value)return;
                 this._valueDescricao = value; 
            } 
        } 

       protected int _cfopOriginal{get;private set;}
       private int _cfopOriginalCommited{get; set;}
        private int _valueCfop;
         [Column("opc_cfop")]
        public virtual int Cfop
         { 
            get { return this._valueCfop; } 
            set 
            { 
                if (this._valueCfop == value)return;
                 this._valueCfop = value; 
            } 
        } 

       protected int _cfopForaEstadoOriginal{get;private set;}
       private int _cfopForaEstadoOriginalCommited{get; set;}
        private int _valueCfopForaEstado;
         [Column("opc_cfop_fora_estado")]
        public virtual int CfopForaEstado
         { 
            get { return this._valueCfopForaEstado; } 
            set 
            { 
                if (this._valueCfopForaEstado == value)return;
                 this._valueCfopForaEstado = value; 
            } 
        } 

       protected string _naturezaOperacaoOriginal{get;private set;}
       private string _naturezaOperacaoOriginalCommited{get; set;}
        private string _valueNaturezaOperacao;
         [Column("opc_natureza_operacao")]
        public virtual string NaturezaOperacao
         { 
            get { return this._valueNaturezaOperacao; } 
            set 
            { 
                if (this._valueNaturezaOperacao == value)return;
                 this._valueNaturezaOperacao = value; 
            } 
        } 

       protected bool _consumidorFinalOriginal{get;private set;}
       private bool _consumidorFinalOriginalCommited{get; set;}
        private bool _valueConsumidorFinal;
         [Column("opc_consumidor_final")]
        public virtual bool ConsumidorFinal
         { 
            get { return this._valueConsumidorFinal; } 
            set 
            { 
                if (this._valueConsumidorFinal == value)return;
                 this._valueConsumidorFinal = value; 
            } 
        } 

       protected PresencaComprador _presencaConsumidorOriginal{get;private set;}
       private PresencaComprador _presencaConsumidorOriginalCommited{get; set;}
        private PresencaComprador _valuePresencaConsumidor;
         [Column("opc_presenca_consumidor")]
        public virtual PresencaComprador PresencaConsumidor
         { 
            get { return this._valuePresencaConsumidor; } 
            set 
            { 
                if (this._valuePresencaConsumidor == value)return;
                 this._valuePresencaConsumidor = value; 
            } 
        } 

        public bool PresencaConsumidor_ForaEstabelecimento
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.ForaEstabelecimento; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.ForaEstabelecimento; }
         } 

        public bool PresencaConsumidor_NFCeEntregaDomicilio
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.NFCeEntregaDomicilio; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.NFCeEntregaDomicilio; }
         } 

        public bool PresencaConsumidor_NaoAplicavel
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.NaoAplicavel; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.NaoAplicavel; }
         } 

        public bool PresencaConsumidor_Presencial
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.Presencial; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.Presencial; }
         } 

        public bool PresencaConsumidor_Internet
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.Internet; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.Internet; }
         } 

        public bool PresencaConsumidor_Teleatendimento
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.Teleatendimento; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.Teleatendimento; }
         } 

        public bool PresencaConsumidor_NaoPresencialOutros
         { 
            get { return this._valuePresencaConsumidor == BibliotecaEntidades.Base.PresencaComprador.NaoPresencialOutros; } 
            set { if (value) this._valuePresencaConsumidor = BibliotecaEntidades.Base.PresencaComprador.NaoPresencialOutros; }
         } 

       protected bool _gerarContasReceberOriginal{get;private set;}
       private bool _gerarContasReceberOriginalCommited{get; set;}
        private bool _valueGerarContasReceber;
         [Column("opc_gerar_contas_receber")]
        public virtual bool GerarContasReceber
         { 
            get { return this._valueGerarContasReceber; } 
            set 
            { 
                if (this._valueGerarContasReceber == value)return;
                 this._valueGerarContasReceber = value; 
            } 
        } 

       protected IncidenciaImposto _icmsIncideOriginal{get;private set;}
       private IncidenciaImposto _icmsIncideOriginalCommited{get; set;}
        private IncidenciaImposto _valueIcmsIncide;
         [Column("opc_icms_incide")]
        public virtual IncidenciaImposto IcmsIncide
         { 
            get { return this._valueIcmsIncide; } 
            set 
            { 
                if (this._valueIcmsIncide == value)return;
                 this._valueIcmsIncide = value; 
            } 
        } 

        public bool IcmsIncide_NaoIncide
         { 
            get { return this._valueIcmsIncide == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IcmsIncide_Incide
         { 
            get { return this._valueIcmsIncide == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IcmsIncide_Suspenso
         { 
            get { return this._valueIcmsIncide == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected bool _icmsPartilhaOriginal{get;private set;}
       private bool _icmsPartilhaOriginalCommited{get; set;}
        private bool _valueIcmsPartilha;
         [Column("opc_icms_partilha")]
        public virtual bool IcmsPartilha
         { 
            get { return this._valueIcmsPartilha; } 
            set 
            { 
                if (this._valueIcmsPartilha == value)return;
                 this._valueIcmsPartilha = value; 
            } 
        } 

       protected bool _icmsSomaFreteBcOriginal{get;private set;}
       private bool _icmsSomaFreteBcOriginalCommited{get; set;}
        private bool _valueIcmsSomaFreteBc;
         [Column("opc_icms_soma_frete_bc")]
        public virtual bool IcmsSomaFreteBc
         { 
            get { return this._valueIcmsSomaFreteBc; } 
            set 
            { 
                if (this._valueIcmsSomaFreteBc == value)return;
                 this._valueIcmsSomaFreteBc = value; 
            } 
        } 

       protected string _icmsCstOriginal{get;private set;}
       private string _icmsCstOriginalCommited{get; set;}
        private string _valueIcmsCst;
         [Column("opc_icms_cst")]
        public virtual string IcmsCst
         { 
            get { return this._valueIcmsCst; } 
            set 
            { 
                if (this._valueIcmsCst == value)return;
                 this._valueIcmsCst = value; 
            } 
        } 

       protected double _icmsAliquotaCreditoOriginal{get;private set;}
       private double _icmsAliquotaCreditoOriginalCommited{get; set;}
        private double _valueIcmsAliquotaCredito;
         [Column("opc_icms_aliquota_credito")]
        public virtual double IcmsAliquotaCredito
         { 
            get { return this._valueIcmsAliquotaCredito; } 
            set 
            { 
                if (this._valueIcmsAliquotaCredito == value)return;
                 this._valueIcmsAliquotaCredito = value; 
            } 
        } 

       protected short _icmsModDetBcOriginal{get;private set;}
       private short _icmsModDetBcOriginalCommited{get; set;}
        private short _valueIcmsModDetBc;
         [Column("opc_icms_mod_det_bc")]
        public virtual short IcmsModDetBc
         { 
            get { return this._valueIcmsModDetBc; } 
            set 
            { 
                if (this._valueIcmsModDetBc == value)return;
                 this._valueIcmsModDetBc = value; 
            } 
        } 

       protected bool _icmsReducaoBcOriginal{get;private set;}
       private bool _icmsReducaoBcOriginalCommited{get; set;}
        private bool _valueIcmsReducaoBc;
         [Column("opc_icms_reducao_bc")]
        public virtual bool IcmsReducaoBc
         { 
            get { return this._valueIcmsReducaoBc; } 
            set 
            { 
                if (this._valueIcmsReducaoBc == value)return;
                 this._valueIcmsReducaoBc = value; 
            } 
        } 

       protected double _icmsPercentualReducaoBcOriginal{get;private set;}
       private double _icmsPercentualReducaoBcOriginalCommited{get; set;}
        private double _valueIcmsPercentualReducaoBc;
         [Column("opc_icms_percentual_reducao_bc")]
        public virtual double IcmsPercentualReducaoBc
         { 
            get { return this._valueIcmsPercentualReducaoBc; } 
            set 
            { 
                if (this._valueIcmsPercentualReducaoBc == value)return;
                 this._valueIcmsPercentualReducaoBc = value; 
            } 
        } 

       protected double _icmsPercentualBcOperacaoPropriaOriginal{get;private set;}
       private double _icmsPercentualBcOperacaoPropriaOriginalCommited{get; set;}
        private double _valueIcmsPercentualBcOperacaoPropria;
         [Column("opc_icms_percentual_bc_operacao_propria")]
        public virtual double IcmsPercentualBcOperacaoPropria
         { 
            get { return this._valueIcmsPercentualBcOperacaoPropria; } 
            set 
            { 
                if (this._valueIcmsPercentualBcOperacaoPropria == value)return;
                 this._valueIcmsPercentualBcOperacaoPropria = value; 
            } 
        } 

       protected short _icmsStOriginal{get;private set;}
       private short _icmsStOriginalCommited{get; set;}
        private short _valueIcmsSt;
         [Column("opc_icms_st")]
        public virtual short IcmsSt
         { 
            get { return this._valueIcmsSt; } 
            set 
            { 
                if (this._valueIcmsSt == value)return;
                 this._valueIcmsSt = value; 
            } 
        } 

       protected short _icmsModDetBcStOriginal{get;private set;}
       private short _icmsModDetBcStOriginalCommited{get; set;}
        private short _valueIcmsModDetBcSt;
         [Column("opc_icms_mod_det_bc_st")]
        public virtual short IcmsModDetBcSt
         { 
            get { return this._valueIcmsModDetBcSt; } 
            set 
            { 
                if (this._valueIcmsModDetBcSt == value)return;
                 this._valueIcmsModDetBcSt = value; 
            } 
        } 

       protected double _icmsPercentualReducaoBcStOriginal{get;private set;}
       private double _icmsPercentualReducaoBcStOriginalCommited{get; set;}
        private double _valueIcmsPercentualReducaoBcSt;
         [Column("opc_icms_percentual_reducao_bc_st")]
        public virtual double IcmsPercentualReducaoBcSt
         { 
            get { return this._valueIcmsPercentualReducaoBcSt; } 
            set 
            { 
                if (this._valueIcmsPercentualReducaoBcSt == value)return;
                 this._valueIcmsPercentualReducaoBcSt = value; 
            } 
        } 

       protected double _icmsPercentualDiferimentoOriginal{get;private set;}
       private double _icmsPercentualDiferimentoOriginalCommited{get; set;}
        private double _valueIcmsPercentualDiferimento;
         [Column("opc_icms_percentual_diferimento")]
        public virtual double IcmsPercentualDiferimento
         { 
            get { return this._valueIcmsPercentualDiferimento; } 
            set 
            { 
                if (this._valueIcmsPercentualDiferimento == value)return;
                 this._valueIcmsPercentualDiferimento = value; 
            } 
        } 

       protected string _icmsObservacaoDiferimentoOriginal{get;private set;}
       private string _icmsObservacaoDiferimentoOriginalCommited{get; set;}
        private string _valueIcmsObservacaoDiferimento;
         [Column("opc_icms_observacao_diferimento")]
        public virtual string IcmsObservacaoDiferimento
         { 
            get { return this._valueIcmsObservacaoDiferimento; } 
            set 
            { 
                if (this._valueIcmsObservacaoDiferimento == value)return;
                 this._valueIcmsObservacaoDiferimento = value; 
            } 
        } 

       protected IncidenciaIPI _ipiIncideOriginal{get;private set;}
       private IncidenciaIPI _ipiIncideOriginalCommited{get; set;}
        private IncidenciaIPI _valueIpiIncide;
         [Column("opc_ipi_incide")]
        public virtual IncidenciaIPI IpiIncide
         { 
            get { return this._valueIpiIncide; } 
            set 
            { 
                if (this._valueIpiIncide == value)return;
                 this._valueIpiIncide = value; 
            } 
        } 

        public bool IpiIncide_NaoIncide
         { 
            get { return this._valueIpiIncide == BibliotecaEntidades.Base.IncidenciaIPI.NaoIncide; } 
            set { if (value) this._valueIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.NaoIncide; }
         } 

        public bool IpiIncide_Incide
         { 
            get { return this._valueIpiIncide == BibliotecaEntidades.Base.IncidenciaIPI.Incide; } 
            set { if (value) this._valueIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.Incide; }
         } 

        public bool IpiIncide_Suspenso
         { 
            get { return this._valueIpiIncide == BibliotecaEntidades.Base.IncidenciaIPI.Suspenso; } 
            set { if (value) this._valueIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.Suspenso; }
         } 

        public bool IpiIncide_UtilizaDadosProdutoNcm
         { 
            get { return this._valueIpiIncide == BibliotecaEntidades.Base.IncidenciaIPI.UtilizaDadosProdutoNcm; } 
            set { if (value) this._valueIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.UtilizaDadosProdutoNcm; }
         } 

       protected string _ipiCstOriginal{get;private set;}
       private string _ipiCstOriginalCommited{get; set;}
        private string _valueIpiCst;
         [Column("opc_ipi_cst")]
        public virtual string IpiCst
         { 
            get { return this._valueIpiCst; } 
            set 
            { 
                if (this._valueIpiCst == value)return;
                 this._valueIpiCst = value; 
            } 
        } 

       protected short _ipiModTributacaoOriginal{get;private set;}
       private short _ipiModTributacaoOriginalCommited{get; set;}
        private short _valueIpiModTributacao;
         [Column("opc_ipi_mod_tributacao")]
        public virtual short IpiModTributacao
         { 
            get { return this._valueIpiModTributacao; } 
            set 
            { 
                if (this._valueIpiModTributacao == value)return;
                 this._valueIpiModTributacao = value; 
            } 
        } 

       protected string _ipiCodEnquadramentoOriginal{get;private set;}
       private string _ipiCodEnquadramentoOriginalCommited{get; set;}
        private string _valueIpiCodEnquadramento;
         [Column("opc_ipi_cod_enquadramento")]
        public virtual string IpiCodEnquadramento
         { 
            get { return this._valueIpiCodEnquadramento; } 
            set 
            { 
                if (this._valueIpiCodEnquadramento == value)return;
                 this._valueIpiCodEnquadramento = value; 
            } 
        } 

       protected double _ipiAliquotaOriginal{get;private set;}
       private double _ipiAliquotaOriginalCommited{get; set;}
        private double _valueIpiAliquota;
         [Column("opc_ipi_aliquota")]
        public virtual double IpiAliquota
         { 
            get { return this._valueIpiAliquota; } 
            set 
            { 
                if (this._valueIpiAliquota == value)return;
                 this._valueIpiAliquota = value; 
            } 
        } 

       protected IncidenciaImposto _pisIncideOriginal{get;private set;}
       private IncidenciaImposto _pisIncideOriginalCommited{get; set;}
        private IncidenciaImposto _valuePisIncide;
         [Column("opc_pis_incide")]
        public virtual IncidenciaImposto PisIncide
         { 
            get { return this._valuePisIncide; } 
            set 
            { 
                if (this._valuePisIncide == value)return;
                 this._valuePisIncide = value; 
            } 
        } 

        public bool PisIncide_NaoIncide
         { 
            get { return this._valuePisIncide == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valuePisIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool PisIncide_Incide
         { 
            get { return this._valuePisIncide == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valuePisIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool PisIncide_Suspenso
         { 
            get { return this._valuePisIncide == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valuePisIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected string _pisCstOriginal{get;private set;}
       private string _pisCstOriginalCommited{get; set;}
        private string _valuePisCst;
         [Column("opc_pis_cst")]
        public virtual string PisCst
         { 
            get { return this._valuePisCst; } 
            set 
            { 
                if (this._valuePisCst == value)return;
                 this._valuePisCst = value; 
            } 
        } 

       protected short _pisModTributacaoOriginal{get;private set;}
       private short _pisModTributacaoOriginalCommited{get; set;}
        private short _valuePisModTributacao;
         [Column("opc_pis_mod_tributacao")]
        public virtual short PisModTributacao
         { 
            get { return this._valuePisModTributacao; } 
            set 
            { 
                if (this._valuePisModTributacao == value)return;
                 this._valuePisModTributacao = value; 
            } 
        } 

       protected double _pisAliquotaOriginal{get;private set;}
       private double _pisAliquotaOriginalCommited{get; set;}
        private double _valuePisAliquota;
         [Column("opc_pis_aliquota")]
        public virtual double PisAliquota
         { 
            get { return this._valuePisAliquota; } 
            set 
            { 
                if (this._valuePisAliquota == value)return;
                 this._valuePisAliquota = value; 
            } 
        } 

       protected bool _pisImpostoRetidoOriginal{get;private set;}
       private bool _pisImpostoRetidoOriginalCommited{get; set;}
        private bool _valuePisImpostoRetido;
         [Column("opc_pis_imposto_retido")]
        public virtual bool PisImpostoRetido
         { 
            get { return this._valuePisImpostoRetido; } 
            set 
            { 
                if (this._valuePisImpostoRetido == value)return;
                 this._valuePisImpostoRetido = value; 
            } 
        } 

       protected IncidenciaImposto _cofinsIncideOriginal{get;private set;}
       private IncidenciaImposto _cofinsIncideOriginalCommited{get; set;}
        private IncidenciaImposto _valueCofinsIncide;
         [Column("opc_cofins_incide")]
        public virtual IncidenciaImposto CofinsIncide
         { 
            get { return this._valueCofinsIncide; } 
            set 
            { 
                if (this._valueCofinsIncide == value)return;
                 this._valueCofinsIncide = value; 
            } 
        } 

        public bool CofinsIncide_NaoIncide
         { 
            get { return this._valueCofinsIncide == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool CofinsIncide_Incide
         { 
            get { return this._valueCofinsIncide == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool CofinsIncide_Suspenso
         { 
            get { return this._valueCofinsIncide == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected string _cofinsCstOriginal{get;private set;}
       private string _cofinsCstOriginalCommited{get; set;}
        private string _valueCofinsCst;
         [Column("opc_cofins_cst")]
        public virtual string CofinsCst
         { 
            get { return this._valueCofinsCst; } 
            set 
            { 
                if (this._valueCofinsCst == value)return;
                 this._valueCofinsCst = value; 
            } 
        } 

       protected short _cofinsModTributacaoOriginal{get;private set;}
       private short _cofinsModTributacaoOriginalCommited{get; set;}
        private short _valueCofinsModTributacao;
         [Column("opc_cofins_mod_tributacao")]
        public virtual short CofinsModTributacao
         { 
            get { return this._valueCofinsModTributacao; } 
            set 
            { 
                if (this._valueCofinsModTributacao == value)return;
                 this._valueCofinsModTributacao = value; 
            } 
        } 

       protected double _cofinsAliquotaOriginal{get;private set;}
       private double _cofinsAliquotaOriginalCommited{get; set;}
        private double _valueCofinsAliquota;
         [Column("opc_cofins_aliquota")]
        public virtual double CofinsAliquota
         { 
            get { return this._valueCofinsAliquota; } 
            set 
            { 
                if (this._valueCofinsAliquota == value)return;
                 this._valueCofinsAliquota = value; 
            } 
        } 

       protected bool _cofinsImpostoRetidoOriginal{get;private set;}
       private bool _cofinsImpostoRetidoOriginalCommited{get; set;}
        private bool _valueCofinsImpostoRetido;
         [Column("opc_cofins_imposto_retido")]
        public virtual bool CofinsImpostoRetido
         { 
            get { return this._valueCofinsImpostoRetido; } 
            set 
            { 
                if (this._valueCofinsImpostoRetido == value)return;
                 this._valueCofinsImpostoRetido = value; 
            } 
        } 

       protected bool _entregaFuturaOriginal{get;private set;}
       private bool _entregaFuturaOriginalCommited{get; set;}
        private bool _valueEntregaFutura;
         [Column("opc_entrega_futura")]
        public virtual bool EntregaFutura
         { 
            get { return this._valueEntregaFutura; } 
            set 
            { 
                if (this._valueEntregaFutura == value)return;
                 this._valueEntregaFutura = value; 
            } 
        } 

       protected int? _entregaFuturaCfopRemessaOriginal{get;private set;}
       private int? _entregaFuturaCfopRemessaOriginalCommited{get; set;}
        private int? _valueEntregaFuturaCfopRemessa;
         [Column("opc_entrega_futura_cfop_remessa")]
        public virtual int? EntregaFuturaCfopRemessa
         { 
            get { return this._valueEntregaFuturaCfopRemessa; } 
            set 
            { 
                if (this._valueEntregaFuturaCfopRemessa == value)return;
                 this._valueEntregaFuturaCfopRemessa = value; 
            } 
        } 

       protected int? _entregaFuturaCfopRemessaForaEstadoOriginal{get;private set;}
       private int? _entregaFuturaCfopRemessaForaEstadoOriginalCommited{get; set;}
        private int? _valueEntregaFuturaCfopRemessaForaEstado;
         [Column("opc_entrega_futura_cfop_remessa_fora_estado")]
        public virtual int? EntregaFuturaCfopRemessaForaEstado
         { 
            get { return this._valueEntregaFuturaCfopRemessaForaEstado; } 
            set 
            { 
                if (this._valueEntregaFuturaCfopRemessaForaEstado == value)return;
                 this._valueEntregaFuturaCfopRemessaForaEstado = value; 
            } 
        } 

       protected string _entregaFuturaNaturezaOperacaoRemessaOriginal{get;private set;}
       private string _entregaFuturaNaturezaOperacaoRemessaOriginalCommited{get; set;}
        private string _valueEntregaFuturaNaturezaOperacaoRemessa;
         [Column("opc_entrega_futura_natureza_operacao_remessa")]
        public virtual string EntregaFuturaNaturezaOperacaoRemessa
         { 
            get { return this._valueEntregaFuturaNaturezaOperacaoRemessa; } 
            set 
            { 
                if (this._valueEntregaFuturaNaturezaOperacaoRemessa == value)return;
                 this._valueEntregaFuturaNaturezaOperacaoRemessa = value; 
            } 
        } 

       protected bool _devolucaoMaterialOriginal{get;private set;}
       private bool _devolucaoMaterialOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterial;
         [Column("opc_devolucao_material")]
        public virtual bool DevolucaoMaterial
         { 
            get { return this._valueDevolucaoMaterial; } 
            set 
            { 
                if (this._valueDevolucaoMaterial == value)return;
                 this._valueDevolucaoMaterial = value; 
            } 
        } 

       protected int? _devolucaoMaterialCfopOriginal{get;private set;}
       private int? _devolucaoMaterialCfopOriginalCommited{get; set;}
        private int? _valueDevolucaoMaterialCfop;
         [Column("opc_devolucao_material_cfop")]
        public virtual int? DevolucaoMaterialCfop
         { 
            get { return this._valueDevolucaoMaterialCfop; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCfop == value)return;
                 this._valueDevolucaoMaterialCfop = value; 
            } 
        } 

       protected int? _devolucaoMaterialCfopForaEstadoOriginal{get;private set;}
       private int? _devolucaoMaterialCfopForaEstadoOriginalCommited{get; set;}
        private int? _valueDevolucaoMaterialCfopForaEstado;
         [Column("opc_devolucao_material_cfop_fora_estado")]
        public virtual int? DevolucaoMaterialCfopForaEstado
         { 
            get { return this._valueDevolucaoMaterialCfopForaEstado; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCfopForaEstado == value)return;
                 this._valueDevolucaoMaterialCfopForaEstado = value; 
            } 
        } 

       protected IncidenciaImposto? _devolucaoMaterialIcmsIncideOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIcmsIncideOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIcmsIncide;
         [Column("opc_devolucao_material_icms_incide")]
        public virtual IncidenciaImposto? DevolucaoMaterialIcmsIncide
         { 
            get { return this._valueDevolucaoMaterialIcmsIncide; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsIncide == value)return;
                 this._valueDevolucaoMaterialIcmsIncide = value; 
            } 
        } 

        public bool DevolucaoMaterialIcmsIncide_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIcmsIncide.HasValue && this._valueDevolucaoMaterialIcmsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIcmsIncide_Incide
         { 
            get { return this._valueDevolucaoMaterialIcmsIncide.HasValue && this._valueDevolucaoMaterialIcmsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIcmsIncide_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIcmsIncide.HasValue && this._valueDevolucaoMaterialIcmsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIcmsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected bool _devolucaoMaterialIcmsPartilhaOriginal{get;private set;}
       private bool _devolucaoMaterialIcmsPartilhaOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialIcmsPartilha;
         [Column("opc_devolucao_material_icms_partilha")]
        public virtual bool DevolucaoMaterialIcmsPartilha
         { 
            get { return this._valueDevolucaoMaterialIcmsPartilha; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsPartilha == value)return;
                 this._valueDevolucaoMaterialIcmsPartilha = value; 
            } 
        } 

       protected bool _devolucaoMaterialIcmsSomaFreteBcOriginal{get;private set;}
       private bool _devolucaoMaterialIcmsSomaFreteBcOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialIcmsSomaFreteBc;
         [Column("opc_devolucao_material_icms_soma_frete_bc")]
        public virtual bool DevolucaoMaterialIcmsSomaFreteBc
         { 
            get { return this._valueDevolucaoMaterialIcmsSomaFreteBc; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsSomaFreteBc == value)return;
                 this._valueDevolucaoMaterialIcmsSomaFreteBc = value; 
            } 
        } 

       protected string _devolucaoMaterialIcmsCstOriginal{get;private set;}
       private string _devolucaoMaterialIcmsCstOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIcmsCst;
         [Column("opc_devolucao_material_icms_cst")]
        public virtual string DevolucaoMaterialIcmsCst
         { 
            get { return this._valueDevolucaoMaterialIcmsCst; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsCst == value)return;
                 this._valueDevolucaoMaterialIcmsCst = value; 
            } 
        } 

       protected double _devolucaoMaterialIcmsAliquotaCreditoOriginal{get;private set;}
       private double _devolucaoMaterialIcmsAliquotaCreditoOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIcmsAliquotaCredito;
         [Column("opc_devolucao_material_icms_aliquota_credito")]
        public virtual double DevolucaoMaterialIcmsAliquotaCredito
         { 
            get { return this._valueDevolucaoMaterialIcmsAliquotaCredito; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsAliquotaCredito == value)return;
                 this._valueDevolucaoMaterialIcmsAliquotaCredito = value; 
            } 
        } 

       protected short _devolucaoMaterialIcmsModDetBcOriginal{get;private set;}
       private short _devolucaoMaterialIcmsModDetBcOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialIcmsModDetBc;
         [Column("opc_devolucao_material_icms_mod_det_bc")]
        public virtual short DevolucaoMaterialIcmsModDetBc
         { 
            get { return this._valueDevolucaoMaterialIcmsModDetBc; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsModDetBc == value)return;
                 this._valueDevolucaoMaterialIcmsModDetBc = value; 
            } 
        } 

       protected bool _devolucaoMaterialIcmsReducaoBcOriginal{get;private set;}
       private bool _devolucaoMaterialIcmsReducaoBcOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialIcmsReducaoBc;
         [Column("opc_devolucao_material_icms_reducao_bc")]
        public virtual bool DevolucaoMaterialIcmsReducaoBc
         { 
            get { return this._valueDevolucaoMaterialIcmsReducaoBc; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsReducaoBc == value)return;
                 this._valueDevolucaoMaterialIcmsReducaoBc = value; 
            } 
        } 

       protected double _devolucaoMaterialIcmsPercentualReducaoBcOriginal{get;private set;}
       private double _devolucaoMaterialIcmsPercentualReducaoBcOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIcmsPercentualReducaoBc;
         [Column("opc_devolucao_material_icms_percentual_reducao_bc")]
        public virtual double DevolucaoMaterialIcmsPercentualReducaoBc
         { 
            get { return this._valueDevolucaoMaterialIcmsPercentualReducaoBc; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsPercentualReducaoBc == value)return;
                 this._valueDevolucaoMaterialIcmsPercentualReducaoBc = value; 
            } 
        } 

       protected double _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal{get;private set;}
       private double _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIcmsPercentualBcOperacaoPropria;
         [Column("opc_devolucao_material_icms_percentual_bc_operacao_propria")]
        public virtual double DevolucaoMaterialIcmsPercentualBcOperacaoPropria
         { 
            get { return this._valueDevolucaoMaterialIcmsPercentualBcOperacaoPropria; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsPercentualBcOperacaoPropria == value)return;
                 this._valueDevolucaoMaterialIcmsPercentualBcOperacaoPropria = value; 
            } 
        } 

       protected short _devolucaoMaterialIcmsStOriginal{get;private set;}
       private short _devolucaoMaterialIcmsStOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialIcmsSt;
         [Column("opc_devolucao_material_icms_st")]
        public virtual short DevolucaoMaterialIcmsSt
         { 
            get { return this._valueDevolucaoMaterialIcmsSt; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsSt == value)return;
                 this._valueDevolucaoMaterialIcmsSt = value; 
            } 
        } 

       protected short _devolucaoMaterialIcmsModDetBcStOriginal{get;private set;}
       private short _devolucaoMaterialIcmsModDetBcStOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialIcmsModDetBcSt;
         [Column("opc_devolucao_material_icms_mod_det_bc_st")]
        public virtual short DevolucaoMaterialIcmsModDetBcSt
         { 
            get { return this._valueDevolucaoMaterialIcmsModDetBcSt; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsModDetBcSt == value)return;
                 this._valueDevolucaoMaterialIcmsModDetBcSt = value; 
            } 
        } 

       protected double _devolucaoMaterialIcmsPercentualReducaoBcStOriginal{get;private set;}
       private double _devolucaoMaterialIcmsPercentualReducaoBcStOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIcmsPercentualReducaoBcSt;
         [Column("opc_devolucao_material_icms_percentual_reducao_bc_st")]
        public virtual double DevolucaoMaterialIcmsPercentualReducaoBcSt
         { 
            get { return this._valueDevolucaoMaterialIcmsPercentualReducaoBcSt; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsPercentualReducaoBcSt == value)return;
                 this._valueDevolucaoMaterialIcmsPercentualReducaoBcSt = value; 
            } 
        } 

       protected double _devolucaoMaterialIcmsPercentualDiferimentoOriginal{get;private set;}
       private double _devolucaoMaterialIcmsPercentualDiferimentoOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIcmsPercentualDiferimento;
         [Column("opc_devolucao_material_icms_percentual_diferimento")]
        public virtual double DevolucaoMaterialIcmsPercentualDiferimento
         { 
            get { return this._valueDevolucaoMaterialIcmsPercentualDiferimento; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsPercentualDiferimento == value)return;
                 this._valueDevolucaoMaterialIcmsPercentualDiferimento = value; 
            } 
        } 

       protected string _devolucaoMaterialIcmsObservacaoDiferimentoOriginal{get;private set;}
       private string _devolucaoMaterialIcmsObservacaoDiferimentoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIcmsObservacaoDiferimento;
         [Column("opc_devolucao_material_icms_observacao_diferimento")]
        public virtual string DevolucaoMaterialIcmsObservacaoDiferimento
         { 
            get { return this._valueDevolucaoMaterialIcmsObservacaoDiferimento; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsObservacaoDiferimento == value)return;
                 this._valueDevolucaoMaterialIcmsObservacaoDiferimento = value; 
            } 
        } 

       protected IncidenciaIPI? _devolucaoMaterialIpiIncideOriginal{get;private set;}
       private IncidenciaIPI? _devolucaoMaterialIpiIncideOriginalCommited{get; set;}
        private IncidenciaIPI? _valueDevolucaoMaterialIpiIncide;
         [Column("opc_devolucao_material_ipi_incide")]
        public virtual IncidenciaIPI? DevolucaoMaterialIpiIncide
         { 
            get { return this._valueDevolucaoMaterialIpiIncide; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiIncide == value)return;
                 this._valueDevolucaoMaterialIpiIncide = value; 
            } 
        } 

        public bool DevolucaoMaterialIpiIncide_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIpiIncide.HasValue && this._valueDevolucaoMaterialIpiIncide.Value == BibliotecaEntidades.Base.IncidenciaIPI.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.NaoIncide; }
         } 

        public bool DevolucaoMaterialIpiIncide_Incide
         { 
            get { return this._valueDevolucaoMaterialIpiIncide.HasValue && this._valueDevolucaoMaterialIpiIncide.Value == BibliotecaEntidades.Base.IncidenciaIPI.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.Incide; }
         } 

        public bool DevolucaoMaterialIpiIncide_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIpiIncide.HasValue && this._valueDevolucaoMaterialIpiIncide.Value == BibliotecaEntidades.Base.IncidenciaIPI.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.Suspenso; }
         } 

        public bool DevolucaoMaterialIpiIncide_UtilizaDadosProdutoNcm
         { 
            get { return this._valueDevolucaoMaterialIpiIncide.HasValue && this._valueDevolucaoMaterialIpiIncide.Value == BibliotecaEntidades.Base.IncidenciaIPI.UtilizaDadosProdutoNcm; } 
            set { if (value) this._valueDevolucaoMaterialIpiIncide = BibliotecaEntidades.Base.IncidenciaIPI.UtilizaDadosProdutoNcm; }
         } 

       protected string _devolucaoMaterialIpiCstOriginal{get;private set;}
       private string _devolucaoMaterialIpiCstOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIpiCst;
         [Column("opc_devolucao_material_ipi_cst")]
        public virtual string DevolucaoMaterialIpiCst
         { 
            get { return this._valueDevolucaoMaterialIpiCst; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiCst == value)return;
                 this._valueDevolucaoMaterialIpiCst = value; 
            } 
        } 

       protected short _devolucaoMaterialIpiModTributacaoOriginal{get;private set;}
       private short _devolucaoMaterialIpiModTributacaoOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialIpiModTributacao;
         [Column("opc_devolucao_material_ipi_mod_tributacao")]
        public virtual short DevolucaoMaterialIpiModTributacao
         { 
            get { return this._valueDevolucaoMaterialIpiModTributacao; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiModTributacao == value)return;
                 this._valueDevolucaoMaterialIpiModTributacao = value; 
            } 
        } 

       protected string _devolucaoMaterialIpiCodEnquadramentoOriginal{get;private set;}
       private string _devolucaoMaterialIpiCodEnquadramentoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIpiCodEnquadramento;
         [Column("opc_devolucao_material_ipi_cod_enquadramento")]
        public virtual string DevolucaoMaterialIpiCodEnquadramento
         { 
            get { return this._valueDevolucaoMaterialIpiCodEnquadramento; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiCodEnquadramento == value)return;
                 this._valueDevolucaoMaterialIpiCodEnquadramento = value; 
            } 
        } 

       protected double _devolucaoMaterialIpiAliquotaOriginal{get;private set;}
       private double _devolucaoMaterialIpiAliquotaOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialIpiAliquota;
         [Column("opc_devolucao_material_ipi_aliquota")]
        public virtual double DevolucaoMaterialIpiAliquota
         { 
            get { return this._valueDevolucaoMaterialIpiAliquota; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiAliquota == value)return;
                 this._valueDevolucaoMaterialIpiAliquota = value; 
            } 
        } 

       protected IncidenciaImposto? _devolucaoMaterialPisIncideOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialPisIncideOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialPisIncide;
         [Column("opc_devolucao_material_pis_incide")]
        public virtual IncidenciaImposto? DevolucaoMaterialPisIncide
         { 
            get { return this._valueDevolucaoMaterialPisIncide; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisIncide == value)return;
                 this._valueDevolucaoMaterialPisIncide = value; 
            } 
        } 

        public bool DevolucaoMaterialPisIncide_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialPisIncide.HasValue && this._valueDevolucaoMaterialPisIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialPisIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialPisIncide_Incide
         { 
            get { return this._valueDevolucaoMaterialPisIncide.HasValue && this._valueDevolucaoMaterialPisIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialPisIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialPisIncide_Suspenso
         { 
            get { return this._valueDevolucaoMaterialPisIncide.HasValue && this._valueDevolucaoMaterialPisIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialPisIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected string _devolucaoMaterialPisCstOriginal{get;private set;}
       private string _devolucaoMaterialPisCstOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialPisCst;
         [Column("opc_devolucao_material_pis_cst")]
        public virtual string DevolucaoMaterialPisCst
         { 
            get { return this._valueDevolucaoMaterialPisCst; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisCst == value)return;
                 this._valueDevolucaoMaterialPisCst = value; 
            } 
        } 

       protected short _devolucaoMaterialPisModTributacaoOriginal{get;private set;}
       private short _devolucaoMaterialPisModTributacaoOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialPisModTributacao;
         [Column("opc_devolucao_material_pis_mod_tributacao")]
        public virtual short DevolucaoMaterialPisModTributacao
         { 
            get { return this._valueDevolucaoMaterialPisModTributacao; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisModTributacao == value)return;
                 this._valueDevolucaoMaterialPisModTributacao = value; 
            } 
        } 

       protected double _devolucaoMaterialPisAliquotaOriginal{get;private set;}
       private double _devolucaoMaterialPisAliquotaOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialPisAliquota;
         [Column("opc_devolucao_material_pis_aliquota")]
        public virtual double DevolucaoMaterialPisAliquota
         { 
            get { return this._valueDevolucaoMaterialPisAliquota; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisAliquota == value)return;
                 this._valueDevolucaoMaterialPisAliquota = value; 
            } 
        } 

       protected bool _devolucaoMaterialPisImpostoRetidoOriginal{get;private set;}
       private bool _devolucaoMaterialPisImpostoRetidoOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialPisImpostoRetido;
         [Column("opc_devolucao_material_pis_imposto_retido")]
        public virtual bool DevolucaoMaterialPisImpostoRetido
         { 
            get { return this._valueDevolucaoMaterialPisImpostoRetido; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisImpostoRetido == value)return;
                 this._valueDevolucaoMaterialPisImpostoRetido = value; 
            } 
        } 

       protected IncidenciaImposto? _devolucaoMaterialCofinsIncideOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialCofinsIncideOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialCofinsIncide;
         [Column("opc_devolucao_material_cofins_incide")]
        public virtual IncidenciaImposto? DevolucaoMaterialCofinsIncide
         { 
            get { return this._valueDevolucaoMaterialCofinsIncide; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsIncide == value)return;
                 this._valueDevolucaoMaterialCofinsIncide = value; 
            } 
        } 

        public bool DevolucaoMaterialCofinsIncide_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialCofinsIncide.HasValue && this._valueDevolucaoMaterialCofinsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialCofinsIncide_Incide
         { 
            get { return this._valueDevolucaoMaterialCofinsIncide.HasValue && this._valueDevolucaoMaterialCofinsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialCofinsIncide_Suspenso
         { 
            get { return this._valueDevolucaoMaterialCofinsIncide.HasValue && this._valueDevolucaoMaterialCofinsIncide.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialCofinsIncide = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected string _devolucaoMaterialCofinsCstOriginal{get;private set;}
       private string _devolucaoMaterialCofinsCstOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialCofinsCst;
         [Column("opc_devolucao_material_cofins_cst")]
        public virtual string DevolucaoMaterialCofinsCst
         { 
            get { return this._valueDevolucaoMaterialCofinsCst; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsCst == value)return;
                 this._valueDevolucaoMaterialCofinsCst = value; 
            } 
        } 

       protected short _devolucaoMaterialCofinsModTributacaoOriginal{get;private set;}
       private short _devolucaoMaterialCofinsModTributacaoOriginalCommited{get; set;}
        private short _valueDevolucaoMaterialCofinsModTributacao;
         [Column("opc_devolucao_material_cofins_mod_tributacao")]
        public virtual short DevolucaoMaterialCofinsModTributacao
         { 
            get { return this._valueDevolucaoMaterialCofinsModTributacao; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsModTributacao == value)return;
                 this._valueDevolucaoMaterialCofinsModTributacao = value; 
            } 
        } 

       protected double _devolucaoMaterialCofinsAliquotaOriginal{get;private set;}
       private double _devolucaoMaterialCofinsAliquotaOriginalCommited{get; set;}
        private double _valueDevolucaoMaterialCofinsAliquota;
         [Column("opc_devolucao_material_cofins_aliquota")]
        public virtual double DevolucaoMaterialCofinsAliquota
         { 
            get { return this._valueDevolucaoMaterialCofinsAliquota; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsAliquota == value)return;
                 this._valueDevolucaoMaterialCofinsAliquota = value; 
            } 
        } 

       protected bool _devolucaoMaterialCofinsImpostoRetidoOriginal{get;private set;}
       private bool _devolucaoMaterialCofinsImpostoRetidoOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialCofinsImpostoRetido;
         [Column("opc_devolucao_material_cofins_imposto_retido")]
        public virtual bool DevolucaoMaterialCofinsImpostoRetido
         { 
            get { return this._valueDevolucaoMaterialCofinsImpostoRetido; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsImpostoRetido == value)return;
                 this._valueDevolucaoMaterialCofinsImpostoRetido = value; 
            } 
        } 

       protected string _icmsObservacaoCreditoOriginal{get;private set;}
       private string _icmsObservacaoCreditoOriginalCommited{get; set;}
        private string _valueIcmsObservacaoCredito;
         [Column("opc_icms_observacao_credito")]
        public virtual string IcmsObservacaoCredito
         { 
            get { return this._valueIcmsObservacaoCredito; } 
            set 
            { 
                if (this._valueIcmsObservacaoCredito == value)return;
                 this._valueIcmsObservacaoCredito = value; 
            } 
        } 

       protected string _devolucaoMaterialIcmsObservacaoCreditoOriginal{get;private set;}
       private string _devolucaoMaterialIcmsObservacaoCreditoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIcmsObservacaoCredito;
         [Column("opc_devolucao_material_icms_observacao_credito")]
        public virtual string DevolucaoMaterialIcmsObservacaoCredito
         { 
            get { return this._valueDevolucaoMaterialIcmsObservacaoCredito; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsObservacaoCredito == value)return;
                 this._valueDevolucaoMaterialIcmsObservacaoCredito = value; 
            } 
        } 

       protected short? _devolucaoMaterialIcmsMotivoDesoneracaoOriginal{get;private set;}
       private short? _devolucaoMaterialIcmsMotivoDesoneracaoOriginalCommited{get; set;}
        private short? _valueDevolucaoMaterialIcmsMotivoDesoneracao;
         [Column("opc_devolucao_material_icms_motivo_desoneracao")]
        public virtual short? DevolucaoMaterialIcmsMotivoDesoneracao
         { 
            get { return this._valueDevolucaoMaterialIcmsMotivoDesoneracao; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsMotivoDesoneracao == value)return;
                 this._valueDevolucaoMaterialIcmsMotivoDesoneracao = value; 
            } 
        } 

       protected short? _icmsMotivoDesoneracaoOriginal{get;private set;}
       private short? _icmsMotivoDesoneracaoOriginalCommited{get; set;}
        private short? _valueIcmsMotivoDesoneracao;
         [Column("opc_icms_motivo_desoneracao")]
        public virtual short? IcmsMotivoDesoneracao
         { 
            get { return this._valueIcmsMotivoDesoneracao; } 
            set 
            { 
                if (this._valueIcmsMotivoDesoneracao == value)return;
                 this._valueIcmsMotivoDesoneracao = value; 
            } 
        } 

       protected bool _ipiSomaFreteBcOriginal{get;private set;}
       private bool _ipiSomaFreteBcOriginalCommited{get; set;}
        private bool _valueIpiSomaFreteBc;
         [Column("opc_ipi_soma_frete_bc")]
        public virtual bool IpiSomaFreteBc
         { 
            get { return this._valueIpiSomaFreteBc; } 
            set 
            { 
                if (this._valueIpiSomaFreteBc == value)return;
                 this._valueIpiSomaFreteBc = value; 
            } 
        } 

       protected bool _devolucaoMaterialIpiSomaFreteBcOriginal{get;private set;}
       private bool _devolucaoMaterialIpiSomaFreteBcOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialIpiSomaFreteBc;
         [Column("opc_devolucao_material_ipi_soma_frete_bc")]
        public virtual bool DevolucaoMaterialIpiSomaFreteBc
         { 
            get { return this._valueDevolucaoMaterialIpiSomaFreteBc; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiSomaFreteBc == value)return;
                 this._valueDevolucaoMaterialIpiSomaFreteBc = value; 
            } 
        } 

       protected EasiValidaPrecos _validaPrecosOriginal{get;private set;}
       private EasiValidaPrecos _validaPrecosOriginalCommited{get; set;}
        private EasiValidaPrecos _valueValidaPrecos;
         [Column("opc_valida_precos")]
        public virtual EasiValidaPrecos ValidaPrecos
         { 
            get { return this._valueValidaPrecos; } 
            set 
            { 
                if (this._valueValidaPrecos == value)return;
                 this._valueValidaPrecos = value; 
            } 
        } 

        public bool ValidaPrecos_NaoValida
         { 
            get { return this._valueValidaPrecos == BibliotecaEntidades.Base.EasiValidaPrecos.NaoValida; } 
            set { if (value) this._valueValidaPrecos = BibliotecaEntidades.Base.EasiValidaPrecos.NaoValida; }
         } 

        public bool ValidaPrecos_ValidaComBloqueio
         { 
            get { return this._valueValidaPrecos == BibliotecaEntidades.Base.EasiValidaPrecos.ValidaComBloqueio; } 
            set { if (value) this._valueValidaPrecos = BibliotecaEntidades.Base.EasiValidaPrecos.ValidaComBloqueio; }
         } 

        public bool ValidaPrecos_ValidaSemBloqueio
         { 
            get { return this._valueValidaPrecos == BibliotecaEntidades.Base.EasiValidaPrecos.ValidaSemBloqueio; } 
            set { if (value) this._valueValidaPrecos = BibliotecaEntidades.Base.EasiValidaPrecos.ValidaSemBloqueio; }
         } 

       protected bool _devolucaoMaterialSeparadaOriginal{get;private set;}
       private bool _devolucaoMaterialSeparadaOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialSeparada;
         [Column("opc_devolucao_material_separada")]
        public virtual bool DevolucaoMaterialSeparada
         { 
            get { return this._valueDevolucaoMaterialSeparada; } 
            set 
            { 
                if (this._valueDevolucaoMaterialSeparada == value)return;
                 this._valueDevolucaoMaterialSeparada = value; 
            } 
        } 

       protected string _devolucaoMaterialSeparadaNatuezaOperacaoOriginal{get;private set;}
       private string _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialSeparadaNatuezaOperacao;
         [Column("opc_devolucao_material_separada_natueza_operacao")]
        public virtual string DevolucaoMaterialSeparadaNatuezaOperacao
         { 
            get { return this._valueDevolucaoMaterialSeparadaNatuezaOperacao; } 
            set 
            { 
                if (this._valueDevolucaoMaterialSeparadaNatuezaOperacao == value)return;
                 this._valueDevolucaoMaterialSeparadaNatuezaOperacao = value; 
            } 
        } 

       protected bool _pisDescontarIcmsBcOriginal{get;private set;}
       private bool _pisDescontarIcmsBcOriginalCommited{get; set;}
        private bool _valuePisDescontarIcmsBc;
         [Column("opc_pis_descontar_icms_bc")]
        public virtual bool PisDescontarIcmsBc
         { 
            get { return this._valuePisDescontarIcmsBc; } 
            set 
            { 
                if (this._valuePisDescontarIcmsBc == value)return;
                 this._valuePisDescontarIcmsBc = value; 
            } 
        } 

       protected bool _cofinsDescontarIcmsBcOriginal{get;private set;}
       private bool _cofinsDescontarIcmsBcOriginalCommited{get; set;}
        private bool _valueCofinsDescontarIcmsBc;
         [Column("opc_cofins_descontar_icms_bc")]
        public virtual bool CofinsDescontarIcmsBc
         { 
            get { return this._valueCofinsDescontarIcmsBc; } 
            set 
            { 
                if (this._valueCofinsDescontarIcmsBc == value)return;
                 this._valueCofinsDescontarIcmsBc = value; 
            } 
        } 

       private List<long> _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaOriginal;
       private List<Entidades.OperacaoCompletaIcmsAliquotaClass > _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass> _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass> CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta 
       { 
           get { if(!_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded && !this.DisableLoadCollection){this.LoadCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta();}
return this._valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta; } 
           set 
           { 
               this._valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta = value; 
               this._valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosClass > _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta();}
return this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassOperacaoCompletaOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassOperacaoCompletaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassOperacaoCompleta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassOperacaoCompleta 
       { 
           get { if(!_valueCollectionPedidoItemClassOperacaoCompletaLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassOperacaoCompleta();}
return this._valueCollectionPedidoItemClassOperacaoCompleta; } 
           set 
           { 
               this._valueCollectionPedidoItemClassOperacaoCompleta = value; 
               this._valueCollectionPedidoItemClassOperacaoCompletaLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros 
       { 
           get { if(!_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros();}
return this._valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros; } 
           set 
           { 
               this._valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros = value; 
               this._valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded = true; 
           } 
       } 

       private List<long> _collectionPostoTrabalhoClassOperacaoCompletaOriginal;
       private List<Entidades.PostoTrabalhoClass > _collectionPostoTrabalhoClassOperacaoCompletaRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PostoTrabalhoClass> _valueCollectionPostoTrabalhoClassOperacaoCompleta { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PostoTrabalhoClass> CollectionPostoTrabalhoClassOperacaoCompleta 
       { 
           get { if(!_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded && !this.DisableLoadCollection){this.LoadCollectionPostoTrabalhoClassOperacaoCompleta();}
return this._valueCollectionPostoTrabalhoClassOperacaoCompleta; } 
           set 
           { 
               this._valueCollectionPostoTrabalhoClassOperacaoCompleta = value; 
               this._valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded = true; 
           } 
       } 

        public OperacaoCompletaBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.ConsumidorFinal = false;
           this.PresencaConsumidor = (PresencaComprador)1;
           this.GerarContasReceber = true;
           this.IcmsIncide = (IncidenciaImposto)1;
           this.IcmsPartilha = false;
           this.IcmsSomaFreteBc = false;
           this.IcmsAliquotaCredito = 0;
           this.IcmsModDetBc = 0;
           this.IcmsReducaoBc = false;
           this.IcmsPercentualReducaoBc = 0;
           this.IcmsPercentualBcOperacaoPropria = 0;
           this.IcmsSt = 0;
           this.IcmsModDetBcSt = 0;
           this.IcmsPercentualReducaoBcSt = 0;
           this.IcmsPercentualDiferimento = 0;
           this.IpiIncide = (IncidenciaIPI)1;
           this.IpiModTributacao = 0;
           this.IpiAliquota = 0;
           this.PisIncide = (IncidenciaImposto)1;
           this.PisModTributacao = 0;
           this.PisAliquota = 0;
           this.PisImpostoRetido = false;
           this.CofinsIncide = (IncidenciaImposto)1;
           this.CofinsModTributacao = 0;
           this.CofinsAliquota = 0;
           this.CofinsImpostoRetido = false;
           this.EntregaFutura = false;
           this.DevolucaoMaterial = false;
           this.DevolucaoMaterialIcmsPartilha = false;
           this.DevolucaoMaterialIcmsSomaFreteBc = false;
           this.DevolucaoMaterialIcmsAliquotaCredito = 0;
           this.DevolucaoMaterialIcmsModDetBc = 0;
           this.DevolucaoMaterialIcmsReducaoBc = false;
           this.DevolucaoMaterialIcmsPercentualReducaoBc = 0;
           this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria = 0;
           this.DevolucaoMaterialIcmsSt = 0;
           this.DevolucaoMaterialIcmsModDetBcSt = 0;
           this.DevolucaoMaterialIcmsPercentualReducaoBcSt = 0;
           this.DevolucaoMaterialIcmsPercentualDiferimento = 0;
           this.DevolucaoMaterialIpiIncide = (IncidenciaIPI?)1;
           this.DevolucaoMaterialIpiModTributacao = 0;
           this.DevolucaoMaterialIpiAliquota = 0;
           this.DevolucaoMaterialPisModTributacao = 0;
           this.DevolucaoMaterialPisAliquota = 0;
           this.DevolucaoMaterialPisImpostoRetido = false;
           this.DevolucaoMaterialCofinsModTributacao = 0;
           this.DevolucaoMaterialCofinsAliquota = 0;
           this.DevolucaoMaterialCofinsImpostoRetido = false;
           this.IpiSomaFreteBc = false;
           this.DevolucaoMaterialIpiSomaFreteBc = false;
           this.ValidaPrecos = (EasiValidaPrecos)1;
           this.DevolucaoMaterialSeparada = false;
           this.PisDescontarIcmsBc = false;
           this.CofinsDescontarIcmsBc = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OperacaoCompletaClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OperacaoCompletaClass) GetEntity(typeof(OperacaoCompletaClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged = true;
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged = true; 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.OperacaoCompletaIcmsAliquotaClass item in e.OldItems) 
                 { 
                     _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged = true; 
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.OperacaoCompletaIcmsAliquotaClass item in _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta) 
                 { 
                     _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta()
         {
            try
            {
                 ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass> oc;
                _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged = false;
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged = false;
                _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos = new List<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                }
                else{ 
                   Entidades.OperacaoCompletaIcmsAliquotaClass search = new Entidades.OperacaoCompletaIcmsAliquotaClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OperacaoCompletaIcmsAliquotaClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoCompleta", this),                     }                       ).Cast<Entidades.OperacaoCompletaIcmsAliquotaClass>().ToList());
                 }
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta = new BindingList<Entidades.OperacaoCompletaIcmsAliquotaClass>(oc); 
                 _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaOriginal= (from a in _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta select a.ID).ToList();
                 _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded = true;
                 oc.CollectionChanged += CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosClass search = new Entidades.OrdemProducaoEnvioTerceirosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoCompleta", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta = new BindingList<Entidades.OrdemProducaoEnvioTerceirosClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassOperacaoCompletaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassOperacaoCompletaChanged = true;
                  _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassOperacaoCompletaChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassOperacaoCompletaChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassOperacaoCompleta) 
                 { 
                     _collectionPedidoItemClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassOperacaoCompleta()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassOperacaoCompletaChanged = false;
                 _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged = false;
                _collectionPedidoItemClassOperacaoCompletaRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoCompleta", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassOperacaoCompleta = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassOperacaoCompletaOriginal= (from a in _valueCollectionPedidoItemClassOperacaoCompleta select a.ID).ToList();
                 _valueCollectionPedidoItemClassOperacaoCompletaLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassOperacaoCompletaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassOperacaoCompleta+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged = true;
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros) 
                 { 
                     _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged = false;
                 _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged = false;
                _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoCompletaEnvioTerceiros", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros select a.ID).ToList();
                 _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPostoTrabalhoClassOperacaoCompletaChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged = true;
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged = true; 
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionPostoTrabalhoClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged = true; 
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in _valueCollectionPostoTrabalhoClassOperacaoCompleta) 
                 { 
                     _collectionPostoTrabalhoClassOperacaoCompletaRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPostoTrabalhoClassOperacaoCompleta()
         {
            try
            {
                 ObservableCollection<Entidades.PostoTrabalhoClass> oc;
                _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged = false;
                 _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged = false;
                _collectionPostoTrabalhoClassOperacaoCompletaRemovidos = new List<Entidades.PostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PostoTrabalhoClass>();
                }
                else{ 
                   Entidades.PostoTrabalhoClass search = new Entidades.PostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoCompleta", this),                     }                       ).Cast<Entidades.PostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionPostoTrabalhoClassOperacaoCompleta = new BindingList<Entidades.PostoTrabalhoClass>(oc); 
                 _collectionPostoTrabalhoClassOperacaoCompletaOriginal= (from a in _valueCollectionPostoTrabalhoClassOperacaoCompleta select a.ID).ToList();
                 _valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded = true;
                 oc.CollectionChanged += CollectionPostoTrabalhoClassOperacaoCompletaChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPostoTrabalhoClassOperacaoCompleta+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Identificacao))
                {
                    throw new Exception(ErroIdentificacaoObrigatorio);
                }
                if (Identificacao.Length >70)
                {
                    throw new Exception( ErroIdentificacaoComprimento);
                }
                if (string.IsNullOrEmpty(NaturezaOperacao))
                {
                    throw new Exception(ErroNaturezaOperacaoObrigatorio);
                }
                if (NaturezaOperacao.Length >255)
                {
                    throw new Exception( ErroNaturezaOperacaoComprimento);
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
                    "  public.operacao_completa  " +
                    "WHERE " +
                    "  id_operacao_completa = :id";
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
                        "  public.operacao_completa   " +
                        "SET  " + 
                        "  opc_identificacao = :opc_identificacao, " + 
                        "  opc_descricao = :opc_descricao, " + 
                        "  opc_cfop = :opc_cfop, " + 
                        "  opc_cfop_fora_estado = :opc_cfop_fora_estado, " + 
                        "  opc_natureza_operacao = :opc_natureza_operacao, " + 
                        "  opc_consumidor_final = :opc_consumidor_final, " + 
                        "  opc_presenca_consumidor = :opc_presenca_consumidor, " + 
                        "  opc_gerar_contas_receber = :opc_gerar_contas_receber, " + 
                        "  opc_icms_incide = :opc_icms_incide, " + 
                        "  opc_icms_partilha = :opc_icms_partilha, " + 
                        "  opc_icms_soma_frete_bc = :opc_icms_soma_frete_bc, " + 
                        "  opc_icms_cst = :opc_icms_cst, " + 
                        "  opc_icms_aliquota_credito = :opc_icms_aliquota_credito, " + 
                        "  opc_icms_mod_det_bc = :opc_icms_mod_det_bc, " + 
                        "  opc_icms_reducao_bc = :opc_icms_reducao_bc, " + 
                        "  opc_icms_percentual_reducao_bc = :opc_icms_percentual_reducao_bc, " + 
                        "  opc_icms_percentual_bc_operacao_propria = :opc_icms_percentual_bc_operacao_propria, " + 
                        "  opc_icms_st = :opc_icms_st, " + 
                        "  opc_icms_mod_det_bc_st = :opc_icms_mod_det_bc_st, " + 
                        "  opc_icms_percentual_reducao_bc_st = :opc_icms_percentual_reducao_bc_st, " + 
                        "  opc_icms_percentual_diferimento = :opc_icms_percentual_diferimento, " + 
                        "  opc_icms_observacao_diferimento = :opc_icms_observacao_diferimento, " + 
                        "  opc_ipi_incide = :opc_ipi_incide, " + 
                        "  opc_ipi_cst = :opc_ipi_cst, " + 
                        "  opc_ipi_mod_tributacao = :opc_ipi_mod_tributacao, " + 
                        "  opc_ipi_cod_enquadramento = :opc_ipi_cod_enquadramento, " + 
                        "  opc_ipi_aliquota = :opc_ipi_aliquota, " + 
                        "  opc_pis_incide = :opc_pis_incide, " + 
                        "  opc_pis_cst = :opc_pis_cst, " + 
                        "  opc_pis_mod_tributacao = :opc_pis_mod_tributacao, " + 
                        "  opc_pis_aliquota = :opc_pis_aliquota, " + 
                        "  opc_pis_imposto_retido = :opc_pis_imposto_retido, " + 
                        "  opc_cofins_incide = :opc_cofins_incide, " + 
                        "  opc_cofins_cst = :opc_cofins_cst, " + 
                        "  opc_cofins_mod_tributacao = :opc_cofins_mod_tributacao, " + 
                        "  opc_cofins_aliquota = :opc_cofins_aliquota, " + 
                        "  opc_cofins_imposto_retido = :opc_cofins_imposto_retido, " + 
                        "  opc_entrega_futura = :opc_entrega_futura, " + 
                        "  opc_entrega_futura_cfop_remessa = :opc_entrega_futura_cfop_remessa, " + 
                        "  opc_entrega_futura_cfop_remessa_fora_estado = :opc_entrega_futura_cfop_remessa_fora_estado, " + 
                        "  opc_entrega_futura_natureza_operacao_remessa = :opc_entrega_futura_natureza_operacao_remessa, " + 
                        "  opc_devolucao_material = :opc_devolucao_material, " + 
                        "  opc_devolucao_material_cfop = :opc_devolucao_material_cfop, " + 
                        "  opc_devolucao_material_cfop_fora_estado = :opc_devolucao_material_cfop_fora_estado, " + 
                        "  opc_devolucao_material_icms_incide = :opc_devolucao_material_icms_incide, " + 
                        "  opc_devolucao_material_icms_partilha = :opc_devolucao_material_icms_partilha, " + 
                        "  opc_devolucao_material_icms_soma_frete_bc = :opc_devolucao_material_icms_soma_frete_bc, " + 
                        "  opc_devolucao_material_icms_cst = :opc_devolucao_material_icms_cst, " + 
                        "  opc_devolucao_material_icms_aliquota_credito = :opc_devolucao_material_icms_aliquota_credito, " + 
                        "  opc_devolucao_material_icms_mod_det_bc = :opc_devolucao_material_icms_mod_det_bc, " + 
                        "  opc_devolucao_material_icms_reducao_bc = :opc_devolucao_material_icms_reducao_bc, " + 
                        "  opc_devolucao_material_icms_percentual_reducao_bc = :opc_devolucao_material_icms_percentual_reducao_bc, " + 
                        "  opc_devolucao_material_icms_percentual_bc_operacao_propria = :opc_devolucao_material_icms_percentual_bc_operacao_propria, " + 
                        "  opc_devolucao_material_icms_st = :opc_devolucao_material_icms_st, " + 
                        "  opc_devolucao_material_icms_mod_det_bc_st = :opc_devolucao_material_icms_mod_det_bc_st, " + 
                        "  opc_devolucao_material_icms_percentual_reducao_bc_st = :opc_devolucao_material_icms_percentual_reducao_bc_st, " + 
                        "  opc_devolucao_material_icms_percentual_diferimento = :opc_devolucao_material_icms_percentual_diferimento, " + 
                        "  opc_devolucao_material_icms_observacao_diferimento = :opc_devolucao_material_icms_observacao_diferimento, " + 
                        "  opc_devolucao_material_ipi_incide = :opc_devolucao_material_ipi_incide, " + 
                        "  opc_devolucao_material_ipi_cst = :opc_devolucao_material_ipi_cst, " + 
                        "  opc_devolucao_material_ipi_mod_tributacao = :opc_devolucao_material_ipi_mod_tributacao, " + 
                        "  opc_devolucao_material_ipi_cod_enquadramento = :opc_devolucao_material_ipi_cod_enquadramento, " + 
                        "  opc_devolucao_material_ipi_aliquota = :opc_devolucao_material_ipi_aliquota, " + 
                        "  opc_devolucao_material_pis_incide = :opc_devolucao_material_pis_incide, " + 
                        "  opc_devolucao_material_pis_cst = :opc_devolucao_material_pis_cst, " + 
                        "  opc_devolucao_material_pis_mod_tributacao = :opc_devolucao_material_pis_mod_tributacao, " + 
                        "  opc_devolucao_material_pis_aliquota = :opc_devolucao_material_pis_aliquota, " + 
                        "  opc_devolucao_material_pis_imposto_retido = :opc_devolucao_material_pis_imposto_retido, " + 
                        "  opc_devolucao_material_cofins_incide = :opc_devolucao_material_cofins_incide, " + 
                        "  opc_devolucao_material_cofins_cst = :opc_devolucao_material_cofins_cst, " + 
                        "  opc_devolucao_material_cofins_mod_tributacao = :opc_devolucao_material_cofins_mod_tributacao, " + 
                        "  opc_devolucao_material_cofins_aliquota = :opc_devolucao_material_cofins_aliquota, " + 
                        "  opc_devolucao_material_cofins_imposto_retido = :opc_devolucao_material_cofins_imposto_retido, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  opc_icms_observacao_credito = :opc_icms_observacao_credito, " + 
                        "  opc_devolucao_material_icms_observacao_credito = :opc_devolucao_material_icms_observacao_credito, " + 
                        "  opc_devolucao_material_icms_motivo_desoneracao = :opc_devolucao_material_icms_motivo_desoneracao, " + 
                        "  opc_icms_motivo_desoneracao = :opc_icms_motivo_desoneracao, " + 
                        "  opc_ipi_soma_frete_bc = :opc_ipi_soma_frete_bc, " + 
                        "  opc_devolucao_material_ipi_soma_frete_bc = :opc_devolucao_material_ipi_soma_frete_bc, " + 
                        "  opc_valida_precos = :opc_valida_precos, " + 
                        "  opc_devolucao_material_separada = :opc_devolucao_material_separada, " + 
                        "  opc_devolucao_material_separada_natueza_operacao = :opc_devolucao_material_separada_natueza_operacao, " + 
                        "  opc_pis_descontar_icms_bc = :opc_pis_descontar_icms_bc, " + 
                        "  opc_cofins_descontar_icms_bc = :opc_cofins_descontar_icms_bc "+
                        "WHERE  " +
                        "  id_operacao_completa = :id " +
                        "RETURNING id_operacao_completa;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.operacao_completa " +
                        "( " +
                        "  opc_identificacao , " + 
                        "  opc_descricao , " + 
                        "  opc_cfop , " + 
                        "  opc_cfop_fora_estado , " + 
                        "  opc_natureza_operacao , " + 
                        "  opc_consumidor_final , " + 
                        "  opc_presenca_consumidor , " + 
                        "  opc_gerar_contas_receber , " + 
                        "  opc_icms_incide , " + 
                        "  opc_icms_partilha , " + 
                        "  opc_icms_soma_frete_bc , " + 
                        "  opc_icms_cst , " + 
                        "  opc_icms_aliquota_credito , " + 
                        "  opc_icms_mod_det_bc , " + 
                        "  opc_icms_reducao_bc , " + 
                        "  opc_icms_percentual_reducao_bc , " + 
                        "  opc_icms_percentual_bc_operacao_propria , " + 
                        "  opc_icms_st , " + 
                        "  opc_icms_mod_det_bc_st , " + 
                        "  opc_icms_percentual_reducao_bc_st , " + 
                        "  opc_icms_percentual_diferimento , " + 
                        "  opc_icms_observacao_diferimento , " + 
                        "  opc_ipi_incide , " + 
                        "  opc_ipi_cst , " + 
                        "  opc_ipi_mod_tributacao , " + 
                        "  opc_ipi_cod_enquadramento , " + 
                        "  opc_ipi_aliquota , " + 
                        "  opc_pis_incide , " + 
                        "  opc_pis_cst , " + 
                        "  opc_pis_mod_tributacao , " + 
                        "  opc_pis_aliquota , " + 
                        "  opc_pis_imposto_retido , " + 
                        "  opc_cofins_incide , " + 
                        "  opc_cofins_cst , " + 
                        "  opc_cofins_mod_tributacao , " + 
                        "  opc_cofins_aliquota , " + 
                        "  opc_cofins_imposto_retido , " + 
                        "  opc_entrega_futura , " + 
                        "  opc_entrega_futura_cfop_remessa , " + 
                        "  opc_entrega_futura_cfop_remessa_fora_estado , " + 
                        "  opc_entrega_futura_natureza_operacao_remessa , " + 
                        "  opc_devolucao_material , " + 
                        "  opc_devolucao_material_cfop , " + 
                        "  opc_devolucao_material_cfop_fora_estado , " + 
                        "  opc_devolucao_material_icms_incide , " + 
                        "  opc_devolucao_material_icms_partilha , " + 
                        "  opc_devolucao_material_icms_soma_frete_bc , " + 
                        "  opc_devolucao_material_icms_cst , " + 
                        "  opc_devolucao_material_icms_aliquota_credito , " + 
                        "  opc_devolucao_material_icms_mod_det_bc , " + 
                        "  opc_devolucao_material_icms_reducao_bc , " + 
                        "  opc_devolucao_material_icms_percentual_reducao_bc , " + 
                        "  opc_devolucao_material_icms_percentual_bc_operacao_propria , " + 
                        "  opc_devolucao_material_icms_st , " + 
                        "  opc_devolucao_material_icms_mod_det_bc_st , " + 
                        "  opc_devolucao_material_icms_percentual_reducao_bc_st , " + 
                        "  opc_devolucao_material_icms_percentual_diferimento , " + 
                        "  opc_devolucao_material_icms_observacao_diferimento , " + 
                        "  opc_devolucao_material_ipi_incide , " + 
                        "  opc_devolucao_material_ipi_cst , " + 
                        "  opc_devolucao_material_ipi_mod_tributacao , " + 
                        "  opc_devolucao_material_ipi_cod_enquadramento , " + 
                        "  opc_devolucao_material_ipi_aliquota , " + 
                        "  opc_devolucao_material_pis_incide , " + 
                        "  opc_devolucao_material_pis_cst , " + 
                        "  opc_devolucao_material_pis_mod_tributacao , " + 
                        "  opc_devolucao_material_pis_aliquota , " + 
                        "  opc_devolucao_material_pis_imposto_retido , " + 
                        "  opc_devolucao_material_cofins_incide , " + 
                        "  opc_devolucao_material_cofins_cst , " + 
                        "  opc_devolucao_material_cofins_mod_tributacao , " + 
                        "  opc_devolucao_material_cofins_aliquota , " + 
                        "  opc_devolucao_material_cofins_imposto_retido , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  opc_icms_observacao_credito , " + 
                        "  opc_devolucao_material_icms_observacao_credito , " + 
                        "  opc_devolucao_material_icms_motivo_desoneracao , " + 
                        "  opc_icms_motivo_desoneracao , " + 
                        "  opc_ipi_soma_frete_bc , " + 
                        "  opc_devolucao_material_ipi_soma_frete_bc , " + 
                        "  opc_valida_precos , " + 
                        "  opc_devolucao_material_separada , " + 
                        "  opc_devolucao_material_separada_natueza_operacao , " + 
                        "  opc_pis_descontar_icms_bc , " + 
                        "  opc_cofins_descontar_icms_bc  "+
                        ")  " +
                        "VALUES ( " +
                        "  :opc_identificacao , " + 
                        "  :opc_descricao , " + 
                        "  :opc_cfop , " + 
                        "  :opc_cfop_fora_estado , " + 
                        "  :opc_natureza_operacao , " + 
                        "  :opc_consumidor_final , " + 
                        "  :opc_presenca_consumidor , " + 
                        "  :opc_gerar_contas_receber , " + 
                        "  :opc_icms_incide , " + 
                        "  :opc_icms_partilha , " + 
                        "  :opc_icms_soma_frete_bc , " + 
                        "  :opc_icms_cst , " + 
                        "  :opc_icms_aliquota_credito , " + 
                        "  :opc_icms_mod_det_bc , " + 
                        "  :opc_icms_reducao_bc , " + 
                        "  :opc_icms_percentual_reducao_bc , " + 
                        "  :opc_icms_percentual_bc_operacao_propria , " + 
                        "  :opc_icms_st , " + 
                        "  :opc_icms_mod_det_bc_st , " + 
                        "  :opc_icms_percentual_reducao_bc_st , " + 
                        "  :opc_icms_percentual_diferimento , " + 
                        "  :opc_icms_observacao_diferimento , " + 
                        "  :opc_ipi_incide , " + 
                        "  :opc_ipi_cst , " + 
                        "  :opc_ipi_mod_tributacao , " + 
                        "  :opc_ipi_cod_enquadramento , " + 
                        "  :opc_ipi_aliquota , " + 
                        "  :opc_pis_incide , " + 
                        "  :opc_pis_cst , " + 
                        "  :opc_pis_mod_tributacao , " + 
                        "  :opc_pis_aliquota , " + 
                        "  :opc_pis_imposto_retido , " + 
                        "  :opc_cofins_incide , " + 
                        "  :opc_cofins_cst , " + 
                        "  :opc_cofins_mod_tributacao , " + 
                        "  :opc_cofins_aliquota , " + 
                        "  :opc_cofins_imposto_retido , " + 
                        "  :opc_entrega_futura , " + 
                        "  :opc_entrega_futura_cfop_remessa , " + 
                        "  :opc_entrega_futura_cfop_remessa_fora_estado , " + 
                        "  :opc_entrega_futura_natureza_operacao_remessa , " + 
                        "  :opc_devolucao_material , " + 
                        "  :opc_devolucao_material_cfop , " + 
                        "  :opc_devolucao_material_cfop_fora_estado , " + 
                        "  :opc_devolucao_material_icms_incide , " + 
                        "  :opc_devolucao_material_icms_partilha , " + 
                        "  :opc_devolucao_material_icms_soma_frete_bc , " + 
                        "  :opc_devolucao_material_icms_cst , " + 
                        "  :opc_devolucao_material_icms_aliquota_credito , " + 
                        "  :opc_devolucao_material_icms_mod_det_bc , " + 
                        "  :opc_devolucao_material_icms_reducao_bc , " + 
                        "  :opc_devolucao_material_icms_percentual_reducao_bc , " + 
                        "  :opc_devolucao_material_icms_percentual_bc_operacao_propria , " + 
                        "  :opc_devolucao_material_icms_st , " + 
                        "  :opc_devolucao_material_icms_mod_det_bc_st , " + 
                        "  :opc_devolucao_material_icms_percentual_reducao_bc_st , " + 
                        "  :opc_devolucao_material_icms_percentual_diferimento , " + 
                        "  :opc_devolucao_material_icms_observacao_diferimento , " + 
                        "  :opc_devolucao_material_ipi_incide , " + 
                        "  :opc_devolucao_material_ipi_cst , " + 
                        "  :opc_devolucao_material_ipi_mod_tributacao , " + 
                        "  :opc_devolucao_material_ipi_cod_enquadramento , " + 
                        "  :opc_devolucao_material_ipi_aliquota , " + 
                        "  :opc_devolucao_material_pis_incide , " + 
                        "  :opc_devolucao_material_pis_cst , " + 
                        "  :opc_devolucao_material_pis_mod_tributacao , " + 
                        "  :opc_devolucao_material_pis_aliquota , " + 
                        "  :opc_devolucao_material_pis_imposto_retido , " + 
                        "  :opc_devolucao_material_cofins_incide , " + 
                        "  :opc_devolucao_material_cofins_cst , " + 
                        "  :opc_devolucao_material_cofins_mod_tributacao , " + 
                        "  :opc_devolucao_material_cofins_aliquota , " + 
                        "  :opc_devolucao_material_cofins_imposto_retido , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :opc_icms_observacao_credito , " + 
                        "  :opc_devolucao_material_icms_observacao_credito , " + 
                        "  :opc_devolucao_material_icms_motivo_desoneracao , " + 
                        "  :opc_icms_motivo_desoneracao , " + 
                        "  :opc_ipi_soma_frete_bc , " + 
                        "  :opc_devolucao_material_ipi_soma_frete_bc , " + 
                        "  :opc_valida_precos , " + 
                        "  :opc_devolucao_material_separada , " + 
                        "  :opc_devolucao_material_separada_natueza_operacao , " + 
                        "  :opc_pis_descontar_icms_bc , " + 
                        "  :opc_cofins_descontar_icms_bc  "+
                        ")RETURNING id_operacao_completa;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_identificacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Identificacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cfop_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CfopForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_natureza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaturezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_consumidor_final", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConsumidorFinal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_presenca_consumidor", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PresencaConsumidor);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_gerar_contas_receber", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GerarContasReceber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IcmsIncide);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_partilha", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPartilha ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_soma_frete_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsSomaFreteBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_aliquota_credito", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsAliquotaCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_mod_det_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsModDetBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_reducao_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPercentualReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_percentual_bc_operacao_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPercentualBcOperacaoPropria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_mod_det_bc_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsModDetBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPercentualReducaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsPercentualDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_observacao_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsObservacaoDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IpiIncide);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_cod_enquadramento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiCodEnquadramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PisIncide);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_imposto_retido", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.CofinsIncide);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_imposto_retido", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_entrega_futura", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFutura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_entrega_futura_cfop_remessa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaCfopRemessa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_entrega_futura_cfop_remessa_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaCfopRemessaForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_entrega_futura_natureza_operacao_remessa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaNaturezaOperacaoRemessa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cfop_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCfopForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIcmsIncide.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIcmsIncide) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_partilha", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsPartilha ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_soma_frete_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsSomaFreteBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_aliquota_credito", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsAliquotaCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_mod_det_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsModDetBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_reducao_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_percentual_reducao_bc", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsPercentualReducaoBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_percentual_bc_operacao_propria", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_mod_det_bc_st", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsModDetBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_percentual_reducao_bc_st", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsPercentualReducaoBcSt ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_percentual_diferimento", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsPercentualDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_observacao_diferimento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsObservacaoDiferimento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIpiIncide.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIpiIncide) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_cod_enquadramento", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiCodEnquadramento ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_pis_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialPisIncide.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialPisIncide) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_pis_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialPisCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_pis_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialPisModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_pis_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialPisAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_pis_imposto_retido", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialPisImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cofins_incide", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialCofinsIncide.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialCofinsIncide) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cofins_cst", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCofinsCst ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cofins_mod_tributacao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCofinsModTributacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cofins_aliquota", NpgsqlDbType.Double));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCofinsAliquota ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_cofins_imposto_retido", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCofinsImpostoRetido ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_observacao_credito", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsObservacaoCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_observacao_credito", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsObservacaoCredito ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_icms_motivo_desoneracao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsMotivoDesoneracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_icms_motivo_desoneracao", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsMotivoDesoneracao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_ipi_soma_frete_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiSomaFreteBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_ipi_soma_frete_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiSomaFreteBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_valida_precos", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ValidaPrecos);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_separada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialSeparada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_devolucao_material_separada_natueza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialSeparadaNatuezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_pis_descontar_icms_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisDescontarIcmsBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("opc_cofins_descontar_icms_bc", NpgsqlDbType.Boolean));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsDescontarIcmsBc ?? DBNull.Value;

 
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
 if (CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta+"\r\n";
                foreach (Entidades.OperacaoCompletaIcmsAliquotaClass tmp in CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosClass tmp in CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassOperacaoCompleta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassOperacaoCompleta+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassOperacaoCompleta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPostoTrabalhoClassOperacaoCompleta.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPostoTrabalhoClassOperacaoCompleta+"\r\n";
                foreach (Entidades.PostoTrabalhoClass tmp in CollectionPostoTrabalhoClassOperacaoCompleta)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
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
        public static OperacaoCompletaClass CopiarEntidade(OperacaoCompletaClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OperacaoCompletaClass toRet = new OperacaoCompletaClass(usuario,conn);
 toRet.Identificacao= entidadeCopiar.Identificacao;
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Cfop= entidadeCopiar.Cfop;
 toRet.CfopForaEstado= entidadeCopiar.CfopForaEstado;
 toRet.NaturezaOperacao= entidadeCopiar.NaturezaOperacao;
 toRet.ConsumidorFinal= entidadeCopiar.ConsumidorFinal;
 toRet.PresencaConsumidor= entidadeCopiar.PresencaConsumidor;
 toRet.GerarContasReceber= entidadeCopiar.GerarContasReceber;
 toRet.IcmsIncide= entidadeCopiar.IcmsIncide;
 toRet.IcmsPartilha= entidadeCopiar.IcmsPartilha;
 toRet.IcmsSomaFreteBc= entidadeCopiar.IcmsSomaFreteBc;
 toRet.IcmsCst= entidadeCopiar.IcmsCst;
 toRet.IcmsAliquotaCredito= entidadeCopiar.IcmsAliquotaCredito;
 toRet.IcmsModDetBc= entidadeCopiar.IcmsModDetBc;
 toRet.IcmsReducaoBc= entidadeCopiar.IcmsReducaoBc;
 toRet.IcmsPercentualReducaoBc= entidadeCopiar.IcmsPercentualReducaoBc;
 toRet.IcmsPercentualBcOperacaoPropria= entidadeCopiar.IcmsPercentualBcOperacaoPropria;
 toRet.IcmsSt= entidadeCopiar.IcmsSt;
 toRet.IcmsModDetBcSt= entidadeCopiar.IcmsModDetBcSt;
 toRet.IcmsPercentualReducaoBcSt= entidadeCopiar.IcmsPercentualReducaoBcSt;
 toRet.IcmsPercentualDiferimento= entidadeCopiar.IcmsPercentualDiferimento;
 toRet.IcmsObservacaoDiferimento= entidadeCopiar.IcmsObservacaoDiferimento;
 toRet.IpiIncide= entidadeCopiar.IpiIncide;
 toRet.IpiCst= entidadeCopiar.IpiCst;
 toRet.IpiModTributacao= entidadeCopiar.IpiModTributacao;
 toRet.IpiCodEnquadramento= entidadeCopiar.IpiCodEnquadramento;
 toRet.IpiAliquota= entidadeCopiar.IpiAliquota;
 toRet.PisIncide= entidadeCopiar.PisIncide;
 toRet.PisCst= entidadeCopiar.PisCst;
 toRet.PisModTributacao= entidadeCopiar.PisModTributacao;
 toRet.PisAliquota= entidadeCopiar.PisAliquota;
 toRet.PisImpostoRetido= entidadeCopiar.PisImpostoRetido;
 toRet.CofinsIncide= entidadeCopiar.CofinsIncide;
 toRet.CofinsCst= entidadeCopiar.CofinsCst;
 toRet.CofinsModTributacao= entidadeCopiar.CofinsModTributacao;
 toRet.CofinsAliquota= entidadeCopiar.CofinsAliquota;
 toRet.CofinsImpostoRetido= entidadeCopiar.CofinsImpostoRetido;
 toRet.EntregaFutura= entidadeCopiar.EntregaFutura;
 toRet.EntregaFuturaCfopRemessa= entidadeCopiar.EntregaFuturaCfopRemessa;
 toRet.EntregaFuturaCfopRemessaForaEstado= entidadeCopiar.EntregaFuturaCfopRemessaForaEstado;
 toRet.EntregaFuturaNaturezaOperacaoRemessa= entidadeCopiar.EntregaFuturaNaturezaOperacaoRemessa;
 toRet.DevolucaoMaterial= entidadeCopiar.DevolucaoMaterial;
 toRet.DevolucaoMaterialCfop= entidadeCopiar.DevolucaoMaterialCfop;
 toRet.DevolucaoMaterialCfopForaEstado= entidadeCopiar.DevolucaoMaterialCfopForaEstado;
 toRet.DevolucaoMaterialIcmsIncide= entidadeCopiar.DevolucaoMaterialIcmsIncide;
 toRet.DevolucaoMaterialIcmsPartilha= entidadeCopiar.DevolucaoMaterialIcmsPartilha;
 toRet.DevolucaoMaterialIcmsSomaFreteBc= entidadeCopiar.DevolucaoMaterialIcmsSomaFreteBc;
 toRet.DevolucaoMaterialIcmsCst= entidadeCopiar.DevolucaoMaterialIcmsCst;
 toRet.DevolucaoMaterialIcmsAliquotaCredito= entidadeCopiar.DevolucaoMaterialIcmsAliquotaCredito;
 toRet.DevolucaoMaterialIcmsModDetBc= entidadeCopiar.DevolucaoMaterialIcmsModDetBc;
 toRet.DevolucaoMaterialIcmsReducaoBc= entidadeCopiar.DevolucaoMaterialIcmsReducaoBc;
 toRet.DevolucaoMaterialIcmsPercentualReducaoBc= entidadeCopiar.DevolucaoMaterialIcmsPercentualReducaoBc;
 toRet.DevolucaoMaterialIcmsPercentualBcOperacaoPropria= entidadeCopiar.DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
 toRet.DevolucaoMaterialIcmsSt= entidadeCopiar.DevolucaoMaterialIcmsSt;
 toRet.DevolucaoMaterialIcmsModDetBcSt= entidadeCopiar.DevolucaoMaterialIcmsModDetBcSt;
 toRet.DevolucaoMaterialIcmsPercentualReducaoBcSt= entidadeCopiar.DevolucaoMaterialIcmsPercentualReducaoBcSt;
 toRet.DevolucaoMaterialIcmsPercentualDiferimento= entidadeCopiar.DevolucaoMaterialIcmsPercentualDiferimento;
 toRet.DevolucaoMaterialIcmsObservacaoDiferimento= entidadeCopiar.DevolucaoMaterialIcmsObservacaoDiferimento;
 toRet.DevolucaoMaterialIpiIncide= entidadeCopiar.DevolucaoMaterialIpiIncide;
 toRet.DevolucaoMaterialIpiCst= entidadeCopiar.DevolucaoMaterialIpiCst;
 toRet.DevolucaoMaterialIpiModTributacao= entidadeCopiar.DevolucaoMaterialIpiModTributacao;
 toRet.DevolucaoMaterialIpiCodEnquadramento= entidadeCopiar.DevolucaoMaterialIpiCodEnquadramento;
 toRet.DevolucaoMaterialIpiAliquota= entidadeCopiar.DevolucaoMaterialIpiAliquota;
 toRet.DevolucaoMaterialPisIncide= entidadeCopiar.DevolucaoMaterialPisIncide;
 toRet.DevolucaoMaterialPisCst= entidadeCopiar.DevolucaoMaterialPisCst;
 toRet.DevolucaoMaterialPisModTributacao= entidadeCopiar.DevolucaoMaterialPisModTributacao;
 toRet.DevolucaoMaterialPisAliquota= entidadeCopiar.DevolucaoMaterialPisAliquota;
 toRet.DevolucaoMaterialPisImpostoRetido= entidadeCopiar.DevolucaoMaterialPisImpostoRetido;
 toRet.DevolucaoMaterialCofinsIncide= entidadeCopiar.DevolucaoMaterialCofinsIncide;
 toRet.DevolucaoMaterialCofinsCst= entidadeCopiar.DevolucaoMaterialCofinsCst;
 toRet.DevolucaoMaterialCofinsModTributacao= entidadeCopiar.DevolucaoMaterialCofinsModTributacao;
 toRet.DevolucaoMaterialCofinsAliquota= entidadeCopiar.DevolucaoMaterialCofinsAliquota;
 toRet.DevolucaoMaterialCofinsImpostoRetido= entidadeCopiar.DevolucaoMaterialCofinsImpostoRetido;
 toRet.IcmsObservacaoCredito= entidadeCopiar.IcmsObservacaoCredito;
 toRet.DevolucaoMaterialIcmsObservacaoCredito= entidadeCopiar.DevolucaoMaterialIcmsObservacaoCredito;
 toRet.DevolucaoMaterialIcmsMotivoDesoneracao= entidadeCopiar.DevolucaoMaterialIcmsMotivoDesoneracao;
 toRet.IcmsMotivoDesoneracao= entidadeCopiar.IcmsMotivoDesoneracao;
 toRet.IpiSomaFreteBc= entidadeCopiar.IpiSomaFreteBc;
 toRet.DevolucaoMaterialIpiSomaFreteBc= entidadeCopiar.DevolucaoMaterialIpiSomaFreteBc;
 toRet.ValidaPrecos= entidadeCopiar.ValidaPrecos;
 toRet.DevolucaoMaterialSeparada= entidadeCopiar.DevolucaoMaterialSeparada;
 toRet.DevolucaoMaterialSeparadaNatuezaOperacao= entidadeCopiar.DevolucaoMaterialSeparadaNatuezaOperacao;
 toRet.PisDescontarIcmsBc= entidadeCopiar.PisDescontarIcmsBc;
 toRet.CofinsDescontarIcmsBc= entidadeCopiar.CofinsDescontarIcmsBc;

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
       _identificacaoOriginal = Identificacao;
       _identificacaoOriginalCommited = _identificacaoOriginal;
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _cfopOriginal = Cfop;
       _cfopOriginalCommited = _cfopOriginal;
       _cfopForaEstadoOriginal = CfopForaEstado;
       _cfopForaEstadoOriginalCommited = _cfopForaEstadoOriginal;
       _naturezaOperacaoOriginal = NaturezaOperacao;
       _naturezaOperacaoOriginalCommited = _naturezaOperacaoOriginal;
       _consumidorFinalOriginal = ConsumidorFinal;
       _consumidorFinalOriginalCommited = _consumidorFinalOriginal;
       _presencaConsumidorOriginal = PresencaConsumidor;
       _presencaConsumidorOriginalCommited = _presencaConsumidorOriginal;
       _gerarContasReceberOriginal = GerarContasReceber;
       _gerarContasReceberOriginalCommited = _gerarContasReceberOriginal;
       _icmsIncideOriginal = IcmsIncide;
       _icmsIncideOriginalCommited = _icmsIncideOriginal;
       _icmsPartilhaOriginal = IcmsPartilha;
       _icmsPartilhaOriginalCommited = _icmsPartilhaOriginal;
       _icmsSomaFreteBcOriginal = IcmsSomaFreteBc;
       _icmsSomaFreteBcOriginalCommited = _icmsSomaFreteBcOriginal;
       _icmsCstOriginal = IcmsCst;
       _icmsCstOriginalCommited = _icmsCstOriginal;
       _icmsAliquotaCreditoOriginal = IcmsAliquotaCredito;
       _icmsAliquotaCreditoOriginalCommited = _icmsAliquotaCreditoOriginal;
       _icmsModDetBcOriginal = IcmsModDetBc;
       _icmsModDetBcOriginalCommited = _icmsModDetBcOriginal;
       _icmsReducaoBcOriginal = IcmsReducaoBc;
       _icmsReducaoBcOriginalCommited = _icmsReducaoBcOriginal;
       _icmsPercentualReducaoBcOriginal = IcmsPercentualReducaoBc;
       _icmsPercentualReducaoBcOriginalCommited = _icmsPercentualReducaoBcOriginal;
       _icmsPercentualBcOperacaoPropriaOriginal = IcmsPercentualBcOperacaoPropria;
       _icmsPercentualBcOperacaoPropriaOriginalCommited = _icmsPercentualBcOperacaoPropriaOriginal;
       _icmsStOriginal = IcmsSt;
       _icmsStOriginalCommited = _icmsStOriginal;
       _icmsModDetBcStOriginal = IcmsModDetBcSt;
       _icmsModDetBcStOriginalCommited = _icmsModDetBcStOriginal;
       _icmsPercentualReducaoBcStOriginal = IcmsPercentualReducaoBcSt;
       _icmsPercentualReducaoBcStOriginalCommited = _icmsPercentualReducaoBcStOriginal;
       _icmsPercentualDiferimentoOriginal = IcmsPercentualDiferimento;
       _icmsPercentualDiferimentoOriginalCommited = _icmsPercentualDiferimentoOriginal;
       _icmsObservacaoDiferimentoOriginal = IcmsObservacaoDiferimento;
       _icmsObservacaoDiferimentoOriginalCommited = _icmsObservacaoDiferimentoOriginal;
       _ipiIncideOriginal = IpiIncide;
       _ipiIncideOriginalCommited = _ipiIncideOriginal;
       _ipiCstOriginal = IpiCst;
       _ipiCstOriginalCommited = _ipiCstOriginal;
       _ipiModTributacaoOriginal = IpiModTributacao;
       _ipiModTributacaoOriginalCommited = _ipiModTributacaoOriginal;
       _ipiCodEnquadramentoOriginal = IpiCodEnquadramento;
       _ipiCodEnquadramentoOriginalCommited = _ipiCodEnquadramentoOriginal;
       _ipiAliquotaOriginal = IpiAliquota;
       _ipiAliquotaOriginalCommited = _ipiAliquotaOriginal;
       _pisIncideOriginal = PisIncide;
       _pisIncideOriginalCommited = _pisIncideOriginal;
       _pisCstOriginal = PisCst;
       _pisCstOriginalCommited = _pisCstOriginal;
       _pisModTributacaoOriginal = PisModTributacao;
       _pisModTributacaoOriginalCommited = _pisModTributacaoOriginal;
       _pisAliquotaOriginal = PisAliquota;
       _pisAliquotaOriginalCommited = _pisAliquotaOriginal;
       _pisImpostoRetidoOriginal = PisImpostoRetido;
       _pisImpostoRetidoOriginalCommited = _pisImpostoRetidoOriginal;
       _cofinsIncideOriginal = CofinsIncide;
       _cofinsIncideOriginalCommited = _cofinsIncideOriginal;
       _cofinsCstOriginal = CofinsCst;
       _cofinsCstOriginalCommited = _cofinsCstOriginal;
       _cofinsModTributacaoOriginal = CofinsModTributacao;
       _cofinsModTributacaoOriginalCommited = _cofinsModTributacaoOriginal;
       _cofinsAliquotaOriginal = CofinsAliquota;
       _cofinsAliquotaOriginalCommited = _cofinsAliquotaOriginal;
       _cofinsImpostoRetidoOriginal = CofinsImpostoRetido;
       _cofinsImpostoRetidoOriginalCommited = _cofinsImpostoRetidoOriginal;
       _entregaFuturaOriginal = EntregaFutura;
       _entregaFuturaOriginalCommited = _entregaFuturaOriginal;
       _entregaFuturaCfopRemessaOriginal = EntregaFuturaCfopRemessa;
       _entregaFuturaCfopRemessaOriginalCommited = _entregaFuturaCfopRemessaOriginal;
       _entregaFuturaCfopRemessaForaEstadoOriginal = EntregaFuturaCfopRemessaForaEstado;
       _entregaFuturaCfopRemessaForaEstadoOriginalCommited = _entregaFuturaCfopRemessaForaEstadoOriginal;
       _entregaFuturaNaturezaOperacaoRemessaOriginal = EntregaFuturaNaturezaOperacaoRemessa;
       _entregaFuturaNaturezaOperacaoRemessaOriginalCommited = _entregaFuturaNaturezaOperacaoRemessaOriginal;
       _devolucaoMaterialOriginal = DevolucaoMaterial;
       _devolucaoMaterialOriginalCommited = _devolucaoMaterialOriginal;
       _devolucaoMaterialCfopOriginal = DevolucaoMaterialCfop;
       _devolucaoMaterialCfopOriginalCommited = _devolucaoMaterialCfopOriginal;
       _devolucaoMaterialCfopForaEstadoOriginal = DevolucaoMaterialCfopForaEstado;
       _devolucaoMaterialCfopForaEstadoOriginalCommited = _devolucaoMaterialCfopForaEstadoOriginal;
       _devolucaoMaterialIcmsIncideOriginal = DevolucaoMaterialIcmsIncide;
       _devolucaoMaterialIcmsIncideOriginalCommited = _devolucaoMaterialIcmsIncideOriginal;
       _devolucaoMaterialIcmsPartilhaOriginal = DevolucaoMaterialIcmsPartilha;
       _devolucaoMaterialIcmsPartilhaOriginalCommited = _devolucaoMaterialIcmsPartilhaOriginal;
       _devolucaoMaterialIcmsSomaFreteBcOriginal = DevolucaoMaterialIcmsSomaFreteBc;
       _devolucaoMaterialIcmsSomaFreteBcOriginalCommited = _devolucaoMaterialIcmsSomaFreteBcOriginal;
       _devolucaoMaterialIcmsCstOriginal = DevolucaoMaterialIcmsCst;
       _devolucaoMaterialIcmsCstOriginalCommited = _devolucaoMaterialIcmsCstOriginal;
       _devolucaoMaterialIcmsAliquotaCreditoOriginal = DevolucaoMaterialIcmsAliquotaCredito;
       _devolucaoMaterialIcmsAliquotaCreditoOriginalCommited = _devolucaoMaterialIcmsAliquotaCreditoOriginal;
       _devolucaoMaterialIcmsModDetBcOriginal = DevolucaoMaterialIcmsModDetBc;
       _devolucaoMaterialIcmsModDetBcOriginalCommited = _devolucaoMaterialIcmsModDetBcOriginal;
       _devolucaoMaterialIcmsReducaoBcOriginal = DevolucaoMaterialIcmsReducaoBc;
       _devolucaoMaterialIcmsReducaoBcOriginalCommited = _devolucaoMaterialIcmsReducaoBcOriginal;
       _devolucaoMaterialIcmsPercentualReducaoBcOriginal = DevolucaoMaterialIcmsPercentualReducaoBc;
       _devolucaoMaterialIcmsPercentualReducaoBcOriginalCommited = _devolucaoMaterialIcmsPercentualReducaoBcOriginal;
       _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal = DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
       _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginalCommited = _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal;
       _devolucaoMaterialIcmsStOriginal = DevolucaoMaterialIcmsSt;
       _devolucaoMaterialIcmsStOriginalCommited = _devolucaoMaterialIcmsStOriginal;
       _devolucaoMaterialIcmsModDetBcStOriginal = DevolucaoMaterialIcmsModDetBcSt;
       _devolucaoMaterialIcmsModDetBcStOriginalCommited = _devolucaoMaterialIcmsModDetBcStOriginal;
       _devolucaoMaterialIcmsPercentualReducaoBcStOriginal = DevolucaoMaterialIcmsPercentualReducaoBcSt;
       _devolucaoMaterialIcmsPercentualReducaoBcStOriginalCommited = _devolucaoMaterialIcmsPercentualReducaoBcStOriginal;
       _devolucaoMaterialIcmsPercentualDiferimentoOriginal = DevolucaoMaterialIcmsPercentualDiferimento;
       _devolucaoMaterialIcmsPercentualDiferimentoOriginalCommited = _devolucaoMaterialIcmsPercentualDiferimentoOriginal;
       _devolucaoMaterialIcmsObservacaoDiferimentoOriginal = DevolucaoMaterialIcmsObservacaoDiferimento;
       _devolucaoMaterialIcmsObservacaoDiferimentoOriginalCommited = _devolucaoMaterialIcmsObservacaoDiferimentoOriginal;
       _devolucaoMaterialIpiIncideOriginal = DevolucaoMaterialIpiIncide;
       _devolucaoMaterialIpiIncideOriginalCommited = _devolucaoMaterialIpiIncideOriginal;
       _devolucaoMaterialIpiCstOriginal = DevolucaoMaterialIpiCst;
       _devolucaoMaterialIpiCstOriginalCommited = _devolucaoMaterialIpiCstOriginal;
       _devolucaoMaterialIpiModTributacaoOriginal = DevolucaoMaterialIpiModTributacao;
       _devolucaoMaterialIpiModTributacaoOriginalCommited = _devolucaoMaterialIpiModTributacaoOriginal;
       _devolucaoMaterialIpiCodEnquadramentoOriginal = DevolucaoMaterialIpiCodEnquadramento;
       _devolucaoMaterialIpiCodEnquadramentoOriginalCommited = _devolucaoMaterialIpiCodEnquadramentoOriginal;
       _devolucaoMaterialIpiAliquotaOriginal = DevolucaoMaterialIpiAliquota;
       _devolucaoMaterialIpiAliquotaOriginalCommited = _devolucaoMaterialIpiAliquotaOriginal;
       _devolucaoMaterialPisIncideOriginal = DevolucaoMaterialPisIncide;
       _devolucaoMaterialPisIncideOriginalCommited = _devolucaoMaterialPisIncideOriginal;
       _devolucaoMaterialPisCstOriginal = DevolucaoMaterialPisCst;
       _devolucaoMaterialPisCstOriginalCommited = _devolucaoMaterialPisCstOriginal;
       _devolucaoMaterialPisModTributacaoOriginal = DevolucaoMaterialPisModTributacao;
       _devolucaoMaterialPisModTributacaoOriginalCommited = _devolucaoMaterialPisModTributacaoOriginal;
       _devolucaoMaterialPisAliquotaOriginal = DevolucaoMaterialPisAliquota;
       _devolucaoMaterialPisAliquotaOriginalCommited = _devolucaoMaterialPisAliquotaOriginal;
       _devolucaoMaterialPisImpostoRetidoOriginal = DevolucaoMaterialPisImpostoRetido;
       _devolucaoMaterialPisImpostoRetidoOriginalCommited = _devolucaoMaterialPisImpostoRetidoOriginal;
       _devolucaoMaterialCofinsIncideOriginal = DevolucaoMaterialCofinsIncide;
       _devolucaoMaterialCofinsIncideOriginalCommited = _devolucaoMaterialCofinsIncideOriginal;
       _devolucaoMaterialCofinsCstOriginal = DevolucaoMaterialCofinsCst;
       _devolucaoMaterialCofinsCstOriginalCommited = _devolucaoMaterialCofinsCstOriginal;
       _devolucaoMaterialCofinsModTributacaoOriginal = DevolucaoMaterialCofinsModTributacao;
       _devolucaoMaterialCofinsModTributacaoOriginalCommited = _devolucaoMaterialCofinsModTributacaoOriginal;
       _devolucaoMaterialCofinsAliquotaOriginal = DevolucaoMaterialCofinsAliquota;
       _devolucaoMaterialCofinsAliquotaOriginalCommited = _devolucaoMaterialCofinsAliquotaOriginal;
       _devolucaoMaterialCofinsImpostoRetidoOriginal = DevolucaoMaterialCofinsImpostoRetido;
       _devolucaoMaterialCofinsImpostoRetidoOriginalCommited = _devolucaoMaterialCofinsImpostoRetidoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _icmsObservacaoCreditoOriginal = IcmsObservacaoCredito;
       _icmsObservacaoCreditoOriginalCommited = _icmsObservacaoCreditoOriginal;
       _devolucaoMaterialIcmsObservacaoCreditoOriginal = DevolucaoMaterialIcmsObservacaoCredito;
       _devolucaoMaterialIcmsObservacaoCreditoOriginalCommited = _devolucaoMaterialIcmsObservacaoCreditoOriginal;
       _devolucaoMaterialIcmsMotivoDesoneracaoOriginal = DevolucaoMaterialIcmsMotivoDesoneracao;
       _devolucaoMaterialIcmsMotivoDesoneracaoOriginalCommited = _devolucaoMaterialIcmsMotivoDesoneracaoOriginal;
       _icmsMotivoDesoneracaoOriginal = IcmsMotivoDesoneracao;
       _icmsMotivoDesoneracaoOriginalCommited = _icmsMotivoDesoneracaoOriginal;
       _ipiSomaFreteBcOriginal = IpiSomaFreteBc;
       _ipiSomaFreteBcOriginalCommited = _ipiSomaFreteBcOriginal;
       _devolucaoMaterialIpiSomaFreteBcOriginal = DevolucaoMaterialIpiSomaFreteBc;
       _devolucaoMaterialIpiSomaFreteBcOriginalCommited = _devolucaoMaterialIpiSomaFreteBcOriginal;
       _validaPrecosOriginal = ValidaPrecos;
       _validaPrecosOriginalCommited = _validaPrecosOriginal;
       _devolucaoMaterialSeparadaOriginal = DevolucaoMaterialSeparada;
       _devolucaoMaterialSeparadaOriginalCommited = _devolucaoMaterialSeparadaOriginal;
       _devolucaoMaterialSeparadaNatuezaOperacaoOriginal = DevolucaoMaterialSeparadaNatuezaOperacao;
       _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited = _devolucaoMaterialSeparadaNatuezaOperacaoOriginal;
       _pisDescontarIcmsBcOriginal = PisDescontarIcmsBc;
       _pisDescontarIcmsBcOriginalCommited = _pisDescontarIcmsBcOriginal;
       _cofinsDescontarIcmsBcOriginal = CofinsDescontarIcmsBc;
       _cofinsDescontarIcmsBcOriginalCommited = _cofinsDescontarIcmsBcOriginal;

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
       _identificacaoOriginalCommited = Identificacao;
       _descricaoOriginalCommited = Descricao;
       _cfopOriginalCommited = Cfop;
       _cfopForaEstadoOriginalCommited = CfopForaEstado;
       _naturezaOperacaoOriginalCommited = NaturezaOperacao;
       _consumidorFinalOriginalCommited = ConsumidorFinal;
       _presencaConsumidorOriginalCommited = PresencaConsumidor;
       _gerarContasReceberOriginalCommited = GerarContasReceber;
       _icmsIncideOriginalCommited = IcmsIncide;
       _icmsPartilhaOriginalCommited = IcmsPartilha;
       _icmsSomaFreteBcOriginalCommited = IcmsSomaFreteBc;
       _icmsCstOriginalCommited = IcmsCst;
       _icmsAliquotaCreditoOriginalCommited = IcmsAliquotaCredito;
       _icmsModDetBcOriginalCommited = IcmsModDetBc;
       _icmsReducaoBcOriginalCommited = IcmsReducaoBc;
       _icmsPercentualReducaoBcOriginalCommited = IcmsPercentualReducaoBc;
       _icmsPercentualBcOperacaoPropriaOriginalCommited = IcmsPercentualBcOperacaoPropria;
       _icmsStOriginalCommited = IcmsSt;
       _icmsModDetBcStOriginalCommited = IcmsModDetBcSt;
       _icmsPercentualReducaoBcStOriginalCommited = IcmsPercentualReducaoBcSt;
       _icmsPercentualDiferimentoOriginalCommited = IcmsPercentualDiferimento;
       _icmsObservacaoDiferimentoOriginalCommited = IcmsObservacaoDiferimento;
       _ipiIncideOriginalCommited = IpiIncide;
       _ipiCstOriginalCommited = IpiCst;
       _ipiModTributacaoOriginalCommited = IpiModTributacao;
       _ipiCodEnquadramentoOriginalCommited = IpiCodEnquadramento;
       _ipiAliquotaOriginalCommited = IpiAliquota;
       _pisIncideOriginalCommited = PisIncide;
       _pisCstOriginalCommited = PisCst;
       _pisModTributacaoOriginalCommited = PisModTributacao;
       _pisAliquotaOriginalCommited = PisAliquota;
       _pisImpostoRetidoOriginalCommited = PisImpostoRetido;
       _cofinsIncideOriginalCommited = CofinsIncide;
       _cofinsCstOriginalCommited = CofinsCst;
       _cofinsModTributacaoOriginalCommited = CofinsModTributacao;
       _cofinsAliquotaOriginalCommited = CofinsAliquota;
       _cofinsImpostoRetidoOriginalCommited = CofinsImpostoRetido;
       _entregaFuturaOriginalCommited = EntregaFutura;
       _entregaFuturaCfopRemessaOriginalCommited = EntregaFuturaCfopRemessa;
       _entregaFuturaCfopRemessaForaEstadoOriginalCommited = EntregaFuturaCfopRemessaForaEstado;
       _entregaFuturaNaturezaOperacaoRemessaOriginalCommited = EntregaFuturaNaturezaOperacaoRemessa;
       _devolucaoMaterialOriginalCommited = DevolucaoMaterial;
       _devolucaoMaterialCfopOriginalCommited = DevolucaoMaterialCfop;
       _devolucaoMaterialCfopForaEstadoOriginalCommited = DevolucaoMaterialCfopForaEstado;
       _devolucaoMaterialIcmsIncideOriginalCommited = DevolucaoMaterialIcmsIncide;
       _devolucaoMaterialIcmsPartilhaOriginalCommited = DevolucaoMaterialIcmsPartilha;
       _devolucaoMaterialIcmsSomaFreteBcOriginalCommited = DevolucaoMaterialIcmsSomaFreteBc;
       _devolucaoMaterialIcmsCstOriginalCommited = DevolucaoMaterialIcmsCst;
       _devolucaoMaterialIcmsAliquotaCreditoOriginalCommited = DevolucaoMaterialIcmsAliquotaCredito;
       _devolucaoMaterialIcmsModDetBcOriginalCommited = DevolucaoMaterialIcmsModDetBc;
       _devolucaoMaterialIcmsReducaoBcOriginalCommited = DevolucaoMaterialIcmsReducaoBc;
       _devolucaoMaterialIcmsPercentualReducaoBcOriginalCommited = DevolucaoMaterialIcmsPercentualReducaoBc;
       _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginalCommited = DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
       _devolucaoMaterialIcmsStOriginalCommited = DevolucaoMaterialIcmsSt;
       _devolucaoMaterialIcmsModDetBcStOriginalCommited = DevolucaoMaterialIcmsModDetBcSt;
       _devolucaoMaterialIcmsPercentualReducaoBcStOriginalCommited = DevolucaoMaterialIcmsPercentualReducaoBcSt;
       _devolucaoMaterialIcmsPercentualDiferimentoOriginalCommited = DevolucaoMaterialIcmsPercentualDiferimento;
       _devolucaoMaterialIcmsObservacaoDiferimentoOriginalCommited = DevolucaoMaterialIcmsObservacaoDiferimento;
       _devolucaoMaterialIpiIncideOriginalCommited = DevolucaoMaterialIpiIncide;
       _devolucaoMaterialIpiCstOriginalCommited = DevolucaoMaterialIpiCst;
       _devolucaoMaterialIpiModTributacaoOriginalCommited = DevolucaoMaterialIpiModTributacao;
       _devolucaoMaterialIpiCodEnquadramentoOriginalCommited = DevolucaoMaterialIpiCodEnquadramento;
       _devolucaoMaterialIpiAliquotaOriginalCommited = DevolucaoMaterialIpiAliquota;
       _devolucaoMaterialPisIncideOriginalCommited = DevolucaoMaterialPisIncide;
       _devolucaoMaterialPisCstOriginalCommited = DevolucaoMaterialPisCst;
       _devolucaoMaterialPisModTributacaoOriginalCommited = DevolucaoMaterialPisModTributacao;
       _devolucaoMaterialPisAliquotaOriginalCommited = DevolucaoMaterialPisAliquota;
       _devolucaoMaterialPisImpostoRetidoOriginalCommited = DevolucaoMaterialPisImpostoRetido;
       _devolucaoMaterialCofinsIncideOriginalCommited = DevolucaoMaterialCofinsIncide;
       _devolucaoMaterialCofinsCstOriginalCommited = DevolucaoMaterialCofinsCst;
       _devolucaoMaterialCofinsModTributacaoOriginalCommited = DevolucaoMaterialCofinsModTributacao;
       _devolucaoMaterialCofinsAliquotaOriginalCommited = DevolucaoMaterialCofinsAliquota;
       _devolucaoMaterialCofinsImpostoRetidoOriginalCommited = DevolucaoMaterialCofinsImpostoRetido;
       _versionOriginalCommited = Version;
       _icmsObservacaoCreditoOriginalCommited = IcmsObservacaoCredito;
       _devolucaoMaterialIcmsObservacaoCreditoOriginalCommited = DevolucaoMaterialIcmsObservacaoCredito;
       _devolucaoMaterialIcmsMotivoDesoneracaoOriginalCommited = DevolucaoMaterialIcmsMotivoDesoneracao;
       _icmsMotivoDesoneracaoOriginalCommited = IcmsMotivoDesoneracao;
       _ipiSomaFreteBcOriginalCommited = IpiSomaFreteBc;
       _devolucaoMaterialIpiSomaFreteBcOriginalCommited = DevolucaoMaterialIpiSomaFreteBc;
       _validaPrecosOriginalCommited = ValidaPrecos;
       _devolucaoMaterialSeparadaOriginalCommited = DevolucaoMaterialSeparada;
       _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited = DevolucaoMaterialSeparadaNatuezaOperacao;
       _pisDescontarIcmsBcOriginalCommited = PisDescontarIcmsBc;
       _cofinsDescontarIcmsBcOriginalCommited = CofinsDescontarIcmsBc;

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
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  if (_collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos != null) 
                  {
                     _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos = new List<Entidades.OperacaoCompletaIcmsAliquotaClass>();
                  }
                  _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaOriginal= (from a in _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta select a.ID).ToList();
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged = false;
                  _valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  if (_collectionPedidoItemClassOperacaoCompletaRemovidos != null) 
                  {
                     _collectionPedidoItemClassOperacaoCompletaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassOperacaoCompletaRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassOperacaoCompletaOriginal= (from a in _valueCollectionPedidoItemClassOperacaoCompleta select a.ID).ToList();
                  _valueCollectionPedidoItemClassOperacaoCompletaChanged = false;
                  _valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  if (_collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos != null) 
                  {
                     _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceiros select a.ID).ToList();
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged = false;
                  _valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged = false;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  if (_collectionPostoTrabalhoClassOperacaoCompletaRemovidos != null) 
                  {
                     _collectionPostoTrabalhoClassOperacaoCompletaRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPostoTrabalhoClassOperacaoCompletaRemovidos = new List<Entidades.PostoTrabalhoClass>();
                  }
                  _collectionPostoTrabalhoClassOperacaoCompletaOriginal= (from a in _valueCollectionPostoTrabalhoClassOperacaoCompleta select a.ID).ToList();
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaChanged = false;
                  _valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged = false;
               }

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
               Identificacao=_identificacaoOriginal;
               _identificacaoOriginalCommited=_identificacaoOriginal;
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Cfop=_cfopOriginal;
               _cfopOriginalCommited=_cfopOriginal;
               CfopForaEstado=_cfopForaEstadoOriginal;
               _cfopForaEstadoOriginalCommited=_cfopForaEstadoOriginal;
               NaturezaOperacao=_naturezaOperacaoOriginal;
               _naturezaOperacaoOriginalCommited=_naturezaOperacaoOriginal;
               ConsumidorFinal=_consumidorFinalOriginal;
               _consumidorFinalOriginalCommited=_consumidorFinalOriginal;
               PresencaConsumidor=_presencaConsumidorOriginal;
               _presencaConsumidorOriginalCommited=_presencaConsumidorOriginal;
               GerarContasReceber=_gerarContasReceberOriginal;
               _gerarContasReceberOriginalCommited=_gerarContasReceberOriginal;
               IcmsIncide=_icmsIncideOriginal;
               _icmsIncideOriginalCommited=_icmsIncideOriginal;
               IcmsPartilha=_icmsPartilhaOriginal;
               _icmsPartilhaOriginalCommited=_icmsPartilhaOriginal;
               IcmsSomaFreteBc=_icmsSomaFreteBcOriginal;
               _icmsSomaFreteBcOriginalCommited=_icmsSomaFreteBcOriginal;
               IcmsCst=_icmsCstOriginal;
               _icmsCstOriginalCommited=_icmsCstOriginal;
               IcmsAliquotaCredito=_icmsAliquotaCreditoOriginal;
               _icmsAliquotaCreditoOriginalCommited=_icmsAliquotaCreditoOriginal;
               IcmsModDetBc=_icmsModDetBcOriginal;
               _icmsModDetBcOriginalCommited=_icmsModDetBcOriginal;
               IcmsReducaoBc=_icmsReducaoBcOriginal;
               _icmsReducaoBcOriginalCommited=_icmsReducaoBcOriginal;
               IcmsPercentualReducaoBc=_icmsPercentualReducaoBcOriginal;
               _icmsPercentualReducaoBcOriginalCommited=_icmsPercentualReducaoBcOriginal;
               IcmsPercentualBcOperacaoPropria=_icmsPercentualBcOperacaoPropriaOriginal;
               _icmsPercentualBcOperacaoPropriaOriginalCommited=_icmsPercentualBcOperacaoPropriaOriginal;
               IcmsSt=_icmsStOriginal;
               _icmsStOriginalCommited=_icmsStOriginal;
               IcmsModDetBcSt=_icmsModDetBcStOriginal;
               _icmsModDetBcStOriginalCommited=_icmsModDetBcStOriginal;
               IcmsPercentualReducaoBcSt=_icmsPercentualReducaoBcStOriginal;
               _icmsPercentualReducaoBcStOriginalCommited=_icmsPercentualReducaoBcStOriginal;
               IcmsPercentualDiferimento=_icmsPercentualDiferimentoOriginal;
               _icmsPercentualDiferimentoOriginalCommited=_icmsPercentualDiferimentoOriginal;
               IcmsObservacaoDiferimento=_icmsObservacaoDiferimentoOriginal;
               _icmsObservacaoDiferimentoOriginalCommited=_icmsObservacaoDiferimentoOriginal;
               IpiIncide=_ipiIncideOriginal;
               _ipiIncideOriginalCommited=_ipiIncideOriginal;
               IpiCst=_ipiCstOriginal;
               _ipiCstOriginalCommited=_ipiCstOriginal;
               IpiModTributacao=_ipiModTributacaoOriginal;
               _ipiModTributacaoOriginalCommited=_ipiModTributacaoOriginal;
               IpiCodEnquadramento=_ipiCodEnquadramentoOriginal;
               _ipiCodEnquadramentoOriginalCommited=_ipiCodEnquadramentoOriginal;
               IpiAliquota=_ipiAliquotaOriginal;
               _ipiAliquotaOriginalCommited=_ipiAliquotaOriginal;
               PisIncide=_pisIncideOriginal;
               _pisIncideOriginalCommited=_pisIncideOriginal;
               PisCst=_pisCstOriginal;
               _pisCstOriginalCommited=_pisCstOriginal;
               PisModTributacao=_pisModTributacaoOriginal;
               _pisModTributacaoOriginalCommited=_pisModTributacaoOriginal;
               PisAliquota=_pisAliquotaOriginal;
               _pisAliquotaOriginalCommited=_pisAliquotaOriginal;
               PisImpostoRetido=_pisImpostoRetidoOriginal;
               _pisImpostoRetidoOriginalCommited=_pisImpostoRetidoOriginal;
               CofinsIncide=_cofinsIncideOriginal;
               _cofinsIncideOriginalCommited=_cofinsIncideOriginal;
               CofinsCst=_cofinsCstOriginal;
               _cofinsCstOriginalCommited=_cofinsCstOriginal;
               CofinsModTributacao=_cofinsModTributacaoOriginal;
               _cofinsModTributacaoOriginalCommited=_cofinsModTributacaoOriginal;
               CofinsAliquota=_cofinsAliquotaOriginal;
               _cofinsAliquotaOriginalCommited=_cofinsAliquotaOriginal;
               CofinsImpostoRetido=_cofinsImpostoRetidoOriginal;
               _cofinsImpostoRetidoOriginalCommited=_cofinsImpostoRetidoOriginal;
               EntregaFutura=_entregaFuturaOriginal;
               _entregaFuturaOriginalCommited=_entregaFuturaOriginal;
               EntregaFuturaCfopRemessa=_entregaFuturaCfopRemessaOriginal;
               _entregaFuturaCfopRemessaOriginalCommited=_entregaFuturaCfopRemessaOriginal;
               EntregaFuturaCfopRemessaForaEstado=_entregaFuturaCfopRemessaForaEstadoOriginal;
               _entregaFuturaCfopRemessaForaEstadoOriginalCommited=_entregaFuturaCfopRemessaForaEstadoOriginal;
               EntregaFuturaNaturezaOperacaoRemessa=_entregaFuturaNaturezaOperacaoRemessaOriginal;
               _entregaFuturaNaturezaOperacaoRemessaOriginalCommited=_entregaFuturaNaturezaOperacaoRemessaOriginal;
               DevolucaoMaterial=_devolucaoMaterialOriginal;
               _devolucaoMaterialOriginalCommited=_devolucaoMaterialOriginal;
               DevolucaoMaterialCfop=_devolucaoMaterialCfopOriginal;
               _devolucaoMaterialCfopOriginalCommited=_devolucaoMaterialCfopOriginal;
               DevolucaoMaterialCfopForaEstado=_devolucaoMaterialCfopForaEstadoOriginal;
               _devolucaoMaterialCfopForaEstadoOriginalCommited=_devolucaoMaterialCfopForaEstadoOriginal;
               DevolucaoMaterialIcmsIncide=_devolucaoMaterialIcmsIncideOriginal;
               _devolucaoMaterialIcmsIncideOriginalCommited=_devolucaoMaterialIcmsIncideOriginal;
               DevolucaoMaterialIcmsPartilha=_devolucaoMaterialIcmsPartilhaOriginal;
               _devolucaoMaterialIcmsPartilhaOriginalCommited=_devolucaoMaterialIcmsPartilhaOriginal;
               DevolucaoMaterialIcmsSomaFreteBc=_devolucaoMaterialIcmsSomaFreteBcOriginal;
               _devolucaoMaterialIcmsSomaFreteBcOriginalCommited=_devolucaoMaterialIcmsSomaFreteBcOriginal;
               DevolucaoMaterialIcmsCst=_devolucaoMaterialIcmsCstOriginal;
               _devolucaoMaterialIcmsCstOriginalCommited=_devolucaoMaterialIcmsCstOriginal;
               DevolucaoMaterialIcmsAliquotaCredito=_devolucaoMaterialIcmsAliquotaCreditoOriginal;
               _devolucaoMaterialIcmsAliquotaCreditoOriginalCommited=_devolucaoMaterialIcmsAliquotaCreditoOriginal;
               DevolucaoMaterialIcmsModDetBc=_devolucaoMaterialIcmsModDetBcOriginal;
               _devolucaoMaterialIcmsModDetBcOriginalCommited=_devolucaoMaterialIcmsModDetBcOriginal;
               DevolucaoMaterialIcmsReducaoBc=_devolucaoMaterialIcmsReducaoBcOriginal;
               _devolucaoMaterialIcmsReducaoBcOriginalCommited=_devolucaoMaterialIcmsReducaoBcOriginal;
               DevolucaoMaterialIcmsPercentualReducaoBc=_devolucaoMaterialIcmsPercentualReducaoBcOriginal;
               _devolucaoMaterialIcmsPercentualReducaoBcOriginalCommited=_devolucaoMaterialIcmsPercentualReducaoBcOriginal;
               DevolucaoMaterialIcmsPercentualBcOperacaoPropria=_devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal;
               _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginalCommited=_devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal;
               DevolucaoMaterialIcmsSt=_devolucaoMaterialIcmsStOriginal;
               _devolucaoMaterialIcmsStOriginalCommited=_devolucaoMaterialIcmsStOriginal;
               DevolucaoMaterialIcmsModDetBcSt=_devolucaoMaterialIcmsModDetBcStOriginal;
               _devolucaoMaterialIcmsModDetBcStOriginalCommited=_devolucaoMaterialIcmsModDetBcStOriginal;
               DevolucaoMaterialIcmsPercentualReducaoBcSt=_devolucaoMaterialIcmsPercentualReducaoBcStOriginal;
               _devolucaoMaterialIcmsPercentualReducaoBcStOriginalCommited=_devolucaoMaterialIcmsPercentualReducaoBcStOriginal;
               DevolucaoMaterialIcmsPercentualDiferimento=_devolucaoMaterialIcmsPercentualDiferimentoOriginal;
               _devolucaoMaterialIcmsPercentualDiferimentoOriginalCommited=_devolucaoMaterialIcmsPercentualDiferimentoOriginal;
               DevolucaoMaterialIcmsObservacaoDiferimento=_devolucaoMaterialIcmsObservacaoDiferimentoOriginal;
               _devolucaoMaterialIcmsObservacaoDiferimentoOriginalCommited=_devolucaoMaterialIcmsObservacaoDiferimentoOriginal;
               DevolucaoMaterialIpiIncide=_devolucaoMaterialIpiIncideOriginal;
               _devolucaoMaterialIpiIncideOriginalCommited=_devolucaoMaterialIpiIncideOriginal;
               DevolucaoMaterialIpiCst=_devolucaoMaterialIpiCstOriginal;
               _devolucaoMaterialIpiCstOriginalCommited=_devolucaoMaterialIpiCstOriginal;
               DevolucaoMaterialIpiModTributacao=_devolucaoMaterialIpiModTributacaoOriginal;
               _devolucaoMaterialIpiModTributacaoOriginalCommited=_devolucaoMaterialIpiModTributacaoOriginal;
               DevolucaoMaterialIpiCodEnquadramento=_devolucaoMaterialIpiCodEnquadramentoOriginal;
               _devolucaoMaterialIpiCodEnquadramentoOriginalCommited=_devolucaoMaterialIpiCodEnquadramentoOriginal;
               DevolucaoMaterialIpiAliquota=_devolucaoMaterialIpiAliquotaOriginal;
               _devolucaoMaterialIpiAliquotaOriginalCommited=_devolucaoMaterialIpiAliquotaOriginal;
               DevolucaoMaterialPisIncide=_devolucaoMaterialPisIncideOriginal;
               _devolucaoMaterialPisIncideOriginalCommited=_devolucaoMaterialPisIncideOriginal;
               DevolucaoMaterialPisCst=_devolucaoMaterialPisCstOriginal;
               _devolucaoMaterialPisCstOriginalCommited=_devolucaoMaterialPisCstOriginal;
               DevolucaoMaterialPisModTributacao=_devolucaoMaterialPisModTributacaoOriginal;
               _devolucaoMaterialPisModTributacaoOriginalCommited=_devolucaoMaterialPisModTributacaoOriginal;
               DevolucaoMaterialPisAliquota=_devolucaoMaterialPisAliquotaOriginal;
               _devolucaoMaterialPisAliquotaOriginalCommited=_devolucaoMaterialPisAliquotaOriginal;
               DevolucaoMaterialPisImpostoRetido=_devolucaoMaterialPisImpostoRetidoOriginal;
               _devolucaoMaterialPisImpostoRetidoOriginalCommited=_devolucaoMaterialPisImpostoRetidoOriginal;
               DevolucaoMaterialCofinsIncide=_devolucaoMaterialCofinsIncideOriginal;
               _devolucaoMaterialCofinsIncideOriginalCommited=_devolucaoMaterialCofinsIncideOriginal;
               DevolucaoMaterialCofinsCst=_devolucaoMaterialCofinsCstOriginal;
               _devolucaoMaterialCofinsCstOriginalCommited=_devolucaoMaterialCofinsCstOriginal;
               DevolucaoMaterialCofinsModTributacao=_devolucaoMaterialCofinsModTributacaoOriginal;
               _devolucaoMaterialCofinsModTributacaoOriginalCommited=_devolucaoMaterialCofinsModTributacaoOriginal;
               DevolucaoMaterialCofinsAliquota=_devolucaoMaterialCofinsAliquotaOriginal;
               _devolucaoMaterialCofinsAliquotaOriginalCommited=_devolucaoMaterialCofinsAliquotaOriginal;
               DevolucaoMaterialCofinsImpostoRetido=_devolucaoMaterialCofinsImpostoRetidoOriginal;
               _devolucaoMaterialCofinsImpostoRetidoOriginalCommited=_devolucaoMaterialCofinsImpostoRetidoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               IcmsObservacaoCredito=_icmsObservacaoCreditoOriginal;
               _icmsObservacaoCreditoOriginalCommited=_icmsObservacaoCreditoOriginal;
               DevolucaoMaterialIcmsObservacaoCredito=_devolucaoMaterialIcmsObservacaoCreditoOriginal;
               _devolucaoMaterialIcmsObservacaoCreditoOriginalCommited=_devolucaoMaterialIcmsObservacaoCreditoOriginal;
               DevolucaoMaterialIcmsMotivoDesoneracao=_devolucaoMaterialIcmsMotivoDesoneracaoOriginal;
               _devolucaoMaterialIcmsMotivoDesoneracaoOriginalCommited=_devolucaoMaterialIcmsMotivoDesoneracaoOriginal;
               IcmsMotivoDesoneracao=_icmsMotivoDesoneracaoOriginal;
               _icmsMotivoDesoneracaoOriginalCommited=_icmsMotivoDesoneracaoOriginal;
               IpiSomaFreteBc=_ipiSomaFreteBcOriginal;
               _ipiSomaFreteBcOriginalCommited=_ipiSomaFreteBcOriginal;
               DevolucaoMaterialIpiSomaFreteBc=_devolucaoMaterialIpiSomaFreteBcOriginal;
               _devolucaoMaterialIpiSomaFreteBcOriginalCommited=_devolucaoMaterialIpiSomaFreteBcOriginal;
               ValidaPrecos=_validaPrecosOriginal;
               _validaPrecosOriginalCommited=_validaPrecosOriginal;
               DevolucaoMaterialSeparada=_devolucaoMaterialSeparadaOriginal;
               _devolucaoMaterialSeparadaOriginalCommited=_devolucaoMaterialSeparadaOriginal;
               DevolucaoMaterialSeparadaNatuezaOperacao=_devolucaoMaterialSeparadaNatuezaOperacaoOriginal;
               _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited=_devolucaoMaterialSeparadaNatuezaOperacaoOriginal;
               PisDescontarIcmsBc=_pisDescontarIcmsBcOriginal;
               _pisDescontarIcmsBcOriginalCommited=_pisDescontarIcmsBcOriginal;
               CofinsDescontarIcmsBc=_cofinsDescontarIcmsBcOriginal;
               _cofinsDescontarIcmsBcOriginalCommited=_cofinsDescontarIcmsBcOriginal;
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.Clear();
                  foreach(int item in _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaOriginal)
                  {
                    CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.Add(Entidades.OperacaoCompletaIcmsAliquotaClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta.Add(Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  CollectionPedidoItemClassOperacaoCompleta.Clear();
                  foreach(int item in _collectionPedidoItemClassOperacaoCompletaOriginal)
                  {
                    CollectionPedidoItemClassOperacaoCompleta.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassOperacaoCompletaRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros.Clear();
                  foreach(int item in _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosOriginal)
                  {
                    CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassOperacaoCompletaEnvioTerceirosRemovidos.Clear();
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  CollectionPostoTrabalhoClassOperacaoCompleta.Clear();
                  foreach(int item in _collectionPostoTrabalhoClassOperacaoCompletaOriginal)
                  {
                    CollectionPostoTrabalhoClassOperacaoCompleta.Add(Entidades.PostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPostoTrabalhoClassOperacaoCompletaRemovidos.Clear();
               }

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
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoCompletaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassOperacaoCompletaChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoCompleta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassOperacaoCompleta.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
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
       dirty = _identificacaoOriginal != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _cfopOriginal != Cfop;
      if (dirty) return true;
       dirty = _cfopForaEstadoOriginal != CfopForaEstado;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginal != NaturezaOperacao;
      if (dirty) return true;
       dirty = _consumidorFinalOriginal != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaConsumidorOriginal != PresencaConsumidor;
      if (dirty) return true;
       dirty = _gerarContasReceberOriginal != GerarContasReceber;
      if (dirty) return true;
       dirty = _icmsIncideOriginal != IcmsIncide;
      if (dirty) return true;
       dirty = _icmsPartilhaOriginal != IcmsPartilha;
      if (dirty) return true;
       dirty = _icmsSomaFreteBcOriginal != IcmsSomaFreteBc;
      if (dirty) return true;
       dirty = _icmsCstOriginal != IcmsCst;
      if (dirty) return true;
       dirty = _icmsAliquotaCreditoOriginal != IcmsAliquotaCredito;
      if (dirty) return true;
       dirty = _icmsModDetBcOriginal != IcmsModDetBc;
      if (dirty) return true;
       dirty = _icmsReducaoBcOriginal != IcmsReducaoBc;
      if (dirty) return true;
       dirty = _icmsPercentualReducaoBcOriginal != IcmsPercentualReducaoBc;
      if (dirty) return true;
       dirty = _icmsPercentualBcOperacaoPropriaOriginal != IcmsPercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _icmsStOriginal != IcmsSt;
      if (dirty) return true;
       dirty = _icmsModDetBcStOriginal != IcmsModDetBcSt;
      if (dirty) return true;
       dirty = _icmsPercentualReducaoBcStOriginal != IcmsPercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _icmsPercentualDiferimentoOriginal != IcmsPercentualDiferimento;
      if (dirty) return true;
       dirty = _icmsObservacaoDiferimentoOriginal != IcmsObservacaoDiferimento;
      if (dirty) return true;
       dirty = _ipiIncideOriginal != IpiIncide;
      if (dirty) return true;
       dirty = _ipiCstOriginal != IpiCst;
      if (dirty) return true;
       dirty = _ipiModTributacaoOriginal != IpiModTributacao;
      if (dirty) return true;
       dirty = _ipiCodEnquadramentoOriginal != IpiCodEnquadramento;
      if (dirty) return true;
       dirty = _ipiAliquotaOriginal != IpiAliquota;
      if (dirty) return true;
       dirty = _pisIncideOriginal != PisIncide;
      if (dirty) return true;
       dirty = _pisCstOriginal != PisCst;
      if (dirty) return true;
       dirty = _pisModTributacaoOriginal != PisModTributacao;
      if (dirty) return true;
       dirty = _pisAliquotaOriginal != PisAliquota;
      if (dirty) return true;
       dirty = _pisImpostoRetidoOriginal != PisImpostoRetido;
      if (dirty) return true;
       dirty = _cofinsIncideOriginal != CofinsIncide;
      if (dirty) return true;
       dirty = _cofinsCstOriginal != CofinsCst;
      if (dirty) return true;
       dirty = _cofinsModTributacaoOriginal != CofinsModTributacao;
      if (dirty) return true;
       dirty = _cofinsAliquotaOriginal != CofinsAliquota;
      if (dirty) return true;
       dirty = _cofinsImpostoRetidoOriginal != CofinsImpostoRetido;
      if (dirty) return true;
       dirty = _entregaFuturaOriginal != EntregaFutura;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaOriginal != EntregaFuturaCfopRemessa;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaForaEstadoOriginal != EntregaFuturaCfopRemessaForaEstado;
      if (dirty) return true;
       dirty = _entregaFuturaNaturezaOperacaoRemessaOriginal != EntregaFuturaNaturezaOperacaoRemessa;
      if (dirty) return true;
       dirty = _devolucaoMaterialOriginal != DevolucaoMaterial;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopOriginal != DevolucaoMaterialCfop;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopForaEstadoOriginal != DevolucaoMaterialCfopForaEstado;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsIncideOriginal != DevolucaoMaterialIcmsIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPartilhaOriginal != DevolucaoMaterialIcmsPartilha;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsSomaFreteBcOriginal != DevolucaoMaterialIcmsSomaFreteBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsCstOriginal != DevolucaoMaterialIcmsCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsAliquotaCreditoOriginal != DevolucaoMaterialIcmsAliquotaCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsModDetBcOriginal != DevolucaoMaterialIcmsModDetBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsReducaoBcOriginal != DevolucaoMaterialIcmsReducaoBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualReducaoBcOriginal != DevolucaoMaterialIcmsPercentualReducaoBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginal != DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsStOriginal != DevolucaoMaterialIcmsSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsModDetBcStOriginal != DevolucaoMaterialIcmsModDetBcSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualReducaoBcStOriginal != DevolucaoMaterialIcmsPercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualDiferimentoOriginal != DevolucaoMaterialIcmsPercentualDiferimento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsObservacaoDiferimentoOriginal != DevolucaoMaterialIcmsObservacaoDiferimento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiIncideOriginal != DevolucaoMaterialIpiIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCstOriginal != DevolucaoMaterialIpiCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiModTributacaoOriginal != DevolucaoMaterialIpiModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCodEnquadramentoOriginal != DevolucaoMaterialIpiCodEnquadramento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiAliquotaOriginal != DevolucaoMaterialIpiAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisIncideOriginal != DevolucaoMaterialPisIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisCstOriginal != DevolucaoMaterialPisCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisModTributacaoOriginal != DevolucaoMaterialPisModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisAliquotaOriginal != DevolucaoMaterialPisAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisImpostoRetidoOriginal != DevolucaoMaterialPisImpostoRetido;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsIncideOriginal != DevolucaoMaterialCofinsIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsCstOriginal != DevolucaoMaterialCofinsCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsModTributacaoOriginal != DevolucaoMaterialCofinsModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsAliquotaOriginal != DevolucaoMaterialCofinsAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsImpostoRetidoOriginal != DevolucaoMaterialCofinsImpostoRetido;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _icmsObservacaoCreditoOriginal != IcmsObservacaoCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsObservacaoCreditoOriginal != DevolucaoMaterialIcmsObservacaoCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsMotivoDesoneracaoOriginal != DevolucaoMaterialIcmsMotivoDesoneracao;
      if (dirty) return true;
       dirty = _icmsMotivoDesoneracaoOriginal != IcmsMotivoDesoneracao;
      if (dirty) return true;
       dirty = _ipiSomaFreteBcOriginal != IpiSomaFreteBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiSomaFreteBcOriginal != DevolucaoMaterialIpiSomaFreteBc;
      if (dirty) return true;
       dirty = _validaPrecosOriginal != ValidaPrecos;
      if (dirty) return true;
       dirty = _devolucaoMaterialSeparadaOriginal != DevolucaoMaterialSeparada;
      if (dirty) return true;
       dirty = _devolucaoMaterialSeparadaNatuezaOperacaoOriginal != DevolucaoMaterialSeparadaNatuezaOperacao;
      if (dirty) return true;
       dirty = _pisDescontarIcmsBcOriginal != PisDescontarIcmsBc;
      if (dirty) return true;
       dirty = _cofinsDescontarIcmsBcOriginal != CofinsDescontarIcmsBc;

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
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoCompletaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassOperacaoCompletaCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoCompleta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassOperacaoCompleta.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
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
       dirty = _identificacaoOriginalCommited != Identificacao;
      if (dirty) return true;
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _cfopOriginalCommited != Cfop;
      if (dirty) return true;
       dirty = _cfopForaEstadoOriginalCommited != CfopForaEstado;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginalCommited != NaturezaOperacao;
      if (dirty) return true;
       dirty = _consumidorFinalOriginalCommited != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaConsumidorOriginalCommited != PresencaConsumidor;
      if (dirty) return true;
       dirty = _gerarContasReceberOriginalCommited != GerarContasReceber;
      if (dirty) return true;
       dirty = _icmsIncideOriginalCommited != IcmsIncide;
      if (dirty) return true;
       dirty = _icmsPartilhaOriginalCommited != IcmsPartilha;
      if (dirty) return true;
       dirty = _icmsSomaFreteBcOriginalCommited != IcmsSomaFreteBc;
      if (dirty) return true;
       dirty = _icmsCstOriginalCommited != IcmsCst;
      if (dirty) return true;
       dirty = _icmsAliquotaCreditoOriginalCommited != IcmsAliquotaCredito;
      if (dirty) return true;
       dirty = _icmsModDetBcOriginalCommited != IcmsModDetBc;
      if (dirty) return true;
       dirty = _icmsReducaoBcOriginalCommited != IcmsReducaoBc;
      if (dirty) return true;
       dirty = _icmsPercentualReducaoBcOriginalCommited != IcmsPercentualReducaoBc;
      if (dirty) return true;
       dirty = _icmsPercentualBcOperacaoPropriaOriginalCommited != IcmsPercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _icmsStOriginalCommited != IcmsSt;
      if (dirty) return true;
       dirty = _icmsModDetBcStOriginalCommited != IcmsModDetBcSt;
      if (dirty) return true;
       dirty = _icmsPercentualReducaoBcStOriginalCommited != IcmsPercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _icmsPercentualDiferimentoOriginalCommited != IcmsPercentualDiferimento;
      if (dirty) return true;
       dirty = _icmsObservacaoDiferimentoOriginalCommited != IcmsObservacaoDiferimento;
      if (dirty) return true;
       dirty = _ipiIncideOriginalCommited != IpiIncide;
      if (dirty) return true;
       dirty = _ipiCstOriginalCommited != IpiCst;
      if (dirty) return true;
       dirty = _ipiModTributacaoOriginalCommited != IpiModTributacao;
      if (dirty) return true;
       dirty = _ipiCodEnquadramentoOriginalCommited != IpiCodEnquadramento;
      if (dirty) return true;
       dirty = _ipiAliquotaOriginalCommited != IpiAliquota;
      if (dirty) return true;
       dirty = _pisIncideOriginalCommited != PisIncide;
      if (dirty) return true;
       dirty = _pisCstOriginalCommited != PisCst;
      if (dirty) return true;
       dirty = _pisModTributacaoOriginalCommited != PisModTributacao;
      if (dirty) return true;
       dirty = _pisAliquotaOriginalCommited != PisAliquota;
      if (dirty) return true;
       dirty = _pisImpostoRetidoOriginalCommited != PisImpostoRetido;
      if (dirty) return true;
       dirty = _cofinsIncideOriginalCommited != CofinsIncide;
      if (dirty) return true;
       dirty = _cofinsCstOriginalCommited != CofinsCst;
      if (dirty) return true;
       dirty = _cofinsModTributacaoOriginalCommited != CofinsModTributacao;
      if (dirty) return true;
       dirty = _cofinsAliquotaOriginalCommited != CofinsAliquota;
      if (dirty) return true;
       dirty = _cofinsImpostoRetidoOriginalCommited != CofinsImpostoRetido;
      if (dirty) return true;
       dirty = _entregaFuturaOriginalCommited != EntregaFutura;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaOriginalCommited != EntregaFuturaCfopRemessa;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaForaEstadoOriginalCommited != EntregaFuturaCfopRemessaForaEstado;
      if (dirty) return true;
       dirty = _entregaFuturaNaturezaOperacaoRemessaOriginalCommited != EntregaFuturaNaturezaOperacaoRemessa;
      if (dirty) return true;
       dirty = _devolucaoMaterialOriginalCommited != DevolucaoMaterial;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopOriginalCommited != DevolucaoMaterialCfop;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopForaEstadoOriginalCommited != DevolucaoMaterialCfopForaEstado;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsIncideOriginalCommited != DevolucaoMaterialIcmsIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPartilhaOriginalCommited != DevolucaoMaterialIcmsPartilha;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsSomaFreteBcOriginalCommited != DevolucaoMaterialIcmsSomaFreteBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsCstOriginalCommited != DevolucaoMaterialIcmsCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsAliquotaCreditoOriginalCommited != DevolucaoMaterialIcmsAliquotaCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsModDetBcOriginalCommited != DevolucaoMaterialIcmsModDetBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsReducaoBcOriginalCommited != DevolucaoMaterialIcmsReducaoBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualReducaoBcOriginalCommited != DevolucaoMaterialIcmsPercentualReducaoBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualBcOperacaoPropriaOriginalCommited != DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsStOriginalCommited != DevolucaoMaterialIcmsSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsModDetBcStOriginalCommited != DevolucaoMaterialIcmsModDetBcSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualReducaoBcStOriginalCommited != DevolucaoMaterialIcmsPercentualReducaoBcSt;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsPercentualDiferimentoOriginalCommited != DevolucaoMaterialIcmsPercentualDiferimento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsObservacaoDiferimentoOriginalCommited != DevolucaoMaterialIcmsObservacaoDiferimento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiIncideOriginalCommited != DevolucaoMaterialIpiIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCstOriginalCommited != DevolucaoMaterialIpiCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiModTributacaoOriginalCommited != DevolucaoMaterialIpiModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCodEnquadramentoOriginalCommited != DevolucaoMaterialIpiCodEnquadramento;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiAliquotaOriginalCommited != DevolucaoMaterialIpiAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisIncideOriginalCommited != DevolucaoMaterialPisIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisCstOriginalCommited != DevolucaoMaterialPisCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisModTributacaoOriginalCommited != DevolucaoMaterialPisModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisAliquotaOriginalCommited != DevolucaoMaterialPisAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisImpostoRetidoOriginalCommited != DevolucaoMaterialPisImpostoRetido;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsIncideOriginalCommited != DevolucaoMaterialCofinsIncide;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsCstOriginalCommited != DevolucaoMaterialCofinsCst;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsModTributacaoOriginalCommited != DevolucaoMaterialCofinsModTributacao;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsAliquotaOriginalCommited != DevolucaoMaterialCofinsAliquota;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsImpostoRetidoOriginalCommited != DevolucaoMaterialCofinsImpostoRetido;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _icmsObservacaoCreditoOriginalCommited != IcmsObservacaoCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsObservacaoCreditoOriginalCommited != DevolucaoMaterialIcmsObservacaoCredito;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsMotivoDesoneracaoOriginalCommited != DevolucaoMaterialIcmsMotivoDesoneracao;
      if (dirty) return true;
       dirty = _icmsMotivoDesoneracaoOriginalCommited != IcmsMotivoDesoneracao;
      if (dirty) return true;
       dirty = _ipiSomaFreteBcOriginalCommited != IpiSomaFreteBc;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiSomaFreteBcOriginalCommited != DevolucaoMaterialIpiSomaFreteBc;
      if (dirty) return true;
       dirty = _validaPrecosOriginalCommited != ValidaPrecos;
      if (dirty) return true;
       dirty = _devolucaoMaterialSeparadaOriginalCommited != DevolucaoMaterialSeparada;
      if (dirty) return true;
       dirty = _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited != DevolucaoMaterialSeparadaNatuezaOperacao;
      if (dirty) return true;
       dirty = _pisDescontarIcmsBcOriginalCommited != PisDescontarIcmsBc;
      if (dirty) return true;
       dirty = _cofinsDescontarIcmsBcOriginalCommited != CofinsDescontarIcmsBc;

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
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  foreach(OperacaoCompletaIcmsAliquotaClass item in CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoCompleta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassOperacaoCompleta)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
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
             case "Identificacao":
                return this.Identificacao;
             case "Descricao":
                return this.Descricao;
             case "Cfop":
                return this.Cfop;
             case "CfopForaEstado":
                return this.CfopForaEstado;
             case "NaturezaOperacao":
                return this.NaturezaOperacao;
             case "ConsumidorFinal":
                return this.ConsumidorFinal;
             case "PresencaConsumidor":
                return this.PresencaConsumidor;
             case "GerarContasReceber":
                return this.GerarContasReceber;
             case "IcmsIncide":
                return this.IcmsIncide;
             case "IcmsPartilha":
                return this.IcmsPartilha;
             case "IcmsSomaFreteBc":
                return this.IcmsSomaFreteBc;
             case "IcmsCst":
                return this.IcmsCst;
             case "IcmsAliquotaCredito":
                return this.IcmsAliquotaCredito;
             case "IcmsModDetBc":
                return this.IcmsModDetBc;
             case "IcmsReducaoBc":
                return this.IcmsReducaoBc;
             case "IcmsPercentualReducaoBc":
                return this.IcmsPercentualReducaoBc;
             case "IcmsPercentualBcOperacaoPropria":
                return this.IcmsPercentualBcOperacaoPropria;
             case "IcmsSt":
                return this.IcmsSt;
             case "IcmsModDetBcSt":
                return this.IcmsModDetBcSt;
             case "IcmsPercentualReducaoBcSt":
                return this.IcmsPercentualReducaoBcSt;
             case "IcmsPercentualDiferimento":
                return this.IcmsPercentualDiferimento;
             case "IcmsObservacaoDiferimento":
                return this.IcmsObservacaoDiferimento;
             case "IpiIncide":
                return this.IpiIncide;
             case "IpiCst":
                return this.IpiCst;
             case "IpiModTributacao":
                return this.IpiModTributacao;
             case "IpiCodEnquadramento":
                return this.IpiCodEnquadramento;
             case "IpiAliquota":
                return this.IpiAliquota;
             case "PisIncide":
                return this.PisIncide;
             case "PisCst":
                return this.PisCst;
             case "PisModTributacao":
                return this.PisModTributacao;
             case "PisAliquota":
                return this.PisAliquota;
             case "PisImpostoRetido":
                return this.PisImpostoRetido;
             case "CofinsIncide":
                return this.CofinsIncide;
             case "CofinsCst":
                return this.CofinsCst;
             case "CofinsModTributacao":
                return this.CofinsModTributacao;
             case "CofinsAliquota":
                return this.CofinsAliquota;
             case "CofinsImpostoRetido":
                return this.CofinsImpostoRetido;
             case "EntregaFutura":
                return this.EntregaFutura;
             case "EntregaFuturaCfopRemessa":
                return this.EntregaFuturaCfopRemessa;
             case "EntregaFuturaCfopRemessaForaEstado":
                return this.EntregaFuturaCfopRemessaForaEstado;
             case "EntregaFuturaNaturezaOperacaoRemessa":
                return this.EntregaFuturaNaturezaOperacaoRemessa;
             case "DevolucaoMaterial":
                return this.DevolucaoMaterial;
             case "DevolucaoMaterialCfop":
                return this.DevolucaoMaterialCfop;
             case "DevolucaoMaterialCfopForaEstado":
                return this.DevolucaoMaterialCfopForaEstado;
             case "DevolucaoMaterialIcmsIncide":
                return this.DevolucaoMaterialIcmsIncide;
             case "DevolucaoMaterialIcmsPartilha":
                return this.DevolucaoMaterialIcmsPartilha;
             case "DevolucaoMaterialIcmsSomaFreteBc":
                return this.DevolucaoMaterialIcmsSomaFreteBc;
             case "DevolucaoMaterialIcmsCst":
                return this.DevolucaoMaterialIcmsCst;
             case "DevolucaoMaterialIcmsAliquotaCredito":
                return this.DevolucaoMaterialIcmsAliquotaCredito;
             case "DevolucaoMaterialIcmsModDetBc":
                return this.DevolucaoMaterialIcmsModDetBc;
             case "DevolucaoMaterialIcmsReducaoBc":
                return this.DevolucaoMaterialIcmsReducaoBc;
             case "DevolucaoMaterialIcmsPercentualReducaoBc":
                return this.DevolucaoMaterialIcmsPercentualReducaoBc;
             case "DevolucaoMaterialIcmsPercentualBcOperacaoPropria":
                return this.DevolucaoMaterialIcmsPercentualBcOperacaoPropria;
             case "DevolucaoMaterialIcmsSt":
                return this.DevolucaoMaterialIcmsSt;
             case "DevolucaoMaterialIcmsModDetBcSt":
                return this.DevolucaoMaterialIcmsModDetBcSt;
             case "DevolucaoMaterialIcmsPercentualReducaoBcSt":
                return this.DevolucaoMaterialIcmsPercentualReducaoBcSt;
             case "DevolucaoMaterialIcmsPercentualDiferimento":
                return this.DevolucaoMaterialIcmsPercentualDiferimento;
             case "DevolucaoMaterialIcmsObservacaoDiferimento":
                return this.DevolucaoMaterialIcmsObservacaoDiferimento;
             case "DevolucaoMaterialIpiIncide":
                return this.DevolucaoMaterialIpiIncide;
             case "DevolucaoMaterialIpiCst":
                return this.DevolucaoMaterialIpiCst;
             case "DevolucaoMaterialIpiModTributacao":
                return this.DevolucaoMaterialIpiModTributacao;
             case "DevolucaoMaterialIpiCodEnquadramento":
                return this.DevolucaoMaterialIpiCodEnquadramento;
             case "DevolucaoMaterialIpiAliquota":
                return this.DevolucaoMaterialIpiAliquota;
             case "DevolucaoMaterialPisIncide":
                return this.DevolucaoMaterialPisIncide;
             case "DevolucaoMaterialPisCst":
                return this.DevolucaoMaterialPisCst;
             case "DevolucaoMaterialPisModTributacao":
                return this.DevolucaoMaterialPisModTributacao;
             case "DevolucaoMaterialPisAliquota":
                return this.DevolucaoMaterialPisAliquota;
             case "DevolucaoMaterialPisImpostoRetido":
                return this.DevolucaoMaterialPisImpostoRetido;
             case "DevolucaoMaterialCofinsIncide":
                return this.DevolucaoMaterialCofinsIncide;
             case "DevolucaoMaterialCofinsCst":
                return this.DevolucaoMaterialCofinsCst;
             case "DevolucaoMaterialCofinsModTributacao":
                return this.DevolucaoMaterialCofinsModTributacao;
             case "DevolucaoMaterialCofinsAliquota":
                return this.DevolucaoMaterialCofinsAliquota;
             case "DevolucaoMaterialCofinsImpostoRetido":
                return this.DevolucaoMaterialCofinsImpostoRetido;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "IcmsObservacaoCredito":
                return this.IcmsObservacaoCredito;
             case "DevolucaoMaterialIcmsObservacaoCredito":
                return this.DevolucaoMaterialIcmsObservacaoCredito;
             case "DevolucaoMaterialIcmsMotivoDesoneracao":
                return this.DevolucaoMaterialIcmsMotivoDesoneracao;
             case "IcmsMotivoDesoneracao":
                return this.IcmsMotivoDesoneracao;
             case "IpiSomaFreteBc":
                return this.IpiSomaFreteBc;
             case "DevolucaoMaterialIpiSomaFreteBc":
                return this.DevolucaoMaterialIpiSomaFreteBc;
             case "ValidaPrecos":
                return this.ValidaPrecos;
             case "DevolucaoMaterialSeparada":
                return this.DevolucaoMaterialSeparada;
             case "DevolucaoMaterialSeparadaNatuezaOperacao":
                return this.DevolucaoMaterialSeparadaNatuezaOperacao;
             case "PisDescontarIcmsBc":
                return this.PisDescontarIcmsBc;
             case "CofinsDescontarIcmsBc":
                return this.CofinsDescontarIcmsBc;
              default:
                 return new ArgumentOutOfRangeException();
           }
        }
        public override void ChangeSingleConnection(IWTPostgreNpgsqlConnection newConnection)
        {
          if (this.SingleConnection.Equals(newConnection)) return;
          this.SingleConnection = newConnection; 
               if (_valueCollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompletaLoaded) 
               {
                  foreach(OperacaoCompletaIcmsAliquotaClass item in CollectionOperacaoCompletaIcmsAliquotaClassOperacaoCompleta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCompletaLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOperacaoCompleta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoCompleta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoCompletaEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoCompletaEnvioTerceiros)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoCompletaLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassOperacaoCompleta)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
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
                  command.CommandText += " COUNT(operacao_completa.id_operacao_completa) " ;
               }
               else
               {
               command.CommandText += "operacao_completa.id_operacao_completa, " ;
               command.CommandText += "operacao_completa.opc_identificacao, " ;
               command.CommandText += "operacao_completa.opc_descricao, " ;
               command.CommandText += "operacao_completa.opc_cfop, " ;
               command.CommandText += "operacao_completa.opc_cfop_fora_estado, " ;
               command.CommandText += "operacao_completa.opc_natureza_operacao, " ;
               command.CommandText += "operacao_completa.opc_consumidor_final, " ;
               command.CommandText += "operacao_completa.opc_presenca_consumidor, " ;
               command.CommandText += "operacao_completa.opc_gerar_contas_receber, " ;
               command.CommandText += "operacao_completa.opc_icms_incide, " ;
               command.CommandText += "operacao_completa.opc_icms_partilha, " ;
               command.CommandText += "operacao_completa.opc_icms_soma_frete_bc, " ;
               command.CommandText += "operacao_completa.opc_icms_cst, " ;
               command.CommandText += "operacao_completa.opc_icms_aliquota_credito, " ;
               command.CommandText += "operacao_completa.opc_icms_mod_det_bc, " ;
               command.CommandText += "operacao_completa.opc_icms_reducao_bc, " ;
               command.CommandText += "operacao_completa.opc_icms_percentual_reducao_bc, " ;
               command.CommandText += "operacao_completa.opc_icms_percentual_bc_operacao_propria, " ;
               command.CommandText += "operacao_completa.opc_icms_st, " ;
               command.CommandText += "operacao_completa.opc_icms_mod_det_bc_st, " ;
               command.CommandText += "operacao_completa.opc_icms_percentual_reducao_bc_st, " ;
               command.CommandText += "operacao_completa.opc_icms_percentual_diferimento, " ;
               command.CommandText += "operacao_completa.opc_icms_observacao_diferimento, " ;
               command.CommandText += "operacao_completa.opc_ipi_incide, " ;
               command.CommandText += "operacao_completa.opc_ipi_cst, " ;
               command.CommandText += "operacao_completa.opc_ipi_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_ipi_cod_enquadramento, " ;
               command.CommandText += "operacao_completa.opc_ipi_aliquota, " ;
               command.CommandText += "operacao_completa.opc_pis_incide, " ;
               command.CommandText += "operacao_completa.opc_pis_cst, " ;
               command.CommandText += "operacao_completa.opc_pis_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_pis_aliquota, " ;
               command.CommandText += "operacao_completa.opc_pis_imposto_retido, " ;
               command.CommandText += "operacao_completa.opc_cofins_incide, " ;
               command.CommandText += "operacao_completa.opc_cofins_cst, " ;
               command.CommandText += "operacao_completa.opc_cofins_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_cofins_aliquota, " ;
               command.CommandText += "operacao_completa.opc_cofins_imposto_retido, " ;
               command.CommandText += "operacao_completa.opc_entrega_futura, " ;
               command.CommandText += "operacao_completa.opc_entrega_futura_cfop_remessa, " ;
               command.CommandText += "operacao_completa.opc_entrega_futura_cfop_remessa_fora_estado, " ;
               command.CommandText += "operacao_completa.opc_entrega_futura_natureza_operacao_remessa, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cfop, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cfop_fora_estado, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_incide, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_partilha, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_soma_frete_bc, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_cst, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_aliquota_credito, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_mod_det_bc, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_reducao_bc, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_percentual_bc_operacao_propria, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_st, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_mod_det_bc_st, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc_st, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_percentual_diferimento, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_observacao_diferimento, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_incide, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_cst, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_cod_enquadramento, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_aliquota, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_pis_incide, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_pis_cst, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_pis_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_pis_aliquota, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_pis_imposto_retido, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cofins_incide, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cofins_cst, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cofins_mod_tributacao, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cofins_aliquota, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_cofins_imposto_retido, " ;
               command.CommandText += "operacao_completa.entity_uid, " ;
               command.CommandText += "operacao_completa.version, " ;
               command.CommandText += "operacao_completa.opc_icms_observacao_credito, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_observacao_credito, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_icms_motivo_desoneracao, " ;
               command.CommandText += "operacao_completa.opc_icms_motivo_desoneracao, " ;
               command.CommandText += "operacao_completa.opc_ipi_soma_frete_bc, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_ipi_soma_frete_bc, " ;
               command.CommandText += "operacao_completa.opc_valida_precos, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_separada, " ;
               command.CommandText += "operacao_completa.opc_devolucao_material_separada_natueza_operacao, " ;
               command.CommandText += "operacao_completa.opc_pis_descontar_icms_bc, " ;
               command.CommandText += "operacao_completa.opc_cofins_descontar_icms_bc " ;
               }
               command.CommandText += " FROM  operacao_completa ";
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
                        orderByClause += " , opc_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(opc_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = operacao_completa.id_acs_usuario_ultima_revisao ";
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
                     case "id_operacao_completa":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.id_operacao_completa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.id_operacao_completa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_identificacao":
                     case "Identificacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_identificacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_identificacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cfop_fora_estado":
                     case "CfopForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cfop_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cfop_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_natureza_operacao":
                     case "NaturezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_natureza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_natureza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_consumidor_final":
                     case "ConsumidorFinal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_consumidor_final " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_consumidor_final) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_presenca_consumidor":
                     case "PresencaConsumidor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_presenca_consumidor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_presenca_consumidor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_gerar_contas_receber":
                     case "GerarContasReceber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_gerar_contas_receber " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_gerar_contas_receber) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_incide":
                     case "IcmsIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_partilha":
                     case "IcmsPartilha":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_partilha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_partilha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_soma_frete_bc":
                     case "IcmsSomaFreteBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_soma_frete_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_soma_frete_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_cst":
                     case "IcmsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_icms_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_aliquota_credito":
                     case "IcmsAliquotaCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_aliquota_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_aliquota_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_mod_det_bc":
                     case "IcmsModDetBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_mod_det_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_mod_det_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_reducao_bc":
                     case "IcmsReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_percentual_reducao_bc":
                     case "IcmsPercentualReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_percentual_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_percentual_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_percentual_bc_operacao_propria":
                     case "IcmsPercentualBcOperacaoPropria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_percentual_bc_operacao_propria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_percentual_bc_operacao_propria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_st":
                     case "IcmsSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_mod_det_bc_st":
                     case "IcmsModDetBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_mod_det_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_mod_det_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_percentual_reducao_bc_st":
                     case "IcmsPercentualReducaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_percentual_reducao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_percentual_reducao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_percentual_diferimento":
                     case "IcmsPercentualDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_percentual_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_percentual_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_observacao_diferimento":
                     case "IcmsObservacaoDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_icms_observacao_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_observacao_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_incide":
                     case "IpiIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_ipi_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_cst":
                     case "IpiCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_ipi_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_mod_tributacao":
                     case "IpiModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_ipi_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_cod_enquadramento":
                     case "IpiCodEnquadramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_ipi_cod_enquadramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_cod_enquadramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_aliquota":
                     case "IpiAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_ipi_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_incide":
                     case "PisIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_pis_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_cst":
                     case "PisCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_pis_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_mod_tributacao":
                     case "PisModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_pis_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_aliquota":
                     case "PisAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_pis_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_imposto_retido":
                     case "PisImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_pis_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_incide":
                     case "CofinsIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cofins_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_cst":
                     case "CofinsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_cofins_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_mod_tributacao":
                     case "CofinsModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cofins_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_aliquota":
                     case "CofinsAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cofins_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_imposto_retido":
                     case "CofinsImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cofins_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_entrega_futura":
                     case "EntregaFutura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_entrega_futura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_entrega_futura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_entrega_futura_cfop_remessa":
                     case "EntregaFuturaCfopRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_entrega_futura_cfop_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_entrega_futura_cfop_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_entrega_futura_cfop_remessa_fora_estado":
                     case "EntregaFuturaCfopRemessaForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_entrega_futura_cfop_remessa_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_entrega_futura_cfop_remessa_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_entrega_futura_natureza_operacao_remessa":
                     case "EntregaFuturaNaturezaOperacaoRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_entrega_futura_natureza_operacao_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_entrega_futura_natureza_operacao_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material":
                     case "DevolucaoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cfop":
                     case "DevolucaoMaterialCfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cfop_fora_estado":
                     case "DevolucaoMaterialCfopForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cfop_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cfop_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_incide":
                     case "DevolucaoMaterialIcmsIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_partilha":
                     case "DevolucaoMaterialIcmsPartilha":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_partilha " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_partilha) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_soma_frete_bc":
                     case "DevolucaoMaterialIcmsSomaFreteBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_soma_frete_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_soma_frete_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_cst":
                     case "DevolucaoMaterialIcmsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_aliquota_credito":
                     case "DevolucaoMaterialIcmsAliquotaCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_aliquota_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_aliquota_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_mod_det_bc":
                     case "DevolucaoMaterialIcmsModDetBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_mod_det_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_mod_det_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_reducao_bc":
                     case "DevolucaoMaterialIcmsReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_percentual_reducao_bc":
                     case "DevolucaoMaterialIcmsPercentualReducaoBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_percentual_bc_operacao_propria":
                     case "DevolucaoMaterialIcmsPercentualBcOperacaoPropria":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_percentual_bc_operacao_propria " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_percentual_bc_operacao_propria) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_st":
                     case "DevolucaoMaterialIcmsSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_mod_det_bc_st":
                     case "DevolucaoMaterialIcmsModDetBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_mod_det_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_mod_det_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_percentual_reducao_bc_st":
                     case "DevolucaoMaterialIcmsPercentualReducaoBcSt":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc_st " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc_st) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_percentual_diferimento":
                     case "DevolucaoMaterialIcmsPercentualDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_percentual_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_percentual_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_observacao_diferimento":
                     case "DevolucaoMaterialIcmsObservacaoDiferimento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_observacao_diferimento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_observacao_diferimento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_incide":
                     case "DevolucaoMaterialIpiIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_cst":
                     case "DevolucaoMaterialIpiCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_mod_tributacao":
                     case "DevolucaoMaterialIpiModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_cod_enquadramento":
                     case "DevolucaoMaterialIpiCodEnquadramento":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_cod_enquadramento " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_cod_enquadramento) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_aliquota":
                     case "DevolucaoMaterialIpiAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_pis_incide":
                     case "DevolucaoMaterialPisIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_pis_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_pis_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_pis_cst":
                     case "DevolucaoMaterialPisCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_pis_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_pis_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_pis_mod_tributacao":
                     case "DevolucaoMaterialPisModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_pis_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_pis_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_pis_aliquota":
                     case "DevolucaoMaterialPisAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_pis_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_pis_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_pis_imposto_retido":
                     case "DevolucaoMaterialPisImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_pis_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_pis_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cofins_incide":
                     case "DevolucaoMaterialCofinsIncide":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cofins_incide " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cofins_incide) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cofins_cst":
                     case "DevolucaoMaterialCofinsCst":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cofins_cst " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cofins_cst) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cofins_mod_tributacao":
                     case "DevolucaoMaterialCofinsModTributacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cofins_mod_tributacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cofins_mod_tributacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cofins_aliquota":
                     case "DevolucaoMaterialCofinsAliquota":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cofins_aliquota " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cofins_aliquota) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_cofins_imposto_retido":
                     case "DevolucaoMaterialCofinsImpostoRetido":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_cofins_imposto_retido " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_cofins_imposto_retido) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , operacao_completa.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_observacao_credito":
                     case "IcmsObservacaoCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_icms_observacao_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_observacao_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_observacao_credito":
                     case "DevolucaoMaterialIcmsObservacaoCredito":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_observacao_credito " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_observacao_credito) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_icms_motivo_desoneracao":
                     case "DevolucaoMaterialIcmsMotivoDesoneracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_icms_motivo_desoneracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_icms_motivo_desoneracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_icms_motivo_desoneracao":
                     case "IcmsMotivoDesoneracao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_icms_motivo_desoneracao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_icms_motivo_desoneracao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_ipi_soma_frete_bc":
                     case "IpiSomaFreteBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_ipi_soma_frete_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_ipi_soma_frete_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_ipi_soma_frete_bc":
                     case "DevolucaoMaterialIpiSomaFreteBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_ipi_soma_frete_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_ipi_soma_frete_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_valida_precos":
                     case "ValidaPrecos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_valida_precos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_valida_precos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_separada":
                     case "DevolucaoMaterialSeparada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_devolucao_material_separada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_separada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_devolucao_material_separada_natueza_operacao":
                     case "DevolucaoMaterialSeparadaNatuezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao_completa.opc_devolucao_material_separada_natueza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao_completa.opc_devolucao_material_separada_natueza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_pis_descontar_icms_bc":
                     case "PisDescontarIcmsBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_pis_descontar_icms_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_pis_descontar_icms_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "opc_cofins_descontar_icms_bc":
                     case "CofinsDescontarIcmsBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao_completa.opc_cofins_descontar_icms_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao_completa.opc_cofins_descontar_icms_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_identificacao")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_identificacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_identificacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_descricao")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_natureza_operacao")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_natureza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_natureza_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_icms_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_icms_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_icms_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_icms_observacao_diferimento")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_icms_observacao_diferimento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_icms_observacao_diferimento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_ipi_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_ipi_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_ipi_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_ipi_cod_enquadramento")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_ipi_cod_enquadramento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_ipi_cod_enquadramento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_pis_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_pis_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_pis_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_cofins_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_cofins_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_cofins_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_entrega_futura_natureza_operacao_remessa")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_entrega_futura_natureza_operacao_remessa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_entrega_futura_natureza_operacao_remessa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_icms_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_icms_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_icms_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_icms_observacao_diferimento")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_icms_observacao_diferimento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_icms_observacao_diferimento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_ipi_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_ipi_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_ipi_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_ipi_cod_enquadramento")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_ipi_cod_enquadramento) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_ipi_cod_enquadramento) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_pis_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_pis_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_pis_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_cofins_cst")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_cofins_cst) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_cofins_cst) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_icms_observacao_credito")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_icms_observacao_credito) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_icms_observacao_credito) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_icms_observacao_credito")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_icms_observacao_credito) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_icms_observacao_credito) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("opc_devolucao_material_separada_natueza_operacao")) 
                        {
                           whereClause += " OR UPPER(operacao_completa.opc_devolucao_material_separada_natueza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao_completa.opc_devolucao_material_separada_natueza_operacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_operacao_completa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.id_operacao_completa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.id_operacao_completa = :operacao_completa_ID_3510 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_ID_3510", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Identificacao" || parametro.FieldName == "opc_identificacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_identificacao LIKE :operacao_completa_Identificacao_1175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Identificacao_1175", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "opc_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_descricao LIKE :operacao_completa_Descricao_1997 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Descricao_1997", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "opc_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cfop = :operacao_completa_Cfop_1855 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Cfop_1855", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CfopForaEstado" || parametro.FieldName == "opc_cfop_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cfop_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cfop_fora_estado = :operacao_completa_CfopForaEstado_9230 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CfopForaEstado_9230", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacao" || parametro.FieldName == "opc_natureza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_natureza_operacao LIKE :operacao_completa_NaturezaOperacao_1156 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_NaturezaOperacao_1156", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConsumidorFinal" || parametro.FieldName == "opc_consumidor_final")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_consumidor_final IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_consumidor_final = :operacao_completa_ConsumidorFinal_8886 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_ConsumidorFinal_8886", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PresencaConsumidor" || parametro.FieldName == "opc_presenca_consumidor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PresencaComprador)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PresencaComprador");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_presenca_consumidor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_presenca_consumidor = :operacao_completa_PresencaConsumidor_1275 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PresencaConsumidor_1275", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GerarContasReceber" || parametro.FieldName == "opc_gerar_contas_receber")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_gerar_contas_receber IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_gerar_contas_receber = :operacao_completa_GerarContasReceber_3863 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_GerarContasReceber_3863", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsIncide" || parametro.FieldName == "opc_icms_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_incide = :operacao_completa_IcmsIncide_9331 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsIncide_9331", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPartilha" || parametro.FieldName == "opc_icms_partilha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_partilha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_partilha = :operacao_completa_IcmsPartilha_7446 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsPartilha_7446", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsSomaFreteBc" || parametro.FieldName == "opc_icms_soma_frete_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_soma_frete_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_soma_frete_bc = :operacao_completa_IcmsSomaFreteBc_2795 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsSomaFreteBc_2795", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsCst" || parametro.FieldName == "opc_icms_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_cst LIKE :operacao_completa_IcmsCst_5497 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsCst_5497", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsAliquotaCredito" || parametro.FieldName == "opc_icms_aliquota_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_aliquota_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_aliquota_credito = :operacao_completa_IcmsAliquotaCredito_1507 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsAliquotaCredito_1507", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsModDetBc" || parametro.FieldName == "opc_icms_mod_det_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_mod_det_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_mod_det_bc = :operacao_completa_IcmsModDetBc_3034 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsModDetBc_3034", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsReducaoBc" || parametro.FieldName == "opc_icms_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_reducao_bc = :operacao_completa_IcmsReducaoBc_612 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsReducaoBc_612", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPercentualReducaoBc" || parametro.FieldName == "opc_icms_percentual_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_reducao_bc = :operacao_completa_IcmsPercentualReducaoBc_9640 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsPercentualReducaoBc_9640", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPercentualBcOperacaoPropria" || parametro.FieldName == "opc_icms_percentual_bc_operacao_propria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_bc_operacao_propria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_bc_operacao_propria = :operacao_completa_IcmsPercentualBcOperacaoPropria_5011 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsPercentualBcOperacaoPropria_5011", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsSt" || parametro.FieldName == "opc_icms_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_st = :operacao_completa_IcmsSt_5564 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsSt_5564", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsModDetBcSt" || parametro.FieldName == "opc_icms_mod_det_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_mod_det_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_mod_det_bc_st = :operacao_completa_IcmsModDetBcSt_9563 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsModDetBcSt_9563", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPercentualReducaoBcSt" || parametro.FieldName == "opc_icms_percentual_reducao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_reducao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_reducao_bc_st = :operacao_completa_IcmsPercentualReducaoBcSt_5102 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsPercentualReducaoBcSt_5102", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsPercentualDiferimento" || parametro.FieldName == "opc_icms_percentual_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_percentual_diferimento = :operacao_completa_IcmsPercentualDiferimento_8454 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsPercentualDiferimento_8454", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsObservacaoDiferimento" || parametro.FieldName == "opc_icms_observacao_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_diferimento LIKE :operacao_completa_IcmsObservacaoDiferimento_3274 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsObservacaoDiferimento_3274", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiIncide" || parametro.FieldName == "opc_ipi_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaIPI)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaIPI");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_incide = :operacao_completa_IpiIncide_4835 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiIncide_4835", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCst" || parametro.FieldName == "opc_ipi_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_cst LIKE :operacao_completa_IpiCst_1507 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiCst_1507", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiModTributacao" || parametro.FieldName == "opc_ipi_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_mod_tributacao = :operacao_completa_IpiModTributacao_1127 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiModTributacao_1127", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCodEnquadramento" || parametro.FieldName == "opc_ipi_cod_enquadramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_cod_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_cod_enquadramento LIKE :operacao_completa_IpiCodEnquadramento_362 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiCodEnquadramento_362", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiAliquota" || parametro.FieldName == "opc_ipi_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_aliquota = :operacao_completa_IpiAliquota_4294 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiAliquota_4294", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisIncide" || parametro.FieldName == "opc_pis_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_incide = :operacao_completa_PisIncide_6149 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisIncide_6149", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCst" || parametro.FieldName == "opc_pis_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_cst LIKE :operacao_completa_PisCst_357 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisCst_357", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisModTributacao" || parametro.FieldName == "opc_pis_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_mod_tributacao = :operacao_completa_PisModTributacao_5802 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisModTributacao_5802", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisAliquota" || parametro.FieldName == "opc_pis_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_aliquota = :operacao_completa_PisAliquota_3685 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisAliquota_3685", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisImpostoRetido" || parametro.FieldName == "opc_pis_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_imposto_retido = :operacao_completa_PisImpostoRetido_4069 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisImpostoRetido_4069", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsIncide" || parametro.FieldName == "opc_cofins_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_incide = :operacao_completa_CofinsIncide_7699 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsIncide_7699", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCst" || parametro.FieldName == "opc_cofins_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_cst LIKE :operacao_completa_CofinsCst_1655 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsCst_1655", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsModTributacao" || parametro.FieldName == "opc_cofins_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_mod_tributacao = :operacao_completa_CofinsModTributacao_5308 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsModTributacao_5308", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsAliquota" || parametro.FieldName == "opc_cofins_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_aliquota = :operacao_completa_CofinsAliquota_5230 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsAliquota_5230", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsImpostoRetido" || parametro.FieldName == "opc_cofins_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_imposto_retido = :operacao_completa_CofinsImpostoRetido_5892 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsImpostoRetido_5892", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFutura" || parametro.FieldName == "opc_entrega_futura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura = :operacao_completa_EntregaFutura_3658 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntregaFutura_3658", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaCfopRemessa" || parametro.FieldName == "opc_entrega_futura_cfop_remessa")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_cfop_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_cfop_remessa = :operacao_completa_EntregaFuturaCfopRemessa_8611 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntregaFuturaCfopRemessa_8611", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaCfopRemessaForaEstado" || parametro.FieldName == "opc_entrega_futura_cfop_remessa_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_cfop_remessa_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_cfop_remessa_fora_estado = :operacao_completa_EntregaFuturaCfopRemessaForaEstado_3025 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntregaFuturaCfopRemessaForaEstado_3025", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaNaturezaOperacaoRemessa" || parametro.FieldName == "opc_entrega_futura_natureza_operacao_remessa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_natureza_operacao_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_natureza_operacao_remessa LIKE :operacao_completa_EntregaFuturaNaturezaOperacaoRemessa_557 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntregaFuturaNaturezaOperacaoRemessa_557", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterial" || parametro.FieldName == "opc_devolucao_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material = :operacao_completa_DevolucaoMaterial_9672 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterial_9672", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCfop" || parametro.FieldName == "opc_devolucao_material_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cfop = :operacao_completa_DevolucaoMaterialCfop_6516 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCfop_6516", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCfopForaEstado" || parametro.FieldName == "opc_devolucao_material_cfop_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cfop_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cfop_fora_estado = :operacao_completa_DevolucaoMaterialCfopForaEstado_6091 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCfopForaEstado_6091", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsIncide" || parametro.FieldName == "opc_devolucao_material_icms_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_incide = :operacao_completa_DevolucaoMaterialIcmsIncide_9585 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsIncide_9585", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsPartilha" || parametro.FieldName == "opc_devolucao_material_icms_partilha")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_partilha IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_partilha = :operacao_completa_DevolucaoMaterialIcmsPartilha_2982 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsPartilha_2982", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsSomaFreteBc" || parametro.FieldName == "opc_devolucao_material_icms_soma_frete_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_soma_frete_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_soma_frete_bc = :operacao_completa_DevolucaoMaterialIcmsSomaFreteBc_8879 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsSomaFreteBc_8879", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsCst" || parametro.FieldName == "opc_devolucao_material_icms_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_cst LIKE :operacao_completa_DevolucaoMaterialIcmsCst_409 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsCst_409", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsAliquotaCredito" || parametro.FieldName == "opc_devolucao_material_icms_aliquota_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_aliquota_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_aliquota_credito = :operacao_completa_DevolucaoMaterialIcmsAliquotaCredito_7085 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsAliquotaCredito_7085", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsModDetBc" || parametro.FieldName == "opc_devolucao_material_icms_mod_det_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_mod_det_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_mod_det_bc = :operacao_completa_DevolucaoMaterialIcmsModDetBc_2390 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsModDetBc_2390", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsReducaoBc" || parametro.FieldName == "opc_devolucao_material_icms_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_reducao_bc = :operacao_completa_DevolucaoMaterialIcmsReducaoBc_4456 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsReducaoBc_4456", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsPercentualReducaoBc" || parametro.FieldName == "opc_devolucao_material_icms_percentual_reducao_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc = :operacao_completa_DevolucaoMaterialIcmsPercentualReducaoBc_5774 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsPercentualReducaoBc_5774", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsPercentualBcOperacaoPropria" || parametro.FieldName == "opc_devolucao_material_icms_percentual_bc_operacao_propria")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_bc_operacao_propria IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_bc_operacao_propria = :operacao_completa_DevolucaoMaterialIcmsPercentualBcOperacaoPropria_4191 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsPercentualBcOperacaoPropria_4191", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsSt" || parametro.FieldName == "opc_devolucao_material_icms_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_st = :operacao_completa_DevolucaoMaterialIcmsSt_9890 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsSt_9890", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsModDetBcSt" || parametro.FieldName == "opc_devolucao_material_icms_mod_det_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_mod_det_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_mod_det_bc_st = :operacao_completa_DevolucaoMaterialIcmsModDetBcSt_5054 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsModDetBcSt_5054", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsPercentualReducaoBcSt" || parametro.FieldName == "opc_devolucao_material_icms_percentual_reducao_bc_st")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc_st IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_reducao_bc_st = :operacao_completa_DevolucaoMaterialIcmsPercentualReducaoBcSt_7899 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsPercentualReducaoBcSt_7899", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsPercentualDiferimento" || parametro.FieldName == "opc_devolucao_material_icms_percentual_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_percentual_diferimento = :operacao_completa_DevolucaoMaterialIcmsPercentualDiferimento_7161 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsPercentualDiferimento_7161", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsObservacaoDiferimento" || parametro.FieldName == "opc_devolucao_material_icms_observacao_diferimento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_diferimento LIKE :operacao_completa_DevolucaoMaterialIcmsObservacaoDiferimento_348 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsObservacaoDiferimento_348", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiIncide" || parametro.FieldName == "opc_devolucao_material_ipi_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaIPI?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaIPI?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_incide = :operacao_completa_DevolucaoMaterialIpiIncide_8103 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiIncide_8103", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCst" || parametro.FieldName == "opc_devolucao_material_ipi_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cst LIKE :operacao_completa_DevolucaoMaterialIpiCst_795 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiCst_795", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiModTributacao" || parametro.FieldName == "opc_devolucao_material_ipi_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_mod_tributacao = :operacao_completa_DevolucaoMaterialIpiModTributacao_4593 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiModTributacao_4593", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCodEnquadramento" || parametro.FieldName == "opc_devolucao_material_ipi_cod_enquadramento")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cod_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cod_enquadramento LIKE :operacao_completa_DevolucaoMaterialIpiCodEnquadramento_5125 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiCodEnquadramento_5125", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiAliquota" || parametro.FieldName == "opc_devolucao_material_ipi_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_aliquota = :operacao_completa_DevolucaoMaterialIpiAliquota_3507 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiAliquota_3507", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisIncide" || parametro.FieldName == "opc_devolucao_material_pis_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_incide = :operacao_completa_DevolucaoMaterialPisIncide_3530 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisIncide_3530", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisCst" || parametro.FieldName == "opc_devolucao_material_pis_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_cst LIKE :operacao_completa_DevolucaoMaterialPisCst_3762 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisCst_3762", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisModTributacao" || parametro.FieldName == "opc_devolucao_material_pis_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_mod_tributacao = :operacao_completa_DevolucaoMaterialPisModTributacao_8725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisModTributacao_8725", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisAliquota" || parametro.FieldName == "opc_devolucao_material_pis_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_aliquota = :operacao_completa_DevolucaoMaterialPisAliquota_7797 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisAliquota_7797", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisImpostoRetido" || parametro.FieldName == "opc_devolucao_material_pis_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_imposto_retido = :operacao_completa_DevolucaoMaterialPisImpostoRetido_9850 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisImpostoRetido_9850", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsIncide" || parametro.FieldName == "opc_devolucao_material_cofins_incide")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_incide IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_incide = :operacao_completa_DevolucaoMaterialCofinsIncide_7725 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsIncide_7725", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsCst" || parametro.FieldName == "opc_devolucao_material_cofins_cst")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_cst LIKE :operacao_completa_DevolucaoMaterialCofinsCst_5381 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsCst_5381", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsModTributacao" || parametro.FieldName == "opc_devolucao_material_cofins_mod_tributacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_mod_tributacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_mod_tributacao = :operacao_completa_DevolucaoMaterialCofinsModTributacao_3749 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsModTributacao_3749", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsAliquota" || parametro.FieldName == "opc_devolucao_material_cofins_aliquota")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo double");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_aliquota IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_aliquota = :operacao_completa_DevolucaoMaterialCofinsAliquota_1353 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsAliquota_1353", NpgsqlDbType.Double, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsImpostoRetido" || parametro.FieldName == "opc_devolucao_material_cofins_imposto_retido")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_imposto_retido IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_imposto_retido = :operacao_completa_DevolucaoMaterialCofinsImpostoRetido_6952 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsImpostoRetido_6952", NpgsqlDbType.Boolean, parametro.Fieldvalue));
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
                         whereClause += "  operacao_completa.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.entity_uid LIKE :operacao_completa_EntityUid_6538 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntityUid_6538", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  operacao_completa.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.version = :operacao_completa_Version_4546 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Version_4546", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsObservacaoCredito" || parametro.FieldName == "opc_icms_observacao_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_credito LIKE :operacao_completa_IcmsObservacaoCredito_8780 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsObservacaoCredito_8780", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsObservacaoCredito" || parametro.FieldName == "opc_devolucao_material_icms_observacao_credito")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_credito LIKE :operacao_completa_DevolucaoMaterialIcmsObservacaoCredito_6757 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsObservacaoCredito_6757", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsMotivoDesoneracao" || parametro.FieldName == "opc_devolucao_material_icms_motivo_desoneracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_motivo_desoneracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_motivo_desoneracao = :operacao_completa_DevolucaoMaterialIcmsMotivoDesoneracao_8743 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsMotivoDesoneracao_8743", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsMotivoDesoneracao" || parametro.FieldName == "opc_icms_motivo_desoneracao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is short?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo short?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_motivo_desoneracao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_motivo_desoneracao = :operacao_completa_IcmsMotivoDesoneracao_1921 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsMotivoDesoneracao_1921", NpgsqlDbType.Smallint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiSomaFreteBc" || parametro.FieldName == "opc_ipi_soma_frete_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_soma_frete_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_soma_frete_bc = :operacao_completa_IpiSomaFreteBc_8144 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiSomaFreteBc_8144", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiSomaFreteBc" || parametro.FieldName == "opc_devolucao_material_ipi_soma_frete_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_soma_frete_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_soma_frete_bc = :operacao_completa_DevolucaoMaterialIpiSomaFreteBc_1481 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiSomaFreteBc_1481", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValidaPrecos" || parametro.FieldName == "opc_valida_precos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiValidaPrecos)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiValidaPrecos");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_valida_precos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_valida_precos = :operacao_completa_ValidaPrecos_3885 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_ValidaPrecos_3885", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialSeparada" || parametro.FieldName == "opc_devolucao_material_separada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada = :operacao_completa_DevolucaoMaterialSeparada_9062 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialSeparada_9062", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialSeparadaNatuezaOperacao" || parametro.FieldName == "opc_devolucao_material_separada_natueza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada_natueza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada_natueza_operacao LIKE :operacao_completa_DevolucaoMaterialSeparadaNatuezaOperacao_7965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialSeparadaNatuezaOperacao_7965", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisDescontarIcmsBc" || parametro.FieldName == "opc_pis_descontar_icms_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_descontar_icms_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_descontar_icms_bc = :operacao_completa_PisDescontarIcmsBc_1347 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisDescontarIcmsBc_1347", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsDescontarIcmsBc" || parametro.FieldName == "opc_cofins_descontar_icms_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_descontar_icms_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_descontar_icms_bc = :operacao_completa_CofinsDescontarIcmsBc_7910 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsDescontarIcmsBc_7910", NpgsqlDbType.Boolean, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IdentificacaoExato" || parametro.FieldName == "IdentificacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_identificacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_identificacao LIKE :operacao_completa_Identificacao_9877 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Identificacao_9877", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DescricaoExato" || parametro.FieldName == "DescricaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_descricao LIKE :operacao_completa_Descricao_7807 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_Descricao_7807", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacaoExato" || parametro.FieldName == "NaturezaOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_natureza_operacao LIKE :operacao_completa_NaturezaOperacao_6600 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_NaturezaOperacao_6600", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsCstExato" || parametro.FieldName == "IcmsCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_cst LIKE :operacao_completa_IcmsCst_7407 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsCst_7407", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsObservacaoDiferimentoExato" || parametro.FieldName == "IcmsObservacaoDiferimentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_diferimento LIKE :operacao_completa_IcmsObservacaoDiferimento_8067 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsObservacaoDiferimento_8067", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCstExato" || parametro.FieldName == "IpiCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_cst LIKE :operacao_completa_IpiCst_5544 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiCst_5544", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCodEnquadramentoExato" || parametro.FieldName == "IpiCodEnquadramentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_ipi_cod_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_ipi_cod_enquadramento LIKE :operacao_completa_IpiCodEnquadramento_5553 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IpiCodEnquadramento_5553", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCstExato" || parametro.FieldName == "PisCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_pis_cst LIKE :operacao_completa_PisCst_7816 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_PisCst_7816", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCstExato" || parametro.FieldName == "CofinsCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_cofins_cst LIKE :operacao_completa_CofinsCst_8430 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_CofinsCst_8430", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaNaturezaOperacaoRemessaExato" || parametro.FieldName == "EntregaFuturaNaturezaOperacaoRemessaExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_natureza_operacao_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_entrega_futura_natureza_operacao_remessa LIKE :operacao_completa_EntregaFuturaNaturezaOperacaoRemessa_5431 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntregaFuturaNaturezaOperacaoRemessa_5431", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsCstExato" || parametro.FieldName == "DevolucaoMaterialIcmsCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_cst LIKE :operacao_completa_DevolucaoMaterialIcmsCst_6166 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsCst_6166", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsObservacaoDiferimentoExato" || parametro.FieldName == "DevolucaoMaterialIcmsObservacaoDiferimentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_diferimento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_diferimento LIKE :operacao_completa_DevolucaoMaterialIcmsObservacaoDiferimento_2987 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsObservacaoDiferimento_2987", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCstExato" || parametro.FieldName == "DevolucaoMaterialIpiCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cst LIKE :operacao_completa_DevolucaoMaterialIpiCst_2329 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiCst_2329", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCodEnquadramentoExato" || parametro.FieldName == "DevolucaoMaterialIpiCodEnquadramentoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cod_enquadramento IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_ipi_cod_enquadramento LIKE :operacao_completa_DevolucaoMaterialIpiCodEnquadramento_861 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIpiCodEnquadramento_861", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisCstExato" || parametro.FieldName == "DevolucaoMaterialPisCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_pis_cst LIKE :operacao_completa_DevolucaoMaterialPisCst_5184 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialPisCst_5184", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsCstExato" || parametro.FieldName == "DevolucaoMaterialCofinsCstExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_cst IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_cofins_cst LIKE :operacao_completa_DevolucaoMaterialCofinsCst_9027 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialCofinsCst_9027", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  operacao_completa.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.entity_uid LIKE :operacao_completa_EntityUid_2682 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_EntityUid_2682", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsObservacaoCreditoExato" || parametro.FieldName == "IcmsObservacaoCreditoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_icms_observacao_credito LIKE :operacao_completa_IcmsObservacaoCredito_1705 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_IcmsObservacaoCredito_1705", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsObservacaoCreditoExato" || parametro.FieldName == "DevolucaoMaterialIcmsObservacaoCreditoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_credito IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_icms_observacao_credito LIKE :operacao_completa_DevolucaoMaterialIcmsObservacaoCredito_8639 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialIcmsObservacaoCredito_8639", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialSeparadaNatuezaOperacaoExato" || parametro.FieldName == "DevolucaoMaterialSeparadaNatuezaOperacaoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada_natueza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao_completa.opc_devolucao_material_separada_natueza_operacao LIKE :operacao_completa_DevolucaoMaterialSeparadaNatuezaOperacao_3103 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_completa_DevolucaoMaterialSeparadaNatuezaOperacao_3103", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OperacaoCompletaClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OperacaoCompletaClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OperacaoCompletaClass), Convert.ToInt32(read["id_operacao_completa"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OperacaoCompletaClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_operacao_completa"]);
                     entidade.Identificacao = (read["opc_identificacao"] != DBNull.Value ? read["opc_identificacao"].ToString() : null);
                     entidade.Descricao = (read["opc_descricao"] != DBNull.Value ? read["opc_descricao"].ToString() : null);
                     entidade.Cfop = (int)read["opc_cfop"];
                     entidade.CfopForaEstado = (int)read["opc_cfop_fora_estado"];
                     entidade.NaturezaOperacao = (read["opc_natureza_operacao"] != DBNull.Value ? read["opc_natureza_operacao"].ToString() : null);
                     entidade.ConsumidorFinal = Convert.ToBoolean(read["opc_consumidor_final"]);
                     entidade.PresencaConsumidor = (PresencaComprador) (read["opc_presenca_consumidor"] != DBNull.Value ? Enum.ToObject(typeof(PresencaComprador), read["opc_presenca_consumidor"]) : null);
                     entidade.GerarContasReceber = Convert.ToBoolean(read["opc_gerar_contas_receber"]);
                     entidade.IcmsIncide = (IncidenciaImposto) (read["opc_icms_incide"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["opc_icms_incide"]) : null);
                     entidade.IcmsPartilha = Convert.ToBoolean(read["opc_icms_partilha"]);
                     entidade.IcmsSomaFreteBc = Convert.ToBoolean(read["opc_icms_soma_frete_bc"]);
                     entidade.IcmsCst = (read["opc_icms_cst"] != DBNull.Value ? read["opc_icms_cst"].ToString() : null);
                     entidade.IcmsAliquotaCredito = (double)read["opc_icms_aliquota_credito"];
                     entidade.IcmsModDetBc = (short)read["opc_icms_mod_det_bc"];
                     entidade.IcmsReducaoBc = Convert.ToBoolean(read["opc_icms_reducao_bc"]);
                     entidade.IcmsPercentualReducaoBc = (double)read["opc_icms_percentual_reducao_bc"];
                     entidade.IcmsPercentualBcOperacaoPropria = (double)read["opc_icms_percentual_bc_operacao_propria"];
                     entidade.IcmsSt = (short)read["opc_icms_st"];
                     entidade.IcmsModDetBcSt = (short)read["opc_icms_mod_det_bc_st"];
                     entidade.IcmsPercentualReducaoBcSt = (double)read["opc_icms_percentual_reducao_bc_st"];
                     entidade.IcmsPercentualDiferimento = (double)read["opc_icms_percentual_diferimento"];
                     entidade.IcmsObservacaoDiferimento = (read["opc_icms_observacao_diferimento"] != DBNull.Value ? read["opc_icms_observacao_diferimento"].ToString() : null);
                     entidade.IpiIncide = (IncidenciaIPI) (read["opc_ipi_incide"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaIPI), read["opc_ipi_incide"]) : null);
                     entidade.IpiCst = (read["opc_ipi_cst"] != DBNull.Value ? read["opc_ipi_cst"].ToString() : null);
                     entidade.IpiModTributacao = (short)read["opc_ipi_mod_tributacao"];
                     entidade.IpiCodEnquadramento = (read["opc_ipi_cod_enquadramento"] != DBNull.Value ? read["opc_ipi_cod_enquadramento"].ToString() : null);
                     entidade.IpiAliquota = (double)read["opc_ipi_aliquota"];
                     entidade.PisIncide = (IncidenciaImposto) (read["opc_pis_incide"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["opc_pis_incide"]) : null);
                     entidade.PisCst = (read["opc_pis_cst"] != DBNull.Value ? read["opc_pis_cst"].ToString() : null);
                     entidade.PisModTributacao = (short)read["opc_pis_mod_tributacao"];
                     entidade.PisAliquota = (double)read["opc_pis_aliquota"];
                     entidade.PisImpostoRetido = Convert.ToBoolean(read["opc_pis_imposto_retido"]);
                     entidade.CofinsIncide = (IncidenciaImposto) (read["opc_cofins_incide"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["opc_cofins_incide"]) : null);
                     entidade.CofinsCst = (read["opc_cofins_cst"] != DBNull.Value ? read["opc_cofins_cst"].ToString() : null);
                     entidade.CofinsModTributacao = (short)read["opc_cofins_mod_tributacao"];
                     entidade.CofinsAliquota = (double)read["opc_cofins_aliquota"];
                     entidade.CofinsImpostoRetido = Convert.ToBoolean(read["opc_cofins_imposto_retido"]);
                     entidade.EntregaFutura = Convert.ToBoolean(read["opc_entrega_futura"]);
                     entidade.EntregaFuturaCfopRemessa = read["opc_entrega_futura_cfop_remessa"] as int?;
                     entidade.EntregaFuturaCfopRemessaForaEstado = read["opc_entrega_futura_cfop_remessa_fora_estado"] as int?;
                     entidade.EntregaFuturaNaturezaOperacaoRemessa = (read["opc_entrega_futura_natureza_operacao_remessa"] != DBNull.Value ? read["opc_entrega_futura_natureza_operacao_remessa"].ToString() : null);
                     entidade.DevolucaoMaterial = Convert.ToBoolean(read["opc_devolucao_material"]);
                     entidade.DevolucaoMaterialCfop = read["opc_devolucao_material_cfop"] as int?;
                     entidade.DevolucaoMaterialCfopForaEstado = read["opc_devolucao_material_cfop_fora_estado"] as int?;
                     entidade.DevolucaoMaterialIcmsIncide = (IncidenciaImposto?) (read["opc_devolucao_material_icms_incide"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["opc_devolucao_material_icms_incide"]) : null);
                     entidade.DevolucaoMaterialIcmsPartilha = Convert.ToBoolean(read["opc_devolucao_material_icms_partilha"]);
                     entidade.DevolucaoMaterialIcmsSomaFreteBc = Convert.ToBoolean(read["opc_devolucao_material_icms_soma_frete_bc"]);
                     entidade.DevolucaoMaterialIcmsCst = (read["opc_devolucao_material_icms_cst"] != DBNull.Value ? read["opc_devolucao_material_icms_cst"].ToString() : null);
                     entidade.DevolucaoMaterialIcmsAliquotaCredito = (double)read["opc_devolucao_material_icms_aliquota_credito"];
                     entidade.DevolucaoMaterialIcmsModDetBc = (short)read["opc_devolucao_material_icms_mod_det_bc"];
                     entidade.DevolucaoMaterialIcmsReducaoBc = Convert.ToBoolean(read["opc_devolucao_material_icms_reducao_bc"]);
                     entidade.DevolucaoMaterialIcmsPercentualReducaoBc = (double)read["opc_devolucao_material_icms_percentual_reducao_bc"];
                     entidade.DevolucaoMaterialIcmsPercentualBcOperacaoPropria = (double)read["opc_devolucao_material_icms_percentual_bc_operacao_propria"];
                     entidade.DevolucaoMaterialIcmsSt = (short)read["opc_devolucao_material_icms_st"];
                     entidade.DevolucaoMaterialIcmsModDetBcSt = (short)read["opc_devolucao_material_icms_mod_det_bc_st"];
                     entidade.DevolucaoMaterialIcmsPercentualReducaoBcSt = (double)read["opc_devolucao_material_icms_percentual_reducao_bc_st"];
                     entidade.DevolucaoMaterialIcmsPercentualDiferimento = (double)read["opc_devolucao_material_icms_percentual_diferimento"];
                     entidade.DevolucaoMaterialIcmsObservacaoDiferimento = (read["opc_devolucao_material_icms_observacao_diferimento"] != DBNull.Value ? read["opc_devolucao_material_icms_observacao_diferimento"].ToString() : null);
                     entidade.DevolucaoMaterialIpiIncide = (IncidenciaIPI?) (read["opc_devolucao_material_ipi_incide"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaIPI?)), read["opc_devolucao_material_ipi_incide"]) : null);
                     entidade.DevolucaoMaterialIpiCst = (read["opc_devolucao_material_ipi_cst"] != DBNull.Value ? read["opc_devolucao_material_ipi_cst"].ToString() : null);
                     entidade.DevolucaoMaterialIpiModTributacao = (short)read["opc_devolucao_material_ipi_mod_tributacao"];
                     entidade.DevolucaoMaterialIpiCodEnquadramento = (read["opc_devolucao_material_ipi_cod_enquadramento"] != DBNull.Value ? read["opc_devolucao_material_ipi_cod_enquadramento"].ToString() : null);
                     entidade.DevolucaoMaterialIpiAliquota = (double)read["opc_devolucao_material_ipi_aliquota"];
                     entidade.DevolucaoMaterialPisIncide = (IncidenciaImposto?) (read["opc_devolucao_material_pis_incide"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["opc_devolucao_material_pis_incide"]) : null);
                     entidade.DevolucaoMaterialPisCst = (read["opc_devolucao_material_pis_cst"] != DBNull.Value ? read["opc_devolucao_material_pis_cst"].ToString() : null);
                     entidade.DevolucaoMaterialPisModTributacao = (short)read["opc_devolucao_material_pis_mod_tributacao"];
                     entidade.DevolucaoMaterialPisAliquota = (double)read["opc_devolucao_material_pis_aliquota"];
                     entidade.DevolucaoMaterialPisImpostoRetido = Convert.ToBoolean(read["opc_devolucao_material_pis_imposto_retido"]);
                     entidade.DevolucaoMaterialCofinsIncide = (IncidenciaImposto?) (read["opc_devolucao_material_cofins_incide"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["opc_devolucao_material_cofins_incide"]) : null);
                     entidade.DevolucaoMaterialCofinsCst = (read["opc_devolucao_material_cofins_cst"] != DBNull.Value ? read["opc_devolucao_material_cofins_cst"].ToString() : null);
                     entidade.DevolucaoMaterialCofinsModTributacao = (short)read["opc_devolucao_material_cofins_mod_tributacao"];
                     entidade.DevolucaoMaterialCofinsAliquota = (double)read["opc_devolucao_material_cofins_aliquota"];
                     entidade.DevolucaoMaterialCofinsImpostoRetido = Convert.ToBoolean(read["opc_devolucao_material_cofins_imposto_retido"]);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.IcmsObservacaoCredito = (read["opc_icms_observacao_credito"] != DBNull.Value ? read["opc_icms_observacao_credito"].ToString() : null);
                     entidade.DevolucaoMaterialIcmsObservacaoCredito = (read["opc_devolucao_material_icms_observacao_credito"] != DBNull.Value ? read["opc_devolucao_material_icms_observacao_credito"].ToString() : null);
                     entidade.DevolucaoMaterialIcmsMotivoDesoneracao = read["opc_devolucao_material_icms_motivo_desoneracao"] as short?;
                     entidade.IcmsMotivoDesoneracao = read["opc_icms_motivo_desoneracao"] as short?;
                     entidade.IpiSomaFreteBc = Convert.ToBoolean(read["opc_ipi_soma_frete_bc"]);
                     entidade.DevolucaoMaterialIpiSomaFreteBc = Convert.ToBoolean(read["opc_devolucao_material_ipi_soma_frete_bc"]);
                     entidade.ValidaPrecos = (EasiValidaPrecos) (read["opc_valida_precos"] != DBNull.Value ? Enum.ToObject(typeof(EasiValidaPrecos), read["opc_valida_precos"]) : null);
                     entidade.DevolucaoMaterialSeparada = Convert.ToBoolean(Convert.ToInt16(read["opc_devolucao_material_separada"]));
                     entidade.DevolucaoMaterialSeparadaNatuezaOperacao = (read["opc_devolucao_material_separada_natueza_operacao"] != DBNull.Value ? read["opc_devolucao_material_separada_natueza_operacao"].ToString() : null);
                     entidade.PisDescontarIcmsBc = Convert.ToBoolean(read["opc_pis_descontar_icms_bc"]);
                     entidade.CofinsDescontarIcmsBc = Convert.ToBoolean(read["opc_cofins_descontar_icms_bc"]);
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OperacaoCompletaClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
