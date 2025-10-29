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
     [Table("operacao","ope")]
     public class OperacaoBaseClass:AbstractEntity 
    { 
       protected bool NaoCarregarIdNegativo { get; set; }
 #region Constantes
protected const string ErroLoad = "Erro ao carregar os dados do OperacaoClass";
protected const string ErroDelete = "Erro ao excluir o OperacaoClass  ";
protected const string ErroSave = "Erro ao salvar o OperacaoClass.";
protected const string ErroCollectionOrcamentoItemClassOperacao = "Erro ao carregar a coleção de OrcamentoItemClass.";
protected const string ErroCollectionOrdemProducaoEnvioTerceirosClassOperacao = "Erro ao carregar a coleção de OrdemProducaoEnvioTerceirosClass.";
protected const string ErroCollectionPedidoItemClassOperacao = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPedidoItemClassOperacaoEnvioTerceiros = "Erro ao carregar a coleção de PedidoItemClass.";
protected const string ErroCollectionPostoTrabalhoClassOperacao = "Erro ao carregar a coleção de PostoTrabalhoClass.";
protected const string ErroDescricaoObrigatorio = "O campo Descricao é obrigatório";
protected const string ErroDescricaoComprimento = "O campo Descricao deve ter no máximo 255 caracteres";
protected const string ErroNaturezaOperacaoObrigatorio = "O campo NaturezaOperacao é obrigatório";
protected const string ErroNaturezaOperacaoComprimento = "O campo NaturezaOperacao deve ter no máximo 255 caracteres";
protected const string ErroEntityUidObrigatorio = "O campo EntityUid é obrigatório";
protected const string ErroEntityUidComprimento = "O campo EntityUid deve ter no máximo 36 caracteres";
protected const string ErroValidate = "Erro ao validar os dados do OperacaoClass.";
protected const string MensagemUtilizadoCollectionOrcamentoItemClassOperacao =  "A entidade OperacaoClass está sendo utilizada nos seguintes OrcamentoItemClass:";
protected const string MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOperacao =  "A entidade OperacaoClass está sendo utilizada nos seguintes OrdemProducaoEnvioTerceirosClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassOperacao =  "A entidade OperacaoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPedidoItemClassOperacaoEnvioTerceiros =  "A entidade OperacaoClass está sendo utilizada nos seguintes PedidoItemClass:";
protected const string MensagemUtilizadoCollectionPostoTrabalhoClassOperacao =  "A entidade OperacaoClass está sendo utilizada nos seguintes PostoTrabalhoClass:";
protected const string ErroUtilizado =  "Erro ao verificar se a entidade OperacaoClass está sendo utilizada.";
#endregion
       protected string _descricaoOriginal{get;private set;}
       private string _descricaoOriginalCommited{get; set;}
        private string _valueDescricao;
         [Column("ope_descricao")]
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
         [Column("ope_cfop")]
        public virtual int Cfop
         { 
            get { return this._valueCfop; } 
            set 
            { 
                if (this._valueCfop == value)return;
                 this._valueCfop = value; 
            } 
        } 

       protected string _naturezaOperacaoOriginal{get;private set;}
       private string _naturezaOperacaoOriginalCommited{get; set;}
        private string _valueNaturezaOperacao;
         [Column("ope_natureza_operacao")]
        public virtual string NaturezaOperacao
         { 
            get { return this._valueNaturezaOperacao; } 
            set 
            { 
                if (this._valueNaturezaOperacao == value)return;
                 this._valueNaturezaOperacao = value; 
            } 
        } 

       protected IncidenciaImposto _incideIcmsOriginal{get;private set;}
       private IncidenciaImposto _incideIcmsOriginalCommited{get; set;}
        private IncidenciaImposto _valueIncideIcms;
         [Column("ope_incide_icms")]
        public virtual IncidenciaImposto IncideIcms
         { 
            get { return this._valueIncideIcms; } 
            set 
            { 
                if (this._valueIncideIcms == value)return;
                 this._valueIncideIcms = value; 
            } 
        } 

        public bool IncideIcms_NaoIncide
         { 
            get { return this._valueIncideIcms == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IncideIcms_Incide
         { 
            get { return this._valueIncideIcms == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IncideIcms_Suspenso
         { 
            get { return this._valueIncideIcms == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto _incideIpiOriginal{get;private set;}
       private IncidenciaImposto _incideIpiOriginalCommited{get; set;}
        private IncidenciaImposto _valueIncideIpi;
         [Column("ope_incide_ipi")]
        public virtual IncidenciaImposto IncideIpi
         { 
            get { return this._valueIncideIpi; } 
            set 
            { 
                if (this._valueIncideIpi == value)return;
                 this._valueIncideIpi = value; 
            } 
        } 

        public bool IncideIpi_NaoIncide
         { 
            get { return this._valueIncideIpi == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IncideIpi_Incide
         { 
            get { return this._valueIncideIpi == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IncideIpi_Suspenso
         { 
            get { return this._valueIncideIpi == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto _incidePisOriginal{get;private set;}
       private IncidenciaImposto _incidePisOriginalCommited{get; set;}
        private IncidenciaImposto _valueIncidePis;
         [Column("ope_incide_pis")]
        public virtual IncidenciaImposto IncidePis
         { 
            get { return this._valueIncidePis; } 
            set 
            { 
                if (this._valueIncidePis == value)return;
                 this._valueIncidePis = value; 
            } 
        } 

        public bool IncidePis_NaoIncide
         { 
            get { return this._valueIncidePis == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IncidePis_Incide
         { 
            get { return this._valueIncidePis == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IncidePis_Suspenso
         { 
            get { return this._valueIncidePis == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto _incideCofinsOriginal{get;private set;}
       private IncidenciaImposto _incideCofinsOriginalCommited{get; set;}
        private IncidenciaImposto _valueIncideCofins;
         [Column("ope_incide_cofins")]
        public virtual IncidenciaImposto IncideCofins
         { 
            get { return this._valueIncideCofins; } 
            set 
            { 
                if (this._valueIncideCofins == value)return;
                 this._valueIncideCofins = value; 
            } 
        } 

        public bool IncideCofins_NaoIncide
         { 
            get { return this._valueIncideCofins == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IncideCofins_Incide
         { 
            get { return this._valueIncideCofins == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IncideCofins_Suspenso
         { 
            get { return this._valueIncideCofins == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto _incideIssOriginal{get;private set;}
       private IncidenciaImposto _incideIssOriginalCommited{get; set;}
        private IncidenciaImposto _valueIncideIss;
         [Column("ope_incide_iss")]
        public virtual IncidenciaImposto IncideIss
         { 
            get { return this._valueIncideIss; } 
            set 
            { 
                if (this._valueIncideIss == value)return;
                 this._valueIncideIss = value; 
            } 
        } 

        public bool IncideIss_NaoIncide
         { 
            get { return this._valueIncideIss == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool IncideIss_Incide
         { 
            get { return this._valueIncideIss == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool IncideIss_Suspenso
         { 
            get { return this._valueIncideIss == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected EasiValidaPrecos _validaPrecosOriginal{get;private set;}
       private EasiValidaPrecos _validaPrecosOriginalCommited{get; set;}
        private EasiValidaPrecos _valueValidaPrecos;
         [Column("ope_valida_precos")]
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

       protected int _cfopForaEstadoOriginal{get;private set;}
       private int _cfopForaEstadoOriginalCommited{get; set;}
        private int _valueCfopForaEstado;
         [Column("ope_cfop_fora_estado")]
        public virtual int CfopForaEstado
         { 
            get { return this._valueCfopForaEstado; } 
            set 
            { 
                if (this._valueCfopForaEstado == value)return;
                 this._valueCfopForaEstado = value; 
            } 
        } 

       protected string _icmsCstSuspensoOriginal{get;private set;}
       private string _icmsCstSuspensoOriginalCommited{get; set;}
        private string _valueIcmsCstSuspenso;
         [Column("ope_icms_cst_suspenso")]
        public virtual string IcmsCstSuspenso
         { 
            get { return this._valueIcmsCstSuspenso; } 
            set 
            { 
                if (this._valueIcmsCstSuspenso == value)return;
                 this._valueIcmsCstSuspenso = value; 
            } 
        } 

       protected string _ipiCstSuspensoOriginal{get;private set;}
       private string _ipiCstSuspensoOriginalCommited{get; set;}
        private string _valueIpiCstSuspenso;
         [Column("ope_ipi_cst_suspenso")]
        public virtual string IpiCstSuspenso
         { 
            get { return this._valueIpiCstSuspenso; } 
            set 
            { 
                if (this._valueIpiCstSuspenso == value)return;
                 this._valueIpiCstSuspenso = value; 
            } 
        } 

       protected string _pisCstSuspensoOriginal{get;private set;}
       private string _pisCstSuspensoOriginalCommited{get; set;}
        private string _valuePisCstSuspenso;
         [Column("ope_pis_cst_suspenso")]
        public virtual string PisCstSuspenso
         { 
            get { return this._valuePisCstSuspenso; } 
            set 
            { 
                if (this._valuePisCstSuspenso == value)return;
                 this._valuePisCstSuspenso = value; 
            } 
        } 

       protected string _cofinsCstSuspensoOriginal{get;private set;}
       private string _cofinsCstSuspensoOriginalCommited{get; set;}
        private string _valueCofinsCstSuspenso;
         [Column("ope_cofins_cst_suspenso")]
        public virtual string CofinsCstSuspenso
         { 
            get { return this._valueCofinsCstSuspenso; } 
            set 
            { 
                if (this._valueCofinsCstSuspenso == value)return;
                 this._valueCofinsCstSuspenso = value; 
            } 
        } 

       protected bool _devolucaoMaterialOriginal{get;private set;}
       private bool _devolucaoMaterialOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterial;
         [Column("ope_devolucao_material")]
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
         [Column("ope_devolucao_material_cfop")]
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
         [Column("ope_devolucao_material_cfop_fora_estado")]
        public virtual int? DevolucaoMaterialCfopForaEstado
         { 
            get { return this._valueDevolucaoMaterialCfopForaEstado; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCfopForaEstado == value)return;
                 this._valueDevolucaoMaterialCfopForaEstado = value; 
            } 
        } 

       protected IncidenciaImposto? _devolucaoMaterialIncideIcmsOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIncideIcmsOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIncideIcms;
         [Column("ope_devolucao_material_incide_icms")]
        public virtual IncidenciaImposto? DevolucaoMaterialIncideIcms
         { 
            get { return this._valueDevolucaoMaterialIncideIcms; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIncideIcms == value)return;
                 this._valueDevolucaoMaterialIncideIcms = value; 
            } 
        } 

        public bool DevolucaoMaterialIncideIcms_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIncideIcms.HasValue && this._valueDevolucaoMaterialIncideIcms.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIncideIcms_Incide
         { 
            get { return this._valueDevolucaoMaterialIncideIcms.HasValue && this._valueDevolucaoMaterialIncideIcms.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIncideIcms_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIncideIcms.HasValue && this._valueDevolucaoMaterialIncideIcms.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIncideIcms = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto? _devolucaoMaterialIncideIpiOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIncideIpiOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIncideIpi;
         [Column("ope_devolucao_material_incide_ipi")]
        public virtual IncidenciaImposto? DevolucaoMaterialIncideIpi
         { 
            get { return this._valueDevolucaoMaterialIncideIpi; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIncideIpi == value)return;
                 this._valueDevolucaoMaterialIncideIpi = value; 
            } 
        } 

        public bool DevolucaoMaterialIncideIpi_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIncideIpi.HasValue && this._valueDevolucaoMaterialIncideIpi.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIncideIpi_Incide
         { 
            get { return this._valueDevolucaoMaterialIncideIpi.HasValue && this._valueDevolucaoMaterialIncideIpi.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIncideIpi_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIncideIpi.HasValue && this._valueDevolucaoMaterialIncideIpi.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIncideIpi = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto? _devolucaoMaterialIncidePisOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIncidePisOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIncidePis;
         [Column("ope_devolucao_material_incide_pis")]
        public virtual IncidenciaImposto? DevolucaoMaterialIncidePis
         { 
            get { return this._valueDevolucaoMaterialIncidePis; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIncidePis == value)return;
                 this._valueDevolucaoMaterialIncidePis = value; 
            } 
        } 

        public bool DevolucaoMaterialIncidePis_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIncidePis.HasValue && this._valueDevolucaoMaterialIncidePis.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIncidePis_Incide
         { 
            get { return this._valueDevolucaoMaterialIncidePis.HasValue && this._valueDevolucaoMaterialIncidePis.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIncidePis_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIncidePis.HasValue && this._valueDevolucaoMaterialIncidePis.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIncidePis = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto? _devolucaoMaterialIncideCofinsOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIncideCofinsOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIncideCofins;
         [Column("ope_devolucao_material_incide_cofins")]
        public virtual IncidenciaImposto? DevolucaoMaterialIncideCofins
         { 
            get { return this._valueDevolucaoMaterialIncideCofins; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIncideCofins == value)return;
                 this._valueDevolucaoMaterialIncideCofins = value; 
            } 
        } 

        public bool DevolucaoMaterialIncideCofins_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIncideCofins.HasValue && this._valueDevolucaoMaterialIncideCofins.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIncideCofins_Incide
         { 
            get { return this._valueDevolucaoMaterialIncideCofins.HasValue && this._valueDevolucaoMaterialIncideCofins.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIncideCofins_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIncideCofins.HasValue && this._valueDevolucaoMaterialIncideCofins.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIncideCofins = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected IncidenciaImposto? _devolucaoMaterialIncideIssOriginal{get;private set;}
       private IncidenciaImposto? _devolucaoMaterialIncideIssOriginalCommited{get; set;}
        private IncidenciaImposto? _valueDevolucaoMaterialIncideIss;
         [Column("ope_devolucao_material_incide_iss")]
        public virtual IncidenciaImposto? DevolucaoMaterialIncideIss
         { 
            get { return this._valueDevolucaoMaterialIncideIss; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIncideIss == value)return;
                 this._valueDevolucaoMaterialIncideIss = value; 
            } 
        } 

        public bool DevolucaoMaterialIncideIss_NaoIncide
         { 
            get { return this._valueDevolucaoMaterialIncideIss.HasValue && this._valueDevolucaoMaterialIncideIss.Value == BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.NaoIncide; }
         } 

        public bool DevolucaoMaterialIncideIss_Incide
         { 
            get { return this._valueDevolucaoMaterialIncideIss.HasValue && this._valueDevolucaoMaterialIncideIss.Value == BibliotecaEntidades.Base.IncidenciaImposto.Incide; } 
            set { if (value) this._valueDevolucaoMaterialIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.Incide; }
         } 

        public bool DevolucaoMaterialIncideIss_Suspenso
         { 
            get { return this._valueDevolucaoMaterialIncideIss.HasValue && this._valueDevolucaoMaterialIncideIss.Value == BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; } 
            set { if (value) this._valueDevolucaoMaterialIncideIss = BibliotecaEntidades.Base.IncidenciaImposto.Suspenso; }
         } 

       protected string _devolucaoMaterialIcmsCstSuspensoOriginal{get;private set;}
       private string _devolucaoMaterialIcmsCstSuspensoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIcmsCstSuspenso;
         [Column("ope_devolucao_material_icms_cst_suspenso")]
        public virtual string DevolucaoMaterialIcmsCstSuspenso
         { 
            get { return this._valueDevolucaoMaterialIcmsCstSuspenso; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIcmsCstSuspenso == value)return;
                 this._valueDevolucaoMaterialIcmsCstSuspenso = value; 
            } 
        } 

       protected string _devolucaoMaterialIpiCstSuspensoOriginal{get;private set;}
       private string _devolucaoMaterialIpiCstSuspensoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialIpiCstSuspenso;
         [Column("ope_devolucao_material_ipi_cst_suspenso")]
        public virtual string DevolucaoMaterialIpiCstSuspenso
         { 
            get { return this._valueDevolucaoMaterialIpiCstSuspenso; } 
            set 
            { 
                if (this._valueDevolucaoMaterialIpiCstSuspenso == value)return;
                 this._valueDevolucaoMaterialIpiCstSuspenso = value; 
            } 
        } 

       protected string _devolucaoMaterialPisCstSuspensoOriginal{get;private set;}
       private string _devolucaoMaterialPisCstSuspensoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialPisCstSuspenso;
         [Column("ope_devolucao_material_pis_cst_suspenso")]
        public virtual string DevolucaoMaterialPisCstSuspenso
         { 
            get { return this._valueDevolucaoMaterialPisCstSuspenso; } 
            set 
            { 
                if (this._valueDevolucaoMaterialPisCstSuspenso == value)return;
                 this._valueDevolucaoMaterialPisCstSuspenso = value; 
            } 
        } 

       protected string _devolucaoMaterialCofinsCstSuspensoOriginal{get;private set;}
       private string _devolucaoMaterialCofinsCstSuspensoOriginalCommited{get; set;}
        private string _valueDevolucaoMaterialCofinsCstSuspenso;
         [Column("ope_devolucao_material_cofins_cst_suspenso")]
        public virtual string DevolucaoMaterialCofinsCstSuspenso
         { 
            get { return this._valueDevolucaoMaterialCofinsCstSuspenso; } 
            set 
            { 
                if (this._valueDevolucaoMaterialCofinsCstSuspenso == value)return;
                 this._valueDevolucaoMaterialCofinsCstSuspenso = value; 
            } 
        } 

       protected bool _consumidorFinalOriginal{get;private set;}
       private bool _consumidorFinalOriginalCommited{get; set;}
        private bool _valueConsumidorFinal;
         [Column("ope_consumidor_final")]
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
         [Column("ope_presenca_consumidor")]
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
         [Column("ope_gerar_contas_receber")]
        public virtual bool GerarContasReceber
         { 
            get { return this._valueGerarContasReceber; } 
            set 
            { 
                if (this._valueGerarContasReceber == value)return;
                 this._valueGerarContasReceber = value; 
            } 
        } 

       protected bool _entregaFuturaOriginal{get;private set;}
       private bool _entregaFuturaOriginalCommited{get; set;}
        private bool _valueEntregaFutura;
         [Column("ope_entrega_futura")]
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
         [Column("ope_entrega_futura_cfop_remessa")]
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
         [Column("ope_entrega_futura_cfop_remessa_fora_estado")]
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
         [Column("ope_entrega_futura_natureza_operacao_remessa")]
        public virtual string EntregaFuturaNaturezaOperacaoRemessa
         { 
            get { return this._valueEntregaFuturaNaturezaOperacaoRemessa; } 
            set 
            { 
                if (this._valueEntregaFuturaNaturezaOperacaoRemessa == value)return;
                 this._valueEntregaFuturaNaturezaOperacaoRemessa = value; 
            } 
        } 

       protected bool _partilhaIcmsOriginal{get;private set;}
       private bool _partilhaIcmsOriginalCommited{get; set;}
        private bool _valuePartilhaIcms;
         [Column("ope_partilha_icms")]
        public virtual bool PartilhaIcms
         { 
            get { return this._valuePartilhaIcms; } 
            set 
            { 
                if (this._valuePartilhaIcms == value)return;
                 this._valuePartilhaIcms = value; 
            } 
        } 

       protected bool _somaFreteBcIcmsOriginal{get;private set;}
       private bool _somaFreteBcIcmsOriginalCommited{get; set;}
        private bool _valueSomaFreteBcIcms;
         [Column("ope_soma_frete_bc_icms")]
        public virtual bool SomaFreteBcIcms
         { 
            get { return this._valueSomaFreteBcIcms; } 
            set 
            { 
                if (this._valueSomaFreteBcIcms == value)return;
                 this._valueSomaFreteBcIcms = value; 
            } 
        } 

       protected bool _somaFreteBcIpiOriginal{get;private set;}
       private bool _somaFreteBcIpiOriginalCommited{get; set;}
        private bool _valueSomaFreteBcIpi;
         [Column("ope_soma_frete_bc_ipi")]
        public virtual bool SomaFreteBcIpi
         { 
            get { return this._valueSomaFreteBcIpi; } 
            set 
            { 
                if (this._valueSomaFreteBcIpi == value)return;
                 this._valueSomaFreteBcIpi = value; 
            } 
        } 

       protected bool _devolucaoMaterialSeparadaOriginal{get;private set;}
       private bool _devolucaoMaterialSeparadaOriginalCommited{get; set;}
        private bool _valueDevolucaoMaterialSeparada;
         [Column("ope_devolucao_material_separada")]
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
         [Column("ope_devolucao_material_separada_natueza_operacao")]
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
         [Column("ope_pis_descontar_icms_bc")]
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
         [Column("ope_cofins_descontar_icms_bc")]
        public virtual bool CofinsDescontarIcmsBc
         { 
            get { return this._valueCofinsDescontarIcmsBc; } 
            set 
            { 
                if (this._valueCofinsDescontarIcmsBc == value)return;
                 this._valueCofinsDescontarIcmsBc = value; 
            } 
        } 

       private List<long> _collectionOrcamentoItemClassOperacaoOriginal;
       private List<Entidades.OrcamentoItemClass > _collectionOrcamentoItemClassOperacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOperacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOperacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrcamentoItemClassOperacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrcamentoItemClass> _valueCollectionOrcamentoItemClassOperacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrcamentoItemClass> CollectionOrcamentoItemClassOperacao 
       { 
           get { if(!_valueCollectionOrcamentoItemClassOperacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrcamentoItemClassOperacao();}
return this._valueCollectionOrcamentoItemClassOperacao; } 
           set 
           { 
               this._valueCollectionOrcamentoItemClassOperacao = value; 
               this._valueCollectionOrcamentoItemClassOperacaoLoaded = true; 
           } 
       } 

       private List<long> _collectionOrdemProducaoEnvioTerceirosClassOperacaoOriginal;
       private List<Entidades.OrdemProducaoEnvioTerceirosClass > _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> _valueCollectionOrdemProducaoEnvioTerceirosClassOperacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.OrdemProducaoEnvioTerceirosClass> CollectionOrdemProducaoEnvioTerceirosClassOperacao 
       { 
           get { if(!_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionOrdemProducaoEnvioTerceirosClassOperacao();}
return this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacao; } 
           set 
           { 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacao = value; 
               this._valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassOperacaoOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassOperacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassOperacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassOperacao 
       { 
           get { if(!_valueCollectionPedidoItemClassOperacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassOperacao();}
return this._valueCollectionPedidoItemClassOperacao; } 
           set 
           { 
               this._valueCollectionPedidoItemClassOperacao = value; 
               this._valueCollectionPedidoItemClassOperacaoLoaded = true; 
           } 
       } 

       private List<long> _collectionPedidoItemClassOperacaoEnvioTerceirosOriginal;
       private List<Entidades.PedidoItemClass > _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PedidoItemClass> _valueCollectionPedidoItemClassOperacaoEnvioTerceiros { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PedidoItemClass> CollectionPedidoItemClassOperacaoEnvioTerceiros 
       { 
           get { if(!_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded && !this.DisableLoadCollection){this.LoadCollectionPedidoItemClassOperacaoEnvioTerceiros();}
return this._valueCollectionPedidoItemClassOperacaoEnvioTerceiros; } 
           set 
           { 
               this._valueCollectionPedidoItemClassOperacaoEnvioTerceiros = value; 
               this._valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded = true; 
           } 
       } 

       private List<long> _collectionPostoTrabalhoClassOperacaoOriginal;
       private List<Entidades.PostoTrabalhoClass > _collectionPostoTrabalhoClassOperacaoRemovidos;
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoLoaded { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetFalse)] 
       protected bool _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged { get; private set;} 
       [UnCloneable(UnCloneableAttributeType.RetNull)] 
       protected BindingList<Entidades.PostoTrabalhoClass> _valueCollectionPostoTrabalhoClassOperacao { get; set;} 
       [UnCloneable(UnCloneableAttributeType.RetPadrao)] 
       public BindingList<Entidades.PostoTrabalhoClass> CollectionPostoTrabalhoClassOperacao 
       { 
           get { if(!_valueCollectionPostoTrabalhoClassOperacaoLoaded && !this.DisableLoadCollection){this.LoadCollectionPostoTrabalhoClassOperacao();}
return this._valueCollectionPostoTrabalhoClassOperacao; } 
           set 
           { 
               this._valueCollectionPostoTrabalhoClassOperacao = value; 
               this._valueCollectionPostoTrabalhoClassOperacaoLoaded = true; 
           } 
       } 

        public OperacaoBaseClass(AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection singleConnection)
            : base(usuarioAtual, singleConnection)
        {
           ControleRevisaoHabilitado = false;
           InitDefaults();
        }

        protected void InitDefaults()
        {
            base.SalvarValoresAntigosHabilitado = false;
            this.IncideIcms = (IncidenciaImposto)1;
           this.IncideIpi = (IncidenciaImposto)0;
           this.IncidePis = (IncidenciaImposto)1;
           this.IncideCofins = (IncidenciaImposto)1;
           this.IncideIss = (IncidenciaImposto)0;
           this.ValidaPrecos = (EasiValidaPrecos)1;
           this.DevolucaoMaterial = false;
           this.ConsumidorFinal = false;
           this.PresencaConsumidor = (PresencaComprador)9;
           this.GerarContasReceber = true;
           this.EntregaFutura = false;
           this.PartilhaIcms = false;
           this.SomaFreteBcIcms = false;
           this.SomaFreteBcIpi = false;
           this.DevolucaoMaterialSeparada = false;
           this.PisDescontarIcmsBc = false;
           this.CofinsDescontarIcmsBc = false;
            base.SalvarValoresAntigosHabilitado = true;
         }

public static OperacaoClass GetEntidade(long id, AcsUsuarioClass usuarioAtual, IWTPostgreNpgsqlConnection connection, Guid? operacao = null)
        {
            return (OperacaoClass) GetEntity(typeof(OperacaoClass),id,usuarioAtual,connection, operacao);
        }
        private void CollectionOrcamentoItemClassOperacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrcamentoItemClassOperacaoChanged = true;
                  _valueCollectionOrcamentoItemClassOperacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrcamentoItemClassOperacaoChanged = true; 
                  _valueCollectionOrcamentoItemClassOperacaoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in e.OldItems) 
                 { 
                     _collectionOrcamentoItemClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrcamentoItemClassOperacaoChanged = true; 
                  _valueCollectionOrcamentoItemClassOperacaoCommitedChanged = true;
                 foreach (Entidades.OrcamentoItemClass item in _valueCollectionOrcamentoItemClassOperacao) 
                 { 
                     _collectionOrcamentoItemClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrcamentoItemClassOperacao()
         {
            try
            {
                 ObservableCollection<Entidades.OrcamentoItemClass> oc;
                _valueCollectionOrcamentoItemClassOperacaoChanged = false;
                 _valueCollectionOrcamentoItemClassOperacaoCommitedChanged = false;
                _collectionOrcamentoItemClassOperacaoRemovidos = new List<Entidades.OrcamentoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrcamentoItemClass>();
                }
                else{ 
                   Entidades.OrcamentoItemClass search = new Entidades.OrcamentoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrcamentoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Operacao", this),                     }                       ).Cast<Entidades.OrcamentoItemClass>().ToList());
                 }
                 _valueCollectionOrcamentoItemClassOperacao = new BindingList<Entidades.OrcamentoItemClass>(oc); 
                 _collectionOrcamentoItemClassOperacaoOriginal= (from a in _valueCollectionOrcamentoItemClassOperacao select a.ID).ToList();
                 _valueCollectionOrcamentoItemClassOperacaoLoaded = true;
                 oc.CollectionChanged += CollectionOrcamentoItemClassOperacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrcamentoItemClassOperacao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionOrdemProducaoEnvioTerceirosClassOperacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged = true;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in e.OldItems) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged = true; 
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged = true;
                 foreach (Entidades.OrdemProducaoEnvioTerceirosClass item in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacao) 
                 { 
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionOrdemProducaoEnvioTerceirosClassOperacao()
         {
            try
            {
                 ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass> oc;
                _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged = false;
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged = false;
                _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>();
                }
                else{ 
                   Entidades.OrdemProducaoEnvioTerceirosClass search = new Entidades.OrdemProducaoEnvioTerceirosClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.OrdemProducaoEnvioTerceirosClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Operacao", this),                     }                       ).Cast<Entidades.OrdemProducaoEnvioTerceirosClass>().ToList());
                 }
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacao = new BindingList<Entidades.OrdemProducaoEnvioTerceirosClass>(oc); 
                 _collectionOrdemProducaoEnvioTerceirosClassOperacaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacao select a.ID).ToList();
                 _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded = true;
                 oc.CollectionChanged += CollectionOrdemProducaoEnvioTerceirosClassOperacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionOrdemProducaoEnvioTerceirosClassOperacao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassOperacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassOperacaoChanged = true;
                  _valueCollectionPedidoItemClassOperacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassOperacaoChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassOperacaoChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassOperacao) 
                 { 
                     _collectionPedidoItemClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassOperacao()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassOperacaoChanged = false;
                 _valueCollectionPedidoItemClassOperacaoCommitedChanged = false;
                _collectionPedidoItemClassOperacaoRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Operacao", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassOperacao = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassOperacaoOriginal= (from a in _valueCollectionPedidoItemClassOperacao select a.ID).ToList();
                 _valueCollectionPedidoItemClassOperacaoLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassOperacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassOperacao+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPedidoItemClassOperacaoEnvioTerceirosChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged = true;
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in e.OldItems) 
                 { 
                     _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged = true; 
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged = true;
                 foreach (Entidades.PedidoItemClass item in _valueCollectionPedidoItemClassOperacaoEnvioTerceiros) 
                 { 
                     _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPedidoItemClassOperacaoEnvioTerceiros()
         {
            try
            {
                 ObservableCollection<Entidades.PedidoItemClass> oc;
                _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged = false;
                 _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged = false;
                _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PedidoItemClass>();
                }
                else{ 
                   Entidades.PedidoItemClass search = new Entidades.PedidoItemClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PedidoItemClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("OperacaoEnvioTerceiros", this),                     }                       ).Cast<Entidades.PedidoItemClass>().ToList());
                 }
                 _valueCollectionPedidoItemClassOperacaoEnvioTerceiros = new BindingList<Entidades.PedidoItemClass>(oc); 
                 _collectionPedidoItemClassOperacaoEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassOperacaoEnvioTerceiros select a.ID).ToList();
                 _valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded = true;
                 oc.CollectionChanged += CollectionPedidoItemClassOperacaoEnvioTerceirosChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPedidoItemClassOperacaoEnvioTerceiros+"\r\n" + e.Message, e);
            }
         } 
        private void CollectionPostoTrabalhoClassOperacaoChangedEvent(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
           if (DisableEventosRemocaoVetores) return;
           switch (e.Action) 
           { 
             case NotifyCollectionChangedAction.Add: 
                  _valueCollectionPostoTrabalhoClassOperacaoChanged = true;
                  _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged = true;
                 break; 
             case NotifyCollectionChangedAction.Remove: 
             case NotifyCollectionChangedAction.Replace: 
             case NotifyCollectionChangedAction.Move: 
                  _valueCollectionPostoTrabalhoClassOperacaoChanged = true; 
                  _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in e.OldItems) 
                 { 
                     _collectionPostoTrabalhoClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             case NotifyCollectionChangedAction.Reset: 
                  _valueCollectionPostoTrabalhoClassOperacaoChanged = true; 
                  _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged = true;
                 foreach (Entidades.PostoTrabalhoClass item in _valueCollectionPostoTrabalhoClassOperacao) 
                 { 
                     _collectionPostoTrabalhoClassOperacaoRemovidos.Add(item); 
                 } 
                 break; 
             default: 
                 throw new ArgumentOutOfRangeException(); 
           } 
         }
         protected void LoadCollectionPostoTrabalhoClassOperacao()
         {
            try
            {
                 ObservableCollection<Entidades.PostoTrabalhoClass> oc;
                _valueCollectionPostoTrabalhoClassOperacaoChanged = false;
                 _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged = false;
                _collectionPostoTrabalhoClassOperacaoRemovidos = new List<Entidades.PostoTrabalhoClass>();
                if (this.ID == -1) 
                {
                     oc = new ObservableCollection<Entidades.PostoTrabalhoClass>();
                }
                else{ 
                   Entidades.PostoTrabalhoClass search = new Entidades.PostoTrabalhoClass(this.UsuarioAtual, SingleConnection);
                   search.BufferSecundario = this.BufferSecundario; 
                    oc = 
                      new ObservableCollection<Entidades.PostoTrabalhoClass>(                        search.Search(new List<SearchParameterClass>() {                            new SearchParameterClass("Operacao", this),                     }                       ).Cast<Entidades.PostoTrabalhoClass>().ToList());
                 }
                 _valueCollectionPostoTrabalhoClassOperacao = new BindingList<Entidades.PostoTrabalhoClass>(oc); 
                 _collectionPostoTrabalhoClassOperacaoOriginal= (from a in _valueCollectionPostoTrabalhoClassOperacao select a.ID).ToList();
                 _valueCollectionPostoTrabalhoClassOperacaoLoaded = true;
                 oc.CollectionChanged += CollectionPostoTrabalhoClassOperacaoChangedEvent; 
            }
            catch (Exception e)
            {
                throw new Exception(ErroCollectionPostoTrabalhoClassOperacao+"\r\n" + e.Message, e);
            }
         } 
        public override bool ValidateData(ref IWTPostgreNpgsqlCommand command)
        {
            try
            {
                if (string.IsNullOrEmpty(Descricao))
                {
                    throw new Exception(ErroDescricaoObrigatorio);
                }
                if (Descricao.Length >255)
                {
                    throw new Exception( ErroDescricaoComprimento);
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
                    "  public.operacao  " +
                    "WHERE " +
                    "  id_operacao = :id";
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
                        "  public.operacao   " +
                        "SET  " + 
                        "  ope_descricao = :ope_descricao, " + 
                        "  ope_cfop = :ope_cfop, " + 
                        "  ope_natureza_operacao = :ope_natureza_operacao, " + 
                        "  ope_incide_icms = :ope_incide_icms, " + 
                        "  ope_incide_ipi = :ope_incide_ipi, " + 
                        "  ope_incide_pis = :ope_incide_pis, " + 
                        "  ope_incide_cofins = :ope_incide_cofins, " + 
                        "  ope_incide_iss = :ope_incide_iss, " + 
                        "  ope_valida_precos = :ope_valida_precos, " + 
                        "  ope_cfop_fora_estado = :ope_cfop_fora_estado, " + 
                        "  ope_icms_cst_suspenso = :ope_icms_cst_suspenso, " + 
                        "  ope_ipi_cst_suspenso = :ope_ipi_cst_suspenso, " + 
                        "  ope_pis_cst_suspenso = :ope_pis_cst_suspenso, " + 
                        "  ope_cofins_cst_suspenso = :ope_cofins_cst_suspenso, " + 
                        "  ope_devolucao_material = :ope_devolucao_material, " + 
                        "  ope_devolucao_material_cfop = :ope_devolucao_material_cfop, " + 
                        "  ope_devolucao_material_cfop_fora_estado = :ope_devolucao_material_cfop_fora_estado, " + 
                        "  ope_devolucao_material_incide_icms = :ope_devolucao_material_incide_icms, " + 
                        "  ope_devolucao_material_incide_ipi = :ope_devolucao_material_incide_ipi, " + 
                        "  ope_devolucao_material_incide_pis = :ope_devolucao_material_incide_pis, " + 
                        "  ope_devolucao_material_incide_cofins = :ope_devolucao_material_incide_cofins, " + 
                        "  ope_devolucao_material_incide_iss = :ope_devolucao_material_incide_iss, " + 
                        "  ope_devolucao_material_icms_cst_suspenso = :ope_devolucao_material_icms_cst_suspenso, " + 
                        "  ope_devolucao_material_ipi_cst_suspenso = :ope_devolucao_material_ipi_cst_suspenso, " + 
                        "  ope_devolucao_material_pis_cst_suspenso = :ope_devolucao_material_pis_cst_suspenso, " + 
                        "  ope_devolucao_material_cofins_cst_suspenso = :ope_devolucao_material_cofins_cst_suspenso, " + 
                        "  entity_uid = :entity_uid, " + 
                        "  version = :version, " + 
                        "  ope_consumidor_final = :ope_consumidor_final, " + 
                        "  ope_presenca_consumidor = :ope_presenca_consumidor, " + 
                        "  ope_gerar_contas_receber = :ope_gerar_contas_receber, " + 
                        "  ope_entrega_futura = :ope_entrega_futura, " + 
                        "  ope_entrega_futura_cfop_remessa = :ope_entrega_futura_cfop_remessa, " + 
                        "  ope_entrega_futura_cfop_remessa_fora_estado = :ope_entrega_futura_cfop_remessa_fora_estado, " + 
                        "  ope_entrega_futura_natureza_operacao_remessa = :ope_entrega_futura_natureza_operacao_remessa, " + 
                        "  ope_partilha_icms = :ope_partilha_icms, " + 
                        "  ope_soma_frete_bc_icms = :ope_soma_frete_bc_icms, " + 
                        "  ope_soma_frete_bc_ipi = :ope_soma_frete_bc_ipi, " + 
                        "  ope_devolucao_material_separada = :ope_devolucao_material_separada, " + 
                        "  ope_devolucao_material_separada_natueza_operacao = :ope_devolucao_material_separada_natueza_operacao, " + 
                        "  ope_pis_descontar_icms_bc = :ope_pis_descontar_icms_bc, " + 
                        "  ope_cofins_descontar_icms_bc = :ope_cofins_descontar_icms_bc "+
                        "WHERE  " +
                        "  id_operacao = :id " +
                        "RETURNING id_operacao;";
                }
                else
                {
                    command.CommandText =
                        "INSERT INTO " +
                        "public.operacao " +
                        "( " +
                        "  ope_descricao , " + 
                        "  ope_cfop , " + 
                        "  ope_natureza_operacao , " + 
                        "  ope_incide_icms , " + 
                        "  ope_incide_ipi , " + 
                        "  ope_incide_pis , " + 
                        "  ope_incide_cofins , " + 
                        "  ope_incide_iss , " + 
                        "  ope_valida_precos , " + 
                        "  ope_cfop_fora_estado , " + 
                        "  ope_icms_cst_suspenso , " + 
                        "  ope_ipi_cst_suspenso , " + 
                        "  ope_pis_cst_suspenso , " + 
                        "  ope_cofins_cst_suspenso , " + 
                        "  ope_devolucao_material , " + 
                        "  ope_devolucao_material_cfop , " + 
                        "  ope_devolucao_material_cfop_fora_estado , " + 
                        "  ope_devolucao_material_incide_icms , " + 
                        "  ope_devolucao_material_incide_ipi , " + 
                        "  ope_devolucao_material_incide_pis , " + 
                        "  ope_devolucao_material_incide_cofins , " + 
                        "  ope_devolucao_material_incide_iss , " + 
                        "  ope_devolucao_material_icms_cst_suspenso , " + 
                        "  ope_devolucao_material_ipi_cst_suspenso , " + 
                        "  ope_devolucao_material_pis_cst_suspenso , " + 
                        "  ope_devolucao_material_cofins_cst_suspenso , " + 
                        "  entity_uid , " + 
                        "  version , " + 
                        "  ope_consumidor_final , " + 
                        "  ope_presenca_consumidor , " + 
                        "  ope_gerar_contas_receber , " + 
                        "  ope_entrega_futura , " + 
                        "  ope_entrega_futura_cfop_remessa , " + 
                        "  ope_entrega_futura_cfop_remessa_fora_estado , " + 
                        "  ope_entrega_futura_natureza_operacao_remessa , " + 
                        "  ope_partilha_icms , " + 
                        "  ope_soma_frete_bc_icms , " + 
                        "  ope_soma_frete_bc_ipi , " + 
                        "  ope_devolucao_material_separada , " + 
                        "  ope_devolucao_material_separada_natueza_operacao , " + 
                        "  ope_pis_descontar_icms_bc , " + 
                        "  ope_cofins_descontar_icms_bc  "+
                        ")  " +
                        "VALUES ( " +
                        "  :ope_descricao , " + 
                        "  :ope_cfop , " + 
                        "  :ope_natureza_operacao , " + 
                        "  :ope_incide_icms , " + 
                        "  :ope_incide_ipi , " + 
                        "  :ope_incide_pis , " + 
                        "  :ope_incide_cofins , " + 
                        "  :ope_incide_iss , " + 
                        "  :ope_valida_precos , " + 
                        "  :ope_cfop_fora_estado , " + 
                        "  :ope_icms_cst_suspenso , " + 
                        "  :ope_ipi_cst_suspenso , " + 
                        "  :ope_pis_cst_suspenso , " + 
                        "  :ope_cofins_cst_suspenso , " + 
                        "  :ope_devolucao_material , " + 
                        "  :ope_devolucao_material_cfop , " + 
                        "  :ope_devolucao_material_cfop_fora_estado , " + 
                        "  :ope_devolucao_material_incide_icms , " + 
                        "  :ope_devolucao_material_incide_ipi , " + 
                        "  :ope_devolucao_material_incide_pis , " + 
                        "  :ope_devolucao_material_incide_cofins , " + 
                        "  :ope_devolucao_material_incide_iss , " + 
                        "  :ope_devolucao_material_icms_cst_suspenso , " + 
                        "  :ope_devolucao_material_ipi_cst_suspenso , " + 
                        "  :ope_devolucao_material_pis_cst_suspenso , " + 
                        "  :ope_devolucao_material_cofins_cst_suspenso , " + 
                        "  :entity_uid , " + 
                        "  :version , " + 
                        "  :ope_consumidor_final , " + 
                        "  :ope_presenca_consumidor , " + 
                        "  :ope_gerar_contas_receber , " + 
                        "  :ope_entrega_futura , " + 
                        "  :ope_entrega_futura_cfop_remessa , " + 
                        "  :ope_entrega_futura_cfop_remessa_fora_estado , " + 
                        "  :ope_entrega_futura_natureza_operacao_remessa , " + 
                        "  :ope_partilha_icms , " + 
                        "  :ope_soma_frete_bc_icms , " + 
                        "  :ope_soma_frete_bc_ipi , " + 
                        "  :ope_devolucao_material_separada , " + 
                        "  :ope_devolucao_material_separada_natueza_operacao , " + 
                        "  :ope_pis_descontar_icms_bc , " + 
                        "  :ope_cofins_descontar_icms_bc  "+
                        ")RETURNING id_operacao;";
                }

                command.Parameters.Clear();
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("id", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = this.ID;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_descricao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Descricao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Cfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_natureza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.NaturezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_incide_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IncideIcms);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_incide_ipi", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IncideIpi);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_incide_pis", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IncidePis);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_incide_cofins", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IncideCofins);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_incide_iss", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.IncideIss);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_valida_precos", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.ValidaPrecos);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_cfop_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CfopForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_icms_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IcmsCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_ipi_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.IpiCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_pis_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_cofins_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.CofinsCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterial ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_cfop", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCfop ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_cfop_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCfopForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_incide_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIncideIcms.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIncideIcms) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_incide_ipi", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIncideIpi.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIncideIpi) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_incide_pis", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIncidePis.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIncidePis) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_incide_cofins", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIncideCofins.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIncideCofins) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_incide_iss", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = this.DevolucaoMaterialIncideIss.HasValue ? (object)Convert.ToInt16(this.DevolucaoMaterialIncideIss) : (object)DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_icms_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIcmsCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_ipi_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialIpiCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_pis_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialPisCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_cofins_cst_suspenso", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialCofinsCstSuspenso ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("entity_uid", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntityUid ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("version", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.Version ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_consumidor_final", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.ConsumidorFinal ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_presenca_consumidor", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = Convert.ToInt16(this.PresencaConsumidor);
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_gerar_contas_receber", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.GerarContasReceber ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_entrega_futura", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFutura ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_entrega_futura_cfop_remessa", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaCfopRemessa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_entrega_futura_cfop_remessa_fora_estado", NpgsqlDbType.Integer));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaCfopRemessaForaEstado ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_entrega_futura_natureza_operacao_remessa", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.EntregaFuturaNaturezaOperacaoRemessa ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_partilha_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PartilhaIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_soma_frete_bc_icms", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SomaFreteBcIcms ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_soma_frete_bc_ipi", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.SomaFreteBcIpi ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_separada", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialSeparada ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_devolucao_material_separada_natueza_operacao", NpgsqlDbType.Varchar));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.DevolucaoMaterialSeparadaNatuezaOperacao ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_pis_descontar_icms_bc", NpgsqlDbType.Smallint));
                command.Parameters[command.Parameters.Count - 1].Value = (object)this.PisDescontarIcmsBc ?? DBNull.Value;
                command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("ope_cofins_descontar_icms_bc", NpgsqlDbType.Smallint));
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
 if (CollectionOrcamentoItemClassOperacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrcamentoItemClassOperacao+"\r\n";
                foreach (Entidades.OrcamentoItemClass tmp in CollectionOrcamentoItemClassOperacao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionOrdemProducaoEnvioTerceirosClassOperacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionOrdemProducaoEnvioTerceirosClassOperacao+"\r\n";
                foreach (Entidades.OrdemProducaoEnvioTerceirosClass tmp in CollectionOrdemProducaoEnvioTerceirosClassOperacao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassOperacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassOperacao+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassOperacao)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPedidoItemClassOperacaoEnvioTerceiros.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPedidoItemClassOperacaoEnvioTerceiros+"\r\n";
                foreach (Entidades.PedidoItemClass tmp in CollectionPedidoItemClassOperacaoEnvioTerceiros)
                {
                    mensagemUtilizado += tmp.ToString() + "\r\n";
                }
                return true;
            }
 if (CollectionPostoTrabalhoClassOperacao.Count > 0) 
            {
                mensagemUtilizado = MensagemUtilizadoCollectionPostoTrabalhoClassOperacao+"\r\n";
                foreach (Entidades.PostoTrabalhoClass tmp in CollectionPostoTrabalhoClassOperacao)
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
        public static OperacaoClass CopiarEntidade(OperacaoClass entidadeCopiar, AcsUsuarioClass usuario, IWTPostgreNpgsqlConnection conn)
        {
            try
            {
               OperacaoClass toRet = new OperacaoClass(usuario,conn);
 toRet.Descricao= entidadeCopiar.Descricao;
 toRet.Cfop= entidadeCopiar.Cfop;
 toRet.NaturezaOperacao= entidadeCopiar.NaturezaOperacao;
 toRet.IncideIcms= entidadeCopiar.IncideIcms;
 toRet.IncideIpi= entidadeCopiar.IncideIpi;
 toRet.IncidePis= entidadeCopiar.IncidePis;
 toRet.IncideCofins= entidadeCopiar.IncideCofins;
 toRet.IncideIss= entidadeCopiar.IncideIss;
 toRet.ValidaPrecos= entidadeCopiar.ValidaPrecos;
 toRet.CfopForaEstado= entidadeCopiar.CfopForaEstado;
 toRet.IcmsCstSuspenso= entidadeCopiar.IcmsCstSuspenso;
 toRet.IpiCstSuspenso= entidadeCopiar.IpiCstSuspenso;
 toRet.PisCstSuspenso= entidadeCopiar.PisCstSuspenso;
 toRet.CofinsCstSuspenso= entidadeCopiar.CofinsCstSuspenso;
 toRet.DevolucaoMaterial= entidadeCopiar.DevolucaoMaterial;
 toRet.DevolucaoMaterialCfop= entidadeCopiar.DevolucaoMaterialCfop;
 toRet.DevolucaoMaterialCfopForaEstado= entidadeCopiar.DevolucaoMaterialCfopForaEstado;
 toRet.DevolucaoMaterialIncideIcms= entidadeCopiar.DevolucaoMaterialIncideIcms;
 toRet.DevolucaoMaterialIncideIpi= entidadeCopiar.DevolucaoMaterialIncideIpi;
 toRet.DevolucaoMaterialIncidePis= entidadeCopiar.DevolucaoMaterialIncidePis;
 toRet.DevolucaoMaterialIncideCofins= entidadeCopiar.DevolucaoMaterialIncideCofins;
 toRet.DevolucaoMaterialIncideIss= entidadeCopiar.DevolucaoMaterialIncideIss;
 toRet.DevolucaoMaterialIcmsCstSuspenso= entidadeCopiar.DevolucaoMaterialIcmsCstSuspenso;
 toRet.DevolucaoMaterialIpiCstSuspenso= entidadeCopiar.DevolucaoMaterialIpiCstSuspenso;
 toRet.DevolucaoMaterialPisCstSuspenso= entidadeCopiar.DevolucaoMaterialPisCstSuspenso;
 toRet.DevolucaoMaterialCofinsCstSuspenso= entidadeCopiar.DevolucaoMaterialCofinsCstSuspenso;
 toRet.ConsumidorFinal= entidadeCopiar.ConsumidorFinal;
 toRet.PresencaConsumidor= entidadeCopiar.PresencaConsumidor;
 toRet.GerarContasReceber= entidadeCopiar.GerarContasReceber;
 toRet.EntregaFutura= entidadeCopiar.EntregaFutura;
 toRet.EntregaFuturaCfopRemessa= entidadeCopiar.EntregaFuturaCfopRemessa;
 toRet.EntregaFuturaCfopRemessaForaEstado= entidadeCopiar.EntregaFuturaCfopRemessaForaEstado;
 toRet.EntregaFuturaNaturezaOperacaoRemessa= entidadeCopiar.EntregaFuturaNaturezaOperacaoRemessa;
 toRet.PartilhaIcms= entidadeCopiar.PartilhaIcms;
 toRet.SomaFreteBcIcms= entidadeCopiar.SomaFreteBcIcms;
 toRet.SomaFreteBcIpi= entidadeCopiar.SomaFreteBcIpi;
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
       _descricaoOriginal = Descricao;
       _descricaoOriginalCommited = _descricaoOriginal;
       _cfopOriginal = Cfop;
       _cfopOriginalCommited = _cfopOriginal;
       _naturezaOperacaoOriginal = NaturezaOperacao;
       _naturezaOperacaoOriginalCommited = _naturezaOperacaoOriginal;
       _incideIcmsOriginal = IncideIcms;
       _incideIcmsOriginalCommited = _incideIcmsOriginal;
       _incideIpiOriginal = IncideIpi;
       _incideIpiOriginalCommited = _incideIpiOriginal;
       _incidePisOriginal = IncidePis;
       _incidePisOriginalCommited = _incidePisOriginal;
       _incideCofinsOriginal = IncideCofins;
       _incideCofinsOriginalCommited = _incideCofinsOriginal;
       _incideIssOriginal = IncideIss;
       _incideIssOriginalCommited = _incideIssOriginal;
       _validaPrecosOriginal = ValidaPrecos;
       _validaPrecosOriginalCommited = _validaPrecosOriginal;
       _cfopForaEstadoOriginal = CfopForaEstado;
       _cfopForaEstadoOriginalCommited = _cfopForaEstadoOriginal;
       _icmsCstSuspensoOriginal = IcmsCstSuspenso;
       _icmsCstSuspensoOriginalCommited = _icmsCstSuspensoOriginal;
       _ipiCstSuspensoOriginal = IpiCstSuspenso;
       _ipiCstSuspensoOriginalCommited = _ipiCstSuspensoOriginal;
       _pisCstSuspensoOriginal = PisCstSuspenso;
       _pisCstSuspensoOriginalCommited = _pisCstSuspensoOriginal;
       _cofinsCstSuspensoOriginal = CofinsCstSuspenso;
       _cofinsCstSuspensoOriginalCommited = _cofinsCstSuspensoOriginal;
       _devolucaoMaterialOriginal = DevolucaoMaterial;
       _devolucaoMaterialOriginalCommited = _devolucaoMaterialOriginal;
       _devolucaoMaterialCfopOriginal = DevolucaoMaterialCfop;
       _devolucaoMaterialCfopOriginalCommited = _devolucaoMaterialCfopOriginal;
       _devolucaoMaterialCfopForaEstadoOriginal = DevolucaoMaterialCfopForaEstado;
       _devolucaoMaterialCfopForaEstadoOriginalCommited = _devolucaoMaterialCfopForaEstadoOriginal;
       _devolucaoMaterialIncideIcmsOriginal = DevolucaoMaterialIncideIcms;
       _devolucaoMaterialIncideIcmsOriginalCommited = _devolucaoMaterialIncideIcmsOriginal;
       _devolucaoMaterialIncideIpiOriginal = DevolucaoMaterialIncideIpi;
       _devolucaoMaterialIncideIpiOriginalCommited = _devolucaoMaterialIncideIpiOriginal;
       _devolucaoMaterialIncidePisOriginal = DevolucaoMaterialIncidePis;
       _devolucaoMaterialIncidePisOriginalCommited = _devolucaoMaterialIncidePisOriginal;
       _devolucaoMaterialIncideCofinsOriginal = DevolucaoMaterialIncideCofins;
       _devolucaoMaterialIncideCofinsOriginalCommited = _devolucaoMaterialIncideCofinsOriginal;
       _devolucaoMaterialIncideIssOriginal = DevolucaoMaterialIncideIss;
       _devolucaoMaterialIncideIssOriginalCommited = _devolucaoMaterialIncideIssOriginal;
       _devolucaoMaterialIcmsCstSuspensoOriginal = DevolucaoMaterialIcmsCstSuspenso;
       _devolucaoMaterialIcmsCstSuspensoOriginalCommited = _devolucaoMaterialIcmsCstSuspensoOriginal;
       _devolucaoMaterialIpiCstSuspensoOriginal = DevolucaoMaterialIpiCstSuspenso;
       _devolucaoMaterialIpiCstSuspensoOriginalCommited = _devolucaoMaterialIpiCstSuspensoOriginal;
       _devolucaoMaterialPisCstSuspensoOriginal = DevolucaoMaterialPisCstSuspenso;
       _devolucaoMaterialPisCstSuspensoOriginalCommited = _devolucaoMaterialPisCstSuspensoOriginal;
       _devolucaoMaterialCofinsCstSuspensoOriginal = DevolucaoMaterialCofinsCstSuspenso;
       _devolucaoMaterialCofinsCstSuspensoOriginalCommited = _devolucaoMaterialCofinsCstSuspensoOriginal;
       _versionOriginal = Version;
       _versionOriginalCommited = _versionOriginal ;
       _consumidorFinalOriginal = ConsumidorFinal;
       _consumidorFinalOriginalCommited = _consumidorFinalOriginal;
       _presencaConsumidorOriginal = PresencaConsumidor;
       _presencaConsumidorOriginalCommited = _presencaConsumidorOriginal;
       _gerarContasReceberOriginal = GerarContasReceber;
       _gerarContasReceberOriginalCommited = _gerarContasReceberOriginal;
       _entregaFuturaOriginal = EntregaFutura;
       _entregaFuturaOriginalCommited = _entregaFuturaOriginal;
       _entregaFuturaCfopRemessaOriginal = EntregaFuturaCfopRemessa;
       _entregaFuturaCfopRemessaOriginalCommited = _entregaFuturaCfopRemessaOriginal;
       _entregaFuturaCfopRemessaForaEstadoOriginal = EntregaFuturaCfopRemessaForaEstado;
       _entregaFuturaCfopRemessaForaEstadoOriginalCommited = _entregaFuturaCfopRemessaForaEstadoOriginal;
       _entregaFuturaNaturezaOperacaoRemessaOriginal = EntregaFuturaNaturezaOperacaoRemessa;
       _entregaFuturaNaturezaOperacaoRemessaOriginalCommited = _entregaFuturaNaturezaOperacaoRemessaOriginal;
       _partilhaIcmsOriginal = PartilhaIcms;
       _partilhaIcmsOriginalCommited = _partilhaIcmsOriginal;
       _somaFreteBcIcmsOriginal = SomaFreteBcIcms;
       _somaFreteBcIcmsOriginalCommited = _somaFreteBcIcmsOriginal;
       _somaFreteBcIpiOriginal = SomaFreteBcIpi;
       _somaFreteBcIpiOriginalCommited = _somaFreteBcIpiOriginal;
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
       _descricaoOriginalCommited = Descricao;
       _cfopOriginalCommited = Cfop;
       _naturezaOperacaoOriginalCommited = NaturezaOperacao;
       _incideIcmsOriginalCommited = IncideIcms;
       _incideIpiOriginalCommited = IncideIpi;
       _incidePisOriginalCommited = IncidePis;
       _incideCofinsOriginalCommited = IncideCofins;
       _incideIssOriginalCommited = IncideIss;
       _validaPrecosOriginalCommited = ValidaPrecos;
       _cfopForaEstadoOriginalCommited = CfopForaEstado;
       _icmsCstSuspensoOriginalCommited = IcmsCstSuspenso;
       _ipiCstSuspensoOriginalCommited = IpiCstSuspenso;
       _pisCstSuspensoOriginalCommited = PisCstSuspenso;
       _cofinsCstSuspensoOriginalCommited = CofinsCstSuspenso;
       _devolucaoMaterialOriginalCommited = DevolucaoMaterial;
       _devolucaoMaterialCfopOriginalCommited = DevolucaoMaterialCfop;
       _devolucaoMaterialCfopForaEstadoOriginalCommited = DevolucaoMaterialCfopForaEstado;
       _devolucaoMaterialIncideIcmsOriginalCommited = DevolucaoMaterialIncideIcms;
       _devolucaoMaterialIncideIpiOriginalCommited = DevolucaoMaterialIncideIpi;
       _devolucaoMaterialIncidePisOriginalCommited = DevolucaoMaterialIncidePis;
       _devolucaoMaterialIncideCofinsOriginalCommited = DevolucaoMaterialIncideCofins;
       _devolucaoMaterialIncideIssOriginalCommited = DevolucaoMaterialIncideIss;
       _devolucaoMaterialIcmsCstSuspensoOriginalCommited = DevolucaoMaterialIcmsCstSuspenso;
       _devolucaoMaterialIpiCstSuspensoOriginalCommited = DevolucaoMaterialIpiCstSuspenso;
       _devolucaoMaterialPisCstSuspensoOriginalCommited = DevolucaoMaterialPisCstSuspenso;
       _devolucaoMaterialCofinsCstSuspensoOriginalCommited = DevolucaoMaterialCofinsCstSuspenso;
       _versionOriginalCommited = Version;
       _consumidorFinalOriginalCommited = ConsumidorFinal;
       _presencaConsumidorOriginalCommited = PresencaConsumidor;
       _gerarContasReceberOriginalCommited = GerarContasReceber;
       _entregaFuturaOriginalCommited = EntregaFutura;
       _entregaFuturaCfopRemessaOriginalCommited = EntregaFuturaCfopRemessa;
       _entregaFuturaCfopRemessaForaEstadoOriginalCommited = EntregaFuturaCfopRemessaForaEstado;
       _entregaFuturaNaturezaOperacaoRemessaOriginalCommited = EntregaFuturaNaturezaOperacaoRemessa;
       _partilhaIcmsOriginalCommited = PartilhaIcms;
       _somaFreteBcIcmsOriginalCommited = SomaFreteBcIcms;
       _somaFreteBcIpiOriginalCommited = SomaFreteBcIpi;
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
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  if (_collectionOrcamentoItemClassOperacaoRemovidos != null) 
                  {
                     _collectionOrcamentoItemClassOperacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrcamentoItemClassOperacaoRemovidos = new List<Entidades.OrcamentoItemClass>();
                  }
                  _collectionOrcamentoItemClassOperacaoOriginal= (from a in _valueCollectionOrcamentoItemClassOperacao select a.ID).ToList();
                  _valueCollectionOrcamentoItemClassOperacaoChanged = false;
                  _valueCollectionOrcamentoItemClassOperacaoCommitedChanged = false;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  if (_collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos != null) 
                  {
                     _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos = new List<Entidades.OrdemProducaoEnvioTerceirosClass>();
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOperacaoOriginal= (from a in _valueCollectionOrdemProducaoEnvioTerceirosClassOperacao select a.ID).ToList();
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged = false;
                  _valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  if (_collectionPedidoItemClassOperacaoRemovidos != null) 
                  {
                     _collectionPedidoItemClassOperacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassOperacaoRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassOperacaoOriginal= (from a in _valueCollectionPedidoItemClassOperacao select a.ID).ToList();
                  _valueCollectionPedidoItemClassOperacaoChanged = false;
                  _valueCollectionPedidoItemClassOperacaoCommitedChanged = false;
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  if (_collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos != null) 
                  {
                     _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos = new List<Entidades.PedidoItemClass>();
                  }
                  _collectionPedidoItemClassOperacaoEnvioTerceirosOriginal= (from a in _valueCollectionPedidoItemClassOperacaoEnvioTerceiros select a.ID).ToList();
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged = false;
                  _valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged = false;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  if (_collectionPostoTrabalhoClassOperacaoRemovidos != null) 
                  {
                     _collectionPostoTrabalhoClassOperacaoRemovidos.Clear();
                  }
                  else 
                  {
                      _collectionPostoTrabalhoClassOperacaoRemovidos = new List<Entidades.PostoTrabalhoClass>();
                  }
                  _collectionPostoTrabalhoClassOperacaoOriginal= (from a in _valueCollectionPostoTrabalhoClassOperacao select a.ID).ToList();
                  _valueCollectionPostoTrabalhoClassOperacaoChanged = false;
                  _valueCollectionPostoTrabalhoClassOperacaoCommitedChanged = false;
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
               Descricao=_descricaoOriginal;
               _descricaoOriginalCommited=_descricaoOriginal;
               Cfop=_cfopOriginal;
               _cfopOriginalCommited=_cfopOriginal;
               NaturezaOperacao=_naturezaOperacaoOriginal;
               _naturezaOperacaoOriginalCommited=_naturezaOperacaoOriginal;
               IncideIcms=_incideIcmsOriginal;
               _incideIcmsOriginalCommited=_incideIcmsOriginal;
               IncideIpi=_incideIpiOriginal;
               _incideIpiOriginalCommited=_incideIpiOriginal;
               IncidePis=_incidePisOriginal;
               _incidePisOriginalCommited=_incidePisOriginal;
               IncideCofins=_incideCofinsOriginal;
               _incideCofinsOriginalCommited=_incideCofinsOriginal;
               IncideIss=_incideIssOriginal;
               _incideIssOriginalCommited=_incideIssOriginal;
               ValidaPrecos=_validaPrecosOriginal;
               _validaPrecosOriginalCommited=_validaPrecosOriginal;
               CfopForaEstado=_cfopForaEstadoOriginal;
               _cfopForaEstadoOriginalCommited=_cfopForaEstadoOriginal;
               IcmsCstSuspenso=_icmsCstSuspensoOriginal;
               _icmsCstSuspensoOriginalCommited=_icmsCstSuspensoOriginal;
               IpiCstSuspenso=_ipiCstSuspensoOriginal;
               _ipiCstSuspensoOriginalCommited=_ipiCstSuspensoOriginal;
               PisCstSuspenso=_pisCstSuspensoOriginal;
               _pisCstSuspensoOriginalCommited=_pisCstSuspensoOriginal;
               CofinsCstSuspenso=_cofinsCstSuspensoOriginal;
               _cofinsCstSuspensoOriginalCommited=_cofinsCstSuspensoOriginal;
               DevolucaoMaterial=_devolucaoMaterialOriginal;
               _devolucaoMaterialOriginalCommited=_devolucaoMaterialOriginal;
               DevolucaoMaterialCfop=_devolucaoMaterialCfopOriginal;
               _devolucaoMaterialCfopOriginalCommited=_devolucaoMaterialCfopOriginal;
               DevolucaoMaterialCfopForaEstado=_devolucaoMaterialCfopForaEstadoOriginal;
               _devolucaoMaterialCfopForaEstadoOriginalCommited=_devolucaoMaterialCfopForaEstadoOriginal;
               DevolucaoMaterialIncideIcms=_devolucaoMaterialIncideIcmsOriginal;
               _devolucaoMaterialIncideIcmsOriginalCommited=_devolucaoMaterialIncideIcmsOriginal;
               DevolucaoMaterialIncideIpi=_devolucaoMaterialIncideIpiOriginal;
               _devolucaoMaterialIncideIpiOriginalCommited=_devolucaoMaterialIncideIpiOriginal;
               DevolucaoMaterialIncidePis=_devolucaoMaterialIncidePisOriginal;
               _devolucaoMaterialIncidePisOriginalCommited=_devolucaoMaterialIncidePisOriginal;
               DevolucaoMaterialIncideCofins=_devolucaoMaterialIncideCofinsOriginal;
               _devolucaoMaterialIncideCofinsOriginalCommited=_devolucaoMaterialIncideCofinsOriginal;
               DevolucaoMaterialIncideIss=_devolucaoMaterialIncideIssOriginal;
               _devolucaoMaterialIncideIssOriginalCommited=_devolucaoMaterialIncideIssOriginal;
               DevolucaoMaterialIcmsCstSuspenso=_devolucaoMaterialIcmsCstSuspensoOriginal;
               _devolucaoMaterialIcmsCstSuspensoOriginalCommited=_devolucaoMaterialIcmsCstSuspensoOriginal;
               DevolucaoMaterialIpiCstSuspenso=_devolucaoMaterialIpiCstSuspensoOriginal;
               _devolucaoMaterialIpiCstSuspensoOriginalCommited=_devolucaoMaterialIpiCstSuspensoOriginal;
               DevolucaoMaterialPisCstSuspenso=_devolucaoMaterialPisCstSuspensoOriginal;
               _devolucaoMaterialPisCstSuspensoOriginalCommited=_devolucaoMaterialPisCstSuspensoOriginal;
               DevolucaoMaterialCofinsCstSuspenso=_devolucaoMaterialCofinsCstSuspensoOriginal;
               _devolucaoMaterialCofinsCstSuspensoOriginalCommited=_devolucaoMaterialCofinsCstSuspensoOriginal;
               Version=_versionOriginal;
               _versionOriginalCommited=_versionOriginal;
               ConsumidorFinal=_consumidorFinalOriginal;
               _consumidorFinalOriginalCommited=_consumidorFinalOriginal;
               PresencaConsumidor=_presencaConsumidorOriginal;
               _presencaConsumidorOriginalCommited=_presencaConsumidorOriginal;
               GerarContasReceber=_gerarContasReceberOriginal;
               _gerarContasReceberOriginalCommited=_gerarContasReceberOriginal;
               EntregaFutura=_entregaFuturaOriginal;
               _entregaFuturaOriginalCommited=_entregaFuturaOriginal;
               EntregaFuturaCfopRemessa=_entregaFuturaCfopRemessaOriginal;
               _entregaFuturaCfopRemessaOriginalCommited=_entregaFuturaCfopRemessaOriginal;
               EntregaFuturaCfopRemessaForaEstado=_entregaFuturaCfopRemessaForaEstadoOriginal;
               _entregaFuturaCfopRemessaForaEstadoOriginalCommited=_entregaFuturaCfopRemessaForaEstadoOriginal;
               EntregaFuturaNaturezaOperacaoRemessa=_entregaFuturaNaturezaOperacaoRemessaOriginal;
               _entregaFuturaNaturezaOperacaoRemessaOriginalCommited=_entregaFuturaNaturezaOperacaoRemessaOriginal;
               PartilhaIcms=_partilhaIcmsOriginal;
               _partilhaIcmsOriginalCommited=_partilhaIcmsOriginal;
               SomaFreteBcIcms=_somaFreteBcIcmsOriginal;
               _somaFreteBcIcmsOriginalCommited=_somaFreteBcIcmsOriginal;
               SomaFreteBcIpi=_somaFreteBcIpiOriginal;
               _somaFreteBcIpiOriginalCommited=_somaFreteBcIpiOriginal;
               DevolucaoMaterialSeparada=_devolucaoMaterialSeparadaOriginal;
               _devolucaoMaterialSeparadaOriginalCommited=_devolucaoMaterialSeparadaOriginal;
               DevolucaoMaterialSeparadaNatuezaOperacao=_devolucaoMaterialSeparadaNatuezaOperacaoOriginal;
               _devolucaoMaterialSeparadaNatuezaOperacaoOriginalCommited=_devolucaoMaterialSeparadaNatuezaOperacaoOriginal;
               PisDescontarIcmsBc=_pisDescontarIcmsBcOriginal;
               _pisDescontarIcmsBcOriginalCommited=_pisDescontarIcmsBcOriginal;
               CofinsDescontarIcmsBc=_cofinsDescontarIcmsBcOriginal;
               _cofinsDescontarIcmsBcOriginalCommited=_cofinsDescontarIcmsBcOriginal;
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  CollectionOrcamentoItemClassOperacao.Clear();
                  foreach(int item in _collectionOrcamentoItemClassOperacaoOriginal)
                  {
                    CollectionOrcamentoItemClassOperacao.Add(Entidades.OrcamentoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrcamentoItemClassOperacaoRemovidos.Clear();
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  CollectionOrdemProducaoEnvioTerceirosClassOperacao.Clear();
                  foreach(int item in _collectionOrdemProducaoEnvioTerceirosClassOperacaoOriginal)
                  {
                    CollectionOrdemProducaoEnvioTerceirosClassOperacao.Add(Entidades.OrdemProducaoEnvioTerceirosClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionOrdemProducaoEnvioTerceirosClassOperacaoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  CollectionPedidoItemClassOperacao.Clear();
                  foreach(int item in _collectionPedidoItemClassOperacaoOriginal)
                  {
                    CollectionPedidoItemClassOperacao.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassOperacaoRemovidos.Clear();
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  CollectionPedidoItemClassOperacaoEnvioTerceiros.Clear();
                  foreach(int item in _collectionPedidoItemClassOperacaoEnvioTerceirosOriginal)
                  {
                    CollectionPedidoItemClassOperacaoEnvioTerceiros.Add(Entidades.PedidoItemClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPedidoItemClassOperacaoEnvioTerceirosRemovidos.Clear();
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  CollectionPostoTrabalhoClassOperacao.Clear();
                  foreach(int item in _collectionPostoTrabalhoClassOperacaoOriginal)
                  {
                    CollectionPostoTrabalhoClassOperacao.Add(Entidades.PostoTrabalhoClass.GetEntidade(item, UsuarioAtual, SingleConnection));
                  }
                  _collectionPostoTrabalhoClassOperacaoRemovidos.Clear();
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
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassOperacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassOperacaoChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassOperacao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOperacao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacao.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoEnvioTerceiros.Any(item => item.IsDirty());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassOperacao.Any(item => item.IsDirty());
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
       dirty = _descricaoOriginal != Descricao;
      if (dirty) return true;
       dirty = _cfopOriginal != Cfop;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginal != NaturezaOperacao;
      if (dirty) return true;
       dirty = _incideIcmsOriginal != IncideIcms;
      if (dirty) return true;
       dirty = _incideIpiOriginal != IncideIpi;
      if (dirty) return true;
       dirty = _incidePisOriginal != IncidePis;
      if (dirty) return true;
       dirty = _incideCofinsOriginal != IncideCofins;
      if (dirty) return true;
       dirty = _incideIssOriginal != IncideIss;
      if (dirty) return true;
       dirty = _validaPrecosOriginal != ValidaPrecos;
      if (dirty) return true;
       dirty = _cfopForaEstadoOriginal != CfopForaEstado;
      if (dirty) return true;
       dirty = _icmsCstSuspensoOriginal != IcmsCstSuspenso;
      if (dirty) return true;
       dirty = _ipiCstSuspensoOriginal != IpiCstSuspenso;
      if (dirty) return true;
       dirty = _pisCstSuspensoOriginal != PisCstSuspenso;
      if (dirty) return true;
       dirty = _cofinsCstSuspensoOriginal != CofinsCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialOriginal != DevolucaoMaterial;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopOriginal != DevolucaoMaterialCfop;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopForaEstadoOriginal != DevolucaoMaterialCfopForaEstado;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIcmsOriginal != DevolucaoMaterialIncideIcms;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIpiOriginal != DevolucaoMaterialIncideIpi;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncidePisOriginal != DevolucaoMaterialIncidePis;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideCofinsOriginal != DevolucaoMaterialIncideCofins;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIssOriginal != DevolucaoMaterialIncideIss;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsCstSuspensoOriginal != DevolucaoMaterialIcmsCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCstSuspensoOriginal != DevolucaoMaterialIpiCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisCstSuspensoOriginal != DevolucaoMaterialPisCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsCstSuspensoOriginal != DevolucaoMaterialCofinsCstSuspenso;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginal != Version;
      if (dirty) return true;
       dirty = _consumidorFinalOriginal != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaConsumidorOriginal != PresencaConsumidor;
      if (dirty) return true;
       dirty = _gerarContasReceberOriginal != GerarContasReceber;
      if (dirty) return true;
       dirty = _entregaFuturaOriginal != EntregaFutura;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaOriginal != EntregaFuturaCfopRemessa;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaForaEstadoOriginal != EntregaFuturaCfopRemessaForaEstado;
      if (dirty) return true;
       dirty = _entregaFuturaNaturezaOperacaoRemessaOriginal != EntregaFuturaNaturezaOperacaoRemessa;
      if (dirty) return true;
       dirty = _partilhaIcmsOriginal != PartilhaIcms;
      if (dirty) return true;
       dirty = _somaFreteBcIcmsOriginal != SomaFreteBcIcms;
      if (dirty) return true;
       dirty = _somaFreteBcIpiOriginal != SomaFreteBcIpi;
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
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  if (_valueCollectionOrcamentoItemClassOperacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  if (_valueCollectionPostoTrabalhoClassOperacaoCommitedChanged)
                  {
                     return true;
                  }
               }
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                   tempRet = CollectionOrcamentoItemClassOperacao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                   tempRet = CollectionOrdemProducaoEnvioTerceirosClassOperacao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacao.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                   tempRet = CollectionPedidoItemClassOperacaoEnvioTerceiros.Any(item => item.IsDirtyCommited());
                   if (tempRet) return true;
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                   tempRet = CollectionPostoTrabalhoClassOperacao.Any(item => item.IsDirtyCommited());
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
       dirty = _descricaoOriginalCommited != Descricao;
      if (dirty) return true;
       dirty = _cfopOriginalCommited != Cfop;
      if (dirty) return true;
       dirty = _naturezaOperacaoOriginalCommited != NaturezaOperacao;
      if (dirty) return true;
       dirty = _incideIcmsOriginalCommited != IncideIcms;
      if (dirty) return true;
       dirty = _incideIpiOriginalCommited != IncideIpi;
      if (dirty) return true;
       dirty = _incidePisOriginalCommited != IncidePis;
      if (dirty) return true;
       dirty = _incideCofinsOriginalCommited != IncideCofins;
      if (dirty) return true;
       dirty = _incideIssOriginalCommited != IncideIss;
      if (dirty) return true;
       dirty = _validaPrecosOriginalCommited != ValidaPrecos;
      if (dirty) return true;
       dirty = _cfopForaEstadoOriginalCommited != CfopForaEstado;
      if (dirty) return true;
       dirty = _icmsCstSuspensoOriginalCommited != IcmsCstSuspenso;
      if (dirty) return true;
       dirty = _ipiCstSuspensoOriginalCommited != IpiCstSuspenso;
      if (dirty) return true;
       dirty = _pisCstSuspensoOriginalCommited != PisCstSuspenso;
      if (dirty) return true;
       dirty = _cofinsCstSuspensoOriginalCommited != CofinsCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialOriginalCommited != DevolucaoMaterial;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopOriginalCommited != DevolucaoMaterialCfop;
      if (dirty) return true;
       dirty = _devolucaoMaterialCfopForaEstadoOriginalCommited != DevolucaoMaterialCfopForaEstado;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIcmsOriginalCommited != DevolucaoMaterialIncideIcms;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIpiOriginalCommited != DevolucaoMaterialIncideIpi;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncidePisOriginalCommited != DevolucaoMaterialIncidePis;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideCofinsOriginalCommited != DevolucaoMaterialIncideCofins;
      if (dirty) return true;
       dirty = _devolucaoMaterialIncideIssOriginalCommited != DevolucaoMaterialIncideIss;
      if (dirty) return true;
       dirty = _devolucaoMaterialIcmsCstSuspensoOriginalCommited != DevolucaoMaterialIcmsCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialIpiCstSuspensoOriginalCommited != DevolucaoMaterialIpiCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialPisCstSuspensoOriginalCommited != DevolucaoMaterialPisCstSuspenso;
      if (dirty) return true;
       dirty = _devolucaoMaterialCofinsCstSuspensoOriginalCommited != DevolucaoMaterialCofinsCstSuspenso;
      if (dirty) return true;
      if (dirty) return true;
      dirty =  _versionOriginalCommited != Version;
      if (dirty) return true;
       dirty = _consumidorFinalOriginalCommited != ConsumidorFinal;
      if (dirty) return true;
       dirty = _presencaConsumidorOriginalCommited != PresencaConsumidor;
      if (dirty) return true;
       dirty = _gerarContasReceberOriginalCommited != GerarContasReceber;
      if (dirty) return true;
       dirty = _entregaFuturaOriginalCommited != EntregaFutura;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaOriginalCommited != EntregaFuturaCfopRemessa;
      if (dirty) return true;
       dirty = _entregaFuturaCfopRemessaForaEstadoOriginalCommited != EntregaFuturaCfopRemessaForaEstado;
      if (dirty) return true;
       dirty = _entregaFuturaNaturezaOperacaoRemessaOriginalCommited != EntregaFuturaNaturezaOperacaoRemessa;
      if (dirty) return true;
       dirty = _partilhaIcmsOriginalCommited != PartilhaIcms;
      if (dirty) return true;
       dirty = _somaFreteBcIcmsOriginalCommited != SomaFreteBcIcms;
      if (dirty) return true;
       dirty = _somaFreteBcIpiOriginalCommited != SomaFreteBcIpi;
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
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassOperacao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOperacao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacao)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoEnvioTerceiros)
                  {
                     item.Save(ref command, propagado:true);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassOperacao)
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
             case "Descricao":
                return this.Descricao;
             case "Cfop":
                return this.Cfop;
             case "NaturezaOperacao":
                return this.NaturezaOperacao;
             case "IncideIcms":
                return this.IncideIcms;
             case "IncideIpi":
                return this.IncideIpi;
             case "IncidePis":
                return this.IncidePis;
             case "IncideCofins":
                return this.IncideCofins;
             case "IncideIss":
                return this.IncideIss;
             case "ValidaPrecos":
                return this.ValidaPrecos;
             case "CfopForaEstado":
                return this.CfopForaEstado;
             case "IcmsCstSuspenso":
                return this.IcmsCstSuspenso;
             case "IpiCstSuspenso":
                return this.IpiCstSuspenso;
             case "PisCstSuspenso":
                return this.PisCstSuspenso;
             case "CofinsCstSuspenso":
                return this.CofinsCstSuspenso;
             case "DevolucaoMaterial":
                return this.DevolucaoMaterial;
             case "DevolucaoMaterialCfop":
                return this.DevolucaoMaterialCfop;
             case "DevolucaoMaterialCfopForaEstado":
                return this.DevolucaoMaterialCfopForaEstado;
             case "DevolucaoMaterialIncideIcms":
                return this.DevolucaoMaterialIncideIcms;
             case "DevolucaoMaterialIncideIpi":
                return this.DevolucaoMaterialIncideIpi;
             case "DevolucaoMaterialIncidePis":
                return this.DevolucaoMaterialIncidePis;
             case "DevolucaoMaterialIncideCofins":
                return this.DevolucaoMaterialIncideCofins;
             case "DevolucaoMaterialIncideIss":
                return this.DevolucaoMaterialIncideIss;
             case "DevolucaoMaterialIcmsCstSuspenso":
                return this.DevolucaoMaterialIcmsCstSuspenso;
             case "DevolucaoMaterialIpiCstSuspenso":
                return this.DevolucaoMaterialIpiCstSuspenso;
             case "DevolucaoMaterialPisCstSuspenso":
                return this.DevolucaoMaterialPisCstSuspenso;
             case "DevolucaoMaterialCofinsCstSuspenso":
                return this.DevolucaoMaterialCofinsCstSuspenso;
             case "EntityUid":
                return this.EntityUid;
             case "Version":
                return this.Version;
             case "ConsumidorFinal":
                return this.ConsumidorFinal;
             case "PresencaConsumidor":
                return this.PresencaConsumidor;
             case "GerarContasReceber":
                return this.GerarContasReceber;
             case "EntregaFutura":
                return this.EntregaFutura;
             case "EntregaFuturaCfopRemessa":
                return this.EntregaFuturaCfopRemessa;
             case "EntregaFuturaCfopRemessaForaEstado":
                return this.EntregaFuturaCfopRemessaForaEstado;
             case "EntregaFuturaNaturezaOperacaoRemessa":
                return this.EntregaFuturaNaturezaOperacaoRemessa;
             case "PartilhaIcms":
                return this.PartilhaIcms;
             case "SomaFreteBcIcms":
                return this.SomaFreteBcIcms;
             case "SomaFreteBcIpi":
                return this.SomaFreteBcIpi;
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
               if (_valueCollectionOrcamentoItemClassOperacaoLoaded) 
               {
                  foreach(OrcamentoItemClass item in CollectionOrcamentoItemClassOperacao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionOrdemProducaoEnvioTerceirosClassOperacaoLoaded) 
               {
                  foreach(OrdemProducaoEnvioTerceirosClass item in CollectionOrdemProducaoEnvioTerceirosClassOperacao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacao)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPedidoItemClassOperacaoEnvioTerceirosLoaded) 
               {
                  foreach(PedidoItemClass item in CollectionPedidoItemClassOperacaoEnvioTerceiros)
                  {
                     item.ChangeSingleConnection(newConnection);
                  }
               }
               if (_valueCollectionPostoTrabalhoClassOperacaoLoaded) 
               {
                  foreach(PostoTrabalhoClass item in CollectionPostoTrabalhoClassOperacao)
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
                  command.CommandText += " COUNT(operacao.id_operacao) " ;
               }
               else
               {
               command.CommandText += "operacao.id_operacao, " ;
               command.CommandText += "operacao.ope_descricao, " ;
               command.CommandText += "operacao.ope_cfop, " ;
               command.CommandText += "operacao.ope_natureza_operacao, " ;
               command.CommandText += "operacao.ope_incide_icms, " ;
               command.CommandText += "operacao.ope_incide_ipi, " ;
               command.CommandText += "operacao.ope_incide_pis, " ;
               command.CommandText += "operacao.ope_incide_cofins, " ;
               command.CommandText += "operacao.ope_incide_iss, " ;
               command.CommandText += "operacao.ope_valida_precos, " ;
               command.CommandText += "operacao.ope_cfop_fora_estado, " ;
               command.CommandText += "operacao.ope_icms_cst_suspenso, " ;
               command.CommandText += "operacao.ope_ipi_cst_suspenso, " ;
               command.CommandText += "operacao.ope_pis_cst_suspenso, " ;
               command.CommandText += "operacao.ope_cofins_cst_suspenso, " ;
               command.CommandText += "operacao.ope_devolucao_material, " ;
               command.CommandText += "operacao.ope_devolucao_material_cfop, " ;
               command.CommandText += "operacao.ope_devolucao_material_cfop_fora_estado, " ;
               command.CommandText += "operacao.ope_devolucao_material_incide_icms, " ;
               command.CommandText += "operacao.ope_devolucao_material_incide_ipi, " ;
               command.CommandText += "operacao.ope_devolucao_material_incide_pis, " ;
               command.CommandText += "operacao.ope_devolucao_material_incide_cofins, " ;
               command.CommandText += "operacao.ope_devolucao_material_incide_iss, " ;
               command.CommandText += "operacao.ope_devolucao_material_icms_cst_suspenso, " ;
               command.CommandText += "operacao.ope_devolucao_material_ipi_cst_suspenso, " ;
               command.CommandText += "operacao.ope_devolucao_material_pis_cst_suspenso, " ;
               command.CommandText += "operacao.ope_devolucao_material_cofins_cst_suspenso, " ;
               command.CommandText += "operacao.entity_uid, " ;
               command.CommandText += "operacao.version, " ;
               command.CommandText += "operacao.ope_consumidor_final, " ;
               command.CommandText += "operacao.ope_presenca_consumidor, " ;
               command.CommandText += "operacao.ope_gerar_contas_receber, " ;
               command.CommandText += "operacao.ope_entrega_futura, " ;
               command.CommandText += "operacao.ope_entrega_futura_cfop_remessa, " ;
               command.CommandText += "operacao.ope_entrega_futura_cfop_remessa_fora_estado, " ;
               command.CommandText += "operacao.ope_entrega_futura_natureza_operacao_remessa, " ;
               command.CommandText += "operacao.ope_partilha_icms, " ;
               command.CommandText += "operacao.ope_soma_frete_bc_icms, " ;
               command.CommandText += "operacao.ope_soma_frete_bc_ipi, " ;
               command.CommandText += "operacao.ope_devolucao_material_separada, " ;
               command.CommandText += "operacao.ope_devolucao_material_separada_natueza_operacao, " ;
               command.CommandText += "operacao.ope_pis_descontar_icms_bc, " ;
               command.CommandText += "operacao.ope_cofins_descontar_icms_bc " ;
               }
               command.CommandText += " FROM  operacao ";
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
                        orderByClause += " , ope_ultima_revisao_data " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisao")
                     {
                        orderByClause += " , UPPER(ope_ultima_revisao) " + parametro.Ordenacao.ToString();
                        continue;
                     }
                     if (parametro.FieldName == "UltimaRevisaoUsuario")
                     {
                        orderByClause += " , usu_rev_auto.aus_login " + parametro.Ordenacao.ToString();
                        command.CommandText += " LEFT JOIN acs_usuario usu_rev_auto ON usu_rev_auto.id_acs_usuario = operacao.id_acs_usuario_ultima_revisao ";
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
                     case "id_operacao":
                     case "ID":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.id_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.id_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_descricao":
                     case "Descricao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_descricao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_descricao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_cfop":
                     case "Cfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_natureza_operacao":
                     case "NaturezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_natureza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_natureza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_incide_icms":
                     case "IncideIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_incide_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_incide_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_incide_ipi":
                     case "IncideIpi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_incide_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_incide_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_incide_pis":
                     case "IncidePis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_incide_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_incide_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_incide_cofins":
                     case "IncideCofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_incide_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_incide_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_incide_iss":
                     case "IncideIss":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_incide_iss " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_incide_iss) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_valida_precos":
                     case "ValidaPrecos":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_valida_precos " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_valida_precos) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_cfop_fora_estado":
                     case "CfopForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_cfop_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_cfop_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_icms_cst_suspenso":
                     case "IcmsCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_icms_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_icms_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_ipi_cst_suspenso":
                     case "IpiCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_ipi_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_ipi_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_pis_cst_suspenso":
                     case "PisCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_pis_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_pis_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_cofins_cst_suspenso":
                     case "CofinsCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_cofins_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_cofins_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material":
                     case "DevolucaoMaterial":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_cfop":
                     case "DevolucaoMaterialCfop":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_cfop " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_cfop) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_cfop_fora_estado":
                     case "DevolucaoMaterialCfopForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_cfop_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_cfop_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_incide_icms":
                     case "DevolucaoMaterialIncideIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_incide_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_incide_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_incide_ipi":
                     case "DevolucaoMaterialIncideIpi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_incide_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_incide_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_incide_pis":
                     case "DevolucaoMaterialIncidePis":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_incide_pis " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_incide_pis) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_incide_cofins":
                     case "DevolucaoMaterialIncideCofins":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_incide_cofins " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_incide_cofins) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_incide_iss":
                     case "DevolucaoMaterialIncideIss":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_incide_iss " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_incide_iss) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_icms_cst_suspenso":
                     case "DevolucaoMaterialIcmsCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_devolucao_material_icms_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_icms_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_ipi_cst_suspenso":
                     case "DevolucaoMaterialIpiCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_devolucao_material_ipi_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_ipi_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_pis_cst_suspenso":
                     case "DevolucaoMaterialPisCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_devolucao_material_pis_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_pis_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_cofins_cst_suspenso":
                     case "DevolucaoMaterialCofinsCstSuspenso":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_devolucao_material_cofins_cst_suspenso " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_cofins_cst_suspenso) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "entity_uid":
                     case "EntityUid":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.entity_uid " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.entity_uid) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                           orderByClause += " , operacao.version " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.version) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_consumidor_final":
                     case "ConsumidorFinal":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_consumidor_final " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_consumidor_final) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_presenca_consumidor":
                     case "PresencaConsumidor":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_presenca_consumidor " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_presenca_consumidor) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_gerar_contas_receber":
                     case "GerarContasReceber":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_gerar_contas_receber " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_gerar_contas_receber) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_entrega_futura":
                     case "EntregaFutura":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_entrega_futura " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_entrega_futura) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_entrega_futura_cfop_remessa":
                     case "EntregaFuturaCfopRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_entrega_futura_cfop_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_entrega_futura_cfop_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_entrega_futura_cfop_remessa_fora_estado":
                     case "EntregaFuturaCfopRemessaForaEstado":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_entrega_futura_cfop_remessa_fora_estado " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_entrega_futura_cfop_remessa_fora_estado) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_entrega_futura_natureza_operacao_remessa":
                     case "EntregaFuturaNaturezaOperacaoRemessa":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_entrega_futura_natureza_operacao_remessa " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_entrega_futura_natureza_operacao_remessa) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_partilha_icms":
                     case "PartilhaIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_partilha_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_partilha_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_soma_frete_bc_icms":
                     case "SomaFreteBcIcms":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_soma_frete_bc_icms " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_soma_frete_bc_icms) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_soma_frete_bc_ipi":
                     case "SomaFreteBcIpi":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_soma_frete_bc_ipi " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_soma_frete_bc_ipi) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_separada":
                     case "DevolucaoMaterialSeparada":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_devolucao_material_separada " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_separada) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_devolucao_material_separada_natueza_operacao":
                     case "DevolucaoMaterialSeparadaNatuezaOperacao":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                           orderByClause += " , operacao.ope_devolucao_material_separada_natueza_operacao " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , UPPER(operacao.ope_devolucao_material_separada_natueza_operacao) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_pis_descontar_icms_bc":
                     case "PisDescontarIcmsBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_pis_descontar_icms_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_pis_descontar_icms_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                     }
                     break;
                     case "ope_cofins_descontar_icms_bc":
                     case "CofinsDescontarIcmsBc":
                     switch (parametro.TipoOrdenacao)
                     {
                        case TipoOrdenacao.Numerica:
                        case TipoOrdenacao.Data:
                        case TipoOrdenacao.Automatica:
                           orderByClause += " , operacao.ope_cofins_descontar_icms_bc " + parametro.Ordenacao.ToString().ToUpper(); 
                           break;
                        case TipoOrdenacao.String:
                           orderByClause += " , UPPER(operacao.ope_cofins_descontar_icms_bc) " + parametro.Ordenacao.ToString().ToUpper(); 
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
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_descricao")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_descricao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_descricao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_natureza_operacao")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_natureza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_natureza_operacao) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_icms_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_icms_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_icms_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_ipi_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_ipi_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_ipi_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_pis_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_pis_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_pis_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_cofins_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_cofins_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_cofins_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_devolucao_material_icms_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_devolucao_material_icms_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_devolucao_material_icms_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_devolucao_material_ipi_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_devolucao_material_ipi_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_devolucao_material_ipi_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_devolucao_material_pis_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_devolucao_material_pis_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_devolucao_material_pis_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_devolucao_material_cofins_cst_suspenso")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_devolucao_material_cofins_cst_suspenso) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_devolucao_material_cofins_cst_suspenso) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("entity_uid")) 
                        {
                           whereClause += " OR UPPER(operacao.entity_uid) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.entity_uid) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_entrega_futura_natureza_operacao_remessa")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_entrega_futura_natureza_operacao_remessa) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_entrega_futura_natureza_operacao_remessa) LIKE :buscaCompletaLower ";
                        }
                        if (!CamposNaoIncluirBuscaCompleta.Contains("ope_devolucao_material_separada_natueza_operacao")) 
                        {
                           whereClause += " OR UPPER(operacao.ope_devolucao_material_separada_natueza_operacao) LIKE :buscaCompletaUpper ";
                           whereClause += " OR LOWER(operacao.ope_devolucao_material_separada_natueza_operacao) LIKE :buscaCompletaLower ";
                        }
                        whereClause += ") ";
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaUpper", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToUpper() + "%"));
                        command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("buscaCompletaLower", NpgsqlDbType.Varchar, "%" + parametro.Fieldvalue.ToString().ToLower() + "%"));
                        continue;
                     }
                     if (parametro.FieldName == "ID" || parametro.FieldName == "id_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is long)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo long");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.id_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.id_operacao = :operacao_ID_4187 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_ID_4187", NpgsqlDbType.Bigint, parametro.Fieldvalue));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Descricao" || parametro.FieldName == "ope_descricao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_descricao LIKE :operacao_Descricao_159 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_Descricao_159", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "Cfop" || parametro.FieldName == "ope_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_cfop = :operacao_Cfop_9950 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_Cfop_9950", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "NaturezaOperacao" || parametro.FieldName == "ope_natureza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_natureza_operacao LIKE :operacao_NaturezaOperacao_2449 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_NaturezaOperacao_2449", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IncideIcms" || parametro.FieldName == "ope_incide_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_incide_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_incide_icms = :operacao_IncideIcms_162 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IncideIcms_162", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IncideIpi" || parametro.FieldName == "ope_incide_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_incide_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_incide_ipi = :operacao_IncideIpi_6885 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IncideIpi_6885", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IncidePis" || parametro.FieldName == "ope_incide_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_incide_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_incide_pis = :operacao_IncidePis_2644 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IncidePis_2644", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IncideCofins" || parametro.FieldName == "ope_incide_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_incide_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_incide_cofins = :operacao_IncideCofins_7865 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IncideCofins_7865", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IncideIss" || parametro.FieldName == "ope_incide_iss")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_incide_iss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_incide_iss = :operacao_IncideIss_95 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IncideIss_95", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ValidaPrecos" || parametro.FieldName == "ope_valida_precos")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is EasiValidaPrecos)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo EasiValidaPrecos");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_valida_precos IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_valida_precos = :operacao_ValidaPrecos_9091 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_ValidaPrecos_9091", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CfopForaEstado" || parametro.FieldName == "ope_cfop_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_cfop_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_cfop_fora_estado = :operacao_CfopForaEstado_5844 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_CfopForaEstado_5844", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsCstSuspenso" || parametro.FieldName == "ope_icms_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_icms_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_icms_cst_suspenso LIKE :operacao_IcmsCstSuspenso_5127 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IcmsCstSuspenso_5127", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCstSuspenso" || parametro.FieldName == "ope_ipi_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_ipi_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_ipi_cst_suspenso LIKE :operacao_IpiCstSuspenso_9129 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IpiCstSuspenso_9129", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCstSuspenso" || parametro.FieldName == "ope_pis_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_pis_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_pis_cst_suspenso LIKE :operacao_PisCstSuspenso_8417 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_PisCstSuspenso_8417", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCstSuspenso" || parametro.FieldName == "ope_cofins_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_cofins_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_cofins_cst_suspenso LIKE :operacao_CofinsCstSuspenso_6170 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_CofinsCstSuspenso_6170", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterial" || parametro.FieldName == "ope_devolucao_material")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material = :operacao_DevolucaoMaterial_5120 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterial_5120", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCfop" || parametro.FieldName == "ope_devolucao_material_cfop")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_cfop IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_cfop = :operacao_DevolucaoMaterialCfop_8429 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialCfop_8429", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCfopForaEstado" || parametro.FieldName == "ope_devolucao_material_cfop_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_cfop_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_cfop_fora_estado = :operacao_DevolucaoMaterialCfopForaEstado_9965 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialCfopForaEstado_9965", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIncideIcms" || parametro.FieldName == "ope_devolucao_material_incide_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_icms = :operacao_DevolucaoMaterialIncideIcms_8976 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIncideIcms_8976", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIncideIpi" || parametro.FieldName == "ope_devolucao_material_incide_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_ipi = :operacao_DevolucaoMaterialIncideIpi_1888 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIncideIpi_1888", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIncidePis" || parametro.FieldName == "ope_devolucao_material_incide_pis")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_pis IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_pis = :operacao_DevolucaoMaterialIncidePis_7775 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIncidePis_7775", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIncideCofins" || parametro.FieldName == "ope_devolucao_material_incide_cofins")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_cofins IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_cofins = :operacao_DevolucaoMaterialIncideCofins_2012 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIncideCofins_2012", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIncideIss" || parametro.FieldName == "ope_devolucao_material_incide_iss")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is IncidenciaImposto?)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo IncidenciaImposto?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_iss IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_incide_iss = :operacao_DevolucaoMaterialIncideIss_9855 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIncideIss_9855", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsCstSuspenso" || parametro.FieldName == "ope_devolucao_material_icms_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_icms_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_icms_cst_suspenso LIKE :operacao_DevolucaoMaterialIcmsCstSuspenso_8999 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIcmsCstSuspenso_8999", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCstSuspenso" || parametro.FieldName == "ope_devolucao_material_ipi_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_ipi_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_ipi_cst_suspenso LIKE :operacao_DevolucaoMaterialIpiCstSuspenso_4385 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIpiCstSuspenso_4385", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisCstSuspenso" || parametro.FieldName == "ope_devolucao_material_pis_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_pis_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_pis_cst_suspenso LIKE :operacao_DevolucaoMaterialPisCstSuspenso_2002 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialPisCstSuspenso_2002", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsCstSuspenso" || parametro.FieldName == "ope_devolucao_material_cofins_cst_suspenso")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_cofins_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_cofins_cst_suspenso LIKE :operacao_DevolucaoMaterialCofinsCstSuspenso_9789 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialCofinsCstSuspenso_9789", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  operacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.entity_uid LIKE :operacao_EntityUid_3321 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntityUid_3321", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
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
                         whereClause += "  operacao.version IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.version = :operacao_Version_5260 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_Version_5260", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "ConsumidorFinal" || parametro.FieldName == "ope_consumidor_final")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_consumidor_final IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_consumidor_final = :operacao_ConsumidorFinal_5429 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_ConsumidorFinal_5429", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PresencaConsumidor" || parametro.FieldName == "ope_presenca_consumidor")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is PresencaComprador)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo PresencaComprador");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_presenca_consumidor IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_presenca_consumidor = :operacao_PresencaConsumidor_3828 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_PresencaConsumidor_3828", NpgsqlDbType.Smallint,  Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "GerarContasReceber" || parametro.FieldName == "ope_gerar_contas_receber")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_gerar_contas_receber IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_gerar_contas_receber = :operacao_GerarContasReceber_4387 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_GerarContasReceber_4387", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFutura" || parametro.FieldName == "ope_entrega_futura")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_entrega_futura IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_entrega_futura = :operacao_EntregaFutura_4782 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntregaFutura_4782", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaCfopRemessa" || parametro.FieldName == "ope_entrega_futura_cfop_remessa")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_entrega_futura_cfop_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_entrega_futura_cfop_remessa = :operacao_EntregaFuturaCfopRemessa_8627 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntregaFuturaCfopRemessa_8627", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaCfopRemessaForaEstado" || parametro.FieldName == "ope_entrega_futura_cfop_remessa_fora_estado")
                     {
                      if (parametro.Fieldvalue != null && !((parametro.Fieldvalue is int)||(parametro.Fieldvalue is long)||(parametro.Fieldvalue is decimal)||(parametro.Fieldvalue is double)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo int?");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_entrega_futura_cfop_remessa_fora_estado IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_entrega_futura_cfop_remessa_fora_estado = :operacao_EntregaFuturaCfopRemessaForaEstado_4739 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntregaFuturaCfopRemessaForaEstado_4739", NpgsqlDbType.Integer, Convert.ToInt32(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "EntregaFuturaNaturezaOperacaoRemessa" || parametro.FieldName == "ope_entrega_futura_natureza_operacao_remessa")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_entrega_futura_natureza_operacao_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_entrega_futura_natureza_operacao_remessa LIKE :operacao_EntregaFuturaNaturezaOperacaoRemessa_6451 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntregaFuturaNaturezaOperacaoRemessa_6451", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PartilhaIcms" || parametro.FieldName == "ope_partilha_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_partilha_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_partilha_icms = :operacao_PartilhaIcms_3372 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_PartilhaIcms_3372", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SomaFreteBcIcms" || parametro.FieldName == "ope_soma_frete_bc_icms")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_soma_frete_bc_icms IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_soma_frete_bc_icms = :operacao_SomaFreteBcIcms_5189 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_SomaFreteBcIcms_5189", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "SomaFreteBcIpi" || parametro.FieldName == "ope_soma_frete_bc_ipi")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_soma_frete_bc_ipi IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_soma_frete_bc_ipi = :operacao_SomaFreteBcIpi_9096 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_SomaFreteBcIpi_9096", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialSeparada" || parametro.FieldName == "ope_devolucao_material_separada")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_separada IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_separada = :operacao_DevolucaoMaterialSeparada_5565 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialSeparada_5565", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialSeparadaNatuezaOperacao" || parametro.FieldName == "ope_devolucao_material_separada_natueza_operacao")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_separada_natueza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_separada_natueza_operacao LIKE :operacao_DevolucaoMaterialSeparadaNatuezaOperacao_2881 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialSeparadaNatuezaOperacao_2881", NpgsqlDbType.Varchar,"%"+ parametro.Fieldvalue+"%"));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisDescontarIcmsBc" || parametro.FieldName == "ope_pis_descontar_icms_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_pis_descontar_icms_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_pis_descontar_icms_bc = :operacao_PisDescontarIcmsBc_6385 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_PisDescontarIcmsBc_6385", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsDescontarIcmsBc" || parametro.FieldName == "ope_cofins_descontar_icms_bc")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is bool)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo bool");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_cofins_descontar_icms_bc IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_cofins_descontar_icms_bc = :operacao_CofinsDescontarIcmsBc_4392 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_CofinsDescontarIcmsBc_4392", NpgsqlDbType.Smallint, Convert.ToInt16(parametro.Fieldvalue)));
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
                         whereClause += "  operacao.ope_descricao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_descricao LIKE :operacao_Descricao_3631 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_Descricao_3631", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  operacao.ope_natureza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_natureza_operacao LIKE :operacao_NaturezaOperacao_5474 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_NaturezaOperacao_5474", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IcmsCstSuspensoExato" || parametro.FieldName == "IcmsCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_icms_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_icms_cst_suspenso LIKE :operacao_IcmsCstSuspenso_1983 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IcmsCstSuspenso_1983", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "IpiCstSuspensoExato" || parametro.FieldName == "IpiCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_ipi_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_ipi_cst_suspenso LIKE :operacao_IpiCstSuspenso_2646 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_IpiCstSuspenso_2646", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "PisCstSuspensoExato" || parametro.FieldName == "PisCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_pis_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_pis_cst_suspenso LIKE :operacao_PisCstSuspenso_6745 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_PisCstSuspenso_6745", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "CofinsCstSuspensoExato" || parametro.FieldName == "CofinsCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_cofins_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_cofins_cst_suspenso LIKE :operacao_CofinsCstSuspenso_2616 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_CofinsCstSuspenso_2616", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIcmsCstSuspensoExato" || parametro.FieldName == "DevolucaoMaterialIcmsCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_icms_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_icms_cst_suspenso LIKE :operacao_DevolucaoMaterialIcmsCstSuspenso_3306 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIcmsCstSuspenso_3306", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialIpiCstSuspensoExato" || parametro.FieldName == "DevolucaoMaterialIpiCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_ipi_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_ipi_cst_suspenso LIKE :operacao_DevolucaoMaterialIpiCstSuspenso_9271 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialIpiCstSuspenso_9271", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialPisCstSuspensoExato" || parametro.FieldName == "DevolucaoMaterialPisCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_pis_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_pis_cst_suspenso LIKE :operacao_DevolucaoMaterialPisCstSuspenso_3361 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialPisCstSuspenso_3361", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
                      }
                      whereClause += " ) " ;
                        continue;
                     }
                     if (parametro.FieldName == "DevolucaoMaterialCofinsCstSuspensoExato" || parametro.FieldName == "DevolucaoMaterialCofinsCstSuspensoExata")
                     {
                      if (parametro.Fieldvalue != null && (!(parametro.Fieldvalue is string)))
                      {
                         throw new ExcecaoTratada("O parâmetro " + parametro.FieldName + " fornecido não é do tipo string");
                      }
                      whereClause += " " + (utilizarOr ? "  OR " : " AND ") + "(" ;
                      if (parametro.Fieldvalue == null)
                      {
                         whereClause += "  operacao.ope_devolucao_material_cofins_cst_suspenso IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_cofins_cst_suspenso LIKE :operacao_DevolucaoMaterialCofinsCstSuspenso_3461 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialCofinsCstSuspenso_3461", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  operacao.entity_uid IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.entity_uid LIKE :operacao_EntityUid_1099 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntityUid_1099", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  operacao.ope_entrega_futura_natureza_operacao_remessa IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_entrega_futura_natureza_operacao_remessa LIKE :operacao_EntregaFuturaNaturezaOperacaoRemessa_5107 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_EntregaFuturaNaturezaOperacaoRemessa_5107", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                         whereClause += "  operacao.ope_devolucao_material_separada_natueza_operacao IS NULL" ;
                      }
                      else
                      {
                         whereClause += "  operacao.ope_devolucao_material_separada_natueza_operacao LIKE :operacao_DevolucaoMaterialSeparadaNatuezaOperacao_2175 " ;
                         command.Parameters.Add(new IWTPostgreNpgsqlCommandParameter("operacao_DevolucaoMaterialSeparadaNatuezaOperacao_2175", NpgsqlDbType.Varchar,""+ parametro.Fieldvalue+""));
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
                  OperacaoClass entidade = null;
if (!operacao.HasValue)
{
    operacao = Guid.NewGuid();
}
                  if (utilizarBuffer) 
                  {
                     entidade = (OperacaoClass)BufferAbstractEntity.GetEntidadeSemCarregamento(typeof(OperacaoClass), Convert.ToInt32(read["id_operacao"]), UsuarioAtual, command.Connection, this.BufferSecundario, operacao.Value);
                  }
                  if (entidade == null)
                  {
                     entidade = new OperacaoClass(UsuarioAtual, SingleConnection);
                     entidade.BufferSecundario = this.BufferSecundario;
                     entidade.loading = true;
                     entidade.ID = Convert.ToInt64(read["id_operacao"]);
                     entidade.Descricao = (read["ope_descricao"] != DBNull.Value ? read["ope_descricao"].ToString() : null);
                     entidade.Cfop = (int)read["ope_cfop"];
                     entidade.NaturezaOperacao = (read["ope_natureza_operacao"] != DBNull.Value ? read["ope_natureza_operacao"].ToString() : null);
                     entidade.IncideIcms = (IncidenciaImposto) (read["ope_incide_icms"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["ope_incide_icms"]) : null);
                     entidade.IncideIpi = (IncidenciaImposto) (read["ope_incide_ipi"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["ope_incide_ipi"]) : null);
                     entidade.IncidePis = (IncidenciaImposto) (read["ope_incide_pis"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["ope_incide_pis"]) : null);
                     entidade.IncideCofins = (IncidenciaImposto) (read["ope_incide_cofins"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["ope_incide_cofins"]) : null);
                     entidade.IncideIss = (IncidenciaImposto) (read["ope_incide_iss"] != DBNull.Value ? Enum.ToObject(typeof(IncidenciaImposto), read["ope_incide_iss"]) : null);
                     entidade.ValidaPrecos = (EasiValidaPrecos) (read["ope_valida_precos"] != DBNull.Value ? Enum.ToObject(typeof(EasiValidaPrecos), read["ope_valida_precos"]) : null);
                     entidade.CfopForaEstado = (int)read["ope_cfop_fora_estado"];
                     entidade.IcmsCstSuspenso = (read["ope_icms_cst_suspenso"] != DBNull.Value ? read["ope_icms_cst_suspenso"].ToString() : null);
                     entidade.IpiCstSuspenso = (read["ope_ipi_cst_suspenso"] != DBNull.Value ? read["ope_ipi_cst_suspenso"].ToString() : null);
                     entidade.PisCstSuspenso = (read["ope_pis_cst_suspenso"] != DBNull.Value ? read["ope_pis_cst_suspenso"].ToString() : null);
                     entidade.CofinsCstSuspenso = (read["ope_cofins_cst_suspenso"] != DBNull.Value ? read["ope_cofins_cst_suspenso"].ToString() : null);
                     entidade.DevolucaoMaterial = Convert.ToBoolean(Convert.ToInt16(read["ope_devolucao_material"]));
                     entidade.DevolucaoMaterialCfop = read["ope_devolucao_material_cfop"] as int?;
                     entidade.DevolucaoMaterialCfopForaEstado = read["ope_devolucao_material_cfop_fora_estado"] as int?;
                     entidade.DevolucaoMaterialIncideIcms = (IncidenciaImposto?) (read["ope_devolucao_material_incide_icms"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["ope_devolucao_material_incide_icms"]) : null);
                     entidade.DevolucaoMaterialIncideIpi = (IncidenciaImposto?) (read["ope_devolucao_material_incide_ipi"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["ope_devolucao_material_incide_ipi"]) : null);
                     entidade.DevolucaoMaterialIncidePis = (IncidenciaImposto?) (read["ope_devolucao_material_incide_pis"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["ope_devolucao_material_incide_pis"]) : null);
                     entidade.DevolucaoMaterialIncideCofins = (IncidenciaImposto?) (read["ope_devolucao_material_incide_cofins"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["ope_devolucao_material_incide_cofins"]) : null);
                     entidade.DevolucaoMaterialIncideIss = (IncidenciaImposto?) (read["ope_devolucao_material_incide_iss"] != DBNull.Value ? Enum.ToObject(Nullable.GetUnderlyingType(typeof(IncidenciaImposto?)), read["ope_devolucao_material_incide_iss"]) : null);
                     entidade.DevolucaoMaterialIcmsCstSuspenso = (read["ope_devolucao_material_icms_cst_suspenso"] != DBNull.Value ? read["ope_devolucao_material_icms_cst_suspenso"].ToString() : null);
                     entidade.DevolucaoMaterialIpiCstSuspenso = (read["ope_devolucao_material_ipi_cst_suspenso"] != DBNull.Value ? read["ope_devolucao_material_ipi_cst_suspenso"].ToString() : null);
                     entidade.DevolucaoMaterialPisCstSuspenso = (read["ope_devolucao_material_pis_cst_suspenso"] != DBNull.Value ? read["ope_devolucao_material_pis_cst_suspenso"].ToString() : null);
                     entidade.DevolucaoMaterialCofinsCstSuspenso = (read["ope_devolucao_material_cofins_cst_suspenso"] != DBNull.Value ? read["ope_devolucao_material_cofins_cst_suspenso"].ToString() : null);
                     entidade.EntityUid = (read["entity_uid"] != DBNull.Value ? read["entity_uid"].ToString() : null);
                     entidade.Version = (int)read["version"];
                     entidade.ConsumidorFinal = Convert.ToBoolean(Convert.ToInt16(read["ope_consumidor_final"]));
                     entidade.PresencaConsumidor = (PresencaComprador) (read["ope_presenca_consumidor"] != DBNull.Value ? Enum.ToObject(typeof(PresencaComprador), read["ope_presenca_consumidor"]) : null);
                     entidade.GerarContasReceber = Convert.ToBoolean(Convert.ToInt16(read["ope_gerar_contas_receber"]));
                     entidade.EntregaFutura = Convert.ToBoolean(Convert.ToInt16(read["ope_entrega_futura"]));
                     entidade.EntregaFuturaCfopRemessa = read["ope_entrega_futura_cfop_remessa"] as int?;
                     entidade.EntregaFuturaCfopRemessaForaEstado = read["ope_entrega_futura_cfop_remessa_fora_estado"] as int?;
                     entidade.EntregaFuturaNaturezaOperacaoRemessa = (read["ope_entrega_futura_natureza_operacao_remessa"] != DBNull.Value ? read["ope_entrega_futura_natureza_operacao_remessa"].ToString() : null);
                     entidade.PartilhaIcms = Convert.ToBoolean(Convert.ToInt16(read["ope_partilha_icms"]));
                     entidade.SomaFreteBcIcms = Convert.ToBoolean(Convert.ToInt16(read["ope_soma_frete_bc_icms"]));
                     entidade.SomaFreteBcIpi = Convert.ToBoolean(Convert.ToInt16(read["ope_soma_frete_bc_ipi"]));
                     entidade.DevolucaoMaterialSeparada = Convert.ToBoolean(Convert.ToInt16(read["ope_devolucao_material_separada"]));
                     entidade.DevolucaoMaterialSeparadaNatuezaOperacao = (read["ope_devolucao_material_separada_natueza_operacao"] != DBNull.Value ? read["ope_devolucao_material_separada_natueza_operacao"].ToString() : null);
                     entidade.PisDescontarIcmsBc = Convert.ToBoolean(Convert.ToInt16(read["ope_pis_descontar_icms_bc"]));
                     entidade.CofinsDescontarIcmsBc = Convert.ToBoolean(Convert.ToInt16(read["ope_cofins_descontar_icms_bc"]));
                     entidade.loading = false;
                     entidade.SalvaValoresOriginais();
                     entidade.CarregamentoConcluido();
                     entidade = (OperacaoClass) BufferAbstractEntity.SetEntidadeBuffer(entidade); 
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
